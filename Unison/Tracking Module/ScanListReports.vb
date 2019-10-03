Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class SuspiciousScans
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim TemplateID As Integer
    Dim Template As String
    Dim dtSet As New DataSet
    Dim HidCols() As String = {"RowID"}

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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents utOfficeName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents uosFilter As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents cbOffice As System.Windows.Forms.CheckBox
    Friend WithEvents utOfficeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents udToDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udBatchDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents upsBatchDate As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents udFromDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents uosDisplay As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem13 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.utOfficeName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.uosFilter = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnSelect = New System.Windows.Forms.Button
        Me.cbOffice = New System.Windows.Forms.CheckBox
        Me.utOfficeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.udToDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.udBatchDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.upsBatchDate = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.udFromDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.uosDisplay = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.GroupBox1.SuspendLayout()
        CType(Me.utOfficeName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.uosFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.udToDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udBatchDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.upsBatchDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udFromDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.uosDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Enabled = False
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.utOfficeName)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(783, 229)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'utOfficeName
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOfficeName.Appearance = Appearance1
        Me.utOfficeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeName.Enabled = False
        Me.utOfficeName.Location = New System.Drawing.Point(346, 109)
        Me.utOfficeName.Name = "utOfficeName"
        Me.utOfficeName.Size = New System.Drawing.Size(280, 21)
        Me.utOfficeName.TabIndex = 206
        Me.utOfficeName.Tag = ""
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.uosFilter)
        Me.GroupBox6.Location = New System.Drawing.Point(597, 11)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(134, 78)
        Me.GroupBox6.TabIndex = 205
        Me.GroupBox6.TabStop = False
        '
        'uosFilter
        '
        Appearance2.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uosFilter.Appearance = Appearance2
        Me.uosFilter.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uosFilter.ItemAppearance = Appearance3
        ValueListItem1.DataValue = "Default Item"
        ValueListItem1.DisplayText = "Filter"
        ValueListItem2.DataValue = "Undelivered After 3 Days"
        ValueListItem2.DisplayText = "UnFilter"
        ValueListItem3.DataValue = "ValueListItem2"
        ValueListItem3.DisplayText = "Smart Filter"
        Me.uosFilter.Items.Add(ValueListItem1)
        Me.uosFilter.Items.Add(ValueListItem2)
        Me.uosFilter.Items.Add(ValueListItem3)
        Me.uosFilter.ItemSpacingVertical = 10
        Me.uosFilter.Location = New System.Drawing.Point(6, 6)
        Me.uosFilter.Name = "uosFilter"
        Me.uosFilter.Size = New System.Drawing.Size(115, 68)
        Me.uosFilter.TabIndex = 188
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnSelect)
        Me.GroupBox4.Controls.Add(Me.cbOffice)
        Me.GroupBox4.Controls.Add(Me.utOfficeID)
        Me.GroupBox4.Location = New System.Drawing.Point(219, 94)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(513, 44)
        Me.GroupBox4.TabIndex = 204
        Me.GroupBox4.TabStop = False
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(415, 15)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(88, 21)
        Me.btnSelect.TabIndex = 199
        Me.btnSelect.Text = "Selec&t"
        '
        'cbOffice
        '
        Me.cbOffice.Location = New System.Drawing.Point(11, 14)
        Me.cbOffice.Name = "cbOffice"
        Me.cbOffice.Size = New System.Drawing.Size(54, 24)
        Me.cbOffice.TabIndex = 199
        Me.cbOffice.Text = "Office"
        '
        'utOfficeID
        '
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOfficeID.Appearance = Appearance4
        Me.utOfficeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeID.Location = New System.Drawing.Point(68, 15)
        Me.utOfficeID.Name = "utOfficeID"
        Me.utOfficeID.Size = New System.Drawing.Size(50, 21)
        Me.utOfficeID.TabIndex = 197
        Me.utOfficeID.Tag = ".OfficeID"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.udToDate)
        Me.GroupBox3.Controls.Add(Me.udBatchDate)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.upsBatchDate)
        Me.GroupBox3.Controls.Add(Me.udFromDate)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(219, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(369, 78)
        Me.GroupBox3.TabIndex = 203
        Me.GroupBox3.TabStop = False
        '
        'udToDate
        '
        Me.udToDate.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udToDate.Location = New System.Drawing.Point(268, 44)
        Me.udToDate.Name = "udToDate"
        Me.udToDate.Size = New System.Drawing.Size(96, 21)
        Me.udToDate.TabIndex = 184
        Me.udToDate.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'udBatchDate
        '
        Me.udBatchDate.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udBatchDate.Location = New System.Drawing.Point(153, 14)
        Me.udBatchDate.Name = "udBatchDate"
        Me.udBatchDate.Size = New System.Drawing.Size(96, 21)
        Me.udBatchDate.TabIndex = 181
        Me.udBatchDate.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(249, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 186
        Me.Label2.Text = "To"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'upsBatchDate
        '
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.upsBatchDate.Appearance = Appearance5
        Me.upsBatchDate.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.upsBatchDate.ItemAppearance = Appearance6
        ValueListItem4.DataValue = "Default Item"
        ValueListItem4.DisplayText = "Batch Date:"
        ValueListItem5.DataValue = "Undelivered After 3 Days"
        ValueListItem5.DisplayText = "Batch Date Range:"
        Me.upsBatchDate.Items.Add(ValueListItem4)
        Me.upsBatchDate.Items.Add(ValueListItem5)
        Me.upsBatchDate.ItemSpacingVertical = 10
        Me.upsBatchDate.Location = New System.Drawing.Point(10, 17)
        Me.upsBatchDate.Name = "upsBatchDate"
        Me.upsBatchDate.Size = New System.Drawing.Size(115, 46)
        Me.upsBatchDate.TabIndex = 187
        '
        'udFromDate
        '
        Me.udFromDate.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udFromDate.Location = New System.Drawing.Point(153, 44)
        Me.udFromDate.Name = "udFromDate"
        Me.udFromDate.Size = New System.Drawing.Size(96, 21)
        Me.udFromDate.TabIndex = 183
        Me.udFromDate.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(122, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 16)
        Me.Label11.TabIndex = 185
        Me.Label11.Text = "From"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.uosDisplay)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(151, 209)
        Me.GroupBox2.TabIndex = 202
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Display By Error Code"
        '
        'uosDisplay
        '
        Appearance7.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uosDisplay.Appearance = Appearance7
        Me.uosDisplay.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uosDisplay.ItemAppearance = Appearance8
        ValueListItem6.DataValue = "Default Item"
        ValueListItem6.DisplayText = "Duplicate Scans"
        ValueListItem7.DataValue = "Undelivered After 3 Days"
        ValueListItem7.DisplayText = "Wrong Branch Errors"
        ValueListItem8.DataValue = "ValueListItem2"
        ValueListItem8.DisplayText = "Supervisor Reviews"
        ValueListItem9.DataValue = "ValueListItem3"
        ValueListItem9.DisplayText = "Weight Errors"
        ValueListItem10.DataValue = "ValueListItem4"
        ValueListItem10.DisplayText = "Scale Errors"
        ValueListItem11.DataValue = "ValueListItem5"
        ValueListItem11.DisplayText = "Read Errors"
        ValueListItem12.DataValue = "ValueListItem6"
        ValueListItem12.DisplayText = "Old Flip Cards"
        ValueListItem13.DataValue = "ValueListItem7"
        ValueListItem13.DisplayText = "No Weight-Plan Scans"
        Me.uosDisplay.Items.Add(ValueListItem6)
        Me.uosDisplay.Items.Add(ValueListItem7)
        Me.uosDisplay.Items.Add(ValueListItem8)
        Me.uosDisplay.Items.Add(ValueListItem9)
        Me.uosDisplay.Items.Add(ValueListItem10)
        Me.uosDisplay.Items.Add(ValueListItem11)
        Me.uosDisplay.Items.Add(ValueListItem12)
        Me.uosDisplay.Items.Add(ValueListItem13)
        Me.uosDisplay.ItemSpacingVertical = 10
        Me.uosDisplay.Location = New System.Drawing.Point(9, 17)
        Me.uosDisplay.Name = "uosDisplay"
        Me.uosDisplay.Size = New System.Drawing.Size(136, 189)
        Me.uosDisplay.TabIndex = 2
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(489, 192)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(88, 21)
        Me.btnExcel.TabIndex = 201
        Me.btnExcel.Text = "Export to E&xcel"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(585, 192)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 21)
        Me.btnPrint.TabIndex = 200
        Me.btnPrint.Text = "&Print"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(681, 192)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 199
        Me.btnDisplay.Text = "D&isplay"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.btnExit)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox5.Location = New System.Drawing.Point(0, 573)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(783, 39)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(14, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 21)
        Me.Button1.TabIndex = 198
        Me.Button1.Text = "&Delete"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(110, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 21)
        Me.Button2.TabIndex = 197
        Me.Button2.Text = "&Edit"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(680, 13)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 21)
        Me.btnExit.TabIndex = 196
        Me.btnExit.Text = "Exit"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 229)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(783, 344)
        Me.UltraGrid1.TabIndex = 5
        Me.UltraGrid1.Text = "Scan List Report"
        '
        'UltraGridExcelExporter1
        '
        Me.UltraGridExcelExporter1.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.ThrowException
        '
        'SuspiciousScans
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(783, 612)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Menu = Me.MainMenu1
        Me.Name = "SuspiciousScans"
        Me.Text = "Suspicious Scans"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utOfficeName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.uosFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.udToDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udBatchDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.upsBatchDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udFromDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.uosDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ScanListReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        StandardFormPrep(Me, MeText, TRCTblPath)
        Me.CenterToScreen()

        udBatchDate.Nullable = True
        udBatchDate.Value = Date.Today
        udBatchDate.FormatString = "MM/dd/yyyy"

        udFromDate.Nullable = True
        udFromDate.Value = DateAdd(DateInterval.Day, -1, Date.Today)
        udFromDate.FormatString = "MM/dd/yyyy"

        udToDate.Nullable = True
        udToDate.Value = Date.Today
        udToDate.FormatString = "MM/dd/yyyy"

        uosDisplay.CheckedIndex = 0
        upsBatchDate.CheckedIndex = 0

        uosFilter.CheckedIndex = 1
        uosFilter.Enabled = False

        AddHandler utOfficeID.KeyPress, AddressOf Value_Int_KeyPress

        cbOffice.Checked = False
        utOfficeID.Text = ""
        utOfficeID.Enabled = False
        utOfficeName.Text = ""
        btnSelect.Enabled = False
    End Sub

    Private Sub LoadData()
        Dim SqlSelect, sqlScans, sqlWrongBranch, sqlScans2, sqlReadErr As String
        Dim ErrorLog, BatchDateStart, BatchDateEnd, HHID As String
        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer

        If cbOffice.Checked = True And utOfficeID.Text = "" Then
            MsgBox("Please select the office.", MsgBoxStyle.Exclamation, "Warning! Missing data!")
            Exit Sub
        ElseIf upsBatchDate.CheckedIndex = 0 And udBatchDate.Text = "" Then
            MsgBox("Please select the batch date.", MsgBoxStyle.Exclamation, "Warning! Missing data!")
            Exit Sub
        ElseIf upsBatchDate.CheckedIndex = 1 And (udFromDate.Text = "" Or udToDate.Text = "") Then
            MsgBox("Please select the batch date range.", MsgBoxStyle.Exclamation, "Warning! Missing data!")
            Exit Sub
        End If

        Dim cntOfficeID As Integer
        cntOfficeID = utOfficeID.Text.Length
        If cbOffice.Checked = True And utOfficeID.Text <> "" Then
            If cntOfficeID = 1 Then
                HHID = "'%" & utOfficeID.Text & "W%'"
            ElseIf cntOfficeID = 2 Then
                HHID = "'" & utOfficeID.Text & "W%'"
            End If

        Else
            HHID = "'%'"
        End If

        If upsBatchDate.CheckedIndex = 0 Then
            BatchDateStart = udBatchDate.Text
            BatchDateEnd = udBatchDate.Text
        Else
            BatchDateStart = udFromDate.Text
            BatchDateEnd = udToDate.Text
        End If

        Select Case uosDisplay.CheckedIndex
            Case 0 ' Display Duplicate Scans
                SqlSelect = "spScanListSuspiciousReports 'DUPOK', " & HHID & ", 'WC', '" & BatchDateStart & "', '" & BatchDateEnd & "', 1024, 1040"
            Case 1 ' Display Wrong Branch Errors
                SqlSelect = "spScanListSuspiciousReports 'WRONGB', " & HHID & ", 'WC', '" & BatchDateStart & "', '" & BatchDateEnd & "', 2, 65538, 196608"
            Case 2 ' Display Supervisor Reviews
                SqlSelect = "spScanListSuspiciousReports 'SUPERR', " & HHID & ", 'WC', '" & BatchDateStart & "', '" & BatchDateEnd & "', 4, 20, 65540, 131076, 196612, 196620"
            Case 3 ' Display Weight Errors
                SqlSelect = "spScanListSuspiciousReports 'NWGTX', " & HHID & ", 'WC', '" & BatchDateStart & "', '" & BatchDateEnd & "', 8, 8192, 139264, 196612, 196620"
            Case 4 ' Display Scale Errors
                SqlSelect = "spScanListSuspiciousReports 'SCALEX', " & HHID & ", 'WC', '" & BatchDateStart & "', '" & BatchDateEnd & "', 16, 20, 48, 1040, 131088"
            Case 5 ' Display Read Errors
                SqlSelect = "spScanListSuspiciousReports 'READX', " & HHID & ", 'WC', '" & BatchDateStart & "', '" & BatchDateEnd & "', 32, 48"
            Case 6 ' Display Old Flip Cards
                SqlSelect = "spScanListSuspiciousReports 'OLDFCOK', " & HHID & ", 'WC', '" & BatchDateStart & "', '" & BatchDateEnd & "', 65536, 65538, 65540, 196612, 196620"
            Case 7 ' Display No Weight-Plans Scans
                SqlSelect = "spScanListSuspiciousReports 'NOPLNOK', " & HHID & ", 'WC', '" & BatchDateStart & "', '" & BatchDateEnd & "', 131072, 131076, 131088, 139264, 196608"
        End Select

        Dim cnProcedure As New SqlConnection(strConnection)
        Dim cmd As New SqlCommand("exec " & TRCTblPath & SqlSelect, cnProcedure)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.SelectCommand = cmd
        da.Fill(ds)

        FillUltraGrid(UltraGrid1, ds, -1, HidCols, 0)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        UltraGrid1.DisplayLayout.AutoFitColumns = False
        For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = True
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("TrackingNum", Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns("TrackingNum"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid1.DisplayLayout.Bands(0).Summaries("TrackingNum").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        da = Nothing
        dtSet = Nothing
    End Sub

    Private Sub upsBatchDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upsBatchDate.ValueChanged
        Select Case upsBatchDate.CheckedIndex
            Case 0 ' Batch Date
                udBatchDate.Visible = True
                udFromDate.Visible = False
                Label11.Visible = False
                udToDate.Visible = False
                Label2.Visible = False
            Case 1 ' Batch Date Range
                udBatchDate.Visible = False
                udFromDate.Visible = True
                Label11.Visible = True
                udToDate.Visible = True
                Label2.Visible = True
        End Select
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        UltraGrid1.PrintPreview(Infragistics.Win.UltraWinGrid.RowPropertyCategories.All)
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
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


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub ScanListReports_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Me.Close()
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
        'x.TextBox1.Text = "c :\ScanListReport.xls"
        x.TextBox1.Text = ".\ScanListReport.xls"
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

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * From " & HRTblPath & "ServiceOffices order by Name"
        Title = "Service Offices"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = Title
            Srch.Text = Title
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
                    utOfficeID.Text = ugRow.Cells("ID").Text
                    utOfficeName.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                End If
            End Try
        End If
    End Sub

    Private Sub utOfficeID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utOfficeID.Leave
        Dim dbRow As DataRow
        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then
            utOfficeID.Text = ""
            utOfficeName.Text = ""
            Exit Sub
        End If
        sender.modified = False
        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, HRTblPath & "ServiceOffices", "where Active = 1") = False Then
                MsgBox("Office Not Found! Please try again.", MsgBoxStyle.OKOnly, "WARNING - Incorrect Input")
                'MsgBox("Office not found.")
                utOfficeID.Text = ""
                utOfficeName.Text = ""
                sender.Focus()
                Exit Sub
            End If
            utOfficeName.Text = dbRow.Item("NAME")
            sender.Modified = False
            'ucboCompany.Focus()
            btnDisplay.Focus()
            dbRow = Nothing
        End If
    End Sub

    Private Sub utOfficeName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utOfficeName.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utOfficeID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, utOfficeID, HRTblPath & "ServiceOffices", "ID", "Name", "*", "Service Offices", " Where Active = 1 ") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
                'ucboCompany.Focus()
                btnDisplay.Focus()

            Else
                'MsgBox("Truck Not Found.")
                utOfficeID.Text = ""
                utOfficeName.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utOfficeName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utOfficeName.KeyUp
        TypeAhead(sender, e, HRTblPath & "ServiceOffices", "Name", " Where Active = 1 ")

    End Sub
    Private Sub utOfficeid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utOfficeID.TextChanged
        Dim row As DataRow

        If GlobalVars.ReturnRowByID(utOfficeID.Text.Trim, row, HRTblPath & "ServiceOffices") Then
            utOfficeName.Text = row("Name")
        End If
        row = Nothing
    End Sub

    Private Sub cbOffice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOffice.CheckedChanged
        If cbOffice.Checked = True Then
            utOfficeID.Text = ""
            utOfficeID.Enabled = True
            utOfficeName.Text = ""
            btnSelect.Enabled = True
        Else
            utOfficeID.Text = ""
            utOfficeID.Enabled = False
            utOfficeName.Text = ""
            btnSelect.Enabled = False
        End If
    End Sub
    Private Sub UltraGrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown
        On Error GoTo ErrLabel

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement
            Dim oUIElement As Infragistics.Win.UIElement
            Dim oUIElementTmp As Infragistics.Win.UIElement
            Dim point As Point = New Point(e.X, e.Y)


            oUIElement = Me.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(point)
            If oUIElement Is Nothing Then Exit Sub

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

   
End Class
