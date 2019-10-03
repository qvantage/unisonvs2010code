Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class WeightPlanGroup
    Inherits System.Windows.Forms.Form
    Public SortColIdx As Int16 = 0 'Karina Added
    Dim SQLSelect As String = _
            "Select ID, Name, Description " & _
            " FROM " & WeightVars.WEIGHTTblPath & "WeightPlanGroups ORDER BY Name"


    Dim MeText As String
    Dim dtSet As New DataSet
    Dim dvStates As New DataView
    Dim cmdTrans As SqlCommand
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
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupName As System.Windows.Forms.TextBox
    Friend WithEvents GroupID As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupName = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.TextBox1, Me.GroupID, Me.Label1, Me.GroupName})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 88)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupID
        '
        Me.GroupID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GroupID.Location = New System.Drawing.Point(352, 24)
        Me.GroupID.Name = "GroupID"
        Me.GroupID.Size = New System.Drawing.Size(56, 20)
        Me.GroupID.TabIndex = 17
        Me.GroupID.Tag = ".ID.View"
        Me.GroupID.Text = ""
        Me.GroupID.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Group :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupName
        '
        Me.GroupName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GroupName.Location = New System.Drawing.Point(80, 24)
        Me.GroupName.Name = "GroupName"
        Me.GroupName.Size = New System.Drawing.Size(152, 20)
        Me.GroupName.TabIndex = 14
        Me.GroupName.Tag = ".NAME"
        Me.GroupName.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExit, Me.btnDelete, Me.btnNew, Me.btnSave, Me.btnEdit})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 381)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 40)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(490, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(230, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 21)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(155, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 21)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
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
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(79, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(80, 48)
        Me.TextBox1.MaxLength = 50
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(464, 32)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.Tag = ".Description"
        Me.TextBox1.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Description :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.UltraGrid1})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 88)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(568, 293)
        Me.Panel1.TabIndex = 4
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(568, 293)
        Me.UltraGrid1.TabIndex = 2
        Me.UltraGrid1.Text = "Manifests"
        '
        'WeightPlanGroup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.GroupBox2, Me.GroupBox1})
        Me.Name = "WeightPlanGroup"
        Me.Tag = "WeightPlanGroups"
        Me.Text = "Manifest Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub WeightPlanGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtAdapter As SqlDataAdapter
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = WeightVars.WEIGHTTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        If dtSet.Tables(0).Rows.Count = 0 Then
            btnSave.Text = "&Save"
        Else
            btnSave.Text = "&Update"
        End If
        FillUltraGrid(UltraGrid1, dtSet, 0)
        UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Bands(0).Columns(0).Layout.Override.ActiveCellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).Columns(0).Layout.Override.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        Group_EnDis(False)



    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        FormLoadFromGrid(Me, sender)
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled Then
            FormLoadFromGrid(Me, sender)
        End If
    End Sub
    'Karina added Btn_EnA(status)
    Private Sub Group_EnDis(ByVal status As Boolean)
        GroupBox1.Enabled = status
        btnSave.Enabled = status
        UltraGrid1.Enabled = Not status
        btnDelete.Enabled = Not status
        Btn_En(status)

        'Original from Aly
        'GroupBox1.Enabled = status
        'btnSave.Enabled = status
        'If UltraGrid1.Rows.Count = 0 Or btnNew.Text = "&Cancel" Then
        '    btnSave.Text = "&Save"
        'Else
        '    btnSave.Text = "&Update"
        'End If

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
        Dim ID As Integer

        'Karina - dont' let the uset to save empty Group Name.
        If GroupName.Text.Trim = "" Then
            MsgBox("Enter a Group Name!")
            Exit Sub
        End If

        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, " Where ID = " & GroupID.Text) Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            ID = Val(GroupID.Text)
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
            'Me.Text = MeText & " -- Record Updated."
            PopulateDataset2(dtA, dtSet, SQLSelect)
            FillUltraGrid(UltraGrid1, dtSet, 1)
            If ID > 0 Then
                row = dtSet.Tables(0).Rows.Find(ID)
            End If
            'UltraGrid1.ActiveRow.Cells(0) = row.Item(0) 'Infragistics.Win.UltraWinGrid.UltraGridRow)
            'sender.text = "&New"
            UltraGrid1.Enabled = True
            Group_EnDis(False)
            UltraGrid1.Focus()
            UltraGrid1.Refresh()
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records

        'If UltraGrid1.Rows.Count <= 0 Then Exit Sub 'Karina - In Edit Mode Disable DELETE btn

        If GroupID.Text.Trim = "" Then Exit Sub
        If btnNew.Text = "&Cancel" Then
            MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        'If btnDelete.Text = "&Delete" Then
        '    Exit Sub
        'End If

        If sender.text.toupper = "&EDIT" Then
            If UltraGrid1.Rows.Count <= 0 Then Exit Sub 'Karina - In Edit Mode Disable DELETE btn
            If EditForm(Me, PrepSelectQuery(SQLSelect, " Where ID = " & GroupID.Text), EditAction.START, cmdTrans) Then
                UltraGrid1.Enabled = False
                sender.text = "&Cancel" 'Karina change places with Group_EnDis
                Group_EnDis(True)

            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                If UltraGrid1.Rows.Count <= 0 Then Exit Sub 'Karina - In Edit Mode Disable DELETE btn
                UltraGrid1.Enabled = True
                sender.text = "&Edit" 'Karina change places with Group_EnDis
                Group_EnDis(False)

                'FormLoad(Me, dvCompany)
            End If
        End If
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
        '        UltraGrid1.Enabled = True
        '        sender.text = "&Edit"
        '        Group_EnDis(False)
        '    Else
        '        'Exit Sub
        '    End If

        'End If
        'UGSaveLayout(Me, UltraGrid1, 1)
        Me.Close()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'UltraGrid1.DeleteSelectedRows()

        ' If UltraGrid1.Rows.Count <= 0 Then Exit Sub 'Karina - In New Mode Disable DELETE btn

        If btnEdit.Text = "&Cancel" Then
            MessageBox.Show("You are in 'Edit' mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If sender.text = "&New" Then
            UltraGrid1.Enabled = False
            ClearForm(Me)
            sender.text = "&Cancel"
            Group_EnDis(True)
            GroupName.Focus()
        Else
            sender.text = "&New"
            UltraGrid1.Enabled = True
            Group_EnDis(False)
            UltraGrid1.Focus()

        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dsData As DataSet
        Dim ID As Integer
        Dim row As DataRow
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        'If UltraGrid1.Rows.Count <= 0 Then Exit Sub 'Karina - Disable DELETE btn

        ''Karina, do not delete without selection
        'If UltraGrid1.ActiveRow Is Nothing Then
        '    MsgBox("Please select a row first.")
        '    Exit Sub
        'End If

        'If UltraGrid1.Selected.Rows.Count <= 0 Then
        '    MsgBox("Please select a row to be DELETED.")
        '    Exit Sub
        'End If
        ''End Karina

        If UltraGrid1.Selected.Rows.Count = 0 Then Exit Sub 'Karina added, don't delete if not chosed

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
            'MsgBox("Record Deletion Failed.")
            LoadData() 'Karian uncomented
            Exit Sub
        End If
        If ID >= 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetItem(ID)
        Else
            ClearForm(Me)
        End If
        'ID = UltraGrid1.ActiveRow.Cells(0).Value
        'row = dtSet.Tables(0).Rows.Find(ID)
        'row.Delete()

        'UltraGrid1.ActiveRow.Delete()
        'dsData = UltraGrid1.DataSource


    End Sub
    ''KArina added Load
    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        If dtSet Is Nothing Then
            dtSet = New DataSet
        End If
        dtSet.Tables.Clear()
        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        FillUltraGrid(UltraGrid1, dtSet, SortColIdx) 'Karina changed from '-1' to '1'
        UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Clear()
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(UltraGrid1.DisplayLayout.Bands(0).Columns(SortColIdx), False)
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False)
        UltraGrid1.ActiveRow = UltraGrid1.Rows(0)

    End Sub

    Private Sub WeightPlanGroup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                sender.text = "&Edit"
                Group_EnDis(False)
            Else
                'Exit Sub
            End If

        End If
        UGSaveLayout(Me, UltraGrid1, 1)
    End Sub
End Class
