Public Class frmSearchInfo
    Inherits System.Windows.Forms.Form
    Private m_owningForm As Object 'WeightPlanListing1
    Private m_columnName As String

    '' The next 3 lines have neen added to self contain search screen and are used in search routines
    '' imported from owning form.
    Private m_UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid
    Private m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Private O_searchInfo As clsSearchInfo

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
    Friend WithEvents lblFindWhat As System.Windows.Forms.Label
    Friend WithEvents cboFindWhat As System.Windows.Forms.ComboBox
    Friend WithEvents cmdFindNext As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboLookIn As System.Windows.Forms.ComboBox
    Friend WithEvents lblLookIn As System.Windows.Forms.Label
    Friend WithEvents lblMatch As System.Windows.Forms.Label
    Friend WithEvents chkMatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchDirection As System.Windows.Forms.ComboBox
    Friend WithEvents lblSearchDirection As System.Windows.Forms.Label
    Friend WithEvents cboMatch As System.Windows.Forms.ComboBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblFindWhat = New System.Windows.Forms.Label()
        Me.cboFindWhat = New System.Windows.Forms.ComboBox()
        Me.cmdFindNext = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cboLookIn = New System.Windows.Forms.ComboBox()
        Me.lblLookIn = New System.Windows.Forms.Label()
        Me.cboMatch = New System.Windows.Forms.ComboBox()
        Me.lblMatch = New System.Windows.Forms.Label()
        Me.cboSearchDirection = New System.Windows.Forms.ComboBox()
        Me.lblSearchDirection = New System.Windows.Forms.Label()
        Me.chkMatchCase = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lblFindWhat
        '
        Me.lblFindWhat.AutoSize = True
        Me.lblFindWhat.Location = New System.Drawing.Point(8, 16)
        Me.lblFindWhat.Name = "lblFindWhat"
        Me.lblFindWhat.Size = New System.Drawing.Size(59, 13)
        Me.lblFindWhat.TabIndex = 0
        Me.lblFindWhat.Text = "Find What:"
        '
        'cboFindWhat
        '
        Me.cboFindWhat.Location = New System.Drawing.Point(72, 14)
        Me.cboFindWhat.Name = "cboFindWhat"
        Me.cboFindWhat.Size = New System.Drawing.Size(248, 21)
        Me.cboFindWhat.TabIndex = 1
        '
        'cmdFindNext
        '
        Me.cmdFindNext.Location = New System.Drawing.Point(352, 16)
        Me.cmdFindNext.Name = "cmdFindNext"
        Me.cmdFindNext.TabIndex = 2
        Me.cmdFindNext.Text = "Find Next"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(352, 48)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        '
        'cboLookIn
        '
        Me.cboLookIn.Location = New System.Drawing.Point(72, 72)
        Me.cboLookIn.Name = "cboLookIn"
        Me.cboLookIn.Size = New System.Drawing.Size(168, 21)
        Me.cboLookIn.TabIndex = 5
        '
        'lblLookIn
        '
        Me.lblLookIn.AutoSize = True
        Me.lblLookIn.Location = New System.Drawing.Point(8, 72)
        Me.lblLookIn.Name = "lblLookIn"
        Me.lblLookIn.Size = New System.Drawing.Size(44, 13)
        Me.lblLookIn.TabIndex = 4
        Me.lblLookIn.Text = "Look In:"
        '
        'cboMatch
        '
        Me.cboMatch.Location = New System.Drawing.Point(72, 104)
        Me.cboMatch.Name = "cboMatch"
        Me.cboMatch.Size = New System.Drawing.Size(168, 21)
        Me.cboMatch.TabIndex = 7
        '
        'lblMatch
        '
        Me.lblMatch.AutoSize = True
        Me.lblMatch.Location = New System.Drawing.Point(8, 104)
        Me.lblMatch.Name = "lblMatch"
        Me.lblMatch.Size = New System.Drawing.Size(38, 13)
        Me.lblMatch.TabIndex = 6
        Me.lblMatch.Text = "Match:"
        '
        'cboSearchDirection
        '
        Me.cboSearchDirection.Location = New System.Drawing.Point(72, 160)
        Me.cboSearchDirection.Name = "cboSearchDirection"
        Me.cboSearchDirection.Size = New System.Drawing.Size(168, 21)
        Me.cboSearchDirection.TabIndex = 9
        '
        'lblSearchDirection
        '
        Me.lblSearchDirection.AutoSize = True
        Me.lblSearchDirection.Location = New System.Drawing.Point(8, 160)
        Me.lblSearchDirection.Name = "lblSearchDirection"
        Me.lblSearchDirection.Size = New System.Drawing.Size(43, 13)
        Me.lblSearchDirection.TabIndex = 8
        Me.lblSearchDirection.Text = "Search:"
        '
        'chkMatchCase
        '
        Me.chkMatchCase.Location = New System.Drawing.Point(256, 160)
        Me.chkMatchCase.Name = "chkMatchCase"
        Me.chkMatchCase.Size = New System.Drawing.Size(96, 24)
        Me.chkMatchCase.TabIndex = 10
        Me.chkMatchCase.Text = "Match Case"
        '
        'frmSearchInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(442, 207)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkMatchCase, Me.cboSearchDirection, Me.lblSearchDirection, Me.cboMatch, Me.lblMatch, Me.cboLookIn, Me.lblLookIn, Me.cmdCancel, Me.cmdFindNext, Me.cboFindWhat, Me.lblFindWhat})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSearchInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Find"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSearchInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = AppTblPath & Me.Tag
            End If
        End If

        Me.PopulateLookInCombo()
        Me.PopulateSearchContentCombo()
        Me.PopulateSearchDirectionCombo()
    End Sub

    Public Sub ShowMe(ByVal owningForm As Form, ByVal columnName As String, ByRef SearchGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByRef m_searchInfo As Object) ' ByVal owningForm As WeightPlanListing1

        Me.m_owningForm = owningForm
        Me.m_columnName = columnName
        Me.m_UltraGrid = SearchGrid
        Me.O_searchInfo = m_searchInfo

        Me.CancelButton = Me.cmdCancel
        Me.KeyPreview = True

        '   Repopulate this, in case the search column has changed
        Me.PopulateLookInCombo()

        '   Show the form, bring it to the foreground
        Me.TopMost = True
        Me.Show()
        Me.BringToFront()

    End Sub

    Private Sub PopulateLookInCombo()
        Me.cboLookIn.Items.Clear()
        Me.cboLookIn.Items.Add(Me.m_columnName)
        Me.cboLookIn.Items.Add("All columns")
        Me.cboLookIn.SelectedIndex = 0
    End Sub

    Private Sub PopulateSearchDirectionCombo()

        Me.cboSearchDirection.Items.Clear()

        Dim values As Array
        Dim names As String()

        values = System.Enum.GetValues(GetType(SearchDirectionEnum))
        names = System.Enum.GetNames(GetType(SearchDirectionEnum))

        Dim i As Integer
        For i = 0 To names.Length - 1
            Me.cboSearchDirection.Items.Add(names(i))
        Next

        Me.cboSearchDirection.Tag = values
        Me.cboSearchDirection.SelectedIndex = 0

    End Sub

    Private Sub PopulateSearchContentCombo()

        Me.cboMatch.Items.Clear()

        Dim values As Array
        Dim names As String()

        values = System.Enum.GetValues(GetType(SearchContentEnum))
        names = System.Enum.GetNames(GetType(SearchContentEnum))

        Dim i As Integer
        For i = 0 To names.Length - 1
            Me.cboMatch.Items.Add(names(i))
        Next

        Me.cboMatch.Tag = values
        Me.cboMatch.SelectedIndex = 0

    End Sub

    Private Sub ProcessSearch()

        '   Set the demo form's SearchInfo properties
        ''Me.m_owningForm.SearchInfo.searchString = Me.cboFindWhat.Text
        ''Me.m_owningForm.SearchInfo.searchDirection = Me.cboSearchDirection.Tag(Me.cboSearchDirection.SelectedIndex)
        ''Me.m_owningForm.SearchInfo.searchContent = Me.cboMatch.Tag(Me.cboMatch.SelectedIndex)
        ''Me.m_owningForm.SearchInfo.matchCase = Me.chkMatchCase.Checked
        ''Me.m_owningForm.SearchInfo.lookIn = Me.cboLookIn.Text



        Me.SearchInfo.searchString = Me.cboFindWhat.Text
        Me.SearchInfo.searchDirection = Me.cboSearchDirection.Tag(Me.cboSearchDirection.SelectedIndex)
        Me.SearchInfo.searchContent = Me.cboMatch.Tag(Me.cboMatch.SelectedIndex)
        Me.SearchInfo.matchCase = Me.chkMatchCase.Checked
        Me.SearchInfo.lookIn = Me.cboLookIn.Text

        '   Add the search string to the combobox, ala MRU
        '   Also limit its capacity to 10 items
        If Not Me.cboFindWhat.Items.Contains(Me.cboFindWhat.Text) Then
            Me.cboFindWhat.Items.Insert(0, Me.cboFindWhat.Text)
            If Me.cboFindWhat.Items.Count > 10 Then
                Me.cboFindWhat.Items.RemoveAt(10)
            End If
        End If

        '   Call the demo form's Search method
        ''Me.m_owningForm.Search()
        Me.Search()

    End Sub

    Private Sub cmdFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindNext.Click
        ProcessSearch()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
    End Sub

    Private Sub frmSearchInfo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        '   Real useful. When a combobox has focus, KeyPreview is ignored
        If e.KeyValue = Keys.Enter Then Me.ProcessSearch()
        If e.KeyValue = Keys.Escape Then Me.Hide()

    End Sub

    Private Sub cboFindWhat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFindWhat.KeyDown
        If e.KeyValue = Keys.Enter Then Me.ProcessSearch()
        If e.KeyValue = Keys.Escape Then Me.Hide()
    End Sub

    '==========================================================================================================
    '==========================================================================================================
    '==========================================================================================================
    '==========================================================================================================
    '==========================================================================================================
    '==========================================================================================================
    '==========================================================================================================



    Public Sub Search()

        '   See if there is an active row; if there is, use it, otherwise
        '   activate the first row and start the search from there
        Dim oRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        oRow = m_UltraGrid.ActiveRow
        If oRow Is Nothing Then oRow = m_UltraGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)

        '   Use the row object's GetSibling method to iterate through the rows
        '   and check the appropriate cell values

        '   Downward search
        If Me.O_searchInfo.searchDirection = SearchDirectionEnum.Down Then
            While Not oRow Is Nothing
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
                If Me.MatchText(oRow) Then
                    m_UltraGrid.ActiveRow = oRow
                    If Not Me.m_oColumn Is Nothing Then
                        m_UltraGrid.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
                        m_UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
            End While

            '   Upward search
        ElseIf Me.O_searchInfo.searchDirection = SearchDirectionEnum.Up Then
            While Not oRow Is Nothing
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous)
                If Me.MatchText(oRow) Then
                    m_UltraGrid.ActiveRow = oRow
                    If Not Me.m_oColumn Is Nothing Then
                        m_UltraGrid.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
                        m_UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
            End While

            '   Search all rows. First, we start with the active row. If we don't find
            '   it by the time we hit the  last row, try again starting from the first row
        ElseIf Me.O_searchInfo.searchDirection = SearchDirectionEnum.All Then
            While Not oRow Is Nothing
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
                If Me.MatchText(oRow) Then
                    m_UltraGrid.ActiveRow = oRow
                    If Not Me.m_oColumn Is Nothing Then
                        m_UltraGrid.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
                        m_UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
            End While

            '   We didn't find it the first time around, so start again from the first row
            oRow = m_UltraGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)
            While Not oRow Is Nothing
                If Me.MatchText(oRow) Then
                    m_UltraGrid.ActiveRow = oRow
                    If Not Me.m_oColumn Is Nothing Then
                        m_UltraGrid.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
                        m_UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
            End While

        End If

        '   If we get this far, we didn't find the string, so show a message box
        'Message modified by Michael Pastor
        MsgBox("UltraGrid has searched all the records. The search item '" & Me.O_searchInfo.searchString & "' was not found.", MsgBoxStyle.Information, "Data Unavailable")
        '- MessageBox.Show("UltraGrid has searched all the records. The search item '" & Me.O_searchInfo.searchString & "' was not found.", "Infragistics UltraGrid", MessageBoxButtons.OK, MessageBoxIcon.None)

    End Sub

    Private Function MatchText(ByVal oRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Boolean
        If oRow Is Nothing Then
            MatchText = False
            Exit Function
        End If
        If oRow.ListObject Is Nothing Then
            MatchText = False
            Exit Function
        End If

        Dim strColumnKey As String = Me.O_searchInfo.lookIn
        Dim oCol As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim strCellValue As String = ""

        '   Determine whether we are searching the current column or all columns
        Dim bSearchAllColumns = True
        If m_UltraGrid.DisplayLayout.Bands(0).Columns.Exists(strColumnKey) Then bSearchAllColumns = False

        '   If we are searching all columns then we must iterate through all the cells
        '    in this row, which we can do by using the band's Columns collection
        If bSearchAllColumns Then
            For Each oCol In m_UltraGrid.DisplayLayout.Bands(0).Columns
                If Not oRow.Cells(oCol.Key).Value Is Nothing And oRow.Cells(oCol.Key).Value.GetType.ToString <> "System.DBNull" Then
                    If Me.Match(Me.O_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
                        MatchText = True
                        Me.m_oColumn = oCol
                        Exit Function
                    End If
                End If
            Next
        Else
            oCol = m_UltraGrid.DisplayLayout.Bands(0).Columns(strColumnKey)
            If Not oRow.Cells(oCol.Key).Value Is Nothing Then
                If Me.Match(Me.O_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
                    MatchText = True
                    Me.m_oColumn = oCol
                    Exit Function
                End If
            End If
        End If

    End Function

    Private Function Match(ByVal userString As String, ByVal cellValue As String) As Boolean

        '   If our search is case insensitive, make both strings uppercase
        If Not Me.O_searchInfo.matchCase Then
            userString = userString.ToUpper
            cellValue = cellValue.ToUpper
        End If

        '   If we are searching any part of the cell value...
        If Me.O_searchInfo.searchContent = SearchContentEnum.AnyPartOfField Then

            '   If the user string is larger than the cell value, it is by definition
            '   a mismatch, so return false
            If userString.Length > cellValue.Length Then
                Match = False
                Exit Function
            ElseIf userString.Length = cellValue.Length Then
                '   If the lengths are equal, the strings must be equal as well
                If userString = cellValue Then Match = True Else Match = False
                Exit Function
            Else
                '   There is probably an easier way to do this
                Dim i As Integer
                For i = 0 To (cellValue.Length - userString.Length) - 0
                    If userString = cellValue.Substring(i, userString.Length) Then
                        Match = True
                        Exit Function
                    End If
                Next
                Match = False
                Exit Function

            End If

        ElseIf Me.O_searchInfo.searchContent = SearchContentEnum.WholeField Then
            If userString = cellValue Then Match = True Else Match = False
            Exit Function

        ElseIf Me.O_searchInfo.searchContent = SearchContentEnum.StartOfField Then
            If userString.Length >= cellValue.Length Then
                If userString.Substring(0, cellValue.Length) = cellValue Then
                    Match = True
                Else
                    Match = False
                End If
                Exit Function
            Else
                If cellValue.Substring(0, userString.Length) = userString Then Match = True Else Match = False
                Exit Function
            End If

        End If

    End Function

    Public ReadOnly Property SearchInfo()
        Get
            SearchInfo = Me.O_searchInfo
        End Get
    End Property

End Class
