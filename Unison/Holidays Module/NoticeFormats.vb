Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class NoticeFormats
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = _
            "Select ID, Name, FileName " & _
            " From " & HOLIDAYSTblPath & "NoticeFormats ORDER by ID"

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim dvStates As New DataView()
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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents WeightID As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FormatName As System.Windows.Forms.TextBox
    Friend WithEvents File As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.FormatName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.File = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.WeightID = New System.Windows.Forms.TextBox
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.GroupBox3.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.FormatName)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.File)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.WeightID)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(674, 120)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'FormatName
        '
        Me.FormatName.Location = New System.Drawing.Point(96, 56)
        Me.FormatName.Name = "FormatName"
        Me.FormatName.Size = New System.Drawing.Size(156, 20)
        Me.FormatName.TabIndex = 1
        Me.FormatName.Tag = ".Name"
        Me.FormatName.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "File:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'File
        '
        Me.File.Location = New System.Drawing.Point(96, 88)
        Me.File.Name = "File"
        Me.File.Size = New System.Drawing.Size(312, 20)
        Me.File.TabIndex = 2
        Me.File.Tag = ".FileName"
        Me.File.Text = ""
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 16)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Format Name:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(72, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WeightID
        '
        Me.WeightID.Enabled = False
        Me.WeightID.Location = New System.Drawing.Point(96, 23)
        Me.WeightID.Name = "WeightID"
        Me.WeightID.Size = New System.Drawing.Size(78, 20)
        Me.WeightID.TabIndex = 0
        Me.WeightID.Tag = ".id.view"
        Me.WeightID.Text = ""
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 120)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(674, 255)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Text = "Notice Formats"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 375)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(674, 40)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(596, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 4
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
        'NoticeFormats
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(674, 415)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "NoticeFormats"
        Me.Tag = "NoticeFormats"
        Me.Text = "Notice Formats Setup"
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub WeightBreakdown_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtAdapter As SqlDataAdapter
        Dim MinWinSize As System.Drawing.Size


        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HOLIDAYSTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, HOLIDAYSDBName, HOLIDAYSDBUser, HOLIDAYSDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        btnSave.Text = "&Save"

        'Dim ugListLayout As New Infragistics.Win.UltraWinGrid.UltraGridLayout()

        FillUltraGrid(UltraGrid1, dtSet, 1)
        UGLoadLayout(Me, UltraGrid1, 1)

        'UltraGrid1.DisplayLayout.Bands(0).Columns(0).Layout.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid1.DisplayLayout.Bands(0).Columns(1).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid1.DisplayLayout.Bands(0).Columns(0).Layout.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).Columns(0).Layout.Override.ActiveCellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).Columns(0).Layout.Override.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        'MinWinSize.Width = GroupBox3.Left + GroupBox3.Width + 50

        'With UltraGrid1.DisplayLayout.Bands(0).Header
        '    MinWinSize.Height = UltraGrid1.Rows(0).Height * 8 + GroupBox3.Height + GroupBox1.Height

        'End With
        'Me.MinimumSize = MinWinSize

        Group_EnDis(False)


    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        FormLoadFromGrid(Me, sender)
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled Then
            FormLoadFromGrid(Me, sender)
        End If
    End Sub

    Private Sub Group_EnDis(ByVal status As Boolean)
        GroupBox3.Enabled = status

        btnSave.Enabled = status
        If UltraGrid1.Enabled = False Then
            btnSave.Text = "&Save"
        Else
            If UltraGrid1.Rows.Count > 0 Then
                btnSave.Text = "&Update"
            Else
                btnSave.Text = "&Save"
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim ID As Integer

        'Karina Error MsgBoxes on Save
        If FormatName.Text.Trim = "" And File.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Format name and file location remain unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Enter Format Name and File Location!")
            Exit Sub
        End If

        If FormatName.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Format name remains unspecified. Please enter a format name.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '-MsgBox("Enter Format Name!")
            Exit Sub
        End If

        If File.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("File location remains unspecified. Please enter a file location.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Enter File Location!")
            Exit Sub
        End If

        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, " Where ID = " & WeightID.Text) Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            ID = Val(WeightID.Text)
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
        If WeightID.Text.Trim = "" Then Exit Sub
        If btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            MsgBox("You are in 'New' mode. Cancel or Save your current job first.", MsgBoxStyle.Exclamation, "Current Mode: New")
            '- MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLSelect, " Where ID = " & WeightID.Text), EditAction.START, cmdTrans) Then
                UltraGrid1.Enabled = False
                Group_EnDis(True)
                sender.text = "&Cancel"
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                sender.text = "&Edit"
                'FormLoad(Me, dvCompany)
            End If
        End If
    End Sub
    'Karina commented and added PackageTypes_Closing to WARN a user about Exiting from EDIT/NEW mode.
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
        '        UltraGrid1.Enabled = True
        '        Group_EnDis(False)
        '        sender.text = "&Edit"
        '    Else
        '        'Exit Sub
        '    End If

        'End If
        'UGSaveLayout(Me, UltraGrid1, 1)
        Me.Close()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'UltraGrid1.DeleteSelectedRows()
        If btnEdit.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            MsgBox("You are in 'Edit' mode. Cancel or Save your current job first.", MsgBoxStyle.Exclamation, "Current Mode: Edit")
            '- MessageBox.Show("You are in 'Edit' mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If sender.text = "&New" Then
            UltraGrid1.Enabled = False
            ClearForm(Me)
            Group_EnDis(True)
            sender.text = "&Cancel"
            FormatName.Focus()
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

        'Karina - NOTHING on DELETing not chosed field
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
        'ID = UltraGrid1.ActiveRow.Cells(0).Value
        'row = dtSet.Tables(0).Rows.Find(ID)
        'row.Delete()

        'UltraGrid1.ActiveRow.Delete()
        'dsData = UltraGrid1.DataSource


    End Sub

    Private Sub Value_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(e.KeyChar) = False And (e.KeyChar <> ".") And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub


    Private Sub Value_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.text = Format(Val(sender.text), "#0.00")
    End Sub

    Private Sub NoticeFormats_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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
