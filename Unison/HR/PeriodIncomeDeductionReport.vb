Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class PeriodIncomeDeductionReport
    Inherits System.Windows.Forms.Form

    Dim RepDoc As ReportDocument

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
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Report1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents ucboCompany As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label28 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.Report1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ucboCompany = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label28 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ucboCompany)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Controls.Add(Me.UltraDate1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(656, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 2
        Me.btnDisplay.Text = "D&isplay"
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(96, 12)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate1.TabIndex = 0
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 16)
        Me.Label11.TabIndex = 166
        Me.Label11.Text = "Period Ending:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Report1
        '
        Me.Report1.ActiveViewIndex = -1
        Me.Report1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Report1.Location = New System.Drawing.Point(0, 72)
        Me.Report1.Name = "Report1"
        Me.Report1.ReportSource = Nothing
        Me.Report1.Size = New System.Drawing.Size(752, 389)
        Me.Report1.TabIndex = 1
        '
        'ucboCompany
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboCompany.Appearance = Appearance1
        Me.ucboCompany.AutoEdit = False
        Me.ucboCompany.DisplayMember = ""
        Me.ucboCompany.Location = New System.Drawing.Point(96, 40)
        Me.ucboCompany.Name = "ucboCompany"
        Me.ucboCompany.Size = New System.Drawing.Size(160, 21)
        Me.ucboCompany.TabIndex = 1
        Me.ucboCompany.Tag = ".Company..1.Companies.Company.Company"
        Me.ucboCompany.ValueMember = ""
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(8, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(85, 16)
        Me.Label28.TabIndex = 171
        Me.Label28.Text = "Company:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PeriodIncomeDeductionReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(752, 461)
        Me.Controls.Add(Me.Report1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PeriodIncomeDeductionReport"
        Me.Text = "Period Income & Deduction Report"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PeriodIncomeDeductionReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If

        Me.KeyPreview = True

        'SetConnectionInfo("CUSTOMER", "weight", "WeightModule", "weight", "weight")
        'SetConnectionInfo("DAILYENTRY", "weight", "WeightModule", "weight", "weight")

        Report1.Enabled = False

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        UltraDate1.Nullable = True
        UltraDate1.Value = Date.Today 'DateAdd(DateInterval.Day, -1, Date.Today)
        UltraDate1.FormatString = "MM/dd/yyyy"

        FillUCombo(ucboCompany, "", "", "", HRTblPath, False, True)
        AddHandler ucboCompany.Leave, AddressOf UCbo_Leave

        'UltraDate2.Nullable = True
        'UltraDate2.Value = Date.Today 'DateAdd(DateInterval.Day, -1, Date.Today)
        'UltraDate2.FormatString = "MM/dd/yyyy"

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        If ucboCompany.Value Is Nothing Then
            MsgBox("Please select a Company.")
            Exit Sub
        End If

        Dim paramDiscreteValue1 As New ParameterDiscreteValue
        Dim paramDiscreteValue2 As New ParameterDiscreteValue

        Dim paramFields1 As New ParameterFields

        Dim paramField1 As New ParameterField
        Dim paramField2 As New ParameterField


        'If Not RepDoc.IsLoaded() Then
        '    '    RepDoc.Load()
        'Else
        '    RepDoc.Close()
        '    '    RepDoc.Load()
        'End If
        If Not RepDoc Is Nothing Then
            RepDoc.Dispose()
            RepDoc = Nothing
        End If

        RepDoc = New PeriodIncomeDeductionCR


        ''      SelectSQL = "SELECT DailyEntry.AccountID, CUSTOMER.STREET, CUSTOMER.CITYNAME, CUSTOMER.STATE, CUSTOMER.ZIPCODE, CUSTOMER.PHONE1, DailyEntry.TranDate, DailyEntry.Weight, DailyEntry.WeightLimit, DailyEntry.OWCharge, DailyEntry.ManifestName, DailyEntry.Charge, DailyEntry.AccountName, DailyEntry.ManifestID " & _
        ''" FROM   WeightModule.dbo.DailyEntry DailyEntry INNER JOIN WeightModule.dbo.CUSTOMER CUSTOMER ON DailyEntry.AccountID=CUSTOMER.ID " & _
        ''" ORDER BY DailyEntry.AccountID, DailyEntry.ManifestID"
        ''      PopulateDataset2(dtAdapter, dtSet2, SelectSQL)

        RepDoc.RecordSelectionFormula = "{EmployeePeriodIncomeDeductions;1.Company} = '" & ucboCompany.Value & "'"  '"{EmployeeMiscChargesView.PayrollDate} >= datevalue('" & UltraDate1.Text & "') and {EmployeeMiscChargesView.PayrollDate} < datevalue('" & DateAdd(DateInterval.Day, 1, UltraDate1.Value) & "')"

        'RepDoc.SetDataSource(dtSet2) ' ("Provider = SQLOLEDB; DATA SOURCE = 192.80.90.200; INITIAL CATALOG = WEIGHTMODULE; USER ID = sa; PASSWORD = 4183771")

        paramDiscreteValue1.Value = UltraDate1.Text 'Format(UltraDate1.Text, "MM/dd/yyyy")
        paramDiscreteValue2.Value = UltraDate1.Value

        paramField1.ParameterFieldName = "PeriodDate"
        paramField1.CurrentValues.Add(paramDiscreteValue1)

        paramField2.ParameterFieldName = "@PAYDATE"
        paramField2.CurrentValues.Add(paramDiscreteValue2)

        paramFields1.Add(paramField1)
        paramFields1.Add(paramField2)



        'SetConnectionInfo("CUSTOMER", "weight", "WeightModule", "weight", "weight")
        'SetConnectionInfo("DAILYENTRY", "weight", "WeightModule", "weight", "weight")

        'SetConnectionInfo("EmployeeMiscChargesView", "67.112.189.226", HRDBName, HRDBUser, HRDBPass, RepDoc)
        'SetConnectionInfo("EmployeeMiscChargesView", "UN_HR.DSN", HRDBName, HRDBUser, HRDBPass, RepDoc)
        'SetConnectionInfo("EmployeePeriodIncomeDeductions;1", "C :\Program Files\Common Files\ODBC\Data Sources\UN_HR.dsn", HRDBName, AppDBUser, AppDBPass, RepDoc)
        'SetConnectionInfo("DAILYENTRY", "Weight2.DSN", WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepDoc) 'Weightmodule2

        Report1.Enabled = True
        Report1.ReportSource = Nothing
        Report1.ParameterFieldInfo = Nothing
        Report1.ShowRefreshButton = False

        Report1.DisplayGroupTree = False
        Report1.ParameterFieldInfo = paramFields1
        'SetConnectionInfo("EmployeePeriodIncomeDeductions;1", "", "", "", AppDBPass, RepDoc)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        Report1.ReportSource = RepDoc '"AcctWGTReport.RPT"

        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub SetConnectionInfo(ByVal table As String, _
        ByVal server As String, ByVal database As String, _
        ByVal user As String, ByVal password As String, ByRef ReportDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument)

        ' Get the ConnectionInfo Object.
        Dim logOnInfo As New TableLogOnInfo
        logOnInfo = ReportDoc.Database.Tables.Item(table).LogOnInfo

        'Dim connectionInfo As New ConnectionInfo()
        'connectionInfo = ReportDoc.Database.Tables.Item(table).LogOnInfo.ConnectionInfo

        ' Set the Connection parameters.
        With logOnInfo
            If database <> "" Then
                .ConnectionInfo.DatabaseName = database
            End If
            If server <> "" Then
                .ConnectionInfo.ServerName = server
            End If
            If user <> "" Then
                .ConnectionInfo.UserID = user
            End If
            If password <> "" Then
                .ConnectionInfo.Password = password
            End If
        End With

        'logOnInfo.ConnectionInfo = ConnectionInfo

        ReportDoc.Database.Tables.Item(table).ApplyLogOnInfo(logOnInfo)

    End Sub

End Class
