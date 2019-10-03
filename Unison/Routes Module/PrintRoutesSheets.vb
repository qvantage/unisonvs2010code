Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Collections


Imports System.Text


Public Class PrintRoutesSheets
    Inherits System.Windows.Forms.Form

    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

    Dim TemplateID As Integer
    Dim Template As String
    Dim strSqlCommand As String

    Class SchCols
        Public Name As String
        Public Type As Type
        Public Format As String
        Public NoEdit As Boolean
        Public Hide As Boolean
        Public BackColor As Color
        Public MaxLength As Byte
        Public Width As Byte
    End Class

    Dim WCols(10) As SchCols


#Region "Private Members"

    Private _strCondition, strWhereRoute, _strWhereDate, _strWhereDriver As String
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
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbActiveOnly As System.Windows.Forms.CheckBox
    Friend WithEvents lblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ulblTo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtTo As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtFrom As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents uopDate As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ucboOffice As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBreakAnalysis As System.Windows.Forms.Button
    Friend WithEvents btnComplianceCheck As System.Windows.Forms.Button
    Friend WithEvents btnTimeVerification As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents utDriverID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnDriver As System.Windows.Forms.Button
    Friend WithEvents lblDriverName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uopDriver As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents udtDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ucboRoute As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents cbByRoute As System.Windows.Forms.CheckBox
    Friend WithEvents cbWholeCompany As System.Windows.Forms.CheckBox
    Friend WithEvents cbByOffice As System.Windows.Forms.CheckBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents bnRemoveTest As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnZTest As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbActiveOnly = New System.Windows.Forms.CheckBox
        Me.utDriverID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnDriver = New System.Windows.Forms.Button
        Me.lblDriverName = New Infragistics.Win.Misc.UltraLabel
        Me.lblName = New Infragistics.Win.Misc.UltraLabel
        Me.uopDriver = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ulblTo = New Infragistics.Win.Misc.UltraLabel
        Me.udtTo = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.udtFrom = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.udtDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.uopDate = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbWholeCompany = New System.Windows.Forms.CheckBox
        Me.cbByRoute = New System.Windows.Forms.CheckBox
        Me.cbByOffice = New System.Windows.Forms.CheckBox
        Me.ucboOffice = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ucboRoute = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.bnRemoveTest = New System.Windows.Forms.Button
        Me.btnTest = New System.Windows.Forms.Button
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.btnBreakAnalysis = New System.Windows.Forms.Button
        Me.btnComplianceCheck = New System.Windows.Forms.Button
        Me.btnTimeVerification = New System.Windows.Forms.Button
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnZTest = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.utDriverID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopDriver, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.udtTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ucboOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboRoute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(0, 0)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(1, 620)
        Me.Splitter2.TabIndex = 12
        Me.Splitter2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbActiveOnly)
        Me.GroupBox1.Controls.Add(Me.utDriverID)
        Me.GroupBox1.Controls.Add(Me.btnDriver)
        Me.GroupBox1.Controls.Add(Me.lblDriverName)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Controls.Add(Me.uopDriver)
        Me.GroupBox1.Location = New System.Drawing.Point(738, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 105)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'cbActiveOnly
        '
        Me.cbActiveOnly.Checked = True
        Me.cbActiveOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbActiveOnly.Location = New System.Drawing.Point(298, 43)
        Me.cbActiveOnly.Name = "cbActiveOnly"
        Me.cbActiveOnly.Size = New System.Drawing.Size(98, 27)
        Me.cbActiveOnly.TabIndex = 152
        Me.cbActiveOnly.Text = "Active Only"
        Me.cbActiveOnly.Visible = False
        '
        'utDriverID
        '
        Me.utDriverID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utDriverID.Location = New System.Drawing.Point(128, 44)
        Me.utDriverID.Name = "utDriverID"
        Me.utDriverID.Size = New System.Drawing.Size(87, 24)
        Me.utDriverID.TabIndex = 150
        Me.utDriverID.Tag = ".DriverID"
        '
        'btnDriver
        '
        Me.btnDriver.Location = New System.Drawing.Point(217, 42)
        Me.btnDriver.Name = "btnDriver"
        Me.btnDriver.Size = New System.Drawing.Size(58, 27)
        Me.btnDriver.TabIndex = 151
        Me.btnDriver.TabStop = False
        Me.btnDriver.Text = "Se&lect"
        '
        'lblDriverName
        '
        Appearance1.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance1.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblDriverName.Appearance = Appearance1
        Me.lblDriverName.Location = New System.Drawing.Point(133, 73)
        Me.lblDriverName.Name = "lblDriverName"
        Me.lblDriverName.Size = New System.Drawing.Size(237, 19)
        Me.lblDriverName.TabIndex = 148
        '
        'lblName
        '
        Appearance2.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance2.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblName.Appearance = Appearance2
        Me.lblName.Location = New System.Drawing.Point(62, 73)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(48, 18)
        Me.lblName.TabIndex = 149
        Me.lblName.Text = "Name"
        '
        'uopDriver
        '
        Appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopDriver.Appearance = Appearance3
        Me.uopDriver.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopDriver.ItemAppearance = Appearance4
        ValueListItem1.DataValue = "All Drivers"
        ValueListItem1.DisplayText = "All Drivers"
        ValueListItem2.DataValue = "By Driver"
        ValueListItem2.DisplayText = "By Driver"
        Me.uopDriver.Items.Add(ValueListItem1)
        Me.uopDriver.Items.Add(ValueListItem2)
        Me.uopDriver.ItemSpacingVertical = 9
        Me.uopDriver.Location = New System.Drawing.Point(10, 18)
        Me.uopDriver.Name = "uopDriver"
        Me.uopDriver.Size = New System.Drawing.Size(115, 56)
        Me.uopDriver.TabIndex = 146
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ulblTo)
        Me.GroupBox3.Controls.Add(Me.udtTo)
        Me.GroupBox3.Controls.Add(Me.udtFrom)
        Me.GroupBox3.Controls.Add(Me.udtDate)
        Me.GroupBox3.Controls.Add(Me.uopDate)
        Me.GroupBox3.Location = New System.Drawing.Point(312, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(422, 105)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'ulblTo
        '
        Appearance5.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance5.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblTo.Appearance = Appearance5
        Me.ulblTo.Location = New System.Drawing.Point(254, 74)
        Me.ulblTo.Name = "ulblTo"
        Me.ulblTo.Size = New System.Drawing.Size(29, 18)
        Me.ulblTo.TabIndex = 153
        Me.ulblTo.Text = "To"
        '
        'udtTo
        '
        Me.udtTo.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtTo.Location = New System.Drawing.Point(307, 74)
        Me.udtTo.Name = "udtTo"
        Me.udtTo.Size = New System.Drawing.Size(106, 24)
        Me.udtTo.TabIndex = 151
        Me.udtTo.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'udtFrom
        '
        Me.udtFrom.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtFrom.Location = New System.Drawing.Point(134, 74)
        Me.udtFrom.Name = "udtFrom"
        Me.udtFrom.Size = New System.Drawing.Size(106, 24)
        Me.udtFrom.TabIndex = 150
        Me.udtFrom.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'udtDate
        '
        Me.udtDate.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtDate.Location = New System.Drawing.Point(134, 45)
        Me.udtDate.Name = "udtDate"
        Me.udtDate.Size = New System.Drawing.Size(106, 24)
        Me.udtDate.TabIndex = 149
        Me.udtDate.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'uopDate
        '
        Appearance6.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopDate.Appearance = Appearance6
        Me.uopDate.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopDate.ItemAppearance = Appearance7
        ValueListItem3.DataValue = "Date"
        ValueListItem3.DisplayText = "Date"
        ValueListItem4.DataValue = "Date  Range"
        ValueListItem4.DisplayText = "Date  Range"
        Me.uopDate.Items.Add(ValueListItem3)
        Me.uopDate.Items.Add(ValueListItem4)
        Me.uopDate.ItemSpacingVertical = 9
        Me.uopDate.Location = New System.Drawing.Point(10, 45)
        Me.uopDate.Name = "uopDate"
        Me.uopDate.Size = New System.Drawing.Size(124, 57)
        Me.uopDate.TabIndex = 148
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbWholeCompany)
        Me.GroupBox2.Controls.Add(Me.cbByRoute)
        Me.GroupBox2.Controls.Add(Me.cbByOffice)
        Me.GroupBox2.Controls.Add(Me.ucboOffice)
        Me.GroupBox2.Controls.Add(Me.ucboRoute)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(307, 105)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'cbWholeCompany
        '
        Me.cbWholeCompany.Checked = True
        Me.cbWholeCompany.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbWholeCompany.Location = New System.Drawing.Point(11, 17)
        Me.cbWholeCompany.Name = "cbWholeCompany"
        Me.cbWholeCompany.Size = New System.Drawing.Size(129, 23)
        Me.cbWholeCompany.TabIndex = 157
        Me.cbWholeCompany.Text = "Whole Company"
        '
        'cbByRoute
        '
        Me.cbByRoute.Location = New System.Drawing.Point(11, 75)
        Me.cbByRoute.Name = "cbByRoute"
        Me.cbByRoute.Size = New System.Drawing.Size(109, 23)
        Me.cbByRoute.TabIndex = 156
        Me.cbByRoute.Text = "By Route"
        '
        'cbByOffice
        '
        Me.cbByOffice.Location = New System.Drawing.Point(11, 46)
        Me.cbByOffice.Name = "cbByOffice"
        Me.cbByOffice.Size = New System.Drawing.Size(109, 23)
        Me.cbByOffice.TabIndex = 155
        Me.cbByOffice.Text = "By Office"
        '
        'ucboOffice
        '
        Me.ucboOffice.DisplayMember = ""
        Me.ucboOffice.Location = New System.Drawing.Point(134, 48)
        Me.ucboOffice.Name = "ucboOffice"
        Me.ucboOffice.Size = New System.Drawing.Size(125, 24)
        Me.ucboOffice.TabIndex = 149
        Me.ucboOffice.Tag = ""
        Me.ucboOffice.ValueMember = ""
        '
        'ucboRoute
        '
        Me.ucboRoute.DisplayMember = ""
        Me.ucboRoute.Location = New System.Drawing.Point(134, 74)
        Me.ucboRoute.Name = "ucboRoute"
        Me.ucboRoute.Size = New System.Drawing.Size(125, 24)
        Me.ucboRoute.TabIndex = 148
        Me.ucboRoute.Tag = ""
        Me.ucboRoute.ValueMember = ""
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(28, 20)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(105, 24)
        Me.btnDisplay.TabIndex = 163
        Me.btnDisplay.Text = "D&isplay"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnZTest)
        Me.GroupBox4.Controls.Add(Me.btnTest)
        Me.GroupBox4.Controls.Add(Me.btnGenerate)
        Me.GroupBox4.Controls.Add(Me.btnComplianceCheck)
        Me.GroupBox4.Controls.Add(Me.btnTimeVerification)
        Me.GroupBox4.Controls.Add(Me.btnExcel)
        Me.GroupBox4.Controls.Add(Me.btnPrint)
        Me.GroupBox4.Controls.Add(Me.btnDisplay)
        Me.GroupBox4.Location = New System.Drawing.Point(1, 112)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1144, 54)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        '
        'bnRemoveTest
        '
        Me.bnRemoveTest.Location = New System.Drawing.Point(786, 345)
        Me.bnRemoveTest.Name = "bnRemoveTest"
        Me.bnRemoveTest.Size = New System.Drawing.Size(142, 26)
        Me.bnRemoveTest.TabIndex = 171
        Me.bnRemoveTest.Text = "Test Remove"
        Me.bnRemoveTest.Visible = False
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(840, 18)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(90, 27)
        Me.btnTest.TabIndex = 170
        Me.btnTest.Text = "Test"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(160, 20)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(105, 24)
        Me.btnGenerate.TabIndex = 169
        Me.btnGenerate.Text = "&Generate"
        '
        'btnBreakAnalysis
        '
        Me.btnBreakAnalysis.Location = New System.Drawing.Point(1035, 346)
        Me.btnBreakAnalysis.Name = "btnBreakAnalysis"
        Me.btnBreakAnalysis.Size = New System.Drawing.Size(111, 26)
        Me.btnBreakAnalysis.TabIndex = 168
        Me.btnBreakAnalysis.Text = "Break Analysis"
        Me.btnBreakAnalysis.Visible = False
        '
        'btnComplianceCheck
        '
        Me.btnComplianceCheck.Location = New System.Drawing.Point(677, 20)
        Me.btnComplianceCheck.Name = "btnComplianceCheck"
        Me.btnComplianceCheck.Size = New System.Drawing.Size(134, 26)
        Me.btnComplianceCheck.TabIndex = 167
        Me.btnComplianceCheck.Text = "Compliance Report"
        Me.btnComplianceCheck.Visible = False
        '
        'btnTimeVerification
        '
        Me.btnTimeVerification.Location = New System.Drawing.Point(539, 20)
        Me.btnTimeVerification.Name = "btnTimeVerification"
        Me.btnTimeVerification.Size = New System.Drawing.Size(131, 26)
        Me.btnTimeVerification.TabIndex = 166
        Me.btnTimeVerification.Text = "Time Verification"
        Me.btnTimeVerification.Visible = False
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(418, 20)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(105, 24)
        Me.btnExcel.TabIndex = 165
        Me.btnExcel.Text = "Export to E&xcel"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(284, 20)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(106, 24)
        Me.btnPrint.TabIndex = 164
        Me.btnPrint.Text = "&Print"
        '
        'UltraButton1
        '
        Me.UltraButton1.Location = New System.Drawing.Point(932, 344)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(90, 26)
        Me.UltraButton1.TabIndex = 7
        Me.UltraButton1.Text = "UltraButton1"
        Me.UltraButton1.Visible = False
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGrid1.Location = New System.Drawing.Point(2, 172)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(1169, 172)
        Me.UltraGrid1.TabIndex = 11
        Me.UltraGrid1.Tag = "HRSINPUTLISTING"
        Me.UltraGrid1.Text = "Routes Summary"
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
        'UltraGrid2
        '
        Me.UltraGrid2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGrid2.Location = New System.Drawing.Point(-5, 372)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(1169, 198)
        Me.UltraGrid2.TabIndex = 13
        Me.UltraGrid2.Tag = "HRSINPUTLISTING"
        Me.UltraGrid2.Text = "Routes Detail"
        '
        'btnZTest
        '
        Me.btnZTest.Location = New System.Drawing.Point(962, 18)
        Me.btnZTest.Name = "btnZTest"
        Me.btnZTest.Size = New System.Drawing.Size(90, 27)
        Me.btnZTest.TabIndex = 171
        Me.btnZTest.Text = "ZTest"
        '
        'PrintRoutesSheets
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1161, 620)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.bnRemoveTest)
        Me.Controls.Add(Me.UltraButton1)
        Me.Controls.Add(Me.btnBreakAnalysis)
        Me.Menu = Me.MainMenu1
        Me.Name = "PrintRoutesSheets"
        Me.Text = "Print Routes Schedule"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utDriverID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopDriver, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.udtTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ucboOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboRoute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Common Events"

    Private Sub PrintRoutesSheets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************************************************
        'SF - 5/10/2010 - Commented out GetRoutes so we can run it by Office id
        'SF - 5/13/2010 - Added SetupSchCols()
        '**************************************************************************
        StandardFormPrep()

        'Initialize Default Condition Destined for FetchDriverActivityDetail
        _strCondition = ""
        'uopCompany.CheckedIndex = 0
        cbWholeCompany.Checked = True
        cbByRoute.Checked = False
        cbByOffice.Checked = False

        uopDate.CheckedIndex = 0
        uopDriver.CheckedIndex = 0

        'Set Initial Widget Values
        'GetRoutes()
        SetupSchCols()
        GetOfficeIds()
        SetDefaultRange()
        SetDefaultDate()
        'SetDefaultWeekEnding()
        'SetDefaultPayrollEnding()

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        '**************************************************************************
        'SF - 5/6/2010 - Change Where clause due to change in Query in FetchDriverActivityDetails
        '**************************************************************************
        Dim intWeekday As Integer

        'Validate utDriverID
        If _strError <> "" Then
            Beep()
            utDriverID.Focus()
            Exit Sub
        End If

        'Reset the condition variable
        _strCondition = ""
        strWhereRoute = ""

        'Construct the Whole Company Where Clause
        If cbWholeCompany.Checked = True Then
            strWhereRoute = ""
        ElseIf cbByRoute.Checked = True And cbByOffice.Checked = False Then
            If ucboRoute.Text = "" Then
                'strWhereRoute = strWhereRoute & " AND RouteId = NULL "
            Else
                strWhereRoute = strWhereRoute & " AND r.RouteId = '" & ucboRoute.Text & "' "
            End If
            'If IsNumeric(ucboOffice.Text) Then
            '    Dim dataRows As DataRow()
            '    Dim dataRow As DataRow
            '    dataRows = ucboOffice.DataSource.Select("ID = " & ucboOffice.Text)
            '    strWhereRoute = strWhereRoute & " AND o.office = '" & dataRows(0).Item("Name") & "' "
            'Else
            '    strWhereRoute = strWhereRoute & " AND o.office = '" & ucboOffice.Text & "' "
            'End If
        ElseIf cbByOffice.Checked = True And cbByRoute.Checked = False Then
            If IsNumeric(ucboOffice.Text) Then
                Dim dataRows As DataRow()
                Dim dataRow As DataRow
                dataRows = ucboOffice.DataSource.Select("ID = " & ucboOffice.Text)
                strWhereRoute = strWhereRoute & " AND o.name = '" & dataRows(0).Item("Name") & "' "
            Else
                If ucboOffice.Text <> "" Then
                    strWhereRoute = strWhereRoute & " AND o.name = '" & ucboOffice.Text & "' "
                End If
            End If
        ElseIf cbByOffice.Checked = True And cbByRoute.Checked = True Then
            If ucboRoute.Text = "" Then
                'strWhereRoute = strWhereRoute & " AND RouteId = NULL "
            Else
                strWhereRoute = strWhereRoute & " AND r.RouteId = '" & ucboRoute.Text & "' "
            End If

            If IsNumeric(ucboOffice.Text) Then
                Dim dataRows As DataRow()
                Dim dataRow As DataRow
                dataRows = ucboOffice.DataSource.Select("ID = " & ucboOffice.Text)
                strWhereRoute = strWhereRoute & " AND o.name = '" & dataRows(0).Item("Name") & "' "
            Else
                If ucboOffice.Text <> "" Then
                    strWhereRoute = strWhereRoute & " AND o.name = '" & ucboOffice.Text & "' "
                End If

            End If
        End If

        'Construct the Date Where Clause
        Select Case uopDate.CheckedIndex
            Case 0 ' Date Range
                '_strWhereDate = " AND ead.CheckInDate between CAST('" & udtFrom.DateTime.ToShortDateString & "' AS DATETIME) AND CAST('" & udtTo.DateTime.ToShortDateString & "' AS DATETIME) "
                'strWhereRoute = strWhereRoute & " AND (StartDate is not null AND (rs.Enddate is null or rs.EndDate > CAST('" & udtTo.DateTime.ToShortDateString & "' AS DATETIME) )) "
                strWhereRoute = strWhereRoute & " AND StartDate <> '' and (EndDate ='Jan  1 1900 12:00AM' or EndDate > " & udtDate.DateTime.ToShortDateString & " )"
                strWhereRoute = strWhereRoute & " AND Day = " & GetUnisonDay(udtDate.DateTime)
            Case 1 ' Specified Date
                'strWhereRoute = strWhereRoute & " AND (StartDate is not null AND (rs.Enddate is null or rs.EndDate > CAST('" & udtDate.DateTime.ToShortDateString & "' AS DATETIME) )) "
                strWhereRoute = strWhereRoute & " AND StartDate <> '' and (EndDate ='Jan  1 1900 12:00AM' or EndDate > " & udtTo.DateTime.ToShortDateString & " )"
                strWhereRoute = strWhereRoute & " AND Day In (" & GetUnisonDays(udtFrom.DateTime, udtTo.DateTime) & ") "
        End Select

        'Construct the Driver Where Clause
        Select Case uopDriver.CheckedIndex
            Case 0 ' All Drivers
            Case 1 ' By Driver
                strWhereRoute = strWhereRoute & " AND e.id = " & utDriverID.Text
        End Select

        'Construct the final condition statement and populate the Grid
        _strCondition = strWhereRoute

        PopulateGrid()
    End Sub

    Private Sub btnDriver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDriver.Click
        '**************************************************************************
        'SF - 5/6/2010 - Modified code to add condition ElseIf cbByOffice.Checked = True And cbByRoute.Checked = True Then
        '**************************************************************************
        If uopDriver.CheckedIndex <> 1 Then
            Exit Sub
        Else
            _strError = ""
        End If

        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        'Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim strRoute As String = ""
        Dim iOfficeId As Int32 = 0

        'Clear Error State of utDriverID
        If ErrorProvider1.GetError(utDriverID).ToString <> "" Then
            ClearError(utDriverID)
            utDriverID.Text = ""
        End If

        ''Construct the Organization Where Clause
        'Select Case uopCompany.CheckedIndex
        '    Case 1 ' By Route
        '        strRoute = ucboRoute.Text
        '    Case 2 ' By Office
        '        iOfficeId = ucboOffice.Value
        'End Select

        'Construct The Whole Company Where Clause
        If cbByRoute.Checked = True And cbByOffice.Checked = True Then
            strRoute = ucboRoute.Text
            iOfficeId = ucboOffice.ValueMember
        ElseIf cbByOffice.Checked = True And cbByRoute.Checked = False Then
            iOfficeId = ucboOffice.Value
        ElseIf cbByOffice.Checked = True And cbByRoute.Checked = True Then
            strRoute = ucboRoute.Text
            iOfficeId = ucboOffice.Value
        End If

        If cbActiveOnly.Checked Then
            FetchPrintRoutesDrivers(dtSet, strRoute, iOfficeId)
        Else
            FetchPrintAllRoutesDrivers(dtSet, strRoute, iOfficeId)
        End If

        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Drivers"
            Srch.Text = "Drivers"
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
                    utDriverID.Text = ugRow.Cells("DriverID").Text
                    lblDriverName.Text = ugRow.Cells("Driver").Text
                    Srch = Nothing
                    utDriverID.Modified = False
                End If

                dtSet.Dispose()
                dtView.Dispose()
            End Try
        End If
    End Sub

    Private Sub PrintRoutesSheets_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If ErrorProvider1.GetError(utDriverID).ToString <> "" Or ErrorProvider1.GetError(ucboOffice).ToString <> "" Or ErrorProvider1.GetError(ucboRoute).ToString <> "" Then
            e.Cancel = False
        End If
    End Sub
