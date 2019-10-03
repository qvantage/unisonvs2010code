Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Public Class TimeCardListing
    Inherits System.Windows.Forms.Form

    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

    Dim TemplateID As Integer
    Dim Template As String

#Region "Private Members"

    Private _strCondition, _strWhereOrganization, _strWhereDate, _strWhereEmployee As String
    Private MeText As String
    Private _strError As String

#End Region

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents uopEmployee As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents lblEmpName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uopCompany As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents ucboDivision As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ucboOffice As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents udtPayrollEnding As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtFrom As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtTo As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtWeekEnding As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ulblTo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents utEmployeeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnEmployee As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents uopDate As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cbActiveOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnTimeVerification As System.Windows.Forms.Button
    Friend WithEvents btnComplianceCheck As System.Windows.Forms.Button
    Friend WithEvents btnBreakAnalysis As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbActiveOnly = New System.Windows.Forms.CheckBox
        Me.utEmployeeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnEmployee = New System.Windows.Forms.Button
        Me.lblEmpName = New Infragistics.Win.Misc.UltraLabel
        Me.lblName = New Infragistics.Win.Misc.UltraLabel
        Me.uopEmployee = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ucboOffice = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ucboDivision = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.uopCompany = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ulblTo = New Infragistics.Win.Misc.UltraLabel
        Me.udtWeekEnding = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.udtTo = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.udtFrom = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.udtPayrollEnding = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.uopDate = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnBreakAnalysis = New System.Windows.Forms.Button
        Me.btnComplianceCheck = New System.Windows.Forms.Button
        Me.btnTimeVerification = New System.Windows.Forms.Button
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.GroupBox1.SuspendLayout()
        CType(Me.utEmployeeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ucboOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.udtWeekEnding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtPayrollEnding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbActiveOnly)
        Me.GroupBox1.Controls.Add(Me.utEmployeeID)
        Me.GroupBox1.Controls.Add(Me.btnEmployee)
        Me.GroupBox1.Controls.Add(Me.lblEmpName)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Controls.Add(Me.uopEmployee)
        Me.GroupBox1.Location = New System.Drawing.Point(622, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 91)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'cbActiveOnly
        '
        Me.cbActiveOnly.Checked = True
        Me.cbActiveOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbActiveOnly.Location = New System.Drawing.Point(248, 37)
        Me.cbActiveOnly.Name = "cbActiveOnly"
        Me.cbActiveOnly.Size = New System.Drawing.Size(82, 24)
        Me.cbActiveOnly.TabIndex = 152
        Me.cbActiveOnly.Text = "Active Only"
        Me.cbActiveOnly.Visible = False
        '
        'utEmployeeID
        '
        Me.utEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployeeID.Location = New System.Drawing.Point(107, 38)
        Me.utEmployeeID.Name = "utEmployeeID"
        Me.utEmployeeID.Size = New System.Drawing.Size(72, 21)
        Me.utEmployeeID.TabIndex = 150
        Me.utEmployeeID.Tag = ".EmployeeID"
        '
        'btnEmployee
        '
        Me.btnEmployee.Location = New System.Drawing.Point(181, 36)
        Me.btnEmployee.Name = "btnEmployee"
        Me.btnEmployee.Size = New System.Drawing.Size(48, 24)
        Me.btnEmployee.TabIndex = 151
        Me.btnEmployee.TabStop = False
        Me.btnEmployee.Text = "Se&lect"
        '
        'lblEmpName
        '
        Appearance1.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance1.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblEmpName.Appearance = Appearance1
        Me.lblEmpName.Location = New System.Drawing.Point(111, 63)
        Me.lblEmpName.Name = "lblEmpName"
        Me.lblEmpName.Size = New System.Drawing.Size(197, 17)
        Me.lblEmpName.TabIndex = 148
        '
        'lblName
        '
        Appearance2.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance2.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblName.Appearance = Appearance2
        Me.lblName.Location = New System.Drawing.Point(52, 63)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(40, 16)
        Me.lblName.TabIndex = 149
        Me.lblName.Text = "Name"
        '
        'uopEmployee
        '
        Appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopEmployee.Appearance = Appearance3
        Me.uopEmployee.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopEmployee.ItemAppearance = Appearance4
        ValueListItem1.DataValue = "All Employees"
        ValueListItem1.DisplayText = "All Employees"
        ValueListItem2.DataValue = "By Employee"
        ValueListItem2.DisplayText = "By Employee"
        Me.uopEmployee.Items.Add(ValueListItem1)
        Me.uopEmployee.Items.Add(ValueListItem2)
        Me.uopEmployee.ItemSpacingVertical = 9
        Me.uopEmployee.Location = New System.Drawing.Point(8, 16)
        Me.uopEmployee.Name = "uopEmployee"
        Me.uopEmployee.Size = New System.Drawing.Size(96, 48)
        Me.uopEmployee.TabIndex = 146
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ucboOffice)
        Me.GroupBox2.Controls.Add(Me.ucboDivision)
        Me.GroupBox2.Controls.Add(Me.uopCompany)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 91)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'ucboOffice
        '
        Me.ucboOffice.DisplayMember = ""
        Me.ucboOffice.Location = New System.Drawing.Point(112, 64)
        Me.ucboOffice.Name = "ucboOffice"
        Me.ucboOffice.Size = New System.Drawing.Size(104, 21)
        Me.ucboOffice.TabIndex = 149
        Me.ucboOffice.Tag = ".Division...Divisions.Division.Division"
        Me.ucboOffice.ValueMember = ""
        '
        'ucboDivision
        '
        Me.ucboDivision.DisplayMember = ""
        Me.ucboDivision.Location = New System.Drawing.Point(112, 39)
        Me.ucboDivision.Name = "ucboDivision"
        Me.ucboDivision.Size = New System.Drawing.Size(104, 21)
        Me.ucboDivision.TabIndex = 148
        Me.ucboDivision.Tag = ".Division...Divisions.Division.Division"
        Me.ucboDivision.ValueMember = ""
        '
        'uopCompany
        '
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopCompany.Appearance = Appearance5
        Me.uopCompany.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopCompany.ItemAppearance = Appearance6
        ValueListItem3.DataValue = "Whole Company"
        ValueListItem3.DisplayText = "Whole Company"
        ValueListItem4.DataValue = "By Division"
        ValueListItem4.DisplayText = "By Division"
        ValueListItem5.DataValue = "By Office"
        ValueListItem5.DisplayText = "By Office"
        Me.uopCompany.Items.Add(ValueListItem3)
        Me.uopCompany.Items.Add(ValueListItem4)
        Me.uopCompany.Items.Add(ValueListItem5)
        Me.uopCompany.ItemSpacingVertical = 9
        Me.uopCompany.Location = New System.Drawing.Point(8, 16)
        Me.uopCompany.Name = "uopCompany"
        Me.uopCompany.Size = New System.Drawing.Size(104, 64)
        Me.uopCompany.TabIndex = 147
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ulblTo)
        Me.GroupBox3.Controls.Add(Me.udtWeekEnding)
        Me.GroupBox3.Controls.Add(Me.udtTo)
        Me.GroupBox3.Controls.Add(Me.udtFrom)
        Me.GroupBox3.Controls.Add(Me.udtPayrollEnding)
        Me.GroupBox3.Controls.Add(Me.uopDate)
        Me.GroupBox3.Location = New System.Drawing.Point(264, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(352, 91)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'ulblTo
        '
        Appearance7.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance7.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblTo.Appearance = Appearance7
        Me.ulblTo.Location = New System.Drawing.Point(212, 18)
        Me.ulblTo.Name = "ulblTo"
        Me.ulblTo.Size = New System.Drawing.Size(24, 16)
        Me.ulblTo.TabIndex = 153
        Me.ulblTo.Text = "To"
        '
        'udtWeekEnding
        '
        Me.udtWeekEnding.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtWeekEnding.Location = New System.Drawing.Point(112, 64)
        Me.udtWeekEnding.Name = "udtWeekEnding"
        Me.udtWeekEnding.Size = New System.Drawing.Size(88, 21)
        Me.udtWeekEnding.TabIndex = 152
        Me.udtWeekEnding.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'udtTo
        '
        Me.udtTo.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtTo.Location = New System.Drawing.Point(256, 16)
        Me.udtTo.Name = "udtTo"
        Me.udtTo.Size = New System.Drawing.Size(88, 21)
        Me.udtTo.TabIndex = 151
        Me.udtTo.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'udtFrom
        '
        Me.udtFrom.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtFrom.Location = New System.Drawing.Point(112, 16)
        Me.udtFrom.Name = "udtFrom"
        Me.udtFrom.Size = New System.Drawing.Size(88, 21)
        Me.udtFrom.TabIndex = 150
        Me.udtFrom.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'udtPayrollEnding
        '
        Me.udtPayrollEnding.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtPayrollEnding.Location = New System.Drawing.Point(112, 40)
        Me.udtPayrollEnding.Name = "udtPayrollEnding"
        Me.udtPayrollEnding.Size = New System.Drawing.Size(88, 21)
        Me.udtPayrollEnding.TabIndex = 149
        Me.udtPayrollEnding.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'uopDate
        '
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopDate.Appearance = Appearance8
        Me.uopDate.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopDate.ItemAppearance = Appearance9
        ValueListItem6.DataValue = "Date Range"
        ValueListItem6.DisplayText = "Date Range"
        ValueListItem7.DataValue = "Payroll Ending"
        ValueListItem7.DisplayText = "Payroll Ending"
        ValueListItem8.DataValue = "Week Ending"
        ValueListItem8.DisplayText = "Week Ending"
        Me.uopDate.Items.Add(ValueListItem6)
        Me.uopDate.Items.Add(ValueListItem7)
        Me.uopDate.Items.Add(ValueListItem8)
        Me.uopDate.ItemSpacingVertical = 9
        Me.uopDate.Location = New System.Drawing.Point(8, 16)
        Me.uopDate.Name = "uopDate"
        Me.uopDate.Size = New System.Drawing.Size(104, 72)
        Me.uopDate.TabIndex = 148
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGrid1.Location = New System.Drawing.Point(8, 147)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(974, 340)
        Me.UltraGrid1.TabIndex = 5
        Me.UltraGrid1.Tag = "HRSINPUTLISTING"
        Me.UltraGrid1.Text = "Time Card Input  Listing"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnBreakAnalysis)
        Me.GroupBox4.Controls.Add(Me.btnComplianceCheck)
        Me.GroupBox4.Controls.Add(Me.btnTimeVerification)
        Me.GroupBox4.Controls.Add(Me.btnExcel)
        Me.GroupBox4.Controls.Add(Me.btnPrint)
        Me.GroupBox4.Controls.Add(Me.btnDisplay)
        Me.GroupBox4.Controls.Add(Me.UltraButton1)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 97)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(953, 47)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'btnBreakAnalysis
        '
        Me.btnBreakAnalysis.Location = New System.Drawing.Point(571, 15)
        Me.btnBreakAnalysis.Name = "btnBreakAnalysis"
        Me.btnBreakAnalysis.Size = New System.Drawing.Size(93, 23)
        Me.btnBreakAnalysis.TabIndex = 168
        Me.btnBreakAnalysis.Text = "Break Analysis"
        '
        'btnComplianceCheck
        '
        Me.btnComplianceCheck.Location = New System.Drawing.Point(453, 16)
        Me.btnComplianceCheck.Name = "btnComplianceCheck"
        Me.btnComplianceCheck.Size = New System.Drawing.Size(112, 23)
        Me.btnComplianceCheck.TabIndex = 167
        Me.btnComplianceCheck.Text = "Compliance Report"
        '
        'btnTimeVerification
        '
        Me.btnTimeVerification.Location = New System.Drawing.Point(338, 16)
        Me.btnTimeVerification.Name = "btnTimeVerification"
        Me.btnTimeVerification.Size = New System.Drawing.Size(109, 23)
        Me.btnTimeVerification.TabIndex = 166
        Me.btnTimeVerification.Text = "Time Verification"
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(240, 16)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(88, 21)
        Me.btnExcel.TabIndex = 165
        Me.btnExcel.Text = "Export to E&xcel"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(128, 16)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 21)
        Me.btnPrint.TabIndex = 164
        Me.btnPrint.Text = "&Print"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(16, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 163
        Me.btnDisplay.Text = "D&isplay"
        '
        'UltraButton1
        '
        Me.UltraButton1.Location = New System.Drawing.Point(816, 17)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.TabIndex = 7
        Me.UltraButton1.Text = "UltraButton1"
        Me.UltraButton1.Visible = False
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
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(0, 0)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(1, 517)
        Me.Splitter2.TabIndex = 6
        Me.Splitter2.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TimeCardListing
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(968, 517)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Menu = Me.MainMenu1
        Me.Name = "TimeCardListing"
        Me.Tag = "TimeCardListingTag"
        Me.Text = "TimeCardListing"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utEmployeeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ucboOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.udtWeekEnding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtPayrollEnding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Common Events"

    Private Sub TimeCardListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'StandardFormPrep()
        StandardFormPrep(Me, MeText, HRTblPath)
        Me.CenterToScreen()

        'Initialize Default Condition Destined for FetchEmployeeActivityDetail
        _strCondition = ""
        uopCompany.CheckedIndex = 0
        uopDate.CheckedIndex = 0
        uopEmployee.CheckedIndex = 0

        'Set Initial Widget Values
        GetDivisions()
        GetOfficeIds()
        SetDefaultRange()
        SetDefaultWeekEnding()
        SetDefaultPayrollEnding()

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        'Validate utEmployeeID
        If _strError <> "" Then
            Beep()
            utEmployeeID.Focus()
            Exit Sub
        End If

        'Reset the condition variable
        _strCondition = ""

        'Construct the Organization Where Clause
        Select Case uopCompany.CheckedIndex
            Case 0 ' Whole Company
                _strWhereOrganization = ""
            Case 1 ' By Division
                If ucboDivision.Text = "" Then
                    _strWhereOrganization = " AND ead.division = NULL "
                Else
                    _strWhereOrganization = " AND ead.division = '" & ucboDivision.Text & "' "
                End If
            Case 2 ' By Office
                'If ucboOffice.Text = "" Then
                '_strWhereOrganization = " AND ead.office = NULL "
                'Else
                If IsNumeric(ucboOffice.Text) Then
                    Dim dataRows As DataRow()
                    Dim dataRow As DataRow
                    dataRows = ucboOffice.DataSource.Select("ID = " & ucboOffice.Text)
                    _strWhereOrganization = " AND ead.office = '" & dataRows(0).Item("Name") & "' "
                Else
                    _strWhereOrganization = " AND ead.office = '" & ucboOffice.Text & "' "
                End If
                'End If
        End Select

        'Construct the Date Where Clause
        Select Case uopDate.CheckedIndex
            Case 0 'Date Range
                _strWhereDate = " AND ead.CheckInDate between CAST('" & udtFrom.DateTime.ToShortDateString & "' AS DATETIME) AND CAST('" & udtTo.DateTime.ToShortDateString & "' AS DATETIME) "
            Case 1 'Payroll Ending
                _strWhereDate = " AND ead.PayrollEnding = CAST('" & udtPayrollEnding.DateTime.ToShortDateString & "' AS DATETIME) "
            Case 2 'Week Ending
                _strWhereDate = "AND ead.WeekEnding = CAST('" & udtWeekEnding.DateTime.ToShortDateString & "' AS DATETIME) "
        End Select

        'Construct the Employee Where Clause
        Select Case uopEmployee.CheckedIndex
            Case 0 'All Employees
                _strWhereEmployee = ""
            Case 1 'By Employee
                _strWhereEmployee = " AND ead.employeeId = " & utEmployeeID.Text
        End Select

        'Construct the final condition statement and populate the Grid
        _strCondition = _strWhereOrganization & _strWhereDate & _strWhereEmployee & " order by ead.EmployeeID, ead.CheckInDate, ead.TimeIn asc "

        PopulateGrid()

    End Sub

    Private Sub btnEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployee.Click

        If uopEmployee.CheckedIndex <> 1 Then
            Exit Sub
        Else
            _strError = ""
        End If

        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim strDivision As String = ""
        Dim iOfficeId As Int32 = 0

        'Clear Error State of utEmployeeID
        If ErrorProvider1.GetError(utEmployeeID).ToString <> "" Then
            ClearError(utEmployeeID)
            utEmployeeID.Text = ""
        End If

        'Construct the Organization Where Clause
        Select Case uopCompany.CheckedIndex
            Case 1 ' By Division
                strDivision = ucboDivision.Text
            Case 2 ' By Office
                iOfficeId = ucboOffice.Value
        End Select

        If cbActiveOnly.Checked Then
            FetchTimeCardEmployees(dtSet, strDivision, iOfficeId)
        Else
            FetchAllTimeCardEmployees(dtSet, strDivision, iOfficeId)
        End If

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
                    utEmployeeID.Text = ugRow.Cells("EmployeeID").Text
                    lblEmpName.Text = ugRow.Cells("Employee").Text
                    Srch = Nothing
                    utEmployeeID.Modified = False
                End If
            End Try
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Validate utEmployeeID
        If _strError <> "" Then
            Beep()
            utEmployeeID.Focus()
            Exit Sub
        End If
        'btnDisplay.PerformClick()
        UltraGrid1.PrintPreview(UltraGrid1.DisplayLayout, Infragistics.Win.UltraWinGrid.RowPropertyCategories.All)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        'Validate utEmployeeID
        If _strError <> "" Then
            Beep()
            utEmployeeID.Focus()
            Exit Sub
        End If
        btnDisplay.PerformClick()

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
        'x.TextBox1.Text = "c :\EmployeeActivityDetail.xls"
        x.TextBox1.Text = ".\EmployeeActivityDetail.xls"
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

    Private Sub TimeCardListing_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If ErrorProvider1.GetError(utEmployeeID).ToString <> "" Or ErrorProvider1.GetError(ucboOffice).ToString <> "" Or ErrorProvider1.GetError(ucboDivision).ToString <> "" Then
            e.Cancel = False
        End If
    End Sub

#End Region

#Region "ValueChanged Events"

    Private Sub uopCompany_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopCompany.ValueChanged

        Select Case uopCompany.CheckedIndex

            Case 0 'Whole Company

                ucboDivision.Text = ""
                ClearError(ucboDivision)
                ucboDivision.Visible = False

                ucboOffice.Text = ""
                ClearError(ucboOffice)
                ucboOffice.Visible = False

            Case 1 'By Division

                ucboOffice.Text = ""
                ClearError(ucboOffice)
                ucboOffice.Visible = False

                ucboDivision.Visible = True
                ucboDivision.Focus()

            Case 2 'By Office

                ucboDivision.Text = ""
                ClearError(ucboDivision)
                ucboDivision.Visible = False

                ucboOffice.Visible = True
                ucboOffice.Focus()

        End Select

    End Sub

    Private Sub uopDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopDate.ValueChanged

        Select Case uopDate.CheckedIndex

            Case 0 'Date Range

                udtPayrollEnding.Visible = False

                udtWeekEnding.Visible = False

                udtFrom.Visible = True
                ulblTo.Visible = True
                udtTo.Visible = True
                udtFrom.Focus()

            Case 1 'Payroll Ending

                udtFrom.Visible = False
                ulblTo.Visible = False
                udtTo.Visible = False

                udtWeekEnding.Visible = False

                udtPayrollEnding.Visible = True
                udtPayrollEnding.Focus()

            Case 2 'Week Ending

                udtFrom.Visible = False
                ulblTo.Visible = False
                udtTo.Visible = False

                udtPayrollEnding.Visible = False

                udtWeekEnding.Visible = True
                udtWeekEnding.Focus()

        End Select

    End Sub

    Private Sub uopEmployee_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopEmployee.ValueChanged

        Select Case uopEmployee.CheckedIndex

            Case 0 'All Employees

                If ErrorProvider1.GetError(utEmployeeID).ToString <> "" Then
                    ClearError(utEmployeeID)
                    utEmployeeID.Text = ""
                End If

                utEmployeeID.Text = ""
                utEmployeeID.Visible = False

                btnEmployee.Visible = False

                cbActiveOnly.Visible = False
                lblEmpName.Text = ""
                lblName.Visible = False

            Case 1 'By Employee

                utEmployeeID.Visible = True
                utEmployeeID.Focus()

                btnEmployee.Visible = True

                cbActiveOnly.Visible = True
                lblName.Visible = True

        End Select

    End Sub

#End Region

#Region "Helper Functions"

    'Private Sub StandardFormPrep()

    '    'Standard Code for Most Unison Form's Load Event
    '    AddHandler Me.Activated, AddressOf Form_Activated
    '    AddHandler Me.KeyUp, AddressOf Form_KeyUp

    '    If Not Me.Tag Is Nothing Then
    '        If Me.Tag <> "" Then
    '            Me.Tag = HRTblPath & Me.Tag
    '        End If
    '    End If

    '    Me.CenterToScreen()

    '    Me.KeyPreview = True
    '    MeText = Me.Text

    'End Sub

    Private Sub SetDefaultRange()
        udtTo.DateTime = Date.Today
        udtFrom.DateTime = udtTo.DateTime.AddDays(-7)
    End Sub

    Private Sub SetDefaultWeekEnding()
        Dim y As Short
        y = 7 - Date.Today.DayOfWeek
        udtWeekEnding.DateTime = Date.Today.AddDays(y)
    End Sub

    Private Sub SetDefaultPayrollEnding()
        Dim y As Short
        y = 7 - Date.Today.DayOfWeek
        udtPayrollEnding.DateTime = Date.Today.AddDays(y)
    End Sub

    Private Sub SetError(ByRef ctl As Control, ByVal e As System.ComponentModel.CancelEventArgs, ByVal str As String)
        Beep()
        e.Cancel = True
        Me.ErrorProvider1.SetError(ctl, str)
    End Sub

    Private Sub ClearError(ByRef ctl As Control)
        Me.ErrorProvider1.SetError(ctl, "")
    End Sub

    Private Sub SimulateTab(ByVal e As System.Windows.Forms.KeyEventArgs, ByVal key As Integer, ByVal ctl As Windows.Forms.Control)
        If CInt(e.KeyValue) = key Then
            Me.SelectNextControl(ctl, True, True, True, True)
        End If
    End Sub

#End Region

#Region "Data Access Functions"

    Private Sub GetDivisions()

        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim SQLSelect As String

        'Populate the DataSet
        SQLSelect = "SELECT division FROM " & HRTblPath & "Divisions ORDER BY division"
        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        'Initialize the UltraCombo
        ucboDivision.DataSource = dtSet.Tables(0)
        ucboDivision.ValueMember = dtSet.Tables(0).Columns("division").ToString
        ucboDivision.DisplayMember = dtSet.Tables(0).Columns("division").ToString
        ucboDivision.DisplayLayout.Bands(0).ColHeadersVisible = False

        '<<<NOTE:  This is how it should work.  But doing it this way, breaks ValidDivision(), so use old way temporarily.>>>
        'Dim SQLSelect As String
        'SQLSelect = "SELECT division as FldCode, division as FldLabel FROM " & HRTblPath & "Divisions ORDER BY division"
        'FillUCombo(ucboDivision, "", "", SQLSelect)
        'Cbo.DisplayLayout.Bands(0).Columns(FldCode).Hidden = HideFldCode

    End Sub

    Private Function ValidDivision(ByVal p_strName As String) As Boolean

        Dim dataRow As DataRow
        Dim dataRows As DataRow()
        Dim iCount As Integer = 0

        dataRows = ucboDivision.DataSource.Select("division = '" & p_strName & "'")

        For Each dataRow In dataRows
            iCount += 1
        Next

        ValidDivision = IIf(iCount > 0, True, False)

    End Function

    Private Function GetOfficeIds() As Boolean

        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim strSQL As String

        'Initialzie DataSet
        strSQL = "SELECT ID, Name FROM " & HRTblPath & "ServiceOffices ORDER BY ID"
        PopulateDataset2(dtAdapter, dtSet, strSQL)

        If dtSet.Tables(0).Rows.Count >= 1 Then
            'Initialize the UltraCombo
            ucboOffice.DataSource = dtSet.Tables(0)
            ucboOffice.ValueMember = dtSet.Tables(0).Columns("ID").ToString
            ucboOffice.DisplayMember = dtSet.Tables(0).Columns("Name").ToString
            ucboOffice.DisplayLayout.Bands(0).ColHeadersVisible = False
            GetOfficeIds = True
            'Hide the ID column
            Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
            For Each ugcol In ucboOffice.DisplayLayout.Bands(0).Columns
                If StrComp(ugcol.ToString, "ID") = 0 Then
                    ugcol.Hidden = True
                End If
            Next
            '<<<NOTE:  Use FillUCombo when know how to keep ValidOfficeId() from breaking.>>>
        Else
            ucboOffice.Text = ""
            GetOfficeIds = False
        End If

    End Function

    Private Function ValidOfficeId(ByVal p_strName As String) As Boolean

        Dim dataRow As DataRow
        Dim dataRows As DataRow()
        Dim iCount As Integer = 0

        If IsNumeric(p_strName) Then
            dataRows = ucboOffice.DataSource.Select("ID = " & p_strName)
        Else
            dataRows = ucboOffice.DataSource.Select("Name = '" & p_strName & "'")
        End If

        For Each dataRow In dataRows
            iCount += 1
        Next

        ValidOfficeId = IIf(iCount > 0, True, False)

    End Function

    Private Sub PopulateGrid()

        Dim dtSet As New DataSet
        Dim HidCols() As String = {"RowID", "OfficeID", "CheckOutDate", "LastUpdate", "OperatorId"}
        Dim i As Integer
        Dim SummCol As String

        If FetchEmployeeActivityDetails(dtSet, _strCondition) Then

            For i = 0 To dtSet.Tables(0).Columns.Count - 1
                dtSet.Tables(0).Columns(i).ReadOnly = True
            Next

            FillUltraGrid(UltraGrid1, dtSet, -1, HidCols, 0)

            UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
            UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            UltraGrid1.DisplayLayout.AutoFitColumns = False

            Dim b As New SizeF
            Dim g As Graphics = Me.CreateGraphics

            For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
                UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = True

                b = g.MeasureString(UltraGrid1.DisplayLayout.Bands(0).Columns(i).ToString, UltraGrid1.Font)
                UltraGrid1.DisplayLayout.Bands(0).Columns(i).Width = b.Width + 20

                UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
            Next

            UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

            SummCol = "TotalHrs"

            UltraGrid1.DisplayLayout.Bands(0).Summaries.Add(SummCol, Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns(SummCol), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
            UltraGrid1.DisplayLayout.Bands(0).Summaries(SummCol).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
            UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


            UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

            UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
            UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        End If

    End Sub

    Private Function FetchTimeCardEmployeeName(ByVal p_iEmpId As Int32) As String

        Dim dtSet As New DataSet
        Dim strDivision As String = ""
        Dim strCondition As String = ""
        Dim iOfficeId As Int32 = 0

        'Construct the Organization Where Clause
        Select Case uopCompany.CheckedIndex
            Case 1 ' By Division
                strDivision = ucboDivision.Text
            Case 2 ' By Office
                iOfficeId = ucboOffice.Value
        End Select

        'Construct the employee ID where clause
        strCondition = " AND e.ID = " & utEmployeeID.Text

        If cbActiveOnly.Checked Then
            FetchTimeCardEmployees(dtSet, strDivision, iOfficeId, strCondition)
        Else
            FetchAllTimeCardEmployees(dtSet, strDivision, iOfficeId, strCondition)
        End If

        If dtSet.Tables(0).Rows.Count = 1 Then
            FetchTimeCardEmployeeName = dtSet.Tables(0).Rows(0).Item("employee")
        Else
            FetchTimeCardEmployeeName = ""
        End If

    End Function

#End Region

#Region "Menu Routines"

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

#End Region

#Region "Search Routines"

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

#End Region

#Region "Field Validation"

    Private Sub utEmployeeID_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles utEmployeeID.Enter
        'If ErrorProvider1.GetError(utEmployeeID).ToString <> "" Then
        utEmployeeID.SelectAll()
        'End If
    End Sub

    Private Sub utEmployeeID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles utEmployeeID.Validating
        ' Validate Entered Data
        If uopEmployee.CheckedIndex = 1 Then
            If IsNumeric(utEmployeeID.Text) Then
                Dim strEmpName As String = FetchTimeCardEmployeeName(utEmployeeID.Text)
                If strEmpName = "" Then
                    'SetError(utEmployeeID, e, "Employee Not Found")
                    lblEmpName.Text = "Employee Not Found"
                    _strError = "Employee Not Found"
                Else
                    lblEmpName.Text = strEmpName
                    _strError = ""
                End If
            Else
                'SetError(utEmployeeID, e, "Please Enter an Employee ID")
                'Beep()
                lblEmpName.Text = "Please Enter a Valid Employee ID"
                _strError = "Please Enter a Valid Employee ID"
            End If
        Else
            _strError = ""
        End If
    End Sub

    Private Sub utEmployeeID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles utEmployeeID.Validated
        'ClearError(utEmployeeID)
        'Validate()
    End Sub

    Private Sub ucboDivision_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDivision.Enter
        If ErrorProvider1.GetError(ucboDivision).ToString <> "" Then
            ucboDivision.Select()
        End If
    End Sub

    Private Sub ucboDivision_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ucboDivision.Validating
        If Not ValidDivision(ucboDivision.Text) And uopCompany.CheckedIndex = 1 Then
            SetError(ucboDivision, e, "Please Enter or Select a Division")
        End If
    End Sub

    Private Sub ucboDivision_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDivision.Validated
        ClearError(ucboDivision)
    End Sub

    Private Sub ucboOffice_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboOffice.Enter
        If ErrorProvider1.GetError(ucboOffice).ToString <> "" Then
            ucboOffice.Select()
        End If
    End Sub

    Private Sub ucboOffice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ucboOffice.Validating
        If Not ValidOfficeId(ucboOffice.Text) And uopCompany.CheckedIndex = 2 Then
            SetError(ucboOffice, e, "Please Enter or Select a valid Office")
        End If
    End Sub

    Private Sub ucboOffice_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboOffice.Validated
        ClearError(ucboOffice)
    End Sub

    Private Sub udtFrom_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtFrom.Enter
        udtFrom.SelectAll()
    End Sub

    Private Sub udtPayrollEnding_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtPayrollEnding.Enter
        udtPayrollEnding.SelectAll()
    End Sub

    Private Sub udtTo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtTo.Enter
        udtTo.SelectAll()
    End Sub

    Private Sub udtWeekEnding_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtWeekEnding.Enter
        udtWeekEnding.SelectAll()
    End Sub

#End Region

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        'Make sure required conditions are set.
        If uopDate.CheckedIndex = 2 And uopEmployee.CheckedIndex = 1 Then
            CategorizeWorkHoursV2(CInt(utEmployeeID.Text), udtWeekEnding.DateTime.ToShortDateString)
            btnDisplay.PerformClick()
        Else
            MessageBox.Show("You must specify a WeekEnding and Specific Employee for this Test.")
        End If
    End Sub

    Private Sub btnTimeVerification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeVerification.Click

        'Validate utEmployeeID
        If _strError <> "" Then
            Beep()
            utEmployeeID.Focus()
            Exit Sub
        End If

        'Reset the condition variable
        _strCondition = ""

        'Construct the Organization Where Clause
        Select Case uopCompany.CheckedIndex
            Case 0 ' Whole Company
                _strWhereOrganization = ""
            Case 1 ' By Division
                If ucboDivision.Text = "" Then
                    _strWhereOrganization = " AND ead.division = NULL "
                Else
                    _strWhereOrganization = " AND ead.division = '" & ucboDivision.Text & "' "
                End If
            Case 2 ' By Office
                'If ucboOffice.Text = "" Then
                '_strWhereOrganization = " AND ead.office = NULL "
                'Else
                If IsNumeric(ucboOffice.Text) Then
                    Dim dataRows As DataRow()
                    Dim dataRow As DataRow
                    dataRows = ucboOffice.DataSource.Select("ID = " & ucboOffice.Text)
                    _strWhereOrganization = " AND ead.office = '" & dataRows(0).Item("Name") & "' "
                Else
                    _strWhereOrganization = " AND ead.office = '" & ucboOffice.Text & "' "
                End If
                'End If
        End Select

        'Construct the Date Where Clause
        Select Case uopDate.CheckedIndex
            Case 0 'Date Range
                _strWhereDate = " AND ead.CheckInDate between CAST('" & udtFrom.DateTime.ToShortDateString & "' AS DATETIME) AND CAST('" & udtTo.DateTime.ToShortDateString & "' AS DATETIME) "
            Case 1 'Payroll Ending
                _strWhereDate = " AND ead.PayrollEnding = CAST('" & udtPayrollEnding.DateTime.ToShortDateString & "' AS DATETIME) "
            Case 2 'Week Ending
                _strWhereDate = "AND ead.WeekEnding = CAST('" & udtWeekEnding.DateTime.ToShortDateString & "' AS DATETIME) "
        End Select

        'Construct the Employee Where Clause
        Select Case uopEmployee.CheckedIndex
            Case 0 'All Employees
                _strWhereEmployee = ""
            Case 1 'By Employee
                _strWhereEmployee = " AND ead.employeeId = " & utEmployeeID.Text
        End Select

        'Construct the final condition statement and populate the Grid
        _strCondition = _strWhereOrganization & _strWhereDate & _strWhereEmployee & " order by ead.EmployeeID, ead.CheckInDate, ead.TimeIn asc "

        RunTimeCardVerificationReport()

    End Sub

    Private Sub RunTimeCardVerificationReport()

        'Prepare the SqlCommand for the Report
        Dim strSqlCommand As String

        'strSqlCommand = "SELECT * FROM (" & FetchEmployeeActivityDetailsQuery(_strCondition) & ") AS TimeCardInputActivity"

        strSqlCommand = FetchEmployeeActivityDetailsQuery(_strCondition)

        Dim x As New TimeCardVerificationForm
        x.SqlCommand = strSqlCommand
        x.Show()

    End Sub

    Public Function FetchEmployeeActivityDetailsQuery(ByVal Condition As String) As String

        Dim sqlEmplTmpList As String = _
"SELECT DISTINCT  ead.RowID, ead.EmployeeID, e.FirstName, e.LastName, ead.Division, ead.OfficeID, ead.Office, ead.CheckInDate, ead.TimeIn, ead.CheckOutDate, " & _
                      " ead.TimeOut, ead.BreakTime, ead.DeptNo, ead.PayRate, ead.TotalHrs, ead.RegHrs, ead.OTHrs, ead.DTHrs, ead.WeekEnding, " & _
                      " ead.PayrollEnding, ead.LastUpdate, ead.Processed, ead.UserID AS OperatorID " & _
" FROM " & HRTblPath & "EMPLOYEEACTIVITYDETAIL AS ead INNER JOIN " & _
                      CFGTblPath & "UN_HRTimeCardOfficeRights AS tcr ON ead.OfficeID = tcr.OfficeID " & _
" LEFT OUTER JOIN " & HRTblPath & "Employees e on ead.EmployeeID = e.ID " & _
" WHERE     (tcr.TimeCardInput = 1 AND tcr.UserID IN (Select Group_Code as UserID from " & CFGTblPath & "UN_UserMemberships where userid = '" _
& LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID) AND tcr.Company_Code = '" & LoginInfo.CompanyCode & "') "


        Dim sqlSelect As String

        sqlSelect = PrepSelectQuery(sqlEmplTmpList, Condition)

        Return sqlSelect

    End Function

    Private Sub btnComplianceCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplianceCheck.Click

        'Validate utEmployeeID
        If _strError <> "" Then
            Beep()
            utEmployeeID.Focus()
            Exit Sub
        End If

        'Reset the condition variable
        _strCondition = " WHERE "

        'Construct the Organization Where Clause
        Select Case uopCompany.CheckedIndex
            Case 0 ' Whole Company
                _strWhereOrganization = ""
            Case 1 ' By Division
                If ucboDivision.Text = "" Then
                    _strWhereOrganization = "  division = NULL "
                Else
                    _strWhereOrganization = "  division = '" & ucboDivision.Text & "' "
                End If
            Case 2 ' By Office
                'If ucboOffice.Text = "" Then
                '_strWhereOrganization = " AND ead.office = NULL "
                'Else
                If IsNumeric(ucboOffice.Text) Then
                    Dim dataRows As DataRow()
                    Dim dataRow As DataRow
                    dataRows = ucboOffice.DataSource.Select("ID = " & ucboOffice.Text)
                    _strWhereOrganization = " office = '" & dataRows(0).Item("Name") & "' "
                Else
                    _strWhereOrganization = " office = '" & ucboOffice.Text & "' "
                End If
                'End If
        End Select

        'Construct the Date Where Clause
        Dim strConjunction As String

        If _strWhereOrganization = "" Then
            strConjunction = " "
        Else
            strConjunction = " AND "
        End If

        Select Case uopDate.CheckedIndex
            Case 0 'Date Range
                _strWhereDate = strConjunction & "CheckInDate between CAST('" & udtFrom.DateTime.ToShortDateString & "' AS DATETIME) AND CAST('" & udtTo.DateTime.ToShortDateString & "' AS DATETIME) "
            Case 1 'Payroll Ending
                _strWhereDate = strConjunction & "PayrollEnding = CAST('" & udtPayrollEnding.DateTime.ToShortDateString & "' AS DATETIME) "
            Case 2 'Week Ending
                _strWhereDate = strConjunction & "WeekEnding = CAST('" & udtWeekEnding.DateTime.ToShortDateString & "' AS DATETIME) "
        End Select

        'Construct the Employee Where Clause
        strConjunction = " AND "

        Select Case uopEmployee.CheckedIndex
            Case 0 'All Employees
                _strWhereEmployee = ""
            Case 1 'By Employee
                _strWhereEmployee = strConjunction & "employeeId = " & utEmployeeID.Text
        End Select

        'Construct the final condition statement and populate the Grid
        _strCondition &= _strWhereOrganization & _strWhereDate & _strWhereEmployee

        RunTimeCardComplianceReport()

    End Sub

    Public Function RunTimeCardComplianceReport()
        'Prepare the SqlCommand for the Report
        Dim strSqlCommand As String

        'strSqlCommand = "SELECT * FROM (" & FetchEmployeeActivityDetailsQuery(_strCondition) & ") AS TimeCardInputActivity"

        strSqlCommand = FetchTimeCardComplianceQuery(_strCondition)

        'DEBUG
        ''MsgBox(strSqlCommand)

        Dim x As New TimeCardComplianceForm
        x.SqlCommand = strSqlCommand
        x.Show()

    End Function


    Public Function FetchTimeCardComplianceQuery(ByVal Condition As String) As String

        Dim sqlEmpTmpList As String = _
