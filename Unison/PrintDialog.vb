Public Class PrintDialog
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbFrom As System.Windows.Forms.RadioButton
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents tbTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Copies As System.Windows.Forms.TextBox
    Friend WithEvents cbCollate As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents tbFrom As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbCollate = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Copies = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTo = New System.Windows.Forms.TextBox()
        Me.tbFrom = New System.Windows.Forms.TextBox()
        Me.rbFrom = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSave, Me.btnExit})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(432, 40)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 21)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "&OK"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(349, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 21)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "&Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox4, Me.GroupBox3})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 109)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbCollate, Me.Label2, Me.Copies})
        Me.GroupBox4.Location = New System.Drawing.Point(261, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(163, 88)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Print Count"
        '
        'cbCollate
        '
        Me.cbCollate.Location = New System.Drawing.Point(8, 48)
        Me.cbCollate.Name = "cbCollate"
        Me.cbCollate.Size = New System.Drawing.Size(64, 24)
        Me.cbCollate.TabIndex = 7
        Me.cbCollate.Text = "Collate"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Number of Copies :"
        '
        'Copies
        '
        Me.Copies.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Copies.Location = New System.Drawing.Point(118, 22)
        Me.Copies.MaxLength = 3
        Me.Copies.Name = "Copies"
        Me.Copies.Size = New System.Drawing.Size(32, 20)
        Me.Copies.TabIndex = 5
        Me.Copies.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.tbTo, Me.tbFrom, Me.rbFrom, Me.rbAll})
        Me.GroupBox3.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(248, 88)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Print Range"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(121, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "To"
        '
        'tbTo
        '
        Me.tbTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbTo.Location = New System.Drawing.Point(144, 47)
        Me.tbTo.MaxLength = 3
        Me.tbTo.Name = "tbTo"
        Me.tbTo.Size = New System.Drawing.Size(32, 20)
        Me.tbTo.TabIndex = 3
        Me.tbTo.Text = ""
        '
        'tbFrom
        '
        Me.tbFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbFrom.Location = New System.Drawing.Point(88, 46)
        Me.tbFrom.MaxLength = 3
        Me.tbFrom.Name = "tbFrom"
        Me.tbFrom.Size = New System.Drawing.Size(32, 20)
        Me.tbFrom.TabIndex = 2
        Me.tbFrom.Text = ""
        '
        'rbFrom
        '
        Me.rbFrom.Location = New System.Drawing.Point(16, 48)
        Me.rbFrom.Name = "rbFrom"
        Me.rbFrom.Size = New System.Drawing.Size(80, 16)
        Me.rbFrom.TabIndex = 1
        Me.rbFrom.Text = "Print From"
        '
        'rbAll
        '
        Me.rbAll.Location = New System.Drawing.Point(16, 24)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(64, 16)
        Me.rbAll.TabIndex = 0
        Me.rbAll.Text = "Print All"
        '
        'PrintDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 149)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.GroupBox2})
        Me.Name = "PrintDialog"
        Me.Text = "Print Dialog"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim MeText As String

    Private Sub PrintDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text
        rbAll.Checked = True
        Copies.Text = "1"


    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.CheckedChanged, rbFrom.CheckedChanged
        If sender.Name = "rbAll" Then
            tbFrom.Enabled = False
            tbTo.Enabled = False
        Else
            tbFrom.Enabled = True
            tbTo.Enabled = True
        End If
    End Sub

    Private Sub Value_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbFrom.KeyPress, tbTo.KeyPress, Copies.KeyPress
        If IsNumeric(e.KeyChar) = False And (e.KeyChar <> ".") And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub

End Class
