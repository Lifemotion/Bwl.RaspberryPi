Imports Bwl.Framework

Public Class ImageConfigForm
    Inherits FormAppBase
    Private _rootPath As String = ""

    Private Sub ImageConfigForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bScanRPiRoot_Click(Nothing, Nothing)
    End Sub

    Private Sub bScanRPiRoot_Click(sender As Object, e As EventArgs) Handles bScanRPiRoot.Click
        For Each drv In IO.DriveInfo.GetDrives
            If drv.IsReady Then
                If CheckRootPath(drv.RootDirectory.FullName) Then
                    tb.Text = drv.RootDirectory.FullName
                    _logger.AddMessage("Mounted Raspbian SDCard found at " + tb.Text)
                    Try
                        bOpen_Click(Nothing, Nothing)
                    Catch ex As Exception

                    End Try
                    Return
                End If
            End If
        Next
        _logger.AddWarning("Mounted Raspbian SDCard not found!")
    End Sub

    Private Function CheckRootPath(path As String) As Boolean
        Return IO.File.Exists(IO.Path.Combine(path, "etc\dpkg\origins\raspbian"))
    End Function




    Private Sub bOpen_Click(sender As Object, e As EventArgs) Handles bOpen.Click
        If CheckRootPath(tb.Text) Then
            _rootPath = tb.Text
            Try
                Dim hostname = DebianConfigEditor.GetHostname(_rootPath)
                tbHostname.Text = hostname
                gbComputerName.Enabled = True
            Catch ex As Exception
                gbComputerName.Enabled = False
                _logger.AddError(ex.Message)
            End Try

            Try
                Dim wpa = DebianConfigEditor.GetWpaSupplicant(_rootPath).Split(vbTab)
                tbWpaSsid.Text = wpa(0)
                tbWpaPsk.Text = wpa(1)
                gbNetwork.Enabled = True
            Catch ex As Exception
                gbNetwork.Enabled = False
                _logger.AddError(ex.Message)
            End Try

        End If
    End Sub

    Private Sub bHostanameSet_Click(sender As Object, e As EventArgs) Handles bHostanameSet.Click
        Try
            DebianConfigEditor.SetHostname(_rootPath, tbHostname.Text)
            _logger.AddMessage("Hostname set to " + DebianConfigEditor.GetHostname(_rootPath))
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub

    Private Sub bWifiSet_Click(sender As Object, e As EventArgs) Handles bWifiSet.Click
        Try
            DebianConfigEditor.SetWpaSupplicant(_rootPath, tbWpaSsid.Text, tbWpaPsk.Text)
            _logger.AddMessage("WPA data set to " + DebianConfigEditor.GetWpaSupplicant(_rootPath).Replace(vbTab, " "))
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub
End Class
