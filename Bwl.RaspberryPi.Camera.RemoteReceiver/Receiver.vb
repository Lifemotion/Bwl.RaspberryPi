Imports Bwl.Network.Transport

Public Class Receiver
    Private WithEvents _listener As New TCPServer(8042)

    Private Sub _listener_NewConnection(server As IPortListener, transport As IPacketTransport) Handles _listener.NewConnection
        AddHandler transport.ReceivedPacket, AddressOf ReceivedPacketHandler
    End Sub

    Private Sub ReceivedPacketHandler(packet As BytePacket)
        Try
            IO.File.WriteAllBytes(Now.Ticks.ToString + ".jpg", packet.Bytes)
            Dim bmp As New Bitmap(New IO.MemoryStream(packet.Bytes))
            Me.Invoke(Sub()
                          pbFrame.Image = bmp
                          pbFrame.Refresh()
                      End Sub)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Receiver_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub bSendParameters_Click(sender As Object, e As EventArgs) Handles bSendParameters.Click
        Dim sbp As New StructuredPacket
        sbp.Add("Width", CInt(tbWidth.Text))
        sbp.Add("Height", CInt(tbHeight.Text))
        sbp.Add("FPS", CInt(tbFPS.Text))
        sbp.Add("Shutter", CInt(tbShutter.Text))
        sbp.Add("ISO", CInt(tbISO.Text))
        sbp.Add("Options", tbOptions.Text)
        Dim bp = sbp.ToBytePacket

        For Each conn In _listener.ActiveConnections
            Try
                conn.SendPacket(bp)
            Catch ex As Exception
            End Try
        Next
    End Sub
End Class
