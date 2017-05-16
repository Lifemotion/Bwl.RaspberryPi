Imports System.Drawing
Imports Bwl.Network.Transport

Module App
    Dim cam As IRpiCam = New RpiCamVideo
    <STAThread>
    Sub Main()
        cam.Open()
        TestTransmission()
        cam.Close()
    End Sub

    Public Sub TestTransmission()
        Dim client As New TCPTransport
        AddHandler client.ReceivedPacket, AddressOf ReceivedPacketHandler
        client.Open("192.168.0.112:8042", "")
        Do
            Dim time = Now
            Dim size = 0.0
            For i = 1 To 10
                cam.CaptureOrWaitFrame()
                size += cam.FrameBytesLength
                Dim bytes = cam.CreateBytesCopy
                Dim pkt As New BytePacket(bytes)
                client.SendPacket(pkt)
            Next
            Dim MS = (Now - time).TotalMilliseconds / 10
            Dim fps = (1000 / MS)
            Console.WriteLine("FPS without save, bitmaps: " + fps.ToString("0.0") + ", " + (size / 1024.0 / 1024.0 / 10.0 * fps).ToString("0.0") + " Mbytes\sec")
        Loop
    End Sub

    Private Sub ReceivedPacketHandler(packet As BytePacket)
        Console.WriteLine("Received!")
        Dim sbp = New StructuredPacket(packet)
        cam.CameraParameters.Width = sbp.Parts("Width")
        cam.CameraParameters.Height = sbp.Parts("Height")
        cam.CameraParameters.Shutter = sbp.Parts("Shutter")
        cam.CameraParameters.ISO = sbp.Parts("ISO")
        cam.CameraParameters.Options = sbp.Parts("Options")
        cam.CameraParameters.FPS = sbp.Parts("FPS")
        cam.Open()
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
