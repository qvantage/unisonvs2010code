Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class GroupsSetup
    Inherits System.Windows.Forms.Form
    Dim MeText, SQLSelect As String
    Dim HidColsG() As String = {""}
    Dim HidColsC() As String = {""}
    Dim HidColsM() As String = {"RowID"}
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim m_oGrid As Infragistics.Win.UltraWinGrid.UltraGrid = Nothing
    Dim m_oSelectedGrpID, m_oSelectedGrp, m_oSelectedClubID, m_oSelectedClub As String
    Dim m_oRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

    Dim cmdTrans As SqlCommand

    Dim Frames(3)() As Object
    Dim UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid

    Dim GSQLSelect As String = "Select GroupID, Group_Name, Group_Comment " & _
                    " From " & AppTblPath & "Groups " & _
                    " Order By GroupID "
    Dim CSQLSelect As String = "Select GroupID, ClubID, Club_Name, Club_Comment " & _
                    " From " & AppTblPath & "GroupClubs " & _
                    " Order By GroupID "
    Dim MSQLSelect As String = "Select RowID, GroupID, ClubID, MemberID, Member_Name, MemberType " & _
                    " From " & AppTblPath & "GroupClubMembers " & _
                    " Order By GroupID "
    ' View For Tracking incorporating club in club membership:
    'SELECT     *
    'FROM         GROUPCLUBMEMBERS
    'WHERE     groupid = 'Z' AND membertype = 'A'
    'UNION
    'SELECT     gcm2.*
    'FROM         GROUPCLUBMEMBERS gcm1, GROUPCLUBMEMBERS gcm2
    'WHERE     gcm1.groupid = 'Z' AND gcm1.membertype = 'C' AND gcm2.clubid = gcm1.memberid

    Private Enum enFrm

        _0SQL
        _1Grp
        _2UGd
        _3UTx
        _4BSv
        _5BNw
        _6BEd
        _7BDl
        _8HCl
    End Enum

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents utClub As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents utClubComments As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid3 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents utGroupComments As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnGDelete As System.Windows.Forms.Button
    Friend WithEvents btnGNew As System.Windows.Forms.Button
    Friend WithEvents btnGSave As System.Windows.Forms.Button
    Friend WithEvents btnGEdit As System.Windows.Forms.Button
    Friend WithEvents btnCSave As System.Windows.Forms.Button
    Friend WithEvents utGroupID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utGroup As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents CGroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CGroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CGroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GGroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GGroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MGroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MGroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents MGroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents utMemberID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utMember As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnMember As System.Windows.Forms.Button
    Friend WithEvents utClubID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnCDelete As System.Windows.Forms.Button
    Friend WithEvents btnCNew As System.Windows.Forms.Button
    Friend WithEvents btnCEdit As System.Windows.Forms.Button
    Friend WithEvents btnMDelete As System.Windows.Forms.Button
    Friend WithEvents btnMNew As System.Windows.Forms.Button
    Friend WithEvents btnMSave As System.Windows.Forms.Button
    Friend WithEvents btnMEdit As System.Windows.Forms.Button
    Friend WithEvents utCGroupID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utMGroupID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utMClubID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GGroupBox1 = New System.Windows.Forms.GroupBox
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnGDelete = New System.Windows.Forms.Button
        Me.btnGNew = New System.Windows.Forms.Button
        Me.btnGSave = New System.Windows.Forms.Button
        Me.btnGEdit = New System.Windows.Forms.Button
        Me.GGroupBox2 = New System.Windows.Forms.GroupBox
        Me.utGroupComments = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.utGroupID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utGroup = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CGroupBox1 = New System.Windows.Forms.GroupBox
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CGroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnCDelete = New System.Windows.Forms.Button
        Me.btnCNew = New System.Windows.Forms.Button
        Me.btnCSave = New System.Windows.Forms.Button
        Me.btnCEdit = New System.Windows.Forms.Button
        Me.CGroupBox2 = New System.Windows.Forms.GroupBox
        Me.utCGroupID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utClubID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utClubComments = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.utClub = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.MGroupBox1 = New System.Windows.Forms.GroupBox
        Me.UltraGrid3 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.MGroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnMDelete = New System.Windows.Forms.Button
        Me.btnMNew = New System.Windows.Forms.Button
        Me.btnMSave = New System.Windows.Forms.Button
        Me.btnMEdit = New System.Windows.Forms.Button
        Me.MGroupBox2 = New System.Windows.Forms.GroupBox
        Me.utMClubID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utMGroupID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.utMemberID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utMember = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnMember = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.GGroupBox1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GGroupBox2.SuspendLayout()
        CType(Me.utGroupComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utGroupID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CGroupBox1.SuspendLayout()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CGroupBox3.SuspendLayout()
        Me.CGroupBox2.SuspendLayout()
        CType(Me.utCGroupID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utClubID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utClubComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utClub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MGroupBox1.SuspendLayout()
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MGroupBox3.SuspendLayout()
        Me.MGroupBox2.SuspendLayout()
        CType(Me.utMClubID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMGroupID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMemberID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMember, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GGroupBox1
        '
        Me.GGroupBox1.Controls.Add(Me.UltraGrid1)
        Me.GGroupBox1.Controls.Add(Me.GroupBox3)
        Me.GGroupBox1.Controls.Add(Me.GGroupBox2)
        Me.GGroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GGroupBox1.Name = "GGroupBox1"
        Me.GGroupBox1.Size = New System.Drawing.Size(280, 477)
        Me.GGroupBox1.TabIndex = 0
        Me.GGroupBox1.TabStop = False
        Me.GGroupBox1.Tag = "GROUPS"
        Me.GGroupBox1.Text = "Groups"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(3, 120)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(274, 314)
        Me.UltraGrid1.TabIndex = 21
        Me.UltraGrid1.Text = "Groups"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnGDelete)
        Me.GroupBox3.Controls.Add(Me.btnGNew)
        Me.GroupBox3.Controls.Add(Me.btnGSave)
        Me.GroupBox3.Controls.Add(Me.btnGEdit)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(3, 434)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(274, 40)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        '
        'btnGDelete
        '
        Me.btnGDelete.Location = New System.Drawing.Point(186, 16)
        Me.btnGDelete.Name = "btnGDelete"
        Me.btnGDelete.Size = New System.Drawing.Size(60, 21)
        Me.btnGDelete.TabIndex = 3
        Me.btnGDelete.Text = "&Delete"
        '
        'btnGNew
        '
        Me.btnGNew.Location = New System.Drawing.Point(126, 16)
        Me.btnGNew.Name = "btnGNew"
        Me.btnGNew.Size = New System.Drawing.Size(60, 21)
        Me.btnGNew.TabIndex = 2
        Me.btnGNew.Text = "&New"
        '
        'btnGSave
        '
        Me.btnGSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnGSave.Location = New System.Drawing.Point(3, 16)
        Me.btnGSave.Name = "btnGSave"
        Me.btnGSave.Size = New System.Drawing.Size(60, 21)
        Me.btnGSave.TabIndex = 0
        Me.btnGSave.Text = "&Save"
        '
        'btnGEdit
        '
        Me.btnGEdit.Location = New System.Drawing.Point(65, 16)
        Me.btnGEdit.Name = "btnGEdit"
        Me.btnGEdit.Size = New System.Drawing.Size(60, 21)
        Me.btnGEdit.TabIndex = 1
        Me.btnGEdit.Text = "&Edit"
        '
        'GGroupBox2
        '
        Me.GGroupBox2.Controls.Add(Me.utGroupComments)
        Me.GGroupBox2.Controls.Add(Me.Label6)
        Me.GGroupBox2.Controls.Add(Me.utGroupID)
        Me.GGroupBox2.Controls.Add(Me.utGroup)
        Me.GGroupBox2.Controls.Add(Me.Label1)
        Me.GGroupBox2.Controls.Add(Me.Label2)
        Me.GGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GGroupBox2.Location = New System.Drawing.Point(3, 16)
        Me.GGroupBox2.Name = "GGroupBox2"
        Me.GGroupBox2.Size = New System.Drawing.Size(274, 104)
        Me.GGroupBox2.TabIndex = 23
        Me.GGroupBox2.TabStop = False
        Me.GGroupBox2.Tag = "GROUPS"
        '
        'utGroupComments
        '
        Me.utGroupComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utGroupComments.Location = New System.Drawing.Point(80, 64)
        Me.utGroupComments.Multiline = True
        Me.utGroupComments.Name = "utGroupComments"
        Me.utGroupComments.Size = New System.Drawing.Size(184, 32)
        Me.utGroupComments.TabIndex = 154
        Me.utGroupComments.Tag = "Groups.GROUP_COMMENT"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 153
        Me.Label6.Text = "Comments:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utGroupID
        '
        Me.utGroupID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utGroupID.Location = New System.Drawing.Point(81, 40)
        Me.utGroupID.MaxLength = 4
        Me.utGroupID.Name = "utGroupID"
        Me.utGroupID.Size = New System.Drawing.Size(72, 21)
        Me.utGroupID.TabIndex = 148
        Me.utGroupID.Tag = "Groups.GROUPID"
        '
        'utGroup
        '
        Me.utGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utGroup.Location = New System.Drawing.Point(81, 16)
        Me.utGroup.MaxLength = 50
        Me.utGroup.Name = "utGroup"
        Me.utGroup.Size = New System.Drawing.Size(183, 21)
        Me.utGroup.TabIndex = 147
        Me.utGroup.Tag = "Groups.GROUP_NAME"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Group :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Group ID :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CGroupBox1
        '
        Me.CGroupBox1.Controls.Add(Me.UltraGrid2)
        Me.CGroupBox1.Controls.Add(Me.CGroupBox3)
        Me.CGroupBox1.Controls.Add(Me.CGroupBox2)
        Me.CGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CGroupBox1.Location = New System.Drawing.Point(280, 0)
        Me.CGroupBox1.Name = "CGroupBox1"
        Me.CGroupBox1.Size = New System.Drawing.Size(312, 477)
        Me.CGroupBox1.TabIndex = 1
        Me.CGroupBox1.TabStop = False
        Me.CGroupBox1.Tag = "GROUPCLUBS"
        Me.CGroupBox1.Text = "Group Clubs"
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid2.Location = New System.Drawing.Point(3, 120)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(306, 314)
        Me.UltraGrid2.TabIndex = 21
        Me.UltraGrid2.Text = "Group Clubs"
        '
        'CGroupBox3
        '
        Me.CGroupBox3.Controls.Add(Me.btnCDelete)
        Me.CGroupBox3.Controls.Add(Me.btnCNew)
        Me.CGroupBox3.Controls.Add(Me.btnCSave)
        Me.CGroupBox3.Controls.Add(Me.btnCEdit)
        Me.CGroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CGroupBox3.Location = New System.Drawing.Point(3, 434)
        Me.CGroupBox3.Name = "CGroupBox3"
        Me.CGroupBox3.Size = New System.Drawing.Size(306, 40)
        Me.CGroupBox3.TabIndex = 24
        Me.CGroupBox3.TabStop = False
        '
        'btnCDelete
        '
        Me.btnCDelete.Location = New System.Drawing.Point(230, 16)
        Me.btnCDelete.Name = "btnCDelete"
        Me.btnCDelete.Size = New System.Drawing.Size(75, 21)
        Me.btnCDelete.TabIndex = 3
        Me.btnCDelete.Text = "&Delete"
        '
        'btnCNew
        '
        Me.btnCNew.Location = New System.Drawing.Point(155, 16)
        Me.btnCNew.Name = "btnCNew"
        Me.btnCNew.Size = New System.Drawing.Size(75, 21)
        Me.btnCNew.TabIndex = 2
        Me.btnCNew.Text = "&New"
        '
        'btnCSave
        '
        Me.btnCSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCSave.Location = New System.Drawing.Point(3, 16)
        Me.btnCSave.Name = "btnCSave"
        Me.btnCSave.Size = New System.Drawing.Size(75, 21)
        Me.btnCSave.TabIndex = 0
        Me.btnCSave.Text = "&Save"
        '
        'btnCEdit
        '
        Me.btnCEdit.Location = New System.Drawing.Point(79, 16)
        Me.btnCEdit.Name = "btnCEdit"
        Me.btnCEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnCEdit.TabIndex = 1
        Me.btnCEdit.Text = "&Edit"
        '
        'CGroupBox2
        '
        Me.CGroupBox2.Controls.Add(Me.utCGroupID)
        Me.CGroupBox2.Controls.Add(Me.utClubID)
        Me.CGroupBox2.Controls.Add(Me.utClubComments)
        Me.CGroupBox2.Controls.Add(Me.Label7)
        Me.CGroupBox2.Controls.Add(Me.utClub)
        Me.CGroupBox2.Controls.Add(Me.Label5)
        Me.CGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.CGroupBox2.Location = New System.Drawing.Point(3, 16)
        Me.CGroupBox2.Name = "CGroupBox2"
        Me.CGroupBox2.Size = New System.Drawing.Size(306, 104)
        Me.CGroupBox2.TabIndex = 23
        Me.CGroupBox2.TabStop = False
        Me.CGroupBox2.Tag = "GROUPCLUBS"
        '
        'utCGroupID
        '
        Me.utCGroupID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utCGroupID.Location = New System.Drawing.Point(40, 72)
        Me.utCGroupID.Name = "utCGroupID"
        Me.utCGroupID.Size = New System.Drawing.Size(16, 21)
        Me.utCGroupID.TabIndex = 154
        Me.utCGroupID.Tag = "GroupClubs.GroupID..1"
        Me.utCGroupID.Visible = False
        '
        'utClubID
        '
        Me.utClubID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utClubID.Location = New System.Drawing.Point(16, 56)
        Me.utClubID.Name = "utClubID"
        Me.utClubID.Size = New System.Drawing.Size(16, 21)
        Me.utClubID.TabIndex = 153
        Me.utClubID.Tag = "GroupClubs.ClubID.view"
        Me.utClubID.Visible = False
        '
        'utClubComments
        '
        Me.utClubComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utClubComments.Location = New System.Drawing.Point(69, 41)
        Me.utClubComments.Multiline = True
        Me.utClubComments.Name = "utClubComments"
        Me.utClubComments.Size = New System.Drawing.Size(216, 55)
        Me.utClubComments.TabIndex = 152
        Me.utClubComments.Tag = "GroupClubs.Club_Comment"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(5, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 151
        Me.Label7.Text = "Comments:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utClub
        '
        Me.utClub.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utClub.Location = New System.Drawing.Point(68, 11)
        Me.utClub.Name = "utClub"
        Me.utClub.Size = New System.Drawing.Size(216, 21)
        Me.utClub.TabIndex = 149
        Me.utClub.Tag = "GroupClubs.Club_Name"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(21, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "Club:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MGroupBox1
        '
        Me.MGroupBox1.Controls.Add(Me.UltraGrid3)
        Me.MGroupBox1.Controls.Add(Me.MGroupBox3)
        Me.MGroupBox1.Controls.Add(Me.MGroupBox2)
        Me.MGroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.MGroupBox1.Location = New System.Drawing.Point(592, 0)
        Me.MGroupBox1.Name = "MGroupBox1"
        Me.MGroupBox1.Size = New System.Drawing.Size(312, 477)
        Me.MGroupBox1.TabIndex = 2
        Me.MGroupBox1.TabStop = False
        Me.MGroupBox1.Tag = "GROUPCLUBMEMBERS"
        Me.MGroupBox1.Text = "Club Members"
        '
        'UltraGrid3
        '
        Me.UltraGrid3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid3.Location = New System.Drawing.Point(3, 120)
        Me.UltraGrid3.Name = "UltraGrid3"
        Me.UltraGrid3.Size = New System.Drawing.Size(306, 314)
        Me.UltraGrid3.TabIndex = 21
        Me.UltraGrid3.Text = "Club Members"
        '
        'MGroupBox3
        '
        Me.MGroupBox3.Controls.Add(Me.btnMDelete)
        Me.MGroupBox3.Controls.Add(Me.btnMNew)
        Me.MGroupBox3.Controls.Add(Me.btnMSave)
        Me.MGroupBox3.Controls.Add(Me.btnMEdit)
        Me.MGroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MGroupBox3.Location = New System.Drawing.Point(3, 434)
        Me.MGroupBox3.Name = "MGroupBox3"
        Me.MGroupBox3.Size = New System.Drawing.Size(306, 40)
        Me.MGroupBox3.TabIndex = 24
        Me.MGroupBox3.TabStop = False
        '
        'btnMDelete
        '
        Me.btnMDelete.Location = New System.Drawing.Point(230, 16)
        Me.btnMDelete.Name = "btnMDelete"
        Me.btnMDelete.Size = New System.Drawing.Size(75, 21)
        Me.btnMDelete.TabIndex = 3
        Me.btnMDelete.Text = "&Delete"
        '
        'btnMNew
        '
        Me.btnMNew.Location = New System.Drawing.Point(155, 16)
        Me.btnMNew.Name = "btnMNew"
        Me.btnMNew.Size = New System.Drawing.Size(75, 21)
        Me.btnMNew.TabIndex = 2
        Me.btnMNew.Text = "&New"
        '
        'btnMSave
        '
        Me.btnMSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnMSave.Location = New System.Drawing.Point(3, 16)
        Me.btnMSave.Name = "btnMSave"
        Me.btnMSave.Size = New System.Drawing.Size(75, 21)
        Me.btnMSave.TabIndex = 0
        Me.btnMSave.Text = "&Save"
        '
        'btnMEdit
        '
        Me.btnMEdit.Location = New System.Drawing.Point(79, 16)
        Me.btnMEdit.Name = "btnMEdit"
        Me.btnMEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnMEdit.TabIndex = 1
        Me.btnMEdit.Text = "&Edit"
        '
        'MGroupBox2
        '
        Me.MGroupBox2.Controls.Add(Me.utMClubID)
        Me.MGroupBox2.Controls.Add(Me.utMGroupID)
        Me.MGroupBox2.Controls.Add(Me.Label3)
        Me.MGroupBox2.Controls.Add(Me.utMemberID)
        Me.MGroupBox2.Controls.Add(Me.utMember)
        Me.MGroupBox2.Controls.Add(Me.btnMember)
        Me.MGroupBox2.Controls.Add(Me.Label4)
        Me.MGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.MGroupBox2.Location = New System.Drawing.Point(3, 16)
        Me.MGroupBox2.Name = "MGroupBox2"
        Me.MGroupBox2.Size = New System.Drawing.Size(306, 104)
        Me.MGroupBox2.TabIndex = 23
        Me.MGroupBox2.TabStop = False
        Me.MGroupBox2.Tag = "GROUPCLUBMEMBERS"
        '
        'utMClubID
        '
        Me.utMClubID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMClubID.Location = New System.Drawing.Point(104, 72)
        Me.utMClubID.Name = "utMClubID"
        Me.utMClubID.Size = New System.Drawing.Size(16, 21)
        Me.utMClubID.TabIndex = 156
        Me.utMClubID.Tag = "GroupClubMembers.ClubID..1"
        Me.utMClubID.Visible = False
        '
        'utMGroupID
        '
        Me.utMGroupID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMGroupID.Location = New System.Drawing.Point(48, 72)
        Me.utMGroupID.Name = "utMGroupID"
        Me.utMGroupID.Size = New System.Drawing.Size(16, 21)
        Me.utMGroupID.TabIndex = 155
        Me.utMGroupID.Tag = "GroupClubMembers.GroupID..1"
        Me.utMGroupID.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 23)
        Me.Label3.TabIndex = 151
        Me.Label3.Text = "Acct.ID:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMemberID
        '
        Me.utMemberID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMemberID.Enabled = False
        Me.utMemberID.Location = New System.Drawing.Point(53, 40)
        Me.utMemberID.Name = "utMemberID"
        Me.utMemberID.Size = New System.Drawing.Size(72, 21)
        Me.utMemberID.TabIndex = 149
        Me.utMemberID.Tag = ".MemberID"
        '
        'utMember
        '
        Me.utMember.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMember.Location = New System.Drawing.Point(53, 16)
        Me.utMember.Name = "utMember"
        Me.utMember.Size = New System.Drawing.Size(216, 21)
        Me.utMember.TabIndex = 148
        Me.utMember.Tag = ".Member_Name"
        '
        'btnMember
        '
        Me.btnMember.Location = New System.Drawing.Point(141, 40)
        Me.btnMember.Name = "btnMember"
        Me.btnMember.Size = New System.Drawing.Size(80, 21)
        Me.btnMember.TabIndex = 150
        Me.btnMember.Text = "Se&lect"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(5, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "Account:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupsSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(904, 477)
        Me.Controls.Add(Me.CGroupBox1)
        Me.Controls.Add(Me.MGroupBox1)
        Me.Controls.Add(Me.GGroupBox1)
        Me.Name = "GroupsSetup"
        Me.Tag = "Groups"
        Me.Text = "Groups Setup"
        Me.GGroupBox1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GGroupBox2.ResumeLayout(False)
        CType(Me.utGroupComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utGroupID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CGroupBox1.ResumeLayout(False)
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CGroupBox3.ResumeLayout(False)
        Me.CGroupBox2.ResumeLayout(False)
        CType(Me.utCGroupID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utClubID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utClubComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utClub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MGroupBox1.ResumeLayout(False)
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MGroupBox3.ResumeLayout(False)
        Me.MGroupBox2.ResumeLayout(False)
        CType(Me.utMClubID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMGroupID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMemberID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMember, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub GroupsSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated

        Dim MinWinSize As System.Drawing.Size

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = AppTblPath & Me.Tag
            End If
        End If

        Frames(0) = New Object() {GSQLSelect, GGroupBox2, UltraGrid1, New Infragistics.Win.UltraWinEditors.UltraTextEditor() {utGroup, utGroupID, utGroupComments}, btnGSave, btnGNew, btnGEdit, btnGDelete, HidColsG}
        Frames(1) = New Object() {CSQLSelect, CGroupBox2, UltraGrid2, New Infragistics.Win.UltraWinEditors.UltraTextEditor() {utClub, utClubID, utClubComments}, btnCSave, btnCNew, btnCEdit, btnCDelete, HidColsC}
        Frames(2) = New Object() {MSQLSelect, MGroupBox2, UltraGrid3, New Infragistics.Win.UltraWinEditors.UltraTextEditor() {utMember, utMemberID}, btnMSave, btnMNew, btnMEdit, btnMDelete, HidColsM}
        'BCColsData2(0) = New Object() {New Integer() {}, New String() {}}


        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(GGroupBox1, AppDBName, AppDBUser, AppDBPass)
        SetupCtrlsLength(CGroupBox1, AppDBName, AppDBUser, AppDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp


        'MinWinSize.Width = UltraGrid1.Width + Value.Left + Value.Width + 50
        'MinWinSize.Height = GroupBox4.Height + GroupBox3.Height + 20 'Panel1.Height
        'Me.MinimumSize = MinWinSize

        LoadData(0)
        Edit_Enable(False, 0)
        Edit_Enable(False, 1)
        Edit_Enable(False, 2)


    End Sub

    Private Sub LoadData(ByVal Index As Int16)

        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim HidCols() As String
        Dim i As Integer
        Dim AcctCond, FromLocCond, ToLocCond, TRNumCond, ThirdPCond As String
        Dim condition As String
        Dim UltraGridx As Infragistics.Win.UltraWinGrid.UltraGrid

        Dim IDFld, IDVal As String

        Select Case Index
            Case 0
                IDFld = "GroupID"
                condition = ""
            Case 1
                IDFld = "ClubID"
                condition = " Where GroupID = '" & utCGroupID.Text & "' "
            Case 2
                IDFld = "MemberID"
                condition = " Where GroupID = '" & utMGroupID.Text & "' AND ClubID = '" & utMClubID.Text & "' "
            Case Else
                MsgBox("Unknown key : " & Index)
                Exit Sub
        End Select

        IDVal = Frames(Index)(enFrm._3UTx)(1).text

        SQLSelect = PrepSelectQuery(Frames(Index)(enFrm._0SQL), condition)
        UltraGridx = Frames(Index)(enFrm._2UGd)
        HidCols = Frames(Index)(enFrm._8HCl)

        If Not UltraGridx.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If


        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        'For i = 0 To dtSet.Tables(0).Columns.Count - 1
        '    dtSet.Tables(0).Columns(i).ReadOnly = True
        'Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGridx, dtSet, -1, HidCols, 0)
        'UltraGrid1.DataSource = dtSet

        'UGLoadLayout(Me, UltraGrid1, 1)

        UltraGridx.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        UltraGridx.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        For i = 0 To UltraGridx.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGridx.DisplayLayout.Bands(0).Columns(i).TabStop = False
            UltraGridx.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next

        UltraGridx.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False

        'UltraGridx.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGridx.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGridx.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGridx.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGridx.DisplayLayout.Bands(0).Summaries.Add(IDFld, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGridx.DisplayLayout.Bands(0).Columns(IDFld), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGridx.DisplayLayout.Bands(0).Summaries(IDFld).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGridx.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGridx.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGridx.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGridx.DisplayLayout.GroupByBox.Hidden = False
        UltraGridx.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGridx.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        UltraGridx.DisplayLayout.Bands(0).Columns(0).Width = 40
        UltraGridx.DisplayLayout.AutoFitColumns = True
        UltraGridx.AllowDrop = True
        'ultragrid1.DisplayLayout.Override.
        'UltraGrid1.Text = "Packages"
    End Sub

    'Private Sub LoadGroups()

    '    Dim dtAdapter As SqlDataAdapter
    '    Dim dtSet As New DataSet
    '    Dim SummaryFld As String = "GroupID"
    '    Dim i As Integer
    '    Dim AcctCond, FromLocCond, ToLocCond, TRNumCond, ThirdPCond As String


    '    SQLSelect = GSQLSelect
    '    If Not UltraGrid1.DataSource Is Nothing Then
    '        'UGSaveLayout(Me, UltraGrid1, 1)
    '    End If


    '    PopulateDataset2(dtAdapter, dtSet, SQLSelect)

    '    'For i = 0 To dtSet.Tables(0).Columns.Count - 1
    '    '    dtSet.Tables(0).Columns(i).ReadOnly = True
    '    'Next
    '    'dtSet.Tables(0).Columns(0).ReadOnly = False

    '    FillUltraGrid(UltraGrid1, dtSet, -1, HidCols, 0)
    '    'UltraGrid1.DataSource = dtSet

    '    'UGLoadLayout(Me, UltraGrid1, 1)

    '    UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
    '    UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

    '    For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
    '        UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
    '        UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '    Next

    '    UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False

    '    'UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
    '    'UltraGrid1.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
    '    'UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
    '    'UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


    '    UltraGrid1.DisplayLayout.Bands(0).Summaries.Add(SummaryFld, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns(SummaryFld), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
    '    UltraGrid1.DisplayLayout.Bands(0).Summaries(SummaryFld).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
    '    UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
    '    UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


    '    UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

    '    UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
    '    UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
    '    UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
    '    UltraGrid1.DisplayLayout.Bands(0).Columns(0).Width = 50
    '    UltraGrid1.DisplayLayout.AutoFitColumns = True
    '    'UltraGrid1.Text = "Packages"
    'End Sub

    Private Sub Edit_Enable(ByVal status As Boolean, ByVal FrmIdx As Int16)
        Dim Groupbox, GrpBoxP As GroupBox
        Dim btnSave, btnDelete, btnEdit, btnNew As Button

        Groupbox = Frames(FrmIdx)(enFrm._1Grp)
        btnSave = Frames(FrmIdx)(enFrm._4BSv)
        btnNew = Frames(FrmIdx)(enFrm._5BNw)
        btnEdit = Frames(FrmIdx)(enFrm._6BEd)
        btnDelete = Frames(FrmIdx)(enFrm._7BDl)
        UltraGrid = Frames(FrmIdx)(enFrm._2UGd)

        GrpBoxP = Groupbox.Parent
        If GGroupBox1.Name <> GrpBoxP.Name Then
            GGroupBox1.Enabled = Not status
            UltraGrid1.Enabled = Not status
        End If
        If CGroupBox1.Name <> GrpBoxP.Name Then
            CGroupBox1.Enabled = Not status
            UltraGrid2.Enabled = Not status
        End If
        If MGroupBox1.Name <> GrpBoxP.Name Then
            MGroupBox1.Enabled = Not status
            UltraGrid3.Enabled = Not status
        End If
        Groupbox.Enabled = status
        btnSave.Enabled = status
        btnDelete.Enabled = Not status
        UltraGrid.Enabled = Not status
        btnSave.Text = "&Save"

        If status = True Then 'Enable Editing
        Else 'End Editing
            btnEdit.Text = "&Edit"
            btnEdit.Enabled = True
            btnNew.Text = "&New"
            btnNew.Enabled = True
        End If
    End Sub

    Private Sub btnGEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGEdit.Click, btnCEdit.Click, btnMEdit.Click
        Dim IDFld, IDVal As String
        Dim GrpBox As GroupBox
        Dim btnNew, btnEdit, btnDelete, btnSave As Button
        Dim FrmIdx As Int16

        Select Case sender.name
            Case "btnGEdit"
                IDFld = "GroupID"
                FrmIdx = 0
            Case "btnCEdit"
                IDFld = "ClubID"
                FrmIdx = 1
            Case "btnMEdit"
                IDFld = "MemberID"
                FrmIdx = 2
            Case Else
                MsgBox("Unknown key : " & sender.name)
                Exit Sub
        End Select

        IDVal = Frames(FrmIdx)(enFrm._3UTx)(1).text
        UltraGrid = Frames(FrmIdx)(enFrm._2UGd)
        SQLSelect = Frames(FrmIdx)(enFrm._0SQL)
        GrpBox = Frames(FrmIdx)(enFrm._1Grp)

        btnNew = Frames(FrmIdx)(enFrm._5BNw)
        btnEdit = Frames(FrmIdx)(enFrm._6BEd)
        btnDelete = Frames(FrmIdx)(enFrm._7BDl)
        btnSave = Frames(FrmIdx)(enFrm._4BSv)



        If UltraGrid.ActiveRow Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("No row is selected. Please select a row to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Select a row first.")
            Exit Sub
        End If
        If UltraGrid.ActiveRow.ListObject Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("No row is selected. Please select a row to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '-  MsgBox("Select a row first.")
            Exit Sub
        End If

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLSelect, " Where " & IDFld & " = '" & IDVal & "'"), EditAction.START, cmdTrans) Then
                sender.text = "&Cancel"
                UltraGrid.Enabled = False
                Edit_Enable(True, FrmIdx)
                If sender.name = "btnGEdit" Then
                    utGroupID.Enabled = False
                End If
                btnNew.Enabled = False
                'utGroup.Focus()
                GrpBox.Focus()
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                sender.text = "&Edit"
                UltraGrid.Enabled = True
                Edit_Enable(False, FrmIdx)
                'FormLoad(Me, dvCompany)
            End If
        End If

    End Sub

    Private Sub btnGNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGNew.Click, btnCNew.Click, btnMNew.Click
        Dim IDFld, IDVal As String
        Dim GrpBox As GroupBox
        Dim btnNew, btnEdit, btnDelete, btnSave As Button
        Dim FrmIdx As Int16

        Select Case sender.name
            Case "btnGNew"
                IDFld = "GroupID"
                FrmIdx = 0
            Case "btnCNew"
                IDFld = "ClubID"
                FrmIdx = 1
            Case "btnMNew"
                IDFld = "MemberID"
                FrmIdx = 2
            Case Else
                MsgBox("Unknown key : " & sender.name)
                Exit Sub
        End Select

        IDVal = Frames(FrmIdx)(enFrm._3UTx)(1).text
        UltraGrid = Frames(FrmIdx)(enFrm._2UGd)
        SQLSelect = Frames(FrmIdx)(enFrm._0SQL)
        GrpBox = Frames(FrmIdx)(enFrm._1Grp)

        btnNew = Frames(FrmIdx)(enFrm._5BNw)
        btnEdit = Frames(FrmIdx)(enFrm._6BEd)
        btnDelete = Frames(FrmIdx)(enFrm._7BDl)
        btnSave = Frames(FrmIdx)(enFrm._4BSv)



        If sender.text.toupper = "&NEW" Then
            Select Case FrmIdx
                Case 1 'Club
                    If UltraGrid1.ActiveRow Is Nothing Then 'Should be UltraGrid1
                        'Message modified by Michael Pastor
                        MsgBox("No group row is selected. Please select a group row to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
                        '- MsgBox("Select a Group row first.")
                        Exit Sub
                    End If
                    If UltraGrid1.ActiveRow.ListObject Is Nothing Then
                        'Message modified by Michael Pastor
                        MsgBox("No group row is selected. Please select a group row to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
                        '- MsgBox("Select a Group row first.")
                        Exit Sub
                    End If
                Case 2 'Member
                    If UltraGrid2.ActiveRow Is Nothing Then 'Should be UltraGrid1
                        'Message modified by Michael Pastor
                        MsgBox("No club row is selected. Please select a club row to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
                        '- MsgBox("Select a Club row first.")
                        Exit Sub
                    End If
                    If UltraGrid2.ActiveRow.ListObject Is Nothing Then
                        'Message modified by Michael Pastor
                        MsgBox("No club row is selected. Please select a club row to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
                        '- MsgBox("Select a Club row first.")
                        Exit Sub
                    End If
            End Select
            sender.text = "&Cancel"
            Edit_Enable(True, FrmIdx)
            If FrmIdx = 0 Then
                utGroupID.Enabled = True
            End If
            btnEdit.Enabled = False
            ClearForm(GrpBox)
            'utGroup.Focus()
            GrpBox.Focus()
        Else
            sender.text = "&New"
            ClearForm(GrpBox)
            Edit_Enable(False, FrmIdx)
            'btnEdit.Enabled = True
        End If

    End Sub

    Private Sub btnGSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGSave.Click, btnCSave.Click, btnMSave.Click

        Dim cnt As Integer
        Dim RowIdx, IdxName As Integer

        Dim StrArr() As String
        Dim Verify As Boolean

        Dim IDFld, IDVal As String
        Dim GrpBox As GroupBox
        Dim btnNew, btnEdit, btnDelete, btnSave As Button
        Dim FrmIdx As Int16
        Dim utID, utName As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "btnGSave"
                IDFld = "GroupID"
                FrmIdx = 0
            Case "btnCSave"
                IDFld = "ClubID"
                FrmIdx = 1
            Case "btnMSave"
                IDFld = "MemberID"
                FrmIdx = 2
            Case Else
                'Message modified by Michael Pastor
                MsgBox("Unknown key: " & sender.name, MsgBoxStyle.Exclamation, "Data Unavailable")
                '- MsgBox("Unknown key : " & sender.name)
                Exit Sub
        End Select

        IDVal = Frames(FrmIdx)(enFrm._3UTx)(1).text
        UltraGrid = Frames(FrmIdx)(enFrm._2UGd)
        SQLSelect = Frames(FrmIdx)(enFrm._0SQL)
        GrpBox = Frames(FrmIdx)(enFrm._1Grp)

        btnNew = Frames(FrmIdx)(enFrm._5BNw)
        btnEdit = Frames(FrmIdx)(enFrm._6BEd)
        btnDelete = Frames(FrmIdx)(enFrm._7BDl)
        btnSave = Frames(FrmIdx)(enFrm._4BSv)
        utID = Frames(FrmIdx)(enFrm._3UTx)(1)
        utName = Frames(FrmIdx)(enFrm._3UTx)(0)

        Verify = True
        StrArr = GetCtrldbFieldInfo(utID)
        If StrArr.Length >= (TagOpts.JustView + 1) Then
            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then
                Verify = False
            End If
        End If
        If Verify And utID.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("The ID remains unspecified. Please enter a valid ID.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("ID is blank.")
            Exit Sub
        End If
        If utName.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("The ID remains unspecified. Please enter a valid ID.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Name is blank.")
            Exit Sub
        End If

        If btnNew.Enabled Then
        ElseIf btnEdit.Enabled Then
            RowIdx = UltraGrid.ActiveRow.Index()
        Else
            MsgBox("Error!!")
            Exit Sub
        End If

        If EditForm(GrpBox, SQLSelect, EditAction.ENDEDIT, cmdTrans, " Where " & IDFld & " = '" & utID.Text & "'") Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            'btnEdit.Text = "&Edit"
            'Me.Text = MeText & " -- Record Updated."
            LoadData(FrmIdx)
            'row = dtSet.Tables(0).Rows.Find(IdxName)
            'Dim Arr() As Array
            'Arr = row.ItemArray
            Edit_Enable(False, FrmIdx)
            UltraGrid.Focus()
            UltraGrid.Refresh()
            UltraGrid.ActiveRow = UltraGrid.Rows.GetRowAtVisibleIndex(RowIdx)

        End If

    End Sub

    'Karina Warning on Closing the form 6.16.2005
    Private Sub GroupsSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If btnCEdit.Text = "&Cancel" Or btnCNew.Text = "&Cancel" Or _
           btnGEdit.Text = "&Cancel" Or btnGNew.Text = "&Cancel" Or _
           btnMEdit.Text = "&Cancel" Or btnMNew.Text = "&Cancel" Then

            'Message modified by Michael Pastor
            If MessageBox.Show("Data is not saved! Are you sure you want to exit?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                '- If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            'SQLSelect = GSQLSelect
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                'btnGEdit.Text = "&Edit"
                UltraGrid.Enabled = True 'Karina Enabled
                sender.text = "&Edit"
                'Edit_Enable(False, GGroupBox2)
            Else
                'Exit Sub
            End If
        End If
        UGSaveLayout(Me, UltraGrid1, 1) 'Karina Enabled

        'Me.Close()


    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate, UltraGrid2.AfterRowActivate, UltraGrid3.AfterRowActivate
        Dim IDFld, IDVal As String
        Dim GrpBox As GroupBox
        Dim btnNew, btnEdit, btnDelete, btnSave As Button
        Dim FrmIdx As Int16
        Dim utID, utName As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "UltraGrid1"
                IDFld = "GroupID"
                'UltraGrid2.Dispose()
                UltraGrid2.DataSource = Nothing
                UltraGrid3.DataSource = Nothing
                ClearForm(MGroupBox2)
                ClearForm(CGroupBox2)
                If Not UltraGrid1.ActiveRow Is Nothing Then
                    If Not UltraGrid1.ActiveRow.ListObject Is Nothing Then
                        utCGroupID.Text = UltraGrid1.ActiveRow.Cells("GroupID").Value
                        utMGroupID.Text = UltraGrid1.ActiveRow.Cells("GroupID").Value
                    End If
                End If
                FrmIdx = 0
            Case "UltraGrid2"
                'UltraGrid3.Dispose()
                UltraGrid3.DataSource = Nothing
                ClearForm(MGroupBox2)
                IDFld = "ClubID"
                FrmIdx = 1
                If Not UltraGrid2.ActiveRow Is Nothing Then
                    If Not UltraGrid2.ActiveRow.ListObject Is Nothing Then
                        utMClubID.Text = UltraGrid2.ActiveRow.Cells("ClubID").Value
                    End If
                End If
            Case "UltraGrid3"
                IDFld = "MemberID"
                FrmIdx = 2
            Case Else
                'Message modified by Michael Pastor
                MsgBox("Unknown key: " & sender.name, MsgBoxStyle.Exclamation, "Data Unavailable")
                '- MsgBox("Unknown key : " & sender.name)
                Exit Sub
        End Select

        IDVal = Frames(FrmIdx)(enFrm._3UTx)(1).text
        UltraGrid = Frames(FrmIdx)(enFrm._2UGd)
        SQLSelect = Frames(FrmIdx)(enFrm._0SQL)
        GrpBox = Frames(FrmIdx)(enFrm._1Grp)

        btnNew = Frames(FrmIdx)(enFrm._5BNw)
        btnEdit = Frames(FrmIdx)(enFrm._6BEd)
        btnDelete = Frames(FrmIdx)(enFrm._7BDl)
        btnSave = Frames(FrmIdx)(enFrm._4BSv)
        utID = Frames(FrmIdx)(enFrm._3UTx)(1)
        utName = Frames(FrmIdx)(enFrm._3UTx)(0)


        FormLoadFromGrid(GrpBox, sender)
        Select Case FrmIdx
            Case 0
                LoadData(1)
            Case 1
                LoadData(2)
        End Select
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        Dim IDFld, IDVal As String
        Dim GrpBox As GroupBox
        Dim btnNew, btnEdit, btnDelete, btnSave As Button
        Dim FrmIdx As Int16
        Dim utID, utName As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "UltraGrid1"
                IDFld = "GroupID"
                'UltraGrid2.DataSource = Nothing
                'UltraGrid3.DataSource = Nothing
                'ClearForm(MGroupBox2)
                'ClearForm(CGroupBox2)
                If Not UltraGrid1.ActiveRow Is Nothing Then
                    If Not UltraGrid1.ActiveRow.ListObject Is Nothing Then
                        utCGroupID.Text = UltraGrid1.ActiveRow.Cells("GroupID").Value
                        utMGroupID.Text = UltraGrid1.ActiveRow.Cells("GroupID").Value
                    End If
                End If
                FrmIdx = 0
            Case "UltraGrid2"
                IDFld = "ClubID"
                FrmIdx = 1
                'UltraGrid3.DataSource = Nothing
                'ClearForm(MGroupBox2)
                If Not UltraGrid2.ActiveRow Is Nothing Then
                    If Not UltraGrid2.ActiveRow.ListObject Is Nothing Then
                        utMClubID.Text = UltraGrid2.ActiveRow.Cells("ClubID").Value
                    End If
                End If
            Case "UltraGrid3"
                IDFld = "MemberID"
                FrmIdx = 2
            Case Else
                'Message modified by Michael Pastor
                MsgBox("Unknown key: " & sender.name, MsgBoxStyle.Exclamation, "Data Unavailable")
                '- MsgBox("Unknown key : " & sender.name)
                Exit Sub
        End Select

        IDVal = Frames(FrmIdx)(enFrm._3UTx)(1).text
        UltraGrid = Frames(FrmIdx)(enFrm._2UGd)
        SQLSelect = Frames(FrmIdx)(enFrm._0SQL)
        GrpBox = Frames(FrmIdx)(enFrm._1Grp)

        btnNew = Frames(FrmIdx)(enFrm._5BNw)
        btnEdit = Frames(FrmIdx)(enFrm._6BEd)
        btnDelete = Frames(FrmIdx)(enFrm._7BDl)
        btnSave = Frames(FrmIdx)(enFrm._4BSv)
        utID = Frames(FrmIdx)(enFrm._3UTx)(1)
        utName = Frames(FrmIdx)(enFrm._3UTx)(0)

        If sender.enabled And UltraGrid.Rows.Count > 0 Then
            FormLoadFromGrid(GrpBox, sender)
            Select Case FrmIdx
                Case 0
                    LoadData(1)
                Case 1
                    LoadData(2)
            End Select
        End If
    End Sub

    Private Sub utMember_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utMember.KeyUp
        Dim WGTGrpSQL As String

        WGTGrpSQL = AppTblPath & "Customer"

        TypeAhead(sender, e, WGTGrpSQL, "Name", "")
        'sender.modified = True

    End Sub

    Private Sub utMember_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utMember.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utMemberID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, utMemberID, AppTblPath & "Customer", "ID", "Name", "*", "Accounts", " Where status = 1 ") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
            Else
                'MsgBox("Truck Not Found.")
                utMemberID.Text = ""
                utMember.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False
    End Sub

    Private Sub btnMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMember.Click
        Dim SelectSQLx As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQLx = "Select * from [" & AppDBName & "].dbo.Customer i WHERE (Status = 1) order by ID"

        PopulateDataset2(dtAdapter, dtSet, SelectSQLx)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Accounts"
            Srch.Text = "Accounts"
            Srch.ShowDialog()
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                'MsgBox("Zipcode Leave: " & Err.Message)
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
                ' CANCEL PRESSED
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch osqlexception As SqlException
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                '- MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    'AcctName.Text = ugRow.Cells("Name").Text
                    utMember.Text = ugRow.Cells("Name").Text
                    utMemberID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                    utMember.Modified = False
                    utMemberID.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If

    End Sub

    Private Sub btnGDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGDelete.Click, btnCDelete.Click, btnMDelete.Click
        Dim dsData As DataSet
        Dim ID As Integer
        Dim row As DataRow
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim dv As New DataView


        Dim IDFld, IDVal, condition As String
        Dim GrpBox As GroupBox
        Dim btnNew, btnEdit, btnDelete, btnSave As Button
        Dim FrmIdx As Int16
        Dim utID, utName As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim sqlTemp As String

        Select Case sender.name
            Case "btnGDelete"
                IDFld = "GroupID"
                FrmIdx = 0
                SQLSelect = Frames(FrmIdx)(enFrm._0SQL)
                sqlTemp = Frames(FrmIdx + 1)(enFrm._0SQL)

                condition = " Where GroupID = '" & utGroupID.Text & "' "
            Case "btnCDelete"
                IDFld = "ClubID"
                FrmIdx = 1
                SQLSelect = Frames(FrmIdx)(enFrm._0SQL)
                sqlTemp = Frames(FrmIdx + 1)(enFrm._0SQL)
                condition = " Where GroupID = '" & utCGroupID.Text & "' AND ClubID = '" & utClubID.Text & "' "
            Case "btnMDelete"
                IDFld = "MemberID"
                FrmIdx = 2
                SQLSelect = Frames(FrmIdx)(enFrm._0SQL)
                sqlTemp = Frames(FrmIdx)(enFrm._0SQL)
                condition = " Where MemberID = @MEMBID "
            Case Else
                'Message modified by Michael Pastor
                MsgBox("Unknown key: " & sender.name, MsgBoxStyle.Exclamation, "Data Unavailable")
                '- MsgBox("Unknown key : " & sender.name)
                Exit Sub
        End Select

        IDVal = Frames(FrmIdx)(enFrm._3UTx)(1).text
        UltraGrid = Frames(FrmIdx)(enFrm._2UGd)
        GrpBox = Frames(FrmIdx)(enFrm._1Grp)

        btnNew = Frames(FrmIdx)(enFrm._5BNw)
        btnEdit = Frames(FrmIdx)(enFrm._6BEd)
        btnDelete = Frames(FrmIdx)(enFrm._7BDl)
        btnSave = Frames(FrmIdx)(enFrm._4BSv)
        utID = Frames(FrmIdx)(enFrm._3UTx)(1)
        utName = Frames(FrmIdx)(enFrm._3UTx)(0)


        If UltraGrid.Selected.Rows.Count = 0 Then Exit Sub

        If UltraGrid.Selected.Rows.Count = UltraGrid.Rows.Count Then
            ID = -1
        Else
            ugrow = UltraGrid.Selected.Rows(0)
            If ugrow.Index > 0 Then
                ID = ugrow.Index - 1
            Else
                ID = 0
            End If
        End If
        If ReturnRowByID("", row, AppTblPath & "GroupClubMembers", "", "RowID", PrepSelectQuery(sqlTemp, condition.Replace("@MEMBID", "'-1'"))) Then
            If Not row Is Nothing Then
                'Message modified by Michael Pastor
                MsgBox("Selected record contains linked sub records. Please delete the sub records to continue.", MsgBoxStyle.Exclamation, "Data Deletion")
                '- MsgBox("There sub records linked to this record. Delete them First.")
                row = Nothing
                Exit Sub
            End If
        End If
        UltraGrid.DeleteSelectedRows()
        dv = UltraGrid.DataSource
        dsData = dv.Table.DataSet
        If UpdateDbFromDataSet(dsData, SQLSelect) <= 0 Then
            'MsgBox("btnDelete_Click: Error!")
            Exit Sub
        End If
        If ID >= 0 Then
            UltraGrid.ActiveRow = UltraGrid.Rows.GetItem(ID)
        Else
            ClearForm(GrpBox)
        End If

    End Sub

    Private Sub UltraGrid1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles UltraGrid1.DragDrop

        e.Effect = DragDropEffects.Copy

    End Sub

    Private Sub UltraGrid1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles UltraGrid1.DragEnter
        Dim i As Int32
        i = e.X

    End Sub

    Private Sub UltraGrid1_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.DragLeave
        Dim i As Int16
        i = 1
    End Sub

    Private Sub UltraGrid1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles UltraGrid1.DragOver
        Dim i As Int16
        i = 1
    End Sub

    '=========================================================================================================
    '
    '                                           Context Menu
    '
    '=========================================================================================================

    Private Sub Ultragrid2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid2.MouseDown, UltraGrid1.MouseDown, UltraGrid3.MouseDown
        On Error GoTo ErrLabel

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement
            Dim oUIElement As Infragistics.Win.UIElement
            Dim oUIElementTmp As Infragistics.Win.UIElement
            Dim point As Point = New Point(e.X, e.Y)

            Dim oRowUI As Infragistics.Win.UltraWinGrid.RowUIElement

            m_oGrid = sender

            oUIElement = Me.m_oGrid.DisplayLayout.UIElement.ElementFromPoint(point)
            If oUIElement Is Nothing Then Exit Sub
            'Infragistics.Win.UltraWinGrid.BandHeadersUIElement()
            'Infragistics.Win.UltraWinGrid.CaptionAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardCaptionUIElement()
            'Infragistics.Win.UltraWinGrid.CardLabelAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardLabelUIElement()
            'Infragistics.Win.UltraWinGrid.CellUIElement()
            'Infragistics.Win.UltraWinGrid.DataAreaUIElement()
            'Infragistics.Win.UltraWinGrid.PageHeaderUIElement()
            'Infragistics.Win.UltraWinGrid.PreRowAreaUIElement()
            'Infragistics.Win.UltraWinGrid.RowCellAreaUIElement()
            'Infragistics.Win.UltraWinGrid.RowSelectorUIElement()
            'Infragistics.Win.UltraWinGrid.RowUIElement()
            'Infragistics.Win.UltraWinGrid.SortIndicatorUIElement()
            'Infragistics.Win.UltraWinGrid.UltraGridUIElement()

            oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement))
            If oUIElementTmp Is Nothing Then
                oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement))
                If oUIElementTmp Is Nothing Then
                    oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.RowUIElement))
                    If oUIElementTmp Is Nothing Then
                        Return
                    End If
                End If
            End If

            oUIElement = oUIElementTmp
            Select Case oUIElement.GetType().ToString
                Case "Infragistics.Win.UltraWinGrid.HeaderUIElement"
                    oHeaderUI = oUIElement
                Case "Infragistics.Win.UltraWinGrid.CaptionAreaUIElement"
                    oCaptionUI = oUIElement
                Case "Infragistics.Win.UltraWinGrid.RowUIElement"
                    oRowUI = oUIElement
                Case Else
                    Exit Sub
            End Select

            'If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement) Then
            '    If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement) Then
            '        Exit Sub
            '    Else
            '        oCaptionUI = oUIElement
            '    End If
            'Else
            '    oHeaderUI = oUIElement
            'End If

            If Not oCaptionUI Is Nothing Then
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("AutoFit", New EventHandler(AddressOf mnuAutoFit_Click))
                CntMenu1.MenuItems(0).Checked = m_oGrid.DisplayLayout.AutoFitColumns
                CntMenu1.Show(m_oGrid, point)
            End If

            If Not oHeaderUI Is Nothing Then
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("Hide", New EventHandler(AddressOf mnuHide_Click))
                CntMenu1.MenuItems.Add("Unhide")
                CntMenu1.MenuItems.Add("Find", New EventHandler(AddressOf mnuFind_Click))
                CntMenu1.MenuItems.Add("Add to Sort (Asc)", New EventHandler(AddressOf mnuSortAsc_Click))
                CntMenu1.MenuItems.Add("Add to Sort (Desc)", New EventHandler(AddressOf mnuSortDesc_Click))


                Dim oColHeader As Infragistics.Win.UltraWinGrid.ColumnHeader = Nothing
                m_oColumn = Nothing
                oColHeader = oHeaderUI.SelectableItem
                m_oColumn = oColHeader.Column
                If m_oColumn Is Nothing Then Exit Sub

                Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
                If CntMenu1.MenuItems.Item(1).MenuItems.Count > 0 Then
                    CntMenu1.MenuItems.Item(1).MenuItems.Clear()
                    CntMenu1.MenuItems.RemoveAt(1)
                    CntMenu1.MenuItems.Add("Unhide")
                    CntMenu1.MenuItems(CntMenu1.MenuItems.Count).Index = 1
                End If
                For Each ugcol In m_oGrid.DisplayLayout.Bands(0).Columns
                    If ugcol.Hidden = True Then
                        CntMenu1.MenuItems(1).MenuItems.Add(ugcol.ToString, New EventHandler(AddressOf SubMnuUnHide_Click))
                    End If
                Next

                CntMenu1.Show(m_oGrid, point)
            End If

            If Not oRowUI Is Nothing And sender.name.toupper = "ULTRAGRID2" Then
                m_oRow = oRowUI.Row
                If m_oRow Is Nothing Then Exit Sub

                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("Make Member Of ")
                CntMenu1.MenuItems.Add("Copy Members Into")

                CntMenu1.MenuItems(0).MenuItems.Clear()
                CntMenu1.MenuItems(1).MenuItems.Clear()

                Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
                Dim ugrow2 As Infragistics.Win.UltraWinGrid.UltraGridRow
                Dim mnuItem As MenuItem
                Dim GrpIdx, Clbidx As Int32
                Dim dta As SqlDataAdapter
                Dim ds As DataSet

                Clbidx = GrpIdx = 0
                For Each ugrow In UltraGrid1.Rows
                    CntMenu1.MenuItems(0).MenuItems.Add(ugrow.Cells("Group_Name").Value, New EventHandler(AddressOf mnuMKMemG_Click))
                    CntMenu1.MenuItems(0).MenuItems(GrpIdx).MenuItems.Clear()
                    Clbidx = 0
                    PopulateDataset2(dta, ds, "Select Club_Name From " & AppTblPath & "GroupClubs where GroupID = '" & ugrow.Cells("GroupID").Value & "' ")
                    Dim row As DataRow
                    For Each row In ds.Tables(0).Rows
                        'CntMenu1.MenuItems(0).MenuItems(GrpIdx).MenuItems.RemoveAt(ClbIdx)
                        mnuItem = CntMenu1.MenuItems(0).MenuItems(GrpIdx).MenuItems.Add(row("Club_Name"), New EventHandler(AddressOf MnuMKMemClub_Click))
                        'mnuItem.Index = Clbidx
                        Clbidx += 1
                    Next
                    If Not dta Is Nothing Then
                        dta.Dispose()
                        dta = Nothing
                    End If
                    ds.Dispose()
                    ds = Nothing
                    GrpIdx += 1
                Next


                CntMenu1.Show(m_oGrid, point)
            End If

            'If oCaptionUI Is Nothing Then
            '    CntMenu1.MenuItems.Clear()
            '    CntMenu1.MenuItems.Add("Hide", New EventHandler(AddressOf mnuHide_Click))
            '    CntMenu1.MenuItems.Add("Unhide")
            '    CntMenu1.MenuItems.Add("Find", New EventHandler(AddressOf mnuFind_Click))
            '    CntMenu1.MenuItems.Add("Add to Sort (Asc)", New EventHandler(AddressOf mnuSortAsc_Click))
            '    CntMenu1.MenuItems.Add("Add to Sort (Desc)", New EventHandler(AddressOf mnuSortDesc_Click))


            '    Dim oColHeader As Infragistics.Win.UltraWinGrid.ColumnHeader = Nothing
            '    m_oColumn = Nothing
            '    oColHeader = oHeaderUI.SelectableItem
            '    m_oColumn = oColHeader.Column
            '    If m_oColumn Is Nothing Then Exit Sub


            '    Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
            '    If CntMenu1.MenuItems.Item(1).MenuItems.Count > 0 Then
            '        CntMenu1.MenuItems.Item(1).MenuItems.Clear()
            '        CntMenu1.MenuItems.RemoveAt(1)
            '        CntMenu1.MenuItems.Add("Unhide")
            '        CntMenu1.MenuItems(CntMenu1.MenuItems.Count).Index = 1
            '    End If
            '    For Each ugcol In UltraGrid1.DisplayLayout.Bands(0).Columns
            '        If ugcol.Hidden = True Then
            '            CntMenu1.MenuItems(1).MenuItems.Add(ugcol.ToString, New EventHandler(AddressOf SubMnuUnHide_Click))
            '        End If
            '    Next

            '    CntMenu1.Show(UltraGrid1, point)
            'Else 'Caption Click
            '    CntMenu1.MenuItems.Clear()
            '    CntMenu1.MenuItems.Add("AutoFit", New EventHandler(AddressOf mnuAutoFit_Click))
            '    CntMenu1.MenuItems(0).Checked = UltraGrid1.DisplayLayout.AutoFitColumns
            '    CntMenu1.Show(UltraGrid1, point)

            'End If
        End If
        Exit Sub
ErrLabel:
        'Message modified by Michael Pastor
        MsgBox("Error: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("Error : " & Err.Description)
        'Resume
    End Sub

    Private Sub mnuAutoFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CntMenu1.MenuItems(0).Checked Then
            CntMenu1.MenuItems(0).Checked = False
        Else
            CntMenu1.MenuItems(0).Checked = True
        End If

        m_oGrid.DisplayLayout.AutoFitColumns = CntMenu1.MenuItems(0).Checked

    End Sub

    Private Sub mnuHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuHide.Click
        If Not m_oColumn Is Nothing Then
            m_oColumn.Hidden = True
        End If
    End Sub
    Private Sub SubMnuUnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ugCol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        For Each ugCol In m_oGrid.DisplayLayout.Bands(0).Columns
            If ugCol.ToString = sender.text Then
                ugCol.Hidden = False
            End If
        Next

    End Sub

    Private Sub mnuSortAsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortAsc.Click
        m_oGrid.DisplayLayout.Bands(0).SortedColumns.Add(m_oColumn, False)
    End Sub

    Private Sub mnuSortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortDesc.Click
        m_oGrid.DisplayLayout.Bands(0).SortedColumns.Add(Me.m_oColumn, True)
    End Sub

    Private Sub mnuMKMemG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortDesc.Click
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        'm_oSelectedGrpID = ""
        'For Each ugrow In UltraGrid1.Rows
        '    If ugrow.Cells("Group_Name").Value = sender.text Then
        '        m_oSelectedGrpID = ugrow.Cells("GroupID").Value
        '        m_oSelectedGrp = ugrow.Cells("Group_Name").Value
        '        Exit For
        '    End If
        'Next

    End Sub

    Private Sub MnuMKMemClub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim row As DataRow

        Dim mnuItem As MenuItem
        mnuItem = sender
        mnuItem = mnuItem.Parent

        For Each ugrow In UltraGrid1.Rows
            If ugrow.Cells("Group_Name").Value = mnuItem.Text Then
                m_oSelectedGrpID = ugrow.Cells("GroupID").Value
                m_oSelectedGrp = ugrow.Cells("Group_Name").Value
                Exit For
            End If
        Next


        m_oSelectedClubID = ""
        If ReturnRowByID(sender.text, row, AppTblPath & "GroupClubs", " Where GroupID = '" & m_oSelectedGrpID & "' ", "Club_Name") = False Then
            'Message modified by Michael Pastor
            MsgBox("Unable to recieve club information.", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MsgBox("Error retriving the Club Info.")
            Exit Sub
        End If
        m_oSelectedClubID = row("ClubID")
        m_oSelectedClub = row("Club_Name")

        row = Nothing

        'For Each ugrow In UltraGrid2.Rows
        '    If ugrow.Cells("Club_Name").Value = sender.text Then
        '        m_oSelectedClubID = ugrow.Cells("ClubID").Value
        '        m_oSelectedClub = ugrow.Cells("Club_Name").Value
        '        Exit For
        '    End If
        'Next

        'Message NOT modified by Michael Pastor
        '- If MessageBox.Show("Make " & m_oRow.Cells("Club_Name").Value & " a member of " & m_oSelectedGrp & "-" & m_oSelectedClub & "?", "Data Unavailable", MsgBoxStyle.Exclamation, MessageBoxButtons.YesNo) Then
        '- The above was made to substitue, but MessageBox is incapable of handling this much information.
        '- Original message box is used (below):
        If MsgBox("Make " & m_oRow.Cells("Club_Name").Value & " a member of " & m_oSelectedGrp & "-" & m_oSelectedClub & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim sqlInsert As String = "Insert into " & AppTblPath & "GroupClubMembers(GroupID, ClubID, MemberID, Member_Name, MemberType) values('" & m_oSelectedGrpID & "', '" & m_oSelectedClubID & "', '" & m_oRow.Cells("ClubID").Value & "', '" & m_oRow.Cells("Club_Name").Value & "', 'C')"
            ExecuteQuery(sqlInsert)
        End If

    End Sub

    '=================================================================================================================
    '=================================================================================================================
    '================================             Search Routines              =======================================
    '=================================================================================================================

    Private m_searchForm As frmSearchInfo = Nothing
    Private m_searchInfo As clsSearchInfo = New clsSearchInfo

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim UGrid As Infragistics.Win.UltraWinGrid.UltraGrid

        If Me.m_oColumn Is Nothing Then Exit Sub
        UGrid = Me.m_oColumn.Band.Layout.Grid

        If Me.m_searchForm Is Nothing Then
            Me.m_searchForm = New frmSearchInfo
        End If

        Me.m_searchForm.ShowMe(Me, Me.m_oColumn.Key, UGrid, m_searchInfo)

    End Sub

    Private Sub utMemberID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utMemberID.Leave

        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utMemberID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, utMemberID, AppTblPath & "Customer", "ID", "Name", "*", "Accounts", " Where status = 1 ") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
            Else
                'MsgBox("Truck Not Found.")
                utMemberID.Text = ""
                utMember.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub
End Class
