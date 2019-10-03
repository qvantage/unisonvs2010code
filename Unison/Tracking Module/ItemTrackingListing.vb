Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class ItemTrackingListing
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim dtSet As New DataSet
    'Dim cmdTrans As SqlCommand
    Dim HidCols() As String = {"RowID"}
    'Dim DataModified As Boolean
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

    Dim TemplateID As Integer
    Dim Template As String

    'Make Useable by Add Event Form
    Private m_bInvokedByAddEvent As Boolean = False
    Private m_sTrackingNumber As String = Nothing
    Private m_sThirdPartyBarcode As String = Nothing
    Private m_iOption As Integer = 0

    Public WriteOnly Property InvokedByAddEvent() As Boolean
        Set(ByVal Value As Boolean)
            m_bInvokedByAddEvent = Value
        End Set
    End Property

    Public ReadOnly Property TrackingNumber() As String
        Get
            Return m_sTrackingNumber
        End Get
    End Property

    Public ReadOnly Property ThirdPartyBarcode() As String
        Get
            Return m_sThirdPartyBarcode
        End Get
    End Property

    Public Property TrackingOption() As Integer
        Get
            m_iOption = uopTRNUM.CheckedIndex
            Return m_iOption
        End Get
        Set(ByVal Value As Integer)
            m_iOption = Value
            uopTRNUM.CheckedIndex = m_iOption
        End Set
    End Property

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
    Friend WithEvents UltraDate2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents utTRNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents uopTRNUM As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents utToLocID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utToLoc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnToLoc As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents utAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents rbTRNUM As System.Windows.Forms.RadioButton
    Friend WithEvents rbToLoc As System.Windows.Forms.RadioButton
    Friend WithEvents uchShipDate As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents utToAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.UltraDate2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.uopTRNUM = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.utTRNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.rbTRNUM = New System.Windows.Forms.RadioButton
        Me.rbToLoc = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.utToAddrID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uchShipDate = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.utAcctID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.utToLocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utToLoc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnToLoc = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.uopTRNUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTRNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utToAddrID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToLocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraDate2
        '
        Me.UltraDate2.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate2.Location = New System.Drawing.Point(264, 21)
        Me.UltraDate2.Name = "UltraDate2"
        Me.UltraDate2.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate2.TabIndex = 143
        Me.UltraDate2.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(192, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "To Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(88, 21)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate1.TabIndex = 142
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 144
        Me.Label11.Text = "From Date:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.uopTRNUM)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.utTRNum)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 80)
        Me.GroupBox1.TabIndex = 146
        Me.GroupBox1.TabStop = False
        '
        'uopTRNUM
        '
        Appearance1.TextHAlign = Infragistics.Win.HAlign.Center
        Appearance1.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Appearance1.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.uopTRNUM.Appearance = Appearance1
        Me.uopTRNUM.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Appearance2.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.uopTRNUM.ItemAppearance = Appearance2
        ValueListItem1.DataValue = "Tracking #"
        ValueListItem1.DisplayText = "Company TR#"
        ValueListItem1.Tag = "TrackingNum"
        ValueListItem2.DataValue = "3rd Party TR#"
        ValueListItem2.DisplayText = "3rd Party TR#"
        ValueListItem2.Tag = "ThirdPartyBarcode"
        Me.uopTRNUM.Items.Add(ValueListItem1)
        Me.uopTRNUM.Items.Add(ValueListItem2)
        Me.uopTRNUM.ItemSpacingHorizontal = 20
        Me.uopTRNUM.ItemSpacingVertical = 20
        Me.uopTRNUM.Location = New System.Drawing.Point(104, 16)
        Me.uopTRNUM.Name = "uopTRNUM"
        Me.uopTRNUM.Size = New System.Drawing.Size(208, 24)
        Me.uopTRNUM.TabIndex = 165
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 141
        Me.Label1.Text = "TR#:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utTRNum
        '
        Me.utTRNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTRNum.Location = New System.Drawing.Point(104, 46)
        Me.utTRNum.Name = "utTRNum"
        Me.utTRNum.Size = New System.Drawing.Size(216, 21)
        Me.utTRNum.TabIndex = 23
        Me.utTRNum.Tag = ""
        '
        'rbTRNUM
        '
        Me.rbTRNUM.Location = New System.Drawing.Point(24, 51)
        Me.rbTRNUM.Name = "rbTRNUM"
        Me.rbTRNUM.TabIndex = 147
        Me.rbTRNUM.Text = "Search By TR#"
        '
        'rbToLoc
        '
        Me.rbToLoc.Location = New System.Drawing.Point(24, 149)
        Me.rbToLoc.Name = "rbToLoc"
        Me.rbToLoc.Size = New System.Drawing.Size(263, 24)
        Me.rbToLoc.TabIndex = 149
        Me.rbToLoc.Text = "Search By Dest. Ship. Activity In a Period"
        Me.rbToLoc.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.utToAddrID)
        Me.GroupBox2.Controls.Add(Me.uchShipDate)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.utAcctID)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.utToLocID)
        Me.GroupBox2.Controls.Add(Me.utToLoc)
        Me.GroupBox2.Controls.Add(Me.btnToLoc)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 155)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(580, 80)
        Me.GroupBox2.TabIndex = 148
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'utToAddrID
        '
        Me.utToAddrID.Enabled = False
        Me.utToAddrID.Location = New System.Drawing.Point(280, 16)
        Me.utToAddrID.Name = "utToAddrID"
        Me.utToAddrID.Size = New System.Drawing.Size(24, 21)
        Me.utToAddrID.TabIndex = 173
        Me.utToAddrID.Tag = ""
        Me.utToAddrID.Visible = False
        '
        'uchShipDate
        '
        Me.uchShipDate.Location = New System.Drawing.Point(332, 16)
        Me.uchShipDate.Name = "uchShipDate"
        Me.uchShipDate.Size = New System.Drawing.Size(200, 20)
        Me.uchShipDate.TabIndex = 172
        Me.uchShipDate.Text = "Search For a Ship-Date Activity"
        Me.uchShipDate.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(40, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 23)
        Me.Label4.TabIndex = 171
        Me.Label4.Text = "Acct.ID:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Visible = False
        '
        'utAcctID
        '
        Me.utAcctID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcctID.Location = New System.Drawing.Point(96, 24)
        Me.utAcctID.Name = "utAcctID"
        Me.utAcctID.ReadOnly = True
        Me.utAcctID.Size = New System.Drawing.Size(72, 21)
        Me.utAcctID.TabIndex = 170
        Me.utAcctID.Tag = ""
        Me.utAcctID.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(312, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 23)
        Me.Label5.TabIndex = 169
        Me.Label5.Text = "Loc.ID:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Visible = False
        '
        'utToLocID
        '
        Me.utToLocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utToLocID.Location = New System.Drawing.Point(368, 48)
        Me.utToLocID.Name = "utToLocID"
        Me.utToLocID.Size = New System.Drawing.Size(72, 21)
        Me.utToLocID.TabIndex = 167
        Me.utToLocID.Tag = ""
        Me.utToLocID.Visible = False
        '
        'utToLoc
        '
        Me.utToLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utToLoc.Location = New System.Drawing.Point(96, 48)
        Me.utToLoc.Name = "utToLoc"
        Me.utToLoc.Size = New System.Drawing.Size(216, 21)
        Me.utToLoc.TabIndex = 166
        Me.utToLoc.Tag = ""
        Me.utToLoc.Visible = False
        '
        'btnToLoc
        '
        Me.btnToLoc.Location = New System.Drawing.Point(456, 48)
        Me.btnToLoc.Name = "btnToLoc"
        Me.btnToLoc.Size = New System.Drawing.Size(80, 21)
        Me.btnToLoc.TabIndex = 168
        Me.btnToLoc.Text = "Se&lect"
        Me.btnToLoc.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 141
        Me.Label3.Text = "To Location:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnExcel)
        Me.GroupBox3.Controls.Add(Me.btnPrint)
        Me.GroupBox3.Controls.Add(Me.btnDisplay)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.Location = New System.Drawing.Point(813, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(104, 125)
        Me.GroupBox3.TabIndex = 150
        Me.GroupBox3.TabStop = False
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(8, 80)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(88, 21)
        Me.btnExcel.TabIndex = 162
        Me.btnExcel.Text = "Export to E&xcel"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(8, 48)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 21)
        Me.btnPrint.TabIndex = 161
        Me.btnPrint.Text = "&Print"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(8, 19)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 160
        Me.btnDisplay.Text = "D&isplay"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 144)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(920, 433)
        Me.UltraGrid1.TabIndex = 151
        Me.UltraGrid1.Tag = "BasicTrackingListing"
        Me.UltraGrid1.Text = "Packages"
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
        'UltraGridExcelExporter1
        '
        Me.UltraGridExcelExporter1.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.ThrowException
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbToLoc)
        Me.GroupBox4.Controls.Add(Me.rbTRNUM)
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.UltraDate1)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.UltraDate2)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(920, 144)
        Me.GroupBox4.TabIndex = 152
        Me.GroupBox4.TabStop = False
        '
        'ItemTrackingListing
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(920, 577)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Menu = Me.MainMenu1
        Me.Name = "ItemTrackingListing"
        Me.Tag = "BasicTrackingListing"
        Me.Text = "Basic Tracking Listing"
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.uopTRNUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTRNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utToAddrID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToLocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToLoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ItemTrackingListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        UltraDate1.Value = DateAdd(DateInterval.Day, -7, Date.Today)
        UltraDate1.FormatString = "MM/dd/yyyy"

        UltraDate2.Nullable = True
        UltraDate2.Value = Date.Today
        UltraDate2.FormatString = "MM/dd/yyyy"

        'utAcct.MaxLength = 30
        'utAcct.Enabled = False
        'btnAcct.Enabled = False
        utAcctID.MaxLength = 10

        utToLoc.MaxLength = 30
        utToLoc.Enabled = True
        btnToLoc.Enabled = True
        utToLocID.MaxLength = 10

        utTRNum.MaxLength = 25
        utTRNum.Enabled = True

        UltraGrid1.Text = "Packages"

        uopTRNUM.CheckedIndex = 1 ' By Acct

        uchShipDate.Checked = False

        rbTRNUM.Checked = True

        'FillUCombo(ucboEvent, "TR")
        'AddHandler ucboEvent.Leave, AddressOf UCbo_Leave

        If m_bInvokedByAddEvent Then
            btnPrint.Enabled = False
            btnExcel.Enabled = False
            uopTRNUM.CheckedIndex = m_iOption
        End If

    End Sub

    Private Sub rbTRNUM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTRNUM.CheckedChanged, rbToLoc.CheckedChanged

        Select Case sender.name
            Case "rbTRNUM"
                GroupBox1.Enabled = True
                GroupBox2.Enabled = False
                uopTRNUM.CheckedIndex = 1
                utTRNum.Focus()

            Case "rbToLoc"
                GroupBox1.Enabled = False
                GroupBox2.Enabled = True
                utToLoc.Focus()

            Case Else
                MsgBox("Unknown RadioButton.")
                Exit Sub
        End Select

    End Sub

    Private Sub utToLocID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utToLocID.Leave
        Dim row As DataRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        On Error GoTo ErrTrap

        If sender.Modified = False Then Exit Sub
        Select Case sender.name
            Case "utToLocID"
                gLocID = utToLocID
                gLoc = utToLoc
                gAddrID = utToAddrID
        End Select

        If sender.text.trim = "" Then
            gLoc.Text = ""
            gAddrID.Text = ""
            utAcctID.Text = ""
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
                    utAcctID.Text = row("CustomerID")
                    row = Nothing
                Else
                    MsgBox("Account Not Found.")
                    gLoc.Text = ""
                    gLocID.Text = ""
                    gAddrID.Text = ""
                    utAcctID.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gLoc.Text = ""
                gLocID.Text = ""
                gAddrID.Text = ""
                utAcctID.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False
        Exit Sub
