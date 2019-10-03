Imports System.Data
Imports System.Data.SqlClient

Public Class InvoiceAssignment
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim cmdTrans As SqlCommand
    Dim HidCols() As String = {"ACT_ID", "Driver_ID", "Office_ID", "Truck_Invent_ID"}
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents UltraDate2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents utTruckInventID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utTruckID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utInvoiceNo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents utStartMile As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnTrucks As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.utTruckInventID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utTruckID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnTrucks = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.UltraDate2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkSelectAll = New System.Windows.Forms.CheckBox
        Me.utStartMile = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.utInvoiceNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.GroupBox1.SuspendLayout()
        CType(Me.utTruckInventID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTruckID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utStartMile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utInvoiceNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.utTruckInventID)
        Me.GroupBox1.Controls.Add(Me.utTruckID)
        Me.GroupBox1.Controls.Add(Me.btnTrucks)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.UltraDate2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.UltraDate1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(864, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'utTruckInventID
        '
        Me.utTruckInventID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTruckInventID.Enabled = False
        Me.utTruckInventID.Location = New System.Drawing.Point(256, 17)
        Me.utTruckInventID.Name = "utTruckInventID"
        Me.utTruckInventID.Size = New System.Drawing.Size(16, 21)
        Me.utTruckInventID.TabIndex = 1
        Me.utTruckInventID.Tag = ".Truck_Invent_ID"
        Me.utTruckInventID.Visible = False
        '
        'utTruckID
        '
        Me.utTruckID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTruckID.Location = New System.Drawing.Point(72, 17)
        Me.utTruckID.Name = "utTruckID"
        Me.utTruckID.Size = New System.Drawing.Size(176, 21)
        Me.utTruckID.TabIndex = 0
        Me.utTruckID.Tag = ".TruckID"
        '
        'btnTrucks
        '
        Me.btnTrucks.Location = New System.Drawing.Point(272, 17)
        Me.btnTrucks.Name = "btnTrucks"
        Me.btnTrucks.Size = New System.Drawing.Size(63, 21)
        Me.btnTrucks.TabIndex = 2
        Me.btnTrucks.TabStop = False
        Me.btnTrucks.Text = "Select"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 141
        Me.Label9.Text = "Truck ID :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate2
        '
        Me.UltraDate2.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate2.Location = New System.Drawing.Point(600, 16)
        Me.UltraDate2.Name = "UltraDate2"
        Me.UltraDate2.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate2.TabIndex = 4
        Me.UltraDate2.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(552, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "To Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(456, 17)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate1.TabIndex = 3
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(392, 21)
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
        Me.GroupBox2.Controls.Add(Me.chkSelectAll)
        Me.GroupBox2.Controls.Add(Me.utStartMile)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.utInvoiceNo)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 421)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(864, 64)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'chkSelectAll
        '
        Me.chkSelectAll.Location = New System.Drawing.Point(32, 24)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.TabIndex = 0
        Me.chkSelectAll.Text = "Select All"
        '
        'utStartMile
        '
        Me.utStartMile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utStartMile.Location = New System.Drawing.Point(328, 24)
        Me.utStartMile.Name = "utStartMile"
        Me.utStartMile.Size = New System.Drawing.Size(72, 21)
        Me.utStartMile.TabIndex = 1
        Me.utStartMile.Tag = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(232, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "Invoice Starting Mileage:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utInvoiceNo
        '
        Me.utInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utInvoiceNo.Location = New System.Drawing.Point(472, 22)
        Me.utInvoiceNo.Name = "utInvoiceNo"
        Me.utInvoiceNo.Size = New System.Drawing.Size(88, 21)
        Me.utInvoiceNo.TabIndex = 2
        Me.utInvoiceNo.Tag = ".Inv_No"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(408, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "Invoice#:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(616, 24)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 21)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Save"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 48)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(864, 256)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Text = "Truck Activity List"
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid2.Location = New System.Drawing.Point(0, 304)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(864, 117)
        Me.UltraGrid2.TabIndex = 3
        Me.UltraGrid2.Text = "Inventory Activity"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 304)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(864, 3)
        Me.Splitter1.TabIndex = 4
        Me.Splitter1.TabStop = False
        '
        'InvoiceAssignment
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(864, 485)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "InvoiceAssignment"
        Me.Tag = "DAILYACTIVITY"
        Me.Text = "Trucks Invoice Assignment"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utTruckInventID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTruckID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utStartMile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utInvoiceNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InvoiceAssignment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        AddHandler utStartMile.KeyPress, AddressOf Value_Int_KeyPress
        'AddHandler utInvoiceNo.KeyPress, AddressOf Value_Int_KeyPress
        '
        cmdTrans = Nothing

        UltraDate1.Nullable = True
        UltraDate1.Value = Nothing 'Date.Now
        UltraDate1.FormatString = "MM/dd/yyyy"

        UltraDate2.Nullable = True
        UltraDate2.Value = Nothing 'Date.Now
        UltraDate2.FormatString = "MM/dd/yyyy"

        utInvoiceNo.MaxLength = 10
        UltraGrid1.Text = "Truck Activity List"

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
        If DataModified Then
            If MsgBox("Data has changed. Do you want to save?", MsgBoxStyle.YesNo, "Data Changed") = MsgBoxResult.Yes Then
                btnSave_Click(btnSave, e1)
            End If
        End If

        dtSet.Dispose()
        dtSet = Nothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim i As Integer
        Dim ActivityIDs, Updqry As String

        If utTruckInventID.Text = "" Or utTruckInventID.Text = "0" Then
            MsgBox("Truck not selected.")
            Exit Sub
        End If
        If UltraGrid1.DataSource Is Nothing Then
            MsgBox("No data displayed.")
            Exit Sub
        End If
        If utStartMile.Text.Trim = "" Then
            MsgBox("Invoice Start Mile not inputted.")
            Exit Sub
        End If

        ActivityIDs = "("

        For i = 0 To UltraGrid1.Rows.Count - 1
            If UltraGrid1.Rows(i).Cells(0).Value = True And UltraGrid1.Rows(i).Cells(cols._02Inv_No).Value = "" Then
                ActivityIDs = ActivityIDs & UltraGrid1.Rows(i).Cells("Act_ID").Value & ", "
            End If
        Next
        ActivityIDs = ActivityIDs.Trim
        If Len(ActivityIDs) = 1 Then
            MsgBox("No records selected.")
            Exit Sub
        End If
        ActivityIDs = ActivityIDs.Substring(0, Len(ActivityIDs) - 1) & ")"
        Updqry = "Update " & TrucksVars.TRUCKSTblPath & "DailyActivity set Inv_No = '" & utInvoiceNo.Text & "' where Act_ID in " & ActivityIDs
        If ExecuteQuery(Updqry) = True Then
            MsgBox("Invoice number applied successfully.")
        Else
            MsgBox("Error Applying Invoice number.")
        End If
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        LoadData()
    End Sub

    Enum cols
        _00CHK
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



        SQLSelect = " Select Convert(bit, 0) as CHK, da.Act_Date, da.Inv_No as [Inv#], da.Act_ID, da.Route, da.Driver_ID, da.Driver, da.Office_ID, so.Name as Office, da.Truck_Invent_ID, da.Start_Miles, da.End_Miles, da.End_Miles-da.Start_Miles as Mileage, da.Fuel from " & Me.Tag & " da, " & TrucksVars.TRUCKSTblPath & "Inventory i, " & AppTblPath & "ServiceOffices so Where da.truck_invent_ID = i.Truck_Invent_ID AND da.OFFICE_ID = so.ID AND da.Act_Date Between @DATE1 AND @DATE2 and da.Truck_Invent_ID = @TRKID Order By ACT_Date"
        'SQLInventory = "Select TruckID, Lic_Plate, VIN, Provider, Date_In, Miles_In, Office_In, Operator_In, Date_Out, Miles_Out, Office_Out, Operator_Out, [Truck Size], Remarks from TrucksManagement.dbo.INVENTORY where Date_In >= (Select isnull(max(Date_IN), @DATE1) from TrucksManagement.dbo.INVENTORY where Date_In <= @DATE1 and TruckID = @TRKID) AND Date_OUT in (Select min(Date_OUT) from TrucksManagement.dbo.INVENTORY where Date_OUT >= @DATE2 and TruckID = @TRKID) and TruckID = @TRKID"
        SQLInventory = "Select TruckID, Lic_Plate, VIN, Provider, Date_In, Miles_In, Office_In, Operator_In, Date_Out, Miles_Out, Office_Out, Operator_Out, [Truck Size], Remarks from " & TrucksVars.TRUCKSTblPath & "INVENTORY " & _
                        " where Date_In >= (Select isnull(max(Date_IN), '@DATE1') from " & TrucksVars.TRUCKSTblPath & "INVENTORY where Date_In <= '@DATE1' and TruckID = '@TRKID') " & _
                        " and Date_In <= '@DATE2'" & _
                        " and TruckID = '@TRKID'"

        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If
        If utTruckID.Text.Trim = "" Then
            MsgBox("Provider not selected.")
            Exit Sub
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
        TmpQuery = TmpQuery.Replace("@TRKID", utTruckInventID.Text)

        PopulateDataset2(dtAdapter, dtSet, TmpQuery)

        TmpQuery = SQLInventory.Replace("@DATE1", UltraDate1.Text)
        TmpQuery = TmpQuery.Replace("@DATE2", UltraDate2.Text)
        TmpQuery = TmpQuery.Replace("@TRKID", utTruckID.Text)

        PopulateDataset2(dtAdapter, dtSet, TmpQuery, True)

        btnSave.Text = "&Save"

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
        For i = 1 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
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
        UltraGrid1.Text = "Truck Activity List"
    End Sub
    Private Sub utTruckID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utTruckID.KeyUp
        TypeAhead(sender, e, TrucksVars.TRUCKSTblPath & "Inventory", "TruckID", " Where (Truck_Invent_ID IN (SELECT DISTINCT da.Truck_Invent_ID FROM " & TrucksVars.TRUCKSTblPath & "DAILYACTIVITY da WHERE (da.Inv_No IS NULL) OR (da.Inv_No = '')))")
        '"Select TruckID, Truck_Invent_ID, Lic_Plate, VIN, Provider from TrucksManagement.dbo.Inventory iWHERE     (Truck_Invent_ID IN  (SELECT DISTINCT da.Truck_Invent_ID  FROM  DAILYACTIVITY da WHERE (da.Inv_No IS NULL) OR (da.Inv_No = ''))) order by TruckID"
        'sender.modified = True
    End Sub

    Private Sub utTruckID_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utTruckID.ValueChanged

    End Sub

    Private Sub btnTrucks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrucks.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select TruckID, Truck_Invent_ID, Lic_Plate, VIN, Provider from " & TrucksVars.TRUCKSTblPath & "Inventory i WHERE (Truck_Invent_ID IN (SELECT DISTINCT da.Truck_Invent_ID  FROM " & TrucksVars.TRUCKSTblPath & "DAILYACTIVITY da WHERE (da.Inv_No IS NULL) OR (da.Inv_No = ''))) order by TruckID"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Truck Providers"
            Srch.Text = "Truck Providers"
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
                    utTruckID.Text = ugRow.Cells("TruckID").Text
                    utTruckInventID.Text = ugRow.Cells("Truck_Invent_ID").Text
                    Srch = Nothing
                    utTruckID.Modified = False
                    utTruckInventID.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub utTruckID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utTruckID.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utTruckInventID.Text = ""
            'btnSave.Enabled = False
        Else
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If
            If SearchOnLeave(sender, utTruckInventID, TrucksVars.TRUCKSTblPath & "Inventory", "Truck_Invent_ID", "TruckID", ", Date_Out", "Trucks", " Where (Truck_Invent_ID IN (SELECT DISTINCT da.Truck_Invent_ID FROM " & TrucksVars.TRUCKSTblPath & "DAILYACTIVITY da WHERE (da.Inv_No IS NULL) OR (da.Inv_No = '')))") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
            Else
                'MsgBox("Truck Not Found.")
                utTruckInventID.Text = ""
                utTruckID.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False
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

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        Dim i As Int32

        For i = 0 To UltraGrid1.Rows.Count - 1
            UltraGrid1.Rows(i).Cells("CHK").Value = chkSelectAll.Checked
            UltraGrid1.Rows(i).Update()
        Next
        'UltraGrid1.Update()
        'UltraGrid1.Refresh()
    End Sub

    Private Sub utStartMile_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utStartMile.ValueChanged

    End Sub

    Private Sub utStartMile_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utStartMile.Leave
        Dim LastEndMile As Decimal
        Dim EndMileQry As String = "Select top 1 * from " & TrucksVars.TRUCKSTblPath & "DailyActivity where Inv_No <> '' and Inv_No is not NULL and Truck_Invent_ID = " & utTruckInventID.Text & " order by Act_Date desc"
        Dim row As DataRow
        Dim conn As SqlConnection = New SqlConnection(strConnection)
        Dim cmd As SqlCommand = New SqlCommand(EndMileQry, conn)
        Dim Rdr As SqlDataReader

        If sender.modified = False Then Exit Sub

        If sender.text.trim = "" Then
            sender.text = ""
            Exit Sub
        End If
        If utTruckInventID.Text = "" Or utTruckInventID.Text = "0" Then
            MsgBox("Truck is not selected.")
            Exit Sub
        End If
        cmd.CommandType = CommandType.Text
        cmd.Connection.Open()
        Rdr = cmd.ExecuteReader()
        If Rdr.Read = True Then
            If Rdr.Item("End_Miles") > Val(sender.text) Then
                MsgBox("Mileage entered is less than last billed mileage.")
                sender.focus()
                Exit Sub
            End If
        End If
        Rdr.Close()
        Rdr = Nothing
        cmd.Connection.Close()
    End Sub

    Private Sub utInvoiceNo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utInvoiceNo.ValueChanged

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

End Class
