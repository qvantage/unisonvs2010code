Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class BillingCycleSetup
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = _
            "Select Code, Name " & _
            " FROM " & AppTblPath & "BillingCycles ORDER BY Code"

    Public SortColIdx As Int16 = 0

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim dvStates As New DataView
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
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 72)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(376, 200)
        Me.UltraGrid1.TabIndex = 2
        Me.UltraGrid1.Text = "Billing Cycles"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 278)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 48)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(215, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 24)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "&Delete"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(146, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(64, 24)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(77, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(64, 24)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(304, 16)
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
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(56, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Location = New System.Drawing.Point(96, 40)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(200, 20)
        Me.txtName.TabIndex = 1
        Me.txtName.Tag = ".Name"
        Me.txtName.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(56, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Code:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCode.Enabled = False
        Me.txtCode.Location = New System.Drawing.Point(96, 8)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(30, 20)
        Me.txtCode.TabIndex = 0
        Me.txtCode.Tag = ".Code"
        Me.txtCode.Text = ""
        '
        'BillingCycleSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 326)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtCode)
        Me.Name = "BillingCycleSetup"
        Me.Tag = "BillingCycles"
        Me.Text = "Billing Cycle Setup"
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub BillingCycleSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtAdapter As SqlDataAdapter
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = AppTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, AppDBName, AppDBUser, AppDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        btnSave.Text = "&Save"

        FillUltraGrid(UltraGrid1, dtSet, 0)
        UGLoadLayout(Me, UltraGrid1, 1)

        UltraGrid1.DisplayLayout.Bands(0).Columns(0).Layout.Override.ActiveCellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).Columns(0).Layout.Override.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        Group_EnDis(False)
    End Sub

    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        If dtSet Is Nothing Then
            dtSet = New DataSet
        End If
        dtSet.Tables.Clear()
        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        FillUltraGrid(UltraGrid1, dtSet, SortColIdx)
        UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Clear()
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(UltraGrid1.DisplayLayout.Bands(0).Columns(SortColIdx), False)
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False)
        If UltraGrid1.Rows.Count > 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows(0)
        End If

    End Sub
    Private Sub Group_EnDis(ByVal status As Boolean)
        btnSave.Enabled = status

        txtCode.Enabled = status
        txtName.Enabled = status

        UltraGrid1.Enabled = Not status
        Btn_En(status)
    End Sub

    Private Sub Btn_En(ByVal status As Boolean)
        btnSave.Enabled = status
        btnDelete.Enabled = status


        btnSave.Text = "&Save"
        If status = True Then 'Enable Editing
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                btnNew.Enabled = False
                btnDelete.Enabled = False
                txtCode.ReadOnly = True
                txtName.ReadOnly = False
            Else
                btnEdit.Enabled = False
                btnDelete.Enabled = False
            End If
        Else 'End Editing
            btnNew.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnEdit.Text = "&Edit"
            btnDelete.Text = "&Delete"
            btnNew.Text = "&New"

            txtCode.ReadOnly = True
            txtName.ReadOnly = True
        End If
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim RowIdx As Integer
        Dim IdxName As String
        Dim row As DataRow

        If txtCode.Text = "" And txtName.Text = "" Then
            'Message modified by Michael Pastor
            MsgBox("Code and name fields remain unspecified. Please enter a code and a name.", MsgBoxStyle.Exclamation, "Missing Data Input")
            Exit Sub
            txtCode.Focus()
        End If
        If txtCode.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Code field remain unspecified. Please enter a code.", MsgBoxStyle.Exclamation, "Missing Data Input")
            Exit Sub
            txtCode.Focus()
        End If
        If txtName.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Name field remain unspecified. Please enter a name.", MsgBoxStyle.Exclamation, "Missing Data Input")
            Exit Sub
            txtName.Focus()
        End If

        If Not UltraGrid1.ActiveRow Is Nothing Then
            IdxName = " Where Code = '" & UltraGrid1.ActiveRow.Cells("Code").Value.ToString.Trim & "'"
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                RowIdx = UltraGrid1.ActiveRow.Index()
            End If
        Else
            IdxName = ""
        End If
        If Not btnEdit.Text = "&Cancel" Then
            If ReturnRowByName(txtCode.Text, row, AppTblPath & "BillingCycles", , "Code") Then
                'Message modified by Michael Pastor
                MsgBox("Specified code already exists. Please enter a unique code.", MsgBoxStyle.Exclamation, "Data Invalid")
                '- MsgBox("This Code already exists! Input UNIQUE Code!")
                Exit Sub
            End If
        End If

        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, IdxName) Then
            'Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            PopulateDataset2(dtA, dtSet, SQLSelect)
            SortColIdx = UltraGrid1.DisplayLayout.Bands(0).SortedColumns(0).Index
            FillUltraGrid(UltraGrid1, dtSet, SortColIdx) 'Let user to sort a Grid '1' not '-1'
            UGLoadLayout(Me, UltraGrid1, 1) 'Karina added
            row = dtSet.Tables(0).Rows.Find(IdxName)
            UltraGrid1.Enabled = True 'Karina added
            Group_EnDis(False)
            UltraGrid1.Focus()
            UltraGrid1.Refresh()
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(RowIdx) 'Karina commented, after saving - refreshing

        End If
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        ' Lock Records
        If sender.text.toupper = "&EDIT" Then
            If UltraGrid1.Rows.Count <= 0 Then Exit Sub
            If EditForm(Me, PrepSelectQuery(SQLSelect, " Where Code = '" & UltraGrid1.ActiveRow.Cells("Code").Value.ToString.Trim & "'"), EditAction.START, cmdTrans) Then
                sender.text = "&Cancel"
                UltraGrid1.Enabled = False
                Group_EnDis(True)
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                If UltraGrid1.Rows.Count <= 0 Then Exit Sub
                sender.text = "&Edit"
                UltraGrid1.Enabled = True
                Group_EnDis(False)

            End If
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If btnEdit.Text.ToUpper = "&CANCEL" Then

        End If
        If sender.text = "&New" Then

            Group_EnDis(True)
            txtCode.ReadOnly = False
            txtName.ReadOnly = False
            ClearForm(Me)
            sender.text = "&Cancel"
            txtCode.Focus()
        Else
            ClearForm(Me)
            sender.text = "&New"
            Group_EnDis(False)
            UltraGrid1.Focus()
        End If
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
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
    Private Sub BillingCycleSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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
            End If
        End If
        UGSaveLayout(Me, UltraGrid1, 1)
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dsData As DataSet
        Dim ID As Integer
        Dim row As DataRow
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

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
            Exit Sub
        End If
        If ID >= 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetItem(ID)
        Else
            ClearForm(Me)
        End If

    End Sub

    Public Function ReturnRowByName(ByVal Name As String, ByRef dbRow As DataRow, ByVal dbTableName As String, Optional ByVal Condition As String = "", Optional ByVal NameFldName As String = "Name", Optional ByVal AltQuery As String = "") As Boolean
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet

        dbRow = Nothing
        ReturnRowByName = False
        If AltQuery = "" Then
            PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery("Select * from " & dbTableName & " Where " & NameFldName & " = '" & Name & "'", Condition))
        Else
            PopulateDataset2(dtAdapter, dtSet, AltQuery)
        End If

        If dtSet.Tables(0).Rows.Count > 0 Then
            dbRow = dtSet.Tables(0).NewRow
            dbRow = dtSet.Tables(0).Rows(0)
            ReturnRowByName = True
            dtSet = Nothing
            dtAdapter = Nothing
        Else
            dtSet = Nothing
            dtAdapter = Nothing
        End If
    End Function
End Class