Imports System.Drawing
Imports Bwl.Network.Transport

Module App
    Dim cam As IRpiCam '= New RpiCamMMAL
    <STAThread>
    Sub Main(args() As String)
        Console.WriteLine("Bwl.RaspberryPi.Camera.TestNetCore")
        Console.WriteLine("#100")
        For Each arg In args
            Select Case arg.ToLower
                Case "mmal" : cam = New RpiCamMMAL
                Case "still" : cam = New RpiCamVideo
                Case "video" : cam = New RpiCamStill
            End Select
        Next
        If cam Is Nothing Then cam = New RpiCamMMAL
        cam.Open()
        TestTransmission()
        cam.Close()
    End Sub

    Public Sub TestTransmission()
        Dim server As New TCPServer
        AddHandler server.ServerReceivedPacket, AddressOf ReceivedPacketHandler
        server.Open(8042)
        server.StartBeacon("Bwl RPi Camera Test", False)
        Console.WriteLine("Started Net Server")
        Do
            Dim time = Now
            Dim size = 0.0
            For i = 1 To 10
                cam.CaptureOrWaitFrame()
                size += cam.FrameBytesLength
                Dim bytes = cam.CreateBytesCopy
                Dim pkt As New BytePacket(bytes)
                For Each conn In server.ActiveConnections
                    Try
                        conn.Channel.SendPacket(pkt)
                    Catch ex As Exception
                    End Try
                Next
            Next
            Dim MS = (Now - time).TotalMilliseconds / 10
            Dim fps = (1000 / MS)
            Console.WriteLine("FPS without save, bitmaps: " + fps.ToString("0.0") + ", " + (size / 1024.0 / 1024.0 / 10.0 * fps).ToString("0.0") + " Mbytes\sec")
        Loop
    End Sub

    Private Sub ReceivedPacketHandler(connection As IConnectedChannel, packet As BytePacket)
        Console.WriteLine("Received!")
        Dim sbp = New StructuredPacket(packet)
        If cam.CameraParameters.Width <> sbp.Parts("Width") Or
                cam.CameraParameters.Height <> sbp.Parts("Height") Or
                cam.CameraParameters.FPS <> sbp.Parts("FPS") Or
                cam.CameraParameters.Options <> sbp.Parts("Options") Or
                cam.CameraParameters.Quality <> sbp.Parts("Quality") Or
                cam.CameraParameters.BitRateMbps <> sbp.Parts("BitRateMbps") Then

            cam.CameraParameters.Width = sbp.Parts("Width")
            cam.CameraParameters.Height = sbp.Parts("Height")
            cam.CameraParameters.FPS = sbp.Parts("FPS")
            cam.CameraParameters.Options = sbp.Parts("Options")
            cam.CameraParameters.Quality = sbp.Parts("Quality")
            cam.CameraParameters.BitRateMbps = sbp.Parts("BitRateMbps")
            cam.CameraParameters.Shutter = sbp.Parts("Shutter")
            cam.CameraParameters.ISO = sbp.Parts("ISO")
            Console.WriteLine("Reopen")
            cam.Open()
        Else
            cam.CameraParameters.Shutter = sbp.Parts("Shutter")
            cam.CameraParameters.ISO = sbp.Parts("ISO")
            Console.WriteLine("Reconfigure")
            cam.Reconfigure()
        End If
    End Sub

    Public Sub CreateUserDefinedCamera()
        Console.WriteLine("Width, Height, FPS, Options:")
        Dim line = Console.ReadLine
        Dim parts = line.Split(",")

        If parts.Length = 4 Then
            cam.CameraParameters.Width = Val(parts(0).Trim)
            cam.CameraParameters.Height = Val(parts(1).Trim)
            cam.CameraParameters.FPS = Val(parts(2).Trim)
            cam.CameraParameters.Options = parts(3).Trim
            cam.Open()
        Else
            cam.CameraParameters.Width = 640
            cam.CameraParameters.Height = 480
            cam.CameraParameters.FPS = 20
            cam.CameraParameters.Options = ""
            cam.Open()
        End If
    End Sub

    Public Sub TestFpsBitmaps(repeats As Integer)
        Throw New NotImplementedException

        For k = 1 To repeats
            Dim time = Now
            Dim Size = 0.0
            For i = 1 To 10
                cam.CaptureOrWaitFrame()
                Size += cam.FrameBytesLength
            Next
            Dim MS = (Now - time).TotalMilliseconds / 10
            Dim fps = (1000 / MS)
            Console.WriteLine("FPS without save, bitmaps: " + fps.ToString("0.0") + ", " + (Size / 1024.0 / 1024.0 / 10.0 * fps).ToString("0.0") + " Mbytes\sec")
        Next
    End Sub

    Public Sub TestFpsBytes(repeats As Integer)
        For k = 1 To repeats
            Dim time = Now
            Dim Size = 0.0
            For i = 1 To 10
                cam.CaptureOrWaitFrame()
                Size += cam.FrameBytesLength
            Next
            Dim MS = (Now - time).TotalMilliseconds / 10
            Dim fps = (1000 / MS)
            Console.WriteLine("FPS without save, bytes: " + fps.ToString("0.0") + ", " + (Size / 1024.0 / 1024.0 / 10.0 * fps).ToString("0.0") + " Mbytes\sec")
        Next
    End Sub

    Public Function BytesToBitmap(bytes As Byte()) As Bitmap
        Dim bmp As New Bitmap(New IO.MemoryStream(bytes))
        Return bmp
    End Function
End Module