#End Region

#Region "ValueChanged Events"

    Private Sub cbWholeCompany_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbWholeCompany.CheckedChanged
        ' Whole Company
        If cbWholeCompany.Checked = True Then
            ucboRoute.Text = ""
            ClearError(ucboRoute)
            ucboRoute.Enabled = False
            cbByRoute.CheckState = CheckState.Unchecked
            cbByRoute.Enabled = False

            ucboOffice.Text = ""
            ClearError(ucboOffice)
            ucboOffice.Enabled = False
            cbByOffice.CheckState = CheckState.Unchecked
            cbByOffice.Enabled = False
        Else
            'ucboRoute.Text = ""
            'ClearError(ucboRoute)
            'ucboRoute.Enabled = True
            'cbByRoute.CheckState = CheckState.Unchecked
            'cbByRoute.Enabled = True

            'ucboOffice.Text = ""
            'ClearError(ucboOffice)
            'ucboOffice.Enabled = True
            cbByOffice.CheckState = CheckState.Unchecked
            cbByOffice.Enabled = True
        End If
    End Sub


    'Private Sub uopCompany_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Select Case uopCompany.CheckedIndex
    '        Case 0 'Whole Company
    '            ucboRoute.Text = ""
    '            ClearError(ucboRoute)
    '            ucboRoute.Visible = False

    '            ucboOffice.Text = ""
    '            ClearError(ucboOffice)
    '            ucboOffice.Visible = True
    '            ucboOffice.Enabled = False
    '        Case 1 'By Division

    '            ucboOffice.Text = ""
    '            ClearError(ucboOffice)
    '            ucboOffice.Visible = False

    '            ucboRoute.Visible = True
    '            ucboRoute.Focus()

    '        Case 2 'By Office

    '            ucboRoute.Text = ""
    '            ClearError(ucboRoute)
    '            ucboRoute.Visible = False

    '            ucboOffice.Visible = True
    '            ucboOffice.Focus()

    '    End Select
    'End Sub

    Private Sub SetDefaultRange()
        udtTo.DateTime = Date.Today.AddDays(1)
        udtFrom.DateTime = udtTo.DateTime.AddDays(-1)
    End Sub

    Private Sub SetDefaultDate()
        udtDate.DateTime = Date.Today.AddDays(1)
    End Sub

    Private Sub ClearError(ByRef ctl As Control)
        Me.ErrorProvider1.SetError(ctl, "")
    End Sub

