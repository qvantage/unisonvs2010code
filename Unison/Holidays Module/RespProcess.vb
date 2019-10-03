Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class RespProcess
    Inherits System.Windows.Forms.Form
    Dim SelectQuery As String = "SELECT ID, Active, AccountID, AccountName, PHONE1, Responded, Needs_Service, No_Service, Resp_Date, isnull(Remarks, '') as Remarks, HDate, FormatID, HolidayCommentsMn as [Minor Hol. Comments] FROM " & HOLIDAYSTblPath & "RespProcessView  ORDER BY AccountID"

    'Dim SelectQuery As String = "SELECT Notices.ID, c.Status as Active, AccountID, AccountName, c.Phone1, Responded, NeedService AS [Needs_Service]," & _
    '                            " NoService AS [No_Service], RespDate AS [Resp_Date], Remarks FROM " & HOLIDAYSTblPath & "Notices left outer join " & HOLIDAYSTblPath & "Customer c on Notices.AccountID = c.ID  ORDER BY AccountID"
    Dim UpdateQuery As String = "Update " & HOLIDAYSTblPath & "Notices set Responded = @Responded , NeedService = @NeedService, NoService = @NoService, Remarks = '@Remarks' where ID = @ID "
    'Dim UpdateQuery As String = "Update " & HOLIDAYSTblPath & "Notices set Responded = (case '@Responded' when 'TRUE' then 1 else 0 end) , NeedService = @NeedService, NoService = @NoService, Remarks = '@Remarks' where ID = @ID "
    Dim UpdParamCols()() As String = {New String() {"@Responded", "Responded"}, New String() {"@NeedService", "Needs_Service"}, New String() {"@NoService", "No_Service"}, New String() {"@Remarks", "Remarks"}, New String() {"@ID", "ID"}}

    'Dim UpdateQuery As String = "Update " & HOLIDAYSTblPath & "Notices set NoService = @NoService where ID = @ID "
    'Dim UpdParamCols()() As String = {New String() {"@NoService", "No_Service"}, New String() {"@ID", "ID"}}


    'Dim SelectQuery1 As String = "SELECT Notices.ID, AccountID, AccountName, Responded, NeedService AS [Needs_Service]," & _
    '                            " NoService AS [No_Service], RespDate AS [Resp_Date], Remarks FROM " & HOLIDAYSTblPath & "Notices ORDER BY AccountID"
    'Dim SelectQuery2 As String = "SELECT c.ID, c.status as Active, c.Phone1 " & _
    '                            " FROM " & HOLIDAYSTblPath & "Customer c ORDER BY c.ID"
    Dim SelectCriteria As String = " where HDate = "

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim cmdTrans As SqlCommand
    Dim HidCols() As String = {"ID", "HDate", "FormatID"}
    Dim DataModified As Boolean

    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

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
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents cboHDate As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.cboHDate = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDisplay, Me.cboHDate, Me.Label12})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(592, 56)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(379, 18)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 69
        Me.btnDisplay.Text = "D&isplay"
        '
        'cboHDate
        '
        Me.cboHDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDate.Location = New System.Drawing.Point(88, 18)
        Me.cboHDate.Name = "cboHDate"
        Me.cboHDate.Size = New System.Drawing.Size(144, 21)
        Me.cboHDate.TabIndex = 64
        Me.cboHDate.Tag = ".HDate...Holidays.ID.Convert(Varchar,HDate,101)"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Holiday :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPreview, Me.btnExit, Me.btnSave})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 357)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(592, 40)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'btnPreview
        '
        Me.btnPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPreview.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPreview.Location = New System.Drawing.Point(78, 16)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 21)
        Me.btnPreview.TabIndex = 6
        Me.btnPreview.Text = "Pre&view"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(514, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 21)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 56)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(592, 301)
        Me.UltraGrid1.TabIndex = 4
        Me.UltraGrid1.Text = "Sent Notices"
        '
        'RespProcess
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 397)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.UltraGrid1, Me.GroupBox2, Me.GroupBox1})
        Me.Name = "RespProcess"
        Me.Text = "Response Processing"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub RespProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HOLIDAYSTblPath & Me.Tag
            End If
        End If

        DataModified = False

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        'Changed pass by Karina
        FillCombo(cboHDate, "", " Where year(hdate) in (" & Date.Today.Year & ", " & Date.Today.Year + 1 & ")", "", HOLIDAYSTblPath)

    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub RespProcess_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim e1 As System.EventArgs
        If Not UltraGrid1.ActiveRow Is Nothing Then
            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
            'UltraGrid1.ActiveCell.Activate()
            UltraGrid1.ActiveRow.Update()
        End If
        If DataModified Then
            'Message modified by Michael Pastor
            If MessageBox.Show("Data has changed. Would you like to save?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.Yes Then
                '- If MsgBox("Data has changed. Do you want to save?", MsgBoxStyle.YesNo, "Data Changed") = MsgBoxResult.Yes Then
                btnSave_Click(btnSave, e1)
            End If
        End If

        dtSet.Dispose()
        dtSet = Nothing
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        LoadData()
    End Sub

    Private Sub cboHDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHDate.SelectedIndexChanged
        UltraGrid1.DataSource = Nothing
    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer

        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If
        Dim CustCond As String = " WHERE c.ID in (select AccountID from " & HOLIDAYSTblPath & "Notices n where n.HDAte = '" & cboHDate.Text & "' AND (FormatID > 0))"
        PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SelectQuery, SelectCriteria & "'" & cboHDate.Text & "' AND (FormatID > 0)"))
        'PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SelectQuery1, SelectCriteria & "'" & cboHDate.Text & "' AND (FormatID > 0)"))
        'PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SelectQuery2, CustCond), True)
        Dim CustRel As DataRelation

        'Dim ParentCols(0), ChildCols(0) As DataColumn
        'ParentCols(0) = dtSet.Tables(0).Columns("AccountID")
        'ChildCols(0) = dtSet.Tables(1).Columns("ID")

        'CustRel = dtSet.Relations.Add("CustRel", ParentCols, ChildCols)

        'Dim dtTbl As DataTable
        'dtTbl = dtSet.Tables.Add("JoinTbl")

        'Dim dvm As New DataViewManager
        'Dim dvData As New DataView

        ''dvm = dvData.DataViewManager

        'dvm.DataSet = dtSet
        'dvm.DataViewSettings(HOLIDAYSTblPath & "Notices").Sort = "AccountID"
        'dvm.DataViewSettings("C").Sort = "Active"

        btnSave.Text = "&Save"
        dtSet.Tables(0).Columns("Remarks").ReadOnly = False

        FillUltraGrid(UltraGrid1, dtSet, 0, HidCols)
        'FillUltraGrid(UltraGrid1, dvData, 0, HidCols)

        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        UltraGrid1.DisplayLayout.AutoFitColumns = True
        For i = 1 To 4
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
        Next
        UltraGrid1.DisplayLayout.Bands(0).Columns("Remarks").Case = Infragistics.Win.UltraWinGrid.[Case].Upper

    End Sub

    Private Sub UltraGrid1_BeforeCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles UltraGrid1.BeforeCellUpdate
        DataModified = True
        If e.Cell.Column.ToString = "Responded" Or e.Cell.Column.ToString = "Needs_Service" Or e.Cell.Column.ToString = "No_Service" Or e.Cell.Column.ToString = "Remarks" Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub UltraGrid1_BeforeEnterEditMode(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UltraGrid1.BeforeEnterEditMode

        If UltraGrid1.ActiveCell.Column.ToString = "Responded" Or UltraGrid1.ActiveCell.Column.ToString = "Needs_Service" Or UltraGrid1.ActiveCell.Column.ToString = "No_Service" Or UltraGrid1.ActiveCell.Column.ToString = "Remarks" Then  'Or UltraGrid1.ActiveCell.Column.ToString = "Charge"
            'WgtTotal -= UltraGrid1.ActiveRow.Cells("Weight").Value       '  ugrow.Cells("Weight").Value
            e.Cancel = False
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim SelectTmp As String

        Dim PKArray(0)() As Object
        Dim x(2) As Object
        Dim OmitFldList() As String = {"ID", "HDate", "FormatID"}

        If CheckServiceReq() = False Then
            Exit Sub
        End If
        x(0) = "ID" : x(1) = SqlDbType.Int ': x(2) = Val(ManifestID.Text)

        PKArray(0) = x

        SelectTmp = PrepSelectQuery(SelectQuery, SelectCriteria & "'" & cboHDate.Text & "' AND FormatID > 0 ")

        'If UpdateDbFromDataSet(dtSet, SelectTmp) <= 0 Then
        '    MsgBox("Save: No Records Updated!")
        'End If
        Dim dsChanges As New DataSet
        Dim row As DataRow
        Dim TmpUpdate As String
        Dim i As Int32
        Dim SaveOK As Boolean = True

        dsChanges = dtSet.GetChanges
        For Each row In dsChanges.Tables(0).Rows
            TmpUpdate = UpdateQuery
            For i = 0 To UpdParamCols.Length - 1
                If TypeName(row(UpdParamCols(i)(1))) = "Boolean" Then
                    TmpUpdate = TmpUpdate.Replace(UpdParamCols(i)(0), Val(row(UpdParamCols(i)(1))))
                Else
                    TmpUpdate = TmpUpdate.Replace(UpdParamCols(i)(0), row(UpdParamCols(i)(1)))
                End If
            Next
            If ExecuteQuery(TmpUpdate) = False Then
                SaveOK = False
                'Message modified by Michael Pastor
                If MessageBox.Show("Unable to save account ID: " & row("AccountID") & " Would you like to continue?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                    '-If MsgBox("Error saving AccountID: " & row("AccountID") & ". Continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        Next
        If SaveOK Then
            'Message modified by Michael Pastor
            MsgBox("Save successful.", MsgBoxStyle.Information, "Save Successful")
            '- MsgBox("Saved successfully.")
        Else
            'Message modified by Michael Pastor
            MsgBox("Save process complete, but with errors.", MsgBoxStyle.Information, "Save Completed With Errors")
            '- MsgBox("Save process completed with errors.")
        End If
        'If UpdateDbFromDataSetV4(dtSet, SelectTmp, PKArray, OmitFldList, UpdateQuery, UpdParamCols) <= 0 Then
        '    'If UpdateDbFromDataSetV4(dtSet, SelectTmp, PKArray, OmitFldList) <= 0 Then
        '    MsgBox("No Records Updated!")
        '    Exit Sub
        'End If
        DataModified = False

        Dim DeleteUnusedReqSvc As String = "Delete FROM " & HOLIDAYSTblPath & "HolidayRoutes where HDate = '" & cboHDate.Text & "' AND AccountID in (Select AccountID FROM " & HOLIDAYSTblPath & "Notices Where HDate = '" & cboHDate.Text & "' And Responded = 0)"
        ExecuteQuery(DeleteUnusedReqSvc)

    End Sub

    Private Sub UltraGrid1_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.AfterCellUpdate
        If e.Cell.Column.ToString = "Responded" Then
            e.Cell.Row.Cells("Needs_Service").Activate()
            'e.Cell.Row.Cells("Needs_Service?").Selected = True
            '    e.Cell.Row.Cells("Needs_Service?").Appearance.BorderColor3DBase = System.Drawing.Color.AliceBlue
        End If
    End Sub


    Private Sub UltraGrid1_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.CellChange
        DataModified = True
        If e.Cell.Column.ToString = "Responded" Then
            If e.Cell.Text = "True" Then
                'Infrag. 2003: e.Cell.Selected = True
                e.Cell.Row.Update()
                'e.Cell.Row.Cells("Needs_Service").Activate()

                'Infrag. 2003: e.Cell.Row.Cells("Needs_Service").Selected = True
                'e.Cell.Row.Cells("Needs_Service?").Appearance.BorderColor3DBase = System.Drawing.Color.AliceBlue
            Else
                e.Cell.Row.Cells("Needs_Service").Value = False
                e.Cell.Row.Update()
            End If
        ElseIf e.Cell.Column.ToString = "Needs_Service" Then
            If e.Cell.Text = "True" Then
                e.Cell.Row.Cells("Responded").Value = True
                e.Cell.Row.Update()
            End If
        End If

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            UltraGrid1.PrintPreview(Infragistics.Win.UltraWinGrid.RowPropertyCategories.All)
        Catch ex As System.Data.SqlClient.SqlException
            'Message modified by Michael Pastor
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Catch Err As System.Exception
            'Message modified by Michael Pastor
            MsgBox("Error: " & Err.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & Err.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Catch Err2 As System.NullReferenceException
            'Message modified by Michael Pastor
            MsgBox("Error: " & Err2.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & Err2.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Finally
        End Try

    End Sub
    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown
        On Error GoTo ErrLabel

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement
            Dim oUIElement As Infragistics.Win.UIElement
            Dim oUIElementTmp As Infragistics.Win.UIElement
            Dim point As Point = New Point(e.X, e.Y)


            oUIElement = Me.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(point)
            If oUIElement Is Nothing Then Exit Sub
            'Infragistics.Win.UltraWinGrid.BandHeadersUIElement()
            'Infragistics.Win.UltraWinGrid.CaptionAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardCaptionUIElement()
            'Infragistics.Win.UltraWinGrid.CardLabelAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardLabelUIElement()
            'Infragistics.Win.UltraWinGrid.CellUIElement()
            'Infragistics.Win.UltraWinGrid.DataAreaUIElement()
            'Infragistics.Win.UltraWinGrid.PageHeaderUIElement()
            'Infragistics.Win.UltraWinGrid.PreRowAreaUIElement()
            'Infragistics.Win.UltraWinGrid.RowCellAreaUIElement()
            'Infragistics.Win.UltraWinGrid.RowSelectorUIElement()
            'Infragistics.Win.UltraWinGrid.RowUIElement()
            'Infragistics.Win.UltraWinGrid.SortIndicatorUIElement()
            'Infragistics.Win.UltraWinGrid.UltraGridUIElement()

            oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement))
            If oUIElementTmp Is Nothing Then
                oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement))
                If oUIElementTmp Is Nothing Then
                    Return
                End If
            End If
            oUIElement = oUIElementTmp
            If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement) Then
                If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement) Then
                    Exit Sub
                Else
                    oCaptionUI = oUIElement
                End If
            Else
                oHeaderUI = oUIElement
            End If

            If oCaptionUI Is Nothing Then
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("Hide", New EventHandler(AddressOf mnuHide_Click))
                CntMenu1.MenuItems.Add("Unhide")
                'CntMenu1.MenuItems.Add("Find", New EventHandler(AddressOf mnuFind_Click))
                CntMenu1.MenuItems.Add("Add to Sort (Asc)", New EventHandler(AddressOf mnuSortAsc_Click))
                CntMenu1.MenuItems.Add("Add to Sort (Desc)", New EventHandler(AddressOf mnuSortDesc_Click))


                Dim oColHeader As Infragistics.Win.UltraWinGrid.ColumnHeader = Nothing
                m_oColumn = Nothing
                oColHeader = oHeaderUI.SelectableItem
                m_oColumn = oColHeader.Column
                If m_oColumn Is Nothing Then Exit Sub


                Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
                If CntMenu1.MenuItems.Item(1).MenuItems.Count > 0 Then
                    CntMenu1.MenuItems.Item(1).MenuItems.Clear()
                    CntMenu1.MenuItems.RemoveAt(1)
                    CntMenu1.MenuItems.Add("Unhide")
                    CntMenu1.MenuItems(CntMenu1.MenuItems.Count).Index = 1
                End If
                For Each ugcol In UltraGrid1.DisplayLayout.Bands(0).Columns
                    If ugcol.Hidden = True Then
                        CntMenu1.MenuItems(1).MenuItems.Add(ugcol.ToString, New EventHandler(AddressOf SubMnuUnHide_Click))
                    End If
                Next

                CntMenu1.Show(UltraGrid1, point)
            Else 'Caption Click
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("AutoFit", New EventHandler(AddressOf mnuAutoFit_Click))
                CntMenu1.MenuItems(0).Checked = UltraGrid1.DisplayLayout.AutoFitColumns
                CntMenu1.Show(UltraGrid1, point)

            End If
        End If
        Exit Sub
