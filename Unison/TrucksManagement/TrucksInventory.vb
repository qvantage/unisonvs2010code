Imports System.Data
Imports System.Data.SqlClient

Public Class TrucksInventory
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String
    Dim MeText As String
    Dim cmdTrans As SqlCommand

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
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents utMilesIn As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents utOperatorIn As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents utInventID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnInventList As System.Windows.Forms.Button
    Friend WithEvents btnProviders As System.Windows.Forms.Button
    Friend WithEvents UltraDateIn As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents utOfficeIn As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnOfficeIn As System.Windows.Forms.Button
    Friend WithEvents OfficeIDIn As System.Windows.Forms.TextBox
    Friend WithEvents utRemarks As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents OfficeIDOut As System.Windows.Forms.TextBox
    Friend WithEvents btnOfficeOut As System.Windows.Forms.Button
    Friend WithEvents utOfficeOut As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utOperatorOut As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utMilesOut As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraDateOut As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents utProvider As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utProviderID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents rbInventID As System.Windows.Forms.RadioButton
    Friend WithEvents rbTruckID As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents utTruckIDSrch As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utVIN As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utTruckID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLicPlate As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utTruckSize As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label16 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TrucksInventory))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbTruckID = New System.Windows.Forms.RadioButton
        Me.rbInventID = New System.Windows.Forms.RadioButton
        Me.utInventID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnInventList = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.utTruckIDSrch = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.utTruckSize = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label16 = New System.Windows.Forms.Label
        Me.utVIN = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.utTruckID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utProviderID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utLicPlate = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utProvider = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utRemarks = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnProviders = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.OfficeIDIn = New System.Windows.Forms.TextBox
        Me.btnOfficeIn = New System.Windows.Forms.Button
        Me.utOfficeIn = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.utOperatorIn = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.utMilesIn = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.UltraDateIn = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.OfficeIDOut = New System.Windows.Forms.TextBox
        Me.btnOfficeOut = New System.Windows.Forms.Button
        Me.utOfficeOut = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label10 = New System.Windows.Forms.Label
        Me.utOperatorOut = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.utMilesOut = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label12 = New System.Windows.Forms.Label
        Me.UltraDateOut = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.utInventID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTruckIDSrch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utTruckSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utVIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTruckID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utProviderID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLicPlate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.utOfficeIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOperatorIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMilesIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDateIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.utOfficeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOperatorOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMilesOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDateOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 333)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(728, 40)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(650, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(155, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 21)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
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
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(79, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbTruckID)
        Me.GroupBox3.Controls.Add(Me.rbInventID)
        Me.GroupBox3.Controls.Add(Me.utInventID)
        Me.GroupBox3.Controls.Add(Me.btnPrev)
        Me.GroupBox3.Controls.Add(Me.btnNext)
        Me.GroupBox3.Controls.Add(Me.btnInventList)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.utTruckIDSrch)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(728, 80)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search"
        '
        'rbTruckID
        '
        Me.rbTruckID.Location = New System.Drawing.Point(120, 45)
        Me.rbTruckID.Name = "rbTruckID"
        Me.rbTruckID.Size = New System.Drawing.Size(16, 24)
        Me.rbTruckID.TabIndex = 113
        '
        'rbInventID
        '
        Me.rbInventID.Location = New System.Drawing.Point(120, 16)
        Me.rbInventID.Name = "rbInventID"
        Me.rbInventID.Size = New System.Drawing.Size(16, 24)
        Me.rbInventID.TabIndex = 112
        '
        'utInventID
        '
        Me.utInventID.Location = New System.Drawing.Point(203, 16)
        Me.utInventID.Name = "utInventID"
        Me.utInventID.Size = New System.Drawing.Size(80, 21)
        Me.utInventID.TabIndex = 0
        Me.utInventID.Tag = ".Truck_Invent_ID.view"
        '
        'btnPrev
        '
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.Location = New System.Drawing.Point(304, 16)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(24, 23)
        Me.btnPrev.TabIndex = 1
        '
        'btnNext
        '
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.Location = New System.Drawing.Point(328, 16)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(24, 23)
        Me.btnNext.TabIndex = 2
        '
        'btnInventList
        '
        Me.btnInventList.Location = New System.Drawing.Point(368, 16)
        Me.btnInventList.Name = "btnInventList"
        Me.btnInventList.Size = New System.Drawing.Size(75, 21)
        Me.btnInventList.TabIndex = 3
        Me.btnInventList.Text = "Se&lect"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(143, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Invent.ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(144, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "Truck ID :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'utTruckIDSrch
        '
        Me.utTruckIDSrch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTruckIDSrch.Location = New System.Drawing.Point(202, 47)
        Me.utTruckIDSrch.Name = "utTruckIDSrch"
        Me.utTruckIDSrch.Size = New System.Drawing.Size(80, 21)
        Me.utTruckIDSrch.TabIndex = 4
        Me.utTruckIDSrch.Tag = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.utTruckSize)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.utVIN)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.utTruckID)
        Me.GroupBox2.Controls.Add(Me.utProviderID)
        Me.GroupBox2.Controls.Add(Me.utLicPlate)
        Me.GroupBox2.Controls.Add(Me.utProvider)
        Me.GroupBox2.Controls.Add(Me.utRemarks)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnProviders)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(728, 104)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'utTruckSize
        '
        Me.utTruckSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTruckSize.Location = New System.Drawing.Point(481, 48)
        Me.utTruckSize.Name = "utTruckSize"
        Me.utTruckSize.Size = New System.Drawing.Size(96, 21)
        Me.utTruckSize.TabIndex = 6
        Me.utTruckSize.Tag = ".[Truck Size]"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(440, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 16)
        Me.Label16.TabIndex = 118
        Me.Label16.Text = "Size:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utVIN
        '
        Me.utVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utVIN.Location = New System.Drawing.Point(440, 16)
        Me.utVIN.Name = "utVIN"
        Me.utVIN.Size = New System.Drawing.Size(272, 21)
        Me.utVIN.TabIndex = 2
        Me.utVIN.Tag = ".VIN"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(408, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 16)
        Me.Label15.TabIndex = 116
        Me.Label15.Text = "VIN :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(64, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 114
        Me.Label14.Text = "Truck ID :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'utTruckID
        '
        Me.utTruckID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTruckID.Location = New System.Drawing.Point(120, 16)
        Me.utTruckID.Name = "utTruckID"
        Me.utTruckID.Size = New System.Drawing.Size(80, 21)
        Me.utTruckID.TabIndex = 0
        Me.utTruckID.Tag = ".TruckID"
        '
        'utProviderID
        '
        Me.utProviderID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utProviderID.Enabled = False
        Me.utProviderID.Location = New System.Drawing.Point(304, 47)
        Me.utProviderID.Name = "utProviderID"
        Me.utProviderID.Size = New System.Drawing.Size(38, 21)
        Me.utProviderID.TabIndex = 4
        Me.utProviderID.Tag = ".Provider_ID"
        '
        'utLicPlate
        '
        Me.utLicPlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLicPlate.Location = New System.Drawing.Point(288, 16)
        Me.utLicPlate.Name = "utLicPlate"
        Me.utLicPlate.Size = New System.Drawing.Size(80, 21)
        Me.utLicPlate.TabIndex = 1
        Me.utLicPlate.Tag = ".Lic_Plate"
        '
        'utProvider
        '
        Me.utProvider.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utProvider.Location = New System.Drawing.Point(120, 47)
        Me.utProvider.Name = "utProvider"
        Me.utProvider.Size = New System.Drawing.Size(176, 21)
        Me.utProvider.TabIndex = 3
        Me.utProvider.Tag = ".Provider"
        '
        'utRemarks
        '
        Me.utRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utRemarks.Location = New System.Drawing.Point(120, 71)
        Me.utRemarks.Name = "utRemarks"
        Me.utRemarks.Size = New System.Drawing.Size(304, 21)
        Me.utRemarks.TabIndex = 7
        Me.utRemarks.Tag = ".Remarks"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(56, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "Remarks:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnProviders
        '
        Me.btnProviders.Location = New System.Drawing.Point(360, 47)
        Me.btnProviders.Name = "btnProviders"
        Me.btnProviders.Size = New System.Drawing.Size(63, 21)
        Me.btnProviders.TabIndex = 5
        Me.btnProviders.Text = "Select"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(208, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "License Plate :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(48, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "Provider :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.OfficeIDIn)
        Me.GroupBox4.Controls.Add(Me.btnOfficeIn)
        Me.GroupBox4.Controls.Add(Me.utOfficeIn)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.utOperatorIn)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.utMilesIn)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.UltraDateIn)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 189)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(360, 146)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "  In"
        '
        'OfficeIDIn
        '
        Me.OfficeIDIn.Enabled = False
        Me.OfficeIDIn.Location = New System.Drawing.Point(240, 114)
        Me.OfficeIDIn.Name = "OfficeIDIn"
        Me.OfficeIDIn.Size = New System.Drawing.Size(32, 20)
        Me.OfficeIDIn.TabIndex = 5
        Me.OfficeIDIn.Tag = ".Office_In_ID"
        Me.OfficeIDIn.Text = ""
        '
        'btnOfficeIn
        '
        Me.btnOfficeIn.Location = New System.Drawing.Point(280, 112)
        Me.btnOfficeIn.Name = "btnOfficeIn"
        Me.btnOfficeIn.Size = New System.Drawing.Size(75, 21)
        Me.btnOfficeIn.TabIndex = 4
        Me.btnOfficeIn.Text = "Select"
        '
        'utOfficeIn
        '
        Me.utOfficeIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeIn.Location = New System.Drawing.Point(76, 112)
        Me.utOfficeIn.Name = "utOfficeIn"
        Me.utOfficeIn.Size = New System.Drawing.Size(156, 21)
        Me.utOfficeIn.TabIndex = 3
        Me.utOfficeIn.Tag = ".Office_In"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Office:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utOperatorIn
        '
        Me.utOperatorIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOperatorIn.Location = New System.Drawing.Point(76, 82)
        Me.utOperatorIn.Name = "utOperatorIn"
        Me.utOperatorIn.Size = New System.Drawing.Size(156, 21)
        Me.utOperatorIn.TabIndex = 2
        Me.utOperatorIn.Tag = ".Operator_In"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Operator:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMilesIn
        '
        Me.utMilesIn.Location = New System.Drawing.Point(76, 52)
        Me.utMilesIn.Name = "utMilesIn"
        Me.utMilesIn.Size = New System.Drawing.Size(68, 21)
        Me.utMilesIn.TabIndex = 1
        Me.utMilesIn.Tag = ".Miles_In"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Mileage:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDateIn
        '
        Me.UltraDateIn.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDateIn.Location = New System.Drawing.Point(76, 24)
        Me.UltraDateIn.Name = "UltraDateIn"
        Me.UltraDateIn.Size = New System.Drawing.Size(112, 21)
        Me.UltraDateIn.TabIndex = 0
        Me.UltraDateIn.Tag = ".Date_In"
        Me.UltraDateIn.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(21, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Date :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.OfficeIDOut)
        Me.GroupBox5.Controls.Add(Me.btnOfficeOut)
        Me.GroupBox5.Controls.Add(Me.utOfficeOut)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.utOperatorOut)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.utMilesOut)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.UltraDateOut)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Location = New System.Drawing.Point(360, 189)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(360, 146)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "  Out"
        '
        'OfficeIDOut
        '
        Me.OfficeIDOut.Enabled = False
        Me.OfficeIDOut.Location = New System.Drawing.Point(240, 113)
        Me.OfficeIDOut.Name = "OfficeIDOut"
        Me.OfficeIDOut.Size = New System.Drawing.Size(32, 20)
        Me.OfficeIDOut.TabIndex = 5
        Me.OfficeIDOut.Tag = ".Office_Out_ID"
        Me.OfficeIDOut.Text = ""
        '
        'btnOfficeOut
        '
        Me.btnOfficeOut.Location = New System.Drawing.Point(280, 115)
        Me.btnOfficeOut.Name = "btnOfficeOut"
        Me.btnOfficeOut.Size = New System.Drawing.Size(75, 21)
        Me.btnOfficeOut.TabIndex = 4
        Me.btnOfficeOut.Text = "Select"
        '
        'utOfficeOut
        '
        Me.utOfficeOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeOut.Location = New System.Drawing.Point(76, 112)
        Me.utOfficeOut.Name = "utOfficeOut"
        Me.utOfficeOut.Size = New System.Drawing.Size(156, 21)
        Me.utOfficeOut.TabIndex = 3
        Me.utOfficeOut.Tag = ".Office_Out"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 106
        Me.Label10.Text = "Office:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utOperatorOut
        '
        Me.utOperatorOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOperatorOut.Location = New System.Drawing.Point(76, 82)
        Me.utOperatorOut.Name = "utOperatorOut"
        Me.utOperatorOut.Size = New System.Drawing.Size(156, 21)
        Me.utOperatorOut.TabIndex = 2
        Me.utOperatorOut.Tag = ".Operator_Out"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 104
        Me.Label11.Text = "Operator:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMilesOut
        '
        Me.utMilesOut.Location = New System.Drawing.Point(76, 52)
        Me.utMilesOut.Name = "utMilesOut"
        Me.utMilesOut.Size = New System.Drawing.Size(68, 21)
        Me.utMilesOut.TabIndex = 1
        Me.utMilesOut.Tag = ".Miles_Out"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(21, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 16)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "Mileage:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDateOut
        '
        Me.UltraDateOut.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDateOut.Location = New System.Drawing.Point(76, 24)
        Me.UltraDateOut.Name = "UltraDateOut"
        Me.UltraDateOut.Size = New System.Drawing.Size(112, 21)
        Me.UltraDateOut.TabIndex = 0
        Me.UltraDateOut.Tag = ".Date_Out"
        Me.UltraDateOut.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(21, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 16)
        Me.Label13.TabIndex = 100
        Me.Label13.Text = "Date :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TrucksInventory
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(728, 373)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "TrucksInventory"
        Me.Tag = "Inventory"
        Me.Text = "Trucks Inventory"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.utInventID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTruckIDSrch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utTruckSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utVIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTruckID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utProviderID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLicPlate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.utOfficeIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOperatorIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMilesIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDateIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.utOfficeOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOperatorOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMilesOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDateOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub TrucksInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MinWinSize As System.Drawing.Size

        ' btnEdit.Enabled = True
        'If utInventID.Text = "" Then
        '    btnEdit.Enabled = False 'Karina added

        'End If
        'btnEdit.Enabled = True
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = TrucksVars.TRUCKSTblPath & Me.Tag
            End If
        End If

        SQLSelect = "Select Truck_Invent_ID, TruckID, Lic_Plate, VIN, Provider_ID, Provider, Date_In, Miles_In, Office_In_ID, Office_In, Operator_In, Date_Out, Miles_Out, Office_Out_ID, Office_Out, Operator_Out, [Truck Size], Remarks from " & Me.Tag
        '
        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text
        cmdTrans = Nothing

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, TrucksVars.TRUCKSDBName, TRUCKSDBUser, TRUCKSDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        'MinWinSize.Width = btnExit.Left + btnExit.Width + 50

        'Me.MinimumSize = MinWinSize
        UltraDateIn.Nullable = True
        UltraDateIn.Value = Nothing 'Date.Now
        UltraDateIn.FormatString = "MM/dd/yyyy"

        UltraDateOut.Nullable = True
        UltraDateOut.Value = Nothing 'Date.Now
        UltraDateOut.FormatString = "MM/dd/yyyy"
        GroupBoxDis(False)
        rbInventID.Checked = True

    End Sub

    Private Sub GroupBoxDis(ByVal Status As Boolean)
        GroupBox2.Enabled = Status
        GroupBox4.Enabled = Status
        GroupBox5.Enabled = Status
        GroupBox3.Enabled = Not Status
    End Sub
    Private Sub LoadData(ByVal IDValue As String, Optional ByVal Direction As String = "C")
        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView
        Dim dtSet2 As New DataSet
        Dim TempQuery As String
        Dim CritTmp As String

       
        'If Val(IDValue) > 0 Then
        '    CritTmp = " Where ID = " & IDValue
        'Else
        '    CritTmp = ""
        'End If

        Select Case Direction.ToUpper
            Case "N"
                If Val(IDValue) = 0 Then
                    CritTmp = " Where Truck_Invent_ID > 0 "
                Else
                    CritTmp = " Where Truck_Invent_ID > " & IDValue
                End If
            Case "P"
                If Val(IDValue) = 0 Then
                    CritTmp = " Where Truck_Invent_ID < 999999999 "
                Else
                    CritTmp = " Where Truck_Invent_ID < " & IDValue
                End If
            Case Else
                CritTmp = " Where Truck_Invent_ID = " & IDValue
        End Select

        TempQuery = PrepSelectQuery(SQLSelect, CritTmp)

        PopulateDataset2(dtAdapter, dtSet2, TempQuery)
        If dtSet2 Is Nothing Then Exit Sub
        If dtSet2.Tables Is Nothing Then Exit Sub
        If dtSet2.Tables(0) Is Nothing Then Exit Sub

        If dtSet2.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No Records found.")
            'If Direction.ToUpper = "C" Then
            '    Group_EnDis(True)
            '    ClearForm(TabCtrl1)
            '    AcctName.Focus()
            '    'Change for Tab Based : ClearForm(GroupBox2)
            '    btnNew.Text = "&Cancel"
            '    btnSave.Text = "&Save"
            'Else
            '    MessageBox.Show("No Records found.")
            'End If
        Else
            dvAcct.Table = dtSet2.Tables(0)
            If Direction.ToUpper = "N" Then
                dvAcct.RowFilter = "Truck_Invent_ID = Min(Truck_Invent_ID)"
            ElseIf Direction.ToUpper = "P" Then
                dvAcct.RowFilter = "Truck_Invent_ID = Max(Truck_Invent_ID)"
            End If
            FormLoad(Me, dvAcct)
        End If
        dtSet2.Dispose()
        dtSet2 = Nothing

    End Sub
    ''Karina added Group_EnDis() and Btn_En() for buttons ability/enability usege.
    'Private Sub Group_EnDis(ByVal status As Boolean)
    '    GroupBox2.Enabled = status
    '    btnSave.Enabled = status
    '    Btn_En(status)
    'End Sub

    'Private Sub Btn_En(ByVal status As Boolean)
    '    btnSave.Enabled = status
    '    btnSave.Text = "&Save"
    '    If status = True Then 'Enable Editing
    '        If btnEdit.Text.ToUpper = "&CANCEL" Then
    '            btnNew.Enabled = False
    '        Else
    '            btnEdit.Enabled = False
    '        End If
    '    Else 'End Editing
    '        btnNew.Enabled = True
    '        btnEdit.Enabled = True
    '        btnEdit.Text = "&Edit"
    '        btnNew.Text = "&New"
    '    End If
    'End Sub


    Private Sub utInventID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utInventID.Leave
        'Dim row As DataRow
        Dim ID As Int16
        If sender.modified = False Then Exit Sub

        ID = Val(sender.text)
        ClearForm(Me)
        LoadData(ID)

        'If ReturnRowByID(sender.text, row, Me.Tag, "", "Invemtory_ID") Then
        '    ClearForm(Me)
        'End If
        'If SearchOnLeave(sender, sender, Me.Tag, "Inventory_ID", "TruckID", "Lic_Plate, Provider_ID, Provider, Date_In, Miles_In, Office_In_ID, Office_In, Operator_In, Date_Out, Miles_Out, Office_Out_ID, Office_Out, Operator_Out, [Truck Size], Remarks") Then

        'End If
    End Sub
    Private Sub rbInventID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInventID.CheckedChanged, rbTruckID.CheckedChanged
        Select Case sender.name
            Case "rbInventID"
                utInventID.Enabled = True
                utTruckIDSrch.Enabled = False
            Case "rbTruckID"
                utInventID.Enabled = False
                utTruckIDSrch.Enabled = True
            Case Else
                MsgBox("Invalid RadioButton")
                Exit Sub
        End Select
    End Sub

    Private Sub utTruckID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utTruckIDSrch.ValueChanged

    End Sub

    Private Sub utTruckIDSrch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utTruckIDSrch.Leave
        Dim ID As String
        Dim row As DataRow

        If sender.modified = False Then Exit Sub

        'ID = sender.text
        ClearForm(Me)
        'LoadData(ID)

        If SearchOnLeave(sender, utInventID, Me.Tag, "Truck_Invent_ID", "TruckID", "*", "Trucks", " AND Date_Out is null ") Then     '"Lic_Plate, Provider_ID, Provider, Date_In, Miles_In, Office_In_ID, Office_In, Operator_In, Date_Out, Miles_Out, Office_Out_ID, Office_Out, Operator_Out, [Truck Size], Remarks"
            ID = Val(utInventID.Text)
            sender.text = ""
            rbInventID.Checked = True
            LoadData(ID)
            'If ReturnRowByID(utInventID.Text, row, Me.Tag, "", "Truck_Invent_ID") Then
            '    ID = row("Truck_Invent_ID")
            '    LoadData(ID)
            '    row = Nothing
            'End If

        End If

    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        LoadData(Val(utInventID.Text), "P")
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadData(Val(utInventID.Text), "N")
    End Sub

    Private Sub btnInventList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventList.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select * from " & Me.Tag & " order by TruckID"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Trucks"
            Srch.Text = "Trucks"
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
                    utInventID.Text = ugRow.Cells("Truck_Invent_ID").Text
                    Srch = Nothing
                    utInventID.Modified = True
                    Dim ev As New System.EventArgs
                    utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If

    End Sub

    Private Sub utTruckID_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utTruckID.ValueChanged

    End Sub

    Private Sub utTruckID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utTruckID.Leave
        Dim ID As String
        Dim row As DataRow

        If sender.modified = False Then Exit Sub

        'ID = sender.text
        'LoadData(ID)
        If btnNew.Text = "&Cancel" Then
            If ReturnRowByID(utTruckID.Text, row, Me.Tag, " AND DATE_OUT IS NULL ", "TruckID") Then
                MsgBox("There is already an open record for this truck.")
                ClearForm(Me)
                sender.focus()
                row = Nothing
                Exit Sub
                'ID = row("Truck_Invent_ID")
                'LoadData(ID)
            End If
            If ReturnRowByID(utTruckID.Text, row, Me.Tag, "", "TruckID", "Select top 1 * from " & Me.Tag & " where TruckID = '" & utTruckID.Text & "' order by Date_Out Desc") Then
                utLicPlate.Text = row("Lic_Plate")
                utVIN.Text = row("VIN")
                utProvider.Text = row("Provider")
                utProvider.Modified = False
                utProviderID.Text = row("Provider_ID")
                'LoadData(ID)
                row = Nothing
                utRemarks.Focus()
            End If
            'Exit Sub
        ElseIf btnEdit.Text = "&Cancel" Then
            ' If overwriting ??
        Else
            MsgBox("Invalid Mode")
            Exit Sub
        End If
        'If SearchOnLeave(sender, utInventID, Me.Tag, "Truck_Invent_ID", "TruckID", "*", "Trucks", " AND Date_Out is null ") Then     '"Lic_Plate, Provider_ID, Provider, Date_In, Miles_In, Office_In_ID, Office_In, Operator_In, Date_Out, Miles_Out, Office_Out_ID, Office_Out, Operator_Out, [Truck Size], Remarks"
        '    ID = Val(utInventID.Text)
        '    LoadData(ID)
        'End If
    End Sub
    'Karina added utInventID.KeyPress to prevent user from entering alpha characters in int field!
    Private Sub Value_Int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles utMilesIn.KeyPress, utMilesOut.KeyPress, utInventID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    Private Sub utProvider_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utProvider.KeyUp
        TypeAhead(sender, e, TrucksVars.TRUCKSTblPath & "Providers", "Name", "")
        'sender.modified = True
    End Sub

    Private Sub utProvider_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utProvider.ValueChanged

    End Sub
    Private Sub utProvider_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utProvider.Leave
        Dim ID As String
        Dim row As DataRow

        If sender.modified = False Then Exit Sub

        'ID = sender.text
        'ClearForm(Me)
        'LoadData(ID)

        If SearchOnLeave(sender, utProviderID, TrucksVars.TRUCKSTblPath & "Providers", "Provider_ID", "Name", "*", "Providers", "") = False Then
            utProviderID.Text = ""
            'utprovider.Text = "" ' Can input invalid provider
        End If

    End Sub

    Private Sub btnProviders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProviders.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select * FROM " & TrucksVars.TRUCKSTblPath & "Providers order by Provider_ID"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Truck Providers"
            Srch.Text = "Truck Providers"
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
                    utProviderID.Text = ugRow.Cells("Provider_ID").Text
                    utProvider.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                    utProviderID.Modified = False
                    utProvider.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub utOfficeIn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utOfficeIn.Leave, utOfficeOut.Leave
        Dim ID As String
        Dim row As DataRow
        Dim senderid, sendername As Object

        If sender.modified = False Then Exit Sub

        If sender.name = "utOfficeOut" Then
            senderid = OfficeIDOut
            sendername = utOfficeOut
        Else
            senderid = OfficeIDIn
            sendername = utOfficeIn
        End If

        If sender.text.trim = "" Then
            sender.text = ""
            senderid.text = ""
            Exit Sub
        End If
        'ID = sender.text
        'ClearForm(Me)
        'LoadData(ID)

        If SearchOnLeave(sender, senderid, AppTblPath & "ServiceOffices", "ID", "Name", "*", "Offices", "") = False Then
            MsgBox("Office Not found.")
            sender.text = ""
            senderid.text = ""
            sender.focus()
        End If
    End Sub

    Private Sub btnOfficeIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOfficeIn.Click, btnOfficeOut.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim senderid, sendername As Object
        If sender.name = "btnOfficeOut" Then
            senderid = OfficeIDOut
            sendername = utOfficeOut
        Else
            senderid = OfficeIDIn
            sendername = utOfficeIn
        End If

        SelectSQL = "Select * FROM " & AppTblPath & "ServiceOffices where Active=1 order by ID"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Offices"
            Srch.Text = "Offices"
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
                    senderid.Text = ugRow.Cells("ID").Text
                    sendername.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                    senderid.Modified = False
                    sendername.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records
        If btnNew.Text = "&Cancel" Then
            MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If utTruckID.Text.Trim = "" Or utInventID.Text.Trim = "" Then Exit Sub

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLSelect, " AND Truck_Invent_ID = " & utInventID.Text), EditAction.START, cmdTrans) Then
                sender.text = "&Cancel"
                'AccountID.Enabled = False
                btnNew.Enabled = False 'Karina added
                GroupBoxDis(True)
                'btnSaveNew.Enabled = False
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                sender.text = "&Edit"
                LoadData(utInventID.Text)
                GroupBoxDis(False)
                btnNew.Enabled = True 'Karina added
                'btnSaveNew.Enabled = True
                'FormLoad(Me, dvCompany)
            End If
        End If

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'UltraGrid1.DeleteSelectedRows()
        If btnEdit.Text = "&Cancel" Then
            MessageBox.Show("You are in Edit mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If sender.text = "&New" Then
            ClearForm(Me)
            sender.text = "&Cancel"
            'btnSave.Text = "&Save"
            btnEdit.Enabled = False 'Karina added
            GroupBoxDis(True)
            utTruckID.Focus()
        Else
            sender.text = "&New"
            ClearForm(Me)
            btnEdit.Enabled = True 'Karina added
            GroupBoxDis(False)
            'btnSave.Text = "&Update"

        End If
    End Sub
    'Karina commented out and added TruckInventory_Closing()
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
        '        'Group_EnDis(False)
        '        sender.text = "&Edit"
        '    Else
        '        'Exit Sub
        '    End If

        'End If
        Me.Close()

    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim ID As Integer

        If utTruckID.Text.Trim = "" And UltraDateIn.Text.Trim = "" Then
            MsgBox("TruckID and InDate are empty.")
            Exit Sub
        End If
        If utTruckID.Text.Trim = "" Then
            MsgBox("TruckID is empty.")
            Exit Sub
        End If
        If UltraDateIn.Text.Trim = "" Then
            MsgBox("InDate is empty.")
            Exit Sub
        End If
        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, " WHERE Truck_Invent_ID = " & utInventID.Text) Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
            'Me.Text = MeText & " -- Record Updated."
            'PopulateDataset2(dtA, dtSet, SQLSelect)
            'sender.text = "&New"
            If utInventID.Text.Trim = "" Then
                LoadData(0, "P")
            Else
                LoadData(utInventID.Text)
            End If
            GroupBoxDis(False)
        End If
    End Sub
    'Karina 06.21.2005, changes btnExit_Click and added TrackInventory_Closing
    Private Sub TrackInventory_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                sender.text = "&Edit"
                'Group_EnDis(False)
            Else
                'Exit Sub
            End If
        End If
    End Sub
End Class
