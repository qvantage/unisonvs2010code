Option Explicit On 
Imports System.Data
Imports System.Data.SqlClient

Public Class MassAcctHolidaySetup
    Inherits System.Windows.Forms.Form
    Dim SelectAccts As String = "Select c.ID, c.Name From " & AppTblPath & "Customer c " & _
                                " where c.Status = 1 order by c.ID"

    '" AND ((c.HolidaySvcMj*2 & h.type = 2) or (c.HolidaySvcMn & h.type = 1)) " & _

    Dim MeText As String
    Dim dtSet As New DataSet
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
    Friend WithEvents AccountsTree As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkMnNotice As System.Windows.Forms.CheckBox
    Friend WithEvents chkMjNotice As System.Windows.Forms.CheckBox
    Friend WithEvents chkMnSvc As System.Windows.Forms.CheckBox
    Friend WithEvents chkMjSvc As System.Windows.Forms.CheckBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkMnNotice = New System.Windows.Forms.CheckBox
        Me.chkMjNotice = New System.Windows.Forms.CheckBox
        Me.chkMnSvc = New System.Windows.Forms.CheckBox
        Me.chkMjSvc = New System.Windows.Forms.CheckBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.AccountsTree = New Infragistics.Win.UltraWinTree.UltraTree
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.AccountsTree, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkMnNotice)
        Me.GroupBox1.Controls.Add(Me.chkMjNotice)
        Me.GroupBox1.Controls.Add(Me.chkMnSvc)
        Me.GroupBox1.Controls.Add(Me.chkMjSvc)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkMnNotice
        '
        Me.chkMnNotice.Enabled = False
        Me.chkMnNotice.Location = New System.Drawing.Point(312, 64)
        Me.chkMnNotice.Name = "chkMnNotice"
        Me.chkMnNotice.Size = New System.Drawing.Size(16, 16)
        Me.chkMnNotice.TabIndex = 3
        Me.chkMnNotice.Tag = ".HolidayNoticeMn"
        '
        'chkMjNotice
        '
        Me.chkMjNotice.Enabled = False
        Me.chkMjNotice.Location = New System.Drawing.Point(200, 64)
        Me.chkMjNotice.Name = "chkMjNotice"
        Me.chkMjNotice.Size = New System.Drawing.Size(16, 16)
        Me.chkMjNotice.TabIndex = 1
        Me.chkMjNotice.Tag = ".HolidayNoticeMj"
        '
        'chkMnSvc
        '
        Me.chkMnSvc.Location = New System.Drawing.Point(312, 40)
        Me.chkMnSvc.Name = "chkMnSvc"
        Me.chkMnSvc.Size = New System.Drawing.Size(16, 16)
        Me.chkMnSvc.TabIndex = 2
        Me.chkMnSvc.Tag = ".HolidaySvcMn"
        '
        'chkMjSvc
        '
        Me.chkMjSvc.Location = New System.Drawing.Point(200, 40)
        Me.chkMjSvc.Name = "chkMjSvc"
        Me.chkMjSvc.Size = New System.Drawing.Size(16, 16)
        Me.chkMjSvc.TabIndex = 0
        Me.chkMjSvc.Tag = ".HolidaySvcMj"
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(280, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(80, 16)
        Me.Label37.TabIndex = 25
        Me.Label37.Text = "Minor Holidays"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(168, 16)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(80, 16)
        Me.Label36.TabIndex = 24
        Me.Label36.Text = "Major Holidays"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(77, 64)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(88, 16)
        Me.Label27.TabIndex = 23
        Me.Label27.Text = "Send Notice"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(72, 40)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(96, 16)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Holiday Service"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AccountsTree
        '
        Me.AccountsTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountsTree.Location = New System.Drawing.Point(0, 100)
        Me.AccountsTree.Name = "AccountsTree"
        Me.AccountsTree.Size = New System.Drawing.Size(496, 233)
        Me.AccountsTree.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 333)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 40)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(407, 13)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(8, 14)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 21)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'MassAcctHolidaySetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 373)
        Me.Controls.Add(Me.AccountsTree)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "MassAcctHolidaySetup"
        Me.Tag = "Customer"
        Me.Text = "Mass Account Holiday Setup"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.AccountsTree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MassAcctHolidaySetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = AppTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        PopulateAccountsTree()
        AccountsTree.Override.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Extended
        AccountsTree.HideSelection = False

    End Sub
    'This Sub populates the AccountsTree with nodes representing
    'different tree objects, their Overrides, and Appearances
    Private Sub PopulateAccountsTree()
        'A TreeNode used for temporary storage so we can set 
        'properties of newly-added nodes
        Dim aNode As Infragistics.Win.UltraWinTree.UltraTreeNode
        AccountsTree.Nodes.Clear()
        With AccountsTree
            'Add a node for the Control
            aNode = .Nodes.Add("All")
            aNode.Key = "All"
            aNode.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBoxTriState
            'Add an Override node for the Control node
            AddAccountNodes(aNode)
            'Expand this Control node
            aNode.Expanded = True

        End With
    End Sub

    Private Sub AddAccountNodes(ByVal parentNode As Infragistics.Win.UltraWinTree.UltraTreeNode)
        'A TreeNode used for temporary storage so we can set 
        'properties of newly-added nodes
        Dim aNode As Infragistics.Win.UltraWinTree.UltraTreeNode
        Dim row As DataRow
        LoadData()
        For Each row In dtSet.Tables(0).Rows
            With parentNode
                'Add an Overide node. Since there will be a few of these
                'in the AppearanceTree, we don't want to assign a key. 
                'So we add a blank node and then set it's Text
                aNode = .Nodes.Add()
                aNode.Text = row.Item("ID") & Space(10 - Len(CStr(row.Item("ID")))) & row.Item("Name") & ""
                aNode.Tag = row.Item("Name")
                aNode.Key = row.Item("ID")
                aNode.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox

                'Make the Override node red, just to distinguish it
                'aNode.Override.NodeAppearance.ForeColor = Color.Red
                'aNode.CheckedState = CheckState.Indeterminate

                'aNode.Tag = AppearanceType.NodeAppearance
                'aNode.Override.NodeAppearance.ForeColor = Color.Blue
                'aNode.Override.NodeDoubleClickAction = Infragistics.Win.UltraWinTree.NodeDoubleClickAction.None
                'e.TreeNode.Parent.Parent.Key
            End With
        Next

    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim Pos As Integer
        Dim TempAcctsQry As String

        TempAcctsQry = SelectAccts

        PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(TempAcctsQry, ""))
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub MassAcctHolidaySetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        dtSet.Dispose()
        dtSet = Nothing
    End Sub
    Private Sub AccountsTree_AfterCheck(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles AccountsTree.AfterCheck
        Dim aNode As Infragistics.Win.UltraWinTree.UltraTreeNode
        Dim bNode As Infragistics.Win.UltraWinTree.UltraTreeNode
        Dim chkcnt, uchkcnt As Integer
        Static InProcess As Integer = 0

        If InProcess <> 0 Then Exit Sub
        InProcess += 1
        If e.TreeNode.Key <> "All" Then
            aNode = e.TreeNode.Parent
            For Each bNode In aNode.Nodes
                If bNode.CheckedState = CheckState.Checked Then
                    chkcnt += 1
                Else
                    uchkcnt += 1
                End If
            Next
            If chkcnt = 0 Then
                aNode.CheckedState = CheckState.Unchecked
            ElseIf uchkcnt = 0 Then
                aNode.CheckedState = CheckState.Checked
            Else
                aNode.CheckedState = CheckState.Indeterminate
            End If
        Else
            aNode = e.TreeNode
            Select Case aNode.CheckedState
                Case CheckState.Indeterminate, CheckState.Unchecked
                    For Each bNode In aNode.Nodes
                        bNode.CheckedState = CheckState.Unchecked
                    Next
                    aNode.CheckedState = CheckState.Unchecked
                Case CheckState.Checked
                    For Each bNode In aNode.Nodes
                        bNode.CheckedState = CheckState.Checked
                    Next
            End Select
        End If
        InProcess -= 1
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim aNode As Infragistics.Win.UltraWinTree.UltraTreeNode
        Dim AcctIDList As String = "("
        Dim AcctUnChkList As String = "("
        Dim TagFix As String
        Dim SqteLoc As Integer
        Dim dtAdapter As SqlDataAdapter
        Dim row As System.Data.DataRow


        Me.Cursor = Cursors.WaitCursor

        For Each aNode In AccountsTree.Nodes(0).Nodes
            If aNode.CheckedState = CheckState.Checked Then
                AcctIDList = AcctIDList & aNode.Key & ", "
            End If
        Next aNode
        AcctIDList = AcctIDList.Substring(0, Len(AcctIDList) - Len(", ")) & ")"
        If ExecuteQuery("Update " & Me.Tag & " SET HolidaySvcMj = " & Val(chkMjSvc.Checked) & ", HolidayNoticeMj = " & Val(chkMjNotice.Checked) & ", HolidaySvcMn = " & Val(chkMnSvc.Checked) & ",  HolidayNoticeMn = " & Val(chkMnNotice.Checked) & " where ID in " & AcctIDList) = False Then
            Me.Text = MeText
            'Message modified by Michael Pastor
            MsgBox("Unable to update information.", MsgBoxStyle.Exclamation, "Data Not Saved")
            '- MsgBox("Error Updating Information.")

        Else
            Me.Text = MeText & " - Holiday Settings Updated Succesfully..."
        End If

        Me.Cursor = Cursors.Default
        AccountsTree.Nodes(0).CheckedState = CheckState.Unchecked

    End Sub

    'Private Sub cboHDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHDate.SelectedIndexChanged
    '    AccountsTree.Nodes.Clear()
    'End Sub
    Private Sub chkMjSvc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMjSvc.CheckedChanged
        chkMjNotice.Enabled = chkMjSvc.Checked
        If chkMjSvc.Checked = False Then
            chkMjNotice.Checked = False
        End If
    End Sub

    Private Sub chkMnSvc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMnSvc.CheckedChanged
        chkMnNotice.Enabled = chkMnSvc.Checked
        If chkMnSvc.Checked = False Then
            chkMnNotice.Checked = False
        End If
    End Sub
End Class
