Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class WeightEntryBlankPrint
    Inherits System.Windows.Forms.Form
    'Dim RepDoc As New WeightBlank
    'Dim RepDoc As New WeightBlankBarcode
    Dim RepDoc As Object

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
    Friend WithEvents AcctSelection2 As System.Windows.Forms.RadioButton
    Friend WithEvents AcctSelection As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnOffice As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents OFFICEID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OfficeName As System.Windows.Forms.TextBox
    Friend WithEvents ManifestSelection As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGroup As System.Windows.Forms.Button
    Friend WithEvents GroupID As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Group As System.Windows.Forms.TextBox
    Friend WithEvents ReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents cbBarcodes As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnGroup = New System.Windows.Forms.Button
        Me.GroupID = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Group = New System.Windows.Forms.TextBox
        Me.ManifestSelection = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnOffice = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.OFFICEID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OfficeName = New System.Windows.Forms.TextBox
        Me.AcctSelection2 = New System.Windows.Forms.RadioButton
        Me.AcctSelection = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnPreview = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.ReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cbBarcodes = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.ManifestSelection)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.AcctSelection2)
        Me.GroupBox1.Controls.Add(Me.AcctSelection)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(648, 152)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnGroup)
        Me.GroupBox4.Controls.Add(Me.GroupID)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Group)
        Me.GroupBox4.Location = New System.Drawing.Point(152, 96)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(488, 48)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        '
        'btnGroup
        '
        Me.btnGroup.Location = New System.Drawing.Point(276, 14)
        Me.btnGroup.Name = "btnGroup"
        Me.btnGroup.Size = New System.Drawing.Size(75, 21)
        Me.btnGroup.TabIndex = 86
        Me.btnGroup.Text = "Select"
        '
        'GroupID
        '
        Me.GroupID.Location = New System.Drawing.Point(412, 14)
        Me.GroupID.Name = "GroupID"
        Me.GroupID.Size = New System.Drawing.Size(64, 20)
        Me.GroupID.TabIndex = 85
        Me.GroupID.Tag = ".GroupID"
        Me.GroupID.Text = ""
        Me.GroupID.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(18, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 16)
        Me.Label16.TabIndex = 87
        Me.Label16.Text = "Manifest :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Group
        '
        Me.Group.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Group.Location = New System.Drawing.Point(89, 14)
        Me.Group.Name = "Group"
        Me.Group.Size = New System.Drawing.Size(152, 20)
        Me.Group.TabIndex = 84
        Me.Group.Tag = ".Plan Group.view"
        Me.Group.Text = ""
        '
        'ManifestSelection
        '
        Me.ManifestSelection.Location = New System.Drawing.Point(16, 109)
        Me.ManifestSelection.Name = "ManifestSelection"
        Me.ManifestSelection.TabIndex = 9
        Me.ManifestSelection.Text = "By Manifest"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOffice)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.OFFICEID)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.OfficeName)
        Me.GroupBox2.Location = New System.Drawing.Point(152, 37)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(488, 56)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'btnOffice
        '
        Me.btnOffice.Location = New System.Drawing.Point(408, 24)
        Me.btnOffice.Name = "btnOffice"
        Me.btnOffice.Size = New System.Drawing.Size(75, 21)
        Me.btnOffice.TabIndex = 15
        Me.btnOffice.Text = "Select"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "W.Center ID:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OFFICEID
        '
        Me.OFFICEID.Location = New System.Drawing.Point(89, 22)
        Me.OFFICEID.Name = "OFFICEID"
        Me.OFFICEID.Size = New System.Drawing.Size(64, 20)
        Me.OFFICEID.TabIndex = 13
        Me.OFFICEID.Tag = ".officeid"
        Me.OFFICEID.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(167, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Wgt.Center:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OfficeName
        '
        Me.OfficeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OfficeName.Enabled = False
        Me.OfficeName.Location = New System.Drawing.Point(239, 22)
        Me.OfficeName.Name = "OfficeName"
        Me.OfficeName.Size = New System.Drawing.Size(152, 20)
        Me.OfficeName.TabIndex = 14
        Me.OfficeName.Tag = ".OfficeNAME.view"
        Me.OfficeName.Text = ""
        '
        'AcctSelection2
        '
        Me.AcctSelection2.Location = New System.Drawing.Point(16, 53)
        Me.AcctSelection2.Name = "AcctSelection2"
        Me.AcctSelection2.Size = New System.Drawing.Size(120, 24)
        Me.AcctSelection2.TabIndex = 7
        Me.AcctSelection2.Text = "By Weight Center"
        '
        'AcctSelection
        '
        Me.AcctSelection.Location = New System.Drawing.Point(16, 16)
        Me.AcctSelection.Name = "AcctSelection"
        Me.AcctSelection.Size = New System.Drawing.Size(120, 24)
        Me.AcctSelection.TabIndex = 6
        Me.AcctSelection.Text = "All Weight Centers"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbBarcodes)
        Me.GroupBox3.Controls.Add(Me.btnPrint)
        Me.GroupBox3.Controls.Add(Me.btnPreview)
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 469)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(648, 42)
        Me.GroupBox3.TabIndex = 50
        Me.GroupBox3.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(112, 14)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(104, 21)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "&Print"
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(8, 14)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(104, 21)
        Me.btnPreview.TabIndex = 6
        Me.btnPreview.Text = "Pre&view"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(563, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.ActiveViewIndex = -1
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 152)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ReportSource = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(648, 317)
        Me.ReportViewer1.TabIndex = 51
        '
        'cbBarcodes
        '
        Me.cbBarcodes.Location = New System.Drawing.Point(229, 13)
        Me.cbBarcodes.Name = "cbBarcodes"
        Me.cbBarcodes.Size = New System.Drawing.Size(126, 24)
        Me.cbBarcodes.TabIndex = 8
        Me.cbBarcodes.Text = "Print with Barcodes"
        '
        'WeightEntryBlankPrint
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(648, 511)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "WeightEntryBlankPrint"
        Me.Text = "Blank Weight-Entry Form Printout"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub WeightEntryBlankPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = WeightVars.WEIGHTTblPath & Me.Tag
            End If
        End If

        Me.KeyPreview = True

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        AcctSelection.Checked = True

    End Sub

    Private Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OFFICEID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And Asc(e.KeyChar) <> Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    Private Sub OfficeID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OFFICEID.Leave
        Dim dbRow As DataRow

        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then Exit Sub
        sender.modified = False

        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "ServiceOffices", "where Active = 1") = False Then Exit Sub
            OfficeName.Text = dbRow.Item("NAME")
            sender.Modified = False
        End If

    End Sub

    Private Sub btnOffice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOffice.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * FROM " & AppTblPath & "ServiceOffices where Active = 1 order by Name"
        Title = "Offices"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings()
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
                    OfficeName.Text = ugRow.Cells("Name").Text
                    OFFICEID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                End If
            End Try
        End If
    End Sub


    Private Sub AcctSelection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcctSelection.CheckedChanged, AcctSelection2.CheckedChanged, ManifestSelection.CheckedChanged

        GroupBox2.Enabled = False
        GroupBox4.Enabled = False
        Select Case sender.Name.ToUpper
            Case UCase("AcctSelection")
            Case UCase("AcctSelection2")
                GroupBox2.Enabled = True
            Case UCase("ManifestSelection")
                GroupBox4.Enabled = True
        End Select
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        PrepareRepDoc()

        ReportViewer1.Enabled = True
        ReportViewer1.ReportSource = Nothing
        ReportViewer1.ParameterFieldInfo = Nothing
        ReportViewer1.ShowRefreshButton = False
        ReportViewer1.DisplayGroupTree = False

        ReportViewer1.ReportSource = RepDoc

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub SetConnectionInfo(ByVal table As String, _
            ByVal server As String, ByVal database As String, _
            ByVal user As String, ByVal password As String)

        ' Get the ConnectionInfo Object.
        Dim logOnInfo As New TableLogOnInfo()
        logOnInfo = RepDoc.Database.Tables.Item(table).LogOnInfo

        'Dim connectionInfo As New ConnectionInfo()
        'connectionInfo = RepDoc.Database.Tables.Item(table).LogOnInfo.ConnectionInfo

        ' Set the Connection parameters.
        With logOnInfo
            .ConnectionInfo.DatabaseName = database
            .ConnectionInfo.ServerName = server
            .ConnectionInfo.UserID = user
            .ConnectionInfo.Password = password
        End With

        'logOnInfo.ConnectionInfo = ConnectionInfo

        RepDoc.Database.Tables.Item(table).ApplyLogOnInfo(logOnInfo)

    End Sub


    Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * FROM " & WeightVars.WEIGHTTblPath & "WeightPlanGroups order by Name"
        Title = "Manifests"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings()
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
                    GroupID.Text = ugRow.Cells("ID").Text
                    Group.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                End If
            End Try
        End If

    End Sub
    Private Sub Manifest_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Group.Leave
        'On Error GoTo ErrTrap
        Dim daCity As New SqlDataAdapter()
        Dim dsCity As New DataSet()
        Dim dvCities1 As New DataView()
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        Dim GroupSQL As String = "Select ID, Name as Manifest FROM " & WeightVars.WEIGHTTblPath & "WeightPlanGroups " '& " where StateCode = '" & State.SelectedValue & "'" '" AND zipcode = '" & Zipcode.Text & "'"
        HasErr = False
        If sender.Modified Then
            If IsNumeric(sender.Text) Then ' Zipcode
                GroupSQL = GroupSQL & " where ID = '" & sender.Text & "'"
                PopulateDataset2(daCity, dsCity, GroupSQL)
                dvCities1.Table = dsCity.Tables("WeightPlanGroups")
                If dvCities1.Table.Rows.Count > 0 Then
                    GroupID.Text = sender.Text.ToString
                    sender.Text = dvCities1.Table.Rows(0).Item("Manifest")
                Else
                    MsgBox("Manifest not found!")
                    'ClearData()
                End If
            Else 'Blank or City Name
                If sender.text.trim() = "" Then
                    Exit Sub
                End If
                If sender.Text.StartsWith("?") Then
                    sender.text = sender.text.substring(1)
                End If
                GroupSQL = GroupSQL & " where Name like '" & sender.text & "%' Order by Name"
                PopulateDataset2(daCity, dsCity, GroupSQL)
                dvCities1.Table = dsCity.Tables(0) ' "WeightPlanGroups"
                If dvCities1.Table.Rows.Count > 0 Then
                    If dvCities1.Table.Rows.Count > 1 Then
                        Dim Srch As New SearchListings()
                        Srch.dsList = dsCity

                        Srch.UltraGrid1.Text = "Manifests beginning with '" & sender.text & "'"
                        Srch.Text = "Manifests"
                        Srch.ShowDialog()
                        If Srch.DialogResult <> DialogResult.OK Then
                            'ClearData()
                            Exit Sub
                        End If
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
                                Group.Text = ugRow.Cells("Manifest").Text
                                GroupID.Text = ugRow.Cells("ID").Text
                                Srch = Nothing
                            End If
                        End Try
                    Else ' Just one record found
                        Group.Text = dvCities1(0).Item("manifest") 'ugRow.Cells("City").Text
                        GroupID.Text = dvCities1(0).Item("ID") ' ugRow.Cells("Zipcode").Text

                    End If
                Else
                    MsgBox("No matching Manifest found!")
                    'ClearData()
                    Group.Focus()
                End If
            End If
            sender.Modified = False
        End If
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing
        'If GroupID.Text.Trim <> "" Then
        '    LoadData()
        'End If
        Exit Sub
