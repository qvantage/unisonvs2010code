Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class WeightBreakdown
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = _
            "Select ID, WeightLimit, OWCharge, Description " & _
            " FROM " & WeightVars.WEIGHTTblPath & "WeightBreakdown ORDER BY ID"

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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents OWCharge As System.Windows.Forms.TextBox
    Friend WithEvents WeightLimit As System.Windows.Forms.TextBox
    Friend WithEvents Description As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Description = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OWCharge = New System.Windows.Forms.TextBox()
        Me.WeightLimit = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WeightID = New System.Windows.Forms.TextBox()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Description)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.OWCharge)
        Me.GroupBox3.Controls.Add(Me.WeightLimit)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.WeightID)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(518, 138)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 18)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Description:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Description
        '
        Me.Description.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Description.Location = New System.Drawing.Point(115, 102)
        Me.Description.Name = "Description"
        Me.Description.Size = New System.Drawing.Size(375, 22)
        Me.Description.TabIndex = 34
        Me.Description.Tag = ".Description"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(432, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 19)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "$/lb"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(192, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 19)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "lb"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OWCharge
        '
        Me.OWCharge.Location = New System.Drawing.Point(346, 55)
        Me.OWCharge.Name = "OWCharge"
        Me.OWCharge.Size = New System.Drawing.Size(76, 22)
        Me.OWCharge.TabIndex = 2
        Me.OWCharge.Tag = ".owcharge"
        Me.OWCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'WeightLimit
        '
        Me.WeightLimit.Location = New System.Drawing.Point(115, 55)
        Me.WeightLimit.Name = "WeightLimit"
        Me.WeightLimit.Size = New System.Drawing.Size(77, 22)
        Me.WeightLimit.TabIndex = 1
        Me.WeightLimit.Tag = ".WeightLimit"
        Me.WeightLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(250, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 19)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "O.W.Charge:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(19, 55)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 19)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Weight Limit:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(77, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WeightID
        '
        Me.WeightID.Enabled = False
        Me.WeightID.Location = New System.Drawing.Point(115, 18)
        Me.WeightID.Name = "WeightID"
        Me.WeightID.Size = New System.Drawing.Size(67, 22)
        Me.WeightID.TabIndex = 0
        Me.WeightID.Tag = ".id.view"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 138)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(518, 204)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Text = "Weight Breakdowns"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 342)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(518, 46)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(413, 18)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(90, 25)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(192, 18)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 25)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(96, 18)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(90, 25)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 18)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 25)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(288, 18)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(90, 25)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.Visible = False
        '
        'WeightBreakdown
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(432, 341)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "WeightBreakdown"
        Me.Tag = "WeightBreakdown"
        Me.Text = "Weight Charge"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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

        btnSave.Text = "&Save"

        'Dim ugListLayout As New Infragistics.Win.UltraWinGrid.UltraGridLayout()

        FillUltraGrid(UltraGrid1, dtSet, 0)
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

        'Karina added
        If WeightLimit.Text = "" And OWCharge.Text = "" Then
            MsgBox("Weight Limit and O.W.Charge fields are empty.")
            Exit Sub
        End If
        If WeightLimit.Text = "" Then
            MsgBox("Weight Limit field is empty.")
            Exit Sub
        End If
        If OWCharge.Text = "" Then
            MsgBox("O.W.Charge field is empty.")
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
        btnDelete.Enabled = True
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records
        If WeightID.Text.Trim = "" Then Exit Sub
        If btnNew.Text = "&Cancel" Then
            MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLSelect, " Where ID = " & WeightID.Text), EditAction.START, cmdTrans) Then
                UltraGrid1.Enabled = False
                sender.text = "&Cancel"
                Group_EnDis(True)

            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                sender.text = "&Edit"
                Group_EnDis(False)

                'FormLoad(Me, dvCompany)
            End If
        End If
    End Sub

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
            MessageBox.Show("You are in 'Edit' mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If sender.text = "&New" Then
            btnDelete.Enabled = False
            UltraGrid1.Enabled = False
            ClearForm(Me)
            sender.text = "&Cancel"
            Group_EnDis(True)
            WeightLimit.Focus()
        Else
            sender.text = "&New"
            btnDelete.Enabled = True
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

    Private Sub Value_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles WeightLimit.KeyPress, OWCharge.KeyPress
        If IsNumeric(e.KeyChar) = False And (e.KeyChar <> ".") And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub


    Private Sub Value_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OWCharge.Leave
        sender.text = Format(Val(sender.text), "#0.00")
    End Sub
    Private Sub WeightBreakdown_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
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