#End Region

#Region "Helper Functions"

#End Region

    Private Sub SetError(ByRef ctl As Control, ByVal e As System.ComponentModel.CancelEventArgs, ByVal str As String)
        Beep()
        e.Cancel = True
        Me.ErrorProvider1.SetError(ctl, str)
    End Sub

#Region "Data Access Functions"

    Private Sub GetRoutes()
        '**************************************************************************
        'SF - 5/10/2010 - Modifed the query to return routes based on Office id
        '**************************************************************************
        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim SQLSelect As String

        'SF - If ucboOffice is blank, exit Sub
        If ucboOffice.Value = Nothing Then
            MessageBox.Show("Please select a Office.")
            Exit Sub
        End If
        'Populate the DataSet
        SQLSelect = "SELECT DISTINCT RouteID FROM " & AppTblPath & "Routes2 "
        SQLSelect = SQLSelect & "WHERE Officeid = " & ucboOffice.Value
        SQLSelect = SQLSelect & " ORDER BY RouteID"
        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        'Initialize the UltraCombo
        ucboRoute.DataSource = dtSet.Tables(0)
        ucboRoute.ValueMember = dtSet.Tables(0).Columns("RouteID").ToString
        ucboRoute.DisplayMember = dtSet.Tables(0).Columns("RouteID").ToString
        ucboRoute.DisplayLayout.Bands(0).ColHeadersVisible = False

        '<<<NOTE:  This is how it should work.  But doing it this way, breaks ValidDivision(), so use old way temporarily.>>>
        'Dim SQLSelect As String
        'SQLSelect = "SELECT division as FldCode, division as FldLabel FROM " & HRTblPath & "Divisions ORDER BY division"
        'FillUCombo(ucboDivision, "", "", SQLSelect)
        'Cbo.DisplayLayout.Bands(0).Columns(FldCode).Hidden = HideFldCode

        dtAdapter = Nothing
        dtSet = Nothing

    End Sub

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

        dtAdapter = Nothing
        dtSet = Nothing

    End Function

    Private Function FetchTimeCardEmployeeName(ByVal p_iEmpId As Int32) As String

        Dim dtSet As New DataSet
        Dim strRoute As String = ""
        Dim strCondition As String = ""
        Dim iOfficeId As Int32 = 0

        ''Construct the Organization Where Clause
        'Select Case uopCompany.CheckedIndex
        '    Case 1 ' By Division
        '        strRoute = ucboRoute.Text
        '    Case 2 ' By Office
        '        iOfficeId = ucboOffice.Value
        'End Select

        'Construct the Organization Where Clause
        If cbByRoute.Checked = True And cbByOffice.Checked = True Then
            strRoute = ucboRoute.Text
            iOfficeId = ucboOffice.ValueMember
        ElseIf cbByRoute.Checked = False And cbByOffice.Checked = True Then
            iOfficeId = ucboOffice.Value
        End If


        'Construct the employee ID where clause
        strCondition = " AND e.ID = " & utDriverID.Text

        If cbActiveOnly.Checked Then
            FetchTimeCardEmployees(dtSet, strRoute, iOfficeId, strCondition)
        Else
            FetchAllTimeCardEmployees(dtSet, strRoute, iOfficeId, strCondition)
        End If

        If dtSet.Tables(0).Rows.Count = 1 Then
            FetchTimeCardEmployeeName = dtSet.Tables(0).Rows(0).Item("employee")
        Else
            FetchTimeCardEmployeeName = ""
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
    Private Sub StandardFormPrep()

        'Standard Code for Most Unison Form's Load Event
        AddHandler Me.Activated, AddressOf Form_Activated
        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

    End Sub

    Private Sub PopulateGrid()

        Dim dtSet As New DataSet
        Dim HidCols() As String ''= {"RowID", "OfficeID", "CheckOutDate", "PayRate", "LastUpdate", "OperatorId"}
        Dim i As Integer

        'Dim SummCol As String

        If FetchDriverActivityDetails(dtSet, _strCondition) Then

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

            'SummCol = "TotalHrs"

            'UltraGrid1.DisplayLayout.Bands(0).Summaries.Add(SummCol, Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns(SummCol), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
            'UltraGrid1.DisplayLayout.Bands(0).Summaries(SummCol).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
            UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


            UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

            UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
            UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

            LoadData2()

        End If

    End Sub
