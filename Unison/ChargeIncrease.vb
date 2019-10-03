Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class ChargeIncrease
    Inherits System.Windows.Forms.Form
    Dim sqlIncreaseSvc As String = " Select isv.IncDate as [Date], isv.AccountID, isv.SID, isv.Applied" & _
                              " , asv.Charge, isv.FinalAmount " & _
                              " From IncreasesService isv, AccountServices asv"

    Dim sqlIncreaseAcc As String = " Select isv.IncDate as [Date], isv.AccountID, isv.SID, isv.Applied" & _
                              " , asv.Charge, isv.FinalAmount " & _
                              " From IncreasesService isv, AccountServices asv"
    Dim MeText As String
    Dim dtSet As New DataSet()
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As RoutesModule.MyTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboHDate As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.TextBox1 = New RoutesModule.MyTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboHDate = New System.Windows.Forms.ComboBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrint, Me.btnExit, Me.btnSave})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 381)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(672, 40)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrint.Location = New System.Drawing.Point(78, 16)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 21)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(594, 16)
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
        Me.btnSave.Text = "&Save"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioButton2, Me.RadioButton1, Me.cboHDate, Me.Label1, Me.TextBox1, Me.btnLoad})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(672, 58)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(470, 22)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(104, 21)
        Me.btnLoad.TabIndex = 68
        Me.btnLoad.Text = "&Preview Increase"
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(378, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(64, 20)
        Me.TextBox1.TabIndex = 70
        Me.TextBox1.Tag = ".Rate"
        Me.TextBox1.Text = ""
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
        'cboHDate
        '
        Me.cboHDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDate.Location = New System.Drawing.Point(51, 20)
        Me.cboHDate.Name = "cboHDate"
        Me.cboHDate.Size = New System.Drawing.Size(117, 21)
        Me.cboHDate.TabIndex = 73
        Me.cboHDate.Tag = ".HDate...Holidays.ID.Convert(Varchar,HDate,101)..HDate"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(210, 23)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(72, 16)
        Me.RadioButton1.TabIndex = 74
        Me.RadioButton1.Text = "Rate (%)"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(290, 23)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(80, 16)
        Me.RadioButton2.TabIndex = 75
        Me.RadioButton2.Text = "Amount ($)"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 58)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(672, 323)
        Me.UltraGrid1.TabIndex = 6
        Me.UltraGrid1.Text = "Accounts & Services"
        '
        'ChargeIncrease
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(672, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.UltraGrid1, Me.GroupBox2, Me.GroupBox1})
        Me.Name = "ChargeIncrease"
        Me.Tag = "IncreasesService"
        Me.Text = "Serivice Charge Increase"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
