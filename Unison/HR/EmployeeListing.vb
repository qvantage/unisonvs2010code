Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class EmployeeListing
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
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents utOfficeName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utOfficeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnOffice As System.Windows.Forms.Button
    Friend WithEvents uopOffice As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents uopCompany As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents ucboCompany As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents utEmployee As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utEmployeeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uopEmployee As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents btnEmployee As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents uopRepStyle As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents uchExpand As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uchDeduction As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.uchDeduction = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.uchExpand = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.uopRepStyle = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.utOfficeName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utOfficeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnOffice = New System.Windows.Forms.Button
        Me.uopOffice = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.uopCompany = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.ucboCompany = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.utEmployee = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utEmployeeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uopEmployee = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.btnEmployee = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.uopRepStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.utOfficeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.uopCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utEmployeeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.uchDeduction)
        Me.GroupBox1.Controls.Add(Me.uchExpand)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(815, 200)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'uchDeduction
        '
        Me.uchDeduction.Location = New System.Drawing.Point(168, 168)
        Me.uchDeduction.Name = "uchDeduction"
        Me.uchDeduction.Size = New System.Drawing.Size(168, 20)
        Me.uchDeduction.TabIndex = 5
        Me.uchDeduction.Text = "Show Only With Deductions"
        '
        'uchExpand
        '
        Me.uchExpand.Location = New System.Drawing.Point(8, 168)
        Me.uchExpand.Name = "uchExpand"
        Me.uchExpand.Size = New System.Drawing.Size(131, 20)
        Me.uchExpand.TabIndex = 4
        Me.uchExpand.Text = "Expand Rows"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.uopRepStyle)
        Me.GroupBox5.Location = New System.Drawing.Point(456, 17)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(248, 72)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'uopRepStyle
        '
        Appearance1.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopRepStyle.Appearance = Appearance1
        Me.uopRepStyle.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopRepStyle.ItemAppearance = Appearance2
        ValueListItem1.DataValue = "AIO"
        ValueListItem1.DisplayText = "All in One Row (Shows Duplicate Rows)"
        ValueListItem2.DataValue = "Seggregated"
        ValueListItem2.DisplayText = "Segregated Pay Rate and Deduction Info"
        Me.uopRepStyle.Items.Add(ValueListItem1)
        Me.uopRepStyle.Items.Add(ValueListItem2)
        Me.uopRepStyle.ItemSpacingVertical = 7
        Me.uopRepStyle.Location = New System.Drawing.Point(6, 16)
        Me.uopRepStyle.Name = "uopRepStyle"
        Me.uopRepStyle.Size = New System.Drawing.Size(234, 46)
        Me.uopRepStyle.TabIndex = 0
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(712, 64)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(88, 21)
        Me.btnExcel.TabIndex = 8
        Me.btnExcel.Text = "Export to E&xcel"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(712, 38)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 21)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "&Print"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(712, 13)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 6
        Me.btnDisplay.Text = "D&isplay"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.utOfficeName)
        Me.GroupBox4.Controls.Add(Me.utOfficeID)
        Me.GroupBox4.Controls.Add(Me.btnOffice)
        Me.GroupBox4.Controls.Add(Me.uopOffice)
        Me.GroupBox4.Location = New System.Drawing.Point(353, 91)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(448, 72)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'utOfficeName
        '
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOfficeName.Appearance = Appearance3
        Me.utOfficeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeName.Location = New System.Drawing.Point(91, 39)
        Me.utOfficeName.Name = "utOfficeName"
        Me.utOfficeName.Size = New System.Drawing.Size(176, 21)
        Me.utOfficeName.TabIndex = 1
        Me.utOfficeName.Tag = ""
        '
        'utOfficeID
        '
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOfficeID.Appearance = Appearance4
        Me.utOfficeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeID.Location = New System.Drawing.Point(275, 39)
        Me.utOfficeID.Name = "utOfficeID"
        Me.utOfficeID.Size = New System.Drawing.Size(40, 21)
        Me.utOfficeID.TabIndex = 2
        Me.utOfficeID.Tag = ".OfficeID"
        '
        'btnOffice
        '
        Me.btnOffice.Location = New System.Drawing.Point(340, 39)
        Me.btnOffice.Name = "btnOffice"
        Me.btnOffice.Size = New System.Drawing.Size(75, 20)
        Me.btnOffice.TabIndex = 3
        Me.btnOffice.TabStop = False
        Me.btnOffice.Text = "Selec&t"
        '
        'uopOffice
        '
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopOffice.Appearance = Appearance5
        Me.uopOffice.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopOffice.ItemAppearance = Appearance6
        ValueListItem3.DataValue = "All Offices"
        ValueListItem3.DisplayText = "All Offices"
        ValueListItem4.DataValue = "By Office"
        ValueListItem4.DisplayText = "By Office"
        Me.uopOffice.Items.Add(ValueListItem3)
        Me.uopOffice.Items.Add(ValueListItem4)
        Me.uopOffice.ItemSpacingVertical = 7
        Me.uopOffice.Location = New System.Drawing.Point(16, 16)
        Me.uopOffice.Name = "uopOffice"
        Me.uopOffice.Size = New System.Drawing.Size(72, 46)
        Me.uopOffice.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.uopCompany)
        Me.GroupBox3.Controls.Add(Me.ucboCompany)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 91)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(344, 72)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'uopCompany
        '
        Appearance7.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopCompany.Appearance = Appearance7
        Me.uopCompany.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopCompany.ItemAppearance = Appearance8
        ValueListItem5.DataValue = "All Companies"
        ValueListItem5.DisplayText = "All Companies"
        ValueListItem6.DataValue = "By Company"
        ValueListItem6.DisplayText = "By Company"
        Me.uopCompany.Items.Add(ValueListItem5)
        Me.uopCompany.Items.Add(ValueListItem6)
        Me.uopCompany.ItemSpacingVertical = 7
        Me.uopCompany.Location = New System.Drawing.Point(16, 16)
        Me.uopCompany.Name = "uopCompany"
        Me.uopCompany.Size = New System.Drawing.Size(96, 46)
        Me.uopCompany.TabIndex = 0
        '
        'ucboCompany
        '
        Appearance9.BackColorDisabled = System.Drawing.Color.Silver
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboCompany.Appearance = Appearance9
        Me.ucboCompany.AutoEdit = False
        Me.ucboCompany.DisplayMember = ""
        Me.ucboCompany.Location = New System.Drawing.Point(112, 38)
        Me.ucboCompany.Name = "ucboCompany"
        Me.ucboCompany.Size = New System.Drawing.Size(208, 21)
        Me.ucboCompany.TabIndex = 1
        Me.ucboCompany.Tag = ".Company..1.Companies.Company.Company"
        Me.ucboCompany.ValueMember = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.utEmployee)
        Me.GroupBox2.Controls.Add(Me.utEmployeeID)
        Me.GroupBox2.Controls.Add(Me.uopEmployee)
        Me.GroupBox2.Controls.Add(Me.btnEmployee)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(448, 72)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'utEmployee
        '
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.ForeColorDisabled = System.Drawing.Color.Black
        Me.utEmployee.Appearance = Appearance10
        Me.utEmployee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployee.Enabled = False
        Me.utEmployee.Location = New System.Drawing.Point(176, 40)
        Me.utEmployee.Name = "utEmployee"
        Me.utEmployee.Size = New System.Drawing.Size(176, 21)
        Me.utEmployee.TabIndex = 2
        Me.utEmployee.Tag = ""
        '
        'utEmployeeID
        '
        Appearance11.ForeColor = System.Drawing.Color.Black
        Appearance11.ForeColorDisabled = System.Drawing.Color.Black
        Me.utEmployeeID.Appearance = Appearance11
        Me.utEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployeeID.Location = New System.Drawing.Point(112, 40)
        Me.utEmployeeID.Name = "utEmployeeID"
        Me.utEmployeeID.Size = New System.Drawing.Size(56, 21)
        Me.utEmployeeID.TabIndex = 1
        Me.utEmployeeID.Tag = ".OfficeID"
        '
        'uopEmployee
        '
        Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopEmployee.Appearance = Appearance12
        Me.uopEmployee.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopEmployee.ItemAppearance = Appearance13
        ValueListItem7.DataValue = "All Employees"
        ValueListItem7.DisplayText = "All Employees"
        ValueListItem8.DataValue = "By Employee"
        ValueListItem8.DisplayText = "By Employee"
        Me.uopEmployee.Items.Add(ValueListItem7)
        Me.uopEmployee.Items.Add(ValueListItem8)
        Me.uopEmployee.ItemSpacingVertical = 7
        Me.uopEmployee.Location = New System.Drawing.Point(16, 16)
        Me.uopEmployee.Name = "uopEmployee"
        Me.uopEmployee.Size = New System.Drawing.Size(96, 46)
        Me.uopEmployee.TabIndex = 0
        '
        'btnEmployee
        '
        Me.btnEmployee.Location = New System.Drawing.Point(360, 41)
        Me.btnEmployee.Name = "btnEmployee"
        Me.btnEmployee.Size = New System.Drawing.Size(75, 20)
        Me.btnEmployee.TabIndex = 3
        Me.btnEmployee.Text = "Select"
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
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 200)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(815, 388)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Tag = "EmployeeListingGrid"
        Me.UltraGrid1.Text = "Employee Listing"
        '
        'EmployeeListing
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(815, 588)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Menu = Me.MainMenu1
        Me.Name = "EmployeeListing"
        Me.Tag = "EmployeeListing"
        Me.Text = "Employee Listing"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.uopRepStyle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.utOfficeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopOffice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.uopCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utEmployeeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub EmployeeListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        'AddHandler utStartMile.KeyPress, AddressOf Value_Int_KeyPress
        'AddHandler utInvoiceNo.KeyPress, AddressOf Value_Int_KeyPress
        '
        'cmdTrans = Nothing

        'UltraDate1.Nullable = True
        'UltraDate1.Value = Date.Today 'DateAdd(DateInterval.Day, -1, Date.Today)
        'UltraDate1.FormatString = "MM/dd/yyyy"

        'UltraDate2.Nullable = True
        'UltraDate2.Value = Date.Today 'DateAdd(DateInterval.Day, -1, Date.Today)
        'UltraDate2.FormatString = "MM/dd/yyyy"

        utEmployeeID.MaxLength = 6
        utEmployeeID.Enabled = False
        utEmployee.Enabled = False
        btnEmployee.Enabled = False

        utOfficeID.Enabled = False
        utOfficeName.Enabled = False
        btnEmployee.Enabled = False

        ucboCompany.Enabled = False

        UltraGrid1.Text = "HR Pay Period Listing"

        uopEmployee.CheckedIndex = 0 ' All
        uopCompany.CheckedIndex = 0 ' All
        uopOffice.CheckedIndex = 0 ' All
        uopRepStyle.CheckedIndex = 0 'AIO

        FillUCombo(ucboCompany, "", "", "", HRTblPath)
        AddHandler ucboCompany.Leave, AddressOf UCbo_Leave

    End Sub

    Private Sub utEmployeeID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utEmployeeID.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utEmployeeID"
                gAcct = utEmployee
                gAcctID = utEmployeeID
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
            If SearchOnLeave(sender, gAcctID, "" & HRTblPath & "EmployeesBase", "ID", "ID", "*", "Employees", "") Then
                If ReturnRowByID(gAcctID.Text, row, HRTblPath & "EmployeesBase", "", "ID") Then
                    gAcct.Text = row("FirstName") & " " & row("LastName")
                    row = Nothing
                Else
                    MsgBox("Employee Not Found.")
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

    Private Sub btnEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployee.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Select Case sender.Name
            Case "btnEmployee"
                gAcct = utEmployee
                gAcctID = utEmployeeID
            Case Else
                MsgBox("Unknown Button")
                Exit Sub
        End Select

        SelectSQL = "Select * from " & HRTblPath & "EmployeesBase i order by ID "

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

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
                    gAcct.Text = ugRow.Cells("FirstName").Text & " " & ugRow.Cells("LastName").Text
                    gAcctID.Text = ugRow.Cells("ID").Text
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

    Private Sub uopEmployee_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uopEmployee.ValueChanged
        Select Case uopEmployee.CheckedIndex
            Case 0 ' All Employees
                utEmployee.Text = ""
                utEmployeeID.Text = ""
                utEmployeeID.Enabled = False
                btnEmployee.Enabled = False

            Case 1 ' By Employee
                'utEmployee.Enabled = True
                utEmployeeID.Enabled = True
                btnEmployee.Enabled = True
        End Select

    End Sub

    Private Sub uopCompany_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopCompany.ValueChanged
        Select Case uopCompany.CheckedIndex
            Case 0 ' All 
                ucboCompany.Text = ""
                ucboCompany.Value = Nothing

                ucboCompany.Enabled = False

            Case 1 ' By Company
                ucboCompany.Enabled = True
        End Select
    End Sub

    Private Sub uopOffice_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uopOffice.ValueChanged
        Select Case uopOffice.CheckedIndex
            Case 0 ' All 
                utOfficeName.Text = ""
                utOfficeID.Text = ""
                utOfficeName.Enabled = False
                utOfficeID.Enabled = False
                btnOffice.Enabled = False

            Case 1 ' By Employee
                utOfficeName.Enabled = True
                utOfficeID.Enabled = True
                btnOffice.Enabled = True
        End Select

    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOffice.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * From " & HRTblPath & "ServiceOffices WHERE ID in (SELECT OfficeID FROM " & CFGTblPath & "UN_HRTimeCardOfficeRights WHERE UserID = '" & LoginInfo.UserID & "') order by Name"
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
            If ReturnRowByID(Val(sender.Text), dbRow, HRTblPath & "ServiceOffices", "Where Active = 1 AND ID in (SELECT OfficeID FROM " & CFGTblPath & "UN_HRTimeCardOfficeRights WHERE UserID = '" & LoginInfo.UserID & "')") = False Then
                MsgBox("Account not found.")
                utOfficeID.Text = ""
                utOfficeName.Text = ""
                sender.Focus()
                Exit Sub
            End If
            utOfficeName.Text = dbRow.Item("NAME")
            sender.Modified = False
            ucboCompany.Focus()
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
            If SearchOnLeave(sender, utOfficeID, HRTblPath & "ServiceOffices", "ID", "Name", "*", "Service Offices", " Where Active = 1 AND ID in (SELECT OfficeID FROM " & CFGTblPath & "UN_HRTimeCardOfficeRights WHERE UserID = '" & LoginInfo.UserID & "')") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
                ucboCompany.Focus()
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
        TypeAhead(sender, e, HRTblPath & "ServiceOffices", "Name", " Where Active = 1 AND ID in (SELECT OfficeID FROM " & CFGTblPath & "UN_HRTimeCardOfficeRights WHERE UserID = '" & LoginInfo.UserID & "')")

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Hide the Columns for not Printing - WORKING
        'UltraGrid1.DataSource = dtSet
        'UltraGrid1.DataBind()
        'UltraGrid1.DisplayLayout.Bands(0).Columns(0).Hidden = True

        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim i As Integer
        Dim hideGridColumnNum As Integer
        Dim SelectSQL As String = "SELECT ID FROM " & HRTblPath & "HREmployeeListingField WHERE [Print/Export] = 0"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)

        For i = 0 To dtSet.Tables(0).Rows.Count - 1
            hideGridColumnNum = dtSet.Tables(0).Columns(0).Table.Rows(i).ItemArray(0)
            UltraGrid1.DisplayLayout.Bands(0).Columns(hideGridColumnNum - 1).Hidden = True
        Next i
        UltraGrid1.PrintPreview(Infragistics.Win.UltraWinGrid.RowPropertyCategories.All)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim x As New EnterTextBox
        Dim FileName As String

        On Error GoTo ErrTrap

        If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        'Hide the Columns for not Printing - WORKING
        'UltraGrid1.DataSource = dtSet
        'UltraGrid1.DataBind()
        'UltraGrid1.DisplayLayout.Bands(0).Columns(0).Hidden = True

        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim i As Integer
        Dim hideGridColumnNum As Integer
        Dim SelectSQL As String = "SELECT ID FROM " & HRTblPath & "HREmployeeListingField WHERE [Print/Export] = 0"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)

        For i = 0 To dtSet.Tables(0).Rows.Count - 1
            hideGridColumnNum = dtSet.Tables(0).Columns(0).Table.Rows(i).ItemArray(0)
            UltraGrid1.DisplayLayout.Bands(0).Columns(hideGridColumnNum - 1).Hidden = True
        Next i

        x.Label1.Text = "File Name:"
        x.Label2.Text = ""
        x.Label2.Visible = False
        x.btnBrowse1.Visible = True

        x.Text = "File Name"
        x.TextBox1.Enabled = True
        'x.TextBox1.Text = "c :\EmployeeListing.xls"
        x.TextBox1.Text = ".\EmployeeListing.xls"
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
    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, DateRngCond, EmplCond, CompCond, OfficeCond, DedJoinCond, DedCond, SummCol As String
        Dim sqlEmployee, sqlPayRates, sqlDeductions As String



        SQLSelect = "Select eb.Company, eb.OfficeID, so.Name as Office, eb.ID As EmployeeID " & _
                    " , eb.FirstName, eb.MiddleName, eb.LastName, eb.Status, eb.StatusDate, eb.CreateDate, eb.HireDate " & _
                    " , ep.DeptNo, ep.PayRate " & _
                    ",  ep.MileageRate, sofs.FuelSurcharge_Rate " & _
                    " , ep.WCCode, ep.ClassID, cl.Class " & _
                    " , d.Deduction, ed.Amount " & _
                    " , ei.DOB, ei.Gender, ei.Race, ei.Address1, ei.Address2, ei.City, ei.State, ei.Zip, ei.Phone, ei.Phone2 as Emrg_Phone " & _
                    " , ei.Cell, ei.email, ei.DLN, ei.DLExpDate, ei.AutoInsPolNum as Auto_Pol_Num, ei.AutoInsExpDate as AutoIns_ExpDate " & _
                    " , ei.Marital_Status  " & _
                    " FROM " & HRTblPath & "EmployeesBase eb " & _
                    " Left Outer Join " & HRTblPath & "EmployeeInfo ei On eb.ID = ei.EmployeeID " & _
                    " Left Outer Join " & HRTblPath & "EmployeePayRates ep On eb.ID = ep.EmployeeID " & _
                    " @DEDJOIN " & HRTblPath & "EmployeeDeductions ed On eb.ID = ed.EmployeeID " & _
                    " Left Outer Join " & HRTblPath & "ServiceOffices so On eb.OfficeID = so.ID " & _
                    " Left Outer Join " & HRTblPath & "ServiceOffice_FS sofs On eb.OfficeID = sofs.OfficeID " & _
                    " Left Outer Join " & HRTblPath & "CLASSES cl On ep.ClassID = cl.ClassID " & _
                    " Left Outer Join " & HRTblPath & "Deductions d On ed.DeductionID = d.DeductionID " & _
                    " WHERE @EMPLID @COMP @OFFICE " & _
                    " ORDER BY eb.Company, so.Name, eb.ID "

        sqlEmployee = "Select eb.Company, eb.OfficeID, so.Name as Office, eb.ID As EmployeeID " & _
                    " , eb.FirstName, eb.MiddleName, eb.LastName, eb.Status, eb.StatusDate, eb.CreateDate, eb.HireDate " & _
                    ",  sofs.FuelSurcharge_Rate " & _
                    " , ei.DOB, ei.Gender, ei.Race, ei.Address1, ei.Address2, ei.City, ei.State, ei.Zip, ei.Phone, ei.Phone2 as Emrg_Phone " & _
                    " , ei.Cell, ei.email, ei.DLN, ei.DLExpDate, ei.AutoInsPolNum as Auto_Pol_Num, ei.AutoInsExpDate as AutoIns_ExpDate " & _
                    " , ei.Marital_Status  " & _
                    " FROM " & HRTblPath & "EmployeesBase eb " & _
                    " Left Outer Join " & HRTblPath & "EmployeeInfo ei On eb.ID = ei.EmployeeID " & _
                    " Left Outer Join " & HRTblPath & "ServiceOffices so On eb.OfficeID = so.ID " & _
                    " Left Outer Join " & HRTblPath & "ServiceOffice_FS sofs On eb.OfficeID = sofs.OfficeID " & _
                    " WHERE @EMPLID @COMP @OFFICE @DEDUCT " & _
                    " ORDER BY eb.Company, so.Name, eb.ID "

        sqlPayRates = "Select ep.EmployeeID " & _
                    " , ep.DeptNo, ep.PayRate " & _
                    ",  ep.MileageRate " & _
                    " , ep.WCCode, wc.WCTitle, ep.ClassID, cl.Class " & _
                    " FROM " & HRTblPath & "EmployeePayRates ep " & _
                    " Left Outer Join " & HRTblPath & "CLASSES cl On ep.ClassID = cl.ClassID " & _
                    " Left Outer Join " & HRTblPath & "WCCodes wc On ep.WCCode = wc.WCCOde " & _
                    " Left Outer Join " & HRTblPath & "EmployeesBase eb On ep.EmployeeID = eb.ID " & _
                    " Left Outer Join " & HRTblPath & "ServiceOffices so On eb.OfficeID = so.ID " & _
                    " WHERE @EMPLID @COMP @OFFICE " & _
                    " ORDER BY eb.Company, so.Name, eb.ID "

        sqlDeductions = "Select ed.EmployeeID " & _
                    " , d.Deduction, ed.Amount " & _
                    " FROM " & HRTblPath & "EmployeeDeductions ed " & _
                    " Left Outer Join " & HRTblPath & "EmployeesBase eb On ed.EmployeeID = eb.ID " & _
                    " Left Outer Join " & HRTblPath & "ServiceOffices so On eb.OfficeID = so.ID " & _
                    " Left Outer Join " & HRTblPath & "Deductions d On ed.DeductionID = d.DeductionID " & _
                    " WHERE @EMPLID @COMP @OFFICE " & _
                    " ORDER BY eb.Company, so.Name, eb.ID "

        'If UltraDate1.Value Is Nothing Then
        '    MsgBox("Period Date is not set.")
        '    Exit Sub
        'End If
        'If UltraDate2.Value Is Nothing Then
        '    MsgBox("ToDate is not set.")
        '    Exit Sub
        'End If
        'SQLSelect = SQLSelect.Replace("@DATERNG", "AND CONVERT(datetime, CONVERT(varchar, e.ScanDate, 101)) between '" & UltraDate1.Text & "' AND dateadd(d, 1,'" & UltraDate2.Text & "')")
        'DateRngCond = " ea.PayrollDate >= '" & UltraDate1.Text & "' AND  ea.PayrollDate < dateadd(d, 1,'" & UltraDate2.Text & "')"
        ' Moved to the last step
        'SQLSelect = SQLSelect.Replace("@DATERNG", DateRngCond)
        Select Case uopEmployee.CheckedIndex
            Case 0 'All Employees
                EmplCond = " eb.ID like '%' "
            Case 1 'By Employee
                If utEmployeeID.Text.Trim = "" Then
                    MsgBox("Employee not selected.")
                    Exit Sub
                End If
                EmplCond = " eb.ID = '" & utEmployeeID.Text.Trim & "'"
        End Select

        Select Case uopCompany.CheckedIndex
            Case 0 'All Companies
                CompCond = ""
            Case 1 'By Company
                If ucboCompany.Value Is Nothing Or ucboCompany.Text.Trim = "" Then
                    MsgBox("Company not selected.")
                    Exit Sub
                End If
                CompCond = " AND eb.Company = '" & ucboCompany.Value & "'"
        End Select

        Select Case uopOffice.CheckedIndex
            Case 0 'All Offices
                'Dim DBUserName As String = LoginInfo.UserID
                OfficeCond = " AND eb.OfficeID in (SELECT OfficeID FROM " & CFGTblPath & "UN_HRTimeCardOfficeRights WHERE UserID = '" & LoginInfo.UserID & "')"
            Case 1 'By Office
                If utOfficeID.Text.Trim = "" Then
                    MsgBox("Office not selected.")
                    Exit Sub
                End If
                OfficeCond = " AND eb.OfficeID = '" & utOfficeID.Text.Trim & "'"
        End Select
        Select Case uchDeduction.Checked
            Case True
                DedJoinCond = " INNER JOIN "
                sqlPayRates = ""
                DedCond = " AND eb.ID in (Select distinct EmployeeID from " & HRTblPath & "EmployeeDeductions ed)"
            Case False
                DedJoinCond = " Left Outer Join "
                DedCond = ""
        End Select

        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If


        ' Moved From Top to cover any changes to date selection that each option may need
        'SQLSelect = SQLSelect.Replace("@PAYDATE", DateRngCond)


        Select Case uopRepStyle.CheckedIndex
            Case 0 ' AIO
                SQLSelect = SQLSelect.Replace("@EMPLID", EmplCond)
                SQLSelect = SQLSelect.Replace("@COMP", CompCond)
                SQLSelect = SQLSelect.Replace("@OFFICE", OfficeCond)
                SQLSelect = SQLSelect.Replace("@DEDJOIN", DedJoinCond)

                PopulateDataset2(dtAdapter, dtSet, SQLSelect)

                uchExpand.Checked = False
                uchExpand.Enabled = True

            Case 1 'Seg
                sqlEmployee = sqlEmployee.Replace("@EMPLID", EmplCond)
                sqlEmployee = sqlEmployee.Replace("@COMP", CompCond)
                sqlEmployee = sqlEmployee.Replace("@OFFICE", OfficeCond)
                sqlEmployee = sqlEmployee.Replace("@DEDUCT", DedCond)

                sqlPayRates = sqlPayRates.Replace("@EMPLID", EmplCond)
                sqlPayRates = sqlPayRates.Replace("@COMP", CompCond)
                sqlPayRates = sqlPayRates.Replace("@OFFICE", OfficeCond)

                sqlDeductions = sqlDeductions.Replace("@EMPLID", EmplCond)
                sqlDeductions = sqlDeductions.Replace("@COMP", CompCond)
                sqlDeductions = sqlDeductions.Replace("@OFFICE", OfficeCond)

                PopulateDataset2(dtAdapter, dtSet, sqlEmployee)
                PopulateDataset2(dtAdapter, dtSet, sqlPayRates, True)
                PopulateDataset2(dtAdapter, dtSet, sqlDeductions, True)

                Dim CustRel As DataRelation

                Dim ParentCols(0), ChildColsPay(0), ChildColsDed(0) As DataColumn

                ParentCols(0) = dtSet.Tables(0).Columns("EmployeeID")

                ChildColsPay(0) = dtSet.Tables(1).Columns("EmployeeID")
                dtSet.Relations.Add("CustRelP", ParentCols, ChildColsPay)

                If sqlPayRates <> "" Then
                    ChildColsDed(0) = dtSet.Tables(2).Columns("EmployeeID")
                    dtSet.Relations.Add("CustRelD", ParentCols, ChildColsDed)
                End If



                uchExpand.Checked = False
                uchExpand.Enabled = True
        End Select

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid1, dtSet, -1, HidCols, 0)
        'UltraGrid1.DataSource = dtSet
        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
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

        SummCol = "EmployeeID"
        UltraGrid1.DisplayLayout.Bands(0).Summaries.Add(SummCol, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns(SummCol), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid1.DisplayLayout.Bands(0).Summaries(SummCol).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        'UltraGrid1.Text = "Packages"
    End Sub

    ' =============================================================================================
    ' ==================================     MENU ROUTINES     ====================================
    ' =============================================================================================

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

    Private Sub uopRepStyle_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uopRepStyle.ValueChanged

        'Select Case uopRepStyle.CheckedIndex
        '    Case 0 'AIO
        '        uchExpand.Checked = False
        '        uchExpand.Enabled = False
        'End Select
    End Sub

    Private Sub uchExpand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchExpand.CheckedChanged
        Select Case uchExpand.Checked
            Case True
                Me.UltraGrid1.Rows.ExpandAll(True)
            Case False
                Me.UltraGrid1.Rows.CollapseAll(True)
        End Select
    End Sub

    Private Sub utEmployeeID_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles utEmployeeID.ValueChanged, utOfficeName.ValueChanged, utOfficeID.ValueChanged
        Select Case sender.name
            Case "utEmployeeID"
                If utEmployeeID.Text = "" Then utEmployee.Text = ""
            Case "utOfficeName"
                If utOfficeName.Text = "" Then utOfficeID.Text = ""
            Case "utOfficeID"
                If utOfficeID.Text = "" Then utOfficeName.Text = ""

        End Select
    End Sub
End Class
