Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class DailyEntryListing
    Inherits System.Windows.Forms.Form
    Implements Infragistics.Win.IUIElementDrawFilter

    Dim WorkSheetName As String = "SheetX"
    Dim FileName As String = ""

    Dim LogicalPageNo As Integer
    Dim WgtTotal, ChargeTotal As Decimal
    Dim iCheckBoxSelected As Integer = 0
    Dim SQLSelect As String = _
        "Select " & _
        "de.TranDate as [Trans. Date], de.OfficeID as [Center ID],  " & _
        "so.Name as [Wgt.Ctr.]  ,  " & _
        "de.WeightPlanGroup as Manifest, " & _
        "de.AccountID, de.AccountName as Account,de.ManifestID as [Wgt.PlanId], de.ManifestName as [Wgt.Plan],  " & _
        "de.WeightLimit  ,de.OWCharge, de.Weight, de.Charge  ,  " & _
        " @SHOWCLUBID" & _
        "de.ParentID from  " & _
        "( " & _
        "	( " & _
        "		(UN_WEIGHT.dbo.DailyEntry de left outer join UNISON.dbo.ServiceOffices so on de.officeid = so.id)   " & _
        "		Left Outer join UNISON.dbo.Customer c on de.AccountID = c.id)   " & _
        "       @BYACCTCLUBJOINS " & _
        "	)   " & _
        " @WHERE  " & _
        " @BYACCOUNT " & _
        " @BYACCTCLUBSTATIC " & _
        " @BYACCTCLUBDYNAMIC " & _
        " @BYMANIFEST " & _
        " @BYWEIGHT " & _
        " @ORDERBYCLAUSE"
    '"de.TranDate between '5/1/2012' and '5/15/2012'  " & _
    '@ORDERBYCLAUSE
    '   For No Condition & By Manifest
    '   "ORDER BY de.ManifestName, de.TranDate "
    '   For By Account & By Account Club
    '   "ORDER BY de.TranDate"
    '   For By Weight
    '   "ORDER BY de.weight, de.ManifestName, de.TranDate
    '@BYACCOUNT
    '   For By Account
    '   "ACCOUNTID = XXX AND"
    '   For NOT By Account
    '   ""
    '@BYACCTCLUBJOINS
    '   For By Account Club
    '   "Left Outer Join UNISON.dbo.GroupClubMembers gcm on convert(varchar, c.ID) = gcm.MemberID "
    '   "left outer join UNISON.dbo.GroupClubs gc on gc.ClubID = gcm.ClubID)  "
    '   For Not By Account Club
    '   ""
    '@BYACCTCLUBSTATIC
    '   For By Account Club
    '   "gcm.MemberType = 'A' and "
    '   "gcm.GroupID = 'W'    AND  "
    '   For NOT By Account Club
    '   ""
    '@BYACCTCLUBDYNAMIC
    '   For By Account Club
    '   "gcm.ClubID = x AND"
    '   For NOT By Account Club
    '   ""
    '@BYMANIFEST
    '   For By Manifest
    '   "WeightPlanGroupID = 1 AND "
    '   For NOT By Manifest
    '   ""
    '@BYWEIGHT
    '   For By Weight
    '   "de.Weight = x AND "
    '   For NOT By Weight
    '   ""


    'Dim SQLSelect As String = _
    '"Select de.TranDate as [Trans. Date], de.OfficeID as [Center ID], so.Name as [Wgt.Ctr.] " & _
    '" , de.WeightPlanGroup as Manifest, de.AccountID, de.AccountName as Account, de.ManifestName as [Wgt.Plan], de.WeightLimit " & _
    '" ,de.OWCharge, de.Weight, de.Charge " & _
    '" , isnull(ag.Group_Name, '') as [Acct.Grp.], isnull(gc.Club_Name, '') as Club_Name, de.ParentID" & _
    '" from (((" & WeightVars.WEIGHTTblPath & "DailyEntry de left outer join " & AppTblPath & "ServiceOffices so on de.officeid = so.id) " & _
    '" Left Outer join " & AppTblPath & "Customer c on de.AccountID = c.id) " & _
    '" Left Outer Join " & AppTblPath & "GroupClubMembers gcm on convert(varchar, c.ID) = gcm.MemberID left outer join " & AppTblPath & "Groups ag on gcm.GroupID = ag.GroupID left outer join " & AppTblPath & "GroupClubs gc on gc.ClubID = gcm.ClubID) " & _
    '" WHERE gcm.MemberType = '" & GrpMemType(enGrpMemType.Acct) & "' and gcm.GroupID = '" & ModuleGroup(enGroups.Wgt) & "' " & _
    '" ORDER BY de.TranDate "

    Dim TemplateID As Integer
    Dim Template As String

    Dim sqlCondition As String

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Private m_searchForm As frmSearchInfo = Nothing
    Private m_searchInfo As clsSearchInfo = New clsSearchInfo


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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents CondID As System.Windows.Forms.TextBox
    Friend WithEvents Condition As System.Windows.Forms.TextBox
    Friend WithEvents rbNone As System.Windows.Forms.RadioButton
    Friend WithEvents rbAcct As System.Windows.Forms.RadioButton
    Friend WithEvents rbAcctGrp As System.Windows.Forms.RadioButton
    Friend WithEvents rbManifest As System.Windows.Forms.RadioButton
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbWeight As System.Windows.Forms.RadioButton
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkExpandAll = New System.Windows.Forms.CheckBox
        Me.btnPreview = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbWeight = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.CondID = New System.Windows.Forms.TextBox
        Me.Condition = New System.Windows.Forms.TextBox
        Me.rbNone = New System.Windows.Forms.RadioButton
        Me.rbAcct = New System.Windows.Forms.RadioButton
        Me.rbAcctGrp = New System.Windows.Forms.RadioButton
        Me.rbManifest = New System.Windows.Forms.RadioButton
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.btnExcel = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraGrid1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 73)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 344)
        Me.Panel1.TabIndex = 7
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(800, 344)
        Me.UltraGrid1.TabIndex = 3
        Me.UltraGrid1.Text = "Daily Weight Entry Listing"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Load"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem4})
        Me.MenuItem1.Text = "Templates"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Save As"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "Delete"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.chkExpandAll)
        Me.GroupBox1.Controls.Add(Me.btnPreview)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 417)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 40)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Location = New System.Drawing.Point(304, 16)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(96, 16)
        Me.chkExpandAll.TabIndex = 17
        Me.chkExpandAll.Text = "Expand All"
        '
        'btnPreview
        '
        Me.btnPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPreview.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPreview.Location = New System.Drawing.Point(3, 16)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 21)
        Me.btnPreview.TabIndex = 5
        Me.btnPreview.Text = "Pre&view"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(722, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 72)
        Me.Panel2.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbWeight)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DTPicker2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DTPicker1)
        Me.GroupBox2.Controls.Add(Me.btnDisplay)
        Me.GroupBox2.Controls.Add(Me.CondID)
        Me.GroupBox2.Controls.Add(Me.Condition)
        Me.GroupBox2.Controls.Add(Me.rbNone)
        Me.GroupBox2.Controls.Add(Me.rbAcct)
        Me.GroupBox2.Controls.Add(Me.rbAcctGrp)
        Me.GroupBox2.Controls.Add(Me.rbManifest)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(800, 72)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'rbWeight
        '
        Me.rbWeight.Location = New System.Drawing.Point(354, 42)
        Me.rbWeight.Name = "rbWeight"
        Me.rbWeight.Size = New System.Drawing.Size(64, 24)
        Me.rbWeight.TabIndex = 39
        Me.rbWeight.Text = "Weight"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(248, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "To Date:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPicker2
        '
        Me.DTPicker2.Location = New System.Drawing.Point(321, 14)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(104, 20)
        Me.DTPicker2.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "From Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPicker1
        '
        Me.DTPicker1.Location = New System.Drawing.Point(80, 14)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(104, 20)
        Me.DTPicker1.TabIndex = 35
        '
        'btnDisplay
        '
        Me.btnDisplay.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDisplay.Location = New System.Drawing.Point(719, 43)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(75, 21)
        Me.btnDisplay.TabIndex = 6
        Me.btnDisplay.Text = "Dis&play"
        '
        'CondID
        '
        Me.CondID.Location = New System.Drawing.Point(712, 8)
        Me.CondID.Name = "CondID"
        Me.CondID.Size = New System.Drawing.Size(21, 20)
        Me.CondID.TabIndex = 5
        Me.CondID.Text = ""
        Me.CondID.Visible = False
        '
        'Condition
        '
        Me.Condition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Condition.Location = New System.Drawing.Point(460, 43)
        Me.Condition.Name = "Condition"
        Me.Condition.Size = New System.Drawing.Size(248, 20)
        Me.Condition.TabIndex = 4
        Me.Condition.Text = ""
        '
        'rbNone
        '
        Me.rbNone.Location = New System.Drawing.Point(8, 43)
        Me.rbNone.Name = "rbNone"
        Me.rbNone.Size = New System.Drawing.Size(88, 24)
        Me.rbNone.TabIndex = 3
        Me.rbNone.Text = "No Condition"
        '
        'rbAcct
        '
        Me.rbAcct.Location = New System.Drawing.Point(282, 43)
        Me.rbAcct.Name = "rbAcct"
        Me.rbAcct.Size = New System.Drawing.Size(65, 24)
        Me.rbAcct.TabIndex = 2
        Me.rbAcct.Text = "Account"
        '
        'rbAcctGrp
        '
        Me.rbAcctGrp.Location = New System.Drawing.Point(172, 43)
        Me.rbAcctGrp.Name = "rbAcctGrp"
        Me.rbAcctGrp.Size = New System.Drawing.Size(105, 24)
        Me.rbAcctGrp.TabIndex = 1
        Me.rbAcctGrp.Text = "Account Club"
        '
        'rbManifest
        '
        Me.rbManifest.Location = New System.Drawing.Point(101, 43)
        Me.rbManifest.Name = "rbManifest"
        Me.rbManifest.Size = New System.Drawing.Size(65, 24)
        Me.rbManifest.TabIndex = 0
        Me.rbManifest.Text = "Manifest"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'UltraGridExcelExporter1
        '
        Me.UltraGridExcelExporter1.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.ThrowException
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(88, 16)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(88, 23)
        Me.btnExcel.TabIndex = 18
        Me.btnExcel.Text = "Export to Excel"
        '
        'DailyEntryListing
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(800, 457)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Menu = Me.MainMenu1
        Me.Name = "DailyEntryListing"
        Me.Tag = "DailyEntryListing"
        Me.Text = "Daily Weight Entry Listing"
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub DailyEntryListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = WeightVars.WEIGHTTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        DTPicker1.Format = DateTimePickerFormat.Custom
        DTPicker1.CustomFormat = "MM/dd/yyyy"
        DTPicker1.Value = Date.Today
        DTPicker2.Format = DateTimePickerFormat.Custom
        DTPicker2.CustomFormat = "MM/dd/yyyy"
        DTPicker2.Value = Date.Today

        rbNone.Checked = True

        'LoadData()

    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim TmpCond, SummFld, sQuery As String
        Dim sSQLSelect As String = SQLSelect

        Try

            If Condition.Enabled Then
                If CondID.Text.Trim = "" Then
                    MsgBox("Error: No value set for the condition.")
                    Exit Sub
                End If
                'TmpCond = sqlCondition & CondID.Text & " AND de.TranDate between '" & DTPicker1.Value & "' and '" & DTPicker2.Value & "'"
                TmpCond = " Where de.TranDate between '" & DTPicker1.Value & "' and '" & DTPicker2.Value & "'"
            Else
                TmpCond = " Where de.TranDate between '" & DTPicker1.Value & "' and '" & DTPicker2.Value & "'"
            End If

            Select Case iCheckBoxSelected
                Case 0 'No Condition
                    'MsgBox("No Condition")
                    sSQLSelect = Replace(sSQLSelect, "@ORDERBYCLAUSE", "ORDER BY de.ManifestName, de.TranDate ")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCOUNT", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBJOINS", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBSTATIC", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBDYNAMIC", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYMANIFEST", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYWEIGHT", "")
                    sSQLSelect = Replace(sSQLSelect, "@WHERE", "")
                    sSQLSelect = Replace(sSQLSelect, "@SHOWCLUBID", "")
                Case 1 'Manifest
                    'MsgBox("Manifest")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCOUNT", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBJOINS", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBSTATIC", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBDYNAMIC", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYWEIGHT", "")
                    sSQLSelect = Replace(sSQLSelect, "@WHERE", "JOIN UN_WEIGHT.DBO.WEIGHTPLANGROUPS wpg ON wpg.[id] = de.WeightPlanGroupID ")
                    'SQLSelect = Replace(SQLSelect, "@WHERE", "WHERE de.ManifestName = '" & Condition.Text & "' AND")
                    'SQLSelect = Replace(SQLSelect, "@BYMANIFEST", "WeightPlanGroupID = 1 ")
                    sSQLSelect = Replace(sSQLSelect, "@BYMANIFEST", "AND wpg.[NAME] = '" & Condition.Text & "'")
                    sSQLSelect = Replace(sSQLSelect, "@ORDERBYCLAUSE", "ORDER BY de.ManifestName, de.TranDate ", 1, -1, CompareMethod.Text)
                    sSQLSelect = Replace(sSQLSelect, "@SHOWCLUBID", "")
                Case 2 'Account Club
                    'MsgBox("Account Club")
                    sSQLSelect = Replace(sSQLSelect, "@ORDERBYCLAUSE", "ORDER BY de.TranDate")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCOUNT", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBJOINS", "Left Outer Join UNISON.dbo.GroupClubMembers gcm on convert(varchar, c.ID) = gcm.MemberID left outer join UNISON.dbo.GroupClubs gc on gc.ClubID = gcm.ClubID  ")
                    sSQLSelect = Replace(sSQLSelect, "@WHERE", "JOIN UNISON.DBO.GROUPCLUBS gc2 ON gc2.Club_Name = '" & Condition.Text & "' AND gc2.ClubId = gcm.ClubId AND de.TranDate between '" & DTPicker1.Value & "' and '" & DTPicker2.Value & "' AND ")
                    TmpCond = ""
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBSTATIC", "gcm.MemberType = 'A' and gcm.GroupID = 'W' ")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBDYNAMIC", "")
                    'sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBDYNAMIC", "gcm.ClubID = @XXX ")
                    'sSQLSelect = Replace(sSQLSelect, "@XXX", "'" & Condition.Text & "'")
                    sSQLSelect = Replace(sSQLSelect, "@BYMANIFEST", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYWEIGHT", "")
                    sSQLSelect = Replace(sSQLSelect, "@SHOWCLUBID", "isnull(gc.Club_Name,'') as Club_Name,")
                Case 3 'Account
                    'MsgBox("Account")
                    sSQLSelect = Replace(sSQLSelect, "@ORDERBYCLAUSE", "ORDER BY de.TranDate")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCOUNT", "ACCOUNTID = @XXX ")
                    sSQLSelect = Replace(sSQLSelect, "@XXX", CondID.Text)
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBJOINS", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBSTATIC", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBDYNAMIC", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYMANIFEST", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYWEIGHT", "")
                    sSQLSelect = Replace(sSQLSelect, "@WHERE", "WHERE ")
                    sSQLSelect = Replace(sSQLSelect, "@SHOWCLUBID", "")
                Case 4 'Weight
                    'MsgBox("Weight")
                    sSQLSelect = Replace(sSQLSelect, "@ORDERBYCLAUSE", "ORDER BY de.weight, de.ManifestName, de.TranDate")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCOUNT", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBJOINS", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBSTATIC", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYACCTCLUBDYNAMIC", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYMANIFEST", "")
                    sSQLSelect = Replace(sSQLSelect, "@BYWEIGHT", "de.Weight = " & CInt(Condition.Text))
                    sSQLSelect = Replace(sSQLSelect, "@WHERE", "WHERE ")
                    sSQLSelect = Replace(sSQLSelect, "@SHOWCLUBID", "")
            End Select

            '@ORDERBYCLAUSE
            '   For No Condition & By Manifest
            '   "ORDER BY de.ManifestName, de.TranDate "
            '   For By Account & By Account Club
            '   "ORDER BY de.TranDate"
            '   For By Weight
            '   "ORDER BY de.weight, de.ManifestName, de.TranDate
            '@BYACCOUNT
            '   For By Account
            '   "ACCOUNTID = XXX AND"
            '   For NOT By Account
            '   ""
            '@BYACCTCLUBJOINS
            '   For By Account Club
            '   "Left Outer Join UNISON.dbo.GroupClubMembers gcm on convert(varchar, c.ID) = gcm.MemberID "
            '   "left outer join UNISON.dbo.GroupClubs gc on gc.ClubID = gcm.ClubID)  "
            '   For Not By Account Club
            '   ""
            '@BYACCTCLUBSTATIC
            '   For By Account Club
            '   "gcm.MemberType = 'A' and "
            '   "gcm.GroupID = 'W'    AND  "
            '   For NOT By Account Club
            '   ""
            '@BYACCTCLUBDYNAMIC
            '   For By Account Club
            '   "gcm.ClubID = x AND"
            '   For NOT By Account Club
            '   ""
            '@BYMANIFEST
            '   For By Manifest
            '   "WeightPlanGroupID = 1 AND "
            '   For NOT By Manifest
            '   ""
            '@BYWEIGHT
            '   For By Weight
            '   "de.Weight = x AND "
            '   For NOT By Weight
            '   ""


            sQuery = PrepSelectQuery(sSQLSelect, TmpCond)
            PopulateDataset2(dtAdapter, dtSet, sQuery)

            FillUltraGrid(UltraGrid1, dtSet, 0)

            'UGLoadListingLayout(UltraGrid1, TemplateID)

            UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
            UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
            SummFld = "Trans. Date"
            UltraGrid1.DisplayLayout.Bands(0).Summaries.Add(SummFld, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns(SummFld), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
            UltraGrid1.DisplayLayout.Bands(0).Summaries(SummFld).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
            UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False

            'ultragrid1.DisplayLayout.Bands(0).

            Me.Text = MeText
            UltraGrid1.DrawFilter = Me

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try


    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            UltraGrid1.PrintPreview()
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Catch Err As System.Exception
            MsgBox("Error: " & Err.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Catch Err2 As System.NullReferenceException
            MsgBox("Error: " & Err2.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Finally
        End Try

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'UGSaveLayout(Me, UltraGrid1, 1)
        Me.Close()

    End Sub
    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement
            Dim oUIElement As Infragistics.Win.UIElement
            Dim oUIElementTmp As Infragistics.Win.UIElement
            Dim point As Point = New Point(e.X, e.Y)


            oUIElement = Me.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(point)
            If oUIElement Is Nothing Then Exit Sub
            'Infragistics.Win.UltraWinGrid.BandHeadersUIElement()
            'Infragistics.Win.UltraWinGrid.CaptionAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardCaptionUIElement()
            'Infragistics.Win.UltraWinGrid.CardLabelAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardLabelUIElement()
            'Infragistics.Win.UltraWinGrid.CellUIElement()
            'Infragistics.Win.UltraWinGrid.DataAreaUIElement()
            'Infragistics.Win.UltraWinGrid.PageHeaderUIElement()
            'Infragistics.Win.UltraWinGrid.PreRowAreaUIElement()
            'Infragistics.Win.UltraWinGrid.RowCellAreaUIElement()
            'Infragistics.Win.UltraWinGrid.RowSelectorUIElement()
            'Infragistics.Win.UltraWinGrid.RowUIElement()
            'Infragistics.Win.UltraWinGrid.SortIndicatorUIElement()
            'Infragistics.Win.UltraWinGrid.UltraGridUIElement()

            oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement))
            If oUIElementTmp Is Nothing Then
                oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement))
                If oUIElementTmp Is Nothing Then
                    Return
                End If
            End If
            oUIElement = oUIElementTmp
            If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement) Then
                If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement) Then
                    Exit Sub
                Else
                    oCaptionUI = oUIElement
                End If
            Else
                oHeaderUI = oUIElement
            End If

            If oCaptionUI Is Nothing Then
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("Hide", New EventHandler(AddressOf mnuHide_Click))
                CntMenu1.MenuItems.Add("Unhide")
                CntMenu1.MenuItems.Add("Find", New EventHandler(AddressOf mnuFind_Click))
                CntMenu1.MenuItems.Add("Add to Sort (Asc)", New EventHandler(AddressOf mnuSortAsc_Click))
                CntMenu1.MenuItems.Add("Add to Sort (Desc)", New EventHandler(AddressOf mnuSortDesc_Click))


                Dim oColHeader As Infragistics.Win.UltraWinGrid.ColumnHeader = Nothing
                m_oColumn = Nothing
                oColHeader = oHeaderUI.SelectableItem
                m_oColumn = oColHeader.Column
                If m_oColumn Is Nothing Then Exit Sub


                Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
                If CntMenu1.MenuItems.Item(1).MenuItems.Count > 0 Then
                    CntMenu1.MenuItems.Item(1).MenuItems.Clear()
                    CntMenu1.MenuItems.RemoveAt(1)
                    CntMenu1.MenuItems.Add("Unhide")
                    CntMenu1.MenuItems(CntMenu1.MenuItems.Count).Index = 1
                End If
                For Each ugcol In UltraGrid1.DisplayLayout.Bands(0).Columns
                    If ugcol.Hidden = True Then
                        CntMenu1.MenuItems(1).MenuItems.Add(ugcol.ToString, New EventHandler(AddressOf SubMnuUnHide_Click))
                    End If
                Next

                CntMenu1.Show(UltraGrid1, point)
            Else 'Caption Click
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("AutoFit", New EventHandler(AddressOf mnuAutoFit_Click))
                CntMenu1.MenuItems(0).Checked = UltraGrid1.DisplayLayout.AutoFitColumns
                CntMenu1.Show(UltraGrid1, point)

            End If


        End If

    End Sub

    Private Sub mnuAutoFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CntMenu1.MenuItems(0).Checked Then
            CntMenu1.MenuItems(0).Checked = False
        Else
            CntMenu1.MenuItems(0).Checked = True
        End If
        UltraGrid1.DisplayLayout.AutoFitColumns = CntMenu1.MenuItems(0).Checked

    End Sub

    Private Sub mnuHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuHide.Click
        If Not m_oColumn Is Nothing Then
            m_oColumn.Hidden = True
        End If
    End Sub
    Private Sub SubMnuUnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ugCol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        For Each ugCol In UltraGrid1.DisplayLayout.Bands(0).Columns
            If ugCol.ToString = sender.text Then
                ugCol.Hidden = False
            End If
        Next

    End Sub

    Private Sub mnuSortAsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortAsc.Click
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(m_oColumn, False)
    End Sub

    Private Sub mnuSortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortDesc.Click
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(Me.m_oColumn, True)
    End Sub

    Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
        If chkExpandAll.Checked Then
            Me.UltraGrid1.Rows.ExpandAll(True)
        Else
            Me.UltraGrid1.Rows.CollapseAll(True)
        End If
    End Sub

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.m_oColumn Is Nothing Then Exit Sub

        If Me.m_searchForm Is Nothing Then
            Me.m_searchForm = New frmSearchInfo
        End If

        Me.m_searchForm.ShowMe(Me, Me.m_oColumn.Key, UltraGrid1, m_searchInfo)

    End Sub

    '*********************************************************************************************************
    '*************************************** Search Routines  ************************************************
    '*********************************************************************************************************

    ''Public ReadOnly Property SearchInfo()
    ''    Get
    ''        SearchInfo = Me.m_searchInfo
    ''    End Get
    ''End Property

    ''Public Sub Search()

    ''    '   See if there is an active row; if there is, use it, otherwise
    ''    '   activate the first row and start the search from there
    ''    Dim oRow As Infragistics.Win.UltraWinGrid.UltraGridRow
    ''    oRow = Me.UltraGrid1.ActiveRow
    ''    If oRow Is Nothing Then oRow = Me.UltraGrid1.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)

    ''    '   Use the row object's GetSibling method to iterate through the rows
    ''    '   and check the appropriate cell values

    ''    '   Downward search
    ''    If Me.m_searchInfo.searchDirection = SearchDirectionEnum.Down Then
    ''        While Not oRow Is Nothing
    ''            oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
    ''            If Me.MatchText(oRow) Then
    ''                Me.UltraGrid1.ActiveRow = oRow
    ''                If Not Me.m_oColumn Is Nothing Then
    ''                    Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
    ''                    Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
    ''                End If
    ''                Exit Sub
    ''            End If
    ''        End While

    ''        '   Upward search
    ''    ElseIf Me.m_searchInfo.searchDirection = SearchDirectionEnum.Up Then
    ''        While Not oRow Is Nothing
    ''            oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous)
    ''            If Me.MatchText(oRow) Then
    ''                Me.UltraGrid1.ActiveRow = oRow
    ''                If Not Me.m_oColumn Is Nothing Then
    ''                    Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
    ''                    Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
    ''                End If
    ''                Exit Sub
    ''            End If
    ''        End While

    ''        '   Search all rows. First, we start with the active row. If we don't find
    ''        '   it by the time we hit the  last row, try again starting from the first row
    ''    ElseIf Me.m_searchInfo.searchDirection = SearchDirectionEnum.All Then
    ''        While Not oRow Is Nothing
    ''            oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
    ''            If Me.MatchText(oRow) Then
    ''                Me.UltraGrid1.ActiveRow = oRow
    ''                If Not Me.m_oColumn Is Nothing Then
    ''                    Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
    ''                    Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
    ''                End If
    ''                Exit Sub
    ''            End If
    ''        End While

    ''        '   We didn't find it the first time around, so start again from the first row
    ''        oRow = Me.UltraGrid1.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)
    ''        While Not oRow Is Nothing
    ''            If Me.MatchText(oRow) Then
    ''                Me.UltraGrid1.ActiveRow = oRow
    ''                If Not Me.m_oColumn Is Nothing Then
    ''                    Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
    ''                    Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
    ''                End If
    ''                Exit Sub
    ''            End If
    ''            oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
    ''        End While

    ''    End If

    ''    '   If we get this far, we didn't find the string, so show a message box
    ''    MessageBox.Show("UltraGrid has searched all the records. The search item '" & Me.m_searchInfo.searchString & "' was not found.", "Infragistics UltraGrid", MessageBoxButtons.OK, MessageBoxIcon.None)

    ''End Sub

    ''Private Function MatchText(ByVal oRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Boolean
    ''    If oRow Is Nothing Then
    ''        MatchText = False
    ''        Exit Function
    ''    End If
    ''    If oRow.ListObject Is Nothing Then
    ''        MatchText = False
    ''        Exit Function
    ''    End If

    ''    Dim strColumnKey As String = Me.m_searchInfo.lookIn
    ''    Dim oCol As Infragistics.Win.UltraWinGrid.UltraGridColumn
    ''    Dim strCellValue As String = ""

    ''    '   Determine whether we are searching the current column or all columns
    ''    Dim bSearchAllColumns = True
    ''    If Me.UltraGrid1.DisplayLayout.Bands(0).Columns.Exists(strColumnKey) Then bSearchAllColumns = False

    ''    '   If we are searching all columns then we must iterate through all the cells
    ''    '    in this row, which we can do by using the band's Columns collection
    ''    If bSearchAllColumns Then
    ''        For Each oCol In Me.UltraGrid1.DisplayLayout.Bands(0).Columns
    ''            If Not oRow.Cells(oCol.Key).Value Is Nothing Then
    ''                If Me.Match(Me.m_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
    ''                    MatchText = True
    ''                    Me.m_oColumn = oCol
    ''                    Exit Function
    ''                End If
    ''            End If
    ''        Next
    ''    Else
    ''        oCol = Me.UltraGrid1.DisplayLayout.Bands(0).Columns(strColumnKey)
    ''        If Not oRow.Cells(oCol.Key).Value Is Nothing Then
    ''            If Me.Match(Me.m_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
    ''                MatchText = True
    ''                Me.m_oColumn = oCol
    ''                Exit Function
    ''            End If
    ''        End If
    ''    End If

    ''End Function

    ''Private Function Match(ByVal userString As String, ByVal cellValue As String) As Boolean

    ''    '   If our search is case insensitive, make both strings uppercase
    ''    If Not Me.m_searchInfo.matchCase Then
    ''        userString = userString.ToUpper
    ''        cellValue = cellValue.ToUpper
    ''    End If

    ''    '   If we are searching any part of the cell value...
    ''    If Me.m_searchInfo.searchContent = SearchContentEnum.AnyPartOfField Then

    ''        '   If the user string is larger than the cell value, it is by definition
    ''        '   a mismatch, so return false
    ''        If userString.Length > cellValue.Length Then
    ''            Match = False
    ''            Exit Function
    ''        ElseIf userString.Length = cellValue.Length Then
    ''            '   If the lengths are equal, the strings must be equal as well
    ''            If userString = cellValue Then Match = True Else Match = False
    ''            Exit Function
    ''        Else
    ''            '   There is probably an easier way to do this
    ''            Dim i As Integer
    ''            For i = 0 To (cellValue.Length - userString.Length) - 0
    ''                If userString = cellValue.Substring(i, userString.Length) Then
    ''                    Match = True
    ''                    Exit Function
    ''                End If
    ''            Next
    ''            Match = False
    ''            Exit Function

    ''        End If

    ''    ElseIf Me.m_searchInfo.searchContent = SearchContentEnum.WholeField Then
    ''        If userString = cellValue Then Match = True Else Match = False
    ''        Exit Function

    ''    ElseIf Me.m_searchInfo.searchContent = SearchContentEnum.StartOfField Then
    ''        If userString.Length >= cellValue.Length Then
    ''            If userString.Substring(0, cellValue.Length) = cellValue Then
    ''                Match = True
    ''            Else
    ''                Match = False
    ''            End If
    ''            Exit Function
    ''        Else
    ''            If cellValue.Substring(0, userString.Length) = userString Then Match = True Else Match = False
    ''            Exit Function
    ''        End If

    ''    End If

    ''End Function

    ''Public Class clsSearchInfo
    ''    Public searchString As String = ""
    ''    Public lookIn As String
    ''    Public searchDirection As SearchDirectionEnum = SearchDirectionEnum.All
    ''    Public searchContent As SearchContentEnum = SearchContentEnum.WholeField
    ''    Public matchCase As Boolean = False
    ''End Class

    ''Public Enum SearchDirectionEnum
    ''    Down = 0
    ''    Up = 1
    ''    All = 2
    ''End Enum

    ''Public Enum SearchContentEnum
    ''    AnyPartOfField = 0
    ''    WholeField = 1
    ''    StartOfField = 2
    ''End Enum

    ''Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click ' Load Template
    ''    Dim SelectSQL As String
    ''    Dim dtAdapter As New SqlDataAdapter()
    ''    Dim dtSet As New DataSet()
    ''    Dim dtView As New DataView()
    ''    Dim HasErr As Boolean
    ''    Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

    ''    SelectSQL = "Select ID, Name from ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

    ''    PopulateDataset2(dtAdapter, dtSet, SelectSQL)
    ''    dtView.Table = dtSet.Tables(0)
    ''    If dtView.Table.Rows.Count > 0 Then
    ''        Dim Srch As New SearchListings()
    ''        Srch.dsList = dtSet

    ''        Srch.UltraGrid1.Text = "Templates"
    ''        Srch.Text = "Weight-Plan Listing Templates"
    ''        Srch.ShowDialog()
    ''        If Srch.DialogResult <> DialogResult.OK Then Exit Sub
    ''        Try
    ''            Dim cnt As Integer
    ''            cnt = Srch.UltraGrid1.Rows.Count
    ''        Catch Err As System.Exception
    ''            'MsgBox("Zipcode Leave: " & Err.Message)
    ''            Srch = Nothing
    ''            sender.Focus()
    ''            HasErr = True
    ''            Exit Try
    ''        Catch Err2 As System.NullReferenceException
    ''            ' CANCEL PRESSED
    ''            Srch = Nothing
    ''            sender.Focus()
    ''            HasErr = True
    ''            Exit Try
    ''        Catch osqlexception As SqlException
    ''            MsgBox("SQL_Error: " & osqlexception.Message)
    ''            Srch = Nothing
    ''            sender.Focus()
    ''            Exit Try
    ''        Finally
    ''            If HasErr = False Then
    ''                ugRow = Srch.UltraGrid1.ActiveRow

    ''                TemplateID = ugRow.Cells("ID").Text
    ''                If Not UltraGrid1.DataSource Is Nothing Then
    ''                    UGLoadListingLayout(UltraGrid1, TemplateID)
    ''                End If
    ''                Me.Text = MeText & " - Using Layout : " & ugRow.Cells("Name").Text
    ''                Template = ugRow.Cells("Name").Text
    ''            End If
    ''        End Try
    ''        Srch = Nothing
    ''    End If

    ''End Sub

    ''Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
    ''    Dim x As New EnterTextBox()

    ''    x.Text = "Save Template"
    ''    x.TextBox1.Text = Template
    ''    x.ShowDialog()
    ''    If x.DialogResult <> DialogResult.OK Then Exit Sub
    ''    If Template <> x.TextBox1.Text.Trim Then
    ''        TemplateID = 0
    ''    End If
    ''    Template = x.TextBox1.Text.Trim
    ''    UGSaveListingLayout(Me, UltraGrid1, TemplateID, Template)
    ''    x = Nothing
    ''    If TemplateID = 0 Then
    ''        MsgBox("Failed")
    ''    End If
    ''End Sub

    ''Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
    ''    Dim SelectSQL As String
    ''    Dim dtAdapter As New SqlDataAdapter()
    ''    Dim dtSet As New DataSet()
    ''    Dim dtView As New DataView()

    ''    SelectSQL = "Select ID, Name from ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

    ''    PopulateDataset2(dtAdapter, dtSet, SelectSQL)
    ''    dtView.Table = dtSet.Tables(0)
    ''    If dtView.Table.Rows.Count > 0 Then
    ''        Dim Srch As New SearchListings()
    ''        Srch.dsList = dtSet
    ''        Srch.sqlSelect = SelectSQL
    ''        Srch.btnDelete.Visible = True
    ''        Srch.Button1.Enabled = False

    ''        Srch.UltraGrid1.Text = "Templates"
    ''        Srch.Text = "Weight-Plan Listing Templates"
    ''        Srch.ShowDialog()
    ''        'If Srch.DialogResult <> DialogResult.OK Then Exit Sub
    ''        Srch = Nothing
    ''    End If

    ''End Sub

    Private Sub rbNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNone.CheckedChanged, rbManifest.CheckedChanged, rbAcctGrp.CheckedChanged, rbAcct.CheckedChanged, rbWeight.CheckedChanged
        Condition.Text = "" 'Karina added to empty Condition field if change the menu

        Select Case sender.name
            Case "rbNone"
                Condition.Enabled = False
                Condition.Text = ""
                sqlCondition = ""
                iCheckBoxSelected = 0
            Case "rbManifest"
                Condition.Enabled = True
                sqlCondition = " Where WeightPlanGroupID = "
                iCheckBoxSelected = 1
            Case "rbAcctGrp"
                Condition.Enabled = True
                sqlCondition = " Where gcm.GroupID = '" & ModuleGroup(enGroups.Wgt) & "' AND gcm.ClubID = "
                iCheckBoxSelected = 2
            Case "rbAcct"
                Condition.Enabled = True
                sqlCondition = " Where AccountID = "
                iCheckBoxSelected = 3
            Case "rbWeight"
                ''Private Sub Value_Dec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
                ''    If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "." Then
                ''        e.Handled = True
                ''    End If
                ''End Sub
                'If IsNumeric(Condition.Text) = False And Asc(Condition.Text) <> Keys.Back And Condition.Text <> "." Then
                '    Condition.Enabled = True
                'End If

                Condition.Enabled = True
                sqlCondition = " Where Weight = "
                iCheckBoxSelected = 4
        End Select

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        If Not rbNone.Checked And Condition.Text.Trim = "" Then
            MsgBox("Condition is not set. Please input the criteria.")
            Exit Sub
        End If

        'Karina commented to check if condition is Decimal
        'If rbWeight.Checked Then
        '    If Condition.Text.ToString() Is GetType(System.Decimal) = False Then
        '        MsgBox("ENTER DECIMAL!")
        '        Condition.Text = ""
        '        Exit Sub
        '    End If
        'End If
        LoadData()
    End Sub


    Private Sub Condition_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Condition.Leave
        'On Error GoTo ErrTrap
        Dim daCity As New SqlDataAdapter
        Dim dsCity As New DataSet
        Dim dvCities1 As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim IDFld, NameFld, SrchTitle As String

        Dim WGTGrpSQL, TableName As String
        NameFld = "Name"
        IDFld = "ID"
        If rbManifest.Checked Then
            WGTGrpSQL = "Select * FROM " & WeightVars.WEIGHTTblPath & "WeightPlanGroups "
            TableName = WeightVars.WEIGHTTblPath & "WeightPlanGroups"
            SrchTitle = "Weight-Plan Groups"
        ElseIf rbAcctGrp.Checked Then
            WGTGrpSQL = "Select * FROM " & WeightVars.WEIGHTTblPath & "GroupClubs where GroupID = '" & ModuleGroup(enGroups.Wgt) & "' " 'AppTblPath
            TableName = WeightVars.WEIGHTTblPath & "GroupClubs"
            IDFld = "ClubID"
            NameFld = "Club_Name"
            SrchTitle = "Clubs"
        ElseIf rbWeight.Checked Then
            CondID.Text = Condition.Text
            SrchTitle = "Weight"
            Exit Sub
        Else
            WGTGrpSQL = "Select * FROM " & WeightVars.WEIGHTTblPath & "Customer " 'AppTblPath
            TableName = WeightVars.WEIGHTTblPath & "Customer"
            SrchTitle = "Accounts"
        End If

        HasErr = False
        If sender.Modified Then
            If IsNumeric(sender.Text) Then ' ClubID
                WGTGrpSQL = PrepSelectQuery(WGTGrpSQL, " where " & IDFld & " = '" & sender.Text & "' ")
                PopulateDataset2(daCity, dsCity, WGTGrpSQL)
                dvCities1.Table = dsCity.Tables(TableName)
                If dvCities1.Table.Rows.Count > 0 Then
                    CondID.Text = sender.Text.ToString
                    Condition.Text = dvCities1.Table.Rows(0).Item(NameFld)
                Else
                    MsgBox("ID not found!", MsgBoxStyle.OKOnly, MeText)
                    Condition.ResetText()
                    Condition.Focus()

                End If
            Else 'Blank or City Name
                If sender.text.trim() = "" Then
                    CondID.Text = ""
                    Exit Sub
                End If
                If sender.Text.StartsWith("?") Then
                    sender.text = sender.text.substring(1)
                End If
                'WGTGrpSQL = PrepSelectQuery(WGTGrpSQL, " where " & NameFld & " like '" & sender.text & "%' Order by " & NameFld & "")
                WGTGrpSQL = PrepSelectQuery(WGTGrpSQL, " where " & NameFld & " like '" & sender.text & "%' Order by " & NameFld & "")

                PopulateDataset2(daCity, dsCity, WGTGrpSQL)
                dvCities1.Table = dsCity.Tables(TableName)
                If dvCities1.Table.Rows.Count > 0 Then
                    If dvCities1.Table.Rows.Count > 1 Then
                        Dim Srch As New SearchListings
                        Srch.dsList = dsCity

                        Srch.UltraGrid1.Text = SrchTitle '"Manifests beginning with '" & sender.text & "' in '" & GetNextControl(sender, True).Text & "'"
                        Srch.Text = SrchTitle '"Manifests"
                        Srch.ShowDialog()
                        If Srch.DialogResult <> DialogResult.OK Then
                            sender.focus()
                            Exit Sub
                        End If
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
                                Condition.Text = ugRow.Cells(NameFld).Text
                                CondID.Text = ugRow.Cells(IDFld).Text
                                Srch = Nothing
                            End If
                        End Try
                    Else ' Just one record found
                        Condition.Text = dvCities1(0).Item(NameFld) 'ugRow.Cells("City").Text
                        CondID.Text = dvCities1(0).Item(IDFld) ' ugRow.Cells("Zipcode").Text
                    End If
                Else
                    MsgBox("No matching record found!", MsgBoxStyle.OKOnly, MeText)
                End If
            End If
            sender.Modified = False
        End If
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing
        Exit Sub
ErrTrap:
        MsgBox("Error: " & Err.Description)
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing

    End Sub
    Private Sub Condition_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Condition.KeyUp
        Dim WGTGrpSQL As String
        Dim NameFld, Cond As String

        NameFld = "Name"
        Cond = ""
        If rbManifest.Checked Then
            WGTGrpSQL = WeightVars.WEIGHTTblPath & "WeightPlanGroups"
        ElseIf rbWeight.Checked Then 'Karina added to prevent from TypeAhead on Weight
            AddHandler Condition.KeyPress, AddressOf Value_Dec_KeyPress
            Exit Sub
        ElseIf rbAcctGrp.Checked Then
            WGTGrpSQL = WeightVars.WEIGHTTblPath & "GroupClubs" 'Karina changed pass from AppTblPath
            NameFld = "Club_Name"
            Cond = " Where GroupID = '" & ModuleGroup(enGroups.Wgt) & "' "
        Else
            WGTGrpSQL = WeightVars.WEIGHTTblPath & "Customer" 'Karina changed pass from AppTblPath
        End If

        TypeAhead(sender, e, WGTGrpSQL, NameFld, Cond)
        'sender.modified = True
    End Sub


    'Private Sub UltraGrid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout

    '    ''    '   Hide the identity columns
    '    ''    e.Layout.Bands(0).Columns("CustomerID").Hidden = True

    '    ''    e.Layout.Bands(1).Columns("InvoiceID").Hidden = True
    '    ''    e.Layout.Bands(1).Columns("CustomerID").Hidden = True

    '    ''    e.Layout.Bands(2).Columns("DetailID").Hidden = True
    '    ''    e.Layout.Bands(2).Columns("InvoiceID").Hidden = True
    '    ''    e.Layout.Bands(2).Columns("ProductID").Hidden = True
    '    ''    e.Layout.Bands(2).Columns("Description").Header.VisiblePosition = 0

    '    ''    With e.Layout.Override
    '    ''        .RowAppearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent

    '    ''        'use the same appearance for alternate rows
    '    ''        .RowAlternateAppearance = .RowAppearance
    '    ''        .CellAppearance.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    '    ''        .CellAppearance.AlphaLevel = 192

    '    ''        .HeaderAppearance.AlphaLevel = 192
    '    ''        .HeaderAppearance.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel

    '    ''        '   Disallow the moving and resizing of columns to simplify
    '    ''        '   the rendering of text in the band totals area
    '    ''        .AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
    '    ''        .AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
    '    ''    End With


    '    ''    FormatCurrencyColumns()

    '    '' Create the Appearance objects, if they aren't already there
    '    If Not UltraGrid1.DisplayLayout.Appearances.Exists("Totals") Then
    '        UltraGrid1.DisplayLayout.Appearances.Add("Totals")
    '        UltraGrid1.DisplayLayout.Appearances("Totals").BackColor = Color.DarkGray
    '        UltraGrid1.DisplayLayout.Appearances("Totals").ForeColor = Color.Red
    '    End If
    '    If Not UltraGrid1.DisplayLayout.Appearances.Exists("Title") Then
    '        UltraGrid1.DisplayLayout.Appearances.Add("Title")
    '        UltraGrid1.DisplayLayout.Appearances("Title").BackColor = Color.Aquamarine
    '        UltraGrid1.DisplayLayout.Appearances("Title").ForeColor = Color.Blue
    '    End If
    'End Sub

    '======================================================================================================

    Private Sub FormatCurrencyColumns() 'Used in InitializeRow

        Dim oBand As Infragistics.Win.UltraWinGrid.UltraGridBand
        Dim oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn

        For Each oBand In Me.UltraGrid1.DisplayLayout.Bands
            For Each oColumn In oBand.Columns
                If oColumn.DataType.ToString() = "System.Decimal" Then
                    oColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    oColumn.Format = "$#,###,###.00"
                End If
            Next
        Next

    End Sub

    Public Function DrawElement(ByVal drawPhase As Infragistics.Win.DrawPhase, ByRef drawParams As Infragistics.Win.UIElementDrawParams) As Boolean Implements Infragistics.Win.IUIElementDrawFilter.DrawElement

        Dim childUIElement As Infragistics.Win.UIElement
        Dim rowUIElement As Infragistics.Win.UltraWinGrid.RowUIElement
        For Each childUIElement In drawParams.Element.ChildElements
            If childUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.RowUIElement) Then
                rowUIElement = childUIElement

                '''   We are only doing this for bands 1 & 2
                ''If rowUIElement.Row.Band.Index > 0 Then

                'If rowUIElement.Row.HasNextSibling() = False Then
                '    'DrawRowTitle(rowUIElement, drawParams)
                '    DrawRowTotals(rowUIElement, drawParams)
                '    'If rowUIElement.Row.Band.Index = 1 Then
                '    '    DrawRowTitle(rowUIElement, drawParams)
                '    '    DrawRowTotals(rowUIElement, drawParams)
                '    'Else
                '    '    DrawRowTotals(rowUIElement, drawParams)
                '    'End If
                'End If
                ''End If
            End If
        Next

    End Function

    Public Function GetPhasesToFilter(ByRef drawParams As Infragistics.Win.UIElementDrawParams) As Infragistics.Win.DrawPhase Implements Infragistics.Win.IUIElementDrawFilter.GetPhasesToFilter

        If Not drawParams.Element.GetType() Is GetType(Infragistics.Win.UltraWinGrid.RowColRegionIntersectionUIElement) Then
            GetPhasesToFilter = Infragistics.Win.DrawPhase.None
        Else
            GetPhasesToFilter = Infragistics.Win.DrawPhase.AfterDrawElement
        End If

    End Function


    'Private Sub DrawRowTotals(ByVal oRowUI As Infragistics.Win.UltraWinGrid.RowUIElement, ByRef drawParams As Infragistics.Win.UIElementDrawParams)

    '    Dim height As Integer
    '    Dim width As Integer
    '    Dim offset As Integer = 0
    '    Dim total As Decimal = Me.GetInvoiceTotal(oRowUI.Row)
    '    Dim pad As Integer = 4

    '    '   Create a font
    '    Dim font As Font = New Font("Arial", 8.25)

    '    '   Create a graphics object off the control
    '    Dim gr As Graphics
    '    gr = Me.UltraGrid1.CreateGraphics()
    '    height = gr.MeasureString("Wj", font).Height + pad
    '    Dim stringWidth As Integer = gr.MeasureString(total.ToString("$#,###,###.00"), font).Width + pad

    '    If oRowUI.Row.Band.Index = 1 Then offset = height + 1

    '    Dim rect As Rectangle
    '    Dim left As Integer = oRowUI.Row.Band.GetOrigin(Infragistics.Win.UltraWinGrid.BandOrigin.RowSelector) + 2
    '    If oRowUI.Row.Band.Index = 1 Then
    '        width = oRowUI.Rect.Width - oRowUI.Row.Band.GetOrigin(Infragistics.Win.UltraWinGrid.BandOrigin.PreRowArea)
    '    ElseIf oRowUI.Row.Band.Index = 0 Then
    '        'width = oRowUI.Rect.Width - _
    '        '   (oRowUI.Row.Band.GetOrigin(Infragistics.Win.UltraWinGrid.BandOrigin.RowSelector) - _
    '        '  oRowUI.Row.Band.GetOrigin(Infragistics.Win.UltraWinGrid.BandOrigin.PreRowArea))
    '        width = 800
    '    End If

    '    rect = New Rectangle(left, oRowUI.Rect.Bottom + offset, width, height)

    '    Dim backBrush As New SolidBrush(Me.UltraGrid1.DisplayLayout.Appearances("Totals").BackColor)
    '    Dim foreBrush As New SolidBrush(Me.UltraGrid1.DisplayLayout.Appearances("Totals").ForeColor)
    '    Me.DrawRoundedRect(drawParams.Graphics, backBrush, rect)
    '    'drawParams.Graphics.DrawString(total.ToString("$#,###,###.00"), font, foreBrush, rect.Right - stringWidth, rect.Top)
    '    drawParams.Graphics.DrawString(total.ToString("$#,###,###.00"), font, foreBrush, rect.Right - stringWidth, rect.Top)

    '    '   Clean up
    '    font.Dispose()
    '    gr.Dispose()
    'End Sub

    Private Sub DrawRowTitle(ByVal oRowUI As Infragistics.Win.UltraWinGrid.RowUIElement, ByRef drawParams As Infragistics.Win.UIElementDrawParams)

        Dim height As Integer
        Dim pad As Integer = 4
        Dim strCustomerName As String = _
        oRowUI.Row.ParentRow.Cells("FirstName").GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw).ToString()
        strCustomerName = strCustomerName & " " & _
        oRowUI.Row.ParentRow.Cells("LastName").GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw).ToString()

        '   Create a font
        Dim font As Font = New Font("Arial", 8.25)

        '   Create a graphics object off the control
        Dim gr As Graphics
        gr = Me.UltraGrid1.CreateGraphics()
        height = gr.MeasureString("Wj", font).Height + pad

        Dim rect As Rectangle
        Dim left As Integer = oRowUI.Row.Band.GetOrigin(Infragistics.Win.UltraWinGrid.BandOrigin.RowSelector) + 2
        Dim width As Integer = oRowUI.Rect.Width - oRowUI.Row.Band.GetOrigin(Infragistics.Win.UltraWinGrid.BandOrigin.PreRowArea)
        rect = New Rectangle(left, oRowUI.Rect.Bottom + 1, width, height)

        Dim backBrush As New SolidBrush(Me.UltraGrid1.DisplayLayout.Appearances("Title").BackColor)
        Dim foreBrush As New SolidBrush(Me.UltraGrid1.DisplayLayout.Appearances("Title").ForeColor)
        drawParams.Graphics.FillRectangle(backBrush, rect)
        drawParams.Graphics.DrawString("Totals for Customer '" & strCustomerName & "' (" & Me.GetInvoiceCount(oRowUI.Row).ToString() & " invoices)", font, foreBrush, rect.Left + 2, rect.Top)

        '   Clean up
        font.Dispose()
        gr.Dispose()
    End Sub

    Private Sub DrawRoundedRect(ByRef gr As Graphics, ByRef brush As SolidBrush, ByVal rect As Rectangle)

        Dim temp As Rectangle = New Rectangle(rect.Left, rect.Top, rect.Width, (rect.Height * 3 / 4))
        Dim corner As Integer = rect.Height / 4
        gr.FillRectangle(brush, temp)
        temp = New Rectangle(rect.Left + corner, temp.Bottom, rect.Width - (corner * 2), corner)
        gr.FillRectangle(brush, temp)
        temp = New Rectangle(rect.Left, rect.Bottom - (corner * 2) - 1, (corner * 2), (corner * 2))
        gr.FillEllipse(brush, temp)
        temp = New Rectangle(rect.Right - (corner * 2) - 1, rect.Bottom - (corner * 2) - 1, (corner * 2), (corner * 2))
        gr.FillEllipse(brush, temp)


    End Sub

    Private Function GetInvoiceTotal(ByVal oRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Decimal

        If oRow.HasNextSibling() Then
            Throw New Exception("The row has to be the last one in this band")
            Exit Function
        End If

        Dim prevRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim total As Decimal = 0
        prevRow = oRow
        While Not prevRow Is Nothing
            total += prevRow.Cells("Charge").Value
            prevRow = prevRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous)
        End While
        GetInvoiceTotal = total

    End Function

    Private Function GetInvoiceCount(ByVal oRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Integer

        If oRow.HasNextSibling() Then
            Throw New Exception("The row has to be the last one in this band")
            Exit Function
        End If

        Dim prevRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim total As Integer = 0
        prevRow = oRow
        While Not prevRow Is Nothing
            total += 1
            prevRow = prevRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous)
        End While
        GetInvoiceCount = total

    End Function


    'Private Sub UltraGrid1_AfterRowExpanded(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles UltraGrid1.AfterRowExpanded

    '    Dim childRow As Infragistics.Win.UltraWinGrid.UltraGridRow = e.Row.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)

    '    While Not childRow Is Nothing
    '        If Not childRow.HasNextSibling(False) Then
    '            If childRow.Band.Index = 1 Then
    '                childRow.RowSpacingAfter = ROW_SPACING * 2
    '            End If
    '            If childRow.Band.Index = 2 Then
    '                childRow.RowSpacingAfter = ROW_SPACING
    '            End If
    '        End If
    '        childRow = childRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
    '    End While

    'End Sub



    Private Sub UltraGrid1_InitializeLogicalPrintPage(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableLogicalPrintPageEventArgs) Handles UltraGrid1.InitializeLogicalPrintPage
        LogicalPageNo = e.LogicalPageNumber()
        e.LogicalPageLayoutInfo.PageFooter = "Logical Page No.: " & LogicalPageNo & ", Page No. <#>" & Chr(9) & "Total Weight = " & WgtTotal & " lb" & ",Total Charge = $" & ChargeTotal & Chr(9) & Date.Today.ToString

        'e.DefaultLogicalPageLayoutInfo.PageFooter = "Logical Page No.: " & LogicalPageNo & Chr(9) & "Page No. <#>"
    End Sub

    Private Sub UltraGrid1_InitializePrint(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs) Handles UltraGrid1.InitializePrint
        'LogicalPageNo = 1

        'e.DefaultLogicalPageLayoutInfo.FitWidthToPages
        'e.DefaultLogicalPageLayoutInfo.PageFooter = "<#>"
    End Sub

    Private Sub UltraGrid1_InitializePrintPreview(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintPreviewEventArgs) Handles UltraGrid1.InitializePrintPreview
        LogicalPageNo = 1
        CalcTotals()

        e.DefaultLogicalPageLayoutInfo.PageFooter = "Logical Page No.: " & LogicalPageNo & ", Page No. <#>" & Chr(9) & "Total Weight = " & WgtTotal & " lb" & Chr(9) & "Total Charge = $" & ChargeTotal

        'e.PrintDocument.DefaultPageSettings.Landscape = True

        e.PrintDocument.DefaultPageSettings.Margins.Left = 35
        e.PrintDocument.DefaultPageSettings.Margins.Right = 45
        e.PrintDocument.DefaultPageSettings.Margins.Top = 50
        e.PrintDocument.DefaultPageSettings.Margins.Bottom = 50


    End Sub

    Private Sub CalcTotals()
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        WgtTotal = 0
        ChargeTotal = 0
        For Each ugrow In UltraGrid1.Rows
            If Not ugrow.ListObject Is Nothing Then
                WgtTotal += ugrow.Cells("Weight").Value
                ChargeTotal += ugrow.Cells("Charge").Value
            ElseIf ugrow.IsExpandable Then
                CalcChildTotals(ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First))
            End If
        Next
    End Sub

    Private Sub CalcChildTotals(ByVal ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow)
        While Not ugrow Is Nothing
            If Not ugrow.ListObject Is Nothing Then
                WgtTotal += ugrow.Cells("Weight").Value
                ChargeTotal += ugrow.Cells("Charge").Value
            ElseIf ugrow.IsExpandable Then
                CalcChildTotals(ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First))
            End If
            ugrow = ugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
        End While
    End Sub
    'Karina added for a condition on rbWeight
    Private Sub Value_Dec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Condition.KeyPress
        If rbWeight.Checked Then
            If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "." Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub btnExport2Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click

        Dim x As New EnterTextBox
        Dim UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid

        Select Case sender.name
            Case "btnExcel"
                UltraGrid = UltraGrid1
                WorkSheetName = "Accounts Holiday List"
                'FileName = "C :\Invoice_" & UltraGrid1.ActiveRow.Cells("Invoice_No").Value & "_Summary.XLS"
                'FileName = "C :\" & Format(Date.Today, "yyyy-MM-dd") & "TruckHistory" & ".xls"
                FileName = ".\" & Format(Date.Today, "yyyy-MM-dd") & "DailyWeightEntryListing" & ".xls"
        End Select

        On Error GoTo ErrTrap

        If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "File Name:"
        x.Label2.Text = ""
        x.Label2.Visible = False
        x.btnBrowse1.Visible = True

        x.Text = "File Name"
        x.TextBox1.Enabled = True
        x.TextBox1.Text = FileName
        x.TextBox2.Visible = False
        'x.Show()
        x.ShowDialog(Me)
        If x.DialogResult = DialogResult.OK Then
            If x.TextBox1.Text.Trim = "" Then
                MsgBox("No file name specified.")
                Exit Sub
            End If
            FileName = x.TextBox1.Text
            x.Dispose()
            x = Nothing
            'Dim wk As New Infragistics.Excel.Workbook
            'Dim ws1, ws2 As Infragistics.Excel.Worksheet

            'ws1 = wk.Worksheets.Add("Summary")
            'ws2 = wk.Worksheets.Add("Details")
            Me.Cursor = Cursors.WaitCursor

            Me.UltraGridExcelExporter1.Export(UltraGrid, FileName)

            Me.Cursor = Cursors.Default

            'Me.UltraGridExcelExporter1.Export(Me.UltraGrid1, ws1)
            'Me.UltraGridExcelExporter1.Export(Me.UltraGrid2, ws2)

            'Dim gh As GCHandle
            'gh = GCHandle.Alloc(wk)

            'Dim ptr As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(Infragistics.Excel.Workbook)) 'Marshal.SizeOf(wk)

            'Marshal.StructureToPtr(wk, ptr, True)

            'Dim Arr() As Byte 'Marshal.SizeOf(wk)
            'Arr = Marshal.PtrToStructure(ptr, New Byte().GetType)

            'Dim strm2 As New IO.StreamWriter("C :\2SheetFile.xls")
            'strm2.Write(Arr)
            'strm2.Close()
            'strm2 = Nothing


        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            'Message modified by Michael Pastor
            MsgBox("Error in btnNewGroup_Click : " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If

    End Sub
End Class
