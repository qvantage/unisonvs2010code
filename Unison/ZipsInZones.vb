Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class ZipsInZones
    Inherits System.Windows.Forms.Form

    Public SQLSelect As String = "Select ZoneID as ID, Zone_Name" & _
                                    " From " & smBILLTblPath & "PricePlanZones " & _
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

    Dim lSelectedZips As New ArrayList

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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddZip As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnDelZip As System.Windows.Forms.Button
    Friend WithEvents ugBillingZones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugSettlementZones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugZipSearchList As Infragistics.Win.UltraWinGrid.UltraGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkSelectAll = New System.Windows.Forms.CheckBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnDelZip = New System.Windows.Forms.Button
        Me.btnAddZip = New System.Windows.Forms.Button
        Me.ugSettlementZones = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ugZipSearchList = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ugBillingZones = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox3.SuspendLayout()
        CType(Me.ugSettlementZones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugZipSearchList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugBillingZones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.GroupBox3.Location = New System.Drawing.Point(0, 328)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(864, 108)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        '
        'chkSelectAll
        '
        Me.chkSelectAll.Location = New System.Drawing.Point(192, 48)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.TabIndex = 4
        Me.chkSelectAll.Text = "Select All"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(664, 72)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        '
        'btnDelZip
        '
        Me.btnDelZip.Location = New System.Drawing.Point(8, 48)
        Me.btnDelZip.Name = "btnDelZip"
        Me.btnDelZip.Size = New System.Drawing.Size(176, 23)
        Me.btnDelZip.TabIndex = 1
        Me.btnDelZip.Text = "Remove Zips From Search List"
        '
        'btnAddZip
        '
        Me.btnAddZip.Location = New System.Drawing.Point(8, 16)
        Me.btnAddZip.Name = "btnAddZip"
        Me.btnAddZip.Size = New System.Drawing.Size(176, 23)
        Me.btnAddZip.TabIndex = 0
        Me.btnAddZip.Text = "Add Zips To Search List"
        '
        'ugSettlementZones
        '
        Me.ugSettlementZones.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugSettlementZones.Location = New System.Drawing.Point(680, 0)
        Me.ugSettlementZones.Name = "ugSettlementZones"
        Me.ugSettlementZones.Size = New System.Drawing.Size(185, 325)
        Me.ugSettlementZones.TabIndex = 4
        Me.ugSettlementZones.Text = "Settlement Module"
        '
        'ugZipSearchList
        '
        Me.ugZipSearchList.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugZipSearchList.Location = New System.Drawing.Point(0, 0)
        Me.ugZipSearchList.Name = "ugZipSearchList"
        Me.ugZipSearchList.Size = New System.Drawing.Size(480, 325)
        Me.ugZipSearchList.TabIndex = 8
        Me.ugZipSearchList.Text = "Zip Codes"
        '
        'ugBillingZones
        '
        Me.ugBillingZones.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugBillingZones.Location = New System.Drawing.Point(488, 0)
        Me.ugBillingZones.Name = "ugBillingZones"
        Me.ugBillingZones.Size = New System.Drawing.Size(185, 325)
        Me.ugBillingZones.TabIndex = 9
        Me.ugBillingZones.Text = "Billing Module"
        '
        'ZipsInZones
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(872, 429)
        Me.Controls.Add(Me.ugBillingZones)
        Me.Controls.Add(Me.ugZipSearchList)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ugSettlementZones)
        Me.Name = "ZipsInZones"
        Me.Tag = "PricePlanZones"
        Me.Text = "Find Zips in Zones"
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.ugSettlementZones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugZipSearchList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugBillingZones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ZipsInZones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MinWinSize As System.Drawing.Size
        Dim dtaStates As New SqlDataAdapter

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = smBILLTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        'AddHandler Me.Activated, AddressOf Form_Activated

        Me.KeyPreview = True
        MeText = Me.Text

        'Set each control's length based on DB size
        SetupCtrlsLength(Me, AppDBName, AppDBUser, AppDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        'LoadData()
    End Sub
    Private Sub ugSettlementZones_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ugSettlementZones.AfterRowActivate
        'Dim ZoneID As Integer

        'FormLoadFromGrid(Me, sender)
        'ZoneID = ugSettlementZones.ActiveRow.Cells("ID").Value 'ZoneID
        'FIllugZipSearchList(ZoneID)
    End Sub

    Public Function AddToZipSearchList() As Boolean

    End Function

    Public Function FIllugZipSearchList(ByVal ZoneID As Integer)
        Dim dS As New DataSet
        Dim dA As New SqlDataAdapter
        Dim SqlSel As String = "Select Convert(bit, 0) as CHK, ppzz.Zip, ct.Name as City, ct.Statecode as State From " & smBILLTblPath & "PRICEPLANZONEZIP ppzz, " & smBILLTblPath & "City ct, " & smBILLTblPath & "PricePlanZones ppz Where ppz.zoneid = ppzz.zoneid and ppzz.zip *= ct.zipcode and ppz.ZoneID = " & ZoneID & ""
        Dim i As Int32

        PopulateDataset2(dA, dS, SqlSel)


        For i = 1 To dS.Tables(0).Columns.Count - 1
            dS.Tables(0).Columns(i).ReadOnly = True
        Next
        dS.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(ugZipSearchList, dS, SortColIdx2)
        ugZipSearchList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        ugZipSearchList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        For i = 1 To ugZipSearchList.DisplayLayout.Bands(0).Columns.Count - 1
            ugZipSearchList.DisplayLayout.Bands(0).Columns(i).TabStop = False
            ugZipSearchList.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next
        ugZipSearchList.DisplayLayout.AutoFitColumns = True

        dA.Dispose()
        dA = Nothing

        dS.Dispose()
        dS = Nothing
    End Function

    Public Function FillugZipSearchList(ByVal p_lSelectedZips As ArrayList) As Boolean

        ''Create a new data table
        'Dim tbl As New DataTable

        ''create a column for zipcode
        'tbl.Columns.Add("ZipCode", String.Empty.GetType())

        ''Add some data
        'Dim i As Integer
        'For i = 0 To p_lSelectedZips.Count - 1
        '    tbl.Rows.Add(New String() {p_lSelectedZips(i)})
        'Next

        'ugZipSearchList.DataSource = tbl
        'ugZipSearchList.DataBind()
        'ugZipSearchList.Rows(0).Selected = True

        'Begin Alternate Population Option
        Dim i As Integer
        'Dim sSql As String = "SELECT ZIPCODE, [NAME] as CityName from UNISON.DBO.CITY where ZIPCODE IN ("
        'For i = 0 To p_lSelectedZips.Count - 1
        '    sSql = sSql & "'" & p_lSelectedZips(i) & "',"
        'Next
        Dim sSql As String = "SELECT CONVERT(bit,0) as CHK,ISNULL(DZ.BranchID,0) AS DEPOTID, C.ZIPCODE,c.[NAME] AS CITYNAME FROM UNISON.DBO.CITY c LEFT OUTER JOIN UNISON.DBO.DestinationZipCode dz on dz.DestZip = c.ZIPCODE WHERE C.ZIPCODE IN ("
        For i = 0 To p_lSelectedZips.Count - 1
            sSql = sSql & "'" & p_lSelectedZips(i) & "',"
        Next
        sSql = sSql.Substring(0, Len(sSql) - 1) & String.Empty
        sSql = sSql & ") ORDER BY C.[NAME]"
        Dim ds As DataSet
        Dim da As SqlDataAdapter
        PopulateDataset2(da, ds, sSql)
        FillUltraGrid(ugZipSearchList, ds)

    End Function

    Private Sub LoadData()
        Dim i As Int32
        'ugSettlementZones
        If dtSet Is Nothing Then
            dtSet = New DataSet
        End If
        dtSet.Tables.Clear()
        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        'FillUltraGrid(ugSettlementZones, dtSet, SortColIdx, HiddenCols) 'Karina changed from '-1' to '1'
        FillUltraGrid(ugSettlementZones, dtSet, SortColIdx, HiddenCols)
        'UGLoadLayout(Me, ugSettlementZones, 1)
        ugSettlementZones.DisplayLayout.Bands(0).SortedColumns.Clear()
        ugSettlementZones.DisplayLayout.Bands(0).SortedColumns.Add(ugSettlementZones.DisplayLayout.Bands(0).Columns(SortColIdx), False)
        ugSettlementZones.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False)
    End Sub

    Private Sub LoadData(ByRef p_uGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal p_sSelect As String)

        Dim i As Int32
        'ugSettlementZones
        If dtSet Is Nothing Then
            dtSet = New DataSet
        End If
        dtSet.Tables.Clear()
        PopulateDataset2(dtAdapter, dtSet, p_sSelect)

        'FillUltraGrid(ugSettlementZones, dtSet, SortColIdx, HiddenCols) 'Karina changed from '-1' to '1'
        FillUltraGrid(p_uGrid, dtSet, SortColIdx, HiddenCols)
        'UGLoadLayout(Me, p_uGrid, 1)
        p_uGrid.DisplayLayout.Bands(0).SortedColumns.Clear()
        p_uGrid.DisplayLayout.Bands(0).SortedColumns.Add(ugSettlementZones.DisplayLayout.Bands(0).Columns(SortColIdx), False)
        p_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False)
    End Sub

    'Private Sub btnCreateNewZone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If sender.text = "&New Zone" Then
    '        btnDeleteZone.Text = "&Save"
    '        sender.text = "&Cancel"
    '        Group_EnDis(False)
    '        ClearForm(Me)
    '    Else
    '        ClearForm(Me)
    '        btnDeleteZone.Text = "&Delete Zone"
    '        sender.text = "&New Zone"
    '        Group_EnDis(True)
    '        LoadData()
    '    End If
    'End Sub
    'Private Sub btnDeleteZone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim RowIdx, IdxName As Integer
    '    'If we are in SAVE condition
    '    If sender.text = "&Save" Then

    '        If Not ugSettlementZones.ActiveRow Is Nothing Then
    '            IdxName = ugSettlementZones.ActiveRow.Cells("ID").Value 'ZoneID
    '            If btnCreateNewZone.Text.ToUpper = "&CANCEL" Then
    '                RowIdx = ugSettlementZones.ActiveRow.Index()
    '            End If
    '        End If


    '        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans) Then  ' Ali: " Where ZoneID = '" & IdxName & "'"
    '            PopulateDataset2(dtAdapter, dtSet, SQLSelect)
    '            SortColIdx = ugSettlementZones.DisplayLayout.Bands(0).SortedColumns(0).Index
    '            FillUltraGrid(ugSettlementZones, dtSet, SortColIdx, HiddenCols)
    '            'UGLoadLayout(Me, ugSettlementZones, 1)
    '            'row = dtSet.Tables(0).Rows.Find(IdxName)

    '            ugSettlementZones.Focus()
    '            ugSettlementZones.Refresh()
    '            ugSettlementZones.ActiveRow = ugSettlementZones.Rows.GetRowAtVisibleIndex(RowIdx) 'Karina commented, after saving - refreshing

    '            btnCreateNewZone.Text = "&New Zone"
    '            btnDeleteZone.Text = "&Delete Zone"
    '            Group_EnDis(True)
    '            ugZipSearchList.Refresh()
    '            LoadData()
    '        End If
    '    Else
    '        Dim ZipCode As String
    '        Dim urgow As Infragistics.Win.UltraWinGrid.UltraGridRow
    '        Dim notDeleted As Boolean

    '        Dim row As DataRow
    '        Dim ID As String = ugSettlementZones.ActiveRow.Cells("id").Value
    '        Dim QueryExec As String = "Delete from " & smBILLTblPath & "PricePlanZones where ZoneID = '" & ID & "'"


    '        If ReturnRowByID(ID, row, smBILLTblPath & "PricePlans", , "From_Zone", "Select * from " & smBILLTblPath & "PricePlans where From_Zone = '" & ID & "' or To_Zone = '" & ID & "'") = True _
    '         Or ReturnRowByID(ID, row, smBILLTblPath & "PricePlanZoneZip", , "ZoneID", "Select * from " & smBILLTblPath & "PricePlanZoneZip where ZoneID = '" & ID & "'") = True Then

    '            MsgBox("Can not be beleted! Used in by others tables!", MsgBoxStyle.Exclamation, "Delete Zone!")
    '            LoadData()
    '            ugZipSearchList.Focus()
    '            ugZipSearchList.ActiveRow = ugZipSearchList.Rows.GetRowAtVisibleIndex(0)
    '            Exit Sub
    '        Else
    '            If MsgBox("Are you sure that you want to delete selected Zone?", MsgBoxStyle.YesNo, "Delete Zone!") = MsgBoxResult.Yes Then
    '                ExecuteQuery(QueryExec)
    '            End If
    '        End If
    '        LoadData()
    '        ugZipSearchList.Focus()
    '        ugZipSearchList.ActiveRow = ugZipSearchList.Rows.GetRowAtVisibleIndex(0)

    '    End If

    'End Sub

    Private Sub Group_EnDis(ByVal status As Boolean)
        ugSettlementZones.Enabled = Not status
        ugZipSearchList.Enabled = Not status
        Btn_En(status)
    End Sub

    Private Sub Btn_En(ByVal status As Boolean)
        If status = True Then
            ugSettlementZones.Enabled = True
            ugZipSearchList.Enabled = True
        Else
            ugSettlementZones.Enabled = False
            ugZipSearchList.Enabled = False
        End If
    End Sub
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    'Private Sub ZipsInZones_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '    If btnCreateNewZone.Text = "&Cancel" Then
    '        If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
    '            e.Cancel = True
    '            Exit Sub
    '        End If
    '    End If

    '    If Not cmdTrans Is Nothing Then
    '        If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
    '            sender.text = "&Edit"
    '            ugSettlementZones.Enabled = True
    '            ugZipSearchList.Enabled = True
    '            Group_EnDis(False)
    '        Else
    '            'Exit Sub
    '        End If
    '    End If
    '    'UGSaveLayout(Me, ugSettlementZones, 1)
    'End Sub
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
        SqlSelState = "Select Code, Name as State from  " & smBILLTblPath & "STATE order by Code"
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
            'SQLSelect2 = "Select Convert(bit, 0) as CHK, ZIPCODE, [NAME] AS CityName from  " & smBILLTblPath & "CITY where STATECODE = '" & Code & "' order by NAME"
            SQLSelect2 = "SELECT CONVERT(bit,0) as CHK,ISNULL(DZ.BranchID,0) AS DEPOTID, C.ZIPCODE,c.[NAME] AS CITYNAME FROM " & smBILLTblPath & "CITY c LEFT OUTER JOIN UNISON.DBO.DestinationZipCode dz on dz.DestZip = c.ZIPCODE WHERE STATECODE = '" & Code & "' ORDER BY C.[NAME]"

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
                Dim cnt As Integer
                Try
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
                        'ID = ugSettlementZones.ActiveRow.Cells("ID").Value
                        Dim SelZip, InsQry As String
                        SelZip = String.Empty

                        GetAllSelectedZips(Srch.UltraGrid1.Rows, SelZip)

                        ''BEGIN ORIGINAL CODE (Replaced by GetAllSelectedZips)
                        'For i = 0 To Srch.UltraGrid1.Rows.Count - 1
                        '    If Srch.UltraGrid1.Rows(i).Cells("CHK").Value = "1" Then
                        '        SelZip = SelZip & Srch.UltraGrid1.Rows(i).Cells("ZipCode").Value & ","
                        '    End If
                        'Next
                        ''END ORIGINAL CODE (Replaced by GetAllSelectedZips)

                        ''BEGIN TEST CODE
                        'Dim rowsCount As Integer = 0
                        'Dim groupByRowsCount As Integer = 0
                        'MessageBox.Show("Please wsit.  This operation may take a while depending on number of rows.")
                        'Me.TraverseAllRowsHelper(Srch.UltraGrid1.Rows, rowsCount, groupByRowsCount)
                        'MessageBox.Show("The UltraGrid has " & rowsCount & " number of regular rows, and " & groupByRowsCount & " number of group-by rows.")
                        ''END TEST CODE

                        If SelZip = String.Empty Then
                            MsgBox("Zip Code was not selected!", MsgBoxStyle.Exclamation)
                        Else
                            SelZip = SelZip.Substring(0, Len(SelZip) - 1) & String.Empty
                            Dim Zips() As String = SelZip.Split(",")
                            For i = 0 To Zips.Length - 1
                                lSelectedZips.Add(Zips(i))
                            Next
                            FIllugZipSearchList(lSelectedZips)
                        End If

                        Srch = Nothing
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
        For i = 0 To ugZipSearchList.Rows.Count - 1
            ugZipSearchList.Rows(i).Cells("CHK").Value = chkSelectAll.Checked
            ugZipSearchList.Rows(i).Update()
        Next
    End Sub
    Private Sub btnDelZip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelZip.Click
        Dim ZipCode As String
        Dim ID As String
        Dim urgow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim notDeleted As Boolean

        Dim i As Int32

        For i = 0 To ugZipSearchList.Rows.Count - 1
            If ugZipSearchList.Rows(i).Cells("CHK").Value = "1" Then
                notDeleted = False
                Exit For
            Else
                notDeleted = True
            End If
        Next

        ID = ugSettlementZones.ActiveRow.Cells("ID").Value

        If notDeleted = True Then
            MsgBox("To delete ZipCode, select it first!", MsgBoxStyle.Exclamation)
            Exit Sub
        Else

            If MsgBox("Are you sure that you want to delete checked ZipCodes?", MsgBoxStyle.YesNo, "Delete ZipCodes!") = MsgBoxResult.Yes Then
                For i = 0 To ugZipSearchList.Rows.Count - 1
                    'ID = ugSettlementZones.Rows(i).Cells("ID").Value 'ZoneID
                    If ugZipSearchList.Rows(i).Cells("CHK").Value = "1" Then
                        ZipCode = ugZipSearchList.Rows(i).Cells("Zip").Value
                        ExecuteQuery("Delete " & smBILLTblPath & "PricePlanZoneZip where Zip = '" & ZipCode & "' and ZoneID = '" & ID & "'") 'ZoneID
                    End If
                Next
            Else
                Exit Sub
            End If
        End If
        'LoadData()
        FIllugZipSearchList(ID)
        ugZipSearchList.Focus()
        ugZipSearchList.ActiveRow = ugZipSearchList.Rows.GetRowAtVisibleIndex(0)
        chkSelectAll.Checked = False
    End Sub

    Private Sub ugZipSearchList_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugZipSearchList.AfterRowActivate
        LoadBillingZones()
        LoadSettlementZones()
    End Sub

    Private Sub LoadBillingZones()
        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, SQLSelect2, Cond As String

        SQLSelect = "SELECT ppz.Zone_Name as 'Zones' FROM  UN_BILLING.DBO.PricePlanZoneZip ppzz JOIN UN_BILLING.DBO.PricePlanZones ppz on ppz.ZoneID = ppzz.ZoneID and Zip = '@ZIPCODE' ORDER by Zone_Name"

        If Not ugZipSearchList.ActiveRow Is Nothing Then
            If Not ugZipSearchList.ActiveRow.ListObject Is Nothing Then
                Cond = ugZipSearchList.ActiveRow.Cells("ZipCode").Value
            Else
                Exit Sub
            End If
        End If

        SQLSelect = SQLSelect.Replace("@ZIPCODE", Cond)

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(ugBillingZones, dtSet, -1, , 0)
        'UltraGrid2.DataSource = dtSet
        'UGLoadLayout(Me, UltraGrid2, 1)
        'ugBillingZones.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        ugBillingZones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        ugBillingZones.DisplayLayout.AutoFitColumns = True
        For i = 0 To ugBillingZones.DisplayLayout.Bands(0).Columns.Count - 1
            ugBillingZones.DisplayLayout.Bands(0).Columns(i).TabStop = True
            ugBillingZones.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        'ugBillingZones.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'UltraGrid2.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid2.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid2.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid2.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid2.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False

        'Dim SumCol As String = "TranDate"
        'UltraGrid2.DisplayLayout.Bands(0).Summaries.Add(SumCol, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid2.DisplayLayout.Bands(0).Columns(SumCol), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid2.DisplayLayout.Bands(0).Summaries(SumCol).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid2.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid2.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        ugBillingZones.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        ugBillingZones.DisplayLayout.GroupByBox.Hidden = False
        'ugBillingZones.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        ugBillingZones.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        'UltraGrid2.Text = "Packages"
    End Sub

    Private Sub LoadSettlementZones()
        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, SQLSelect2, Cond As String

        SQLSelect = "SELECT ppz.Zone_Name as 'Zones' FROM  UN_SETTLEMENT.DBO.PricePlanZoneZip ppzz JOIN UN_SETTLEMENT.DBO.PricePlanZones ppz on ppz.ZoneID = ppzz.ZoneID and Zip = '@ZIPCODE' ORDER by Zone_Name"

        If Not ugZipSearchList.ActiveRow Is Nothing Then
            If Not ugZipSearchList.ActiveRow.ListObject Is Nothing Then
                Cond = ugZipSearchList.ActiveRow.Cells("ZipCode").Value
            Else
                Exit Sub
            End If
        End If

        SQLSelect = SQLSelect.Replace("@ZIPCODE", Cond)

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(ugSettlementZones, dtSet, -1, , 0)
        'UltraGrid2.DataSource = dtSet
        'UGLoadLayout(Me, UltraGrid2, 1)
        'ugSettlementZones.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        ugSettlementZones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        ugSettlementZones.DisplayLayout.AutoFitColumns = True
        For i = 0 To ugSettlementZones.DisplayLayout.Bands(0).Columns.Count - 1
            ugSettlementZones.DisplayLayout.Bands(0).Columns(i).TabStop = True
            ugSettlementZones.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        'ugSettlementZones.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'UltraGrid2.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid2.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid2.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid2.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid2.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False

        'Dim SumCol As String = "TranDate"
        'UltraGrid2.DisplayLayout.Bands(0).Summaries.Add(SumCol, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid2.DisplayLayout.Bands(0).Columns(SumCol), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid2.DisplayLayout.Bands(0).Summaries(SumCol).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid2.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid2.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        ugSettlementZones.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        ugSettlementZones.DisplayLayout.GroupByBox.Hidden = False
        'ugSettlementZones.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        ugSettlementZones.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        'UltraGrid2.Text = "Packages"
    End Sub

    Private Sub TraverseAllRowsHelper(ByVal rows As RowsCollection, ByRef rowsCount As Integer, ByRef groupByRowsCount As Integer)

        'Loop through every row in the passed in rows collection
        Dim row As UltraGridRow = Nothing
        For Each row In rows
            'If you are using Outlook GroupBy feature and have grouped rows by columns in the UltraGrid, then rows collection can contain grouop-by rows 
            'or regular rows.  So you may need to have code th handle group-by rows as well.
            If TypeOf row Is UltraGridGroupByRow Then
                Dim groupByRow As UltraGridGroupByRow = DirectCast(row, UltraGridGroupByRow)
                'Increment the group-by row count
                groupByRowsCount += 1
            Else
                ' Increment the regular tow count
                rowsCount += 1
            End If
            'If the row has any child rows.  Typically, there is only a single child band.  However, there will be multiple child bands if the 
            'band associated with row1 has multiple child bands. This would be the case for example when youhave a database hierarchy in which a 
            'table has multiple child tables.
            If Not Nothing Is row.ChildBands Then
                'Loop through each of the child bands
                Dim childBand As UltraGridChildBand = Nothing
                For Each childBand In row.ChildBands
                    'Call this method recursively for each child rows collection
                    TraverseAllRowsHelper(childBand.Rows, rowsCount, groupByRowsCount)
                Next
            End If

        Next
    End Sub

    Private Sub GetAllSelectedZips(ByVal rows As RowsCollection, ByRef p_sSelZip As String)

        ' Loop through every row in the passed in rows collection
        Dim row As UltraGridRow = Nothing
        For Each row In rows
            If TypeOf row Is UltraGridGroupByRow Then
                If Not Nothing Is row.ChildBands Then
                    Dim childBand As UltraGridChildBand = Nothing
                    For Each childBand In row.ChildBands
                        GetAllSelectedZips(childBand.Rows, p_sSelZip)
                    Next
                End If
            Else
                If row.Cells("CHK").Value = "1" Then
                    p_sSelZip = p_sSelZip & row.Cells("ZipCode").Value & ","
                End If
            End If
        Next

    End Sub

End Class