#End Region

#Region "Menu Routines"

#End Region

#Region "Search Routines"
    Private Sub utDriverID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles utDriverID.Validating
        ' Validate Entered Data
        If uopDriver.CheckedIndex = 1 Then
            If IsNumeric(utDriverID.Text) Then
                Dim strEmpName As String = FetchTimeCardEmployeeName(utDriverID.Text)
                If strEmpName = "" Then
                    lblDriverName.Text = "Employee Not Found"
                    _strError = "Employee Not Found"
                Else
                    lblDriverName.Text = strEmpName
                    _strError = ""
                End If
            Else
                lblDriverName.Text = "Please Enter a Valid Employee ID"
                _strError = "Please Enter a Valid Driver ID"
            End If
        Else
            _strError = ""
        End If
    End Sub
#End Region

#Region "Field Validation"

    Private Sub ucboOffice_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboOffice.Enter
        If ErrorProvider1.GetError(ucboOffice).ToString <> "" Then
            ucboOffice.Select()
        End If
    End Sub

    Private Sub ucboOffice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ucboOffice.Validating
        If Not ValidOfficeId(ucboOffice.Text) And cbByOffice.Checked = True Then
            SetError(ucboOffice, e, "Please Enter or Select a valid Office")
        End If
    End Sub

    Private Sub ucboOffice_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboOffice.Validated
        ClearError(ucboOffice)
    End Sub
#End Region

    Private Sub utDriverID_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utDriverID.Enter
        utDriverID.SelectAll()
    End Sub
    'MOVE TO THE UNISONVARS.vb

    Public Function FetchPrintRoutesDrivers(ByRef dtSet As System.Data.DataSet, Optional ByVal Division As String = "", Optional ByVal OfficeID As Int32 = 0, Optional ByVal Condition As String = "") As Boolean
        '**************************************************************************
        'SF - 5/6/2010 - Modified SQL Query to return all drivers.  When Office is determine by User, then the 
        '               code will filter by officeid.  For now office will be filtered by ucboOffice, if ucboOffice is populated
        '**************************************************************************
        Dim da As SqlDataAdapter
        Dim localConn As New SqlConnection(strConnection)
        Dim sqlDriverList As String
        'Dim sqlDriverTmpList As String = "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where TimeCardInput = 1 AND UserID IN (Select Group_Code as UserID from UN_UserMemberships where userid = '" & LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID) AND Company_Code = '" & LoginInfo.CompanyCode & "' @@OFFICEID ) @@ROUTE  ORDER BY e.ID "
        'Dim sqlDriverTmpList As String = "Select e.ID as DriverID, rtrim(e.LastName)+', '+rtrim(e.FirstNAme) as Driver, e.OfficeID,  isnull(so.Name, 'N/A') as Office, e.Company as Division, e.Status From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.ID in (Select EmployeeID from " & HRTblPath & "EmployeePayRates where ClassID = 4) AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where TimeCardInput = 1 AND UserID IN (Select Group_Code as UserID from UN_UserMemberships where userid = '" & LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID) AND Company_Code = '" & LoginInfo.CompanyCode & "' @@OFFICEID ) @@ROUTE  ORDER BY e.ID "
        Dim sqlDriverTmpList As String
        Dim sqlSelect As String
        Dim connstr, connstrBAK As String

        On Error GoTo ErrTrap

        FetchPrintRoutesDrivers = False

        sqlDriverTmpList = "SELECT e.ID as DriverID, rtrim(e.LastName)+', '+rtrim(e.FirstNAme) as Driver, e.OfficeID,  "
        sqlDriverTmpList = sqlDriverTmpList & " isnull(so.Name, 'N/A') as Office, e.Company as Division, e.Status  "
        sqlDriverTmpList = sqlDriverTmpList & " FROM " & AppTblPath & "Employeesbase e "
        sqlDriverTmpList = sqlDriverTmpList & "LEFT OUTER JOIN " & AppTblPath & "ServiceOffices so on e.OfficeId = so.ID "
        sqlDriverTmpList = sqlDriverTmpList & "WHERE e.STATUS = 'A' "
        If OfficeID <> 0 Then
            sqlDriverTmpList = sqlDriverTmpList & "AND e.OfficeID = " & OfficeID
        End If
        'SF - Per Sammy, needs to investigate how to use UN_Usermemberships to get office id by user logn
        'AND UserID IN "
        'sqlDriverTmpList = sqlDriverTmpList & "Select Group_Code as UserID FROM UN_UserMemberships WHERE "
        'sqlDriverTmpList = sqlDriverTmpList & "userid = '" & LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID) AND Company_Code = '" & LoginInfo.CompanyCode & "' @@OFFICEID ) @@ROUTE  ORDER BY e.ID"


        If dtSet Is Nothing Then
            dtSet = New DataSet
        Else
            If dtSet.Tables.Count > 0 Then
                dtSet.Tables.Clear()
                dtSet.Dispose()
                dtSet = Nothing
                dtSet = New DataSet
            End If
        End If

        'connstr = strConnection2.Replace("@DB", CFGDBName)
        'connstr = connstr.Replace("@USER", CFGDBUser)
        'connstr = connstr.Replace("@PASS", CFGDBPass)

        connstrBAK = strConnection
        'strConnection = connstr
        'sqlConn.ConnectionString = connstr 'strConnection

        da = New SqlDataAdapter
        sqlDriverList = sqlDriverTmpList.Replace("@@ROUTE", IIf(Division <> "", " AND Company = '" & Division & "'", ""))
        sqlDriverList = sqlDriverList.Replace("@@OFFICEID", IIf(OfficeID <> 0, " AND OfficeID = " & OfficeID & "", ""))
        sqlSelect = PrepSelectQuery(sqlDriverList, Condition)
        If PopulateDataset2(da, dtSet, sqlSelect) Is Nothing Then GoTo ErrTrap

        FetchPrintRoutesDrivers = True

