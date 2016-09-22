Imports Bwl.Framework

Public Class ImagePrepareForm
    Inherits FormAppBase

    Private WithEvents _rpi As New RaspberryPi

    Private Sub _rpi_DebugReceivedLine(line As String) Handles _rpi.DebugReceivedLine
        _logger.AddInformation("-> " + line)
    End Sub

    Private Sub _rpi_DebugSentLine(line As String) Handles _rpi.DebugSentLine
        _logger.AddInformation("<- " + line)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bConnect.Click
        Try
            _logger.AddMessage("Connecting...")
            Application.DoEvents()
            _rpi.Connect()
            _logger.AddMessage("Connected by serial port")
        Catch ex As Exception
            _logger.AddMessage(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles bReboot.Click
        _rpi.RebootCommand()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles bInstallBasic.Click
        _rpi.WriteLine("sudo apt-get update; sudo apt-get upgrade; sudo apt-get install git mc mono-complete mono-basic-dbg mono-dbg mono-runtime-dbg")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        _rpi.readAll
    End Sub
End Class
