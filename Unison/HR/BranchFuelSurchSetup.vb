Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Public Class BranchFuelSurchSetup
    Inherits System.Windows.Forms.Form
    Public SQLSelect As String = "Select OfficeID, Office_Name, FuelSurcharge_Rate From " & HRTblPath & "ServiceOffice_FS ORDER BY OfficeID"

    Public HiddenCols() As String = {""}
    'Public CLDB, CLDBUser, CLDBPass As String
    Public SortColIdx As Int16 = 0

    Dim OfficeCriteria As String = " WHERE OfficeID = @OfficeID "
    Dim MeText As String
    Dim dtSet As New DataSet
    Dim dvStates As New DataView
    Dim cmdTrans As SqlCommand


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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents utOfficeName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents utFSRate As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnOfficeID As System.Windows.Forms.Button
    Friend WithEvents OfficeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.utOfficeName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.OfficeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Label3 = New System.Windows.Forms.Label
        Me.utFSRate = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnOfficeID = New System.Windows.Forms.Button
        CType(Me.utOfficeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFSRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'utOfficeName
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOfficeName.Appearance = Appearance1
        Me.utOfficeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeName.Location = New System.Drawing.Point(128, 28)
        Me.utOfficeName.Name = "utOfficeName"
        Me.utOfficeName.Size = New System.Drawing.Size(200, 21)
        Me.utOfficeName.TabIndex = 2
        Me.utOfficeName.Tag = ".Office_Name"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(64, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 14)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Office ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OfficeID
        '
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.OfficeID.Appearance = Appearance2
        Me.OfficeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OfficeID.Location = New System.Drawing.Point(128, 4)
        Me.OfficeID.Name = "OfficeID"
        Me.OfficeID.Size = New System.Drawing.Size(100, 21)
        Me.OfficeID.TabIndex = 0
        Me.OfficeID.Tag = ".OfficeID"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Office Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnDelete)
        Me.GroupBox4.Controls.Add(Me.btnNew)
        Me.GroupBox4.Controls.Add(Me.btnEdit)
        Me.GroupBox4.Controls.Add(Me.btnExit)
        Me.GroupBox4.Controls.Add(Me.btnSave)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 278)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(376, 48)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(204, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 24)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(138, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(64, 24)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(73, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(64, 24)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(302, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 24)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(8, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 24)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 80)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(376, 200)
        Me.UltraGrid1.TabIndex = 4
        Me.UltraGrid1.Tag = "OFFICE_FS"
        Me.UltraGrid1.Text = "Offices Fuel Surcharge"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 20)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "FS Amt. (USD/Mile): $"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utFSRate
        '
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Me.utFSRate.Appearance = Appearance3
        Me.utFSRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFSRate.Location = New System.Drawing.Point(128, 52)
        Me.utFSRate.Name = "utFSRate"
        Me.utFSRate.Size = New System.Drawing.Size(100, 21)
        Me.utFSRate.TabIndex = 3
        Me.utFSRate.Tag = ".FuelSurcharge_Rate"
        '
        'btnOfficeID
        '
        Me.btnOfficeID.Location = New System.Drawing.Point(232, 4)
        Me.btnOfficeID.Name = "btnOfficeID"
        Me.btnOfficeID.Size = New System.Drawing.Size(72, 21)
        Me.btnOfficeID.TabIndex = 1
        Me.btnOfficeID.TabStop = False
        Me.btnOfficeID.Text = "Se&lect"
        '
        'BranchFuelSurchSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 326)
        Me.Controls.Add(Me.btnOfficeID)
        Me.Controls.Add(Me.utFSRate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.utOfficeName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OfficeID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Name = "BranchFuelSurchSetup"
        Me.Tag = "ServiceOffice_FS"
        Me.Text = "Office Fuel Surcharge Setup"
        CType(Me.utOfficeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFSRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BranchFuelSurchSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtaStates As New SqlDataAdapter
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me, HRDBName, HRDBUser, HRDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        AddHandler utFSRate.KeyPress, AddressOf GlobalVars.Value_Dec_KeyPress
        LoadData()

        btnSave.Text = "&Save"

        'MinWinSize.Width = UltraGrid1.Width + Value.Left + Value.Width + 50
        'MinWinSize.Height = GroupBox4.Height + GroupBox3.Height + 20 'Panel1.Height
        'Me.MinimumSize = MinWinSize


        UltraGrid1.Focus()
        Group_EnDis(False)
        'utDedName.Focus()

        UltraGrid1.DisplayLayout.AutoFitColumns = True
    End Sub
    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        If dtSet Is Nothing Then
            dtSet = New DataSet
        End If
        dtSet.Tables.Clear()
        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols)
        UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Clear()
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(UltraGrid1.DisplayLayout.Bands(0).Columns(SortColIdx), False)
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False)
        If UltraGrid1.Rows.Count > 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows(0)
        End If
    End Sub
    Private Sub Group_EnDis(ByVal status As Boolean)
        'GroupBox3.Enabled = status
        btnSave.Enabled = status

        OfficeID.Enabled = status
        utOfficeName.Enabled = status
        btnOfficeID.Enabled = status
        utFSRate.Enabled = status

        UltraGrid1.Enabled = Not status
        'btnDelete.Enabled = Not status
        'Btn_En(status)
    End Sub

    Private Sub Btn_En(ByVal status As Boolean)
        btnSave.Enabled = status


        btnSave.Text = "&Save"
        If status = True Then 'Enable Editing
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                btnNew.Enabled = False
                OfficeID.Enabled = True
                utOfficeName.Enabled = False
                utFSRate.Enabled = True
            Else
                btnEdit.Enabled = False
            End If
        Else 'End Editing
            btnNew.Enabled = True
            btnEdit.Enabled = True
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"

            OfficeID.Enabled = True
            utOfficeName.Enabled = True
            utFSRate.Enabled = True
        End If
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        ''Dim RowIdx, IdxName As Integer

        Dim RowIdx As Integer
        Dim IdxName As String
        ''Dim SQLSave As String = "Select DeptNo, Department, Active From " & HRTblPath & "DEPARTMENTS"

        ''If Value.Text.Trim = "" Then
        ''    MsgBox("Enter Service Type!")
        ''    Exit Sub
        ''End If
        'If utDedID.Text.Trim = "" And utDedName.Text.Trim = "" Then
        '    MsgBox("Enter Departmnet ID and Name!")
        '    Exit Sub
        'Else
        '    If utDedID.Text.Trim = "" Then
        '        MsgBox("Enter Department ID!")
        '        Exit Sub
        '    End If
        If OfficeID.Text.Trim = "" Then
            MsgBox("Office Not Selected.")
            Exit Sub
        End If
        If utOfficeName.Text.Trim = "" Then
            MsgBox("Office Name is blank.")
            Exit Sub
        End If
        'End If
        If utFSRate.Text.Trim = "" Then
            MsgBox("Insert the Fuel Surcharge Rate!")
            Exit Sub
        End If
        If utFSRate.Text.Trim >= 1 Then
            MsgBox("The Fuel Surcharge Rate sould be less then 1!", MsgBoxStyle.OKOnly, "Rate Error!")
            Exit Sub
        End If

        IdxName = ""
        If Not UltraGrid1.ActiveRow Is Nothing Then
            IdxName = " Where OfficeID = '" & UltraGrid1.ActiveRow.Cells("OfficeID").Value & "'"
        
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                RowIdx = UltraGrid1.ActiveRow.Index()
            End If
        End If


        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, IdxName) Then
            '    If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, " Where DeptNo = '" & utDeptID.Text & "'") Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            ''btnEdit.Text = "&Edit"
            ''Me.Text = MeText & " -- Record Updated."
            PopulateDataset2(dtA, dtSet, SQLSelect)
            SortColIdx = UltraGrid1.DisplayLayout.Bands(0).SortedColumns(0).Index
            FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols) 'Let user to sort a Grid '1' not '-1'
            UGLoadLayout(Me, UltraGrid1, 1) 'Karina added
            'row = dtSet.Tables(0).Rows.Find(IdxName)
            'UltraGrid1.Enabled = True 'Karina added
            ''Dim Arr() As Array
            ''Arr = row.ItemArray
            Group_EnDis(False)
            btnNew.Text = "&New"
            btnEdit.Text = "&Edit"
            UltraGrid1.Focus()
            UltraGrid1.Refresh()
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(RowIdx) 'Karina commented, after saving - refreshing

        End If
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        'utDeptID.ReadOnly = True

        ' Lock Records
        If sender.text.toupper = "&EDIT" Then
            If UltraGrid1.Rows.Count <= 0 Then Exit Sub
            If EditForm(Me, PrepSelectQuery(SQLSelect, " Where OfficeID = '" & UltraGrid1.ActiveRow.Cells("OfficeID").Value.ToString.Trim & "'"), EditAction.START, cmdTrans) Then
                'If EditForm(Me, PrepSelectQuery(SQLSelect, " Where DeptNo = " & utDeptID.Text), EditAction.START, cmdTrans) Then
                'SQLEdit, " Where ID = " & ManifestID.Text)

                sender.text = "&Cancel"
                UltraGrid1.Enabled = False
                Group_EnDis(True)
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                If UltraGrid1.Rows.Count <= 0 Then Exit Sub
                sender.text = "&Edit"
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                'FormLoad(Me, dvCompany)
            End If
        End If
        'utDeptID.ReadOnly = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'UltraGrid1.DeleteSelectedRows()
        If btnEdit.Text = "&Cancel" Then
            MessageBox.Show("You are in Edit mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If sender.text = "&New" Then
            ClearForm(Me)
            sender.text = "&Cancel"
            Group_EnDis(True)
            utOfficeName.Focus()
        Else
            ClearForm(Me)
            sender.text = "&New"
            Group_EnDis(False)
        End If

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        FormLoadFromGrid(Me, sender)
    End Sub
    Private Sub UltraGrid1_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled And UltraGrid1.Rows.Count > 0 Then
            FormLoadFromGrid(Me, sender)
        End If
    End Sub
    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                sender.text = "&Edit"
            Else
                'Exit Sub
            End If
        End If
        UGSaveLayout(Me, UltraGrid1, 1)
    End Sub

    Private Sub btnOfficeID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOfficeID.Click
        'Dim row As DataRow
        'Dim dvAcct As New DataView()

        'If SearchOnLeave(FName, EmplID, AppTblPath & "EmployeesBase", , "FirstName", "*", "Employees") Then
        '    dvAcct.Table = row.Table
        '    FormLoad(Me, dvAcct)
        'End If
        Dim SelectQry As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        'SelectQry = "Select ID, FirstName, MiddleName, LastName from " & Me.Tag & " order by LastName"
        SelectQry = "Select ID, Name, Contact, Street, Address2, City, State, ZipCode, Phone1, Phone2, Fax, Email, Web, Territory, RegionID, Password, CustomerID From " & HRTblPath & "ServiceOffices where Active = 1"
        PopulateDataset2(dtAdapter, dtSet, SelectQry)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Service Offices"
            Srch.Text = "Branches"
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
                    'AcctName.Text = ugRow.Cells("Name").Text
                    OfficeID.Text = ugRow.Cells("ID").Text
                    utOfficeName.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                    OfficeID.Modified = True
                    Dim ev As New System.EventArgs
                    'OfficeID_Leave(OfficeID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub OfficeID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OfficeID.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utOfficeName.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, OfficeID, HRTblPath & "ServiceOffices", "ID", "ID", "*", "Service Offices", " Where Active = 1") Then
                If ReturnRowByID(OfficeID.Text, row, HRTblPath & "ServiceOffices", "", "ID") Then
                    utOfficeName.Text = row("Name")
                    row = Nothing
                Else
                    MsgBox("Office Not Found.")
                    OfficeID.Text = ""
                    utOfficeName.Text = ""
                    OfficeID.ClearUndo()
                    OfficeID.Modified = False
                    utOfficeName.Modified = False
                    OfficeID.Focus()
                End If
            Else
                OfficeID.Text = ""
                utOfficeName.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False
        utOfficeName.Modified = False
        utFSRate.Focus()

    End Sub

    Private Sub utOfficeName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utOfficeName.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            OfficeID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, OfficeID, HRTblPath & "ServiceOffices", "ID", "Name", "*", "Service Offices", " Where Active = 1") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
                utFSRate.Focus()
            Else
                'MsgBox("Truck Not Found.")
                OfficeID.Text = ""
                utOfficeName.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utAcct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utOfficeName.KeyUp
        TypeAhead(sender, e, HRTblPath & "ServiceOffices", "Name", " Where Active = 1")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dsData As DataSet
        Dim ID As Integer
        Dim row As DataRow
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If UltraGrid1.Selected.Rows.Count = 0 Then Exit Sub

        If UltraGrid1.Selected.Rows.Count = UltraGrid1.Rows.Count Then
            ID = -1
        Else
            ugrow = UltraGrid1.Selected.Rows(0)
            If ugrow.Index > 0 Then
                ID = ugrow.Index - 1
            Else
                ID = 0
            End If
        End If

        UltraGrid1.DeleteSelectedRows()
        If UpdateDbFromDataSet(dtSet, SQLSelect) <= 0 Then
            'MsgBox("btnDelete_Click: Error!")
            Exit Sub
        End If
        If ID >= 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetItem(ID)
        Else
            ClearForm(Me)
        End If
    End Sub

    Private Sub utFSRate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utFSRate.Leave


        If sender.modified = False Then Exit Sub

        If Val(sender.Text) > 1 Then
            MsgBox("Branch Fuel Surcharge can not be more than a Dollar.")
            ByPassKeyUp = True
            sender.text = ""
            sender.modified = False
            sender.focus()
        End If

    End Sub
End Class