ErrTrap:
        strConnection = connstrBAK
        sqlConn.ConnectionString = strConnection

        da.Dispose()
        da = Nothing
        localConn.Dispose()

    End Function

    Public Function FetchPrintAllRoutesDrivers(ByRef dtSet As System.Data.DataSet, Optional ByVal Division As String = "", Optional ByVal OfficeID As Int32 = 0, Optional ByVal Condition As String = "") As Boolean
        Dim da As SqlDataAdapter
        Dim localConn As New SqlConnection(strConnection)
        Dim sqlDriverList As String '= "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where UserID = '" & LoginInfo.UserID & "' AND Company_Code = '" & LoginInfo.CompanyCode & "' AND Division = '" & Division & "' ) AND Company = '" & Division & "' ORDER BY e.ID "
        'Dim sqlEmplTmpList As String = "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where UserID = '" & LoginInfo.UserID & "' AND Company_Code = '" & LoginInfo.CompanyCode & "' @@OFFICEID ) @@DIV  ORDER BY e.ID "
        Dim sqlDriverTmpList As String = "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where TimeCardInput = 1 AND UserID IN (Select Group_Code as UserID from UN_UserMemberships where userid = '" & LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID) AND Company_Code = '" & LoginInfo.CompanyCode & "' @@OFFICEID ) @@DIV  ORDER BY e.ID "
        Dim sqlSelect As String
        Dim connstr, connstrBAK As String

        On Error GoTo ErrTrap

        FetchPrintAllRoutesDrivers = False

        If dtSet Is Nothing Then
            dtSet = New DataSet
        Else
            If dtSet.Tables.Count > 0 Then
                dtSet.Tables.Clear()
                dtSet.Dispose()
                dtSet = Nothing
                dtSet = New DataSet
            End If
        End If

        connstr = strConnection2.Replace("@DB", CFGDBName)
        connstr = connstr.Replace("@USER", CFGDBUser)
        connstr = connstr.Replace("@PASS", CFGDBPass)

        connstrBAK = strConnection
        strConnection = connstr
        sqlConn.ConnectionString = connstr 'strConnection

        da = New SqlDataAdapter
        sqlDriverList = sqlDriverTmpList.Replace("@@ROUTE", IIf(Division <> "", " AND Company = '" & Division & "'", ""))
        sqlDriverList = sqlDriverList.Replace("@@OFFICEID", IIf(OfficeID <> 0, " AND OfficeID = " & OfficeID & "", ""))
        sqlSelect = PrepSelectQuery(sqlDriverList, Condition)
        If PopulateDataset2(da, dtSet, sqlSelect) Is Nothing Then GoTo ErrTrap

        FetchPrintAllRoutesDrivers = True

        da.Dispose()
        da = Nothing
        localConn.Dispose()
