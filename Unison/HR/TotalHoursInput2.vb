Imports System.Data
Imports System.Data.SqlClient

Public Class TotalHoursInput2
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim HidCols() As String = {"RowID"}
    Dim DeptModified As Boolean = False
    'Dim DataModified As Boolean
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim cmdTrans As SqlCommand = Nothing

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
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents utEmployeeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnEmployee As System.Windows.Forms.Button
    Friend WithEvents utEmployee As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents utPayRate As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents utRegHrs As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents utOTHrs As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents utDTHrs As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents utMiles As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents utMileageRate As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents utBranchFS As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ucboDept As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents utOfficeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents utWCCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents utClass As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utClassID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utoffice As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents utHrsPay As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents utAutoPay As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboMiscIncome1 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents utMiscIncome1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents utMiscIncome2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboMiscIncome2 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents utMiscIncome3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboMiscIncome3 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents utMiscIncome4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboMiscIncome4 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents utMiscIncome5 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboMiscIncome5 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents utMiscIncome6 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboMiscIncome6 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents utTotalHrs As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utFuelSur As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents uchVoucher As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents utRowID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uchTaxable1 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uchTaxable2 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uchTaxable3 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uchTaxable4 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uchTaxable5 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uchTaxable6 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uchMisc As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents utMisc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.utClassID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label13 = New System.Windows.Forms.Label
        Me.utClass = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label12 = New System.Windows.Forms.Label
        Me.utWCCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utOfficeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboDept = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label9 = New System.Windows.Forms.Label
        Me.utoffice = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.utPayRate = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.utEmployee = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.utEmployeeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnEmployee = New System.Windows.Forms.Button
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.utBranchFS = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.utMisc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uchMisc = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.utRowID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uchVoucher = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.utFuelSur = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.utTotalHrs = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utAutoPay = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.utHrsPay = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label8 = New System.Windows.Forms.Label
        Me.utMileageRate = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.utMiles = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.utDTHrs = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.utOTHrs = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.utRegHrs = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.uchTaxable6 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.uchTaxable5 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.uchTaxable4 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.uchTaxable3 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.uchTaxable2 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.uchTaxable1 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Label21 = New System.Windows.Forms.Label
        Me.utMiscIncome6 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboMiscIncome6 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label20 = New System.Windows.Forms.Label
        Me.utMiscIncome5 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboMiscIncome5 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label19 = New System.Windows.Forms.Label
        Me.utMiscIncome4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboMiscIncome4 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label18 = New System.Windows.Forms.Label
        Me.utMiscIncome3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboMiscIncome3 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label17 = New System.Windows.Forms.Label
        Me.utMiscIncome2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboMiscIncome2 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label16 = New System.Windows.Forms.Label
        Me.utMiscIncome1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboMiscIncome1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1.SuspendLayout()
        CType(Me.utClassID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utWCCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDept, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utoffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utPayRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utEmployeeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utBranchFS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utMisc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFuelSur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTotalHrs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAutoPay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utHrsPay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMileageRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utDTHrs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOTHrs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRegHrs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.utMiscIncome6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboMiscIncome6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMiscIncome5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboMiscIncome5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMiscIncome4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboMiscIncome4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMiscIncome3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboMiscIncome3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMiscIncome2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboMiscIncome2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMiscIncome1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboMiscIncome1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.utClassID)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.utClass)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.utWCCode)
        Me.GroupBox1.Controls.Add(Me.utOfficeID)
        Me.GroupBox1.Controls.Add(Me.ucboDept)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.utoffice)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.utPayRate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.utEmployee)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.utEmployeeID)
        Me.GroupBox1.Controls.Add(Me.btnEmployee)
        Me.GroupBox1.Controls.Add(Me.UltraDate1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.utBranchFS)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(656, 128)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'utClassID
        '
        Me.utClassID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utClassID.Enabled = False
        Me.utClassID.Location = New System.Drawing.Point(544, 72)
        Me.utClassID.Name = "utClassID"
        Me.utClassID.Size = New System.Drawing.Size(16, 21)
        Me.utClassID.TabIndex = 14
        Me.utClassID.TabStop = False
        Me.utClassID.Tag = ".ClassID"
        Me.utClassID.Visible = False
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(420, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Class:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utClass
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utClass.Appearance = Appearance1
        Me.utClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utClass.Enabled = False
        Me.utClass.Location = New System.Drawing.Point(464, 96)
        Me.utClass.Name = "utClass"
        Me.utClass.Size = New System.Drawing.Size(128, 21)
        Me.utClass.TabIndex = 13
        Me.utClass.TabStop = False
        Me.utClass.Tag = ".Class"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(242, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 23)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "WCCode:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utWCCode
        '
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.utWCCode.Appearance = Appearance2
        Me.utWCCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utWCCode.Enabled = False
        Me.utWCCode.Location = New System.Drawing.Point(303, 97)
        Me.utWCCode.Name = "utWCCode"
        Me.utWCCode.Size = New System.Drawing.Size(81, 21)
        Me.utWCCode.TabIndex = 11
        Me.utWCCode.TabStop = False
        Me.utWCCode.Tag = ".WCCode"
        '
        'utOfficeID
        '
        Me.utOfficeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeID.Enabled = False
        Me.utOfficeID.Location = New System.Drawing.Point(224, 16)
        Me.utOfficeID.Name = "utOfficeID"
        Me.utOfficeID.Size = New System.Drawing.Size(16, 21)
        Me.utOfficeID.TabIndex = 3
        Me.utOfficeID.TabStop = False
        Me.utOfficeID.Tag = ".officeid"
        Me.utOfficeID.Visible = False
        '
        'ucboDept
        '
        Me.ucboDept.AutoEdit = False
        Me.ucboDept.DisplayMember = ""
        Me.ucboDept.Location = New System.Drawing.Point(104, 72)
        Me.ucboDept.Name = "ucboDept"
        Me.ucboDept.Size = New System.Drawing.Size(96, 21)
        Me.ucboDept.TabIndex = 2
        Me.ucboDept.Tag = ".DeptNo..1.EmployeePayRates.DeptNo.DeptNo"
        Me.ucboDept.ValueMember = ""
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(256, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 23)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Office:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utoffice
        '
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Me.utoffice.Appearance = Appearance3
        Me.utoffice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utoffice.Enabled = False
        Me.utoffice.Location = New System.Drawing.Point(304, 16)
        Me.utoffice.Name = "utoffice"
        Me.utoffice.Size = New System.Drawing.Size(288, 21)
        Me.utoffice.TabIndex = 8
        Me.utoffice.TabStop = False
        Me.utoffice.Tag = ".Office"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(216, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Pay Rate: $"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utPayRate
        '
        Appearance4.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance4.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Appearance4.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.utPayRate.Appearance = Appearance4
        Me.utPayRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utPayRate.Enabled = False
        Me.utPayRate.Location = New System.Drawing.Point(303, 72)
        Me.utPayRate.Name = "utPayRate"
        Me.utPayRate.ReadOnly = True
        Me.utPayRate.Size = New System.Drawing.Size(80, 21)
        Me.utPayRate.TabIndex = 10
        Me.utPayRate.TabStop = False
        Me.utPayRate.Tag = ".PayRate"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Dept.:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utEmployee
        '
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Me.utEmployee.Appearance = Appearance5
        Me.utEmployee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployee.Enabled = False
        Me.utEmployee.Location = New System.Drawing.Point(304, 48)
        Me.utEmployee.Name = "utEmployee"
        Me.utEmployee.Size = New System.Drawing.Size(288, 21)
        Me.utEmployee.TabIndex = 9
        Me.utEmployee.TabStop = False
        Me.utEmployee.Tag = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Employee ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utEmployeeID
        '
        Me.utEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployeeID.Location = New System.Drawing.Point(104, 48)
        Me.utEmployeeID.Name = "utEmployeeID"
        Me.utEmployeeID.Size = New System.Drawing.Size(96, 21)
        Me.utEmployeeID.TabIndex = 1
        Me.utEmployeeID.Tag = ".EmployeeID"
        '
        'btnEmployee
        '
        Me.btnEmployee.Location = New System.Drawing.Point(216, 48)
        Me.btnEmployee.Name = "btnEmployee"
        Me.btnEmployee.Size = New System.Drawing.Size(80, 21)
        Me.btnEmployee.TabIndex = 4
        Me.btnEmployee.TabStop = False
        Me.btnEmployee.Text = "Se&lect"
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(105, 16)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate1.TabIndex = 0
        Me.UltraDate1.Tag = ".PayrollDate"
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Period Ending:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(392, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 162
        Me.Label10.Text = "Branch FS: $"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utBranchFS
        '
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Me.utBranchFS.Appearance = Appearance6
        Me.utBranchFS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utBranchFS.Enabled = False
        Me.utBranchFS.Location = New System.Drawing.Point(464, 72)
        Me.utBranchFS.Name = "utBranchFS"
        Me.utBranchFS.Size = New System.Drawing.Size(65, 21)
        Me.utBranchFS.TabIndex = 5
        Me.utBranchFS.TabStop = False
        Me.utBranchFS.Tag = ".FuelSurcharge_Rate.view"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.utMisc)
        Me.GroupBox2.Controls.Add(Me.uchMisc)
        Me.GroupBox2.Controls.Add(Me.utRowID)
        Me.GroupBox2.Controls.Add(Me.uchVoucher)
        Me.GroupBox2.Controls.Add(Me.utFuelSur)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.utTotalHrs)
        Me.GroupBox2.Controls.Add(Me.utAutoPay)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.utHrsPay)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.utMileageRate)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.utMiles)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.utDTHrs)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.utOTHrs)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.utRegHrs)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 216)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'utMisc
        '
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.ForeColorDisabled = System.Drawing.Color.Black
        Me.utMisc.Appearance = Appearance7
        Me.utMisc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMisc.Enabled = False
        Me.utMisc.Location = New System.Drawing.Point(120, 182)
        Me.utMisc.Name = "utMisc"
        Me.utMisc.Size = New System.Drawing.Size(200, 21)
        Me.utMisc.TabIndex = 175
        Me.utMisc.TabStop = False
        Me.utMisc.Tag = ".Misc_Comment"
        '
        'uchMisc
        '
        Appearance8.ForeColor = System.Drawing.Color.Black
        Appearance8.ForeColorDisabled = System.Drawing.Color.Black
        Appearance8.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchMisc.Appearance = Appearance8
        Me.uchMisc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Appearance9.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchMisc.CheckedAppearance = Appearance9
        Me.uchMisc.Location = New System.Drawing.Point(53, 183)
        Me.uchMisc.Name = "uchMisc"
        Me.uchMisc.Size = New System.Drawing.Size(64, 20)
        Me.uchMisc.TabIndex = 174
        Me.uchMisc.Tag = ".Misc"
        Me.uchMisc.Text = "Misc"
        '
        'utRowID
        '
        Me.utRowID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utRowID.Enabled = False
        Me.utRowID.Location = New System.Drawing.Point(296, 16)
        Me.utRowID.Name = "utRowID"
        Me.utRowID.Size = New System.Drawing.Size(16, 21)
        Me.utRowID.TabIndex = 173
        Me.utRowID.TabStop = False
        Me.utRowID.Tag = ".RowID.View"
        Me.utRowID.Visible = False
        '
        'uchVoucher
        '
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.ForeColorDisabled = System.Drawing.Color.Black
        Appearance10.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchVoucher.Appearance = Appearance10
        Me.uchVoucher.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Appearance11.ForeColor = System.Drawing.Color.Black
        Appearance11.ForeColorDisabled = System.Drawing.Color.Black
        Appearance11.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchVoucher.CheckedAppearance = Appearance11
        Me.uchVoucher.Location = New System.Drawing.Point(53, 160)
        Me.uchVoucher.Name = "uchVoucher"
        Me.uchVoucher.Size = New System.Drawing.Size(64, 20)
        Me.uchVoucher.TabIndex = 172
        Me.uchVoucher.Tag = ".Voucher"
        Me.uchVoucher.Text = "Voucher"
        '
        'utFuelSur
        '
        Appearance12.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance12.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Appearance12.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Appearance12.TextHAlign = Infragistics.Win.HAlign.Left
        Me.utFuelSur.Appearance = Appearance12
        Me.utFuelSur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFuelSur.Enabled = False
        Me.utFuelSur.Location = New System.Drawing.Point(256, 113)
        Me.utFuelSur.Name = "utFuelSur"
        Me.utFuelSur.Size = New System.Drawing.Size(64, 21)
        Me.utFuelSur.TabIndex = 171
        Me.utFuelSur.TabStop = False
        Me.utFuelSur.Tag = ".FuelSurcharge"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(183, 113)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 23)
        Me.Label23.TabIndex = 170
        Me.Label23.Text = "Fuel Sur.: $"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(184, 67)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 16)
        Me.Label22.TabIndex = 169
        Me.Label22.Text = "Total Hours:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utTotalHrs
        '
        Appearance13.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance13.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Appearance13.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Appearance13.TextHAlign = Infragistics.Win.HAlign.Left
        Me.utTotalHrs.Appearance = Appearance13
        Me.utTotalHrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTotalHrs.Enabled = False
        Me.utTotalHrs.Location = New System.Drawing.Point(256, 64)
        Me.utTotalHrs.Name = "utTotalHrs"
        Me.utTotalHrs.Size = New System.Drawing.Size(64, 21)
        Me.utTotalHrs.TabIndex = 168
        Me.utTotalHrs.TabStop = False
        Me.utTotalHrs.Tag = ""
        '
        'utAutoPay
        '
        Appearance14.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance14.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Appearance14.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Appearance14.TextHAlign = Infragistics.Win.HAlign.Left
        Me.utAutoPay.Appearance = Appearance14
        Me.utAutoPay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAutoPay.Enabled = False
        Me.utAutoPay.Location = New System.Drawing.Point(256, 137)
        Me.utAutoPay.Name = "utAutoPay"
        Me.utAutoPay.Size = New System.Drawing.Size(64, 21)
        Me.utAutoPay.TabIndex = 167
        Me.utAutoPay.TabStop = False
        Me.utAutoPay.Tag = ".AutoPay"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(183, 135)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 23)
        Me.Label15.TabIndex = 166
        Me.Label15.Text = "Auto Pay: $"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(183, 93)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 16)
        Me.Label14.TabIndex = 164
        Me.Label14.Text = "Gross Pay: $"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utHrsPay
        '
        Appearance15.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance15.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Appearance15.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Appearance15.TextHAlign = Infragistics.Win.HAlign.Left
        Me.utHrsPay.Appearance = Appearance15
        Me.utHrsPay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utHrsPay.Enabled = False
        Me.utHrsPay.Location = New System.Drawing.Point(256, 89)
        Me.utHrsPay.Name = "utHrsPay"
        Me.utHrsPay.Size = New System.Drawing.Size(64, 21)
        Me.utHrsPay.TabIndex = 163
        Me.utHrsPay.TabStop = False
        Me.utHrsPay.Tag = ".HrsPay"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 158
        Me.Label8.Text = "Mileage Rate: $"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMileageRate
        '
        Me.utMileageRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMileageRate.Location = New System.Drawing.Point(104, 137)
        Me.utMileageRate.Name = "utMileageRate"
        Me.utMileageRate.ReadOnly = True
        Me.utMileageRate.Size = New System.Drawing.Size(65, 21)
        Me.utMileageRate.TabIndex = 4
        Me.utMileageRate.TabStop = False
        Me.utMileageRate.Tag = ".MileageRate"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 23)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "Miles Driven:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMiles
        '
        Me.utMiles.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMiles.Location = New System.Drawing.Point(103, 114)
        Me.utMiles.Name = "utMiles"
        Me.utMiles.Size = New System.Drawing.Size(65, 21)
        Me.utMiles.TabIndex = 3
        Me.utMiles.Tag = ".Miles"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 23)
        Me.Label6.TabIndex = 154
        Me.Label6.Text = "D.T. Hours:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utDTHrs
        '
        Appearance16.ForeColorDisabled = System.Drawing.Color.Black
        Me.utDTHrs.Appearance = Appearance16
        Me.utDTHrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utDTHrs.Location = New System.Drawing.Point(103, 64)
        Me.utDTHrs.Name = "utDTHrs"
        Me.utDTHrs.Size = New System.Drawing.Size(65, 21)
        Me.utDTHrs.TabIndex = 2
        Me.utDTHrs.Tag = ".DTHrs"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 23)
        Me.Label5.TabIndex = 152
        Me.Label5.Text = "O.T. Hours:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utOTHrs
        '
        Appearance17.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOTHrs.Appearance = Appearance17
        Me.utOTHrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOTHrs.Location = New System.Drawing.Point(103, 40)
        Me.utOTHrs.Name = "utOTHrs"
        Me.utOTHrs.Size = New System.Drawing.Size(65, 21)
        Me.utOTHrs.TabIndex = 1
        Me.utOTHrs.Tag = ".OTHrs"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 23)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "Reg. Hours:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utRegHrs
        '
        Appearance18.ForeColorDisabled = System.Drawing.Color.Black
        Me.utRegHrs.Appearance = Appearance18
        Me.utRegHrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utRegHrs.Location = New System.Drawing.Point(103, 15)
        Me.utRegHrs.Name = "utRegHrs"
        Me.utRegHrs.Size = New System.Drawing.Size(65, 21)
        Me.utRegHrs.TabIndex = 0
        Me.utRegHrs.Tag = ".RegHrs"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Location = New System.Drawing.Point(341, 276)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(307, 196)
        Me.UltraGrid1.TabIndex = 3
        Me.UltraGrid1.TabStop = False
        Me.UltraGrid1.Tag = "EmplPeriodDeductions"
        Me.UltraGrid1.Text = "Deductions"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnEdit)
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Location = New System.Drawing.Point(342, 475)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(306, 48)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(100, 17)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(64, 24)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "&Edit"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(234, 17)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 24)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        Me.btnExit.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(8, 17)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 24)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.uchTaxable6)
        Me.GroupBox4.Controls.Add(Me.uchTaxable5)
        Me.GroupBox4.Controls.Add(Me.uchTaxable4)
        Me.GroupBox4.Controls.Add(Me.uchTaxable3)
        Me.GroupBox4.Controls.Add(Me.uchTaxable2)
        Me.GroupBox4.Controls.Add(Me.uchTaxable1)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.utMiscIncome6)
        Me.GroupBox4.Controls.Add(Me.ucboMiscIncome6)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.utMiscIncome5)
        Me.GroupBox4.Controls.Add(Me.ucboMiscIncome5)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.utMiscIncome4)
        Me.GroupBox4.Controls.Add(Me.ucboMiscIncome4)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.utMiscIncome3)
        Me.GroupBox4.Controls.Add(Me.ucboMiscIncome3)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.utMiscIncome2)
        Me.GroupBox4.Controls.Add(Me.ucboMiscIncome2)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.utMiscIncome1)
        Me.GroupBox4.Controls.Add(Me.ucboMiscIncome1)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 349)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(336, 176)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "EmployeeMiscCharges"
        Me.GroupBox4.Text = "Misc. Income"
        '
        'uchTaxable6
        '
        Appearance19.ForeColor = System.Drawing.Color.Black
        Appearance19.ForeColorDisabled = System.Drawing.Color.Black
        Appearance19.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable6.Appearance = Appearance19
        Me.uchTaxable6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Appearance20.ForeColor = System.Drawing.Color.Black
        Appearance20.ForeColorDisabled = System.Drawing.Color.Black
        Appearance20.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable6.CheckedAppearance = Appearance20
        Me.uchTaxable6.Location = New System.Drawing.Point(251, 139)
        Me.uchTaxable6.Name = "uchTaxable6"
        Me.uchTaxable6.Size = New System.Drawing.Size(64, 20)
        Me.uchTaxable6.TabIndex = 17
        Me.uchTaxable6.Tag = ""
        Me.uchTaxable6.Text = "Taxable"
        '
        'uchTaxable5
        '
        Appearance21.ForeColor = System.Drawing.Color.Black
        Appearance21.ForeColorDisabled = System.Drawing.Color.Black
        Appearance21.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable5.Appearance = Appearance21
        Me.uchTaxable5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Appearance22.ForeColor = System.Drawing.Color.Black
        Appearance22.ForeColorDisabled = System.Drawing.Color.Black
        Appearance22.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable5.CheckedAppearance = Appearance22
        Me.uchTaxable5.Location = New System.Drawing.Point(252, 114)
        Me.uchTaxable5.Name = "uchTaxable5"
        Me.uchTaxable5.Size = New System.Drawing.Size(64, 20)
        Me.uchTaxable5.TabIndex = 14
        Me.uchTaxable5.Tag = ""
        Me.uchTaxable5.Text = "Taxable"
        '
        'uchTaxable4
        '
        Appearance23.ForeColor = System.Drawing.Color.Black
        Appearance23.ForeColorDisabled = System.Drawing.Color.Black
        Appearance23.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable4.Appearance = Appearance23
        Me.uchTaxable4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Appearance24.ForeColor = System.Drawing.Color.Black
        Appearance24.ForeColorDisabled = System.Drawing.Color.Black
        Appearance24.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable4.CheckedAppearance = Appearance24
        Me.uchTaxable4.Location = New System.Drawing.Point(252, 90)
        Me.uchTaxable4.Name = "uchTaxable4"
        Me.uchTaxable4.Size = New System.Drawing.Size(64, 20)
        Me.uchTaxable4.TabIndex = 11
        Me.uchTaxable4.Tag = ""
        Me.uchTaxable4.Text = "Taxable"
        '
        'uchTaxable3
        '
        Appearance25.ForeColor = System.Drawing.Color.Black
        Appearance25.ForeColorDisabled = System.Drawing.Color.Black
        Appearance25.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable3.Appearance = Appearance25
        Me.uchTaxable3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Appearance26.ForeColor = System.Drawing.Color.Black
        Appearance26.ForeColorDisabled = System.Drawing.Color.Black
        Appearance26.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable3.CheckedAppearance = Appearance26
        Me.uchTaxable3.Location = New System.Drawing.Point(252, 66)
        Me.uchTaxable3.Name = "uchTaxable3"
        Me.uchTaxable3.Size = New System.Drawing.Size(64, 20)
        Me.uchTaxable3.TabIndex = 8
        Me.uchTaxable3.Tag = ""
        Me.uchTaxable3.Text = "Taxable"
        '
        'uchTaxable2
        '
        Appearance27.ForeColor = System.Drawing.Color.Black
        Appearance27.ForeColorDisabled = System.Drawing.Color.Black
        Appearance27.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable2.Appearance = Appearance27
        Me.uchTaxable2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Appearance28.ForeColor = System.Drawing.Color.Black
        Appearance28.ForeColorDisabled = System.Drawing.Color.Black
        Appearance28.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable2.CheckedAppearance = Appearance28
        Me.uchTaxable2.Location = New System.Drawing.Point(252, 43)
        Me.uchTaxable2.Name = "uchTaxable2"
        Me.uchTaxable2.Size = New System.Drawing.Size(64, 20)
        Me.uchTaxable2.TabIndex = 5
        Me.uchTaxable2.Tag = ""
        Me.uchTaxable2.Text = "Taxable"
        '
        'uchTaxable1
        '
        Appearance29.ForeColor = System.Drawing.Color.Black
        Appearance29.ForeColorDisabled = System.Drawing.Color.Black
        Appearance29.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable1.Appearance = Appearance29
        Me.uchTaxable1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Appearance30.ForeColor = System.Drawing.Color.Black
        Appearance30.ForeColorDisabled = System.Drawing.Color.Black
        Appearance30.TextHAlign = Infragistics.Win.HAlign.Right
        Me.uchTaxable1.CheckedAppearance = Appearance30
        Me.uchTaxable1.Location = New System.Drawing.Point(252, 20)
        Me.uchTaxable1.Name = "uchTaxable1"
        Me.uchTaxable1.Size = New System.Drawing.Size(64, 20)
        Me.uchTaxable1.TabIndex = 2
        Me.uchTaxable1.Tag = ""
        Me.uchTaxable1.Text = "Taxable"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(127, 136)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 23)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Amount: $"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMiscIncome6
        '
        Appearance31.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance31.ForeColor = System.Drawing.Color.Black
        Appearance31.ForeColorDisabled = System.Drawing.Color.Black
        Appearance31.TextHAlign = Infragistics.Win.HAlign.Left
        Me.utMiscIncome6.Appearance = Appearance31
        Me.utMiscIncome6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMiscIncome6.Location = New System.Drawing.Point(183, 136)
        Me.utMiscIncome6.Name = "utMiscIncome6"
        Me.utMiscIncome6.Size = New System.Drawing.Size(64, 21)
        Me.utMiscIncome6.TabIndex = 16
        Me.utMiscIncome6.Tag = ""
        '
        'ucboMiscIncome6
        '
        Me.ucboMiscIncome6.AutoEdit = False
        Me.ucboMiscIncome6.DisplayMember = ""
        Me.ucboMiscIncome6.Location = New System.Drawing.Point(24, 136)
        Me.ucboMiscIncome6.Name = "ucboMiscIncome6"
        Me.ucboMiscIncome6.Size = New System.Drawing.Size(96, 21)
        Me.ucboMiscIncome6.TabIndex = 15
        Me.ucboMiscIncome6.Tag = ".MiscIncomeID.view..MiscIncome.MiscIncomeID.MiscIncomeName"
        Me.ucboMiscIncome6.ValueMember = ""
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(127, 112)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 23)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "Amount: $"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMiscIncome5
        '
        Appearance32.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance32.ForeColor = System.Drawing.Color.Black
        Appearance32.ForeColorDisabled = System.Drawing.Color.Black
        Appearance32.TextHAlign = Infragistics.Win.HAlign.Left
        Me.utMiscIncome5.Appearance = Appearance32
        Me.utMiscIncome5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMiscIncome5.Location = New System.Drawing.Point(183, 112)
        Me.utMiscIncome5.Name = "utMiscIncome5"
        Me.utMiscIncome5.Size = New System.Drawing.Size(64, 21)
        Me.utMiscIncome5.TabIndex = 13
        Me.utMiscIncome5.Tag = ""
        '
        'ucboMiscIncome5
        '
        Me.ucboMiscIncome5.AutoEdit = False
        Me.ucboMiscIncome5.DisplayMember = ""
        Me.ucboMiscIncome5.Location = New System.Drawing.Point(24, 112)
        Me.ucboMiscIncome5.Name = "ucboMiscIncome5"
        Me.ucboMiscIncome5.Size = New System.Drawing.Size(96, 21)
        Me.ucboMiscIncome5.TabIndex = 12
        Me.ucboMiscIncome5.Tag = ".MiscIncomeID.view..MiscIncome.MiscIncomeID.MiscIncomeName"
        Me.ucboMiscIncome5.ValueMember = ""
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(127, 88)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 23)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "Amount: $"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMiscIncome4
        '
        Appearance33.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance33.ForeColor = System.Drawing.Color.Black
        Appearance33.ForeColorDisabled = System.Drawing.Color.Black
        Appearance33.TextHAlign = Infragistics.Win.HAlign.Left
        Me.utMiscIncome4.Appearance = Appearance33
        Me.utMiscIncome4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMiscIncome4.Location = New System.Drawing.Point(183, 88)
        Me.utMiscIncome4.Name = "utMiscIncome4"
        Me.utMiscIncome4.Size = New System.Drawing.Size(64, 21)
        Me.utMiscIncome4.TabIndex = 10
        Me.utMiscIncome4.Tag = ""
        '
        'ucboMiscIncome4
        '
        Me.ucboMiscIncome4.AutoEdit = False
        Me.ucboMiscIncome4.DisplayMember = ""
        Me.ucboMiscIncome4.Location = New System.Drawing.Point(24, 88)
        Me.ucboMiscIncome4.Name = "ucboMiscIncome4"
        Me.ucboMiscIncome4.Size = New System.Drawing.Size(96, 21)
        Me.ucboMiscIncome4.TabIndex = 9
        Me.ucboMiscIncome4.Tag = ".MiscIncomeID.view..MiscIncome.MiscIncomeID.MiscIncomeName"
        Me.ucboMiscIncome4.ValueMember = ""
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(127, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 23)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Amount: $"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMiscIncome3
        '
        Appearance34.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance34.ForeColor = System.Drawing.Color.Black
        Appearance34.ForeColorDisabled = System.Drawing.Color.Black
        Appearance34.TextHAlign = Infragistics.Win.HAlign.Left
        Me.utMiscIncome3.Appearance = Appearance34
        Me.utMiscIncome3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMiscIncome3.Location = New System.Drawing.Point(183, 64)
        Me.utMiscIncome3.Name = "utMiscIncome3"
        Me.utMiscIncome3.Size = New System.Drawing.Size(64, 21)
        Me.utMiscIncome3.TabIndex = 7
        Me.utMiscIncome3.Tag = ""
        '
        'ucboMiscIncome3
        '
        Me.ucboMiscIncome3.AutoEdit = False
        Me.ucboMiscIncome3.DisplayMember = ""
        Me.ucboMiscIncome3.Location = New System.Drawing.Point(24, 64)
        Me.ucboMiscIncome3.Name = "ucboMiscIncome3"
        Me.ucboMiscIncome3.Size = New System.Drawing.Size(96, 21)
        Me.ucboMiscIncome3.TabIndex = 6
        Me.ucboMiscIncome3.Tag = ".MiscIncomeID.view..MiscIncome.MiscIncomeID.MiscIncomeName"
        Me.ucboMiscIncome3.ValueMember = ""
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(127, 40)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 23)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Amount: $"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMiscIncome2
        '
        Appearance35.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance35.ForeColor = System.Drawing.Color.Black
        Appearance35.ForeColorDisabled = System.Drawing.Color.Black
        Appearance35.TextHAlign = Infragistics.Win.HAlign.Left
        Me.utMiscIncome2.Appearance = Appearance35
        Me.utMiscIncome2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMiscIncome2.Location = New System.Drawing.Point(183, 40)
        Me.utMiscIncome2.Name = "utMiscIncome2"
        Me.utMiscIncome2.Size = New System.Drawing.Size(64, 21)
        Me.utMiscIncome2.TabIndex = 4
        Me.utMiscIncome2.Tag = ""
        '
        'ucboMiscIncome2
        '
        Me.ucboMiscIncome2.AutoEdit = False
        Me.ucboMiscIncome2.DisplayMember = ""
        Me.ucboMiscIncome2.Location = New System.Drawing.Point(24, 40)
        Me.ucboMiscIncome2.Name = "ucboMiscIncome2"
        Me.ucboMiscIncome2.Size = New System.Drawing.Size(96, 21)
        Me.ucboMiscIncome2.TabIndex = 3
        Me.ucboMiscIncome2.Tag = ".MiscIncomeID.view..MiscIncome.MiscIncomeID.MiscIncomeName"
        Me.ucboMiscIncome2.ValueMember = ""
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(127, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 23)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Amount: $"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMiscIncome1
        '
        Appearance36.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance36.ForeColor = System.Drawing.Color.Black
        Appearance36.ForeColorDisabled = System.Drawing.Color.Black
        Appearance36.TextHAlign = Infragistics.Win.HAlign.Left
        Me.utMiscIncome1.Appearance = Appearance36
        Me.utMiscIncome1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMiscIncome1.Location = New System.Drawing.Point(183, 17)
        Me.utMiscIncome1.Name = "utMiscIncome1"
        Me.utMiscIncome1.Size = New System.Drawing.Size(64, 21)
        Me.utMiscIncome1.TabIndex = 1
        Me.utMiscIncome1.Tag = ""
        '
        'ucboMiscIncome1
        '
        Me.ucboMiscIncome1.AutoEdit = False
        Me.ucboMiscIncome1.DisplayMember = ""
        Me.ucboMiscIncome1.Location = New System.Drawing.Point(24, 17)
        Me.ucboMiscIncome1.Name = "ucboMiscIncome1"
        Me.ucboMiscIncome1.Size = New System.Drawing.Size(96, 21)
        Me.ucboMiscIncome1.TabIndex = 0
        Me.ucboMiscIncome1.Tag = ".MiscIncomeID.view..MiscIncome.MiscIncomeID.MiscIncomeName....1"
        Me.ucboMiscIncome1.ValueMember = ""
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Location = New System.Drawing.Point(341, 134)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(307, 136)
        Me.UltraGrid2.TabIndex = 5
        Me.UltraGrid2.TabStop = False
        Me.UltraGrid2.Tag = "EmplPeriodDeductions"
        Me.UltraGrid2.Text = "Input History Of This Period"
        '
        'TotalHoursInput2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(656, 533)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Name = "TotalHoursInput2"
        Me.Tag = "EMPLOYEEACTIVITY"
        Me.Text = "Period Ending Input"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utClassID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utWCCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDept, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utoffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utPayRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utEmployeeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utBranchFS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utMisc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFuelSur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTotalHrs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAutoPay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utHrsPay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMileageRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utDTHrs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOTHrs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRegHrs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.utMiscIncome6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboMiscIncome6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMiscIncome5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboMiscIncome5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMiscIncome4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboMiscIncome4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMiscIncome3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboMiscIncome3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMiscIncome2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboMiscIncome2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMiscIncome1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboMiscIncome1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub StandardFormPrep()

        'Standard Code for Most Unison Form's Load Event
        AddHandler Me.Activated, AddressOf Form_Activated
        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

    End Sub

    Private Sub TotalHoursInput2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        StandardFormPrep()

        GroupBox4.Tag = HRTblPath & GroupBox4.Tag

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler utRegHrs.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler utDTHrs.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler utOTHrs.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler utMiles.KeyPress, AddressOf Value_Int_KeyPress
        AddHandler utMileageRate.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler utPayRate.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler utHrsPay.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler utAutoPay.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler utEmployeeID.KeyPress, AddressOf Value_Int_KeyPress
        'AddHandler utInvoiceNo.KeyPress, AddressOf Value_Int_KeyPress
        '
        cmdTrans = Nothing

        UltraDate1.Nullable = True
        UltraDate1.Value = DateAdd(DateInterval.Day, 0, Date.Today)
        UltraDate1.FormatString = "MM/dd/yyyy"

        utEmployee.Enabled = False
        utEmployeeID.MaxLength = 7

        AddHandler ucboDept.Leave, AddressOf UCbo_Leave
        ucboDept.Enabled = False

        UltraGrid1.Text = "Deductions"
        'UltraGrid2.Text = "Misc. Income"

        FillUCombo(ucboMiscIncome1, "", "", "Select MiscIncomeID, MiscIncomeName from " & HRTblPath & "MiscIncome where Active = 1", HRTblPath, True)
        FillUCombo(ucboMiscIncome2, "", "", "Select MiscIncomeID, MiscIncomeName from " & HRTblPath & "MiscIncome where Active = 1", HRTblPath, True)
        FillUCombo(ucboMiscIncome3, "", "", "Select MiscIncomeID, MiscIncomeName from " & HRTblPath & "MiscIncome where Active = 1", HRTblPath, True)
        FillUCombo(ucboMiscIncome4, "", "", "Select MiscIncomeID, MiscIncomeName from " & HRTblPath & "MiscIncome where Active = 1", HRTblPath, True)
        FillUCombo(ucboMiscIncome5, "", "", "Select MiscIncomeID, MiscIncomeName from " & HRTblPath & "MiscIncome where Active = 1", HRTblPath, True)
        FillUCombo(ucboMiscIncome6, "", "", "Select MiscIncomeID, MiscIncomeName from " & HRTblPath & "MiscIncome where Active = 1", HRTblPath, True)
        AddHandler ucboMiscIncome1.Leave, AddressOf UCbo_Leave
        AddHandler ucboMiscIncome2.Leave, AddressOf UCbo_Leave
        AddHandler ucboMiscIncome3.Leave, AddressOf UCbo_Leave
        AddHandler ucboMiscIncome4.Leave, AddressOf UCbo_Leave
        AddHandler ucboMiscIncome5.Leave, AddressOf UCbo_Leave

        EnableInput(False)
    End Sub

    Private Sub utEmployeeID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utEmployeeID.Leave
        Dim row As DataRow
        Dim gEmpl, gEmplID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim EmplHidCols() As String = {"EmplGroupID"}

        Select Case sender.Name
            Case "utEmployeeID"
                gEmpl = utEmployee
                gEmplID = utEmployeeID
            Case Else
                MsgBox("Unknown Control.")
                Exit Sub
        End Select

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gEmpl.Text = ""
            sender.text = ""
            utOfficeID.Text = ""
            utoffice.Text = ""
            UltraGrid2.DataSource = Nothing
            'utBranchFS.Text = ""
            ClearDept()
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, gEmplID, "" & HRTblPath & "EmployeesBase", "ID", "ID", "*", "Employees", " Where UPPER(STATUS) = 'A'", False, EmplHidCols) Then
                If ReturnRowByID(gEmplID.Text, row, "" & HRTblPath & "EmployeesBase", "", "ID") Then
                    Dim MidName As String
                    If Len(CStr(IIf(row("MiddleName") Is Nothing, "", row("MiddleName")))) > 0 Then
                        MidName = CStr(row("MiddleName")).Substring(0, 1)
                    Else
                        MidName = ""
                    End If
                    gEmpl.Text = row("FirstName") & " " & MidName & " " & row("LastName")
                    utOfficeID.Text = IIf(row("OfficeID") Is Nothing, 0, row("OfficeID"))
                    row = Nothing
                    LoadDept()
                Else
                    MsgBox("Employee Not Found.")
                    gEmplID.Text = ""
                    gEmpl.Text = ""
                    utOfficeID.Text = ""
                    ClearDept()
                End If
            Else
                'MsgBox("Truck Not Found.")
                gEmplID.Text = ""
                gEmpl.Text = ""
                utOfficeID.Text = ""
                ClearDept()
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub btnEmpl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployee.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim EmplHidCols() As String = {"EmplGroupID"}
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gEmpl, gEmplID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Select Case sender.Name
            Case "btnEmployee"
                gEmpl = utEmployee
                gEmplID = utEmployeeID
        End Select

        SelectSQL = "Select * from " & HRTblPath & "EmployeesBase WHERE UPPER(STATUS) = 'A' order by LastName"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet
            Srch.HidCols = EmplHidCols

            Srch.UltraGrid1.Text = "Employees"
            Srch.Text = "Employees"
            Srch.ShowDialog()
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                'MsgBox("Zipcode Leave: " & Err.Message)
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
                ' CANCEL PRESSED
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch osqlexception As SqlException
                MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    'AcctName.Text = ugRow.Cells("Name").Text
                    gEmpl.Text = ugRow.Cells("FirstName").Value & " " & CStr(ugRow.Cells("MiddleName").Value).Substring(0, IIf(Len(ugRow.Cells("MiddleName").Value) > 0, 1, 0)) & " " & ugRow.Cells("LastName").Value
                    gEmplID.Text = ugRow.Cells("ID").Text
                    utOfficeID.Text = IIf(ugRow.Cells("OfficeID").Value Is Nothing, 0, ugRow.Cells("OfficeID").Value)
                    Srch = Nothing
                    gEmpl.Modified = False
                    gEmplID.Modified = False
                    LoadDept()
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                Else
                    'MsgBox("Employee Not Found.")
                    gEmplID.Text = ""
                    gEmpl.Text = ""
                    utOfficeID.Text = ""
                    ClearDept()
                End If
            End Try
        End If

    End Sub

    Private Sub LoadDept()
        ucboDept.Enabled = True
        FillUCombo(ucboDept, "", "", "Select ep.DeptNo, dp.Department, cl.Class, ep.WCCode, ep.PayRate, ep.MileageRate from " & HRTblPath & "EmployeePayRates ep left outer join " & HRTblPath & "Departments dp on ep.DeptNo = dp.DeptNo Left outer join " & HRTblPath & "CLASSES cl on ep.ClassID = cl.ClassID where ep.EmployeeID = " & utEmployeeID.Text.Trim, HRTblPath, True, False)
        FillDeductions()
        FillInputHistory()
        EnableInput(False)
        ucboDept.Focus()

    End Sub
    Private Sub ClearDept()
        'ucboDept.Dispose()
        If Not cmdTrans Is Nothing Then
            If cmdTrans.Connection.State <> ConnectionState.Closed And cmdTrans.Connection.State <> ConnectionState.Broken Then
                cmdTrans.Transaction.Rollback()
                cmdTrans.Connection.Close()
            End If
        End If
        cmdTrans = Nothing

        ucboDept.Text = ""
        ucboDept.DataSource = Nothing
        UltraGrid1.DataSource = Nothing
        'utEmployeeID.Focus()
        ''EnableInput(False)
    End Sub

    Private Sub utPayRate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles utPayRate.Click

    End Sub

    Private Sub utPayRate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utPayRate.Leave, utMileageRate.Leave
        sender.readonly = True
    End Sub
    Private Sub FillInputHistory()
        If utEmployeeID.Text.Trim = "" Then Exit Sub

        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim HidCols() As String = {"RowID", "EmployeeID", "DeductionID"}
        Dim i As Integer
        Dim SQLSelect, DateRngCond, AcctCond, FromLocCond, ToLocCond, TRNumCond, ThirdPCond, EventCond, Address3 As String


        ' For Routesheet based on Scans:  SUBSTRING(ThirdPartyBarcode, 2 - 57 / ASCII(LEFT(ThirdPartyBarcode, 1)), LEN(ThirdPartyBarcode)) AS XThirdPartyBarcodeNum, '' as RteSheetTime, '' as RteSheetAddr,
        SQLSelect = "Select ea.* from " & HRTblPath & "EmployeeActivity ea where ea.PayrollDate = @PAYDATE AND ea.EmployeeID = @EMPLID order by ea.EmployeeID desc"
        SQLSelect = SQLSelect.Replace("@PAYDATE", "'" & UltraDate1.Text & "'")
        SQLSelect = SQLSelect.Replace("@EMPLID", utEmployeeID.Text)

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid2, dtSet, -1, HidCols, 0)
        'UltraGrid2.DataSource = dtSet
        'UGLoadLayout(Me, UltraGrid2, 1)
        UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGrid2.DisplayLayout.AutoFitColumns = False
        For i = 0 To UltraGrid2.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = True
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next
        UltraGrid2.DisplayLayout.Bands(0).Columns(0).Width = 20

        UltraGrid2.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'UltraGrid2.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid2.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid2.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid2.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid2.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        'UltraGrid2.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid2.DisplayLayout.GroupByBox.Hidden = True
        'UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        'UltraGrid2.Text = "Packages"

    End Sub
    Private Sub FillDeductions()
        If utEmployeeID.Text.Trim = "" Then Exit Sub

        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim HidCols() As String = {"EmployeeID", "DeductionID"}
        Dim i As Integer
        Dim SQLSelect, DateRngCond, AcctCond, FromLocCond, ToLocCond, TRNumCond, ThirdPCond, EventCond, Address3 As String


        ' For Routesheet based on Scans:  SUBSTRING(ThirdPartyBarcode, 2 - 57 / ASCII(LEFT(ThirdPartyBarcode, 1)), LEN(ThirdPartyBarcode)) AS XThirdPartyBarcodeNum, '' as RteSheetTime, '' as RteSheetAddr,
        SQLSelect = "Select EmployeeID, ep.DeductionID, d.Deduction, Amount from " & HRTblPath & "EmployeeDeductions ep left outer join " & HRTblPath & "DEDUCTIONS d on ep.DeductionID = d.DeductionID Where EmployeeId = " & utEmployeeID.Text.Trim

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid1, dtSet, -1, HidCols, 0)
        'UltraGrid1.DataSource = dtSet
        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGrid1.DisplayLayout.AutoFitColumns = True
        For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = True
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next
        UltraGrid1.DisplayLayout.Bands(0).Columns(0).Width = 20

        UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid1.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        'UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
        'UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        'UltraGrid1.Text = "Packages"

    End Sub

    Private Sub ucboDept_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDept.TextChanged
        DeptModified = True
        EnableInput(False)
    End Sub

    Private Sub ucboDept_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDept.Leave
        Dim row, row2 As DataRow

        If DeptModified = False Then Exit Sub

        DeptModified = False

        If ucboDept.Value Is Nothing Then Exit Sub
        If ucboDept.Text.Trim = "" Then Exit Sub

        If ReturnRowByID(ucboDept.Value, row, "" & HRTblPath & "EmployeePayRates", " EmployeeID = " & utEmployeeID.Text.Trim, "DeptNo") Then
            If ReturnRowByID(ucboDept.Value, row2, "" & HRTblPath & "EmployeeActivity", " EmployeeID = " & utEmployeeID.Text.Trim & " AND PayRollDate = '" & UltraDate1.Text & "' AND Processed = 1 ", "DeptNo") Then
                MsgBox("Dept.No. " & ucboDept.Value & " for Period Ending '" & UltraDate1.Text & "' has been PROCESSED for this employee and is not editable.")
                ucboDept.Value = Nothing
                ucboDept.Text = ""
                ucboDept.Focus()
                row = Nothing
                row2 = Nothing
                Exit Sub
            End If
            row2 = Nothing
            EnableInput(True)
            utPayRate.Text = IIf(row("PayRate") Is Nothing, 0, row("PayRate"))
            utMileageRate.Text = IIf(row("MileageRate") Is Nothing, 0, row("MileageRate"))
            utClassID.Text = IIf(row("ClassID") Is Nothing, 0, row("ClassID"))
            'utClass.Text = IIf(row("Class") Is Nothing, 0, row("Class"))
            utWCCode.Text = IIf(row("WCCode") Is Nothing, 0, row("WCCode"))
            row = Nothing
            If LoadPreviousIncome(UltraDate1.Text, utEmployeeID.Text, ucboDept.Value) = True Then

            End If
        Else
            MsgBox("No Departments Found for this employee.")
            EnableInput(False)
            Exit Sub
        End If

    End Sub

    Private Function LoadPreviousIncome(ByVal PayrollDate As String, ByVal EmployeeID As Int32, ByVal DeptNo As String) As Boolean
        Dim sqlSelect As String = "Select emc.EmployeeID, emc.PayrollDate, emc.DeptNo, isnull(emc.ChargeID, 0) as ChargeID, isnull(emc.Description, '') as Description, isnull(emc.Amount, 0.00) as Amount, emc.Processed from " & HRTblPath & "EmployeeMiscCharges emc where emc.Type = 'I' and emc.PayrollDate = @PAYDATE AND emc.EmployeeID = @EMPLID and emc.DeptNo = @DEPTNO order by emc.Processed Desc "
        Dim row As DataRow
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim ctrl, ctrl2 As Control
        Dim ucboIdx As Int16 = 1
        Dim ucbo As Infragistics.Win.UltraWinGrid.UltraCombo
        Dim ut As Infragistics.Win.UltraWinEditors.UltraTextEditor

        LoadPreviousIncome = True ' No Previous Data

        sqlSelect = sqlSelect.Replace("@PAYDATE", "'" & PayrollDate & "'")
        sqlSelect = sqlSelect.Replace("@EMPLID", EmployeeID)
        sqlSelect = sqlSelect.Replace("@DEPTNO", "'" & DeptNo & "'")

        PopulateDataset2(dtAdapter, dtSet, sqlSelect)

        If dtSet.Tables(0).Rows.Count > 0 Then
            'See if there is any processed income, if TRUE prevent inputting for this department.
            If dtSet.Tables(0).Rows(0).Item("Processed") = 1 Then
                MsgBox("This Department has processed-Misc.Income(s). You can not add any Income.")
                GroupBox4.Enabled = False
                LoadPreviousIncome = True
            Else
                dtView.Table = dtSet.Tables(0)
                LoadPreviousIncome = True
                For Each row In dtSet.Tables(0).Rows
                    If row("ChargeID") > 0 Then ' Has been 1 Why??
                        For Each ctrl In GroupBox4.Controls
                            If ctrl.GetType.ToString = "Infragistics.Win.UltraWinGrid.UltraCombo" Then
                                ucbo = ctrl
                                If ucbo.Name = "ucboMiscIncome" & ucboIdx Then
                                    For Each ctrl2 In GroupBox4.Controls
                                        If ctrl2.GetType.ToString = "Infragistics.Win.UltraWinEditors.UltraTextEditor" And ctrl2.Name = "utMiscIncome" & ucboIdx Then
                                            ut = ctrl2
                                            Exit For
                                        End If
                                    Next
                                    ucboIdx += 1
                                    ucbo.Value = row("ChargeID")
                                    ut.Text = Format(Val(row("Amount")), "0.00")
                                End If
                            End If
                        Next
                    Else
                        ucboMiscIncome6.Text = CStr(row("Description")).ToUpper
                        utMiscIncome6.Text = Format(Val(row("Amount")), "0.00")
                        Exit For
                    End If
                Next
            End If
        End If
        dtView.Dispose()
        dtView = Nothing
        dtSet.Dispose()
        dtAdapter.Dispose()
        dtSet = Nothing
        dtAdapter = Nothing
    End Function

    Private Function LoadPreviousInput(ByVal PayrollDate As String, ByVal EmployeeID As Int32, ByVal RowID As String) As Boolean
        Dim sqlSelect As String = "Select ea.*, isnull(emc.ChargeID, 0) as ChargeID, isnull(emc.Description, '') as Description, isnull(emc.Amount, 0.00) as Amount, emc.Taxable from " & HRTblPath & "EmployeeActivity ea left outer join " & HRTblPath & "EmployeeMiscCharges emc on ea.PayrollDate = emc.payrolldate and ea.EmployeeID = emc.EmployeeID and ea.DeptNo = emc.DeptNo AND emc.Type = 'I' where ea.Processed = 0 and ea.PayrollDate = @PAYDATE AND ea.EmployeeID = @EMPLID and ea.RowID = @ROWID order by emc.ChargeID desc"
        Dim sqlSelect2 As String = "Select ea.* from " & HRTblPath & "EmployeeActivity ea where ea.Processed = 0  and ea.PayrollDate = @PAYDATE AND ea.EmployeeID = @EMPLID and ea.RowID = @ROWID "
        Dim row As DataRow
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim ucboIdx As Int16 = 1
        Dim ucbo As Infragistics.Win.UltraWinGrid.UltraCombo
        Dim ut As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim uch As Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Dim ctrl, ctrl2 As Control
        Dim dtView As New DataView

        sqlSelect = sqlSelect.Replace("@PAYDATE", "'" & PayrollDate & "'")
        sqlSelect = sqlSelect.Replace("@EMPLID", EmployeeID)
        sqlSelect = sqlSelect.Replace("@ROWID", "'" & RowID & "'")

        sqlSelect2 = sqlSelect2.Replace("@PAYDATE", "'" & PayrollDate & "'")
        sqlSelect2 = sqlSelect2.Replace("@EMPLID", EmployeeID)
        sqlSelect2 = sqlSelect2.Replace("@ROWID", "'" & RowID & "'")

        LoadPreviousInput = False ' No Previous Data
        PopulateDataset2(dtAdapter, dtSet, sqlSelect)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            LoadPreviousInput = True
            FormLoad(GroupBox2, dtView)
            utPayRate.Text = dtView(0).Item("PayRate")
            If Not cmdTrans Is Nothing Then
                cmdTrans.Transaction.Rollback()
                If cmdTrans.Connection.State = ConnectionState.Open Then
                    cmdTrans.Connection.Close()
                End If
                cmdTrans = Nothing
            End If
            If EditForm(GroupBox2, sqlSelect2, EditAction.START, cmdTrans) = False Then
                cmdTrans = Nothing
            End If

            For Each row In dtSet.Tables(0).Rows
                If row("ChargeID") > 0 Then ' Has been 1 Why??
                    Select Case ucboIdx ' ucbo.Name.Substring(ucbo.Name.Length - 1)
                        Case 1
                            ucbo = ucboMiscIncome1
                            uch = uchTaxable1
                            ut = utMiscIncome1
                        Case 2
                            ucbo = ucboMiscIncome2
                            uch = uchTaxable2
                            ut = utMiscIncome2
                        Case 3
                            ucbo = ucboMiscIncome3
                            uch = uchTaxable3
                            ut = utMiscIncome3
                        Case 4
                            ucbo = ucboMiscIncome4
                            uch = uchTaxable4
                            ut = utMiscIncome4
                        Case 5
                            ucbo = ucboMiscIncome5
                            uch = uchTaxable5
                            ut = utMiscIncome5
                        Case 6
                            ucbo = ucboMiscIncome6
                            uch = uchTaxable6
                            ut = utMiscIncome6
                    End Select
                    ucboIdx += 1
                    ucbo.Value = row("ChargeID")
                    ut.Text = Format(Val(row("Amount")), "0.00")
                    uch.Checked = row("Taxable")

                    'For Each ctrl In GroupBox4.Controls
                    '    If ctrl.GetType.ToString = "Infragistics.Win.UltraWinGrid.UltraCombo" Then
                    '        ucbo = ctrl
                    '        If ucbo.Name = "ucboMiscIncome" & ucboIdx Then

                    '            For Each ctrl2 In GroupBox4.Controls
                    '                If ctrl2.GetType.ToString = "Infragistics.Win.UltraWinEditors.UltraTextEditor" And ctrl2.Name = "utMiscIncome" & ucboIdx Then
                    '                    ut = ctrl2
                    '                    Exit For
                    '                End If
                    '            Next
                    '            ucboIdx += 1
                    '            ucbo.Value = row("ChargeID")
                    '            ut.Text = Format(Val(row("Amount")), "0.00")
                    '        End If
                    '    End If
                    'Next
                Else
                    ucboMiscIncome6.Text = CStr(row("Description")).ToUpper
                    utMiscIncome6.Text = Format(Val(row("Amount")), "0.00")
                    Exit For
                End If
            Next
        Else ' No Rows Returned...
        End If

        dtView.Dispose()
        dtView = Nothing
        dtSet.Dispose()
        dtAdapter.Dispose()
        dtSet = Nothing
        dtAdapter = Nothing

    End Function
    Private Sub EnableInput(ByVal Status As Boolean)
        utPayRate.Text = ""
        utMileageRate.Text = ""
        utWCCode.Text = ""
        utClassID.Text = ""
        utClass.Text = ""
        'utBranchFS.Text = "0.000"

        utRegHrs.Enabled = True
        utOTHrs.Enabled = True
        utDTHrs.Enabled = True

        utHrsPay.Text = "0.00"
        utTotalHrs.Text = "0.00"
        utAutoPay.Text = "0.00"
        utFuelSur.Text = "0.00"
        uchVoucher.Checked = False
        uchMisc.Checked = False
        utRowID.Text = ""

        ClearForm(GroupBox4)
        'utMiscIncome1.Text = "0.00"
        'utMiscIncome2.Text = "0.00"
        'utMiscIncome3.Text = "0.00"
        'utMiscIncome4.Text = "0.00"
        'utMiscIncome5.Text = "0.00"
        'utMiscIncome6.Text = "0.00"

        utRegHrs.Text = "0.00"
        utOTHrs.Text = "0.00"
        utDTHrs.Text = "0.00"
        utMiles.Text = "0"
        GroupBox2.Enabled = Status
        GroupBox4.Enabled = Status
        UltraGrid1.Enabled = Status
        'UltraGrid2.Enabled = Status
        btnSave.Enabled = Status
        If Status = True Then
            utRegHrs.Focus()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim ID As Integer
        Dim IdentIns As Boolean = False
        Dim CritTmp, StrArr() As String
        Dim SQLSelect As String = "Select PayrollDate, EmployeeID, OfficeID, Office, DeptNo, RegHrs, OTHrs, DTHrs, Miles, MileageRate, PayRate, WCCode, ClassID, Class from " & HRTblPath & "EmployeeActivity"

        If utEmployeeID.Text.Trim = "" Then
            MsgBox("Employee not selected.")
            Exit Sub
        End If
        If ucboDept.Value Is Nothing Then
            MsgBox("Department not selected.")
            Exit Sub
        End If
        If ucboDept.Text.Trim = "" Then
            MsgBox("Department not selected.")
            Exit Sub
        End If

        If utRegHrs.Enabled = True And uchVoucher.Checked = False And uchMisc.Checked = False Then
            MsgBox("Hours Added through this screen should be either Voucher or Miscellaneous." & vbCrLf & "Time-Card Hours should get input in Time-Card Input Screen.")
            Exit Sub
        End If

        'StrArr = GetCtrldbFieldInfo(utEmployeeID)

        'If EmplID.Text.Trim <> "" Then

        '    CritTmp = EmplCriteria2.Replace("@EmplID", EmplID.Text)
        '    IdentIns = True
        '    If btnEdit.Text.ToUpper = "&CANCEL" Then
        '        EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "View"
        '    Else
        '        EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "INSERT"
        '    End If
        '    'EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName)
        '    'New rule: USE INSERT or UPDATE instead of VIEW ...
        'Else
        '    CritTmp = ""
        '    IdentIns = False
        '    EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "View"
        'End If
        'If Val(EmplID.Text.Trim) < 0 Then
        '    MsgBox("Please input valid ID number.")
        '    Exit Sub
        'End If
        If cmdTrans Is Nothing Then
            CritTmp = ""
        Else
            'CritTmp = " Where PayrollDate = '" & UltraDate1.Text & "' AND EmployeeID = " & utEmployeeID.Text & " AND DeptNo = '" & ucboDept.Value & "' "
            If utRowID.Text.Trim = "" Then
                MsgBox("RowID field is not set. SAVE aborted.")
                Exit Sub
            End If
            CritTmp = " Where RowID = " & utRowID.Text & " "
        End If
        If SaveMiscIncome(cmdTrans) = False Then
            Exit Sub
        End If
        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, CritTmp, IdentIns) Then
            Me.Text = MeText & " -- " & "Saved: " & UltraDate1.Text & " - EmplID: " & utEmployeeID.Text.Trim & " - Dept.: " & ucboDept.Text & "."
            ucboDept.Value = Nothing
            ucboDept.Text = ""
            FillInputHistory()
            utEmployeeID.Focus()
            'Dim row As DataRow
            'Dim dtA As New SqlDataAdapter
            'If EmplID.Text = "" Then
            '    LoadData("", "P")
            'Else
            '    LoadData(EmplID.Text, "C")
            'End If
            'btnEdit.Text = "&Edit"
            'btnNew.Text = "&New"
            'Me.Text = MeText & " -- Record Updated."
            ''PopulateDataset2(dtA, dtSet, SQLSelect)
            'sender.text = "&New"
        End If

    End Sub
    Private Function SaveMiscIncome(ByVal cmd As SqlCommand) As Boolean
        Dim ctrl, ctrl2 As Control
        Dim ucbo As Infragistics.Win.UltraWinGrid.UltraCombo
        Dim ut As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim uch As Infragistics.Win.UltraWinEditors.UltraCheckEditor

        Dim SelectArr(), sqlInsert As String
        Dim i, ArrIdx As Integer

        ArrIdx = -1
        SaveMiscIncome = False
        For Each ctrl In GroupBox4.Controls
            If ctrl.GetType.ToString = "Infragistics.Win.UltraWinGrid.UltraCombo" Then
                ucbo = ctrl
                If ucbo.Text.Trim <> "" Then
                    ArrIdx += 1
                    ReDim Preserve SelectArr(ArrIdx)
                    Select Case ucbo.Name.Substring(ucbo.Name.Length - 1)
                        Case "1"
                            uch = uchTaxable1
                            ut = utMiscIncome1
                        Case "2"
                            uch = uchTaxable2
                            ut = utMiscIncome2
                        Case "3"
                            uch = uchTaxable3
                            ut = utMiscIncome3
                        Case "4"
                            uch = uchTaxable4
                            ut = utMiscIncome4
                        Case "5"
                            uch = uchTaxable5
                            ut = utMiscIncome5
                        Case "6"
                            uch = uchTaxable6
                            ut = utMiscIncome6
                    End Select
                    'For Each ctrl2 In GroupBox4.Controls
                    '    If ctrl2.GetType.ToString = "Infragistics.Win.UltraWinEditors.UltraTextEditor" And ctrl2.Name = "utMiscIncome" & ucbo.Name.Substring(ucbo.Name.Length - 1) Then
                    '        ut = ctrl2
                    '        Exit For
                    '    End If
                    'Next
                    SelectArr(ArrIdx) = "Select '" & UltraDate1.Text & "' as PayrollDate, '" & utEmployeeID.Text & "' as EmployeeID, '" & ucboDept.Value & "' as DeptNo, 'I' as Type, " & IIf(ucbo.Value Is Nothing, "0", CStr(ucbo.Value)) & " as ChargeID, '" & ucbo.Text.Trim & "' as Description, '" & ut.Text.Trim & "' as Amount, " & IIf(uch.Checked, "1", "0") & " as Taxable " 'utMiscIncome1
                End If
            End If
        Next

        If ArrIdx >= 0 Then
            sqlInsert = "Delete from " & HRTblPath & "EmployeeMiscCharges where EmployeeID = " & utEmployeeID.Text & " AND PayrollDate = '" & UltraDate1.Text & "' AND DeptNo = '" & ucboDept.Value & "' ; "
            sqlInsert = sqlInsert & " Insert into " & HRTblPath & "EmployeeMiscCharges(PayrollDate, EmployeeID, DeptNo, Type, ChargeID, Description, Amount, Taxable) "
            sqlInsert = sqlInsert & SelectArr(i)
            For i = 1 To SelectArr.Length - 1
                sqlInsert = sqlInsert & " UNION " & SelectArr(i)
            Next
            'sqlInsert = sqlInsert & ") as TmpTable; "

            If ExecuteQuery(sqlInsert, cmd, False) = False Then
                MsgBox("Misc. Income Insert Failed. Save cancelled.")
                Exit Function
            End If
        End If
        SaveMiscIncome = True

    End Function
    Private Sub utAutoPay_BeforeEnterEditMode(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles utAutoPay.BeforeEnterEditMode, utDTHrs.BeforeEnterEditMode, utEmployeeID.BeforeEnterEditMode, utHrsPay.BeforeEnterEditMode, utMileageRate.BeforeEnterEditMode, utMiles.BeforeEnterEditMode, utOTHrs.BeforeEnterEditMode, utPayRate.BeforeEnterEditMode, utRegHrs.BeforeEnterEditMode
        sender.SelectAll()
    End Sub

    Private Sub utRegHrs_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utRegHrs.ValueChanged

    End Sub

    Private Sub utRegHrs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utRegHrs.Leave, utDTHrs.Leave, utMileageRate.Leave, utMiles.Leave, utMileageRate.Leave, utOTHrs.Leave, utPayRate.Leave, utMiscIncome1.Leave, utMiscIncome2.Leave, utMiscIncome3.Leave, utMiscIncome4.Leave, utMiscIncome5.Leave, utMiscIncome6.Leave
        Dim gUT As Infragistics.Win.UltraWinEditors.UltraTextEditor

        gUT = sender
        If gUT.Name <> "utMiles" Then
            gUT.Text = Format(Val(gUT.Text), "0.#0")
        End If

        Select Case gUT.Name
            Case "utRegHrs"
                utHrsPay.Text = Format(CalcHrsPay(), "0.00")
                utTotalHrs.Text = Format(Val(utRegHrs.Text) + Val(utOTHrs.Text) + Val(utDTHrs.Text), "0.00")
            Case "utOTHrs"
                utHrsPay.Text = Format(CalcHrsPay(), "0.00")
                utTotalHrs.Text = Format(Val(utRegHrs.Text) + Val(utOTHrs.Text) + Val(utDTHrs.Text), "0.00")
            Case "utDTHrs"
                utHrsPay.Text = Format(CalcHrsPay(), "0.00")
                utTotalHrs.Text = Format(Val(utRegHrs.Text) + Val(utOTHrs.Text) + Val(utDTHrs.Text), "0.00")
            Case "utMiles"
                utAutoPay.Text = Format(CalcAutoPay(), "0.00")
                utFuelSur.Text = Format(Val(utMiles.Text) * Val(utBranchFS.Text), "0.00")
            Case "utPayRate"
                utHrsPay.Text = Format(CalcHrsPay(), "0.00")
            Case "utMileageRate"
                utAutoPay.Text = Format(CalcAutoPay(), "0.00")
                utFuelSur.Text = Format(Val(utMiles.Text) * Val(utBranchFS.Text), "0.00")
                'utMileageRate.ReadOnly = True
        End Select

    End Sub

    Private Sub utHrsPay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utHrsPay.ValueChanged, utAutoPay.ValueChanged, utFuelSur.ValueChanged  ' utPayRate.ValueChanged, utMileageRate.ValueChanged,
        Dim gUT As Infragistics.Win.UltraWinEditors.UltraTextEditor

        gUT = sender
        gUT.Text = Format(Val(gUT.Text), "0.#0")
        utTotalHrs.Text = Format(Val(utTotalHrs.Text), "0.00")

    End Sub

    Private Function CalcHrsPay() As Decimal
        CalcHrsPay = Val(utRegHrs.Text) * Val(utPayRate.Text) + Val(utOTHrs.Text) * Val(utPayRate.Text) * 1.5 + Val(utDTHrs.Text) * Val(utPayRate.Text) * 2
    End Function

    Private Function CalcAutoPay() As Decimal
        CalcAutoPay = Val(utMiles.Text) * Val(utMileageRate.Text)
    End Function

    Private Sub utClassID_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles utClassID.ValueChanged
        Dim row As DataRow
        If sender.text.trim = "" Then
            utClass.Text = ""
            Exit Sub
        End If
        If ReturnRowByID(sender.text, row, HRTblPath & "CLASSES", , "ClassID") Then
            utClass.Text = row("class")
        End If

        row = Nothing
    End Sub

    Private Sub utOfficeID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utOfficeID.ValueChanged
        Dim row As DataRow
        If sender.text.trim = "" Then
            utBranchFS.Text = "0.000"
            Exit Sub
        End If
        If ReturnRowByID(utOfficeID.Text.Trim, row, "" & AppTblPath & "ServiceOffices", "", "ID") Then
            utoffice.Text = IIf(row("Name") Is Nothing, "N/A", row("Name"))
        End If
        row = Nothing
        If ReturnRowByID(sender.text, row, HRTblPath & "ServiceOffice_FS", , "OfficeID") Then
            utBranchFS.Text = row("FuelSurcharge_Rate")
        End If

        row = Nothing
    End Sub

    Private Sub ucboMiscIncome6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboMiscIncome6.Leave
        sender.text = sender.text.toupper
    End Sub

    Private Sub TotalHoursInput2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not cmdTrans Is Nothing Then
            If cmdTrans.Connection.State <> ConnectionState.Closed And cmdTrans.Connection.State <> ConnectionState.Broken Then
                cmdTrans.Transaction.Rollback()
                cmdTrans.Connection.Close()
            End If
        End If
        cmdTrans = Nothing
    End Sub


    Private Sub utPayRate_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles utMileageRate.MouseDown, utPayRate.MouseDown

        Dim x As New EnterTextBox
        Dim FileName As String

        On Error GoTo ErrTrap

        'If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "Enter Password:"
        x.Label2.Text = ""
        x.Label2.Visible = False
        x.btnBrowse1.Visible = False

        x.Text = "Password needed to change Pay Rate"
        x.TextBox1.Enabled = True
        x.TextBox1.Text = ""
        x.btnSave.Text = "&OK"

        x.TextBox2.Visible = False
        'x.Show()
        x.ShowDialog(Me)
        If x.DialogResult = DialogResult.OK Then
            If x.TextBox1.Text.Trim <> "chpy" Then
                MsgBox("Incorrect password.")
                Exit Sub
            End If
            x.Dispose()
            x = Nothing
            sender.enabled = True
            sender.readonly = False
            sender.focus()
        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("Error: " & Err.Description)
        End If

    End Sub

    Private Sub UltraDate1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraDate1.ValueChanged
        utEmployeeID.Text = ""
        ClearDept()
    End Sub

    Private Sub UltraGrid2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid2.GotFocus
        'btnEdit.Enabled = True
    End Sub

    Private Sub UltraGrid2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid2.LostFocus
        'btnEdit.Enabled = False
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        ugRow = UltraGrid2.ActiveRow
        If UltraGrid2.ActiveRow Is Nothing Then
            MsgBox("Please Select a ROW of the Input History for Editing.")
            Exit Sub
        End If
        If UltraGrid2.ActiveRow.ListObject Is Nothing Then
            MsgBox("Please Select a ROW of the Input History for Editing.")
            Exit Sub
        End If
        If UltraGrid2.ActiveRow.Cells("Processed").Value = True Then
            MsgBox("This entry has been PROCESSED and can not be edited.")
            Exit Sub
        End If
        If MsgBox("Are you sure you want to EDIT the previously entered data for Dept.: '" & UltraGrid2.ActiveRow.Cells("DeptNo").Value & "'?", MsgBoxStyle.YesNo, "Edit A Previuos Record") = MsgBoxResult.Yes Then
            ucboDept.Focus()

            ucboDept.Value = ugRow.Cells("DeptNo").Value
            'ucboDept.SelectNextControl(ucboDept, True, True, False, True)
            utEmployeeID.Focus()
            If LoadPreviousInput(ugRow.Cells("PayrollDate").Text, ugRow.Cells("EmployeeID").Value, ugRow.Cells("RowID").Value) = True Then
                utTotalHrs.Text = Format(Val(utRegHrs.Text) + Val(utOTHrs.Text) + Val(utDTHrs.Text), "0.00")
                If ugRow.Cells("Misc").Value + ugRow.Cells("Voucher").Value = 0 Then
                    utRegHrs.Enabled = False
                    utOTHrs.Enabled = False
                    utDTHrs.Enabled = False
                End If
                utAutoPay.Text = Format(CalcAutoPay(), "0.00")
                utFuelSur.Text = Format(Val(utMiles.Text) * Val(utBranchFS.Text), "0.00")
            End If
        End If

    End Sub

    Private Sub uchMisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchMisc.CheckedChanged
        Select Case uchMisc.Checked
            Case True
                utMisc.Enabled = True
            Case False
                utMisc.Text = ""
                utMisc.Enabled = False
        End Select
    End Sub

End Class
