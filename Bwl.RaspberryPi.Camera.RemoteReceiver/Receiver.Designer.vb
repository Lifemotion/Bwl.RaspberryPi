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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Receiver))
        Me.pbFrame = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbBitrate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbOptions = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbISO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbShutter = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbFPS = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbHeight = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbWidth = New System.Windows.Forms.TextBox()
        Me.bSendParameters = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bConnect = New System.Windows.Forms.Button()
        Me.tbServerAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbWriteFrames = New System.Windows.Forms.CheckBox()
        Me.tbWriteFramesPath = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbQuality = New System.Windows.Forms.TextBox()
        CType(Me.pbFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbFrame
        '
        Me.pbFrame.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbFrame.BackColor = System.Drawing.Color.White
        Me.pbFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFrame.Location = New System.Drawing.Point(1, 103)
        Me.pbFrame.Name = "pbFrame"
        Me.pbFrame.Size = New System.Drawing.Size(1123, 544)
        Me.pbFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbFrame.TabIndex = 0
        Me.pbFrame.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbQuality)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbBitrate)
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
        Me.GroupBox1.Location = New System.Drawing.Point(212, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(492, 92)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Camera Parameters:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(266, 45)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Bitrate, Mbps:"
        '
        'tbBitrate
        '
        Me.tbBitrate.Location = New System.Drawing.Point(343, 42)
        Me.tbBitrate.Margin = New System.Windows.Forms.Padding(2)
        Me.tbBitrate.Name = "tbBitrate"
        Me.tbBitrate.Size = New System.Drawing.Size(76, 20)
        Me.tbBitrate.TabIndex = 13
        Me.tbBitrate.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 70)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Quality:"
        '
        'tbOptions
        '
        Me.tbOptions.Location = New System.Drawing.Point(184, 67)
        Me.tbOptions.Margin = New System.Windows.Forms.Padding(2)
        Me.tbOptions.Name = "tbOptions"
        Me.tbOptions.Size = New System.Drawing.Size(235, 20)
        Me.tbOptions.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 45)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ISO:"
        '
        'tbISO
        '
        Me.tbISO.Location = New System.Drawing.Point(184, 42)
        Me.tbISO.Margin = New System.Windows.Forms.Padding(2)
        Me.tbISO.Name = "tbISO"
        Me.tbISO.Size = New System.Drawing.Size(76, 20)
        Me.tbISO.TabIndex = 9
        Me.tbISO.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(136, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Shutter:"
        '
        'tbShutter
        '
        Me.tbShutter.Location = New System.Drawing.Point(184, 17)
        Me.tbShutter.Margin = New System.Windows.Forms.Padding(2)
        Me.tbShutter.Name = "tbShutter"
        Me.tbShutter.Size = New System.Drawing.Size(76, 20)
        Me.tbShutter.TabIndex = 7
        Me.tbShutter.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(266, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "FPS:"
        '
        'tbFPS
        '
        Me.tbFPS.Location = New System.Drawing.Point(343, 17)
        Me.tbFPS.Margin = New System.Windows.Forms.Padding(2)
        Me.tbFPS.Name = "tbFPS"
        Me.tbFPS.Size = New System.Drawing.Size(76, 20)
        Me.tbFPS.TabIndex = 5
        Me.tbFPS.Text = "20"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Height:"
        '
        'tbHeight
        '
        Me.tbHeight.Location = New System.Drawing.Point(56, 42)
        Me.tbHeight.Margin = New System.Windows.Forms.Padding(2)
        Me.tbHeight.Name = "tbHeight"
        Me.tbHeight.Size = New System.Drawing.Size(76, 20)
        Me.tbHeight.TabIndex = 3
        Me.tbHeight.Text = "480"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Width:"
        '
        'tbWidth
        '
        Me.tbWidth.Location = New System.Drawing.Point(56, 17)
        Me.tbWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.tbWidth.Name = "tbWidth"
        Me.tbWidth.Size = New System.Drawing.Size(76, 20)
        Me.tbWidth.TabIndex = 1
        Me.tbWidth.Text = "640"
        '
        'bSendParameters
        '
        Me.bSendParameters.Location = New System.Drawing.Point(432, 15)
        Me.bSendParameters.Margin = New System.Windows.Forms.Padding(2)
        Me.bSendParameters.Name = "bSendParameters"
        Me.bSendParameters.Size = New System.Drawing.Size(56, 72)
        Me.bSendParameters.TabIndex = 0
        Me.bSendParameters.Text = "Send"
        Me.bSendParameters.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bConnect)
        Me.GroupBox2.Controls.Add(Me.tbServerAddress)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(195, 92)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Connection"
        '
        'bConnect
        '
        Me.bConnect.Location = New System.Drawing.Point(5, 59)
        Me.bConnect.Margin = New System.Windows.Forms.Padding(2)
        Me.bConnect.Name = "bConnect"
        Me.bConnect.Size = New System.Drawing.Size(185, 28)
        Me.bConnect.TabIndex = 3
        Me.bConnect.Text = "Connect"
        Me.bConnect.UseVisualStyleBackColor = True
        '
        'tbServerAddress
        '
        Me.tbServerAddress.Location = New System.Drawing.Point(5, 20)
        Me.tbServerAddress.Margin = New System.Windows.Forms.Padding(2)
        Me.tbServerAddress.Name = "tbServerAddress"
        Me.tbServerAddress.Size = New System.Drawing.Size(185, 20)
        Me.tbServerAddress.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbWriteFrames)
        Me.GroupBox3.Controls.Add(Me.tbWriteFramesPath)
        Me.GroupBox3.Location = New System.Drawing.Point(710, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(195, 92)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Save Frames"
        '
        'cbWriteFrames
        '
        Me.cbWriteFrames.AutoSize = True
        Me.cbWriteFrames.Location = New System.Drawing.Point(5, 16)
        Me.cbWriteFrames.Name = "cbWriteFrames"
        Me.cbWriteFrames.Size = New System.Drawing.Size(139, 17)
        Me.cbWriteFrames.TabIndex = 4
        Me.cbWriteFrames.Text = "Write Frames To Folder:"
        Me.cbWriteFrames.UseVisualStyleBackColor = True
        '
        'tbWriteFramesPath
        '
        Me.tbWriteFramesPath.Location = New System.Drawing.Point(5, 38)
        Me.tbWriteFramesPath.Margin = New System.Windows.Forms.Padding(2)
        Me.tbWriteFramesPath.Name = "tbWriteFramesPath"
        Me.tbWriteFramesPath.Size = New System.Drawing.Size(185, 20)
        Me.tbWriteFramesPath.TabIndex = 2
        Me.tbWriteFramesPath.Text = "frames0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(136, 70)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Options:"
        '
        'tbQuality
        '
        Me.tbQuality.Location = New System.Drawing.Point(56, 66)
        Me.tbQuality.Margin = New System.Windows.Forms.Padding(2)
        Me.tbQuality.Name = "tbQuality"
        Me.tbQuality.Size = New System.Drawing.Size(76, 20)
        Me.tbQuality.TabIndex = 16
        Me.tbQuality.Text = "0"
        '
        'Receiver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 648)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pbFrame)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Receiver"
        Me.Text = "Bwl RPi Camera Receiver"
        CType(Me.pbFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents bConnect As Button
    Friend WithEvents tbServerAddress As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tbBitrate As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbWriteFrames As CheckBox
    Friend WithEvents tbWriteFramesPath As TextBox
    Friend WithEvents tbQuality As TextBox
    Friend WithEvents Label8 As Label
End Class
