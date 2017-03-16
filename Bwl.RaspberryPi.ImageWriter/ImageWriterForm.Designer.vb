<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageWriterForm

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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.bHostanameSet = New System.Windows.Forms.Button()
        Me.gbNetwork = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbWpaPsk = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbWpaSsid = New System.Windows.Forms.TextBox()
        Me.gbComputerName = New System.Windows.Forms.GroupBox()
        Me.tbHostname = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gbNetwork.SuspendLayout()
        Me.gbComputerName.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.ExtendedView = False
        Me.logWriter.Location = New System.Drawing.Point(2, 358)
        Me.logWriter.Size = New System.Drawing.Size(781, 162)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 49)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "1. Raspbian Image"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(6, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(748, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "C:\Users\heart\Raspberry\Raspbian 22.11.2016 with RMHC 1.1.2.img"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 82)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(290, 76)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "2. Select SD Card"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 19)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(278, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Location = New System.Drawing.Point(308, 82)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(464, 76)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "3. Write Image to SD"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Write"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.bHostanameSet)
        Me.GroupBox4.Controls.Add(Me.gbNetwork)
        Me.GroupBox4.Controls.Add(Me.gbComputerName)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 164)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(760, 191)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "4. Configure Image on SD Card"
        '
        'bHostanameSet
        '
        Me.bHostanameSet.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bHostanameSet.Location = New System.Drawing.Point(566, 158)
        Me.bHostanameSet.Name = "bHostanameSet"
        Me.bHostanameSet.Size = New System.Drawing.Size(188, 27)
        Me.bHostanameSet.TabIndex = 4
        Me.bHostanameSet.Text = "Set this parameters"
        Me.bHostanameSet.UseVisualStyleBackColor = True
        '
        'gbNetwork
        '
        Me.gbNetwork.Controls.Add(Me.Label3)
        Me.gbNetwork.Controls.Add(Me.tbWpaPsk)
        Me.gbNetwork.Controls.Add(Me.Label2)
        Me.gbNetwork.Controls.Add(Me.tbWpaSsid)
        Me.gbNetwork.Enabled = False
        Me.gbNetwork.Location = New System.Drawing.Point(6, 76)
        Me.gbNetwork.Name = "gbNetwork"
        Me.gbNetwork.Size = New System.Drawing.Size(200, 75)
        Me.gbNetwork.TabIndex = 9
        Me.gbNetwork.TabStop = False
        Me.gbNetwork.Text = "Network"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(6, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Wi-Fi PSK:"
        '
        'tbWpaPsk
        '
        Me.tbWpaPsk.Location = New System.Drawing.Point(74, 45)
        Me.tbWpaPsk.Name = "tbWpaPsk"
        Me.tbWpaPsk.Size = New System.Drawing.Size(120, 20)
        Me.tbWpaPsk.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Wi-Fi SSID:"
        '
        'tbWpaSsid
        '
        Me.tbWpaSsid.Location = New System.Drawing.Point(74, 19)
        Me.tbWpaSsid.Name = "tbWpaSsid"
        Me.tbWpaSsid.Size = New System.Drawing.Size(120, 20)
        Me.tbWpaSsid.TabIndex = 3
        '
        'gbComputerName
        '
        Me.gbComputerName.Controls.Add(Me.tbHostname)
        Me.gbComputerName.Enabled = False
        Me.gbComputerName.Location = New System.Drawing.Point(6, 19)
        Me.gbComputerName.Name = "gbComputerName"
        Me.gbComputerName.Size = New System.Drawing.Size(200, 51)
        Me.gbComputerName.TabIndex = 8
        Me.gbComputerName.TabStop = False
        Me.gbComputerName.Text = "Computer Name (Hostname)"
        '
        'tbHostname
        '
        Me.tbHostname.Location = New System.Drawing.Point(6, 19)
        Me.tbHostname.Name = "tbHostname"
        Me.tbHostname.Size = New System.Drawing.Size(188, 20)
        Me.tbHostname.TabIndex = 3
        '
        'ImageWriterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 521)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "ImageWriterForm"
        Me.Text = "Bwl RaspberryPi Image Writer & Config"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.gbNetwork.ResumeLayout(False)
        Me.gbNetwork.PerformLayout()
        Me.gbComputerName.ResumeLayout(False)
        Me.gbComputerName.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents bHostanameSet As Button
    Friend WithEvents gbNetwork As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbWpaPsk As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbWpaSsid As TextBox
    Friend WithEvents gbComputerName As GroupBox
    Friend WithEvents tbHostname As TextBox
End Class
