Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class ListingInfo
    Inherits System.Windows.Forms.Form

    Public dsList1 As DataSet
    Public dsList2 As DataSet
    Public dsList3 As DataSet
    Public sqlSelect As String
    Public srchSortCol As Integer
    Public HidCols As String()
    'Public GenFunc As btnGenClickSub

    Friend GridProps As GridProp = Nothing

    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

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
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGrid3 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGrid4 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGrid3 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGrid4 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnExit = New System.Windows.Forms.Button
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGrid1
        '
        Appearance1.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.UltraGrid1.DisplayLayout.CaptionAppearance = Appearance1
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(500, 200)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Text = "UltraGrid1"
        '
        'UltraGrid2
        '
        Appearance2.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.UltraGrid2.DisplayLayout.CaptionAppearance = Appearance2
        Me.UltraGrid2.Location = New System.Drawing.Point(503, 0)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(500, 200)
        Me.UltraGrid2.TabIndex = 2
        Me.UltraGrid2.Text = "UltraGrid2"
        '
        'UltraGrid3
        '
        Appearance3.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.UltraGrid3.DisplayLayout.CaptionAppearance = Appearance3
        Me.UltraGrid3.Location = New System.Drawing.Point(0, 203)
        Me.UltraGrid3.Name = "UltraGrid3"
        Me.UltraGrid3.Size = New System.Drawing.Size(500, 200)
        Me.UltraGrid3.TabIndex = 3
        Me.UltraGrid3.Text = "UltraGrid3"
        '
        'UltraGrid4
        '
        Appearance4.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.UltraGrid4.DisplayLayout.CaptionAppearance = Appearance4
        Me.UltraGrid4.Location = New System.Drawing.Point(503, 204)
        Me.UltraGrid4.Name = "UltraGrid4"
        Me.UltraGrid4.Size = New System.Drawing.Size(500, 200)
        Me.UltraGrid4.TabIndex = 4
        Me.UltraGrid4.Text = "UltraGrid4"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(913, 414)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        '
        'ListingInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1002, 443)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.UltraGrid4)
        Me.Controls.Add(Me.UltraGrid3)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Name = "ListingInfo"
        Me.Text = "Listing Info"
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ListingInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Int32

        'Load - UltraGrid1
        FillUltraGrid(UltraGrid1, dsList1, 0, HidCols)
        If Not Me.Tag Is Nothing Then
            If Me.Tag.trim <> "" Then
                UGLoadLayout(Me, UltraGrid1, 1)
                'btnLayout.Visible = True
            End If
        End If
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
        UltraGrid1.Focus()
        
        If UltraGrid1.Rows.Count > 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows(0)
        End If
        If Not GridProps Is Nothing Then

            UltraGrid1.DisplayLayout.Override.AllowUpdate = GridProps.AllowUpdate
            UltraGrid1.DisplayLayout.Override.CellClickAction = GridProps.CellClickAction
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

        'Load - UltraGrid2
        FillUltraGrid(UltraGrid2, dsList2, 0, HidCols)
        If Not Me.Tag Is Nothing Then
            If Me.Tag.trim <> "" Then
                UGLoadLayout(Me, UltraGrid2, 1)
                'btnLayout.Visible = True
            End If
        End If
        UltraGrid2.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        UltraGrid2.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
        UltraGrid2.Focus()

        If UltraGrid2.Rows.Count > 0 Then
            UltraGrid2.ActiveRow = UltraGrid2.Rows(0)
        End If
        If Not GridProps Is Nothing Then

            UltraGrid2.DisplayLayout.Override.AllowUpdate = GridProps.AllowUpdate
            UltraGrid2.DisplayLayout.Override.CellClickAction = GridProps.CellClickAction
            If Not GridProps.ColProps Is Nothing Then
                For i = 0 To UltraGrid2.DisplayLayout.Bands(0).Columns.Count - 1
                    UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = False
                    UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Next
                For i = 0 To GridProps.ColProps.Length - 1
                    UltraGrid2.DisplayLayout.Bands(0).Columns(GridProps.ColProps(i).ColIdx).TabStop = GridProps.ColProps(i).TabStop
                    UltraGrid2.DisplayLayout.Bands(0).Columns(GridProps.ColProps(i).ColIdx).CellActivation = GridProps.ColProps(i).CellActivation 'Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Next
            End If
        End If

        'Load - UltraGrid3
        FillUltraGrid(UltraGrid3, dsList3, 0, HidCols)
        If Not Me.Tag Is Nothing Then
            If Me.Tag.trim <> "" Then
                UGLoadLayout(Me, UltraGrid2, 1)
                'btnLayout.Visible = True
            End If
        End If
        UltraGrid3.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid3.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        UltraGrid3.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
        UltraGrid3.Focus()

        If UltraGrid3.Rows.Count > 0 Then
            UltraGrid3.ActiveRow = UltraGrid3.Rows(0)
        End If
        If Not GridProps Is Nothing Then

            UltraGrid3.DisplayLayout.Override.AllowUpdate = GridProps.AllowUpdate
            UltraGrid3.DisplayLayout.Override.CellClickAction = GridProps.CellClickAction
            If Not GridProps.ColProps Is Nothing Then
                For i = 0 To UltraGrid3.DisplayLayout.Bands(0).Columns.Count - 1
                    UltraGrid3.DisplayLayout.Bands(0).Columns(i).TabStop = False
                    UltraGrid3.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Next
                For i = 0 To GridProps.ColProps.Length - 1
                    UltraGrid3.DisplayLayout.Bands(0).Columns(GridProps.ColProps(i).ColIdx).TabStop = GridProps.ColProps(i).TabStop
                    UltraGrid3.DisplayLayout.Bands(0).Columns(GridProps.ColProps(i).ColIdx).CellActivation = GridProps.ColProps(i).CellActivation 'Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Next
            End If
        End If
    End Sub

    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown, UltraGrid2.MouseDown, UltraGrid3.MouseDown, UltraGrid4.MouseDown
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
                Exit Sub
            End If
        End If

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement

            oUIElement = Me.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(point)
            If oUIElement Is Nothing Then Exit Sub

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
    Private Sub mnuSortAsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(m_oColumn, False)
    End Sub
    Private Sub mnuSortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(Me.m_oColumn, True)
    End Sub
    Private Sub UltraGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.DoubleClick, UltraGrid2.DoubleClick, UltraGrid3.DoubleClick, UltraGrid4.DoubleClick
        If Not m_oRow Is Nothing Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub UltraGrid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UltraGrid1.KeyPress, UltraGrid2.KeyPress, UltraGrid3.KeyPress, UltraGrid4.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not UltraGrid1.ActiveRow Is Nothing) And (Not UltraGrid2.ActiveRow Is Nothing) And (Not UltraGrid3.ActiveRow Is Nothing) And (Not UltraGrid4.ActiveRow Is Nothing) Then
                Me.DialogResult = DialogResult.OK
                e.Handled = False
                Me.Close()
            End If
        End If
    End Sub
    Private Sub SListingInfo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not GridProps Is Nothing Then
            GridProps.ColProps.Clear(GridProps.ColProps, 0, GridProps.ColProps.LongLength)
            GridProps.ColProps = Nothing
            GridProps = Nothing
        End If
    End Sub
End Class
