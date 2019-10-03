Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors


Public Class PricePlanModules
    Inherits System.Windows.Forms.Form
 
    Dim SQLSelect As String = "Select RowId, ModuleName, TableName, ColumnTitle, ColumnName, ColumnPrefix, ColumnSuffix From " & BILLTblPath & " PricePlanModules"
    'Dim SQLSelect As String = "Select ModuleName, TableName, ColumnName, ColumnPrefix, ColumnSuffix From " & BillTblPath & " PricePlanModules"
    'Dim SLQSelSave As String = "Select ModuleName, TableName, ColumnName, ColumnPrefix, ColumnSuffix From " & BillTblPath & " PricePlanModules"
    Dim cmdTrans As SqlCommand
    Dim MeText As String
    Dim dtSet As New DataSet
    Dim SortColIdx As Int16 = 1
    Dim HidCols() As String = {"RowId"}
    Dim dtAdapter As SqlDataAdapter

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
    Friend WithEvents utModuleName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utTableName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utColumnName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utColumnPrefix As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utColumnSuffix As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents utRowID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents utColumnTitle As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.utColumnTitle = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.utRowID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utModuleName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utTableName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utColumnName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utColumnPrefix = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utColumnSuffix = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        CType(Me.utColumnTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utModuleName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTableName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utColumnName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utColumnPrefix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utColumnSuffix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.utColumnTitle)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.utRowID)
        Me.Panel1.Controls.Add(Me.utModuleName)
        Me.Panel1.Controls.Add(Me.utTableName)
        Me.Panel1.Controls.Add(Me.utColumnName)
        Me.Panel1.Controls.Add(Me.utColumnPrefix)
        Me.Panel1.Controls.Add(Me.utColumnSuffix)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(648, 88)
        Me.Panel1.TabIndex = 0
        '
        'utColumnTitle
        '
        Me.utColumnTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utColumnTitle.Location = New System.Drawing.Point(432, 16)
        Me.utColumnTitle.MaxLength = 40
        Me.utColumnTitle.Name = "utColumnTitle"
        Me.utColumnTitle.Size = New System.Drawing.Size(200, 21)
        Me.utColumnTitle.TabIndex = 2
        Me.utColumnTitle.Tag = ".ColumnTitle"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(352, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Column Title:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utRowID
        '
        Me.utRowID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utRowID.Location = New System.Drawing.Point(16, 64)
        Me.utRowID.MaxLength = 15
        Me.utRowID.Name = "utRowID"
        Me.utRowID.Size = New System.Drawing.Size(18, 21)
        Me.utRowID.TabIndex = 53
        Me.utRowID.Tag = ".RowID.view"
        Me.utRowID.Visible = False
        '
        'utModuleName
        '
        Me.utModuleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utModuleName.Location = New System.Drawing.Point(88, 16)
        Me.utModuleName.MaxLength = 20
        Me.utModuleName.Name = "utModuleName"
        Me.utModuleName.Size = New System.Drawing.Size(200, 21)
        Me.utModuleName.TabIndex = 0
        Me.utModuleName.Tag = ".ModuleName"
        '
        'utTableName
        '
        Me.utTableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTableName.Location = New System.Drawing.Point(88, 40)
        Me.utTableName.MaxLength = 60
        Me.utTableName.Name = "utTableName"
        Me.utTableName.Size = New System.Drawing.Size(200, 21)
        Me.utTableName.TabIndex = 1
        Me.utTableName.Tag = ".TableName"
        '
        'utColumnName
        '
        Me.utColumnName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utColumnName.Location = New System.Drawing.Point(432, 40)
        Me.utColumnName.MaxLength = 40
        Me.utColumnName.Name = "utColumnName"
        Me.utColumnName.Size = New System.Drawing.Size(200, 21)
        Me.utColumnName.TabIndex = 3
        Me.utColumnName.Tag = ".ColumnName"
        '
        'utColumnPrefix
        '
        Me.utColumnPrefix.Location = New System.Drawing.Point(432, 64)
        Me.utColumnPrefix.MaxLength = 5
        Me.utColumnPrefix.Name = "utColumnPrefix"
        Me.utColumnPrefix.Size = New System.Drawing.Size(48, 21)
        Me.utColumnPrefix.TabIndex = 4
        Me.utColumnPrefix.Tag = ".ColumnPrefix"
        '
        'utColumnSuffix
        '
        Me.utColumnSuffix.Location = New System.Drawing.Point(584, 64)
        Me.utColumnSuffix.MaxLength = 5
        Me.utColumnSuffix.Name = "utColumnSuffix"
        Me.utColumnSuffix.Size = New System.Drawing.Size(48, 21)
        Me.utColumnSuffix.TabIndex = 5
        Me.utColumnSuffix.Tag = ".ColumnSuffix"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Table Name:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(504, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 16)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Column Suffix:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(352, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Column Prefix:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(352, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Column Name:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Module Name:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 88)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(648, 216)
        Me.UltraGrid1.TabIndex = 0
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(176, 8)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(560, 8)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "&Exit"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(96, 8)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(16, 8)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(384, 8)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnDelete)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnEdit)
        Me.Panel2.Controls.Add(Me.btnExit)
        Me.Panel2.Controls.Add(Me.btnNew)
        Me.Panel2.Location = New System.Drawing.Point(0, 304)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(656, 40)
        Me.Panel2.TabIndex = 1
        '
        'PricePlanModules
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(648, 342)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PricePlanModules"
        Me.Tag = "PricePlanModules"
        Me.Text = "Price Plan Modules"
        Me.Panel1.ResumeLayout(False)
        CType(Me.utColumnTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utModuleName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTableName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utColumnName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utColumnPrefix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utColumnSuffix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PricePlanCodules_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = BILLTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ''Set each control's length based on DB size
        SetupCtrlsLength(UltraGrid1, AppDBName, AppDBUser, AppDBPass)

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.GroupByBox.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        Group_EnDis(True)
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)
        FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HidCols)

    End Sub
    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        FormLoadFromGrid(Me, sender)
    End Sub
    Private Sub UltraGrid1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled Then
            FormLoadFromGrid(Me, sender)
        End If
    End Sub
    Private Sub Group_EnDis(ByVal status As Boolean)
        Panel1.Enabled = status
        btnSave.Enabled = status
        btnDelete.Enabled = status
        UltraGrid1.Enabled = status
        Btn_En(status)
    End Sub

    Private Sub Btn_En(ByVal status As Boolean)
        If status = True Then 'Enable Editing
            UltraGrid1.Enabled = True
            btnDelete.Enabled = True
            Panel1.Enabled = False
            btnSave.Enabled = False
            btnEdit.Enabled = True
        Else 'End Editing
            UltraGrid1.Enabled = False
            btnDelete.Enabled = False
            Panel1.Enabled = True
            btnSave.Enabled = True
            btnEdit.Enabled = False
        End If
    End Sub

    Private Sub PricePlanModules_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Karina, Warn the user on EXITING/CLOSING window when in Edit/New modes.
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                Group_EnDis(False)
                sender.text = "&Edit"
            Else
            End If

        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If btnEdit.Text = "&Cancel" Then
            MessageBox.Show("You are in 'Edit' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If sender.text = "&New" Then
            ClearForm(Me)
            sender.text = "&Cancel"
            Group_EnDis(False)
            utModuleName.Focus()
        Else
            sender.text = "&New"
            Group_EnDis(True)
            UltraGrid1.Focus()

        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim RowIdx, IdxName As Integer


        ''Get the next PlanID
        If utRowID.Text.Trim = "" Then
            Dim numRowsUG1 As Integer = UltraGrid1.Rows.Count() - 1
            Dim valueLastRowID As Infragistics.Win.UltraWinGrid.UltraGridCell = UltraGrid1.Rows(numRowsUG1).Cells("RowId")
            Dim newRowID As Integer = valueLastRowID.Text
            newRowID = newRowID + 1
            utRowID.Text = newRowID
        End If


        If Not UltraGrid1.ActiveRow Is Nothing Then
            IdxName = UltraGrid1.ActiveRow.Cells("RowID").Value
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                RowIdx = UltraGrid1.ActiveRow.Index()
            End If
        End If


        If utModuleName.Text.Trim = "" Then
            MsgBox("Module Name field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf utTableName.Text.Trim = "" Then
            MsgBox("Table Name field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf utColumnTitle.Text.Trim = "" Then
            MsgBox("Column Title field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf utColumnName.Text.Trim = "" Then
            MsgBox("Column Name field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If



        Dim value As Integer = utRowID.Text


        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, "Where RowID = " & utRowID.Text) Then ', " Where RowID = " & utRowID.Text
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            PopulateDataset2(dtA, dtSet, SQLSelect)
            SortColIdx = UltraGrid1.DisplayLayout.Bands(0).SortedColumns(0).Index
            FillUltraGrid(UltraGrid1, dtSet, SortColIdx, HidCols) 'Let user to sort a Grid '1' not '-1'
            UltraGrid1.Enabled = True 'Karina added
            Group_EnDis(True)
            btnNew.Enabled = True
            btnEdit.Enabled = True
            btnNew.Text = "&New"
            btnEdit.Text = "&Edit"

            UltraGrid1.Focus()
            UltraGrid1.Refresh()
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(RowIdx) 'Karina commented, after saving - refreshing

        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records
        If utModuleName.Text.Trim = "" Then Exit Sub
        If btnNew.Text = "&Cancel" Then
            MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If sender.text.toupper = "&EDIT" Then
            If UltraGrid1.Rows.Count <= 0 Then Exit Sub
            If EditForm(Me, PrepSelectQuery(SQLSelect, " Where RowID = " & utRowID.Text), EditAction.START, cmdTrans) Then
                sender.text = "&Cancel"
                Group_EnDis(False)
                btnEdit.Enabled = True
                btnNew.Enabled = False


            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                If UltraGrid1.Rows.Count <= 0 Then Exit Sub
                sender.text = "&Edit"
                Group_EnDis(True)
                btnNew.Enabled = True

            End If
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim RowID As String = UltraGrid1.ActiveRow.Cells("RowId").Value
        Dim QueryExec As String = "Delete from " & BILLTblPath & "PricePlanModules where RowId = '" & RowID & "'"

        If MsgBox("Are you sure that you want to delete selected Module?", MsgBoxStyle.YesNo, "Delete Module!") = MsgBoxResult.Yes Then
            ExecuteQuery(QueryExec)
        End If
        LoadData()
        UltraGrid1.Focus()
        UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(0)

    End Sub

    
End Class
