Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class BranchZip
    Inherits System.Windows.Forms.Form
    Public HiddenCols() As String = {"ID"}

    Dim MeText As String
    Dim cmdTrans As SqlCommand
    Dim HidCols() As String '= {"RowID"}
    Dim dtSet As New DataSet
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim m_row As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents utBranch As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utBranchID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utCity As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBranch As System.Windows.Forms.Button
    Friend WithEvents utOldZip As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents utZip As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnCity As System.Windows.Forms.Button
    Friend WithEvents ucboState As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ucboState = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnCity = New System.Windows.Forms.Button
        Me.utOldZip = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.utZip = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.utCity = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBranch = New System.Windows.Forms.Button
        Me.utBranchID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.utBranch = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ucboState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOldZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utCity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.utBranchID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(648, 144)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Default Values "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ucboState)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnCity)
        Me.GroupBox2.Controls.Add(Me.utOldZip)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.utZip)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.utCity)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(616, 48)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'ucboState
        '
        Me.ucboState.AutoEdit = False
        Me.ucboState.DisplayMember = ""
        Me.ucboState.Location = New System.Drawing.Point(230, 16)
        Me.ucboState.Name = "ucboState"
        Me.ucboState.Size = New System.Drawing.Size(48, 21)
        Me.ucboState.TabIndex = 1
        Me.ucboState.Tag = ".STATE..1.STATE.CODE.CODE"
        Me.ucboState.ValueMember = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(187, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 151
        Me.Label5.Text = "State:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCity
        '
        Me.btnCity.Location = New System.Drawing.Point(437, 17)
        Me.btnCity.Name = "btnCity"
        Me.btnCity.Size = New System.Drawing.Size(80, 21)
        Me.btnCity.TabIndex = 3
        Me.btnCity.Text = "Se&lect"
        '
        'utOldZip
        '
        Me.utOldZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOldZip.Location = New System.Drawing.Point(584, 16)
        Me.utOldZip.Name = "utOldZip"
        Me.utOldZip.Size = New System.Drawing.Size(24, 21)
        Me.utOldZip.TabIndex = 4
        Me.utOldZip.Tag = "DestinationZipcode.DestZip......Zip"
        Me.utOldZip.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 149
        Me.Label3.Tag = ""
        Me.Label3.Text = "City:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utZip
        '
        Me.utZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utZip.Location = New System.Drawing.Point(357, 17)
        Me.utZip.Name = "utZip"
        Me.utZip.Size = New System.Drawing.Size(72, 21)
        Me.utZip.TabIndex = 2
        Me.utZip.Tag = "DestinationZipCode.DestZip......Zip"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(293, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 147
        Me.Label2.Tag = ""
        Me.Label2.Text = "Zipcode:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utCity
        '
        Me.utCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utCity.Location = New System.Drawing.Point(80, 16)
        Me.utCity.Name = "utCity"
        Me.utCity.Size = New System.Drawing.Size(104, 21)
        Me.utCity.TabIndex = 0
        Me.utCity.Tag = "City.Name......City"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBranch)
        Me.GroupBox1.Controls.Add(Me.utBranchID)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.utBranch)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(616, 56)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnBranch
        '
        Me.btnBranch.Location = New System.Drawing.Point(440, 22)
        Me.btnBranch.Name = "btnBranch"
        Me.btnBranch.Size = New System.Drawing.Size(80, 21)
        Me.btnBranch.TabIndex = 2
        Me.btnBranch.Text = "Se&lect"
        '
        'utBranchID
        '
        Me.utBranchID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utBranchID.Location = New System.Drawing.Point(360, 21)
        Me.utBranchID.Name = "utBranchID"
        Me.utBranchID.Size = New System.Drawing.Size(72, 21)
        Me.utBranchID.TabIndex = 1
        Me.utBranchID.Tag = ".BranchID"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(296, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 151
        Me.Label4.Tag = ""
        Me.Label4.Text = "Branch ID:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Tag = ""
        Me.Label1.Text = "Branch:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utBranch
        '
        Me.utBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utBranch.Location = New System.Drawing.Point(72, 21)
        Me.utBranch.Name = "utBranch"
        Me.utBranch.Size = New System.Drawing.Size(216, 21)
        Me.utBranch.TabIndex = 0
        Me.utBranch.Tag = ".Name......Branch"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnDelete)
        Me.GroupBox4.Controls.Add(Me.btnNew)
        Me.GroupBox4.Controls.Add(Me.btnExit)
        Me.GroupBox4.Controls.Add(Me.btnSave)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 373)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(648, 48)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(139, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 24)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "&Delete"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(73, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(64, 24)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "&New"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(552, 16)
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
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 144)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(648, 229)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Text = "BRANCH ZIPCODES"
        '
        'BranchZip
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(648, 421)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "BranchZip"
        Me.Text = "BranchZip"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ucboState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOldZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utCity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utBranchID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utBranch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BranchZip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtAdapter As SqlDataAdapter
        Dim dtaStates As New SqlDataAdapter
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = TRCTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        FillUCombo(ucboState, "CA")
        AddHandler ucboState.Leave, AddressOf UCbo_Leave

        LoadData()
        btnSave.Text = "&Save"

        Group_EnDis(False)

    End Sub


    Private Sub Group_EnDis(ByVal status As Boolean)
        GroupBox1.Enabled = status
        GroupBox2.Enabled = status
        btnSave.Enabled = status
        UltraGrid1.Enabled = Not status
        Btn_En(status)
    End Sub

    Private Sub Btn_En(ByVal status As Boolean)
        btnSave.Enabled = status
        btnSave.Text = "&Save"
        If status = True Then 'Enable Editing
        Else 'End Editing
            'btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim cnt As Integer
        Dim RowIdx, IdxName As Integer
        Dim SQLSelect, SQLSelect2 As String
        Dim row As DataRow

        SQLSelect = "Insert into " & TRCTblPath & "DestinationZipCode(BranchID, DestZip) " & _
                    " values('" & utBranchID.Text.Trim & "', '" & utZip.Text.Trim & "'); "
        'SQLSelect2 = " Insert Into " & TRCTblPath & "City(ID, Name, Zipcode, STATECODE) " & _
        '             " values('" & utBranchID.Text.Trim & "', '" & utCity.Text.Trim.ToUpper.Trim & "', '" & utZip.Text.Trim & "', '" & ucboState.Value & "'); "
        SQLSelect2 = " Insert Into " & TRCTblPath & "City(Name, Zipcode, STATECODE) " & _
                     " values('" & utCity.Text.Trim.ToUpper.Trim & "', '" & utZip.Text.Trim & "', '" & ucboState.Value & "'); "

        If Not UltraGrid1.ActiveRow Is Nothing Then
            'IdxName = UltraGrid1.ActiveRow.Cells("ID").Value
            'If btnEdit.Text.ToUpper = "&CANCEL" Then
            '    RowIdx = UltraGrid1.ActiveRow.Index()
            'End If
        End If
        If utBranchID.Text.Trim = "" Then
            MsgBox("Branch not selected.")
            Exit Sub
        End If
        If utCity.Text.Trim = "" Then
            MsgBox("City not selected.")
            Exit Sub
        End If
        If utZip.Text.Trim = "" Then
            MsgBox("Zipcode not selected.")
            Exit Sub
        End If
        If ExecuteQuery(SQLSelect) = False Then
            MsgBox("Record not inserted for Branch-Zip.")
            Exit Sub
        End If
        If ReturnRowByID(utZip.Text.Trim, row, AppTblPath & "CITY", "", "Zipcode", "") = False Then
            If ExecuteQuery(SQLSelect2) = False Then
                row = Nothing

            End If
        End If
        LoadData()

        ClearForm(Me)
        Group_EnDis(False)
        'UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(RowIdx)

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dsData As DataSet
        Dim ID As Integer
        Dim row As DataRow
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim SQLSelect As String

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

        SQLSelect = "Delete " & _
                    " FROM " & TRCTblPath & "DestinationZipCode where DestZip = '" & ugrow.Cells("Zip").Value & "'"

        'If MsgBox("Delete Assignment for Zipcode '" & utZip.Text.Trim & "'?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '    Exit Sub
        'End If


        UltraGrid1.DeleteSelectedRows()
        'If UpdateDbFromDataSet(dtSet, SQLSelect) <= 0 Then
        '    MsgBox("btnDelete_Click: Error!")
        '    Exit Sub
        'End If
        If ExecuteQuery(SQLSelect) = False Then
            MsgBox("Record Deletion was not successful.")
        End If
        If ID >= 0 Then
            'UltraGrid1.ActiveRow = UltraGrid1.Rows.GetItem(ID)
        Else
            ClearForm(Me)
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Lock Records
        Dim SQLSelect As String
        SQLSelect = "Select dz.BranchID, dz.DestZip as Zip " & _
                    " FROM " & TRCTblPath & "DestinationZipCode dz "
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
            ClearForm(Me.GroupBox2)
            sender.text = "&Cancel"
            'Value.Focus()
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
        'FormLoadFromGrid(Me, sender)
        'If Not UltraGrid1.ActiveRow.ListObject Is Nothing Then
        'utBranch.Text = UltraGrid1.ActiveRow.Cells("Branch").Value
        'MsgBox("Hey!")

        'End If
        m_row = UltraGrid1.ActiveRow
        'If Not m_row Is Nothing Then
        '    If Not m_row.ListObject Is Nothing Then
        '        UltraGrid1.ActiveRow.Update()
        '    End If
        'End If
    End Sub

    Private Sub UltraGrid1_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles UltraGrid1.Invalidated
    End Sub
    Private Sub UltraGrid1_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles UltraGrid1.AfterRowUpdate
        If Not m_row Is Nothing Then
            FormLoadFromGrid(Me, UltraGrid1)
        End If
    End Sub
    Private Sub UltraGrid1_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles UltraGrid1.InitializeRow
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled And UltraGrid1.Rows.Count > 0 Then
            'FormLoadFromGrid(Me, sender)
        End If
    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, AcctCond, FromLocCond, ToLocCond, TRNumCond, ThirdPCond As String



        SQLSelect = "Select b.BranchID, b.Name as Branch, c.Name as City, dz.DestZip as Zip " & _
                    " From " & TRCTblPath & "Branch b, " & TRCTblPath & "City c, " & TRCTblPath & "DestinationZipCode dz " & _
                    " Where b.branchID = dz.BranchID AND dz.DestZip = c.Zipcode " & _
                    " Order By b.BranchID "


        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If


        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        'For i = 0 To dtSet.Tables(0).Columns.Count - 1
        '    dtSet.Tables(0).Columns(i).ReadOnly = True
        'Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid1, dtSet, -1, HidCols, 0)
        'UltraGrid1.DataSource = dtSet

        'UGLoadLayout(Me, UltraGrid1, 1)

        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next

        UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid1.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("Zip", Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns("Zip"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid1.DisplayLayout.Bands(0).Summaries("Zip").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        UltraGrid1.DisplayLayout.AutoFitColumns = False
        'UltraGrid1.Text = "Packages"
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


    Private Sub btnBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBranch.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow


        SelectSQL = "Select * from " & TRCTblPath & "Branch b order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Branches"
            Srch.Text = "Branches"
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

                    utBranch.Text = ugRow.Cells("Name").Text
                    utBranchID.Text = ugRow.Cells("BranchID").Text

                    Srch = Nothing
                    utBranch.Modified = False
                    utBranchID.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub utBranch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utBranch.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utBranchID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If
            If SearchOnLeave(sender, utBranchID, TRCTblPath & "Branch", "BranchID", "Name", "*", "Branches", "") Then
                'If ReturnRowByID(utBranchID.Text, row, "[" & TRCDBName & "].dbo.Location", "", "AddressID") Then
                '    gLoc.Text = row("Name")
                '    gLocID.Text = row("LocationID")
                '    row = Nothing
                'Else
                '    MsgBox("Point Not Found.")
                '    gLoc.Text = ""
                '    gLocID.Text = ""
                '    gAddrID.Text = ""
                'End If
            Else
                'MsgBox("Truck Not Found.")
                utBranch.Text = ""
                utBranchID.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utBranch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utBranch.KeyUp
        TypeAhead(sender, e, TRCTblPath & "Branch", "Name", "")
    End Sub

    Private Sub utBranchID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utBranchID.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utBranch.Text = ""
            sender.text = ""
        Else
            ' This for Accounts With Numbers Only Name!!
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If
            If SearchOnLeave(sender, utBranchID, TRCTblPath & "branch", "BranchID", "BranchID", "*", "Branches", "") Then
                If ReturnRowByID(utBranchID.Text, row, TRCTblPath & "branch", "", "BranchID") Then
                    utBranch.Text = row("Name")
                    row = Nothing
                Else
                    MsgBox("Branch Not Found.")
                    utBranch.Text = ""
                    utBranchID.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                utBranch.Text = ""
                utBranchID.Text = ""
                sender.focus()
            End If
        End If

        sender.Modified = False


    End Sub

    Private Sub btnCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCity.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow


        SelectSQL = "Select * from " & TRCTblPath & "city c Where zipcode not in (select rtrim(destzip) FROM " & TRCTblPath & "DestinationZipcode) order by statecode, Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Cities"
            Srch.Text = "City-Zip List"
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

                    utCity.Text = ugRow.Cells("Name").Text
                    utZip.Text = ugRow.Cells("Zipcode").Text

                    Srch = Nothing
                    utBranch.Modified = False
                    utBranchID.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub utCity_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utCity.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utZip.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, utZip, TRCTblPath & "City", "ZIPCODE", "Name", "*", "Cities", "") Then
                'If ReturnRowByID(utBranchID.Text, row, "[" & TRCDBName & "].dbo.Location", "", "AddressID") Then
                '    gLoc.Text = row("Name")
                '    gLocID.Text = row("LocationID")
                '    row = Nothing
                'Else
                '    MsgBox("Point Not Found.")
                '    gLoc.Text = ""
                '    gLocID.Text = ""
                '    gAddrID.Text = ""
                'End If
            Else
                'MsgBox("Truck Not Found.")
                'utCity.Text = ""
                utZip.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utCity_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utCity.KeyUp
        TypeAhead(sender, e, TRCTblPath & "city", "Name", " WHERE ZIPCODE not in (select rtrim(destzip) FROM " & TRCTblPath & "DestinationZipcode)")
    End Sub

    Private Sub utZip_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utZip.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utCity.Text = ""
            sender.text = ""
        Else
            ' This for Accounts With Numbers Only Name!!
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If
            If SearchOnLeave(sender, utZip, TRCTblPath & "city", "ZIPCODE", "ZIPCODE", "*", "City-Zipcodes", "") Then
                If ReturnRowByID(utZip.Text, row, TRCTblPath & "city", "", "ZIPCODE") Then
                    utCity.Text = row("Name")
                    row = Nothing
                Else
                    MsgBox("City Not Found.")
                    utCity.Text = ""
                    utZip.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                'utCity.Text = ""
                'utZip.Text = ""
                sender.focus()
            End If
        End If

        sender.Modified = False
    End Sub
    'Karina
    Private Sub BranchZip_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

    End Sub
End Class
