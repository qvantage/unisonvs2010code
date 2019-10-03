Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class PackageTypes
    Inherits System.Windows.Forms.Form
    Public SQLSelect As String ' = "Select ID, Name from PackageTypes ORDER BY Name"
    Public HiddenCols() As String = {"ID"}
    Public SortColIdx As Int16 = 0

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim dvStates As New DataView()
    Dim cmdTrans As SqlCommand
    ' Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing 'Karina added

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
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents utSortID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents utDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.utDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label14 = New System.Windows.Forms.Label
        Me.utSortID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Value = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.utDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utSortID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(440, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(384, 213)
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
        Me.GroupBox4.Location = New System.Drawing.Point(0, 165)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(384, 48)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(204, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 24)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(138, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(64, 24)
        Me.btnNew.TabIndex = 2
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
        Me.btnExit.Location = New System.Drawing.Point(296, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 24)
        Me.btnExit.TabIndex = 4
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
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.utDescription)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.utSortID)
        Me.GroupBox3.Controls.Add(Me.Value)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(384, 213)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Default Values "
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Description:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utDescription
        '
        Me.utDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utDescription.Location = New System.Drawing.Point(88, 88)
        Me.utDescription.Name = "utDescription"
        Me.utDescription.Size = New System.Drawing.Size(240, 21)
        Me.utDescription.TabIndex = 2
        Me.utDescription.Tag = ".Description"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(30, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 116
        Me.Label14.Text = "Sort ID :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utSortID
        '
        Me.utSortID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utSortID.Location = New System.Drawing.Point(88, 24)
        Me.utSortID.Name = "utSortID"
        Me.utSortID.Size = New System.Drawing.Size(80, 21)
        Me.utSortID.TabIndex = 0
        Me.utSortID.Tag = ".SortID"
        '
        'Value
        '
        Me.Value.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Value.Location = New System.Drawing.Point(88, 56)
        Me.Value.MaxLength = 2
        Me.Value.Name = "Value"
        Me.Value.Size = New System.Drawing.Size(80, 20)
        Me.Value.TabIndex = 1
        Me.Value.Tag = ".Name"
        Me.Value.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(29, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Tag = ""
        Me.Label1.Text = "Code:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraGrid1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(440, 213)
        Me.Panel2.TabIndex = 12
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(440, 213)
        Me.UltraGrid1.TabIndex = 0
        Me.UltraGrid1.Text = "Packages"
        '
        'PackageTypes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(824, 213)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PackageTypes"
        Me.Tag = "PACKAGETYPES"
        Me.Text = "Package Types"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.utDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utSortID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PackageType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtAdapter As SqlDataAdapter
        Dim dtaStates As New SqlDataAdapter()
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated
        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, AppDBName, AppDBUser, AppDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp


        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        btnSave.Text = "&Save"

        FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols) 'Karina, to sort, changes here from -1 to 1
        UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Clear()
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(UltraGrid1.DisplayLayout.Bands(0).Columns(SortColIdx), False)
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False)
        UltraGrid1.ActiveRow = UltraGrid1.Rows(0)


        MinWinSize.Width = UltraGrid1.Width + Value.Left + Value.Width + 50
        MinWinSize.Height = GroupBox4.Height + GroupBox3.Height + 20 'Panel1.Height
        Me.MinimumSize = MinWinSize

        Group_EnDis(False)

        UltraGrid1.DisplayLayout.AutoFitColumns = True



    End Sub
    Private Sub Group_EnDis(ByVal status As Boolean)
        GroupBox3.Enabled = status
        btnSave.Enabled = status
        UltraGrid1.Enabled = Not status
        btnDelete.Enabled = Not status 'Karina added
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

        'Original by Aly
        'btnSave.Enabled = status
        'btnSave.Text = "&Save"
        'If status = True Then 'Enable Editing
        'Else 'End Editing
        '    btnEdit.Text = "&Edit"
        '    btnNew.Text = "&New"
        'End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim cnt As Integer
        Dim RowIdx, IdxName As Integer

        'Karina - Field empty, don't save.
        If Value.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Package type code remains unspecified. Please enter a valid package type code.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Enter The Code of the Package Type!")
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
            FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols)
            'row = dtSet.Tables(0).Rows.Find(IdxName)
            'Dim Arr() As Array
            'Arr = row.ItemArray
            Group_EnDis(False)
            UltraGrid1.Focus()
            UltraGrid1.Refresh()
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(RowIdx)

        End If

    End Sub

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
        If UltraGrid1.Rows.Count <= 0 Then Exit Sub

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLSelect, " Where ID = '" & UltraGrid1.ActiveRow.Cells("ID").Value.ToString.Trim & "'"), EditAction.START, cmdTrans) Then
                sender.text = "&Cancel"
                UltraGrid1.Enabled = False
                Group_EnDis(True)
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                sender.text = "&Edit"
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                'FormLoad(Me, dvCompany)
            End If
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'UltraGrid1.DeleteSelectedRows()
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

    'Karina commented and added PackageTypes_Closing to WARN a user about Exiting from EDIT/NEW mode.
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
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
    'Original   
    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        FormLoadFromGrid(Me, sender)
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled And UltraGrid1.Rows.Count > 0 Then
            FormLoadFromGrid(Me, sender)
        End If
    End Sub
 
    Private Sub PackageTypes_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            If MessageBox.Show("Data is not saved! Are you sure you want to exit?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                '- If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                sender.text = "&Edit"
                UltraGrid1.Enabled = True
                Group_EnDis(False)
            Else
                'Exit Sub
            End If
        End If
        UGSaveLayout(Me, UltraGrid1, 1)
    End Sub

  
End Class
