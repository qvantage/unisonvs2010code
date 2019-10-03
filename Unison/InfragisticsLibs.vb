Module InfragisticsLibs
    Public FindWhat As String
    Public SearchDir As SearchDirectionEnum
    Public SearchCntnt As SearchContentEnum
    Public MatchCase As Boolean

    Private m_owningForm As Object 'WeightPlanListing1
    Private m_columnName As String

    '' The next 3 lines have neen added to self contain search screen and are used in search routines
    '' imported from owning form.
    Private m_UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid
    Private m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Private O_searchInfo As clsSearchInfo

    Public Sub SearchGrid(ByVal owningForm As Form, ByVal columnName As String, ByRef SearchGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByRef m_searchInfo As clsSearchInfo) ' ByVal owningForm As WeightPlanListing1

        If m_searchInfo.searchString.Trim = "" Then
            Exit Sub
        End If
        m_owningForm = owningForm
        m_columnName = columnName
        m_UltraGrid = SearchGrid
        O_searchInfo = m_searchInfo

        '   Set the demo form's SearchInfo properties
        ''Me.m_owningForm.SearchInfo.searchString = Me.cboFindWhat.Text
        ''Me.m_owningForm.SearchInfo.searchDirection = Me.cboSearchDirection.Tag(Me.cboSearchDirection.SelectedIndex)
        ''Me.m_owningForm.SearchInfo.searchContent = Me.cboMatch.Tag(Me.cboMatch.SelectedIndex)
        ''Me.m_owningForm.SearchInfo.matchCase = Me.chkMatchCase.Checked
        ''Me.m_owningForm.SearchInfo.lookIn = Me.cboLookIn.Text



        'SearchInfo.searchString = FindWhat
        'SearchInfo.searchDirection = SearchDir ' SearchDirectionEnum.Down
        'SearchInfo.searchContent = SearchCntnt 'SearchContentEnum.WholeField

        'SearchInfo.matchCase = MatchCase

        'SearchInfo.lookIn = m_columnName

        Search()

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
        '   Test
        '   activate the first row and start the search from there
        Dim oRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        oRow = m_UltraGrid.ActiveRow
        If oRow Is Nothing Then oRow = m_UltraGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)

        '   Use the row object's GetSibling method to iterate through the rows
        '   and check the appropriate cell values

        '   Downward search
        If O_searchInfo.searchDirection = SearchDirectionEnum.Down Then
            While Not oRow Is Nothing
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
                If MatchText(oRow) Then
                    m_UltraGrid.ActiveRow = oRow
                    If Not m_oColumn Is Nothing Then
                        m_UltraGrid.ActiveCell = oRow.Cells(m_oColumn.Key)
                        m_UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
            End While

            '   Upward search
        ElseIf O_searchInfo.searchDirection = SearchDirectionEnum.Up Then
            While Not oRow Is Nothing
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous)
                If MatchText(oRow) Then
                    m_UltraGrid.ActiveRow = oRow
                    If Not m_oColumn Is Nothing Then
                        m_UltraGrid.ActiveCell = oRow.Cells(m_oColumn.Key)
                        m_UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
            End While

            '   Search all rows. First, we start with the active row. If we don't find
            '   it by the time we hit the  last row, try again starting from the first row
        ElseIf O_searchInfo.searchDirection = SearchDirectionEnum.All Then
            While Not oRow Is Nothing
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
                If MatchText(oRow) Then
                    m_UltraGrid.ActiveRow = oRow
                    If Not m_oColumn Is Nothing Then
                        m_UltraGrid.ActiveCell = oRow.Cells(m_oColumn.Key)
                        m_UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
            End While

            '   We didn't find it the first time around, so start again from the first row
            oRow = m_UltraGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)
            While Not oRow Is Nothing
                If MatchText(oRow) Then
                    m_UltraGrid.ActiveRow = oRow
                    If Not m_oColumn Is Nothing Then
                        m_UltraGrid.ActiveCell = oRow.Cells(m_oColumn.Key)
                        m_UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End If
                    Exit Sub
                End If
                oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
            End While

        End If

        '   If we get this far, we didn't find the string, so show a message box
        'Message modified by Michael Pastor
        MsgBox("UltraGrid has searched all the records. The search item '" & O_searchInfo.searchString & "' was not found.", MsgBoxStyle.Information, "Data Unavailable")
        '- MessageBox.Show("UltraGrid has searched all the records. The search item '" & O_searchInfo.searchString & "' was not found.", "Infragistics UltraGrid", MessageBoxButtons.OK, MessageBoxIcon.None)

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

        Dim strColumnKey As String = O_searchInfo.lookIn
        Dim oCol As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim strCellValue As String = ""

        '   Determine whether we are searching the current column or all columns
        Dim bSearchAllColumns = True
        If m_UltraGrid.DisplayLayout.Bands(0).Columns.Exists(strColumnKey) Then bSearchAllColumns = False

        '   If we are searching all columns then we must iterate through all the cells
        '    in this row, which we can do by using the band's Columns collection
        If bSearchAllColumns Then
            For Each oCol In m_UltraGrid.DisplayLayout.Bands(0).Columns
                If Not oRow.Cells(oCol.Key).Value Is Nothing Then
                    If Match(O_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
                        MatchText = True
                        m_oColumn = oCol
                        Exit Function
                    End If
                End If
            Next
        Else
            oCol = m_UltraGrid.DisplayLayout.Bands(0).Columns(strColumnKey)
            If Not oRow.Cells(oCol.Key).Value Is Nothing Then
                If Match(O_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
                    MatchText = True
                    m_oColumn = oCol
                    Exit Function
                End If
            End If
        End If

    End Function

    Private Function Match(ByVal userString As String, ByVal cellValue As String) As Boolean

        '   If our search is case insensitive, make both strings uppercase
        If Not O_searchInfo.matchCase Then
            userString = userString.ToUpper
            cellValue = cellValue.ToUpper
        End If

        '   If we are searching any part of the cell value...
        If O_searchInfo.searchContent = SearchContentEnum.AnyPartOfField Then

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

        ElseIf O_searchInfo.searchContent = SearchContentEnum.WholeField Then
            If userString = cellValue Then Match = True Else Match = False
            Exit Function

        ElseIf O_searchInfo.searchContent = SearchContentEnum.StartOfField Then
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
            SearchInfo = O_searchInfo
        End Get
    End Property

End Module
