Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class TransReport
    Inherits System.Windows.Forms.Form

    Dim RepDoc As ReportDocument
    Dim MeText As String
    Dim Sec3, Sec7 As Boolean
    Dim Title As String
    Public Server As String

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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTotals As System.Windows.Forms.RadioButton
    Friend WithEvents rbTrans As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbOffice As System.Windows.Forms.RadioButton
    Friend WithEvents ucboOffice As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UltraDate2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Report1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnShow = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rbTotals = New System.Windows.Forms.RadioButton
        Me.rbTrans = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbAll = New System.Windows.Forms.RadioButton
        Me.rbOffice = New System.Windows.Forms.RadioButton
        Me.ucboOffice = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.UltraDate2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Report1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ucboOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnPrint)
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Controls.Add(Me.btnShow)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 381)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(784, 40)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(64, 16)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(104, 21)
        Me.btnPrint.TabIndex = 42
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(706, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        '
        'btnShow
        '
        Me.btnShow.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnShow.Location = New System.Drawing.Point(3, 16)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(61, 21)
        Me.btnShow.TabIndex = 0
        Me.btnShow.Text = "&Show"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.UltraDate2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 64)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbTotals)
        Me.GroupBox4.Controls.Add(Me.rbTrans)
        Me.GroupBox4.Location = New System.Drawing.Point(494, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(282, 45)
        Me.GroupBox4.TabIndex = 23
        Me.GroupBox4.TabStop = False
        '
        'rbTotals
        '
        Me.rbTotals.Location = New System.Drawing.Point(16, 13)
        Me.rbTotals.Name = "rbTotals"
        Me.rbTotals.Size = New System.Drawing.Size(112, 24)
        Me.rbTotals.TabIndex = 21
        Me.rbTotals.Text = "Shipping Manifest"
        '
        'rbTrans
        '
        Me.rbTrans.Enabled = False
        Me.rbTrans.Location = New System.Drawing.Point(140, 13)
        Me.rbTrans.Name = "rbTrans"
        Me.rbTrans.Size = New System.Drawing.Size(134, 24)
        Me.rbTrans.TabIndex = 20
        Me.rbTrans.Text = "Transaction Manifest"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbAll)
        Me.GroupBox2.Controls.Add(Me.rbOffice)
        Me.GroupBox2.Controls.Add(Me.ucboOffice)
        Me.GroupBox2.Location = New System.Drawing.Point(208, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 45)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        '
        'rbAll
        '
        Me.rbAll.Location = New System.Drawing.Point(16, 13)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(80, 24)
        Me.rbAll.TabIndex = 21
        Me.rbAll.Text = "All Offices"
        '
        'rbOffice
        '
        Me.rbOffice.Location = New System.Drawing.Point(104, 13)
        Me.rbOffice.Name = "rbOffice"
        Me.rbOffice.Size = New System.Drawing.Size(72, 24)
        Me.rbOffice.TabIndex = 20
        Me.rbOffice.Text = "By Office:"
        '
        'ucboOffice
        '
        Appearance1.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboOffice.Appearance = Appearance1
        Me.ucboOffice.AutoEdit = False
        Me.ucboOffice.DisplayMember = ""
        Me.ucboOffice.Location = New System.Drawing.Point(176, 13)
        Me.ucboOffice.Name = "ucboOffice"
        Me.ucboOffice.Size = New System.Drawing.Size(80, 21)
        Me.ucboOffice.TabIndex = 18
        Me.ucboOffice.Tag = ".Store#..0.Stores.Store#.Store#"
        Me.ucboOffice.ValueMember = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate2
        '
        Me.UltraDate2.DateTime = New Date(2004, 2, 11, 0, 0, 0, 0)
        Me.UltraDate2.Location = New System.Drawing.Point(72, 24)
        Me.UltraDate2.Name = "UltraDate2"
        Me.UltraDate2.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate2.TabIndex = 16
        Me.UltraDate2.Tag = ".[Mft Date]"
        Me.UltraDate2.Value = New Date(2004, 2, 11, 0, 0, 0, 0)
        '
        'Report1
        '
        Me.Report1.ActiveViewIndex = -1
        Me.Report1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Report1.Location = New System.Drawing.Point(0, 64)
        Me.Report1.Name = "Report1"
        Me.Report1.ReportSource = Nothing
        Me.Report1.Size = New System.Drawing.Size(784, 317)
        Me.Report1.TabIndex = 7
        '
        'TransReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 421)
        Me.Controls.Add(Me.Report1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "TransReport"
        Me.Text = "Reports"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ucboOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TransReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim qOffice As String = "SELECT DISTINCT BranchID AS fldCode, NAME AS fldLabel FROM " & TRCTblPath & "BRANCH ORDER BY Name"

        Me.CenterToScreen()

        AddHandler Me.Activated, AddressOf Form_Activated

        Me.KeyPreview = True
        MeText = Me.Text

        'SetConnectionInfo("CUSTOMER", "weight", "WeightModule", "weight", "weight")
        'SetConnectionInfo("DAILYENTRY", "weight", "WeightModule", "weight", "weight")

        Report1.Enabled = False

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        UltraDate2.Nullable = True
        UltraDate2.Value = Nothing 'Date.Now
        UltraDate2.FormatString = "MM/dd/yyyy"

        rbAll.Checked = True
        rbTotals.Checked = True

        FillUCombo(ucboOffice, "", "", qOffice)
        AddHandler ucboOffice.Leave, AddressOf UCbo_Leave

    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
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

        RepDoc = New PrintedLabelsReport 'Transactions

        'RepDoc.RecordSelectionFormula = "Date({Manifest.DateTime}) = #" & UltraDate2.Value & "#"

        '=========================================================================================
        '==============================      START     ===========================================
        '=========================================================================================
        Dim connstr As String

        connstr = strConnection

        Dim localConn As New SqlConnection(connstr)
        Dim DataAdapter As New SqlDataAdapter
        Dim dsRapid As New DeliveryReports
        Dim Cond As String
        Dim i As Int16

        DataAdapter.SelectCommand = New SqlCommand

        If ucboOffice.Enabled Then
            If ucboOffice.Value Is Nothing Then
                MsgBox("No Office is selected.")
                Exit Sub
            End If
            Cond = " where FromCustID = 5630 AND ISNULL(VOID, 'F') = 'F' AND CONVERT(varchar, [DateTime], 101) = '" & UltraDate2.Text & "'" & " AND RTrim(DestBranchID) = '" & ucboOffice.Value & "'"
            'RepDoc.DataDefinition.RecordSelectionFormula = RepDoc.DataDefinition.RecordSelectionFormula & " AND Trim({BRANCH_DL.Name}) = '" & ucboOffice.Value & "'"
        Else
            Cond = " where FromCustID = 5630 AND ISNULL(VOID, 'F') = 'F' AND CONVERT(varchar, [DateTime], 101) = '" & UltraDate2.Text & "'"
            'Cond = " where [DateTime] between '11/24/2004' and '11/27/2004'"
        End If
        With DataAdapter.SelectCommand
            .Connection = localConn
            .CommandType = CommandType.Text
            .CommandText = "Select * from " & TRCTblPath & "BillingReport " & Cond
        End With
        Try
            localConn.Open()

            With DataAdapter
                .AcceptChangesDuringFill = True
                .MissingSchemaAction = MissingSchemaAction.AddWithKey
                'If .TableMappings.Count <= 0 Then
                '.TableMappings.Add("Table", RepDoc.Database.Tables(i).Name)
                'End If
                .Fill(dsRapid, "BillingReport")
                RepDoc.SetDataSource(dsRapid)
                'RepDoc.Database.Tables("BillingReport").SetDataSource(dsRapid)
            End With

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
            'Exit Sub
            'Catch ex As System.Data.ConstraintException
            '    MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
        End Try
        localConn.Close()

        'RepDoc.SetDataSource(dtSet2) ' ("Provider = SQLOLEDB; DATA SOURCE = 192.80.90.200; INITIAL CATALOG = WEIGHTMODULE; USER ID = sa; PASSWORD = 4183771")
        '===============================================================================
        '========================         END            ===============================
        '===============================================================================


        'RepDoc.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = Sec3
        'RepDoc.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = Sec7
        RepDoc.DataDefinition.FormulaFields("Title").Text = "'" & Title & "'"

        'RepDoc.RecordSelectionFormula = "{Customer.AcctGroupID} = " & GroupID.Text & " and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0 "

        'RepDoc.SetDataSource(dtSet2) ' ("Provider = SQLOLEDB; DATA SOURCE = 192.80.90.200; INITIAL CATALOG = WEIGHTMODULE; USER ID = sa; PASSWORD = 4183771")

        'paramDiscreteValue1.Value = Format(DTPicker1.Value, "MM/dd/yyyy")
        'paramDiscreteValue2.Value = Format(DTPicker2.Value, "MM/dd/yyyy")

        'paramField1.ParameterFieldName = "fromdate"
        'paramField1.CurrentValues.Add(paramDiscreteValue1)

        'paramField2.ParameterFieldName = "ToDate"
        'paramField2.CurrentValues.Add(paramDiscreteValue2)

        'paramFields1.Add(paramField1)
        'paramFields1.Add(paramField2)

        'SetConnectionInfo("Manifest", Server, "TOP", "TPCTRK", "top", RepDoc)
        'SetConnectionInfo("BRANCH_DL", Server, "TOP", "TPCTRK", "top", RepDoc)
        'SetConnectionInfo("BRANCH_PU", Server, "TOP", "TPCTRK", "top", RepDoc)
        'SetConnectionInfo("DestinationZipCode_DL", Server, "TOP", "TPCTRK", "top", RepDoc)
        'SetConnectionInfo("DestinationZipCode_PU", Server, "TOP", "TPCTRK", "top", RepDoc)

        Report1.Enabled = True
        Report1.ReportSource = Nothing
        Report1.ParameterFieldInfo = Nothing
        Report1.ShowRefreshButton = False

        Report1.DisplayGroupTree = False
        'Report1.ParameterFieldInfo = paramFields1
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

            'PrepareRepDoc(Nothing, False)

            RepDoc.PrintToPrinter(Count, Collated, FromPage, ToPage)

            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.CheckedChanged, rbOffice.CheckedChanged
        Select Case sender.name
            Case "rbAll"
                ucboOffice.Enabled = False
                ucboOffice.Value = Nothing
                ucboOffice.Text = ""
            Case "rbOffice"
                ucboOffice.Enabled = True
        End Select
    End Sub

    Private Sub rbTotals_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTotals.CheckedChanged, rbTrans.CheckedChanged
        Select Case sender.name
            Case "rbTotals"
                'RepDoc.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = True
                'RepDoc.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = False
                'RepDoc.DataDefinition.FormulaFields("Title").Text = "Shipping Manifest"

                Sec3 = True
                Sec7 = False
                Title = "Shipping Manifest"
            Case "rbTrans"
                'RepDoc.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = False
                'RepDoc.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = True
                'RepDoc.DataDefinition.FormulaFields("Title").Text = "Transactions Manifest"

                Sec3 = False
                Sec7 = True
                Title = "Transactions Manifest"
        End Select
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
