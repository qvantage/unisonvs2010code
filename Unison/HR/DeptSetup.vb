Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class DeptSetup
    Inherits System.Windows.Forms.Form
    'Public SQLSelect As String = "Select DeptNo, Department, Active from " & HRTblPath & "DEPARTMENTS where Active = 1 ORDER BY DeptNo"
    Public SQLSelect As String = "Select DeptNo, Department, Active from " & HRTblPath & "DEPARTMENTS ORDER BY DeptNo"

    Public HiddenCols() As String = {"Active"}
    'Public CLDB, CLDBUser, CLDBPass As String
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents utDeptID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utDeptName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.utDeptID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utDeptName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        CType(Me.utDeptID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utDeptName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'utDeptID
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utDeptID.Appearance = Appearance1
        Me.utDeptID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utDeptID.Location = New System.Drawing.Point(104, 16)
        Me.utDeptID.Name = "utDeptID"
        Me.utDeptID.Size = New System.Drawing.Size(100, 21)
        Me.utDeptID.TabIndex = 0
        Me.utDeptID.Tag = ".DeptNo"
        '
        'utDeptName
        '
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.utDeptName.Appearance = Appearance2
        Me.utDeptName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utDeptName.Location = New System.Drawing.Point(104, 40)
        Me.utDeptName.Name = "utDeptName"
        Me.utDeptName.Size = New System.Drawing.Size(200, 21)
        Me.utDeptName.TabIndex = 1
        Me.utDeptName.Tag = ".Department"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(64, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(64, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 72)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(376, 200)
        Me.UltraGrid1.TabIndex = 2
        Me.UltraGrid1.Tag = "Departments"
        Me.UltraGrid1.Text = "Departments"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnNew)
        Me.GroupBox4.Controls.Add(Me.btnEdit)
        Me.GroupBox4.Controls.Add(Me.btnExit)
        Me.GroupBox4.Controls.Add(Me.btnSave)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 278)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(376, 48)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
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
        'DeptSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 326)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.utDeptName)
        Me.Controls.Add(Me.utDeptID)
        Me.Name = "DeptSetup"
        Me.Tag = "DEPARTMENTS"
        Me.Text = "Departments Setup"
        CType(Me.utDeptID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utDeptName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub DeptSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtaStates As New SqlDataAdapter
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me, HRDBName, HRDBUser, HRDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        LoadData()

        btnSave.Text = "&Save"

        'MinWinSize.Width = UltraGrid1.Width + Value.Left + Value.Width + 50
        'MinWinSize.Height = GroupBox4.Height + GroupBox3.Height + 20 'Panel1.Height
        'Me.MinimumSize = MinWinSize


        'UltraGrid1.Focus()
        Group_EnDis(False)



        UltraGrid1.DisplayLayout.AutoFitColumns = True
    End Sub
    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        If dtSet Is Nothing Then
            dtSet = New DataSet
        End If
        dtSet.Tables.Clear()
        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols)
        UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Clear()
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(UltraGrid1.DisplayLayout.Bands(0).Columns(SortColIdx), False)
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, False, False)
        If UltraGrid1.Rows.Count > 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows(0)
        End If
    End Sub
    Private Sub Group_EnDis(ByVal status As Boolean)
        'GroupBox3.Enabled = status
        btnSave.Enabled = status

        utDeptID.Enabled = status
        utDeptName.Enabled = status

        UltraGrid1.Enabled = Not status
        'btnDelete.Enabled = Not status
        Btn_En(status)
    End Sub

    Private Sub Btn_En(ByVal status As Boolean)
        btnSave.Enabled = status


        btnSave.Text = "&Save"
        If status = True Then 'Enable Editing
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                btnNew.Enabled = False
                utDeptID.ReadOnly = True
                utDeptName.ReadOnly = False
            Else
                btnEdit.Enabled = False
            End If
        Else 'End Editing
            btnNew.Enabled = True
            btnEdit.Enabled = True
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"

            utDeptID.ReadOnly = True
            utDeptName.ReadOnly = True
        End If
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        ''Dim RowIdx, IdxName As Integer

        Dim RowIdx As Integer
        Dim IdxName As String

        ''Dim SQLSave As String = "Select DeptNo, Department, Active From " & HRTblPath & "DEPARTMENTS"

        ''If Value.Text.Trim = "" Then
        ''    MsgBox("Enter Service Type!")
        ''    Exit Sub
        ''End If
        If utDeptID.Text.Trim = "" Then
            MsgBox("Enter Department ID.")
            Exit Sub
        End If
        If utDeptName.Text.Trim = "" Then
            MsgBox("Enter Department Name.")
            Exit Sub
        End If


        If Not UltraGrid1.ActiveRow Is Nothing Then
            'IdxName = UltraGrid1.ActiveRow.Cells("DeptNo").Value
            IdxName = " Where DeptNo = '" & UltraGrid1.ActiveRow.Cells("DeptNO").Value.ToString.Trim & "'"
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                RowIdx = UltraGrid1.ActiveRow.Index()
            End If
        Else
            IdxName = ""
        End If


        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, IdxName) Then
            '    If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, " Where DeptNo = '" & utDeptID.Text & "'") Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            ''btnEdit.Text = "&Edit"
            ''Me.Text = MeText & " -- Record Updated."
            PopulateDataset2(dtA, dtSet, SQLSelect)
            SortColIdx = UltraGrid1.DisplayLayout.Bands(0).SortedColumns(0).Index
            FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HiddenCols) 'Let user to sort a Grid '1' not '-1'
            UGLoadLayout(Me, UltraGrid1, 1) 'Karina added
            row = dtSet.Tables(0).Rows.Find(IdxName)
            UltraGrid1.Enabled = True 'Karina added
            ''Dim Arr() As Array
            ''Arr = row.ItemArray
            Group_EnDis(False)
            UltraGrid1.Focus()
            UltraGrid1.Refresh()
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(RowIdx) 'Karina commented, after saving - refreshing

        End If
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        'utDeptID.ReadOnly = True

        ' Lock Records
        If sender.text.toupper = "&EDIT" Then
            If UltraGrid1.Rows.Count <= 0 Then Exit Sub
            If EditForm(Me, PrepSelectQuery(SQLSelect, " Where DeptNo = '" & UltraGrid1.ActiveRow.Cells("DeptNO").Value.ToString.Trim & "'"), EditAction.START, cmdTrans) Then
                'If EditForm(Me, PrepSelectQuery(SQLSelect, " Where DeptNo = " & utDeptID.Text), EditAction.START, cmdTrans) Then
                'SQLEdit, " Where ID = " & ManifestID.Text)

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

                'FormLoad(Me, dvCompany)
            End If
        End If
        'utDeptID.ReadOnly = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'UltraGrid1.DeleteSelectedRows()

        If btnEdit.Text.ToUpper = "&CANCEL" Then

        End If
        If sender.text = "&New" Then

            Group_EnDis(True)
            utDeptID.ReadOnly = False
            utDeptName.ReadOnly = False
            ClearForm(Me)
            sender.text = "&Cancel"
            utDeptID.Focus()
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
    Private Sub DeptSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.No Then
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
