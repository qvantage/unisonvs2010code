''THIS FORM DOES NOT WORK ON
'If in NEW mode and pressed CANCEL, form shuts down
'Karina

Imports System.Data
Imports System.Data.SqlClient

Public Class EmployeeSchedule
    Inherits System.Windows.Forms.Form

#Region "Private Members"

    Private MeText As String
    Private _strMode As String
    Private _strInputMode As String
    Private EmplCriteria As String
    Private EmplCriteria3 As String
    Private _strEmployees_Select As String
    Private _strEmployeeSchedule_Select As String
    Private _strEmployeeSchedule_Where As String
    Private _strEmployeeSchedule_Sort As String
    Private _cmdTrans As SqlCommand
    Private _dsGridData As DataSet
    Private _strGridSQL As String
    Private _iCurrentRow As Integer
    Private _cValidate As clsFieldValidator
    Private _firstClick As Boolean

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
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents utEmployeeName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnEmplID As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EmplID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ulblDeptNo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblBreakTime As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTimeOut As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTimeIn As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtTimeIn As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtTimeOut As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboDeptNo As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ucboDay As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtBreakTime As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtDayNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalHrs As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EmployeeSchedule))
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.utEmployeeName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnEmplID = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.EmplID = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtDayNo = New System.Windows.Forms.TextBox
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.ucboDay = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ulblDeptNo = New Infragistics.Win.Misc.UltraLabel
        Me.lblBreakTime = New Infragistics.Win.Misc.UltraLabel
        Me.lblTimeOut = New Infragistics.Win.Misc.UltraLabel
        Me.lblTimeIn = New Infragistics.Win.Misc.UltraLabel
        Me.txtTimeIn = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtTimeOut = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtBreakTime = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboDeptNo = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTotalHrs = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox1.SuspendLayout()
        CType(Me.utEmployeeName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ucboDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimeIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBreakTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDeptNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalHrs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.utEmployeeName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnPrev)
        Me.GroupBox1.Controls.Add(Me.btnNext)
        Me.GroupBox1.Controls.Add(Me.btnEmplID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.EmplID)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'utEmployeeName
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utEmployeeName.Appearance = Appearance1
        Me.utEmployeeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployeeName.Enabled = False
        Me.utEmployeeName.Location = New System.Drawing.Point(101, 39)
        Me.utEmployeeName.Name = "utEmployeeName"
        Me.utEmployeeName.Size = New System.Drawing.Size(207, 21)
        Me.utEmployeeName.TabIndex = 5
        Me.utEmployeeName.Tag = ".EmployeeName.view"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(2, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Employee Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPrev
        '
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrev.Location = New System.Drawing.Point(181, 15)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(24, 21)
        Me.btnPrev.TabIndex = 2
        Me.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNext
        '
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNext.Location = New System.Drawing.Point(205, 15)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(24, 21)
        Me.btnNext.TabIndex = 3
        '
        'btnEmplID
        '
        Me.btnEmplID.Location = New System.Drawing.Point(233, 15)
        Me.btnEmplID.Name = "btnEmplID"
        Me.btnEmplID.Size = New System.Drawing.Size(75, 20)
        Me.btnEmplID.TabIndex = 4
        Me.btnEmplID.Text = "Select"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employee ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EmplID
        '
        Me.EmplID.Location = New System.Drawing.Point(101, 15)
        Me.EmplID.Name = "EmplID"
        Me.EmplID.Size = New System.Drawing.Size(75, 20)
        Me.EmplID.TabIndex = 1
        Me.EmplID.Tag = ".id"
        Me.EmplID.Text = ""
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnDelete)
        Me.GroupBox4.Controls.Add(Me.btnNew)
        Me.GroupBox4.Controls.Add(Me.btnEdit)
        Me.GroupBox4.Controls.Add(Me.btnExit)
        Me.GroupBox4.Controls.Add(Me.btnSave)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 454)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(336, 48)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(157, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 24)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(106, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 24)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(55, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 24)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(264, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(50, 24)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(50, 24)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTotalHrs)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtDayNo)
        Me.GroupBox2.Controls.Add(Me.UltraLabel1)
        Me.GroupBox2.Controls.Add(Me.ucboDay)
        Me.GroupBox2.Controls.Add(Me.ulblDeptNo)
        Me.GroupBox2.Controls.Add(Me.lblBreakTime)
        Me.GroupBox2.Controls.Add(Me.lblTimeOut)
        Me.GroupBox2.Controls.Add(Me.lblTimeIn)
        Me.GroupBox2.Controls.Add(Me.txtTimeIn)
        Me.GroupBox2.Controls.Add(Me.txtTimeOut)
        Me.GroupBox2.Controls.Add(Me.txtBreakTime)
        Me.GroupBox2.Controls.Add(Me.ucboDeptNo)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 104)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtDayNo
        '
        Me.txtDayNo.Location = New System.Drawing.Point(314, 15)
        Me.txtDayNo.Name = "txtDayNo"
        Me.txtDayNo.Size = New System.Drawing.Size(15, 20)
        Me.txtDayNo.TabIndex = 6
        Me.txtDayNo.Tag = ".DayNo"
        Me.txtDayNo.Text = ""
        Me.txtDayNo.Visible = False
        '
        'UltraLabel1
        '
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Appearance2.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance2.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Location = New System.Drawing.Point(195, 16)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(31, 16)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "Day:"
        '
        'ucboDay
        '
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.ucboDay.Appearance = Appearance3
        Me.ucboDay.DisplayMember = ""
        Me.ucboDay.Location = New System.Drawing.Point(228, 14)
        Me.ucboDay.Name = "ucboDay"
        Me.ucboDay.Size = New System.Drawing.Size(80, 21)
        Me.ucboDay.TabIndex = 2
        Me.ucboDay.Tag = ".Day..1.EmployeeSchedule.Day.Day"
        Me.ucboDay.ValueMember = ""
        '
        'ulblDeptNo
        '
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Appearance4.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance4.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblDeptNo.Appearance = Appearance4
        Me.ulblDeptNo.Location = New System.Drawing.Point(18, 16)
        Me.ulblDeptNo.Name = "ulblDeptNo"
        Me.ulblDeptNo.Size = New System.Drawing.Size(56, 16)
        Me.ulblDeptNo.TabIndex = 0
        Me.ulblDeptNo.Text = "Dept. No.:"
        '
        'lblBreakTime
        '
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Appearance5.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance5.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblBreakTime.Appearance = Appearance5
        Me.lblBreakTime.Location = New System.Drawing.Point(2, 75)
        Me.lblBreakTime.Name = "lblBreakTime"
        Me.lblBreakTime.Size = New System.Drawing.Size(72, 16)
        Me.lblBreakTime.TabIndex = 0
        Me.lblBreakTime.Text = "Break Length"
        '
        'lblTimeOut
        '
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Appearance6.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance6.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblTimeOut.Appearance = Appearance6
        Me.lblTimeOut.Location = New System.Drawing.Point(171, 47)
        Me.lblTimeOut.Name = "lblTimeOut"
        Me.lblTimeOut.Size = New System.Drawing.Size(55, 16)
        Me.lblTimeOut.TabIndex = 0
        Me.lblTimeOut.Text = "Time Out:"
        '
        'lblTimeIn
        '
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Appearance7.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance7.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblTimeIn.Appearance = Appearance7
        Me.lblTimeIn.Location = New System.Drawing.Point(28, 47)
        Me.lblTimeIn.Name = "lblTimeIn"
        Me.lblTimeIn.Size = New System.Drawing.Size(46, 16)
        Me.lblTimeIn.TabIndex = 0
        Me.lblTimeIn.Text = "Time In:"
        '
        'txtTimeIn
        '
        Appearance8.ForeColor = System.Drawing.Color.Black
        Appearance8.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.txtTimeIn.Appearance = Appearance8
        Me.txtTimeIn.Location = New System.Drawing.Point(82, 45)
        Me.txtTimeIn.Name = "txtTimeIn"
        Me.txtTimeIn.Size = New System.Drawing.Size(64, 21)
        Me.txtTimeIn.TabIndex = 3
        Me.txtTimeIn.Tag = ".TimeIn"
        '
        'txtTimeOut
        '
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.txtTimeOut.Appearance = Appearance9
        Me.txtTimeOut.Location = New System.Drawing.Point(228, 45)
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.Size = New System.Drawing.Size(64, 21)
        Me.txtTimeOut.TabIndex = 4
        Me.txtTimeOut.Tag = ".TimeOut"
        '
        'txtBreakTime
        '
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.txtBreakTime.Appearance = Appearance10
        Me.txtBreakTime.Location = New System.Drawing.Point(82, 73)
        Me.txtBreakTime.Name = "txtBreakTime"
        Me.txtBreakTime.Size = New System.Drawing.Size(64, 21)
        Me.txtBreakTime.TabIndex = 5
        Me.txtBreakTime.Tag = ".BreakTime"
        '
        'ucboDeptNo
        '
        Appearance11.ForeColor = System.Drawing.Color.Black
        Appearance11.ForeColorDisabled = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.ucboDeptNo.Appearance = Appearance11
        Me.ucboDeptNo.DisplayMember = ""
        Me.ucboDeptNo.Location = New System.Drawing.Point(82, 14)
        Me.ucboDeptNo.Name = "ucboDeptNo"
        Me.ucboDeptNo.Size = New System.Drawing.Size(101, 21)
        Me.ucboDeptNo.TabIndex = 1
        Me.ucboDeptNo.Tag = ".DeptNo..1.EmployeeSchedule.DeptNo.DeptNo"
        Me.ucboDeptNo.ValueMember = ""
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 176)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(336, 278)
        Me.UltraGrid1.TabIndex = 2
        Me.UltraGrid1.TabStop = False
        Me.UltraGrid1.Text = "Employee Schedule"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(160, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Total Hours:"
        '
        'txtTotalHrs
        '
        Appearance12.FontData.Name = "Arial Black"
        Appearance12.ForeColor = System.Drawing.Color.Blue
        Appearance12.ForeColorDisabled = System.Drawing.Color.Blue
        Me.txtTotalHrs.Appearance = Appearance12
        Me.txtTotalHrs.Enabled = False
        Me.txtTotalHrs.Location = New System.Drawing.Point(229, 71)
        Me.txtTotalHrs.Name = "txtTotalHrs"
        Me.txtTotalHrs.Size = New System.Drawing.Size(64, 24)
        Me.txtTotalHrs.TabIndex = 8
        '
        'EmployeeSchedule
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(336, 502)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "EmployeeSchedule"
        Me.Text = "Employees Schedule"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utEmployeeName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ucboDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTimeIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTimeOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBreakTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDeptNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalHrs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Common Events"

    Private Sub EmployeeSchedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        StandardFormPrep()

        AddHandler txtTimeIn.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler txtTimeOut.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler txtBreakTime.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler ucboDeptNo.Leave, AddressOf UCbo_Leave
        AddHandler ucboDay.Leave, AddressOf UCbo_Leave

        _cValidate = New clsFieldValidator
        _firstClick = True

        ' Set Widgets in View Mode by Default
        SetFormMode("VIEW")

        ' Initialize Data Members
        EmplCriteria = " WHERE ID = @EmplID "
        EmplCriteria3 = " WHERE EmployeeID = @EmplID "
        _strEmployees_Select = "Select ID, FirstName + ' ' + LastName as EmployeeName from " & HRTblPath & "EmployeesBase order by ID ASC"
        _strEmployeeSchedule_Select = "SELECT RowID, EmployeeID, DeptNo, Day, DayNo, TimeIn, TimeOut, BreakTime FROM " & HRTblPath & "EMPLOYEESCHEDULE "
        _strEmployeeSchedule_Where = " WHERE EmployeeID = @@EmplId "
        _strEmployeeSchedule_Sort = " ORDER BY DayNo, TimeIn "

        '_strEmployeeSchedule_Select = _
        '"SELECT rowid, employeeid, deptno, day, timein, timeout, breaktime, 1 as dayNum FROM un_hr.dbo.EMPLOYEESCHEDULE where employeeid = '@@EmplId' and day = 'MON' " & _
        '"UNION SELECT rowid, employeeid, deptno, day, timein, timeout, breaktime, 2 as dayNum FROM un_hr.dbo.EMPLOYEESCHEDULE where employeeid = '@@EmplId' and day = 'TUE' " & _
        '"UNION SELECT rowid, employeeid, deptno, day, timein, timeout, breaktime, 3 as dayNum FROM un_hr.dbo.EMPLOYEESCHEDULE where employeeid = '@@EmplId' and day = 'WED' " & _
        '"UNION SELECT rowid, employeeid, deptno, day, timein, timeout, breaktime, 4 as dayNum FROM un_hr.dbo.EMPLOYEESCHEDULE where employeeid = '@@EmplId' and day = 'THU' " & _
        '"UNION SELECT rowid, employeeid, deptno, day, timein, timeout, breaktime, 5 as dayNum FROM un_hr.dbo.EMPLOYEESCHEDULE where employeeid = '@@EmplId' and day = 'FRI' " & _
        '"UNION SELECT rowid, employeeid, deptno, day, timein, timeout, breaktime, 6 as dayNum FROM un_hr.dbo.EMPLOYEESCHEDULE where employeeid = '@@EmplId' and day = 'SAT' " & _
        '"UNION SELECT rowid, employeeid, deptno, day, timein, timeout, breaktime, 7 as dayNum FROM un_hr.dbo.EMPLOYEESCHEDULE where employeeid = '@@EmplId' and day = 'SUN' "

        '_strEmployeeSchedule_Sort = "ORDER BY dayNum, timein"

        ' Retrieve Data and Initialize Widgets
        LoadData("", "N")
        If EmplID.Text <> "" Then
            PopulateGrid(EmplID.Text)
        End If

        'This seemingly useless call allows the form to initialize properly so that the first click on the grid is received correctly
        Me.SelectNextControl(EmplID, True, True, True, True)

    End Sub

    Private Sub EmployeeSchedule_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnNew.Text = "&Cancel" Or btnEdit.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        If _strMode.ToUpper = "INPUT" Then
            EditForm(Me, _strEmployeeSchedule_Select, EditAction.CANCEL, _cmdTrans)
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        ''Rollback and Toggle Out if already in New mode.
        'If sender.Text = "&Cancel" Then
        '    SetFormMode("VIEW")
        '    ' Reset GroupBox2
        '    UltraGrid1.Select()
        '    LoadGroupBox2FromGrid(UltraGrid1)
        '    SetFormMode("VIEW")
        'Else
        '    ' Make sure can start this action
        '    If btnEdit.Text = "&Cancel" Then
        '        MessageBox.Show("You are in Edit mode. Cancel or Save your current job first.")
        '        Exit Sub
        '    End If
        '    'Initialize GroupBox1 Widgets
        '    'Initialize GroupBox2 Widgets
        '    ClearGroupBox2()
        '    TagGroupBox2(True)
        '    FillDayCombo()
        '    FillDeptNoCombo()
        '    ' Initialize Widget State
        '    SetFormMode("INPUT", "NEW")
        '    ucboDeptNo.Focus()
        'End If
        'Karina's changes
        If btnEdit.Text = "&Cancel" Then
            MessageBox.Show("You are in 'Edit' mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If sender.Text = "&Cancel" Then
            SetFormMode("VIEW")
            ' Reset GroupBox2
            UltraGrid1.Select()
            LoadGroupBox2FromGrid(UltraGrid1)
            SetFormMode("VIEW")
        Else
            '    ' Make sure can start this action
            '    If btnEdit.Text = "&Cancel" Then
            '        MessageBox.Show("You are in Edit mode. Cancel or Save your current job first.")
            '        Exit Sub
            '    End If
            '    'Initialize GroupBox1 Widgets
            '    'Initialize GroupBox2 Widgets
            ClearGroupBox2()
            TagGroupBox2(True)
            FillDayCombo()
            FillDeptNoCombo()
            ' Initialize Widget State
            SetFormMode("INPUT", "NEW")
            ucboDeptNo.Focus()
        End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        'Dim SQLSelect As String = "select deptno, day, timein, timeout, breaktime from " & HRTblPath & "employeeschedule "

        'Rollback and Toggle Out if already in New mode.
        If btnEdit.Text = "&Cancel" Then

            ' Initialize GroupBox2 Data
            EditForm(Me, _strEmployeeSchedule_Select, EditAction.CANCEL, _cmdTrans)

            ' Reset GroupBox2
            UltraGrid1.Select()
            LoadGroupBox2FromGrid(UltraGrid1)
            SetFormMode("VIEW")

        Else

            ' Make sure can start this action
            If btnNew.Text = "&Cancel" Then
                MessageBox.Show("You are in New mode. Cancel or Save your current job first.")
                Exit Sub
            End If

            'Populate GroupBox2 Widgets with Dataset in Edit Mode
            If UltraGrid1.Rows.Count <= 0 Then Exit Sub

            ' Initialize Widget State
            SetFormMode("INPUT", "EDIT")

            'Initialize GroupBox2 Widgets
            TagGroupBox2(True)
            FillDayCombo()
            FillDeptNoCombo()

            EditForm(Me, PrepSelectQuery(_strEmployeeSchedule_Select, " where rowid = " & UltraGrid1.ActiveRow.Cells("RowID").Value.ToString.Trim), EditAction.START, _cmdTrans)

            ucboDeptNo.Select()
            ucboDay.Select()
            ucboDeptNo.Select()

        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        'If _strMode = "INPUT" Then
        '    Dim response As MsgBoxResult
        '    response = MyMsgBox("Do you want to exit now and lose your changes?", "Confirm Exit From Input Mode", MsgBoxStyle.YesNo)
        '    Select Case response
        '        Case MsgBoxResult.Yes
        '            'Rollback Changes
        '        Case MsgBoxResult.No
        '            Exit Sub
        '    End Select
        'End If
        'Close()
        'Karina
        Me.Close()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' This Sub-routine Will Either Perform Database Update or Insert Depending on the Current Mode

        If ValidateGroupBox2() = False Then Exit Sub

        Dim bResult As Boolean
        Dim strCondition As String

        'Initialize Widget Tags In Preparation for Call to EditForm()
        Me.Tag = HRTblPath & "EmployeeSchedule"
        utEmployeeName.Tag = ""
        If _strInputMode = "NEW" Then
            EmplID.Tag = ".EmployeeId"
            strCondition = ""
        Else
            EmplID.Tag = ""
            strCondition = " WHERE rowid = " & UltraGrid1.ActiveRow.Cells("RowID").Value.ToString.Trim
        End If

        Dim ucboDeptNoText, ucboDeptNoTag As String
        Dim ucboDayText, ucboDayTag As String
        Dim txtDayNoText, txtDayNoTag As String
        ucboDeptNoText = ucboDeptNo.Text
        ucboDeptNoTag = ucboDeptNo.Tag
        ucboDayText = ucboDay.Text
        ucboDayTag = ucboDay.Tag
        txtDayNoText = txtDayNo.Text
        txtDayNoTag = txtDayNo.Tag
        If EditForm(Me, _strEmployeeSchedule_Select, EditAction.ENDEDIT, _cmdTrans, strCondition) Then
            PopulateGrid(CInt(EmplID.Text))
        End If

        'Return Widgets to View Mode
        Me.Tag = ""
        EmplID.Tag = ".id"
        utEmployeeName.Tag = ".EmployeeName.view"
        SetFormMode("VIEW")

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        ' Make sure can start this action
        If _strMode.ToUpper = "INPUT" Then
            CriticalMessage("You are in Input mode. Cancel or Save your current job first.", "Mode Error")
            Exit Sub
        End If

        Dim dsData As New DataSet
        Dim ID As Integer
        Dim row As DataRow
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If UltraGrid1.Selected.Rows.Count = 0 Then Exit Sub

        If UltraGrid1.Selected.Rows.Count = UltraGrid1.Rows.Count Then
            ID = -1
        Else
            ugrow = UltraGrid1.Selected.Rows(0)
            If ugrow.Index > 0 Then
                ID = ugrow.Index - 1
            Else
                ID = 0
            End If
        End If

        UltraGrid1.DeleteSelectedRows()
        If UpdateDbFromDataSet(_dsGridData, _strGridSQL) <= 0 Then
            'MsgBox("btnDelete_Click: Error!")
            Exit Sub
        End If
        If ID >= 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetItem(ID)
            UltraGrid1.ActiveRow.Selected = True
        Else
            ClearGroupBox2()
            SetFormMode("VIEW")
        End If
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        LoadData(Val(EmplID.Text), "P")
        PopulateGrid(CInt(EmplID.Text))
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadData(Val(EmplID.Text), "N")
        PopulateGrid(CInt(EmplID.Text))
    End Sub

    Private Sub btnEmplID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmplID.Click

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
        If ErrorProvider1.GetError(EmplID).ToString <> "" Then
            ClearError(EmplID)
            EmplID.Text = ""
        End If

        PopulateDataset2(dtAdapter, dtSet, _strEmployees_Select)

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
                    EmplID.Text = ugRow.Cells("ID").Text
                    utEmployeeName.Text = ugRow.Cells("EmployeeName").Text
                    Srch = Nothing
                    EmplID.Modified = False
                End If
                EmplID.Focus()
                SelectNextControl(EmplID, True, False, False, False)
                EmplID.Focus()
            End Try
        End If

    End Sub

    Private Sub txtTimeIn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeIn.Leave
        sender.Text = Format(Val(sender.text), "0.00")
    End Sub

    Private Sub txtTimeOut_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeOut.Leave
        sender.Text = Format(Val(sender.text), "0.00")
    End Sub

    Private Sub txtBreakTime_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBreakTime.Leave
        sender.Text = Format(Val(sender.text), "0.00")
    End Sub

#End Region

#Region "Helper Functions"

    Private Sub SetFormMode(ByVal p_strMode As String, Optional ByVal p_strInputMode As String = "")

        _strMode = ""
        _strInputMode = ""

        Select Case p_strMode.ToUpper

            Case "VIEW"

                _strMode = p_strMode.ToUpper
                GroupBox1.Enabled = True
                GroupBox2.Enabled = False
                TagGroupBox2(False)
                UltraGrid1.Enabled = True
                btnSave.Enabled = False
                btnSave.Text = "&Save"
                btnEdit.Enabled = True
                btnEdit.Text = "&Edit"
                btnNew.Enabled = True
                btnNew.Text = "&New"
                btnExit.Enabled = True
                btnExit.Text = "&Exit"

            Case "INPUT"

                If ValidEmployeeID() Then
                    _strMode = p_strMode.ToUpper
                    _strInputMode = p_strInputMode.ToUpper
                    If _strInputMode = "NEW" Then
                        GroupBox1.Enabled = False
                        GroupBox2.Enabled = True
                        TagGroupBox2(True)
                        UltraGrid1.Enabled = False
                        btnSave.Enabled = True
                        btnSave.Text = "&Save"
                        btnEdit.Enabled = False
                        btnEdit.Text = "&Edit"
                        btnNew.Enabled = True
                        btnNew.Text = "&Cancel"
                        btnExit.Enabled = True
                        btnExit.Text = "&Exit"
                        CalculateTotalHours()
                    Else
                        GroupBox1.Enabled = False
                        GroupBox2.Enabled = True
                        TagGroupBox2(True)
                        UltraGrid1.Enabled = False
                        btnSave.Enabled = True
                        btnSave.Text = "&Save"
                        btnEdit.Enabled = True
                        btnEdit.Text = "&Cancel"
                        btnNew.Enabled = False
                        btnNew.Text = "&New"
                        btnExit.Enabled = True
                        btnExit.Text = "&Exit"
                        CalculateTotalHours()
                    End If
                Else
                    MyMsgBox("You must enter a valid EmployeeID", "Invalid Employee", MsgBoxStyle.Critical)
                End If

        End Select

    End Sub

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

    Private Function MyMsgBox(ByVal msg As String, ByVal title As String, ByVal style As MsgBoxStyle) As MsgBoxResult
        MyMsgBox = MsgBox(msg, style, title)
    End Function

    Private Function TagGroupBox2(ByVal p_tagged As Boolean)

        If p_tagged Then
            ucboDeptNo.Tag = ".deptno..1.employeschedule.deptno.deptno"
            ucboDay.Tag = ".day..1.employeschedule.day.day"
            txtDayNo.Tag = ".dayno"
            txtTimeIn.Tag = ".timein"
            txtTimeOut.Tag = ".timeout"
            txtBreakTime.Tag = ".breaktime"
        Else
            ucboDeptNo.Tag = ""
            ucboDay.Tag = ""
            txtDayNo.Tag = ""
            txtTimeIn.Tag = ""
            txtTimeOut.Tag = ""
            txtBreakTime.Tag = ""
        End If

    End Function

    Private Sub ClearGroupBox2()

        ucboDeptNo.Text = ""
        ucboDay.Text = ""
        txtDayNo.Text = ""
        txtTimeIn.Text = ""
        txtTimeOut.Text = ""
        txtBreakTime.Text = ""
        txtTotalHrs.Text = ""

    End Sub

    Private Sub LoadGroupBox2FromGrid(ByRef UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow = UltraGrid.ActiveRow

        _iCurrentRow = ugRow.Cells("RowId").Text

        ClearGroupBox2()

        If ugRow Is Nothing Then Exit Sub
        If ugRow.ListObject Is Nothing Then Exit Sub

        ucboDeptNo.Text = ugRow.Cells("DeptNo").Text
        ucboDay.Text = ugRow.Cells("Day").Text
        txtDayNo.Text = ugRow.Cells("DayNo").Text
        txtTimeIn.Text = Format(CSng(ugRow.Cells("TimeIn").Text), "00.00")
        txtTimeOut.Text = Format(CSng(ugRow.Cells("TimeOut").Text), "00.00")
        txtBreakTime.Text = Format(CSng(ugRow.Cells("BreakTime").Text), "0.00")
        CalculateTotalHours()

    End Sub

    Private Sub FillDayCombo()

        Dim cDataSet As New DataSet
        Dim cRow As DataRow
        Dim rowValues(1) As Object

        cDataSet.Tables.Add("Days")
        cDataSet.Tables("Days").Columns.Add("idDay", Type.GetType("System.Int32"))
        cDataSet.Tables("Days").Columns.Add("Day", Type.GetType("System.String"))

        rowValues(0) = 1
        rowValues(1) = "MON"
        cRow = cDataSet.Tables("Days").NewRow
        cRow.ItemArray = rowValues
        cDataSet.Tables("Days").Rows.Add(cRow)
        cRow.AcceptChanges()

        rowValues(0) = 2
        rowValues(1) = "TUE"
        cRow = cDataSet.Tables("Days").NewRow
        cRow.ItemArray = rowValues
        cDataSet.Tables("Days").Rows.Add(cRow)
        cRow.AcceptChanges()

        rowValues(0) = 3
        rowValues(1) = "WED"
        cRow = cDataSet.Tables("Days").NewRow
        cRow.ItemArray = rowValues
        cDataSet.Tables("Days").Rows.Add(cRow)
        cRow.AcceptChanges()

        rowValues(0) = 4
        rowValues(1) = "THU"
        cRow = cDataSet.Tables("Days").NewRow
        cRow.ItemArray = rowValues
        cDataSet.Tables("Days").Rows.Add(cRow)
        cRow.AcceptChanges()

        rowValues(0) = 5
        rowValues(1) = "FRI"
        cRow = cDataSet.Tables("Days").NewRow
        cRow.ItemArray = rowValues
        cDataSet.Tables("Days").Rows.Add(cRow)
        cRow.AcceptChanges()

        rowValues(0) = 6
        rowValues(1) = "SAT"
        cRow = cDataSet.Tables("Days").NewRow
        cRow.ItemArray = rowValues
        cDataSet.Tables("Days").Rows.Add(cRow)
        cRow.AcceptChanges()

        rowValues(0) = 7
        rowValues(1) = "SUN"
        cRow = cDataSet.Tables("Days").NewRow
        cRow.ItemArray = rowValues
        cDataSet.Tables("Days").Rows.Add(cRow)
        cRow.AcceptChanges()

        ucboDay.DataSource = cDataSet.Tables("Days")
        ucboDay.DisplayMember = cDataSet.Tables("Days").Columns("Day").ToString
        ucboDay.ValueMember = cDataSet.Tables("Days").Columns("Day").ToString
        ucboDay.DisplayLayout.Bands(0).HeaderVisible = False
        ucboDay.DisplayLayout.Bands(0).ColHeadersVisible = False
        ucboDay.DisplayLayout.Bands(0).Columns("idDay").Hidden = False
        ucboDay.AutoEdit = True
        ucboDay.DisplayLayout.Bands(0).Columns(0).Hidden = True

    End Sub

    Private Sub FillDeptNoCombo()

        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim strSQL As String

        strSQL = "select deptNo fldCode, deptNo fldName from " & HRTblPath & "departments where active = 1 order by deptNo"
        PopulateDataset2(dtAdapter, dtSet, strSQL)

        If dtSet.Tables(0).Rows.Count >= 1 Then
            ucboDeptNo.DataSource = dtSet.Tables(0)
            ucboDeptNo.ValueMember = dtSet.Tables(0).Columns("fldCode").ToString
            ucboDeptNo.DisplayMember = dtSet.Tables(0).Columns("fldName").ToString
            ucboDeptNo.DisplayLayout.Bands(0).HeaderVisible = False
            ucboDeptNo.DisplayLayout.Bands(0).ColHeadersVisible = False
            ucboDeptNo.DisplayLayout.Bands(0).Columns("fldCode").Hidden = False
            ucboDeptNo.AutoEdit = True
            ucboDeptNo.DisplayLayout.Bands(0).Columns(0).Hidden = True
        End If

    End Sub

    Private Sub SetError(ByRef ctl As Control, ByVal e As System.ComponentModel.CancelEventArgs, ByVal str As String)
        Beep()
        e.Cancel = True
        Me.ErrorProvider1.SetError(ctl, str)
    End Sub

    Private Sub ClearError(ByRef ctl As Control)
        Me.ErrorProvider1.SetError(ctl, "")
    End Sub

    Private Sub CriticalMessage(ByVal p_msg As String, ByVal p_title As String, Optional ByRef p_ctrl As Object = Nothing)
        Beep()
        MsgBox(p_msg, MsgBoxStyle.Critical, p_title)
        If Not IsNothing(p_ctrl) Then p_ctrl.Focus()
    End Sub

#End Region

#Region "Data Access Functions"

    Private Sub LoadData(Optional ByVal IDValue As String = "", Optional ByVal Direction As String = "C")

        ClearGroupBox2()

        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView
        Dim dtSet2 As New DataSet
        Dim dtSet3 As DataSet
        Dim TempQuery As String
        Dim CritTmp As String

        If Val(IDValue) > 0 Then
            CritTmp = EmplCriteria.Replace("@EmplID", IDValue)
        Else
            CritTmp = ""
        End If

        Select Case Direction.ToUpper
            Case "N"
                If CritTmp = "" Then
                    CritTmp = EmplCriteria.Replace("@EmplID", "0")
                End If
                CritTmp = CritTmp.Replace("=", ">")
            Case "C"
            Case "P"
                If CritTmp = "" Then
                    CritTmp = EmplCriteria.Replace("@EmplID", "999999999")
                End If
                CritTmp = CritTmp.Replace("=", "<")
        End Select


        TempQuery = PrepSelectQuery(_strEmployees_Select, CritTmp)

        PopulateDataset2(dtAdapter, dtSet2, TempQuery)
        If dtSet2 Is Nothing Then Exit Sub
        If dtSet2.Tables Is Nothing Then Exit Sub
        If dtSet2.Tables(0) Is Nothing Then Exit Sub

        If dtSet2.Tables(0).Rows.Count = 0 Then
            If Direction.ToUpper = "C" Then
                Dim TmpEmplID As String
                TmpEmplID = EmplID.Text
                EmplID.Text = ""
                MessageBox.Show("No Records found.")
            Else
                MessageBox.Show("No Records found.")
            End If
        Else
            EmplID.Text = "" ' Clears the form
            dvAcct.Table = dtSet2.Tables(0)
            If Direction.ToUpper = "N" Then
                dvAcct.RowFilter = "ID = Min(ID)"
            ElseIf Direction.ToUpper = "P" Then
                dvAcct.RowFilter = "ID = Max(ID)"
            End If
            FormLoad(Me, dvAcct)
        End If

        dtSet2 = Nothing

    End Sub

    Private Sub PopulateGrid(ByVal p_iEmpId)

        '        Dim dtSet As New DataSet
        _dsGridData = Nothing
        _strGridSQL = ""

        'Dim HidCols() As String = {"RowID", "EmployeeId", "DayNum"}
        Dim HidCols() As String = {"RowID", "EmployeeId", "DayNo"}
        Dim i As Integer
        Dim strSQL As String
        'Dim SummCol As String

        'strSQL = _strEmployeeSchedule_Select & "WHERE employeeId = '" & EmplID.Text & "'" & _strEmployeeSchedule_Sort
        strSQL = _strEmployeeSchedule_Select & _strEmployeeSchedule_Where.Replace("@@EmplId", p_iEmpId) & _strEmployeeSchedule_Sort
        'strSQL = _strEmployeeSchedule_Select.Replace("@@EmplId", p_iEmpId) & _strEmployeeSchedule_Sort
        If FetchEmployeeSchedule(_dsGridData, strSQL) Then

            _strGridSQL = strSQL

            For i = 0 To _dsGridData.Tables(0).Columns.Count - 1
                _dsGridData.Tables(0).Columns(i).ReadOnly = True
            Next

            FillUltraGrid(UltraGrid1, _dsGridData, -1, HidCols, 0)

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
            UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        End If

    End Sub

    Private Function FetchEmployeeSchedule(ByRef p_dtSet As DataSet, Optional ByVal p_strCondition As String = "") As Boolean

        Dim dtAdapter As SqlDataAdapter

        PopulateDataset2(dtAdapter, p_dtSet, p_strCondition)
        If p_dtSet Is Nothing Then Return False
        If p_dtSet.Tables Is Nothing Then Return False
        If p_dtSet.Tables(0) Is Nothing Then Return False

        Return True

    End Function

#End Region

#Region "Validation Functions"

    Private Sub EmplID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EmplID.Validating
        If EmplID.Text = "" Then
            LoadData("", "N")
        Else
            LoadData(EmplID.Text, "C")
            If EmplID.Text = "" Then
                EmplID.Focus()
                Exit Sub
            End If
        End If
        PopulateGrid(CInt(EmplID.Text))
    End Sub

    Private Function ValidateTimeRange() As Boolean

        If txtTimeIn.Text = "" Then txtTimeIn.Text = 0.0
        If txtTimeOut.Text = "" Then txtTimeOut.Text = 0.0

        Dim dsDataRow As DataRow
        Dim dsDataRows As DataRow()
        Dim iCurrentRow As Integer
        Dim iCount As Integer = 0
        Dim fTimeIn, fTimeOut, fNewTimeIn, fNewTimeOut, fTimeOut24 As Single

        dsDataRows = _dsGridData.Tables(0).Select("day like '" & ucboDay.Text & "'")
        fNewTimeIn = CSng(txtTimeIn.Text)
        fNewTimeOut = CSng(txtTimeOut.Text)

        'Make Sure TimeIn does not equal TimeOut
        If fNewTimeIn = fNewTimeOut Then
            CriticalMessage("TimeIn & TimeOut Cannot be Equal", "Input Error", txtTimeOut)
            Return False
        End If

        For Each dsDataRow In dsDataRows
            iCurrentRow = CInt(dsDataRow.Item("rowid"))
            iCount += 1
            If (iCurrentRow <> _iCurrentRow) Or (_strInputMode = "NEW") Then

                fTimeIn = CSng(dsDataRow.Item("timein"))
                fTimeOut = CSng(dsDataRow.Item("timeout"))
                If fTimeOut < fTimeIn Then
                    fTimeOut24 += 24
                Else
                    fTimeOut24 = fTimeOut
                End If

                If (fNewTimeIn = fTimeIn) Then
                    CriticalMessage("Invalid Time In", "Input Error", txtTimeIn)
                    Return False
                End If

                If (fNewTimeIn = fTimeIn) And (fNewTimeOut = fTimeOut) Then
                    CriticalMessage("Duplicate Time Period", "Input Error", txtTimeIn)
                    Return False
                End If

                If (fNewTimeIn > fTimeIn) And (fNewTimeIn < fTimeOut) Then
                    CriticalMessage("Invalid Time In", "Input Error", txtTimeIn)
                    Return False
                End If
                If (fNewTimeIn > fTimeIn) And (fNewTimeIn < fTimeOut24) Then
                    CriticalMessage("Invalid Time In", "Input Error", txtTimeIn)
                    Return False
                End If

                If (fNewTimeOut > fTimeIn) And (fNewTimeOut < fTimeOut) And (fNewTimeOut > fNewTimeIn) Then
                    CriticalMessage("Invalid Time Out", "Input Error", txtTimeOut)
                    Return False
                End If
                If (fNewTimeOut > fTimeIn) And (fNewTimeOut < fTimeOut24) And (fNewTimeOut > fNewTimeIn) Then
                    CriticalMessage("Invalid Time Out", "Input Error", txtTimeOut)
                    Return False
                End If

                If (fNewTimeIn < fTimeIn) And (fNewTimeOut >= fTimeOut) And (fTimeOut > fTimeIn) Then
                    CriticalMessage("Invalid Time Out", "Input Error", txtTimeOut)
                    Return False
                End If
                If (fNewTimeIn < fTimeIn) And (fNewTimeOut >= fTimeOut24) And (fTimeOut > fTimeIn) Then
                    CriticalMessage("Invalid Time Out", "Input Error", txtTimeOut)
                    Return False
                End If

                If (fNewTimeOut < fNewTimeIn) Then 'Midnight Rollover. Must Check Next Day & Current TimeIn

                    Dim fNewTimeOut24 As Single = (fNewTimeOut + 24)
                    Dim fTotalHours As Single = (fNewTimeOut24 - fNewTimeIn)
                    Dim fNextDayTimeIn As Single

                    ''Determine Next Day
                    Dim dsNextDayDataRow As DataRow
                    Dim dsNextDayDataRows As DataRow()
                    Select Case CInt(txtDayNo.Text)
                        Case 1
                            dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'TUE'")
                        Case 2
                            dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'WED'")
                        Case 3
                            dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'THU'")
                        Case 4
                            dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'FRI'")
                        Case 5
                            dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'SAT'")
                        Case 6
                            dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'SUN'")
                        Case 7
                            dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'MON'")
                    End Select
                    For Each dsNextDayDataRow In dsNextDayDataRows
                        fNextDayTimeIn = CSng(dsNextDayDataRow.Item("timein")) + 24.0
                        If (fNewTimeIn + fTotalHours) > fNextDayTimeIn Then
                            CriticalMessage("Overlapping Time Frame", "Input Error", txtTimeOut)
                            Return False
                        End If
                    Next

                    If (fNewTimeOut24 > fTimeIn) And (fNewTimeOut24 < fTimeOut) Then
                        CriticalMessage("Invalid Time Out", "Input Error", txtTimeOut)
                        Return False
                    End If
                    If (fNewTimeOut24 > fTimeIn) And (fNewTimeOut24 < fTimeOut24) Then
                        CriticalMessage("Invalid Time Out", "Input Error", txtTimeOut)
                        Return False
                    End If

                    If (fNewTimeIn < fTimeIn) And (fNewTimeOut24 >= fTimeOut) Then
                        CriticalMessage("Invalid Time Out", "Input Error", txtTimeOut)
                        Return False
                    End If
                    If (fNewTimeIn < fTimeIn) And (fNewTimeOut24 >= fTimeOut24) Then
                        CriticalMessage("Invalid Time Out", "Input Error", txtTimeOut)
                        Return False
                    End If

                End If
            End If
        Next

        'Check for NextDay Overlap if New Day to Schedule
        If (fNewTimeOut < fNewTimeIn) Then  'Ali- 08-10-2006: Taken out of the IF condition clause: "Or (iCount = 0)"
            ' Ali - 08-10-2006- Cont.-- Situation : Employee working all six days and on Sunday 13.00 to 20.75 is wrongully reported conflicting with MON and same time frame.
            Dim fNewTimeOut24 As Single = (fNewTimeOut + 24)
            Dim fTotalHours As Single = (fNewTimeOut24 - fNewTimeIn)
            Dim fNextDayTimeIn As Single
            'Determine Next Day
            Dim dsNextDayDataRow As DataRow
            Dim dsNextDayDataRows As DataRow()
            Select Case CInt(txtDayNo.Text)
                Case 1
                    dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'TUE'")
                Case 2
                    dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'WED'")
                Case 3
                    dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'THU'")
                Case 4
                    dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'FRI'")
                Case 5
                    dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'SAT'")
                Case 6
                    dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'SUN'")
                Case 7
                    dsNextDayDataRows = _dsGridData.Tables(0).Select("day like 'MON'")
            End Select
            'Nest Loop for Next Day
            For Each dsNextDayDataRow In dsNextDayDataRows
                fNextDayTimeIn = CSng(dsNextDayDataRow.Item("timein")) + 24.0
                If (fNewTimeIn + fTotalHours) > fNextDayTimeIn Then
                    CriticalMessage("Overlapping Time Frame", "Input Error", txtTimeOut)
                    Return False
                End If
            Next
        End If

        'Test against previous day that might have rolled-over into current day
        Dim dsPrevDayDataRow As DataRow
        Dim dsPrevDayDataRows As DataRow()
        Select Case CInt(txtDayNo.Text)
            Case 1
                dsPrevDayDataRows = _dsGridData.Tables(0).Select("day like 'SUN'")
            Case 2
                dsPrevDayDataRows = _dsGridData.Tables(0).Select("day like 'MON'")
            Case 3
                dsPrevDayDataRows = _dsGridData.Tables(0).Select("day like 'TUE'")
            Case 4
                dsPrevDayDataRows = _dsGridData.Tables(0).Select("day like 'WED'")
            Case 5
                dsPrevDayDataRows = _dsGridData.Tables(0).Select("day like 'THU'")
            Case 6
                dsPrevDayDataRows = _dsGridData.Tables(0).Select("day like 'FRI'")
            Case 7
                dsPrevDayDataRows = _dsGridData.Tables(0).Select("day like 'SAT'")
        End Select
        For Each dsPrevDayDataRow In dsPrevDayDataRows
            Dim fPrevDayTimeIn, fPrevDayTimeOut As Single
            fPrevDayTimeIn = CSng(dsPrevDayDataRow.Item("timein"))
            fPrevDayTimeOut = CSng(dsPrevDayDataRow.Item("timeout"))
            If fPrevDayTimeOut < fPrevDayTimeIn Then
                If fNewTimeIn < fPrevDayTimeOut Then
                    CriticalMessage("Overlapping Time Frame", "Input Error", txtTimeIn)
                    Return False
                End If
            End If
        Next

        Return True

    End Function

    Private Function ValidateDeptNo() As Boolean

        Dim dataRow As DataRow
        Dim dataRows As DataRow()
        Dim iCount As Integer = 0
        Dim bReturn As Boolean

        dataRows = ucboDeptNo.DataSource.Select("fldName = '" & ucboDeptNo.Text & "'")

        For Each dataRow In dataRows
            iCount += 1
        Next

        bReturn = IIf(iCount > 0, True, False)
        If bReturn = False Then
            CriticalMessage("Invalid Department Number", "Input Error", ucboDeptNo)
        End If

        Return bReturn

    End Function

    Private Function ValidateDay() As Boolean

        Dim dataRow As DataRow
        Dim dataRows As DataRow()
        Dim iCount As Integer = 0
        Dim bReturn As Boolean

        dataRows = ucboDay.DataSource.Select("day = '" & ucboDay.Text & "'")

        For Each dataRow In dataRows
            iCount += 1
            txtDayNo.Text = dataRow.Item("idDay").ToString
        Next

        bReturn = IIf(iCount > 0, True, False)
        If bReturn = False Then
            CriticalMessage("Invalid Day", "Input Error", ucboDay)
        End If

        Return bReturn

    End Function

    Private Function ValidateBreakTime() As Boolean

        If txtBreakTime.Text = "" Then txtBreakTime.Text = 0.0

        Dim fBreakTime As Single
        Dim fTimeIn As Single = CSng(txtTimeIn.Text)
        Dim fTimeOut As Single = CSng(txtTimeOut.Text)
        Dim fTimeRange As Single

        If fTimeOut < fTimeIn Then fTimeOut += 24.0
        fTimeRange = fTimeOut - fTimeIn

        fBreakTime = CSng(txtBreakTime.Text)
        If fBreakTime < 0.0 Or fBreakTime > 24.0 Then
            CriticalMessage("Break Length Must be Between 0 and 24", "Input Error", txtBreakTime)
            Return False
        End If

        If fTimeRange - fBreakTime <= 0 Then
            CriticalMessage("Break Time Exceeds Work Time", "Input Error", txtBreakTime)
            Return False
        End If

        Return True

    End Function

    Private Function ValidateGroupBox2() As Boolean

        Dim bReturn As Boolean = True

        bReturn = ValidateDeptNo()
        If bReturn = False Then Return bReturn

        bReturn = ValidateDay()
        If bReturn = False Then Return bReturn

        bReturn = ValidateTimeRange()
        If bReturn = False Then Return bReturn

        bReturn = ValidateBreakTime()
        If bReturn = False Then Return bReturn

        Return bReturn

    End Function

    Private Function ValidEmployeeID() As Boolean
        If EmplID.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub txtTimeIn_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeIn.Enter
        If ErrorProvider1.GetError(txtTimeIn).ToString <> "" Then
            txtTimeIn.SelectAll()
        End If
    End Sub

    Private Sub txtTimeIn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTimeIn.Validating
        If (_cValidate.Range(txtTimeIn, 0, 23.99) = False) Then
            SetError(txtTimeIn, e, "Must be between 00.00 and 23.99")
        End If
    End Sub

    Private Sub txtTimeIn_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeIn.Validated
        ClearError(txtTimeIn)
        CalculateTotalHours()
        'ValidateTimeRange()
    End Sub

    Private Sub txtTimeOut_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeOut.Enter
        If ErrorProvider1.GetError(txtTimeOut).ToString <> "" Then
            txtTimeOut.SelectAll()
        End If
    End Sub

    Private Sub txtTimeOut_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTimeOut.Validating
        If (_cValidate.Range(txtTimeOut, 0, 23.99) = False) Then
            SetError(txtTimeOut, e, "Must be between 00.00 and 23.99")
        End If
    End Sub

    Private Sub txtTimeOut_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeOut.Validated
        ClearError(txtTimeOut)
        CalculateTotalHours()
        'ValidateTimeRange()
    End Sub

    Private Sub txtBreakTime_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBreakTime.Enter
        If ErrorProvider1.GetError(txtBreakTime).ToString <> "" Then
            txtBreakTime.SelectAll()
        End If
    End Sub

    Private Sub txtBreakTime_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBreakTime.Validating
        If (_cValidate.Range(txtBreakTime, 0, 23.99) = False) Then
            SetError(txtBreakTime, e, "Must be between 00.00 and 23.99")
        End If
    End Sub

    Private Sub txtBreakTime_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBreakTime.Validated
        ClearError(txtBreakTime)
        CalculateTotalHours()
    End Sub

    Private Sub CalculateTotalHours()

        Dim sTimeIn As Single = 0
        Dim sTimeOut As Single = 0
        Dim sBreakHrs As Single = 0
        Dim sTotalHrs As Single = 0

        If txtTimeIn.Text <> "" Then sTimeIn = CSng(txtTimeIn.Text)
        If txtTimeOut.Text <> "" Then sTimeOut = CSng(txtTimeOut.Text)
        If txtBreakTime.Text <> "" Then sBreakHrs = CSng(txtBreakTime.Text)

        If (sTimeOut < sTimeIn) And (txtTimeOut.Text <> "") Then sTimeOut += 24

        sTotalHrs = (sTimeOut - sTimeIn) - sBreakHrs
        txtTotalHrs.Text = Format(sTotalHrs, "0.00")

    End Sub

#End Region

#Region "UltraGrid Events"

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        LoadGroupBox2FromGrid(sender)
    End Sub

#End Region

    Private Sub UltraGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.Click
        If _firstClick = True Then
            _firstClick = False
        End If
    End Sub
End Class
