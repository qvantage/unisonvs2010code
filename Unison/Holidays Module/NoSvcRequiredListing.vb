Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class NoSvcRequiredListing
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = "SELECT a.AccountID, c.Name AS Account, a.ID AS SID, a.OfficeID, " & _
                              " so.Name AS Office, a.CompName AS Location, a.Street, a.CityName AS City, a.State, a.ZipCode " & _
                              " From " & ROUTESTblPath & "AccountServices a, " & AppTblPath & "Customer c, " & AppTblPath & "ServiceOffices so WHERE a.accountid = c.id AND a.officeid = so.id AND " & _
                              " a.AccountID @AcctID AND " & _
                              " c.subjholiday = 0 " & _
                            " UNION " & _
                            " SELECT a.AccountID, c.Name AS Account, a.ID AS SID, a.OfficeID, " & _
                            " so.Name AS Office, a.CompName AS Location, a.Street, " & _
                            " a.CityName AS City, a.State, a.ZipCode From " & ROUTESTblPath & "AccountServices a, " & AppTblPath & "Customer c, " & AppTblPath & "ServiceOffices so, " & _
                            " " & HOLIDAYSTblPath & "notices n WHERE a.accountid = c.id AND a.officeid = so.id AND " & _
                            " a.AccountID @AcctID AND " & _
                            " n.AccountID = a.accountid And n.NoService = 1 " & _
                            " UNION " & _
                            " SELECT a.AccountID, c.Name AS Account, a.ID AS SID, a.OfficeID, " & _
                            " so.Name AS Office, a.CompName AS Location, a.Street, " & _
                            " a.CityName AS City, a.State, a.ZipCode " & _
                            " From " & ROUTESTblPath & "AccountServices a, " & AppTblPath & "Customer c, " & AppTblPath & "ServiceOffices so, " & _
                            HOLIDAYSTblPath & " notices n WHERE a.accountid = c.id AND a.officeid = so.id AND " & _
                            " n.AccountID = a.accountid AND n.NeedService = 1 AND " & _
                            " a.AccountID @AcctID AND " & _
                            " a.ID NOT IN (SELECT hrte.ServiceID From " & HOLIDAYSTblPath & "holidayroutes hrte " & _
                            " WHERE hrte.hdate = @HDate AND hrte.accountid = a.accountid) "

    'Dim Template As Infragistics.Win.UltraWinGrid.UltraGridDisplayLayout()

    Dim TemplateID As Integer
    Dim Template As String

    Dim sqlCondition As String

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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AcctID As System.Windows.Forms.TextBox
    Friend WithEvents Account As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboHDate As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.AcctID = New System.Windows.Forms.TextBox()
        Me.Account = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboHDate = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem4})
        Me.MenuItem1.Text = "Templates"
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
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "Delete"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkExpandAll, Me.btnPreview, Me.btnExit})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 401)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 40)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Location = New System.Drawing.Point(176, 16)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(96, 16)
        Me.chkExpandAll.TabIndex = 17
        Me.chkExpandAll.Text = "Expand All"
        '
        'btnPreview
        '
        Me.btnPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPreview.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPreview.Location = New System.Drawing.Point(3, 16)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 21)
        Me.btnPreview.TabIndex = 5
        Me.btnPreview.Text = "Pre&view"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(714, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'Panel2
        '
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2})
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(792, 48)
        Me.Panel2.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.AcctID, Me.Account, Me.Label1, Me.cboHDate, Me.Label12, Me.btnDisplay})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(792, 48)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'AcctID
        '
        Me.AcctID.Location = New System.Drawing.Point(584, 16)
        Me.AcctID.Name = "AcctID"
        Me.AcctID.Size = New System.Drawing.Size(21, 20)
        Me.AcctID.TabIndex = 74
        Me.AcctID.Text = ""
        Me.AcctID.Visible = False
        '
        'Account
        '
        Me.Account.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Account.Location = New System.Drawing.Point(328, 16)
        Me.Account.Name = "Account"
        Me.Account.Size = New System.Drawing.Size(248, 20)
        Me.Account.TabIndex = 73
        Me.Account.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(256, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Account:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboHDate
        '
        Me.cboHDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDate.Location = New System.Drawing.Point(96, 16)
        Me.cboHDate.Name = "cboHDate"
        Me.cboHDate.Size = New System.Drawing.Size(144, 21)
        Me.cboHDate.TabIndex = 72
        Me.cboHDate.Tag = ".HDate...Holidays.ID.Convert(Varchar,HDate,101)..HDate"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(24, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Holiday :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDisplay
        '
        Me.btnDisplay.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDisplay.Location = New System.Drawing.Point(704, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(75, 21)
        Me.btnDisplay.TabIndex = 6
        Me.btnDisplay.Text = "Dis&play"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 48)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(792, 353)
        Me.UltraGrid1.TabIndex = 9
        Me.UltraGrid1.Text = "Required Services"
        '
        'NoSvcRequiredListing
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 441)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.UltraGrid1, Me.Panel2, Me.GroupBox1})
        Me.Menu = Me.MainMenu1
        Me.Name = "NoSvcRequiredListing"
        Me.Tag = "NoSvcRequiredListing"
        Me.Text = "No Service Required Listing"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub NoSvcRequiredListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HOLIDAYSTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        FillCombo(cboHDate, "", "", "", HOLIDAYSTblPath)
        '" Where year(hdate) in (" & Date.Today.Year & ", " & Date.Today.Year + 1 & ")"

    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim TempQuery As String

        TempQuery = SQLSelect.Replace("@HDate", "'" & cboHDate.Text & "'")
        If AcctID.Text = "" Then
            TempQuery = TempQuery.Replace("@AcctID", " >= 0 ")
        Else
            TempQuery = TempQuery.Replace("@AcctID", " = " & AcctID.Text)
        End If

        PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(TempQuery, ""))

        FillUltraGrid(UltraGrid1, dtSet, 0)
        'UGLoadListingLayout(UltraGrid1, TemplateID)
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.Text = MeText

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            UltraGrid1.PrintPreview()
        Catch ex As System.Data.SqlClient.SqlException
            'Message modified by Michael Pastor
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Catch Err As System.Exception
            'Message modified by Michael Pastor
            MsgBox("Error: " & Err.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & Err.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Catch Err2 As System.NullReferenceException
            'Message modified by Michael Pastor
            MsgBox("Error: " & Err2.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & Err2.Message, MsgBoxStyle.Critical, "")
            Exit Try
        Finally
        End Try

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub
    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement
            Dim oUIElement As Infragistics.Win.UIElement
            Dim oUIElementTmp As Infragistics.Win.UIElement
            Dim point As Point = New Point(e.X, e.Y)


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
                'CntMenu1.MenuItems.Add("Find", New EventHandler(AddressOf mnuFind_Click))
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

    Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
        If chkExpandAll.Checked Then
            Me.UltraGrid1.Rows.ExpandAll(True)
        Else
            Me.UltraGrid1.Rows.CollapseAll(True)
        End If
    End Sub



    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click ' Load Template
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select ID, Name From " & AppTblPath & "ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

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
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                '- MsgBox("SQL_Error: " & osqlexception.Message)
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
            'Message modified by Michael Pastor
            MsgBox("Unable to save template.", MsgBoxStyle.Exclamation, "Data Not Saved")
            '- MsgBox("Failed")
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()

        SelectSQL = "Select ID, Name From " & AppTblPath & "ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

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

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        LoadData()
    End Sub

    Private Sub RequiredServicesListing_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        dtSet.Dispose()
        dtSet = Nothing
    End Sub

    Private Sub Account_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Account.KeyUp
        TypeAhead(sender, e, HOLIDAYSTblPath & "Notices", "AccountName", "HDate = '" & cboHDate.Text & "'")
        'sender.modified = True
    End Sub

    Private Sub Account_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Account.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            AcctID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, AcctID, HOLIDAYSTblPath & "Notices", "AccountID", "AccountName", "", "Accounts Responded", "NeedService = 1") Then
            If ReturnRowByID(AcctID.Text, row, AppTblPath & "Customer") Then
                Account.Text = row("Name")
                'row.Table.DataSet = Nothing
                row = Nothing
                'LoadData()
            End If
        End If
    End Sub

    Private Sub cboHDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHDate.SelectedIndexChanged
        UltraGrid1.DataSource = Nothing
        AcctID.Text = ""
        Account.Text = ""
    End Sub

End Class
