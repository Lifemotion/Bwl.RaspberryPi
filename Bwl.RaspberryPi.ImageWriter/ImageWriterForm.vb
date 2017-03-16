Imports Bwl.Framework

Public Class ImageWriterForm
    Inherits FormAppBase
    Dim lld As New LowLevelDrive

    Private Sub ImageWriterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim drvs = lld.GetPhysicalDrivesList
        For Each drv In drvs
            ComboBox1.Items.Add("DRIVE" + drv.Index.ToString + " - " + drv.SizeGigabytes.ToString("0.0") + " Gb")
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fs As New IO.FileStream(TextBox1.Text, IO.FileMode.Open, IO.FileAccess.Read)
        Dim buffer(1024 * 1024 - 1) As Byte
        Dim read As Integer
        Dim pos As Integer
        lld.OpenDriveReadWrite(2)
        Dim testread = lld.ReadBytes(0, 4096)
        Dim teststr = System.Text.Encoding.ASCII.GetString(testread)
        Dim info = lld.GetInfo
        Do
            read = fs.Read(buffer, 0, buffer.Length)
            lld.WriteBytesSectored(pos, buffer)
            pos += buffer.Length
            If pos Mod (1024 * 1024 * 50) = 0 Then _logger.AddMessage((pos / 1024 / 1024).ToString("0"))
            Application.DoEvents()
        Loop While read > 0
    End Sub
End Class
