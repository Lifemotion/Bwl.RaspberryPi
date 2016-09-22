<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageConfigForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImageConfigForm))
        Me.tb = New System.Windows.Forms.TextBox()
        Me.bScanRPiRoot = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bOpen = New System.Windows.Forms.Button()
        Me.gbComputerName = New System.Windows.Forms.GroupBox()
        Me.bHostanameSet = New System.Windows.Forms.Button()
        Me.tbHostname = New System.Windows.Forms.TextBox()
        Me.gbNetwork = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbWpaPsk = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bWifiSet = New System.Windows.Forms.Button()
        Me.tbWpaSsid = New System.Windows.Forms.TextBox()
        Me.gbRMHC = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbRepeaterAddress = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cbStartRMHC = New System.Windows.Forms.CheckBox()
        Me.cbInstalled = New System.Windows.Forms.CheckBox()
        Me.gbComputerName.SuspendLayout()
        Me.gbNetwork.SuspendLayout()
        Me.gbRMHC.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.ExtendedView = False
        resources.ApplyResources(Me.logWriter, "logWriter")
        '
        'tb
        '
        resources.ApplyResources(Me.tb, "tb")
        Me.tb.Name = "tb"
        '
        'bScanRPiRoot
        '
        resources.ApplyResources(Me.bScanRPiRoot, "bScanRPiRoot")
        Me.bScanRPiRoot.Name = "bScanRPiRoot"
        Me.bScanRPiRoot.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'bOpen
        '
        resources.ApplyResources(Me.bOpen, "bOpen")
        Me.bOpen.Name = "bOpen"
        Me.bOpen.UseVisualStyleBackColor = True
        '
        'gbComputerName
        '
        Me.gbComputerName.Controls.Add(Me.bHostanameSet)
        Me.gbComputerName.Controls.Add(Me.tbHostname)
        resources.ApplyResources(Me.gbComputerName, "gbComputerName")
        Me.gbComputerName.Name = "gbComputerName"
        Me.gbComputerName.TabStop = False
        '
        'bHostanameSet
        '
        resources.ApplyResources(Me.bHostanameSet, "bHostanameSet")
        Me.bHostanameSet.Name = "bHostanameSet"
        Me.bHostanameSet.UseVisualStyleBackColor = True
        '
        'tbHostname
        '
        resources.ApplyResources(Me.tbHostname, "tbHostname")
        Me.tbHostname.Name = "tbHostname"
        '
        'gbNetwork
        '
        Me.gbNetwork.Controls.Add(Me.Label3)
        Me.gbNetwork.Controls.Add(Me.tbWpaPsk)
        Me.gbNetwork.Controls.Add(Me.Label2)
        Me.gbNetwork.Controls.Add(Me.bWifiSet)
        Me.gbNetwork.Controls.Add(Me.tbWpaSsid)
        resources.ApplyResources(Me.gbNetwork, "gbNetwork")
        Me.gbNetwork.Name = "gbNetwork"
        Me.gbNetwork.TabStop = False
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'tbWpaPsk
        '
        resources.ApplyResources(Me.tbWpaPsk, "tbWpaPsk")
        Me.tbWpaPsk.Name = "tbWpaPsk"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'bWifiSet
        '
        resources.ApplyResources(Me.bWifiSet, "bWifiSet")
        Me.bWifiSet.Name = "bWifiSet"
        Me.bWifiSet.UseVisualStyleBackColor = True
        '
        'tbWpaSsid
        '
        resources.ApplyResources(Me.tbWpaSsid, "tbWpaSsid")
        Me.tbWpaSsid.Name = "tbWpaSsid"
        '
        'gbRMHC
        '
        Me.gbRMHC.Controls.Add(Me.Button2)
        Me.gbRMHC.Controls.Add(Me.Label4)
        Me.gbRMHC.Controls.Add(Me.tbRepeaterAddress)
        Me.gbRMHC.Controls.Add(Me.TextBox4)
        Me.gbRMHC.Controls.Add(Me.Button1)
        Me.gbRMHC.Controls.Add(Me.RadioButton3)
        Me.gbRMHC.Controls.Add(Me.RadioButton2)
        Me.gbRMHC.Controls.Add(Me.RadioButton1)
        Me.gbRMHC.Controls.Add(Me.CheckBox1)
        Me.gbRMHC.Controls.Add(Me.cbStartRMHC)
        Me.gbRMHC.Controls.Add(Me.cbInstalled)
        resources.ApplyResources(Me.gbRMHC, "gbRMHC")
        Me.gbRMHC.Name = "gbRMHC"
        Me.gbRMHC.TabStop = False
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'tbRepeaterAddress
        '
        resources.ApplyResources(Me.tbRepeaterAddress, "tbRepeaterAddress")
        Me.tbRepeaterAddress.Name = "tbRepeaterAddress"
        '
        'TextBox4
        '
        resources.ApplyResources(Me.TextBox4, "TextBox4")
        Me.TextBox4.Name = "TextBox4"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        resources.ApplyResources(Me.RadioButton3, "RadioButton3")
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        resources.ApplyResources(Me.RadioButton2, "RadioButton2")
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cbStartRMHC
        '
        resources.ApplyResources(Me.cbStartRMHC, "cbStartRMHC")
        Me.cbStartRMHC.Name = "cbStartRMHC"
        Me.cbStartRMHC.UseVisualStyleBackColor = True
        '
        'cbInstalled
        '
        resources.ApplyResources(Me.cbInstalled, "cbInstalled")
        Me.cbInstalled.Name = "cbInstalled"
        Me.cbInstalled.UseVisualStyleBackColor = True
        '
        'ImageConfigForm
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.gbRMHC)
        Me.Controls.Add(Me.gbNetwork)
        Me.Controls.Add(Me.gbComputerName)
        Me.Controls.Add(Me.bOpen)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bScanRPiRoot)
        Me.Controls.Add(Me.tb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ImageConfigForm"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.tb, 0)
        Me.Controls.SetChildIndex(Me.bScanRPiRoot, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.bOpen, 0)
        Me.Controls.SetChildIndex(Me.gbComputerName, 0)
        Me.Controls.SetChildIndex(Me.gbNetwork, 0)
        Me.Controls.SetChildIndex(Me.gbRMHC, 0)
        Me.gbComputerName.ResumeLayout(False)
        Me.gbComputerName.PerformLayout()
        Me.gbNetwork.ResumeLayout(False)
        Me.gbNetwork.PerformLayout()
        Me.gbRMHC.ResumeLayout(False)
        Me.gbRMHC.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tb As TextBox
    Friend WithEvents bScanRPiRoot As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents bOpen As Button
    Friend WithEvents gbComputerName As GroupBox
    Friend WithEvents bHostanameSet As Button
    Friend WithEvents tbHostname As TextBox
    Friend WithEvents gbNetwork As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbWpaPsk As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents bWifiSet As Button
    Friend WithEvents tbWpaSsid As TextBox
    Friend WithEvents gbRMHC As GroupBox
    Friend WithEvents cbInstalled As CheckBox
    Friend WithEvents cbStartRMHC As CheckBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents tbRepeaterAddress As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button1 As Button
End Class
