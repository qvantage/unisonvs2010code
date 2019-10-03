'Be about to save the Plan Price Setup without entering the Module Name
'HOw to handle TAB on Grid2?
'Not able to save changes on Grid2
'Not able EDIT and SAVE Grid1

Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors


Public Class PricePlanSetup
    Inherits System.Windows.Forms.Form


    Dim sqlPricePlanEdit As String = _
            " Select pp.PlanID, pp.Plan_Name, pp.Charge_Code, pp.PlanTypeCode, " & _
            " pp.From_Zone, " & _
            " pp.To_Zone, " & _
            " pp.Start_Date, pp.End_Date, pp.ModuleName, pp.TableName, pp.ColumnTitle, pp.ColumnName, pp.ColumnPrefix, pp.ColumnSuffix, pp.OverLimit_Charge, pp.Taxable, pp.PerLocationID, pp.PerDayID, " & _
            " pp.Invoice_Title, pp.Description " & _
            " from " & BILLTblPath & "PricePlans pp "


    Dim SQLSelectAddCond As String = _
        "Select ppc.PlanID, ppc.ModuleName, ppc.TableName, ppc.ColumnName, ppc.ColumnTitle, ppc.[Operator], ppc.[Values] " & _
        "From " & BILLTblPath & "PricePlanCondition ppc left outer join " & BILLTblPath & "PricePlanConditionOperators ppco" & _
        "on ppco.Operator = ppc.Operator"

    Dim SQLSelectEdit As String = "Select PlanID, Plan_Name, PlanTypeCode, Charge_Code," & _
        "From_Zone, To_Zone, Start_Date, End_Date, ModuleName, TableName, ColumnName," & _
        "ColumnPrefix, ColumnSuffix, Invoice_Title, Taxable, Description, OverLimit_Charge, " & _
        "PerLocationID, PerDayID from " & BILLTblPath & "PricePlans"

    Dim SQLSelect3 As String 
    Dim cmdTrans As SqlCommand
    Dim Srch As SearchListings
    Dim HidCols3() As String = {"RowID", "PlanID"}
    Dim dtSetCond As New DataSet
    Dim dtSet3 As New DataSet
    Dim MeText As String
    Public SortColIdx2 As Int16 = 0

    Private PricePlanCharges As DataTable

    Dim DataModified As Boolean
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
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ucboPlanType As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents udStartDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents utToZone As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utFromZone As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utPlanName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents umskEndDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSelFromZ As System.Windows.Forms.Button
    Friend WithEvents btnSelectToZ As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents utModuleName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utTableName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utColumnPrefix As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utColumnSuffix As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSelModName As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents utInvoiceSelTitle As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents utDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents cbTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents utFromZoneID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utToZoneID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utPlanID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbPerLocation As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents utOverLimit_Charge As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents utValue As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ucboOperator As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid3 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ucboChargeCode As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents utColumnTitle As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utCondColumnTitle As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents utCondModuleName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utCondTableName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utColumnName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utCondColumnName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents gbConds As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCondColumn As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cbPerDay As System.Windows.Forms.CheckBox
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
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ucboPlanType = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.udStartDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.utToZone = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utFromZone = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utPlanName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label13 = New System.Windows.Forms.Label
        Me.umskEndDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnSelFromZ = New System.Windows.Forms.Button
        Me.btnSelectToZ = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.utModuleName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utTableName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utColumnTitle = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utColumnPrefix = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utColumnSuffix = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnSelModName = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cbPerDay = New System.Windows.Forms.CheckBox
        Me.utColumnName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label14 = New System.Windows.Forms.Label
        Me.utFromZoneID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utPlanID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.cbTaxable = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.utToZoneID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.utInvoiceSelTitle = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utOverLimit_Charge = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label18 = New System.Windows.Forms.Label
        Me.cbPerLocation = New System.Windows.Forms.CheckBox
        Me.ucboChargeCode = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.gbConds = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnCondColumn = New System.Windows.Forms.Button
        Me.utCondColumnName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utCondTableName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utCondModuleName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label15 = New System.Windows.Forms.Label
        Me.utValue = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label17 = New System.Windows.Forms.Label
        Me.ucboOperator = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label16 = New System.Windows.Forms.Label
        Me.utCondColumnTitle = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGrid3 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboPlanType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToZone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFromZone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utPlanName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utModuleName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTableName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utColumnTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utColumnPrefix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utColumnSuffix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.utColumnName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFromZoneID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utPlanID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToZoneID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utInvoiceSelTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOverLimit_Charge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboChargeCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConds.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.utCondColumnName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utCondTableName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utCondModuleName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboOperator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utCondColumnTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(16, 24)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Save"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(92, 24)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "&Edit"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(880, 24)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "&Exit"
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid2.Location = New System.Drawing.Point(752, 0)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(272, 208)
        Me.UltraGrid2.TabIndex = 1
        Me.UltraGrid2.Text = "Charges"
        '
        'ucboPlanType
        '
        Appearance1.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboPlanType.Appearance = Appearance1
        Me.ucboPlanType.AutoEdit = False
        Me.ucboPlanType.DisplayMember = ""
        Me.ucboPlanType.Enabled = False
        Me.ucboPlanType.Location = New System.Drawing.Point(280, 48)
        Me.ucboPlanType.Name = "ucboPlanType"
        Me.ucboPlanType.Size = New System.Drawing.Size(88, 21)
        Me.ucboPlanType.TabIndex = 2
        Me.ucboPlanType.Tag = ".PlanTypeCode...PricePlanTypes.PlanTypeCode.PlanType"
        Me.ucboPlanType.ValueMember = ""
        '
        'udStartDate
        '
        Appearance2.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.udStartDate.Appearance = Appearance2
        Me.udStartDate.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.udStartDate.Location = New System.Drawing.Point(96, 128)
        Me.udStartDate.Name = "udStartDate"
        Me.udStartDate.Size = New System.Drawing.Size(88, 21)
        Me.udStartDate.TabIndex = 7
        Me.udStartDate.Tag = ".Start_Date"
        Me.udStartDate.Value = Nothing
        '
        'utToZone
        '
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Me.utToZone.Appearance = Appearance3
        Me.utToZone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utToZone.Location = New System.Drawing.Point(96, 96)
        Me.utToZone.MaxLength = 20
        Me.utToZone.Name = "utToZone"
        Me.utToZone.Size = New System.Drawing.Size(100, 21)
        Me.utToZone.TabIndex = 5
        Me.utToZone.Tag = ".To_Zone_Name.view"
        '
        'utFromZone
        '
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Me.utFromZone.Appearance = Appearance4
        Me.utFromZone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFromZone.Location = New System.Drawing.Point(96, 72)
        Me.utFromZone.MaxLength = 20
        Me.utFromZone.Name = "utFromZone"
        Me.utFromZone.Size = New System.Drawing.Size(100, 21)
        Me.utFromZone.TabIndex = 3
        Me.utFromZone.Tag = ".FROM_ZONE_NAME.VIEW"
        '
        'utPlanName
        '
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Me.utPlanName.Appearance = Appearance5
        Me.utPlanName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utPlanName.Location = New System.Drawing.Point(96, 16)
        Me.utPlanName.MaxLength = 40
        Me.utPlanName.Name = "utPlanName"
        Me.utPlanName.Size = New System.Drawing.Size(224, 21)
        Me.utPlanName.TabIndex = 0
        Me.utPlanName.Tag = ".Plan_Name"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(216, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 12)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "End Date:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umskEndDate
        '
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Me.umskEndDate.Appearance = Appearance6
        Me.umskEndDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskEndDate.InputMask = "mm/dd/yyyy"
        Me.umskEndDate.Location = New System.Drawing.Point(280, 128)
        Me.umskEndDate.Name = "umskEndDate"
        Me.umskEndDate.Size = New System.Drawing.Size(80, 20)
        Me.umskEndDate.TabIndex = 8
        Me.umskEndDate.Tag = ".End_Date"
        Me.umskEndDate.Text = "//"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 12)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Plan Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(32, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 12)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "To Zone:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSelFromZ
        '
        Me.btnSelFromZ.Location = New System.Drawing.Point(200, 72)
        Me.btnSelFromZ.Name = "btnSelFromZ"
        Me.btnSelFromZ.Size = New System.Drawing.Size(75, 19)
        Me.btnSelFromZ.TabIndex = 4
        Me.btnSelFromZ.Text = "Select"
        '
        'btnSelectToZ
        '
        Me.btnSelectToZ.Location = New System.Drawing.Point(200, 96)
        Me.btnSelectToZ.Name = "btnSelectToZ"
        Me.btnSelectToZ.Size = New System.Drawing.Size(75, 19)
        Me.btnSelectToZ.TabIndex = 6
        Me.btnSelectToZ.Text = "Select"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(216, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Plan Type:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(32, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 12)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Start Date:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(32, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 12)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "From Zone:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utModuleName
        '
        Appearance7.ForeColorDisabled = System.Drawing.Color.Black
        Me.utModuleName.Appearance = Appearance7
        Me.utModuleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utModuleName.Enabled = False
        Me.utModuleName.Location = New System.Drawing.Point(471, 40)
        Me.utModuleName.MaxLength = 20
        Me.utModuleName.Name = "utModuleName"
        Me.utModuleName.Size = New System.Drawing.Size(200, 21)
        Me.utModuleName.TabIndex = 12
        Me.utModuleName.Tag = ".ModuleName"
        '
        'utTableName
        '
        Appearance8.ForeColorDisabled = System.Drawing.Color.Black
        Me.utTableName.Appearance = Appearance8
        Me.utTableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTableName.Location = New System.Drawing.Point(471, 64)
        Me.utTableName.MaxLength = 15
        Me.utTableName.Name = "utTableName"
        Me.utTableName.ReadOnly = True
        Me.utTableName.Size = New System.Drawing.Size(200, 21)
        Me.utTableName.TabIndex = 14
        Me.utTableName.TabStop = False
        Me.utTableName.Tag = ".TableName"
        '
        'utColumnTitle
        '
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Me.utColumnTitle.Appearance = Appearance9
        Me.utColumnTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utColumnTitle.Enabled = False
        Me.utColumnTitle.Location = New System.Drawing.Point(472, 16)
        Me.utColumnTitle.MaxLength = 15
        Me.utColumnTitle.Name = "utColumnTitle"
        Me.utColumnTitle.Size = New System.Drawing.Size(156, 21)
        Me.utColumnTitle.TabIndex = 15
        Me.utColumnTitle.TabStop = False
        Me.utColumnTitle.Tag = ".ColumnTitle"
        '
        'utColumnPrefix
        '
        Appearance10.ForeColorDisabled = System.Drawing.Color.Black
        Me.utColumnPrefix.Appearance = Appearance10
        Me.utColumnPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utColumnPrefix.Location = New System.Drawing.Point(472, 96)
        Me.utColumnPrefix.MaxLength = 15
        Me.utColumnPrefix.Name = "utColumnPrefix"
        Me.utColumnPrefix.ReadOnly = True
        Me.utColumnPrefix.Size = New System.Drawing.Size(50, 21)
        Me.utColumnPrefix.TabIndex = 16
        Me.utColumnPrefix.TabStop = False
        Me.utColumnPrefix.Tag = ".ColumnPrefix"
        '
        'utColumnSuffix
        '
        Appearance11.ForeColorDisabled = System.Drawing.Color.Black
        Me.utColumnSuffix.Appearance = Appearance11
        Me.utColumnSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utColumnSuffix.Location = New System.Drawing.Point(621, 96)
        Me.utColumnSuffix.MaxLength = 15
        Me.utColumnSuffix.Name = "utColumnSuffix"
        Me.utColumnSuffix.ReadOnly = True
        Me.utColumnSuffix.Size = New System.Drawing.Size(50, 21)
        Me.utColumnSuffix.TabIndex = 17
        Me.utColumnSuffix.TabStop = False
        Me.utColumnSuffix.Tag = ".ColumnSuffix"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(400, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 12)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Table Name:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(536, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 12)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Column Suffix:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(392, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 12)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Column Prefix:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(392, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 12)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Column Name:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(392, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 12)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Module Name:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSelModName
        '
        Me.btnSelModName.Location = New System.Drawing.Point(672, 16)
        Me.btnSelModName.Name = "btnSelModName"
        Me.btnSelModName.Size = New System.Drawing.Size(75, 19)
        Me.btnSelModName.TabIndex = 13
        Me.btnSelModName.Text = "Select"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(167, 24)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.TabIndex = 5
        Me.btnNew.Text = "&New"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraGrid2)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 208)
        Me.Panel1.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbPerDay)
        Me.GroupBox3.Controls.Add(Me.utColumnName)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.utFromZoneID)
        Me.GroupBox3.Controls.Add(Me.utPlanID)
        Me.GroupBox3.Controls.Add(Me.cbTaxable)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.utToZoneID)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.utInvoiceSelTitle)
        Me.GroupBox3.Controls.Add(Me.udStartDate)
        Me.GroupBox3.Controls.Add(Me.utToZone)
        Me.GroupBox3.Controls.Add(Me.utDescription)
        Me.GroupBox3.Controls.Add(Me.utPlanName)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.umskEndDate)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.btnSelFromZ)
        Me.GroupBox3.Controls.Add(Me.btnSelectToZ)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.utModuleName)
        Me.GroupBox3.Controls.Add(Me.utTableName)
        Me.GroupBox3.Controls.Add(Me.utColumnTitle)
        Me.GroupBox3.Controls.Add(Me.utColumnPrefix)
        Me.GroupBox3.Controls.Add(Me.utColumnSuffix)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.btnSelModName)
        Me.GroupBox3.Controls.Add(Me.ucboPlanType)
        Me.GroupBox3.Controls.Add(Me.utOverLimit_Charge)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.cbPerLocation)
        Me.GroupBox3.Controls.Add(Me.ucboChargeCode)
        Me.GroupBox3.Controls.Add(Me.utFromZone)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(752, 208)
        Me.GroupBox3.TabIndex = 63
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Tag = "PricePlans"
        '
        'cbPerDay
        '
        Me.cbPerDay.Location = New System.Drawing.Point(216, 184)
        Me.cbPerDay.Name = "cbPerDay"
        Me.cbPerDay.Size = New System.Drawing.Size(104, 16)
        Me.cbPerDay.TabIndex = 58
        Me.cbPerDay.Tag = ".PerDayID"
        Me.cbPerDay.Text = "Per Day"
        '
        'utColumnName
        '
        Me.utColumnName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utColumnName.Location = New System.Drawing.Point(632, 16)
        Me.utColumnName.MaxLength = 15
        Me.utColumnName.Name = "utColumnName"
        Me.utColumnName.ReadOnly = True
        Me.utColumnName.Size = New System.Drawing.Size(39, 21)
        Me.utColumnName.TabIndex = 57
        Me.utColumnName.TabStop = False
        Me.utColumnName.Tag = ".ColumnName"
        Me.utColumnName.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(16, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 12)
        Me.Label14.TabIndex = 52
        Me.Label14.Text = "Charge Code:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utFromZoneID
        '
        Me.utFromZoneID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFromZoneID.Location = New System.Drawing.Point(280, 72)
        Me.utFromZoneID.MaxLength = 15
        Me.utFromZoneID.Name = "utFromZoneID"
        Me.utFromZoneID.Size = New System.Drawing.Size(18, 21)
        Me.utFromZoneID.TabIndex = 48
        Me.utFromZoneID.TabStop = False
        Me.utFromZoneID.Tag = ".From_Zone"
        Me.utFromZoneID.Visible = False
        '
        'utPlanID
        '
        Me.utPlanID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utPlanID.Enabled = False
        Me.utPlanID.Location = New System.Drawing.Point(328, 16)
        Me.utPlanID.MaxLength = 15
        Me.utPlanID.Name = "utPlanID"
        Me.utPlanID.Size = New System.Drawing.Size(36, 21)
        Me.utPlanID.TabIndex = 47
        Me.utPlanID.TabStop = False
        Me.utPlanID.Tag = ".PlanID.view"
        Me.utPlanID.Visible = False
        '
        'cbTaxable
        '
        Me.cbTaxable.Location = New System.Drawing.Point(96, 184)
        Me.cbTaxable.Name = "cbTaxable"
        Me.cbTaxable.Size = New System.Drawing.Size(72, 20)
        Me.cbTaxable.TabIndex = 10
        Me.cbTaxable.Tag = ".Taxable"
        Me.cbTaxable.Text = "Taxable"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(408, 160)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 12)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Description:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utToZoneID
        '
        Me.utToZoneID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utToZoneID.Location = New System.Drawing.Point(280, 96)
        Me.utToZoneID.MaxLength = 15
        Me.utToZoneID.Name = "utToZoneID"
        Me.utToZoneID.Size = New System.Drawing.Size(18, 21)
        Me.utToZoneID.TabIndex = 49
        Me.utToZoneID.TabStop = False
        Me.utToZoneID.Tag = ".To_Zone"
        Me.utToZoneID.Visible = False
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(360, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 12)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Invoice Section Title:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utInvoiceSelTitle
        '
        Appearance12.ForeColorDisabled = System.Drawing.Color.Black
        Me.utInvoiceSelTitle.Appearance = Appearance12
        Me.utInvoiceSelTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utInvoiceSelTitle.Location = New System.Drawing.Point(472, 128)
        Me.utInvoiceSelTitle.MaxLength = 40
        Me.utInvoiceSelTitle.Name = "utInvoiceSelTitle"
        Me.utInvoiceSelTitle.Size = New System.Drawing.Size(248, 21)
        Me.utInvoiceSelTitle.TabIndex = 18
        Me.utInvoiceSelTitle.Tag = ".Invoice_Title"
        '
        'utDescription
        '
        Appearance13.ForeColorDisabled = System.Drawing.Color.Black
        Me.utDescription.Appearance = Appearance13
        Me.utDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utDescription.Location = New System.Drawing.Point(472, 152)
        Me.utDescription.Multiline = True
        Me.utDescription.Name = "utDescription"
        Me.utDescription.Size = New System.Drawing.Size(250, 38)
        Me.utDescription.TabIndex = 19
        Me.utDescription.Tag = ".Description"
        '
        'utOverLimit_Charge
        '
        Appearance14.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOverLimit_Charge.Appearance = Appearance14
        Me.utOverLimit_Charge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOverLimit_Charge.Location = New System.Drawing.Point(96, 160)
        Me.utOverLimit_Charge.MaxLength = 20
        Me.utOverLimit_Charge.Name = "utOverLimit_Charge"
        Me.utOverLimit_Charge.Size = New System.Drawing.Size(88, 21)
        Me.utOverLimit_Charge.TabIndex = 9
        Me.utOverLimit_Charge.Tag = ".OverLimit_Charge"
        '
        'Label18
        '
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(8, 160)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 12)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "Over Limit Chrg:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbPerLocation
        '
        Me.cbPerLocation.Location = New System.Drawing.Point(216, 160)
        Me.cbPerLocation.Name = "cbPerLocation"
        Me.cbPerLocation.Size = New System.Drawing.Size(136, 20)
        Me.cbPerLocation.TabIndex = 11
        Me.cbPerLocation.Tag = ".PerLocationID"
        Me.cbPerLocation.Text = "Per Location Per Day"
        '
        'ucboChargeCode
        '
        Appearance15.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance15.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboChargeCode.Appearance = Appearance15
        Me.ucboChargeCode.AutoEdit = False
        Me.ucboChargeCode.DisplayMember = ""
        Me.ucboChargeCode.Location = New System.Drawing.Point(96, 48)
        Me.ucboChargeCode.Name = "ucboChargeCode"
        Me.ucboChargeCode.Size = New System.Drawing.Size(100, 21)
        Me.ucboChargeCode.TabIndex = 1
        Me.ucboChargeCode.Tag = ".Charge_Code...InvoiceChargeCodes.Charge_Code.Description"
        Me.ucboChargeCode.ValueMember = ""
        '
        'gbConds
        '
        Me.gbConds.Controls.Add(Me.GroupBox4)
        Me.gbConds.Controls.Add(Me.btnRemove)
        Me.gbConds.Controls.Add(Me.btnAdd)
        Me.gbConds.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbConds.Location = New System.Drawing.Point(0, 0)
        Me.gbConds.Name = "gbConds"
        Me.gbConds.Size = New System.Drawing.Size(240, 216)
        Me.gbConds.TabIndex = 62
        Me.gbConds.TabStop = False
        Me.gbConds.Tag = "PricePlanCondition"
        Me.gbConds.Text = "Additional Conditions"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnCondColumn)
        Me.GroupBox4.Controls.Add(Me.utCondColumnName)
        Me.GroupBox4.Controls.Add(Me.utCondTableName)
        Me.GroupBox4.Controls.Add(Me.utCondModuleName)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.utValue)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.ucboOperator)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.utCondColumnTitle)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(224, 152)
        Me.GroupBox4.TabIndex = 63
        Me.GroupBox4.TabStop = False
        '
        'btnCondColumn
        '
        Me.btnCondColumn.Location = New System.Drawing.Point(158, 31)
        Me.btnCondColumn.Name = "btnCondColumn"
        Me.btnCondColumn.Size = New System.Drawing.Size(48, 23)
        Me.btnCondColumn.TabIndex = 59
        Me.btnCondColumn.Text = "Select"
        '
        'utCondColumnName
        '
        Me.utCondColumnName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utCondColumnName.Location = New System.Drawing.Point(136, 79)
        Me.utCondColumnName.MaxLength = 15
        Me.utCondColumnName.Name = "utCondColumnName"
        Me.utCondColumnName.Size = New System.Drawing.Size(16, 21)
        Me.utCondColumnName.TabIndex = 62
        Me.utCondColumnName.TabStop = False
        Me.utCondColumnName.Tag = ".ColumnName"
        Me.utCondColumnName.Visible = False
        '
        'utCondTableName
        '
        Me.utCondTableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utCondTableName.Location = New System.Drawing.Point(168, 79)
        Me.utCondTableName.MaxLength = 15
        Me.utCondTableName.Name = "utCondTableName"
        Me.utCondTableName.Size = New System.Drawing.Size(16, 21)
        Me.utCondTableName.TabIndex = 61
        Me.utCondTableName.TabStop = False
        Me.utCondTableName.Tag = ".TableName"
        Me.utCondTableName.Visible = False
        '
        'utCondModuleName
        '
        Me.utCondModuleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utCondModuleName.Location = New System.Drawing.Point(112, 79)
        Me.utCondModuleName.MaxLength = 20
        Me.utCondModuleName.Name = "utCondModuleName"
        Me.utCondModuleName.Size = New System.Drawing.Size(16, 21)
        Me.utCondModuleName.TabIndex = 60
        Me.utCondModuleName.Tag = ".ModuleName"
        Me.utCondModuleName.Visible = False
        Me.utCondModuleName.WordWrap = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(14, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "Column:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utValue
        '
        Appearance16.ForeColorDisabled = System.Drawing.Color.Black
        Me.utValue.Appearance = Appearance16
        Me.utValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utValue.Location = New System.Drawing.Point(16, 119)
        Me.utValue.MaxLength = 255
        Me.utValue.Name = "utValue"
        Me.utValue.Size = New System.Drawing.Size(185, 21)
        Me.utValue.TabIndex = 2
        Me.utValue.Tag = ".[VALUES]......VALUES"
        '
        'Label17
        '
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label17.Location = New System.Drawing.Point(16, 103)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 16)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "Value:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ucboOperator
        '
        Appearance17.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance17.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboOperator.Appearance = Appearance17
        Me.ucboOperator.AutoEdit = False
        Me.ucboOperator.DisplayMember = ""
        Me.ucboOperator.Location = New System.Drawing.Point(16, 79)
        Me.ucboOperator.Name = "ucboOperator"
        Me.ucboOperator.Size = New System.Drawing.Size(80, 21)
        Me.ucboOperator.TabIndex = 1
        Me.ucboOperator.Tag = ".Operator...PricePlanConditionOperators.Operator.Title"
        Me.ucboOperator.ValueMember = ""
        '
        'Label16
        '
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Location = New System.Drawing.Point(16, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 16)
        Me.Label16.TabIndex = 54
        Me.Label16.Text = "Operator:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'utCondColumnTitle
        '
        Appearance18.ForeColorDisabled = System.Drawing.Color.Black
        Me.utCondColumnTitle.Appearance = Appearance18
        Me.utCondColumnTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utCondColumnTitle.Enabled = False
        Me.utCondColumnTitle.Location = New System.Drawing.Point(14, 31)
        Me.utCondColumnTitle.MaxLength = 15
        Me.utCondColumnTitle.Name = "utCondColumnTitle"
        Me.utCondColumnTitle.Size = New System.Drawing.Size(136, 21)
        Me.utCondColumnTitle.TabIndex = 57
        Me.utCondColumnTitle.TabStop = False
        Me.utCondColumnTitle.Tag = ".ColumnTitle"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(168, 184)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(56, 23)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "&Remove"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 184)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(44, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "&Add"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(3, 232)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(1018, 219)
        Me.UltraGrid1.TabIndex = 0
        Me.UltraGrid1.Text = "Price Plans"
        '
        'UltraGrid3
        '
        Me.UltraGrid3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid3.Location = New System.Drawing.Point(240, 0)
        Me.UltraGrid3.Name = "UltraGrid3"
        Me.UltraGrid3.Size = New System.Drawing.Size(778, 216)
        Me.UltraGrid3.TabIndex = 2
        Me.UltraGrid3.Text = "Conditions"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 662)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1024, 56)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.UltraGrid1)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 208)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1024, 454)
        Me.GroupBox2.TabIndex = 64
        Me.GroupBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraGrid3)
        Me.Panel2.Controls.Add(Me.gbConds)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1018, 216)
        Me.Panel2.TabIndex = 3
        '
        'PricePlanSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 718)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PricePlanSetup"
        Me.Tag = "PricePlanSetup"
        Me.Text = "Price Plan Setup"
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboPlanType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udStartDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToZone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFromZone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utPlanName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utModuleName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTableName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utColumnTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utColumnPrefix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utColumnSuffix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.utColumnName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFromZoneID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utPlanID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToZoneID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utInvoiceSelTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOverLimit_Charge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboChargeCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConds.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.utCondColumnName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utCondTableName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utCondModuleName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboOperator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utCondColumnTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub PricePlanSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = BILLTblPath & Me.Tag
            End If
        End If
        If Not GroupBox3.Tag Is Nothing Then
            If GroupBox3.Tag <> "" Then
                GroupBox3.Tag = BILLTblPath & GroupBox3.Tag
            End If
        End If
        If Not gbConds.Tag Is Nothing Then
            If gbConds.Tag <> "" Then
                gbConds.Tag = BILLTblPath & gbConds.Tag
            End If
        End If

        Me.CenterToScreen()

        udStartDate.Nullable = True
        udStartDate.Value = Nothing 'Date.Now
        udStartDate.FormatString = "MM/dd/yyyy"

        Me.KeyPreview = True
        MeText = Me.Text

        ''Set each control's length based on DB size
        '???SetupCtrlsLength(UltraGrid2, AppDBName, AppDBUser, AppDBPass)

        AddHandler ucboPlanType.Leave, AddressOf UCbo_Leave
        FillUCombo(ucboPlanType, "", , , BILLTblPath)

        AddHandler ucboChargeCode.Leave, AddressOf UCbo_Leave
        FillUCombo(ucboChargeCode, "", , , BILLTblPath)

        AddHandler ucboOperator.Leave, AddressOf UCbo_Leave
        FillUCombo(ucboOperator, "", , , BILLTblPath)

        'FillUCombo(ucboField, "", "", "Select modulename, tablename, columnname, columntitle, columnprefix, columnsuffix from " & BILLTblPath & "priceplanmodules ")

        Group_EnDis(True)



        LoadData()
    End Sub

    Private Sub LoadData(Optional ByVal PlanID As Int32 = 0)
        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim SortColIdx As Int16 = 1
        Dim HidCols() As String = {""}

        Dim sqlPricePlan As String = _
                " Select pp.PlanID, pp.Plan_Name, pp.Charge_Code, pp.PlanTypeCode, " & _
                " isnull(pp.From_Zone, '0') as From_Zone, ppzfrom.Zone_Name as [From_Zone_Name], " & _
                " isnull(pp.To_Zone, '0') as To_Zone, ppzto.Zone_Name as [To_Zone_Name], " & _
                " pp.Start_Date, pp.End_Date, pp.ModuleName, pp.TableName, pp.ColumnTitle, pp.ColumnName, pp.ColumnPrefix, pp.ColumnSuffix, pp.OverLimit_Charge, pp.Taxable, pp.PerLocationID, pp.PerDayID, " & _
                " pp.Invoice_Title, pp.Description " & _
                " from " & BILLTblPath & "PricePlans pp left outer join " & BILLTblPath & "PricePlanZones ppzfrom on ppzfrom.ZoneID = pp.From_Zone " & _
                " left outer join " & BILLTblPath & "PricePlanZones ppzto on  ppzto.ZoneID=pp.To_Zone " & _
                " "

        PopulateDataset2(dtAdapter, dtSet, sqlPricePlan)
        FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HidCols)

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.GroupByBox.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        Select Case PlanID
            Case -1
                UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Clear()
                UltraGrid1.DisplayLayout.Bands(0).Columns(0).SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
                'UltraGrid.ActiveRow = UltraGrid.Rows.GetItem(0)
                UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInBand, False, False)
        End Select

        'UltraGrid1.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.Last).Activate()


        'UltraGrid3.DisplayLayout.GroupByBox.Hidden = False
        'UltraGrid3.DisplayLayout.GroupByBox.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        'UltraGrid3.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        'PopulateDataset2(dtAdapter, dtSet3, SQLSelect3)
        'FillUltraGrid(UltraGrid3, dtSet3, SortColIdx2, HidCols3)

        'FillUCombo(ucboField, "", "", "Select * from PricePlanModules")
        'AddHandler ucboField.Leave, AddressOf UCbo_Leave

        'Click on the NEW ROW button

        'Create and bind PricePlanCharges DataTable
        'Dim PricePlanChargesDataClass As New clsCustomerData

        'AddNewChargeRow()

        'END - click on the NEW ROW button

    End Sub
    Private Sub utFromZone_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utFromZone.KeyUp, utToZone.KeyUp, utColumnTitle.KeyUp
        If utColumnTitle.ContainsFocus = True Then
            TypeAhead(sender, e, BILLTblPath & "PricePlanModules", "ColumnTitle")
        Else
            TypeAhead(sender, e, BILLTblPath & "PricePlanZones", "Zone_Name")
        End If
    End Sub
    Private Sub utFromZone_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utFromZone.Leave, utToZone.Leave, utColumnTitle.Leave
        Dim row As DataRow
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            If utFromZone.ContainsFocus = True Then
                utFromZone.Text = ""
                utFromZoneID.Text = ""
            End If
            If utToZone.ContainsFocus = True Then
                utToZone.Text = ""
                utToZoneID.Text = ""
            End If
            If utColumnTitle.ContainsFocus = True Then
                utColumnTitle.Text = ""
            End If
            sender.text = ""
            Exit Sub
        End If


        If utColumnTitle.ContainsFocus = True Then
            If SearchOnLeave(sender, utColumnTitle, BILLTblPath & "PricePlanModules", "RowId", "ColumnTitle", "*") Then
                If ReturnRowByID(utColumnTitle.Text, row, BILLTblPath & "PricePlanModules", , "RowID") Then
                    utTableName.Text = row("TableName")
                    utModuleName.Text = row("ModuleName")
                    utColumnName.Text = row("ColumnName")
                    utColumnPrefix.Text = row("ColumnPrefix")
                    utColumnSuffix.Text = row("ColumnSuffix")
                End If
                utInvoiceSelTitle.Focus()
                Exit Sub
            Else
                utModuleName.Text = ""
                utColumnName.Text = ""
                utColumnTitle.Text = ""
                utColumnPrefix.Text = ""
                utColumnSuffix.Text = ""
            End If
        Else
            If utFromZone.ContainsFocus = True Then
                If SearchOnLeave(sender, utFromZoneID, BILLTblPath & "PricePlanZones", "ZoneID", "Zone_Name", "*") Then
                    utToZone.Focus()
                    Exit Sub
                Else
                    utFromZone.Text = ""
                    utFromZoneID.Text = ""
                End If
            End If
            If utToZone.ContainsFocus = True Then
                If SearchOnLeave(sender, utToZoneID, BILLTblPath & "PricePlanZones", "ZoneID", "Zone_Name", "*") Then
                    udStartDate.Focus()
                    Exit Sub
                Else
                    utToZone.Text = ""
                    utToZoneID.Text = ""
                End If

            End If
            'sender.text = ""

        End If
        'row.Delete()
        'row = Nothing

        sender.focus()
        sender.Modified = False

    End Sub
    Private Sub Group_EnDis(ByVal status As Boolean)
        'Panel1.Enabled = status
        'gbConds.Enabled = Not status
        'btnSave.Enabled = status
        'UltraGrid1.Enabled = status
        'UltraGrid3.Enabled = status
        Btn_En(status)
    End Sub

    Private Sub Btn_En(ByVal status As Boolean)
        UltraGrid1.Enabled = status
        GroupBox3.Enabled = Not status

        UltraGrid3.Enabled = True 'Not status
        gbConds.Enabled = Not status

        btnSave.Enabled = Not status
        'btnEdit.Enabled = status
        'btnNew.Enabled = status

        'If status = True Then 'Enable Editing
        '    UltraGrid1.Enabled = True
        '    UltraGrid3.Enabled = True
        '    'Panel1.Enabled = False
        '    gbConds.Enabled = True
        '    btnSave.Enabled = False
        '    btnEdit.Enabled = True
        '    btnNew.Enabled = True
        'Else 'End Editing
        '    UltraGrid1.Enabled = False
        '    UltraGrid3.Enabled = False
        '    Panel1.Enabled = True
        '    gbConds.Enabled = True
        '    btnSave.Enabled = True
        '    btnEdit.Enabled = False
        '    btnNew.Enabled = False
        'End If
    End Sub
    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        UltraGrid1RowChange(sender)
    End Sub
    Private Sub UltraGrid1RowChange(ByVal sender As System.Object)
        Dim PlanID As Integer
        ClearForm(GroupBox3)
        FormLoadFromGrid(GroupBox3, sender)

        PlanID = UltraGrid1.ActiveRow.Cells("PlanID").Value
        FillUltraGrid2(PlanID)
        FillUltraGrid3(PlanID)

    End Sub
    Private Sub UltraGrid1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled Then
            FormLoadFromGrid(GroupBox3, sender)
        End If
    End Sub

    Public Function FillUltraGrid2(ByVal PlanID As Integer)
        Dim dS As New DataSet
        Dim dA As New SqlDataAdapter
        Dim HidCols() As String
        Dim SQLSelect2 As String '= "Select From_Range, To_Range, Charge From " & BillTblPath & "PricePlanCharges where PlanID = " & PlanID & " Order by From_Range"

        'If UltraGrid1.Rows.Count = 0 Then
        '    ClearForm(UltraGrid2)
        '    Exit Function
        'End If

        Dim PlanType As String = ucboPlanType.Value 'UltraGrid1.ActiveRow.Cells("PlanTypeCode").Value
        'Dim Description As String = UltraGrid1.ActiveRow.Cells("Description").Value
        UltraGrid2.DataSource = Nothing

        HidCols = New String() {"RowID", "PlanID"}
        Select Case PlanType
            Case "F"
                SQLSelect2 = "Select RowID, " & PlanID & " as PlanID, Charge from " & BILLTblPath & "PricePlanCharges where PlanID = " & PlanID & " Order by Charge"
                UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.DefaultableBoolean.Default 'Karina added
                UltraGrid2.DisplayLayout.AddNewBox.Hidden = True 'To display the button on UltraGrid2
                'UltraGrid2.DisplayLayout.Bands(0).AddButtonCaption = "New Row"
                cbPerLocation.Visible = True
                cbPerDay.Visible = True
            Case "R"
                SQLSelect2 = "Select RowID, PlanID, From_Range, To_Range, Charge From " & BILLTblPath & "PricePlanCharges where PlanID = " & PlanID & " Order by From_Range"
                UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.DefaultableBoolean.Default 'Karina added
                UltraGrid2.DisplayLayout.AddNewBox.Hidden = True 'To display the button on UltraGrid2 only in EDIT and NEW modes
                'UltraGrid2.DisplayLayout.Bands(0).AddButtonCaption = "New Row"
                cbPerLocation.Visible = False
                cbPerDay.Visible = False
            Case Else
                MsgBox("Unknown Plan-Type")
                Exit Function
        End Select

        PopulateDataset2(dA, dS, SQLSelect2)

        FillUltraGrid(UltraGrid2, dS, SortColIdx2, HidCols)
        UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        'Dim i As Int32
        'For i = 1 To UltraGrid2.DisplayLayout.Bands(0).ColumnFilters.Count - 1
        '    UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = False
        'UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        'Next

        'Dim i As Int32
        'For i = 1 To UltraGrid2.DisplayLayout.Bands(0).ColumnFilters.Count - 1
        '    UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = False
        '    UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        'Next


        'UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.DefaultableBoolean.Default 'Karina added
        'UltraGrid2.DisplayLayout.AddNewBox.Hidden = False 'To display the button on UltraGrid2
        UltraGrid2.DisplayLayout.Bands(0).AddButtonCaption = "New Row"



        dA.Dispose()
        dA = Nothing

        dS.Dispose()
        dS = Nothing
    End Function
    Public Function FillUltraGrid3(ByVal PlanID As Integer)
        Dim dS As New DataSet
        Dim dA As New SqlDataAdapter
        'Dim SQLSelect3 As String '= "Select From_Range, To_Range, Charge From " & BillTblPath & "PricePlanCharges where PlanID = " & PlanID & " Order by From_Range"
        Dim PlanType As String = UltraGrid1.ActiveRow.Cells("PlanTypeCode").Value
        Dim PlanIDCond As String

        'SQLSelect3 = "Select ppc.RowID, ppc.PlanID, ppc.ModuleName, ppc.TableName, ppc.ColumnName, ppc.ColumnTitle, ppc.Operator, ppc.[Values] " & _
        '            "from " & BillTblPath & "PricePlanCondition ppc " & _
        '            "where ppc.PlanID = "
        '            "left outer join " & BillTblPath & "PricePlans pp " & _

        '            "on pp.PlanID = ppc.PlanID where " BillTblPath "@PLANID Order by ModuleName"

        UltraGrid3.DataSource = Nothing
        ClearForm(GroupBox4)
        UltraGrid3.DisplayLayout.Override.AllowAddNew = Infragistics.Win.DefaultableBoolean.False

        '  Dim SQLSelect As String = _
        '"Select pp.PlanID, pp.Plan_Name, icc.Description, pp.Charge_Code, ppt.PlanType, pp.PlanTypeCode, " & _
        '    "isnull(pp.From_Zone, '') as From_Zone, ppzfrom.Zone_Name as [From_Zone_Name], " & _
        '    "isnull(pp.To_Zone, '') as To_Zone, ppzto.Zone_Name as [To_Zone_Name], " & _
        '    "pp.Start_Date, pp.End_Date, pp.ModuleName, pp.TableName, pp.ColumnName, pp.ColumnPrefix, pp.ColumnSuffix, pp.OverLimit_Charge, pp.Taxable, pp.PerLocationID, pp.ModuleName, pp.TableName, pp.ColumnName, pp.ColumnPrefix, " & _
        '    "pp.ColumnSuffix, pp.Invoice_Title, pp.Description " & _
        '    "from [TOP].dbo.PricePlans pp left outer join [TOP].dbo.InvoiceChargeCodes icc " & _
        '    "on icc.Charge_Code = pp.Charge_Code " & _
        '    "left outer join [TOP].dbo.PricePlanTypes ppt on ppt.PlanTypeCode = pp.PlanTypeCode " & _
        '    "left outer join [TOP].dbo.PricePlanZones ppzfrom on ppzfrom.ZoneID = pp.From_Zone " & _
        '    "left outer join [TOP].dbo.PricePlanZones ppzto on  ppzto.ZoneID=pp.To_Zone"

        SQLSelect3 = "Select ppc.RowID, ppc.PlanID, ppc.ModuleName, ppc.TableName, ppc.ColumnName, ppc.ColumnTitle, ppc.Operator, ppc.[Values] " & _
            "from " & BILLTblPath & "PricePlanCondition ppc where @PLANID Order by ModuleName"
        'SQLSelect3 = "Select ppc.RowID, ppc.PlanID, ppc.ModuleName, ppc.TableName, ppc.ColumnName, ppc.ColumnTitle, ppc.Operator, ppc.[Values] " & _
        '            "from " & BillTblPath & "PricePlanCondition ppc " & _
        '            "left outer join " & BillTblPath & "PricePlans pp " & _
        '            "on pp.PlanID = ppc.PlanID where @PLANID Order by ModuleName"


        PlanIDCond = "PlanID = " & PlanID & ""
        SQLSelect3 = SQLSelect3.Replace("@PLANID", PlanIDCond)

        PopulateDataset2(dA, dS, SQLSelect3)

        FillUltraGrid(UltraGrid3, dS, SortColIdx2, HidCols3)
        UltraGrid3.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        UltraGrid3.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect


        'Dim i As Int32
        'For i = 1 To UltraGrid3.DisplayLayout.Bands(0).ColumnFilters.Count - 1
        '    UltraGrid3.DisplayLayout.Bands(0).Columns(i).TabStop = False
        '    UltraGrid3.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        'Next

        dA.Dispose()
        dA = Nothing

        dS.Dispose()
        dS = Nothing
    End Function
    Private Sub btnSelFromZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelFromZ.Click, btnSelectToZ.Click, btnSelModName.Click
        Dim SelectSQL, SelectSQL2 As String
        Dim dtAdapter As New SqlDataAdapter
        Dim HidCols() As String '= ("RowID", "ColumnName")
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If btnSelModName.Focused = True Then
            SelectSQL2 = "Select RowID, ModuleName, TableName, ColumnTitle, ColumnName, ColumnPrefix, ColumnSuffix from " & BILLTblPath & "PricePlanModules order by ModuleName, Tablename, ColumnTitle"
            PopulateDataset2(dtAdapter, dtSet, SelectSQL2)
        Else
            SelectSQL = "Select * from  " & BILLTblPath & "PricePlanZones order by Zone_Name"
            PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        End If

        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            If btnSelModName.Focused = True Then
                Srch.UltraGrid1.Text = "Modules, Tables and Columns"
                Srch.Text = "Price-Plan Modules"
                HidCols = New String() {"RowID", "ColumnName"}
                Srch.HidCols = HidCols
            Else
                Srch.Text = "Price-Plans Zones"
                If btnSelFromZ.Focused = True Then
                    Srch.UltraGrid1.Text = "From Zones"
                Else
                    Srch.UltraGrid1.Text = "To Zones"
                End If
            End If
            Srch.ShowDialog()
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
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
                    If btnSelModName.Focused = True Then
                        utColumnTitle.Text = ugRow.Cells("ColumnTitle").Value
                        utModuleName.Text = ugRow.Cells("ModuleName").Text
                        'utModuleNameID.Text = ugRow.Cells("RowID").Text
                        'Fill in the field under the utModuleName
                        utTableName.Text = ugRow.Cells("TableName").Text
                        utColumnName.Text = ugRow.Cells("ColumnName").Value
                        utColumnPrefix.Text = ugRow.Cells("ColumnPrefix").Value
                        utColumnSuffix.Text = ugRow.Cells("ColumnSuffix").Value

                        utInvoiceSelTitle.Focus()
                    Else
                        If btnSelFromZ.Focused = True Then
                            utFromZone.Text = ugRow.Cells("Zone_Name").Text
                            utFromZoneID.Text = ugRow.Cells("ZoneID").Text
                            utToZone.Focus()
                        Else
                            utToZone.Text = ugRow.Cells("Zone_Name").Text
                            utToZoneID.Text = ugRow.Cells("ZoneID").Text
                            udStartDate.Focus()
                        End If
                    End If
                    Srch = Nothing
                    ugRow = Nothing
                End If
            End Try
        End If

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If btnEdit.Text = "&Cancel" Then
            MessageBox.Show("You are in 'Edit' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If sender.text = "&New" Then
            'ultragrid2.DataSource = ""
            sender.text = "&Cancel"
            Group_EnDis(False)
            ' You can not input charges when creating new plans

            UltraGrid2.DataSource = Nothing
            UltraGrid2.Enabled = False
            ucboPlanType.Enabled = True

            ClearForm(Me)

            UltraGrid3.DataSource = Nothing
            UltraGrid3.Enabled = False
            gbConds.Enabled = False

            utPlanName.Focus()
        Else
            ClearForm(Me)
            sender.text = "&New"

            UltraGrid1RowChange(UltraGrid1)

            'UltraGrid2.Visible = True
            ucboPlanType.Enabled = False
            Group_EnDis(True)
            UltraGrid1.Focus()
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'If utPlanName.Text.Trim = "" Or ucboPlanType.Text.Trim = "" Or utFromZone.Text.Trim = "" Or utToZone.Text.Trim = "" Then
        '    MsgBox("Some of the fields are empty!", MsgBoxStyle.Exclamation, "Error")
        '    Exit Sub
        'End If
        Dim NullArr, StrArr() As String
        'StrArr = GetCtrldbFieldInfo(utPlanID)


        If Not (umskEndDate.Text.Trim = "//" Or umskEndDate.Text.Trim = "") Then  '"//" Then
            If CDate(udStartDate.Text) > CDate(umskEndDate.Text) Then
                MsgBox("The End Date cann't be earlie the Start Date!", MsgBoxStyle.Exclamation, "Error")
                umskEndDate.Text = ""
                Exit Sub
            End If
        End If

        If utPlanName.Text.Trim = "" Then
            MsgBox("Plan Name field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf ucboPlanType.Text.Trim = "" Then
            MsgBox("Plan Type field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf ucboChargeCode.Text.Trim = "" Then
            MsgBox("Description of Charge Code field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf udStartDate.Text.Trim = "//" Then
            MsgBox("Start Date field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If


        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If utOverLimit_Charge.Text.Trim = "" Then
            utOverLimit_Charge.Text = "0"
        End If

        '''Get the next PlanID - Start
        ''Dim numRowsUG1 As Integer
        ''If UltraGrid1.Rows.Count() = 0 Then
        ''    numRowsUG1 = UltraGrid1.Rows.Count()
        ''    Dim newPlanID As Integer
        ''    newPlanID = 0

        ''Else
        ''    numRowsUG1 = UltraGrid1.Rows.Count() - 1
        ''    Dim valueLastPlanID As Infragistics.Win.UltraWinGrid.UltraGridCell = UltraGrid1.Rows(numRowsUG1).Cells("PlanID")
        ''    Dim newPlanID As Integer = valueLastPlanID.Text
        ''    newPlanID = newPlanID + 1
        ''End If
        '''Dim value As String = UltraGrid1.Rows(numRowsUG1).Cells("PlanID").Value()


        '''Get the next PlanID - End

        If utColumnName.Text = "" Then
            MsgBox("Column Name is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        ''If some fields are empty is empty
        'If utModuleName.Text = "" Then
        '    'utModuleNameID.Text = 0 'Checking
        '    utModuleName.Text = NullArr
        '    utTableName.Text = NullArr
        '    utColumnPrefix.Text = NullArr
        '    utColumnSuffix.Text = NullArr
        'End If

        'If utInvoiceSelTitle.Text = "" Then
        '    utInvoiceSelTitle.Text = NullArr
        'End If

        'If utDescription.Text = "" Then
        '    utDescription.Text = NullArr
        'End If

        'If cbTaxable.Checked = False Then
        '    cbTaxable.CheckState = CheckState.Unchecked
        'End If

        'If cbPerLocation.Checked = False Then
        '    cbPerLocation.CheckState = CheckState.Unchecked
        'End If

        'If utFromZone.Text = "" Then
        '    utFromZone.Text = NullArr
        'End If

        'If utToZone.Text = "" Then
        '    utToZone.Text = NullArr
        'End If

        If EditForm(GroupBox3, sqlPricePlanEdit, EditAction.ENDEDIT, cmdTrans, " Where PlanID = " & Val(utPlanID.Text)) Then
            ''Dim row As DataRow
            '' Then save the charges.
            'Dim dtA As New SqlDataAdapter
            'Dim dtACond As New SqlDataAdapter

            If btnEdit.Text.ToUpper = "&CANCEL" Then
                ''Ali: Add saving for charges.
                UltraGrid2.DisplayLayout.AddNewBox.Hidden = True 'To display the button on UltraGrid2 only in EDIT and NEW modes
                If UltraGrid2.Rows.Count > 0 Then

                    SavePlanCharges(utPlanID.Text.Trim, ucboPlanType.Value)
                End If

                UltraGrid2.DisplayLayout.AddNewBox.Hidden = True
                UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
                UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

                btnEdit.Text = "&Edit"
                btnNew.Text = "&New"

                UltraGrid1RowChange(UltraGrid1)
            Else
                btnEdit.Text = "&Edit"
                btnNew.Text = "&New"

                LoadData(-1)

            End If

            'PopulateDataset2(dtA, dtSet, SQLSelect)
            ''SortColIdx = UltraGrid1.DisplayLayout.Bands(0).SortedColumns(0).Index 'Karina commented out
            'FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HidCols)

            '''Start UltraGrid3
            ''PopulateDataset2(dtACond, dtSetCond, SQLSelectEdit)
            ''FillUltraGrid(UltraGrid3, dtSetCond, SortColIdx, HidCols3)
            '''End UltraGrid3
            'UltraGrid1.Focus()
            'UltraGrid1.Refresh()
            'UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(1)

            ''FillUltraGrid(UltraGrid2, dtSet, SortColIdx, HidCols)
            ''UltraGrid2.Focus()
            ''UltraGrid2.Refresh()
            ''UltraGrid2.ActiveRow = UltraGrid2.Rows.GetRowAtVisibleIndex(1)



            'LoadData()


            ''PopulateDataset2(dtA, dtSet, SQLSelect)
            ''SortColIdx = UltraGrid1.DisplayLayout.Bands(0).SortedColumns(0).Index
            '''FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HidCols)

            ucboPlanType.Enabled = False
            Group_EnDis(True)
            'UltraGrid2.Enabled = True
            'UltraGrid2.Visible = True
            ''UltraGrid1.Focus()
            ''UltraGrid1.Refresh()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If utPlanName.Text.Trim = "" Then Exit Sub
        'UltraGrid2.Enabled = False 'added
        If btnNew.Text = "&Cancel" Then
            MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If UltraGrid1.Rows.Count <= 0 Then Exit Sub
        If UltraGrid1.ActiveRow.ListObject Is Nothing Then Exit Sub

        'UltraGrid1.ActiveRow.Cells("PlanTypeCode").Value()
        'ucboPlanType = UltraGrid1.ActiveRow.Cells("PlanTypeCode").Value
        If sender.text.toupper = "&EDIT" Then
            ucboPlanType.Enabled = False
            'Karina 02 27 06
            'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, True, True)
            'UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, True, True)
            'End Karina 02 27 06
            If EditForm(Me, PrepSelectQuery(sqlPricePlanEdit, " Where PlanID = " & utPlanID.Text), EditAction.START, cmdTrans) Then
                sender.text = "&Cancel"
                Group_EnDis(False)

                UltraGrid2.Enabled = True
                If UltraGrid1.ActiveRow.Cells("PlanTypeCode").Value = "F" And UltraGrid2.Rows.Count > 0 Then
                    UltraGrid2.DisplayLayout.AddNewBox.Hidden = True 'To display the button on UltraGrid2 only in EDIT and NEW modes
                Else
                    UltraGrid2.DisplayLayout.AddNewBox.Hidden = False 'To display the button on UltraGrid2 only in EDIT and NEW modes
                End If

                UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
                UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit

                UltraGrid3.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
                UltraGrid3.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

                ClearForm(gbConds)

                UltraGrid1.Enabled = False
            End If
        Else
            If EditForm(Me, sqlPricePlanEdit, EditAction.CANCEL, cmdTrans) Then
                sender.text = "&Edit"

                UltraGrid2.DisplayLayout.AddNewBox.Hidden = True
                UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
                UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
                UltraGrid2.DataSource = Nothing
                UltraGrid3.DataSource = Nothing

                UltraGrid1RowChange(UltraGrid1)

                'If UltraGrid1.Rows.Count <= 0 Then Exit Sub
                'UltraGrid1.Enabled = False
                Group_EnDis(True)
                btnNew.Enabled = True
                'UltraGrid3.ActiveRow.Activate()
            End If
        End If
    End Sub
    Private Sub PricePlanSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        'Karina, Warn the user on EXITING/CLOSING window when in Edit/New modes.
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, sqlPricePlanEdit, EditAction.CANCEL, cmdTrans) Then
                '        UltraGrid2.Enabled = True
                Group_EnDis(False)
                sender.text = "&Edit"
            Else
                '        'Exit Sub
            End If

        End If
        'UGSaveLayout(Me, UltraGrid1, 1)
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub Value_Char_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ucboPlanType.KeyPress, ucboOperator.KeyPress, ucboChargeCode.KeyPress
        If IsArray(e.KeyChar) = False Then 'And Asc(e.KeyChar) <> Keys.Back 'And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    Private Sub Value_Int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UltraGrid2.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And Asc(e.KeyChar) <> Keys.Tab And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub


    'Private Sub UltraGrid2_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles UltraGrid2.BeforeCellUpdate
    '    If e.Cell.Column.ToString = "To_Range" Then 'Or e.Cell.Column.ToString = "Charge" Then
    '        e.Cancel = False
    '    Else
    '        e.Cancel = True
    '    End If
    'End Sub

    Private Sub UltraGrid2_BeforeEnterEditMode(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UltraGrid2.BeforeEnterEditMode
        If UltraGrid2.ActiveCell.Column.ToString = "From_Range" Or UltraGrid2.ActiveCell.Column.ToString = "To_Range" Or UltraGrid2.ActiveCell.Column.ToString = "Charge" Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub


    'Private Sub UltraGrid2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid2.Leave
    '    If Not UltraGrid2.ActiveCell Is Nothing Then
    '        UltraGrid2.ActiveCell.Selected = True
    '    End If
    '    If Not UltraGrid2.ActiveRow Is Nothing Then
    '        UltraGrid2.ActiveRow.Update()
    '    End If





    '    Dim cnt As Integer
    '    Dim ID As Integer
    '    Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
    '    Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
    '    Dim row As DataRow

    '    Dim updCmd As SqlCommand
    '    updCmd = New SqlCommand("Update " & BillTblPath & "PricePlanCharges Set PlanID = @Pid, From_Range = @Frg, To_Range = @Trg, Charge = @Crg")
    '    'Dim UpdCmd As SqlCommand
    '    'UpdCmd = New SqlCommand("Update " & BillTblPath & "PricePlanCharges Set PlanID = @Pid, From_Range = @Frg, To_Range = @Trg, Charge = @Crg)
    '    'UpdCmd.Parameters.Add("@Wgt", SqlDbType.Decimal, 5, "Weight")
    '    'UpdCmd.Parameters.Add("@Chrg", SqlDbType.Decimal, 5, "Charge")

    '    'Dim CondParam1 As SqlParameter = UpdCmd.Parameters.Add("@TrDate", SqlDbType.DateTime)
    '    'CondParam1.SourceColumn = "TranDate"
    '    'CondParam1.SourceVersion = DataRowVersion.Original

    '    'Dim CondParam2 As SqlParameter = UpdCmd.Parameters.Add("@WgtPlanID", SqlDbType.Int)
    '    'CondParam2.SourceColumn = "ManifestID"
    '    'CondParam2.SourceVersion = DataRowVersion.Original

    '    'UpdateDbFromDataSetV3(dtSet, SQLSelect & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND TranDate = '" & Format(DTPicker1.Value, "MM/dd/yyyy") & "' ORDER BY AccountName", UpdCmd)
    '    '''If UpdateDbFromDataSetV2(dtSet.GetChanges, SQLSelect & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND TranDate = '" & Format(DTPicker1.Value, "MM/dd/yyyy") & "' ORDER BY AccountName", "") <= 0 Then
    '    '''    'MsgBox("btnDelete_Click: Error!")
    '    '''End If
    '    'NewTrans = False
    '    sender.focus()
    'End Sub
    Private Sub UltraGrid2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UltraGrid2.KeyDown
        If e.KeyCode = Keys.Down Then
            e.Handled = True
            UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False)
            UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, False, False)
            UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False)
            UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, False, False)
            UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
        Else
            e.Handled = False
        End If

    End Sub
    Private Sub UltraGrid2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid2.Leave
        If Not UltraGrid2.ActiveCell Is Nothing Then
            UltraGrid2.ActiveCell.Selected = True
            'UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False) 'Karina 02 27 06
        End If
        If Not UltraGrid2.ActiveRow Is Nothing Then
            UltraGrid2.ActiveRow.Update()
            'UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False) 'Karina 02 27 06
        End If
    End Sub


    'Private Sub AddNewChargeRow()
    '    'add new customer row to the PricePlanCharges
    '    Dim newRow As DataRow = PricePlanCharges.NewRow
    '    If PricePlanCharges.Rows.Count > 0 Then
    '        newRow("Charge") = PricePlanCharges.Rows(PricePlanCharges.Rows.Count - 1).Item("Charge") + 1
    '    Else
    '        newRow("Charge") = 1

    '    End If

    '    newRow("PlanID") = Now
    '    newRow("From_Range") = Now
    '    newRow("To_Range") = Now
    '    PricePlanCharges.Rows.Add(newRow)
    'End Sub

    Private Sub Value_Dec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles utOverLimit_Charge.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim SQLSelectAdd As String = "Insert into " & BILLTblPath & "PricePlanCondition(PlanID, ModuleName, TableName, ColumnName, ColumnTitle, Operator, [Values]) " & _
                                     " Values(@PLANID, @Module, @Table, @COL, @TTLCOL, @OPR, @VAL)"


        If utCondColumnName.Text = "" Then
            MsgBox("To Save Addtional Condition fill in Module Name field!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If ucboOperator.Text.Trim = "" Then
            MsgBox("Operator is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If utValue.Text.Trim = "" Then
            MsgBox("Value is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If utPlanID.Text.Trim = "" Then
            MsgBox("PlanID is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        SQLSelectAdd = SQLSelectAdd.Replace("@PLANID", utPlanID.Text.Trim)
        SQLSelectAdd = SQLSelectAdd.Replace("@Module", "'" & utCondModuleName.Text.Trim & "'")
        SQLSelectAdd = SQLSelectAdd.Replace("@Table", "'" & utCondTableName.Text.Trim & "'")
        SQLSelectAdd = SQLSelectAdd.Replace("@COL", "'" & utCondColumnName.Text.Trim & "'")
        SQLSelectAdd = SQLSelectAdd.Replace("@TTLCOL", "'" & utCondColumnTitle.Text.Trim & "'")
        SQLSelectAdd = SQLSelectAdd.Replace("@OPR", "'" & ucboOperator.Value & "'")
        SQLSelectAdd = SQLSelectAdd.Replace("@VAL", "'" & utValue.Text.Trim & "'")

        If ExecuteQuery(SQLSelectAdd) Then
            ClearForm(gbConds)
            FillUltraGrid3(utPlanID.Text.Trim)
            UltraGrid3.Focus()
        End If

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim SQLDelete As String = "Delete from " & BILLTblPath & "PricePlanCondition " & _
                                     " Where PlanID = @PLANID AND RowID = @@ROWID "


        If UltraGrid3.ActiveRow Is Nothing Then
            MsgBox("Please choose a row for deletion.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If utPlanID.Text.Trim = "" Then
            MsgBox("PlanID is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        SQLDelete = SQLDelete.Replace("@PLANID", utPlanID.Text.Trim)
        SQLDelete = SQLDelete.Replace("@@ROWID", UltraGrid3.ActiveRow.Cells("RowID").Value)
        If MsgBox("Delete condition '" & UltraGrid3.ActiveRow.Cells("ColumnTitle").Value & " " & UltraGrid3.ActiveRow.Cells("Operator").Value & " " & UltraGrid3.ActiveRow.Cells("Values").Value & "'?", MsgBoxStyle.YesNo, "Delete Condition") = MsgBoxResult.Yes Then
            If ExecuteQuery(SQLDelete) Then
                ClearForm(gbConds)
                FillUltraGrid3(utPlanID.Text.Trim)
                UltraGrid3.Focus()
            End If
        End If
    End Sub

    Private Sub UltraGrid3_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid3.AfterRowActivate
        Dim PlanID As Integer
        If btnEdit.Text = "&Edit" Then
            ClearForm(gbConds)
            FormLoadFromGrid(gbConds, sender)
        End If

    End Sub

    Private Sub ucboPlanType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboPlanType.Validated
        If Val(utPlanID.Text) > 0 Then
            Select Case ucboPlanType.Value
                Case "F"
                    FillUltraGrid2(Val(utPlanID.Text))
                    'Dim sqlPriceCons As String = "Select "

                    'UltraGrid2.DisplayLayout.AddNewBox.Hidden = True 'To display the button on UltraGrid2 only in EDIT and NEW modes
                    'UltraGrid2.DataSource = Nothing
                    'UltraGrid2.DisplayLayout.Bands(0).Columns.Add("Charge")
                Case "R"
                    FillUltraGrid2(Val(utPlanID.Text))
                    UltraGrid2.DisplayLayout.AddNewBox.Hidden = False 'To display the button on UltraGrid2 only in EDIT and NEW modes
                Case Else
                    MsgBox("Unknown Plan Type.")
            End Select
        End If
    End Sub
    Class Col
        Public Name As String
        Public Type As Type
        Public Format As String
        Public NoEdit As Boolean
        Public Hide As Boolean
        Public BackColor As Color
        Public MaxLength As Byte
        Public Width As Byte
    End Class

    Dim WCols(4) As Col

    Private Function SavePlanCharges(ByVal PlanID As String, ByVal PlanTypeCode As String)
        Dim ds As New DataSet
        Dim dsChanges As DataSet = Nothing
        Dim dv As New DataView
        Dim sqlFixedCharge As String = "Select RowID, PlanID, Charge from " & BILLTblPath & "PricePlanCharges where PlanID = " & PlanID
        Dim sqlFixedChargeUpdate As String = "Update " & BILLTblPath & "PricePlanCharges Set Charge = @CHRG, From_Range = @FRANGE, To_Range = @TRANGE where RowID = @ROWID"
        Dim sqlFixedChargeInsert As String = "Insert Into " & BILLTblPath & "PricePlanCharges(PlanID, From_Range, To_Range, Charge) Values(@PlanID,@FRANGE, @TRANGE, @CHRG) "
        Dim i As Int32 = 0
        Dim da As New SqlDataAdapter
        Dim cmdIns As New SqlCommand
        Dim cmdUpd As New SqlCommand
        Dim con As New SqlConnection(strConnection)
        Dim Param1 As New SqlParameter


        Dim PlanType As String = PlanTypeCode 'ucboPlanType.Value 'UltraGrid1.ActiveRow.Cells("PlanTypeCode").Value

        With Param1
            .ParameterName = "@CHRG"
            .SourceColumn = "Charge"
            .SqlDbType = SqlDbType.Decimal
        End With
        cmdUpd.Parameters.Add(Param1)

        Param1 = New SqlParameter
        With Param1
            .ParameterName = "@CHRG"
            .SourceColumn = "Charge"
            .SqlDbType = SqlDbType.Decimal
        End With
        cmdIns.Parameters.Add(Param1)

        Param1 = New SqlParameter
        With Param1
            .ParameterName = "@ROWID"
            .SourceColumn = "ROWID"
            .SqlDbType = SqlDbType.Int
        End With
        cmdUpd.Parameters.Add(Param1)

        Param1 = New SqlParameter
        With Param1
            .ParameterName = "@PLANID"
            .SourceColumn = "PlanID"
            .SqlDbType = SqlDbType.Int
        End With
        cmdIns.Parameters.Add(Param1)


        Select Case PlanType
            Case "R"
                Param1 = New SqlParameter
                With Param1
                    .ParameterName = "@FRANGE"
                    .SourceColumn = "From_Range"
                    .SqlDbType = SqlDbType.Decimal
                End With
                cmdIns.Parameters.Add(Param1)

                Param1 = New SqlParameter
                With Param1
                    .ParameterName = "@FRANGE"
                    .SourceColumn = "From_Range"
                    .SqlDbType = SqlDbType.Decimal
                End With
                cmdUpd.Parameters.Add(Param1)

                Param1 = New SqlParameter
                With Param1
                    .ParameterName = "@TRANGE"
                    .SourceColumn = "To_Range"
                    .SqlDbType = SqlDbType.Decimal
                End With
                cmdIns.Parameters.Add(Param1)

                Param1 = New SqlParameter
                With Param1
                    .ParameterName = "@TRANGE"
                    .SourceColumn = "To_Range"
                    .SqlDbType = SqlDbType.Decimal
                End With
                cmdUpd.Parameters.Add(Param1)
            Case "F"
                Param1 = New SqlParameter
                With Param1
                    .ParameterName = "@FRANGE"
                    .Value = DBNull.Value
                    .SqlDbType = SqlDbType.Decimal
                End With
                cmdIns.Parameters.Add(Param1)

                Param1 = New SqlParameter
                With Param1
                    .ParameterName = "@FRANGE"
                    .Value = DBNull.Value
                    .SqlDbType = SqlDbType.Decimal
                End With
                cmdUpd.Parameters.Add(Param1)

                Param1 = New SqlParameter
                With Param1
                    .ParameterName = "@TRANGE"
                    .Value = DBNull.Value
                    .SqlDbType = SqlDbType.Decimal
                End With
                cmdIns.Parameters.Add(Param1)

                Param1 = New SqlParameter
                With Param1
                    .ParameterName = "@TRANGE"
                    .Value = DBNull.Value
                    .SqlDbType = SqlDbType.Decimal
                End With
                cmdUpd.Parameters.Add(Param1)
            Case Else
                MsgBox("Inknown Plan Type.")
                Exit Function
        End Select

        Param1 = Nothing

        With cmdIns
            .Connection = con
            .CommandText = sqlFixedChargeInsert
            .CommandType = CommandType.Text
            .CommandTimeout = 180
        End With
        With cmdUpd
            .Connection = con
            .CommandText = sqlFixedChargeUpdate
            .CommandType = CommandType.Text
            .CommandTimeout = 180
        End With

        da.UpdateCommand = cmdUpd
        da.InsertCommand = cmdIns

        dv = UltraGrid2.DataSource

        Try
            con.Open()
            da.Update(dv.Table)

        Catch ex As Exception
            MsgBox("Error Saving PricePlan Charges: " & ex.Message)
        Catch ex As SqlException
            MsgBox("Error Saving PricePlan Charges: " & ex.Message)
        Finally

        End Try

        If con.State <> ConnectionState.Closed Then
            con.Close()
        End If
        con.Dispose()
        con = Nothing

        cmdIns.Parameters.Clear()

        cmdUpd.Parameters.Clear()

        Param1 = Nothing
        cmdUpd.Dispose()
        cmdUpd = Nothing
        cmdIns.Dispose()
        cmdIns = Nothing

        dv.Dispose()
        dv = Nothing
        da.Dispose()
        da = Nothing

        'ds = dv.Table.DataSet
        'dsChanges = ds.GetChanges(DataRowState.Added)
        'If Not dsChanges Is Nothing Then
        '    Dim dschg As DataSet = ds.GetChanges(DataRowState.Added)
        '    Dim sqlInsert As String = "Insert into " & BILLTblPath & "PricePlanCharges(PlanID, From_Range, To_Range, Charge) Select '" & dschg.Tables(0).Rows(i)("Charge")
        'End If

        'dsChanges = ds.GetChanges(DataRowState.Modified)
        'If Not dsChanges Is Nothing Then
        '    Dim sqlParam1 As New SqlParameter("@CHRG", dsChanges.Tables(0).Rows(0)("Charge"))
        '    sqlParam1.SqlDbType = SqlDbType.Decimal
        '    Dim sqlParam2 As New SqlParameter("@ROWID", dsChanges.Tables(0).Rows(0)("ROWID"))
        '    sqlParam2.SqlDbType = SqlDbType.Int
        '    dim Cmd as New SqlCommand(
        'End If
        'Select Case PlanTypeCode
        '    Case "F"
        '        UpdateDbFromDataSet(ds, sqlFixedCharge)
        '    Case "R"

        '    Case Else
        'End Select
    End Function

    Private Sub UltraGrid2_BeforeRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowInsertEventArgs) Handles UltraGrid2.BeforeRowInsert
        If UltraGrid2.Rows.Count >= 1 Then
            If ucboPlanType.Value = "F" Then
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub UltraGrid2_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles UltraGrid2.AfterRowInsert
        UltraGrid2.ActiveRow.Cells("PlanID").Value = utPlanID.Text.Trim
    End Sub

    Private Sub btnCondColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCondColumn.Click
        Dim SelectSQL, SelectSQL2 As String
        Dim dtAdapter As New SqlDataAdapter
        Dim HidCols() As String '= ("RowID", "ColumnName")
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL2 = "Select RowID, ModuleName, TableName, ColumnTitle, ColumnName, ColumnPrefix, ColumnSuffix from " & BILLTblPath & "PricePlanModules order by ModuleName, Tablename, ColumnTitle"
        PopulateDataset2(dtAdapter, dtSet, SelectSQL2)

        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Modules, Tables and Columns"
            Srch.Text = "Price-Plan Modules"
            HidCols = New String() {"RowID", "ColumnName"}
            Srch.HidCols = HidCols
            Srch.ShowDialog()
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
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
                    utCondColumnTitle.Text = ugRow.Cells("ColumnTitle").Value

                    utCondModuleName.Text = ugRow.Cells("ModuleName").Text
                    'utModuleNameID.Text = ugRow.Cells("RowID").Text
                    'Fill in the field under the utModuleName
                    utCondTableName.Text = ugRow.Cells("TableName").Text
                    utCondColumnName.Text = ugRow.Cells("ColumnName").Value
                    'utColumnPrefix.Text = ugRow.Cells("ColumnPrefix").Value
                    'utColumnSuffix.Text = ugRow.Cells("ColumnSuffix").Value

                    ucboOperator.Focus()
                    Srch = Nothing
                    ugRow = Nothing
                End If
            End Try
        End If

    End Sub

End Class
