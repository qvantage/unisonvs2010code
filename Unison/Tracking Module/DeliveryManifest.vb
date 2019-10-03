Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class DeliveryManifest
    Inherits System.Windows.Forms.Form

    Dim RepDoc As ReportDocument
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UltraDate2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Report1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnSummary As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ucboAccount As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents clbDepotFilter As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnClearAll = New System.Windows.Forms.Button
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.clbDepotFilter = New System.Windows.Forms.CheckedListBox
        Me.ucboAccount = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSummary = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnRun = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.UltraDate2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Report1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1.SuspendLayout()
        CType(Me.ucboAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnClearAll)
        Me.GroupBox1.Controls.Add(Me.btnSelectAll)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.clbDepotFilter)
        Me.GroupBox1.Controls.Add(Me.ucboAccount)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSummary)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.btnRun)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.UltraDate2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(728, 168)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnClearAll
        '
        Me.btnClearAll.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAll.Location = New System.Drawing.Point(352, 56)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(80, 16)
        Me.btnClearAll.TabIndex = 49
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectAll.Location = New System.Drawing.Point(352, 40)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(80, 16)
        Me.btnSelectAll.TabIndex = 48
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(248, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 24)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Select Depot(s)"
        '
        'clbDepotFilter
        '
        Me.clbDepotFilter.Location = New System.Drawing.Point(248, 40)
        Me.clbDepotFilter.Name = "clbDepotFilter"
        Me.clbDepotFilter.Size = New System.Drawing.Size(96, 109)
        Me.clbDepotFilter.TabIndex = 46
        '
        'ucboAccount
        '
        Appearance1.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboAccount.Appearance = Appearance1
        Me.ucboAccount.AutoEdit = False
        Me.ucboAccount.DisplayMember = ""
        Me.ucboAccount.Location = New System.Drawing.Point(96, 48)
        Me.ucboAccount.Name = "ucboAccount"
        Me.ucboAccount.Size = New System.Drawing.Size(130, 21)
        Me.ucboAccount.TabIndex = 45
        Me.ucboAccount.Tag = ".Store#..0.Stores.Store#.Store#"
        Me.ucboAccount.ValueMember = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Account:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSummary
        '
        Me.btnSummary.Location = New System.Drawing.Point(128, 128)
        Me.btnSummary.Name = "btnSummary"
        Me.btnSummary.Size = New System.Drawing.Size(104, 21)
        Me.btnSummary.TabIndex = 42
        Me.btnSummary.Text = "Summary"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(616, 136)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(96, 21)
        Me.btnPrint.TabIndex = 41
        Me.btnPrint.Text = "&Print"
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(16, 128)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(104, 21)
        Me.btnRun.TabIndex = 40
        Me.btnRun.Text = "Delivery Manifest"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Pickup Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate2
        '
        Me.UltraDate2.DateTime = New Date(2004, 2, 11, 0, 0, 0, 0)
        Me.UltraDate2.Location = New System.Drawing.Point(130, 16)
        Me.UltraDate2.Name = "UltraDate2"
        Me.UltraDate2.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate2.TabIndex = 18
        Me.UltraDate2.Tag = ".[Mft Date]"
        Me.UltraDate2.Value = New Date(2004, 2, 11, 0, 0, 0, 0)
        '
        'Report1
        '
        Me.Report1.ActiveViewIndex = -1
        Me.Report1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Report1.Location = New System.Drawing.Point(0, 168)
        Me.Report1.Name = "Report1"
        Me.Report1.ReportSource = Nothing
        Me.Report1.Size = New System.Drawing.Size(728, 397)
        Me.Report1.TabIndex = 3
        '
        'DeliveryManifest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(728, 565)
        Me.Controls.Add(Me.Report1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "DeliveryManifest"
        Me.Text = "DeliveryManifest"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ucboAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub DeliveryManifest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim qAcct As String = "SELECT CustomerID AS fldCode, NAME AS fldLabel FROM " & TRCTblPath & "Customer WHERE CustomerID in (5137, 5630, 25140, 25141, 25149) ORDER BY Name"
        'Dim qAcct As String = "SELECT CustomerID AS fldCode, NAME AS fldLabel FROM " & TRCTblPath & "Customer WHERE CustomerID in ('5137', '25140', '25141', '11200', '12019', '12025','12035','11117','13016') ORDER BY Name"
        'Dim qAcct As String = "SELECT CustomerID AS fldCode, NAME AS fldLabel FROM " & TRCTblPath & "Customer WHERE CustomerID in ('25140', '25141', '11200', '12019', '12025','12035','11117','13031','14007','14009') ORDER BY Name"
        Dim qAcct As String = "SELECT fldCode AS fldCode, fldLabel AS fldLabel FROM " & TRCTblPath & "DeliveryManifestCustomers ORDER BY fldLabel"
        Dim qDepotList As String = "SELECT [ID] as fldCode, [NAME] as fldLabel FROM UNISON.DBO.SERVICEOFFICES ORDER BY fldLabel"


        AddHandler Me.Activated, AddressOf Form_Activated

        Me.KeyPreview = True

        'SetConnectionInfo("CUSTOMER", "weight", "WeightModule", "weight", "weight")
        'SetConnectionInfo("DAILYENTRY", "weight", "WeightModule", "weight", "weight")

        Report1.Enabled = False

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        UltraDate2.Nullable = True
        UltraDate2.Value = Nothing 'Date.Now
        UltraDate2.FormatString = "MM/dd/yyyy"

        FillUCombo(ucboAccount, "", "", qAcct)
        FillCheckedListBox(clbDepotFilter, "", "", qDepotList)
        CheckAll(clbDepotFilter)
        AddHandler ucboAccount.Leave, AddressOf UCbo_Leave


    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
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
        If ucboAccount.Value Is Nothing Then
            MsgBox("Please Select an account.")
            Exit Sub
        End If

        If Not RepDoc Is Nothing Then
            RepDoc.Dispose()
            RepDoc = Nothing
        End If

        RepDoc = New RouteSheet
        '=========================================================================================
        '==============================      START     ===========================================
        '=========================================================================================
        Dim connstr As String

        connstr = strConnection

        Dim localConn As New SqlConnection(connstr)
        Dim DataAdapter As New SqlDataAdapter
        Dim dsRapid As New DeliveryReports
        Dim i As Int16
        Dim j As Int16


        'Loop Depot List to get list of checked depots
        Dim obj As System.Windows.Forms.CheckedListBox.CheckedItemCollection = clbDepotFilter.CheckedItems()
        Dim sListOfDepots As String

        For j = 0 To obj.Count - 1
            sListOfDepots &= ","
            sListOfDepots &= obj.Item(j).Row.ItemArray(0)
        Next

        DataAdapter.SelectCommand = New SqlCommand

        With DataAdapter.SelectCommand
            .Connection = localConn
            .CommandType = CommandType.Text
            '.CommandText = "Select * from " & TRCTblPath & "BillingReport where FromCustID = '" & ucboAccount.Value & "' AND ISNULL(VOID, 'F') = 'F' AND CONVERT(varchar, [DateTime], 101) = '" & UltraDate2.Text & "' AND DestBranchID in (0 " & sListOfDepots & ") Order by ToCity"
            .CommandText = "Select *,'*'+RTRIM(TrackingNum)+'*' as BarcodeNumber from " & TRCTblPath & "BillingReport where FromCustID = '" & ucboAccount.Value & "' AND ISNULL(VOID, 'F') = 'F' AND CONVERT(varchar, [DateTime], 101) = '" & UltraDate2.Text & "' AND DestBranchID in (0 " & sListOfDepots & ") Order by ToCity"
            '.CommandText = "Select *,'*'+RTRIM(TrackingNum)+'*' as BarcodeNumber from UN_TRACKING.dbo.BillingReport where FromCustID = '12025' AND ISNULL(VOID, 'F') = 'F' AND CONVERT(varchar, [DateTime], 101) = '09/20/2017' and  TrackingNum='092057Z5B4303472' AND DestBranchID in (0 ,10,2,20,2099,21,2199,22,2299,23,2399,24,2499,25,26,27,28,2899,29,299,3,4,41,4199,42,43,44,5,51,52,53,5399,55,56,6,61,62,63,7,71,72,73,74,81,9,97,98,99,999,37,1,8,12,32,14,0,36,34,33,11,35) Order by ToCity"
            '  .CommandText = "Select *,'*'+RTRIM(TrackingNum)+'*' as BarcodeNumber from UN_TRACKING.dbo.BillingReport where FromCustID = '12025' AND ISNULL(VOID, 'F') = 'F' AND CONVERT(varchar, [DateTime], 101) = '09/20/2017' and DestBranch='20-RED'  AND DestBranchID in (0 ,10,2,20,2099,21,2199,22,2299,23,2399,24,2499,25,26,27,28,2899,29,299,3,4,41,4199,42,43,44,5,51,52,53,5399,55,56,6,61,62,63,7,71,72,73,74,81,9,97,98,99,999,37,1,8,12,32,14,0,36,34,33,11,35) Order by ToCity"

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

        'RepDoc.RecordSelectionFormula = "Date({Manifest.DateTime}) = #" & UltraDate2.Value & "#"
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
        'SetConnectionInfo("BRANCH", Server, "TOP", "TPCTRK", "top", RepDoc)
        'SetConnectionInfo("DestinationZipCode", Server, "TOP", "TPCTRK", "top", RepDoc)

        Report1.Enabled = True
        Report1.ReportSource = Nothing
        Report1.ParameterFieldInfo = Nothing
        Report1.ShowRefreshButton = False

        Report1.DisplayGroupTree = False
        'Report1.ParameterFieldInfo = paramFields1
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        Report1.ReportSource = RepDoc '"AcctWGTReport.RPT"
        ''SORTING BY FIELD - Karina
        'Dim FieldDefSort As FieldDefinition
        'Dim FieldDefGroup1 As FieldDefinition
        'Dim FieldDefGroup2 As FieldDefinition

        'FieldDefGroup1 = RepDoc.Database.Tables(0).Fields("DestBranch")
        'RepDoc.DataDefinition.Groups(0).ConditionField = FieldDefGroup1

        'FieldDefGroup2 = RepDoc.Database.Tables(0).Fields("DestRoute")
        'RepDoc.DataDefinition.Groups(0).ConditionField = FieldDefGroup2

        'FieldDefSort = RepDoc.Database.Tables(0).Fields("ToCity")
        'RepDoc.DataDefinition.SortFields(0).Field = FieldDefSort
        'RepDoc.DataDefinition.SortFields(0).SortDirection = SortDirection.AscendingOrder
        '
        'Let's try to group programmatically
        'Dim FieldGroup As FieldDefinition
        'FieldGroup = RepDoc.Database.Tables(0).Fields("Section6")
        'RepDoc.DataDefinition.Groups(0).ConditionField = FieldGroup

        '
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

    Private Sub btnSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSummary.Click
        Dim paramDiscreteValue1 As New ParameterDiscreteValue
        Dim paramDiscreteValue2 As New ParameterDiscreteValue

        Dim paramFields1 As New ParameterFields

        Dim paramField1 As New ParameterField
        Dim paramField2 As New ParameterField

        If UltraDate2.Value Is Nothing Then Exit Sub

        If ucboAccount.Value Is Nothing Then
            MsgBox("Please select an account.")
            Exit Sub
        End If
        If Not RepDoc Is Nothing Then
            RepDoc.Dispose()
            RepDoc = Nothing
        End If

        RepDoc = New SummarySheet


        '=========================================================================================
        '==============================      START     ===========================================
        '=========================================================================================
        Dim connstr As String

        connstr = strConnection

        Dim localConn As New SqlConnection(connstr)
        Dim DataAdapter As New SqlDataAdapter
        Dim dsRapid As New DeliveryReports
        Dim SQLQuery As String = "Select TrackingNum,RefNum,FromAddID,FromCustID,FromCustName,FromLocID,FromLocName,FromAdd1,FromAdd2,FromCity,FromState,FromZip,FromContact,FromPhone,FromEmail,ToAddID,ToCustID,ToCustName, @TLOCID, ToLocName,ToAdd1,ToAdd2,ToCity,ToState,ToZip,ToContact,ToPhone,ToEmail,Weight,Pieces,SentBy,ParcelType,ServiceLevel,SpecialHandle,BillType,BillNum,DateTime,RowID,VOID,DestBranchID,DestBranch, DestRoute from " & TRCTblPath & "BillingReport where FromCustID = '" & ucboAccount.Value & "' AND ISNULL(VOID, 'F') = 'F' AND [DateTime] >= '" & UltraDate2.Text & "' and [DateTime] < dateadd(d, 1, '" & UltraDate2.Text & "')"
        Dim i As Int16

        SQLQuery = SQLQuery.Replace("@TLOCID", "REPLACE(ToLocID, 'RX', '') as ToLocID")
        'SQLQuery = SQLQuery.Replace("@TLOCID", "REPLACE(ToLocID, '', '') as ToLocID")
        DataAdapter.SelectCommand = New SqlCommand

        With DataAdapter.SelectCommand
            .Connection = localConn
            .CommandType = CommandType.Text
            .CommandText = SQLQuery '"Select TrackingNum,RefNum,FromAddID,FromCustID,FromCustName,FromLocID,FromLocName,FromAdd1,FromAdd2,FromCity,FromState,FromZip,FromContact,FromPhone,FromEmail,ToAddID,ToCustID,ToCustName, @TLOCID,ToLocName,ToAdd1,ToAdd2,ToCity,ToState,ToZip,ToContact,ToPhone,ToEmail,Weight,Pieces,SentBy,ParcelType,ServiceLevel,SpecialHandle,BillType,BillNum,DateTime,RowID,VOID,DestBranchID,DestBranch from BillingReport where [DateTime] >= '" & UltraDate2.Text & "' and [DateTime] < dateadd(d, 1, '" & UltraDate2.Text & "')"
            '.CommandText = "Select * from BillingReport where [DateTime] >= '11/24/2004' and [DateTime] < dateadd(d, 1, '" & UltraDate2.Text & "')"
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


        'RepDoc.RecordSelectionFormula = "Date({Manifest.DateTime}) = #" & UltraDate2.Value & "#"
        'Server = "TrackingReports"
        'SetConnectionInfo("Manifest", Server, "TOP", "TPCTRK", "top", RepDoc)
        'SetConnectionInfo("BRANCH", Server, "TOP", "TPCTRK", "top", RepDoc)
        'SetConnectionInfo("DestinationZipCode", Server, "TOP", "TPCTRK", "top", RepDoc)

        If btnSummary.Text = "Display" Then
            'RepDoc.ReportDefinition.Sections("Section11").SectionFormat.EnableNewPageAfter = False
            RepDoc.ReportDefinition.Sections("Section11").SectionFormat.EnableResetPageNumberAfter = False
            RepDoc.ReportDefinition.Sections("Section10").SectionFormat.EnableSuppress = False
            RepDoc.ReportDefinition.ReportObjects("Field22").ObjectFormat.EnableSuppress = True
            RepDoc.SummaryInfo.ReportComments = "BILLING"
        Else
            'RepDoc.ReportDefinition.Sections("Section11").SectionFormat.EnableNewPageAfter = True
            RepDoc.ReportDefinition.Sections("Section11").SectionFormat.EnableResetPageNumberAfter = True
            RepDoc.ReportDefinition.Sections("Section10").SectionFormat.EnableSuppress = True
            RepDoc.ReportDefinition.ReportObjects("Field22").ObjectFormat.EnableSuppress = False
            RepDoc.SummaryInfo.ReportComments = "SUMMARY"
            'NextIsNull ({BRANCH.Name}) = false
        End If

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

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        CheckAll(clbDepotFilter)
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        CheckAll(clbDepotFilter,False)
    End Sub

End Class
