Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class PrePrintSLabel
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim dtSet As New DataSet
    'Dim cmdTrans As SqlCommand
    Dim HidCols() As String = {"AddressID"}
    'Dim DataModified As Boolean
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents utAcct As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnAcctList As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrintHistory As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.utAcctID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utAcct = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnAcctList = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnPrintHistory = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.GroupBox1.SuspendLayout()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAcct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.utAcctID)
        Me.GroupBox1.Controls.Add(Me.utAcct)
        Me.GroupBox1.Controls.Add(Me.btnAcctList)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(712, 56)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'utAcctID
        '
        Me.utAcctID.Enabled = False
        Me.utAcctID.Location = New System.Drawing.Point(328, 16)
        Me.utAcctID.Name = "utAcctID"
        Me.utAcctID.Size = New System.Drawing.Size(72, 21)
        Me.utAcctID.TabIndex = 9
        Me.utAcctID.Tag = ""
        '
        'utAcct
        '
        Me.utAcct.Location = New System.Drawing.Point(104, 16)
        Me.utAcct.Name = "utAcct"
        Me.utAcct.Size = New System.Drawing.Size(216, 21)
        Me.utAcct.TabIndex = 4
        Me.utAcct.Tag = ""
        '
        'btnAcctList
        '
        Me.btnAcctList.Location = New System.Drawing.Point(408, 16)
        Me.btnAcctList.Name = "btnAcctList"
        Me.btnAcctList.Size = New System.Drawing.Size(80, 21)
        Me.btnAcctList.TabIndex = 8
        Me.btnAcctList.Text = "Se&lect"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Account:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(576, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 15
        Me.btnDisplay.Text = "D&isplay"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 56)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(712, 405)
        Me.UltraGrid1.TabIndex = 11
        Me.UltraGrid1.Text = "Locations"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPrintHistory)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 461)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(712, 48)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'btnPrintHistory
        '
        Me.btnPrintHistory.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPrintHistory.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrintHistory.Location = New System.Drawing.Point(3, 16)
        Me.btnPrintHistory.Name = "btnPrintHistory"
        Me.btnPrintHistory.Size = New System.Drawing.Size(93, 29)
        Me.btnPrintHistory.TabIndex = 5
        Me.btnPrintHistory.Text = "&Print Preview"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(634, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 29)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'PrePrintSLabel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(712, 509)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PrePrintSLabel"
        Me.Text = "Pre-Print S-Label"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAcct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PrePrintSLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = TRCTblPath & Me.Tag
            End If
        End If


        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        'AddHandler utStartMile.KeyPress, AddressOf Value_Int_KeyPress
        'AddHandler utInvoiceNo.KeyPress, AddressOf Value_Int_KeyPress
        '
        'cmdTrans = Nothing

        'UltraDate1.Nullable = True
        'UltraDate1.Value = Nothing 'Date.Now
        'UltraDate1.FormatString = "MM/dd/yyyy"

        'UltraDate2.Nullable = True
        'UltraDate2.Value = Nothing 'Date.Now
        'UltraDate2.FormatString = "MM/dd/yyyy"

        utAcct.MaxLength = 30
        UltraGrid1.Text = "Locations"

    End Sub

    Private Sub utAcct_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utAcct.ValueChanged

    End Sub

    Private Sub utAcct_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcct.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utAcctID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for TruckID!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, utAcctID, TRCTblPath & "Customer", "CustomerID", "Name", "*", "Accounts", " Where Active = 'Y'") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
                LoadData()
            Else
                'MsgBox("Truck Not Found.")
                utAcctID.Text = ""
                utAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utAcct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utAcct.KeyUp
        Dim sCustomer As String = "FilteredCustomerList('" & LoginInfo.UserID & "')"
        'TypeAhead(sender, e, TRCTblPath & "Customer", "Name", " Where Active = 'Y'")
        TypeAhead(sender, e, TRCTblPath & sCustomer, "Name", " Where Active = 'Y'")
    End Sub

    Private Sub btnAcctList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcctList.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        'SelectSQL = "Select * FROM " & TRCTblPath & "Customer i WHERE (Active = 'Y') order by Name"
        SelectSQL = "Select * FROM " & TRCTblPath & "FilteredCustomerList('" & LoginInfo.UserID & "') WHERE (Active = 'Y') order by Name"

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
                    'AcctName.Text = ugRow.Cells("Name").Text
                    utAcct.Text = ugRow.Cells("Name").Text
                    utAcctID.Text = ugRow.Cells("CustomerID").Text
                    Srch = Nothing
                    utAcct.Modified = False
                    utAcctID.Modified = False
                    LoadData()
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        LoadData()
    End Sub

    Enum cols
        _00CHK
        _01LocID
        _02LDate
        _03LTRNo
        _04LQty
        _05Name
        _06Adr1
        _07Adr2
        _08City
        _09State
        _10Zip
        _11Contact
        _12Phone
        _13AdrID
    End Enum
    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, TmpQuery, SQLInventory As String



        SQLSelect = " Select Convert(bit, 0) as CHK, c.LocationID, convert(varchar, l.SysDate, 101) as LDate, isnull(l.LastPrintedNum, 0) as [Last P.Num], isnull(l.LastQty, 0) as LastQty, c.Name, c.Address1, c.Address2, c.City, c.State, c.Zip, c.contact, c.phone, c.AddressID from " & TRCTblPath & "location c, " & TRCTblPath & "PrePrintedLabels l Where c.customerid *= l.customerid and c.locationid *= l.locationid and c.customerid = @CUSTID and c.Active = 'Y' order by c.locationid"

        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If
        If utAcctID.Text.Trim = "" Then
            MsgBox("Provider not selected.")
            Exit Sub
        End If
        TmpQuery = SQLSelect.Replace("@CUSTID", "'" & utAcctID.Text & "'")

        PopulateDataset2(dtAdapter, dtSet, TmpQuery)

        For i = 1 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid1, dtSet, 1, HidCols, 0)

        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        UltraGrid1.DisplayLayout.AutoFitColumns = True
        For i = 1 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next
        'UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummary

        'UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid1.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("LocationID", Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns("LocationID"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid1.DisplayLayout.Bands(0).Summaries("LocationID").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        UltraGrid1.Text = "Locations"
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
        Exit Sub
