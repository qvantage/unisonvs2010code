Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ExpenseBreakdownForm
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents cvReport1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ulblSelectDivision As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ucboDivision As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ulblSelectPayroll As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtPayrollEnding As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cvReport1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.udtPayrollEnding = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.ulblSelectPayroll = New Infragistics.Win.Misc.UltraLabel
        Me.ucboDivision = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ulblSelectDivision = New Infragistics.Win.Misc.UltraLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.GroupBox1.SuspendLayout()
        CType(Me.udtPayrollEnding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cvReport1
        '
        Me.cvReport1.ActiveViewIndex = -1
        Me.cvReport1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cvReport1.Location = New System.Drawing.Point(3, 16)
        Me.cvReport1.Name = "cvReport1"
        Me.cvReport1.ReportSource = Nothing
        Me.cvReport1.Size = New System.Drawing.Size(772, 484)
        Me.cvReport1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.udtPayrollEnding)
        Me.GroupBox1.Controls.Add(Me.ulblSelectPayroll)
        Me.GroupBox1.Controls.Add(Me.ucboDivision)
        Me.GroupBox1.Controls.Add(Me.ulblSelectDivision)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 48)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(379, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Display"
        '
        'udtPayrollEnding
        '
        Me.udtPayrollEnding.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtPayrollEnding.Location = New System.Drawing.Point(276, 17)
        Me.udtPayrollEnding.Name = "udtPayrollEnding"
        Me.udtPayrollEnding.Size = New System.Drawing.Size(89, 21)
        Me.udtPayrollEnding.TabIndex = 9
        Me.udtPayrollEnding.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'ulblSelectPayroll
        '
        Me.ulblSelectPayroll.Location = New System.Drawing.Point(167, 16)
        Me.ulblSelectPayroll.Name = "ulblSelectPayroll"
        Me.ulblSelectPayroll.Size = New System.Drawing.Size(107, 23)
        Me.ulblSelectPayroll.TabIndex = 8
        Me.ulblSelectPayroll.Text = "Payroll Ending Date:"
        '
        'ucboDivision
        '
        Me.ucboDivision.DisplayMember = ""
        Me.ucboDivision.Location = New System.Drawing.Point(60, 17)
        Me.ucboDivision.Name = "ucboDivision"
        Me.ucboDivision.Size = New System.Drawing.Size(88, 21)
        Me.ucboDivision.TabIndex = 7
        Me.ucboDivision.Tag = ".Division...Divisions.Division.Division"
        Me.ucboDivision.ValueMember = ""
        '
        'ulblSelectDivision
        '
        Me.ulblSelectDivision.Location = New System.Drawing.Point(9, 16)
        Me.ulblSelectDivision.Name = "ulblSelectDivision"
        Me.ulblSelectDivision.Size = New System.Drawing.Size(49, 23)
        Me.ulblSelectDivision.TabIndex = 6
        Me.ulblSelectDivision.Text = "Division:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cvReport1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(778, 503)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ExpenseBreakdownForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ExpenseBreakdownForm"
        Me.Text = "Expense Breakdown Form"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.udtPayrollEnding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public strDivision As String

    Private _strDbConnection As String = Nothing
    Private _strSqlCommand As String = Nothing
    Private _oRpt As ExpenseBreakdownReport = Nothing
    Private _clsWorkDate As clsWorkDate
    Private _dt As Date
    Private _freq As String
    Private _wed As String
    Private DivisionChanged As Boolean = False

    Public Property SqlCommand() As String
        Get
            SqlCommand = _strSqlCommand
        End Get
        Set(ByVal Value As String)
            _strSqlCommand = Value
        End Set
    End Property

    Protected ReadOnly Property Report() As ExpenseBreakdownReport
        Get
            If IsNothing(_oRpt) Then
                _oRpt = New ExpenseBreakdownReport
            End If
            Report = _oRpt
        End Get
    End Property

    Private Sub ucboDivision_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDivision.ValueChanged
        'If DivisionChanged = False Then Exit Sub
        If ucboDivision.Text = "" Then
            strDivision = ""
            udtPayrollEnding.Value = Nothing
            Exit Sub
        End If
        strDivision = ucboDivision.Value
        InitWorkDate()
        'If _iValueChanged >= 2 Then _iValueChanged = 1
        udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(Date.Now)

    End Sub

    Private Sub ucboDivision_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDivision.TextChanged
        DivisionChanged = True
    End Sub

    Private Sub udtPayrollEnding_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udtPayrollEnding.ValueChanged
        '_iValueChanged += 1
        'If _iValueChanged > 2 Then
        If udtPayrollEnding.Text.IndexOf(udtPayrollEnding.PromptChar) >= 0 Then
            Exit Sub
        End If
        If ucboDivision.Text <> "" And Not _clsWorkDate Is Nothing Then
            Dim dt As Date
            dt = _clsWorkDate.PayrollEndDate(udtPayrollEnding.Value)
            If dt <> udtPayrollEnding.Value Then
                udtPayrollEnding.Value = dt
            End If
        End If
        'End If
    End Sub

    Private Sub udtPayrollEnding_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtPayrollEnding.Leave
        udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(udtPayrollEnding.Value)
    End Sub

    Private Sub udtPayrollEnding_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles udtPayrollEnding.Validating
        ' Per following logic, the check was removed.
        'The general logic is that If AN EMPLOYEE is being PROCESSED, we can not input any TIME_CARD data for the 
        'processed Payroll Ending for
        'the DeptNo processed. 



        'If (_cValidate.Range(CDate(dpWorked.Value), past, future) = False) Then SetError(dpWorked, e, "Invalid Date Range")

        'Prepare to use the returned data values
        ''Dim strSQL As String
        ''Dim dtaCbo As New SqlDataAdapter
        ''Dim dtSet As DataSet
        ''Dim dtView As New DataView
        ''Dim dtRow As DataRow

        'udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(udtPayrollEnding.Value)

        ''strSQL = "select count(*) matches from " & HRTblPath & "processedpayrollendings where PayrollEnding = CAST('" & CDate(udtPayrollEnding.Value).ToShortDateString & "' AS DATETIME) and Company = '" & ucboDivision.Value & "' and Processed = 1"

        ''PopulateDataset2(dtaCbo, dtSet, strSQL)

        ''dtView.Table = dtSet.Tables(0)
        ''dtRow = dtView.Table.Rows(0)

        ''If CInt(dtRow("matches")) > 0 Then
        ''SetError(udtPayrollEnding, e, "Pay Period Closed to Further Processing")
        ''MsgBox("This payroll is processed and no more inputs are allowed.")
        ''End If
        ''dtView.Dispose()
        ''dtView = Nothing
        ''dtSet.Dispose()
        ''dtSet = Nothing
        ''dtaCbo.Dispose()
        ''dtaCbo = Nothing

    End Sub

    Private Sub udtPayrollEnding_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtPayrollEnding.Validated
        ClearError(udtPayrollEnding)
    End Sub

    Private Sub ExpenseBreakdownForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated ' Code Snippet that brings form under UnisonAdmin control
        Me.CenterToScreen()

        FillUCombo(ucboDivision, "CFC", , , HRTblPath)

        udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(Date.Now)

        'SetCurrentValuesForParameterField(rptTimeCardLabels)

        'CrystalReportViewer1.ReportSource = rptTimeCardLabels

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim strConn, strConnBak As String

        'Prepare the SqlCommand for the Report
        Dim strSqlCommand As String

        strSqlCommand = "select * from " & HRTblPath & "ExpenseBreakdown where PayrollDate = '" & CDate(udtPayrollEnding.Value).ToShortDateString & "' and Company = '" & ucboDivision.Value & "' ORDER BY Company, Office, EmployeeID, [description]"

        SqlCommand = strSqlCommand

        strConn = strConnection2.Replace("@DB", CFGDBName)
        strConn = strConn.Replace("@USER", CFGDBUser)
        strConn = strConn.Replace("@PASS", CFGDBPass)

        strConnBak = strConnection
        strConnection = strConn
        sqlConn.ConnectionString = strConn

        cvReport1.Enabled = False

        Dim connLocal As New SqlConnection(strConnection)
        Dim daLocal As New SqlDataAdapter
        Dim dsData As New ExpenseBreakdownDS

        daLocal.SelectCommand = New SqlCommand

        With daLocal.SelectCommand
            .Connection = connLocal
            .CommandType = CommandType.Text
            .CommandText = SqlCommand
        End With

        Try
            _oRpt = Nothing

            connLocal.Open()

            With daLocal
                .AcceptChangesDuringFill = True
                .MissingSchemaAction = MissingSchemaAction.AddWithKey
                .Fill(dsData, "ExpenseBreakdown")
                Report.SetDataSource(dsData)
                Report.SummaryInfo.ReportTitle = "Expense Breakdown"
            End With

        Catch ex As Exception

            MsgBox("Error:  " & ex.Message, MsgBoxStyle.Critical, "")

        End Try

        With cvReport1

            .Enabled = True
            .ReportSource = Nothing
            .ParameterFieldInfo = Nothing
            .ShowRefreshButton = False
            .DisplayGroupTree = False

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            .ReportSource = Report
            Me.Cursor = System.Windows.Forms.Cursors.Default

        End With

        connLocal.Close()
        strConnection = strConnBak

    End Sub

    Private Sub InitWorkDate()

        If Not IsNothing(_clsWorkDate) Then _clsWorkDate = Nothing

        'Prepare to use the returned data values
        Dim strSQL As String
        Dim dtaCbo As New SqlDataAdapter
        Dim dtSet As DataSet
        Dim dtView As New DataView
        Dim dtRow As DataRow

        strSQL = "SELECT InitialPayPeriodEnding, PayPeriodFreq, WeekEndingDay FROM " & HRTblPath & "divisions WHERE division = '" & strDivision & "'"

        PopulateDataset2(dtaCbo, dtSet, strSQL)

        dtView.Table = dtSet.Tables(0)
        dtRow = dtView.Table.Rows(0)
        _dt = CDate(dtRow("InitialPayPeriodEnding"))
        _freq = dtRow("PayPeriodFreq")
        _wed = dtRow("WeekEndingDay")
        '_clsWorkDate = New clsWorkDate(CDate(dtRow("InitialPayPeriodEnding")), dtRow("PayPeriodFreq"), dtRow("WeekEndingDay"))
        _clsWorkDate = New clsWorkDate(_dt, _freq, _wed)


        'clean up, no longer needed
        dtRow = Nothing

        dtView.Dispose()
        dtView = Nothing
        dtSet.Dispose()
        dtSet = Nothing
        dtaCbo.Dispose()
        dtaCbo = Nothing

    End Sub
    Private Sub SetError(ByRef ctl As Control, ByVal e As System.ComponentModel.CancelEventArgs, ByVal str As String)
        Beep()
        e.Cancel = True
        Me.ErrorProvider1.SetError(ctl, str)
    End Sub

    Private Sub ClearError(ByRef ctl As Control)
        Me.ErrorProvider1.SetError(ctl, "")
    End Sub

End Class
