Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class Listing1
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim dtSet As New DataSet
    'Dim cmdTrans As SqlCommand
    Dim HidCols() As String = {"RowID"}
    'Dim DataModified As Boolean
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

    Dim TemplateID As Integer
    Dim Template As String

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
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents utAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utAcct As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UltraDate2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents uchFromLoc As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uchToLoc As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents utToAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents uchTRNum As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uch3rdP As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents utFromLocID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utFromLoc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utPointLocID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utPoint As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utToLocID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utToLoc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utFromAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utTRNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ut3rdP As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnToLoc As System.Windows.Forms.Button
    Friend WithEvents btnFromLoc As System.Windows.Forms.Button
    Friend WithEvents btnPoint As System.Windows.Forms.Button
    Friend WithEvents btnAcct As System.Windows.Forms.Button
    Friend WithEvents utPAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uopAcct As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents uchCons As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents uchWidenRows As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents ucboEvent As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents uchEvent As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uchIncAdd3 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uopExcept As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents grpExcept As System.Windows.Forms.GroupBox
    Friend WithEvents uopTRNUM As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents utAcctID2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utAcct2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnAcct2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.utAcctID2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utAcct2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnAcct2 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.uchEvent = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.grpExcept = New System.Windows.Forms.GroupBox
        Me.uopTRNUM = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.uopExcept = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.ucboEvent = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.uchToLoc = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.uchFromLoc = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.utFromLoc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uchIncAdd3 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.uchWidenRows = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.uchCons = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.ut3rdP = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uch3rdP = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.utTRNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uchTRNum = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.utToAddrID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.utToLocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utToLoc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnToLoc = New System.Windows.Forms.Button
        Me.utFromAddrID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.utFromLocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnFromLoc = New System.Windows.Forms.Button
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.utPAddrID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.utPointLocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utPoint = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnPoint = New System.Windows.Forms.Button
        Me.UltraDate2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.utAcctID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utAcct = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnAcct = New System.Windows.Forms.Button
        Me.uopAcct = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.GroupBox1.SuspendLayout()
        CType(Me.utAcctID2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAcct2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.grpExcept.SuspendLayout()
        CType(Me.uopTRNUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopExcept, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFromLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ut3rdP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTRNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToAddrID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToLocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFromAddrID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFromLocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utPAddrID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utPointLocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAcct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopAcct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.utAcctID2)
        Me.GroupBox1.Controls.Add(Me.utAcct2)
        Me.GroupBox1.Controls.Add(Me.btnAcct2)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Controls.Add(Me.utPAddrID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.utPointLocID)
        Me.GroupBox1.Controls.Add(Me.utPoint)
        Me.GroupBox1.Controls.Add(Me.btnPoint)
        Me.GroupBox1.Controls.Add(Me.UltraDate2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.UltraDate1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.utAcctID)
        Me.GroupBox1.Controls.Add(Me.utAcct)
        Me.GroupBox1.Controls.Add(Me.btnAcct)
        Me.GroupBox1.Controls.Add(Me.uopAcct)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(783, 328)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(448, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 23)
        Me.Label6.TabIndex = 169
        Me.Label6.Text = "Acct.ID:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utAcctID2
        '
        Me.utAcctID2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcctID2.Location = New System.Drawing.Point(509, 112)
        Me.utAcctID2.Name = "utAcctID2"
        Me.utAcctID2.Size = New System.Drawing.Size(72, 21)
        Me.utAcctID2.TabIndex = 167
        Me.utAcctID2.Tag = ""
        '
        'utAcct2
        '
        Me.utAcct2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcct2.Location = New System.Drawing.Point(227, 112)
        Me.utAcct2.Name = "utAcct2"
        Me.utAcct2.Size = New System.Drawing.Size(216, 21)
        Me.utAcct2.TabIndex = 166
        Me.utAcct2.Tag = ""
        '
        'btnAcct2
        '
        Me.btnAcct2.Location = New System.Drawing.Point(587, 112)
        Me.btnAcct2.Name = "btnAcct2"
        Me.btnAcct2.Size = New System.Drawing.Size(80, 21)
        Me.btnAcct2.TabIndex = 168
        Me.btnAcct2.Text = "Se&lect"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.uchEvent)
        Me.GroupBox2.Controls.Add(Me.grpExcept)
        Me.GroupBox2.Controls.Add(Me.uchToLoc)
        Me.GroupBox2.Controls.Add(Me.uchFromLoc)
        Me.GroupBox2.Controls.Add(Me.utFromLoc)
        Me.GroupBox2.Controls.Add(Me.uchIncAdd3)
        Me.GroupBox2.Controls.Add(Me.uchWidenRows)
        Me.GroupBox2.Controls.Add(Me.uchCons)
        Me.GroupBox2.Controls.Add(Me.ut3rdP)
        Me.GroupBox2.Controls.Add(Me.uch3rdP)
        Me.GroupBox2.Controls.Add(Me.utTRNum)
        Me.GroupBox2.Controls.Add(Me.uchTRNum)
        Me.GroupBox2.Controls.Add(Me.utToAddrID)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.utToLocID)
        Me.GroupBox2.Controls.Add(Me.utToLoc)
        Me.GroupBox2.Controls.Add(Me.btnToLoc)
        Me.GroupBox2.Controls.Add(Me.utFromAddrID)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.utFromLocID)
        Me.GroupBox2.Controls.Add(Me.btnFromLoc)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(768, 192)
        Me.GroupBox2.TabIndex = 165
        Me.GroupBox2.TabStop = False
        '
        'uchEvent
        '
        Me.uchEvent.Location = New System.Drawing.Point(8, 88)
        Me.uchEvent.Name = "uchEvent"
        Me.uchEvent.TabIndex = 161
        Me.uchEvent.Text = "Exception List"
        '
        'grpExcept
        '
        Me.grpExcept.Controls.Add(Me.uopTRNUM)
        Me.grpExcept.Controls.Add(Me.uopExcept)
        Me.grpExcept.Controls.Add(Me.ucboEvent)
        Me.grpExcept.Location = New System.Drawing.Point(8, 96)
        Me.grpExcept.Name = "grpExcept"
        Me.grpExcept.Size = New System.Drawing.Size(296, 85)
        Me.grpExcept.TabIndex = 164
        Me.grpExcept.TabStop = False
        '
        'uopTRNUM
        '
        Appearance1.TextHAlign = Infragistics.Win.HAlign.Center
        Appearance1.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Appearance1.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.uopTRNUM.Appearance = Appearance1
        Me.uopTRNUM.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopTRNUM.ItemAppearance = Appearance2
        ValueListItem1.DataValue = "Tracking #"
        ValueListItem1.DisplayText = "Tracking #"
        ValueListItem1.Tag = "TrackingNum"
        ValueListItem2.DataValue = "3rd Party TR#"
        ValueListItem2.DisplayText = "3rd Party TR#"
        ValueListItem2.Tag = "ThirdPartyBarcode"
        Me.uopTRNUM.Items.Add(ValueListItem1)
        Me.uopTRNUM.Items.Add(ValueListItem2)
        Me.uopTRNUM.ItemSpacingVertical = 20
        Me.uopTRNUM.Location = New System.Drawing.Point(125, 43)
        Me.uopTRNUM.Name = "uopTRNUM"
        Me.uopTRNUM.Size = New System.Drawing.Size(168, 24)
        Me.uopTRNUM.TabIndex = 164
        '
        'uopExcept
        '
        Appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopExcept.Appearance = Appearance3
        Me.uopExcept.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopExcept.ItemAppearance = Appearance4
        ValueListItem3.DataValue = "Event"
        ValueListItem3.DisplayText = "Event"
        ValueListItem4.DataValue = "Manifest Exception"
        ValueListItem4.DisplayText = "Manifest Exception"
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.None
        ValueListItem5.Appearance = Appearance5
        ValueListItem5.DataValue = "Scan Exception"
        ValueListItem5.DisplayText = "Scan Exception"
        Me.uopExcept.Items.Add(ValueListItem3)
        Me.uopExcept.Items.Add(ValueListItem4)
        Me.uopExcept.Items.Add(ValueListItem5)
        Me.uopExcept.ItemSpacingVertical = 7
        Me.uopExcept.Location = New System.Drawing.Point(8, 16)
        Me.uopExcept.Name = "uopExcept"
        Me.uopExcept.Size = New System.Drawing.Size(120, 67)
        Me.uopExcept.TabIndex = 163
        '
        'ucboEvent
        '
        Me.ucboEvent.AutoEdit = False
        Me.ucboEvent.DisplayMember = ""
        Me.ucboEvent.Location = New System.Drawing.Point(128, 14)
        Me.ucboEvent.Name = "ucboEvent"
        Me.ucboEvent.Size = New System.Drawing.Size(136, 21)
        Me.ucboEvent.TabIndex = 162
        Me.ucboEvent.Tag = ".EVENTCODE..1.EVENTCODES.EVENTCODE.NAME"
        Me.ucboEvent.ValueMember = ""
        '
        'uchToLoc
        '
        Me.uchToLoc.Location = New System.Drawing.Point(8, 40)
        Me.uchToLoc.Name = "uchToLoc"
        Me.uchToLoc.Size = New System.Drawing.Size(96, 20)
        Me.uchToLoc.TabIndex = 15
        Me.uchToLoc.Text = "To Location:"
        '
        'uchFromLoc
        '
        Me.uchFromLoc.Location = New System.Drawing.Point(8, 16)
        Me.uchFromLoc.Name = "uchFromLoc"
        Me.uchFromLoc.Size = New System.Drawing.Size(104, 20)
        Me.uchFromLoc.TabIndex = 10
        Me.uchFromLoc.Text = "From Location:"
        '
        'utFromLoc
        '
        Me.utFromLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFromLoc.Location = New System.Drawing.Point(120, 16)
        Me.utFromLoc.Name = "utFromLoc"
        Me.utFromLoc.Size = New System.Drawing.Size(216, 21)
        Me.utFromLoc.TabIndex = 11
        Me.utFromLoc.Tag = ""
        '
        'uchIncAdd3
        '
        Me.uchIncAdd3.Location = New System.Drawing.Point(629, 40)
        Me.uchIncAdd3.Name = "uchIncAdd3"
        Me.uchIncAdd3.Size = New System.Drawing.Size(112, 20)
        Me.uchIncAdd3.TabIndex = 163
        Me.uchIncAdd3.Text = "Include Address3"
        Me.uchIncAdd3.Visible = False
        '
        'uchWidenRows
        '
        Me.uchWidenRows.Location = New System.Drawing.Point(629, 16)
        Me.uchWidenRows.Name = "uchWidenRows"
        Me.uchWidenRows.Size = New System.Drawing.Size(96, 20)
        Me.uchWidenRows.TabIndex = 160
        Me.uchWidenRows.Text = "Widen Rows"
        '
        'uchCons
        '
        Me.uchCons.Enabled = False
        Me.uchCons.Location = New System.Drawing.Point(629, 66)
        Me.uchCons.Name = "uchCons"
        Me.uchCons.Size = New System.Drawing.Size(131, 20)
        Me.uchCons.TabIndex = 24
        Me.uchCons.Text = "Include Consolidation"
        '
        'ut3rdP
        '
        Me.ut3rdP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ut3rdP.Location = New System.Drawing.Point(440, 64)
        Me.ut3rdP.Name = "ut3rdP"
        Me.ut3rdP.Size = New System.Drawing.Size(182, 21)
        Me.ut3rdP.TabIndex = 23
        Me.ut3rdP.Tag = ""
        '
        'uch3rdP
        '
        Me.uch3rdP.Location = New System.Drawing.Point(337, 65)
        Me.uch3rdP.Name = "uch3rdP"
        Me.uch3rdP.Size = New System.Drawing.Size(104, 20)
        Me.uch3rdP.TabIndex = 22
        Me.uch3rdP.Text = "3rd Party Num.:"
        '
        'utTRNum
        '
        Me.utTRNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTRNum.Location = New System.Drawing.Point(120, 64)
        Me.utTRNum.Name = "utTRNum"
        Me.utTRNum.Size = New System.Drawing.Size(216, 21)
        Me.utTRNum.TabIndex = 21
        Me.utTRNum.Tag = ""
        '
        'uchTRNum
        '
        Me.uchTRNum.Location = New System.Drawing.Point(8, 64)
        Me.uchTRNum.Name = "uchTRNum"
        Me.uchTRNum.Size = New System.Drawing.Size(104, 20)
        Me.uchTRNum.TabIndex = 20
        Me.uchTRNum.Text = "Tracking Num.:"
        '
        'utToAddrID
        '
        Me.utToAddrID.Enabled = False
        Me.utToAddrID.Location = New System.Drawing.Point(568, 40)
        Me.utToAddrID.Name = "utToAddrID"
        Me.utToAddrID.Size = New System.Drawing.Size(24, 21)
        Me.utToAddrID.TabIndex = 19
        Me.utToAddrID.Tag = ""
        Me.utToAddrID.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(336, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 23)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "Loc.ID:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utToLocID
        '
        Me.utToLocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utToLocID.Enabled = False
        Me.utToLocID.Location = New System.Drawing.Point(392, 40)
        Me.utToLocID.Name = "utToLocID"
        Me.utToLocID.Size = New System.Drawing.Size(72, 21)
        Me.utToLocID.TabIndex = 17
        Me.utToLocID.Tag = ""
        '
        'utToLoc
        '
        Me.utToLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utToLoc.Location = New System.Drawing.Point(120, 40)
        Me.utToLoc.Name = "utToLoc"
        Me.utToLoc.Size = New System.Drawing.Size(216, 21)
        Me.utToLoc.TabIndex = 16
        Me.utToLoc.Tag = ""
        '
        'btnToLoc
        '
        Me.btnToLoc.Location = New System.Drawing.Point(480, 40)
        Me.btnToLoc.Name = "btnToLoc"
        Me.btnToLoc.Size = New System.Drawing.Size(80, 21)
        Me.btnToLoc.TabIndex = 18
        Me.btnToLoc.Text = "Se&lect"
        '
        'utFromAddrID
        '
        Me.utFromAddrID.Enabled = False
        Me.utFromAddrID.Location = New System.Drawing.Point(568, 16)
        Me.utFromAddrID.Name = "utFromAddrID"
        Me.utFromAddrID.Size = New System.Drawing.Size(24, 21)
        Me.utFromAddrID.TabIndex = 14
        Me.utFromAddrID.Tag = ""
        Me.utFromAddrID.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(336, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 23)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "Loc.ID:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utFromLocID
        '
        Me.utFromLocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFromLocID.Enabled = False
        Me.utFromLocID.Location = New System.Drawing.Point(392, 16)
        Me.utFromLocID.Name = "utFromLocID"
        Me.utFromLocID.Size = New System.Drawing.Size(72, 21)
        Me.utFromLocID.TabIndex = 12
        Me.utFromLocID.Tag = ""
        '
        'btnFromLoc
        '
        Me.btnFromLoc.Location = New System.Drawing.Point(480, 16)
        Me.btnFromLoc.Name = "btnFromLoc"
        Me.btnFromLoc.Size = New System.Drawing.Size(80, 21)
        Me.btnFromLoc.TabIndex = 13
        Me.btnFromLoc.Text = "Se&lect"
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(496, 16)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(88, 21)
        Me.btnExcel.TabIndex = 159
        Me.btnExcel.Text = "Export to E&xcel"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(592, 16)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 21)
        Me.btnPrint.TabIndex = 158
        Me.btnPrint.Text = "&Print"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(688, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 25
        Me.btnDisplay.Text = "D&isplay"
        '
        'utPAddrID
        '
        Me.utPAddrID.Enabled = False
        Me.utPAddrID.Location = New System.Drawing.Point(671, 90)
        Me.utPAddrID.Name = "utPAddrID"
        Me.utPAddrID.Size = New System.Drawing.Size(19, 21)
        Me.utPAddrID.TabIndex = 9
        Me.utPAddrID.Tag = ""
        Me.utPAddrID.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(456, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 23)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "Loc.ID:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utPointLocID
        '
        Me.utPointLocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utPointLocID.Enabled = False
        Me.utPointLocID.Location = New System.Drawing.Point(509, 88)
        Me.utPointLocID.Name = "utPointLocID"
        Me.utPointLocID.Size = New System.Drawing.Size(72, 21)
        Me.utPointLocID.TabIndex = 7
        Me.utPointLocID.Tag = ""
        '
        'utPoint
        '
        Me.utPoint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utPoint.Location = New System.Drawing.Point(227, 88)
        Me.utPoint.Name = "utPoint"
        Me.utPoint.Size = New System.Drawing.Size(216, 21)
        Me.utPoint.TabIndex = 6
        Me.utPoint.Tag = ""
        '
        'btnPoint
        '
        Me.btnPoint.Location = New System.Drawing.Point(587, 88)
        Me.btnPoint.Name = "btnPoint"
        Me.btnPoint.Size = New System.Drawing.Size(80, 21)
        Me.btnPoint.TabIndex = 8
        Me.btnPoint.Text = "Se&lect"
        '
        'UltraDate2
        '
        Me.UltraDate2.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate2.Location = New System.Drawing.Point(255, 14)
        Me.UltraDate2.Name = "UltraDate2"
        Me.UltraDate2.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate2.TabIndex = 1
        Me.UltraDate2.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(176, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "To Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(76, 15)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate1.TabIndex = 0
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(4, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 140
        Me.Label11.Text = "From Date:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(450, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Acct.ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utAcctID
        '
        Me.utAcctID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcctID.Location = New System.Drawing.Point(509, 64)
        Me.utAcctID.Name = "utAcctID"
        Me.utAcctID.Size = New System.Drawing.Size(72, 21)
        Me.utAcctID.TabIndex = 4
        Me.utAcctID.Tag = ""
        '
        'utAcct
        '
        Me.utAcct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcct.Location = New System.Drawing.Point(227, 64)
        Me.utAcct.Name = "utAcct"
        Me.utAcct.Size = New System.Drawing.Size(216, 21)
        Me.utAcct.TabIndex = 3
        Me.utAcct.Tag = ""
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(587, 64)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(80, 21)
        Me.btnAcct.TabIndex = 5
        Me.btnAcct.Text = "Se&lect"
        '
        'uopAcct
        '
        Appearance6.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopAcct.Appearance = Appearance6
        Me.uopAcct.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopAcct.ItemAppearance = Appearance7
        ValueListItem6.DataValue = "Default Item"
        ValueListItem6.DisplayText = "Any Account"
        ValueListItem7.DataValue = "Undelivered After 3 Days"
        ValueListItem7.DisplayText = "By Account:"
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.None
        ValueListItem8.Appearance = Appearance8
        ValueListItem8.DataValue = "ValueListItem2"
        ValueListItem8.DisplayText = "All Records of items Scanned at Point:"
        ValueListItem9.DataValue = "ValueListItem3"
        ValueListItem9.DisplayText = "Based On ShipDate 3rd-Party of Acct:"
        Me.uopAcct.Items.Add(ValueListItem6)
        Me.uopAcct.Items.Add(ValueListItem7)
        Me.uopAcct.Items.Add(ValueListItem8)
        Me.uopAcct.Items.Add(ValueListItem9)
        Me.uopAcct.ItemSpacingVertical = 7
        Me.uopAcct.Location = New System.Drawing.Point(13, 47)
        Me.uopAcct.Name = "uopAcct"
        Me.uopAcct.Size = New System.Drawing.Size(211, 81)
        Me.uopAcct.TabIndex = 2
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 328)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(783, 244)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Tag = "TrackingListing"
        Me.UltraGrid1.Text = "Packages"
        '
        'UltraGridExcelExporter1
        '
        Me.UltraGridExcelExporter1.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.ThrowException
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem4})
        Me.MenuItem1.Text = "Templates"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Load"
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
        'Listing1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(783, 572)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Menu = Me.MainMenu1
        Me.Name = "Listing1"
        Me.Tag = "TrackingListing"
        Me.Text = "Tracking Listing"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utAcctID2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAcct2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.grpExcept.ResumeLayout(False)
        CType(Me.uopTRNUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopExcept, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFromLoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ut3rdP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTRNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToAddrID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToLocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToLoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFromAddrID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFromLocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utPAddrID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utPointLocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAcct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopAcct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Listing1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        AddHandler Me.Activated, AddressOf Form_Activated

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        'AddHandler utStartMile.KeyPress, AddressOf Value_Int_KeyPress
        'AddHandler utInvoiceNo.KeyPress, AddressOf Value_Int_KeyPress
        '
        'cmdTrans = Nothing

        UltraDate1.Nullable = True
        UltraDate1.Value = DateAdd(DateInterval.Day, -1, Date.Today)
        UltraDate1.FormatString = "MM/dd/yyyy"

        UltraDate2.Nullable = True
        UltraDate2.Value = Date.Today
        UltraDate2.FormatString = "MM/dd/yyyy"

        utAcct.MaxLength = 70
        utAcct.Enabled = False
        btnAcct.Enabled = False
        utAcctID.MaxLength = 10

        utPoint.MaxLength = 70
        utPoint.Enabled = False
        btnPoint.Enabled = False
        utPointLocID.MaxLength = 10

        utFromLoc.MaxLength = 70
        utFromLoc.Enabled = False
        btnFromLoc.Enabled = False
        utFromLocID.MaxLength = 10

        utToLoc.MaxLength = 70
        utToLoc.Enabled = False
        btnToLoc.Enabled = False
        utToLocID.MaxLength = 10

        utTRNum.MaxLength = 17
        utTRNum.Enabled = False
        ut3rdP.MaxLength = 20
        ut3rdP.Enabled = False

        UltraGrid1.Text = "Packages"

        uopAcct.CheckedIndex = 1 ' By Acct

        uchFromLoc.Checked = False
        uchToLoc.Checked = False
        uchTRNum.Checked = False
        uch3rdP.Checked = False

        uchEvent.Checked = False
        grpExcept.Enabled = False
        'ucboEvent.Enabled = False

        FillUCombo(ucboEvent, "TR", "", "", TRCTblPath)
        AddHandler ucboEvent.Leave, AddressOf UCbo_Leave

    End Sub

    Private Sub utAcct_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcct.Leave, utAcct2.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utAcct"
                gAcct = utAcct
                gAcctID = utAcctID
            Case "utAcct2"
                gAcct = utAcct2
                gAcctID = utAcctID2
        End Select

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gAcctID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, gAcctID, "" & TRCTblPath & "Customer", "CustomerID", "Name", "*", "Accounts", " Where Active = 'Y'") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
            Else
                'MsgBox("Truck Not Found.")
                gAcctID.Text = ""
                gAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utAcct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utAcct.KeyUp, utAcct2.KeyUp
        TypeAhead(sender, e, "" & TRCTblPath & "Customer", "Name", " Where Active = 'Y'")
    End Sub

    Private Sub utAcctID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcctID.Leave, utAcctID2.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utAcctID"
                gAcct = utAcct
                gAcctID = utAcctID
            Case "utAcctID2"
                gAcct = utAcct2
                gAcctID = utAcctID2
        End Select

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gAcct.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, gAcctID, "" & TRCTblPath & "Customer", "CustomerID", "CustomerID", "*", "Accounts", " Where Active = 'Y'") Then
                If ReturnRowByID(gAcctID.Text, row, "" & TRCTblPath & "Customer", "", "CustomerID") Then
                    gAcct.Text = row("Name")
                    row = Nothing
                Else
                    MsgBox("Account Not Found.")
                    gAcctID.Text = ""
                    gAcct.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gAcctID.Text = ""
                gAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub btnAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcct.Click, btnAcct2.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Select Case sender.Name
            Case "btnAcct"
                gAcct = utAcct
                gAcctID = utAcctID
            Case "btnAcct2"
                gAcct = utAcct2
                gAcctID = utAcctID2
        End Select

        SelectSQL = "Select * from " & TRCTblPath & "Customer i WHERE (Active = 'Y') order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Accounts"
            Srch.Text = "Accounts"
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
                    gAcct.Text = ugRow.Cells("Name").Text
                    gAcctID.Text = ugRow.Cells("CustomerID").Text
                    Srch = Nothing
                    gAcct.Modified = False
                    gAcctID.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If

    End Sub
    '============================ POINT ======================================
    Private Sub utPoint_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utPoint.Leave, utFromLoc.Leave, utToLoc.Leave
        Dim row As DataRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "utPoint"
                gLocID = utPointLocID
                gLoc = utPoint
                gAddrID = utPAddrID
            Case "utFromLoc"
                gLocID = utFromLocID
                gLoc = utFromLoc
                gAddrID = utFromAddrID
            Case "utToLoc"
                gLocID = utToLocID
                gLoc = utToLoc
                gAddrID = utToAddrID
        End Select
        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gLocID.Text = ""
            gAddrID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If
            If SearchOnLeave(sender, gAddrID, "" & TRCTblPath & "Location", "AddressID", "Name", "*", "Locations", " Where Active = 'Y'") Then
                If ReturnRowByID(gAddrID.Text, row, "" & TRCTblPath & "Location", "", "AddressID") Then
                    gLoc.Text = row("Name")
                    gLocID.Text = row("LocationID")
                    row = Nothing
                Else
                    MsgBox("Point Not Found.")
                    gLoc.Text = ""
                    gLocID.Text = ""
                    gAddrID.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gLoc.Text = ""
                gLocID.Text = ""
                gAddrID.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utPoint_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utPoint.KeyUp
        TypeAhead(sender, e, "" & TRCTblPath & "Location", "Name", " Where Active = 'Y'")
    End Sub

    Private Sub utPointLocID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utPointLocID.Leave, utFromLocID.Leave, utToLocID.Leave
        Dim row As DataRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        If sender.Modified = False Then Exit Sub
        Select Case sender.name
            Case "utPointLocID"
                gLocID = utPointLocID
                gLoc = utPoint
                gAddrID = utPAddrID
            Case "utFromLocID"
                gLocID = utFromLocID
                gLoc = utFromLoc
                gAddrID = utFromAddrID
            Case "utToLocID"
                gLocID = utToLocID
                gLoc = utToLoc
                gAddrID = utToAddrID
        End Select

        If sender.text.trim = "" Then
            gLoc.Text = ""
            gAddrID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If
            If SearchOnLeave(sender, gAddrID, "" & TRCTblPath & "Location", "AddressID", "LocationID", "*", "Locations", " Where Active = 'Y'") Then
                If ReturnRowByID(gAddrID.Text, row, "" & TRCTblPath & "Location", "", "AddressID") Then
                    gLoc.Text = row("Name")
                    row = Nothing
                Else
                    MsgBox("Account Not Found.")
                    gLoc.Text = ""
                    gLocID.Text = ""
                    gAddrID.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gLoc.Text = ""
                gLocID.Text = ""
                gAddrID.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub btnPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPoint.Click, btnFromLoc.Click, btnToLoc.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "btnPoint"
                gLocID = utPointLocID
                gLoc = utPoint
                gAddrID = utPAddrID
            Case "btnFromLoc"
                gLocID = utFromLocID
                gLoc = utFromLoc
                gAddrID = utFromAddrID
            Case "btnToLoc"
                gLocID = utToLocID
                gLoc = utToLoc
                gAddrID = utToAddrID
        End Select

        SelectSQL = "Select * from " & TRCTblPath & "Location i WHERE (Active = 'Y') order by Name"

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

                    gLoc.Text = ugRow.Cells("Name").Text
                    gLocID.Text = ugRow.Cells("LocationID").Text
                    gAddrID.Text = ugRow.Cells("AddressID").Text

                    Srch = Nothing
                    utAcct.Modified = False
                    utAcctID.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If

    End Sub

    '============================ POINT END ==================================

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        UltraGrid1.PrintPreview(Infragistics.Win.UltraWinGrid.RowPropertyCategories.All)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim x As New EnterTextBox
        Dim FileName As String

        On Error GoTo ErrTrap

        If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "File Name:"
        x.Label2.Text = ""
        x.Label2.Visible = False
        x.btnBrowse1.Visible = True

        x.Text = "File Name"
        x.TextBox1.Enabled = True
        'x.TextBox1.Text = "c :\TrackingListing.xls"
        x.TextBox1.Text = ".\TrackingListing.xls"
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
            Me.UltraGridExcelExporter1.Export(Me.UltraGrid1, FileName)
        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If

    End Sub
    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        LoadData()
        uchWidenRows.Checked = False
    End Sub

    Enum cols
        _00CHK
        _01LocID
        _02LDate
        _03LTRNo
        _04LQty
        _05Name
        _06Adr1
        _07Adr2
        _08City
        _09State
        _10Zip
        _11Contact
        _12Phone
        _13AdrID
    End Enum
    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, DateRngCond, AcctCond, FromLocCond, ToLocCond, TRNumCond, ThirdPCond, EventCond, Address3 As String


        ' For Routesheet based on Scans:  SUBSTRING(ThirdPartyBarcode, 2 - 57 / ASCII(LEFT(ThirdPartyBarcode, 1)), LEN(ThirdPartyBarcode)) AS XThirdPartyBarcodeNum, '' as RteSheetTime, '' as RteSheetAddr,
        SQLSelect = " Select ScanDate, CONVERT(varchar, ScanDate, 108)  as ScanTime, e.Void, e.TrackingNum, e.ThirdPartyBarcode, e.EventCode, e.BatchNum, e.RefNum, e.OperatorID, emp.FirstName+' '+emp.LastName as Operator, e.PointID, ploc.Name as Point, ploc.LocationID as PLocID, e.TicketNum, e.ContainerBarcode, cont.FromCustID as Container_FromCustID, cont.FromCustName as Container_FromCustName, cont.FromLocID as Container_FromLocID, cont.FromLocName as Container_FromLocName, cont.ToCustID as Container_ToCustID, cont.ToCustName as Container_ToCustName, cont.ToLocID as Container_ToLocID, cont.ToLocName Container_ToLocName, e.DeliveryOption, dlo.Delivery, e.DeliveryComments, tloc.CustomerID as ToCustomerID, e.ToLocID, e.ToLocName, tloc.Address1 as ToAddress1, tloc.Address2 as ToAddress2, e.ToCity, tloc.State as ToState, tloc.Zip as ToZip, e.FromCustID, e.FromCustName, e.FromLocID, e.FromLocName, floc.City as FromCity, e.Weight, e.ParcelType, r.ID as Route, dbr.Name as DestBranch, @ADDR3 e.HHID, isnull(substring(e.trackingnum, 1, 4), '') as LabelPrefix, convert(varchar, scandate, 112) as DateOnly, DatePart(hh,scandate) as Hour,  e.RowID " & _
                    " from ((((((((" & _
                    "(" & TRCTblPath & "EVENT e left outer join " & TRCTblPath & "Location ploc on convert(int,substring(e.PointID, 2, 7)) = ploc.AddressID)" & _
                    " left outer join " & TRCTblPath & "Location floc on e.FromAddID = floc.AddressID) " & _
                    " left outer join " & TRCTblPath & "Location tloc on e.ToAddID = tloc.AddressID) " & _
                    " left outer join " & TRCTblPath & "DeliveryOptions dlo on e.DeliveryOption = dlo.DeliveryOption) " & _
                    " left outer join " & TRCTblPath & "EMPLOYEE emp on e.OperatorID = 'E'+replicate('0', 7-len(emp.EmployeeID))+emp.employeeid) " & _
                    " left outer join " & TRCTblPath & "CourierLabels cont on e.ContainerBarcode = cont.TrackingNum) " & _
                    " left outer join " & TRCTblPath & "ROUTES r on (tloc.CustomerID = r.CustomerID AND tloc.LocationID = r.LocationID)) " & _
                    " left outer join " & TRCTblPath & "DestinationZipcode dz on substring(tloc.Zip, 1, 5) = dz.DestZip ) " & _
                    " left outer join " & TRCTblPath & "Branch dbr on dz.BranchID = dbr.BranchID ) " & _
                    " Where  " & _
                    "   " & _
                    " @DATERNG @ACCTCOND @FRLOC @TOLOC @TRNUM @TRDP @EVENTCODE order by e.ScanDate desc, e.TrackingNum "

        'Templorary query (original above) that does not display ROUTES information. 
        'Return to the "original" query when ROUTES table fixed.
        'Locationid = 8, CustomerID = 10000 has 14 different rounts that duplicates 14 times the output of search tracking number (for example)
        'SQLSelect = " Select ScanDate, CONVERT(varchar, ScanDate, 108)  as ScanTime, e.Void, e.TrackingNum, e.ThirdPartyBarcode, e.EventCode, e.RefNum, e.OperatorID, emp.FirstName+' '+emp.LastName as Operator, e.PointID, ploc.Name as Point, ploc.LocationID as PLocID, e.TicketNum, e.ContainerBarcode, cont.FromCustID as Container_FromCustID, cont.FromCustName as Container_FromCustName, cont.FromLocID as Container_FromLocID, cont.FromLocName as Container_FromLocName, cont.ToCustID as Container_ToCustID, cont.ToCustName as Container_ToCustName, cont.ToLocID as Container_ToLocID, cont.ToLocName Container_ToLocName, e.DeliveryOption, dlo.Delivery, e.DeliveryComments, tloc.CustomerID as ToCustomerID, e.ToLocID, e.ToLocName, tloc.Address1 as ToAddress1, tloc.Address2 as ToAddress2, e.ToCity, tloc.State as ToState, tloc.Zip as ToZip, e.FromCustID, e.FromCustName, e.FromLocID, e.FromLocName, floc.City as FromCity, e.Weight, e.ParcelType, dbr.Name as DestBranch, @ADDR3 e.HHID, isnull(substring(e.trackingnum, 1, 4), '') as LabelPrefix, convert(varchar, scandate, 112) as DateOnly, DatePart(hh,scandate) as Hour,  e.RowID " & _
        '            " from (((((((" & _
        '            "(" & TRCTblPath & "EVENT e left outer join " & TRCTblPath & "Location ploc on convert(int, substring(e.PointID, 2, 7)) = ploc.AddressID)" & _
        '            " left outer join " & TRCTblPath & "Location floc on e.FromAddID = floc.AddressID) " & _
        '            " left outer join " & TRCTblPath & "Location tloc on e.ToAddID = tloc.AddressID) " & _
        '            " left outer join " & TRCTblPath & "DeliveryOptions dlo on e.DeliveryOption = dlo.DeliveryOption) " & _
        '            " left outer join " & TRCTblPath & "EMPLOYEE emp on e.OperatorID = 'E'+replicate('0', 7-len(emp.EmployeeID))+emp.employeeid) " & _
        '            " left outer join " & TRCTblPath & "CourierLabels cont on e.ContainerBarcode = cont.TrackingNum) " & _
        '            " left outer join " & TRCTblPath & "DestinationZipcode dz on substring(tloc.Zip, 1, 5) = dz.DestZip ) " & _
        '            " left outer join " & TRCTblPath & "Branch dbr on dz.BranchID = dbr.BranchID ) " & _
        '            " Where  " & _
        '            "   " & _
        '            " @DATERNG @ACCTCOND @FRLOC @TOLOC @TRNUM @TRDP @EVENTCODE order by e.ScanDate desc, e.TrackingNum "


        If UltraDate1.Value Is Nothing Then
            MsgBox("FromDate is not set.")
            Exit Sub
        End If
        If UltraDate2.Value Is Nothing Then
            MsgBox("ToDate is not set.")
            Exit Sub
        End If
        'SQLSelect = SQLSelect.Replace("@DATERNG", "AND CONVERT(datetime, CONVERT(varchar, e.ScanDate, 101)) between '" & UltraDate1.Text & "' AND dateadd(d, 1,'" & UltraDate2.Text & "')")
        DateRngCond = " e.ScanDate >= '" & UltraDate1.Text & "' AND  e.ScanDate < dateadd(d, 1,'" & UltraDate2.Text & "')"
        ' Moved to the last step
        'SQLSelect = SQLSelect.Replace("@DATERNG", DateRngCond)

        Select Case uopAcct.CheckedIndex
            Case 0 'All Accts
                AcctCond = ""
            Case 1 'By Acct
                If utAcctID.Text.Trim = "" Then
                    MsgBox("Account not selected.")
                    Exit Sub
                End If
                AcctCond = " AND e.FromCustID = '" & utAcctID.Text.Trim & "'"
            Case 2 ' By Point
                AcctCond = " AND (e.TrackingNum IN (SELECT ee.trackingnum FROM " & TRCTblPath & "event ee WHERE (ee.trackingnum IS NOT NULL AND rtrim(ee.trackingnum) <> '') AND (ee.ScanDate between '" & UltraDate1.Text & "' AND dateadd(d, 1,'" & UltraDate2.Text & "') ) AND ee.PointID = 'P" & utPAddrID.Text.Trim.PadLeft(7, "0") & "') OR e.ThirdPartyBarcode IN (SELECT ee.ThirdPartyBarcode FROM " & TRCTblPath & "event ee WHERE (ee.ThirdPartyBarcode IS NOT NULL AND rtrim(ee.ThirdPartyBarcode) <> '') AND (ee.ScanDate between '" & UltraDate1.Text & "' AND dateadd(d, 1,'" & UltraDate2.Text & "') )  AND ee.PointID = 'P" & utPAddrID.Text.Trim.PadLeft(7, "0") & "')) "
            Case 3 '3rd-Party Scans of Acct
                DateRngCond = " e.ThirdPartybarcode in (Select ThirdPartyBarcode from " & TRCTblPath & "event e2 where e2.fromcustid = '" & utAcctID2.Text.Trim & "' and e2.[Scandate] >= '" & UltraDate1.Text & "' AND e2.[Scandate] < dateadd(d, 1,'" & UltraDate1.Text & "') and e2.eventcode = 'L') "
                AcctCond = ""
        End Select
        SQLSelect = SQLSelect.Replace("@ACCTCOND", AcctCond)

        Select Case uchFromLoc.Checked
            Case True
                FromLocCond = " AND e.FromAddID = " & utFromAddrID.Text.Trim
            Case False
                FromLocCond = ""
        End Select
        SQLSelect = SQLSelect.Replace("@FRLOC", FromLocCond)

        Select Case uchToLoc.Checked
            Case True
                ToLocCond = " AND e.ToAddID = " & utToAddrID.Text.Trim
            Case False
                ToLocCond = ""
        End Select
        SQLSelect = SQLSelect.Replace("@TOLOC", ToLocCond)

        Select Case uchTRNum.Checked
            Case True
                If uchCons.Checked Then
                    SQLSelect = "EXEC TRCONS2 '" & utTRNum.Text.Trim & "', '" & UltraDate1.Text & "' , '" & UltraDate2.Text & "', 0, '" & DatePart(DateInterval.Hour, Date.Now) * 10000 + DatePart(DateInterval.Minute, Date.Now) * 100 + DatePart(DateInterval.Second, Date.Now) & "', '" & TRCTblPath & "'"
                Else
                    TRNumCond = " AND e.TrackingNum like '%" & utTRNum.Text.Trim & "%'"
                End If
            Case False
                TRNumCond = ""
        End Select
        SQLSelect = SQLSelect.Replace("@TRNUM", TRNumCond)

        Select Case uch3rdP.Checked
            Case True
                If uchCons.Checked Then
                    SQLSelect = "EXEC TRCONS3 '" & ut3rdP.Text.Trim & "', '" & UltraDate1.Text & "' , '" & UltraDate2.Text & "', 0, '" & DatePart(DateInterval.Hour, Date.Now) * 10000 + DatePart(DateInterval.Minute, Date.Now) * 100 + DatePart(DateInterval.Second, Date.Now) & "', '" & TRCTblPath & "'"
                Else
                    ThirdPCond = " AND e.ThirdPartyBarCode like '%" & ut3rdP.Text.Trim & "%' "
                End If
            Case False
                ThirdPCond = ""
        End Select
        SQLSelect = SQLSelect.Replace("@TRDP", ThirdPCond)

        Select Case uchEvent.Checked
            Case True
                Select Case uopExcept.CheckedIndex
                    Case 0 'EVENT
                        EventCond = " AND e.EventCode like '%" & ucboEvent.Value & "%' "
                        ' Ship Date is the first date only
                        DateRngCond = " e.ScanDate >= '" & UltraDate1.Text & "' AND  e.ScanDate < dateadd(d, 1,'" & UltraDate2.Text & "')"

                        'If uchCons.Checked Then
                        '    If uch3rdP.Checked = True Then
                        '        SQLSelect = "EXEC TRCONS3 '" & ut3rdP.Text.Trim & "', '" & UltraDate1.Text & "' , '" & UltraDate2.Text & "', 0, '" & DatePart(DateInterval.Hour, Date.Now) * 10000 + DatePart(DateInterval.Minute, Date.Now) * 100 + DatePart(DateInterval.Second, Date.Now) & "', " & EventCond
                        '    End If
                        'End If
                    Case 1 ' Manifest Exception
                        EventCond = " and e.eventcode = 'L' AND e." & uopTRNUM.CheckedItem.Tag & " is not null and rtrim(e." & uopTRNUM.CheckedItem.Tag & ") <> '' AND e." & uopTRNUM.CheckedItem.Tag & " not in (Select e2." & uopTRNUM.CheckedItem.Tag & " from " & TRCTblPath & "event e2 where e2.eventcode <> 'L' AND e2." & uopTRNUM.CheckedItem.Tag & " is not null and rtrim(e2." & uopTRNUM.CheckedItem.Tag & ") <> '' AND e2.ScanDate between '" & UltraDate1.Text & "' AND dateadd(d, 1,'" & UltraDate2.Text & "') ) "
                        DateRngCond = " e.ScanDate >= '" & UltraDate1.Text & "' AND  e.ScanDate < dateadd(d, 1,'" & UltraDate1.Text & "')"
                        ' Ship Date is the first date only
                    Case 2 ' Scan Exception
                        EventCond = " and e.eventcode <> 'L' AND e." & uopTRNUM.CheckedItem.Tag & " is not null and rtrim(e." & uopTRNUM.CheckedItem.Tag & ") <> '' AND e." & uopTRNUM.CheckedItem.Tag & " not in (Select e2." & uopTRNUM.CheckedItem.Tag & " from " & TRCTblPath & "event e2 where e2.eventcode = 'L'  AND e2." & uopTRNUM.CheckedItem.Tag & " is not null and rtrim(e2." & uopTRNUM.CheckedItem.Tag & ") <> '' AND " & " e2.ScanDate between dateadd(d, -15, '" & UltraDate1.Text & "') AND dateadd(d, 1,'" & UltraDate2.Text & "')" & " ) "
                        ' Ship Date is the first date only
                        DateRngCond = " e.ScanDate >= '" & UltraDate1.Text & "' AND  e.ScanDate < dateadd(d, 1,'" & UltraDate1.Text & "')"
                End Select
            Case False
                EventCond = ""
        End Select

        SQLSelect = SQLSelect.Replace("@EVENTCODE", EventCond)

        Select Case uchIncAdd3.Checked
            Case True
                Address3 = " (CASE tloc.address2 WHEN '' THEN tloc.Address1 ELSE tloc.Address1 + ', ' + tloc.Address2 END) AS Address3, "
            Case False
                Address3 = ""
        End Select
        SQLSelect = SQLSelect.Replace("@ADDR3", Address3)

        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If

        ' Moved From Top to cover any changes to date selection that each option may need
        SQLSelect = SQLSelect.Replace("@DATERNG", DateRngCond)

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid1, dtSet, -1, HidCols, 0)
        'UltraGrid1.DataSource = dtSet
        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        UltraGrid1.DisplayLayout.AutoFitColumns = False
        For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = True
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid1.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("TrackingNum", Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns("TrackingNum"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid1.DisplayLayout.Bands(0).Summaries("TrackingNum").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        'UltraGrid1.Text = "Packages"
    End Sub

    Private Sub uopAcct_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopAcct.ValueChanged
        Select Case uopAcct.CheckedIndex
            Case 0 ' All Accts
                utAcct.Text = ""
                utAcctID.Text = ""
                utAcct.Enabled = False
                utAcctID.Enabled = False
                btnAcct.Enabled = False

                utPoint.Text = ""
                utPointLocID.Text = ""
                utPAddrID.Text = ""
                utPoint.Enabled = False
                utPointLocID.Enabled = False
                btnPoint.Enabled = False

                utAcct2.Text = ""
                utAcctID2.Text = ""
                utAcct2.Enabled = False
                utAcctID2.Enabled = False
                btnAcct2.Enabled = False

                Label11.Text = "From Date:"
                Label2.Visible = True
                UltraDate2.Visible = True

                GroupBox2.Enabled = True

            Case 1 ' By Acct
                utAcct.Text = ""
                utAcctID.Text = ""
                utAcct.Enabled = True
                utAcctID.Enabled = True
                btnAcct.Enabled = True

                utPoint.Text = ""
                utPointLocID.Text = ""
                utPAddrID.Text = ""
                utPoint.Enabled = False
                utPointLocID.Enabled = False
                btnPoint.Enabled = False

                utAcct2.Text = ""
                utAcctID2.Text = ""
                utAcct2.Enabled = False
                utAcctID2.Enabled = False
                btnAcct2.Enabled = False

                Label11.Text = "From Date:"
                Label2.Visible = True
                UltraDate2.Visible = True

                GroupBox2.Enabled = True

            Case 2 'By Point
                utAcct.Text = ""
                utAcctID.Text = ""
                utAcct.Enabled = False
                utAcctID.Enabled = False
                btnAcct.Enabled = False

                utPoint.Text = ""
                utPointLocID.Text = ""
                utPAddrID.Text = ""
                utPoint.Enabled = True
                utPointLocID.Enabled = True
                btnPoint.Enabled = True

                utAcct2.Text = ""
                utAcctID2.Text = ""
                utAcct2.Enabled = False
                utAcctID2.Enabled = False
                btnAcct2.Enabled = False

                Label11.Text = "From Date:"
                Label2.Visible = True
                UltraDate2.Visible = True

                GroupBox2.Enabled = True

            Case 3 'By Acct/ShipDate/3rdParty
                utAcct.Text = ""
                utAcctID.Text = ""
                utAcct.Enabled = False
                utAcctID.Enabled = False
                btnAcct.Enabled = False

                utPoint.Text = ""
                utPointLocID.Text = ""
                utPAddrID.Text = ""
                utPoint.Enabled = False
                utPointLocID.Enabled = False
                btnPoint.Enabled = False

                utAcct2.Text = ""
                utAcctID2.Text = ""
                utAcct2.Enabled = True
                utAcctID2.Enabled = True
                btnAcct2.Enabled = True

                Label11.Text = "Ship Date:"
                Label2.Visible = False
                UltraDate2.Visible = False

                GroupBox2.Enabled = False
        End Select
    End Sub

    Private Sub uopExcept_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopExcept.ValueChanged

        Select Case uopExcept.CheckedIndex
            Case 0 ' Event
                ucboEvent.Enabled = True
                uchCons.Checked = False
                uchCons.Enabled = False '(sender.checked Xor uchTRNum.Checked)
                uopTRNUM.Enabled = False

                Label11.Text = "From Date:"
                Label2.Text = "To Date:"
            Case 1 ' Manifest Exception
                ucboEvent.Enabled = False
                uopTRNUM.Enabled = True
                uopTRNUM.CheckedIndex = 0

                Label11.Text = "Ship Date:"
                Label2.Text = "Rcv. Date:"
            Case 2 ' Scan Exception
                ucboEvent.Enabled = False
                uopTRNUM.Enabled = True
                uopTRNUM.CheckedIndex = 0

                Label11.Text = "Ship Date:"
                Label2.Text = "Rcv. Date:"
        End Select
    End Sub

    Private Sub uchFromLoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchFromLoc.CheckedChanged
        utFromLoc.Text = ""
        utFromLocID.Text = ""
        utFromAddrID.Text = ""

        utFromLoc.Enabled = sender.Checked
        utFromLocID.Enabled = sender.Checked
        btnFromLoc.Enabled = sender.Checked
    End Sub

    Private Sub uchToLoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchToLoc.CheckedChanged
        utToLoc.Text = ""
        utToLocID.Text = ""
        utToAddrID.Text = ""

        utToLoc.Enabled = sender.Checked
        utToLocID.Enabled = sender.Checked
        btnToLoc.Enabled = sender.Checked
    End Sub

    Private Sub uchTRNum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchTRNum.CheckedChanged
        utTRNum.Text = ""
        utTRNum.Enabled = sender.Checked
        uchCons.Checked = False
        uchCons.Enabled = (sender.checked Xor uch3rdP.Checked)
    End Sub

    Private Sub uch3rdP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uch3rdP.CheckedChanged
        utTRNum.Text = ""
        ut3rdP.Enabled = sender.Checked
        uchCons.Checked = False
        uchCons.Enabled = (sender.checked Xor uchTRNum.Checked)
    End Sub

    Private Sub uchEvent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchEvent.CheckedChanged
        grpExcept.Enabled = sender.Checked

        uchCons.Checked = False
        uchCons.Enabled = False '(sender.checked Xor uchTRNum.Checked)

        uopExcept.CheckedIndex = 0

    End Sub

    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown
        On Error GoTo ErrLabel

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
        Exit Sub
ErrLabel:
        MsgBox("Error : " & Err.Description)
        'Resume
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

    '=================================================================================================================
    '=================================================================================================================
    '================================             Search Routines              =======================================
    '=================================================================================================================

    Private m_searchForm As frmSearchInfo = Nothing
    Private m_searchInfo As clsSearchInfo = New clsSearchInfo

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.m_oColumn Is Nothing Then Exit Sub

        If Me.m_searchForm Is Nothing Then
            Me.m_searchForm = New frmSearchInfo
        End If

        Me.m_searchForm.ShowMe(Me, Me.m_oColumn.Key, UltraGrid1, m_searchInfo)

    End Sub



    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click ' Load Template
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select ID, Name from " & TRCTblPath & "ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Templates"
            Srch.Text = "Listing Templates"
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

                    TemplateID = ugRow.Cells("ID").Text
                    If Not UltraGrid1.DataSource Is Nothing Then
                        UGLoadListingLayout(UltraGrid1, TemplateID)
                    End If
                    Me.Text = MeText & " - Using Layout : " & ugRow.Cells("Name").Text
                    Template = ugRow.Cells("Name").Text
                End If
            End Try
            Srch = Nothing
        End If

    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Dim x As New EnterTextBox

        x.Text = "Save Template"
        x.TextBox1.Text = Template
        x.TextBox2.Visible = False
        x.Label2.Visible = False
        x.ShowDialog()
        If x.DialogResult <> DialogResult.OK Then Exit Sub
        If Template <> x.TextBox1.Text.Trim Then
            TemplateID = 0
        End If
        Template = x.TextBox1.Text.Trim
        UGSaveListingLayout(Me, UltraGrid1, TemplateID, Template)
        x = Nothing
        If TemplateID = 0 Then
            MsgBox("Failed")
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView

        SelectSQL = "Select ID, Name from " & TRCTblPath & "ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet
            Srch.sqlSelect = SelectSQL
            Srch.btnDelete.Visible = True
            Srch.Button1.Enabled = False

            Srch.UltraGrid1.Text = "Templates"
            Srch.Text = "Listing Templates"
            Srch.ShowDialog()
            'If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Srch = Nothing
        End If

    End Sub

    Private Sub uchWidenRows_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchWidenRows.CheckedChanged
        Static RowHeight As Int16 = 0
        If UltraGrid1.ActiveRow Is Nothing Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows(0)
        End If

        While UltraGrid1.ActiveRow.ListObject Is Nothing
            UltraGrid1.ActiveRow = UltraGrid1.ActiveRow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
        End While

        If uchWidenRows.Checked = True Then
            'UltraGrid1.Rows.Band.Override.RowSelectorWidth = 3 '* UltraGrid1.Rows.Band.Override.RowSelectorWidth
            RowHeight = UltraGrid1.DisplayLayout.ActiveRow.Height
            UltraGrid1.DisplayLayout.ActiveRow.Height = 3 * UltraGrid1.DisplayLayout.ActiveRow.Height
        Else
            'UltraGrid1.Rows.Band.Override.RowSelectorWidth = (1 / 3) * UltraGrid1.Rows.Band.Override.RowSelectorWidth
            'UltraGrid1.Rows.Band.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Default
            UltraGrid1.DisplayLayout.ActiveRow.Height = 0 'RowHeight
            UltraGrid1.DisplayLayout.ActiveRow.PerformAutoSize()
            UltraGrid1.DisplayLayout.ActiveRow.Refresh()
        End If
    End Sub

    Private Sub GroupBox2_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.EnabledChanged
        If sender.enabled = False Then
            Dim Ctrl As Control
            For Each Ctrl In GroupBox2.Controls
                If TypeOf Ctrl Is Infragistics.Win.UltraWinEditors.UltraCheckEditor Then
                    Dim x As Infragistics.Win.UltraWinEditors.UltraCheckEditor
                    x = Ctrl
                    x.Checked = False
                End If
            Next
        End If
    End Sub

End Class