ErrLabel:
        'Message modified by Michael Pastor
        MsgBox("Error: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("Error : " & Err.Description)
        'Resume
    End Sub

    Private Sub mnuAutoFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CntMenu1.MenuItems(0).Checked Then
            CntMenu1.MenuItems(0).Checked = False
        Else
            CntMenu1.MenuItems(0).Checked = True
        End If
        UltraGrid1.DisplayLayout.AutoFitColumns = CntMenu1.MenuItems(0).Checked

    End Sub

    Private Sub mnuHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuHide.Click
        If Not m_oColumn Is Nothing Then
            m_oColumn.Hidden = True
        End If
    End Sub
    Private Sub SubMnuUnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ugCol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        For Each ugCol In UltraGrid1.DisplayLayout.Bands(0).Columns
            If ugCol.ToString = sender.text Then
                ugCol.Hidden = False
            End If
        Next

    End Sub

    Private Sub mnuSortAsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortAsc.Click
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(m_oColumn, False)
    End Sub

    Private Sub mnuSortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortDesc.Click
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(Me.m_oColumn, True)
    End Sub

    Private Function CheckServiceReq(Optional ByRef ugrowref As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing) As Boolean
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        CheckServiceReq = False
        If ugrowref Is Nothing Then
            For Each ugrow In UltraGrid1.Rows
                If ugrow.ListObject Is Nothing Then
                    If ugrow.HasChild = True Then
                        CheckServiceReq(ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First))
                    End If
                    GoTo NextRow
                End If

                If ugrow.Cells("Responded").Value = True Then
                    If ugrow.Cells("Needs_Service").Value = False And ugrow.Cells("No_Service").Value = False Then
                        'Message modified by Michael Pastor
                        MsgBox("Service requirement is not set for " & ugrow.Cells("AccountName").Text, MsgBoxStyle.Exclamation, "Data Unavailable")
                        '- MessageBox.Show("Service Requirement is not set for " & ugrow.Cells("AccountName").Text)
                        Exit Function
                    End If
                    If ugrow.Cells("Needs_Service").Value = True And ugrow.Cells("No_Service").Value = True Then
                        'Message modified by Michael Pastor
                        MsgBox("Contradiction in service requirement for " & ugrow.Cells("AccountName").Text, MsgBoxStyle.Exclamation, "Data Invalid")
                        '- MessageBox.Show("Contradiction in Service Requirement for " & ugrow.Cells("AccountName").Text)
                        Exit Function
                    End If
                End If
