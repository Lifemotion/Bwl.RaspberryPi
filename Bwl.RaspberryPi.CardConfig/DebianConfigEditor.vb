Public Class DebianConfigEditor
    Public Shared Function GetHostname(root As String) As String
        Dim hostname = IO.File.ReadAllLines(IO.Path.Combine(root, "etc\hostname"))(0)
        Dim hosts = IO.File.ReadAllLines(IO.Path.Combine(root, "etc\hosts"))
        If hostname > "" Then
            For Each host In hosts
                If host.Contains("127.") And host.Contains(hostname) Then
                    Return hostname
                End If
            Next
        End If
        Throw New Exception("Hostname not detected")
    End Function

    Public Shared Sub SetHostname(root As String, newHostname As String)
        Dim oldHostname = GetHostname(root)
        Dim hosts = IO.File.ReadAllLines(IO.Path.Combine(root, "etc\hosts"))
        For i = 0 To hosts.Length - 1
            If hosts(i).Contains("127.") And hosts(i).Contains(oldHostname) Then
                hosts(i) = "127.0.0.1" + vbTab + newHostname
                IO.File.WriteAllLines(IO.Path.Combine(root, "etc\hostname"), {newHostname})
                IO.File.WriteAllLines(IO.Path.Combine(root, "etc\hosts"), hosts)
                Return
            End If
        Next
        Throw New Exception("Old Hostname not detected in etc\hosts!")
    End Sub

    Public Shared Function GetWpaSupplicant(root As String) As String
        Dim lines = IO.File.ReadAllLines(IO.Path.Combine(root, "etc\wpa_supplicant\wpa_supplicant.conf"))
        Dim networkNow As Boolean
        Dim networkFound As Boolean
        Dim ssid As String = ""
        Dim psk As String = ""
        For i = 0 To lines.Length - 1
            If lines(i).ToLower.Contains("network=") Then networkFound = True : networkNow = True
            If lines(i).ToLower.Contains("}") Then networkNow = False
            If networkNow Then
                Dim parts = lines(i).Split("=")
                If parts.Length = 2 Then
                    If parts(0).Trim.ToLower = "ssid" Then ssid = parts(1).Trim.Replace("""", "")
                    If parts(0).Trim.ToLower = "psk" Then psk = parts(1).Trim.Replace("""", "")
                End If
            Else
                If ssid > "" And psk > "" Then
                    Return ssid + vbTab + psk
                End If
            End If
        Next
        If Not networkFound Then
            Return vbTab
        Else
            Throw New Exception("wpa_supplicant.conf contains network info, but not recognized")
        End If
    End Function

    Public Shared Sub SetWpaSupplicant(root As String, ssid As String, psk As String)
        Dim lines = IO.File.ReadAllLines(IO.Path.Combine(root, "etc\wpa_supplicant\wpa_supplicant.conf"))
        Dim networkFound As Boolean
        Dim networkNow As Boolean
        Dim ssidIndex = -1
        Dim pskIndex = -1
        For i = 0 To lines.Length - 1
            If lines(i).ToLower.Contains("network=") Then networkFound = True : networkNow = True
            If lines(i).ToLower.Contains("}") Then networkNow = False
            If networkNow Then
                Dim parts = lines(i).Split("=")
                If parts.Length = 2 Then
                    If parts(0).Trim.ToLower = "ssid" Then ssidIndex = i
                    If parts(0).Trim.ToLower = "psk" Then pskIndex = i
                End If
            Else
                If pskIndex > 0 And ssidIndex > 0 Then
                    lines(ssidIndex) = "ssid=""" + ssid + """"
                    lines(pskIndex) = "psk=""" + psk + """"
                    IO.File.WriteAllLines(IO.Path.Combine(root, "etc\wpa_supplicant\wpa_supplicant.conf"), lines)
                    Return
                End If
            End If
        Next
        If Not networkFound Then
            Dim linesList As New List(Of String)(lines)
            linesList.Add("network={")
            linesList.Add("ssid=""" + ssid + """")
            linesList.Add("psk=""" + psk + """")
            linesList.Add("}")
            IO.File.WriteAllLines(IO.Path.Combine(root, "etc\wpa_supplicant\wpa_supplicant.conf"), linesList)
            Return
        End If
        Throw New Exception("wpa_supplicant.conf contains network info, but not recognized")
    End Sub
End Class
