Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Report
    Inherits System.Windows.Forms.Form
    'Dim RepDoc As New CrystalReport2()
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
    Friend WithEvents AcctSelection As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAcct As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AcctName As System.Windows.Forms.TextBox
    Friend WithEvents AcctID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents AcctSelection2 As System.Windows.Forms.RadioButton
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnPrintSum As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Report1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnRunDate As System.Windows.Forms.Button
    Friend WithEvents rbAcctGrp As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGroup As System.Windows.Forms.Button
    Friend WithEvents GroupID As System.Windows.Forms.TextBox
    Friend WithEvents Group As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnComet As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnGroup = New System.Windows.Forms.Button
        Me.GroupID = New System.Windows.Forms.TextBox
        Me.Group = New System.Windows.Forms.TextBox
        Me.rbAcctGrp = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnRunDate = New System.Windows.Forms.Button
        Me.btnPrintSum = New System.Windows.Forms.Button
        Me.btnRun = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnAcct = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.AcctName = New System.Windows.Forms.TextBox
        Me.AcctID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.AcctSelection2 = New System.Windows.Forms.RadioButton
        Me.AcctSelection = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Report1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnComet = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.rbAcctGrp)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.AcctSelection2)
        Me.GroupBox1.Controls.Add(Me.AcctSelection)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(848, 152)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnGroup)
        Me.GroupBox4.Controls.Add(Me.GroupID)
        Me.GroupBox4.Controls.Add(Me.Group)
        Me.GroupBox4.Location = New System.Drawing.Point(104, 96)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(432, 48)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'btnGroup
        '
        Me.btnGroup.Location = New System.Drawing.Point(192, 16)
        Me.btnGroup.Name = "btnGroup"
        Me.btnGroup.Size = New System.Drawing.Size(75, 21)
        Me.btnGroup.TabIndex = 88
        Me.btnGroup.Text = "Select"
        '
        'GroupID
        '
        Me.GroupID.Location = New System.Drawing.Point(312, 16)
        Me.GroupID.Name = "GroupID"
        Me.GroupID.Size = New System.Drawing.Size(24, 20)
        Me.GroupID.TabIndex = 87
        Me.GroupID.Tag = ".AcctGroupID"
        Me.GroupID.Text = ""
        Me.GroupID.Visible = False
        '
        'Group
        '
        Me.Group.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Group.Location = New System.Drawing.Point(12, 16)
        Me.Group.Name = "Group"
        Me.Group.Size = New System.Drawing.Size(152, 20)
        Me.Group.TabIndex = 86
        Me.Group.Tag = ".AcctGroup.view"
        Me.Group.Text = ""
        '
        'rbAcctGrp
        '
        Me.rbAcctGrp.Location = New System.Drawing.Point(8, 109)
        Me.rbAcctGrp.Name = "rbAcctGrp"
        Me.rbAcctGrp.Size = New System.Drawing.Size(80, 32)
        Me.rbAcctGrp.TabIndex = 4
        Me.rbAcctGrp.Text = "By Club"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnComet)
        Me.GroupBox3.Controls.Add(Me.btnPrint)
        Me.GroupBox3.Controls.Add(Me.btnRunDate)
        Me.GroupBox3.Controls.Add(Me.btnPrintSum)
        Me.GroupBox3.Controls.Add(Me.btnRun)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.DTPicker2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.DTPicker1)
        Me.GroupBox3.Location = New System.Drawing.Point(544, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(296, 136)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(112, 96)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 21)
        Me.btnPrint.TabIndex = 39
        Me.btnPrint.Text = "&Print"
        '
        'btnRunDate
        '
        Me.btnRunDate.Location = New System.Drawing.Point(200, 56)
        Me.btnRunDate.Name = "btnRunDate"
        Me.btnRunDate.Size = New System.Drawing.Size(88, 21)
        Me.btnRunDate.TabIndex = 38
        Me.btnRunDate.Text = "Run By Da&te"
        '
        'btnPrintSum
        '
        Me.btnPrintSum.Location = New System.Drawing.Point(200, 96)
        Me.btnPrintSum.Name = "btnPrintSum"
        Me.btnPrintSum.Size = New System.Drawing.Size(88, 21)
        Me.btnPrintSum.TabIndex = 37
        Me.btnPrintSum.Text = "Run S&ummary"
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(198, 16)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(91, 21)
        Me.btnRun.TabIndex = 2
        Me.btnRun.Text = "Run By P&lan"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "To Date:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPicker2
        '
        Me.DTPicker2.Location = New System.Drawing.Point(80, 62)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(104, 20)
        Me.DTPicker2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "From Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPicker1
        '
        Me.DTPicker1.Location = New System.Drawing.Point(80, 22)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(104, 20)
        Me.DTPicker1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAcct)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.AcctName)
        Me.GroupBox2.Controls.Add(Me.AcctID)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(102, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(432, 56)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(366, 24)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(58, 21)
        Me.btnAcct.TabIndex = 31
        Me.btnAcct.Text = "Select"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(126, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Acct. Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AcctName
        '
        Me.AcctName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AcctName.Enabled = False
        Me.AcctName.Location = New System.Drawing.Point(198, 24)
        Me.AcctName.Name = "AcctName"
        Me.AcctName.Size = New System.Drawing.Size(152, 20)
        Me.AcctName.TabIndex = 1
        Me.AcctName.Tag = ".AccountNAME.view"
        Me.AcctName.Text = ""
        '
        'AcctID
        '
        Me.AcctID.Location = New System.Drawing.Point(54, 24)
        Me.AcctID.Name = "AcctID"
        Me.AcctID.Size = New System.Drawing.Size(64, 20)
        Me.AcctID.TabIndex = 0
        Me.AcctID.Tag = ".AccountID"
        Me.AcctID.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Acct. ID:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AcctSelection2
        '
        Me.AcctSelection2.Location = New System.Drawing.Point(10, 56)
        Me.AcctSelection2.Name = "AcctSelection2"
        Me.AcctSelection2.Size = New System.Drawing.Size(83, 32)
        Me.AcctSelection2.TabIndex = 1
        Me.AcctSelection2.Text = "By Account"
        '
        'AcctSelection
        '
        Me.AcctSelection.Location = New System.Drawing.Point(9, 18)
        Me.AcctSelection.Name = "AcctSelection"
        Me.AcctSelection.Size = New System.Drawing.Size(91, 24)
        Me.AcctSelection.TabIndex = 0
        Me.AcctSelection.Text = "All Accounts"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Report1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 152)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(848, 317)
        Me.Panel1.TabIndex = 2
        '
        'Report1
        '
        Me.Report1.ActiveViewIndex = -1
        Me.Report1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Report1.Location = New System.Drawing.Point(0, 0)
        Me.Report1.Name = "Report1"
        Me.Report1.ReportSource = Nothing
        Me.Report1.Size = New System.Drawing.Size(848, 317)
        Me.Report1.TabIndex = 2
        '
        'btnComet
        '
        Me.btnComet.Location = New System.Drawing.Point(8, 96)
        Me.btnComet.Name = "btnComet"
        Me.btnComet.Size = New System.Drawing.Size(96, 21)
        Me.btnComet.TabIndex = 40
        Me.btnComet.Text = "Export to Comet"
        '
        'Report
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(848, 469)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Report"
        Me.Text = "Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = WeightVars.WEIGHTTblPath & Me.Tag
            End If
        End If

        Me.KeyPreview = True

        'SetConnectionInfo("CUSTOMER", "weight", "WeightModule", "weight", "weight")
        'SetConnectionInfo("DAILYENTRY", "weight", "WeightModule", "weight", "weight")

        Report1.Enabled = False

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        DTPicker1.Format = DateTimePickerFormat.Custom
        DTPicker1.CustomFormat = "MM/dd/yyyy"
        DTPicker1.Value = Date.Today
        DTPicker2.Format = DateTimePickerFormat.Custom
        DTPicker2.CustomFormat = "MM/dd/yyyy"
        DTPicker2.Value = Date.Today

        AcctSelection.Checked = True

    End Sub

    Private Sub Value_Int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AcctID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And Asc(e.KeyChar) <> Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    Private Sub AcctID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AcctID.Leave
        ''Aly's Original
        'Dim dbRow As DataRow

        'If sender.Modified = False Then Exit Sub
        'If sender.Text.Trim = "" Then Exit Sub
        'sender.modified = False

        'If Val(sender.text) > 0 Then
        '    If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "CUSTOMER") = False Then Exit Sub
        '    AcctName.Text = dbRow.Item("NAME")
        '    sender.Modified = False
        'End If
        ''Aly's end

        'Karina changed to clear up fields when the ID is wrong or empty
        Dim dbRow As DataRow

        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then
            ClearForm(Me)
            AcctName.Text = ""
            Exit Sub
        End If
        sender.modified = False

        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "CUSTOMER") = False Then
                MsgBox("Account not found.")
                ClearForm(Me)
                AcctName.Text = ""
                sender.Focus()
                Exit Sub
            End If
            AcctName.Text = dbRow.Item("NAME")
            sender.Modified = False
        End If
    End Sub

    Private Sub btnAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcct.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select * FROM " & AppTblPath & "Customer order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Accounts"
            Srch.Text = "Accounts"
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
                    AcctName.Text = ugRow.Cells("Name").Text
                    AcctID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                End If
            End Try
        End If
    End Sub

    Private Sub AcctSelection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcctSelection.CheckedChanged, AcctSelection2.CheckedChanged

        If AcctSelection.Checked Then
            GroupBox2.Enabled = False
            GroupBox4.Enabled = False
        ElseIf AcctSelection2.Checked Then
            GroupBox2.Enabled = True
            GroupBox4.Enabled = False
        Else
            GroupBox4.Enabled = True
            GroupBox2.Enabled = False
        End If

    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click, btnRunDate.Click

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

        If sender.name = "btnRunDate" Then
            RepDoc = New crTranReport4
        Else
            RepDoc = New CrystalReport2
        End If


        ''      SelectSQL = "SELECT DailyEntry.AccountID, CUSTOMER.STREET, CUSTOMER.CITYNAME, CUSTOMER.STATE, CUSTOMER.ZIPCODE, CUSTOMER.PHONE1, DailyEntry.TranDate, DailyEntry.Weight, DailyEntry.WeightLimit, DailyEntry.OWCharge, DailyEntry.ManifestName, DailyEntry.Charge, DailyEntry.AccountName, DailyEntry.ManifestID " & _
        ''" FROM   WeightModule.dbo.DailyEntry DailyEntry INNER JOIN WeightModule.dbo.CUSTOMER CUSTOMER ON DailyEntry.AccountID=CUSTOMER.ID " & _
        ''" ORDER BY DailyEntry.AccountID, DailyEntry.ManifestID"
        ''      PopulateDataset2(dtAdapter, dtSet2, SelectSQL)

        If AcctSelection2.Checked Then
            If AcctID.Text = "" Then
                MessageBox.Show("Account is not selected.")
                Exit Sub
            End If
            'Report1.SelectionFormula = "{DailyEntry.AccountID} = " & AcctID.Text & " and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "')"
            RepDoc.RecordSelectionFormula = "{DailyEntry.AccountID} = '" & AcctID.Text & "' and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0 "
        ElseIf AcctSelection.Checked Then
            'Report1.SelectionFormula = "{DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "')"
            RepDoc.RecordSelectionFormula = "{DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0"
        Else
            RepDoc.RecordSelectionFormula = "{GroupClubMembers.ClubID} = " & GroupID.Text.Trim & " and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0 "
            '"{Customer.AcctGroupID} = " & GroupID.Text & " and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0 "
        End If

        'RepDoc.SetDataSource(dtSet2) ' ("Provider = SQLOLEDB; DATA SOURCE = 192.80.90.200; INITIAL CATALOG = WEIGHTMODULE; USER ID = sa; PASSWORD = 4183771")

        paramDiscreteValue1.Value = Format(DTPicker1.Value, "MM/dd/yyyy")
        paramDiscreteValue2.Value = Format(DTPicker2.Value, "MM/dd/yyyy")

        paramField1.ParameterFieldName = "fromdate"
        paramField1.CurrentValues.Add(paramDiscreteValue1)

        paramField2.ParameterFieldName = "ToDate"
        paramField2.CurrentValues.Add(paramDiscreteValue2)

        paramFields1.Add(paramField1)
        paramFields1.Add(paramField2)

        'SetConnectionInfo("CUSTOMER", "weight", "WeightModule", "weight", "weight")
        'SetConnectionInfo("DAILYENTRY", "weight", "WeightModule", "weight", "weight")

        SetConnectionInfo("CUSTOMER", "Weight2.DSN", WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepDoc)
        SetConnectionInfo("DAILYENTRY", "Weight2.DSN", WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepDoc) 'Weightmodule2

        RepDoc.SetParameterValue("fromdate", "05/29/2009")
        RepDoc.SetParameterValue("ToDate", "06/23/2009")

        ''RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, "c :\overhere.pdf")
        'RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, ".\overhere.pdf")

        Report1.Enabled = True
        Report1.ReportSource = Nothing
        Report1.ParameterFieldInfo = Nothing
        Report1.ShowRefreshButton = False

        Report1.DisplayGroupTree = False
        Report1.ParameterFieldInfo = paramFields1
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
            .ConnectionInfo.DatabaseName = database
            .ConnectionInfo.ServerName = server
            .ConnectionInfo.UserID = user
            .ConnectionInfo.Password = password
        End With

        'logOnInfo.ConnectionInfo = ConnectionInfo

        ReportDoc.Database.Tables.Item(table).ApplyLogOnInfo(logOnInfo)

    End Sub

    Private Sub btnPrintSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSum.Click

        Dim RepSummary As New crTranSummary

        Dim paramDiscreteValue1 As New ParameterDiscreteValue
        Dim paramDiscreteValue2 As New ParameterDiscreteValue

        Dim paramField1 As New ParameterField
        Dim paramField2 As New ParameterField

        Dim paramFields1 As New ParameterFields

        If Not RepDoc Is Nothing Then
            RepDoc.Dispose()
            RepDoc = Nothing
        End If

        Report1.Enabled = True
        Report1.ReportSource = Nothing
        Report1.ParameterFieldInfo = Nothing
        Report1.ShowRefreshButton = False
        Report1.DisplayGroupTree = False
        If rbAcctGrp.Checked Then
            If GroupID.Text.Trim = "" Then
                MsgBox("Account Group not selected.")
                Exit Sub
            End If
            RepSummary.RecordSelectionFormula = "{DailyEntry.TranDate} in (cdate('" & DTPicker1.Value & "') to cdate('" & DTPicker2.Value & "')) and {DailyEntry.Charge} > 0 AND {GroupClubMembers.ClubID} = " & Val(GroupID.Text) ' {CUSTOMER.AcctGroupID} = 
        Else
            RepSummary.RecordSelectionFormula = "{DailyEntry.TranDate} in (cdate('" & DTPicker1.Value & "') to cdate('" & DTPicker2.Value & "')) and {DailyEntry.Charge} > 0"
        End If

        paramDiscreteValue1.Value = Format(DTPicker1.Value, "MM/dd/yyyy")
        paramDiscreteValue2.Value = Format(DTPicker2.Value, "MM/dd/yyyy")

        paramField1.ParameterFieldName = "fromdate"
        paramField1.CurrentValues.Add(paramDiscreteValue1)

        paramField2.ParameterFieldName = "ToDate"
        paramField2.CurrentValues.Add(paramDiscreteValue2)

        paramFields1.Add(paramField1)
        paramFields1.Add(paramField2)

        Report1.ParameterFieldInfo = paramFields1

        'RepSummary.DataDefinition.ParameterFields("FromDate").CurrentValues.Add(paramDiscreteValue1)
        'RepSummary.DataDefinition.ParameterFields("ToDate").CurrentValues.Add(paramDiscreteValue2)

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        'Karina
        'SetConnectionInfo("DAILYENTRY", "Weight2.DSN", "WeightModule2", "weight2", "weight2", RepSummary)
        'SetConnectionInfo("SERVICEOFFICES", "Weight2.DSN", "WeightModule2", "weight2", "weight2", RepSummary)

        SetConnectionInfo("DAILYENTRY", "Weight2.DSN", WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepSummary)
        SetConnectionInfo("SERVICEOFFICES", "Weight2.DSN", WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepSummary)

        RepDoc = RepSummary
        RepDoc.SetParameterValue("fromdate", "05/29/2009")
        RepDoc.SetParameterValue("ToDate", "06/23/2009")
        'RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, "c :\summary.pdf")
        RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, ".\summary.pdf")

        ''Report1.ReportSource = RepSummary
        Report1.ReportSource = RepDoc

        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub Group_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Group.Leave

        Dim row As DataRow

        If SearchOnLeave(sender, GroupID, AppTblPath & "GroupClubs", "ClubID", "Club_Name", "", "Account Group-Clubs") = False Then
            sender.GetType()
            Exit Sub
        End If
        If ReturnRowByID(GroupID.Text, row, AppTblPath & "GroupClubs", "", "CLUBID") Then
            Group.Text = row("Club_Name")
        End If

    End Sub
    'Changed from System.Object to Object KArina
    Private Sub Group_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Group.KeyUp
        'TypeAhead(sender, e, AppTblPath & "GroupClubs", "Club_Name", "")

        TypeAhead(sender, e, AppTblPath & "GroupClubs", "Club_Name", "GroupID = '" & ModuleGroup(enGroups.Wgt) & "'")
        'sender.modified = True
    End Sub



    Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * FROM " & AppTblPath & "GroupClubs where GroupID = '" & ModuleGroup(enGroups.Wgt) & "' order by Club_Name"
        Title = "Account Group-Clubs"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = Title
            Srch.Text = Title
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
                    GroupID.Text = ugRow.Cells("ClubID").Text
                    Group.Text = ugRow.Cells("Club_Name").Text
                    Srch = Nothing
                End If
            End Try
        End If

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'ReportViewer1.PrintReport()
        Dim x As New PrintDialog, z As New System.Drawing.Printing.PrinterSettings
        Dim FromPage, ToPage, Count As Int16
        Dim Collated As Boolean = False

        Dim PrinterName As String
        'For i = 0 To System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1
        '    System.Drawing.Printing.PrinterSettings.InstalledPrinters(i)
        'Next

        PrinterName = z.PrinterName 'y.PrinterSettings.PrinterName
        z = Nothing

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

            'PrepareRepDoc(Nothing, False)

            RepDoc.PrintOptions.PrinterName = PrinterName

            RepDoc.PrintToPrinter(Count, Collated, FromPage, ToPage)

            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    'Private Function PrepareRepDoc(ByVal sender As System.Object, ByVal Preview As Boolean)

    'End Function

    Private Sub btnClick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComet.Click

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        ' Set variable values to control file naming and placement
        Dim sFileSavePath As String = "C:\FTPHOME\COMET\"
        Dim sReportName As String = ""
        Dim sStartDate, sEndDate As String

        Dim sMonth, sDay, sYear As String

        If DTPicker1.Value.Month < 10 Then sMonth = "0" & DTPicker1.Value.Month Else sMonth = DTPicker1.Value.Month
        If DTPicker1.Value.Day < 10 Then sDay = "0" & DTPicker1.Value.Day Else sDay = DTPicker1.Value.Day
        sYear = DTPicker1.Value.Year
        sStartDate = sMonth + sDay + sYear

        If DTPicker2.Value.Month < 10 Then sMonth = "0" & DTPicker2.Value.Month Else sMonth = DTPicker2.Value.Month
        If DTPicker2.Value.Day < 10 Then sDay = "0" & DTPicker2.Value.Day Else sDay = DTPicker2.Value.Day
        sYear = DTPicker2.Value.Year
        sEndDate = sMonth + sDay + sYear

        ' Get List of Accounts that have accumulated Weight Charges over the specified period
        Dim sSummarySQL As String = "select * from " & _
             "(select distinct AccountID, AccountName, sum(Charge) as TotalCharge  " & _
              "from " & WeightVars.WEIGHTTblPath & "dailyentry " & _
              "where (TranDate between '" & DTPicker1.Value & "' and '" & DTPicker2.Value & "') " & _
             "group by AccountID, AccountName) as x " & _
            "where(x.TotalCharge > 0) " & _
            "order by x.AccountID"

        ' Iterate through the list and Export a Report for Each Account
        Dim daAdapter As New SqlDataAdapter
        Dim dsData As New DataSet
        PopulateDataset2(daAdapter, dsData, sSummarySQL)

        If dsData.Tables(0).Rows.Count > 0 Then


            For Each dsRow As DataRow In dsData.Tables(0).Rows

                ' Release last resources used by last iteration
                If Not RepDoc Is Nothing Then
                    RepDoc.Dispose()
                    RepDoc = Nothing
                End If

                ' Prepare New RepDoc for this iteration
                RepDoc = New CrystalReport2
                RepDoc.RecordSelectionFormula = "{DailyEntry.AccountID} = '" & dsRow.Item("AccountID") & "' and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0 "

                SetConnectionInfo("CUSTOMER", "Weight2.DSN", WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepDoc)
                SetConnectionInfo("DAILYENTRY", "Weight2.DSN", WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepDoc) 'Weightmodule2

                RepDoc.SetParameterValue("fromdate", DateValue(DTPicker1.Value.ToShortDateString))
                RepDoc.SetParameterValue("ToDate", DateValue(DTPicker2.Value.ToShortDateString))

                ' Prepare Report File Name
                'sReportName = sFileSavePath & dsRow.Item("AccountID") & " " & sStartDate & sEndDate & ".pdf"
                sReportName = dsRow.Item("AccountID") & ".pdf"

                RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, sReportName)

            Next

        End If


        ' Now display all accounts in the report viewer to indicate process is done and to allow user to spot check
        Dim paramDiscreteValue1 As New ParameterDiscreteValue
        Dim paramDiscreteValue2 As New ParameterDiscreteValue

        Dim paramFields1 As New ParameterFields

        Dim paramField1 As New ParameterField
        Dim paramField2 As New ParameterField


        If Not RepDoc Is Nothing Then
            RepDoc.Dispose()
            RepDoc = Nothing
        End If

        If sender.name = "btnRunDate" Then
            RepDoc = New crTranReport4
        Else
            RepDoc = New CrystalReport2
        End If


        If AcctSelection2.Checked Then
            If AcctID.Text = "" Then
                MessageBox.Show("Account is not selected.")
                Exit Sub
            End If
            RepDoc.RecordSelectionFormula = "{DailyEntry.AccountID} = " & AcctID.Text & " and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0 "
        ElseIf AcctSelection.Checked Then
            RepDoc.RecordSelectionFormula = "{DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0"
        Else
            RepDoc.RecordSelectionFormula = "{GroupClubMembers.ClubID} = " & GroupID.Text.Trim & " and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0 "
        End If

        paramDiscreteValue1.Value = Format(DTPicker1.Value, "MM/dd/yyyy")
        paramDiscreteValue2.Value = Format(DTPicker2.Value, "MM/dd/yyyy")

        paramField1.ParameterFieldName = "fromdate"
        paramField1.CurrentValues.Add(paramDiscreteValue1)

        paramField2.ParameterFieldName = "ToDate"
        paramField2.CurrentValues.Add(paramDiscreteValue2)

        paramFields1.Add(paramField1)
        paramFields1.Add(paramField2)

        SetConnectionInfo("CUSTOMER", "Weight2.DSN", WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepDoc)
        SetConnectionInfo("DAILYENTRY", "Weight2.DSN", WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass, RepDoc) 'Weightmodule2

        RepDoc.SetParameterValue("fromdate", "05/29/2009")
        RepDoc.SetParameterValue("ToDate", "06/23/2009")
        'RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, "c :\overhere.pdf")
        RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, ".\overhere.pdf")

        Report1.Enabled = True
        Report1.ReportSource = Nothing
        Report1.ParameterFieldInfo = Nothing
        Report1.ShowRefreshButton = False

        Report1.DisplayGroupTree = False
        Report1.ParameterFieldInfo = paramFields1

        Report1.ReportSource = RepDoc '"AcctWGTReport.RPT"

        Me.Cursor = System.Windows.Forms.Cursors.Default


    End Sub
End Class
