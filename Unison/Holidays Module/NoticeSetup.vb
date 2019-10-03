'Option Explicit On 
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports Word


Public Class NoticeSetup
    Inherits System.Windows.Forms.Form
    'Dim SelectAccts As String = "Select c.ID, c.Name, '0' as NoticeID from Customer c where c.Status = 1 and c.SubjHoliday = 1 and c.ID not in  (Select AccountID from Notices where HDate = '@Date' ) union (Select n.AccountID, n.AccountName, n.ID as NoticeID from Notices n, Customer c2 where n.HDate = '@Date' and n.AccountID = c2.ID and c2.Status = 1 and c2.SubjHoliday = 1 AND n.Formatid = @FmtID ) order by ID"
    Dim SelectAccts As String = "Select c.ID, c.Name, ((c.HolidayNoticeMj*2+c.HolidayNoticeMn) & h.type )/h.type as NoticeID from " & AppTblPath & "Customer c, " & HOLIDAYSTblPath & "Holidays h " & _
                                " where c.Status = 1 and " & _
                                " c.ID not in (Select AccountID from " & HOLIDAYSTblPath & "Notices where HDate = '@Date'  and formatID <> 0 union Select AccountID From " & HOLIDAYSTblPath & "notices where HDate = '@Date' and formatID = 0 and (select Count(formatID) From " & HOLIDAYSTblPath & "notices where HDate = '@Date' and formatID = @FmtID) > 0) and h.hdate = '@Date' " & _
                                " union (Select n.AccountID, n.AccountName, n.FormatID as NoticeID From " & HOLIDAYSTblPath & "Notices n" & _
                                " where n.HDate = '@Date' AND n.Formatid = @FmtID) " & _
                                " union (Select n.AccountID, n.AccountName, n.FormatID as NoticeID From " & HOLIDAYSTblPath & "Notices n" & _
                                " where n.HDate = '@Date' AND n.Formatid = 0 AND (select Count(formatID) From " & HOLIDAYSTblPath & "notices where HDate = '@Date' and formatID = @FmtID) > 0) " & _
                                " order by c.ID"

    '" AND ((c.HolidaySvcMj*2 & h.type = 2) or (c.HolidaySvcMn & h.type = 1)) " & _

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim cmdTrans As SqlCommand

    'Dim WithEvents W_App As New Word.Application
    Dim W_App As Word.Application
    'Dim WithEvents W_App As Word.Application

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
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents cboHDate As System.Windows.Forms.ComboBox
    Friend WithEvents cboFormat As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents AccountsTree As Infragistics.Win.UltraWinTree.UltraTree
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.cboFormat = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboHDate = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.AccountsTree = New Infragistics.Win.UltraWinTree.UltraTree
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AccountsTree, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Controls.Add(Me.btnLoad)
        Me.GroupBox1.Controls.Add(Me.cboFormat)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboHDate)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 88)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(379, 48)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 69
        Me.btnDisplay.Text = "D&isplay"
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(379, 16)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(88, 21)
        Me.btnLoad.TabIndex = 68
        Me.btnLoad.Text = "&Load History"
        '
        'cboFormat
        '
        Me.cboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormat.Location = New System.Drawing.Point(88, 18)
        Me.cboFormat.Name = "cboFormat"
        Me.cboFormat.Size = New System.Drawing.Size(280, 21)
        Me.cboFormat.TabIndex = 66
        Me.cboFormat.Tag = ".FormatID...NOTICEFORMATS.ID.NAME"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Format :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboHDate
        '
        Me.cboHDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDate.Location = New System.Drawing.Point(88, 54)
        Me.cboHDate.Name = "cboHDate"
        Me.cboHDate.Size = New System.Drawing.Size(144, 21)
        Me.cboHDate.TabIndex = 64
        Me.cboHDate.Tag = ".HDate...Holidays.ID.Convert(Varchar,HDate,101)"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Holiday :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPrint)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 317)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(498, 48)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(83, 18)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 21)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(407, 18)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(8, 18)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 21)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "&Save"
        '
        'AccountsTree
        '
        Me.AccountsTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountsTree.Location = New System.Drawing.Point(0, 88)
        Me.AccountsTree.Name = "AccountsTree"
        Me.AccountsTree.Size = New System.Drawing.Size(498, 229)
        Me.AccountsTree.TabIndex = 3
        '
        'NoticeSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(498, 365)
        Me.Controls.Add(Me.AccountsTree)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "NoticeSetup"
        Me.Tag = "Notices"
        Me.Text = "Notice Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.AccountsTree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub NoticeSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


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
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        'specification of the explicit path to the tables
        FillCombo(cboFormat, "", "", "", HOLIDAYSTblPath)
        FillCombo(cboHDate, "", " Where year(hdate) in (" & Date.Today.Year & ", " & Date.Today.Year + 1 & ")", "", HOLIDAYSTblPath)

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
                If row.Item("NoticeID") > 0 Then
                    aNode.CheckedState = CheckState.Checked
                End If
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

        'Pos = InStr(SelectAccts, "@Date", CompareMethod.Text)
        While Pos > 0
        End While
        TempAcctsQry = SelectAccts.Replace("@Date", cboHDate.Text)
        TempAcctsQry = TempAcctsQry.Replace("@FmtID", cboFormat.SelectedValue)
        'if 
        TempAcctsQry = TempAcctsQry.Replace("@HOLTYPE", cboFormat.SelectedValue)

        '" ((c.HolidaySvcMj = 1 AND c.HolidayNoticeMj = 1) OR (c.HolidaySvcMn = 1 AND c.HolidayNoticeMn = 1))" & _
        PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(TempAcctsQry, ""))
    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub NoticeSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String
        Dim LoadDate As String

        SelectSQL = "Select distinct convert(varchar,Hdate,101) as Holiday From " & HOLIDAYSTblPath & "Notices order by Holiday"
        Title = "Saved Holiday Notices"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = Title
            Srch.Text = Title
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
                    LoadDate = ugRow.Cells("Holiday").Text
                    LoadHistory(LoadDate)
                    Srch = Nothing
                End If
            End Try
        End If
    End Sub

    Private Sub LoadHistory(ByVal HisDate As String)
        Dim dtAdapter As SqlDataAdapter
        Dim dtSetHis As New DataSet
        Dim aNode As Infragistics.Win.UltraWinTree.UltraTreeNode
        Dim bNode As Infragistics.Win.UltraWinTree.UltraTreeNode
        Dim row As DataRow
        Dim LastCheckedID As Integer
        Dim HisQuery As String = "Select AccountID From " & HOLIDAYSTblPath & "Notices where HDate = '" & HisDate & "' AND formatid > 0 order by AccountID"
        Dim HisQuery2 As String = "Select ID From " & AppTblPath & "Customer where CreateDate > '" & HisDate & "' AND Status = 1 order by ID"

        'Fill the AppearanceTree
        PopulateAccountsTree()
        AccountsTree.Override.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Extended
        AccountsTree.HideSelection = False
        'End Loading Available Data

        PopulateDataset2(dtAdapter, dtSetHis, PrepSelectQuery(HisQuery, ""))
        AccountsTree.Nodes(0).CheckedState = CheckState.Unchecked
        For Each row In dtSetHis.Tables(0).Rows
            For Each aNode In AccountsTree.Nodes(0).Nodes
                If Val(aNode.Key) = row.Item("AccountID") Then ' Account Found in List
                    aNode.CheckedState = CheckState.Checked
                    LastCheckedID = Val(aNode.Key)
                    Exit For
                ElseIf Val(aNode.Key) > row.Item("AccountID") Then 'Account not found in new list
                    Exit For
                ElseIf Val(aNode.Key) < row.Item("AccountID") And Val(aNode.Key) > LastCheckedID Then 'Account in List is new
                    'aNode.Override.NodeAppearance.ForeColor = Color.Blue
                    'Exit For
                End If
            Next aNode
        Next row

        dtSetHis.Dispose()
        dtAdapter = Nothing

        bNode = AccountsTree.Nodes(0).Nodes(0)
        PopulateDataset2(dtAdapter, dtSetHis, PrepSelectQuery(HisQuery2, ""))
        If dtSet Is Nothing Then Exit Sub
        If dtSetHis.Tables(0).Rows.Count > 0 Then
            For Each row In dtSetHis.Tables(0).Rows
                aNode = bNode
                While Not aNode Is Nothing
                    If Val(aNode.Key) = row.Item("ID") Then ' Account Found in List
                        aNode.Override.NodeAppearance.ForeColor = Color.Blue
                        bNode = aNode
                        Exit For
                    End If
                    aNode = aNode.GetSibling(Infragistics.Win.UltraWinTree.NodePosition.Next)
                End While
            Next row
        End If

        dtSetHis.Dispose()
        dtSetHis = Nothing
        dtAdapter = Nothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim aNode As Infragistics.Win.UltraWinTree.UltraTreeNode
        Dim AcctIDList As String = "("
        Dim AcctUnChkList As String = "("
        Dim TagFix As String
        Dim SqteLoc As Integer
        Dim dtAdapter As SqlDataAdapter
        Dim row As System.Data.DataRow

        ''For Each aNode In AccountsTree.Nodes(0).Nodes
        ''    If aNode.CheckedState = CheckState.Checked Then
        ''        AcctIDList = AcctIDList & aNode.Key & ", "
        ''    End If
        ''Next aNode
        ''If Len(AcctIDList) > 1 Then
        ''    AcctIDList = AcctIDList.Substring(0, Len(AcctIDList) - Len(", ")) & ")"
        ''Else
        ''    AcctIDList = "(-1)"
        ''End If

        'v3... All Accounts will be saved even no svc. but update formatID

        'PopulateDataset2(dtAdapter, dtSet, "Select * from " & Me.Tag & " Where HDate = '" & cboHDate.Text & "' AND AccountID not in " & AcctIDList & " AND FormatID = " & cboFormat.SelectedValue)
        'If Not dtSet Is Nothing Then
        '    If dtSet.Tables(0).Rows.Count > 0 Then
        '        For Each row In dtSet.Tables(0).Rows
        '            AcctUnChkList = AcctUnChkList & row("AccountID") & ", "
        '        Next
        '        AcctUnChkList = AcctUnChkList.Substring(0, Len(AcctUnChkList) - Len(", ")) & ")"
        '        If MessageBox.Show("These accounts will be deleted from this holiday : " & AcctUnChkList & ", Continue?", "Remove Accounts from Holiday Notices", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '        ExecuteQuery("Delete from Notices Where HDate = '" & cboHDate.Text & "' and AccountID in " & AcctUnChkList & " AND FormatID = " & cboFormat.SelectedValue)

        '    End If
        'End If
        If AccountsTree.Nodes.Count <= 0 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        For Each aNode In AccountsTree.Nodes(0).Nodes
            TagFix = aNode.Tag

            'SqteLoc = InStr(TagFix, "'", CompareMethod.Text)
            'If SqteLoc > 0 Then
            '    TagFix = TagFix.Insert(SqteLoc, "'")
            'End If

            TagFix = TagFix.Replace("'", "''")
            TagFix = TagFix.Trim
            'tagfix.Replace("'", "''")
            If Not ReturnRowByID(aNode.Key, row, Me.Tag, "AND HDate = '" & cboHDate.Text & "'", "AccountID") Then
                If aNode.CheckedState = CheckState.Unchecked Then
                    ExecuteQuery("Insert Into " & Me.Tag & "(FormatID, HDate, AccountID, AccountName, NeedService) (Select '0', '" & cboHDate.Text & "', '" & aNode.Key & "', '" & TagFix & "', ((((c.HolidaySvcMj * 2) & h.type) + ((c.HolidayNoticeMj * 2) & h.type)) % 4) / 2 + (((c.HolidaySvcMn & h.type) + (c.HolidayNoticeMn & h.type)) % 2) as NeedSvc from " & AppTblPath & "Customer c, " & HOLIDAYSTblPath & "Holidays h where c.Status = 1 and h.hdate = '" & cboHDate.Text & "' and c.id = '" & aNode.Key & "' )")
                    ''Select h.type, ((((c.HolidaySvcMj*2) & h.type + c.HolidayNoticeMj) % h.type) + ((c.HolidaySvcMn & h.type) + (c.HolidayNoticeMn) % h.type)) ^ 1 as NeedSvc from Customer c, Holidays h where c.Status = 1 and h.hdate = '10/21/2003' and c.id = 2804
                Else
                    ExecuteQuery("Insert Into " & Me.Tag & "(FormatID, HDate, AccountID, AccountName) values(" & cboFormat.SelectedValue & ", '" & cboHDate.Text & "', " & aNode.Key & ", '" & TagFix & "')")
                End If
                ''ExecuteQuery("Insert Into " & Me.Tag & "(FormatID, HDate, AccountID, AccountName) values(" & IIf(aNode.CheckedState = CheckState.Checked, 1, 0) * cboFormat.SelectedValue & ", '" & cboHDate.Text & "', " & aNode.Key & ", '" & TagFix & "')")
            Else
                If IIf(row.Item("FormatID") > 0, 1, 0) <> Val(aNode.CheckedState) Then '= CheckState.Unchecke
                    ExecuteQuery("Update " & Me.Tag & " SET FormatID = " & IIf(aNode.CheckedState = CheckState.Checked, 1, 0) * cboFormat.SelectedValue & ", Responded = 0, NeedService = 0, NoService = 0 where AccountID = '" & aNode.Key & "' and HDate = '" & cboHDate.Text & "'")
                End If
                'ExecuteQuery("Update " & Me.Tag & " SET FormatID = " & IIf(aNode.CheckedState = CheckState.Checked, 1, 0) * cboFormat.SelectedValue & ", NeedService = 0 where AccountID = " & aNode.Key & " and HDate = '" & cboHDate.Text & "'")
            End If
            'If aNode.CheckedState = CheckState.Checked Then
            '    'AcctIDList = AcctIDList & aNode.Key & ", "
            'End If
        Next aNode
        Me.Cursor = Cursors.Default


        'v2.....

        'PopulateDataset2(dtAdapter, dtSet, "Select * from " & Me.Tag & " Where HDate = '" & cboHDate.Text & "' AND AccountID not in " & AcctIDList & " AND FormatID = " & cboFormat.SelectedValue)
        'If Not dtSet Is Nothing Then
        '    If dtSet.Tables(0).Rows.Count > 0 Then
        '        For Each row In dtSet.Tables(0).Rows
        '            AcctUnChkList = AcctUnChkList & row("AccountID") & ", "
        '        Next
        '        AcctUnChkList = AcctUnChkList.Substring(0, Len(AcctUnChkList) - Len(", ")) & ")"
        '        If MessageBox.Show("These accounts will be deleted from this holiday : " & AcctUnChkList & ", Continue?", "Remove Accounts from Holiday Notices", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '        ExecuteQuery("Delete from Notices Where HDate = '" & cboHDate.Text & "' and AccountID in " & AcctUnChkList & " AND FormatID = " & cboFormat.SelectedValue)

        '    End If
        'End If
        'For Each aNode In AccountsTree.Nodes(0).Nodes
        '    If aNode.CheckedState = CheckState.Checked Then
        '        'AcctIDList = AcctIDList & aNode.Key & ", "
        '        TagFix = aNode.Tag
        '        SqteLoc = InStr(TagFix, "'", CompareMethod.Text)
        '        If SqteLoc > 0 Then
        '            TagFix = TagFix.Insert(SqteLoc, "'")
        '        End If
        '        If Not ReturnRowByID(aNode.Key, row, Me.Tag, "AND HDate = '" & cboHDate.Text & "'", "AccountID") Then
        '            ExecuteQuery("Insert Into " & Me.Tag & "(FormatID, HDate, AccountID, AccountName) values(" & cboFormat.SelectedValue & ", '" & cboHDate.Text & "', " & aNode.Key & ", '" & TagFix & "')")
        '        End If
        '    End If
        'Next aNode



        'If ExecuteQuery("Delete from Notices Where HDate = '" & cboHDate.Text & "' and AccountID in " & AcctIDList) Then
        '    'AcctIDList = "("
        '    For Each aNode In AccountsTree.Nodes(0).Nodes
        '        If aNode.CheckedState = CheckState.Checked Then
        '            'AcctIDList = AcctIDList & aNode.Key & ", "
        '            TagFix = aNode.Tag
        '            SqteLoc = InStr(TagFix, "'", CompareMethod.Text)
        '            If SqteLoc > 0 Then
        '                TagFix = TagFix.Insert(SqteLoc, "'")
        '            End If
        '            ExecuteQuery("Insert Into " & Me.Tag & "(FormatID, HDate, AccountID, AccountName) values(" & cboFormat.SelectedValue & ", '" & cboHDate.Text & "', " & aNode.Key & ", '" & TagFix & "')")
        '        End If
        '    Next aNode
        '    'AcctIDList = AcctIDList.Substring(0, Len(AcctIDList) - Len(", ")) & ")"
        '    Me.Text = MeText & " - Data Saved..."
        'Else
        '    Me.Text = MeText & " - Data NOT Saved!"
        'End If
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        'Fill the AppearanceTree
        PopulateAccountsTree()
        AccountsTree.Override.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Extended
        AccountsTree.HideSelection = False

    End Sub

    Private Sub cboHDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHDate.SelectedIndexChanged
        AccountsTree.Nodes.Clear()
    End Sub
    'Dim WithEvents oApp As Word.Application

    Private Function WordTest()
        Dim W_Doc As Word.Document
        Dim x As Word.MailMerge
        Dim row As DataRow
        Dim FileName As String
        Dim FormatQuery As String = "Select FileName From " & HOLIDAYSTblPath & "NoticeFormats where ID = " & cboFormat.ValueMember
        Dim ERR As Boolean = False
        Dim Asm As System.Reflection.Assembly = _
              System.Reflection.Assembly.GetExecutingAssembly
        Dim strConfigLoc As String

        If Not W_App Is Nothing Then
            W_App = Nothing
        End If
        W_App = New Word.Application

        strConfigLoc = Asm.Location

        ' The config file is located in the application's bin directory, so
        ' you need to remove the file name.
        Dim strTemp As String
        strTemp = strConfigLoc
        strTemp = System.IO.Path.GetDirectoryName(strConfigLoc)


        If ReturnRowByID(cboFormat.SelectedValue, row, HOLIDAYSTblPath & "NoticeFormats") Then
            FileName = row("FileName")
        Else
            MessageBox.Show("Format Not Found!")
            Exit Function
        End If

        Dim ConnStr As String = "XLODBC" & vbCrLf & "1" & vbCrLf & "DRIVER=SQL Server;SERVER=" & IPAddr & ";UID=" & HOLIDAYSDBUser & ";PWD=" & HOLIDAYSDBPass & ";APP=Microsoft Open Database Connectivity;WSID=ADMINPC;Network=DBMSSOCN;Address=" & IPAddr & ",1433"
        'Ali Test: Dim ConnStr2 As String = "DSN=Holiday.DSN;UID=" & HOLIDAYSDBUser & "; PWD=" & HOLIDAYSDBPass & ";"  'UID=holiday;PWD=holiday;"
        'Dim Query As String = "Select n.AccountName, h.charge from HolidaysModule.dbo.Notices n, Holidays h where n.HDate = h.Hdate AND n.HDate = '" & cboHDate.Text & "' AND n.FormatID = " & cboFormat.SelectedValue '& " OrderBy AccountName"
        Dim Query As String = "Select n.AccountName, n.AccountID, h.charge from " & HOLIDAYSTblPath & "Notices n, " & HOLIDAYSTblPath & "Holidays h where n.HDate = h.Hdate AND n.HDate = '" & cboHDate.Text & "' AND n.FormatID = " & cboFormat.SelectedValue & " Order By n.AccountID"

        W_Doc = W_App.Documents.Open(FileName) '"C :\Documents and Settings\Administrator\My Documents\HelloMailMerge.doc"

        W_App.Visible = True

        Try
            'W_Doc.MailMerge.OpenDataSource("", connection:=ConnStr2, sqlstatement:=Query)
            WriteFile("Notice.dqy", ConnStr & vbCrLf & Query)
            W_Doc.MailMerge.OpenDataSource(strTemp & "\Notice.dqy") 'C :\Sources\HolidaysModule\Bin
        Catch e1 As System.Runtime.InteropServices.COMException
            W_App = Nothing
            MessageBox.Show(e1.Message)
            'W_Doc.Close()
            'W_App.Quit()
            ERR = True
            Exit Function
        Finally
            If ERR = False Then
                With W_Doc
                    .MailMerge.Destination = WdMailMergeDestination.wdSendToNewDocument 'wdSendToNewDocument
                    .MailMerge.Execute(Pause:=False)
                End With

                W_App.Visible = True
                'W_Doc.Close()
                'W_App.Quit()
            End If
        End Try


        'MsgBox("Mail Merge Complete: " & W_App.ActiveDocument.Name)
        'W_Doc.Close(False)

    End Function

    Private Sub W_App_MailMergeAfterMerge(ByVal Doc As Word.Document, ByVal DocResult As Word.Document)

        'When the mail merge is complete, 1) make Word visible,
        '2) close the mail merge document leaving only the resulting document
        'open and 3) display a message.
        'Doc.Close(False)

    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        WordTest()
    End Sub

    Private Function WriteFile(ByVal FileName As String, ByVal sBuffer As String)
        Dim FileBuffer As New IO.FileStream(FileName, IO.FileMode.Create)

        FileBuffer.Seek(0, IO.SeekOrigin.Begin)
        Dim x As New IO.StreamWriter(FileBuffer)

        x.Write(sBuffer)
        x.Close()
        FileBuffer.Close()
    End Function

    Private Sub cboFormat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFormat.SelectedIndexChanged
        AccountsTree.Nodes.Clear()
    End Sub

End Class
