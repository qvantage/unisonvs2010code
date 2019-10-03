Imports System.Data
Imports System.Data.SqlClient

Public Class TrucksHistory
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim cmdTrans As SqlCommand
    Dim HidCols() As String = {"ACT_ID", "Driver_ID", "Office_ID", "Truck_Invent_ID"}
    Dim DataModified As Boolean
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim WorkSheetName As String = "SheetX"
    Dim FileName As String = ""

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
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraDate2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnPrintHistory As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.UltraDate2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnPrintHistory = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 51)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(896, 237)
        Me.UltraGrid1.TabIndex = 6
        Me.UltraGrid1.Text = "Truck Activity List"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 48)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(896, 3)
        Me.Splitter1.TabIndex = 9
        Me.Splitter1.TabStop = False
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid2.Location = New System.Drawing.Point(0, 288)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(896, 133)
        Me.UltraGrid2.TabIndex = 8
        Me.UltraGrid2.Text = "Inventory Activity"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.UltraDate2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.UltraDate1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(896, 48)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'UltraDate2
        '
        Me.UltraDate2.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate2.Location = New System.Drawing.Point(216, 20)
        Me.UltraDate2.Name = "UltraDate2"
        Me.UltraDate2.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate2.TabIndex = 4
        Me.UltraDate2.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(168, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "To Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(72, 20)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate1.TabIndex = 3
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 135
        Me.Label11.Text = "From Date:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(744, 15)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 5
        Me.btnDisplay.Text = "D&isplay"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnExcel)
        Me.GroupBox2.Controls.Add(Me.btnPrintHistory)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 421)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(896, 64)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(120, 24)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(136, 21)
        Me.btnExcel.TabIndex = 6
        Me.btnExcel.Text = "Export History To Excel"
        '
        'btnPrintHistory
        '
        Me.btnPrintHistory.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPrintHistory.Location = New System.Drawing.Point(32, 24)
        Me.btnPrintHistory.Name = "btnPrintHistory"
        Me.btnPrintHistory.Size = New System.Drawing.Size(80, 21)
        Me.btnPrintHistory.TabIndex = 5
        Me.btnPrintHistory.Text = "&Print History"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(776, 24)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'UltraGridExcelExporter1
        '
        Me.UltraGridExcelExporter1.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.ThrowException
        '
        'TrucksHistory
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(896, 485)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "TrucksHistory"
        Me.Tag = "DAILYACTIVITY"
        Me.Text = "Trucks History"
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TrucksHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = TrucksVars.TRUCKSTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        'AddHandler utInvoiceNo.KeyPress, AddressOf Value_Int_KeyPress
        '
        cmdTrans = Nothing

        UltraDate1.Nullable = True
        UltraDate1.Value = Nothing 'Date.Now
        UltraDate1.FormatString = "MM/dd/yyyy"

        UltraDate2.Nullable = True
        UltraDate2.Value = Nothing 'Date.Now
        UltraDate2.FormatString = "MM/dd/yyyy"

        UltraGrid1.Text = "Truck History"
        UltraGrid2.Text = "Truck Inventory"

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub InvoiceAssignment_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim e1 As System.EventArgs
        If Not UltraGrid1.ActiveRow Is Nothing Then
            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
            'UltraGrid1.ActiveCell.Activate()
            UltraGrid1.ActiveRow.Update()
        End If

        dtSet.Dispose()
        dtSet = Nothing
    End Sub


    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        LoadData()
    End Sub

    Enum cols
        '_00CHK
        _01Act_Date
        _02Inv_No
        _03Act_ID
        _04Route
        _05Driver_ID
        _06Driver
        _07Office_ID
        _08Office
        _09Truck_Invent_ID
        _10Start_Miles
        _11End_Miles
        _12Mileage
        _13Fuel
    End Enum
    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, TmpQuery, SQLInventory As String



        SQLSelect = " Select da.Act_Date, i.TruckID, da.Act_ID, da.Route, da.Driver_ID, da.Driver, da.Office_ID, so.Name as Office, da.Truck_Invent_ID, da.Start_Miles, da.End_Miles, da.End_Miles-da.Start_Miles as Mileage, da.Fuel from " & Me.Tag & " da, " & TrucksVars.TRUCKSTblPath & "Inventory i, " & AppTblPath & "ServiceOffices so Where da.truck_invent_ID = i.Truck_Invent_ID AND da.OFFICE_ID = so.ID AND da.Act_Date Between @DATE1 AND @DATE2 Order By ACT_Date" 'and da.Truck_Invent_ID = @TRKID 
        'SQLInventory = "Select TruckID, Lic_Plate, VIN, Provider, Date_In, Miles_In, Office_In, Operator_In, Date_Out, Miles_Out, Office_Out, Operator_Out, [Truck Size], Remarks from TrucksManagement.dbo.INVENTORY where Date_In >= (Select isnull(max(Date_IN), @DATE1) from TrucksManagement.dbo.INVENTORY where Date_In <= @DATE1 and TruckID = @TRKID) AND Date_OUT in (Select min(Date_OUT) from TrucksManagement.dbo.INVENTORY where Date_OUT >= @DATE2 and TruckID = @TRKID) and TruckID = @TRKID"
        SQLInventory = "Select TruckID, Lic_Plate, VIN, Provider, Date_In, Miles_In, Office_In, Operator_In, Date_Out, Miles_Out, Office_Out, Operator_Out, [Truck Size], Remarks FROM " & TrucksVars.TRUCKSTblPath & "INVENTORY "
        '" where Date_In >= (Select isnull(max(Date_IN), '@DATE1') from TrucksManagement.dbo.INVENTORY where Date_In <= '@DATE1') " & _
        '" and Date_In <= '@DATE2'"
        '" and TruckID = '@TRKID'" 'and TruckID = '@TRKID')

        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If
        If UltraDate1.Value Is Nothing Then
            MsgBox("'From Date' not selected.")
            Exit Sub
        End If
        If UltraDate2.Value Is Nothing Then
            MsgBox("'To Date' not selected.")
            Exit Sub
        End If
        TmpQuery = SQLSelect.Replace("@DATE1", "'" & UltraDate1.Text & "'")
        TmpQuery = TmpQuery.Replace("@DATE2", "'" & UltraDate2.Text & "'")
        'TmpQuery = TmpQuery.Replace("@TRKID", utTruckInventID.Text)

        PopulateDataset2(dtAdapter, dtSet, TmpQuery)

        TmpQuery = SQLInventory.Replace("@DATE1", UltraDate1.Text)
        'TmpQuery = TmpQuery.Replace("@DATE2", UltraDate2.Text)
        'TmpQuery = TmpQuery.Replace("@TRKID", utTruckID.Text)

        PopulateDataset2(dtAdapter, dtSet, TmpQuery, True)

        For i = 1 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        dtSet.Tables(0).Columns(0).ReadOnly = False

        For i = 1 To dtSet.Tables(1).Columns.Count - 1
            dtSet.Tables(1).Columns(i).ReadOnly = True
        Next

        FillUltraGrid(UltraGrid1, dtSet, 0, HidCols, 0)
        FillUltraGrid(UltraGrid2, dtSet, 0, HidCols, 1)

        'UGLoadLayout(Me, UltraGrid1, 1)
        'UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        'UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        UltraGrid1.DisplayLayout.AutoFitColumns = True
        For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next
        'UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummary
        UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid1.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False
        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        UltraGrid1.Text = "Truck History"

        UltraGrid2.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        UltraGrid2.Text = "Truck Inventory"

    End Sub
    Private Sub utTruckID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        TypeAhead(sender, e, TrucksVars.TRUCKSTblPath & "Inventory", "TruckID", " AND DATE_OUT is NULL ")
        'sender.modified = True
    End Sub

    Private Sub UltraGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.Click
        'Dim i As Int16
        'i = 1
    End Sub

    Private Sub UltraGrid1_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.CellChange
        'Dim i As Int16
        'i = 1
    End Sub

    Private Sub UltraGrid1_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.ClickCellButton
        'Dim i As Int16
        'i = 1
    End Sub

    Private Sub UltraGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseUp
        'Dim i As Int16
        'i = 1
    End Sub

    Private Sub UltraGrid1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.Leave
        'UltraGrid1.Update()

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

    Private Sub btnPrintHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintHistory.Click
        UltraGrid1.PrintPreview(Infragistics.Win.UltraWinGrid.RowPropertyCategories.All)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click

        Dim x As New EnterTextBox
        Dim UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid

        Select Case sender.name
            Case "btnExcel"
                UltraGrid = UltraGrid1
                WorkSheetName = "Accounts Holiday List"
                'FileName = "C :\Invoice_" & UltraGrid1.ActiveRow.Cells("Invoice_No").Value & "_Summary.XLS"
                'FileName = "C :\" & Format(Date.Today, "yyyy-MM-dd") & "TruckHistory" & ".xls"
                FileName = ".\" & Format(Date.Today, "yyyy-MM-dd") & "TruckHistory" & ".xls"
        End Select

        On Error GoTo ErrTrap

        If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "File Name:"
        x.Label2.Text = ""
        x.Label2.Visible = False
        x.btnBrowse1.Visible = True

        x.Text = "File Name"
        x.TextBox1.Enabled = True
        x.TextBox1.Text = FileName
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
            'Dim wk As New Infragistics.Excel.Workbook
            'Dim ws1, ws2 As Infragistics.Excel.Worksheet

            'ws1 = wk.Worksheets.Add("Summary")
            'ws2 = wk.Worksheets.Add("Details")
            Me.Cursor = Cursors.WaitCursor

            Me.UltraGridExcelExporter1.Export(UltraGrid, FileName)

            Me.Cursor = Cursors.Default

            'Me.UltraGridExcelExporter1.Export(Me.UltraGrid1, ws1)
            'Me.UltraGridExcelExporter1.Export(Me.UltraGrid2, ws2)

            'Dim gh As GCHandle
            'gh = GCHandle.Alloc(wk)

            'Dim ptr As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(Infragistics.Excel.Workbook)) 'Marshal.SizeOf(wk)

            'Marshal.StructureToPtr(wk, ptr, True)

            'Dim Arr() As Byte 'Marshal.SizeOf(wk)
            'Arr = Marshal.PtrToStructure(ptr, New Byte().GetType)

            'Dim strm2 As New IO.StreamWriter("C :\2SheetFile.xls")
            'strm2.Write(Arr)
            'strm2.Close()
            'strm2 = Nothing


        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            'Message modified by Michael Pastor
            MsgBox("Error in btnNewGroup_Click : " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If

    End Sub

End Class
