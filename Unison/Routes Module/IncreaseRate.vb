Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class IncreaseRate
    Inherits System.Windows.Forms.Form

    Dim MeText As String

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbRate As System.Windows.Forms.RadioButton
    Friend WithEvents rbAmnt As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbAmnt = New System.Windows.Forms.RadioButton()
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker()
        Me.rbRate = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New TextBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExit, Me.btnSave})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(224, 40)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(146, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 21)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "&Ok"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbAmnt, Me.DTPicker1, Me.rbRate, Me.Label1, Me.TextBox1})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 149)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'rbAmnt
        '
        Me.rbAmnt.Location = New System.Drawing.Point(16, 77)
        Me.rbAmnt.Name = "rbAmnt"
        Me.rbAmnt.Size = New System.Drawing.Size(72, 16)
        Me.rbAmnt.TabIndex = 77
        Me.rbAmnt.Text = "Amount($)"
        '
        'DTPicker1
        '
        Me.DTPicker1.Location = New System.Drawing.Point(56, 20)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(136, 20)
        Me.DTPicker1.TabIndex = 76
        '
        'rbRate
        '
        Me.rbRate.Location = New System.Drawing.Point(16, 57)
        Me.rbRate.Name = "rbRate"
        Me.rbRate.Size = New System.Drawing.Size(72, 16)
        Me.rbRate.TabIndex = 74
        Me.rbRate.Text = "Rate (%)"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Date :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(94, 64)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(80, 20)
        Me.TextBox1.TabIndex = 70
        Me.TextBox1.Tag = ".Rate"
        Me.TextBox1.Text = ""
        '
        'IncreaseRate
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(224, 149)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.GroupBox1})
        Me.Name = "IncreaseRate"
        Me.Tag = ""
        Me.Text = "Increase Date & Rate"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ChargeIncrease_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = ROUTESTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        DTPicker1.Format = DateTimePickerFormat.Custom
        DTPicker1.CustomFormat = "MM/dd/yyyy"
        DTPicker1.Value = Date.Today
        rbRate.Checked = True

    End Sub
    'Private Sub LoadData()

    '    Dim dtAdapter As SqlDataAdapter
    '    Dim TempQuery As String

    '    If Not dtSet.Tables Is Nothing Then
    '        dtSet.Tables.Clear()
    '    End If
    '    TempQuery = sqlIncreaseSvc.Replace("@HDate", "'" & .Text & "'")
    '    If AcctID.Text = "" Then
    '        TempQuery = TempQuery.Replace("@AcctID", " >= 0 ")
    '    Else
    '        TempQuery = TempQuery.Replace("@AcctID", " = " & AcctID.Text)
    '    End If

    '    PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(TempQuery, ""))

    '    FillUltraGrid(UltraGrid1, dtSet, 0)
    '    'UGLoadListingLayout(UltraGrid1, TemplateID)
    '    UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
    '    UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
    '    Me.Text = MeText

    'End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If Not IsNumeric(Chr(e.KeyCode)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
