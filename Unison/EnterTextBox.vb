Imports System.Data
Imports System.Data.SqlClient

Public Class EnterTextBox
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnBrowse2 As System.Windows.Forms.Button
    Friend WithEvents btnBrowse1 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EnterTextBox))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBrowse1 = New System.Windows.Forms.Button
        Me.btnBrowse2 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBrowse1)
        Me.GroupBox1.Controls.Add(Me.btnBrowse2)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(398, 88)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnBrowse1
        '
        Me.btnBrowse1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBrowse1.Image = CType(resources.GetObject("btnBrowse1.Image"), System.Drawing.Image)
        Me.btnBrowse1.Location = New System.Drawing.Point(272, 24)
        Me.btnBrowse1.Name = "btnBrowse1"
        Me.btnBrowse1.Size = New System.Drawing.Size(40, 21)
        Me.btnBrowse1.TabIndex = 1
        Me.btnBrowse1.Visible = False
        '
        'btnBrowse2
        '
        Me.btnBrowse2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBrowse2.Image = CType(resources.GetObject("btnBrowse2.Image"), System.Drawing.Image)
        Me.btnBrowse2.Location = New System.Drawing.Point(344, 56)
        Me.btnBrowse2.Name = "btnBrowse2"
        Me.btnBrowse2.Size = New System.Drawing.Size(40, 21)
        Me.btnBrowse2.TabIndex = 3
        Me.btnBrowse2.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(72, 56)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(256, 20)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(72, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(192, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(398, 40)
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
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(315, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 21)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        '
        'EnterTextBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(398, 123)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "EnterTextBox"
        Me.Text = "EnterTextBox"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Abort
        Me.Dispose()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnBrowse1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse1.Click
        If TextBox1.Text = "" Then
            'FolderBrowserDialog1.SelectedPath = "C :\"
        Else
            'FolderBrowserDialog1.SelectedPath = TextBox1.Text
        End If
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.DefaultExt = "XLS"
        SaveFileDialog1.Filter = "Excel | xls"
        'If FolderBrowserDialog1.ShowDialog(Me) = DialogResult.OK Then
        If SaveFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            TextBox1.Text = SaveFileDialog1.FileName
        End If

    End Sub

    Private Sub EnterTextBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToParent()
    End Sub

    Private Sub EnterTextBox_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.DialogResult = DialogResult.Abort Then
            Me.DialogResult = DialogResult.Cancel
        ElseIf Me.DialogResult = DialogResult.OK Then
        Else
            e.Cancel = True
        End If
    End Sub
End Class
