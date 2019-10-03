Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class SigmaPrint
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCalc As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Report1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Report1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.DTPicker2, Me.Label1, Me.DTPicker1})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(728, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(369, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "To Date:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPicker2
        '
        Me.DTPicker2.Location = New System.Drawing.Point(438, 15)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(104, 20)
        Me.DTPicker2.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(138, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "From Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPicker1
        '
        Me.DTPicker1.Location = New System.Drawing.Point(206, 14)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(104, 20)
        Me.DTPicker1.TabIndex = 35
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(645, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 21)
        Me.btnExit.TabIndex = 39
        Me.btnExit.Text = "&Exit"
        '
        'btnCalc
        '
        Me.btnCalc.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCalc.Location = New System.Drawing.Point(3, 16)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(101, 21)
        Me.btnCalc.TabIndex = 0
        Me.btnCalc.Text = "Ca&lc && Pre&view"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrint, Me.btnExit, Me.btnCalc})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 397)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(728, 40)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Report1
        '
        Me.Report1.ActiveViewIndex = -1
        Me.Report1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Report1.Location = New System.Drawing.Point(0, 48)
        Me.Report1.Name = "Report1"
        Me.Report1.ReportSource = Nothing
        Me.Report1.Size = New System.Drawing.Size(728, 349)
        Me.Report1.TabIndex = 3
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(104, 16)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(104, 21)
        Me.btnPrint.TabIndex = 40
        Me.btnPrint.Text = "&Print"
        '
        'SigmaPrint
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(728, 437)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Report1, Me.GroupBox2, Me.GroupBox1})
        Me.Name = "SigmaPrint"
        Me.Text = "SigmaPrint"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub SigmaPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = WeightVars.WEIGHTTblPath & Me.Tag
            End If
        End If

        Me.KeyPreview = True

        'Report1.Enabled = False

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        DTPicker1.Format = DateTimePickerFormat.Custom
        DTPicker1.CustomFormat = "MM/dd/yyyy"
        DTPicker1.Value = Date.Today
        DTPicker2.Format = DateTimePickerFormat.Custom
        DTPicker2.CustomFormat = "MM/dd/yyyy"
        DTPicker2.Value = Date.Today

    End Sub

    Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
        Dim paramDiscreteValue1 As New ParameterDiscreteValue()
        Dim paramDiscreteValue2 As New ParameterDiscreteValue()

        Dim paramFields1 As New ParameterFields()

        Dim paramField1 As New ParameterField()
        Dim paramField2 As New ParameterField()


        Report1.Enabled = True
        Report1.ReportSource = Nothing
        Report1.ParameterFieldInfo = Nothing
        Report1.ShowRefreshButton = False


        If Not RepDoc Is Nothing Then
            'RepDoc.Dispose()
            RepDoc = Nothing
        End If

        RepDoc = New crSigmaPrint()

        Report1.DisplayGroupTree = False
        RepDoc.RecordSelectionFormula = "{DailyEntry.ParentID} > 0 and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "')"
        'RepDoc.SetDataSource(dtSet2) ' ("Provider = SQLOLEDB; DATA SOURCE = 192.80.90.200; INITIAL CATALOG = WEIGHTMODULE; USER ID = sa; PASSWORD = 4183771")

        paramDiscreteValue1.Value = Format(DTPicker1.Value, "MM/dd/yyyy")
        paramDiscreteValue2.Value = Format(DTPicker2.Value, "MM/dd/yyyy")

        paramField1.ParameterFieldName = "fromdate"
        paramField1.CurrentValues.Add(paramDiscreteValue1)

        paramField2.ParameterFieldName = "ToDate"
        paramField2.CurrentValues.Add(paramDiscreteValue2)

        paramFields1.Add(paramField1)
        paramFields1.Add(paramField2)

        Report1.ParameterFieldInfo = paramFields1

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        SetConnectionInfo("Manifests", "Weight2.DSN", WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepDoc)
        SetConnectionInfo("DAILYENTRY", "Weight2.DSN", WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepDoc)

        Report1.ReportSource = RepDoc '"AcctWGTReport.RPT"

        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub SetConnectionInfo(ByVal table As String, _
            ByVal server As String, ByVal database As String, _
            ByVal user As String, ByVal password As String, ByRef ReportDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument)

        ' Get the ConnectionInfo Object.
        Dim logOnInfo As New TableLogOnInfo()
        logOnInfo = ReportDoc.Database.Tables.Item(table).LogOnInfo

        'Dim connectionInfo As New ConnectionInfo()
        'connectionInfo = ReportDoc.Database.Tables.Item(table).LogOnInfo.ConnectionInfo

        ' Set the Connection parameters.
        With logOnInfo
            .ConnectionInfo.DatabaseName = database
            .ConnectionInfo.ServerName = server 'Karina 6.22.2005 unchecked
            .ConnectionInfo.UserID = user 'Karina 6.22.2005 unchecked
            .ConnectionInfo.Password = password
        End With

        'logOnInfo.ConnectionInfo = ConnectionInfo

        ReportDoc.Database.Tables.Item(table).ApplyLogOnInfo(logOnInfo)

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'ReportViewer1.PrintReport()
        Dim x As New PrintDialog
        Dim FromPage, ToPage, Count As Int16
        Dim Collated As Boolean = False

        If Report1.ReportSource Is Nothing Then
            MsgBox("No report is being displayed on screen. Please run a report first.")
            Exit Sub
        End If

        If x.ShowDialog(Me) = DialogResult.OK Then
            If x.rbAll.Checked Then
                FromPage = 1
                ToPage = 999
            Else
                FromPage = Val(x.tbFrom.Text)
                ToPage = Val(x.tbTo.Text)
            End If
            Count = Val(x.Copies.Text)
            If Count = 0 Then Count = 1
            Collated = x.cbCollate.Checked

            x.Dispose()
            x = Nothing
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'PrepareRepDoc()
            RepDoc.PrintToPrinter(Count, Collated, FromPage, ToPage)

            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub


End Class
