Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class RteSvcGroupMembersListing
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = "SELECT sgm.AccountID, c.Name AS Account, sgm.SGroupID, g.Name as [Group Name], sgm.SID AS SID " & _
                    ", asv.CompName as [Location Name], asv.Street, asv.CityName as City, asv.ZipCode " & _
                    ", asv.StartDate, asv.EndDate, asv.charge, asv.Remarks as [Service Remarks], asv.OpenTime, asv.CloseTime, asv.DoorKey " & _
                    ", asv.BoxKey, asv.InternalRef as [Internal Ref], asv.AccountRef as [Acct. Ref], tf.Name as [Tme.Frm]" & _
                    ", svc.Name as [Service], svctp.Name as [Svc.Type], p.Name as Package, asv.SchedType, asv.NonPrintRemark " & _
                    ",(Select top 1 m.OfficeID FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id order by m.Day) as [Office ID]" & _
                    ",(Select top 1 m.RouteNo FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id order by m.Day) as Rte" & _
                    ",(Select top 1 m.StopNo FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id order by m.Day) as Stp" & _
                    ",(case isnull((SELECT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 1), 0) when '1' then 'Y' else 'N' end) as Mo " & _
                    ",(case isnull((SELECT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 2), 0) when '2' then 'Y' else 'N' end) as Tu " & _
                    ",(case isnull((SELECT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 3), 0) when '3' then 'Y' else 'N' end) as We" & _
                    ",(case isnull((SELECT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 4), 0) when '4' then 'Y' else 'N' end) as Th" & _
                    ",(case isnull((SELECT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 5), 0) when '5' then 'Y' else 'N' end) as Fr" & _
                    ",(case isnull((SELECT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 6), 0) when '6' then 'Y' else 'N' end) as Sa" & _
                    ",(case isnull((SELECT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 7), 0) when '7' then 'Y' else 'N' end) as Su" & _
                    " from (((((((" & ROUTESTblPath & "ServiceGroupMembers sgm left outer join " & ROUTESTblPath & "AccountServices asv on sgm.accountID = asv.accountid and sgm.SID = asv.id)" & _
                    " left outer join " & AppTblPath & "Customer c on sgm.accountID = c.ID) left outer join " & ROUTESTblPath & "TimeFrames tf on asv.TimeFrameID = tf.ID) " & _
                    " left outer join " & AppTblPath & "Services as svc on asv.ServiceID = svc.ID) left outer join " & AppTblPath & "ServiceTypes svctp on asv.ServiceTypeID = svctp.ID)" & _
                    " left outer join " & AppTblPath & "PackageTypes as p on asv.PackageID = p.ID) left outer join " & ROUTESTblPath & "ServiceGroups g on sgm.SGroupID = g.ID)"
                    '" Where sgm.AccountID = " & AcctID.Text & " AND sgm.SGroupID = " & GrpID.text & ""

    Dim TemplateID As Integer
    Dim Template As String

    Dim sqlCondition As String

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim m_oRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing


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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AcctID As System.Windows.Forms.TextBox
    Friend WithEvents Account As System.Windows.Forms.TextBox
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoAllAccts As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAccount As System.Windows.Forms.RadioButton
    Friend WithEvents rdoGroup As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAllGroups As System.Windows.Forms.RadioButton
    Friend WithEvents Group As System.Windows.Forms.TextBox
    Friend WithEvents GrpID As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdoGroup = New System.Windows.Forms.RadioButton()
        Me.rdoAllGroups = New System.Windows.Forms.RadioButton()
        Me.Group = New System.Windows.Forms.TextBox()
        Me.GrpID = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdoAccount = New System.Windows.Forms.RadioButton()
        Me.rdoAllAccts = New System.Windows.Forms.RadioButton()
        Me.Account = New System.Windows.Forms.TextBox()
        Me.AcctID = New System.Windows.Forms.TextBox()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2})
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(872, 56)
        Me.Panel2.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox4, Me.GroupBox3})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(872, 56)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.rdoGroup, Me.rdoAllGroups, Me.Group, Me.GrpID})
        Me.GroupBox4.Location = New System.Drawing.Point(8, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(360, 41)
        Me.GroupBox4.TabIndex = 79
        Me.GroupBox4.TabStop = False
        '
        'rdoGroup
        '
        Me.rdoGroup.Location = New System.Drawing.Point(88, 12)
        Me.rdoGroup.Name = "rdoGroup"
        Me.rdoGroup.Size = New System.Drawing.Size(59, 24)
        Me.rdoGroup.TabIndex = 78
        Me.rdoGroup.Text = "Group:"
        '
        'rdoAllGroups
        '
        Me.rdoAllGroups.Location = New System.Drawing.Point(10, 10)
        Me.rdoAllGroups.Name = "rdoAllGroups"
        Me.rdoAllGroups.Size = New System.Drawing.Size(78, 24)
        Me.rdoAllGroups.TabIndex = 77
        Me.rdoAllGroups.Text = "All Groups"
        '
        'Group
        '
        Me.Group.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Group.Location = New System.Drawing.Point(146, 12)
        Me.Group.Name = "Group"
        Me.Group.Size = New System.Drawing.Size(158, 20)
        Me.Group.TabIndex = 73
        Me.Group.Text = ""
        '
        'GrpID
        '
        Me.GrpID.Enabled = False
        Me.GrpID.Location = New System.Drawing.Point(309, 12)
        Me.GrpID.Name = "GrpID"
        Me.GrpID.Size = New System.Drawing.Size(46, 20)
        Me.GrpID.TabIndex = 74
        Me.GrpID.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.rdoAccount, Me.rdoAllAccts, Me.Account, Me.AcctID})
        Me.GroupBox3.Location = New System.Drawing.Point(373, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(480, 41)
        Me.GroupBox3.TabIndex = 78
        Me.GroupBox3.TabStop = False
        '
        'rdoAccount
        '
        Me.rdoAccount.Location = New System.Drawing.Point(102, 12)
        Me.rdoAccount.Name = "rdoAccount"
        Me.rdoAccount.Size = New System.Drawing.Size(67, 24)
        Me.rdoAccount.TabIndex = 78
        Me.rdoAccount.Text = "Account:"
        '
        'rdoAllAccts
        '
        Me.rdoAllAccts.Location = New System.Drawing.Point(10, 12)
        Me.rdoAllAccts.Name = "rdoAllAccts"
        Me.rdoAllAccts.Size = New System.Drawing.Size(86, 24)
        Me.rdoAllAccts.TabIndex = 77
        Me.rdoAllAccts.Text = "All Accounts"
        '
        'Account
        '
        Me.Account.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Account.Location = New System.Drawing.Point(171, 13)
        Me.Account.Name = "Account"
        Me.Account.Size = New System.Drawing.Size(248, 20)
        Me.Account.TabIndex = 73
        Me.Account.Text = ""
        '
        'AcctID
        '
        Me.AcctID.Enabled = False
        Me.AcctID.Location = New System.Drawing.Point(427, 13)
        Me.AcctID.Name = "AcctID"
        Me.AcctID.Size = New System.Drawing.Size(46, 20)
        Me.AcctID.TabIndex = 74
        Me.AcctID.Text = ""
        '
        'btnDisplay
        '
        Me.btnDisplay.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDisplay.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnDisplay.Location = New System.Drawing.Point(3, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(75, 21)
        Me.btnDisplay.TabIndex = 6
        Me.btnDisplay.Text = "Dis&play"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Load"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Save As"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem4})
        Me.MenuItem1.Text = "Templates"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "Delete"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPreview, Me.btnExit, Me.btnDisplay})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 449)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(872, 40)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'btnPreview
        '
        Me.btnPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPreview.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPreview.Location = New System.Drawing.Point(78, 16)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 21)
        Me.btnPreview.TabIndex = 5
        Me.btnPreview.Text = "Pre&view"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(794, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 56)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(872, 393)
        Me.UltraGrid1.TabIndex = 10
        Me.UltraGrid1.Text = "Group Membership"
        '
        'RteSvcGroupMembersListing
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(872, 489)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.UltraGrid1, Me.GroupBox1, Me.Panel2})
        Me.Menu = Me.MainMenu1
        Me.Name = "RteSvcGroupMembersListing"
        Me.Tag = "ServiceGroupListing"
        Me.Text = "Service-Group Listing"
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub RteSvcGroupMembersListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        rdoAllAccts.Checked = True
        rdoAllGroups.Checked = True
    End Sub
    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            UltraGrid1.PrintPreview()
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Catch Err As System.Exception
            MsgBox("Error: " & Err.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Catch Err2 As System.NullReferenceException
            MsgBox("Error: " & Err2.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Finally
        End Try

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim TempQuery As String

        '" Where sgm.AccountID = " & AcctID.Text & " AND sgm.SGroupID = " & GrpID.text & ""
        If rdoAccount.Checked Then
            TempQuery = " Where sgm.AccountID = " & AcctID.Text
        End If
        If rdoGroup.Checked Then
            If TempQuery = "" Then
                TempQuery = " Where sgm.SGroupID = " & GrpID.Text
            Else
                TempQuery = TempQuery & " AND sgm.SGroupID = " & GrpID.Text
            End If
        End If

        'TempQuery = SQLSelect.Replace("@HDate", "'" & cboHDate.Text & "'")

        'If AcctID.Text = "" Then
        '    TempQuery = TempQuery.Replace("@AcctID", " >= 0 ")
        'Else
        '    TempQuery = TempQuery.Replace("@AcctID", " = " & AcctID.Text)
        'End If
        TempQuery = SQLSelect & TempQuery
        PopulateDataset2(dtAdapter, dtSet, TempQuery)

        FillUltraGrid(UltraGrid1, dtSet, 0)
        'UGLoadListingLayout(UltraGrid1, TemplateID)
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        Me.Text = MeText

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        LoadData()
    End Sub

    Private Sub RequiredServicesListing_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        dtSet.Dispose()
        dtSet = Nothing
    End Sub

    Private Sub Account_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Account.KeyUp
        TypeAhead(sender, e, AppTblPath & "CUSTOMER", "Name", "Status = 1")
        'sender.modified = True
    End Sub

    Private Sub Account_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Account.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            AcctID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, AcctID, AppTblPath & "Customer", "ID", "Name", "", "Accounts", "Status = 1") Then
            If ReturnRowByID(AcctID.Text, row, AppTblPath & "Customer") Then
                Account.Text = row("Name")
                'row.Table.DataSet = Nothing
                row = Nothing
                'LoadData()
            End If
        End If
    End Sub

    Private Sub Group_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Group.KeyUp
        TypeAhead(sender, e, ROUTESTblPath & "ServiceGroups", "Name", "")
        'sender.modified = True
    End Sub

    Private Sub Group_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Group.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            AcctID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, GrpID, ROUTESTblPath & "ServiceGroups", "ID", "Name", "", "Service Groups", "") Then
            If ReturnRowByID(GrpID.Text, row, ROUTESTblPath & "ServiceGroups") Then
                Group.Text = row("Name")
                'row.Table.DataSet = Nothing
                row = Nothing
                'LoadData()
            End If
        End If
    End Sub


    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown
        Dim oUIElement As Infragistics.Win.UIElement
        Dim oUIElementTmp As Infragistics.Win.UIElement
        Dim point As Point = New Point(e.X, e.Y)


        If e.Button = MouseButtons.Left Then
            Dim oRowUI As Infragistics.Win.UltraWinGrid.RowUIElement

            m_oRow = Nothing
            oUIElement = Me.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(point)

            If oUIElement Is Nothing Then Exit Sub

            oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.RowUIElement))
            If Not oUIElementTmp Is Nothing Then
                oRowUI = oUIElementTmp
                m_oRow = oRowUI.Row
                'If m_oRow Is Nothing Then Exit Sub
                Exit Sub
            End If
        End If

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement

            oUIElement = Me.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(point)
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
                    Return
                End If
            End If
            oUIElement = oUIElementTmp
            If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement) Then
                If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement) Then
                    Exit Sub
                Else
                    oCaptionUI = oUIElement
                End If
            Else
                oHeaderUI = oUIElement
            End If

            If oCaptionUI Is Nothing Then
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
                For Each ugcol In UltraGrid1.DisplayLayout.Bands(0).Columns
                    If ugcol.Hidden = True Then
                        CntMenu1.MenuItems(1).MenuItems.Add(ugcol.ToString, New EventHandler(AddressOf SubMnuUnHide_Click))
                    End If
                Next

                CntMenu1.Show(UltraGrid1, point)
            Else 'Caption Click
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("AutoFit", New EventHandler(AddressOf mnuAutoFit_Click))
                CntMenu1.MenuItems(0).Checked = UltraGrid1.DisplayLayout.AutoFitColumns
                CntMenu1.Show(UltraGrid1, point)

            End If


        End If

    End Sub

    Private Sub mnuAutoFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CntMenu1.MenuItems(0).Checked Then
            CntMenu1.MenuItems(0).Checked = False
        Else
            CntMenu1.MenuItems(0).Checked = True
        End If
        UltraGrid1.DisplayLayout.AutoFitColumns = CntMenu1.MenuItems(0).Checked

    End Sub

    Private Sub mnuHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuHide.Click
        If Not m_oColumn Is Nothing Then
            m_oColumn.Hidden = True
        End If
    End Sub
    Private Sub SubMnuUnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ugCol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        For Each ugCol In UltraGrid1.DisplayLayout.Bands(0).Columns
            If ugCol.ToString = sender.text Then
                ugCol.Hidden = False
            End If
        Next

    End Sub

    Private Sub mnuSortAsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortAsc.Click
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(m_oColumn, False)
    End Sub

    Private Sub mnuSortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortDesc.Click
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(Me.m_oColumn, True)
    End Sub

    Private Sub rdoAllAccts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAllAccts.CheckedChanged, rdoAccount.CheckedChanged
        If rdoAllAccts.Checked Then
            Account.Text = ""
            AcctID.Text = ""
            Account.Enabled = False
        Else
            Account.Enabled = True
        End If
    End Sub

    Private Sub rdoAllGroups_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAllGroups.CheckedChanged
        If rdoAllGroups.Checked = True Then
            Group.Text = ""
            GrpID.Text = ""
            Group.Enabled = False
        Else
            Group.Enabled = True
        End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click ' Load Template
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select ID, Name FROM " & AppTblPath & "ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings()
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Templates"
            Srch.Text = "Weight-Plan Listing Templates"
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
                MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow

                    TemplateID = ugRow.Cells("ID").Text
                    If Not UltraGrid1.DataSource Is Nothing Then
                        UGLoadListingLayout(UltraGrid1, TemplateID)
                    End If
                    Me.Text = MeText & " - Using Layout : " & ugRow.Cells("Name").Text
                    Template = ugRow.Cells("Name").Text
                End If
            End Try
            Srch = Nothing
        End If

    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Dim x As New EnterTextBox()

        x.Text = "Save Template"
        x.TextBox1.Text = Template
        x.TextBox2.Visible = False
        x.Label2.Visible = False
        x.ShowDialog()
        If x.DialogResult <> DialogResult.OK Then Exit Sub
        If Template <> x.TextBox1.Text.Trim Then
            TemplateID = 0
        End If
        Template = x.TextBox1.Text.Trim
        UGSaveListingLayout(Me, UltraGrid1, TemplateID, Template)
        x = Nothing
        If TemplateID = 0 Then
            MsgBox("Failed")
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()

        SelectSQL = "Select ID, Name FROM " & AppTblPath & "ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings()
            Srch.dsList = dtSet
            Srch.sqlSelect = SelectSQL
            Srch.btnDelete.Visible = True
            Srch.Button1.Enabled = False

            Srch.UltraGrid1.Text = "Templates"
            Srch.Text = "Weight-Plan Listing Templates"
            Srch.ShowDialog()
            'If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Srch = Nothing
        End If

    End Sub

    '=================================================================================================================
    '=================================================================================================================
    '================================             Search Routines              =======================================
    '=================================================================================================================

    Private m_searchForm As frmSearchInfo = Nothing
    Private m_searchInfo As clsSearchInfo = New clsSearchInfo()

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.m_oColumn Is Nothing Then Exit Sub

        If Me.m_searchForm Is Nothing Then
            Me.m_searchForm = New frmSearchInfo()
        End If

        Me.m_searchForm.ShowMe(Me, Me.m_oColumn.Key, UltraGrid1, m_searchInfo)

    End Sub

    '*********************************************************************************************************
    '*************************************** Search Routines  ************************************************
    '*********************************************************************************************************

    '' There are some lines that are double commented. They are matching lines for these routines.

    ''Public ReadOnly Property SearchInfo()
    ''    Get
    ''        SearchInfo = Me.m_searchInfo
    ''    End Get
    ''End Property

    ''Public Sub Search()

    ''    '   See if there is an active row; if there is, use it, otherwise
    ''    '   activate the first row and start the search from there
    ''    Dim oRow As Infragistics.Win.UltraWinGrid.UltraGridRow
    ''    oRow = Me.UltraGrid1.ActiveRow
    ''    If oRow Is Nothing Then oRow = Me.UltraGrid1.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)

    ''    '   Use the row object's GetSibling method to iterate through the rows
    ''    '   and check the appropriate cell values

    ''    '   Downward search
    ''    If Me.m_searchInfo.searchDirection = SearchDirectionEnum.Down Then
    ''        While Not oRow Is Nothing
    ''            oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
    ''            If Me.MatchText(oRow) Then
    ''                Me.UltraGrid1.ActiveRow = oRow
    ''                If Not Me.m_oColumn Is Nothing Then
    ''                    Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
    ''                    Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
    ''                End If
    ''                Exit Sub
    ''            End If
    ''        End While

    ''        '   Upward search
    ''    ElseIf Me.m_searchInfo.searchDirection = SearchDirectionEnum.Up Then
    ''        While Not oRow Is Nothing
    ''            oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous)
    ''            If Me.MatchText(oRow) Then
    ''                Me.UltraGrid1.ActiveRow = oRow
    ''                If Not Me.m_oColumn Is Nothing Then
    ''                    Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
    ''                    Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
    ''                End If
    ''                Exit Sub
    ''            End If
    ''        End While

    ''        '   Search all rows. First, we start with the active row. If we don't find
    ''        '   it by the time we hit the  last row, try again starting from the first row
    ''    ElseIf Me.m_searchInfo.searchDirection = SearchDirectionEnum.All Then
    ''        While Not oRow Is Nothing
    ''            oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
    ''            If Me.MatchText(oRow) Then
    ''                Me.UltraGrid1.ActiveRow = oRow
    ''                If Not Me.m_oColumn Is Nothing Then
    ''                    Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
    ''                    Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
    ''                End If
    ''                Exit Sub
    ''            End If
    ''        End While

    ''        '   We didn't find it the first time around, so start again from the first row
    ''        oRow = Me.UltraGrid1.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)
    ''        While Not oRow Is Nothing
    ''            If Me.MatchText(oRow) Then
    ''                Me.UltraGrid1.ActiveRow = oRow
    ''                If Not Me.m_oColumn Is Nothing Then
    ''                    Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
    ''                    Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
    ''                End If
    ''                Exit Sub
    ''            End If
    ''            oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
    ''        End While

    ''    End If

    ''    '   If we get this far, we didn't find the string, so show a message box
    ''    MessageBox.Show("UltraGrid has searched all the records. The search item '" & Me.m_searchInfo.searchString & "' was not found.", "Infragistics UltraGrid", MessageBoxButtons.OK, MessageBoxIcon.None)

    ''End Sub

    ''Private Function MatchText(ByVal oRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Boolean
    ''    If oRow Is Nothing Then
    ''        MatchText = False
    ''        Exit Function
    ''    End If
    ''    If oRow.ListObject Is Nothing Then
    ''        MatchText = False
    ''        Exit Function
    ''    End If

    ''    Dim strColumnKey As String = Me.m_searchInfo.lookIn
    ''    Dim oCol As Infragistics.Win.UltraWinGrid.UltraGridColumn
    ''    Dim strCellValue As String = ""

    ''    '   Determine whether we are searching the current column or all columns
    ''    Dim bSearchAllColumns = True
    ''    If Me.UltraGrid1.DisplayLayout.Bands(0).Columns.Exists(strColumnKey) Then bSearchAllColumns = False

    ''    '   If we are searching all columns then we must iterate through all the cells
    ''    '    in this row, which we can do by using the band's Columns collection
    ''    If bSearchAllColumns Then
    ''        For Each oCol In Me.UltraGrid1.DisplayLayout.Bands(0).Columns
    ''            If Not oRow.Cells(oCol.Key).Value Is Nothing Then
    ''                If Me.Match(Me.m_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
    ''                    MatchText = True
    ''                    Me.m_oColumn = oCol
    ''                    Exit Function
    ''                End If
    ''            End If
    ''        Next
    ''    Else
    ''        oCol = Me.UltraGrid1.DisplayLayout.Bands(0).Columns(strColumnKey)
    ''        If Not oRow.Cells(oCol.Key).Value Is Nothing Then
    ''            If Me.Match(Me.m_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
    ''                MatchText = True
    ''                Me.m_oColumn = oCol
    ''                Exit Function
    ''            End If
    ''        End If
    ''    End If

    ''End Function

    ''Private Function Match(ByVal userString As String, ByVal cellValue As String) As Boolean

    ''    '   If our search is case insensitive, make both strings uppercase
    ''    If Not Me.m_searchInfo.matchCase Then
    ''        userString = userString.ToUpper
    ''        cellValue = cellValue.ToUpper
    ''    End If

    ''    '   If we are searching any part of the cell value...
    ''    If Me.m_searchInfo.searchContent = SearchContentEnum.AnyPartOfField Then

    ''        '   If the user string is larger than the cell value, it is by definition
    ''        '   a mismatch, so return false
    ''        If userString.Length > cellValue.Length Then
    ''            Match = False
    ''            Exit Function
    ''        ElseIf userString.Length = cellValue.Length Then
    ''            '   If the lengths are equal, the strings must be equal as well
    ''            If userString = cellValue Then Match = True Else Match = False
    ''            Exit Function
    ''        Else
    ''            '   There is probably an easier way to do this
    ''            Dim i As Integer
    ''            For i = 0 To (cellValue.Length - userString.Length) - 0
    ''                If userString = cellValue.Substring(i, userString.Length) Then
    ''                    Match = True
    ''                    Exit Function
    ''                End If
    ''            Next
    ''            Match = False
    ''            Exit Function

    ''        End If

    ''    ElseIf Me.m_searchInfo.searchContent = SearchContentEnum.WholeField Then
    ''        If userString = cellValue Then Match = True Else Match = False
    ''        Exit Function

    ''    ElseIf Me.m_searchInfo.searchContent = SearchContentEnum.StartOfField Then
    ''        If userString.Length >= cellValue.Length Then
    ''            If userString.Substring(0, cellValue.Length) = cellValue Then
    ''                Match = True
    ''            Else
    ''                Match = False
    ''            End If
    ''            Exit Function
    ''        Else
    ''            If cellValue.Substring(0, userString.Length) = userString Then Match = True Else Match = False
    ''            Exit Function
    ''        End If

    ''    End If

    ''End Function

End Class
