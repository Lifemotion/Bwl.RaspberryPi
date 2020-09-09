Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports Bwl.RaspberryPi.Camera.My
Imports MMALSharp
Imports MMALSharp.Common
Imports MMALSharp.Common.Utility
Imports MMALSharp.Components
Imports MMALSharp.Handlers
Imports MMALSharp.Ports

Public Class RpiCamMMAL
    Implements IDisposable
    Implements IRpiCam


    Public Class ImgHandler
        Inherits MemoryStreamCaptureHandler

        Public Event Ready(value As Byte())

        Public Sub New()
            MyBase.New(10 * 1024 * 1024)
        End Sub

        Public Overrides Sub PostProcess()

            If Me.CurrentStream.Length = 0 Then
                Exit Sub
            End If
            MyBase.PostProcess()

            If Me.ImageContext.Eos Then
                RaiseEvent Ready(Me.CurrentStream.ToArray())
                Me.CurrentStream.SetLength(0)
                Me.CurrentStream.Position = 0
            End If
        End Sub
    End Class

    Public Class Frame
        Public Property Buffer As Byte()

        Public Sub New(buffer As Byte())
            _Buffer = buffer
        End Sub

    End Class

    Private ReadOnly _camera As MMALCamera
    Private _captureHandler As ImgHandler
    Private _cancellationTokenSource As CancellationTokenSource

    Private _taskStart As Task

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
    Public ReadOnly Property FrameBytesBuffer As Byte() = New Byte(10 * 1024 * 1024) {} Implements IRpiCam.FrameBytesBuffer
    Public ReadOnly Property FrameBytesFormat As RpiCamFrameType = RpiCamFrameType.jpg Implements IRpiCam.FrameBytesFormat
    Public ReadOnly Property FrameBytesLength As Integer Implements IRpiCam.FrameBytesLength

    Public Sub New()
        _camera = MMALCamera.Instance
    End Sub

    Public Sub Open() Implements IRpiCam.Open
        Close()

        If Environment.OSVersion.Platform = PlatformID.Unix Then

            _cancellationTokenSource = New CancellationTokenSource()
            _taskStart = Task.Run(Function() _threadStartProcess(_cancellationTokenSource.Token), _cancellationTokenSource.Token)

        Else
            Throw New Exception("Implemented only on Unix")
        End If
        Interlocked.Increment(_restartCounter)
    End Sub

    Private Async Function _threadStartProcess(ByVal _cancellationToken As CancellationToken) As Task
        Try
            Using captureHandler = New ImgHandler()
                Using splitter = New MMALSplitterComponent()
                    Using imageEncoder = New MMALImageEncoder(continuousCapture:=True)
                        Using nullSink = New MMALNullSinkComponent()
                            _captureHandler = captureHandler

                            AddHandler _captureHandler.Ready, AddressOf _captureHandlerReady

                            'Console.WriteLine(" w:h " & Me.CameraParameters.Width.ToString() & " : " & Me.CameraParameters.Height.ToString())
                            If Me.CameraParameters.Width > 0 AndAlso Me.CameraParameters.Height > 0 Then
                                MMALCameraConfig.VideoResolution = New Resolution(Me.CameraParameters.Width, Me.CameraParameters.Height)
                            End If
                            'Console.WriteLine(" iso " & Me.CameraParameters.ISO.ToString())
                            MMALCameraConfig.ISO = Me.CameraParameters.ISO
                            'Console.WriteLine(" shutter speed " & Me.CameraParameters.Shutter.ToString())
                            MMALCameraConfig.ShutterSpeed = Me.CameraParameters.Shutter
                            'Console.WriteLine(" fps " & Me.CameraParameters.FPS.ToString())
                            MMALCameraConfig.VideoFramerate = New MMALSharp.Native.MMAL_RATIONAL_T(Me.CameraParameters.FPS, 1)

                            _camera.ConfigureCameraSettings()

                                'Console.WriteLine(" quality " & Me.CameraParameters.Quality.ToString())
                                'Console.WriteLine(" bitratembps " & Me.CameraParameters.BitRateMbps.ToString())
                                Dim portConfig = New MMALPortConfig(MMALEncoding.JPEG, MMALEncoding.I420, Me.CameraParameters.Quality, Me.CameraParameters.BitRateMbps * 100000, DateTime.Now.AddSeconds(1))
                            imageEncoder.ConfigureOutputPort(portConfig, captureHandler)
                            _camera.Camera.VideoPort.ConnectTo(splitter)
                            splitter.Outputs(0).ConnectTo(imageEncoder)
                            _camera.Camera.PreviewPort.ConnectTo(nullSink)
                            Await _camera.ProcessAsync(_camera.Camera.VideoPort, _cancellationToken).ConfigureAwait(False)
                        End Using
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine("EXCEPTION[_threadStartProcess]:" & ex.Message & " | " & ex.Source & " | " & ex.ToString())
        End Try
    End Function

    Private Sub _captureHandlerReady(value As Byte())
        SyncLock FrameBytesSynclock
            _FrameBytesLength = value.Length
            Array.Copy(value, FrameBytesBuffer, _FrameBytesLength)
        End SyncLock
        Interlocked.Increment(_frameCounter)
        RaiseEvent FrameReady(Me)
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
        If _cancellationTokenSource IsNot Nothing Then
            _cancellationTokenSource.Cancel()
        End If

        If _taskStart IsNot Nothing Then
            _taskStart = Nothing
        End If

        GC.Collect()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Close()
        If _camera IsNot Nothing Then
            _camera.Cleanup()
        End If
    End Sub

    Public Function CreateBytesCopy() As Byte() Implements IRpiCam.CreateBytesCopy
        SyncLock FrameBytesSynclock
            Dim bytes(FrameBytesLength - 1) As Byte
            Array.Copy(FrameBytesBuffer, bytes, bytes.Length)
            Return bytes
        End SyncLock
    End Function

    Public Sub Reconfigure() Implements IRpiCam.Reconfigure
        MMALCameraConfig.ISO = Me.CameraParameters.ISO
        MMALCameraConfig.ShutterSpeed = Me.CameraParameters.Shutter
        Try
            Dim ass = Assembly.LoadFile(My.Application.Info.DirectoryPath & "/" & "MMALSharp.dll")
            Dim asmType = ass.GetType("MMALSharp.MMALCameraComponentExtensions")
            Dim mi_SetISO = asmType.GetMethod("SetISO", BindingFlags.NonPublic Or BindingFlags.Static)
            Dim mi_SetShutterSpeed = asmType.GetMethod("SetShutterSpeed", BindingFlags.NonPublic Or BindingFlags.Static)
            Dim parameters_SetISO As Object() = {_camera.Camera, Me.CameraParameters.ISO}
            Dim parameters_SetShutterSpeed As Object() = {_camera.Camera, Me.CameraParameters.Shutter}
            mi_SetISO.Invoke(Nothing, parameters_SetISO)
            mi_SetShutterSpeed.Invoke(Nothing, parameters_SetShutterSpeed)
        Catch ex As Exception
            Console.WriteLine("Exception[Reconfigure]: " & ex.Message)
        End Try

    End Sub
End Class
