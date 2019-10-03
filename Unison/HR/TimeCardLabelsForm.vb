Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections
Imports System.Data.SqlClient


Public Class TimeCardLabelsForm
    Inherits System.Windows.Forms.Form

    Private _dsTimeCardLabels As TimeCardLabelsDS
    Private _oRpt As TimeCardLabelsReport

    Public strDivision As String
    Private _clsWorkDate As clsWorkDate
    Private _dt As Date
    Private _freq As String
    Private _wed As String
    Dim DivisionChanged As Boolean = False

    Public Property DataSource() As TimeCardLabelsDS
        Get
            DataSource = _dsTimeCardLabels
        End Get
        Set(ByVal Value As TimeCardLabelsDS)
            _dsTimeCardLabels = Value
        End Set
    End Property

    Protected ReadOnly Property Report() As TimeCardLabelsReport
        Get
            If IsNothing(_oRpt) Then
                _oRpt = New TimeCardLabelsReport
            End If
            Report = _oRpt
        End Get
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ucboDivision As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents udtPayrollEnding As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.udtPayrollEnding = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.ucboDivision = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.GroupBox1.SuspendLayout()
        CType(Me.udtPayrollEnding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.udtPayrollEnding)
        Me.GroupBox1.Controls.Add(Me.ucboDivision)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(205, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        '
        'udtPayrollEnding
        '
        Me.udtPayrollEnding.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtPayrollEnding.Location = New System.Drawing.Point(97, 61)
        Me.udtPayrollEnding.Name = "udtPayrollEnding"
        Me.udtPayrollEnding.Size = New System.Drawing.Size(88, 21)
        Me.udtPayrollEnding.TabIndex = 6
        Me.udtPayrollEnding.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'ucboDivision
        '
        Me.ucboDivision.DisplayMember = ""
        Me.ucboDivision.Location = New System.Drawing.Point(96, 20)
        Me.ucboDivision.Name = "ucboDivision"
        Me.ucboDivision.Size = New System.Drawing.Size(88, 21)
        Me.ucboDivision.TabIndex = 5
        Me.ucboDivision.Tag = ".Division...Divisions.Division.Division"
        Me.ucboDivision.ValueMember = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(792, 473)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 16)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReportSource = Nothing
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(786, 454)
        Me.CrystalReportViewer1.TabIndex = 1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TimeCardLabelsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "TimeCardLabelsForm"
        Me.Text = "TimeCardLabelsForm"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.udtPayrollEnding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TimeCardLabelsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        FillUCombo(ucboDivision, "CFC", , , HRTblPath)

        udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(Date.Now)
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

    Private Sub udtPayrollEnding_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles udtPayrollEnding.Validating
        ' Per following logic, the check was removed.
        'The general logic is that If AN EMPLOYEE is being PROCESSED, we can not input any TIME_CARD data for the 
        'processed Payroll Ending for
        'the DeptNo processed. 



        'If (_cValidate.Range(CDate(dpWorked.Value), past, future) = False) Then SetError(dpWorked, e, "Invalid Date Range")

        'Prepare to use the returned data values
        Dim strSQL As String
        Dim dtaCbo As New SqlDataAdapter
        Dim dtSet As DataSet
        Dim dtView As New DataView
        Dim dtRow As DataRow

        'udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(udtPayrollEnding.Value)

        strSQL = "select count(*) matches from " & HRTblPath & "processedpayrollendings where PayrollEnding = CAST('" & CDate(udtPayrollEnding.Value).ToShortDateString & "' AS DATETIME) and Company = '" & ucboDivision.Value & "' and Processed = 1"

        PopulateDataset2(dtaCbo, dtSet, strSQL)

        dtView.Table = dtSet.Tables(0)
        dtRow = dtView.Table.Rows(0)

        If CInt(dtRow("matches")) > 0 Then
            SetError(udtPayrollEnding, e, "Pay Period Closed to Further Processing")
            MsgBox("This payroll is processed and no more inputs are allowed.")
        End If
        dtView.Dispose()
        dtView = Nothing
        dtSet.Dispose()
        dtSet = Nothing
        dtaCbo.Dispose()
        dtaCbo = Nothing

    End Sub

    Private Sub udtPayrollEnding_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtPayrollEnding.Validated
        ClearError(udtPayrollEnding)
    End Sub

    Private Sub SetError(ByRef ctl As Control, ByVal e As System.ComponentModel.CancelEventArgs, ByVal str As String)
        Beep()
        e.Cancel = True
        Me.ErrorProvider1.SetError(ctl, str)
    End Sub

    Private Sub ClearError(ByRef ctl As Control)
        Me.ErrorProvider1.SetError(ctl, "")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim strConn, strConnBak As String

        strConn = strConnection2.Replace("@DB", CFGDBName)
        strConn = strConn.Replace("@USER", CFGDBUser)
        strConn = strConn.Replace("@PASS", CFGDBPass)

        strConnBak = strConnection
        strConnection = strConn
        sqlConn.ConnectionString = strConn

        CrystalReportViewer1.Enabled = False

        Dim connLocal As New SqlConnection(strConnection)
        Dim daLocal As New SqlDataAdapter
        Dim dsData As New TimeCardLabelsDS

        daLocal.SelectCommand = New SqlCommand

        With daLocal.SelectCommand
            .Connection = connLocal
            .CommandType = CommandType.Text
            '.CommandText = SqlCommand
        End With

        Try

            connLocal.Open()

            With daLocal
                .AcceptChangesDuringFill = True
                .MissingSchemaAction = MissingSchemaAction.AddWithKey
                .Fill(dsData, "TimeCardCompliance")
                Report.SetDataSource(dsData)
                Report.SummaryInfo.ReportTitle = "Time Card Compliance Report"
            End With

        Catch ex As Exception

            MsgBox("Error:  " & ex.Message, MsgBoxStyle.Critical, "")

        End Try

        With CrystalReportViewer1

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
        'CrystalReportViewer1.Enabled = False

        'Report.SetDataSource(DataSource)
        'Report.SummaryInfo.ReportTitle = "Time Card Labels"

        'With CrystalReportViewer1

        '    .Enabled = True
        '    .ReportSource = Nothing
        '    .ParameterFieldInfo = Nothing
        '    .ShowRefreshButton = False
        '    .DisplayGroupTree = False

        '    .ReportSource = Report

        'End With

        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub
End Class
