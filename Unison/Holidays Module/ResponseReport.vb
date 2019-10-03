Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class ResponseReport
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
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Report1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rbNoSvc As System.Windows.Forms.RadioButton
    Friend WithEvents rbNeedSvc As System.Windows.Forms.RadioButton
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSortAcctID As System.Windows.Forms.RadioButton
    Friend WithEvents rbSortAcct As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkLtrName As System.Windows.Forms.CheckBox
    Friend WithEvents ucboHDate As Infragistics.Win.UltraWinGrid.UltraCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkLtrName = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbNeedSvc = New System.Windows.Forms.RadioButton
        Me.rbNoSvc = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbSortAcct = New System.Windows.Forms.RadioButton
        Me.rbSortAcctID = New System.Windows.Forms.RadioButton
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.Report1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ucboHDate = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ucboHDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ucboHDate)
        Me.GroupBox1.Controls.Add(Me.chkLtrName)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(808, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkLtrName
        '
        Me.chkLtrName.Location = New System.Drawing.Point(555, 47)
        Me.chkLtrName.Name = "chkLtrName"
        Me.chkLtrName.Size = New System.Drawing.Size(117, 24)
        Me.chkLtrName.TabIndex = 70
        Me.chkLtrName.Text = "Show Letter Name"
        Me.chkLtrName.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbNeedSvc)
        Me.GroupBox3.Controls.Add(Me.rbNoSvc)
        Me.GroupBox3.Location = New System.Drawing.Point(42, 40)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(230, 32)
        Me.GroupBox3.TabIndex = 69
        Me.GroupBox3.TabStop = False
        '
        'rbNeedSvc
        '
        Me.rbNeedSvc.Location = New System.Drawing.Point(9, 13)
        Me.rbNeedSvc.Name = "rbNeedSvc"
        Me.rbNeedSvc.Size = New System.Drawing.Size(104, 16)
        Me.rbNeedSvc.TabIndex = 1
        Me.rbNeedSvc.Text = "Needs Service"
        '
        'rbNoSvc
        '
        Me.rbNoSvc.Location = New System.Drawing.Point(146, 13)
        Me.rbNoSvc.Name = "rbNoSvc"
        Me.rbNoSvc.Size = New System.Drawing.Size(79, 16)
        Me.rbNoSvc.TabIndex = 2
        Me.rbNoSvc.Text = "No Service"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbSortAcct)
        Me.GroupBox2.Controls.Add(Me.rbSortAcctID)
        Me.GroupBox2.Location = New System.Drawing.Point(280, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 32)
        Me.GroupBox2.TabIndex = 68
        Me.GroupBox2.TabStop = False
        '
        'rbSortAcct
        '
        Me.rbSortAcct.Location = New System.Drawing.Point(122, 13)
        Me.rbSortAcct.Name = "rbSortAcct"
        Me.rbSortAcct.Size = New System.Drawing.Size(126, 16)
        Me.rbSortAcct.TabIndex = 3
        Me.rbSortAcct.Text = "Sort By Acct. Name"
        '
        'rbSortAcctID
        '
        Me.rbSortAcctID.Location = New System.Drawing.Point(9, 13)
        Me.rbSortAcctID.Name = "rbSortAcctID"
        Me.rbSortAcctID.Size = New System.Drawing.Size(103, 16)
        Me.rbSortAcctID.TabIndex = 2
        Me.rbSortAcctID.Text = "Sort By AcctID"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(632, 16)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(80, 21)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "&Print"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "Holiday :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(728, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(536, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(80, 21)
        Me.btnDisplay.TabIndex = 3
        Me.btnDisplay.Text = "&Display"
        '
        'Report1
        '
        Me.Report1.ActiveViewIndex = -1
        Me.Report1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Report1.Location = New System.Drawing.Point(0, 80)
        Me.Report1.Name = "Report1"
        Me.Report1.ReportSource = Nothing
        Me.Report1.Size = New System.Drawing.Size(808, 445)
        Me.Report1.TabIndex = 1
        '
        'ucboHDate
        '
        Me.ucboHDate.AutoEdit = False
        Me.ucboHDate.DisplayMember = ""
        Me.ucboHDate.Location = New System.Drawing.Point(72, 15)
        Me.ucboHDate.Name = "ucboHDate"
        Me.ucboHDate.Size = New System.Drawing.Size(120, 21)
        Me.ucboHDate.TabIndex = 71
        Me.ucboHDate.Tag = ".HDate...Holidays.ID.HDate"
        Me.ucboHDate.ValueMember = ""
        '
        'ResponseReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(808, 525)
        Me.Controls.Add(Me.Report1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ResponseReport"
        Me.Text = "Response Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ucboHDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ResponseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HOLIDAYSTblPath & Me.Tag
            End If
        End If

        Dim qHolidays As String = "Select ID, HDate, Charge, Description, (case Type when 2 then 'Major' else 'Minor' END) as Type from " & HOLIDAYSTblPath & "Holidays " & " Where year(hdate) in (" & Date.Today.Year & ", " & Date.Today.Year + 1 & ") Order By HDate"

        Me.KeyPreview = True

        'SetConnectionInfo("CUSTOMER", "weight", "WeightModule", "weight", "weight")
        'SetConnectionInfo("DAILYENTRY", "weight", "WeightModule", "weight", "weight")

        Report1.Enabled = False
        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        rbNeedSvc.Checked = True
        rbSortAcctID.Checked = True
        chkLtrName.Checked = False

        'FillCombo(cboHDate, "", " Where year(hdate) in (" & Date.Today.Year & ", " & Date.Today.Year + 1 & ")", qHolidays, HOLIDAYSTblPath)
        FillUCombo(ucboHDate, "", " Where year(hdate) in (" & Date.Today.Year & ", " & Date.Today.Year + 1 & ")", qHolidays, HOLIDAYSTblPath)
        AddHandler ucboHDate.Leave, AddressOf GlobalVars.UCbo_Leave
        AddHandler ucboHDate.KeyPress, AddressOf GlobalVars.UCBO_Search

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        ' ''Dim paramDiscreteValue1 As New ParameterDiscreteValue
        ' ''Dim paramDiscreteValue2 As New ParameterDiscreteValue

        ' ''Dim paramFields1 As New ParameterFields

        ' ''Dim paramField1 As New ParameterField
        ' ''Dim paramField2 As New ParameterField
        'If ucboHDate.ActiveRow Is Nothing Then
        '    MsgBox("Please select a Holiday Date.")
        '    Exit Sub
        'End If

        'If Not RepDoc Is Nothing Then
        '    RepDoc.Dispose()
        '    RepDoc = Nothing
        'End If

        'RepDoc = New ResponesReport

        ''=========================================================================================
        ''==============================      START     ===========================================
        ''=========================================================================================
        'Dim connstr As String

        'connstr = strConnection

        'Dim localConn As New SqlConnection(connstr)
        'Dim DataAdapter As New SqlDataAdapter
        'Dim dsRapid As New ResponseReport_DS
        'Dim i As Int16

        'DataAdapter.SelectCommand = New SqlCommand

        'With DataAdapter.SelectCommand
        '    .Connection = localConn
        '    .CommandType = CommandType.Text
        '    If rbNeedSvc.Checked Then
        '        'RepDoc.RecordSelectionFormula = "{Notices.NeedService} = TRUE and {Notices.HDate} = datevalue('" & cboHDate.Text & "')"
        '        .CommandText = "Select * from " & HOLIDAYSTblPath & "ResponseReportView rrv where rrv.NeedService = 1 AND rrv.HDate = '" & ucboHDate.Text & "' AND Active = 1"
        '    Else
        '        'RepDoc.RecordSelectionFormula = "{Notices.NeedService} = FALSE and {Notices.HDate} = datevalue('" & cboHDate.Text & "')"
        '        .CommandText = "Select * from " & HOLIDAYSTblPath & "ResponseReportView rrv where rrv.NeedService = 0 AND rrv.HDate = '" & ucboHDate.Text & "' AND Active = 1"
        '    End If
        'End With
        'Try
        '    localConn.Open()

        '    With DataAdapter
        '        .AcceptChangesDuringFill = True
        '        .MissingSchemaAction = MissingSchemaAction.AddWithKey
        '        'If .TableMappings.Count <= 0 Then
        '        '.TableMappings.Add("Table", RepDoc.Database.Tables(i).Name)
        '        'End If
        '        .Fill(dsRapid, "ResponseReportView")
        '        RepDoc.SetDataSource(dsRapid)
        '        'RepDoc.Database.Tables("BillingReport").SetDataSource(dsRapid)
        '    End With

        'Catch ex As System.Data.SqlClient.SqlException
        '    'Message modified by Michael Pastor
        '    MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Critical Error")
        '    '- MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
        '    'Exit Sub
        '    'Catch ex As System.Data.ConstraintException
        '    '    MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
        'End Try
        'localConn.Close()

        ''RepDoc.SetDataSource(dtSet2) ' ("Provider = SQLOLEDB; DATA SOURCE = 192.80.90.200; INITIAL CATALOG = WEIGHTMODULE; USER ID = sa; PASSWORD = 4183771")
        ''===============================================================================
        ''========================         END            ===============================
        ''===============================================================================

        'If ucboHDate.ActiveRow.Cells("Type").Value = "MAJOR" Then
        '    RepDoc.ReportDefinition.ReportObjects.Item("Text9").ObjectFormat.EnableSuppress = True
        '    RepDoc.ReportDefinition.ReportObjects.Item("HolidayComments1").ObjectFormat.EnableSuppress = True
        '    RepDoc.ReportDefinition.ReportObjects.Item("Line5").ObjectFormat.EnableSuppress = True
        '    RepDoc.ReportDefinition.ReportObjects.Item("Remarks1").Width = 7184
        '    'Dim LineObj As CrystalDecisions.CrystalReports.Engine.LineObject
        '    RepDoc.ReportDefinition.ReportObjects.Item("Line3").ObjectFormat.EnableSuppress = True
        '    RepDoc.ReportDefinition.ReportObjects.Item("Line4").ObjectFormat.EnableSuppress = False
        'End If

        ''If rbNeedSvc.Checked Then
        ''    RepDoc.RecordSelectionFormula = "{Notices.NeedService} = TRUE and {Notices.HDate} = datevalue('" & cboHDate.Text & "')"
        ''Else
        ''    RepDoc.RecordSelectionFormula = "{Notices.NeedService} = FALSE and {Notices.HDate} = datevalue('" & cboHDate.Text & "')"
        ''End If

        ''RepDoc.SetDataSource(dtSet2) ' ("Provider = SQLOLEDB; DATA SOURCE = 192.80.90.200; INITIAL CATALOG = WEIGHTMODULE; USER ID = sa; PASSWORD = 4183771")

        ' ''paramDiscreteValue1.Value = Format(DTPicker1.Value, "MM/dd/yyyy")
        ' ''paramDiscreteValue2.Value = Format(DTPicker2.Value, "MM/dd/yyyy")

        ' ''paramField1.ParameterFieldName = "fromdate"
        ' ''paramField1.CurrentValues.Add(paramDiscreteValue1)

        ' ''paramField2.ParameterFieldName = "ToDate"
        ' ''paramField2.CurrentValues.Add(paramDiscreteValue2)

        ' ''paramFields1.Add(paramField1)
        ' ''paramFields1.Add(paramField2)



        ''SetConnectionInfo("CUSTOMER", "weight", "WeightModule", "weight", "weight")
        ''SetConnectionInfo("DAILYENTRY", "weight", "WeightModule", "weight", "weight")

        ''Original
        ''SetConnectionInfo("Holidays", "Holidays.dsn", "HolidaysModule", "holiday", "holiday", RepDoc)
        ''SetConnectionInfo("NoticeFormats", "Holidays.dsn", "HolidaysModule", "holiday", "holiday", RepDoc)
        ''SetConnectionInfo("Notices", "Holidays.dsn", "HolidaysModule", "holiday", "holiday", RepDoc)

        ''Karina
        ''SetConnectionInfo("Holidays", "Holidays.dsn", HOLIDAYSDBName, HOLIDAYSDBUser, HOLIDAYSDBPass, RepDoc)
        ''SetConnectionInfo("NoticeFormats", "Holidays.dsn", HOLIDAYSDBName, HOLIDAYSDBUser, HOLIDAYSDBPass, RepDoc)
        ''SetConnectionInfo("Notices", "Holidays.dsn", HOLIDAYSDBName, HOLIDAYSDBUser, HOLIDAYSDBPass, RepDoc)

        ''If chkLtrName.Checked Then
        ''    RepDoc.ReportDefinition.ReportObjects.Item("Field6").ObjectFormat.EnableSuppress = False
        ''    RepDoc.ReportDefinition.ReportObjects.Item("Text6").ObjectFormat.EnableSuppress = False
        ''    RepDoc.ReportDefinition.ReportObjects.Item("Line5").ObjectFormat.EnableSuppress = False
        ''Else
        ''    RepDoc.ReportDefinition.ReportObjects.Item("Field6").ObjectFormat.EnableSuppress = True
        ''    RepDoc.ReportDefinition.ReportObjects.Item("Text6").ObjectFormat.EnableSuppress = True
        ''    RepDoc.ReportDefinition.ReportObjects.Item("Line5").ObjectFormat.EnableSuppress = True
        ''End If
        ''RepDoc.DataDefinition.SortFields.Current() '.Item(0).Field = RepDoc.Database.Tables("Notices").Fields("AccountID")
        'Dim crSortField As CrystalDecisions.CrystalReports.Engine.SortField
        'Dim crSortField2 As CrystalDecisions.CrystalReports.Engine.SortField
        'Dim crDBField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition
        'Dim crDBField2 As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition
        ''Dim x As SortFields
        ''Dim y As SortField

        ' '' it seems that we cannot add sort field in runtime!!
        ''For Each crDBField In RepDoc.Database.Tables("Notices").Fields
        ''    MsgBox(crDBField.Name)
        ''Next

        'crSortField = RepDoc.DataDefinition.SortFields.Item(0)
        'crSortField2 = RepDoc.DataDefinition.SortFields.Item(1)
        'crDBField = crSortField.Field
        'crDBField2 = crSortField2.Field


        'If rbSortAcctID.Checked Then
        '    'crDBField = RepDoc.Database.Tables("Notices").Fields("AccountID")
        '    crSortField.Field = crDBField
        '    crSortField2.Field = crDBField2
        'Else
        '    'crDBField = RepDoc.Database.Tables("Notices").Fields("AccountName")
        '    crSortField.Field = crDBField2
        '    crSortField2.Field = crDBField
        'End If
        ''crSortField = RepDoc.DataDefinition.SortFields.Item(0)
        ''crSortField.Field = crDBField
        ''crSortField.SortDirection = SortDirection.AscendingOrder


        ' ''x = RepDoc.DataDefinition.SortFields()
        ' '''repdoc.DataDefinition.FormulaFields.

        'Report1.Enabled = True

        'Report1.ReportSource = Nothing
        'Report1.ParameterFieldInfo = Nothing
        'Report1.ShowRefreshButton = False


        'Report1.DisplayGroupTree = False
        ' ''Report1.ParameterFieldInfo = paramFields1
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        'Report1.ReportSource = RepDoc '"AcctWGTReport.RPT"


        'Me.Cursor = System.Windows.Forms.Cursors.Default

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
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'ReportViewer1.PrintReport()
        Dim x As New PrintDialog
        Dim FromPage, ToPage, Count As Int16
        Dim Collated As Boolean = False

        If Report1.ReportSource Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("No report is currently run. Please run a report to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("No report is being displayed on screen. Please run a report first.")
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

            RepDoc.PrintToPrinter(Count, Collated, FromPage, ToPage)

            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
