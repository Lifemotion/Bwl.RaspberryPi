Public Class RaspberryPi
    Private _serial As New IO.Ports.SerialPort
    Public Event DebugReceivedLine(line As String)
    Public Event DebugSentLine(line As String)

    Public Sub Connect(Optional port As String = "default", Optional login As String = "pi", Optional password As String = "raspberry")
        If port = "default" Then port = IO.Ports.SerialPort.GetPortNames(0)
        If _serial.IsOpen Then _serial.Close()
        _serial.BaudRate = 115200
        _serial.PortName = port
        _serial.Open()
        _serial.NewLine = vbCrLf
        Debug(_serial.ReadExisting())
        If TryLogin(login, password) = False Then
            _serial.Close()
            Throw New Exception("Login failed")
        End If
    End Sub

    Private Sub Debug(parts As String)
        Dim lines = parts.Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        For Each line In lines
            RaiseEvent DebugReceivedLine(line)
        Next
    End Sub

    Public ReadOnly Property Connected As Boolean
        Get
            Return _serial.IsOpen
        End Get
    End Property

    Public Sub RebootCommand()
        WriteLine("sudo reboot")
    End Sub

    Private Function TryLogin(login As String, password As String) As Boolean
        For attempts = 1 To 3
            If CheckPwd() > "" Then Return True
            For logins = 1 To 6
                Debug(_serial.ReadExisting())
                WriteLine(login)
                Threading.Thread.Sleep(500)
                Dim result = _serial.ReadExisting
                Debug(result)
                If result.ToLower.Contains("password") Then
                    WriteLine(password)
                    Exit For
                End If
            Next
            Threading.Thread.Sleep(5000)
            Debug(_serial.ReadExisting())
        Next
        Return False
    End Function

    Public Function CheckPwd() As String
        WriteLine("pwd")
        For attempts = 1 To 4
            Dim line = ReadLine()
            If line.Contains("/home/") Then
                Return line
            End If
        Next
        Return ""
    End Function

    Public Function WriteReadLine(line As String) As String
        WriteLine(line)
        Return ReadLine()
    End Function

    Public Sub WriteLine(line As String)
        _serial.WriteLine(line)
        RaiseEvent DebugSentLine(line)
    End Sub

    Public Function ReadLine() As String
        _serial.ReadTimeout = 100
        Try
            Dim line As String = _serial.ReadLine()
            Debug(line)
            Return line
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function ReadAll() As String
        If _serial.IsOpen Then
            _serial.ReadTimeout = 100
            Dim line As String = _serial.ReadExisting
            Debug(line)
            Return line
        End If
        Return ""
    End Function


End Class
