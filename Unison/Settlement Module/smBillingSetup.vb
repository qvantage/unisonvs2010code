Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class smBillingSetup
    Inherits System.Windows.Forms.Form
    'Dim SQLSelect As String = "Select [Starting Invoice No], [Next Invoice No] from " & smBILLTblPath
    Dim SQLSelect As String = "Select [Starting Invoice No], [Next Invoice No] from "
    Dim MeText As String
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents utStartNo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents utNextNo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.utNextNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.utStartNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utNextNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utStartNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 40)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(274, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(61, 21)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(64, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(61, 21)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.utNextNo)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.utStartNo)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 61)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(192, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Next Invoice#:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utNextNo
        '
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utNextNo.Appearance = Appearance1
        Me.utNextNo.Enabled = False
        Me.utNextNo.Location = New System.Drawing.Point(280, 21)
        Me.utNextNo.Name = "utNextNo"
        Me.utNextNo.Size = New System.Drawing.Size(54, 21)
        Me.utNextNo.TabIndex = 10
        Me.utNextNo.Tag = ".[Next Invoice No].view"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Starting Inv.#:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utStartNo
        '
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.utStartNo.Appearance = Appearance2
        Me.utStartNo.Location = New System.Drawing.Point(98, 20)
        Me.utStartNo.Name = "utStartNo"
        Me.utStartNo.Size = New System.Drawing.Size(54, 21)
        Me.utStartNo.TabIndex = 3
        Me.utStartNo.Tag = ".[Starting Invoice No]"
        '
        'smBillingSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 101)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "smBillingSetup"
        Me.Tag = "BillingSetup"
        Me.Text = "Settlement Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utNextNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utStartNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub smBillingSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = smBILLTblPath & Me.Tag
            End If
        End If

        SQLSelect = SQLSelect & Me.Tag & ""
        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, smBILLDBName, smBILLDBUser, smBILLDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        MinWinSize.Width = btnExit.Left + btnExit.Width + 50

        Me.MinimumSize = MinWinSize

        Group_EnDis(False)
        LoadData()

    End Sub

    Private Sub Group_EnDis(ByVal status As Boolean)
        btnSave.Enabled = status
        utStartNo.Enabled = status
        btnEdit.Text = IIf(status, "&Cancel", "&Edit")
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim ID As Integer
        If utStartNo.Text.Trim = "" Then
            MsgBox("Starting Inv# is empty.")
            Exit Sub
        End If
        If Val(utStartNo.Text.Trim) <= 0 Then
            'Message modified by Michael Pastor
            MsgBox("Please input valid Starting Inv#.", MsgBoxStyle.Exclamation, "Missing Data Input")
            Exit Sub
        End If
        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, "") Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            btnEdit.Text = "&Edit"
            Me.Text = MeText & " -- Record Updated."
            Group_EnDis(False)
        End If

    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records
        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLSelect, ""), EditAction.START, cmdTrans) Then
                Group_EnDis(True)
                sender.text = "&Cancel"
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                LoadData()
                sender.text = "&Edit" 'Karina - Changed place with Group_EnDis()
                Group_EnDis(False)
            End If
        End If
    End Sub
    'Karina commented and added smBillingSetup_Closing()
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
        '        Group_EnDis(False)
        '        sender.text = "&Edit"
        '    Else
        '        'Exit Sub
        '    End If

        'End If
        Me.Close()

    End Sub
    Private Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles utStartNo.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView
        Dim dtSet2 As New DataSet
        Dim CritTmp As String


        PopulateDataset2(dtAdapter, dtSet2, SQLSelect)
        If dtSet2 Is Nothing Then GoTo Release
        If dtSet2.Tables Is Nothing Then GoTo Release
        If dtSet2.Tables(0) Is Nothing Then GoTo Release

        If dtSet2.Tables(0).Rows.Count = 0 Then
            'Message modified by Michael Pastor
            MsgBox("No Records found.", MsgBoxStyle.Exclamation, "Data Unavailable")
        Else
            Group_EnDis(False)
            btnSave.Text = "&Save"
            btnEdit.Text = "&Edit"

            dvAcct.Table = dtSet2.Tables(0)
            FormLoad(Me, dvAcct)
        End If

Release:
        If Not dtSet2 Is Nothing Then
            dtSet2.Dispose()
            dtSet2.Dispose()
        End If
        If Not dtAdapter Is Nothing Then
            dtAdapter.Dispose()
            dtAdapter = Nothing
        End If

    End Sub

    Private Sub smBillingSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If btnEdit.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            If MessageBox.Show("Data is not saved! Are you sure you want to exit?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                'If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                sender.text = "&Edit" 'Karina changed place with Group_EnDis()
                Group_EnDis(False)

            Else
                'Exit Sub
            End If

        End If
    End Sub
End Class
