<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImagePrepareForm

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.bConnect = New System.Windows.Forms.Button()
        Me.bReboot = New System.Windows.Forms.Button()
        Me.bInstallBasic = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.Location = New System.Drawing.Point(0, 239)
        Me.logWriter.Size = New System.Drawing.Size(655, 238)
        '
        'bConnect
        '
        Me.bConnect.Location = New System.Drawing.Point(12, 27)
        Me.bConnect.Name = "bConnect"
        Me.bConnect.Size = New System.Drawing.Size(75, 23)
        Me.bConnect.TabIndex = 0
        Me.bConnect.Text = "Connect"
        Me.bConnect.UseVisualStyleBackColor = True
        '
        'bReboot
        '
        Me.bReboot.Location = New System.Drawing.Point(12, 56)
        Me.bReboot.Name = "bReboot"
        Me.bReboot.Size = New System.Drawing.Size(75, 23)
        Me.bReboot.TabIndex = 1
        Me.bReboot.Text = "Reboot"
        Me.bReboot.UseVisualStyleBackColor = True
        '
        'bInstallBasic
        '
        Me.bInstallBasic.Location = New System.Drawing.Point(12, 85)
        Me.bInstallBasic.Name = "bInstallBasic"
        Me.bInstallBasic.Size = New System.Drawing.Size(149, 23)
        Me.bInstallBasic.TabIndex = 2
        Me.bInstallBasic.Text = "Install Basic Soft"
        Me.bInstallBasic.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 476)
        Me.Controls.Add(Me.bInstallBasic)
        Me.Controls.Add(Me.bReboot)
        Me.Controls.Add(Me.bConnect)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Controls.SetChildIndex(Me.bConnect, 0)
        Me.Controls.SetChildIndex(Me.bReboot, 0)
        Me.Controls.SetChildIndex(Me.bInstallBasic, 0)
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bConnect As Button
    Friend WithEvents bReboot As Button
    Friend WithEvents bInstallBasic As Button
    Friend WithEvents Timer1 As Timer
End Class
