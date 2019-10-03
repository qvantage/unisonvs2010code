Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class WeightPlanListing1
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = _
            "Select mft.ID, isnull(wpgrp.Name, '') as Manifest, mft.Name as [Wgt.Plan], isnull(ag.Group_Name, '') as [Acct.Grp.], isnull(gc.Club_Name, '') as Club_Name, mft.AccountID, c.name as [Acct. Name], mft.OfficeID as [Wgt.Ctr.ID] " & _
            " ,so.Name as [Wgt. Ctr.], mft.WeightID, wbd.WeightLimit, wbd.OWCharge " & _
            " ,mft.CompName as Company, mft.Street, mft.CityName, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2 " & _
            " , mft.GroupID as [Manifest ID], mft.StartDate, mft.EndDate, mft.Remarks, mft.ParentID, isnull(mftParent.Name, '') as Parent_Plan, mft.SID " & _
            " from (((((" & WeightVars.WEIGHTTblPath & "Manifests mft LEFT OUTER JOIN " & WeightVars.WEIGHTTblPath & "WeightBreakdown wbd ON mft.weightid = wbd.id) " & _
            " LEFT OUTER JOIN " & AppTblPath & "Customer c ON mft.accountid = c.id) left outer join " & AppTblPath & "GroupClubMembers gcm on gcm.MemberID = convert(varchar, c.ID) AND gcm.MemberType = '" & GrpMemType(enGrpMemType.Acct) & "' and gcm.GroupID = '" & ModuleGroup(enGroups.Wgt) & "' left outer JOIN " & AppTblPath & "Groups ag ON gcm.GroupID = ag.GroupID and gcm.GroupID = '" & ModuleGroup(enGroups.Wgt) & "' left outer join " & AppTblPath & "GroupClubs gc on gc.ClubID = gcm.ClubID) " & _
            " LEFT OUTER JOIN " & AppTblPath & "ServiceOffices so ON mft.officeid = so.id) LEFT OUTER JOIN " & WeightVars.WEIGHTTblPath & "WeightPlanGroups wpgrp ON mft.GroupID = wpgrp.ID)" & _
            " LEFT OUTER JOIN " & WeightVars.WEIGHTTblPath & "Manifests mftParent on mft.ParentID = mftParent.ID " & _
            " ORDER BY mft.ID "
    '" WHERE mft.accountid *= c.id AND mft.officeid *= so.id AND mft.weightid *= wbd.id " & _
    '" AND mft.GroupID *= wpgrp.ID AND c.AcctGroupID *= ag.ID " & _
    'Dim Template As Infragistics.Win.UltraWinGrid.UltraGridDisplayLayout()

    Dim TemplateID As Integer
    Dim Template As String

    Dim sqlCondition As String

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Private m_searchForm As frmSearchInfo = Nothing
    Private m_searchInfo As clsSearchInfo = New clsSearchInfo()

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
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CondID As System.Windows.Forms.TextBox
    Friend WithEvents Condition As System.Windows.Forms.TextBox
    Friend WithEvents rbNone As System.Windows.Forms.RadioButton
    Friend WithEvents rbAcct As System.Windows.Forms.RadioButton
    Friend WithEvents rbAcctGrp As System.Windows.Forms.RadioButton
    Friend WithEvents rbManifest As System.Windows.Forms.RadioButton
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkExpandAll = New System.Windows.Forms.CheckBox
        Me.btnPreview = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.CondID = New System.Windows.Forms.TextBox
        Me.Condition = New System.Windows.Forms.TextBox
        Me.rbNone = New System.Windows.Forms.RadioButton
        Me.rbAcct = New System.Windows.Forms.RadioButton
        Me.rbAcctGrp = New System.Windows.Forms.RadioButton
        Me.rbManifest = New System.Windows.Forms.RadioButton
        Me.btnExcel = New System.Windows.Forms.Button
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.chkExpandAll)
        Me.GroupBox1.Controls.Add(Me.btnPreview)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 385)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 40)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Location = New System.Drawing.Point(232, 16)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(80, 16)
        Me.chkExpandAll.TabIndex = 17
        Me.chkExpandAll.Text = "Expand All"
        '
        'btnPreview
        '
        Me.btnPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPreview.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPreview.Location = New System.Drawing.Point(3, 16)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(96, 21)
        Me.btnPreview.TabIndex = 5
        Me.btnPreview.Text = "Pre&view"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(693, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 21)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraGrid1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(792, 336)
        Me.Panel1.TabIndex = 4
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(792, 336)
        Me.UltraGrid1.TabIndex = 3
        Me.UltraGrid1.Text = "Account Weight-Plans"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem4})
        Me.MenuItem1.Text = "Templates"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Load"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Save As"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "Delete"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(792, 48)
        Me.Panel2.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDisplay)
        Me.GroupBox2.Controls.Add(Me.CondID)
        Me.GroupBox2.Controls.Add(Me.Condition)
        Me.GroupBox2.Controls.Add(Me.rbNone)
        Me.GroupBox2.Controls.Add(Me.rbAcct)
        Me.GroupBox2.Controls.Add(Me.rbAcctGrp)
        Me.GroupBox2.Controls.Add(Me.rbManifest)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(792, 48)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'btnDisplay
        '
        Me.btnDisplay.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDisplay.Location = New System.Drawing.Point(704, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(75, 21)
        Me.btnDisplay.TabIndex = 6
        Me.btnDisplay.Text = "Dis&play"
        '
        'CondID
        '
        Me.CondID.Location = New System.Drawing.Point(659, 16)
        Me.CondID.Name = "CondID"
        Me.CondID.Size = New System.Drawing.Size(21, 20)
        Me.CondID.TabIndex = 5
        Me.CondID.Text = ""
        Me.CondID.Visible = False
        '
        'Condition
        '
        Me.Condition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Condition.Location = New System.Drawing.Point(400, 16)
        Me.Condition.Name = "Condition"
        Me.Condition.Size = New System.Drawing.Size(248, 20)
        Me.Condition.TabIndex = 4
        Me.Condition.Text = ""
        '
        'rbNone
        '
        Me.rbNone.Location = New System.Drawing.Point(8, 16)
        Me.rbNone.Name = "rbNone"
        Me.rbNone.Size = New System.Drawing.Size(88, 24)
        Me.rbNone.TabIndex = 3
        Me.rbNone.Text = "No Condition"
        '
        'rbAcct
        '
        Me.rbAcct.Location = New System.Drawing.Point(319, 16)
        Me.rbAcct.Name = "rbAcct"
        Me.rbAcct.Size = New System.Drawing.Size(72, 24)
        Me.rbAcct.TabIndex = 2
        Me.rbAcct.Text = "Account"
        '
        'rbAcctGrp
        '
        Me.rbAcctGrp.Location = New System.Drawing.Point(207, 16)
        Me.rbAcctGrp.Name = "rbAcctGrp"
        Me.rbAcctGrp.TabIndex = 1
        Me.rbAcctGrp.Text = "Account Club"
        '
        'rbManifest
        '
        Me.rbManifest.Location = New System.Drawing.Point(119, 16)
        Me.rbManifest.Name = "rbManifest"
        Me.rbManifest.Size = New System.Drawing.Size(72, 24)
        Me.rbManifest.TabIndex = 0
        Me.rbManifest.Text = "Manifest"
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(112, 16)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(96, 21)
        Me.btnExcel.TabIndex = 18
        Me.btnExcel.Text = "Export to E&xcel"
        '
        'UltraGridExcelExporter1
        '
        Me.UltraGridExcelExporter1.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.ThrowException
        '
        'WeightPlanListing1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 425)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Menu = Me.MainMenu1
        Me.Name = "WeightPlanListing1"
        Me.Tag = "WeightPlanListing1"
        Me.Text = "Weight Plan Listing"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub WeightPlanListing1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = WeightVars.WEIGHTTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        rbNone.Checked = True

        'LoadData()

    End Sub
    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim CondTmp, SummFld As String

        CondTmp = ""
        If Condition.Enabled Then
            If CondID.Text.Trim = "" Then
                MsgBox("Please input the condition value.")
                Exit Sub
            End If
            CondTmp = sqlCondition & CondID.Text & "'"
        End If
        PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SQLSelect, CondTmp))

        FillUltraGrid(UltraGrid1, dtSet, 0)
        'UGLoadListingLayout(UltraGrid1, TemplateID)
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        SummFld = "ID"
        UltraGrid1.DisplayLayout.Bands(0).Summaries.Add(SummFld, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns(SummFld), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid1.DisplayLayout.Bands(0).Summaries(SummFld).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        'ultragrid1.DisplayLayout.Bands(0).
        Me.Text = MeText

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            UltraGrid1.PrintPreview()
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Catch Err As System.Exception
            MsgBox("Error: " & Err.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Catch Err2 As System.NullReferenceException
            MsgBox("Error: " & Err2.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Finally
        End Try

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'UGSaveLayout(Me, UltraGrid1, 1)
        Me.Close()

    End Sub
    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown

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
                CntMenu1.MenuItems.Add("Find", New EventHandler(AddressOf mnuFind_Click))
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

    Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
        If chkExpandAll.Checked Then
            Me.UltraGrid1.Rows.ExpandAll(True)
        Else
            Me.UltraGrid1.Rows.CollapseAll(True)
        End If
    End Sub

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.m_oColumn Is Nothing Then Exit Sub

        If Me.m_searchForm Is Nothing Then
            Me.m_searchForm = New frmSearchInfo()
        End If

        Me.m_searchForm.ShowMe(Me, Me.m_oColumn.Key, UltraGrid1, m_searchInfo)

    End Sub

    '*********************************************************************************************************
    '*************************************** Search Routines  ************************************************
    '*********************************************************************************************************

    Public ReadOnly Property SearchInfo()
        Get
            SearchInfo = Me.m_searchInfo
        End Get
    End Property

    Public Sub Search()

        '   See if there is an active row; if there is, use it, otherwise
        '   activate the first row and start the search from there
        Dim oRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        oRow = Me.UltraGrid1.ActiveRow
        If oRow Is Nothing Then oRow = Me.UltraGrid1.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)

        '   Use the row object's GetSibling method to iterate through the rows
        '   and check the appropriate cell values

        '   Downward search
        If Me.m_searchInfo.searchDirection = SearchDirectionEnum.Down Then
            While Not oRow Is Nothing
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
                If Me.MatchText(oRow) Then
                    Me.UltraGrid1.ActiveRow = oRow
                    If Not Me.m_oColumn Is Nothing Then
                        Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
                        Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
            End While

            '   Upward search
        ElseIf Me.m_searchInfo.searchDirection = SearchDirectionEnum.Up Then
            While Not oRow Is Nothing
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous)
                If Me.MatchText(oRow) Then
                    Me.UltraGrid1.ActiveRow = oRow
                    If Not Me.m_oColumn Is Nothing Then
                        Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
                        Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
            End While

            '   Search all rows. First, we start with the active row. If we don't find
            '   it by the time we hit the  last row, try again starting from the first row
        ElseIf Me.m_searchInfo.searchDirection = SearchDirectionEnum.All Then
            While Not oRow Is Nothing
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
                If Me.MatchText(oRow) Then
                    Me.UltraGrid1.ActiveRow = oRow
                    If Not Me.m_oColumn Is Nothing Then
                        Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
                        Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
            End While

            '   We didn't find it the first time around, so start again from the first row
            oRow = Me.UltraGrid1.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)
            While Not oRow Is Nothing
                If Me.MatchText(oRow) Then
                    Me.UltraGrid1.ActiveRow = oRow
                    If Not Me.m_oColumn Is Nothing Then
                        Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
                        Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
            End While

        End If

        '   If we get this far, we didn't find the string, so show a message box
        MessageBox.Show("UltraGrid has searched all the records. The search item '" & Me.m_searchInfo.searchString & "' was not found.", "Infragistics UltraGrid", MessageBoxButtons.OK, MessageBoxIcon.None)

    End Sub

    Private Function MatchText(ByVal oRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Boolean
        If oRow Is Nothing Then
            MatchText = False
            Exit Function
        End If
        If oRow.ListObject Is Nothing Then
            MatchText = False
            Exit Function
        End If

        Dim strColumnKey As String = Me.m_searchInfo.lookIn
        Dim oCol As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim strCellValue As String = ""

        '   Determine whether we are searching the current column or all columns
        Dim bSearchAllColumns = True
        If Me.UltraGrid1.DisplayLayout.Bands(0).Columns.Exists(strColumnKey) Then bSearchAllColumns = False

        '   If we are searching all columns then we must iterate through all the cells
        '    in this row, which we can do by using the band's Columns collection
        If bSearchAllColumns Then
            For Each oCol In Me.UltraGrid1.DisplayLayout.Bands(0).Columns
                If Not oRow.Cells(oCol.Key).Value Is Nothing Then
                    If Me.Match(Me.m_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
                        MatchText = True
                        Me.m_oColumn = oCol
                        Exit Function
                    End If
                End If
            Next
        Else
            oCol = Me.UltraGrid1.DisplayLayout.Bands(0).Columns(strColumnKey)
            If Not oRow.Cells(oCol.Key).Value Is Nothing Then
                If Me.Match(Me.m_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
                    MatchText = True
                    Me.m_oColumn = oCol
                    Exit Function
                End If
            End If
        End If

    End Function

    Private Function Match(ByVal userString As String, ByVal cellValue As String) As Boolean

        '   If our search is case insensitive, make both strings uppercase
        If Not Me.m_searchInfo.matchCase Then
            userString = userString.ToUpper
            cellValue = cellValue.ToUpper
        End If

        '   If we are searching any part of the cell value...
        If Me.m_searchInfo.searchContent = SearchContentEnum.AnyPartOfField Then

            '   If the user string is larger than the cell value, it is by definition
            '   a mismatch, so return false
            If userString.Length > cellValue.Length Then
                Match = False
                Exit Function
            ElseIf userString.Length = cellValue.Length Then
                '   If the lengths are equal, the strings must be equal as well
                If userString = cellValue Then Match = True Else Match = False
                Exit Function
            Else
                '   There is probably an easier way to do this
                Dim i As Integer
                For i = 0 To (cellValue.Length - userString.Length) - 0
                    If userString = cellValue.Substring(i, userString.Length) Then
                        Match = True
                        Exit Function
                    End If
                Next
                Match = False
                Exit Function

            End If

        ElseIf Me.m_searchInfo.searchContent = SearchContentEnum.WholeField Then
            If userString = cellValue Then Match = True Else Match = False
            Exit Function

        ElseIf Me.m_searchInfo.searchContent = SearchContentEnum.StartOfField Then
            If userString.Length >= cellValue.Length Then
                If userString.Substring(0, cellValue.Length) = cellValue Then
                    Match = True
                Else
                    Match = False
                End If
                Exit Function
            Else
                If cellValue.Substring(0, userString.Length) = userString Then Match = True Else Match = False
                Exit Function
            End If

        End If

    End Function

    Public Class clsSearchInfo
        Public searchString As String = ""
        Public lookIn As String
        Public searchDirection As SearchDirectionEnum = SearchDirectionEnum.All
        Public searchContent As SearchContentEnum = SearchContentEnum.WholeField
        Public matchCase As Boolean = False
    End Class

    Public Enum SearchDirectionEnum
        Down = 0
        Up = 1
        All = 2
    End Enum

    Public Enum SearchContentEnum
        AnyPartOfField = 0
        WholeField = 1
        StartOfField = 2
    End Enum

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click ' Load Template
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select ID, Name from " & AppTblPath & "ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings()
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Templates"
            Srch.Text = "Weight-Plan Listing Templates"
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

                    TemplateID = ugRow.Cells("ID").Text
                    If Not UltraGrid1.DataSource Is Nothing Then
                        UGLoadListingLayout(UltraGrid1, TemplateID)
                    End If
                    Me.Text = MeText & " - Using Layout : " & ugRow.Cells("Name").Text
                    Template = ugRow.Cells("Name").Text
                End If
            End Try
            Srch = Nothing
        End If

    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Dim x As New EnterTextBox()

        x.Text = "Save Template"
        x.TextBox1.Text = Template
        x.ShowDialog()
        If x.DialogResult <> DialogResult.OK Then Exit Sub
        If Template <> x.TextBox1.Text.Trim Then
            TemplateID = 0
        End If
        Template = x.TextBox1.Text.Trim
        UGSaveListingLayout(Me, UltraGrid1, TemplateID, Template)
        x = Nothing
        If TemplateID = 0 Then
            MsgBox("Failed")
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()

        SelectSQL = "Select ID, Name from " & AppTblPath & "ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings()
            Srch.dsList = dtSet
            Srch.sqlSelect = SelectSQL
            Srch.btnDelete.Visible = True
            Srch.Button1.Enabled = False

            Srch.UltraGrid1.Text = "Templates"
            Srch.Text = "Weight-Plan Listing Templates"
            Srch.ShowDialog()
            'If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Srch = Nothing
        End If

    End Sub

    Private Sub rbNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNone.CheckedChanged, rbManifest.CheckedChanged, rbAcctGrp.CheckedChanged, rbAcct.CheckedChanged
        Select Case sender.name
            Case "rbNone"
                Condition.Enabled = False
                Condition.Text = ""
                sqlCondition = ""
            Case "rbManifest"
                Condition.Enabled = True
                sqlCondition = " Where mft.GroupID = '"
            Case "rbAcctGrp"
                Condition.Enabled = True
                sqlCondition = " Where gcm.GroupID = '" & ModuleGroup(enGroups.Wgt) & "' AND gcm.ClubID = '"
            Case "rbAcct"
                Condition.Enabled = True
                sqlCondition = " Where mft.AccountID = '"
        End Select

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        LoadData()
    End Sub


    Private Sub Condition_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Condition.Leave
        'On Error GoTo ErrTrap
        Dim daCity As New SqlDataAdapter()
        Dim dsCity As New DataSet()
        Dim dvCities1 As New DataView()
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim IDFld, NameFld, SrchTitle As String

        Dim WGTGrpSQL, TableName As String
        NameFld = "Name"
        IDFld = "ID"
        If rbManifest.Checked Then
            WGTGrpSQL = "Select * FROM " & WeightVars.WEIGHTTblPath & "WeightPlanGroups "
            TableName = WeightVars.WEIGHTTblPath & "WeightPlanGroups" 'Karina added the pass
            SrchTitle = "Weight-Plan Groups"
        ElseIf rbAcctGrp.Checked Then
            WGTGrpSQL = "Select * from " & WeightVars.WEIGHTTblPath & "GroupClubs Where GroupID = '" & ModuleGroup(enGroups.Wgt) & "' " 'AppTblPath, Karina changed the pass
            TableName = WeightVars.WEIGHTTblPath & "GroupClubs" 'Karina added the pass
            IDFld = "ClubID"
            NameFld = "Club_Name"
            SrchTitle = "Clubs"
        Else
            WGTGrpSQL = "Select * FROM " & WeightVars.WEIGHTTblPath & "Customer " 'AppTblPath, Karina changed the pass
            TableName = WeightVars.WEIGHTTblPath & "Customer" 'Karina changed the pass
            SrchTitle = "Accounts"
        End If

        HasErr = False
        If sender.Modified Then
            If IsNumeric(sender.Text) Then ' GroupID
                WGTGrpSQL = PrepSelectQuery(WGTGrpSQL, " where " & IDFld & " = '" & sender.Text & "' ")
                PopulateDataset2(daCity, dsCity, WGTGrpSQL)
                dvCities1.Table = dsCity.Tables(TableName)
                If dvCities1.Table.Rows.Count > 0 Then
                    CondID.Text = sender.Text.ToString
                    Condition.Text = dvCities1.Table.Rows(0).Item(NameFld)
                Else
                    MsgBox("ID not found!", MsgBoxStyle.OKOnly, MeText)
                    Condition.ResetText()
                    Condition.Focus()
                End If
            Else 'Blank or City Name
                If sender.text.trim() = "" Then
                    CondID.Text = ""
                    Exit Sub
                End If
                If sender.Text.StartsWith("?") Then
                    sender.text = sender.text.substring(1)
                End If
                WGTGrpSQL = PrepSelectQuery(WGTGrpSQL, " where " & NameFld & " like '" & sender.text & "%' Order by " & NameFld & " ")
                PopulateDataset2(daCity, dsCity, WGTGrpSQL)
                dvCities1.Table = dsCity.Tables(TableName)
                If dvCities1.Table.Rows.Count > 0 Then
                    If dvCities1.Table.Rows.Count > 1 Then
                        Dim Srch As New SearchListings
                        Srch.dsList = dsCity

                        Srch.UltraGrid1.Text = SrchTitle '"Manifests beginning with '" & sender.text & "' in '" & GetNextControl(sender, True).Text & "'"
                        Srch.Text = SrchTitle
                        Srch.ShowDialog()
                        If Srch.DialogResult <> DialogResult.OK Then
                            sender.focus()
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
                                Condition.Text = ugRow.Cells(NameFld).Text
                                CondID.Text = ugRow.Cells(IDFld).Text
                                Srch = Nothing
                            End If
                        End Try
                    Else ' Just one record found
                        Condition.Text = dvCities1(0).Item(NameFld) 'ugRow.Cells("City").Text
                        CondID.Text = dvCities1(0).Item(IDFld) ' ugRow.Cells("Zipcode").Text
                    End If
                Else
                    MsgBox("No matching record found!", MsgBoxStyle.OKOnly, MeText)
                End If
            End If
            sender.Modified = False
        End If
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing
        Exit Sub
ErrTrap:
        MsgBox("Error: " & Err.Description)
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing

    End Sub
    Private Sub Condition_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Condition.KeyUp
        Dim WGTGrpSQL As String
        Dim NameFld, Cond As String

        NameFld = "Name"
        Cond = ""

        If rbManifest.Checked Then
            WGTGrpSQL = WeightVars.WEIGHTTblPath & "WeightPlanGroups"
        ElseIf rbAcctGrp.Checked Then
            WGTGrpSQL = WeightVars.WEIGHTTblPath & "GroupClubs"
            NameFld = "Club_Name"
            Cond = " Where GroupID = '" & ModuleGroup(enGroups.Wgt) & "' "
        Else
            WGTGrpSQL = AppTblPath & "Customer"
        End If

        TypeAhead(sender, e, WGTGrpSQL, NameFld, Cond)
        'sender.modified = True
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim x As New EnterTextBox
        Dim FileName As String

        On Error GoTo ErrTrap

        If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "File Name:"
        x.Label2.Text = ""
        x.Label2.Visible = False
        x.btnBrowse1.Visible = True

        x.Text = "File Name"
        x.TextBox1.Enabled = True
        'x.TextBox1.Text = "c :\WeightPlanListing.xls"
        x.TextBox1.Text = ".\WeightPlanListing.xls"
        x.TextBox2.Visible = False
        'x.Show()
        x.ShowDialog(Me)
        If x.DialogResult = DialogResult.OK Then
            If x.TextBox1.Text.Trim = "" Then
                MsgBox("No file name specified.")
                Exit Sub
            End If
            FileName = x.TextBox1.Text
            x.Dispose()
            x = Nothing
            Me.UltraGridExcelExporter1.Export(Me.UltraGrid1, FileName)
        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If
    End Sub
End Class
