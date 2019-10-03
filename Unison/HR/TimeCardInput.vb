Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Math
Imports System.Drawing.Graphics


Public Class TimeCardInput

    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Friend ScreenCode As String
    Dim KeyBuffer(2) As Object
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim PreviousDeptNo As String = ""

#Region "Members"

    Private _userId As Integer
    Private _iCount As Integer
    Private _iDateSection As Integer ' 1 = highlight month, 2 = highlight day, 3 = highlight year, 4 = highlight all
    Private _cValidate As clsFieldValidator
    Private _bFillGrid As Boolean
    Private cmdTrans As SqlCommand = Nothing
    Private _workDate As clsWorkDate

    Private _strClipDeptNo As String
    Private _strClipTimeIn As String
    Private _strClipTimeOut As String
    Private _strClipBreakHrs As String
    Private _strClipOfficeID As String
    Private _strClipPayRate As String
    Private _strClipOffice As String
    Private _strClipTotalHours As String

    Public strDivision As String
    Public datePayrollEndDate As Date

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
    Friend WithEvents btnExit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboEmpId As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents dpWorked As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtTimeIn As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtTimeOut As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtBreakHrs As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblDateWorked As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ulblTotalHrs As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblEmpName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblBreakTime As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTimeOut As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTimeIn As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblEmpId As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtOfficeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtOffice As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtPayRate As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtCheckOutDate As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboDeptNo As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ulblDeptNo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ulblWeekEnding As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ulblDivision As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnEdit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtWeekEnding As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents utTotalHrs As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utRowID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblPayrollEnding As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblDivision As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utUserID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents utRegTotal As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utOTTotal As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents utDTTotal As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents utGross As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnPaste As System.Windows.Forms.Button
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
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
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.btnExit = New Infragistics.Win.Misc.UltraButton
        Me.cboEmpId = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.dpWorked = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtTimeIn = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtTimeOut = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtBreakHrs = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.btnSave = New Infragistics.Win.Misc.UltraButton
        Me.lblDateWorked = New Infragistics.Win.Misc.UltraLabel
        Me.ulblTotalHrs = New Infragistics.Win.Misc.UltraLabel
        Me.lblEmpName = New Infragistics.Win.Misc.UltraLabel
        Me.lblBreakTime = New Infragistics.Win.Misc.UltraLabel
        Me.lblTimeOut = New Infragistics.Win.Misc.UltraLabel
        Me.lblTimeIn = New Infragistics.Win.Misc.UltraLabel
        Me.lblName = New Infragistics.Win.Misc.UltraLabel
        Me.lblEmpId = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnEdit = New Infragistics.Win.Misc.UltraButton
        Me.txtOfficeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtOffice = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtPayRate = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtCheckOutDate = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboDeptNo = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ulblDeptNo = New Infragistics.Win.Misc.UltraLabel
        Me.ulblWeekEnding = New Infragistics.Win.Misc.UltraLabel
        Me.ulblDivision = New Infragistics.Win.Misc.UltraLabel
        Me.txtWeekEnding = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.utUserID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lblDivision = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lblPayrollEnding = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnPaste = New System.Windows.Forms.Button
        Me.btnCopy = New System.Windows.Forms.Button
        Me.utTotalHrs = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utRowID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.utGross = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.utDTTotal = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.utOTTotal = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.utRegTotal = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        CType(Me.cboEmpId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dpWorked, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimeIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBreakHrs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPayRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCheckOutDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDeptNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeekEnding, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.utUserID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPayrollEnding, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.utTotalHrs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.utGross, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utDTTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOTTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRegTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(714, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 22)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "E&xit"
        '
        'cboEmpId
        '
        Me.cboEmpId.DisplayMember = ""
        Me.cboEmpId.Location = New System.Drawing.Point(114, 45)
        Me.cboEmpId.Name = "cboEmpId"
        Me.cboEmpId.Size = New System.Drawing.Size(118, 21)
        Me.cboEmpId.TabIndex = 2
        Me.cboEmpId.Tag = ".EmployeeId"
        Me.cboEmpId.ValueMember = ""
        '
        'dpWorked
        '
        Me.dpWorked.DateTime = New Date(2006, 3, 31, 0, 0, 0, 0)
        Me.dpWorked.Location = New System.Drawing.Point(114, 16)
        Me.dpWorked.Name = "dpWorked"
        Me.dpWorked.Size = New System.Drawing.Size(100, 21)
        Me.dpWorked.TabIndex = 0
        Me.dpWorked.Tag = ".CheckInDate"
        Me.dpWorked.Value = New Date(2006, 3, 31, 0, 0, 0, 0)
        '
        'txtTimeIn
        '
        Me.txtTimeIn.Location = New System.Drawing.Point(112, 48)
        Me.txtTimeIn.Name = "txtTimeIn"
        Me.txtTimeIn.Size = New System.Drawing.Size(100, 21)
        Me.txtTimeIn.TabIndex = 1
        Me.txtTimeIn.Tag = ".TimeIn"
        '
        'txtTimeOut
        '
        Me.txtTimeOut.Location = New System.Drawing.Point(112, 72)
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.Size = New System.Drawing.Size(100, 21)
        Me.txtTimeOut.TabIndex = 2
        Me.txtTimeOut.Tag = ".TimeOut"
        '
        'txtBreakHrs
        '
        Me.txtBreakHrs.Location = New System.Drawing.Point(112, 96)
        Me.txtBreakHrs.Name = "txtBreakHrs"
        Me.txtBreakHrs.Size = New System.Drawing.Size(100, 21)
        Me.txtBreakHrs.TabIndex = 3
        Me.txtBreakHrs.Tag = ".BreakTime"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 22)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'lblDateWorked
        '
        Appearance1.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance1.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblDateWorked.Appearance = Appearance1
        Me.lblDateWorked.Location = New System.Drawing.Point(8, 19)
        Me.lblDateWorked.Name = "lblDateWorked"
        Me.lblDateWorked.Size = New System.Drawing.Size(96, 16)
        Me.lblDateWorked.TabIndex = 7
        Me.lblDateWorked.Text = "Date Worked:"
        '
        'ulblTotalHrs
        '
        Appearance2.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance2.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblTotalHrs.Appearance = Appearance2
        Me.ulblTotalHrs.Location = New System.Drawing.Point(16, 123)
        Me.ulblTotalHrs.Name = "ulblTotalHrs"
        Me.ulblTotalHrs.Size = New System.Drawing.Size(80, 16)
        Me.ulblTotalHrs.TabIndex = 13
        Me.ulblTotalHrs.Text = "Total Hours:"
        '
        'lblEmpName
        '
        Appearance3.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance3.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblEmpName.Appearance = Appearance3
        Me.lblEmpName.Location = New System.Drawing.Point(114, 76)
        Me.lblEmpName.Name = "lblEmpName"
        Me.lblEmpName.Size = New System.Drawing.Size(174, 21)
        Me.lblEmpName.TabIndex = 3
        '
        'lblBreakTime
        '
        Appearance4.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance4.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblBreakTime.Appearance = Appearance4
        Me.lblBreakTime.Location = New System.Drawing.Point(16, 96)
        Me.lblBreakTime.Name = "lblBreakTime"
        Me.lblBreakTime.Size = New System.Drawing.Size(80, 16)
        Me.lblBreakTime.TabIndex = 14
        Me.lblBreakTime.Text = "Break Length"
        '
        'lblTimeOut
        '
        Appearance5.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance5.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblTimeOut.Appearance = Appearance5
        Me.lblTimeOut.Location = New System.Drawing.Point(16, 72)
        Me.lblTimeOut.Name = "lblTimeOut"
        Me.lblTimeOut.Size = New System.Drawing.Size(80, 16)
        Me.lblTimeOut.TabIndex = 9
        Me.lblTimeOut.Text = "Time Out:"
        '
        'lblTimeIn
        '
        Appearance6.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance6.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblTimeIn.Appearance = Appearance6
        Me.lblTimeIn.Location = New System.Drawing.Point(16, 48)
        Me.lblTimeIn.Name = "lblTimeIn"
        Me.lblTimeIn.Size = New System.Drawing.Size(80, 16)
        Me.lblTimeIn.TabIndex = 8
        Me.lblTimeIn.Text = "Time In:"
        '
        'lblName
        '
        Appearance7.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance7.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblName.Appearance = Appearance7
        Me.lblName.Location = New System.Drawing.Point(8, 77)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(96, 16)
        Me.lblName.TabIndex = 11
        Me.lblName.Text = "Employee Name:"
        '
        'lblEmpId
        '
        Appearance8.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance8.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblEmpId.Appearance = Appearance8
        Me.lblEmpId.Location = New System.Drawing.Point(8, 47)
        Me.lblEmpId.Name = "lblEmpId"
        Me.lblEmpId.Size = New System.Drawing.Size(96, 16)
        Me.lblEmpId.TabIndex = 10
        Me.lblEmpId.Text = "Employee ID:"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraGrid1.Location = New System.Drawing.Point(312, 216)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(480, 309)
        Me.UltraGrid1.TabIndex = 2
        Me.UltraGrid1.TabStop = False
        Me.UltraGrid1.Text = "Time-Card Inputs for Current Employee For The Selected Payroll-Ending"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(496, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 22)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'txtOfficeID
        '
        Me.txtOfficeID.Location = New System.Drawing.Point(228, 72)
        Me.txtOfficeID.Name = "txtOfficeID"
        Me.txtOfficeID.Size = New System.Drawing.Size(64, 21)
        Me.txtOfficeID.TabIndex = 4
        Me.txtOfficeID.Tag = ".OfficeID"
        Me.txtOfficeID.Text = "OfficeID - Hidden"
        Me.txtOfficeID.Visible = False
        '
        'txtOffice
        '
        Me.txtOffice.Location = New System.Drawing.Point(228, 120)
        Me.txtOffice.Name = "txtOffice"
        Me.txtOffice.Size = New System.Drawing.Size(64, 21)
        Me.txtOffice.TabIndex = 6
        Me.txtOffice.Tag = ".Office"
        Me.txtOffice.Text = "Office - Hidden"
        Me.txtOffice.Visible = False
        '
        'txtPayRate
        '
        Me.txtPayRate.Location = New System.Drawing.Point(230, 97)
        Me.txtPayRate.Name = "txtPayRate"
        Me.txtPayRate.Size = New System.Drawing.Size(64, 21)
        Me.txtPayRate.TabIndex = 5
        Me.txtPayRate.Tag = ".PayRate"
        Me.txtPayRate.Text = "PayRate - Hidden"
        Me.txtPayRate.Visible = False
        '
        'txtCheckOutDate
        '
        Me.txtCheckOutDate.Location = New System.Drawing.Point(228, 48)
        Me.txtCheckOutDate.Name = "txtCheckOutDate"
        Me.txtCheckOutDate.Size = New System.Drawing.Size(64, 21)
        Me.txtCheckOutDate.TabIndex = 3
        Me.txtCheckOutDate.Tag = ".CheckOutDate"
        Me.txtCheckOutDate.Text = "CheckOutDate - Hidden"
        Me.txtCheckOutDate.Visible = False
        '
        'ucboDeptNo
        '
        Me.ucboDeptNo.DisplayMember = ""
        Me.ucboDeptNo.Location = New System.Drawing.Point(112, 24)
        Me.ucboDeptNo.Name = "ucboDeptNo"
        Me.ucboDeptNo.Size = New System.Drawing.Size(112, 21)
        Me.ucboDeptNo.TabIndex = 0
        Me.ucboDeptNo.Tag = ".DeptNo..1.EmployeePayRates.DeptNo.DeptNo"
        Me.ucboDeptNo.ValueMember = ""
        '
        'ulblDeptNo
        '
        Appearance9.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance9.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblDeptNo.Appearance = Appearance9
        Me.ulblDeptNo.Location = New System.Drawing.Point(16, 24)
        Me.ulblDeptNo.Name = "ulblDeptNo"
        Me.ulblDeptNo.Size = New System.Drawing.Size(88, 16)
        Me.ulblDeptNo.TabIndex = 27
        Me.ulblDeptNo.Text = "Dept. No.:"
        '
        'ulblWeekEnding
        '
        Appearance10.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance10.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblWeekEnding.Appearance = Appearance10
        Me.ulblWeekEnding.Location = New System.Drawing.Point(16, 72)
        Me.ulblWeekEnding.Name = "ulblWeekEnding"
        Me.ulblWeekEnding.Size = New System.Drawing.Size(88, 16)
        Me.ulblWeekEnding.TabIndex = 30
        Me.ulblWeekEnding.Text = "Week Ending:"
        '
        'ulblDivision
        '
        Appearance11.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance11.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblDivision.Appearance = Appearance11
        Me.ulblDivision.Location = New System.Drawing.Point(16, 19)
        Me.ulblDivision.Name = "ulblDivision"
        Me.ulblDivision.Size = New System.Drawing.Size(88, 16)
        Me.ulblDivision.TabIndex = 31
        Me.ulblDivision.Text = "Division:"
        '
        'txtWeekEnding
        '
        Appearance12.FontData.Name = "Arial Black"
        Appearance12.FontData.SizeInPoints = 9.75!
        Appearance12.ForeColor = System.Drawing.Color.Blue
        Appearance12.ForeColorDisabled = System.Drawing.Color.Blue
        Me.txtWeekEnding.Appearance = Appearance12
        Me.txtWeekEnding.Enabled = False
        Me.txtWeekEnding.Location = New System.Drawing.Point(108, 70)
        Me.txtWeekEnding.Multiline = True
        Me.txtWeekEnding.Name = "txtWeekEnding"
        Me.txtWeekEnding.Size = New System.Drawing.Size(100, 21)
        Me.txtWeekEnding.TabIndex = 2
        Me.txtWeekEnding.TabStop = False
        Me.txtWeekEnding.Tag = ".WeekEnding"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.utUserID)
        Me.GroupBox1.Controls.Add(Me.lblDivision)
        Me.GroupBox1.Controls.Add(Me.lblPayrollEnding)
        Me.GroupBox1.Controls.Add(Me.UltraLabel1)
        Me.GroupBox1.Controls.Add(Me.ulblDivision)
        Me.GroupBox1.Controls.Add(Me.ulblWeekEnding)
        Me.GroupBox1.Controls.Add(Me.txtWeekEnding)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(296, 98)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'utUserID
        '
        Me.utUserID.Location = New System.Drawing.Point(240, 64)
        Me.utUserID.Name = "utUserID"
        Me.utUserID.Size = New System.Drawing.Size(24, 21)
        Me.utUserID.TabIndex = 35
        Me.utUserID.Tag = ".UserID"
        Me.utUserID.Visible = False
        '
        'lblDivision
        '
        Appearance13.FontData.Name = "Arial Black"
        Appearance13.FontData.SizeInPoints = 9.75!
        Appearance13.ForeColor = System.Drawing.Color.Blue
        Appearance13.ForeColorDisabled = System.Drawing.Color.Blue
        Me.lblDivision.Appearance = Appearance13
        Me.lblDivision.Enabled = False
        Me.lblDivision.Location = New System.Drawing.Point(108, 19)
        Me.lblDivision.Multiline = True
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(180, 21)
        Me.lblDivision.TabIndex = 0
        Me.lblDivision.TabStop = False
        Me.lblDivision.Tag = ".Division"
        '
        'lblPayrollEnding
        '
        Appearance14.FontData.Name = "Arial Black"
        Appearance14.FontData.SizeInPoints = 9.75!
        Appearance14.ForeColor = System.Drawing.Color.Blue
        Appearance14.ForeColorDisabled = System.Drawing.Color.Blue
        Me.lblPayrollEnding.Appearance = Appearance14
        Me.lblPayrollEnding.Enabled = False
        Me.lblPayrollEnding.Location = New System.Drawing.Point(108, 44)
        Me.lblPayrollEnding.Multiline = True
        Me.lblPayrollEnding.Name = "lblPayrollEnding"
        Me.lblPayrollEnding.Size = New System.Drawing.Size(100, 21)
        Me.lblPayrollEnding.TabIndex = 1
        Me.lblPayrollEnding.TabStop = False
        Me.lblPayrollEnding.Tag = ".PayrollEnding"
        '
        'UltraLabel1
        '
        Appearance15.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance15.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel1.Appearance = Appearance15
        Me.UltraLabel1.Location = New System.Drawing.Point(16, 44)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(88, 16)
        Me.UltraLabel1.TabIndex = 34
        Me.UltraLabel1.Text = "Payroll Ending:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblDateWorked)
        Me.GroupBox2.Controls.Add(Me.lblEmpName)
        Me.GroupBox2.Controls.Add(Me.lblName)
        Me.GroupBox2.Controls.Add(Me.cboEmpId)
        Me.GroupBox2.Controls.Add(Me.dpWorked)
        Me.GroupBox2.Controls.Add(Me.lblEmpId)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 103)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 105)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtPayRate)
        Me.GroupBox3.Controls.Add(Me.btnPaste)
        Me.GroupBox3.Controls.Add(Me.btnCopy)
        Me.GroupBox3.Controls.Add(Me.utTotalHrs)
        Me.GroupBox3.Controls.Add(Me.ulblDeptNo)
        Me.GroupBox3.Controls.Add(Me.ulblTotalHrs)
        Me.GroupBox3.Controls.Add(Me.lblBreakTime)
        Me.GroupBox3.Controls.Add(Me.lblTimeOut)
        Me.GroupBox3.Controls.Add(Me.lblTimeIn)
        Me.GroupBox3.Controls.Add(Me.txtTimeIn)
        Me.GroupBox3.Controls.Add(Me.txtTimeOut)
        Me.GroupBox3.Controls.Add(Me.txtBreakHrs)
        Me.GroupBox3.Controls.Add(Me.ucboDeptNo)
        Me.GroupBox3.Controls.Add(Me.utRowID)
        Me.GroupBox3.Controls.Add(Me.txtCheckOutDate)
        Me.GroupBox3.Controls.Add(Me.txtOfficeID)
        Me.GroupBox3.Controls.Add(Me.txtOffice)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 211)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(296, 189)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'btnPaste
        '
        Me.btnPaste.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaste.Location = New System.Drawing.Point(174, 151)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(50, 23)
        Me.btnPaste.TabIndex = 0
        Me.btnPaste.TabStop = False
        Me.btnPaste.Text = "&Paste"
        '
        'btnCopy
        '
        Me.btnCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopy.Location = New System.Drawing.Point(112, 151)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(50, 23)
        Me.btnCopy.TabIndex = 1
        Me.btnCopy.TabStop = False
        Me.btnCopy.Text = "&Copy"
        '
        'utTotalHrs
        '
        Appearance16.FontData.Name = "Arial Black"
        Appearance16.FontData.SizeInPoints = 9.75!
        Appearance16.ForeColor = System.Drawing.Color.Blue
        Appearance16.ForeColorDisabled = System.Drawing.Color.Blue
        Me.utTotalHrs.Appearance = Appearance16
        Me.utTotalHrs.Enabled = False
        Me.utTotalHrs.Location = New System.Drawing.Point(112, 120)
        Me.utTotalHrs.Multiline = True
        Me.utTotalHrs.Name = "utTotalHrs"
        Me.utTotalHrs.ReadOnly = True
        Me.utTotalHrs.Size = New System.Drawing.Size(100, 21)
        Me.utTotalHrs.TabIndex = 4
        Me.utTotalHrs.TabStop = False
        Me.utTotalHrs.Tag = ".TotalHrs"
        Me.utTotalHrs.Text = "0.00"
        '
        'utRowID
        '
        Me.utRowID.Location = New System.Drawing.Point(228, 24)
        Me.utRowID.Name = "utRowID"
        Me.utRowID.Size = New System.Drawing.Size(64, 21)
        Me.utRowID.TabIndex = 7
        Me.utRowID.Tag = ".RowID.view"
        Me.utRowID.Text = "RowID - Hidden"
        Me.utRowID.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnSave)
        Me.GroupBox4.Controls.Add(Me.btnExit)
        Me.GroupBox4.Controls.Add(Me.btnEdit)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 525)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(792, 41)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(312, 525)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.utGross)
        Me.GroupBox5.Controls.Add(Me.UltraLabel5)
        Me.GroupBox5.Controls.Add(Me.utDTTotal)
        Me.GroupBox5.Controls.Add(Me.UltraLabel4)
        Me.GroupBox5.Controls.Add(Me.utOTTotal)
        Me.GroupBox5.Controls.Add(Me.UltraLabel3)
        Me.GroupBox5.Controls.Add(Me.utRegTotal)
        Me.GroupBox5.Controls.Add(Me.UltraLabel2)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 440)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(296, 72)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Week Totals"
        '
        'utGross
        '
        Appearance17.FontData.Name = "Arial Black"
        Appearance17.FontData.SizeInPoints = 9.75!
        Appearance17.ForeColor = System.Drawing.Color.Blue
        Appearance17.ForeColorDisabled = System.Drawing.Color.Blue
        Me.utGross.Appearance = Appearance17
        Me.utGross.Enabled = False
        Me.utGross.Location = New System.Drawing.Point(216, 40)
        Me.utGross.Multiline = True
        Me.utGross.Name = "utGross"
        Me.utGross.Size = New System.Drawing.Size(56, 21)
        Me.utGross.TabIndex = 35
        Me.utGross.TabStop = False
        Me.utGross.Tag = ""
        '
        'UltraLabel5
        '
        Appearance18.TextHAlign = Infragistics.Win.HAlign.Center
        Appearance18.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel5.Appearance = Appearance18
        Me.UltraLabel5.Location = New System.Drawing.Point(217, 18)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(48, 16)
        Me.UltraLabel5.TabIndex = 34
        Me.UltraLabel5.Text = "Total"
        '
        'utDTTotal
        '
        Appearance19.FontData.Name = "Arial Black"
        Appearance19.FontData.SizeInPoints = 9.75!
        Appearance19.ForeColor = System.Drawing.Color.Blue
        Appearance19.ForeColorDisabled = System.Drawing.Color.Blue
        Me.utDTTotal.Appearance = Appearance19
        Me.utDTTotal.Enabled = False
        Me.utDTTotal.Location = New System.Drawing.Point(151, 40)
        Me.utDTTotal.Multiline = True
        Me.utDTTotal.Name = "utDTTotal"
        Me.utDTTotal.Size = New System.Drawing.Size(56, 21)
        Me.utDTTotal.TabIndex = 33
        Me.utDTTotal.TabStop = False
        Me.utDTTotal.Tag = ""
        '
        'UltraLabel4
        '
        Appearance20.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance20.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel4.Appearance = Appearance20
        Me.UltraLabel4.Location = New System.Drawing.Point(153, 18)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(48, 16)
        Me.UltraLabel4.TabIndex = 32
        Me.UltraLabel4.Text = "DT.Hr.s:"
        '
        'utOTTotal
        '
        Appearance21.FontData.Name = "Arial Black"
        Appearance21.FontData.SizeInPoints = 9.75!
        Appearance21.ForeColor = System.Drawing.Color.Blue
        Appearance21.ForeColorDisabled = System.Drawing.Color.Blue
        Me.utOTTotal.Appearance = Appearance21
        Me.utOTTotal.Enabled = False
        Me.utOTTotal.Location = New System.Drawing.Point(84, 40)
        Me.utOTTotal.Multiline = True
        Me.utOTTotal.Name = "utOTTotal"
        Me.utOTTotal.Size = New System.Drawing.Size(56, 21)
        Me.utOTTotal.TabIndex = 31
        Me.utOTTotal.TabStop = False
        Me.utOTTotal.Tag = ""
        '
        'UltraLabel3
        '
        Appearance22.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance22.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel3.Appearance = Appearance22
        Me.UltraLabel3.Location = New System.Drawing.Point(85, 18)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(48, 16)
        Me.UltraLabel3.TabIndex = 30
        Me.UltraLabel3.Text = "OT.Hr.s:"
        '
        'utRegTotal
        '
        Appearance23.FontData.Name = "Arial Black"
        Appearance23.FontData.SizeInPoints = 9.75!
        Appearance23.ForeColor = System.Drawing.Color.Blue
        Appearance23.ForeColorDisabled = System.Drawing.Color.Blue
        Me.utRegTotal.Appearance = Appearance23
        Me.utRegTotal.Enabled = False
        Me.utRegTotal.Location = New System.Drawing.Point(16, 40)
        Me.utRegTotal.Multiline = True
        Me.utRegTotal.Name = "utRegTotal"
        Me.utRegTotal.Size = New System.Drawing.Size(56, 21)
        Me.utRegTotal.TabIndex = 29
        Me.utRegTotal.TabStop = False
        Me.utRegTotal.Tag = ""
        '
        'UltraLabel2
        '
        Appearance24.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance24.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel2.Appearance = Appearance24
        Me.UltraLabel2.Location = New System.Drawing.Point(13, 18)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(56, 16)
        Me.UltraLabel2.TabIndex = 28
        Me.UltraLabel2.Text = "Reg.Hr.s:"
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGrid2.Location = New System.Drawing.Point(312, 0)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(480, 207)
        Me.UltraGrid2.TabIndex = 3
        Me.UltraGrid2.Text = "Employee Schedule"
        '
        'TimeCardInput
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "TimeCardInput"
        Me.Tag = "EMPLOYEEACTIVITYDETAIL"
        Me.Text = "Time Card Input"
        CType(Me.cboEmpId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dpWorked, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTimeIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTimeOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBreakHrs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOfficeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPayRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCheckOutDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDeptNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeekEnding, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utUserID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPayrollEnding, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.utTotalHrs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.utGross, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utDTTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOTTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRegTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Common Events"

    Private Sub frmTimeCardEntryDE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If Not InitialzeWorkDateClass() Then
        'Me.Close()
        'End If
        utUserID.Text = LoginInfo.UserID
        StandardFormPrep()

        'Removed By Ali
        ''Arrange the Widgets according to desired layout
        'Me.Size = New Size(800, 416)
        'ArrangeForm()

        'Added By Ali for ED case
        ArrangeForm2()


        'initialize the appropriate controls and options according to the privileges of the user id
        _iCount = 1
        _iDateSection = 4
        _cValidate = New clsFieldValidator
        _bFillGrid = True

        'Initialize Default Values for Hidden DB Fields for the table EmployeeActivityDetail
        txtOfficeID.Text = "0"
        txtOfficeID.Visible = False
        txtOffice.Text = ""
        txtOffice.Visible = False
        txtPayRate.Text = "0"
        txtPayRate.Visible = False
        txtWeekEnding.Visible = True

        txtCheckOutDate.Visible = False

        AddHandler txtTimeIn.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler txtTimeOut.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler txtBreakHrs.KeyPress, AddressOf Value_Dec_KeyPress
        'AddHandler utMiles.KeyPress, AddressOf Value_Int_KeyPress
        AddHandler cboEmpId.Leave, AddressOf UCbo_Leave
        AddHandler ucboDeptNo.Leave, AddressOf UCbo_Leave

        'Populate the employee list
        Dim dtView As New DataView

        Dim dtSet As New DataSet
        ' Modified By Ali -- START
        '=========================
        If strDivision Is Nothing Then strDivision = "TOP"

        If FetchTimeCardEmployees(dtSet, strDivision) = False Then
            'If FetchTimeCardEmployeesTmp(_userId, dtSet) = False Then
            MsgBox("No employees are available for input. Please see the Administrator.")
        Else
            dtView.Table = dtSet.Tables(0)
            cboEmpId.DataSource = dtView
            cboEmpId.DisplayMember = dtView.Table.Columns("EmployeeID").ToString
            cboEmpId.ValueMember = dtView.Table.Columns("EmployeeID").ToString
        End If
        ' Modified By Ali -- END
        '=========================

        'Populate Read-only Fields
        lblDivision.Text = strDivision
        lblPayrollEnding.Text = Format(datePayrollEndDate, "MM/dd/yyyy")

        If _workDate.IsInPayPeriod(Now.Date, datePayrollEndDate) = True Then
            dpWorked.Value = Now.Date
        Else
            dpWorked.Value = datePayrollEndDate
        End If

        txtWeekEnding.Text = Format(_workDate.WeekEnding(dpWorked.Value), "MM/dd/yyyy")

        InitializeInputBoxes()
        GroupBox3.Enabled = False

    End Sub
    Private Sub InitializeInputBoxes(Optional ByVal ResetDeptNo As Boolean = True)
        'ucboDeptNo.DataSource = Nothing
        If ResetDeptNo Then
            ucboDeptNo.DataSource = Nothing
            ucboDeptNo.Value = Nothing
            ucboDeptNo.Text = ""
            txtPayRate.Text = ""
        End If
        txtTimeIn.Text = "0.00"
        txtTimeOut.Text = "0.00"
        txtBreakHrs.Text = "0.00"
        utTotalHrs.Text = "0.00"
        txtCheckOutDate.Text = ""
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        ugRow = UltraGrid1.ActiveRow
        If UltraGrid1.ActiveRow Is Nothing Then
            MsgBox("Please Select a ROW of the Input History for Editing.")
            Exit Sub
        End If
        If UltraGrid1.ActiveRow.ListObject Is Nothing Then
            MsgBox("Please Select a ROW of the Input History for Editing.")
            Exit Sub
        End If
        If UltraGrid1.ActiveRow.Cells("Processed").Value = True Then
            MsgBox("This entry has been PROCESSED and can not be edited.")
            Exit Sub
        End If
        If ugRow.Cells("PayrollEnding").Text.Trim <> lblPayrollEnding.Text.Trim Then
            MsgBox("The record you want to EDIT does not belong to the selected Payroll-Ending. Action cancelled.")
            Exit Sub
        End If
        Dim SQLSelect As String = "SELECT RowID, EmployeeID, Division, OfficeID, Office, TotalHrs, CheckInDate, TimeIn, CheckOutDate, TimeOut, BreakTime, DeptNo, PayRate, WeekEnding, PayrollEnding, LastUpdate, Processed" & _
                    " FROM " & HRTblPath & "EmployeeActivityDetail WHERE EmployeeId = " & cboEmpId.Value & " AND RowID = " & ugRow.Cells("rowid").Value

        If MsgBox("Are you sure you want to EDIT the previously entered data for: '" & UltraGrid1.ActiveRow.Cells("CheckInDate").Value & "- In:" & UltraGrid1.ActiveRow.Cells("TimeIn").Value & ", Out: " & UltraGrid1.ActiveRow.Cells("TimeOut").Value & "'?", MsgBoxStyle.YesNo, "Edit A Previuos Record") = MsgBoxResult.Yes Then
            If Not cmdTrans Is Nothing Then
                cmdTrans.Transaction.Rollback()
                If cmdTrans.Connection.State = ConnectionState.Open Then
                    cmdTrans.Connection.Close()
                End If
                cmdTrans = Nothing
            End If
            If EditForm(Me, SQLSelect, EditAction.START, cmdTrans) = False Then
                cmdTrans = Nothing
                Exit Sub
            End If

            ucboDeptNo.Focus()

            utRowID.Text = ugRow.Cells("rowid").Value
            ucboDeptNo.Value = ugRow.Cells("DeptNo").Value

            PreviousDeptNo = ucboDeptNo.Value

            dpWorked.Value = Format(ugRow.Cells("CheckInDate").Value, "MM/dd/yyyy")
            txtWeekEnding.Text = Format(_workDate.WeekEnding(dpWorked.Value), "MM/dd/yyyy")

            txtTimeIn.Text = ugRow.Cells("TimeIn").Value
            txtTimeOut.Text = ugRow.Cells("Timeout").Value
            txtBreakHrs.Text = ugRow.Cells("BreakTime").Value
            txtCheckOutDate.Text = ugRow.Cells("CheckOutDate").Value
            txtOfficeID.Text = ugRow.Cells("OfficeID").Value
            txtOffice.Text = ugRow.Cells("Office").Value
            txtPayRate.Text = ugRow.Cells("PayRate").Value
            utTotalHrs.Text = ugRow.Cells("TotalHrs").Value
            'ucboDept.SelectNextControl(ucboDept, True, True, False, True)
        End If

    End Sub


    Private Sub cboEmpId_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEmpId.KeyUp
        Select Case e.KeyValue
            Case 39
                cboEmpId.ToggleDropdown()
            Case 13
                If ScreenCode = "DE" Then
                    If (cboEmpId.Text = "") And (_iCount <> 0) Then
                        KeyBuffer(0) = 13
                        KeyBuffer(1) = btnExit
                        KeyBuffer(2) = e
                        SimulateTab(e, 13, btnExit)
                    Else
                        KeyBuffer(0) = 13
                        KeyBuffer(1) = cboEmpId
                        KeyBuffer(2) = e
                        SimulateTab(e, 13, cboEmpId)
                    End If
                Else
                    If _iCount > 0 Then
                        _iCount = 0
                        SimulateTab(e, 13, cboEmpId)
                    Else
                        _iCount += 1
                    End If
                End If
        End Select

    End Sub

    Private Sub cboEmpId_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpId.Enter
        If ErrorProvider1.GetError(cboEmpId).ToString <> "" Then
            'cboEmpId.Select()
            Me.cboEmpId.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.FirstCharacter, False, False)
            Me.cboEmpId.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.SelectSection, False, False)
        End If
    End Sub

    Private Sub cboEmpId_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboEmpId.Validating
        If cboEmpId.Text = "" Then
            If ScreenCode = "ED" Then
                SetError(cboEmpId, e, "You must enter a valid Employee Id")
            End If
        Else
            'If (_cValidate.TextInSet(cboEmpId, "EmployeeID", cboEmpId.DataSource) = False) Then
            '    SetError(cboEmpId, e, "Invalid Employee Id")
            'End If
        End If
    End Sub
    Private Sub cboEmpId_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpId.ValueChanged
        InitializeInputBoxes()
        GroupBox3.Enabled = False
        lblEmpName.Text = ""
        UltraGrid1.DataSource = Nothing
        UltraGrid2.DataSource = Nothing
        utRowID.Text = ""
        'FillWeekTotals(cboEmpId.Text.Trim, txtWeekEnding.Text)
        utRegTotal.Text = "0.00"
        utOTTotal.Text = "0.00"
        utDTTotal.Text = "0.00"
        utGross.Text = "0.00"


        If Not cmdTrans Is Nothing Then
            cmdTrans.Transaction.Rollback()
            If cmdTrans.Connection.State = ConnectionState.Open Then
                cmdTrans.Connection.Close()
            End If
            cmdTrans = Nothing
        End If

        txtOfficeID.Text = ""
        txtOffice.Text = ""
    End Sub
    Private Sub cboEmpId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpId.Validated

        'ClearError(cboEmpId)

        If sender.text = "" Then Exit Sub

        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        If cboEmpId.ActiveRow Is Nothing Then
            InitializeInputBoxes()
            GroupBox3.Enabled = False
            Exit Sub
        End If
        ugrow = cboEmpId.ActiveRow
        lblEmpName.Text = ugrow.Cells("Employee").Value
        GroupBox3.Enabled = True

        txtOfficeID.Text = ugrow.Cells("OfficeID").Value
        txtOffice.Text = ugrow.Cells("Office").Value
        'Dim row As DataRow
        'If ReturnRowByID(ugrow.Cells("OfficeID").Value, row, HRTblPath & "ServiceOffices", "ID") Then
        '    txtOffice.Text = row("name")
        'Else
        '    MsgBox("Office could not be found.")
        '    txtOffice.Text = "N/A"
        'End If

        'Removed By Ali
        ''Set the lblEmployeeName
        'Dim dataView As DataView
        'Dim dataRow As DataRow
        'Dim dataRows As DataRowCollection
        'dataView = cboEmpId.DataSource
        'dataRows = dataView.Table.Rows
        'For Each dataRow In dataRows
        '    If dataRow("EmployeeID") = cboEmpId.Text Then
        '        lblEmpName.Text = CStr(dataRow("Employee"))
        '        Exit For
        '    End If
        'Next

        'Populate Dept Combo
        'Removed By Ali
        'Dim strSQL = "select epr.deptno as fldCode, epr.deptno as fldLabel,  d.department, e.officeId, so.office_name, epr.payrate from " & HRTblPath & "employeepayrates epr, " & HRTblPath & "departments d, " & HRTblPath & "employees e, " & HRTblPath & "serviceOffice_fs so where (epr.employeeid = 3322 and epr.deptno = d.deptno) and (e.id = 3322 and e.officeid = so.officeid)"
        ''Dim strSQL = "Select epr.DeptNo, d.Department, epr.payrate from " & HRTblPath & "EmployeePayRates epr, " & HRTblPath & "Departments d where epr.employeeid = '" & ugrow.Cells("EmployeeID").Value & "' and epr.deptno = d.deptno order by epr.DeptNo"
        Dim strSQL = "Select epr.DeptNo, d.Department from " & HRTblPath & "EmployeePayRates epr, " & HRTblPath & "Departments d where epr.employeeid = '" & ugrow.Cells("EmployeeID").Value & "' and epr.deptno = d.deptno order by epr.DeptNo" 'Suppressed Payrate to Deny Access to Input Operators (01/05/2009)
        FillUCombo(ucboDeptNo, "", "", strSQL, HRTblPath, True)

        'Populate DataGrid1
        FillInputHistory(cboEmpId.Text.Trim)
        FillWeekTotals(cboEmpId.Text.Trim, txtWeekEnding.Text)
        If Not KeyBuffer(0) Is Nothing Then
            Select Case KeyBuffer(1).name.toupper
                Case "CBOEMPID"
                    SimulateTab(KeyBuffer(2), 13, cboEmpId)
                    KeyBuffer(0) = Nothing
                    KeyBuffer(1) = Nothing
                    KeyBuffer(2) = Nothing
                Case "BTNEXIT"
                    SimulateTab(KeyBuffer(2), 13, btnExit)
                    KeyBuffer(0) = Nothing
                    KeyBuffer(1) = Nothing
                    KeyBuffer(2) = Nothing
            End Select
        End If

        'Populate DataGrid2
        ShowEmployeeSchedule(GetEmployeeSchedule(cboEmpId.Text.Trim, dpWorked.DateTime.DayOfWeek))

    End Sub
    Private Sub FillWeekTotals(ByVal EmplID As String, ByVal WeekEnding As String)
        Dim strSQL = "Select isnull(Sum(RegHrs), 0) as TotalReg, isnull(Sum(OTHrs), 0) as TotalOT, isnull(Sum(DTHrs), 0) as TotalDT, isnull(Sum(TotalHrs), 0) as Gross from " & HRTblPath & "EmployeeActivityDetail where EmployeeID = '" & EmplID & "' and WeekEnding = '" & WeekEnding & "'"
        Dim row As DataRow

        If EmplID.Trim <> "" And WeekEnding.Trim <> "" Then
            If ReturnRowByID("", row, "", "", "", strSQL) Then
                utRegTotal.Text = row("TotalReg")
                utOTTotal.Text = row("TotalOT")
                utDTTotal.Text = row("TotalDT")
                utGross.Text = row("Gross")
                row = Nothing
                Exit Sub
            End If
        End If

        utRegTotal.Text = "0.00"
        utOTTotal.Text = "0.00"
        utDTTotal.Text = "0.00"
        utGross.Text = "0.00"

    End Sub
    Private Sub dpWorked_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dpWorked.KeyUp

        Select Case e.KeyValue
            Case 13
                If ScreenCode = "DE" Then
                    If _iCount > 0 Then
                        _iCount = 0
                        SimulateTab(e, 13, dpWorked)
                    Else
                        _iCount += 1
                    End If
                Else
                    SimulateTab(e, 13, dpWorked)
                End If
            Case 36
                _iCount += 1
                SimulateTab(e, 36, btnSave)
        End Select

    End Sub

    Private Sub txtTimeIn_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTimeIn.KeyUp
        If e.KeyValue = 13 And txtTimeIn.Text = "" Then
            If ScreenCode = "DE" Then
                cboEmpId.Text = ""
                SimulateTab(e, 13, dpWorked)
            Else
                SimulateTab(e, 13, cboEmpId)
            End If
        Else
            SimulateTab(e, 13, txtTimeIn)
        End If
    End Sub

    Private Sub txtTimeOut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTimeOut.KeyUp
        SimulateTab(e, 13, txtTimeOut)
    End Sub

    Private Sub txtBreakHrs_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBreakHrs.KeyUp

        SimulateTab(e, 13, txtBreakHrs)

    End Sub
    Private Function IsOverlapInput(ByVal EmplID As String, ByVal DateWorked As Date, ByVal TimeIn As String, ByVal TimeOut As String, ByVal RowID As String) As Boolean

        IsOverlapInput = True

        If EmplID.Trim = "" Then
            MsgBox("EmployeeID is blank.")
            Exit Function
        End If
        'If DateWorked Is Nothing Then
        '    MsgBox("Work Date is not specified.")
        '    Exit Function
        'End If
        If TimeIn.Trim = "" Then
            MsgBox("TimeIn is not specified.")
            Exit Function
        End If
        If TimeOut.Trim = "" Then
            MsgBox("TimeOut is not specified.")
            Exit Function
        End If

        Dim sqlSelect As String = "Select * from " & HRTblPath & "EmployeeActivityDetail where EmployeeID = '" & EmplID & "' AND ( (CheckInDate = '" & Format(DateWorked, "MM/dd/yyyy") & "' and ( (timein between " & TimeIn & " AND " & TimeOut & " AND timeout <= " & TimeOut & ") OR (timeout between " & TimeIn & " AND " & TimeOut & " AND timein >= " & TimeIn & ") OR (timein = " & TimeIn & " AND TimeOut = " & TimeOut & ") OR (timein < " & TimeIn & " AND TimeOut > " & TimeIn & ") OR (" & TimeIn & " < " & TimeOut & " AND (TimeIn < " & TimeOut & " AND timeout > " & TimeOut & ")) OR (TimeOut < TimeIn AND (" & TimeIn & " > Timein OR " & TimeOut & " > TimeIn OR " & TimeOut & " < TimeOUt)) ) ) OR (CheckOutDate = '" & Format(dpWorked.Value, "MM/dd/yyyy") & "' AND CheckInDate < CheckoutDate AND (" & TimeIn & " < TimeOut)) @@NEXTDAYCOND ) @@ROWID "

        'Added by Sammy Nava to Check Case where CheckOut time is DateWorked + 1 and timout
        Dim dNextDay As Date
        Dim strNextDay As String
        Dim strNextDayCond As String

        If CSng(TimeOut) < CSng(TimeIn) Then
            dNextDay = CDate(dpWorked.Value).AddDays(1)
            strNextDay = "'" & Format(dNextDay, "MM/dd/yyyy") & "'"
            strNextDayCond = "OR ( (CheckOutDate = " & strNextDay & ") and (timeout <= '" & TimeOut & "') )"
        Else
            strNextDayCond = ""
        End If
        sqlSelect = sqlSelect.Replace("@@NEXTDAYCOND", strNextDayCond)


        Dim row As DataRow = Nothing
        Dim RowIDCond As String

        If Val(RowID.Trim) > 0 Then
            RowIDCond = " AND RowID <> " & RowID & " "
        Else
            RowIDCond = ""
        End If
        sqlSelect = sqlSelect.Replace("@@ROWID", RowIDCond)

        ReturnRowByID("", row, "", "", "", sqlSelect)
        If row Is Nothing Then
            IsOverlapInput = False
        End If
        row = Nothing


    End Function

    Private Sub AddToPayrollTotals(ByVal EmplID As String, ByVal PayrollEnding As String, ByVal DeptNo As String)

        Dim sqlPayrollEndingTotals_Insert As String = _
            "Insert into " & HRTblPath & "EmployeeActivity(PayrollDate, EmployeeID, OfficeID, Office, DeptNo, RegHrs, OTHrs, DTHrs, MileageRate, PayRate, WCCode, ClassID, Class, HrsPay  ) " & _
            " Select ead.PayrollEnding, ead.EmployeeID, ead.OfficeID, ead.Office, ead.DeptNo, Sum(ead.RegHrs) as RegHrsTotal, Sum(ead.OTHrs) as OTHrsTotal, Sum(ead.DTHrs) as DTHrsTotal " & _
            " , max(ep.MileageRate) as MileageRate, max(ep.PayRate) as PayRate, max(ep.WCCode) as WCCode, max(ep.ClassiD) as ClassID, max(cl.Class) as Class " & _
            " , max(ep.PayRate) * ( Sum(ead.RegHrs)+ (1.5 * Sum(ead.OTHrs)) +  (2. * Sum(ead.DTHrs)) ) as HrsPay " & _
            " from " & HRTblPath & "EmployeeActivityDetail ead inner join " & HRTblPath & "EmployeePayRates ep on ead.EmployeeID = ep.EmployeeID and ead.DeptNo = ep.DeptNo " & _
            " left outer join " & HRTblPath & "Classes cl on ep.Classid = cl.Classid " & _
            " where ead.Processed = 0 AND ead.payrollending = '" & PayrollEnding & "' AND ead.DeptNo = '" & DeptNo & "'  AND ead.EmployeeID = '" & EmplID & "' " & _
            " group by ead.PayrollEnding, ead.EmployeeID, ead.DeptNo, ead.OfficeID, ead.Office; "

        'Dim sqlPayrollEndingTotals_Update As String = _
        '    "Update " & HRTblPath & "EmployeeActivity " & _
        '    " Set RegHrs = Sum(ead.RegHrs), OTHrs = Sum(ead.OTHrs), DTHrs = Sum(ead.DTHrs), HrsPay = (ea.PayRate) * ( Sum(ead.RegHrs)+ (1.5 * Sum(ead.OTHrs)) +  (2. * Sum(ead.DTHrs)) ) " & _
        '    " From " & HRTblPath & "EmployeeActivity ea inner join " & HRTblPath & "EmployeeActivityDetail ead on ea.EmployeeID = ead.EmployeeID AND ea.DeptNo = ead.DeptNo And ea.PayrollDate = ead.PayrollEnding " & _
        '    " where ead.Processed = 0 AND ea.PayrollDate = '" & PayrollEnding & "' AND ea.DeptNo = '" & DeptNo & "'  AND ea.EmployeeID = '" & EmplID & "' " & _
        '    ""

        Dim sqlPayrollEndingTotals_Update As String = _
            "Update " & HRTblPath & "EmployeeActivity " & _
            " SET RegHrs = ead.TotRegHrs " & _
            " , OTHrs = ead.TotOTHrs " & _
            " , DTHrs = ead.TotDTHrs " & _
            " , PayRate = ep.PayRate " & _
            " , HrsPay = (ep.PayRate) * ( ead.TotRegHrs+ (1.5 * ead.TotOTHrs) +  (2. * ead.TotDTHrs) )  " & _
            " From " & HRTblPath & "EmployeeActivity ea inner join " & _
            " (Select ead.EmployeeID, ead.PayrollEnding, ead.DeptNo, isnull(Sum(ead.RegHrs), 0) as TotRegHrs, isnull(Sum(ead.OTHrs), 0) as TotOTHrs, isnull(Sum(ead.DTHrs), 0) as TotDTHrs from " & HRTblPath & "EmployeeActivityDetail ead where ead.Processed = 0 AND ead.PayrollEnding = '" & PayrollEnding & "' AND ead.DeptNo = '" & DeptNo & "'  AND ead.EmployeeID = '" & EmplID & "'  group by ead.EmployeeID, ead.PayrollEnding, ead.DeptNo) ead " & _
            " on ea.EmployeeID = ead.EmployeeID AND ea.DeptNo = ead.DeptNo And ea.PayrollDate = ead.PayrollEnding  " & _
            " inner join " & HRTblPath & "EmployeePayRates ep on ead.EmployeeID = ep.EmployeeID and ead.DeptNo = ep.DeptNo " & _
            " where ea.PayrollDate = '" & PayrollEnding & "' AND ea.DeptNo = '" & DeptNo & "'  AND ea.EmployeeID = '" & EmplID & "' AND ea.Voucher = 0 AND ea.Misc = 0 "


        '" group by ead.PayrollEnding, ead.EmployeeID, ead.DeptNo, ead.OfficeID, ead.Office; "

        Dim ChkTotalsExistingRow As String = "Select * from " & HRTblPath & "EmployeeActivity ea where ea.EmployeeID = '" & EmplID & "' AND ea.PayrollDate = '" & PayrollEnding & "' AND ea.DeptNo = '" & DeptNo & "' AND ea.Voucher = 0 AND ea.Misc = 0 "
        Dim row As DataRow

        If ReturnRowByID("", row, "", "", "", ChkTotalsExistingRow) Then
            ExecuteQuery(sqlPayrollEndingTotals_Update)
        Else
            ExecuteQuery(sqlPayrollEndingTotals_Insert)
        End If
        If Not row Is Nothing Then
            row.Table.DataSet.Dispose()
        End If
        row = Nothing


    End Sub


    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim SQLSelect As String = "Select * from " & HRTblPath & "EmployeeActivityDetail"
        Dim CritTmp As String = "Where RowID = " & utRowID.Text
        Dim IdentIns As Boolean = False

        If cboEmpId.Text = "" Then
            MsgBox("Employee Not Selected.")
            Exit Sub
        End If
        If GroupBox3.Enabled = False Then
            MsgBox("Data Entry Incomplete. SAVE aborted.")
            Exit Sub
        End If
        If ucboDeptNo.Text = "" Then
            MsgBox("Department Not Selected.")
            Exit Sub
        End If
        If txtTimeIn.Text.Trim = txtTimeOut.Text.Trim Then
            If MsgBox("TimeIn & TimeOut are the same. Do you still want to save?", MsgBoxStyle.YesNo, "Possible Erroneous Input") = MsgBoxResult.No Then Exit Sub
        End If
        If Val(utTotalHrs.Text) <= 0 Then
            MsgBox("Invalid Total Hours.")
            Exit Sub
        End If

        'Set Calculated Values for Hidden Fields

        ''CheckOutDate
        If CSng(txtTimeOut.Text) < CSng(txtTimeIn.Text) Then
            txtCheckOutDate.Text = CDate(dpWorked.Value).AddDays(1)
        Else
            txtCheckOutDate.Text = CDate(dpWorked.Value).ToShortDateString
        End If

        'Removed By Ali
        ''WeekEnding
        'lblWeekEnding.Text = datePayrollEndDate.ToShortDateString
        If IsOverlapInput(cboEmpId.Value, dpWorked.Value, txtTimeIn.Text, txtTimeOut.Text, utRowID.Text) Then
            MsgBox("The time entered is overlapping with previous entry.")
            Exit Sub
        End If
        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, CritTmp, IdentIns) Then
            Me.Text = MeText & " -- " & "Saved: " & dpWorked.Text & " - EmplID: " & cboEmpId.Text.Trim & " - Dept.: " & ucboDeptNo.Text & "."
            ''ucboDept.Value = Nothing
            ''ucboDept.Text = ""
            'CategorizeWorkHoursV2(cboEmpId.Value, txtWeekEnding.Text)
            CategorizeWorkHours(cboEmpId.Value, txtWeekEnding.Text)
            utRowID.Text = ""

            AddToPayrollTotals(cboEmpId.Text.Trim, lblPayrollEnding.Text.Trim, ucboDeptNo.Value)
            If PreviousDeptNo <> "" Then
                Dim UpdatePrevDeptTotals As String = _
                "Update " & HRTblPath & "EmployeeActivity " & _
                " SET RegHrs = ead.TotRegHrs " & _
                " , OTHrs = ead.TotOTHrs " & _
                " , DTHrs = ead.TotDTHrs " & _
                " , PayRate = ep.PayRate " & _
                " , HrsPay = (ep.PayRate) * ( ead.TotRegHrs+ (1.5 * ead.TotOTHrs) +  (2. * ead.TotDTHrs) )  " & _
                " From " & HRTblPath & "EmployeeActivity ea inner join " & _
                " (Select '" & cboEmpId.Text.Trim & "' as EmployeeID, '" & lblPayrollEnding.Text.Trim & "' as PayrollEnding, '" & PreviousDeptNo & "' as DeptNo, Isnull((Select Sum(ead.RegHrs) from " & HRTblPath & "EmployeeActivityDetail ead where ead.Processed = 0 AND ead.PayrollEnding = '" & lblPayrollEnding.Text.Trim & "' AND ead.DeptNo = '" & PreviousDeptNo & "'  AND ead.EmployeeID = '" & cboEmpId.Text.Trim & "'  group by ead.EmployeeID, ead.PayrollEnding, ead.DeptNo), 0) as TotRegHrs, isnull((Select Sum(ead.OTHrs) from " & HRTblPath & "EmployeeActivityDetail ead where ead.Processed = 0 AND ead.PayrollEnding = '" & lblPayrollEnding.Text.Trim & "' AND ead.DeptNo = '" & PreviousDeptNo & "'  AND ead.EmployeeID = '" & cboEmpId.Text.Trim & "'  group by ead.EmployeeID, ead.PayrollEnding, ead.DeptNo), 0) as TotOTHrs, isnull((Select Sum(ead.DTHrs) from " & HRTblPath & "EmployeeActivityDetail ead where ead.Processed = 0 AND ead.PayrollEnding = '" & lblPayrollEnding.Text.Trim & "' AND ead.DeptNo = '" & PreviousDeptNo & "'  AND ead.EmployeeID = '" & cboEmpId.Text.Trim & "'  group by ead.EmployeeID, ead.PayrollEnding, ead.DeptNo), 0) as TotDTHrs ) ead " & _
                " on ea.EmployeeID = ead.EmployeeID AND ea.DeptNo = ead.DeptNo And ea.PayrollDate = ead.PayrollEnding  " & _
                " inner join " & HRTblPath & "EmployeePayRates ep on ead.EmployeeID = ep.EmployeeID and ead.DeptNo = ep.DeptNo " & _
                " where ea.PayrollDate = '" & lblPayrollEnding.Text.Trim & "' AND ea.DeptNo = '" & PreviousDeptNo & "'  AND ea.EmployeeID = '" & cboEmpId.Text.Trim & "' AND ea.Voucher = 0 AND ea.Misc = 0 "
                'ead table
                'from " & HRTblPath & "EmployeeActivityDetail ead where ead.Processed = 0 AND ead.PayrollEnding = '" & lblPayrollEnding.Text.Trim & "' AND ead.DeptNo = '" & PreviousDeptNo & "'  AND ead.EmployeeID = '" & cboEmpId.Text.Trim & "'  group by ead.EmployeeID, ead.PayrollEnding, ead.DeptNo

                If ExecuteQuery(UpdatePrevDeptTotals) = False Then
                    MsgBox("Error in updating the edited Dept. Totals.")
                End If

                PreviousDeptNo = ""
            End If

            FillInputHistory(cboEmpId.Text.Trim)
            FillWeekTotals(cboEmpId.Text.Trim, txtWeekEnding.Text)
            InitializeInputBoxes(False)

            'ucboDeptNo.Focus()
            Dim e2 As New System.Windows.Forms.KeyEventArgs(Keys.Enter)
            SimulateTab(e2, 13, cboEmpId) 'Go to TimeIn -- Ali: Should go to Dept Selection 
            e2 = Nothing

            ''utEmployeeID.Focus()
            'Dim row As DataRow
            'Dim dtA As New SqlDataAdapter
            'If EmplID.Text = "" Then
            '    LoadData("", "P")
            'Else
            '    LoadData(EmplID.Text, "C")
            'End If
            'btnEdit.Text = "&Edit"
            'btnNew.Text = "&New"
            'Me.Text = MeText & " -- Record Updated."
            ''PopulateDataset2(dtA, dtSet, SQLSelect)
            'sender.text = "&New"
        End If

        'Removed By Ali
        'Clear Fields and Reset Cursor
        'txtTimeIn.Text = ""
        'txtTimeOut.Text = ""
        'txtBreakHrs.Text = ""
        'lblTotalHrs.Text = 0

    End Sub
    Private Sub btnSave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnSave.KeyUp
        If e.KeyValue = 13 Then

            'InsertNewRecord
            ''Dim dataRow As DataRow
            ''Dim iEnd As Integer = UltraGrid1.DataSource.Count

            ''UltraGrid1.DataSource.AddNew()
            ''UltraGrid1.DataSource.Item(iEnd).Item("EmployeeId") = cboEmpId.Text.Trim
            ''UltraGrid1.DataSource.Item(iEnd).Item("CheckInDate") = CDate(dpWorked.Value).ToShortDateString.Trim
            ''UltraGrid1.DataSource.Item(iEnd).Item("TimeIn") = txtTimeIn.Text.Trim
            ''UltraGrid1.DataSource.Item(iEnd).Item("TimeOut") = txtTimeOut.Text.Trim
            ''UltraGrid1.DataSource.Item(iEnd).Item("BreakTime") = txtBreakHrs.Text.Trim
            ''UltraGrid1.DataSource.Item(iEnd).Item("TotalHrs") = lblTotalHrs.Text
            ''UltraGrid1.DataSource.Item(iEnd).Item("Processed") = 0


        End If
    End Sub

    Private Sub ucboDeptNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ucboDeptNo.KeyUp
        Select Case e.KeyValue
            Case 39
                ucboDeptNo.ToggleDropdown()
            Case 13
                SimulateTab(e, 13, ucboDeptNo)
        End Select

    End Sub

