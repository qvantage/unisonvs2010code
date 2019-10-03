Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class PricePlanZonesSetup
    Inherits System.Windows.Forms.Form

    Public SQLSelect As String = "Select ZoneID as ID, Zone_Name" & _
                                    " From " & BILLTblPath & "PricePlanZones " & _
                                    " ORDER By Zone_Name " 'added As ID Zone_Name
    Public SQLSelect2 As String
    Public HiddenCols() As String = {"ID"}
    Public SortColIdx As Int16 = 0
    Public SortColIdx2 As Int16 = 1

    'Dim Srch As New SearchListings

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim dtSet2 As New DataSet
    Dim dtAdapter As SqlDataAdapter
    Dim dtAdapter2 As SqlDataAdapter
    Dim cmdTrans As SqlCommand
    Dim cmdTrans2 As SqlCommand ' Not sure that we are going to need it

    Enum cols
        _00CHK
        _01Zip
        _02City
        _03State
    End Enum

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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtZone As System.Windows.Forms.TextBox
    Friend WithEvents btnCreateNewZone As System.Windows.Forms.Button
    Friend WithEvents btnDeleteZone As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAddZip As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnDelZip As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnDeleteZone = New System.Windows.Forms.Button
        Me.txtZone = New System.Windows.Forms.TextBox
        Me.btnCreateNewZone = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkSelectAll = New System.Windows.Forms.CheckBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnDelZip = New System.Windows.Forms.Button
        Me.btnAddZip = New System.Windows.Forms.Button
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnDeleteZone)
        Me.GroupBox1.Controls.Add(Me.txtZone)
        Me.GroupBox1.Controls.Add(Me.btnCreateNewZone)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 320)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(168, 100)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(32, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Zone Name:"
        '
        'btnDeleteZone
        '
        Me.btnDeleteZone.Location = New System.Drawing.Point(88, 64)
        Me.btnDeleteZone.Name = "btnDeleteZone"
        Me.btnDeleteZone.TabIndex = 2
        Me.btnDeleteZone.Text = "&Delete Zone"
        '
        'txtZone
        '
        Me.txtZone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZone.Location = New System.Drawing.Point(32, 32)
        Me.txtZone.Name = "txtZone"
        Me.txtZone.Size = New System.Drawing.Size(104, 20)
        Me.txtZone.TabIndex = 1
        Me.txtZone.Tag = ".Zone_Name"
        Me.txtZone.Text = ""
        '
        'btnCreateNewZone
        '
        Me.btnCreateNewZone.Location = New System.Drawing.Point(8, 64)
        Me.btnCreateNewZone.Name = "btnCreateNewZone"
        Me.btnCreateNewZone.TabIndex = 0
        Me.btnCreateNewZone.Text = "&New Zone"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chkSelectAll)
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Controls.Add(Me.btnDelZip)
        Me.GroupBox3.Controls.Add(Me.btnAddZip)
        Me.GroupBox3.Location = New System.Drawing.Point(168, 320)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(472, 100)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        '
        'chkSelectAll
        '
        Me.chkSelectAll.Location = New System.Drawing.Point(32, 24)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.TabIndex = 4
        Me.chkSelectAll.Text = "Select All"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(384, 64)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        '
        'btnDelZip
        '
        Me.btnDelZip.Location = New System.Drawing.Point(104, 64)
        Me.btnDelZip.Name = "btnDelZip"
        Me.btnDelZip.TabIndex = 1
        Me.btnDelZip.Text = "Delete Zip"
        '
        'btnAddZip
        '
        Me.btnAddZip.Location = New System.Drawing.Point(16, 64)
        Me.btnAddZip.Name = "btnAddZip"
        Me.btnAddZip.TabIndex = 0
        Me.btnAddZip.Text = "Add Zip"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(168, 325)
        Me.UltraGrid1.TabIndex = 4
        Me.UltraGrid1.Text = "Zones"
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid2.Location = New System.Drawing.Point(168, 0)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(472, 325)
        Me.UltraGrid2.TabIndex = 8
        Me.UltraGrid2.Text = "Location"
        '
        'PricePlanZonesSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(640, 421)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Name = "PricePlanZonesSetup"
        Me.Tag = "PricePlanZones"
        Me.Text = "Price Plan Zones Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PricePlanZonesSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MinWinSize As System.Drawing.Size
        Dim dtaStates As New SqlDataAdapter

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = BILLTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        AddHandler Me.Activated, AddressOf Form_Activated

        txtZone.Enabled = False

        Me.KeyPreview = True
        MeText = Me.Text

        'Set each control's length based on DB size
        SetupCtrlsLength(Me, AppDBName, AppDBUser, AppDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        LoadData()
    End Sub
    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        Dim ZoneID As Integer

        FormLoadFromGrid(Me, sender)
        ZoneID = UltraGrid1.ActiveRow.Cells("ID").Value 'ZoneID
        FIllUltraGrid2(ZoneID)
    End Sub
    Public Function FIllUltraGrid2(ByVal ZoneID As Integer)
        Dim dS As New DataSet
        Dim dA As New SqlDataAdapter
        Dim SqlSel As String = "Select Convert(bit, 0) as CHK, ppzz.Zip, ct.Name as City, ct.Statecode as State From " & BILLTblPath & "PRICEPLANZONEZIP ppzz, " & BILLTblPath & "City ct, " & BILLTblPath & "PricePlanZones ppz Where ppz.zoneid = ppzz.zoneid and ppzz.zip *= ct.zipcode and ppz.ZoneID = " & ZoneID & ""
        Dim i As Int32

        PopulateDataset2(dA, dS, SqlSel)


        For i = 1 To dS.Tables(0).Columns.Count - 1
            dS.Tables(0).Columns(i).ReadOnly = True
        Next
        dS.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid2, dS, SortColIdx2)
        UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        For i = 1 To UltraGrid2.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = False
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next

        dA.Dispose()
        dA = Nothing

        dS.Dispose()
        dS = Nothing
    End Function
    Private Sub LoadData()
        Dim i As Int32
        'UltraGrid1
        If dtSet Is Nothing Then
            dtSet = New DataSet
        End If
        dtSet.Tables.Clear()
        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        'FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols) 'Karina changed from '-1' to '1'
        FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols)
        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Clear()
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(UltraGrid1.DisplayLayout.Bands(0).Columns(SortColIdx), False)
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False)
    End Sub
    Private Sub btnCreateNewZone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNewZone.Click
        If sender.text = "&New Zone" Then
            btnDeleteZone.Text = "&Save"
            sender.text = "&Cancel"
            Group_EnDis(False)
            ClearForm(Me)
            txtZone.Focus()
        Else
            ClearForm(Me)
            btnDeleteZone.Text = "&Delete Zone"
            sender.text = "&New Zone"
            Group_EnDis(True)
            LoadData()
        End If
    End Sub
    Private Sub btnDeleteZone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteZone.Click
        Dim RowIdx, IdxName As Integer
        'If we are in SAVE condition
        If sender.text = "&Save" Then
            If txtZone.Text.Trim = "" Then
                MsgBox("Zone Name is empty.")
                Exit Sub
            End If

            If Not UltraGrid1.ActiveRow Is Nothing Then
                IdxName = UltraGrid1.ActiveRow.Cells("ID").Value 'ZoneID
                If btnCreateNewZone.Text.ToUpper = "&CANCEL" Then
                    RowIdx = UltraGrid1.ActiveRow.Index()
                End If
            End If


            If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans) Then  ' Ali: " Where ZoneID = '" & IdxName & "'"
                PopulateDataset2(dtAdapter, dtSet, SQLSelect)
                SortColIdx = UltraGrid1.DisplayLayout.Bands(0).SortedColumns(0).Index
                FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols)
                'UGLoadLayout(Me, UltraGrid1, 1)
                'row = dtSet.Tables(0).Rows.Find(IdxName)

                UltraGrid1.Focus()
                UltraGrid1.Refresh()
                UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(RowIdx) 'Karina commented, after saving - refreshing

                btnCreateNewZone.Text = "&New Zone"
                btnDeleteZone.Text = "&Delete Zone"
                Group_EnDis(True)
                UltraGrid2.Refresh()
                LoadData()
            End If
        Else
            Dim ZipCode As String
            Dim urgow As Infragistics.Win.UltraWinGrid.UltraGridRow
            Dim notDeleted As Boolean

            Dim row As DataRow
            Dim ID As String = UltraGrid1.ActiveRow.Cells("id").Value
            Dim QueryExec As String = "Delete from " & BILLTblPath & "PricePlanZones where ZoneID = '" & ID & "'"


            If ReturnRowByID(ID, row, BILLTblPath & "PricePlans", , "From_Zone", "Select * from " & BILLTblPath & "PricePlans where From_Zone = '" & ID & "' or To_Zone = '" & ID & "'") = True _
             Or ReturnRowByID(ID, row, BILLTblPath & "PricePlanZoneZip", , "ZoneID", "Select * from " & BILLTblPath & "PricePlanZoneZip where ZoneID = '" & ID & "'") = True Then

                MsgBox("Can not be beleted! Used in by others tables!", MsgBoxStyle.Exclamation, "Delete Zone!")
                LoadData()
                UltraGrid2.Focus()
                UltraGrid2.ActiveRow = UltraGrid2.Rows.GetRowAtVisibleIndex(0)
                Exit Sub
            Else
                If MsgBox("Are you sure that you want to delete selected Zone?", MsgBoxStyle.YesNo, "Delete Zone!") = MsgBoxResult.Yes Then
                    ExecuteQuery(QueryExec)
                End If
            End If
            LoadData()
            UltraGrid2.Focus()
            UltraGrid2.ActiveRow = UltraGrid2.Rows.GetRowAtVisibleIndex(0)

        End If

    End Sub

    Private Sub Group_EnDis(ByVal status As Boolean)
        UltraGrid1.Enabled = Not status
        UltraGrid2.Enabled = Not status
        txtZone.Enabled = status
        Btn_En(status)
    End Sub

    Private Sub Btn_En(ByVal status As Boolean)
        If status = True Then
            txtZone.Enabled = False
            UltraGrid1.Enabled = True
            UltraGrid2.Enabled = True
        Else
            txtZone.Enabled = True
            UltraGrid1.Enabled = False
            UltraGrid2.Enabled = False
        End If
    End Sub
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub PricePlanZonesSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnCreateNewZone.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                sender.text = "&Edit"
                UltraGrid1.Enabled = True
                UltraGrid2.Enabled = True
                Group_EnDis(False)
            Else
                'Exit Sub
            End If
        End If
        'UGSaveLayout(Me, UltraGrid1, 1)
    End Sub
    Private Sub btnAddZip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddZip.Click
        'Dim InactiveQry As String = SQLSelect.Replace("@ACTV", 0) 'Karina added
        Dim SQLSelect2, SqlSelState As String
        Dim dtAdapterAZ As New SqlDataAdapter
        Dim dtAdState As New SqlDataAdapter

        Dim dtSetAZ As New DataSet
        Dim dtSetState As New DataSet

        Dim dtViewAZ As New DataView
        Dim dtViewState As New DataView

        Dim HasErr As Boolean
        Dim i As Int32
        Dim ugRow, ugRowState As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Code, NameState As String

        'Load SearchListings for States
        SqlSelState = "Select Code, Name as State from  " & BILLTblPath & "STATE order by Code"
        PopulateDataset2(dtAdState, dtSetState, SqlSelState)
        dtViewState.Table = dtSetState.Tables(0)

        Dim SrchState As New SearchListings
        Dim Srch As New SearchListings

        SrchState.dsList = dtSetState
        SrchState.UltraGrid1.Text = "States"
        SrchState.Text = "States"
        SrchState.ShowDialog()
        If SrchState.DialogResult <> DialogResult.OK Then
            'ClearData()
            Exit Sub
        End If

        Try
            Dim cnt As Integer
            cnt = SrchState.UltraGrid1.Rows.Count
        Catch Err As System.Exception
            SrchState = Nothing
            sender.Focus()
            HasErr = True
            Exit Try
        Catch Err2 As System.NullReferenceException
            SrchState = Nothing
            sender.Focus()
            HasErr = True
            Exit Try
        Catch osqlexception As SqlException
            MsgBox("SQL_Error: " & osqlexception.Message)
            SrchState = Nothing
            sender.Focus()
            Exit Try
        Finally
            If HasErr = False Then
                ugRowState = SrchState.UltraGrid1.ActiveRow
                Code = SrchState.UltraGrid1.ActiveRow.Cells("Code").Value
                NameState = SrchState.UltraGrid1.ActiveRow.Cells("State").Value
                SrchState = Nothing
            End If
        End Try

        If Code = "" And NameState = "" Then
            Exit Sub
        Else
            'Load SearchListings for ZipCodes
            SQLSelect2 = "Select Convert(bit, 0) as CHK, ZIPCODE from  " & BILLTblPath & "CITY where STATECODE = '" & Code & "' order by NAME"

            PopulateDataset2(dtAdapterAZ, dtSetAZ, SQLSelect2)
            dtViewAZ.Table = dtSetAZ.Tables(0)


            If dtViewAZ.Table.Rows.Count > 0 Then
                'Dim Srch As New SearchListings
                dtSetAZ.Tables(0).Columns("CHK").ReadOnly = False
                Srch.dsList = dtSetAZ

                'Make visible chkSelAllSearch, when in PricePlanZoneSetup clicked Add Zips, called SearchLinsings 
                Srch.chkSelAllSearch.Visible = True
                Srch.chkSelAllSearch.Top = Srch.btnDelete.Top
                Srch.chkSelAllSearch.Left = Srch.btnDelete.Left


                Srch.UltraGrid1.Text = "Zipcodes from " & NameState & " State."
                Srch.Text = "Zipcodes"
                Srch.GridProps = New GridProp
                ReDim Srch.GridProps.ColProps(0)
                Srch.GridProps.ColProps(0) = New GridColProp

                Srch.GridProps.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
                Srch.GridProps.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
                Srch.GridProps.ColProps(0).ColIdx = 0
                Srch.GridProps.ColProps(0).TabStop = True
                Srch.GridProps.ColProps(0).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

                Srch.ShowDialog()
                If Srch.DialogResult <> DialogResult.OK Then Exit Sub

                'Working on adding the zipCode
                Try
                    Dim cnt As Integer
                    cnt = Srch.UltraGrid1.Rows.Count
                Catch Err As System.Exception
                    Srch = Nothing
                    sender.Focus()
                    HasErr = True
                    Exit Try
                Catch Err2 As System.NullReferenceException
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
                        Dim ID, ZipCode As String

                        ''Karina - to insert few records
                        ID = UltraGrid1.ActiveRow.Cells("ID").Value
                        Dim SelZip, InsQry As String
                        SelZip = "("
                        For i = 0 To Srch.UltraGrid1.Rows.Count - 1
                            If Srch.UltraGrid1.Rows(i).Cells("CHK").Value = "1" Then
                                'ZipCode = Srch.UltraGrid1.Rows(i).Cells("ZipCode").Value
                                SelZip = SelZip & Srch.UltraGrid1.Rows(i).Cells("ZipCode").Value & ", "
                            End If
                        Next

                        If SelZip = "(" Then
                            MsgBox("Zip Code was not selected!", MsgBoxStyle.Exclamation)
                        Else
                            SelZip = SelZip.Substring(0, Len(SelZip) - 2) & ")"
                            InsQry = "Insert into " & BILLTblPath & "PricePlanZoneZip(ZoneID, Zip) Select " & ID & ", ZipCode from " & BILLTblPath & "City where ZipCode in " & SelZip & " and ZipCode not in (Select Zip from " & BILLTblPath & "PricePlanZoneZip where ZoneID = " & ID & ")"
                            ExecuteQuery(InsQry)
                        End If

                        Srch = Nothing
                        'LoadData()
                        FIllUltraGrid2(ID)
                    End If
                End Try
            End If

            For i = 1 To dtSetAZ.Tables(0).Columns.Count - 1
                dtSetAZ.Tables(0).Columns(i).ReadOnly = True
            Next
            dtSetAZ.Tables(0).Columns(0).ReadOnly = False
        End If
    End Sub
    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        Dim i As Int32
        For i = 0 To UltraGrid2.Rows.Count - 1
            UltraGrid2.Rows(i).Cells("CHK").Value = chkSelectAll.Checked
            UltraGrid2.Rows(i).Update()
        Next
    End Sub
    Private Sub btnDelZip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelZip.Click
        Dim ZipCode As String
        Dim ID As String
        Dim urgow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim notDeleted As Boolean

        Dim i As Int32

        For i = 0 To UltraGrid2.Rows.Count - 1
            If UltraGrid2.Rows(i).Cells("CHK").Value = "1" Then
                notDeleted = False
                Exit For
            Else
                notDeleted = True
            End If
        Next

        ID = UltraGrid1.ActiveRow.Cells("ID").Value

        If notDeleted = True Then
            MsgBox("To delete ZipCode, select it first!", MsgBoxStyle.Exclamation)
            Exit Sub
        Else

            If MsgBox("Are you sure that you want to delete checked ZipCodes?", MsgBoxStyle.YesNo, "Delete ZipCodes!") = MsgBoxResult.Yes Then
                For i = 0 To UltraGrid2.Rows.Count - 1
                    'ID = UltraGrid1.Rows(i).Cells("ID").Value 'ZoneID
                    If UltraGrid2.Rows(i).Cells("CHK").Value = "1" Then
                        ZipCode = UltraGrid2.Rows(i).Cells("Zip").Value
                        ExecuteQuery("Delete " & BILLTblPath & "PricePlanZoneZip where Zip = '" & ZipCode & "' and ZoneID = '" & ID & "'") 'ZoneID
                    End If
                Next
            Else
                Exit Sub
            End If
        End If
        'LoadData()
        FIllUltraGrid2(ID)
        UltraGrid2.Focus()
        UltraGrid2.ActiveRow = UltraGrid2.Rows.GetRowAtVisibleIndex(0)
        chkSelectAll.Checked = False
    End Sub
End Class
