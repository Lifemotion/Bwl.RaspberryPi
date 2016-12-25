<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Receiver
    Inherits System.Windows.Forms.Form

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
        Me.pbFrame = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bSendParameters = New System.Windows.Forms.Button()
        Me.tbWidth = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbHeight = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbFPS = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbOptions = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbISO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbShutter = New System.Windows.Forms.TextBox()
        CType(Me.pbFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbFrame
        '
        Me.pbFrame.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbFrame.BackColor = System.Drawing.Color.White
        Me.pbFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFrame.Location = New System.Drawing.Point(16, 113)
        Me.pbFrame.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbFrame.Name = "pbFrame"
        Me.pbFrame.Size = New System.Drawing.Size(1043, 564)
        Me.pbFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbFrame.TabIndex = 0
        Me.pbFrame.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbOptions)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbISO)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.tbShutter)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbFPS)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbHeight)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbWidth)
        Me.GroupBox1.Controls.Add(Me.bSendParameters)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1043, 100)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Camera Parameters:"
        '
        'bSendParameters
        '
        Me.bSendParameters.Location = New System.Drawing.Point(962, 71)
        Me.bSendParameters.Name = "bSendParameters"
        Me.bSendParameters.Size = New System.Drawing.Size(75, 23)
        Me.bSendParameters.TabIndex = 0
        Me.bSendParameters.Text = "Send"
        Me.bSendParameters.UseVisualStyleBackColor = True
        '
        'tbWidth
        '
        Me.tbWidth.Location = New System.Drawing.Point(74, 21)
        Me.tbWidth.Name = "tbWidth"
        Me.tbWidth.Size = New System.Drawing.Size(100, 22)
        Me.tbWidth.TabIndex = 1
        Me.tbWidth.Text = "640"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Width:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Height:"
        '
        'tbHeight
        '
        Me.tbHeight.Location = New System.Drawing.Point(74, 47)
        Me.tbHeight.Name = "tbHeight"
        Me.tbHeight.Size = New System.Drawing.Size(100, 22)
        Me.tbHeight.TabIndex = 3
        Me.tbHeight.Text = "480"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "FPS:"
        '
        'tbFPS
        '
        Me.tbFPS.Location = New System.Drawing.Point(74, 73)
        Me.tbFPS.Name = "tbFPS"
        Me.tbFPS.Size = New System.Drawing.Size(100, 22)
        Me.tbFPS.TabIndex = 5
        Me.tbFPS.Text = "20"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(181, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Options:"
        '
        'tbOptions
        '
        Me.tbOptions.Location = New System.Drawing.Point(240, 73)
        Me.tbOptions.Name = "tbOptions"
        Me.tbOptions.Size = New System.Drawing.Size(100, 22)
        Me.tbOptions.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(181, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ISO:"
        '
        'tbISO
        '
        Me.tbISO.Location = New System.Drawing.Point(240, 47)
        Me.tbISO.Name = "tbISO"
        Me.tbISO.Size = New System.Drawing.Size(100, 22)
        Me.tbISO.TabIndex = 9
        Me.tbISO.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(181, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Shutter:"
        '
        'tbShutter
        '
        Me.tbShutter.Location = New System.Drawing.Point(240, 21)
        Me.tbShutter.Name = "tbShutter"
        Me.tbShutter.Size = New System.Drawing.Size(100, 22)
        Me.tbShutter.TabIndex = 7
        Me.tbShutter.Text = "0"
        '
        'Receiver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1075, 692)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pbFrame)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Receiver"
        Me.Text = "Bwl RPi Camera Receiver"
        CType(Me.pbFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbFrame As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbOptions As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbISO As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbShutter As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbFPS As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbHeight As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbWidth As TextBox
    Friend WithEvents bSendParameters As Button
End Class