ErrTrap:
        strConnection = connstrBAK
        sqlConn.ConnectionString = strConnection

        da.Dispose()
        da = Nothing

    End Function

    Public Function FetchDriverActivityDetails(ByRef dtSet As System.Data.DataSet, ByVal Condition As String) As Boolean
        '**************************************************************************
        'SF - 5/5/2010 - Modified SQL Query to return routes and counts
        'SF - 5/6/2010 - **Note** Need to determine what Office by user id -->tcr.OfficeID  " & _
        '               " WHERE (tcr.TimeCardInput = 1 AND tcr.UserID IN (Select Group_Code as UserID 
        '               from " & CFGTblPath & "UN_UserMemberships where userid = '" & LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID)
        'SF - 5/6/2010 - Modified Condition string parameter in btnDisplay based on new SQL Query
        'SF - 5/12/2010 - Modified query to use new RouteSheets table
        '**************************************************************************
        Dim da As SqlDataAdapter
        'SF - Commented out due to run time errors on other screens
        'Dim localConn As New SqlConnection(strConnection)
        Dim sqlDriverList As String
        Dim connstrBAK As String
        'This the original SELECT for the grid
        'Dim sqlDriverTmpList As String = "SELECT ssch.ID, ssch.AccountID, ssch.SID, ssch.Day, ssch.ServiceDate, ssch.RouteNo, ssch.StopNo, " & _
        '" ssch.OfficeID, ssch.STime, ssch.CTime, ssch.Charge FROM " & ROUTESTblPath & "SERVICESCHEDULES AS ssch LEFT OUTER JOIN UN_HR.dbo.Employees ead on ead.EmployeeID = ssch.ID  " & _
        '" INNER JOIN UN_CFG.dbo.UN_HRTimeCardOfficeRights AS tcr ON ead.OfficeID = tcr.OfficeID  " & _
        '" WHERE (tcr.TimeCardInput = 1 AND tcr.UserID IN (Select Group_Code as UserID from " & CFGTblPath & "UN_UserMemberships where userid = '" & LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID) AND tcr.Company_Code = '" & LoginInfo.CompanyCode & "') "

        Try
            'This is the new SELECT for the grid
            Dim sqlDriverTmpList As String

            'sqlDriverTmpList = "Select o.name, rs.officeid, rs.routeno, e.FirstName + ' ' + e.Lastname as Driver, count(rs.row_id) as StopCount"
            sqlDriverTmpList = "Select o.name, rs.officeid, rs.routeno, driver, count(rs.row_id) as StopCount "
            sqlDriverTmpList = sqlDriverTmpList & ", AccountId, LocationId "
            sqlDriverTmpList = sqlDriverTmpList & " FROM " & ROUTESTblPath & "routesheets rs  "
            sqlDriverTmpList = sqlDriverTmpList & "LEFT OUTER JOIN " & AppTblPath & "serviceoffices o on o.id = rs.officeid "
            sqlDriverTmpList = sqlDriverTmpList & "LEFT OUTER JOIN " & AppTblPath & "routes2 r on r.officeid = rs.officeid and r.routeid = rs.routeno "
            sqlDriverTmpList = sqlDriverTmpList & "LEFT OUTER JOIN " & AppTblPath & "Employeesbase e on e.id = r.driverid "
            'sqlDriverTmpList = sqlDriverTmpList & "GROUP BY o.name, rs.Officeid, rs.routeno, e.firstname, e.lastname  "
            sqlDriverTmpList = sqlDriverTmpList & "GROUP BY o.name, rs.Officeid, rs.routeno, driver, AccountId, LocationId"


            Dim sqlSelect As String
            Dim connstr As String

            'On Error GoTo ErrTrap

            FetchDriverActivityDetails = False

            If dtSet Is Nothing Then
                dtSet = New DataSet
            Else
                If dtSet.Tables.Count > 0 Then
                    dtSet.Tables.Clear()
                    dtSet.Dispose()
                    dtSet = Nothing
                    dtSet = New DataSet
                End If
            End If

            'connstr = strConnection2.Replace("@DB", CFGDBName)
            'connstr = connstr.Replace("@USER", CFGDBUser)
            'connstr = connstr.Replace("@PASS", CFGDBPass)

            connstrBAK = strConnection
            'strConnection = connstr
            'sqlConn.ConnectionString = connstr 'strConnection

            da = New SqlDataAdapter
            sqlSelect = PrepSelectQuery(sqlDriverTmpList, Condition)
            'If PopulateDataset2(da, dtSet, sqlSelect) Is Nothing Then GoTo ErrTrap
            If PopulateDataset2(da, dtSet, sqlSelect) Is Nothing Then
            End If

            FetchDriverActivityDetails = True

        Catch ex As Exception
            'Message NOT modified by Michael Pastor, due to format being identical to modified version.
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Company Profile")
            strConnection = connstrBAK
            sqlConn.ConnectionString = strConnection

            da.Dispose()
            da = Nothing
            Exit Function
        Finally
            FetchDriverActivityDetails = True
            strConnection = connstrBAK
            sqlConn.ConnectionString = strConnection

            da.Dispose()
            da = Nothing

        End Try
        'ErrTrap:
        '        strConnection = connstrBAK
        '        sqlConn.ConnectionString = strConnection

        '        da.Dispose()
        '        da = Nothing

    End Function

    Private Sub uopDriver_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopDriver.ValueChanged
        If uopDriver.CheckedIndex = 0 Then
            utDriverID.Enabled = False
            utDriverID.Clear()
            lblDriverName.Text = ""
        ElseIf uopDriver.CheckedIndex = 1 Then
            utDriverID.Enabled = True
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '**************************************************************************
        'SF - 5/10/2010 - New button to call the Route Sheet report using the RouteSheet table.
        '**************************************************************************
        'strSqlCommand = "Select Distinct ss.RouteNo, ss.Stopno, mft2.AddressId, mft2.AccountID, mft2.ID as SID, c.name as AccountName, " & _
        '                    "mft2.CompName as [Location Name], a.locationid, mft2.Street, mft2.CityName as City, mft2.State, mft2.ZipCode, mft2.Phone1, " & _
        '                    "mft2.Remarks, mft2.DoorKey, mft2.BoxKey, " & _
        '                    "isnull(stp.Name, '') as [Service], " & _
        '                    "isnull(p.Name, '') as [Package], " & _
        '                    "ss.Day " & _
        '                    "FROM (((((((un_routes.dbo.serviceschedules ss " & _
        '                    "left outer JOIN unison.dbo.routes2 r on r.officeid = ss.officeid and r.routeid = ss.routeno) " & _
        '                    "left outer join un_routes.dbo.accountservices mft2 on mft2.AccountID = ss.AccountID and mft2.id = ss.sid) " & _
        '                    "LEFT OUTER JOIN unison.dbo.Customer c ON mft2.accountid = c.id) " & _
        '                    "LEFT OUTER JOIN unison.dbo.Services s ON mft2.ServiceID = s.ID) " & _
        '                    "LEFT OUTER JOIN unison.dbo.ServiceTypes stp ON mft2.ServiceTypeID = stp.ID) " & _
        '                    "LEFT OUTER JOIN unison.dbo.PackageTypes p ON mft2.PackageID = p.ID) " & _
        '                    "LEFT OUTER JOIN unison.dbo.Address a ON mft2.addressid = a.id) "
        strSqlCommand = "SELECT OfficeId, RouteNo, StopNo, SID, AccountID, AccountName, LocationName, LocationId, AddressID, Address, Address2, "
        strSqlCommand = strSqlCommand & "City, State, Zipcode, Phone, Comments, StartDate, EndDate, DoorKey, BoxKey, "
        strSqlCommand = strSqlCommand & "Service, Package, [Day], [Print], UserLogon, LastUpdateDate "
        strSqlCommand = strSqlCommand & "FROM " & ROUTESTblPath & "RouteSheets "

        strSqlCommand = strSqlCommand & "WHERE AddressId is not null  "
        If ucboOffice.Value <> 0 Then
            strSqlCommand = strSqlCommand & " AND officeid = " & ucboOffice.Value
        End If
        If ucboRoute.Value <> 0 Then
            strSqlCommand = strSqlCommand & " AND RouteNo = " & ucboRoute.Text
        End If

        Select Case uopDate.CheckedIndex
            Case 0 ' Date Range
                strSqlCommand = strSqlCommand & " AND (StartDate is not null AND (Enddate = '01/01/1900' or EndDate > CAST('" & udtTo.DateTime.ToShortDateString & "' AS DATETIME) )) "
                strSqlCommand = strSqlCommand & " AND Day = " & GetUnisonDay(udtDate.DateTime)
            Case 1 ' Specified Date
                strSqlCommand = strSqlCommand & " AND (StartDate is not null AND (Enddate = '01/01/1900' or EndDate > CAST('" & udtDate.DateTime.ToShortDateString & "' AS DATETIME) )) "
                strSqlCommand = strSqlCommand & " AND Day In (" & GetUnisonDays(udtFrom.DateTime, udtTo.DateTime) & ") "
        End Select

        strSqlCommand = strSqlCommand & " ORDER BY RouteNo "

        Dim x As New RouteSheetForm
        x.SqlCommand = strSqlCommand
        x.Show()
    End Sub

    Private Sub ucboOffice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboOffice.Leave
        GetRoutes()
    End Sub

    Private Sub ucboOffice_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboOffice.AfterCloseUp
        GetRoutes()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        '**************************************************************************
        'SF - 5/11/2010 - New button to generate records in RouteSheets table.  This table will be used 
        '                 for the Route Sheet report    
        'SF - 5/18/2010 - Modified query to use system date as start date and add 7 days from that
        '**************************************************************************
        Dim dtSet As New DataSet
        Dim SQLSelect As String
        Dim Cond As String
        Dim Cond2 As String
        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim row, rowtmp As DataRow
        Dim Cmd As SqlCommand
        Dim localConn As New SqlConnection(strConnection)

        Me.Cursor = Cursors.WaitCursor

        SQLSelect = "Select	ss.id, 	ss.OfficeId, r.Routeid, ss.Stopno, acs.AddressId, ss.SID,acs.AccountID, c.name, acs.CompName, a.locationid, "
        SQLSelect = SQLSelect & "a.id, acs.Street, acs.Address2, acs.CityName, acs.State, acs.ZipCode, acs.Phone1, acs.Remarks, acs.DoorKey, "
        SQLSelect = SQLSelect & "acs.BoxKey, isnull(stp.Name, ''), isnull(p.Name, ''), ss.Day, acs.StartDate, acs.EndDate,"
        SQLSelect = SQLSelect & "e.FirstName + ' ' + e.Lastname AS Driver, "
        SQLSelect = SQLSelect & "stp.Name as Service, p.Name as Package, ss.Day "
        SQLSelect = SQLSelect & "FROM ((((((((" & ROUTESTblPath & "serviceschedules ss "
        SQLSelect = SQLSelect & "LEFT OUTER JOIN " & AppTblPath & "routes2 r on r.officeid = ss.officeid and r.routeid = ss.routeno) "
        SQLSelect = SQLSelect & "LEFT OUTER JOIN " & ROUTESTblPath & "accountservices acs on acs.AccountID = ss.AccountID and acs.id = ss.sid) "
        SQLSelect = SQLSelect & "LEFT OUTER JOIN " & AppTblPath & "Customer c ON acs.accountid = c.id) "
        SQLSelect = SQLSelect & "LEFT OUTER JOIN " & AppTblPath & "Services s ON acs.ServiceID = s.ID) "
        SQLSelect = SQLSelect & "LEFT OUTER JOIN " & AppTblPath & "ServiceTypes stp ON acs.ServiceTypeID = stp.ID) "
        SQLSelect = SQLSelect & "LEFT OUTER JOIN " & AppTblPath & "PackageTypes p ON acs.PackageID = p.ID) "
        SQLSelect = SQLSelect & "LEFT OUTER JOIN " & AppTblPath & "Address a ON acs.addressid = a.id) "
        SQLSelect = SQLSelect & "LEFT OUTER JOIN  " & AppTblPath & "Employeesbase e on e.id = r.driverid) "

        'Construct the Whole Company Where Clause
        If cbWholeCompany.Checked = True Then
            strWhereRoute = ""
        ElseIf cbByRoute.Checked = True And cbByOffice.Checked = False Then
            If ucboRoute.Text = "" Then
                'strWhereRoute = strWhereRoute & " AND r.RouteId = NULL "
            Else
                strWhereRoute = strWhereRoute & " AND r.RouteId = '" & ucboRoute.Text & "' "
            End If
        ElseIf cbByOffice.Checked = True And cbByRoute.Checked = False Then
            If IsNumeric(ucboOffice.Text) Then
                Dim dataRows As DataRow()
                Dim dataRow As DataRow
                dataRows = ucboOffice.DataSource.Select("ID = " & ucboOffice.Text)
                'strWhereRoute = strWhereRoute & " AND o.name = '" & dataRows(0).Item("Name") & "' "
            Else
                strWhereRoute = strWhereRoute & " AND ss.officeid = " & ucboOffice.Value & " "
            End If
        ElseIf cbByOffice.Checked = True And cbByRoute.Checked = True Then
            If ucboRoute.Text = "" Then
                'strWhereRoute = strWhereRoute & " AND RouteId = NULL "
            Else
                strWhereRoute = strWhereRoute & " AND r.RouteId = '" & ucboRoute.Text & "' "
            End If

            If IsNumeric(ucboOffice.Text) Then
                Dim dataRows As DataRow()
                Dim dataRow As DataRow
                dataRows = ucboOffice.DataSource.Select("ID = " & ucboOffice.Text)
                'strWhereRoute = strWhereRoute & " AND o.name = '" & dataRows(0).Item("Name") & "' "
            Else
                strWhereRoute = strWhereRoute & " AND ss.officeid = '" & ucboOffice.Value & "' "
            End If
        End If

        'Construct the Date Where Clause
        'Select Case uopDate.CheckedIndex
        '    Case 0 ' Date Range
        '        strWhereRoute = strWhereRoute & " AND (StartDate is not null AND (Enddate is null or EndDate > CAST('" & udtDate.DateTime.ToShortDateString & "' AS DATETIME) )) "
        '        strWhereRoute = strWhereRoute & " AND Day = " & GetUnisonDay(udtDate.DateTime)
        '    Case 1 ' Specified Date
        '        strWhereRoute = strWhereRoute & " AND (StartDate is not null AND (Enddate is null or EndDate > CAST('" & udtTo.DateTime.ToShortDateString & "' AS DATETIME) )) "
        '        strWhereRoute = strWhereRoute & " AND Day In (" & GetUnisonDays(udtFrom.DateTime, udtTo.DateTime) & ") "
        'End Select

        strWhereRoute = " AND (StartDate is not null AND (Enddate is null or EndDate > getdate() "
        strWhereRoute = strWhereRoute & " AND [Day] In (" & GetUnisonDays(Now, DateAdd(DateInterval.Day, 7, Now)) & ") )) "

        'Construct the Driver Where Clause
        Select Case uopDriver.CheckedIndex
            Case 0 ' All Drivers
            Case 1 ' By Driver
                strWhereRoute = strWhereRoute & " AND e.id = " & utDriverID.Text
        End Select

        'SQLSelect = SQLSelect & " " & strWhereRoute

        SQLSelect = PrepSelectQuery(SQLSelect, strWhereRoute)
        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        Dim boolDataCheck As Boolean

        Try
            localConn.Open()

            If dtSet.Tables(0).Rows.Count > 0 Then

                For Each row In dtSet.Tables(0).Rows
                    SQLSelect = ""
                    If CheckExisting(row) Then
                        If Not DeleteFromRouteSheets() Then
                            SQLSelect = "Update " & ROUTESTblPath & "RouteSheets Set OfficeId = " & row("officeid") & ", RouteNo = '" & row("Routeid") & "', "
                            SQLSelect = SQLSelect & "StopNo = " & row("Stopno") & ", AccountName = '" & row("name") & "', LocationName = '" & row("CompName") & "', "
                            SQLSelect = SQLSelect & "Addressid = " & row("AddressId") & ", Address = '" & row("Street") & "', Address2 = '" & row("Address2") & "', "
                            SQLSelect = SQLSelect & "City = '" & row("CityName") & "', State = '" & row("State") & "', Zipcode = '" & row("ZipCode") & "', "
                            SQLSelect = SQLSelect & "Phone = '" & row("Phone1") & "', Comments = '" & row("remarks") & "', StartDate = '" & row("startdate") & "', "
                            SQLSelect = SQLSelect & "EndDate = '" & row("EndDate") & "', DoorKey = " & IIf(row("DoorKey"), 1, 0) & ", BoxKey = " & IIf(row("BoxKey"), 1, 0) & ", "
                            SQLSelect = SQLSelect & "Service = '" & row("Service") & "', Package = '" & row("Package") & "', [Day] = " & row("Day") & ", "
                            SQLSelect = SQLSelect & "Driver = '" & row("Driver") & "', UserLogon = '" & LoginInfo.UserID & "', LastUpdateDate =  getdate() "
                            SQLSelect = SQLSelect & " WHERE row_id = " & row("id")
                        End If

                    Else
                        SQLSelect = "INSERT INTO " & ROUTESTblPath & "RouteSheets VALUES (" & row("id") & ", " & row("officeid") & ", '" & row("Routeid") & "' "
                        SQLSelect = SQLSelect & ", " & row("Stopno") & ", " & row("Sid") & ", " & row("AccountId") & ", "
                        SQLSelect = SQLSelect & "'" & row("name") & "', '" & row("CompName") & "', '" & row("LocationId") & "', " & row("AddressId") & ", "
                        SQLSelect = SQLSelect & "'" & row("Street") & "', '" & row("Address2") & "', '" & row("CityName") & "', '" & row("State") & "', '" & row("ZipCode") & "', "
                        SQLSelect = SQLSelect & "'" & row("Phone1") & "', '" & row("remarks") & "', '" & row("startdate") & "', '" & row("EndDate") & "', "
                        SQLSelect = SQLSelect & IIf(row("DoorKey"), 1, 0) & ", " & IIf(row("BoxKey"), 1, 0) & ", '" & row("Service") & "', '" & row("Package") & "', "
                        SQLSelect = SQLSelect & row("Day") & ", 1,'" & row("Driver") & "', '" & LoginInfo.UserID & "', getdate() ) "
                    End If

                    If SQLSelect <> "" Then
                        Cmd = New SqlCommand(SQLSelect, localConn)

                        With Cmd
                            .CommandText = SQLSelect
                            .CommandType = CommandType.Text
                            .ExecuteNonQuery()

                            .Dispose()
                        End With
                    End If
                Next

            End If


            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            dtSet = Nothing
            dtAdapter = Nothing
            row = Nothing
            rowtmp = Nothing
            Cmd = Nothing
            localConn = Nothing
        End Try
    End Sub

    Private Function DeleteFromRouteSheets() As Boolean
        '**************************************************************************
        'SF - 5/18/2010 - Routine to check ServiceSchedules to see if a route has been deleted.
        '                 If so, then delete from RouteSheets
        '**************************************************************************
        Dim dtAdapter As SqlDataAdapter
        Dim dtset As DataSet
        Dim dtRouteSet As DataSet

        Dim SQLSelect As String
        Dim strId As String
        Dim Cmd As SqlCommand
        Dim localConn As New SqlConnection(strConnection)
        Dim row As DataRow
        Dim RouteRow As DataRow

        'SQLSelect = "Select	ss.OfficeId, ss.Routeno, ss.Day "
        'SQLSelect = SQLSelect & "FROM " & ROUTESTblPath & "serviceschedules ss "
        'SQLSelect = SQLSelect & "WHERE OfficeId = " & dtRow("OfficeId") & " AND RouteNo = '" & dtRow("RouteId") & "' AND [Day] = " & dtRow("Day")
        SQLSelect = "SELECT * FROM " & ROUTESTblPath & "RouteSheets "

        Try
            PopulateDataset2(dtAdapter, dtset, SQLSelect)

            localConn.Open()

            For Each row In dtset.Tables(0).Rows
                If dtset.Tables(0).Rows.Count > 0 Then
                    SQLSelect = "Select	* "
                    SQLSelect = SQLSelect & "FROM " & ROUTESTblPath & "serviceschedules ss "
                    SQLSelect = SQLSelect & "LEFT OUTER JOIN " & ROUTESTblPath & "accountservices acs on acs.AccountID = ss.AccountID and acs.id = ss.sid "
                    SQLSelect = SQLSelect & "WHERE ss.OfficeId = " & row("OfficeId") & " AND "
                    SQLSelect = SQLSelect & "RouteNo = '" & row("RouteNo") & "' AND [Day] = " & row("Day")
                    SQLSelect = SQLSelect & " AND acs.AccountId = " & row("AccountId")

                    PopulateDataset2(dtAdapter, dtRouteSet, SQLSelect)

                    If dtRouteSet.Tables(0).Rows.Count = 0 Then
                        SQLSelect = "DELETE  "
                        SQLSelect = SQLSelect & "FROM " & ROUTESTblPath & "RouteSheets "
                        SQLSelect = SQLSelect & "WHERE OfficeId = " & row("OfficeId") & " AND RouteNo = '" & row("Routeno") & "' AND [Day] = " & row("Day")

                        Cmd = New SqlCommand(SQLSelect, localConn)

                        With Cmd
                            .CommandText = SQLSelect
                            .CommandType = CommandType.Text
                            .ExecuteNonQuery()

                            .Dispose()
                        End With

                        DeleteFromRouteSheets = True
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Function CheckExisting(ByVal dtRows As DataRow) As Boolean
        '**************************************************************************
        'SF - 5/17/2010 - Routine to check for existing records in RouteSheets.  Return true to update and false to insert
        '                  in RouteSheets
        '**************************************************************************
        Dim dtAdapter As SqlDataAdapter
        Dim dtset As DataSet
        Dim SQLSelect As String
        Dim strId As String

        strId = dtRows("id")

        SQLSelect = "SELECT * FROM " & ROUTESTblPath & "RouteSheets "
        SQLSelect = SQLSelect & " WHERE row_id = " & strId

        Try
            PopulateDataset2(dtAdapter, dtset, SQLSelect)

            If dtset.Tables(0).Rows.Count > 0 Then
                CheckExisting = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Function

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        Call LoadData2()
    End Sub

    Private Sub LoadData2()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, SQLSelect2, Cond As String
        Dim Cond2 As String
        Dim strDayCase As String

        Dim dtSet As New DataSet
        Dim HidCols() As String = {"Row_ID"}

        Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        strDayCase = "	CASE [Day] When 1 Then 'Monday' When 2 Then 'Tuesday' When 3 Then 'Wednesday' When 4 Then 'Thursday' When 5 Then 'Friday' When 6 Then 'Saturday' When 7 Then 'Sunday' END AS [Route Day] "

        SQLSelect = "SELECT [Print], o.name, OfficeId, RouteNo, StopNo, " & strDayCase & ", SID, Address, LocationName, LocationId, Driver "
        SQLSelect = SQLSelect & ", AccountId, LocationId "
        SQLSelect = SQLSelect & " FROM " & ROUTESTblPath & "routesheets  "
        SQLSelect = SQLSelect & " LEFT OUTER JOIN " & AppTblPath & "serviceoffices o on o.id = " & ROUTESTblPath & "routesheets.officeid "
        'SQLSelect = SQLSelect & " WHERE OfficeId = @OfficeId and RouteNo = @RouteNo "
        If cbByOffice.Checked Then
            If ucboOffice.Text <> "" And ucboRoute.Text = "" Then
                SQLSelect = SQLSelect & " WHERE OfficeId = " & ucboOffice.Value
            ElseIf ucboOffice.Text <> "" And ucboRoute.Text <> "" Then
                SQLSelect = SQLSelect & " WHERE OfficeId = " & ucboOffice.Value & "  and RouteNo = " & ucboRoute.Value
            ElseIf ucboOffice.Text = "" And ucboRoute.Text = "" Then
                SQLSelect = SQLSelect & " WHERE  RouteNo = " & ucboRoute.Value
            End If
        Else
        SQLSelect = SQLSelect & " WHERE OfficeId = @OfficeId and RouteNo = @RouteNo "
        End If

        If uopDate.CheckedIndex = 0 Then
            SQLSelect = SQLSelect & " AND Day = " & GetUnisonDay(udtDate.DateTime)
        Else
            SQLSelect = SQLSelect & " AND Day In(" & GetUnisonDays(udtFrom.DateTime, udtTo.DateTime) & ") "
        End If
        SQLSelect = SQLSelect & " ORDER BY OfficeId, RouteNo, [Day], StopNo "

        If Not UltraGrid1.ActiveRow Is Nothing Then
            If Not UltraGrid1.ActiveRow.ListObject Is Nothing Then
                Cond = " " & UltraGrid1.ActiveRow.Cells("officeid").Value & " "
                Cond2 = " " & UltraGrid1.ActiveRow.Cells("routeno").Value & " "
            Else
                Exit Sub
            End If
        End If

        SQLSelect = SQLSelect.Replace("@OfficeId", Cond)
        SQLSelect = SQLSelect.Replace("@RouteNo", Cond2)


        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        FillUltraGrid(UltraGrid2, dtSet, -1, HidCols, 0)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            If i <> 0 And i <> 3 And i <> 9 Then
                dtSet.Tables(0).Columns(i).ReadOnly = True
            End If
        Next

    End Sub

    '===================================================================
    Private Sub SetupSchCols()
        Dim i As Integer
        Dim col As DataColumn

        If Not WCols(0) Is Nothing Then
            Exit Sub
        End If

        For i = 0 To WCols.Length - 1
            WCols(i) = New SchCols
        Next

        'SELECT [Print], o.name, OfficeId, RouteNo, StopNo, " & strDayCase & ", SID, Address, LocationName, LocationId, Driver "

        WCols(0).Name = "Print"
        WCols(0).Type = GetType(System.Byte)
        WCols(0).Format = ""
        WCols(0).NoEdit = False
        WCols(0).MaxLength = 3
        WCols(0).Width = 30

        WCols(1).Name = "Office"
        WCols(1).Type = GetType(System.String)
        WCols(1).Format = ""
        WCols(1).NoEdit = True
        WCols(1).Hide = False
        WCols(1).Width = 40

        WCols(2).Name = "Office ID"
        WCols(2).Type = GetType(System.Int16)
        WCols(2).Format = ""
        WCols(2).NoEdit = True
        WCols(2).Hide = False
        WCols(2).Width = 30

        WCols(3).Name = "Route No"
        WCols(3).Type = GetType(System.String)
        WCols(3).Format = ""
        WCols(3).NoEdit = False
        WCols(2).Hide = False
        WCols(3).Width = 40

        WCols(4).Name = "Stop"
        WCols(4).Type = GetType(System.Int16)
        WCols(4).Format = ""
        WCols(4).NoEdit = False
        WCols(4).Hide = False
        WCols(4).Width = 20

        WCols(5).Name = "Day"
        WCols(5).Type = GetType(System.String)
        WCols(5).Format = ""
        WCols(5).NoEdit = True
        WCols(5).Hide = False
        WCols(5).Width = 40

        WCols(6).Name = "SID"
        WCols(6).Type = GetType(System.Int16)
        WCols(6).Format = ""
        WCols(6).NoEdit = True
        WCols(6).Hide = False
        WCols(6).Width = 40

        WCols(7).Name = "Address"
        WCols(7).Type = GetType(System.String)
        WCols(7).Format = ""
        WCols(7).NoEdit = False
        WCols(7).Hide = False
        WCols(7).Width = 30

        WCols(8).Name = "Location"
        WCols(8).Type = GetType(System.String)
        WCols(8).Format = ""
        WCols(8).NoEdit = True
        WCols(8).Hide = False
        WCols(8).Width = 50

        WCols(9).Name = "Location ID"
        WCols(9).Type = GetType(System.String)
        WCols(9).Format = ""
        WCols(9).NoEdit = True
        WCols(9).Hide = False
        WCols(9).Width = 20

        WCols(10).Name = "Driver"
        WCols(10).Type = GetType(System.String)
        WCols(10).Format = ""
        WCols(10).NoEdit = True
        WCols(10).Hide = False
        WCols(10).Width = 50

        'StatusTable.Clear()
        'StatusTable.Columns.Clear()

        'For i = 0 To WCols.Length - 1
        '    StatusTable.Columns.Add(WCols(i).Name, WCols(i).Type)
        'Next

        ' -- These functions are called separately --
        'AddWeeklyRows()
        'SetSchedDSBlank(StatusTable)

    End Sub

    Function GetUnisonDay(ByVal dtEndDate As Date) As Integer
        Dim intUnisonDay As Integer
        Dim intVBDay As Integer

        intVBDay = DatePart(DateInterval.Weekday, dtEndDate)

        Select Case intVBDay
            Case 1
                intUnisonDay = 7
            Case 2
                intUnisonDay = 1
            Case 3
                intUnisonDay = 2
            Case 4
                intUnisonDay = 3
            Case 5
                intUnisonDay = 4
            Case 6
                intUnisonDay = 5
            Case 7
                intUnisonDay = 6

        End Select

        GetUnisonDay = intUnisonDay

    End Function

    Function GetUnisonDays(ByVal dtStartDate As Date, ByVal dtEndDate As Date) As String
        Dim intUnisonDay As Integer
        Dim strDays As String
        Dim lngDateDiff As Long
        Dim i As Long
        Dim dtDatetoCheck As Date

        lngDateDiff = DateDiff(DateInterval.Day, dtStartDate, dtEndDate)

        For i = 0 To lngDateDiff
            dtDatetoCheck = DateAdd(DateInterval.Day, i, dtStartDate)
            strDays = strDays & CStr(GetUnisonDay(dtDatetoCheck)) & ","

            If i = 6 Then Exit For
        Next

        strDays = Microsoft.VisualBasic.Left(strDays, Microsoft.VisualBasic.Len(strDays) - 1)


        GetUnisonDays = strDays

    End Function

    Private Sub cbByRoute_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbByRoute.CheckedChanged
        If cbByRoute.Checked Then
            ucboRoute.Text = ""
            ClearError(ucboRoute)
            ucboRoute.Enabled = True
            'cbByRoute.CheckState = CheckState.Unchecked
            'cbByRoute.Enabled = True
        Else
            ucboRoute.Text = ""
            ClearError(ucboRoute)
            ucboRoute.Enabled = False
            'cbByRoute.CheckState = CheckState.Unchecked
            'cbByRoute.Enabled = False
        End If
    End Sub

    Private Sub cbByOffice_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbByOffice.CheckedChanged
        If cbByOffice.Checked Then
            ucboOffice.Text = ""
            ClearError(ucboOffice)
            ucboOffice.Enabled = True

            ucboRoute.Text = ""
            ClearError(ucboRoute)
            ucboRoute.Enabled = True
            'cbByOffice.CheckState = CheckState.Unchecked
            'cbByOffice.Enabled = True
            cbByRoute.CheckState = CheckState.Unchecked
            cbByRoute.Enabled = True
        Else
            ucboOffice.Text = ""
            ClearError(ucboOffice)
            ucboOffice.Enabled = False
            'cbByOffice.CheckState = CheckState.Unchecked
            'cbByOffice.Enabled = False

            ucboRoute.Text = ""
            ClearError(ucboRoute)
            ucboRoute.Enabled = False
            cbByRoute.CheckState = CheckState.Unchecked
            cbByRoute.Enabled = False
        End If
    End Sub

    Private Sub uopDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopDate.ValueChanged
        Select Case uopDate.CheckedIndex
            Case 0 '
                udtFrom.Enabled = False
                udtTo.Enabled = False
            Case 1
                udtFrom.Enabled = True
                udtTo.Enabled = True
        End Select
    End Sub


    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim x As New frmBillingTest
        x.Show()

    End Sub


    Private Sub bnRemoveTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnRemoveTest.Click
        '    '**************************************************************************
        '    'SF - 6/7/2010 - Button to test removing from billing collection class
        '    '**************************************************************************

        '    Dim strSQL As String
        '    Dim dtAdapter As SqlDataAdapter
        '    Dim i As Integer
        '    Dim intLoop As Long
        '    Dim dtSet As New DataSet

        '    Dim oSIDIn As SID
        '    Dim oSIDCollection As New SIDCollection


        '    Dim strData As String

        '    'clsSid = New SIDsInfo

        '    Dim row As DataRow

        '    strSQL = "SELECT * FROM " & ROUTESTblPath & "AccountServices ORDER BY RowID "

        '    PopulateDataset2(dtAdapter, dtSet, strSQL)

        '    'Call clsSid.Init()
        '    'clsItms = New Items

        '    If dtSet.Tables(0).Rows.Count > 0 Then
        '        For Each row In dtSet.Tables(0).Rows
        '            i = i + 1
        '            oSIDIn = New SID(row("rowid"))

        '            If GetServiceIdBillingStatus(row, oSIDIn) = True Then
        '                'MessageBox.Show("RowId #" & row("rowid") & " is active for this billing period")
        '                oSIDCollection.Add(oSIDIn)
        '                'oSIDIn = Nothing
        '            Else

        '            End If
        '            'clsSid.mclsSidItms.Add(row("rowid"), i, i.ToString)
        '            'clsSid = clsItms.Item(i)
        '        Next
        '    End If


        '    Try
        '        For Each oSIDOut As SID In oSIDCollection
        '            'MessageBox.Show("RowId for SID = " & oSIDOut.RowId.ToString)
        '            If oSIDCollection.Count > 0 Then oSIDCollection.Remove(oSIDOut)

        '            'MessageBox.Show(Str(oSIDCollection.Count))
        '        Next

        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString)
        '    Finally
        '        oSIDIn = Nothing
        '        oSIDCollection = Nothing
        '    End Try
    End Sub


    Private Sub btnZTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZTest.Click
        Dim x As New frmBillingZTest
        x.Show()
    End Sub
End Class
