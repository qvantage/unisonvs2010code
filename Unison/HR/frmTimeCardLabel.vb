Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections
Imports System.Data.SqlClient

Public Class frmTimeCardLabel
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        ConfigureAccess()
        ConfigureCrystalReports()

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
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents udtPayrollEnding As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ucboDivision As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ulblSelectDivision As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ulblSelectPayroll As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.ulblSelectPayroll = New Infragistics.Win.Misc.UltraLabel
        Me.ulblSelectDivision = New Infragistics.Win.Misc.UltraLabel
        Me.ucboDivision = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.udtPayrollEnding = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.GroupBox1.SuspendLayout()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtPayrollEnding, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ulblSelectPayroll)
        Me.GroupBox1.Controls.Add(Me.ulblSelectDivision)
        Me.GroupBox1.Controls.Add(Me.ucboDivision)
        Me.GroupBox1.Controls.Add(Me.udtPayrollEnding)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(244, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Display"
        '
        'ulblSelectPayroll
        '
        Me.ulblSelectPayroll.Location = New System.Drawing.Point(17, 54)
        Me.ulblSelectPayroll.Name = "ulblSelectPayroll"
        Me.ulblSelectPayroll.Size = New System.Drawing.Size(112, 23)
        Me.ulblSelectPayroll.TabIndex = 6
        Me.ulblSelectPayroll.Text = "Payroll Ending Date:"
        '
        'ulblSelectDivision
        '
        Me.ulblSelectDivision.Location = New System.Drawing.Point(81, 20)
        Me.ulblSelectDivision.Name = "ulblSelectDivision"
        Me.ulblSelectDivision.Size = New System.Drawing.Size(48, 23)
        Me.ulblSelectDivision.TabIndex = 5
        Me.ulblSelectDivision.Text = "Division:"
        '
        'ucboDivision
        '
        Me.ucboDivision.DisplayMember = ""
        Me.ucboDivision.Location = New System.Drawing.Point(128, 21)
        Me.ucboDivision.Name = "ucboDivision"
        Me.ucboDivision.Size = New System.Drawing.Size(88, 21)
        Me.ucboDivision.TabIndex = 4
        Me.ucboDivision.Tag = ".Division...Divisions.Division.Division"
        Me.ucboDivision.ValueMember = ""
        '
        'udtPayrollEnding
        '
        Me.udtPayrollEnding.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtPayrollEnding.Location = New System.Drawing.Point(128, 55)
        Me.udtPayrollEnding.Name = "udtPayrollEnding"
        Me.udtPayrollEnding.Size = New System.Drawing.Size(88, 21)
        Me.udtPayrollEnding.TabIndex = 3
        Me.udtPayrollEnding.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
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
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmTimeCardLabel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmTimeCardLabel"
        Me.Tag = ""
        Me.Text = "Print Time Card Labels"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtPayrollEnding, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public strDivision As String

    'Private rptTimeCardLabels As TimeCardLabels2
    Private rptTimeCardLabels As TimeCardLabels3x1
    Private _clsWorkDate As clsWorkDate
    Private _dt As Date
    Private _freq As String
    Private _wed As String
    Dim DivisionChanged As Boolean = False

    Private Sub ConfigureCrystalReports()

        'rptTimeCardLabels = New TimeCardLabels2
        rptTimeCardLabels = New TimeCardLabels3x1

        Dim myConnectionInfo As New ConnectionInfo

        myConnectionInfo.ServerName = IPAddr
        myConnectionInfo.DatabaseName = HRDBName
        myConnectionInfo.UserID = "unison"
        myConnectionInfo.Password = "unison"

        SetDBLogonForReport(myConnectionInfo, rptTimeCardLabels)

        CrystalReportViewer1.Enabled = True
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.ParameterFieldInfo = Nothing
        CrystalReportViewer1.ShowRefreshButton = False
        CrystalReportViewer1.DisplayGroupTree = False

    End Sub

    Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo, ByVal myReportDocument As ReportDocument)

        Dim myTables As Tables = myReportDocument.Database.Tables
        Dim myTable As CrystalDecisions.CrystalReports.Engine.Table

        'Set the "live" connection for the main Report
        For Each myTable In myTables

            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo

            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            'myTable.ApplyLogOnInfo(myTableLogonInfo)
            myTable.LogOnInfo.ConnectionInfo.DatabaseName = HRDBName
            myTable.LogOnInfo.ConnectionInfo.ServerName = IPAddr
            myTable.LogOnInfo.ConnectionInfo.UserID = "unison"
            myTable.LogOnInfo.ConnectionInfo.Password = "unison"
            myTable.LogOnInfo.ConnectionInfo.Type = ConnectionInfoType.Query

        Next

        'Set the "live" connection for all sub-reports
        For Each section As CrystalDecisions.CrystalReports.Engine.Section In myReportDocument.ReportDefinition.Sections

            For Each reportObject As CrystalDecisions.CrystalReports.Engine.ReportObject In section.ReportObjects

                If reportObject.Kind = ReportObjectKind.SubreportObject Then

                    Dim subReport As SubreportObject = reportObject
                    Dim subDocument As ReportDocument = subReport.OpenSubreport(subReport.SubreportName)

                    For Each table As CrystalDecisions.CrystalReports.Engine.Table In subDocument.Database.Tables

                        table.LogOnInfo.ConnectionInfo.DatabaseName = HRDBName
                        table.LogOnInfo.ConnectionInfo.ServerName = IPAddr
                        table.LogOnInfo.ConnectionInfo.UserID = "unison"
                        table.LogOnInfo.ConnectionInfo.Password = "unison"

                    Next

                End If

            Next

        Next

    End Sub

    Private Sub SetCurrentValuesForParameterField_X1(ByVal myReportDocument As ReportDocument)

        myReportDocument.Refresh()

        Dim alCompanyArray As New ArrayList
        Dim alPayrollEndDate As New ArrayList

        alCompanyArray.Add("TOP")
        alPayrollEndDate.Add("09/02/07")

        Dim currentCompanyValues As New ParameterValues
        Dim currentPayrollEndDateValues As New ParameterValues

        Dim submittedValue As Object

        For Each submittedValue In alCompanyArray
            Dim myParameterDiscreteValue As New ParameterDiscreteValue
            myParameterDiscreteValue.Value = submittedValue.ToString
            currentCompanyValues.Add(myParameterDiscreteValue)
        Next

        For Each submittedValue In alPayrollEndDate
            Dim myParameterDiscreteValue As New ParameterDiscreteValue
            myParameterDiscreteValue.Value = submittedValue.ToString
            currentPayrollEndDateValues.Add(myParameterDiscreteValue)
        Next

        Dim myParameterFieldDefinitions As ParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields
        Dim myCompanyParameterDefinition As ParameterFieldDefinition = myParameterFieldDefinitions("@p_company")
        Dim myPayrollEndDateParameterDefinition As ParameterFieldDefinition = myParameterFieldDefinitions("@p_payrollEndDate")

        myCompanyParameterDefinition.ApplyCurrentValues(currentCompanyValues)
        myPayrollEndDateParameterDefinition.ApplyCurrentValues(currentPayrollEndDateValues)

    End Sub

    Private Sub SetCurrentValuesForParameterField(ByVal myReportDocument As ReportDocument)

        myReportDocument.Refresh()

        Dim alCompanyArray As New ArrayList
        Dim alPayrollEndDate As New ArrayList

        alCompanyArray.Add(ucboDivision.Text)
        alPayrollEndDate.Add(udtPayrollEnding.Value)

        Dim currentCompanyValues As New ParameterValues
        Dim currentPayrollEndDateValues As New ParameterValues

        Dim submittedValue As Object

        For Each submittedValue In alCompanyArray
            Dim myParameterDiscreteValue As New ParameterDiscreteValue
            myParameterDiscreteValue.Value = submittedValue.ToString
            currentCompanyValues.Add(myParameterDiscreteValue)
        Next

        For Each submittedValue In alPayrollEndDate
            Dim myParameterDiscreteValue As New ParameterDiscreteValue
            myParameterDiscreteValue.Value = submittedValue.ToString
            currentPayrollEndDateValues.Add(myParameterDiscreteValue)
        Next

        Dim myParameterFieldDefinitions As ParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields
        Dim myCompanyParameterDefinition As ParameterFieldDefinition = myParameterFieldDefinitions("@p_company")
        Dim myPayrollEndDateParameterDefinition As ParameterFieldDefinition = myParameterFieldDefinitions("@p_payrollEndDate")

        myCompanyParameterDefinition.ApplyCurrentValues(currentCompanyValues)
        myPayrollEndDateParameterDefinition.ApplyCurrentValues(currentPayrollEndDateValues)

    End Sub

    Private Sub ConfigureAccess() 'Called from this Form's New Method.  A good candidate for Global.vb.
        AddHandler Me.Activated, AddressOf Form_Activated
        AddHandler Me.KeyUp, AddressOf Form_KeyUp
    End Sub

    Private Sub frmTimeCardLabel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        FillUCombo(ucboDivision, "CFC", , , HRTblPath)

        udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(Date.Now)

        SetCurrentValuesForParameterField(rptTimeCardLabels)

        ConfigureCrystalReports()

        CrystalReportViewer1.ReportSource = rptTimeCardLabels

    End Sub

    Public Sub LateLoad()
        ' Example if you want to do Access Validation Before Loading.  The Load would do nothing and this
        ' Sub would be called from Form_Activated as sender.LateLoad().  If you go this route, every form
        ' must have a LateLoad sub-routine.
        FillUCombo(ucboDivision, "CFC", , , HRTblPath)

        udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(Date.Now)

        SetCurrentValuesForParameterField(rptTimeCardLabels)

        CrystalReportViewer1.ReportSource = rptTimeCardLabels
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
        CrystalReportViewer1.ReportSource = Nothing
        SetCurrentValuesForParameterField(rptTimeCardLabels)
        CrystalReportViewer1.ReportSource = rptTimeCardLabels
    End Sub

End Class
