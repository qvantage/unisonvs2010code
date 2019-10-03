Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Math
Imports System.Drawing.Graphics

Public Class MileageInput
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
        MessageBox.Show(CStr("cboVehicle" & " = " & cboVehicle.TabIndex))
        'MessageBox.Show(CStr("txtCheckOutDate" & " = " & txtCheckOutDate.TabIndex))
        MessageBox.Show(CStr("lblDateWorked" & " = " & lblDateWorked.TabIndex))
        MessageBox.Show(CStr("lblEmpId" & " = " & lblEmpId.TabIndex))
        MessageBox.Show(CStr("lblName" & " = " & lblName.TabIndex))
        MessageBox.Show(CStr("lblTimeIn" & " = " & lblTimeIn.TabIndex))
        MessageBox.Show(CStr("lblTimeOut" & " = " & lblTimeOut.TabIndex))
        'MessageBox.Show(CStr("lblBreakTime" & " = " & lblBreakTime.TabIndex))
        MessageBox.Show(CStr("ulblTotalHrs" & " = " & ulblTotalHrs.TabIndex))
        MessageBox.Show(CStr("lblEmpName" & " = " & lblEmpName.TabIndex))
        MessageBox.Show(CStr("lblTotalMileage" & " = " & utTotalMileage.TabIndex))
        MessageBox.Show(CStr("ulblDivision" & " = " & ulblDivision.TabIndex))
        MessageBox.Show(CStr("lblDivision" & " = " & lblDivision.TabIndex))
        MessageBox.Show(CStr("ulblWeekEnding" & " = " & ulblWeekEnding.TabIndex))
        MessageBox.Show(CStr("lblWeekEnding" & " = " & lblPayrollEnding.TabIndex))
        MessageBox.Show(CStr("ulblDeptNo" & " = " & ulblDeptNo.TabIndex))
        'MessageBox.Show(CStr("ucboDeptNo" & " = " & ucboDeptNo.TabIndex))
        MessageBox.Show(CStr("UltraGrid1" & " = " & UltraGrid1.TabIndex))
        MessageBox.Show(CStr("dpWorked" & " = " & dpWorked.TabIndex))
        MessageBox.Show(CStr("cboEmpId" & " = " & cboEmpId.TabIndex))
        MessageBox.Show(CStr("txtTimeIn" & " = " & txtMileageIn.TabIndex))
        MessageBox.Show(CStr("txtTimeOut" & " = " & txtMileageOut.TabIndex))
        MessageBox.Show(CStr("utRoute" & " = " & utRoute.TabIndex))
        MessageBox.Show(CStr("btnSave" & " = " & btnSave.TabIndex))
        MessageBox.Show(CStr("btnExit" & " = " & btnExit.TabIndex))
        MessageBox.Show(CStr("btnEdit" & " = " & btnEdit.TabIndex))

    End Sub
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
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents utGross As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDivision As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblPayrollEnding As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ulblDivision As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ulblWeekEnding As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtWeekEnding As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDateWorked As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblEmpName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboEmpId As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents dpWorked As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblEmpId As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ulblDeptNo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ulblTotalHrs As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTimeOut As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTimeIn As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents utRowID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtOfficeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtOffice As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnExit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnEdit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents utUserID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtMileageIn As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtMileageOut As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utUserName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboVehicle As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents utTotalMileage As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utRoute As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dpLastUpdate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents utProcessed As Infragistics.Win.UltraWinEditors.UltraTextEditor
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
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.utProcessed = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.dpLastUpdate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblDivision = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lblPayrollEnding = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.ulblDivision = New Infragistics.Win.Misc.UltraLabel
        Me.ulblWeekEnding = New Infragistics.Win.Misc.UltraLabel
        Me.txtWeekEnding = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboVehicle = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.lblEmpName = New Infragistics.Win.Misc.UltraLabel
        Me.lblName = New Infragistics.Win.Misc.UltraLabel
        Me.cboEmpId = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.lblEmpId = New Infragistics.Win.Misc.UltraLabel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.utUserName = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.utRoute = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utTotalMileage = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ulblDeptNo = New Infragistics.Win.Misc.UltraLabel
        Me.ulblTotalHrs = New Infragistics.Win.Misc.UltraLabel
        Me.lblTimeOut = New Infragistics.Win.Misc.UltraLabel
        Me.lblTimeIn = New Infragistics.Win.Misc.UltraLabel
        Me.txtMileageIn = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtMileageOut = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utRowID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtOfficeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtOffice = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utUserID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.dpWorked = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.lblDateWorked = New Infragistics.Win.Misc.UltraLabel
        Me.utGross = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnSave = New Infragistics.Win.Misc.UltraButton
        Me.btnExit = New Infragistics.Win.Misc.UltraButton
        Me.btnEdit = New Infragistics.Win.Misc.UltraButton
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Panel1.SuspendLayout()
        CType(Me.utProcessed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dpLastUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.lblDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPayrollEnding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeekEnding, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cboVehicle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEmpId, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.utRoute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTotalMileage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMileageIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMileageOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utUserID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dpWorked, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utGross, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.utProcessed)
        Me.Panel1.Controls.Add(Me.dpLastUpdate)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.utGross)
        Me.Panel1.Controls.Add(Me.UltraLabel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(312, 525)
        Me.Panel1.TabIndex = 4
        '
        'utProcessed
        '
        Me.utProcessed.Location = New System.Drawing.Point(128, 448)
        Me.utProcessed.Name = "utProcessed"
        Me.utProcessed.Size = New System.Drawing.Size(24, 21)
        Me.utProcessed.TabIndex = 37
        Me.utProcessed.TabStop = False
        Me.utProcessed.Tag = ".Processed"
        Me.utProcessed.Visible = False
        '
        'dpLastUpdate
        '
        Me.dpLastUpdate.DateTime = New Date(2006, 3, 31, 0, 0, 0, 0)
        Me.dpLastUpdate.Location = New System.Drawing.Point(32, 448)
        Me.dpLastUpdate.Name = "dpLastUpdate"
        Me.dpLastUpdate.Size = New System.Drawing.Size(88, 21)
        Me.dpLastUpdate.TabIndex = 36
        Me.dpLastUpdate.Tag = ".LastUpdate"
        Me.dpLastUpdate.Value = New Date(2006, 3, 31, 0, 0, 0, 0)
        Me.dpLastUpdate.Visible = False
        '
        'GroupBox1
        '
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
        'lblDivision
        '
        Appearance1.FontData.Name = "Arial Black"
        Appearance1.FontData.SizeInPoints = 9.75!
        Appearance1.ForeColor = System.Drawing.Color.Blue
        Appearance1.ForeColorDisabled = System.Drawing.Color.Blue
        Me.lblDivision.Appearance = Appearance1
        Me.lblDivision.Enabled = False
        Me.lblDivision.Location = New System.Drawing.Point(116, 19)
        Me.lblDivision.Multiline = True
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(100, 21)
        Me.lblDivision.TabIndex = 0
        Me.lblDivision.TabStop = False
        Me.lblDivision.Tag = ".Division"
        '
        'lblPayrollEnding
        '
        Appearance2.FontData.Name = "Arial Black"
        Appearance2.FontData.SizeInPoints = 9.75!
        Appearance2.ForeColor = System.Drawing.Color.Blue
        Appearance2.ForeColorDisabled = System.Drawing.Color.Blue
        Me.lblPayrollEnding.Appearance = Appearance2
        Me.lblPayrollEnding.Enabled = False
        Me.lblPayrollEnding.Location = New System.Drawing.Point(116, 44)
        Me.lblPayrollEnding.Multiline = True
        Me.lblPayrollEnding.Name = "lblPayrollEnding"
        Me.lblPayrollEnding.Size = New System.Drawing.Size(100, 21)
        Me.lblPayrollEnding.TabIndex = 1
        Me.lblPayrollEnding.TabStop = False
        Me.lblPayrollEnding.Tag = ".PayrollEnding"
        '
        'UltraLabel1
        '
        Appearance3.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance3.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel1.Appearance = Appearance3
        Me.UltraLabel1.Location = New System.Drawing.Point(16, 44)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(88, 16)
        Me.UltraLabel1.TabIndex = 34
        Me.UltraLabel1.Text = "Payroll Ending:"
        '
        'ulblDivision
        '
        Appearance4.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance4.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblDivision.Appearance = Appearance4
        Me.ulblDivision.Location = New System.Drawing.Point(16, 19)
        Me.ulblDivision.Name = "ulblDivision"
        Me.ulblDivision.Size = New System.Drawing.Size(88, 16)
        Me.ulblDivision.TabIndex = 31
        Me.ulblDivision.Text = "Division:"
        '
        'ulblWeekEnding
        '
        Appearance5.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance5.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblWeekEnding.Appearance = Appearance5
        Me.ulblWeekEnding.Location = New System.Drawing.Point(16, 69)
        Me.ulblWeekEnding.Name = "ulblWeekEnding"
        Me.ulblWeekEnding.Size = New System.Drawing.Size(88, 16)
        Me.ulblWeekEnding.TabIndex = 30
        Me.ulblWeekEnding.Text = "Week Ending:"
        Me.ulblWeekEnding.Visible = False
        '
        'txtWeekEnding
        '
        Appearance6.FontData.Name = "Arial Black"
        Appearance6.FontData.SizeInPoints = 9.75!
        Appearance6.ForeColor = System.Drawing.Color.Blue
        Appearance6.ForeColorDisabled = System.Drawing.Color.Blue
        Me.txtWeekEnding.Appearance = Appearance6
        Me.txtWeekEnding.Enabled = False
        Me.txtWeekEnding.Location = New System.Drawing.Point(116, 69)
        Me.txtWeekEnding.Multiline = True
        Me.txtWeekEnding.Name = "txtWeekEnding"
        Me.txtWeekEnding.Size = New System.Drawing.Size(100, 21)
        Me.txtWeekEnding.TabIndex = 2
        Me.txtWeekEnding.TabStop = False
        Me.txtWeekEnding.Tag = ".WeekEnding"
        Me.txtWeekEnding.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboVehicle)
        Me.GroupBox2.Controls.Add(Me.UltraLabel2)
        Me.GroupBox2.Controls.Add(Me.lblEmpName)
        Me.GroupBox2.Controls.Add(Me.lblName)
        Me.GroupBox2.Controls.Add(Me.cboEmpId)
        Me.GroupBox2.Controls.Add(Me.lblEmpId)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 120)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 96)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'cboVehicle
        '
        Me.cboVehicle.DisplayMember = ""
        Me.cboVehicle.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboVehicle.Location = New System.Drawing.Point(116, 40)
        Me.cboVehicle.Name = "cboVehicle"
        Me.cboVehicle.Size = New System.Drawing.Size(118, 21)
        Me.cboVehicle.TabIndex = 2
        Me.cboVehicle.Tag = ".VehicleLicPlate...Vehicles.LicPlate.LicPlate"
        Me.cboVehicle.ValueMember = ""
        '
        'UltraLabel2
        '
        Appearance7.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance7.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel2.Appearance = Appearance7
        Me.UltraLabel2.Location = New System.Drawing.Point(40, 40)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(64, 16)
        Me.UltraLabel2.TabIndex = 13
        Me.UltraLabel2.Text = "Vehicle:"
        '
        'lblEmpName
        '
        Appearance8.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance8.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblEmpName.Appearance = Appearance8
        Me.lblEmpName.Location = New System.Drawing.Point(116, 64)
        Me.lblEmpName.Name = "lblEmpName"
        Me.lblEmpName.Size = New System.Drawing.Size(174, 21)
        Me.lblEmpName.TabIndex = 3
        '
        'lblName
        '
        Appearance9.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance9.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblName.Appearance = Appearance9
        Me.lblName.Location = New System.Drawing.Point(8, 64)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(96, 16)
        Me.lblName.TabIndex = 11
        Me.lblName.Text = "Employee Name:"
        '
        'cboEmpId
        '
        Me.cboEmpId.DisplayMember = ""
        Me.cboEmpId.Location = New System.Drawing.Point(116, 16)
        Me.cboEmpId.Name = "cboEmpId"
        Me.cboEmpId.Size = New System.Drawing.Size(118, 21)
        Me.cboEmpId.TabIndex = 1
        Me.cboEmpId.Tag = ".EmployeeId"
        Me.cboEmpId.ValueMember = ""
        '
        'lblEmpId
        '
        Appearance10.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance10.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblEmpId.Appearance = Appearance10
        Me.lblEmpId.Location = New System.Drawing.Point(24, 16)
        Me.lblEmpId.Name = "lblEmpId"
        Me.lblEmpId.Size = New System.Drawing.Size(80, 16)
        Me.lblEmpId.TabIndex = 10
        Me.lblEmpId.Text = "Employee ID:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.utUserName)
        Me.GroupBox3.Controls.Add(Me.UltraLabel6)
        Me.GroupBox3.Controls.Add(Me.utRoute)
        Me.GroupBox3.Controls.Add(Me.utTotalMileage)
        Me.GroupBox3.Controls.Add(Me.ulblDeptNo)
        Me.GroupBox3.Controls.Add(Me.ulblTotalHrs)
        Me.GroupBox3.Controls.Add(Me.lblTimeOut)
        Me.GroupBox3.Controls.Add(Me.lblTimeIn)
        Me.GroupBox3.Controls.Add(Me.txtMileageIn)
        Me.GroupBox3.Controls.Add(Me.txtMileageOut)
        Me.GroupBox3.Controls.Add(Me.utRowID)
        Me.GroupBox3.Controls.Add(Me.txtOfficeID)
        Me.GroupBox3.Controls.Add(Me.txtOffice)
        Me.GroupBox3.Controls.Add(Me.utUserID)
        Me.GroupBox3.Controls.Add(Me.dpWorked)
        Me.GroupBox3.Controls.Add(Me.lblDateWorked)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 240)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(296, 176)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'utUserName
        '
        Appearance11.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance11.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.utUserName.Appearance = Appearance11
        Me.utUserName.Location = New System.Drawing.Point(108, 150)
        Me.utUserName.Name = "utUserName"
        Me.utUserName.Size = New System.Drawing.Size(174, 21)
        Me.utUserName.TabIndex = 37
        Me.utUserName.Tag = ""
        '
        'UltraLabel6
        '
        Appearance12.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance12.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel6.Appearance = Appearance12
        Me.UltraLabel6.Location = New System.Drawing.Point(52, 153)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(52, 16)
        Me.UltraLabel6.TabIndex = 30
        Me.UltraLabel6.Text = "Operator:"
        '
        'utRoute
        '
        Me.utRoute.Location = New System.Drawing.Point(116, 15)
        Me.utRoute.Name = "utRoute"
        Me.utRoute.Size = New System.Drawing.Size(101, 21)
        Me.utRoute.TabIndex = 0
        Me.utRoute.Tag = ".Route"
        '
        'utTotalMileage
        '
        Appearance13.FontData.Name = "Arial Black"
        Appearance13.FontData.SizeInPoints = 9.75!
        Appearance13.ForeColor = System.Drawing.Color.Blue
        Appearance13.ForeColorDisabled = System.Drawing.Color.Blue
        Me.utTotalMileage.Appearance = Appearance13
        Me.utTotalMileage.Enabled = False
        Me.utTotalMileage.Location = New System.Drawing.Point(116, 123)
        Me.utTotalMileage.Multiline = True
        Me.utTotalMileage.Name = "utTotalMileage"
        Me.utTotalMileage.ReadOnly = True
        Me.utTotalMileage.Size = New System.Drawing.Size(100, 21)
        Me.utTotalMileage.TabIndex = 4
        Me.utTotalMileage.TabStop = False
        Me.utTotalMileage.Tag = ".TotalMileage"
        Me.utTotalMileage.Text = "0"
        '
        'ulblDeptNo
        '
        Appearance14.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance14.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblDeptNo.Appearance = Appearance14
        Me.ulblDeptNo.Location = New System.Drawing.Point(18, 15)
        Me.ulblDeptNo.Name = "ulblDeptNo"
        Me.ulblDeptNo.Size = New System.Drawing.Size(88, 16)
        Me.ulblDeptNo.TabIndex = 27
        Me.ulblDeptNo.Text = "Route:"
        '
        'ulblTotalHrs
        '
        Appearance15.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance15.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.ulblTotalHrs.Appearance = Appearance15
        Me.ulblTotalHrs.Location = New System.Drawing.Point(24, 122)
        Me.ulblTotalHrs.Name = "ulblTotalHrs"
        Me.ulblTotalHrs.Size = New System.Drawing.Size(80, 16)
        Me.ulblTotalHrs.TabIndex = 13
        Me.ulblTotalHrs.Text = "Total Mileage:"
        '
        'lblTimeOut
        '
        Appearance16.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance16.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblTimeOut.Appearance = Appearance16
        Me.lblTimeOut.Location = New System.Drawing.Point(35, 97)
        Me.lblTimeOut.Name = "lblTimeOut"
        Me.lblTimeOut.Size = New System.Drawing.Size(69, 16)
        Me.lblTimeOut.TabIndex = 9
        Me.lblTimeOut.Text = "Mileage Out:"
        '
        'lblTimeIn
        '
        Appearance17.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance17.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblTimeIn.Appearance = Appearance17
        Me.lblTimeIn.Location = New System.Drawing.Point(43, 72)
        Me.lblTimeIn.Name = "lblTimeIn"
        Me.lblTimeIn.Size = New System.Drawing.Size(61, 16)
        Me.lblTimeIn.TabIndex = 8
        Me.lblTimeIn.Text = "Mileage In:"
        '
        'txtMileageIn
        '
        Me.txtMileageIn.Location = New System.Drawing.Point(116, 69)
        Me.txtMileageIn.Name = "txtMileageIn"
        Me.txtMileageIn.Size = New System.Drawing.Size(100, 21)
        Me.txtMileageIn.TabIndex = 2
        Me.txtMileageIn.Tag = ".MileageIn"
        '
        'txtMileageOut
        '
        Me.txtMileageOut.Location = New System.Drawing.Point(116, 96)
        Me.txtMileageOut.Name = "txtMileageOut"
        Me.txtMileageOut.Size = New System.Drawing.Size(100, 21)
        Me.txtMileageOut.TabIndex = 3
        Me.txtMileageOut.Tag = ".MileageOut"
        '
        'utRowID
        '
        Me.utRowID.Location = New System.Drawing.Point(230, 11)
        Me.utRowID.Name = "utRowID"
        Me.utRowID.Size = New System.Drawing.Size(64, 21)
        Me.utRowID.TabIndex = 7
        Me.utRowID.Tag = ".RowID.view"
        Me.utRowID.Text = "RowID - Hidden"
        Me.utRowID.Visible = False
        '
        'txtOfficeID
        '
        Me.txtOfficeID.Location = New System.Drawing.Point(228, 96)
        Me.txtOfficeID.Name = "txtOfficeID"
        Me.txtOfficeID.Size = New System.Drawing.Size(64, 21)
        Me.txtOfficeID.TabIndex = 4
        Me.txtOfficeID.Tag = ".OfficeID"
        Me.txtOfficeID.Text = "OfficeID - Hidden"
        Me.txtOfficeID.Visible = False
        '
        'txtOffice
        '
        Me.txtOffice.Location = New System.Drawing.Point(229, 123)
        Me.txtOffice.Name = "txtOffice"
        Me.txtOffice.Size = New System.Drawing.Size(64, 21)
        Me.txtOffice.TabIndex = 6
        Me.txtOffice.Tag = ".Office"
        Me.txtOffice.Text = "Office - Hidden"
        Me.txtOffice.Visible = False
        '
        'utUserID
        '
        Me.utUserID.Location = New System.Drawing.Point(16, 147)
        Me.utUserID.Name = "utUserID"
        Me.utUserID.Size = New System.Drawing.Size(24, 21)
        Me.utUserID.TabIndex = 36
        Me.utUserID.TabStop = False
        Me.utUserID.Tag = ".UserID"
        Me.utUserID.Visible = False
        '
        'dpWorked
        '
        Me.dpWorked.DateTime = New Date(2006, 3, 31, 0, 0, 0, 0)
        Me.dpWorked.Location = New System.Drawing.Point(116, 42)
        Me.dpWorked.Name = "dpWorked"
        Me.dpWorked.Size = New System.Drawing.Size(118, 21)
        Me.dpWorked.TabIndex = 1
        Me.dpWorked.Tag = ".CheckInDate"
        Me.dpWorked.Value = New Date(2006, 3, 31, 0, 0, 0, 0)
        '
        'lblDateWorked
        '
        Appearance18.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance18.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.lblDateWorked.Appearance = Appearance18
        Me.lblDateWorked.Location = New System.Drawing.Point(26, 47)
        Me.lblDateWorked.Name = "lblDateWorked"
        Me.lblDateWorked.Size = New System.Drawing.Size(80, 16)
        Me.lblDateWorked.TabIndex = 7
        Me.lblDateWorked.Text = "Date Worked:"
        '
        'utGross
        '
        Appearance19.FontData.Name = "Arial Black"
        Appearance19.FontData.SizeInPoints = 9.75!
        Appearance19.ForeColor = System.Drawing.Color.Blue
        Appearance19.ForeColorDisabled = System.Drawing.Color.Blue
        Me.utGross.Appearance = Appearance19
        Me.utGross.Enabled = False
        Me.utGross.Location = New System.Drawing.Point(116, 424)
        Me.utGross.Multiline = True
        Me.utGross.Name = "utGross"
        Me.utGross.ReadOnly = True
        Me.utGross.Size = New System.Drawing.Size(100, 21)
        Me.utGross.TabIndex = 35
        Me.utGross.TabStop = False
        Me.utGross.Tag = ""
        '
        'UltraLabel5
        '
        Appearance20.TextHAlign = Infragistics.Win.HAlign.Center
        Appearance20.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel5.Appearance = Appearance20
        Me.UltraLabel5.Location = New System.Drawing.Point(48, 424)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(72, 16)
        Me.UltraLabel5.TabIndex = 34
        Me.UltraLabel5.Text = "Week Total:"
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
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
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
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(714, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 22)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "E&xit"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(496, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 22)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UltraGrid1
        '
        Me.UltraGrid1.CausesValidation = False
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(312, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(480, 525)
        Me.UltraGrid1.TabIndex = 6
        Me.UltraGrid1.TabStop = False
        Me.UltraGrid1.Text = "Mileage Inputs for Current Employee For The Selected Payroll-Ending"
        '
        'MileageInput
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "MileageInput"
        Me.Tag = "MileageInput"
        Me.Panel1.ResumeLayout(False)
        CType(Me.utProcessed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dpLastUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.lblDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPayrollEnding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeekEnding, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.cboVehicle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEmpId, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.utRoute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTotalMileage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMileageIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMileageOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOfficeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utUserID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dpWorked, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utGross, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Common Events"

    Private Sub frmMileageEntryDE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        utUserID.Text = LoginInfo.UserID
        utUserName.Text = LoginInfo.UserName
        StandardFormPrep()

        ArrangeForm2()

        'initialize the appropriate controls and options according to the privileges of the user id
        _iCount = 1
        _iDateSection = 2
        _cValidate = New clsFieldValidator
        _bFillGrid = True

        'Initialize Default Values for Hidden DB Fields for the table EmployeeActivityDetail
        txtOfficeID.Text = "0"
        txtOfficeID.Visible = False
        txtOffice.Text = ""
        txtOffice.Visible = False
        'txtPayRate.Text = "0"
        'txtPayRate.Visible = False
        'txtWeekEnding.Visible = True

        'txtCheckOutDate.Visible = False

        AddHandler txtMileageIn.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler txtMileageOut.KeyPress, AddressOf Value_Dec_KeyPress
        'AddHandler txtBreakHrs.KeyPress, AddressOf Value_Dec_KeyPress
        'AddHandler utMiles.KeyPress, AddressOf Value_Int_KeyPress
        AddHandler cboEmpId.Leave, AddressOf UCbo_Leave
        AddHandler cboVehicle.Leave, AddressOf UCbo_Leave
        ' AddHandler ucboDeptNo.Leave, AddressOf UCbo_Leave


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
            'cboVehicle.DataSource = dtView
            cboEmpId.DisplayMember = dtView.Table.Columns("EmployeeID").ToString
            cboEmpId.ValueMember = dtView.Table.Columns("EmployeeID").ToString
            'cboVehicle.ValueMember = dtView.Table.Columns("Vehicle").ToString
        End If
        ' Modified By Ali -- END
        '=========================


        'Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        'ugRow = UltraGrid1.ActiveRow
        ''Dim strSQL = "Select epr.DeptNo, d.Department, epr.payrate from " & HRTblPath & "EmployeePayRates epr, " & HRTblPath & "Departments d where epr.employeeid = '" & ugrow.Cells("EmployeeID").Value & "' and epr.deptno = d.deptno order by epr.DeptNo"
        ' Dim strSQL = "Select LicPlate, Make, Model from " & HRTblPath & " VEHICLES where EmployeeID = '" & ugrow.Cells("EmployeeID").Value & "'"
        'FillUCombo(cboVehicle, "", "", strSQL, HRTblPath, True)


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
        dpLastUpdate.Value = Now.Date

    End Sub
    Private Sub InitializeInputBoxes(Optional ByVal ResetDeptNo As Boolean = True)
        'ucboDeptNo.DataSource = Nothing
        'If ResetDeptNo Then
        'ucboDeptNo.DataSource = Nothing
        'ucboDeptNo.Value = Nothing
        'ucboDeptNo.Text = ""
        'txtPayRate.Text = ""
        'End If
        txtMileageIn.Text = ""
        txtMileageOut.Text = ""
        'txtBreakHrs.Text = "0.00"
        utTotalMileage.Text = ""
        'txtCheckOutDate.Text = ""
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
        'Dim SQLSelect As String = "SELECT RowID, EmployeeID, Division, OfficeID, Office, TotalHrs, CheckInDate, TimeIn, CheckOutDate, TimeOut, BreakTime, DeptNo, PayRate, WeekEnding, PayrollEnding, LastUpdate, Processed" & _
        '           " FROM " & HRTblPath & "EmployeeActivityDetail WHERE EmployeeId = " & cboEmpId.Value & " AND RowID = " & ugRow.Cells("rowid").Value
        'Dim SQLSelect As String = "SELECT rowid, employeeid, division, officeid, office, vehiclelicplate, route, checkindate, mileagein, checkoutdate, mileageout, totalmileage, weekending, payrollending" & _
        '                " FROM " & HRTblPath & "MileageInput WHERE EmployeeId = " & cboEmpId.Value & " AND RowID = " & ugRow.Cells("rowid").Value
        Dim SQLSelect As String = "SELECT rowid, employeeid, division, officeid, office, vehiclelicplate, route, checkindate, mileagein, mileageout, totalmileage, weekending, payrollending" & _
                                " FROM " & HRTblPath & "MileageInput WHERE EmployeeId = " & cboEmpId.Value & " AND RowID = " & ugRow.Cells("rowid").Value

        If MsgBox("Are you sure you want to EDIT the previously entered data for: '" & UltraGrid1.ActiveRow.Cells("CheckInDate").Value & "- In:" & UltraGrid1.ActiveRow.Cells("MileageIn").Value & ", Out: " & UltraGrid1.ActiveRow.Cells("MileageOut").Value & "'?", MsgBoxStyle.YesNo, "Edit A Previuos Record") = MsgBoxResult.Yes Then
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

            'ucboDeptNo.Focus()

            utRowID.Text = ugRow.Cells("rowid").Value
            'ucboDeptNo.Value = ugRow.Cells("DeptNo").Value

            'PreviousDeptNo = ucboDeptNo.Value
            cboVehicle.Text = ugRow.Cells("VehicleLicPlate").Value
            dpWorked.Value = Format(ugRow.Cells("CheckInDate").Value, "MM/dd/yyyy")
            txtWeekEnding.Text = Format(_workDate.WeekEnding(dpWorked.Value), "MM/dd/yyyy")

            txtMileageIn.Text = ugRow.Cells("MileageIn").Value
            utRoute.Text = ugRow.Cells("Route").Value
            txtMileageOut.Text = ugRow.Cells("MileageOut").Value
            'txtBreakHrs.Text = ugRow.Cells("BreakTime").Value
            'txtCheckOutDate.Text = ugRow.Cells("CheckOutDate").Value
            txtOfficeID.Text = ugRow.Cells("OfficeID").Value
            txtOffice.Text = ugRow.Cells("Office").Value
            'txtPayRate.Text = ugRow.Cells("PayRate").Value
            utTotalMileage.Text = ugRow.Cells("TotalMileage").Value
            'ucboDept.SelectNextControl(ucboDept, True, True, False, True)
        End If

    End Sub
    Private Sub cboVehicle_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVehicle.KeyUp
        Select Case e.KeyValue
            Case 39
                cboEmpId.ToggleDropdown()
            Case 13
                If ScreenCode = "DE" Then
                    If (cboVehicle.Text = "") And (_iCount <> 0) Then
                        KeyBuffer(0) = 13
                        KeyBuffer(1) = btnExit
                        KeyBuffer(2) = e
                        SimulateTab(e, 13, btnExit)
                    Else
                        KeyBuffer(0) = 13
                        KeyBuffer(1) = cboVehicle
                        KeyBuffer(2) = e
                        SimulateTab(e, 13, cboVehicle)
                    End If
                Else
                    If _iCount > 0 Then
                        _iCount = 0
                        SimulateTab(e, 13, cboVehicle)
                    Else
                        _iCount += 1
                    End If
                End If
        End Select
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
        'UltraGrid2.DataSource = Nothing
        utRowID.Text = ""
        'FillWeekTotals(cboEmpId.Text.Trim, txtWeekEnding.Text)
        'utRegTotal.Text = "0.00"
        'utOTTotal.Text = "0.00"
        'utDTTotal.Text = "0.00"
        utGross.Text = "0"


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

        'Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        'ugRow = UltraGrid1.ActiveRow
        ''Dim strSQL = "Select epr.DeptNo, d.Department, epr.payrate from " & HRTblPath & "EmployeePayRates epr, " & HRTblPath & "Departments d where epr.employeeid = '" & ugrow.Cells("EmployeeID").Value & "' and epr.deptno = d.deptno order by epr.DeptNo"

        'Dim strSQL As String
        'strSQL = "Select LicPlate, Make, Model from " & HRTblPath & "VEHICLES where EmployeeID = '" & ugrow.Cells("EmployeeID").Value & "'"
        'FillUCombo(cboVehicle, "", "", strSQL, , True)
        'FillUCombo(cboVehicle, "", "", "Select LicPlate, Make, Model from " & HRTblPath & "VEHICLES where EmployeeID = '" & ugrow.Cells("EmployeeID").Value & "'", HRTblPath, True)


        'Dim dtS As New DataSet
        'Dim dtA As New SqlDataAdapter
        'Dim value As String = "SELECT TOP 1 LicPlate from " & HRTblPath & "VEHICLES where EmployeeID = '" & ugrow.Cells("EmployeeID").Value & "' and Active = 'T'"
        'PopulateDataset2(dtA, dtS, value)
        'Dim answer As String = value.



        FillUCombo(cboVehicle, "", "", "Select LicPlate, Make, Model from " & HRTblPath & "VEHICLES where EmployeeID = '" & ugrow.Cells("EmployeeID").Value & "' and Active = 'T'")
        'FillUCombo(cboVehicle, "SELECT TOP 1 LicPlate from " & HRTblPath & "VEHICLES where EmployeeID = '" & ugrow.Cells("EmployeeID").Value & "' and Active = 'T'", "", "Select LicPlate, Make, Model from " & HRTblPath & "VEHICLES where EmployeeID = '" & ugrow.Cells("EmployeeID").Value & "' and Active = 'T'")
        'SELECT TOP 1 * from " & HRTblPath & "VEHICLES
        'cboVehicle.Value = 1
        'FillUCombo(ucboDivision, "CFC", , , HRTblPath)
        AddHandler cboVehicle.Leave, AddressOf UCbo_Leave

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
        'Dim strSQL = "Select epr.DeptNo, d.Department, epr.payrate from " & HRTblPath & "EmployeePayRates epr, " & HRTblPath & "Departments d where epr.employeeid = '" & ugrow.Cells("EmployeeID").Value & "' and epr.deptno = d.deptno order by epr.DeptNo"
        'FillUCombo(ucboDeptNo, "", "", strSQL, HRTblPath, True)

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

        'Dim e2 As New System.Windows.Forms.KeyEventArgs(Keys.Down)
        'SimulateTab(e2, 13, cboVehicle)
        'Application.DoEvents()

        'Populate DataGrid2
        'ShowEmployeeSchedule(GetEmployeeSchedule(cboEmpId.Text.Trim, dpWorked.DateTime.DayOfWeek))

    End Sub

    'Private Sub cboEmpId_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpId.Leave
    '    Dim dbRow As DataRow
    '    Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
    '    'If sender.Modified = False Then Exit Sub
    '    'If sender.Text.Trim = "" Then
    '    '    ClearForm(Me)
    '    '    UltraGrid1.DataSource = Nothing
    '    '    Exit Sub
    '    'End If
    '    sender.modified = False

    '    'If Val(sender.text) > 0 Then
    '    'FillUCombo(cboVehicle, "SELECT TOP 1 LicPlate from " & HRTblPath & "VEHICLES where EmployeeID = '" & ugrow.Cells("EmployeeID").Value & "' and Active = 'T'", "", "Select LicPlate, Make, Model from " & HRTblPath & "VEHICLES where EmployeeID = '" & ugrow.Cells("EmployeeID").Value & "' and Active = 'T'")
    '    'If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "CUSTOMER", " Status = 1") = False Then
    '    If ReturnRowByID(Val(sender.Text), dbRow, HRTblPath & "VEHICLES", " EmployeeID = '" & ugrow.Cells("EmployeeID").Value & "' and Active = 'T'") = False Then
    '        MsgBox("Employee ID not found.")
    '        sender.Focus()
    '        Exit Sub
    '    End If
    '    VehicleLicPlate.Text = dbRow.Item("LicPlate")
    '    sender.Modified = False
    '    'If btnNew.Text.ToUpper <> "&NEW" Then Exit Sub
    '    'LoadData()
    '    'End If

    'End Sub

    Private Sub FillWeekTotals(ByVal EmplID As String, ByVal WeekEnding As String)
        'Dim strSQL = "Select isnull(Sum(RegHrs), 0) as TotalReg, isnull(Sum(OTHrs), 0) as TotalOT, isnull(Sum(DTHrs), 0) as TotalDT, isnull(Sum(TotalHrs), 0) as Gross from " & HRTblPath & "EmployeeActivityDetail where EmployeeID = '" & EmplID & "' and WeekEnding = '" & WeekEnding & "'"
        'Dim strSQL = "Select isnull(Sum(RegHrs), 0) as TotalReg, isnull(Sum(TotalHrs), 0) as Gross from " & HRTblPath & "EmployeeActivityDetail where EmployeeID = '" & EmplID & "' and WeekEnding = '" & WeekEnding & "'"
        Dim strSQL = "Select isnull(Sum(TotalMileage), 0) as WeeklyMileage from " & HRTblPath & "MileageInput where EmployeeID = '" & EmplID & "' and WeekEnding = '" & WeekEnding & "'"
        Dim row As DataRow

        If EmplID.Trim <> "" And WeekEnding.Trim <> "" Then
            If ReturnRowByID("", row, "", "", "", strSQL) Then
                'utRegTotal.Text = row("TotalReg")
                'utOTTotal.Text = row("TotalOT")
                'utDTTotal.Text = row("TotalDT")
                utGross.Text = row("WeeklyMileage")
                row = Nothing
                Exit Sub
            End If
        End If

        'utRegTotal.Text = "0.00"
        'utOTTotal.Text = "0.00"
        'utDTTotal.Text = "0.00"
        utGross.Text = "0.00"

    End Sub
    Private Sub dpWorked_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dpWorked.KeyUp

        Select Case e.KeyValue
            Case 13
                KeyBuffer(0) = Nothing
                KeyBuffer(1) = Nothing
                KeyBuffer(2) = Nothing
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

    Private Sub txtMileageIn_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMileageIn.KeyUp

        If e.KeyValue = 13 Then
            If txtMileageIn.Text = "" Then
                If Not KeyBuffer(0) Is Nothing Then
                    Select Case KeyBuffer(1).name.toupper
                        Case "BTNSAVE"
                            KeyBuffer(0) = Nothing
                            KeyBuffer(1) = Nothing
                            KeyBuffer(2) = Nothing
                        Case Else
                            KeyBuffer(0) = Nothing
                            KeyBuffer(1) = Nothing
                            KeyBuffer(2) = Nothing
                    End Select
                Else
                    If ScreenCode = "DE" Then
                        utRoute.Text = ""
                        KeyBuffer(0) = 13
                        KeyBuffer(1) = txtMileageIn
                        KeyBuffer(2) = e
                        SimulateTab(KeyBuffer(2), KeyBuffer(0), cboVehicle)
                    Else
                        'SimulateTab for "WE"
                    End If
                End If
            Else
                SimulateTab(e, 13, txtMileageIn)
            End If
        End If

    End Sub

    Private Sub txtMileageOut_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMileageOut.KeyUp
        SimulateTab(e, 13, txtMileageOut)
    End Sub

    Private Sub utRoute_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utRoute.KeyUp
        If e.KeyValue = 13 Then
            If utRoute.Text = "" Then
                ''If Not KeyBuffer(0) Is Nothing Then    'This means the "Enter" was sent by another control on the form
                ''Select Case KeyBuffer(1).name.toupper
                ''Case "TXTMILEAGEIN"
                ''KeyBuffer(0) = Nothing
                ''KeyBuffer(1) = Nothing
                ''KeyBuffer(2) = Nothing
                ''Case Else
                ''KeyBuffer(0) = Nothing
                ''KeyBuffer(1) = Nothing
                ''KeyBuffer(2) = Nothing
                ''End Select
                ''Else    ' This means the user hit the "Enter" key when the field was blank
                If ScreenCode = "DE" Then
                    KeyBuffer(0) = 13
                    KeyBuffer(1) = utRoute
                    KeyBuffer(2) = e
                    ''dpWorked.Focus()
                    cboEmpId.Focus()
                    'SimulateTab(KeyBuffer(2), KeyBuffer(0), cboVehicle)
                Else
                    'SimulateTab for "WE"
                End If
            Else
                SimulateTab(e, 13, utRoute)
            End If
        Else
            SimulateTab(e, 13, utRoute)
        End If
        ''End If
        ''If e.KeyValue = 13 And utRoute.Text = "" Then
        ''If ScreenCode = "DE" Then
        ''cboEmpId.Text = ""
        ''SimulateTab(e, 13, dpWorked)
        ''Else
        ''SimulateTab(e, 13, cboEmpId)
        ''End If
        ''Else
        ''SimulateTab(e, 13, utRoute)
        ''End If
    End Sub


    Private Sub btnSave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnSave.KeyUp
        If e.KeyValue = 13 Then
            If ScreenCode = "DE" Then
                txtMileageIn.Text = ""
                SimulateTab(e, 13, utRoute)
            Else
                'Simulate to next field if Weekly Input
            End If
        End If
    End Sub
#End Region

#Region "Field Validation"

    Private Sub txtMileageIn_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMileageIn.Enter
        If ErrorProvider1.GetError(txtMileageIn).ToString <> "" Then
            txtMileageIn.SelectAll()
        End If
    End Sub

    Private Sub txtMileageOut_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMileageOut.Enter
        If ErrorProvider1.GetError(txtMileageOut).ToString <> "" Then
            txtMileageOut.SelectAll()
        End If
    End Sub

    Private Sub txtMileageOut_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMileageOut.Leave 'txtMileageIn.Leave, 
        If txtMileageOut.Text = "" Then txtMileageOut.Text = "0"
        'Retrieve and cast widget value
        Dim mOut, mIn As Single
        mOut = CSng(txtMileageOut.Text)
        mIn = CSng(txtMileageIn.Text)

        utTotalMileage.Text = Format(mOut - mIn)

    End Sub
    Private Sub txtMileageIn_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMileageIn.Validating
        'If (_cValidate.Range(txtMileageOut, 0, 23.99) = False) Then SetError(txtMileageOut, e, "Must be between 00.00 and 23.99")
        If (_cValidate.Range(txtMileageOut, 0, 2000000) = False) Then SetError(txtMileageOut, e, "Must be between 0 and 2,000,000")
    End Sub

    Private Sub txtMileageOut_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMileageOut.Validating

        'If (_cValidate.Range(txtMileageOut, 0, 23.99) = False) Then SetError(txtMileageOut, e, "Must be between 00.00 and 23.99")
        If (_cValidate.Range(txtMileageOut, System.Convert.ToDouble(txtMileageIn.Text), 2000000) = False) Then SetError(txtMileageOut, e, "Must be between " & txtMileageIn.Text & " and 2,000,000")
    End Sub

    Private Sub txtMileageOut_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMileageOut.Validated
        ClearError(txtMileageOut)
    End Sub

    'Private Sub txtBreakHrs_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBreakHrs.Enter
    '    If ErrorProvider1.GetError(txtBreakHrs).ToString <> "" Then
    '        txtBreakHrs.SelectAll()
    '    End If
    'End Sub



    'Private Sub txtBreakHrs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBreakHrs.Validating
    '    If (_cValidate.Range(txtBreakHrs, 0, 23.99) = False) Then SetError(txtBreakHrs, e, "Must be between 00.00 and 23.99")
    'End Sub

    'Private Sub txtBreakHrs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBreakHrs.Validated
    '    ClearError(txtBreakHrs)
    'End Sub

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
    'Private Sub ucboDeptNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDeptNo.Enter
    '    If ErrorProvider1.GetError(ucboDeptNo).ToString <> "" Then
    '        Me.ucboDeptNo.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.FirstCharacter, False, False)
    '        Me.ucboDeptNo.PerformAction(Infragistics.Win.UltraWinMaskedEdit.MaskedEditAction.SelectSection, False, False)
    '    End If
    'End Sub

    'Private Sub ucboDeptNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ucboDeptNo.Validating
    '    If ucboDeptNo.Text = "" Then
    '        'SetError(ucboDeptNo, e, "You must enter a valid Department Number")
    '    Else
    '        'The general logic is that If AN EMPLOYEE is being PROCESSED, we can not input any TIME_CARD data for the 
    '        'processed Payroll Ending for
    '        'the DeptNo processed.
    '        Dim row2 As DataRow
    '        If ReturnRowByID(ucboDeptNo.Value, row2, "" & HRTblPath & "EmployeeActivityDetail", " EmployeeID = " & cboEmpId.Value & " AND PayRollEnding = '" & lblPayrollEnding.Text & "' AND Processed = 1 ", "DeptNo") Then
    '            MsgBox("Dept.No. " & ucboDeptNo.Value & " for Period Ending '" & lblPayrollEnding.Text & "' has been PROCESSED for this employee and is not editable.")
    '            ucboDeptNo.Value = Nothing
    '            ucboDeptNo.Text = ""
    '            ucboDeptNo.Focus()
    '            'Exit Sub
    '        End If
    '        If Not row2 Is Nothing Then
    '            row2.Table.DataSet.Dispose()
    '        End If
    '        row2 = Nothing
    '        'If (_cValidate.TextInSet(ucboDeptNo, "fldCode", ucboDeptNo.DataSource) = False) Then
    '        '    SetError(ucboDeptNo, e, "Invalid Department Number")
    '        'End If
    '    End If
    'End Sub
    'Private Sub ucboDeptNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDeptNo.Validated
    '    'ClearError(ucboDeptNo)
    '    If ucboDeptNo.Text = "" Then Exit Sub
    '    'Update the hidden txtPayRate widget
    '    Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
    '    If ucboDeptNo.ActiveRow Is Nothing Then
    '        txtPayRate.Text = "0.00"
    '    End If
    '    ugrow = ucboDeptNo.ActiveRow
    '    txtPayRate.Text = ugrow.Cells("PayRate").Value
    '    'For Each ugrow In ucboDeptNo.Rows
    '    '    If DataRow("fldCode") = ucboDeptNo.Text Then
    '    '        txtPayRate.Text = CStr(DataRow("PayRate"))
    '    '        'txtOfficeID.Text = CStr(DataRow("OfficeID"))
    '    '        'txtOffice.Text = CStr(DataRow("Office_name"))
    '    '        Exit For
    '    '    End If
    '    'Next
    'End Sub

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
                'ArrangeWidget(txtPayRate, New Point(0, 0), 0)
                'ArrangeWidget(txtCheckOutDate, New Point(0, 0), 0)
                ArrangeWidget(txtWeekEnding, New Point(0, 0), 0)
                ArrangeWidget(lblDateWorked, New Point(8, 80), 0)
                ArrangeWidget(lblEmpId, New Point(8, 112), 0)
                ArrangeWidget(lblName, New Point(8, 144), 0)
                ArrangeWidget(lblTimeIn, New Point(8, 208), 0)
                ArrangeWidget(lblTimeOut, New Point(8, 240), 0)
                'ArrangeWidget(lblBreakTime, New Point(8, 272), 0)
                ArrangeWidget(ulblTotalHrs, New Point(8, 304), 0)
                ArrangeWidget(lblEmpName, New Point(128, 144), 0)
                ArrangeWidget(utTotalMileage, New Point(128, 304), 0)
                ArrangeWidget(ulblDivision, New Point(8, 16), 0)
                ArrangeWidget(lblDivision, New Point(128, 16), 0)
                ArrangeWidget(ulblWeekEnding, New Point(8, 48), 0)
                ArrangeWidget(lblPayrollEnding, New Point(128, 48), 0)
                ArrangeWidget(ulblDeptNo, New Point(8, 176), 0)
                ArrangeWidget(btnEdit, New Point(688, 352), 0)
                ArrangeWidget(UltraGrid1, New Point(288, 8), 0)
                ArrangeWidget(dpWorked, New Point(128, 80), 1)
                ArrangeWidget(cboEmpId, New Point(128, 112), 2)
                'ArrangeWidget(ucboDeptNo, New Point(128, 176), 3)
                ArrangeWidget(txtMileageIn, New Point(128, 208), 4)
                ArrangeWidget(txtMileageOut, New Point(128, 240), 5)
                'ArrangeWidget(txtBreakHrs, New Point(128, 272), 6)
                ArrangeWidget(btnSave, New Point(112, 344), 7)
                ArrangeWidget(btnExit, New Point(200, 344), 8)
            Case "ED"
                ArrangeWidget(txtOfficeID, New Point(0, 0), 0)
                ArrangeWidget(txtOffice, New Point(0, 0), 0)
                'ArrangeWidget(txtPayRate, New Point(0, 0), 0)
                'ArrangeWidget(txtCheckOutDate, New Point(0, 0), 0)
                ArrangeWidget(txtWeekEnding, New Point(0, 0), 0)
                ArrangeWidget(UltraGrid1, New Point(288, 8), 0)
                ArrangeWidget(ulblDivision, New Point(8, 24), 0)
                ArrangeWidget(lblDivision, New Point(128, 24), 0)
                ArrangeWidget(ulblWeekEnding, New Point(8, 56), 0)
                ArrangeWidget(lblEmpName, New Point(128, 152), 0)
                ArrangeWidget(ulblTotalHrs, New Point(8, 312), 0)
                ArrangeWidget(utTotalMileage, New Point(128, 312), 0)
                ArrangeWidget(lblDateWorked, New Point(8, 184), 0)
                ArrangeWidget(lblPayrollEnding, New Point(128, 56), 0)
                ArrangeWidget(lblTimeIn, New Point(8, 216), 0)
                ArrangeWidget(lblEmpId, New Point(8, 88), 0)
                ArrangeWidget(lblName, New Point(8, 152), 0)
                ArrangeWidget(lblTimeOut, New Point(8, 248), 0)
                ArrangeWidget(ulblDeptNo, New Point(8, 120), 0)
                'ArrangeWidget(lblBreakTime, New Point(8, 280), 0)
                ArrangeWidget(btnEdit, New Point(688, 352), 0)
                ArrangeWidget(cboEmpId, New Point(128, 88), 1)
                'ArrangeWidget(ucboDeptNo, New Point(128, 120), 2)
                ArrangeWidget(dpWorked, New Point(128, 184), 3)
                ArrangeWidget(txtMileageIn, New Point(128, 216), 4)
                ArrangeWidget(txtMileageOut, New Point(128, 248), 5)
                'ArrangeWidget(txtBreakHrs, New Point(128, 280), 6)
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
        'Dim HidCols() As String = {"RowID", "EmployeeId", "OfficeID", "CheckOutDate", "Division", "PayrollEnding", "Processed"}
        Dim HidCols() As String = {"RowID", "EmployeeId", "OfficeID", "Division", "PayrollEnding", "Processed"}
        Dim i As Integer
        Dim SQLSelect, DateRngCond, AcctCond, FromLocCond, ToLocCond, TRNumCond, ThirdPCond, EventCond, Address3 As String
        Dim SummCol As String

        'Modified By Ali
        'SQLSelect = "SELECT RowID, EmployeeID, Division, OfficeID, Office, VehicleLicPlate, Route, CheckInDate, MileageIn, CheckOutDate, MileageOut, WeekEnding, PayrollEnding, LastUpdate, Processed, UserID, TotalMileage" & _
        '            " FROM " & HRTblPath & "MileageInput WHERE EmployeeId = " & empId & " AND PayrollEnding = '" & lblPayrollEnding.Text.Trim & "' ORDER BY CheckInDate, VehicleLicPlate, MileageIn Asc"
        SQLSelect = "SELECT RowID, EmployeeID, Division, OfficeID, Office, VehicleLicPlate, Route, CheckInDate, MileageIn, MileageOut, WeekEnding, PayrollEnding, LastUpdate, Processed, UserID, TotalMileage" & _
                            " FROM " & HRTblPath & "MileageInput WHERE EmployeeId = " & empId & " AND PayrollEnding = '" & lblPayrollEnding.Text.Trim & "' ORDER BY CheckInDate, VehicleLicPlate, MileageIn Asc"

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next

        FillUltraGrid(UltraGrid1, dtSet, -1, HidCols, 0)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGrid1.DisplayLayout.AutoFitColumns = False
        UltraGrid1.DisplayLayout.Bands(0).Columns(8).Format = "#"
        UltraGrid1.DisplayLayout.Bands(0).Columns(9).Format = "#"
        UltraGrid1.DisplayLayout.Bands(0).Columns(15).Format = "#"

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

        SummCol = "TotalMileage"
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

    Private Sub txtMileageIn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMileageIn.Leave, txtMileageOut.Leave
        sender.Text = Format(Val(sender.text), "0")
    End Sub
    Private Sub MileageInput_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not cmdTrans Is Nothing Then
            cmdTrans.Transaction.Rollback()
            If cmdTrans.Connection.State = ConnectionState.Open Then
                cmdTrans.Connection.Close()
            End If
            cmdTrans = Nothing
        End If

    End Sub
    ' =BEGIN==== MENU ROUTINES ==============================================================
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
    Private m_searchForm As frmSearchInfo = Nothing
    Private m_searchInfo As clsSearchInfo = New clsSearchInfo

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.m_oColumn Is Nothing Then Exit Sub

        If Me.m_searchForm Is Nothing Then
            Me.m_searchForm = New frmSearchInfo
        End If

        Me.m_searchForm.ShowMe(Me, Me.m_oColumn.Key, UltraGrid1, m_searchInfo)

    End Sub
    ' =END==== MENU ROUTINES ==============================================================

    Private Function AcceptableMileageInput(ByVal EmplID As String, ByVal DateWorked As Date, ByVal MileageIn As String, ByVal MileageOut As String, ByVal RowID As String) As Boolean

        'Make sure all required fields are present
        If Not AllRequiredFieldsPresent(EmplID, MileageIn, MileageOut) Then Return False

        'Make sure proposed mileage range does not conflict with any other entries
        If IsOverlapInput(EmplID, DateWorked, MileageIn, MileageOut, RowID) Then Return False

        'Make sure any equal endpoints are OK
        Return EqualEndPointsOK(EmplID, DateWorked, MileageIn, MileageOut, RowID)

    End Function

    Private Function AllRequiredFieldsPresent(ByVal EmplID As String, ByVal MileageIn As String, ByVal MileageOut As String) As Boolean

        ' Perform Field Validation
        If EmplID.Trim = "" Then

            MsgBox("EmployeeID is blank.")
            Return False

        End If

        If MileageIn.Trim = "" Then

            MsgBox("MileageIn is not specified.")
            Return False

        End If

        If MileageOut.Trim = "" Then

            MsgBox("MileageOut is not specified.")
            Return False

        End If

        Return True

    End Function

    Private Function EqualEndPointsOK(ByVal EmplID As String, ByVal DateWorked As Date, ByVal MileageIn As String, ByVal MileageOut As String, ByVal RowID As String) As Boolean

        ' Determine if we are in Edit Mode or New Mode
        Dim IsEditMode As Boolean
        If RowID = String.Empty Then
            IsEditMode = False
        Else
            IsEditMode = True
        End If

        ' Prepare the Query to Test for Equal Endpoints
        Dim RowIDCond As String
        Dim sqlSelect As String = "Select TOP 1 * from " & HRTblPath & "MileageInput where " & _
        "EmployeeID = '@e' AND VehicleLicPlate = '@v' @@ROWID AND " & _
        "(CheckInDate > (SELECT TOP 1 ResetDate FROM " & HRTblPath & "OdometerReset where LicPlate = '@v' and EmployeeID = '@e' order by ResetDate DESC)) AND " & _
        "(@a = MileageOut OR @b = MileageIn) " & _
        "ORDER BY CheckInDate"

        If Val(RowID.Trim) > 0 Then
            RowIDCond = " AND RowID <> " & RowID & " "
        Else
            RowIDCond = ""
        End If
        sqlSelect = sqlSelect.Replace("@@ROWID", RowIDCond)
        sqlSelect = sqlSelect.Replace("@a", MileageIn)
        sqlSelect = sqlSelect.Replace("@b", MileageOut)
        sqlSelect = sqlSelect.Replace("@c", DateWorked.ToShortDateString)
        sqlSelect = sqlSelect.Replace("@e", EmplID)
        sqlSelect = sqlSelect.Replace("@v", cboVehicle.Text)

        ' Make the call and Inspect the Results
        Dim row As DataRow = Nothing

        ReturnRowByID("", row, "", "", "", sqlSelect)
        If row Is Nothing Then

            EqualEndPointsOK = True

        Else

            Dim sCheckInDate As String = CDate(row("CheckInDate")).ToShortDateString
            Dim sMileageIn As String = row("MileageIn")
            Dim sMileageOut As String = row("MileageOut")
            Dim sMessage As String

            sMessage = "Is it OK to have an Endpoint Equal to this previous entry..." & Chr(13) & Chr(10) & Chr(13) & Chr(10)
            sMessage = sMessage & "          " & sCheckInDate & ": " & sMileageIn & " - " & sMileageOut

            Dim x As MsgBoxResult = MsgBox(sMessage, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Equal Endpoints")

            If x = MsgBoxResult.Yes Then

                EqualEndPointsOK = True

            Else

                EqualEndPointsOK = False

            End If

        End If

    End Function

    Private Function IsOverlapInput(ByVal EmplID As String, ByVal DateWorked As Date, ByVal MileageIn As String, ByVal MileageOut As String, ByVal RowID As String) As Boolean

        ' Set Default Return Value for Function
        IsOverlapInput = True

        ' Determine if we are in Edit Mode or New Mode
        Dim IsEditMode As Boolean = True
        If RowID = String.Empty Then IsEditMode = False


        '' START OF KARINA'S LOGIC
        'Dim sqlSelect As String = "Select * from " & HRTblPath & "EmployeeActivityDetail where EmployeeID = '" & EmplID & "' AND ( (CheckInDate = '" & Format(DateWorked, "MM/dd/yyyy") & "' and ( (timein between " & TimeIn & " AND " & TimeOut & " AND timeout <= " & TimeOut & ") OR (timeout between " & TimeIn & " AND " & TimeOut & " AND timein >= " & TimeIn & ") OR (timein = " & TimeIn & " AND TimeOut = " & TimeOut & ") OR (timein < " & TimeIn & " AND TimeOut > " & TimeIn & ") OR (" & TimeIn & " < " & TimeOut & " AND (TimeIn < " & TimeOut & " AND timeout > " & TimeOut & ")) OR (TimeOut < TimeIn AND (" & TimeIn & " > Timein OR " & TimeOut & " > TimeIn OR " & TimeOut & " < TimeOUt)) ) ) OR (CheckOutDate = '" & Format(dpWorked.Value, "MM/dd/yyyy") & "' AND CheckInDate < CheckoutDate AND (" & TimeIn & " < TimeOut)) @@NEXTDAYCOND ) @@ROWID "
        'Dim sqlSelect As String = "Select * from " & HRTblPath & "MileageInput where EmployeeID = '" & EmplID & "' AND VehicleLicPlate = '" & cboVehicle.Text & "' AND ( (CheckInDate = '" & Format(DateWorked, "MM/dd/yyyy") & "' and ( (MileageIn between " & MileageIn & " AND " & MileageOut & " AND MileageOut <= " & MileageOut & ") OR (MileageOut between " & MileageIn & " AND " & MileageOut & " AND MileageIn >= " & MileageIn & ") OR (MileageIn = " & MileageIn & " AND MileageOut = " & MileageOut & ") OR (MileageIn < " & MileageIn & " AND MileageOut > " & MileageIn & ") OR (" & MileageIn & " < " & MileageOut & " AND (MileageIn < " & MileageOut & " AND MileageOut > " & MileageOut & ")) OR (MileageOut < MileageIn AND (" & MileageIn & " > MileageIn OR " & MileageOut & " > MileageIn OR " & MileageOut & " < MileageOut)) ) ) OR (CheckOutDate = '" & Format(dpWorked.Value, "MM/dd/yyyy") & "' AND CheckInDate < CheckoutDate AND (" & MileageIn & " < MileageOut)) @@NEXTDAYCOND ) @@ROWID "
        'With this quary miles still overlap if miles were input for the same vehicle but in different days.
        'Dim sqlSelect As String = "Select * from " & HRTblPath & "MileageInput where EmployeeID = '" & EmplID & "' AND VehicleLicPlate = '" & cboVehicle.Text & "' AND ( (CheckInDate = '" & Format(DateWorked, "MM/dd/yyyy") & "' and ( (MileageIn between " & MileageIn & " AND " & MileageOut & " AND MileageOut <= " & MileageOut & ") OR (MileageOut between " & MileageIn & " AND " & MileageOut & " AND MileageIn >= " & MileageIn & ") OR (MileageIn = " & MileageIn & " AND MileageOut = " & MileageOut & ") OR (MileageIn < " & MileageIn & " AND MileageOut > " & MileageIn & ") OR (" & MileageIn & " < " & MileageOut & " AND (MileageIn < " & MileageOut & " AND MileageOut > " & MileageOut & ")) OR (MileageOut < MileageIn AND (" & MileageIn & " > MileageIn OR " & MileageOut & " > MileageIn OR " & MileageOut & " < MileageOut)) ) ) @@NEXTDAYCOND ) @@ROWID "
        'Dim sqlSelect As String = "Select * from " & HRTblPath & "MileageInput where EmployeeID = '" & EmplID & "' AND VehicleLicPlate = '" & cboVehicle.Text & "' AND ( ( ( (MileageIn between " & MileageIn & " AND " & MileageOut & " AND MileageOut <= " & MileageOut & ") OR (MileageOut between " & MileageIn & " AND " & MileageOut & " AND MileageIn >= " & MileageIn & ") OR (MileageIn = " & MileageIn & " AND MileageOut = " & MileageOut & ") OR (MileageIn < " & MileageIn & " AND MileageOut > " & MileageIn & ") OR (" & MileageIn & " < " & MileageOut & " AND (MileageIn < " & MileageOut & " AND MileageOut > " & MileageOut & ")) OR (MileageOut < MileageIn AND (" & MileageIn & " > MileageIn OR " & MileageOut & " > MileageIn OR " & MileageOut & " < MileageOut)) ) ) @@NEXTDAYCOND ) @@ROWID "
        'Dim sqlSelect As String = "Select * from " & HRTblPath & "MileageInput where EmployeeID = '" & EmplID & "' AND VehicleLicPlate = '" & cboVehicle.Text & "' AND ( ( ( (MileageIn > " & MileageIn & " AND MileageOut > " & MileageOut & " ) OR (MileageIn between " & MileageIn & " AND " & MileageOut & " AND MileageOut <= " & MileageOut & ") OR (MileageOut between " & MileageIn & " AND " & MileageOut & " AND MileageIn >= " & MileageIn & ") OR (MileageIn = " & MileageIn & " AND MileageOut = " & MileageOut & ") OR (MileageIn < " & MileageIn & " AND MileageOut > " & MileageIn & ") OR (" & MileageIn & " < " & MileageOut & " AND (MileageIn < " & MileageOut & " AND MileageOut > " & MileageOut & ")) OR (MileageOut < MileageIn AND (" & MileageIn & " > MileageIn OR " & MileageOut & " > MileageIn OR " & MileageOut & " < MileageOut)) ) ) @@NEXTDAYCOND ) @@ROWID "
        ''  END OF KARINA'S LOGIC

        '' START OF SAMMY'S LOGIC
        Dim sqlSelect As String = "Select * from " & HRTblPath & "MileageInput where EmployeeID = '@e' " & _
        "AND VehicleLicPlate = '@v' @@ROWID AND (" & _
        "(@a < MileageIn and @b > MileageOut) OR " & _
        "(@a = MileageIn) OR " & _
        "(@b = MileageOut) OR " & _
        "(@a > MileageIn and @a < MileageOut) OR " & _
        "(@b > MileageIn and @b < MileageOut) OR " & _
        "(@a = MileageOut AND @b <= @a) OR " & _
        "(@b = MileageIn AND  @a >= @b) OR " & _
        "(EmployeeID = '@e' and VehicleLicPlate = '@v' and CheckInDate > '@c' AND MileageIn < @b) OR" & _
        "(EmployeeID = '@e' and VehicleLicPlate = '@v' and CheckInDate < '@c' AND MileageIn > @a)) AND" & _
        "(CheckInDate > " & HRTblPath & "fGetOdometerResetDate(@e,'@v'))"
        '"(CheckInDate > (SELECT TOP 1 ResetDate FROM " & HRTblPath & "OdometerReset where LicPlate = '@v' and EmployeeID = '@e' order by ResetDate DESC))"
        '' END OF SAMMY'S LOGIC

        '' START OF ZAK'S LOGIC
        ''Dim sqlSelect As String = "Select TOP 1 * from " & HRTblPath & "MileageInput where " & _
        ''"EmployeeID = '@e' AND VehicleLicPlate = '@v' @@ROWID AND " & _
        ''"(CheckInDate > (SELECT TOP 1 ResetDate FROM UN_HR.DBO.OdometerReset where LicPlate = '@v' and EmployeeID = '@e' order by ResetDate DESC)) AND (" & _
        ''"(@b < MileageIn AND '@c' > CheckInDate) OR " & _
        ''"(MileageIn < @b AND @b < MileageOut) OR " & _
        ''"(@a < MileageIn AND MileageOut < @b) OR " & _
        ''"(@a > MileageIn AND @b < MileageOut) OR " & _
        ''"(@a > MileageIn AND @a < MileageOut) OR " & _
        ''"(@a = MileageIn AND @b = MileageOut) OR" & _
        ''"(@a > MileageOut AND '@c' < CheckInDate)) " & _
        ''"ORDER BY CheckInDate"
        ''  END OF ZAK'S LOGIC

        '' START OF ZAM (SAM & ZAK) LOGIC
        ''Dim sqlSelect As String = "Select TOP 1 * from " & HRTblPath & "MileageInput where " & _
        ''"EmployeeID = '@e' AND VehicleLicPlate = '@v' @@ROWID AND " & _
        ''"(CheckInDate > (SELECT TOP 1 ResetDate FROM UN_HR.DBO.OdometerReset where LicPlate = '@v' and EmployeeID = '@e' order by ResetDate DESC)) AND (" & _
        ''"(@b < MileageIn AND @c <= CheckInDate) OR" & _
        ''"(@a > MileageOut AND @c >= CheckInDate))" & _
        ''"ORDER BY CheckInDate"
        '' END OF ZAM LOGIC

        sqlSelect = sqlSelect.Replace("@a", MileageIn)
        sqlSelect = sqlSelect.Replace("@b", MileageOut)
        sqlSelect = sqlSelect.Replace("@c", DateWorked.ToShortDateString)
        sqlSelect = sqlSelect.Replace("@e", EmplID)
        sqlSelect = sqlSelect.Replace("@v", cboVehicle.Text)

        'Added by Sammy Nava to Check Case where CheckOut time is DateWorked + 1 and timout
        Dim dNextDay As Date
        Dim strNextDay As String
        Dim strNextDayCond As String

        ' This code was taken from Hour Input so it doesn't make sense here
        ' If MileageOut is < MileageIn, it either means operator input error, or the odometer rolled over.
        ' In either case, the field validation will prevent the operation from getting this far.
        ''If CSng(MileageOut) < CSng(MileageIn) Then
        ''dNextDay = CDate(dpWorked.Value).AddDays(1)
        ''strNextDay = "'" & Format(dNextDay, "MM/dd/yyyy") & "'"
        '''strNextDayCond = "OR ( (CheckOutDate = " & strNextDay & ") and (MileageOut <= '" & MileageOut & "') )"
        ''strNextDayCond = "OR (MileageOut <= '" & MileageOut & "')"
        ''Else
        ''strNextDayCond = ""
        ''End If
        ''sqlSelect = sqlSelect.Replace("@@NEXTDAYCOND", strNextDayCond)

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

        Else

            Dim sCheckInDate As String = CDate(row("CheckInDate")).ToShortDateString
            Dim sMileageIn As String = row("MileageIn")
            Dim sMileageOut As String = row("MileageOut")
            Dim sMessage As String

            sMessage = "Invalid Range - Violates the Following Record..." & Chr(13) & Chr(10) & Chr(13) & Chr(10)
            sMessage = sMessage & "          " & sCheckInDate & ": " & sMileageIn & " - " & sMileageOut

            MsgBox(sMessage, MsgBoxStyle.Critical, "Invalid Range Specified")

            IsOverlapInput = True

        End If

        row = Nothing

    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Dim SQLSelect As String = "Select * from " & HRTblPath & "EmployeeActivityDetail"
        Dim SQLSelect As String = "Select * from " & HRTblPath & "MileageInput"
        Dim CritTmp As String = "Where RowID = " & utRowID.Text
        Dim IdentIns As Boolean = False

        utProcessed.Text = 0

        If cboEmpId.Text = "" Then
            MsgBox("Employee Not Selected.")
            Exit Sub
        End If
        If GroupBox3.Enabled = False Then
            MsgBox("Data Entry Incomplete. SAVE aborted.")
            Exit Sub
        End If
        If utRoute.Text = "" Then
            MsgBox("Route Not Entered.")
            Exit Sub
        End If
        If txtMileageIn.Text.Trim = txtMileageOut.Text.Trim Then
            If MsgBox("MileageIn & MileageOut are the same. Do you still want to save?", MsgBoxStyle.YesNo, "Possible Erroneous Input") = MsgBoxResult.No Then Exit Sub
        End If
        If Val(utTotalMileage.Text) <= 0 Then
            MsgBox("Invalid Total Mileage.")
            Exit Sub
        End If

        If (CDate(dpWorked.Value) > CDate(lblPayrollEnding.Text)) Or (CDate(dpWorked.Value) < CDate(lblPayrollEnding.Text).AddDays(-14)) Then
            MsgBox("Date Does Not Correspond with Current Pay Period")
            Exit Sub
        End If

        ''CheckOutDate
        'If CSng(txtMileageOut.Text) < CSng(txtMileageIn.Text) Then
        '    txtCheckOutDate.Text = CDate(dpWorked.Value).AddDays(1)
        'Else
        '    txtCheckOutDate.Text = CDate(dpWorked.Value).ToShortDateString
        'End If

        If Not AcceptableMileageInput(cboEmpId.Value, dpWorked.Value, txtMileageIn.Text, txtMileageOut.Text, utRowID.Text) Then
            Exit Sub
        End If
        ''If IsOverlapInput(cboEmpId.Value, dpWorked.Value, txtMileageIn.Text, txtMileageOut.Text, utRowID.Text) Then
        ''MsgBox("The mileage entered is overlapping with previous entry.")
        ''Exit Sub
        ''End If

        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, CritTmp, IdentIns) Then
            'Me.Text = MeText & " -- " & "Saved: " & dpWorked.Text & " - EmplID: " & cboEmpId.Text.Trim & " - Dept.: " & ucboDeptNo.Text & "."
            Me.Text = MeText & " -- " & "Saved: " & dpWorked.Text & " - EmplID: " & cboEmpId.Text.Trim & "."
            CategorizeWorkHours(cboEmpId.Value, txtWeekEnding.Text)
            utRowID.Text = ""

            'AddToPayrollTotals(cboEmpId.Text.Trim, lblPayrollEnding.Text.Trim, ucboDeptNo.Value)
            'If PreviousDeptNo <> "" Then
            '    Dim UpdatePrevDeptTotals As String = _
            '    "Update UN_HR.dbo.EmployeeActivity " & _
            '    " SET RegHrs = ead.TotRegHrs " & _
            '    " , OTHrs = ead.TotOTHrs " & _
            '    " , DTHrs = ead.TotDTHrs " & _
            '    " , PayRate = ep.PayRate " & _
            '    " , HrsPay = (ep.PayRate) * ( ead.TotRegHrs+ (1.5 * ead.TotOTHrs) +  (2. * ead.TotDTHrs) )  " & _
            '    " From " & HRTblPath & "EmployeeActivity ea inner join " & _
            '    " (Select '" & cboEmpId.Text.Trim & "' as EmployeeID, '" & lblPayrollEnding.Text.Trim & "' as PayrollEnding, '" & PreviousDeptNo & "' as DeptNo, Isnull((Select Sum(ead.RegHrs) from " & HRTblPath & "EmployeeActivityDetail ead where ead.Processed = 0 AND ead.PayrollEnding = '" & lblPayrollEnding.Text.Trim & "' AND ead.DeptNo = '" & PreviousDeptNo & "'  AND ead.EmployeeID = '" & cboEmpId.Text.Trim & "'  group by ead.EmployeeID, ead.PayrollEnding, ead.DeptNo), 0) as TotRegHrs, isnull((Select Sum(ead.OTHrs) from " & HRTblPath & "EmployeeActivityDetail ead where ead.Processed = 0 AND ead.PayrollEnding = '" & lblPayrollEnding.Text.Trim & "' AND ead.DeptNo = '" & PreviousDeptNo & "'  AND ead.EmployeeID = '" & cboEmpId.Text.Trim & "'  group by ead.EmployeeID, ead.PayrollEnding, ead.DeptNo), 0) as TotOTHrs, isnull((Select Sum(ead.DTHrs) from " & HRTblPath & "EmployeeActivityDetail ead where ead.Processed = 0 AND ead.PayrollEnding = '" & lblPayrollEnding.Text.Trim & "' AND ead.DeptNo = '" & PreviousDeptNo & "'  AND ead.EmployeeID = '" & cboEmpId.Text.Trim & "'  group by ead.EmployeeID, ead.PayrollEnding, ead.DeptNo), 0) as TotDTHrs ) ead " & _
            '    " on ea.EmployeeID = ead.EmployeeID AND ea.DeptNo = ead.DeptNo And ea.PayrollDate = ead.PayrollEnding  " & _
            '    " inner join " & HRTblPath & "EmployeePayRates ep on ead.EmployeeID = ep.EmployeeID and ead.DeptNo = ep.DeptNo " & _
            '    " where ea.PayrollDate = '" & lblPayrollEnding.Text.Trim & "' AND ea.DeptNo = '" & PreviousDeptNo & "'  AND ea.EmployeeID = '" & cboEmpId.Text.Trim & "' AND ea.Voucher = 0 AND ea.Misc = 0 "

            '    If ExecuteQuery(UpdatePrevDeptTotals) = False Then
            '        MsgBox("Error in updating the edited Dept. Totals.")
            '    End If

            '    PreviousDeptNo = ""
            'End If

            FillInputHistory(cboEmpId.Text.Trim)
            FillWeekTotals(cboEmpId.Text.Trim, txtWeekEnding.Text)
            InitializeInputBoxes(False)

            'ucboDeptNo.Focus()
            ''Dim e2 As New System.Windows.Forms.KeyEventArgs(Keys.Enter)
            ''SimulateTab(e2, 13, GroupBox3) 'Go to TimeIn -- Ali: Should go to Dept Selection 
            ''SimulateTab(e2, 13, txtMileageIn)
            ''e2 = Nothing

            ''dpWorked.Focus()
            'ControlSetFocus(dpWorked)

            KeyBuffer(0) = 13
            KeyBuffer(1) = btnSave
            KeyBuffer(2) = e
            txtMileageIn.Text = ""

            Dim e2 As New System.Windows.Forms.KeyEventArgs(Keys.Enter)
            SimulateTab(e2, 13, GroupBox3) 'Go to TimeIn -- Ali: Should go to Dept Selection 
            Application.DoEvents()
            SimulateTab(e2, 13, utRoute)
            Application.DoEvents()
            e2 = Nothing

        End If

    End Sub
    'Public Function GetEmployeeSchedule(ByVal p_iEmpId As Integer, ByVal p_iDayOfWeek As Integer) As DataSet

    '    Dim dtAdapter As SqlDataAdapter
    '    Dim dtSet As DataSet
    '    Dim SQLSelect As String
    '    Dim i As Integer

    '    'Prepare the SQL Statement
    '    If p_iDayOfWeek = 0 Then p_iDayOfWeek = 7 'This application treats Sunday as Day 7
    '    SQLSelect = "SELECT EmployeeID, DayNo, TimeIn, TimeOut, BreakTime FROM " & HRTblPath & "EmployeeSchedule WHERE EmployeeID = " & p_iEmpId & " AND DayNo = " & p_iDayOfWeek & " ORDER BY TimeIn ASC"

    '    PopulateDataset2(dtAdapter, dtSet, SQLSelect)

    '    For i = 0 To dtSet.Tables(0).Columns.Count - 1
    '        dtSet.Tables(0).Columns(i).ReadOnly = True
    '    Next

    '    Return dtSet

    'End Function

    'Public Sub ShowEmployeeSchedule(ByRef p_dataSet As DataSet)

    '    Dim HidCols() As String = {"EmployeeId", "DayNo"}
    '    Dim SQLSelect As String ', DateRngCond, AcctCond, FromLocCond, ToLocCond, TRNumCond, ThirdPCond, EventCond, Address3 As String
    '    Dim SummCol As String
    '    Dim i As Integer

    '    FillUltraGrid(UltraGrid2, p_dataSet, -1, HidCols, 0)
    '    UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
    '    UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    '    UltraGrid2.DisplayLayout.AutoFitColumns = False
    '    Dim b As New SizeF
    '    Dim g As Graphics = Me.CreateGraphics

    '    For i = 0 To UltraGrid2.DisplayLayout.Bands(0).Columns.Count - 1
    '        UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = True
    '        'UltraGrid2.DisplayLayout.Bands(0).Columns(i).PerformAutoResize()

    '        b = g.MeasureString(UltraGrid2.DisplayLayout.Bands(0).Columns(i).ToString, UltraGrid2.Font)
    '        UltraGrid2.DisplayLayout.Bands(0).Columns(i).Width = b.Width + 20 'UltraGrid2.DisplayLayout.Bands(0).Columns(i).ToString.Length

    '        UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
    '    Next


    '    'UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

    'End Sub
    'Private Sub dpWorked_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpWorked.ValueChanged
    '    If cboEmpId.Text.Trim <> "" Then
    '        'Populate DataGrid2
    '        ShowEmployeeSchedule(GetEmployeeSchedule(cboEmpId.Text.Trim, dpWorked.DateTime.DayOfWeek))
    '    End If
    'End Sub

End Class
