Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class ExceptionReports
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim HidCols() As String = {"RowID"}

    Dim TemplateID As Integer
    Dim Template As String
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing



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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents uSDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents uSDate2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents uSDate3 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents uSDate4 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents uopAcct1 As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents uopAcct2 As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents rdExRep1 As System.Windows.Forms.RadioButton
    Friend WithEvents utAcctID1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utAcct1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnAcct1 As System.Windows.Forms.Button
    Friend WithEvents rdExRep2 As System.Windows.Forms.RadioButton
    Friend WithEvents utAcctID2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utAcct2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnAcct2 As System.Windows.Forms.Button
    Friend WithEvents utTRNum3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uchTRNum3 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents rdExRep3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdExRep4 As System.Windows.Forms.RadioButton
    Friend WithEvents utTRNum4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uchTRNum4 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents utScanD4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents gbExRep1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbExRep2 As System.Windows.Forms.GroupBox
    Friend WithEvents gbExRep3 As System.Windows.Forms.GroupBox
    Friend WithEvents gbExRep4 As System.Windows.Forms.GroupBox
    Friend WithEvents utScanD3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents ugPackages As Infragistics.Win.UltraWinGrid.UltraGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.ugPackages = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.gbExRep1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.utAcctID1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utAcct1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnAcct1 = New System.Windows.Forms.Button
        Me.uopAcct1 = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label11 = New System.Windows.Forms.Label
        Me.uSDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.rdExRep1 = New System.Windows.Forms.RadioButton
        Me.gbExRep2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.utAcctID2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utAcct2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnAcct2 = New System.Windows.Forms.Button
        Me.uopAcct2 = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.uSDate2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.rdExRep2 = New System.Windows.Forms.RadioButton
        Me.gbExRep3 = New System.Windows.Forms.GroupBox
        Me.utTRNum3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uchTRNum3 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.utScanD3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.uSDate3 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.rdExRep3 = New System.Windows.Forms.RadioButton
        Me.gbExRep4 = New System.Windows.Forms.GroupBox
        Me.utTRNum4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uchTRNum4 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.utScanD4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.uSDate4 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.rdExRep4 = New System.Windows.Forms.RadioButton
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        CType(Me.ugPackages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExRep1.SuspendLayout()
        CType(Me.utAcctID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAcct1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopAcct1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uSDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExRep2.SuspendLayout()
        CType(Me.utAcctID2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAcct2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopAcct2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uSDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExRep3.SuspendLayout()
        CType(Me.utTRNum3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utScanD3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uSDate3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExRep4.SuspendLayout()
        CType(Me.utTRNum4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utScanD4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uSDate4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugPackages
        '
        Me.ugPackages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugPackages.Location = New System.Drawing.Point(0, 408)
        Me.ugPackages.Name = "ugPackages"
        Me.ugPackages.Size = New System.Drawing.Size(728, 214)
        Me.ugPackages.TabIndex = 0
        Me.ugPackages.Tag = "TrackingListing"
        Me.ugPackages.Text = "Packages"
        '
        'gbExRep1
        '
        Me.gbExRep1.Controls.Add(Me.Label1)
        Me.gbExRep1.Controls.Add(Me.utAcctID1)
        Me.gbExRep1.Controls.Add(Me.utAcct1)
        Me.gbExRep1.Controls.Add(Me.btnAcct1)
        Me.gbExRep1.Controls.Add(Me.uopAcct1)
        Me.gbExRep1.Controls.Add(Me.Label11)
        Me.gbExRep1.Controls.Add(Me.uSDate1)
        Me.gbExRep1.Location = New System.Drawing.Point(8, 16)
        Me.gbExRep1.Name = "gbExRep1"
        Me.gbExRep1.Size = New System.Drawing.Size(712, 80)
        Me.gbExRep1.TabIndex = 0
        Me.gbExRep1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(496, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 169
        Me.Label1.Text = "Acct.ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utAcctID1
        '
        Me.utAcctID1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcctID1.Location = New System.Drawing.Point(544, 48)
        Me.utAcctID1.Name = "utAcctID1"
        Me.utAcctID1.Size = New System.Drawing.Size(72, 21)
        Me.utAcctID1.TabIndex = 3
        Me.utAcctID1.Tag = ""
        '
        'utAcct1
        '
        Me.utAcct1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcct1.Location = New System.Drawing.Point(272, 48)
        Me.utAcct1.Name = "utAcct1"
        Me.utAcct1.Size = New System.Drawing.Size(216, 21)
        Me.utAcct1.TabIndex = 2
        Me.utAcct1.Tag = ""
        '
        'btnAcct1
        '
        Me.btnAcct1.Location = New System.Drawing.Point(624, 48)
        Me.btnAcct1.Name = "btnAcct1"
        Me.btnAcct1.Size = New System.Drawing.Size(80, 21)
        Me.btnAcct1.TabIndex = 4
        Me.btnAcct1.Text = "Se&lect"
        '
        'uopAcct1
        '
        Appearance1.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopAcct1.Appearance = Appearance1
        Me.uopAcct1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopAcct1.ItemAppearance = Appearance2
        ValueListItem1.DataValue = "Default Item"
        ValueListItem1.DisplayText = "All Accounts"
        ValueListItem2.DataValue = "Undelivered After 3 Days"
        ValueListItem2.DisplayText = "By Account:"
        Me.uopAcct1.Items.Add(ValueListItem1)
        Me.uopAcct1.Items.Add(ValueListItem2)
        Me.uopAcct1.ItemSpacingVertical = 10
        Me.uopAcct1.Location = New System.Drawing.Point(184, 24)
        Me.uopAcct1.Name = "uopAcct1"
        Me.uopAcct1.Size = New System.Drawing.Size(88, 48)
        Me.uopAcct1.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 21)
        Me.Label11.TabIndex = 164
        Me.Label11.Text = "Ship Date:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uSDate1
        '
        Me.uSDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.uSDate1.Location = New System.Drawing.Point(72, 24)
        Me.uSDate1.Name = "uSDate1"
        Me.uSDate1.Size = New System.Drawing.Size(96, 21)
        Me.uSDate1.TabIndex = 0
        Me.uSDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'rdExRep1
        '
        Me.rdExRep1.Location = New System.Drawing.Point(16, 16)
        Me.rdExRep1.Name = "rdExRep1"
        Me.rdExRep1.Size = New System.Drawing.Size(160, 16)
        Me.rdExRep1.TabIndex = 0
        Me.rdExRep1.Text = "Not Scanned TPC Uploads"
        '
        'gbExRep2
        '
        Me.gbExRep2.Controls.Add(Me.Label2)
        Me.gbExRep2.Controls.Add(Me.utAcctID2)
        Me.gbExRep2.Controls.Add(Me.utAcct2)
        Me.gbExRep2.Controls.Add(Me.btnAcct2)
        Me.gbExRep2.Controls.Add(Me.uopAcct2)
        Me.gbExRep2.Controls.Add(Me.Label3)
        Me.gbExRep2.Controls.Add(Me.uSDate2)
        Me.gbExRep2.Location = New System.Drawing.Point(8, 104)
        Me.gbExRep2.Name = "gbExRep2"
        Me.gbExRep2.Size = New System.Drawing.Size(712, 80)
        Me.gbExRep2.TabIndex = 0
        Me.gbExRep2.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(496, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "Acct.ID:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utAcctID2
        '
        Me.utAcctID2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcctID2.Location = New System.Drawing.Point(544, 48)
        Me.utAcctID2.Name = "utAcctID2"
        Me.utAcctID2.Size = New System.Drawing.Size(72, 21)
        Me.utAcctID2.TabIndex = 3
        Me.utAcctID2.Tag = ""
        '
        'utAcct2
        '
        Me.utAcct2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcct2.Location = New System.Drawing.Point(272, 48)
        Me.utAcct2.Name = "utAcct2"
        Me.utAcct2.Size = New System.Drawing.Size(216, 21)
        Me.utAcct2.TabIndex = 2
        Me.utAcct2.Tag = ""
        '
        'btnAcct2
        '
        Me.btnAcct2.Location = New System.Drawing.Point(624, 48)
        Me.btnAcct2.Name = "btnAcct2"
        Me.btnAcct2.Size = New System.Drawing.Size(80, 21)
        Me.btnAcct2.TabIndex = 4
        Me.btnAcct2.Text = "Se&lect"
        '
        'uopAcct2
        '
        Appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopAcct2.Appearance = Appearance3
        Me.uopAcct2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopAcct2.ItemAppearance = Appearance4
        ValueListItem3.DataValue = "Default Item"
        ValueListItem3.DisplayText = "All Accounts"
        ValueListItem4.DataValue = "Undelivered After 3 Days"
        ValueListItem4.DisplayText = "By Account:"
        Me.uopAcct2.Items.Add(ValueListItem3)
        Me.uopAcct2.Items.Add(ValueListItem4)
        Me.uopAcct2.ItemSpacingVertical = 10
        Me.uopAcct2.Location = New System.Drawing.Point(184, 24)
        Me.uopAcct2.Name = "uopAcct2"
        Me.uopAcct2.Size = New System.Drawing.Size(88, 48)
        Me.uopAcct2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 21)
        Me.Label3.TabIndex = 171
        Me.Label3.Text = "Ship Date:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uSDate2
        '
        Me.uSDate2.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.uSDate2.Location = New System.Drawing.Point(72, 24)
        Me.uSDate2.Name = "uSDate2"
        Me.uSDate2.Size = New System.Drawing.Size(96, 21)
        Me.uSDate2.TabIndex = 0
        Me.uSDate2.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'rdExRep2
        '
        Me.rdExRep2.Location = New System.Drawing.Point(16, 104)
        Me.rdExRep2.Name = "rdExRep2"
        Me.rdExRep2.Size = New System.Drawing.Size(184, 16)
        Me.rdExRep2.TabIndex = 0
        Me.rdExRep2.Text = "Not Scanned 3rd Party Uploads"
        '
        'gbExRep3
        '
        Me.gbExRep3.Controls.Add(Me.utTRNum3)
        Me.gbExRep3.Controls.Add(Me.uchTRNum3)
        Me.gbExRep3.Controls.Add(Me.utScanD3)
        Me.gbExRep3.Controls.Add(Me.Label5)
        Me.gbExRep3.Controls.Add(Me.Label4)
        Me.gbExRep3.Controls.Add(Me.uSDate3)
        Me.gbExRep3.Location = New System.Drawing.Point(8, 192)
        Me.gbExRep3.Name = "gbExRep3"
        Me.gbExRep3.Size = New System.Drawing.Size(712, 88)
        Me.gbExRep3.TabIndex = 0
        Me.gbExRep3.TabStop = False
        '
        'utTRNum3
        '
        Me.utTRNum3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTRNum3.Location = New System.Drawing.Point(360, 56)
        Me.utTRNum3.Name = "utTRNum3"
        Me.utTRNum3.Size = New System.Drawing.Size(216, 21)
        Me.utTRNum3.TabIndex = 3
        Me.utTRNum3.Tag = ""
        '
        'uchTRNum3
        '
        Me.uchTRNum3.Location = New System.Drawing.Point(184, 56)
        Me.uchTRNum3.Name = "uchTRNum3"
        Me.uchTRNum3.Size = New System.Drawing.Size(176, 20)
        Me.uchTRNum3.TabIndex = 2
        Me.uchTRNum3.Text = "Exclude TR #s That Start With:"
        '
        'utScanD3
        '
        Me.utScanD3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utScanD3.Location = New System.Drawing.Point(360, 24)
        Me.utScanD3.Name = "utScanD3"
        Me.utScanD3.Size = New System.Drawing.Size(72, 21)
        Me.utScanD3.TabIndex = 1
        Me.utScanD3.Tag = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(176, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 21)
        Me.Label5.TabIndex = 174
        Me.Label5.Text = "Days to Look for Before Scan Date:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 21)
        Me.Label4.TabIndex = 173
        Me.Label4.Text = "Scan Date:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uSDate3
        '
        Me.uSDate3.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.uSDate3.Location = New System.Drawing.Point(72, 24)
        Me.uSDate3.Name = "uSDate3"
        Me.uSDate3.Size = New System.Drawing.Size(96, 21)
        Me.uSDate3.TabIndex = 0
        Me.uSDate3.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'rdExRep3
        '
        Me.rdExRep3.Location = New System.Drawing.Point(16, 192)
        Me.rdExRep3.Name = "rdExRep3"
        Me.rdExRep3.Size = New System.Drawing.Size(192, 16)
        Me.rdExRep3.TabIndex = 0
        Me.rdExRep3.Text = "Scans Without Uploads For TPC"
        '
        'gbExRep4
        '
        Me.gbExRep4.Controls.Add(Me.utTRNum4)
        Me.gbExRep4.Controls.Add(Me.uchTRNum4)
        Me.gbExRep4.Controls.Add(Me.utScanD4)
        Me.gbExRep4.Controls.Add(Me.Label6)
        Me.gbExRep4.Controls.Add(Me.Label7)
        Me.gbExRep4.Controls.Add(Me.uSDate4)
        Me.gbExRep4.Location = New System.Drawing.Point(8, 288)
        Me.gbExRep4.Name = "gbExRep4"
        Me.gbExRep4.Size = New System.Drawing.Size(712, 88)
        Me.gbExRep4.TabIndex = 0
        Me.gbExRep4.TabStop = False
        '
        'utTRNum4
        '
        Me.utTRNum4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTRNum4.Location = New System.Drawing.Point(360, 56)
        Me.utTRNum4.Name = "utTRNum4"
        Me.utTRNum4.Size = New System.Drawing.Size(216, 21)
        Me.utTRNum4.TabIndex = 3
        Me.utTRNum4.Tag = ""
        '
        'uchTRNum4
        '
        Me.uchTRNum4.Location = New System.Drawing.Point(184, 56)
        Me.uchTRNum4.Name = "uchTRNum4"
        Me.uchTRNum4.Size = New System.Drawing.Size(176, 20)
        Me.uchTRNum4.TabIndex = 2
        Me.uchTRNum4.Text = "Exclude TR #s That Start With:"
        '
        'utScanD4
        '
        Me.utScanD4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utScanD4.Location = New System.Drawing.Point(360, 24)
        Me.utScanD4.Name = "utScanD4"
        Me.utScanD4.Size = New System.Drawing.Size(72, 21)
        Me.utScanD4.TabIndex = 1
        Me.utScanD4.Tag = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(176, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(184, 21)
        Me.Label6.TabIndex = 181
        Me.Label6.Text = "Days to Look for Before Scan Date:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 21)
        Me.Label7.TabIndex = 180
        Me.Label7.Text = "Scan Date:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uSDate4
        '
        Me.uSDate4.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.uSDate4.Location = New System.Drawing.Point(72, 22)
        Me.uSDate4.Name = "uSDate4"
        Me.uSDate4.Size = New System.Drawing.Size(96, 21)
        Me.uSDate4.TabIndex = 0
        Me.uSDate4.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'rdExRep4
        '
        Me.rdExRep4.Location = New System.Drawing.Point(16, 288)
        Me.rdExRep4.Name = "rdExRep4"
        Me.rdExRep4.Size = New System.Drawing.Size(216, 16)
        Me.rdExRep4.TabIndex = 0
        Me.rdExRep4.Text = "Scans Without Uploads For 3rd Party"
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(432, 384)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(88, 21)
        Me.btnExcel.TabIndex = 4
        Me.btnExcel.Text = "Export to E&xcel"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(528, 384)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 21)
        Me.btnPrint.TabIndex = 5
        Me.btnPrint.Text = "&Print"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(624, 384)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 6
        Me.btnDisplay.Text = "D&isplay"
        '
        'UltraGridExcelExporter1
        '
        Me.UltraGridExcelExporter1.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.ThrowException
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(728, 408)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
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
        'ExceptionReports
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(728, 622)
        Me.Controls.Add(Me.rdExRep1)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDisplay)
        Me.Controls.Add(Me.ugPackages)
        Me.Controls.Add(Me.gbExRep1)
        Me.Controls.Add(Me.rdExRep2)
        Me.Controls.Add(Me.gbExRep2)
        Me.Controls.Add(Me.rdExRep3)
        Me.Controls.Add(Me.gbExRep3)
        Me.Controls.Add(Me.rdExRep4)
        Me.Controls.Add(Me.gbExRep4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Menu = Me.MainMenu1
        Me.Name = "ExceptionReports"
        Me.Tag = "ExceptionReports"
        Me.Text = "Exception Reports"
        CType(Me.ugPackages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExRep1.ResumeLayout(False)
        CType(Me.utAcctID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAcct1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopAcct1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uSDate1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExRep2.ResumeLayout(False)
        CType(Me.utAcctID2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAcct2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopAcct2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uSDate2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExRep3.ResumeLayout(False)
        CType(Me.utTRNum3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utScanD3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uSDate3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExRep4.ResumeLayout(False)
        CType(Me.utTRNum4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utScanD4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uSDate4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ExceptionReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        uSDate1.Nullable = True
        uSDate1.Value = DateAdd(DateInterval.Day, -1, Date.Today)
        uSDate1.FormatString = "MM/dd/yyyy"

        uSDate2.Nullable = True
        uSDate2.Value = DateAdd(DateInterval.Day, -1, Date.Today)
        uSDate2.FormatString = "MM/dd/yyyy"

        uSDate3.Nullable = True
        uSDate3.Value = Date.Today
        uSDate3.FormatString = "MM/dd/yyyy"

        uSDate4.Nullable = True
        uSDate4.Value = Date.Today
        uSDate4.FormatString = "MM/dd/yyyy"

        utTRNum3.MaxLength = 30
        utTRNum3.Enabled = False
        uchTRNum3.Checked = False

        utTRNum4.MaxLength = 30
        utTRNum4.Enabled = False
        uchTRNum4.Checked = False

        rdExRep1.Checked = True
        utAcct1.Select()


        utScanD3.Text = "1"
        utScanD4.Text = "1"

    End Sub

    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        Dim i, k As Integer
        Dim AcctCond, SqlSelect1, SqlSelect2, SqlSelect3, SqlSelect4, SqlSelect, ScanDateRng, DateRngCond, TRNumCond, TRNumCondEvent, ExclTRNum, VOID As String
        Dim ExclusionItems() As String


        'All Not Scanned Parcels Shiped On '...' From Any Customer
        'TPC Barcodes
        SqlSelect1 = " Select dz.BranchID, m.* " & _
                    " from " & TRCTblPath & "Manifest m " & _
                    " left outer join " & TRCTblPath & "DestinationZipcode dz on substring(m.tozip, 1, 5) = dz.destzip " & _
                    " where m.trackingnum not in (Select e.TrackingNum from " & TRCTblPath & "Event e " & _
                    " Where(e.hhid Is Not null And e.scandate >= m.datetime And e.trackingnum = m.trackingnum)) " & _
                    " @ACCTCOND @DATERNG @TRNUM @VOID Order By dz.BranchID"

        'All Not Scanned Parcels Shiped On '...' From Any Customer
        'ThirdPartyBarcodes
        SqlSelect2 = " Select dz.BranchID, m.* " & _
                    " from " & TRCTblPath & "Manifest m " & _
                    " left outer join " & TRCTblPath & "DestinationZipcode dz on substring(m.tozip, 1, 5) = dz.destzip " & _
                    " where m.trackingnum not in (Select e.ThirdpartyBarcode from " & TRCTblPath & "Event e " & _
                    " Where e.hhid is not null and e.scandate >= m.datetime and e.thirdpartybarcode = m.trackingnum) " & _
                    " @ACCTCOND @DATERNG @TRNUM @VOID Order By dz.BranchID"

        'Scans Of Branches That have no Manifest in the system for a Scan Date
        'TPC Barcodes
        SqlSelect3 = " Select * from " & TRCTblPath & "Event e " & _
                    " Where e.eventcode <> 'L' " & _
                    " @SCANDATERNG @ETRNUM @XTRNUM" & _
                    " AND e.trackingnum not in(Select Trackingnum from " & TRCTblPath & "Manifest m " & _
                    " Where @DATERNG @TRNUM @VOID union " & _
                    " Select cl.TrackingNum from " & TRCTblPath & "CourierLabels cl " & _
                    " where cl.void = 'F')"

        'Scans Of Branches That have no Manifest in the system for a Scan Date
        'Non-TPC Barcodes (ThirdPartyBarcodes)
        SqlSelect4 = " Select * from " & TRCTblPath & "Event e " & _
                    " Where e.eventcode <> 'L'  @SCANDATERNG @XTRNUM AND rtrim(e.ThirdPartyBarcode) <> '' " & _
                    " AND ThirdPartyBarcode is not NULL and e.ThirdPartyBarcode not in( " & _
                    " Select Trackingnum from " & TRCTblPath & "Manifest m Where @DATERNG @TRNUM @VOID)"

        If rdExRep1.Checked = True Then
            SqlSelect = SqlSelect1
            If uSDate1.Value Is Nothing Then
                MsgBox("ShipDate in not set.")
                Exit Sub
            End If
        ElseIf rdExRep2.Checked = True Then
            SqlSelect = SqlSelect2
            If uSDate2.Value Is Nothing Then
                MsgBox("ShipDate is not set.")
                Exit Sub
            End If
        ElseIf rdExRep3.Checked = True Then
            SqlSelect = SqlSelect3
            If uSDate3.Value Is Nothing Then
                MsgBox("ScanDate is not set.")
                Exit Sub
            End If
        ElseIf rdExRep4.Checked = True Then
            SqlSelect = SqlSelect4
            If uSDate4.Value Is Nothing Then
                MsgBox("ScanDate is not set.")
                Exit Sub
            End If
        End If

        'DateRngCond = " AND m.datetime >= '" & uSDate1.Text & "' AND  m.datetime < dateadd(d, 1,'" & uSDate1.Text & "')"

        If rdExRep1.Checked = True Then
            DateRngCond = " AND m.datetime >= '" & uSDate1.Text & "' AND  m.datetime < dateadd(d, 1,'" & uSDate1.Text & "')"
            TRNumCond = " AND m.TrackingNum like 'TPC%'"
            ExclTRNum = ""
            ScanDateRng = ""
            TRNumCondEvent = ""
            Select Case uopAcct1.CheckedIndex
                Case 0 'All Accounts
                    AcctCond = ""
                Case 1 'By Account
                    If utAcctID1.Text.Trim = "" Then
                        MsgBox("Account not selected.")
                        Exit Sub
                    End If
                    AcctCond = " AND m.FromCustID = '" & utAcctID1.Text.Trim & "'"
                Case Else
                    MsgBox("No ACCOUNT option selected.")
                    Exit Sub
            End Select
        ElseIf rdExRep2.Checked = True Then
            DateRngCond = " AND m.datetime >= '" & uSDate2.Text & "' AND  m.datetime < dateadd(d, 1,'" & uSDate2.Text & "')"
            TRNumCond = " AND m.TrackingNum not like 'TPC%'"
            ExclTRNum = ""
            ScanDateRng = ""
            TRNumCondEvent = ""
            Select Case uopAcct2.CheckedIndex
                Case 0 'All Accounts
                    AcctCond = ""
                Case 1 'By Account
                    If utAcctID2.Text.Trim = "" Then
                        MsgBox("Account not selected.")
                        Exit Sub
                    End If
                    AcctCond = " AND m.FromCustID = '" & utAcctID2.Text.Trim & "'"
                Case Else
                    MsgBox("No ACCOUNT option selected.")
                    Exit Sub
            End Select
        ElseIf rdExRep3.Checked = True Then
            'Karina Check

            AcctCond = ""
            DateRngCond = "m.datetime >= dateadd(d, " & CStr(0 - utScanD3.Text) & ", '" & uSDate3.Text & "') AND m.datetime < dateadd(d, 1, '" & uSDate3.Text & "')"
            TRNumCond = " AND m.TrackingNum like 'TPC%'"
            ScanDateRng = " AND e.scandate >= '" & uSDate3.Text & "' AND e.scandate < dateadd(d, 1, '" & uSDate3.Text & "')"
            TRNumCondEvent = " AND e.TrackingNum like 'TPC%'"
            If uchTRNum3.Checked Then
                ExclusionItems = utTRNum3.Text.Split(",")
                For k = 0 To ExclusionItems.Length - 1
                    ExclusionItems(k) = ExclusionItems(k).Trim
                Next

                While (k > 0)
                    k = k - 1
                    RTrim(ExclusionItems(k))
                    LTrim(ExclusionItems(k))
                    ExclTRNum = ExclTRNum & " AND e.TrackingNum not like '" & ExclusionItems(k).Trim & "%'"
                End While
            Else
                ExclTRNum = ""
            End If
        ElseIf rdExRep4.Checked = True Then
            AcctCond = ""
            DateRngCond = "m.datetime >= dateadd(d, " & CStr(0 - utScanD4.Text) & ", '" & uSDate4.Text & "') AND m.datetime < dateadd(d, 1, '" & uSDate4.Text & "')"
            TRNumCond = " AND m.TrackingNum not like 'TPC%'"
            ScanDateRng = " AND e.scandate >= '" & uSDate4.Text & "' AND e.scandate < dateadd(d, 1, '" & uSDate4.Text & "')"
            TRNumCondEvent = ""
            If uchTRNum4.Checked Then
                ExclusionItems = utTRNum4.Text.Split(",")
                For k = 0 To ExclusionItems.Length - 1
                    ExclusionItems(k) = ExclusionItems(k).Trim
                Next

                While (k > 0)
                    k = k - 1
                    RTrim(ExclusionItems(k))
                    LTrim(ExclusionItems(k))
                    ExclTRNum = ExclTRNum & " AND e.ThirdPartyBarcode not like '" & ExclusionItems(k).Trim & "%'"
                End While
            Else
                ExclTRNum = ""
            End If
        End If
        VOID = " AND m.VOID != 'T'"

        SqlSelect = SqlSelect.Replace("@ACCTCOND", AcctCond)
        SqlSelect = SqlSelect.Replace("@DATERNG", DateRngCond)
        SqlSelect = SqlSelect.Replace("@TRNUM", TRNumCond)
        SqlSelect = SqlSelect.Replace("@XTRNUM", ExclTRNum)
        SqlSelect = SqlSelect.Replace("@SCANDATERNG", ScanDateRng)
        SqlSelect = SqlSelect.Replace("@ETRNUM", TRNumCondEvent)
        SqlSelect = SqlSelect.Replace("@VOID", VOID)
        PopulateDataset2(dtAdapter, dtSet, SqlSelect)

        'Display on UltraGrid
        PopulateDataset2(dtAdapter, dtSet, SqlSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next

        FillUltraGrid(ugPackages, dtSet, -1, HidCols, 0)
        ugPackages.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        ugPackages.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        ugPackages.DisplayLayout.AutoFitColumns = False
        For i = 0 To ugPackages.DisplayLayout.Bands(0).Columns.Count - 1
            ugPackages.DisplayLayout.Bands(0).Columns(i).TabStop = True
            ugPackages.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        ugPackages.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        ugPackages.DisplayLayout.Bands(0).Summaries.Add("TrackingNum", Infragistics.Win.UltraWinGrid.SummaryType.Count, ugPackages.DisplayLayout.Bands(0).Columns("TrackingNum"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        ugPackages.DisplayLayout.Bands(0).Summaries("TrackingNum").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        ugPackages.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        ugPackages.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        ugPackages.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        ugPackages.DisplayLayout.GroupByBox.Hidden = False
        ugPackages.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        ugPackages.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
    End Sub


    Private Sub rdExRep1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdExRep1.CheckedChanged, rdExRep2.CheckedChanged, rdExRep3.CheckedChanged, rdExRep4.CheckedChanged
        Select Case sender.name
            Case "rdExRep1"
                gbExRep1.Enabled = True
                gbExRep2.Enabled = False
                gbExRep3.Enabled = False
                gbExRep4.Enabled = False
                uopAcct1.CheckedIndex = 1
                utAcct1.Focus()
                'rdExRep2.Enabled = True

                utScanD3.Text = "1"
                uchTRNum3.Checked = False
                utTRNum3.Text = ""

                utScanD4.Text = "1"
                uchTRNum4.Checked = False
                utTRNum4.Text = ""

                utAcct2.Text = ""
                utAcctID2.Text = ""
            Case "rdExRep2"
                gbExRep1.Enabled = False
                gbExRep2.Enabled = True
                gbExRep3.Enabled = False
                gbExRep4.Enabled = False
                uopAcct2.CheckedIndex = 1
                utAcct2.Focus()

                utScanD3.Text = "1"
                uchTRNum3.Checked = False
                utTRNum3.Text = ""

                utScanD4.Text = "1"
                uchTRNum4.Checked = False
                utTRNum4.Text = ""

                utAcct1.Text = ""
                utAcctID1.Text = ""
            Case "rdExRep3"
                gbExRep1.Enabled = False
                gbExRep2.Enabled = False
                gbExRep3.Enabled = True
                gbExRep4.Enabled = False
                utScanD3.Focus()

                utScanD4.Text = "1"
                uchTRNum4.Checked = False
                utTRNum4.Text = ""

                utAcct1.Text = ""
                utAcctID1.Text = ""

                utAcct2.Text = ""
                utAcctID2.Text = ""
            Case "rdExRep4"
                gbExRep1.Enabled = False
                gbExRep2.Enabled = False
                gbExRep3.Enabled = False
                gbExRep4.Enabled = True
                utScanD4.Focus()

                utScanD3.Text = "1"
                uchTRNum3.Checked = False
                utTRNum3.Text = ""

                utAcct1.Text = ""
                utAcctID1.Text = ""

                utAcct2.Text = ""
                utAcctID2.Text = ""
            Case Else
                MsgBox("Unknown RadioButton.")
                Exit Sub
        End Select

    End Sub

    Private Sub uopAcct1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopAcct1.ValueChanged, uopAcct2.ValueChanged
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim gAcctBtn As System.Windows.Forms.Button

        Select Case sender.Name
            Case "uopAcct1"
                gAcct = utAcct1
                gAcctID = utAcctID1
                gAcctBtn = btnAcct1
            Case "uopAcct2"
                gAcct = utAcct2
                gAcctID = utAcctID2
                gAcctBtn = btnAcct2
        End Select

        Select Case sender.CheckedIndex
            Case 0 'All Accounts
                gAcct.Text = ""
                gAcctID.Text = ""
                gAcct.Enabled = False
                gAcctID.Enabled = False
                gAcctBtn.Enabled = False

            Case 1 'By Account
                gAcct.Text = ""
                gAcctID.Text = ""
                gAcct.Enabled = True
                gAcctID.Enabled = True
                gAcctBtn.Enabled = True
        End Select
    End Sub

    Private Sub utAcctID1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcctID1.Leave, utAcctID2.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utAcctID1"
                gAcct = utAcct1
                gAcctID = utAcctID1
            Case "utAcctID2"
                gAcct = utAcct2
                gAcctID = utAcctID2
        End Select

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gAcct.Text = ""
            sender.text = ""
        Else
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
                gAcctID.Text = ""
                gAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False
    End Sub

    Private Sub utAcct1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcct1.Leave, utAcct2.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utAcct1"
                gAcct = utAcct1
                gAcctID = utAcctID1
            Case "utAcct2"
                gAcct = utAcct2
                gAcctID = utAcctID2
        End Select

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gAcctID.Text = ""
            sender.text = ""
        Else
            If SearchOnLeave(sender, gAcctID, "" & TRCTblPath & "Customer", "CustomerID", "Name", "*", "Accounts", " Where Active = 'Y'") Then
            Else
                gAcctID.Text = ""
                gAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False
    End Sub

    Private Sub utAcct1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utAcct1.KeyUp, utAcct2.KeyUp
        TypeAhead(sender, e, "" & TRCTblPath & "Customer", "Name", " Where Active = 'Y'")
    End Sub

    Private Sub btnAcct1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcct1.Click, btnAcct2.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "btnAcct1"
                gAcct = utAcct1
                gAcctID = utAcctID1
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
                    gAcct.Text = ugRow.Cells("Name").Text
                    gAcctID.Text = ugRow.Cells("CustomerID").Text
                    Srch = Nothing
                    gAcct.Modified = False
                    gAcctID.Modified = False

                End If
            End Try
        End If
    End Sub

    Private Sub uchTRNum3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchTRNum3.CheckedChanged, uchTRNum4.CheckedChanged
        Dim gTRNum As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "uchTRNum3"
                gTRNum = utTRNum3
            Case "uchTRNum4"
                gTRNum = utTRNum4
        End Select

        gTRNum.Text = ""
        gTRNum.Enabled = sender.Checked
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        LoadData()
    End Sub

    Private Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles utAcctID1.KeyPress, utAcctID2.KeyPress, utScanD4.KeyPress, utScanD3.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "," Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        ugPackages.PrintPreview(Infragistics.Win.UltraWinGrid.RowPropertyCategories.All)

    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim x As New EnterTextBox
        Dim FileName As String

        On Error GoTo ErrTrap

        If ugPackages.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "File Name:"
        x.Label2.Text = ""
        x.Label2.Visible = False
        x.btnBrowse1.Visible = True

        x.Text = "File Name"
        x.TextBox1.Enabled = True
        'x.TextBox1.Text = "c :\ExceptionReports.xls"
        x.TextBox1.Text = ".\ExceptionReports.xls"
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
            Me.UltraGridExcelExporter1.Export(Me.ugPackages, FileName)
        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If
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
                    If Not ugPackages.DataSource Is Nothing Then
                        UGLoadListingLayout(ugPackages, TemplateID)
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
        UGSaveListingLayout(Me, ugPackages, TemplateID, Template)
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
            Srch.Text = "Exception Reports Templates"
            Srch.ShowDialog()
            'If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Srch = Nothing
        End If

    End Sub

    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugPackages.MouseDown
        On Error GoTo ErrLabel

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement
            Dim oUIElement As Infragistics.Win.UIElement
            Dim oUIElementTmp As Infragistics.Win.UIElement
            Dim point As Point = New Point(e.X, e.Y)


            oUIElement = Me.ugPackages.DisplayLayout.UIElement.ElementFromPoint(point)
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
                For Each ugcol In ugPackages.DisplayLayout.Bands(0).Columns
                    If ugcol.Hidden = True Then
                        CntMenu1.MenuItems(1).MenuItems.Add(ugcol.ToString, New EventHandler(AddressOf SubMnuUnHide_Click))
                    End If
                Next

                CntMenu1.Show(ugPackages, point)
            Else 'Caption Click
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("AutoFit", New EventHandler(AddressOf mnuAutoFit_Click))
                CntMenu1.MenuItems(0).Checked = ugPackages.DisplayLayout.AutoFitColumns
                CntMenu1.Show(ugPackages, point)

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
        ugPackages.DisplayLayout.AutoFitColumns = CntMenu1.MenuItems(0).Checked

    End Sub

    Private Sub mnuHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuHide.Click
        If Not m_oColumn Is Nothing Then
            m_oColumn.Hidden = True
        End If
    End Sub
    Private Sub SubMnuUnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ugCol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        For Each ugCol In ugPackages.DisplayLayout.Bands(0).Columns
            If ugCol.ToString = sender.text Then
                ugCol.Hidden = False
            End If
        Next

    End Sub

    Private Sub mnuSortAsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortAsc.Click
        ugPackages.DisplayLayout.Bands(0).SortedColumns.Add(m_oColumn, False)
    End Sub

    Private Sub mnuSortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortDesc.Click
        ugPackages.DisplayLayout.Bands(0).SortedColumns.Add(Me.m_oColumn, True)
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

        Me.m_searchForm.ShowMe(Me, Me.m_oColumn.Key, ugPackages, m_searchInfo)

    End Sub

End Class
