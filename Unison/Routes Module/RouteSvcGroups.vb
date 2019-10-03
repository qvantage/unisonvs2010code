Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class RouteSvcGroups
    Inherits System.Windows.Forms.Form
    Dim sqlAllGroups As String = "Select ID, Name , Comment FROM " & ROUTESTblPath & "ServiceGroups order by Name"
    Dim sqlGroupMembers As String = "Select sgm.AccountID, sgm.SID, sgm.Comment from " & ROUTESTblPath & "ServiceGroupMembers sgm, " & ROUTESTblPath & "AccountServices asv Where sgm.accountid = asv.accountid and sgm.sid = asv.ID and asv.enddate is null and SGroupID = @SGID order by sgm.AccountID, sgm.SID"
    Dim sqlCancelMembers As String = "Select sgm.AccountID, sgm.SID, sgm.Comment FROM " & ROUTESTblPath & "ServiceGroupMembers sgm, " & ROUTESTblPath & "AccountServices asv Where sgm.accountid = asv.accountid and sgm.sid = asv.ID and asv.enddate is not null and SGroupID = @SGID order by sgm.AccountID, sgm.SID"
    Dim sqlGroups As String = "Select sg.ID, sg.Name , sg.Comment FROM " & ROUTESTblPath & "ServiceGroups sg where sg.ID in (Select SGroupID FROM " & ROUTESTblPath & "ServiceGroupMembers sgm Where sgm.AccountID = @AcctID and sgm.SID = @SID)  order by Name"

    Dim HidCols() As String = {"ID"}

    Dim MeText As String
    Dim dtSetAG As New DataSet()
    Dim dtSetAM As New DataSet()
    Dim dtSetMG As New DataSet()
    Dim dtSetMGM As New DataSet()

    Dim dvStates As New DataView()
    Dim cmdTrans As SqlCommand

    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

    Public iAccountID, iSID As Integer

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraGrid3 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGrid4 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents AcctID As System.Windows.Forms.TextBox
    Friend WithEvents SID As System.Windows.Forms.TextBox
    Friend WithEvents Account As System.Windows.Forms.TextBox
    Friend WithEvents btnDelGroup As System.Windows.Forms.Button
    Friend WithEvents btnNewGroup As System.Windows.Forms.Button
    Friend WithEvents btnRemoveMember As System.Windows.Forms.Button
    Friend WithEvents btnAddMember As System.Windows.Forms.Button
    Friend WithEvents Groups As System.Windows.Forms.GroupBox
    Friend WithEvents btnEditGroup As System.Windows.Forms.Button
    Friend WithEvents UltraGrid5 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGrid6 As Infragistics.Win.UltraWinGrid.UltraGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.UltraGrid3 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGrid4 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AcctID = New System.Windows.Forms.TextBox()
        Me.SID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Account = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Groups = New System.Windows.Forms.GroupBox()
        Me.btnEditGroup = New System.Windows.Forms.Button()
        Me.btnDelGroup = New System.Windows.Forms.Button()
        Me.btnNewGroup = New System.Windows.Forms.Button()
        Me.btnRemoveMember = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAddMember = New System.Windows.Forms.Button()
        Me.UltraGrid5 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGrid6 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Groups.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.UltraGrid5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGrid3
        '
        Me.UltraGrid3.Location = New System.Drawing.Point(445, 3)
        Me.UltraGrid3.Name = "UltraGrid3"
        Me.UltraGrid3.Size = New System.Drawing.Size(344, 149)
        Me.UltraGrid3.TabIndex = 2
        Me.UltraGrid3.Text = "Multiple Membership Groups"
        '
        'UltraGrid4
        '
        Me.UltraGrid4.Location = New System.Drawing.Point(445, 152)
        Me.UltraGrid4.Name = "UltraGrid4"
        Me.UltraGrid4.Size = New System.Drawing.Size(344, 192)
        Me.UltraGrid4.TabIndex = 3
        Me.UltraGrid4.Text = "Members"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.AcctID, Me.SID, Me.Label2, Me.Label1, Me.Account, Me.btnExit})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 437)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 48)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'AcctID
        '
        Me.AcctID.Location = New System.Drawing.Point(64, 16)
        Me.AcctID.Name = "AcctID"
        Me.AcctID.ReadOnly = True
        Me.AcctID.Size = New System.Drawing.Size(40, 20)
        Me.AcctID.TabIndex = 11
        Me.AcctID.Text = ""
        '
        'SID
        '
        Me.SID.Location = New System.Drawing.Point(344, 16)
        Me.SID.Name = "SID"
        Me.SID.ReadOnly = True
        Me.SID.Size = New System.Drawing.Size(40, 20)
        Me.SID.TabIndex = 10
        Me.SID.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(312, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "SID :"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Account:"
        '
        'Account
        '
        Me.Account.Location = New System.Drawing.Point(112, 16)
        Me.Account.Name = "Account"
        Me.Account.ReadOnly = True
        Me.Account.Size = New System.Drawing.Size(176, 20)
        Me.Account.TabIndex = 7
        Me.Account.Text = ""
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(713, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 21)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "E&xit"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(334, 152)
        Me.UltraGrid1.TabIndex = 5
        Me.UltraGrid1.Text = "All Groups"
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Location = New System.Drawing.Point(0, 152)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(336, 192)
        Me.UltraGrid2.TabIndex = 6
        Me.UltraGrid2.Text = "Active Members"
        '
        'Groups
        '
        Me.Groups.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEditGroup, Me.btnDelGroup, Me.btnNewGroup})
        Me.Groups.Location = New System.Drawing.Point(337, -2)
        Me.Groups.Name = "Groups"
        Me.Groups.Size = New System.Drawing.Size(104, 154)
        Me.Groups.TabIndex = 7
        Me.Groups.TabStop = False
        Me.Groups.Text = "Groups"
        '
        'btnEditGroup
        '
        Me.btnEditGroup.Location = New System.Drawing.Point(8, 80)
        Me.btnEditGroup.Name = "btnEditGroup"
        Me.btnEditGroup.Size = New System.Drawing.Size(88, 21)
        Me.btnEditGroup.TabIndex = 17
        Me.btnEditGroup.Text = "&Edit Group"
        '
        'btnDelGroup
        '
        Me.btnDelGroup.Location = New System.Drawing.Point(8, 112)
        Me.btnDelGroup.Name = "btnDelGroup"
        Me.btnDelGroup.Size = New System.Drawing.Size(88, 21)
        Me.btnDelGroup.TabIndex = 16
        Me.btnDelGroup.Text = "&Delete Group"
        '
        'btnNewGroup
        '
        Me.btnNewGroup.Location = New System.Drawing.Point(8, 48)
        Me.btnNewGroup.Name = "btnNewGroup"
        Me.btnNewGroup.Size = New System.Drawing.Size(88, 21)
        Me.btnNewGroup.TabIndex = 15
        Me.btnNewGroup.Text = "&New Group"
        '
        'btnRemoveMember
        '
        Me.btnRemoveMember.Location = New System.Drawing.Point(8, 102)
        Me.btnRemoveMember.Name = "btnRemoveMember"
        Me.btnRemoveMember.Size = New System.Drawing.Size(88, 21)
        Me.btnRemoveMember.TabIndex = 15
        Me.btnRemoveMember.Text = "&Remove"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddMember, Me.btnRemoveMember})
        Me.GroupBox3.Location = New System.Drawing.Point(338, 152)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(104, 288)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Group Membeship"
        '
        'btnAddMember
        '
        Me.btnAddMember.Location = New System.Drawing.Point(8, 68)
        Me.btnAddMember.Name = "btnAddMember"
        Me.btnAddMember.Size = New System.Drawing.Size(88, 21)
        Me.btnAddMember.TabIndex = 14
        Me.btnAddMember.Text = "&Add "
        '
        'UltraGrid5
        '
        Me.UltraGrid5.Location = New System.Drawing.Point(0, 344)
        Me.UltraGrid5.Name = "UltraGrid5"
        Me.UltraGrid5.Size = New System.Drawing.Size(336, 96)
        Me.UltraGrid5.TabIndex = 9
        Me.UltraGrid5.Text = "Cancelled Members"
        '
        'UltraGrid6
        '
        Me.UltraGrid6.Location = New System.Drawing.Point(445, 344)
        Me.UltraGrid6.Name = "UltraGrid6"
        Me.UltraGrid6.Size = New System.Drawing.Size(346, 96)
        Me.UltraGrid6.TabIndex = 10
        Me.UltraGrid6.Text = "Cancelled Members"
        '
        'RouteSvcGroups
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 485)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.UltraGrid6, Me.UltraGrid5, Me.GroupBox3, Me.Groups, Me.UltraGrid2, Me.UltraGrid1, Me.GroupBox1, Me.UltraGrid4, Me.UltraGrid3})
        Me.Name = "RouteSvcGroups"
        Me.Text = "Route Service Groups"
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Groups.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.UltraGrid5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub RouteSvcGroups_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = ROUTESTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text
        AcctID.Text = iAccountID
        SID.Text = iSID
        LoadGridData()
        SvcCancelGroupChk()
    End Sub

    Private Sub LoadGridData()

        Dim dtAdapter As SqlDataAdapter
        Dim CritTmp As String

        CritTmp = sqlGroups.Replace("@AcctID", iAccountID)
        CritTmp = CritTmp.Replace("@SID", iSID)

        If PopulateDataset2(dtAdapter, dtSetAG, sqlAllGroups) Is Nothing Then
            Exit Sub
        End If

        If PopulateDataset2(dtAdapter, dtSetMG, CritTmp) Is Nothing Then
            Exit Sub
        End If

        If dtSetAG.Tables(0).Rows.Count = 0 Then
        End If

        UltraGrid2.DataSource = Nothing
        UltraGrid4.DataSource = Nothing
        UltraGrid5.DataSource = Nothing
        UltraGrid6.DataSource = Nothing

        FillUltraGrid(UltraGrid1, dtSetAG, 1, HidCols)
        FillUltraGrid(UltraGrid3, dtSetMG, 1, HidCols)

        'UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        'UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        'With UltraGrid1.DisplayLayout.Override
        '    .RowSpacingAfter = 5
        '    .RowPreviewAppearance.BackColor = System.Drawing.Color.Aqua ' UltraGrid2.DisplayLayout.Override.RowAppearance.BackColor 'SystemColors.Window
        '    .RowPreviewAppearance.ForeColor = SystemColors.WindowText
        'End With
        'UltraGrid1.DisplayLayout.AddNewBox.Hidden = False

    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        Dim dtAdapter As SqlDataAdapter
        Dim CritTmp As String

        CritTmp = sqlGroupMembers.Replace("@SGID", sender.ActiveRow.Cells(0).Value)

        If PopulateDataset2(dtAdapter, dtSetAM, CritTmp) Is Nothing Then
            Exit Sub
        End If

        If dtSetAM.Tables(0).Rows.Count = 0 Then
        End If

        FillUltraGrid(UltraGrid2, dtSetAM, 1, HidCols)

        CritTmp = sqlCancelMembers.Replace("@SGID", sender.ActiveRow.Cells(0).Value)
        dtSetAM.Dispose()

        If PopulateDataset2(dtAdapter, dtSetAM, CritTmp) Is Nothing Then
            Exit Sub
        End If

        If dtSetAM.Tables(0).Rows.Count = 0 Then
        End If

        FillUltraGrid(UltraGrid5, dtSetAM, 1, HidCols)
    End Sub

    Private Sub UltraGrid3_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid3.AfterRowActivate
        Dim dtAdapter As SqlDataAdapter
        Dim CritTmp As String

        CritTmp = sqlGroupMembers.Replace("@SGID", sender.ActiveRow.Cells(0).Value)

        If PopulateDataset2(dtAdapter, dtSetMGM, CritTmp) Is Nothing Then
            Exit Sub
        End If

        If dtSetMGM.Tables(0).Rows.Count = 0 Then
        End If

        FillUltraGrid(UltraGrid4, dtSetMGM, 1, HidCols)


        CritTmp = sqlCancelMembers.Replace("@SGID", sender.ActiveRow.Cells(0).Value)

        dtSetMGM.Dispose()

        If PopulateDataset2(dtAdapter, dtSetMGM, CritTmp) Is Nothing Then
            Exit Sub
        End If

        If dtSetMGM.Tables(0).Rows.Count = 0 Then
        End If

        FillUltraGrid(UltraGrid6, dtSetMGM, 1, HidCols)
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAddMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMember.Click
        Dim x As New EnterTextBox()
        Dim sqlInsMember As String
        Dim dtAdapter As SqlDataAdapter
        Dim dtSetTmp As New DataSet()
        Dim CritTmp As String

        On Error GoTo ErrTrap

        If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "Group :"
        x.Label2.Text = "Comment :"
        x.Text = "Add Membership"
        x.TextBox1.Enabled = False
        x.TextBox1.Text = UltraGrid1.ActiveRow.Cells("Name").Value
        x.TextBox2.Focus()
        x.ShowDialog(Me)
        If x.DialogResult = DialogResult.OK Then

            CritTmp = sqlGroupMembers.Replace("@SGID", UltraGrid1.ActiveRow.Cells(0).Value)

            If PopulateDataset2(dtAdapter, dtSetTmp, PrepSelectQuery(CritTmp, " AND SID = " & iSID)) Is Nothing Then
                Exit Sub
            End If

            If dtSetTmp.Tables(0).Rows.Count > 0 Then
                MsgBox("This Service is already a member of this group.")
                GoTo ErrTrap
            End If
            'Save to DB
            sqlInsMember = "Insert Into " & ROUTESTblPath & "ServiceGroupMembers(AccountID, SID, SGroupID, Comment) " & _
                        " values(" & iAccountID & ", " & iSID & _
                        ", " & UltraGrid1.ActiveRow.Cells(0).Value & ",'" & x.TextBox2.Text & "')"
            If ExecuteQuery(sqlInsMember) = False Then
                MsgBox("Error Saving in Members Table.")
                GoTo ErrTrap
            End If
            LoadGridData()
        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If
        dtSetTmp = Nothing
    End Sub

    Private Sub btnRemoveMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveMember.Click
        Dim sqlDelMember As String
        Dim dtAdapter As SqlDataAdapter
        Dim dtSetTmp As New DataSet()
        Dim CritTmp As String

        On Error GoTo ErrTrap

        If UltraGrid3.ActiveRow Is Nothing Then GoTo ErrTrap

        If MessageBox.Show("Remove SID : " & iSID & " from Group '" & UltraGrid3.ActiveRow.Cells("Name").Value & "' ?", "Delete SID from Group", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            '============================================
            'Do Additional Checks for Hous Account Service
            '============================================
            sqlDelMember = "Delete FROM " & ROUTESTblPath & "ServiceGroupMembers where AccountID = " & iAccountID & " AND SID = " & iSID & " AND SGROUPID = " & UltraGrid3.ActiveRow.Cells("ID").Value
            If ExecuteQuery(sqlDelMember) = False Then
                MsgBox("Error Deleting from Members Table.")
                GoTo ErrTrap
            End If
            LoadGridData()
        End If

        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If
        dtSetTmp = Nothing
    End Sub

    Private Sub btnNewGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGroup.Click
        Dim x As New EnterTextBox()
        Dim sqlCreateGrp As String
        Dim dtAdapter As SqlDataAdapter
        Dim dtSetTmp As New DataSet()
        Dim CritTmp As String

        On Error GoTo ErrTrap

        'If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "Group :"
        x.Label2.Text = "Comment :"
        x.Text = "Create Service Group"
        x.TextBox1.Text = ""
        x.TextBox2.Focus()
        x.ShowDialog(Me)
        If x.DialogResult = DialogResult.OK Then
            If x.TextBox1.Text.Trim = "" Then
                MsgBox("Group name is not specified.")
                GoTo ErrTrap
            End If

            'Save to DB
            sqlCreateGrp = "Insert into " & ROUTESTblPath & "ServiceGroups(Name, Comment) Values('" & x.TextBox1.Text & "', '" & x.TextBox2.Text & "')"

            If ExecuteQuery(sqlCreateGrp) = False Then
                MsgBox("Error Saving in Members Table.")
                GoTo ErrTrap
            End If
            LoadGridData()
        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If
        dtSetTmp = Nothing
    End Sub



    Private Sub btnEditGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditGroup.Click
        Dim x As New EnterTextBox()
        Dim sqlCreateGrp As String
        Dim dtAdapter As SqlDataAdapter
        Dim dtSetTmp As New DataSet()
        Dim CritTmp As String

        On Error GoTo ErrTrap

        If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap


        x.Label1.Text = "Group :"
        x.Label2.Text = "Comment :"
        x.Text = "Edit Service Group"
        x.TextBox1.Text = UltraGrid1.ActiveRow.Cells("Name").Value
        x.TextBox2.Text = UltraGrid1.ActiveRow.Cells("Comment").Value
        x.TextBox1.Focus()
        x.ShowDialog(Me)
        If x.DialogResult = DialogResult.OK Then
            If x.TextBox1.Text.Trim = "" Then
                MsgBox("Group name is not specified.")
                GoTo ErrTrap
            End If

            'Save to DB
            sqlCreateGrp = "Update " & ROUTESTblPath & "ServiceGroups set Name = '" & x.TextBox1.Text & "', Comment = '" & x.TextBox2.Text & "' Where ID = " & UltraGrid1.ActiveRow.Cells("ID").Value

            If ExecuteQuery(sqlCreateGrp) = False Then
                MsgBox("Error Saving in Members Table.")
                GoTo ErrTrap
            End If
            LoadGridData()
        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If
        dtSetTmp = Nothing
    End Sub




    Private Sub btnDelGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelGroup.Click
        Dim sqlDelGroup As String
        Dim dtAdapter As SqlDataAdapter
        Dim dtSetTmp As New DataSet()
        Dim CritTmp As String

        On Error GoTo ErrTrap

        If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        CritTmp = sqlGroupMembers.Replace("@SGID", UltraGrid1.ActiveRow.Cells(0).Value)

        If Not PopulateDataset2(dtAdapter, dtSetTmp, CritTmp) Is Nothing Then
            If dtSetTmp.Tables(0).Rows.Count > 0 Then
                MsgBox("This group has members. Please remove services first.")
                GoTo ErrTrap
            End If
        Else
            'Exit Sub
        End If


        If MessageBox.Show("Remove Group '" & UltraGrid1.ActiveRow.Cells("Name").Value & "' ?", "Delete Group?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            '============================================
            'Do Additional Checks for Hous Account Service
            '============================================
            sqlDelGroup = "Delete FROM " & ROUTESTblPath & "ServiceGroups where ID = " & UltraGrid1.ActiveRow.Cells("ID").Value
            If ExecuteQuery(sqlDelGroup) = False Then
                MsgBox("Error Deleting from Members Table.")
                GoTo ErrTrap
            End If
            LoadGridData()
        End If

        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If
        dtSetTmp = Nothing
    End Sub

    Private Sub SvcCancelGroupChk()

        'Check to See if Account is Non revenue account then delete it from groups
        Dim DelSID2 As String = "DELETE " & ROUTESTblPath & "ServiceGroupMembers FROM " & AppTblPath & "Customer c, " & _
                ROUTESTblPath & "AccountServices a WHERE c.NRVNU = 1 AND " & ROUTESTblPath & "ServiceGroupMembers.AccountID = c.ID AND " & ROUTESTblPath & "ServiceGroupMembers.SID = a.ID AND a.EndDate IS NOT NULL AND a.EndDate < getdate()"
        If ExecuteQuery(DelSID2) = False Then
            MsgBox("Error Deleting from Members Table.")
        End If

    End Sub

End Class
