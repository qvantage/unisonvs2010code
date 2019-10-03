Public Class TrucksActivity
    Inherits System.Windows.Forms.Form

    Dim MeText(3), MeKeys(3) As String
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents utRoute As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents utOfficeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents utOffice As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents utFuel As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utEndMile As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utStartMile As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLicPlate As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utTruckID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utDriverID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utDriverFName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents utDriverLName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents utMiles As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents utTruckInventID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utRouteName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.utRouteName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.utDriverID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.utDriverLName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utDriverFName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.utTruckInventID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utLicPlate = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.utTruckID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.utFuel = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.utMiles = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label9 = New System.Windows.Forms.Label
        Me.utEndMile = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label8 = New System.Windows.Forms.Label
        Me.utStartMile = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utOffice = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.utOfficeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.utRoute = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.utRouteName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.utDriverID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utDriverLName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utDriverFName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.utTruckInventID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLicPlate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTruckID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFuel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utMiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utEndMile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utStartMile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRoute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.utRouteName)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.UltraDate1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.utFuel)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.utOffice)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.utOfficeID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.utRoute)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(488, 325)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'utRouteName
        '
        Me.utRouteName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utRouteName.Enabled = False
        Me.utRouteName.Location = New System.Drawing.Point(272, 56)
        Me.utRouteName.Name = "utRouteName"
        Me.utRouteName.ReadOnly = True
        Me.utRouteName.Size = New System.Drawing.Size(112, 21)
        Me.utRouteName.TabIndex = 2
        Me.utRouteName.Tag = ""
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(200, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 16)
        Me.Label14.TabIndex = 135
        Me.Label14.Text = "Route Name:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.utDriverID)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.utDriverLName)
        Me.GroupBox5.Controls.Add(Me.utDriverFName)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 109)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(472, 48)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Driver"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Last Name:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utDriverID
        '
        Me.utDriverID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utDriverID.Location = New System.Drawing.Point(408, 16)
        Me.utDriverID.Name = "utDriverID"
        Me.utDriverID.Size = New System.Drawing.Size(56, 21)
        Me.utDriverID.TabIndex = 2
        Me.utDriverID.Tag = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(376, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "ID:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utDriverLName
        '
        Me.utDriverLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utDriverLName.Location = New System.Drawing.Point(72, 17)
        Me.utDriverLName.Name = "utDriverLName"
        Me.utDriverLName.Size = New System.Drawing.Size(104, 21)
        Me.utDriverLName.TabIndex = 0
        Me.utDriverLName.Tag = ""
        '
        'utDriverFName
        '
        Me.utDriverFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utDriverFName.Location = New System.Drawing.Point(264, 17)
        Me.utDriverFName.Name = "utDriverFName"
        Me.utDriverFName.Size = New System.Drawing.Size(112, 21)
        Me.utDriverFName.TabIndex = 1
        Me.utDriverFName.Tag = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(199, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "First Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.utTruckInventID)
        Me.GroupBox4.Controls.Add(Me.utLicPlate)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.utTruckID)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 168)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(472, 48)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Truck"
        '
        'utTruckInventID
        '
        Me.utTruckInventID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTruckInventID.Location = New System.Drawing.Point(408, 16)
        Me.utTruckInventID.Name = "utTruckInventID"
        Me.utTruckInventID.Size = New System.Drawing.Size(16, 21)
        Me.utTruckInventID.TabIndex = 2
        Me.utTruckInventID.Tag = ""
        Me.utTruckInventID.Visible = False
        '
        'utLicPlate
        '
        Me.utLicPlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLicPlate.Location = New System.Drawing.Point(264, 16)
        Me.utLicPlate.Name = "utLicPlate"
        Me.utLicPlate.Size = New System.Drawing.Size(112, 21)
        Me.utLicPlate.TabIndex = 1
        Me.utLicPlate.Tag = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(206, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "Lic. Plate:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utTruckID
        '
        Me.utTruckID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTruckID.Location = New System.Drawing.Point(72, 16)
        Me.utTruckID.Name = "utTruckID"
        Me.utTruckID.Size = New System.Drawing.Size(104, 21)
        Me.utTruckID.TabIndex = 0
        Me.utTruckID.Tag = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "ID:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(80, 24)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(104, 21)
        Me.UltraDate1.TabIndex = 0
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(32, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 133
        Me.Label11.Text = "Date:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 289)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 16)
        Me.Label10.TabIndex = 132
        Me.Label10.Text = "Fuel (Gal.):"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utFuel
        '
        Me.utFuel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFuel.Location = New System.Drawing.Point(80, 288)
        Me.utFuel.Name = "utFuel"
        Me.utFuel.Size = New System.Drawing.Size(74, 21)
        Me.utFuel.TabIndex = 8
        Me.utFuel.Tag = ".OFFICE_ID"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.utMiles)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.utEndMile)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.utStartMile)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 221)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(472, 56)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mileage"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(368, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 16)
        Me.Label13.TabIndex = 133
        Me.Label13.Text = "Miles:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMiles
        '
        Me.utMiles.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMiles.Enabled = False
        Me.utMiles.Location = New System.Drawing.Point(408, 24)
        Me.utMiles.Name = "utMiles"
        Me.utMiles.ReadOnly = True
        Me.utMiles.Size = New System.Drawing.Size(56, 21)
        Me.utMiles.TabIndex = 2
        Me.utMiles.Tag = ".OFFICE_ID"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(232, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 131
        Me.Label9.Text = "End:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utEndMile
        '
        Me.utEndMile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEndMile.Location = New System.Drawing.Point(264, 24)
        Me.utEndMile.Name = "utEndMile"
        Me.utEndMile.Size = New System.Drawing.Size(74, 21)
        Me.utEndMile.TabIndex = 1
        Me.utEndMile.Tag = ".OFFICE_ID"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(40, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 16)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Start:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utStartMile
        '
        Me.utStartMile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utStartMile.Location = New System.Drawing.Point(72, 24)
        Me.utStartMile.Name = "utStartMile"
        Me.utStartMile.Size = New System.Drawing.Size(74, 21)
        Me.utStartMile.TabIndex = 0
        Me.utStartMile.Tag = ".OFFICE_ID"
        '
        'utOffice
        '
        Me.utOffice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOffice.Enabled = False
        Me.utOffice.Location = New System.Drawing.Point(272, 80)
        Me.utOffice.Name = "utOffice"
        Me.utOffice.ReadOnly = True
        Me.utOffice.Size = New System.Drawing.Size(112, 21)
        Me.utOffice.TabIndex = 4
        Me.utOffice.Tag = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(232, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "Office:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utOfficeID
        '
        Me.utOfficeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeID.Enabled = False
        Me.utOfficeID.Location = New System.Drawing.Point(80, 80)
        Me.utOfficeID.Name = "utOfficeID"
        Me.utOfficeID.ReadOnly = True
        Me.utOfficeID.Size = New System.Drawing.Size(104, 21)
        Me.utOfficeID.TabIndex = 3
        Me.utOfficeID.Tag = ".OFFICE_ID"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Office ID:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utRoute
        '
        Me.utRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utRoute.Location = New System.Drawing.Point(80, 56)
        Me.utRoute.Name = "utRoute"
        Me.utRoute.Size = New System.Drawing.Size(104, 21)
        Me.utRoute.TabIndex = 1
        Me.utRoute.Tag = ".Route"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Route#:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnClear)
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 325)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(488, 40)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(192, 16)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 21)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "C&lear Fields"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(410, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 21)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'TrucksActivity
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 365)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "TrucksActivity"
        Me.Text = "Trucks Activity"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utRouteName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.utDriverID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utDriverLName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utDriverFName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.utTruckInventID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLicPlate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTruckID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFuel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utMiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utEndMile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utStartMile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRoute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TrucksActivity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = TrucksVars.TRUCKSTblPath & Me.Tag
            End If
        End If

        'UltraDate1.DateTime = Date.Now
        UltraDate1.Nullable = True
        UltraDate1.Value = Nothing 'Date.Now
        UltraDate1.FormatString = "MM/dd/yyyy"
        MeKeys(0) = Me.Text
        MeKeys(1) = " - KDn: @KDN "
        MeKeys(2) = " - KPr: @KPR "
        MeKeys(3) = " -  KUp: @KUP "
        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText(0) = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)
        'AddHandler Me.KeyUp, AddressOf Form_KeyUp
        UltraDate1.Focus()

    End Sub
    Private Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles utDriverID.KeyPress, utStartMile.KeyPress, utEndMile.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub Route_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utRoute.Leave
        Dim dbRow As DataRow
        Dim HidCols As String() = {"ID1"}
        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then
            ClearForm(Me)
            Exit Sub
        End If

        If sender.text <> "" Then
            If SearchOnLeave(sender, utRoute, AppTblPath & "Routes", "ID", "ID", ", Name, OFFICEID, DriverID", "Routes", "", , HidCols) Then
                If ReturnRowByID(utRoute.Text, dbRow, AppTblPath & "Routes", "", "ID", "Select r.*, isnull(so.Name, '') as Office, isnull(e.FirstName,'') as FirstName, isnull(e.LastName,'') as LastName from " & AppTblPath & "Routes r, " & AppTblPath & "ServiceOffices so, " & AppTblPath & "EmployeesBase e where r.DriverID *= e.ID and r.OfficeID *= so.ID and r.ID = '" & sender.text & "'") Then
                    utRouteName.Text = dbRow("Name")
                    utOfficeID.Text = dbRow.Item("OFFICEID")
                    utOffice.Text = dbRow.Item("OFFICE")
                    utDriverID.Text = dbRow.Item("DRIVERID")
                    utDriverFName.Text = dbRow.Item("FirstName")
                    utDriverLName.Text = dbRow.Item("LastName")
                    dbRow = Nothing
                Else
                    'MsgBox("Route not found.")
                    sender.Focus()
                    dbRow = Nothing
                    Exit Sub
                End If
            Else
                'MsgBox("Route not found.")
                sender.text = ""
                sender.Focus()
            End If
        Else
            ClearForm(Me)
        End If
        sender.modified = False
    End Sub

    Private Sub utDriverLName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utDriverLName.KeyUp
        TypeAhead(sender, e, AppTblPath & "EmployeesBase", "LastName", "AND OfficeID = '" & utOfficeID.Text & "' AND Status = 'A'")
        'sender.modified = True
    End Sub
    Private Sub utDriverLName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utDriverLName.Leave
        Dim row As DataRow
        Dim FldName As String
        FldName = "LastName"

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            ClearForm(GroupBox5)
            'btnSave.Enabled = False
        Else
            If SearchOnLeave(sender, utDriverID, AppTblPath & "EmployeesBase", "ID", FldName, "*", "Employees") Then
                If ReturnRowByID(utDriverID.Text, row, AppTblPath & "EmployeesBase", , "ID") Then
                    utDriverFName.Text = row("FirstName")
                    row = Nothing
                End If
                'btnSave.Enabled = True

            Else
                utDriverID.Text = "0"
                utDriverFName.Focus()
            End If
        End If
        sender.Modified = False
    End Sub

    Private Sub utDriverID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utDriverID.Leave
        Dim row As DataRow
        Dim FldName As String
        FldName = "LastName"

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            ClearForm(GroupBox5)
            'btnSave.Enabled = False
        Else
            If ReturnRowByID(utDriverID.Text, row, AppTblPath & "EmployeesBase", , "ID") Then
                utDriverFName.Text = row("FirstName")
                utDriverLName.Text = row("LastName")
                row = Nothing
            Else
                utDriverID.Text = "0"
                ClearForm(GroupBox5)
                utDriverFName.Focus()
                sender.focus()
            End If
        End If
        sender.Modified = False
    End Sub

    Private Sub utTruckID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utTruckID.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            ClearForm(GroupBox4)
            'btnSave.Enabled = False
        Else
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If
            If SearchOnLeave(sender, utTruckInventID, TrucksVars.TRUCKSTblPath & "Inventory", "Truck_Invent_ID", "TruckID", ", Date_Out", "Trucks", " AND Date_Out is NULL ") Then
                If ReturnRowByID(utTruckInventID.Text, row, TrucksVars.TRUCKSTblPath & "Inventory", "", "Truck_Invent_ID") Then
                    utLicPlate.Text = row("Lic_Plate")
                    'utTruckInventID.Text = row("Truck_Invent_ID")
                    row = Nothing
                Else
                    MsgBox("Truck Not Found.")
                    ClearForm(GroupBox4)
                End If
            Else
                MsgBox("Truck Not Found.")
                ClearForm(GroupBox4)
            End If
        End If
        sender.Modified = False
    End Sub

    Private Sub utLicPlate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utLicPlate.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            ClearForm(GroupBox4)
            'btnSave.Enabled = False
        Else
            If SearchOnLeave(sender, utTruckInventID, TrucksVars.TRUCKSTblPath & "Inventory", "Truck_Invent_ID", "Lic_Plate", "*", "Trucks", " AND Date_Out is NULL ") Then
                If ReturnRowByID(utLicPlate.Text, row, TrucksVars.TRUCKSTblPath & "Inventory", " AND Date_Out is NULL", "Lic_Plate") Then
                    utTruckID.Text = row("TruckID")
                    utTruckInventID.Text = row("Truck_Invent_ID")
                    row = Nothing
                Else
                    MsgBox("Truck Not Found.")
                    ClearForm(GroupBox4)
                End If
            End If
        End If
        sender.Modified = False
    End Sub

    Private Sub Value_Dec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles utFuel.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub utStartMile_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utStartMile.Leave, utEndMile.Leave
        Dim Miles As Decimal

        If sender.Modified = False Then Exit Sub

        Miles = Val(utEndMile.Text) - Val(utStartMile.Text) '+ 1
        utMiles.Text = IIf(Miles < 0, "N/A", Miles)
        If Miles < 0 And utStartMile.Text.Trim <> "" And utEndMile.Text.Trim <> "" Then
            MessageBox.Show("Start-Miles is greater than End-Miles.")
            sender.text = ""
            sender.GetType()
        End If
        sender.Modified = False
        utMiles.Modified = False

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If CheckEmptyFields(Me) = False Then
            Exit Sub
        End If
        Dim sqlInsert As String

        sqlInsert = "Insert into " & TrucksVars.TRUCKSTblPath & "DAILYACTIVITY(Act_Date, Route, Driver_ID, Driver, Office_ID, Truck_Invent_ID, Start_Miles, End_Miles, Fuel) " & _
                    " Values('" & UltraDate1.Value & "', '" & utRoute.Text & "', " & IIf(utDriverID.Text.Trim = "", 0, Val(utDriverID.Text)) & ", '" & utDriverFName.Text & " " & utDriverLName.Text & "', " & _
                    utOfficeID.Text & ", " & utTruckInventID.Text & ", " & utStartMile.Text & ", " & utEndMile.Text & ", " & utFuel.Text & ")"

        If ExecuteQuery(sqlInsert) = False Then
            MsgBox("Error inserting the record.")
            Exit Sub
        End If
        Me.Text = MeText(0) & " - TruckID " & utTruckID.Text & " Saved."
        ClearForm(Me)
        UltraDate1.Focus()

    End Sub

    Private Function CheckEmptyFields(ByVal ActForm As Object) As Boolean
        Dim Ctrl As Control

        CheckEmptyFields = False
        For Each Ctrl In ActForm.Controls
            Select Case Ctrl.GetType.ToString
                Case "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                    If Ctrl.Text.Trim = "" Then
                        If Ctrl.Name <> utDriverID.Name Then
                            MsgBox("Some Fields are empty. Record can not be saved.")
                            'MsgBox("DriverID is empty.") 'Karina added
                            Exit Function
                        End If
                    End If
                Case "System.Windows.Forms.GroupBox"
                    If CheckEmptyFields(Ctrl) = False Then
                        Exit Function
                    End If
                Case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                    Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
                    TempCtrl = Ctrl
                    If TempCtrl.Value Is Nothing Then
                        MsgBox("Some Fields are empty. Record can not be saved.")
                        Exit Function
                    End If
            End Select
        Next
        CheckEmptyFields = True
    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub utRoute_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utRoute.ValueChanged

    End Sub

    Private Sub utDriverID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utDriverID.ValueChanged

    End Sub

    Private Sub utStartMile_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utStartMile.ValueChanged

    End Sub

    Private Sub utTruckID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utTruckID.ValueChanged

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearForm(Me)
    End Sub

    Private Sub TrucksActivity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Static Cnt As Int16 = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            Cnt += 1
            MeText(2) = MeKeys(2).Replace("@KPR", Cnt)
            'Me.Text = MeText(0) & MeText(1) & MeText(2) & MeText(3)
        End If

        If Asc(e.KeyChar) = Keys.Enter Then
            If TypeOf sender.ActiveControl Is Button Then
                Exit Sub
            End If
            If TypeOf sender.ActiveControl Is TextBox Then
                Dim CtrlTBX As TextBox
                CtrlTBX = sender.ActiveControl
                If CtrlTBX.AcceptsReturn Then Exit Sub
            End If
            If TypeOf sender.ActiveControl Is Button Then
                'e.Handled = True
            Else
                e.Handled = False
                'e.Handled = True
                SendKeys.Send("{TAB}")
            End If
        End If

    End Sub

    Private Sub TrucksActivity_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Static Cnt2 As Int16 = 0

        If e.KeyCode = Keys.Enter Then
            Cnt2 += 1
            MeText(3) = MeKeys(3).Replace("@KUP", Cnt2)
            'Me.Text = MeText(0) & MeText(1) & MeText(2) & MeText(3)
            e.Handled = True
        End If
    End Sub

    Private Sub TrucksActivity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Static Cnt3 As Int16 = 0

        If e.KeyCode = Keys.Enter Then
            Cnt3 += 1
            MeText(1) = MeKeys(1).Replace("@KDN", Cnt3)
            'Me.Text = MeText(0) & MeText(1) & MeText(2) & MeText(3)
            e.Handled = True
        End If

    End Sub

End Class