ErrLabel:
        MsgBox("Error : " & Err.Description)
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

    '=================================================================================================================
    '=================================================================================================================
    '================================             Search Routines              =======================================
    '=================================================================================================================

    Private m_searchForm As frmSearchInfo = Nothing
    Private m_searchInfo As clsSearchInfo = New clsSearchInfo

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.m_oColumn Is Nothing Then Exit Sub

        If Me.m_searchForm Is Nothing Then
            Me.m_searchForm = New frmSearchInfo
        End If

        Me.m_searchForm.ShowMe(Me, Me.m_oColumn.Key, UltraGrid1, m_searchInfo)

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnPrintHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintHistory.Click
        Dim ugrow, ugrowparent, ugrowtmp As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim ugBand As Infragistics.Win.UltraWinGrid.UltraGridBand

        'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        ugrow = UltraGrid1.Rows(0)
        If ugrow Is Nothing Then
            MsgBox("Nothing to Process.")
            Exit Sub
        End If

        FindRows(ugrow)
        LoadData()

        'For Each ugrow In UltraGrid1.Rows
        '    FindRows(ugrow)
        'Next
    End Sub

    Private Function FindRows(ByVal ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Infragistics.Win.UltraWinGrid.UltraGridRow
        If ugrow.ListObject Is Nothing Then
            'ugrow = ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
            While Not ugrow Is Nothing
                FindRows(ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First))
                ugrow = ugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
            End While
        Else
            ProcessRows(ugrow)
        End If

    End Function

    Private Sub ProcessRows(ByVal ugrowtmp As Infragistics.Win.UltraWinGrid.UltraGridRow)
        While Not ugrowtmp Is Nothing
            If ugrowtmp.Cells("CHK").Value = True Then
                Dim x As New PrintLabels
                x.Label1.Text = ugrowtmp.Cells(cols._01LocID).Value & " - " & ugrowtmp.Cells(cols._05Name).Value
                x.CustID = utAcctID.Text.Trim
                x.LocID = ugrowtmp.Cells(cols._01LocID).Value
                x.StartCounter = Val(ugrowtmp.Cells(cols._03LTRNo).Value) + 1
                x.AddressID = ugrowtmp.Cells(cols._13AdrID).Value
                x.ShowDialog(Me)
                x = Nothing
            End If
            ugrowtmp = ugrowtmp.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
        End While

    End Sub
End Class
