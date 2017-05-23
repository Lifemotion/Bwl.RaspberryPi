Imports Bwl.Network.Transport

Public Class Receiver
    Private WithEvents _client As New TCPChannel

    Private Sub bSendParameters_Click(sender As Object, e As EventArgs) Handles bSendParameters.Click
        Dim sbp As New StructuredPacket
        sbp.Add("Width", CInt(tbWidth.Text))
        sbp.Add("Height", CInt(tbHeight.Text))
        sbp.Add("FPS", CInt(tbFPS.Text))
        sbp.Add("Shutter", CInt(tbShutter.Text))
        sbp.Add("ISO", CInt(tbISO.Text))
        sbp.Add("Options", tbOptions.Text)
        sbp.Add("BitRateMbps", CInt(tbBitrate.Text))
        Dim bp = sbp.ToBytePacket
        Try
            _client.SendPacket(bp)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub _client_PacketReceived(channel As IPacketChannel, packet As BytePacket) Handles _client.PacketReceived
        Dim speed = packet.Bytes.Length / 1024 / 1024
        Try
            Dim bmp As New Bitmap(New IO.MemoryStream(packet.Bytes))
            Me.Invoke(Sub()
                          Me.Text = "Receiving: " + speed.ToString("0.00") + "Mb per frame, Bitrate: " + (speed * 8 * CInt(tbFPS.Text)).ToString("0.0") + "Mbit\s"
                          If cbWriteFrames.Checked Then
                              If tbWriteFramesPath.Text = "" Then tbWriteFramesPath.Text = "-"
                              Dim path = IO.Path.Combine(Application.StartupPath, "..", "data", tbWriteFramesPath.Text)
                              If IO.Directory.Exists(path) = False Then IO.Directory.CreateDirectory(path)
                              path = IO.Path.Combine(path, Now.Ticks.ToString + ".jpg")
                              IO.File.WriteAllBytes(path, packet.Bytes)
                          End If
                          pbFrame.Image = bmp
                          pbFrame.Refresh()
                      End Sub)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bConnect_Click(sender As Object, e As EventArgs) Handles bConnect.Click
        Try
            _client.Open(tbServerAddress.Text, "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Receiver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thr As New Threading.Thread(Sub()
                                            Do

                                                If _client.IsConnected = False Then
                                                    Dim results As TransportNetFinder.NetBeaconInfo() = {}
                                                    Try
                                                        results = TransportNetFinder.Find(1000)
                                                        Threading.Thread.Sleep(1000)
                                                    Catch ex As Exception
                                                        Threading.Thread.Sleep(100)
                                                    End Try
                                                    For Each result In results
                                                        If result.Name.Contains("Bwl RPi Camera Test") Then
                                                            Try
                                                                Me.Invoke(Sub()
                                                                              tbServerAddress.Text = result.Address + ":" + result.Port.ToString
                                                                              bConnect_Click(Nothing, Nothing)
                                                                          End Sub)
                                                            Catch ex As Exception

                                                            End Try
                                                        End If
                                                    Next
                                                End If
                                            Loop
                                        End Sub)
        thr.IsBackground = True
        thr.Start()
    End Sub

    Private Sub Receiver_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        _client.Close()
        End
    End Sub
End Class