ErrTrap:
        MsgBox("ZipCode Error: " & Err.Description)
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing
    End Sub

    Private Sub Group_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Group.KeyUp

        TypeAhead(sender, e, WeightVars.WEIGHTTblPath & "WeightPlanGroups", "Name", "")
        'sender.modified = True
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'ReportViewer1.PrintReport()
        Dim x As New PrintDialog()
        Dim FromPage, ToPage, Count As Int16
        Dim Collated As Boolean = False

        'Karina
        If ReportViewer1.ReportSource Is Nothing Then
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

            PrepareRepDoc()
            RepDoc.PrintToPrinter(Count, Collated, FromPage, ToPage)

            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub PrepareRepDoc()

        ' Decide which version of RepDoc to instantiate
        RepDoc = Nothing
        If cbBarcodes.Checked Then
            RepDoc = New WeightBlankBarcode
        Else
            RepDoc = New WeightBlank
        End If

        Dim StartEndDate As String = " AND (isnull({Manifests.StartDate})=TRUE OR {Manifests.StartDate} <= " & "#" & Format(Now, "MM/dd/yyyy") & "#" & " ) and ( isnull({Manifests.enddate})=TRUE OR {Manifests.enddate} >= " & "#" & Format(Now, "MM/dd/yyyy") & "#" & ")"

        If Not RepDoc.IsLoaded() Then
            RepDoc.Load()
        Else
            RepDoc.Close()
            RepDoc.Load()

        End If

        If AcctSelection2.Checked Then
            If OFFICEID.Text = "" Then
                MessageBox.Show("Account is not selected.")
                Exit Sub
            End If
            RepDoc.RecordSelectionFormula = "{Customer.Status} = TRUE and {Manifests.OfficeID} = " & OFFICEID.Text & StartEndDate
        ElseIf AcctSelection.Checked Then
            RepDoc.RecordSelectionFormula = "{Customer.Status} = TRUE" & StartEndDate
        Else
            If GroupID.Text = "" Then
                MessageBox.Show("Manifest is not selected.")
                Exit Sub
            End If
            RepDoc.RecordSelectionFormula = "{Customer.Status} = TRUE and {Manifests.GroupID} = " & GroupID.Text & StartEndDate

        End If

        'RepDoc.SetDataSource(dtSet2) ' ("Provider = SQLOLEDB; DATA SOURCE = 192.80.90.200; INITIAL CATALOG = WEIGHTMODULE; USER ID = sa; PASSWORD = 4183771")

        'SetConnectionInfo("CUSTOMER", "weight", "WeightModule", "weight", "weight")
        'SetConnectionInfo("DAILYENTRY", "weight", "WeightModule", "weight", "weight")

        SetConnectionInfo("MANIFESTS", "Weight2.DSN", WeightVars.WEIGHTDBName, WeightVars.WEIGHTDBUser, WeightVars.WEIGHTDBPass)
        SetConnectionInfo("SERVICEOFFICES", "Weight2.DSN", WeightVars.WEIGHTDBName, WeightVars.WEIGHTDBUser, WeightVars.WEIGHTDBPass)
        SetConnectionInfo("CUSTOMER", "Weight2.DSN", WeightVars.WEIGHTDBName, WeightVars.WEIGHTDBUser, WeightVars.WEIGHTDBPass)
        SetConnectionInfo("WeightPlanGroups", "Weight2.DSN", WeightVars.WEIGHTDBName, WeightVars.WEIGHTDBUser, WeightVars.WEIGHTDBPass)

    End Sub
End Class
