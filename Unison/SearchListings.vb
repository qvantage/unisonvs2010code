Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices


Public Class SearchListings

    Inherits System.Windows.Forms.Form

    Public dsList As DataSet
    Public sqlSelect As String
    Public srchSortCol As Integer
    Public HidCols As String()
    'Dim HidCols() As String = {"ACTIVE"} 'Karina added Active
    Public GenFunc As btnGenClickSub

    Friend GridProps As GridProp = Nothing
    'Public btnGenClickSub As System.Windows.Forms.Button '= Nothing 'Address of Function to be called by Gen_Click

    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    'Dim m_oRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

    Public m_oRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents btnLayout As System.Windows.Forms.Button
    Friend WithEvents btnGen As System.Windows.Forms.Button
    Friend WithEvents chkSelAllSearch As System.Windows.Forms.CheckBox
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkSelAllSearch = New System.Windows.Forms.CheckBox
        Me.btnGen = New System.Windows.Forms.Button
        Me.btnLayout = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAddNew)
        Me.GroupBox1.Controls.Add(Me.chkSelAllSearch)
        Me.GroupBox1.Controls.Add(Me.btnGen)
        Me.GroupBox1.Controls.Add(Me.btnLayout)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 319)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 46)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'chkSelAllSearch
        '
        Me.chkSelAllSearch.Location = New System.Drawing.Point(448, 18)
        Me.chkSelAllSearch.Name = "chkSelAllSearch"
        Me.chkSelAllSearch.Size = New System.Drawing.Size(72, 24)
        Me.chkSelAllSearch.TabIndex = 5
        Me.chkSelAllSearch.Text = "Select All"
        Me.chkSelAllSearch.Visible = False
        '
        'btnGen
        '
        Me.btnGen.Location = New System.Drawing.Point(264, 16)
        Me.btnGen.Name = "btnGen"
        Me.btnGen.Size = New System.Drawing.Size(80, 27)
        Me.btnGen.TabIndex = 4
        Me.btnGen.Text = "GenButton"
        Me.btnGen.Visible = False
        '
        'btnLayout
        '
        Me.btnLayout.Location = New System.Drawing.Point(360, 16)
        Me.btnLayout.Name = "btnLayout"
        Me.btnLayout.Size = New System.Drawing.Size(85, 27)
        Me.btnLayout.TabIndex = 2
        Me.btnLayout.Text = "Save &Layout"
        Me.btnLayout.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(87, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 27)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.Visible = False
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.Location = New System.Drawing.Point(3, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 27)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "&Select"
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.Location = New System.Drawing.Point(525, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 27)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "E&xit"
        '
        'UltraGrid1
        '
        Appearance1.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.UltraGrid1.DisplayLayout.CaptionAppearance = Appearance1
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(608, 319)
        Me.UltraGrid1.TabIndex = 0
        Me.UltraGrid1.Text = "UltraGrid1"
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(176, 16)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(80, 27)
        Me.btnAddNew.TabIndex = 6
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.Visible = False
        '
        'SearchListings
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(608, 365)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "SearchListings"
        Me.Text = "SearchListings"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub SearchListings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''ultragrid1.Layouts.Add
        'Dim ugListLayout As New Infragistics.Win.UltraWinGrid.UltraGridLayout()
        'ugListLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        'ugListLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False
        'ugListLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        'ugListLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        'UltraGrid1.Layouts.Add(ugListLayout)
        'UltraGrid1.DisplayLayout.Override.AllowAddNew = ugListLayout.Override.AllowAddNew
        'UltraGrid1.DisplayLayout.Override.AllowDelete = ugListLayout.Override.AllowDelete
        'UltraGrid1.DisplayLayout.Override.AllowUpdate = ugListLayout.Override.AllowUpdate
        'UltraGrid1.DisplayLayout.Override.CellClickAction = ugListLayout.Override.CellClickAction

        'UltraGrid1.DataSource = dsList
        ''If srchSortCol >= 0 Then
        'UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Clear()
        'UltraGrid1.DisplayLayout.Bands(0).Columns(srchSortCol).SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
        'UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        'UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        ''End If
        ''ultragrid1.DataMember = "CompanyProfile"

        'Me.KeyPreview = True

        Dim i As Int32
        FillUltraGrid(UltraGrid1, dsList, 0, HidCols)
        If Not Me.Tag Is Nothing Then
            If Me.Tag.trim <> "" Then
                UGLoadLayout(Me, UltraGrid1, 1)
                btnLayout.Visible = True
            End If
        End If
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
        UltraGrid1.Focus()
        If UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False) = False Then
            'MsgBox("Error for FirstRow Grid")
        End If
        If UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False) = False Then
            'MsgBox("Error for FirstRow Band")
        End If
        If UltraGrid1.Rows.Count > 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows(0)
        End If
        If Not GridProps Is Nothing Then

            UltraGrid1.DisplayLayout.Override.AllowUpdate = GridProps.AllowUpdate 'Infragistics.Win.DefaultableBoolean.True
            UltraGrid1.DisplayLayout.Override.CellClickAction = GridProps.CellClickAction 'Infragistics.Win.UltraWinGrid.CellClickAction.Edit
            If Not GridProps.ColProps Is Nothing Then
                For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
                    UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
                    UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Next
                For i = 0 To GridProps.ColProps.Length - 1
                    UltraGrid1.DisplayLayout.Bands(0).Columns(GridProps.ColProps(i).ColIdx).TabStop = GridProps.ColProps(i).TabStop
                    UltraGrid1.DisplayLayout.Bands(0).Columns(GridProps.ColProps(i).ColIdx).CellActivation = GridProps.ColProps(i).CellActivation 'Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Next
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim ID As Integer
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If sqlSelect.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Statement remains unspecified. Please enter a statement to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Select statement not set.")
            Exit Sub
        End If

        If UltraGrid1.Selected.Rows.Count = 0 Then
            'Message modified by Michael Pastor
            MsgBox("Record remains unspecified. Please select a record to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            MessageBox.Show("No Record is selected")
            Exit Sub
        End If
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
        If UpdateDbFromDataSet(dsList, sqlSelect) <= 0 Then
            ' MsgBox("btnDelete_Click: Error!")
            Exit Sub
        End If
        If ID >= 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetItem(ID)
        End If
    End Sub
    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown
        Dim oUIElement As Infragistics.Win.UIElement
        Dim oUIElementTmp As Infragistics.Win.UIElement
        Dim point As Point = New Point(e.X, e.Y)


        If e.Button = MouseButtons.Left Then
            Dim oRowUI As Infragistics.Win.UltraWinGrid.RowUIElement

            m_oRow = Nothing
            oUIElement = Me.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(point)

            If oUIElement Is Nothing Then Exit Sub

            oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.RowUIElement))
            If Not oUIElementTmp Is Nothing Then
                oRowUI = oUIElementTmp
                m_oRow = oRowUI.Row
                'If m_oRow Is Nothing Then Exit Sub
                Exit Sub
            End If
        End If

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement

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

    Private Sub btnLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLayout.Click
        If Not UltraGrid1.DataSource Is Nothing Then
            UGSaveLayout(Me, UltraGrid1, 1)
        End If
    End Sub


    Private Sub UltraGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.DoubleClick
        If Not m_oRow Is Nothing Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    'Private Sub UltraGrid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UltraGrid1.KeyPress
    '    If Asc(e.KeyChar) = Keys.Enter Then
    '        If Not UltraGrid1.ActiveRow Is Nothing Then
    '            Me.DialogResult = DialogResult.OK
    '            e.Handled = True
    '            Me.Close()
    '        End If
    '    End If
    'End Sub

    Private Sub UltraGrid1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UltraGrid1.KeyUp
        'If e.KeyCode = Keys.Enter Then
        '    If Not UltraGrid1.ActiveRow Is Nothing Then
        '        Me.DialogResult = DialogResult.OK
        '        e.Handled = False
        '        Me.Close()
        '    End If
        'End If
    End Sub

    'Private Sub UltraGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UltraGrid1.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        If Not UltraGrid1.ActiveRow Is Nothing Then
    '            Me.DialogResult = DialogResult.OK
    '            e.Handled = True
    '            Me.Close()
    '        End If
    '    End If
    'End Sub

    Private Sub UltraGrid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UltraGrid1.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Not UltraGrid1.ActiveRow Is Nothing Then
                Me.DialogResult = DialogResult.OK
                e.Handled = False
                Me.Close()
            End If
        End If
    End Sub

    Public Delegate Sub btnGenClickSub(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Declare Auto Sub GenBtn Lib "kernel32.dll" (ByVal sender As System.Object, ByVal e As System.EventArgs)

    Private Sub btnGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGen.Click
        GenFunc(sender, e)
    End Sub
    Private Sub SearchListings_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not GridProps Is Nothing Then
            GridProps.ColProps.Clear(GridProps.ColProps, 0, GridProps.ColProps.LongLength)
            GridProps.ColProps = Nothing
            GridProps = Nothing
        End If
    End Sub

    Private Sub chkSelAllSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelAllSearch.CheckedChanged
        Dim i As Int32
        For i = 0 To UltraGrid1.Rows.Count - 1
            UltraGrid1.Rows(i).Cells("CHK").Value = chkSelAllSearch.Checked
            UltraGrid1.Rows(i).Update()
        Next
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
