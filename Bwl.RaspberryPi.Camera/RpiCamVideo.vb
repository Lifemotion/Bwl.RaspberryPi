Imports System.Diagnostics
Imports System.IO
Imports System.Threading

Public Class RpiCamVideo
    Implements IDisposable
    Implements IRpiCam

    Public Event FrameReady(source As IRpiCam) Implements IRpiCam.FrameReady

    Private _frameCounter As Long
    Public ReadOnly Property FrameCounter As Long Implements IRpiCam.FrameCounter
        Get
            Return Interlocked.Read(_frameCounter)
        End Get
    End Property

    Private _restartCounter As Integer
    Public ReadOnly Property RestartCounter As Integer Implements IRpiCam.RestartCounter
        Get
            Return Interlocked.Read(_restartCounter)
        End Get
    End Property
    Public ReadOnly Property CameraParameters As New CameraParameters Implements IRpiCam.CameraParameters
    Public ReadOnly Property FrameBytesSynclock As New Object Implements IRpiCam.FrameBytesSynclock
    Public ReadOnly Property FrameBytesBuffer As Byte() = New Byte(1024 * 512) {} Implements IRpiCam.FrameBytesBuffer
    Public ReadOnly Property FrameBytesFormat As RpiCamFrameType = RpiCamFrameType.jpg Implements IRpiCam.FrameBytesFormat
    Public ReadOnly Property FrameBytesLength As Integer Implements IRpiCam.FrameBytesLength

    Private _prc As Process
    Private _readBuffer As Byte() = New Byte(1024 * 8) {}
    Private _readThread As Threading.Thread
    Private _currentFrameBuffer As Byte() = New Byte(1024 * 512) {}

    Public Sub New()
    End Sub

    Public ReadOnly Property LastCamOpenTime As DateTime

    Public Sub Open() Implements IRpiCam.Open
        _LastCamOpenTime = Now

        Close()

        Thread.Sleep(2000)

        If System.Environment.OSVersion.Platform = PlatformID.Unix Then
            _prc = New Process
            _prc.StartInfo.FileName = "raspivid"
            Dim args = "-cd MJPEG -h " + CameraParameters.Height.ToString + " -w " + CameraParameters.Width.ToString
            If CameraParameters.FPS > 0 Then args += " -fps " + CameraParameters.FPS.ToString
            If CameraParameters.Shutter > 0 Then args += " -ss " + CameraParameters.Shutter.ToString
            If CameraParameters.ISO > 0 Then args += " -ISO " + CameraParameters.ISO.ToString
            If CameraParameters.BitRateMbps > 0 Then args += " -b " + CameraParameters.BitRateMbps.ToString + "000000"
            args += " -n -t 999999999"
            If CameraParameters.Options > "" Then args += " " + CameraParameters.Options

            args += " -o -"
            _prc.StartInfo.Arguments = args
            _prc.StartInfo.RedirectStandardError = False
            _prc.StartInfo.RedirectStandardInput = True
            _prc.StartInfo.RedirectStandardOutput = True
            _prc.StartInfo.UseShellExecute = False
            _prc.Start()

            _readThread = New Threading.Thread(AddressOf ReadingThread)
            _readThread.Start()
        Else
            _readThread = New Threading.Thread(AddressOf ReadingThreadEmulator)
            _readThread.Start()
        End If
        Interlocked.Increment(_restartCounter)
    End Sub

    Private Sub ReadingThreadEmulator()
        Dim frame1 = My.Resources.emulator1
        Dim frame2 = My.Resources.emulator2

        Do
            Try
                SyncLock FrameBytesSynclock
                    If FrameCounter Mod 2 = 0 Then
                        _FrameBytesLength = frame1.Length
                        Array.Copy(frame1, FrameBytesBuffer, FrameBytesLength)
                    Else
                        _FrameBytesLength = frame2.Length
                        Array.Copy(frame2, FrameBytesBuffer, FrameBytesLength)
                    End If
                    Interlocked.Increment(_frameCounter)
                End SyncLock
                RaiseEvent FrameReady(Me)
                Dim fps = CameraParameters.FPS
                If fps < 1 Then fps = 20
                Threading.Thread.Sleep(1000 / fps)
            Catch ex As Exception
                Console.WriteLine("Read Thread Emulator error: " + ex.Message)
            End Try
            Threading.Thread.Sleep(1)
        Loop
    End Sub

    Private Sub ReadingThread()
        Dim _currentFramePosition As Integer
        Dim _frameStarted As Boolean
        Do
            Try
                Dim read = _prc.StandardOutput.BaseStream.Read(_readBuffer, 0, _readBuffer.Length - 16)
                'Console.WriteLine("readed " + read.ToString)
                For i = 0 To read - 1
                    If _readBuffer(i + 0) = &HFF AndAlso
                       _readBuffer(i + 1) = &HD8 Then

                        ' If _readBuffer(i + 3) = &HE0 AndAlso
                        '  _readBuffer(i + 6) = &H4A AndAlso
                        ' _readBuffer(i + 7) = &H46 AndAlso
                        ' _readBuffer(i + 8) = &H49 Then

                        If _frameStarted Then
                                SyncLock FrameBytesSynclock
                                    _FrameBytesLength = _currentFramePosition
                                    Array.Copy(_currentFrameBuffer, FrameBytesBuffer, FrameBytesLength)
                                    Interlocked.Increment(_frameCounter)
                                End SyncLock
                                RaiseEvent FrameReady(Me)
                            End If

                            _frameStarted = True
                            _currentFramePosition = 0
                        ' End If
                    End If
                    _currentFrameBuffer(_currentFramePosition) = _readBuffer(i)
                    _currentFramePosition += 1
                Next
            Catch ex As Exception
                Console.WriteLine("Read Thread error: " + ex.Message)
            End Try
        Loop
    End Sub

    Public Sub WaitNewFrame() Implements IRpiCam.CaptureOrWaitFrame
        Static lastCounterValue As Integer
        Static badRestartCounter As Integer
        Dim start = Now
        Dim frameCounter As Long
        Do
            Threading.Thread.Sleep(1)
            frameCounter = Interlocked.Read(_frameCounter)
        Loop While lastCounterValue = frameCounter And (Now - start).TotalSeconds < 5
        If lastCounterValue <> frameCounter Then
            lastCounterValue = frameCounter
            badRestartCounter = 0 'Получили кадр, всё нормально
            Return
        Else
            If badRestartCounter < 3 Then
                badRestartCounter += 1
                Open()
            Else
                Throw New Exception(String.Format("Frame not captured in 5 seconds, restart count without frame: {0}", badRestartCounter))
            End If
        End If
    End Sub

    ''' <summary>
    ''' Finishes raspivid
    ''' </summary>
    Public Sub Close() Implements IRpiCam.Close
        Try
            If _readThread IsNot Nothing Then
                _readThread.Join(2000)
                _readThread.Abort()
            End If
        Catch
        End Try
        _readThread = Nothing

        Try
            _prc.Kill()
        Catch
        End Try
        _prc = Nothing

        Try
            Dim prc As New Process
            prc.StartInfo.FileName = "pkill"
            prc.StartInfo.Arguments = "raspivid"
            prc.Start()
            prc.WaitForExit()
        Catch ex As Exception
        End Try

        Threading.Thread.Sleep(2000)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Close()
    End Sub

    Public Function CreateBytesCopy() As Byte() Implements IRpiCam.CreateBytesCopy
        SyncLock FrameBytesSynclock
            Dim bytes(FrameBytesLength - 1) As Byte
            Array.Copy(FrameBytesBuffer, bytes, bytes.Length)
            Return bytes
        End SyncLock
    End Function
End Class