#End Region

#Region "Field Validation"

    Private Sub txtTimeIn_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeIn.Enter
        If ErrorProvider1.GetError(txtTimeIn).ToString <> "" Then
            txtTimeIn.SelectAll()
        End If
    End Sub

    Private Sub txtTimeIn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTimeIn.Validating

        If (_cValidate.Range(txtTimeIn, 0, 23.99) = False) Then SetError(txtTimeIn, e, "Must be between 00.00 and 23.99")

    End Sub

    Private Sub txtTimeIn_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeIn.Validated
        ClearError(txtTimeIn)
    End Sub

    Private Sub txtTimeOut_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeOut.Enter
        If ErrorProvider1.GetError(txtTimeOut).ToString <> "" Then
            txtTimeOut.SelectAll()
        End If
    End Sub

    Private Sub txtTimeOut_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeOut.Leave
        If txtTimeOut.Text = "" Then txtTimeOut.Text = "0"
    End Sub

    Private Sub txtTimeOut_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTimeOut.Validating

        If (_cValidate.Range(txtTimeOut, 0, 23.99) = False) Then SetError(txtTimeOut, e, "Must be between 00.00 and 23.99")

    End Sub

    Private Sub txtTimeOut_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeOut.Validated
        ClearError(txtTimeOut)
    End Sub

    Private Sub txtBreakHrs_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBreakHrs.Enter
        If ErrorProvider1.GetError(txtBreakHrs).ToString <> "" Then
            txtBreakHrs.SelectAll()
        End If
    End Sub

    Private Sub txtBreakHrs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBreakHrs.Leave, txtTimeIn.Leave, txtTimeOut.Leave

        'Default Value if Nothing Entered
        If txtTimeIn.Text = "" Then txtTimeIn.Text = "0.00"
        If txtTimeOut.Text = "" Then txtTimeOut.Text = "0.00"
        If txtBreakHrs.Text = "" Then txtBreakHrs.Text = "0.00"

        'Perform a simple calculation of total hours worked and diplay in lblTotalHrs
        Dim fOut, fIn, fBrk As Single

        'Retrieve and cast widget values
        fOut = CSng(txtTimeOut.Text)
        fIn = CSng(txtTimeIn.Text)
        fBrk = CSng(txtBreakHrs.Text)

        'Add 24 Hrs if fOut is less than fIn since that signifies a midnight rollover
        If fOut < fIn Then fOut += 24


        utTotalHrs.Text = Format(Round(((fOut - fIn) - fBrk), 2), "0.00")


    End Sub

    Private Sub txtBreakHrs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBreakHrs.Validating
        If (_cValidate.Range(txtBreakHrs, 0, 23.99) = False) Then SetError(txtBreakHrs, e, "Must be between 00.00 and 23.99")
    End Sub

    Private Sub txtBreakHrs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBreakHrs.Validated
        ClearError(txtBreakHrs)
    End Sub

    Private Sub dpWorked_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpWorked.Enter

        'Make an intelligent guess as to what the next field to be modified will be
        Dim dtNow, dtNext As Date
        dtNow = CDate(dpWorked.Value)
        dtNext = dtNow.AddDays(1)
        If (dtNext.Month <> dtNow.Month) Or (dtNext.Year <> dtNow.Year) Or (ErrorProvider1.GetError(dpWorked).ToString <> "") Then
            _iDateSection = 4
        End If

        'Select the field that is most likely to be modified next
        Select Case _iDateSection
            Case 1
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.FirstCharacter, False, False)
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.SelectSection, False, False)
            Case 2
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.FirstCharacter, False, False)
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.SelectSection, False, False)
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.NextSection, False, False)
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.SelectSection, False, False)
            Case 3
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.FirstCharacter, False, False)
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.SelectSection, False, False)
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.NextSection, False, False)
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.SelectSection, False, False)
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.NextSection, False, False)
                Me.dpWorked.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.SelectSection, True, False)
            Case 4
                Me.dpWorked.SelectAll()
                _iDateSection = 2
        End Select

    End Sub

    Private Sub dpWorked_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpWorked.Leave
        If ScreenCode = "DE" Then _iCount = 1
    End Sub

    Private Sub dpWorked_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dpWorked.Validating


        If _workDate.IsInPayPeriod(dpWorked.Value, datePayrollEndDate) = False Then
            SetError(dpWorked, e, "Invalid Date")
            Exit Sub
        End If


        ' Removed By Ali

        'Dim past, future As Date

        'past = datePayrollEndDate.AddDays()
        'future = future.Now

        'If (_cValidate.Range(CDate(dpWorked.Value), past, future) = False) Then
        '    SetError(dpWorked, e, "Invalid Date")
        '    Exit Sub
        'End If

        'If StrComp(_workDate.PayrollEndDate(CDate(dpWorked.Value)).ToShortDateString, lblWeekEnding.Text) <> 0 Then
        '    SetError(dpWorked, e, "CheckInDate must be in current payroll ending period")
        '    Exit Sub
        'End If


    End Sub

    Private Sub dpWorked_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpWorked.Validated
        ClearError(dpWorked)
        txtWeekEnding.Text = Format(_workDate.WeekEnding(dpWorked.Value), "MM/dd/yyyy")

    End Sub


    Private Sub ucboDeptNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDeptNo.Enter
        If ErrorProvider1.GetError(ucboDeptNo).ToString <> "" Then
            Me.ucboDeptNo.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.FirstCharacter, False, False)
            Me.ucboDeptNo.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.SelectSection, False, False)
        End If
    End Sub

    Private Sub ucboDeptNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ucboDeptNo.Validating
        If ucboDeptNo.Text = "" Then
            'SetError(ucboDeptNo, e, "You must enter a valid Department Number")
        Else
            'The general logic is that If AN EMPLOYEE is being PROCESSED, we can not input any TIME_CARD data for the 
            'processed Payroll Ending for
            'the DeptNo processed.

            Dim row2 As DataRow
            If ReturnRowByID(ucboDeptNo.Value, row2, "" & HRTblPath & "EmployeeActivityDetail", " EmployeeID = " & cboEmpId.Value & " AND PayRollEnding = '" & lblPayrollEnding.Text & "' AND Processed = 1 ", "DeptNo") Then
                MsgBox("Dept.No. " & ucboDeptNo.Value & " for Period Ending '" & lblPayrollEnding.Text & "' has been PROCESSED for this employee and is not editable.")
                ucboDeptNo.Value = Nothing
                ucboDeptNo.Text = ""
                ucboDeptNo.Focus()
                'Exit Sub
            End If
            If Not row2 Is Nothing Then
                row2.Table.DataSet.Dispose()
            End If
            row2 = Nothing

            'If (_cValidate.TextInSet(ucboDeptNo, "fldCode", ucboDeptNo.DataSource) = False) Then
            '    SetError(ucboDeptNo, e, "Invalid Department Number")
            'End If
        End If
    End Sub

    Private Sub ucboDeptNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDeptNo.Validated

        'ClearError(ucboDeptNo)
        If ucboDeptNo.Text = "" Then Exit Sub

        'Update the hidden txtPayRate widget
        '''Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If ucboDeptNo.ActiveRow Is Nothing Then

            txtPayRate.Text = "0.00"

        Else

            '''ugrow = ucboDeptNo.ActiveRow
            '''txtPayRate.Text = ugrow.Cells("PayRate").Value

            ' Get the rate for the currently selected dept
            ''01-05-2009:
            ''  Purpose of Change:  Prevent Input Operators from Seeing the Employee's Payrate.
            ''  Details of Change:
            ''      Payrate used to be displayed in the DeptNo drop-down and txtPayRate would gets its value from there.
            ''      This was changed so that DeptNo no longer queries or displays the payrate and instead, txtPayRate 
            ''      gets the payrate for the currently selected department by doing a query.
            Dim dtAdapter As SqlDataAdapter
            Dim dtSet As DataSet
            Dim SQLSelect As String = "select payrate from " & HRTblPath & "employeepayrates where EmployeeID = " & cboEmpId.Text & " and DeptNO = '" & ucboDeptNo.Text & "'"
            PopulateDataset2(dtAdapter, dtSet, SQLSelect)

            If dtSet.Tables(0).Rows.Count = 0 Then
                txtPayRate.Text = "0.00"
            Else
                txtPayRate.Text = CStr(dtSet.Tables(0).Rows(0).Item("payrate"))
            End If

        End If
        'For Each ugrow In ucboDeptNo.Rows
        '    If DataRow("fldCode") = ucboDeptNo.Text Then
        '        txtPayRate.Text = CStr(DataRow("PayRate"))
        '        'txtOfficeID.Text = CStr(DataRow("OfficeID"))
        '        'txtOffice.Text = CStr(DataRow("Office_name"))
        '        Exit For
        '    End If
        'Next


    End Sub

    Private Sub btnEdit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Enter
        If _iCount = 1 Then
            If ScreenCode = "DE" Then
                ControlSetFocus(dpWorked)
            Else
                ControlSetFocus(cboEmpId)
            End If
            _iCount += 1
        End If
    End Sub

#End Region

#Region "Uncommon Events"

    'Removed By Ali
    'Private Sub ucboDeptNo_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ucboDeptNo.InitializeLayout
    '    e.Layout.Bands(0).Columns("OFFICEID").Hidden = True
    '    e.Layout.Bands(0).Columns("OFFICE_NAME").Hidden = True
    '    e.Layout.Bands(0).Columns("PAYRATE").Hidden = True
    'End Sub

#End Region

#Region "Helper Functions"

    'Private Function InitialzeWorkDateClass() As Boolean

    'Dim frm As New TimeCardInputGetPayrollEnding

    'ScreenCode = frm.Go(Me)

    'If frm.DialogResult = DialogResult.OK Then
    '_workDate = New clsWorkDate(CDate("04/02/2006"), "BIWEEKLY", "SUNDAY")
    '_division = frm.strDivision
    'InitialzeWorkDateClass = True
    'Else
    'InitialzeWorkDateClass = False
    'End If

    'End Function

    Private Sub StandardFormPrep()

        'Standard Code for Most Unison Form's Load Event
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

    End Sub
    Private Sub ArrangeForm2()
        Dim pLblDate, pDate, pLblWeek, pLblWeekVal, pLblEmpID, pEmpID, pLblEmp, pEmp As Point
        Dim tiDate, tiWeekVal, tiEmpID, tiEmp As Int16

        pLblDate = lblDateWorked.Location
        pDate = dpWorked.Location
        tiDate = dpWorked.TabIndex

        'pLblWeek = ulblWeekEnding.Location
        'pLblWeekVal = txtWeekEnding.Location
        'tiWeekVal = txtWeekEnding.TabIndex

        pLblEmpID = lblEmpId.Location
        pEmpID = cboEmpId.Location
        tiEmpID = cboEmpId.TabIndex

        pLblEmp = lblName.Location
        pEmp = lblEmpName.Location
        tiEmp = lblEmpName.TabIndex

        Select Case ScreenCode
            Case "ED"
                lblDateWorked.Location = pLblEmp
                dpWorked.Location = pEmp
                dpWorked.TabIndex = tiEmp

                'ulblWeekEnding.Location = pLblEmp
                'txtWeekEnding.Location = pEmp
                'txtWeekEnding.TabIndex = tiEmp

                lblEmpId.Location = pLblDate
                cboEmpId.Location = pDate
                cboEmpId.TabIndex = tiDate

                lblName.Location = pLblEmpID
                lblEmpName.Location = pEmpID
                lblEmpName.TabIndex = tiEmpID
        End Select
    End Sub
    Private Sub ArrangeForm()

        Select Case ScreenCode
            Case "DE"
                ArrangeWidget(txtOfficeID, New Point(0, 0), 0)
                ArrangeWidget(txtOffice, New Point(0, 0), 0)
                ArrangeWidget(txtPayRate, New Point(0, 0), 0)
                ArrangeWidget(txtCheckOutDate, New Point(0, 0), 0)
                ArrangeWidget(txtWeekEnding, New Point(0, 0), 0)
                ArrangeWidget(lblDateWorked, New Point(8, 80), 0)
                ArrangeWidget(lblEmpId, New Point(8, 112), 0)
                ArrangeWidget(lblName, New Point(8, 144), 0)
                ArrangeWidget(lblTimeIn, New Point(8, 208), 0)
                ArrangeWidget(lblTimeOut, New Point(8, 240), 0)
                ArrangeWidget(lblBreakTime, New Point(8, 272), 0)
                ArrangeWidget(ulblTotalHrs, New Point(8, 304), 0)
                ArrangeWidget(lblEmpName, New Point(128, 144), 0)
                ArrangeWidget(utTotalHrs, New Point(128, 304), 0)
                ArrangeWidget(ulblDivision, New Point(8, 16), 0)
                ArrangeWidget(lblDivision, New Point(128, 16), 0)
                ArrangeWidget(ulblWeekEnding, New Point(8, 48), 0)
                ArrangeWidget(lblPayrollEnding, New Point(128, 48), 0)
                ArrangeWidget(ulblDeptNo, New Point(8, 176), 0)
                ArrangeWidget(btnEdit, New Point(688, 352), 0)
                ArrangeWidget(UltraGrid1, New Point(288, 8), 0)
                ArrangeWidget(dpWorked, New Point(128, 80), 1)
                ArrangeWidget(cboEmpId, New Point(128, 112), 2)
                ArrangeWidget(ucboDeptNo, New Point(128, 176), 3)
                ArrangeWidget(txtTimeIn, New Point(128, 208), 4)
                ArrangeWidget(txtTimeOut, New Point(128, 240), 5)
                ArrangeWidget(txtBreakHrs, New Point(128, 272), 6)
                ArrangeWidget(btnSave, New Point(112, 344), 7)
                ArrangeWidget(btnExit, New Point(200, 344), 8)
            Case "ED"
                ArrangeWidget(txtOfficeID, New Point(0, 0), 0)
                ArrangeWidget(txtOffice, New Point(0, 0), 0)
                ArrangeWidget(txtPayRate, New Point(0, 0), 0)
                ArrangeWidget(txtCheckOutDate, New Point(0, 0), 0)
                ArrangeWidget(txtWeekEnding, New Point(0, 0), 0)
                ArrangeWidget(UltraGrid1, New Point(288, 8), 0)
                ArrangeWidget(ulblDivision, New Point(8, 24), 0)
                ArrangeWidget(lblDivision, New Point(128, 24), 0)
                ArrangeWidget(ulblWeekEnding, New Point(8, 56), 0)
                ArrangeWidget(lblEmpName, New Point(128, 152), 0)
                ArrangeWidget(ulblTotalHrs, New Point(8, 312), 0)
                ArrangeWidget(utTotalHrs, New Point(128, 312), 0)
                ArrangeWidget(lblDateWorked, New Point(8, 184), 0)
                ArrangeWidget(lblPayrollEnding, New Point(128, 56), 0)
                ArrangeWidget(lblTimeIn, New Point(8, 216), 0)
                ArrangeWidget(lblEmpId, New Point(8, 88), 0)
                ArrangeWidget(lblName, New Point(8, 152), 0)
                ArrangeWidget(lblTimeOut, New Point(8, 248), 0)
                ArrangeWidget(ulblDeptNo, New Point(8, 120), 0)
                ArrangeWidget(lblBreakTime, New Point(8, 280), 0)
                ArrangeWidget(btnEdit, New Point(688, 352), 0)
                ArrangeWidget(cboEmpId, New Point(128, 88), 1)
                ArrangeWidget(ucboDeptNo, New Point(128, 120), 2)
                ArrangeWidget(dpWorked, New Point(128, 184), 3)
                ArrangeWidget(txtTimeIn, New Point(128, 216), 4)
                ArrangeWidget(txtTimeOut, New Point(128, 248), 5)
                ArrangeWidget(txtBreakHrs, New Point(128, 280), 6)
                ArrangeWidget(btnSave, New Point(112, 352), 7)
                ArrangeWidget(btnExit, New Point(200, 352), 8)
            Case Else
        End Select

    End Sub

    Private Sub ArrangeWidget(ByVal ctl As Control, ByVal coordinates As Point, ByVal tabIndex As Integer, Optional ByVal visible As Boolean = True)

        ctl.Location = coordinates
        ctl.TabIndex = tabIndex
        ctl.Visible = visible

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

    Public Sub ControlSetFocus(ByVal control As Control)
        ' Set focus to the control, if it can receive focus.
        If control.CanFocus Then
            control.Focus()
        End If
    End Sub

#End Region

#Region "Data Access Functions"

    Private Sub FillInputHistory(ByVal empId As Integer)

        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        'Dim HidCols() As String = {"RowID", "EmployeeId", "OfficeID", "Office", "CheckOutDate", "PayRate", "WeeklyRegHrsTotal", "TotalHrs", "RegHrs", "OTHrs", "DTHrs", "WeekEnding", "LastUpdate", "Processed"}
        Dim HidCols() As String = {"RowID", "EmployeeId", "OfficeID", "CheckOutDate", "PayRate", "Division", "PayrollEnding"}
        Dim i As Integer
        Dim SQLSelect, DateRngCond, AcctCond, FromLocCond, ToLocCond, TRNumCond, ThirdPCond, EventCond, Address3 As String
        Dim SummCol As String

        'Modified By Ali
        SQLSelect = "SELECT RowID, EmployeeID, Division, OfficeID, Office, TotalHrs, CheckInDate, TimeIn, CheckOutDate, TimeOut, BreakTime, DeptNo, PayRate, WeekEnding, PayrollEnding, LastUpdate, Processed" & _
                    " FROM " & HRTblPath & "EmployeeActivityDetail WHERE EmployeeId = " & empId & " AND PayrollEnding = '" & lblPayrollEnding.Text.Trim & "' ORDER BY CheckInDate, TimeIn Asc"

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

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
            'UltraGrid1.DisplayLayout.Bands(0).Columns(i).PerformAutoResize()

            b = g.MeasureString(UltraGrid1.DisplayLayout.Bands(0).Columns(i).ToString, UltraGrid1.Font)
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).Width = b.Width + 20 'UltraGrid1.DisplayLayout.Bands(0).Columns(i).ToString.Length

            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next
        'UltraGrid1.DisplayLayout.Bands(0).Columns(0).Width = 20

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


    End Sub

#End Region

#Region "Class Methods"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        ErrorProvider1.Dispose()
    End Sub

    Public Sub InitWorkDate(ByVal dt As Date, ByVal freq As String, ByVal wed As String)
        _workDate = New clsWorkDate(dt, freq, wed)
    End Sub

#End Region

#Region "Debug Functions"

    Private Sub DebugTabIndex()
        MessageBox.Show(CStr("txtOfficeID" & " = " & txtOfficeID.TabIndex))
        MessageBox.Show(CStr("txtOffice" & " = " & txtOffice.TabIndex))
        MessageBox.Show(CStr("txtPayRate" & " = " & txtPayRate.TabIndex))
        MessageBox.Show(CStr("txtCheckOutDate" & " = " & txtCheckOutDate.TabIndex))
        MessageBox.Show(CStr("lblDateWorked" & " = " & lblDateWorked.TabIndex))
        MessageBox.Show(CStr("lblEmpId" & " = " & lblEmpId.TabIndex))
        MessageBox.Show(CStr("lblName" & " = " & lblName.TabIndex))
        MessageBox.Show(CStr("lblTimeIn" & " = " & lblTimeIn.TabIndex))
        MessageBox.Show(CStr("lblTimeOut" & " = " & lblTimeOut.TabIndex))
        MessageBox.Show(CStr("lblBreakTime" & " = " & lblBreakTime.TabIndex))
        MessageBox.Show(CStr("ulblTotalHrs" & " = " & ulblTotalHrs.TabIndex))
        MessageBox.Show(CStr("lblEmpName" & " = " & lblEmpName.TabIndex))
        MessageBox.Show(CStr("lblTotalHrs" & " = " & utTotalHrs.TabIndex))
        MessageBox.Show(CStr("ulblDivision" & " = " & ulblDivision.TabIndex))
        MessageBox.Show(CStr("lblDivision" & " = " & lblDivision.TabIndex))
        MessageBox.Show(CStr("ulblWeekEnding" & " = " & ulblWeekEnding.TabIndex))
        MessageBox.Show(CStr("lblWeekEnding" & " = " & lblPayrollEnding.TabIndex))
        MessageBox.Show(CStr("ulblDeptNo" & " = " & ulblDeptNo.TabIndex))
        MessageBox.Show(CStr("ucboDeptNo" & " = " & ucboDeptNo.TabIndex))
        MessageBox.Show(CStr("UltraGrid1" & " = " & UltraGrid1.TabIndex))
        MessageBox.Show(CStr("dpWorked" & " = " & dpWorked.TabIndex))
        MessageBox.Show(CStr("cboEmpId" & " = " & cboEmpId.TabIndex))
        MessageBox.Show(CStr("txtTimeIn" & " = " & txtTimeIn.TabIndex))
        MessageBox.Show(CStr("txtTimeOut" & " = " & txtTimeOut.TabIndex))
        MessageBox.Show(CStr("txtBreakHrs" & " = " & txtBreakHrs.TabIndex))
        MessageBox.Show(CStr("btnSave" & " = " & btnSave.TabIndex))
        MessageBox.Show(CStr("btnExit" & " = " & btnExit.TabIndex))
        MessageBox.Show(CStr("btnEdit" & " = " & btnEdit.TabIndex))

    End Sub
    'Removed By Ali
    ''PURPOSE:   This function will return allocate memory for the 'dataset' and populate it with a list of Employees that 'userId' is 
    ''           allowed to view and modify.
    ''RETURNS:   The number of records in the dataset.  0 for an empy set, -1 if an error occured
    'Public Function FetchTimeCardEmployeesTmp(ByVal userId As String, ByRef dtSet As DataSet, Optional ByVal SQLQuery As String = "") As Integer

    '    'Create an instance of the clsSqlServer class
    '    'Dim cServer As New clsSqlServer(strCn) '' REPLACE WITH UNISON'S DATA ACCESS MODEL

    '    'Prepare to use the returned data values
    '    Dim strSQL As String
    '    Dim dtaCbo As New SqlDataAdapter
    '    Dim dtView As New DataView

    '    'cServer.PopulateDataset2(dtaCbo, dtSet, "select id from employeesbase where company in (select company from employeesbase where id = '3841')")
    '    'Dim strSQL = "select id from employeesbase where company in (select company from employeesbase where id = '3841') ORDER BY id"
    '    strSQL = "select id as EmployeeID, RTRIM(firstname) + ' ' + RTRIM(middlename) + ' ' + RTRIM(lastname) as EmployeeName from UN_HR.dbo.employees where status = 'A' order by id asc"

    '    PopulateDataset2(dtaCbo, dtSet, strSQL)

    '    FetchTimeCardEmployeesTmp = True

    'End Function

#End Region

    Private Sub txtTimeIn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeIn.Leave, txtTimeOut.Leave, txtBreakHrs.Leave
        sender.Text = Format(Val(sender.text), "0.00")
    End Sub

    Private Sub TimeCardInput_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not cmdTrans Is Nothing Then
            cmdTrans.Transaction.Rollback()
            If cmdTrans.Connection.State = ConnectionState.Open Then
                cmdTrans.Connection.Close()
            End If
            cmdTrans = Nothing
        End If

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

    Private Sub txtWeekEnding_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWeekEnding.ValueChanged
        FillWeekTotals(cboEmpId.Text.Trim, txtWeekEnding.Text)
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click

        _strClipDeptNo = ucboDeptNo.Text
        _strClipTimeIn = txtTimeIn.Text
        _strClipTimeOut = txtTimeOut.Text
        _strClipBreakHrs = txtBreakHrs.Text

        _strClipOfficeID = txtOfficeID.Text
        _strClipPayRate = txtPayRate.Text
        _strClipOffice = txtOffice.Text
        _strClipTotalHours = utTotalHrs.Text

        'btnSave.Focus()
        txtBreakHrs.Focus()

    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click

        If (_strClipDeptNo = "") And (_strClipTimeIn = "") And (_strClipTimeOut = "") And (_strClipBreakHrs = "") Then
            MsgBox("Clipboard is Empty", MsgBoxStyle.Information, "Clipboard Error")
            ucboDeptNo.Focus()
            Exit Sub
        End If
        ucboDeptNo.Text = _strClipDeptNo
        txtTimeIn.Text = _strClipTimeIn
        txtTimeOut.Text = _strClipTimeOut
        txtBreakHrs.Text = _strClipBreakHrs
        txtOfficeID.Text = _strClipOfficeID
        txtPayRate.Text = _strClipPayRate
        txtOffice.Text = _strClipOffice
        utTotalHrs.Text = _strClipTotalHours

        'btnSave.Focus()
        txtBreakHrs.Focus()

    End Sub

    Public Function GetEmployeeSchedule(ByVal p_iEmpId As Integer, ByVal p_iDayOfWeek As Integer) As DataSet

        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As DataSet
        Dim SQLSelect As String
        Dim i As Integer

        'Prepare the SQL Statement
        If p_iDayOfWeek = 0 Then p_iDayOfWeek = 7 'This application treats Sunday as Day 7
        SQLSelect = "SELECT EmployeeID, DayNo, TimeIn, TimeOut, BreakTime FROM " & HRTblPath & "EmployeeSchedule WHERE EmployeeID = " & p_iEmpId & " AND DayNo = " & p_iDayOfWeek & " ORDER BY TimeIn ASC"

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next

        Return dtSet

    End Function

    Public Sub ShowEmployeeSchedule(ByRef p_dataSet As DataSet)

        Dim HidCols() As String = {"EmployeeId", "DayNo"}
        Dim SQLSelect As String ', DateRngCond, AcctCond, FromLocCond, ToLocCond, TRNumCond, ThirdPCond, EventCond, Address3 As String
        Dim SummCol As String
        Dim i As Integer

        FillUltraGrid(UltraGrid2, p_dataSet, -1, HidCols, 0)
        UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGrid2.DisplayLayout.AutoFitColumns = False
        Dim b As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        For i = 0 To UltraGrid2.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = True
            'UltraGrid2.DisplayLayout.Bands(0).Columns(i).PerformAutoResize()

            b = g.MeasureString(UltraGrid2.DisplayLayout.Bands(0).Columns(i).ToString, UltraGrid2.Font)
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).Width = b.Width + 20 'UltraGrid2.DisplayLayout.Bands(0).Columns(i).ToString.Length

            UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next
        'UltraGrid2.DisplayLayout.Bands(0).Columns(0).Width = 20

        'UltraGrid2.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'SummCol = "TotalHrs"
        'UltraGrid2.DisplayLayout.Bands(0).Summaries.Add(SummCol, Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid2.DisplayLayout.Bands(0).Columns(SummCol), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid2.DisplayLayout.Bands(0).Summaries(SummCol).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid2.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid2.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        'UltraGrid2.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        'UltraGrid2.DisplayLayout.GroupByBox.Hidden = False
        'UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

    End Sub

    Private Sub dpWorked_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpWorked.ValueChanged
        If cboEmpId.Text.Trim <> "" Then
            'Populate DataGrid2
            ShowEmployeeSchedule(GetEmployeeSchedule(cboEmpId.Text.Trim, dpWorked.DateTime.DayOfWeek))
        End If
    End Sub
End Class

