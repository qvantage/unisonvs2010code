Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class CodeLabelForm
    Inherits System.Windows.Forms.Form
    Public SQLSelect As String ' = "Select ID, Name from PackageTypes ORDER BY Name"
    Public HiddenCols() As String = {"ID"}
    Public CLDB, CLDBUser, CLDBPass As String
    Public SortColIdx As Int16 = 0
    Public p_AppTblPath As String = AppDBName & ".dbo."

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim dvStates As New DataView()
    Dim cmdTrans As SqlCommand

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Value As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Value = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(192, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(376, 149)
        Me.Panel1.TabIndex = 11
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnDelete)
        Me.GroupBox4.Controls.Add(Me.btnNew)
        Me.GroupBox4.Controls.Add(Me.btnEdit)
        Me.GroupBox4.Controls.Add(Me.btnExit)
        Me.GroupBox4.Controls.Add(Me.btnSave)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 101)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(376, 48)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(204, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 24)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "&Delete"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(138, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(64, 24)
        Me.btnNew.TabIndex = 4
        Me.btnNew.Text = "&New"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(73, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(64, 24)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(302, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 24)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(8, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 24)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Value)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(376, 96)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Default Values "
        '
        'Value
        '
        Me.Value.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Value.Location = New System.Drawing.Point(16, 56)
        Me.Value.MaxLength = 2
        Me.Value.Name = "Value"
        Me.Value.Size = New System.Drawing.Size(240, 20)
        Me.Value.TabIndex = 28
        Me.Value.Tag = ".Name"
        Me.Value.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Tag = ""
        Me.Label1.Text = "Package:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraGrid1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(192, 149)
        Me.Panel2.TabIndex = 12
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(192, 149)
        Me.UltraGrid1.TabIndex = 0
        Me.UltraGrid1.Text = "Packages"
        '
        'CodeLabelForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 149)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "CodeLabelForm"
        Me.Tag = "PACKAGETYPES"
        Me.Text = "Code-Label Form"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CodeLabelForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtaStates As New SqlDataAdapter
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = p_AppTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, CLDB, CLDBUser, CLDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        LoadData()

        btnSave.Text = "&Save"

        MinWinSize.Width = UltraGrid1.Width + Value.Left + Value.Width + 50
        MinWinSize.Height = GroupBox4.Height + GroupBox3.Height + 20 'Panel1.Height
        Me.MinimumSize = MinWinSize

        Group_EnDis(False)

        UltraGrid1.DisplayLayout.AutoFitColumns = True

    End Sub
    ''Karina's changes
    'Private Sub LoadData()
    '    Dim dtAdapter As SqlDataAdapter
    '    If dtSet Is Nothing Then
    '        dtSet = New DataSet
    '    End If
    '    dtSet.Tables.Clear()
    '    PopulateDataset2(dtAdapter, dtSet, SQLSelect)

    '    FillUltraGrid(UltraGrid1, dtSet, 1, HiddenCols) 'Karina changed from '-1' to '1'
    '    UGLoadLayout(Me, UltraGrid1, 1)


    '    PopulateDataset2(dtAdapter, dtSet, SQLSelect)


    '    FillUltraGrid(UltraGrid1, dtSet, 1, HiddenCols)
    '    UGLoadLayout(Me, UltraGrid1, 1)


    '    Group_EnDis(False)

    'End Sub
    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        If dtSet Is Nothing Then
            dtSet = New DataSet
        End If
        dtSet.Tables.Clear()
        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols) 'Karina changed from '-1' to '1'
        UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Clear()
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(UltraGrid1.DisplayLayout.Bands(0).Columns(SortColIdx), False)
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False)
        UltraGrid1.ActiveRow = UltraGrid1.Rows(0)

    End Sub
    Private Sub Group_EnDis(ByVal status As Boolean)
        GroupBox3.Enabled = status
        btnSave.Enabled = status
        UltraGrid1.Enabled = Not status
        btnDelete.Enabled = Not status
        Btn_En(status)
    End Sub

    Private Sub Btn_En(ByVal status As Boolean)
        btnSave.Enabled = status
        btnSave.Text = "&Save"
        If status = True Then 'Enable Editing
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                btnNew.Enabled = False
            Else
                btnEdit.Enabled = False
            End If
        Else 'End Editing
            btnNew.Enabled = True
            btnEdit.Enabled = True
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
        End If
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim RowIdx, IdxName As Integer

        'Karina - Field empty, don't save.
        If Value.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Service type remains unspecified. Please enter a service type.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Enter Service Type!")
            Exit Sub
        End If

        If Not UltraGrid1.ActiveRow Is Nothing Then
            IdxName = UltraGrid1.ActiveRow.Cells("ID").Value
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                RowIdx = UltraGrid1.ActiveRow.Index()
            End If
        End If


        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, " Where ID = '" & IdxName & "'") Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            'btnEdit.Text = "&Edit"
            'Me.Text = MeText & " -- Record Updated."
            PopulateDataset2(dtA, dtSet, SQLSelect)
            SortColIdx = UltraGrid1.DisplayLayout.Bands(0).SortedColumns(0).Index
            FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols) 'Let user to sort a Grid '1' not '-1'
            UGLoadLayout(Me, UltraGrid1, 1) 'Karina added
            row = dtSet.Tables(0).Rows.Find(IdxName)
            UltraGrid1.Enabled = True 'Karina added
            'Dim Arr() As Array
            'Arr = row.ItemArray
            Group_EnDis(False)
            UltraGrid1.Focus()
            UltraGrid1.Refresh()
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(RowIdx) 'Karina commented, after saving - refreshing

        End If
    End Sub
    'Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    Dim cnt As Integer
    '    Dim RowIdx, IdxName As Integer

    '    'Karina - Field empty, don't save.
    '    If Value.Text.Trim = "" Then
    '        MsgBox("Enter Service Type!")
    '        Exit Sub
    '    End If

    '    If Not UltraGrid1.ActiveRow Is Nothing Then
    '        IdxName = UltraGrid1.ActiveRow.Cells("ID").Value
    '        If btnEdit.Text.ToUpper = "&CANCEL" Then
    '            RowIdx = UltraGrid1.ActiveRow.Index()
    '        End If
    '    End If


    '    If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, " Where ID = '" & IdxName & "'") Then
    '        Dim row As DataRow
    '        Dim dtA As New SqlDataAdapter

    '        'btnEdit.Text = "&Edit"
    '        'Me.Text = MeText & " -- Record Updated."
    '        PopulateDataset2(dtA, dtSet, SQLSelect)
    '        FillUltraGrid(UltraGrid1, dtSet, 1, HiddenCols) 'Let user to sort a Grid '1' not '-1'
    '        UGLoadLayout(Me, UltraGrid1, 1) 'Karina added
    '        row = dtSet.Tables(0).Rows.Find(IdxName)
    '        UltraGrid1.Enabled = True 'Karina added
    '        'Dim Arr() As Array
    '        'Arr = row.ItemArray
    '        Group_EnDis(False)
    '        UltraGrid1.Focus()
    '        UltraGrid1.Refresh()
    '        'UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(RowIdx) 'Karina commented

    '    End If
    'End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dsData As DataSet
        Dim ID As Integer
        Dim row As DataRow
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If UltraGrid1.Selected.Rows.Count = 0 Then Exit Sub

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
        If UpdateDbFromDataSet(dtSet, SQLSelect) <= 0 Then
            'MsgBox("btnDelete_Click: Error!")
            LoadData()
            Exit Sub
        End If
        If ID >= 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetItem(ID)
        Else
            ClearForm(Me)
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records
        If sender.text.toupper = "&EDIT" Then
            If UltraGrid1.Rows.Count <= 0 Then Exit Sub 'Karina - In Edit Mode Disable DELETE btn
            If EditForm(Me, PrepSelectQuery(SQLSelect, " Where ID = '" & UltraGrid1.ActiveRow.Cells("ID").Value.ToString.Trim & "'"), EditAction.START, cmdTrans) Then
                sender.text = "&Cancel"
                UltraGrid1.Enabled = False
                Group_EnDis(True)
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                If UltraGrid1.Rows.Count <= 0 Then Exit Sub 'Karina - In Edit Mode Disable DELETE btn
                sender.text = "&Edit"
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                'FormLoad(Me, dvCompany)
            End If
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'UltraGrid1.DeleteSelectedRows()
        If btnEdit.Text.ToUpper = "&CANCEL" Then

        End If
        If sender.text = "&New" Then
            Group_EnDis(True)
            ClearForm(Me)
            sender.text = "&Cancel"
            Value.Focus()
        Else
            ClearForm(Me)
            sender.text = "&New"
            Group_EnDis(False)
            UltraGrid1.Focus()
        End If
    End Sub

    'Karina
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        'If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
        '    If MsgBox("Data is not saved! Do you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
        '        sender.text = "&Edit"
        '        UltraGrid1.Enabled = True
        '        Group_EnDis(False)
        '    Else
        '        'Exit Sub
        '    End If
        'End If
        'UGSaveLayout(Me, UltraGrid1, 1)

        Me.Close()


    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        FormLoadFromGrid(Me, sender)
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled And UltraGrid1.Rows.Count > 0 Then
            FormLoadFromGrid(Me, sender)
        End If
    End Sub

    'Karina
    Private Sub CodeLabelForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            If MessageBox.Show("Data is not saved! Are you sure you want to exit?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                sender.text = "&Edit"
            Else
                'Exit Sub
            End If

        End If
        UGSaveLayout(Me, UltraGrid1, 1)

    End Sub

   
End Class