"select distinct ead.division,ead.officeid,ead.employeeid,e.FirstName,e.LastName,ead.checkindate,ead.TotalHoursWorked,ead.TotalBreakTime,ead.TimeCardPairs " & _
"from " & _
"(select division, officeid, employeeid, checkindate, sum(totalhrs) as TotalHoursWorked, sum(breaktime) as TotalBreakTime, count(*) as TimeCardPairs " & _
"from " & HRTblPath & "EmployeeActivityDetail @WHERE group by division, officeid, employeeid, checkindate) as ead " & _
"INNER JOIN " & CFGTblPath & "UN_HRTimeCardOfficeRights AS tcr ON ead.OfficeID = tcr.OfficeID " & _
"LEFT OUTER JOIN " & HRTblPath & "Employees e on ead.EmployeeID = e.ID " & _
"WHERE     (tcr.TimeCardInput = 1 AND tcr.UserID IN (Select Group_Code as UserID from " & CFGTblPath & "UN_UserMemberships " & _
"where userid = '" & LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID) AND tcr.Company_Code = '" & LoginInfo.CompanyCode & "') "

        Dim sqlSelect As String

        'sqlSelect = PrepSelectQuery(sqlEmpTmpList, Condition)
        sqlSelect = sqlEmpTmpList.Replace("@WHERE", Condition)

        sqlSelect &= " order by ead.division, ead.officeid, ead.employeeid, ead.checkindate asc "

        Return sqlSelect

    End Function

    Private Sub btnBreakAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBreakAnalysis.Click

        Dim strSqlQuery As String = ""

        Dim strOpen As String = "SELECT * FROM ("
        Dim strClose As String = ") AS TimeCardEventsPlus "

        Dim strSqlPreamble As String = "SELECT ead.EmployeeID as EmployeeID, e.FirstName as FirstName, e.MiddleName as MiddleName, e.LastName as LastName, ead.Division as Division, ead.Office as Office, ead.CheckInDate as CheckInDate, " & _
        "ead.TimeEvent as TimeEvent, ead.Direction as Direction, ead.WeekEnding as WeekEnding, ead.PayrollEnding as PayrollEnding from " & HRTblPath & "TimeCardEvents ead, " & HRTblPath & "Employees e "

        Dim strSqlJoin As String = " AND e.[id] = ead.EmployeeID "

        Dim strSqlOrderBy As String = " order by EmployeeID, CheckInDate, TimeEvent asc"


        'Validate utEmployeeID
        If _strError <> "" Then
            Beep()
            utEmployeeID.Focus()
            Exit Sub
        End If

        'Reset the condition variable
        _strCondition = " WHERE "

        'Construct the Organization Where Clause
        Select Case uopCompany.CheckedIndex
            Case 0 ' Whole Company
                _strWhereOrganization = ""
            Case 1 ' By Division
                If ucboDivision.Text = "" Then
                    _strWhereOrganization = "  ead.division = NULL "
                Else
                    _strWhereOrganization = "  ead.division = '" & ucboDivision.Text & "' "
                End If
            Case 2 ' By Office
                'If ucboOffice.Text = "" Then
                '_strWhereOrganization = " AND ead.office = NULL "
                'Else
                If IsNumeric(ucboOffice.Text) Then
                    Dim dataRows As DataRow()
                    Dim dataRow As DataRow
                    dataRows = ucboOffice.DataSource.Select("ID = " & ucboOffice.Text)
                    _strWhereOrganization = " ead.office = '" & dataRows(0).Item("Name") & "' "
                Else
                    _strWhereOrganization = " ead.office = '" & ucboOffice.Text & "' "
                End If
                'End If
        End Select

        'Construct the Date Where Clause
        Dim strConjunction As String

        If _strWhereOrganization = "" Then
            strConjunction = " "
        Else
            strConjunction = " AND "
        End If

        Select Case uopDate.CheckedIndex
            Case 0 'Date Range
                _strWhereDate = strConjunction & "ead.CheckInDate between CAST('" & udtFrom.DateTime.ToShortDateString & "' AS DATETIME) AND CAST('" & udtTo.DateTime.ToShortDateString & "' AS DATETIME) "
            Case 1 'Payroll Ending
                _strWhereDate = strConjunction & "ead.PayrollEnding = CAST('" & udtPayrollEnding.DateTime.ToShortDateString & "' AS DATETIME) "
            Case 2 'Week Ending
                _strWhereDate = strConjunction & "ead.WeekEnding = CAST('" & udtWeekEnding.DateTime.ToShortDateString & "' AS DATETIME) "
        End Select

        'Construct the Employee Where Clause
        strConjunction = " AND "

        Select Case uopEmployee.CheckedIndex
            Case 0 'All Employees
                _strWhereEmployee = ""
            Case 1 'By Employee
                _strWhereEmployee = strConjunction & "ead.employeeId = " & utEmployeeID.Text
        End Select

        'Construct the final condition statement and populate the Grid
        _strCondition &= _strWhereOrganization & _strWhereDate & _strWhereEmployee

        strSqlQuery = strOpen & strSqlPreamble & _strCondition & strSqlJoin & strClose & strSqlOrderBy

        DetermineTimeCardEvents(strSqlQuery)

    End Sub

    Sub DetermineTimeCardEvents(ByVal p_strSqlQuery As String)

        ' Get a working DataSet
        Dim dsEvents As TimeCardEventsPlusDS = GetTimeCardEventsPlus(p_strSqlQuery)
        Dim dsPeriods As TimeCardEventsAnalysisDS = Nothing

        If Not IsNothing(dsEvents) Then

            ' Itereate through the working DataSet to build the Report Dataset
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            dsPeriods = GetTimeCardPeriodAnalysis(dsEvents)
            Me.Cursor = System.Windows.Forms.Cursors.Default

            If Not IsNothing(dsPeriods) Then

                ' Load the Report DataSet into the Crystal Report Viewer
                DisplayAnalysis(dsPeriods)

            End If

        End If

    End Sub

    Private Sub DisplayAnalysis(ByRef p_dsPeriods As TimeCardEventsAnalysisDS)

        Dim x As New TimeCardEventsAnalysisForm

        x.DataSource = p_dsPeriods

        x.Show()

    End Sub

    Private Function GetTimeCardPeriodAnalysis(ByRef p_dsEvents As TimeCardEventsPlusDS) As TimeCardEventsAnalysisDS

        Dim tblEvents As TimeCardEventsPlusDS.TimeCardEventsPlusDataTable = p_dsEvents.Tables(0)
        Dim rowEventsX, rowEventsY As TimeCardEventsPlusDS.TimeCardEventsPlusRow

        Dim dsAnalyzed As New TimeCardEventsAnalysisDS
        Dim rowAnalyzed As TimeCardEventsAnalysisDS.TimeCardEventsAnalysisRow

        ' Static Data (which is data that will translate untouched between DS)
        Dim iEmployeeID As Integer
        Dim sFirstName, sMiddleName, sLastName, sDivision, sOffice As String
        Dim dWorkDate, dWeekEnding, dPayrollEnding As Date

        ' Variables for data that need to be changed or used in calculations
        Dim fEventX, fEventY, fPeriodHours As Decimal
        'Dim iDayX, iDayY As Integer
        Dim sDirectionX, sDirectionY, sHoursCategory As String

        For i As Integer = 0 To tblEvents.Rows.Count - 2

            ' Get the two rows that are going to be worked on in this pass
            rowEventsX = tblEvents.Rows(i)
            rowEventsY = tblEvents.Rows(i + 1)

            ' Populate Static Data Variables
            iEmployeeID = rowEventsX.EmployeeId
            If iEmployeeID <> rowEventsY.EmployeeId Then
                GoTo SkipPair 'This Means you are looking at TimeEvents for two different employees.  Meaningless.
            End If
            sFirstName = rowEventsX.FirstName
            sMiddleName = rowEventsX.MiddleName
            sLastName = rowEventsX.LastName
            sDivision = rowEventsX.Division
            sOffice = rowEventsX.Office
            dWorkDate = rowEventsX.CheckInDate
            dWeekEnding = rowEventsX.WeekEnding
            dPayrollEnding = rowEventsX.PayrollEnding

            ' Poplulate the variables to be used in calculation
            fEventX = rowEventsX.TimeEvent
            'iDayX = rowEventsX.CheckInDate.Day
            sDirectionX = rowEventsX.Direction

            fEventY = rowEventsY.TimeEvent
            'iDayY = rowEventsY.CheckInDate.Day
            sDirectionY = rowEventsY.Direction

            ' Perform the required calculations
            Dim x As Long = DateDiff(DateInterval.Day, rowEventsX.CheckInDate, rowEventsY.CheckInDate)
            fPeriodHours = (fEventY - fEventX) + (24 * (x))
            If String.Compare(sDirectionX, "In") = 0 Then
                sHoursCategory = "W"
            Else
                If fPeriodHours > 5 Then
                    sHoursCategory = "H"
                Else
                    sHoursCategory = "B"
                End If
            End If

            ' Add a Row to the Periods table
            rowAnalyzed = dsAnalyzed.TimeCardEventsAnalysis.NewTimeCardEventsAnalysisRow()
            With rowAnalyzed
                .EmployeeId = iEmployeeID
                .FirstName = sFirstName
                .MiddleName = sMiddleName
                .LastName = sLastName
                .Division = sDivision
                .Office = sOffice
                .WorkDate = dWorkDate
                .PeriodHours = fPeriodHours
                .HoursCategory = sHoursCategory
                .WeekEnding = dWeekEnding
                .PayrollEnding = dPayrollEnding
            End With
            dsAnalyzed.TimeCardEventsAnalysis.Rows.Add(rowAnalyzed)

SkipPair:

        Next i

        GetTimeCardPeriodAnalysis = dsAnalyzed

    End Function

    Private Function GetTimeCardEventsPlus(ByVal p_strSqlQuery) As TimeCardEventsPlusDS

        Dim DataAdapter As New SqlDataAdapter
        Dim localConn As New SqlConnection(strConnection)
        Dim dsEvents As New TimeCardEventsPlusDS

        Try
            DataAdapter.SelectCommand = New SqlCommand

            With DataAdapter.SelectCommand
                .Connection = localConn
                .CommandTimeout = 120
                .CommandText = p_strSqlQuery
                .CommandType = CommandType.Text
            End With

            With DataAdapter
                .AcceptChangesDuringFill = True
                .MissingSchemaAction = MissingSchemaAction.AddWithKey
                localConn.Open()
                .Fill(dsEvents, "TimeCardEventsPlus")
            End With

        Catch ex As System.Data.SqlClient.SqlException

            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Time Card Listing")
            dsEvents = Nothing

        Finally

            localConn.Close()
            localConn = Nothing

        End Try

        GetTimeCardEventsPlus = dsEvents

    End Function

End Class
