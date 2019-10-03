Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class AddEvent
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim cmdTrans As SqlCommand
    Dim HidCols() As String = {"ACT_ID", "Driver_ID", "Office_ID", "Truck_Invent_ID"}
    Dim DataModified As Boolean
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim dtEventDateTime As DateTime
    Private _cValidate As New clsFieldValidator

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents utTrackingNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uopBatch As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents ucboEvents As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents utComment As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents utContainer As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uopDlvOpt As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents dpEventDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ocboEventPeriod As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtEventHour As System.Windows.Forms.TextBox
    Friend WithEvents txtEventMinute As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.utTrackingNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uopBatch = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtEventMinute = New System.Windows.Forms.TextBox
        Me.txtEventHour = New System.Windows.Forms.TextBox
        Me.ocboEventPeriod = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.dpEventDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtWeight = New System.Windows.Forms.TextBox
        Me.lblWeight = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.uopDlvOpt = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.utContainer = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.utComment = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboEvents = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.utTrackingNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopBatch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ocboEventPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dpEventDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopDlvOpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utComment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboEvents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Controls.Add(Me.utTrackingNum)
        Me.GroupBox1.Controls.Add(Me.uopBatch)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(648, 112)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(552, 40)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(64, 21)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.TabStop = False
        Me.btnSearch.Text = "Search..."
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(448, 72)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(168, 21)
        Me.btnDisplay.TabIndex = 1
        Me.btnDisplay.TabStop = False
        Me.btnDisplay.Text = "&Display Recent Activity"
        Me.btnDisplay.Visible = False
        '
        'utTrackingNum
        '
        Me.utTrackingNum.Location = New System.Drawing.Point(8, 40)
        Me.utTrackingNum.MaxLength = 25
        Me.utTrackingNum.Name = "utTrackingNum"
        Me.utTrackingNum.Size = New System.Drawing.Size(536, 21)
        Me.utTrackingNum.TabIndex = 0
        '
        'uopBatch
        '
        Me.uopBatch.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopBatch.ItemAppearance = Appearance1
        ValueListItem1.DataValue = "Default Item"
        ValueListItem1.DisplayText = "TPC Format Tracking Number"
        ValueListItem2.DataValue = "1"
        ValueListItem2.DisplayText = "By Thirdparty Barcode"
        Me.uopBatch.Items.Add(ValueListItem1)
        Me.uopBatch.Items.Add(ValueListItem2)
        Me.uopBatch.ItemSpacingVertical = 5
        Me.uopBatch.Location = New System.Drawing.Point(8, 16)
        Me.uopBatch.Name = "uopBatch"
        Me.uopBatch.Size = New System.Drawing.Size(600, 16)
        Me.uopBatch.TabIndex = 2
        Me.uopBatch.TabStop = False
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 112)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(648, 309)
        Me.UltraGrid1.TabIndex = 2
        Me.UltraGrid1.TabStop = False
        Me.UltraGrid1.Text = "UltraGrid1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtEventMinute)
        Me.GroupBox2.Controls.Add(Me.txtEventHour)
        Me.GroupBox2.Controls.Add(Me.ocboEventPeriod)
        Me.GroupBox2.Controls.Add(Me.dpEventDate)
        Me.GroupBox2.Controls.Add(Me.txtWeight)
        Me.GroupBox2.Controls.Add(Me.lblWeight)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.UltraLabel4)
        Me.GroupBox2.Controls.Add(Me.uopDlvOpt)
        Me.GroupBox2.Controls.Add(Me.UltraLabel3)
        Me.GroupBox2.Controls.Add(Me.utContainer)
        Me.GroupBox2.Controls.Add(Me.UltraLabel2)
        Me.GroupBox2.Controls.Add(Me.utComment)
        Me.GroupBox2.Controls.Add(Me.ucboEvents)
        Me.GroupBox2.Controls.Add(Me.UltraLabel1)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 421)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(648, 136)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtEventMinute
        '
        Me.txtEventMinute.Location = New System.Drawing.Point(264, 72)
        Me.txtEventMinute.Name = "txtEventMinute"
        Me.txtEventMinute.Size = New System.Drawing.Size(32, 20)
        Me.txtEventMinute.TabIndex = 3
        Me.txtEventMinute.Text = ""
        '
        'txtEventHour
        '
        Me.txtEventHour.Location = New System.Drawing.Point(232, 72)
        Me.txtEventHour.Name = "txtEventHour"
        Me.txtEventHour.Size = New System.Drawing.Size(32, 20)
        Me.txtEventHour.TabIndex = 2
        Me.txtEventHour.Text = ""
        '
        'ocboEventPeriod
        '
        Me.ocboEventPeriod.DisplayMember = ""
        Me.ocboEventPeriod.Enabled = False
        Me.ocboEventPeriod.Location = New System.Drawing.Point(304, 72)
        Me.ocboEventPeriod.Name = "ocboEventPeriod"
        Me.ocboEventPeriod.Size = New System.Drawing.Size(48, 21)
        Me.ocboEventPeriod.TabIndex = 4
        Me.ocboEventPeriod.TabStop = False
        Me.ocboEventPeriod.Tag = ""
        Me.ocboEventPeriod.ValueMember = ""
        Me.ocboEventPeriod.Visible = False
        '
        'dpEventDate
        '
        Me.dpEventDate.DateTime = New Date(2006, 3, 31, 0, 0, 0, 0)
        Me.dpEventDate.Location = New System.Drawing.Point(128, 72)
        Me.dpEventDate.Name = "dpEventDate"
        Me.dpEventDate.Size = New System.Drawing.Size(100, 21)
        Me.dpEventDate.TabIndex = 1
        Me.dpEventDate.Tag = ".CheckInDate"
        Me.dpEventDate.Value = New Date(2006, 3, 31, 0, 0, 0, 0)
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(576, 48)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(56, 20)
        Me.txtWeight.TabIndex = 18
        Me.txtWeight.TabStop = False
        Me.txtWeight.Text = ""
        '
        'lblWeight
        '
        Me.lblWeight.Location = New System.Drawing.Point(520, 48)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(48, 16)
        Me.lblWeight.TabIndex = 17
        Me.lblWeight.Text = "Weight:  "
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Event Date/Time"
        '
        'UltraLabel4
        '
        Appearance2.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance2.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel4.Appearance = Appearance2
        Me.UltraLabel4.Location = New System.Drawing.Point(232, 16)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(96, 16)
        Me.UltraLabel4.TabIndex = 13
        Me.UltraLabel4.Text = "Delivery Options:"
        '
        'uopDlvOpt
        '
        Me.uopDlvOpt.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopDlvOpt.ItemAppearance = Appearance3
        ValueListItem3.DataValue = "Destination"
        ValueListItem3.DisplayText = "Destination"
        ValueListItem4.DataValue = "Neighbor"
        ValueListItem5.DataValue = "Behind The Door"
        ValueListItem6.DataValue = "Other"
        Me.uopDlvOpt.Items.Add(ValueListItem3)
        Me.uopDlvOpt.Items.Add(ValueListItem4)
        Me.uopDlvOpt.Items.Add(ValueListItem5)
        Me.uopDlvOpt.Items.Add(ValueListItem6)
        Me.uopDlvOpt.ItemSpacingVertical = 5
        Me.uopDlvOpt.Location = New System.Drawing.Point(336, 16)
        Me.uopDlvOpt.Name = "uopDlvOpt"
        Me.uopDlvOpt.Size = New System.Drawing.Size(304, 24)
        Me.uopDlvOpt.TabIndex = 12
        Me.uopDlvOpt.TabStop = False
        '
        'UltraLabel3
        '
        Appearance4.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance4.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel3.Appearance = Appearance4
        Me.UltraLabel3.Location = New System.Drawing.Point(392, 80)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(80, 16)
        Me.UltraLabel3.TabIndex = 11
        Me.UltraLabel3.Text = "Container No.:"
        '
        'utContainer
        '
        Me.utContainer.Location = New System.Drawing.Point(480, 72)
        Me.utContainer.MaxLength = 15
        Me.utContainer.Name = "utContainer"
        Me.utContainer.Size = New System.Drawing.Size(152, 21)
        Me.utContainer.TabIndex = 1
        Me.utContainer.TabStop = False
        '
        'UltraLabel2
        '
        Appearance5.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance5.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel2.Appearance = Appearance5
        Me.UltraLabel2.Location = New System.Drawing.Point(24, 48)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(160, 16)
        Me.UltraLabel2.TabIndex = 9
        Me.UltraLabel2.Text = "Event Appropirate Comments:"
        '
        'utComment
        '
        Me.utComment.Location = New System.Drawing.Point(184, 40)
        Me.utComment.MaxLength = 17
        Me.utComment.Name = "utComment"
        Me.utComment.Size = New System.Drawing.Size(168, 21)
        Me.utComment.TabIndex = 0
        '
        'ucboEvents
        '
        Me.ucboEvents.DisplayMember = ""
        Me.ucboEvents.Enabled = False
        Me.ucboEvents.Location = New System.Drawing.Point(96, 16)
        Me.ucboEvents.Name = "ucboEvents"
        Me.ucboEvents.Size = New System.Drawing.Size(120, 21)
        Me.ucboEvents.TabIndex = 3
        Me.ucboEvents.TabStop = False
        Me.ucboEvents.Tag = ""
        Me.ucboEvents.ValueMember = ""
        '
        'UltraLabel1
        '
        Appearance6.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance6.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.Location = New System.Drawing.Point(8, 19)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(80, 16)
        Me.UltraLabel1.TabIndex = 6
        Me.UltraLabel1.Text = "Select Event:"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(776, 24)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(504, 104)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(104, 21)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "&Add Event"
        '
        'AddEvent
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(648, 557)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "AddEvent"
        Me.Text = "Add Event"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utTrackingNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopBatch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ocboEventPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dpEventDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopDlvOpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utContainer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utComment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboEvents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub AddEvent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                'Me.Tag = HOLIDAYSTblPath & Me.Tag
                Me.Tag = TRCTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        'AddHandler utStartMile.KeyPress, AddressOf Value_Int_KeyPress
        'AddHandler utInvoiceNo.KeyPress, AddressOf Value_Int_KeyPress
        '
        cmdTrans = Nothing

        'UltraDate1.Nullable = True
        'UltraDate1.Value = Nothing 'Date.Now
        'UltraDate1.FormatString = "MM/dd/yyyy"

        'UltraDate2.Nullable = True
        'UltraDate2.Value = Nothing 'Date.Now
        'UltraDate2.FormatString = "MM/dd/yyyy"

        utTrackingNum.MaxLength = 25
        UltraGrid1.Text = "Events"
        uopBatch.CheckedIndex = 0

        'Aly's original
        'FillUCombo(ucboEvents)
        'Karina changed
        'FillUCombo(ucboEvents, "", "", "", TRCTblPath) 'Uncomment this line and add TAG property as described in ucboEvents_InitializeLayout() to populate dynamically
        'Temporary Static Populate for Initial AddEvent Rollout during PIA launch - svn
        ucboEvents.Text = "Delivered"
        ucboEvents.Value = "DD"
        uopDlvOpt.Enabled = True
        uopDlvOpt.Visible = True
        UltraLabel4.Visible = True

        AddHandler ucboEvents.Leave, AddressOf UCbo_Leave
        'uopDlvOpt.Enabled = False
        utContainer.Enabled = False

        'txtEventDateTime.Text = Date.Now().ToShortDateString + " " + Date.Now().ToShortTimeString
        SetDefaultEventDate()

        utContainer.Text = String.Empty
        txtWeight.Text = "0.00"

        utContainer.Enabled = False
        utContainer.Visible = False
        UltraLabel3.Visible = False

        txtWeight.Enabled = False
        txtWeight.Visible = False
        lblWeight.Visible = False

        SetDefaultState()

    End Sub

    Private Sub SetDefaultEventDate()
        dtEventDateTime = Date.Now()
        dpEventDate.Value = dtEventDateTime.ToShortDateString
        txtEventHour.Text = dtEventDateTime.Hour
        txtEventMinute.Text = dtEventDateTime.Minute
        Dim dtMeridiem As New DataTable
        dtMeridiem.Columns.Add("ValueMember", GetType(String))
        dtMeridiem.Columns.Add("DisplayMember", GetType(String))
        Dim r = dtMeridiem.NewRow()
        r("ValueMember") = "0"
        r("DisplayMember") = "AM"
        dtMeridiem.Rows.Add(r)
        r = dtMeridiem.NewRow()
        r("ValueMember") = "1"
        r("DisplayMember") = "PM"
        dtMeridiem.Rows.Add(r)
        ocboEventPeriod.ValueMember = "ValueMember"
        ocboEventPeriod.DisplayMember = "DisplayMember"
        ocboEventPeriod.DataSource = dtMeridiem
        If CInt(txtEventHour.Text) > 12 Then ocboEventPeriod.ValueMember = 1 Else ocboEventPeriod.ValueMember = 0
    End Sub

    Private Sub SetDefaultState()
        uopBatch.CheckedIndex = 1
        uopDlvOpt.CheckedIndex = 0
        'SetDefaultEventDate()
        utTrackingNum.Focus()
    End Sub

    Private Sub uopBatch_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uopBatch.ValueChanged
        Select Case uopBatch.CheckedIndex
            Case 0 ' Search for TPC Tracking Numbers
                If utTrackingNum.Enabled = False Then utTrackingNum.Text = ""
                utTrackingNum.Enabled = True
                utTrackingNum.MaxLength = 15
            Case 1 ' Search for 3rd Party Tracking Numbers
                If utTrackingNum.Enabled = False Then utTrackingNum.Text = ""
                utTrackingNum.Enabled = True
                utTrackingNum.MaxLength = 25
            Case 2 ' Search for TPC Tracking Numbers not delivered after 3 days (suppressed by svn on 2014-05-13)
                utTrackingNum.Text = "That option is not currently supported"
                utTrackingNum.Enabled = False
                utTrackingNum.MaxLength = 15
            Case 3 ' Search for 3rd Party Tracking Numbers not delivered after 3 days  (suppressed by svn on 2014-05-13)
                utTrackingNum.Text = "That option is not currently supported"
                utTrackingNum.Enabled = False
                utTrackingNum.MaxLength = 25
        End Select
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        LoadData()
    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, TmpQuery, SQLInventory As String

        'SQLSelect = " Select e.ScanDate as [Scan Date], e.TrackingNum as [Track#], e.Void, e.EventCode, e.OperatorID, e.PointID, e.ThirdPartyBarcode, e.TicketNum, e.ContainerBarcode, e.DeliveryOption, e.DeliveryComments, e.ToCity,e.ParcelType,e.Weight,e.Pieces, e.ToLocID, e.ToLocName, e.RefNum,e.FromCustID,e.FromCustName,e.FromLocID , e.FromLocName, e.HHid, e.BatchNum from " & TRCTblPath & "EVENT e where e.TrackingNum = '@TRACKNUM' AND e.scandate between convert(varchar, dateadd(d,-30,getdate()), 101) AND convert(varchar, dateadd(d,1,getdate()), 101)"
        'SQLSelect = " Select e.ScanDate as [Scan Date], e.TrackingNum as [Track#], e.Void, e.EventCode, e.OperatorID, e.PointID, e.ThirdPartyBarcode, e.TicketNum, e.ContainerBarcode, e.DeliveryOption, e.DeliveryComments, e.ToCity,e.ParcelType,e.Weight,e.Pieces, e.ToLocID, e.ToLocName, e.RefNum,e.FromCustID,e.FromCustName,e.FromLocID , e.FromLocName, e.HHid, e.BatchNum from " & TRCTblPath & "EVENT e where e.@FIELD = '@TRACKNUM' AND e.scandate between convert(varchar, dateadd(d,-30,getdate()), 101) AND convert(varchar, dateadd(d,1,getdate()), 101)"
        SQLSelect = " Select e.ScanDate as [Scan Date],e.EventCode,e.TrackingNum as [Track#],e.ThirdPartyBarcode,e.FromCustID,e.FromCustName,e.FromLocID,e.FromLocName,e.ToCity,e.ToLocID,e.ToLocName,e.ParcelType,e.Weight,e.Pieces,e.RefNum,e.DeliveryComments,e.TicketNum,e.ContainerBarcode,e.OperatorID,e.PointID,e.BatchNum,e.HHid,e.Void,e.DeliveryOption from " & TRCTblPath & "EVENT e where e.@FIELD = '@TRACKNUM' AND e.scandate between convert(varchar, dateadd(d,-90,getdate()), 101) AND convert(varchar, dateadd(d,1,getdate()), 101)"

        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If

        Select Case uopBatch.CheckedIndex
            Case 0
                If utTrackingNum.Text.Trim = "" Then
                    MsgBox("Tracking Number not specified.")
                    Exit Sub
                Else
                    TmpQuery = SQLSelect.Replace("@TRACKNUM", utTrackingNum.Text.Trim)
                    TmpQuery = TmpQuery.Replace("@FIELD", "TrackingNum")
                End If
            Case 1
                If utTrackingNum.Text.Trim = "" Then
                    MsgBox("Tracking Number not specified.")
                    Exit Sub
                Else
                    TmpQuery = SQLSelect.Replace("@TRACKNUM", utTrackingNum.Text.Trim)
                    TmpQuery = TmpQuery.Replace("@FIELD", "ThirdPartyBarcode")
                End If
            Case 2
                MessageBox.Show(utTrackingNum.Text)
                Exit Sub
            Case 3
                MessageBox.Show(utTrackingNum.Text)
                Exit Sub
        End Select


        PopulateDataset2(dtAdapter, dtSet, TmpQuery)


        For i = 1 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next

        dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid1, dtSet, 0, HidCols, 0)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next

        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        UltraGrid1.Text = "Recent Activity"

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim i As Integer
        Dim ActivityIDs, Updqry, TmpQry As String

        If ucboEvents.Value Is Nothing Then
            MsgBox("Event not selected.")
            Exit Sub
        End If
        If UltraGrid1.DataSource Is Nothing Then
            MsgBox("No data displayed.")
            Exit Sub
        End If

        'Updqry = "Insert into " & TRCTblPath & "EVENT(EventCode, ScanDate,OperatorID, PointID,TicketNum,TrackingNum,ThirdPartyBarcode,ContainerBarcode, DeliveryOption,DeliveryComments,ToCity,ParcelType,Weight,Pieces,Void, ToLocID,ToAddID, ToLocName, RefNum,FromAddID , FromCustID,FromCustName,FromLocID , FromLocName,HHid,BatchNum, SignaturePath) " & _
        '"Select @EVTCODE, getdate(), @OPRID, @PNTID, TicketNum,TrackingNum,ThirdPartyBarcode, @CONTAINER, @DLOPT, @DLCOMMENT, ToCity, ParcelType,Weight,Pieces,Void, ToLocID,ToAddID, ToLocName, RefNum,FromAddID , FromCustID,FromCustName,FromLocID , FromLocName,HHid,BatchNum, SignaturePath from " & TRCTblPath & "EVENT e where e.@TRACKNUMFIELD = @TRACKNUM AND e.scandate between convert(varchar, dateadd(d,-30,getdate()), 101) AND convert(varchar, dateadd(d,1,getdate()), 101) and scandate = (select max(ee.scandate) as MaxDate FROM " & TRCTblPath & "event ee where ee.@TRACKNUMFIELD = e.@TRACKNUMFIELD )"
        Updqry = "Insert into " & TRCTblPath & "EVENT(EventCode, ScanDate,OperatorID, PointID,TicketNum,TrackingNum,ThirdPartyBarcode,ContainerBarcode, DeliveryOption,DeliveryComments,ToCity,ParcelType,Weight,Pieces,Void, ToLocID,ToAddID, ToLocName, RefNum,FromAddID , FromCustID,FromCustName,FromLocID , FromLocName,HHid,BatchNum, SignaturePath) " & _
        "Select @EVTCODE, @ScanDate, @OPRID, @PNTID, TicketNum,TrackingNum,ThirdPartyBarcode, @CONTAINER, @DLOPT, @DLCOMMENT, ToCity, ParcelType,@Weight,Pieces,Void, ToLocID,ToAddID, ToLocName, RefNum,FromAddID , FromCustID,FromCustName,FromLocID , FromLocName,HHid,BatchNum, SignaturePath from " & TRCTblPath & "EVENT e where e.@TRACKNUMFIELD = @TRACKNUM AND e.scandate between convert(varchar, dateadd(d,-90,getdate()), 101) AND convert(varchar, dateadd(d,1,getdate()), 101) and scandate = (select max(ee.scandate) as MaxDate FROM " & TRCTblPath & "event ee where ee.@TRACKNUMFIELD = e.@TRACKNUMFIELD )"

        TmpQry = Updqry.Replace("@EVTCODE", "'" & ucboEvents.Value & "'")
        TmpQry = TmpQry.Replace("@OPRID", "'E0000001'")
        TmpQry = TmpQry.Replace("@PNTID", "'P0000497'")
        'TmpQry = TmpQry.Replace("@ScanDate", "'" & txtEventDateTime.Text & "'")
        TmpQry = TmpQry.Replace("@Weight", txtWeight.Text)
        Dim dEvent As New DateTime(CDate(dpEventDate.Value).Year, CDate(dpEventDate.Value).Month, CDate(dpEventDate.Value).Day, CInt(txtEventHour.Text), CInt(txtEventMinute.Text), 0)
        TmpQry = TmpQry.Replace("@ScanDate", "'" & dEvent.ToString() & "'")

        If ucboEvents.Value = "PK" Or ucboEvents.Value = "UP" Then
            TmpQry = TmpQry.Replace("@CONTAINER", "'" & utContainer.Text.Trim & "'")
        Else
            TmpQry = TmpQry.Replace("@CONTAINER", "ContainerBarcode")
        End If

        If ucboEvents.Value = "DD" Or ucboEvents.Value = "BD" Then
            If uopDlvOpt.CheckedIndex < 0 Then
                MsgBox("Delivery Option Not Selected.")
                Exit Sub
            End If
            TmpQry = TmpQry.Replace("@DLOPT", "'" & (uopDlvOpt.CheckedIndex + 1) & "'")
        Else
            TmpQry = TmpQry.Replace("@DLOPT", "DeliveryOption")
        End If

        TmpQry = TmpQry.Replace("@DLCOMMENT", "'" & utComment.Text.Trim & "'")

        If uopBatch.CheckedIndex = 0 Then 'TPC Barcode
            TmpQry = TmpQry.Replace("@TRACKNUMFIELD", "TrackingNum")
            TmpQry = TmpQry.Replace("@TRACKNUM", "'" & utTrackingNum.Text.Trim & "'")
        ElseIf uopBatch.CheckedIndex = 1 Then '3rd Partybarcode
            TmpQry = TmpQry.Replace("@TRACKNUMFIELD", "ThirdPartyBarcode")
            TmpQry = TmpQry.Replace("@TRACKNUM", "'" & utTrackingNum.Text.Trim & "'")
        Else
            Exit Sub
        End If

        If ExecuteQuery(TmpQry) = True Then
            MsgBox("Event Added Successfully.")
            LoadData()
        Else
            MsgBox("Error Adding Event.")
        End If

    End Sub

    Private Sub ucboEvents_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboEvents.ValueChanged

        Dim bContainer As Boolean = False
        Dim bDlvOpt As Boolean = False
        Dim bWeight As Boolean = False

        'txtEventDateTime.Text = Date.Now().ToShortDateString + " " + Date.Now().ToShortTimeString

        If sender.value = "PK" Or sender.value = "UP" Then
            bContainer = True
        Else
            bContainer = False
            utContainer.Text = String.Empty
        End If
        utContainer.Enabled = bContainer
        utContainer.Visible = bContainer
        UltraLabel3.Visible = bContainer

        If sender.value = "DD" Or sender.value = "BD" Then
            bDlvOpt = True
        Else
            bDlvOpt = False
        End If
        uopDlvOpt.Enabled = bDlvOpt
        uopDlvOpt.Visible = bDlvOpt
        UltraLabel4.Visible = bDlvOpt

        If sender.value = "WC" Then
            bWeight = True
        Else
            bWeight = False
            txtWeight.Text = "0.00"
        End If
        txtWeight.Enabled = bWeight
        txtWeight.Visible = bWeight
        lblWeight.Visible = bWeight

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim x As New ItemTrackingListing

        x.InvokedByAddEvent = True
        x.TrackingOption = uopBatch.CheckedIndex
        x.ShowDialog()

        Select Case uopBatch.CheckedIndex
            Case 0
                utTrackingNum.Text = x.TrackingNumber
                btnDisplay.PerformClick()
                'MessageBox.Show(x.TrackingNumber)
            Case 1
                utTrackingNum.Text = x.ThirdPartyBarcode
                btnDisplay.PerformClick()
                'MessageBox.Show(x.ThirdPartyBarcode)
            Case 2
                'MessageBox.Show("Not Supported")
            Case 3
                'MessageBox.Show("Not Supported")
        End Select

        utTrackingNum.Focus()
        utComment.Focus()

    End Sub


    'Private Sub txtEventDateTime_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEventDateTime.Validating
    '    Dim dt As DateTime
    '    Try
    '        dt = CDate(txtEventDateTime.Text)
    '    Catch ex As InvalidCastException
    '        MessageBox.Show("Enter a valid date and time")
    '        'MessageBox.Show(ex.ToString)
    '        txtEventDateTime.Focus()
    '    End Try
    'End Sub

    Private Sub txtWeight_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtWeight.Validating
        Dim f As Double
        Try
            f = CDec(txtWeight.Text)
        Catch ex As InvalidCastException
            MessageBox.Show("Enter a valid Weight")
            'MessageBox.Show(ex.ToString)
            txtWeight.Focus()
        End Try
    End Sub

    Private Sub ucboEvents_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ucboEvents.InitializeLayout
        'The follwoing test should be added to the TAG property to make this drop-down dynamic, "....EVENTCODES.EVENTCODE.NAME"
    End Sub

    Private Sub utTrackingNum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utTrackingNum.Leave
        If RTrim(utTrackingNum.Text) <> String.Empty Then
            LoadData()
        End If
    End Sub

    Private Sub txtEventHour_Leave(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEventHour.Validating
        If (_cValidate.Range(txtEventHour, CInt(0), CInt(23)) = False) Then
            Beep()
            txtEventHour.SelectAll()
            txtEventHour.Focus()
        End If
    End Sub

    Private Sub txtEventMinute_Leave(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEventHour.Validating
        If (_cValidate.Range(txtEventHour, CInt(0), CInt(59)) = False) Then
            Beep()
            txtEventMinute.SelectAll()
            txtEventMinute.Focus()
        End If
    End Sub

End Class