NextRow:
            Next
        Else
            ugrow = ugrowref
            While Not ugrow Is Nothing
                If ugrow.ListObject Is Nothing Then
                    If ugrow.HasChild = True Then
                        CheckServiceReq(ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First))
                    End If
                    GoTo NextLoop
                End If

                If ugrow.Cells("Responded").Value = True Then
                    If ugrow.Cells("Needs_Service").Value = False And ugrow.Cells("No_Service").Value = False Then
                        'Message modified by Michael Pastor
                        MsgBox("Service requirement is not set for " & ugrow.Cells("AccountName").Text, MsgBoxStyle.Exclamation, "Data Unavailable")
                        '- MessageBox.Show("Service Requirement is not set for " & ugrow.Cells("AccountName").Text)
                        Exit Function
                    End If
                    If ugrow.Cells("Needs_Service").Value = True And ugrow.Cells("No_Service").Value = True Then
                        MsgBox("Contradiction in service requirement for " & ugrow.Cells("AccountName").Text, MsgBoxStyle.Exclamation, "Data Invalid")
                        '- MessageBox.Show("Contradiction in Service Requirement for " & ugrow.Cells("AccountName").Text)
                        Exit Function
                    End If
                End If
NextLoop:
                ugrow = ugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
            End While
        End If
        CheckServiceReq = True
    End Function

    Private Sub UltraGrid1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.Leave

    End Sub

    'Private Sub UltraGrid1_AfterExitEditMode(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterExitEditMode
    '    If Not UltraGrid1.ActiveRow Is Nothing Then
    '        UltraGrid1.ActiveRow.Refresh()
    '    End If
    'End Sub
End Class