ErrTrap:
        MsgBox("Error: " & Err.Description)
    End Sub

    Private Sub utToLoc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utToLoc.Leave
        Dim row As DataRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "utToLoc"
                gLocID = utToLocID
                gLoc = utToLoc
                gAddrID = utToAddrID
                utAcctID.Text = ""
        End Select
        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gLocID.Text = ""
            gAddrID.Text = ""
            utAcctID.Text = ""
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
                    utAcctID.Text = row("CustomerID")
                    row = Nothing
                Else
                    MsgBox("Point Not Found.")
                    gLoc.Text = ""
                    gLocID.Text = ""
                    gAddrID.Text = ""
                    utAcctID.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gLoc.Text = ""
                gLocID.Text = ""
                gAddrID.Text = ""
                utAcctID.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub btnToLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToLoc.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
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
                    utAcctID.Text = ugRow.Cells("CustomerID").Text

                    Srch = Nothing
                    'utAcct.Modified = False
                    utAcctID.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If

    End Sub

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

    Private Sub uchShipDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchShipDate.CheckedChanged
        If uchShipDate.Checked = True Then
            Label11.Text = "Ship Date:"
        Else
            Label11.Text = "From Date:"
        End If
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        LoadData()
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
        SQLSelect = " Select ScanDate, CONVERT(varchar, ScanDate, 108)  as ScanTime, e.Void, e.TrackingNum, e.ThirdPartyBarcode, e.EventCode, e.OperatorID, emp.FirstName+' '+emp.LastName as Operator, e.PointID, ploc.Name as Point, ploc.LocationID as PLocID, e.TicketNum, e.ContainerBarcode, cont.FromCustID as Container_FromCustID, cont.FromCustName as Container_FromCustName, cont.FromLocID as Container_FromLocID, cont.FromLocName as Container_FromLocName, cont.ToCustID as Container_ToCustID, cont.ToCustName as Container_ToCustName, cont.ToLocID as Container_ToLocID, cont.ToLocName Container_ToLocName, e.DeliveryOption, dlo.Delivery, e.DeliveryComments, tloc.CustomerID as ToCustomerID, e.ToLocID, e.ToLocName, tloc.Address1 as ToAddress1, tloc.Address2 as ToAddress2, e.ToCity, tloc.State as ToState, tloc.Zip as ToZip, e.FromCustID, e.FromCustName, e.FromLocID, e.FromLocName, floc.City as FromCity, e.Weight, e.ParcelType, r.ID as Route, dbr.Name as DestBranch, @ADDR3 e.HHID, isnull(substring(e.trackingnum, 1, 4), '') as LabelPrefix, convert(varchar, scandate, 112) as DateOnly, DatePart(hh,scandate) as Hour,  e.RowID " & _
                    " from ((((((((" & _
                    "(" & TRCTblPath & "EVENT e left outer join " & TRCTblPath & "Location ploc on convert(int, substring(e.PointID, 2, 7)) = ploc.AddressID)" & _
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
                    " @DATERNG @TOLOC @TRNUM order by e.ScanDate desc, e.TrackingNum "
        ' Per Zak Removed :  AND isnull(e.VOID,'F') <> 'T'

        Dim SQLSelect2 As String = "Select e4.ScanDate, CONVERT(varchar, e4.ScanDate, 108)  as ScanTime, e4.Void, e4.TrackingNum, e4.ThirdPartyBarcode, e4.EventCode, e4.OperatorID, emp.FirstName+' '+emp.LastName as Operator, e4.PointID, ploc.Name as Point, ploc.LocationID as PLocID, e4.TicketNum, e4.ContainerBarcode, cont.FromCustID as Container_FromCustID, cont.FromCustName as Container_FromCustName, cont.FromLocID as Container_FromLocID, cont.FromLocName as Container_FromLocName, cont.ToCustID as Container_ToCustID, cont.ToCustName as Container_ToCustName, cont.ToLocID as Container_ToLocID, cont.ToLocName Container_ToLocName, e4.DeliveryOption, dlo.Delivery, e4.DeliveryComments, tloc.CustomerID as ToCustomerID, e4.ToLocID, e4.ToLocName, tloc.Address1 as ToAddress1, tloc.Address2 as ToAddress2, e4.ToCity, tloc.State as ToState, tloc.Zip as ToZip, e4.FromCustID, e4.FromCustName, e4.FromLocID, e4.FromLocName, floc.City as FromCity, e4.Weight, e4.ParcelType, r.ID as Route, dbr.Name as DestBranch,  e4.HHID, isnull(substring(e4.trackingnum, 1, 4), '') as LabelPrefix, convert(varchar,e4.scandate, 112) as DateOnly, DatePart(hh,e4.scandate) as Hour,  e4.RowID " & _
                        " from ((((((((((" & _
                        " Event e2 " & _
                        " inner join Event e4 on @JOINCOND) " & _
                        " left outer join [TOP].dbo.Location ploc on convert(int, substring(e4.PointID, 2, 7)) = ploc.AddressID) " & _
                        " left outer join [TOP].dbo.Location floc on e4.FromAddID = floc.AddressID) " & _
                        " left outer join [TOP].dbo.Location tloc on e4.ToAddID = tloc.AddressID)  " & _
                        " left outer join [TOP].dbo.DeliveryOptions dlo on e4.DeliveryOption = dlo.DeliveryOption)  " & _
                        " left outer join [TOP].dbo.EMPLOYEE emp on e4.OperatorID = 'E'+replicate('0', 7-len(emp.EmployeeID))+emp.employeeid)  " & _
                        " left outer join [TOP].dbo.CourierLabels cont on e4.ContainerBarcode = cont.TrackingNum)  " & _
                        " left outer join [TOP].dbo.ROUTES r on (tloc.CustomerID = r.CustomerID AND tloc.LocationID = r.LocationID))  " & _
                        " left outer join [TOP].dbo.DestinationZipcode dz on substring(tloc.Zip, 1, 5) = dz.DestZip )  " & _
                        " left outer join [TOP].dbo.Branch dbr on dz.BranchID = dbr.BranchID ) " & _
                        " where  convert(varchar, e2.[Scandate], 101) = @SHIPDATE " & _
                        " AND e2.EventCode = 'L' " & _
                        " @TRNUMTYPE " & _
                        " AND e4.ScanDate >= @SHIPDATE " & _
                        " AND e4.ScanDate < dateadd(d, 1, @TODATE) " & _
                        " AND e2.ToAddID = @TOADDID  AND isnull(e2.VOID,'F') <> 'T'"
        ' AND rtrim(e2.trackingnum) <> ''
        Dim qToLoc1, qToLoc2 As String
        qToLoc1 = ""
        qToLoc2 = ""

        If UltraDate1.Value Is Nothing Then
            MsgBox("FromDate is not set.")
            Exit Sub
        End If
        If UltraDate2.Value Is Nothing Then
            MsgBox("ToDate is not set.")
            Exit Sub
        End If
        'SQLSelect = SQLSelect.Replace("@DATERNG", "AND CONVERT(datetime, CONVERT(varchar, e.ScanDate, 101)) between '" & UltraDate1.Text & "' AND dateadd(d, 1,'" & UltraDate2.Text & "')")
        DateRngCond = " e.ScanDate between '" & UltraDate1.Text & "' AND dateadd(d, 1,'" & UltraDate2.Text & "')"
        ' Moved to the last step
        'SQLSelect = SQLSelect.Replace("@DATERNG", DateRngCond)

        ToLocCond = ""
        TRNumCond = ""
        If rbTRNUM.Checked = True Then
            Select Case uopTRNUM.CheckedIndex
                'Case 0 'Company
                '    TRNumCond = " AND e.TrackingNum like '%" & utTRNum.Text.Trim & "%'"
                'Case 1 '3rd Party
                '    TRNumCond = " AND e.ThirdPartyBarCode like '%" & utTRNum.Text.Trim & "%' "
            Case 0 'Company
                    TRNumCond = " AND e.TrackingNum like '%" & utTRNum.Text.Trim & "'"
                Case 1 '3rd Party
                    TRNumCond = " AND e.ThirdPartyBarCode like '%" & utTRNum.Text.Trim & "' "
                Case Else
                    MsgBox("No TRNUM option selected.")
                    Exit Sub
            End Select
        ElseIf rbToLoc.Checked Then
            If uchShipDate.Checked Then
                DateRngCond = " e.RowID in (Select e2.RowID from Event e2, Event e3 where  convert(varchar, e.[Scandate], 101) = '" & UltraDate1.Text & "' AND e2.EventCode = 'L' AND e3.EventCode  <> 'L' AND e3.ScanDate >= '" & UltraDate1.Text & "' AND e3.ScanDate < dateadd(d, 1,'" & UltraDate2.Text & "' AND (CASE  when rtrim(e2.TrackingNum) = '' then e2.ThirdPartyBarcode = e3.ThirdpartyBarcode ELSE e2.TrackingNum = e3.TrackingNum END) )  "
                SQLSelect2 = SQLSelect2.Replace("@SHIPDATE", "'" & UltraDate1.Text & "'")
                SQLSelect2 = SQLSelect2.Replace("@TODATE", "'" & UltraDate2.Text & "'")
                SQLSelect2 = SQLSelect2.Replace("@TOADDID", utToAddrID.Text.Trim)

                qToLoc1 = SQLSelect2.Replace("@TRNUMTYPE", " AND rtrim(isnull(e2.trackingnum, '')) <> '' ")
                qToLoc1 = qToLoc1.Replace("@JOINCOND", "e4.trackingnum like '%'+e2.trackingnum+'%'")

                qToLoc2 = SQLSelect2.Replace("@TRNUMTYPE", " AND rtrim(isnull(e2.trackingnum, '')) = '' ")
                qToLoc2 = qToLoc2.Replace("@JOINCOND", "e4.ThirdPartyBarcode like '%'+e2.ThirdPartyBarcode+'%'")
            End If
            ToLocCond = " AND e.ToAddID = " & utToAddrID.Text.Trim

        Else
            MsgBox("No Main Option is selected.")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        If qToLoc1 = "" Then
            SQLSelect = SQLSelect.Replace("@TRNUM", TRNumCond)
            SQLSelect = SQLSelect.Replace("@TOLOC", ToLocCond)

            ' Moved From Top to cover any changes to date selection that each option may need
            SQLSelect = SQLSelect.Replace("@DATERNG", DateRngCond)

            'If Not UltraGrid1.DataSource Is Nothing Then
            '    'UGSaveLayout(Me, UltraGrid1, 1)
            'End If

            SQLSelect = SQLSelect.Replace("@ADDR3", "")


            PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        Else
            PopulateDataset2(dtAdapter, dtSet, qToLoc1 & " Union " & qToLoc2)
        End If

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

        Me.Cursor = Cursors.Default

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

        SelectSQL = "Select ID, Name from ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

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

        SelectSQL = "Select ID, Name from ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

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

    Private Sub UltraGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.DoubleClick
        If m_bInvokedByAddEvent = True Then
            Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
            ugRow = UltraGrid1.ActiveRow

            m_sTrackingNumber = ugRow.Cells.Item("TrackingNum").Value
            m_sThirdPartyBarcode = ugRow.Cells.Item("ThirdPartyBarcode").Value

            m_sTrackingNumber = RTrim(m_sTrackingNumber)
            m_sThirdPartyBarcode = RTrim(m_sThirdPartyBarcode)

            Me.Close()
        End If
    End Sub

    Private Sub utTRNum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utTRNum.Leave
        btnDisplay.PerformClick()
    End Sub

End Class
