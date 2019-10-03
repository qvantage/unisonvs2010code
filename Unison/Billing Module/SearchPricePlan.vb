Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Public Class SearchPricePlan
    Inherits System.Windows.Forms.Form

    Dim dtAdapter As New SqlDataAdapter
    Public dSet As DataSet
    Public sqlSelPP As String
    'Public sqlSelPP As String = "Select pp.PlanID, pp.Plan_Name, pp.Charge_Code, ppt.PlanType, pp.From_Zone, " & _
    '                             "pp.To_Zone, pp.Start_Date, pp.End_Date, pp.ModuleName, pp.TableName, pp.ColumnName, " & _
    '                             "pp.ColumnPrefix, pp.ColumnSuffix, pp.Invoice_Title, pp.Taxable, pp.Description From " & AppTblPath & "PricePlans pp, PricePlanTypes ppt where ppt.PlanTypeCode=pp.PlanTypeCode Order by pp.Plan_Name"
    'Public sqlSelPPC As String
    Public sqlSelPPC As String = "Select ppc.PlanID, ppc.From_range, ppc.To_Range, ppc.Charge From " & BILLTblPath & "PricePlanCharges ppc order by From_Range"
    Public srchSortCol As Integer

    Public dsList As DataSet
    Public HidColsPP As String() = {"PlanID"}
    Public HidColsPPC As String() = {"PlanID"}
    Friend GridProps As GridProp = Nothing
    Public SortColIdx As Int16 = 0
    Dim cmdTrans As SqlCommand

    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim m_oRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

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
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSelect = New System.Windows.Forms.Button
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(600, 250)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Text = "Price Plans"
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid2.Location = New System.Drawing.Point(0, 256)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(300, 170)
        Me.UltraGrid2.TabIndex = 3
        Me.UltraGrid2.Text = "Price Plans Charges"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(512, 432)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 25
        Me.btnExit.Text = "E&xit"
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(8, 432)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 21)
        Me.btnSelect.TabIndex = 26
        Me.btnSelect.Text = "&Select"
        '
        'SearchPricePlan
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(600, 462)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Name = "SearchPricePlan"
        Me.Tag = "PricePlans"
        Me.Text = "Search Price Plan"
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub SearchPricePlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Int32
        Me.CenterToScreen()

        '===UltraGrid1
        'PopulateDataset2(dtAdapter, dSet, sqlSelPP)
        FillUltraGrid(UltraGrid1, dsList, SortColIdx, HidColsPP)
        If Not Me.Tag Is Nothing Then
            If Me.Tag.trim <> "" Then
                'UGLoadLayout(Me, UltraGrid1, 1)
                'btnLayout.Visible = True
            End If
        End If
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
        UltraGrid1.Focus()
        'UltraGrid1.ActiveRow.Activate = True

        If UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False) = False Then
            'MsgBox("Error for FirstRow Grid")
        End If
        If UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False) = False Then
            'MsgBox("Error for FirstRow Band")
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
        '====UltraGrid1 - End
        ''====UltraGrid2
        'PopulateDataset2(dtAdapter, dSet, sqlSelPPC)
        ''FillUltraGrid(UltraGrid2, dSet, SortColIdx, HidColsPPC)
        ''PopulateDataset2(dtAdapter, dsList, sqlSelPPC)
        'FillUltraGrid(UltraGrid2, dSet, SortColIdx, HidColsPPC)
        'If Not Me.Tag Is Nothing Then
        '    If Me.Tag.trim <> "" Then
        '        'UGLoadLayout(Me, UltraGrid1, 1)
        '        'btnLayout.Visible = True
        '    End If
        'End If
        'UltraGrid2.DisplayLayout.GroupByBox.Hidden = False
        'UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        'UltraGrid2.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
        'UltraGrid2.Focus()
        'If UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False) = False Then
        '    'MsgBox("Error for FirstRow Grid")
        'End If
        'If UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False) = False Then
        '    'MsgBox("Error for FirstRow Band")
        'End If
        'If Not GridProps Is Nothing Then

        '    UltraGrid2.DisplayLayout.Override.AllowUpdate = GridProps.AllowUpdate 'Infragistics.Win.DefaultableBoolean.True
        '    UltraGrid2.DisplayLayout.Override.CellClickAction = GridProps.CellClickAction 'Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        '    If Not GridProps.ColProps Is Nothing Then
        '        For i = 0 To UltraGrid2.DisplayLayout.Bands(0).Columns.Count - 1
        '            UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = False
        '            UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        '        Next
        '        For i = 0 To GridProps.ColProps.Length - 1
        '            UltraGrid2.DisplayLayout.Bands(0).Columns(GridProps.ColProps(i).ColIdx).TabStop = GridProps.ColProps(i).TabStop
        '            UltraGrid2.DisplayLayout.Bands(0).Columns(GridProps.ColProps(i).ColIdx).CellActivation = GridProps.ColProps(i).CellActivation 'Infragistics.Win.UltraWinGrid.Activation.NoEdit
        '        Next
        '    End If
        'End If
        ''====UltraGrid2 - End
    End Sub
    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        Dim PlanID As Integer

        'FormLoadFromGrid(Me, sender)
        PlanID = UltraGrid1.ActiveRow.Cells("PlanID").Value
        FillUltraGrid2(PlanID)
    End Sub
    Private Sub UltraGrid1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        'If sender.enabled Then
        '    FormLoadFromGrid(Me, sender)
        'End If
    End Sub

    Public Function FillUltraGrid2(ByVal PlanID As Integer)
        Dim dS As New DataSet
        Dim dA As New SqlDataAdapter
        Dim SQLSelect2 As String '= "Select From_Range, To_Range, Charge From " & BillTblPath & "PricePlanCharges where PlanID = " & PlanID & " Order by From_Range"

        'If UltraGrid1.Rows.Count = 0 Then
        '    ClearForm(UltraGrid2)
        '    Exit Function
        'End If

        Dim PlanType As String = UltraGrid1.ActiveRow.Cells("PlanType").Value
        'Dim Description As String = UltraGrid1.ActiveRow.Cells("Description").Value

        If PlanType = "Fixed" Then
            SQLSelect2 = "Select Charge from " & BILLTblPath & "PricePlanCharges where PlanID = " & PlanID & " Order by Charge"
        Else
            SQLSelect2 = "Select From_Range, To_Range, Charge From " & BILLTblPath & "PricePlanCharges where PlanID = " & PlanID & " Order by From_Range"
        End If

        PopulateDataset2(dA, dS, SQLSelect2)

        FillUltraGrid(UltraGrid2, dS, SortColIdx)
        'Karina UnComented
        'UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        'UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit

        Dim i As Int32
        For i = 1 To UltraGrid2.DisplayLayout.Bands(0).ColumnFilters.Count - 1
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = False
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next

        'Dim i As Int32
        'For i = 1 To UltraGrid2.DisplayLayout.Bands(0).ColumnFilters.Count - 1
        '    UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = False
        '    UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        'Next


        'UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.DefaultableBoolean.Default 'Karina added
        'End of Karina's UnComent
        'UltraGrid2.DisplayLayout.AddNewBox.Hidden = False 'To display the button on UltraGrid2
        'UltraGrid2.DisplayLayout.Bands(0).AddButtonCaption = "New Row"



        dA.Dispose()
        dA = Nothing

        dS.Dispose()
        dA = Nothing
    End Function
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub PricePlanCustomer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, sqlSelPP, EditAction.CANCEL, cmdTrans) Then
        '        'Group_EnDis(False)
        '        sender.text = "&Edit"
        '    Else
        '    End If
        'End If
    End Sub
    Private Sub UltraGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.DoubleClick
        If Not m_oRow Is Nothing Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
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
    Private Sub mnuAutoFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CntMenu1.MenuItems(0).Checked Then
            CntMenu1.MenuItems(0).Checked = False
        Else
            CntMenu1.MenuItems(0).Checked = True
        End If
        UltraGrid1.DisplayLayout.AutoFitColumns = CntMenu1.MenuItems(0).Checked

    End Sub
End Class
