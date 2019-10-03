Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

'Public Class LocationInfo
'    Inherits System.Windows.Forms.Form

'    Public dsList As DataSet
'    Public HidCols As String()

'#Region " Windows Form Designer generated code "

'    Public Sub New()
'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()

'        'Add any initialization after the InitializeComponent() call

'    End Sub

'    'Form overrides dispose to clean up the component list.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Required by the Windows Form Designer
'    Private components As System.ComponentModel.IContainer

'    'NOTE: The following procedure is required by the Windows Form Designer
'    'It can be modified using the Windows Form Designer.  
'    'Do not modify it using the code editor.
'    Friend WithEvents btnExit As System.Windows.Forms.Button
'    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
'    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
'    Friend WithEvents UltraGrid3 As Infragistics.Win.UltraWinGrid.UltraGrid
'    Friend WithEvents UltraGrid4 As Infragistics.Win.UltraWinGrid.UltraGrid
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Me.btnExit = New System.Windows.Forms.Button
'        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
'        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
'        Me.UltraGrid3 = New Infragistics.Win.UltraWinGrid.UltraGrid
'        Me.UltraGrid4 = New Infragistics.Win.UltraWinGrid.UltraGrid
'        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.UltraGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
'        Me.SuspendLayout()
'        '
'        'btnExit
'        '
'        Me.btnExit.Location = New System.Drawing.Point(500, 388)
'        Me.btnExit.Name = "btnExit"
'        Me.btnExit.Size = New System.Drawing.Size(75, 21)
'        Me.btnExit.TabIndex = 0
'        Me.btnExit.Text = "E&xit"
'        '
'        'UltraGrid1
'        '
'        Me.UltraGrid1.Location = New System.Drawing.Point(-2, 0)
'        Me.UltraGrid1.Name = "UltraGrid1"
'        Me.UltraGrid1.Size = New System.Drawing.Size(583, 94)
'        Me.UltraGrid1.TabIndex = 1
'        Me.UltraGrid1.Tag = ""
'        Me.UltraGrid1.Text = "UltraGrid1"
'        '
'        'UltraGrid2
'        '
'        Me.UltraGrid2.Location = New System.Drawing.Point(-2, 95)
'        Me.UltraGrid2.Name = "UltraGrid2"
'        Me.UltraGrid2.Size = New System.Drawing.Size(583, 94)
'        Me.UltraGrid2.TabIndex = 2
'        Me.UltraGrid2.Tag = ""
'        Me.UltraGrid2.Text = "UltraGrid2"
'        '
'        'UltraGrid3
'        '
'        Me.UltraGrid3.Location = New System.Drawing.Point(-5, 192)
'        Me.UltraGrid3.Name = "UltraGrid3"
'        Me.UltraGrid3.Size = New System.Drawing.Size(583, 94)
'        Me.UltraGrid3.TabIndex = 3
'        Me.UltraGrid3.Tag = ""
'        Me.UltraGrid3.Text = "UltraGrid3"
'        '
'        'UltraGrid4
'        '
'        Me.UltraGrid4.Location = New System.Drawing.Point(-3, 287)
'        Me.UltraGrid4.Name = "UltraGrid4"
'        Me.UltraGrid4.Size = New System.Drawing.Size(583, 94)
'        Me.UltraGrid4.TabIndex = 4
'        Me.UltraGrid4.Tag = ""
'        Me.UltraGrid4.Text = "UltraGrid4"
'        '
'        'LocationInfo
'        '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'        Me.ClientSize = New System.Drawing.Size(575, 412)
'        Me.Controls.Add(Me.UltraGrid4)
'        Me.Controls.Add(Me.UltraGrid3)
'        Me.Controls.Add(Me.UltraGrid2)
'        Me.Controls.Add(Me.UltraGrid1)
'        Me.Controls.Add(Me.btnExit)
'        Me.Name = "LocationInfo"
'        Me.Text = "Location Info"
'        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.UltraGrid4, System.ComponentModel.ISupportInitialize).EndInit()
'        Me.ResumeLayout(False)

'    End Sub

'#End Region
'    Private Sub LocationInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Dim i As Int32
'        FillUltraGrid(UltraGrid1, dsList, 0, HidCols)
'        If Not Me.Tag Is Nothing Then
'            If Me.Tag.trim <> "" Then
'                UGLoadLayout(Me, UltraGrid1, 1)
'                btnLayout.Visible = True
'            End If
'        End If
'        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
'        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

'        UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
'        UltraGrid1.Focus()
'        If UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False) = False Then
'            'MsgBox("Error for FirstRow Grid")
'        End If
'        If UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False) = False Then
'            'MsgBox("Error for FirstRow Band")
'        End If
'        If UltraGrid1.Rows.Count > 0 Then
'            UltraGrid1.ActiveRow = UltraGrid1.Rows(0)
'        End If
'        If Not GridProps Is Nothing Then

'            UltraGrid1.DisplayLayout.Override.AllowUpdate = GridProps.AllowUpdate 'Infragistics.Win.DefaultableBoolean.True
'            UltraGrid1.DisplayLayout.Override.CellClickAction = GridProps.CellClickAction 'Infragistics.Win.UltraWinGrid.CellClickAction.Edit
'            If Not GridProps.ColProps Is Nothing Then
'                For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
'                    UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
'                    UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
'                Next
'                For i = 0 To GridProps.ColProps.Length - 1
'                    UltraGrid1.DisplayLayout.Bands(0).Columns(GridProps.ColProps(i).ColIdx).TabStop = GridProps.ColProps(i).TabStop
'                    UltraGrid1.DisplayLayout.Bands(0).Columns(GridProps.ColProps(i).ColIdx).CellActivation = GridProps.ColProps(i).CellActivation 'Infragistics.Win.UltraWinGrid.Activation.NoEdit
'                Next
'            End If
'        End If
'    End Sub

'    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
'        Me.Close()
'    End Sub

'End Class
