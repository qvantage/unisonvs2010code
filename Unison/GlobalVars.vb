Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Graphics
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
'Imports System.Drawing.SystemColors

Module GlobalVars
    Public strConnection, strConnection2 As String '= "Server = NTSRVR1;Database = HolidaysModule; " & "User ID = Holiday; Password = holiday"
    Public sqdtAdapter As SqlDataAdapter
    Public dsCompany As New DataSet()
    Public sqlConn As New SqlConnection() ' (strConnection)
    Public daStates As New SqlDataAdapter()
    Public daBStates As New SqlDataAdapter()
    Public strStatesSQL As String = "Select Code, Name from State"
    Public strBStatesSQL As String = "Select BState.Code, BState.Name from State BState"
    Public KeyWords() As String = {" WITH ", " Where ", " Order ", " Group "}
    Public IPAddr As String ' = "192.80.90.200"
    Public ByPassKeyUp As Boolean = False
    'Public IPAddr As String = "66.14.100.162"
    'Public IPAddr As String = "192.168.1.102"
    Public LocalIP, RemoteIP, LocalName, RemoteName As String
    Public cleanNoRecords As Boolean 'flag used in SearchOnLeave when zero rows returned (no matches found) 
    Public NullDate As String = "1/1/0001"


    'Public Class MyTextBox
    '    Inherits TextBox

    '    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '        Dim drawBrush As SolidBrush = New SolidBrush(ForeColor)

    '        MyBase.OnPaint(e)
    '        e.Graphics.DrawString(Text, Font, drawBrush, 0.0F, 0.0F)
    '        If Me.ReadOnly Then
    '            'e.Graphics.DrawString(Text, Font, drawBrush, 0.0F, 0.0F)
    '        End If
    '    End Sub

    '    Public Sub New()
    '        MyBase.New()

    '        Me.SetStyle(ControlStyles.UserPaint, True)

    '        'Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)

    '    End Sub
    'End Class

    Public Enum KW
        _0With
        _1Where
        _2Order
        _3Group
    End Enum

    Public Enum TagOpts
        dtTableName     '0
        dtFieldName     '1
        JustView        '2
        KeepValOnReset  '3
        FillTable       '4 
        CodeField       '5
        LabelField      '6
        GColCap         '7
        cboOrdFld       '8 - Also Used for Radiobutton Value
        DefaultVal      '9
        SavCboTxt       '10 - 1 or 0 to save the text instead of value default to 0
    End Enum

    Public Enum EditAction
        START
        CANCEL
        ENDEDIT
    End Enum


    Public Class clsSearchInfo
        Public searchString As String = ""
        Public lookIn As String
        Public searchDirection As SearchDirectionEnum = SearchDirectionEnum.All
        Public searchContent As SearchContentEnum = SearchContentEnum.WholeField
        Public matchCase As Boolean = False
    End Class

    Public Enum SearchDirectionEnum
        Down = 0
        Up = 1
        All = 2
    End Enum

    Public Enum SearchContentEnum
        AnyPartOfField = 0
        WholeField = 1
        StartOfField = 2
    End Enum

    Public Class GridColProp
        Public ColIdx As Int32
        Public TabStop As Boolean
        Public CellActivation As Infragistics.Win.UltraWinGrid.Activation
    End Class

    Public Class GridProp
        Public AllowUpdate As Infragistics.Win.DefaultableBoolean
        Public CellClickAction As Infragistics.Win.UltraWinGrid.CellClickAction
        Public ColProps() As GridColProp
    End Class

    '====================================================
    'Public Class clsSearchInfo
    '    Public searchString As String = ""
    '    Public lookIn As String
    '    Public searchDirection As SearchDirectionEnum = SearchDirectionEnum.All
    '    Public searchContent As SearchContentEnum = SearchContentEnum.WholeField
    '    Public matchCase As Boolean = False
    'End Class

    'Public Enum SearchDirectionEnum
    '    Down = 0
    '    Up = 1
    '    All = 2
    'End Enum

    'Public Enum SearchContentEnum
    '    AnyPartOfField = 0
    '    WholeField = 1
    '    StartOfField = 2
    'End Enum

    '====================================================








    'Public CustCB As New SqlCommandBuilder(sqdtAdapter)
    Public Structure SearchListData
        Public Query As String
        Public Row As DataRow
    End Structure

    Public Function PopulateDataset2(ByRef xDataAdapter As SqlDataAdapter, ByRef dsData As DataSet, ByVal strSQL As String, Optional ByVal PreserveTbl As Boolean = False) As DataSet
        Dim TblIndex As Integer
        Dim TblString As String
        Dim EndTblIndex As Integer = 0
        Dim i As Integer
        Dim TblArray As Object()()
        Dim DataAdapter As SqlDataAdapter

        PopulateDataset2 = Nothing
        If strSQL.Trim = "" Then Exit Function

        Dim localConn As New SqlConnection(strConnection)

        PopulateDataset2 = Nothing
        If DataAdapter Is Nothing Then
            DataAdapter = New SqlDataAdapter
        End If
        If dsData Is Nothing Then
            dsData = New DataSet
        End If

        TblArray = TablesList(strSQL)
        If TblArray Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("PopulateDataset2: Cannot separate Table Names!", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MsgBox("PopulateDataset2: Cannot separate Table Names!")
            Exit Function
        End If

        If TblArray(0).Length > 1 Then
            TblString = TblArray(0)(1)
        Else
            TblString = TblArray(0)(0) 'Temp coding!!
        End If

        Try
            'Dim sqdtAdapter As New SqlDataAdapter(strSQL, localConn)
            DataAdapter.SelectCommand = New SqlCommand
            With DataAdapter.SelectCommand
                .Connection = localConn
                .CommandTimeout = 120
                .CommandText = strSQL
                .CommandType = CommandType.Text
            End With
            With DataAdapter
                .AcceptChangesDuringFill = True
                .MissingSchemaAction = MissingSchemaAction.AddWithKey
                If .TableMappings.Count <= 0 Then
                    .TableMappings.Add("Table", TblString)
                End If
                localConn.Open()
                If dsData.Tables.Count > 0 And PreserveTbl = False Then
                    'dsData.Tables(TblString).Clear()
                    If Not dsData.Relations Is Nothing Then
                        dsData.Relations.Clear()
                    End If
                    Dim tmpTable As DataTable
                    For Each tmpTable In dsData.Tables
                        tmpTable.Constraints.Clear()
                    Next
                    dsData.Tables.Clear()
                End If
                .Fill(dsData, TblString)
            End With
        Catch ex As System.Data.SqlClient.SqlException
            'Catch ex As Exception
            'Message NOT modified by Michael Pastor, due to format being identical to modified version.
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Company Profile")
            PopulateDataset2 = Nothing
            Exit Function
        Finally
            localConn.Close()
            localConn = Nothing
            PopulateDataset2 = dsData

        End Try
    End Function


    Public Function TypeAhead(ByRef Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs, ByVal sqlTable As String, ByVal sqlFld As String, Optional ByVal CondClause As String = "") As String
        Dim daAdapter As New SqlDataAdapter
        Dim dsData As New DataSet
        Dim Query, FldName, TblName As String
        Dim OldValLen As Integer
        Dim FldInfoArr() As String

        'FldInfoArr = SplitStringToArray(Sender.Tag, ".")
        'FldName = FldInfoArr(1)
        'TblName = FldInfoArr(0)
        'If TblName.Trim = "" Then
        '    TblName = Sender.FindForm.Tag
        'End If
        'Query = "Select Top 1 " & FldName & " from " & TblName & " order by fldname"

        If TypeOf Sender Is TextBox Then
        ElseIf TypeOf Sender Is Infragistics.Win.UltraWinEditors.UltraTextEditor Then
        Else
            'Message modified by Michael Pastor
            MsgBox("Unknown Control passed to TypeAhead function.", MsgBoxStyle.Exclamation, "Data Invalid")
            '- MsgBox("Unknown Control passed to TypeAhead function.")
            Exit Function
        End If

        Select Case e.KeyValue
            Case Keys.Back, Keys.Left, Keys.Right, Keys.Home, Keys.End, Keys.Tab, Keys.ShiftKey, Keys.Delete
                Exit Function
        End Select

        If Sender.text.trim = "" Then Exit Function
        If Sender.modified = False Then Exit Function

        If CondClause <> "" Then
            Dim pos As Integer
            pos = InStr(CondClause, "Where", CompareMethod.Text)
            If pos >= 1 Then
                CondClause = CondClause.Substring(pos + Len("Where"))
                CondClause = " AND " & CondClause
            Else
                Dim StrArr() As String
                CondClause = CondClause.Trim

                StrArr = SplitStringToArray(CondClause, " ")
                If StrArr(0).ToUpper <> "AND" Then
                    CondClause = " AND " & CondClause
                End If
            End If
        End If
        OldValLen = Sender.Text.Length - Sender.SelectionLength
        Dim SrchStr As String
        SrchStr = Sender.Text.Substring(0, OldValLen)
        SrchStr = SrchStr.Replace("'", "''")
        Query = "Select Top 1 " & sqlFld & " from " & sqlTable & " where " & sqlFld & " like '" & SrchStr & "%' " & CondClause & " order by " & sqlFld
        PopulateDataset2(daAdapter, dsData, Query)

        If dsData.Tables(0).Rows.Count < 1 Then GoTo Terminate

        Sender.Text = dsData.Tables(sqlTable).Rows(0).Item(0) & ""
        Sender.SelectionLength = 100
        Sender.SelectionStart = OldValLen
        Sender.Modified = True
        'TypeAhead = Sender.Text
Terminate:
        daAdapter = Nothing
        dsData = Nothing
    End Function


    Public Function GetCtrldbFieldInfo(ByVal sender As Control) As String()
        Dim PointLoc As Integer
        Dim StrArr() As String
        If sender.Tag Is Nothing Then
            ReDim StrArr(0)
            StrArr(0) = ""
        Else
            StrArr = sender.Tag.ToString.Split(".")
        End If
        GetCtrldbFieldInfo = StrArr

    End Function

    Public Function CountSubstr(ByVal Str As String, ByVal Token As String, ByRef PosArr() As Integer) As Integer
        Dim i, pos As Integer


        i = 0 : pos = 1
        pos = InStr(pos, Str, Token, CompareMethod.Text)
        While pos > 0
            ReDim Preserve PosArr(i)
            PosArr(i) = pos
            i += 1
            pos = InStr(pos + 1, Str, Token, CompareMethod.Text)
        End While
        CountSubstr = i
    End Function

    Public Function SplitStringToArray(ByVal TextStr As String, ByVal Token As String) As String()
        Dim strArr() As String
        Dim i, j, Start, Count As Integer
        Dim intArr() As Integer

        Count = CountSubstr(TextStr, Token, intArr)
        If Count > 0 Then
            Start = 0
            ReDim strArr(intArr.GetUpperBound(0) + 1)
            For i = 0 To intArr.GetUpperBound(0)
                strArr(i) = TextStr.Substring(Start, intArr(i) - Start - 1)
                Start = intArr(i) '+ 1
            Next i
            strArr(intArr.GetUpperBound(0) + 1) = TextStr.Substring(Start)
        Else
            ReDim strArr(0)
            strArr(0) = TextStr
        End If
        SplitStringToArray = strArr

    End Function

    Public Function FormLoad(ByVal ActForm As Object, ByVal dvData As DataView, Optional ByRef DR As SqlDataReader = Nothing)
        Dim Ctrl As Control
        Dim StrArr() As String
        Dim DataObj As Object
        Dim GridColCaption As String

        If DR Is Nothing Then
            DataObj = dvData(0)
        Else
            DataObj = DR
            'If TypeOf ActForm Is Form Then
            'DR.Read()
            'End If
        End If


        For Each Ctrl In ActForm.Controls
            If Not (Ctrl.Tag Is Nothing) Or TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage Then
                With Ctrl
                    StrArr = GetCtrldbFieldInfo(Ctrl)
                    If StrArr.Length >= (TagOpts.GColCap + 1) Then
                        GridColCaption = StrArr(TagOpts.GColCap)
                        If GridColCaption.Trim = "" Then
                            GridColCaption = StrArr(TagOpts.dtFieldName).Trim
                            If GridColCaption.StartsWith("[") Then
                                GridColCaption = GridColCaption.Substring(1, GridColCaption.Length - 2)
                            End If
                        End If
                    ElseIf StrArr.Length >= (TagOpts.dtFieldName + 1) Then
                        GridColCaption = StrArr(TagOpts.dtFieldName).Trim
                        If GridColCaption.StartsWith("[") Then
                            GridColCaption = GridColCaption.Substring(1, GridColCaption.Length - 2)
                        End If
                    Else
                        GridColCaption = ""
                    End If
                    If GridColCaption.ToUpper = "_NOUPD_" Then GoTo NextCtrl
                    If StrArr.Length >= 2 Or (TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage) Then
                        Select Case Ctrl.GetType().ToString
                            Case "System.Windows.Forms.TextBox", "RoutesModule.MyTextBox", "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                                .Text = DataObj.Item(GridColCaption).ToString 'StrArr(1))
                            Case "System.Windows.Forms.Label"
                                .Text = DataObj.Item(GridColCaption) & ":"
                            Case "Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit"
                                'SetCtrlLength(Ctrl, dvView)
                                .Text = DataObj.Item(GridColCaption).ToString
                            Case "System.Windows.Forms.ComboBox"
                                Dim TempCtrl As ComboBox
                                TempCtrl = Ctrl
                                TempCtrl.SelectedValue = DataObj.Item(GridColCaption)

                            Case "Infragistics.Win.UltraWinGrid.UltraCombo"
                                Dim TempCtrl As Infragistics.Win.UltraWinGrid.UltraCombo
                                TempCtrl = Ctrl
                                Dim x As Boolean = tempctrl.Enabled
                                tempctrl.Enabled = True
                                TempCtrl.Value = DataObj.Item(GridColCaption)
                                tempctrl.Enabled = x

                            Case "Infragistics.Win.UltraWinEditors.UltraCheckEditor"
                                Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraCheckEditor
                                tempctrl = Ctrl
                                If Not DataObj.Item(GridColCaption) Is DBNull.Value Then
                                    tempctrl.Checked = DataObj.Item(GridColCaption)
                                Else
                                    tempctrl.Checked = False
                                End If
                                'tempctrl.Checked = DataObj.Item(GridColCaption)
                            Case "System.Windows.Forms.CheckBox"
                                Dim TempCtrl As CheckBox
                                tempctrl = Ctrl
                                tempctrl.Checked = IIf(DataObj.Item(GridColCaption) Is Nothing, False, DataObj.Item(GridColCaption))
                            Case "System.Windows.Forms.RadioButton"
                                Dim TempCtrl As RadioButton
                                TempCtrl = Ctrl
                                If StrArr(TagOpts.DefaultVal) = DataObj.Item(GridColCaption) Then
                                    TempCtrl.Checked = True
                                Else
                                    TempCtrl.Checked = False
                                End If
                            Case "System.Windows.Forms.DateTimePicker"
                                Dim TempCtrl As DateTimePicker
                                TempCtrl = Ctrl
                                tempctrl.Value = DataObj.Item(GridColCaption)
                            Case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                                Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
                                TempCtrl = Ctrl
                                tempctrl.Value = DataObj.Item(GridColCaption)
                            Case "System.Windows.Forms.GroupBox", "System.Windows.Forms.Panel"
                                FormLoad(Ctrl, dvData, DR)
                            Case "System.Windows.Forms.TabControl", "System.Windows.Forms.TabPage"
                                If Ctrl.Tag = Nothing Then
                                    FormLoad(Ctrl, dvData, DR)
                                ElseIf Ctrl.Tag = "" Then
                                    FormLoad(Ctrl, dvData, DR)
                                End If
                            Case Else
                                '.Text = DataObj.Item(GridColCaption) 'StrArr(1))
                        End Select
                    End If
                End With
            End If
NextCtrl:
        Next

    End Function

    Public Function DataViewSave(ByVal ActForm As Object, ByVal dvData As DataView) As Boolean
        On Error GoTo ErrTrap

        Dim Ctrl As Control
        Dim StrArr() As String

        DataViewSave = False
        For Each Ctrl In ActForm.Controls
            If Not (Ctrl.Tag Is Nothing) Or TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage Then
                With Ctrl
                    StrArr = GetCtrldbFieldInfo(Ctrl)
                    If StrArr.Length >= 2 Or (TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage) Then
                        Select Case Ctrl.GetType().ToString
                            Case "System.Windows.Forms.TextBox", "RoutesModule.MyTextBox", "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                                dvData(0).Item(StrArr(1)) = .Text
                            Case "System.Windows.Forms.Label"
                                If .Text.LastIndexOf(":") > 0 Then
                                    dvData(0).Item(StrArr(TagOpts.dtFieldName)) = .Text.Substring(0, .Text.LastIndexOf(":"))
                                Else
                                    dvData(0).Item(StrArr(TagOpts.dtFieldName)) = .Text
                                End If

                            Case "Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit"
                                Dim TempCtrl As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
                                tempctrl = Ctrl
                                Select Case tempctrl.EditAs
                                    Case Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
                                        dvData(0).Item(StrArr(TagOpts.dtFieldName)) = IIf(tempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) = "", System.DBNull.Value, TempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals))
                                    Case Infragistics.Win.UltraWinMaskedEdit.EditAsType.Time
                                        dvData(0).Item(StrArr(TagOpts.dtFieldName)) = IIf(tempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) = "", System.DBNull.Value, TempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals))
                                    Case Else
                                        dvData(0).Item(StrArr(TagOpts.dtFieldName)) = tempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)
                                End Select
                            Case "System.Windows.Forms.ComboBox"
                                Dim TempCtrl As ComboBox
                                TempCtrl = Ctrl
                                If (StrArr.Length - 1) >= TagOpts.SavCboTxt Then
                                    If StrArr(TagOpts.SavCboTxt) = "1" Then
                                        dvData(0).Item(StrArr(TagOpts.dtFieldName)) = TempCtrl.Text
                                        Exit Select
                                    End If
                                End If
                                dvData(0).Item(StrArr(TagOpts.dtFieldName)) = TempCtrl.SelectedValue

                            Case "Infragistics.Win.UltraWinGrid.UltraCombo"
                                Dim TempCtrl As Infragistics.Win.UltraWinGrid.UltraCombo
                                TempCtrl = Ctrl
                                If (StrArr.Length - 1) >= TagOpts.SavCboTxt Then
                                    If StrArr(TagOpts.SavCboTxt) = "1" Then
                                        dvData(0).Item(StrArr(TagOpts.dtFieldName)) = TempCtrl.Text
                                        Exit Select
                                    End If
                                End If
                                dvData(0).Item(StrArr(TagOpts.dtFieldName)) = TempCtrl.Value

                            Case "Infragistics.Win.UltraWinEditors.UltraCheckEditor"
                                Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraCheckEditor
                                tempctrl = Ctrl
                                dvData(0).Item(StrArr(TagOpts.dtFieldName)) = tempctrl.Checked 'Convert.ToByte(SamePayAddr.Checked)
                            Case "System.Windows.Forms.CheckBox"
                                Dim TempCtrl As CheckBox
                                tempctrl = Ctrl
                                dvData(0).Item(StrArr(TagOpts.dtFieldName)) = tempctrl.Checked 'Convert.ToByte(SamePayAddr.Checked)
                            Case "System.Windows.Forms.RadioButton"
                                Dim TempCtrl As RadioButton
                                tempctrl = Ctrl
                                If tempctrl.Checked = True Then
                                    dvData(0).Item(StrArr(TagOpts.dtFieldName)) = StrArr(TagOpts.DefaultVal)
                                End If
                            Case "System.Windows.Forms.DateTimePicker"
                                Dim TempCtrl As DateTimePicker
                                TempCtrl = Ctrl
                                dvData(0).Item(StrArr(1)) = tempctrl.Value    'DataObj.Item(StrArr(1))
                            Case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                                Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
                                TempCtrl = Ctrl
                                dvData(0).Item(StrArr(1)) = tempctrl.Value    'DataObj.Item(StrArr(1))
                            Case "System.Windows.Forms.GroupBox"
                                DataViewSave(Ctrl, dvData)
                            Case "System.Windows.Forms.TabControl", "System.Windows.Forms.TabPage"
                                If Ctrl.Tag = Nothing Then
                                    DataViewSave(Ctrl, dvData)
                                ElseIf Ctrl.Tag = "" Then
                                    DataViewSave(Ctrl, dvData)
                                End If
                        End Select
                    End If
                End With
            End If
        Next
        DataViewSave = True
        Exit Function
ErrTrap:
        MsgBox("DataViewSave Error: " & Err.Description)
    End Function

    Public Function FormSave(ByVal ActForm As Object, ByVal dvData As DataView, ByVal sqlSelectStr As String) As Integer
        'Returns Number of Rows Updated

        On Error GoTo ErrTrap
        Dim Count As Integer

        FormSave = 0

        If DataViewSave(ActForm, dvData) Then
            Count = UpdateDbFromDataSet(dvData.Table.DataSet, sqlSelectStr)
            FormSave = Count
            'MsgBox(Count & " rows Updated!!")
        End If
        Exit Function
ErrTrap:
        MsgBox("FormSave Error: " & Err.Description)

    End Function

    Public Function TablesList(ByVal SqlString As String) As Object()()
        On Error GoTo ErrTrap

        Dim TblIndex As Integer
        Dim TblString, TblList() As String
        Dim EndTblIndex As Integer = 0
        Dim i As Integer
        'Dim TableAliasList() As Object


        TblIndex = InStr(SqlString, " From ", CompareMethod.Text) + Len(" From ") - 1
        For i = 0 To KeyWords.GetUpperBound(0)
            EndTblIndex = InStr(SqlString, KeyWords(i), CompareMethod.Text)
            If EndTblIndex > 0 Then Exit For
        Next i
        If EndTblIndex <= 0 Then
            TblString = SqlString.Substring(TblIndex)
        Else
            TblString = SqlString.Substring(TblIndex, EndTblIndex - TblIndex)
        End If
        TblString = TblString.Trim().ToUpper

        If TblString = "" Then
            'Message modified by Michael Pastor
            MsgBox("Table cannot be found.", MsgBoxStyle.Information, "Data Unavailable")
            '- MsgBox("Error: Table not found")
            Exit Function
        End If

        TblIndex = 0 : EndTblIndex = 0

        If TblString.IndexOf(" JOIN ") <= 0 Then
            TblList = TblString.Split(",")
        Else
            Dim TempTblStr, TempTblArr(), TempONArr() As String
            Dim JoinDelims() As String = {"JOIN", "ON"}

            TempTblStr = TblString.Replace("(", "")
            TempTblStr = TempTblStr.Replace(")", "")
            TempTblStr = TempTblStr.ToUpper
            TempTblStr = TempTblStr.Replace(" JOIN ", " | ")
            TempTblArr = TempTblStr.Split("|")
            For i = 0 To TempTblArr.Length - 1
                TempTblArr(i) = TempTblArr(i).Replace(" LEFT ", " ")
                TempTblArr(i) = TempTblArr(i).Replace(" OUTER ", " ")
                TempTblArr(i) = TempTblArr(i).Replace(" INNER ", " ")
                TempTblArr(i) = TempTblArr(i).Replace(" CROSS ", " ")
                TempTblArr(i) = TempTblArr(i).Replace(" ON ", " | ")
                TempONArr = TempTblArr(i).Split("|")
                TempTblArr(i) = TempONArr(0)
                TempTblArr(i) = TempTblArr(i).Trim

                TempONArr.Clear(TempONArr, 0, TempONArr.Length)
                TempONArr = Nothing
            Next
            TblList = TempTblArr
        End If
        'Dim TableAliasList()() = {New String(TblList.GetUpperBound(0)) {}}
        Dim TableAliasList(TblList.GetUpperBound(0))() As String
        Dim Sales()() As Double = {New Double(11) {}}
        'Dim TableAliasList()() As Array
        'TableAliasList = New String(TblList.GetUpperBound(0)) {}

        For i = 0 To TblList.GetUpperBound(0)
            'TableAliasList(i) = New Array(1)
            TableAliasList(i) = TblList(i).Trim.Split(" ")
            'EndTblIndex = TblList(i).IndexOf(" ", TblIndex) 'Check for Alias
            'If EndTblIndex > 0 Then
            '    TblString = TblString.Substring(0, EndTblIndex).Trim
            'End If
        Next i
        TablesList = TableAliasList
        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("TablesList Error: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("TablesList Error: " & Err.Description)
    End Function

    Public Function FieldsList(ByVal SqlString As String) As Object()()
        On Error GoTo ErrTrap

        Dim FldIndex As Integer
        Dim FldString, FldList() As String
        Dim EndFldIndex As Integer = 0
        Dim i As Integer
        Dim DelimPos As Integer

        FieldsList = Nothing
        EndFldIndex = InStr(SqlString, " From ", CompareMethod.Text) - 1
        FldIndex = Len("Select ")

        'For i = 0 To KeyWords.GetUpperBound(0)
        '    EndTblIndex = InStr(SqlString, KeyWords(i), CompareMethod.Text)
        '    If EndTblIndex > 0 Then Exit For
        'Next i

        If EndFldIndex <= 0 Then
            'Message modified by Michael Pastor
            MsgBox("'From' in the query remains unspecified. Please enter a 'From' for the query.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("There is No FROM in the query!")
            Exit Function
        Else
            FldString = SqlString.Substring(FldIndex, EndFldIndex - FldIndex)
        End If

        FldString = FldString.Trim()

        If FldString = "" Then
            'Message modified by Michael Pastor
            MsgBox("Column cannot be found.", MsgBoxStyle.Information, "Data Unavailable")
            '- MsgBox("Error: No Column found!")
            Exit Function
        End If

        'FldString = FldString.ToUpper
        FldList = FldString.Split(",")
        Dim TableAliasList(FldList.GetUpperBound(0))() As String
        Dim Brackets() As Char = {"[", "]"}
        For i = 0 To FldList.GetUpperBound(0)
            DelimPos = InStr(FldList(i).Trim, " as ", CompareMethod.Text)
            If DelimPos > 0 Then
                Dim x(1) As String
                x(0) = FldList(i).Trim.Substring(0, DelimPos - 1)
                x(1) = FldList(i).Trim.Substring(DelimPos + Len(" as ") - 1)
                x(1) = x(1).Split(Brackets).GetValue(CInt((x(1).Split(Brackets).Length - 1) / 2))
                TableAliasList(i) = x
            Else
                'Dim x(0) As String
                'x(0) = FldList(i).Trim
                TableAliasList(i) = FldList(i).Trim.Split(" ")
            End If
            If InStr(TableAliasList(i)(0), ".", CompareMethod.Text) > 0 Then
                TableAliasList(i)(0) = TableAliasList(i)(0).Split(".").GetValue(1)
            End If
        Next i
        FieldsList = TableAliasList
        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("TablesList Error: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("TablesList Error: " & Err.Description)
    End Function

    Public Function UpdateDbFromDataSet(ByVal dsChanges As DataSet, _
            ByVal strSQL As String) As Integer

        Dim Conn As New SqlConnection(strConnection)
        Dim TblList()() As Object
        TblList = TablesList(strSQL)
        UpdateDbFromDataSet = 0
        'Try
        '    'Dim sqdtAdapter As New SqlDataAdapter(strSQL, sqlConn)
        '    DataAdapter.SelectCommand = New SqlCommand()
        '    With DataAdapter.SelectCommand
        '        .Connection = sqlConn
        '        .CommandText = strSQL
        '        .CommandType = CommandType.Text
        '    End With
        '    With DataAdapter
        '        .AcceptChangesDuringFill = True
        '        .MissingSchemaAction = MissingSchemaAction.AddWithKey
        '        If .TableMappings.Count <= 0 Then
        '            .TableMappings.Add("Table", TblString)
        '        End If
        '        sqlConn.Open()
        '        .Fill(dsData, TblString)
        '    End With
        'Catch ex As System.Data.SqlClient.SqlException
        '    MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Company Profile")
        '    PopulateDataset2 = Nothing
        '    Exit Function
        'Finally
        '    sqlConn.Close()
        '    PopulateDataset2 = dsData

        'End Try

        Try
            'declare a new data adapter but assign it to the
            'same SQL statement that was used to retrieve the
            'data from before
            Dim dtAdapter As New SqlDataAdapter(strSQL, Conn)
            Dim i, j As Integer
            With dtAdapter
                If .TableMappings.Count <= 0 Then
                    For i = 0 To 0 'TblList.GetUpperBound(0)
                        ' C-12-16-02 .TableMappings.Add("Table", TblList(i)(0))
                        '.TableMappings.Add(TblList(i)(0), TblList(i)(0))
                        .TableMappings.Add("Table", TblList(i)(0))
                    Next i
                End If
                'sqlConn.Open()
                '.Fill(dsChanges, TblList(0)(0))
            End With

            'build the commands automatically to update the database
            'for the DataAdapter
            Dim custCB As SqlCommandBuilder = _
                New SqlCommandBuilder(dtAdapter)

            'open the connection
            Conn.Open()

            'save the DataSet changes back to the database
            'return records updated
            '''Dim row As DataRow
            '''For Each row In dsChanges.Tables(0).Rows
            '''    j = j
            '''Next
            UpdateDbFromDataSet = dtAdapter.Update(dsChanges)
        Catch ex As System.Data.SqlClient.SqlException
            'Message modified by Michael Pastor
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            Conn.Close()
            Exit Function
        Finally
            'close the connection
            Conn.Close()

        End Try

    End Function

    Public Function UpdateDbFromDataSetV3(ByVal dsChanges As DataSet, _
            ByVal strSQL As String, ByVal UpdateCmd As SqlCommand) As Integer

        Dim TblList()() As Object
        UpdateDbFromDataSetV3 = -1
        If UpdateCmd.CommandText.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Update statement remains unspecified. Please enter an update statment.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("UPDATE statement is blank.", MsgBoxStyle.Critical, "UpdateDbFromDataSetV3")
            Exit Function
        End If
        TblList = TablesList(strSQL)

        Dim Conn As New SqlConnection(strConnection)
        Dim dtAdapter As SqlDataAdapter = New SqlDataAdapter(strSQL, Conn)

        dtAdapter.UpdateCommand = UpdateCmd
        dtAdapter.UpdateCommand.Connection = Conn

        'dtAdapter.UpdateCommand = New SqlCommand("Update DailyEntry Set Weight = @Wgt, Charge = @Chrg where TranDate = @TrDate and ManifestID = @WgtPlanID", Conn)
        'dtAdapter.UpdateCommand.Parameters.Add("@Wgt", SqlDbType.Decimal, 5, "Weight")
        'dtAdapter.UpdateCommand.Parameters.Add("@Chrg", SqlDbType.Decimal, 5, "Charge")

        'Dim CondParam1 As SqlParameter = dtAdapter.UpdateCommand.Parameters.Add("@TrDate", SqlDbType.DateTime)
        'CondParam1.SourceColumn = "TranDate"
        'CondParam1.SourceVersion = DataRowVersion.Original

        'Dim CondParam2 As SqlParameter = dtAdapter.UpdateCommand.Parameters.Add("@WgtPlanID", SqlDbType.Int)
        'CondParam2.SourceColumn = "ManifestID"
        'CondParam2.SourceVersion = DataRowVersion.Original

        With dtAdapter
            .TableMappings.Add("Table", TblList(0)(1))
        End With
        Try
            Conn.Open()
            dtAdapter.Update(dsChanges)

        Catch ex As System.Data.SqlClient.SqlException
            'Message modified by Michael Pastor
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            Conn.Close()
            Exit Function
        Finally
            'close the connection
            Conn.Close()

        End Try

    End Function

    Public Function GetColumnsInfo(ByRef dsData As DataSet, ByVal TblName As String, Optional ByVal DB As String = "", Optional ByVal DBUser As String = "", Optional ByVal DBPass As String = "") As Boolean
        Dim DataAdapter As New SqlDataAdapter
        Dim strConn, TableParts(), DBName, TableName As String
        Dim sqlConn2 As New SqlConnection   ' (strConnection)

        'Dim cmd As New SqlCommand("sp_columns " & TblName, sqlConn)
        'sqlConn.Open()
        'Dim data_reader As SqlDataReader = cmd.ExecuteReader()

        'GetColumnsInfo = False

        'Do While data_reader.Read()
        '    'data_reader.Item("COLUMN_NAME")
        'Loop
        'data_reader.Close()
        'sqlConn.Close()
        If DB = "" Then DB = AppDBName
        If DBUser = "" Then DBUser = AppDBUser
        If DBPass = "" Then DBPass = AppDBPass

        TableParts = TblName.Split(".")
        If TableParts.Length > 1 Then
            DBName = TableParts(0)
            TableName = TableParts(2)
        Else
            DBName = AppDBName '"RoutesModule"
            TableName = TableParts(0)
        End If
        strConn = "Server = " & IPAddr & ";Database = " & DB & "; " & "User ID = " & DBUser & "; Password = " & DBPass
        sqlConn2.ConnectionString = strConnection


        Try
            'Dim sqdtAdapter As New SqlDataAdapter(strSQL, sqlConn)
            DataAdapter.SelectCommand = New SqlCommand
            With DataAdapter.SelectCommand
                .Connection = sqlConn2
                .CommandText = "sp_columns " & TableName
                .CommandType = CommandType.Text
            End With
            With DataAdapter
                '.AcceptChangesDuringFill = True
                '.MissingSchemaAction = MissingSchemaAction.AddWithKey
                .TableMappings.Add("Table", TableName)
                .SelectCommand.Connection.Open()
                .Fill(dsData)
            End With
        Catch ex As System.Data.SqlClient.SqlException
            'Message NOT modified by Michael Pastor, due to format being identical to modified version.
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Company Profile")
            GoTo Release
        Finally
            GetColumnsInfo = True
        End Try

Release:
        sqlConn2.Close()
        sqlConn2 = Nothing
        DataAdapter.Dispose()
        DataAdapter = Nothing
    End Function

    Public Function SetCtrlLength(ByRef Ctrl As Control, ByRef dvView As DataView) As Boolean
        Dim TblField() As String
        Dim CtrlTextBox As TextBox
        Dim ctrlCombo As ComboBox
        Dim ctrlUCombo As Infragistics.Win.UltraWinGrid.UltraCombo
        Dim ctrlUltraText As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim CtrlX As Object

        SetCtrlLength = False
        TblField = GetCtrldbFieldInfo(Ctrl)

        If TypeOf Ctrl Is TextBox Then
            CtrlTextBox = Ctrl
            CtrlX = Ctrl
        ElseIf TypeOf Ctrl Is ComboBox Then
            ctrlCombo = Ctrl
            CtrlX = Ctrl
        ElseIf TypeOf Ctrl Is Infragistics.Win.UltraWinEditors.UltraTextEditor Then
            ctrlUltraText = Ctrl
            CtrlX = Ctrl
        ElseIf TypeOf Ctrl Is Infragistics.Win.UltraWinGrid.UltraCombo Then
            Exit Function
            ctrlUCombo = Ctrl
            CtrlX = Ctrl
        Else
            MsgBox("SetCtrlLength : Invalid Control passed in.")
            Exit Function
        End If

        dvView.RowFilter = "COLUMN_NAME='" & TblField(1) & "'"
        If dvView.Count > 0 Then
            Select Case dvView(0).Item("TYPE_NAME")
                Case "int"
                    'If CtrlTextBox Is Nothing Then
                    '    'ctrlCombo.MaxLength = dvView(0).Item("PRECISION")
                    'Else
                    '    CtrlTextBox.MaxLength = dvView(0).Item("PRECISION")
                    'End If
                    CtrlX.maxlength = dvView(0).Item("PRECISION")
                Case "varchar", "nvarchar"
                    'If CtrlTextBox Is Nothing Then
                    '    ctrlCombo.MaxLength = dvView(0).Item("PRECISION")
                    'Else
                    '    CtrlTextBox.MaxLength = dvView(0).Item("PRECISION")
                    'End If
                    CtrlX.maxlength = dvView(0).Item("PRECISION")
                Case "decimal"
                    'CtrlTextBox.MaxLength = dvView(0).Item("PRECISION") + dvView(0).Item("scale")
                    CtrlX.MaxLength = dvView(0).Item("PRECISION") + dvView(0).Item("scale")
                Case "bit", "char"
                    'CtrlTextBox.MaxLength = 1
                    CtrlX.MaxLength = 1

            End Select
        End If

        dvView.RowFilter = ""
        SetCtrlLength = True
    End Function
    Public Function SetupCtrlsLength(ByVal ActForm As Object, ByVal db As String, ByVal dbuser As String, ByVal dbpass As String)
        Dim Ctrl As Control
        Static Dim dvView As DataView
        Dim dsData As New DataSet


        If dvView Is Nothing Then
            dvView = New DataView
        End If
        ' *************************   Attention ******************************
        ' Later on we have to use the columns own table to get column information
        'Ali : To be fixed Later in Future!
        '*********************************************************************
        If TypeOf ActForm Is Form Then
            Dim Tableparts(), TableName As String

            If GetColumnsInfo(dsData, ActForm.Tag) = False Then
                Exit Function
            End If
            Tableparts = ActForm.Tag.Split(".")
            If Tableparts.Length > 1 Then
                TableName = Tableparts(2)
            Else
                TableName = Tableparts(0)
            End If

            dvView.Table = dsData.Tables(TableName)
        End If
        For Each Ctrl In ActForm.Controls
            If Not (Ctrl.Tag Is Nothing) Or TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage Then
                If Ctrl.Tag <> "" Then
                    With Ctrl
                        Select Case Ctrl.GetType().ToString
                            Case "System.Windows.Forms.TextBox", "RoutesModule.MyTextBox", "System.Windows.Forms.ComboBox", "Infragistics.Win.UltraWinGrid.UltraCombo", "Infragistics.Win.UltraWinEditors.UltraTextEditor", "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                                SetCtrlLength(Ctrl, dvView)
                        End Select
                    End With
                Else
                    Select Case Ctrl.GetType().ToString
                        Case "System.Windows.Forms.GroupBox", "System.Windows.Forms.Panel"
                            SetupCtrlsLength(Ctrl, db, dbuser, dbpass)
                        Case "System.Windows.Forms.TabControl", "System.Windows.Forms.TabPage"
                            If Ctrl.Tag = Nothing Then
                                SetupCtrlsLength(Ctrl, db, dbuser, dbpass)
                            ElseIf Ctrl.Tag = "" Then
                                SetupCtrlsLength(Ctrl, db, dbuser, dbpass)
                            End If
                    End Select
                End If
            End If
        Next Ctrl

        If TypeOf ActForm Is Form Then
            dvView = Nothing
        End If
    End Function


    Public Function EditForm(ByVal ActForm As Object, ByVal SQLQuery As String, ByVal Action As EditAction, ByRef SQLCmd As SqlCommand, Optional ByVal Condition As String = "", Optional ByVal IdentInsert As Boolean = False) As Boolean

        EditForm = False
        Select Case Action
            Case EditAction.START
                SQLCmd = InitiateEdit(ActForm, SQLQuery)
                If Not (SQLCmd Is Nothing) Then
                    'ActForm.Container.Add(SQLCmd.Site, "SQLCMD")
                    EditForm = True
                End If
            Case EditAction.ENDEDIT
                If SQLCmd Is Nothing Then 'What if there is no Transaction??
                    EditForm = TerminateEdit(ActForm, SQLCmd, True, False, Condition, IdentInsert)
                    'MsgBox("EditForm : Error - SQLCmd is Null.")
                    If Not SQLCmd Is Nothing Then
                        If Not SQLCmd.Transaction Is Nothing Then
                            SQLCmd.Transaction.Rollback()
                        End If
                        SQLCmd.Connection.Close()
                        SQLCmd = Nothing
                    End If
                    Exit Function
                End If
                EditForm = TerminateEdit(ActForm, SQLCmd, True, True, Condition, IdentInsert)
                If EditForm Then
                    If Not SQLCmd.Transaction Is Nothing Then
                        SQLCmd.Transaction.Rollback()
                    End If
                    If Not SQLCmd.Connection Is Nothing Then
                        SQLCmd.Connection.Close()
                    End If
                    SQLCmd = Nothing
                End If
            Case EditAction.CANCEL
                If SQLCmd Is Nothing Then
                    'MsgBox("EditForm : Eroor - SQLCmd is Null.")
                    Exit Function
                End If
                EditForm = TerminateEdit(ActForm, SQLCmd, False, True)
                If EditForm Then
                    SQLCmd = Nothing
                End If
        End Select

    End Function

    '    Public Function InitiateEdit(ByVal ActForm As Form, ByRef dsData As DataSet, ByVal SQLQuery As String) As SqlCommand
    Public Function InitiateEdit(ByVal ActForm As Object, ByVal SQLQuery As String, Optional ByVal LOCKTYPE As String = "UPDLOCK", Optional ByVal FormType As String = "NORMAL") As SqlCommand
        On Error GoTo ErrTrap

        Dim sqlConnTrans As New SqlConnection(strConnection)
        Dim cmdSQLTrans As New SqlCommand
        Dim drsqlReader As SqlDataReader
        Dim Pos, i As Integer
        Dim LockStmt As String = " WITH (" & LOCKTYPE & ") "

        Pos = InStr(SQLQuery, " WITH ", CompareMethod.Text)
        If Pos <= 0 Then
            For i = 0 To KeyWords.GetUpperBound(0)
                Pos = InStr(SQLQuery, KeyWords(i), CompareMethod.Text)
                If Pos > 0 Then Exit For
            Next i
            If Pos <= 0 Then
                SQLQuery = SQLQuery & LockStmt
            Else
                SQLQuery = SQLQuery.Insert(Pos, LockStmt)
                'SQLQuery = SQLQuery.Substring(0, pos) & " WITH (" & LOCKTYPE & ") " & SQLQuery.Substring(0, pos)
            End If
        End If
        InitiateEdit = Nothing

        sqlConnTrans.Open()

        ActForm.Cursor = Cursors.WaitCursor()

        Dim trnSql As SqlTransaction = sqlConnTrans.BeginTransaction(IsolationLevel.ReadCommitted)
        'trnSql.Connection.ConnectionTimeout 
        With cmdSQLTrans
            .Connection = sqlConnTrans
            .CommandType = CommandType.Text
            .Transaction = trnSql
            .CommandText = SQLQuery
            drsqlReader = .ExecuteReader
        End With

        If FormType = "FIELDROW" Then
            FormLoadFieldRow(ActForm, SQLQuery)
        Else
            'Correct Later
            drsqlReader.Read()
            'FormLoad(ActForm, Nothing, drsqlReader)
            drsqlReader.Close()

        End If

        InitiateEdit = cmdSQLTrans
        ActForm.Cursor = Cursors.Default
        Exit Function
ErrTrap:
        ActForm.Cursor = Cursors.Default
        If Err.Number = 5 Then
            'Message modified by Michael Pastor
            MsgBox("Either another user is currently editing the specified record, or the connection is slow.", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MsgBox("This record is probably being edited by another user or there is a slow communication.")
        Else
            'Message modified by Michael Pastor
            MsgBox("InitiateEdit : " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("InitiateEdit : " & Err.Description)
        End If

    End Function

    Public Function TerminateEdit(ByVal ActForm As Object, ByRef Cmd As SqlCommand, ByVal Commit As Boolean, ByVal Update As Boolean, Optional ByVal Condition As String = "", Optional ByVal IdentInsert As Boolean = False) As Boolean
        Dim trans As SqlTransaction
        Dim dvView As New DataView
        Dim SQLString As String

        On Error GoTo ErrTrap

        TerminateEdit = False
        If Commit Then
            If Update Then
                SQLString = "Update " & ActForm.Tag & " Set "
                MakeInsertUpdateStatement(ActForm, SQLString, True)
                SQLString = SQLString & Condition 'PrepSelectQuery(SQLString, Condition)
            Else
                SQLString = "Insert into " & ActForm.Tag & "("
                MakeInsertUpdateStatement(ActForm, SQLString, False)
            End If
            If Cmd Is Nothing Then
                sqlConn.Open()
                Dim trnSql As SqlTransaction = sqlConn.BeginTransaction()
                Cmd = New SqlCommand(SQLString, sqlConn, trnSql)
            End If
            With Cmd
                If IdentInsert = True Then
                    .CommandText = "SET IDENTITY_INSERT " & ActForm.Tag & " ON; " & SQLString & "; SET IDENTITY_INSERT " & ActForm.Tag & " OFF;"
                Else
                    .CommandText = SQLString
                End If
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With

            Cmd.Transaction.Commit()
        Else
            Cmd.Transaction.Rollback()
        End If
        Cmd.Connection.Close()
        TerminateEdit = True
        Exit Function

ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("TerminateEdit : " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("TerminateEdit : " & Err.Description)
        Cmd.Transaction.Rollback()
        Cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If
        Cmd.Transaction = sqlConn.BeginTransaction()

        If Not Cmd Is Nothing Then
            'Cmd.Transaction.Rollback()
            'Cmd.Connection.Close()
        End If

    End Function

    Public Function MakeInsertUpdateStatement(ByVal ActForm As Object, ByRef SQLStr As String, ByVal Update As Boolean, Optional ByVal Seed As Int16 = 0)
        Dim Ctrl As Control
        Dim StrArr() As String
        On Error GoTo ErrTrap

        Static Dim Values As String
        If Values = "" Then
            Values = " Values("
        End If

        If Update Then
            For Each Ctrl In ActForm.Controls
                If Not (Ctrl.Tag Is Nothing) Or TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage Then
                    With Ctrl
                        StrArr = GetCtrldbFieldInfo(Ctrl)
                        If StrArr.Length >= 2 Or (TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage) Then
                            If StrArr.Length >= 3 Then
                                'If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then
                                '    GoTo NextCtrl
                                'End If
                                Select Case StrArr(TagOpts.JustView).ToUpper
                                    Case "", "UPDATE"
                                    Case Else
                                        GoTo NextCtrl
                                End Select
                            End If
                            Select Case Ctrl.GetType().ToString
                                Case "System.Windows.Forms.TextBox", "RoutesModule.MyTextBox", "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                                    SQLStr += StrArr(TagOpts.dtFieldName) & " = '" & Replace(.Text, "'", "''") & "', "
                                Case "System.Windows.Forms.Label"
                                    'If .Text.LastIndexOf(":") > 0 Then
                                    'SQLStr += StrArr(1) & " = '" & .Text.Substring(0, .Text.LastIndexOf(":")) & "', "
                                    'Else
                                    'SQLStr += StrArr(1) & " = '" & .Text & "', "
                                    'End If
                                Case "Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit"
                                    Dim TempCtrl As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
                                    tempctrl = Ctrl
                                    Select Case tempctrl.EditAs
                                        Case Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
                                            SQLStr += StrArr(TagOpts.dtFieldName) & " = " & IIf(tempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) = "", "NULL", "'" & TempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals) & "'") & ", "
                                        Case Infragistics.Win.UltraWinMaskedEdit.EditAsType.Time
                                            SQLStr += StrArr(TagOpts.dtFieldName) & " = " & IIf(tempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) = "", "''", "'" & TempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals) & "'") & ", "
                                        Case Else
                                            SQLStr += StrArr(TagOpts.dtFieldName) & " = '" & tempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) & "', "
                                    End Select
                                Case "System.Windows.Forms.ComboBox"
                                    Dim TempCtrl As ComboBox
                                    TempCtrl = Ctrl
                                    If (StrArr.Length - 1) >= TagOpts.SavCboTxt Then
                                        If StrArr(TagOpts.SavCboTxt) = "1" Then
                                            SQLStr += StrArr(TagOpts.dtFieldName) & " = '" & TempCtrl.Text & "', "
                                            Exit Select
                                        End If
                                    End If
                                    SQLStr += StrArr(TagOpts.dtFieldName) & " = '" & TempCtrl.SelectedValue & "', "

                                Case "Infragistics.Win.UltraWinGrid.UltraCombo"
                                    Dim TempCtrl As Infragistics.Win.UltraWinGrid.UltraCombo
                                    TempCtrl = Ctrl
                                    If (StrArr.Length - 1) >= TagOpts.SavCboTxt Then
                                        If StrArr(TagOpts.SavCboTxt) = "1" Then
                                            SQLStr += StrArr(TagOpts.dtFieldName) & " = '" & TempCtrl.Text & "', "
                                            Exit Select
                                        End If
                                    End If
                                    SQLStr += StrArr(TagOpts.dtFieldName) & " = '" & TempCtrl.Value & "', "

                                Case "Infragistics.Win.UltraWinEditors.UltraCheckEditor"
                                    Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraCheckEditor
                                    tempctrl = Ctrl
                                    SQLStr += StrArr(TagOpts.dtFieldName) & " = " & CType(tempctrl.Checked, Short) & ", "
                                Case "System.Windows.Forms.CheckBox"
                                    Dim TempCtrl As CheckBox
                                    tempctrl = Ctrl
                                    SQLStr += StrArr(TagOpts.dtFieldName) & " = " & CType(tempctrl.Checked, Short) & ", "
                                Case "System.Windows.Forms.RadioButton"
                                    Dim TempCtrl As RadioButton
                                    tempctrl = Ctrl
                                    If tempctrl.Checked = True Then
                                        SQLStr += StrArr(TagOpts.dtFieldName) & " = '" & StrArr(TagOpts.DefaultVal) & "', "
                                    End If
                                Case "System.Windows.Forms.DateTimePicker"
                                    Dim TempCtrl As DateTimePicker
                                    tempctrl = Ctrl
                                    SQLStr += StrArr(TagOpts.dtFieldName) & " = '" & Format(tempctrl.Value, "MM/dd/yyyy") & "', "
                                Case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                                    Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
                                    TempCtrl = Ctrl
                                    SQLStr += StrArr(TagOpts.dtFieldName) & " = " & IIf(tempctrl.Value Is Nothing, "NULL", "'" & Format(Tempctrl.Value, "MM/dd/yyyy") & "'") & ", "
                                Case "System.Windows.Forms.GroupBox", "System.Windows.Forms.Panel"
                                    MakeInsertUpdateStatement(Ctrl, SQLStr, Update, Seed + 1)
                                Case "System.Windows.Forms.TabControl", "System.Windows.Forms.TabPage"
                                    If Ctrl.Tag = Nothing Then
                                        MakeInsertUpdateStatement(Ctrl, SQLStr, Update, Seed + 1)
                                    ElseIf Ctrl.Tag = "" Then
                                        MakeInsertUpdateStatement(Ctrl, SQLStr, Update, Seed + 1)
                                    End If

                                    'MakeInsertUpdateStatement(Ctrl, SQLStr, Update, Seed + 1)
                            End Select
                        End If
                    End With
                End If
NextCtrl:
            Next
            'If TypeOf ActForm Is Form Then
            If Seed = 0 Then
                SQLStr = SQLStr.Substring(0, Len(SQLStr) - 2)
            End If
        Else
            For Each Ctrl In ActForm.Controls
                If Not (Ctrl.Tag Is Nothing) Or TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage Then
                    With Ctrl
                        StrArr = GetCtrldbFieldInfo(Ctrl)
                        If StrArr.Length >= 2 Or (TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage) Then
                            If StrArr.Length >= 3 Then
                                'If StrArr(TagOpts.JustView) <> "" Then
                                '    GoTo NextCtrl2
                                'End If
                                Select Case StrArr(TagOpts.JustView).ToUpper
                                    Case "", "INSERT"
                                    Case Else
                                        GoTo NextCtrl2
                                End Select
                            End If
                            Select Case Ctrl.GetType().ToString
                                Case "System.Windows.Forms.TextBox", "RoutesModule.MyTextBox", "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                                    SQLStr += StrArr(1) & ", "
                                    Values += "'" & Replace(.Text, "'", "''") & "', "
                                Case "System.Windows.Forms.Label"
                                    'SQLStr += StrArr(1) & ", "
                                    'Values += "'" & .Text & "', "
                                Case "Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit"
                                    Dim TempCtrl As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
                                    tempctrl = Ctrl
                                    SQLStr += StrArr(TagOpts.dtFieldName) & ", "
                                    Select Case tempctrl.EditAs
                                        Case Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
                                            Values += IIf(tempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) = "", "NULL", "'" & TempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals) & "'") & ", "
                                        Case Infragistics.Win.UltraWinMaskedEdit.EditAsType.Time
                                            Values += IIf(tempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) = "", "''", "'" & TempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals) & "'") & ", "
                                        Case Else
                                            Values += "'" & tempCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) & "', "
                                    End Select
                                Case "System.Windows.Forms.ComboBox"
                                    Dim TempCtrl As ComboBox
                                    TempCtrl = Ctrl
                                    SQLStr += StrArr(TagOpts.dtFieldName) & ", "
                                    If (StrArr.Length - 1) >= TagOpts.SavCboTxt Then
                                        If StrArr(TagOpts.SavCboTxt) = "1" Then
                                            Values += "'" & TempCtrl.Text & "', "
                                            Exit Select
                                        End If
                                    End If
                                    Values += "'" & TempCtrl.SelectedValue & "', "

                                Case "Infragistics.Win.UltraWinGrid.UltraCombo"
                                    Dim TempCtrl As Infragistics.Win.UltraWinGrid.UltraCombo
                                    TempCtrl = Ctrl
                                    SQLStr += StrArr(TagOpts.dtFieldName) & ", "
                                    If (StrArr.Length - 1) >= TagOpts.SavCboTxt Then
                                        If StrArr(TagOpts.SavCboTxt) = "1" Then
                                            Values += "'" & TempCtrl.Text & "', "
                                            Exit Select
                                        End If
                                    End If

                                    Values += "'" & TempCtrl.Value & "', "

                                Case "Infragistics.Win.UltraWinEditors.UltraCheckEditor"
                                    Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraCheckEditor
                                    tempctrl = Ctrl
                                    SQLStr += StrArr(TagOpts.dtFieldName) & ", "
                                    Values += "" & CType(tempctrl.Checked, Short) & ", "
                                Case "System.Windows.Forms.CheckBox"
                                    Dim TempCtrl As CheckBox
                                    tempctrl = Ctrl
                                    SQLStr += StrArr(TagOpts.dtFieldName) & ", "
                                    Values += "" & CType(tempctrl.Checked, Short) & ", "
                                Case "System.Windows.Forms.RadioButton"
                                    Dim TempCtrl As RadioButton
                                    tempctrl = Ctrl
                                    If tempctrl.Checked = True Then
                                        SQLStr += StrArr(TagOpts.dtFieldName) & ", "
                                        Values += "'" & StrArr(TagOpts.DefaultVal) & "', "
                                    End If
                                Case "System.Windows.Forms.DateTimePicker"
                                    Dim TempCtrl As DateTimePicker
                                    tempctrl = Ctrl
                                    'SQLStr += StrArr(TagOpts.dtFieldName) & " = '" & Format(tempctrl.Value, "MM/dd/yyyy") & "', "
                                    SQLStr += StrArr(TagOpts.dtFieldName) & ", "
                                    Values += "'" & Format(tempctrl.Value, "MM/dd/yyyy") & "', "
                                Case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                                    Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
                                    TempCtrl = Ctrl
                                    SQLStr += StrArr(TagOpts.dtFieldName) & ", "
                                    If tempctrl.Value Is Nothing Then
                                        Values += "NULL, "
                                    Else
                                        Values += "'" & Format(tempctrl.Value, "MM/dd/yyyy") & "', "
                                    End If
                                Case "System.Windows.Forms.GroupBox", "System.Windows.Forms.Panel"
                                    MakeInsertUpdateStatement(Ctrl, SQLStr, Update, Seed + 1)
                                Case "System.Windows.Forms.TabControl", "System.Windows.Forms.TabPage"
                                    If Ctrl.Tag = Nothing Then
                                        MakeInsertUpdateStatement(Ctrl, SQLStr, Update, Seed + 1)
                                    ElseIf Ctrl.Tag = "" Then
                                        MakeInsertUpdateStatement(Ctrl, SQLStr, Update, Seed + 1)
                                    End If
                            End Select
                        End If
                    End With
                End If
NextCtrl2:
            Next
            'If TypeOf ActForm Is Form Then
            If Seed = 0 Then
                SQLStr = SQLStr.Substring(0, Len(SQLStr) - 2)
                SQLStr += ") " & Values.Substring(0, Len(Values) - 2) & ")"
                Values = ""
            End If
        End If
        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("MakeInsertUpdateStatement: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("MakeInsertUpdateStatement: " & Err.Description)
        'Resume
    End Function

    Public Function FillCombo(ByRef Cbo As ComboBox, Optional ByVal DefVal As String = "", Optional ByVal Condition As String = "", Optional ByVal SubstQry As String = "", Optional ByVal DBPath As String = "") As DataView
        Dim dtaCbo As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim TagParts() As String
        Dim SQLQuery As String
        Dim dtView As New DataView
        Dim OrdFld, FldCode, FldLabel, FldCodeArr(), FldLabelArr() As String

        FillCombo = Nothing
        TagParts = Cbo.Tag.ToString.Split(".")
        If TagParts.Length < 9 Then
            OrdFld = TagParts(TagOpts.LabelField)
        Else
            OrdFld = TagParts(TagOpts.cboOrdFld)
        End If

        FldCode = "fldCode"
        FldLabel = "fldLabel"

        If SubstQry <> "" Then
            SQLQuery = SubstQry
            If SQLQuery.IndexOf("AS fldCode") >= 0 Then
                'FldCode = "fldCode"
                'FldLabel = "fldLabel"
            Else
                FldCodeArr = TagParts(TagOpts.CodeField).Split(" AS ")
                FldLabelArr = TagParts(TagOpts.LabelField).Split(" AS ")
                FldCode = FldCodeArr(FldCodeArr.Length - 1)
                FldLabel = FldLabelArr(FldLabelArr.Length - 1)
            End If
        Else
            SQLQuery = "Select " & TagParts(TagOpts.CodeField) & " as fldCode, " & TagParts(TagOpts.LabelField) & " as fldLabel from " & DBPath & TagParts(TagOpts.FillTable) & " ORDER BY " & OrdFld
        End If


        'SQLQuery = "Select " & TagParts(TagOpts.CodeField) & " as fldCode, " & TagParts(TagOpts.LabelField) & " as fldLabel from " & TagParts(TagOpts.FillTable) & " ORDER BY " & OrdFld

        If PopulateDataset2(dtaCbo, dtSet, PrepSelectQuery(SQLQuery, Condition)) Is Nothing Then
            dtView.Dispose()
            dtView = Nothing
            Exit Function
        End If

        dtView.Table = dtSet.Tables(TagParts(TagOpts.FillTable))

        If SubstQry <> "" Then
            dtView.Table = dtSet.Tables(0)
        Else
            dtView.Table = dtSet.Tables(DBPath & TagParts(TagOpts.FillTable))
        End If

        Cbo.DataSource = dtView 'dtSet.Tables("State")

        'If dtView.Table.Columns("fldLabel").DataType.ToString = "System.DateTime" Then
        '    Cbo.DisplayMember = dtView.Table.Columns("fldLabel").ToString
        'End If


        Cbo.DisplayMember = dtView.Table.Columns(FldLabel).ToString
        Cbo.ValueMember = dtView.Table.Columns(FldCode).ToString

        If DefVal <> "" Then
            Cbo.SelectedValue = DefVal
        Else
            Cbo.SelectedIndex = 0
        End If

        FillCombo = dtView

    End Function

    Public Function FillCheckedListBox(ByRef Cbo As System.Windows.Forms.CheckedListBox, Optional ByVal DefVal As String = "", Optional ByVal Condition As String = "", Optional ByVal SubstQry As String = "", Optional ByVal DBPath As String = "", Optional ByVal ColHdrVis As Boolean = False, Optional ByVal HideFldCode As Boolean = True) As DataView

        Dim dtaCbo As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim TagParts() As String
        Dim SQLQuery As String
        Dim dtView As New DataView
        Dim OrdFld, FldCode, FldLabel, FldCodeArr(), FldLabelArr() As String


        'TagParts = Cbo.Tag.ToString.Split(".")
        'If TagParts.Length < 9 Then
        '    OrdFld = TagParts(TagOpts.LabelField)
        'Else
        '    OrdFld = TagParts(TagOpts.cboOrdFld)
        'End If

        FldCode = "fldCode"
        FldLabel = "fldLabel"

        'If SubstQry <> "" Then
        '    SQLQuery = SubstQry.ToUpper

        '    If SQLQuery.IndexOf("AS fldCode".ToUpper) >= 0 Then
        '        'FldCode = "fldCode"
        '        'FldLabel = "fldLabel"
        '    Else
        '        'FldCode = TagParts(TagOpts.CodeField)
        '        'FldLabel = TagParts(TagOpts.LabelField)
        '        FldCodeArr = TagParts(TagOpts.CodeField).Split(" AS ")
        '        FldLabelArr = TagParts(TagOpts.LabelField).Split(" AS ")
        '        FldCode = FldCodeArr(FldCodeArr.Length - 1)
        '        FldLabel = FldLabelArr(FldLabelArr.Length - 1)
        '    End If
        'Else
        '    SQLQuery = "Select " & TagParts(TagOpts.CodeField) & " as fldCode, " & TagParts(TagOpts.LabelField) & " as fldLabel from " & DBPath & TagParts(TagOpts.FillTable) & " ORDER BY " & OrdFld
        'End If

        PopulateDataset2(dtaCbo, dtSet, PrepSelectQuery(SubstQry, Condition))

        If SubstQry <> "" Then
            dtView.Table = dtSet.Tables(0)
            'Else
            '    dtView.Table = dtSet.Tables(DBPath & TagParts(TagOpts.FillTable))
        End If

        'Cbo.DisplayMember = dtView.Table.Columns(FldLabel).ToString
        'Cbo.ValueMember = dtView.Table.Columns(FldCode).ToString
        'Cbo.DataSource = dtView 'dtSet.Tables("State")
        'Cbo.DisplayMember = dtView.Table.Columns(FldLabel).ToString
        'Cbo.ValueMember = dtView.Table.Columns(FldCode).ToString
        'Cbo.DataSource = dtView 'dtSet.Tables("State")


        With Cbo
            .DataSource = New DataView(dtSet.Tables(0))
            .DisplayMember = "FldLabel"
            .ValueMember = "FldCode"
        End With

        With Cbo
            .DataSource = New DataView(dtSet.Tables(0))
            .DisplayMember = "FldLabel"
            .ValueMember = "FldCode"
        End With

        Cbo.CheckOnClick = True


        ''If dtView.Table.Columns("fldLabel").DataType.ToString = "System.DateTime" Then
        ''    Cbo.DisplayMember = dtView.Table.Columns("fldLabel").ToString
        ''End If


        'If DefVal <> "" Then
        '    Cbo.Value = DefVal
        'Else
        '    'Cbo.PerformAction(Infragistics.Win.UltraWinGrid.UltraComboAction.FirstRow)
        'End If
        'Cbo.DisplayLayout.Bands(0).HeaderVisible = False
        'Cbo.DisplayLayout.Bands(0).ColHeadersVisible = ColHdrVis
        'Cbo.DisplayLayout.Bands(0).Columns(FldCode).Hidden = HideFldCode
        'Cbo.AutoEdit = True
        'Cbo.DisplayLayout.Bands(0).Header.Appearance.BackColor = Color.Aqua
        'Cbo.DisplayLayout.Bands(0).Columns(0).Header.Appearance.BackColor = Color.Aqua

        FillCheckedListBox = dtView

    End Function

    Public Function FillUCombo(ByRef Cbo As Infragistics.Win.UltraWinGrid.UltraCombo, Optional ByVal DefVal As String = "", Optional ByVal Condition As String = "", Optional ByVal SubstQry As String = "", Optional ByVal DBPath As String = "", Optional ByVal ColHdrVis As Boolean = False, Optional ByVal HideFldCode As Boolean = True) As DataView
        Dim dtaCbo As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim TagParts() As String
        Dim SQLQuery As String
        Dim dtView As New DataView
        Dim OrdFld, FldCode, FldLabel, FldCodeArr(), FldLabelArr() As String


        TagParts = Cbo.Tag.ToString.Split(".")
        If TagParts.Length < 9 Then
            OrdFld = TagParts(TagOpts.LabelField)
        Else
            OrdFld = TagParts(TagOpts.cboOrdFld)
        End If

        FldCode = "fldCode"
        FldLabel = "fldLabel"

        If SubstQry <> "" Then
            SQLQuery = SubstQry.ToUpper

            If SQLQuery.IndexOf("AS fldCode".ToUpper) >= 0 Then
                'FldCode = "fldCode"
                'FldLabel = "fldLabel"
            Else
                'FldCode = TagParts(TagOpts.CodeField)
                'FldLabel = TagParts(TagOpts.LabelField)
                FldCodeArr = TagParts(TagOpts.CodeField).Split(" AS ")
                FldLabelArr = TagParts(TagOpts.LabelField).Split(" AS ")
                FldCode = FldCodeArr(FldCodeArr.Length - 1)
                FldLabel = FldLabelArr(FldLabelArr.Length - 1)
            End If
        Else
            SQLQuery = "Select " & TagParts(TagOpts.CodeField) & " as fldCode, " & TagParts(TagOpts.LabelField) & " as fldLabel from " & DBPath & TagParts(TagOpts.FillTable) & " ORDER BY " & OrdFld
        End If

        PopulateDataset2(dtaCbo, dtSet, PrepSelectQuery(SQLQuery, Condition))

        If SubstQry <> "" Then
            dtView.Table = dtSet.Tables(0)
        Else
            dtView.Table = dtSet.Tables(DBPath & TagParts(TagOpts.FillTable))
        End If

        Cbo.DisplayMember = dtView.Table.Columns(FldLabel).ToString
        Cbo.ValueMember = dtView.Table.Columns(FldCode).ToString

        Cbo.DataSource = dtView 'dtSet.Tables("State")

        'If dtView.Table.Columns("fldLabel").DataType.ToString = "System.DateTime" Then
        '    Cbo.DisplayMember = dtView.Table.Columns("fldLabel").ToString
        'End If


        If DefVal <> "" Then
            Cbo.Value = DefVal
        Else
            'Cbo.PerformAction(Infragistics.Win.UltraWinGrid.UltraComboAction.FirstRow)
        End If
        Cbo.DisplayLayout.Bands(0).HeaderVisible = False
        Cbo.DisplayLayout.Bands(0).ColHeadersVisible = ColHdrVis
        Cbo.DisplayLayout.Bands(0).Columns(FldCode).Hidden = HideFldCode
        Cbo.AutoEdit = True
        Cbo.DisplayLayout.Bands(0).Header.Appearance.BackColor = Color.Aqua
        Cbo.DisplayLayout.Bands(0).Columns(0).Header.Appearance.BackColor = Color.Aqua

        FillUCombo = dtView

    End Function

    Public Function FillUltraGrid(ByRef UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByRef dtSet As Object, Optional ByVal SortCol As Integer = -1, Optional ByVal HidColArr() As String = Nothing, Optional ByVal TableIndex As Int16 = 0)
        Dim ugListLayout As New Infragistics.Win.UltraWinGrid.UltraGridLayout
        Dim dvOffice As New DataView
        Dim EvenRowApp As New Infragistics.Win.Appearance
        Dim Obj As Object
        Dim j, k As Integer

        UltraGrid.DataSource = Nothing
        Obj = UltraGrid.FindForm
        While Not (TypeOf Obj Is Form)
            Obj = Obj.GetContainerControl()
        End While

        'Correct Larter : dvOffice.Table = dtSet.Tables(Obj.Tag)
        If TypeOf dtSet Is DataSet Then
            dvOffice.Table = dtSet.Tables(TableIndex)
        ElseIf TypeOf dtSet Is DataTable Then
            dvOffice.Table = dtSet
        Else
            'Message modified by Michael Pastor
            MsgBox("Input for 'dtSet' is of an unrecognized type.", MsgBoxStyle.Exclamation, "Data Invalid")
            '- MsgBox("Unknow Type for dtSet.", MsgBoxStyle.Critical, "FillUltraGrid")
            Exit Function
        End If

        EvenRowApp.BackColor = System.Drawing.Color.Yellow
        ugListLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TabRepeat
        ugListLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False
        ugListLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        ugListLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        ugListLayout.Override.MaxSelectedRows = 1
        ugListLayout.Override.RowAlternateAppearance = EvenRowApp
        ugListLayout.AutoFitColumns = True

        'ugListLayout.Override.DefaultColWidth = 0

        UltraGrid.Layouts.Add(ugListLayout)
        UltraGrid.DisplayLayout.Override.AllowAddNew = ugListLayout.Override.AllowAddNew
        UltraGrid.DisplayLayout.Override.AllowDelete = ugListLayout.Override.AllowDelete
        UltraGrid.DisplayLayout.Override.AllowUpdate = ugListLayout.Override.AllowUpdate
        UltraGrid.DisplayLayout.Override.CellClickAction = ugListLayout.Override.CellClickAction
        UltraGrid.DisplayLayout.Override.MaxSelectedRows = ugListLayout.Override.MaxSelectedRows
        UltraGrid.DisplayLayout.Override.RowAlternateAppearance = ugListLayout.Override.RowAlternateAppearance
        'UltraGrid.DisplayLayout.Override.DefaultColWidth = ugListLayout.Override.DefaultColWidth

        UltraGrid.DataSource = dvOffice

        If dvOffice.Count > 0 Then

            If SortCol >= 0 Then
                UltraGrid.DisplayLayout.Bands(0).SortedColumns.Clear()
                UltraGrid.DisplayLayout.Bands(0).Columns(SortCol).SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
                'UltraGrid.ActiveRow = UltraGrid.Rows.GetItem(0)
                UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow, False, False)
            End If
        End If

        Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim ColLen, MaxLen, CharWidth As Integer

        CharWidth = CellSize(UltraGrid).Width
        MaxLen = 0

        For k = 0 To UltraGrid.DisplayLayout.Bands.Count - 1
            For Each ugcol In UltraGrid.DisplayLayout.Bands(k).Columns
                MaxLen = 0
                If InStr(ugcol.ToString, "Phone", CompareMethod.Text) > 0 Or InStr(ugcol.ToString, "Fax", CompareMethod.Text) > 0 Then
                    ugcol.MaskInput = "(###)###-####"
                    ugcol.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    ugcol.MinWidth = 0
                End If
                Select Case ugcol.DataType.ToString
                    Case "System.Decimal"
                        ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                        ugcol.Format = "#0.00##"
                    Case "System.Int32", "System.Int16", "System.Int64"
                        ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    Case "System.String"
                        ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                    Case Else
                        ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default

                End Select

                If Not HidColArr Is Nothing Then
                    For j = 0 To HidColArr.GetUpperBound(0)
                        If ugcol.ToString.ToUpper = HidColArr(j).ToUpper Then
                            ugcol.Hidden = True
                        End If
                    Next
                End If
                '''For Each ugrow In UltraGrid.Rows
                '''    If Not ugrow.ListObject Is Nothing Then
                '''        ColLen = Len(ugrow.Cells(ugcol).Text)
                '''        'ultragrid.CreateGraphics
                '''        ColLen *= CharWidth
                '''        If MaxLen < ColLen Then
                '''            MaxLen = ColLen
                '''            'Else
                '''            '    ugcol.Width = -1
                '''            '    Exit For
                '''        End If
                '''    End If
                '''Next
                '''If (Len(ugcol.ToString) + 2) * CharWidth > MaxLen Then MaxLen = (Len(ugcol.ToString) + 2) * CharWidth
                '''ugcol.Width = MaxLen
                '''UltraGrid.DisplayLayout.Override.DefaultColWidth = MaxLen

                'ugcol.PerformAutoResize()

                'UltraGrid.DisplayLayout.Bands(0).Columns(0).Layout.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            Next ugcol

        Next k
        'UltraGrid.DisplayLayout.AutoFitColumns = ugListLayout.AutoFitColumns
        UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        If UltraGrid.Rows.Count > 0 Then
            UltraGrid.ActiveRow = UltraGrid.Rows(0)
        End If

    End Function

    Public Function FillUltraGrid2(ByRef UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByRef dtSet As DataSet, Optional ByVal SortCol As Integer = -1, Optional ByVal HidColArr() As String = Nothing, Optional ByRef dtSet2 As DataSet = Nothing)
        Dim ugListLayout As New Infragistics.Win.UltraWinGrid.UltraGridLayout
        Dim EvenRowApp As New Infragistics.Win.Appearance
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim i As Int32

        Dim dvOffice As New DataView
        Dim row, row2 As DataRow
        Dim col, col2 As DataColumn
        Dim Values() As Object


        If Not dtSet2 Is Nothing Then
            dtSet2.Tables.Clear()

            dtSet2.Tables.Add("TempTable")

            '''col2 = dtSet2.Tables(0).Columns.Add("Col1")
            ''''col2.DataType = System.Type.GetType("System.Boolean")
            '''row2 = dtSet2.Tables(0).NewRow()
            '''row2(0) = True
            '''dtSet2.Tables(0).Rows.Add(row2)
            '''Exit Function
            dtSet2.Tables.Add("Table") '(dtSet.Tables(0).Clone)
            For Each col In dtSet.Tables(0).Columns
                col2 = dtSet2.Tables(0).Columns.Add(col.ToString)
                col2.DataType = col.DataType
            Next
            'values = dtSet.Tables(0).Row
            For Each row In dtSet.Tables(0).Rows
                row2 = dtSet2.Tables(0).NewRow()
                For i = 0 To row.ItemArray.GetLength(0) - 1
                    row2(i) = row(i)
                Next
                dtSet2.Tables(0).Rows.Add(row2)
            Next
            Exit Function
        End If









        For i = 0 To UltraGrid.DisplayLayout.Bands(0).Columns.UnboundColumnsCount - 1
            UltraGrid.DisplayLayout.Bands(0).Columns.Remove(i)
        Next

        For Each col In dtSet.Tables(0).Columns
            ugcol = UltraGrid.DisplayLayout.Bands(0).Columns.Add(col.ToString)
            If InStr(ugcol.ToString, "Phone", CompareMethod.Text) > 0 Or InStr(ugcol.ToString, "Fax", CompareMethod.Text) > 0 Then
                ugcol.MaskInput = "(###)###-####"
                ugcol.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                ugcol.MinWidth = 0
            End If
            Select Case col.DataType.ToString
                Case "System.Boolean"
                    ugcol.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                    ugcol.DataType = System.Type.GetType("Boolean")
                Case "System.Decimal"
                    ugcol.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default
                    ugcol.DataType = System.Type.GetType("Decimal")
                    ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    ugcol.Format = "#0.00"
                Case "System.Int32", "System.Int16", "System.Int64"
                    ugcol.DataType = System.Type.GetType("Int32")
                    ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                Case "System.String"
                    ugcol.DataType = System.Type.GetType("String")
                    ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                Case Else
                    ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default

            End Select
        Next

        dvOffice.Table = dtSet.Tables(0)

        'UltraGrid.DataSource = Nothing

        'EvenRowApp.BackColor = System.Drawing.Color.Yellow
        ugListLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        ugListLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False
        'ugListLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        'ugListLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        ugListLayout.Override.MaxSelectedRows = 1
        ugListLayout.Override.RowAlternateAppearance = EvenRowApp
        ugListLayout.AutoFitColumns = True

        'ugListLayout.Override.DefaultColWidth = 0

        UltraGrid.Layouts.Add(ugListLayout)
        UltraGrid.DisplayLayout.Override.AllowAddNew = ugListLayout.Override.AllowAddNew
        UltraGrid.DisplayLayout.Override.AllowDelete = ugListLayout.Override.AllowDelete
        UltraGrid.DisplayLayout.Override.AllowUpdate = ugListLayout.Override.AllowUpdate
        UltraGrid.DisplayLayout.Override.CellClickAction = ugListLayout.Override.CellClickAction
        UltraGrid.DisplayLayout.Override.MaxSelectedRows = ugListLayout.Override.MaxSelectedRows
        UltraGrid.DisplayLayout.Override.RowAlternateAppearance = ugListLayout.Override.RowAlternateAppearance
        'UltraGrid.DisplayLayout.Override.DefaultColWidth = ugListLayout.Override.DefaultColWidth


        UltraGrid.DisplayLayout.Bands(0).AddNew()


        ''UltraGrid.DataSource = dvOffice

        ''If dvOffice.Count > 0 Then

        ''    If SortCol >= 0 Then
        ''        UltraGrid.DisplayLayout.Bands(0).SortedColumns.Clear()
        ''        UltraGrid.DisplayLayout.Bands(0).Columns(SortCol).SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
        ''        UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow, False, False)
        ''    End If
        ''End If

        ''Dim ColLen, MaxLen, CharWidth As Integer

        ''CharWidth = CellSize(UltraGrid).Width
        ''MaxLen = 0

        ''For Each ugcol In UltraGrid.DisplayLayout.Bands(0).Columns
        ''    MaxLen = 0
        ''    If InStr(ugcol.ToString, "Phone", CompareMethod.Text) > 0 Or InStr(ugcol.ToString, "Fax", CompareMethod.Text) > 0 Then
        ''        ugcol.MaskInput = "(###)###-####"
        ''        ugcol.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
        ''        ugcol.MinWidth = 0
        ''    End If
        ''    Select Case ugcol.DataType.ToString
        ''        Case "System.Decimal"
        ''            ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        ''            ugcol.Format = "#0.00"
        ''        Case "System.Int32", "System.Int16", "System.Int64"
        ''            ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        ''        Case "System.String"
        ''            ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
        ''        Case Else
        ''            ugcol.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default

        ''    End Select

        ''    If Not HidColArr Is Nothing Then
        ''        For j = 0 To HidColArr.GetUpperBound(0)
        ''            If ugcol.ToString.ToUpper = HidColArr(j).ToUpper Then
        ''                ugcol.Hidden = True
        ''            End If
        ''        Next
        ''    End If
        ''    For Each ugrow In UltraGrid.Rows
        ''        If Not ugrow.ListObject Is Nothing Then
        ''            ColLen = Len(ugrow.Cells(ugcol).Text)
        ''            'ultragrid.CreateGraphics
        ''            ColLen *= CharWidth
        ''            If MaxLen < ColLen Then
        ''                MaxLen = ColLen
        ''                'Else
        ''                '    ugcol.Width = -1
        ''                '    Exit For
        ''            End If
        ''        End If
        ''    Next
        ''    If (Len(ugcol.ToString) + 2) * CharWidth > MaxLen Then MaxLen = (Len(ugcol.ToString) + 2) * CharWidth
        ''    ugcol.Width = MaxLen
        ''    UltraGrid.DisplayLayout.Override.DefaultColWidth = MaxLen
        ''    'ugcol.PerformAutoResize()

        ''    'UltraGrid.DisplayLayout.Bands(0).Columns(0).Layout.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        ''Next

        'UltraGrid.DisplayLayout.AutoFitColumns = ugListLayout.AutoFitColumns


    End Function


    Public Function FormLoadFromGrid(ByRef ActForm As Object, ByRef UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Ctrl As Control
        Dim Arr() As Object
        Dim GridColCaption As String


        'Exit Function
        On Error GoTo ErrTrap


        ClearForm(ActForm)
        ugRow = UltraGrid.ActiveRow

        If ugRow Is Nothing Then Exit Function
        If ugRow.ListObject Is Nothing Then Exit Function
        'ugRow.ChildBands.Count()
        'ugRow.HasChild()
        'ugRow.IsExpandable()
        'ugRow.ListObject()
        'ugRow.VisibleIndex()

        Dim StrArr() As String
        Dim DataObj As Object


        For Each Ctrl In ActForm.Controls
            If Not (Ctrl.Tag Is Nothing) Or TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage Then  'Or TypeOf Ctrl Is Infragistics.Win.UltraWinGrid.UltraGrid
                With Ctrl
                    StrArr = GetCtrldbFieldInfo(Ctrl)
                    If StrArr.Length >= 2 Or (TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage) Then ' Or TypeOf Ctrl Is Infragistics.Win.UltraWinGrid.UltraGrid
                        If StrArr.Length >= (TagOpts.GColCap + 1) Then
                            GridColCaption = StrArr(TagOpts.GColCap)
                            If GridColCaption.Trim = "" Then
                                GridColCaption = StrArr(TagOpts.dtFieldName).Trim
                            End If
                        ElseIf StrArr.Length >= (TagOpts.dtFieldName + 1) Then
                            GridColCaption = StrArr(TagOpts.dtFieldName).Trim
                        Else
                            GridColCaption = ""
                        End If
                        If GridColCaption.ToUpper = "_NOUPD_" Then GoTo NextCtrl
                        Select Case Ctrl.GetType().ToString
                            Case "System.Windows.Forms.TextBox", "RoutesModule.MyTextBox", "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                                .Text = ugRow.Cells(GridColCaption).Text 'DataObj.Item(StrArr(1))
                            Case "System.Windows.Forms.Label"
                                .Text = ugRow.Cells(GridColCaption).Text & ":" 'DataObj.Item(GridColCaption)
                            Case "Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit"
                                .Text = ugRow.Cells(GridColCaption).Text 'DataObj.Item(StrArr(1)).ToString
                            Case "System.Windows.Forms.ComboBox"
                                Dim TempCtrl As ComboBox
                                TempCtrl = Ctrl
                                TempCtrl.SelectedValue = ugRow.Cells(GridColCaption).Text 'DataObj.Item(StrArr(1))

                            Case "Infragistics.Win.UltraWinGrid.UltraCombo"
                                Dim TempCtrl As Infragistics.Win.UltraWinGrid.UltraCombo
                                TempCtrl = Ctrl
                                TempCtrl.Value = ugRow.Cells(GridColCaption).Text 'DataObj.Item(StrArr(1))

                            Case "System.Windows.Forms.DateTimePicker"
                                Dim TempCtrl As DateTimePicker
                                tempctrl = Ctrl
                                tempctrl.Value = ugRow.Cells(GridColCaption).Text
                            Case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                                Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
                                TempCtrl = Ctrl
                                tempctrl.Value = ugRow.Cells(GridColCaption).Text
                            Case "Infragistics.Win.UltraWinEditors.UltraCheckEditor"
                                Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraCheckEditor
                                tempctrl = Ctrl
                                tempctrl.Checked = ugRow.Cells(GridColCaption).Text 'DataObj.Item(StrArr(1))
                            Case "System.Windows.Forms.CheckBox"
                                Dim TempCtrl As CheckBox
                                tempctrl = Ctrl
                                tempctrl.Checked = ugRow.Cells(GridColCaption).Text 'DataObj.Item(StrArr(1))
                            Case "System.Windows.Forms.RadioButton"
                                Dim TempCtrl As RadioButton
                                tempctrl = Ctrl
                                If StrArr(TagOpts.DefaultVal) = ugRow.Cells(GridColCaption).Text Then
                                    tempctrl.Checked = True
                                End If
                            Case "System.Windows.Forms.GroupBox", "System.Windows.Forms.Panel"
                                FormLoadFromGrid(Ctrl, UltraGrid)
                            Case "System.Windows.Forms.TabControl", "System.Windows.Forms.TabPage"
                                If Ctrl.Tag = Nothing Then
                                    FormLoadFromGrid(Ctrl, UltraGrid)
                                ElseIf Ctrl.Tag = "" Then
                                    FormLoadFromGrid(Ctrl, UltraGrid)
                                End If

                        End Select
                    End If
                End With
            End If
NextCtrl:
        Next


        'Arr = ugRow.Cells.All

        'gCity.Text = ugRow.Cells("City").Text
        'gZipcode.Text = ugRow.Cells("Zipcode").Text
        'gPhone.Focus()
        'gState.SelectedValue = ugRow.Cells("State").Text
        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("FormLoadFromGrid : " & Err.Number & " - " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("FormLoadFromGrid : " & Err.Number & " - " & Err.Description)
        'Resume
    End Function

    Public Function FormLoadFieldRow(ByRef ActForm As Object, ByVal SQLSelect As String)
        Dim Arr() As Object
        Dim Cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim TagName As String
        On Error GoTo ErrTrap

        sqlConn.Open()

        Cmd = New SqlCommand(SQLSelect, sqlConn)

        With Cmd
            .CommandType = CommandType.Text
            '.ExecuteNonQuery()
            dr = .ExecuteReader
        End With

        While dr.Read
            TagName = dr("NAME")
            SetCtrlVal(ActForm, TagName, dr("Value"))
        End While

        dr.Close()
        Cmd.Connection.Close()
        Cmd = Nothing

        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("FormLoadFromGrid : " & Err.Number & " - " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("FormLoadFieldRow : " & Err.Number & " - " & Err.Description)
        dr.Close()
        Cmd.Connection.Close()
        Cmd = Nothing
    End Function

    Public Function SetCtrlVal(ByVal Container As Object, ByVal TagName As String, ByVal Value As String)
        Dim Ctrl As Control
        Dim StrArr() As String
        On Error GoTo ErrTrap


        For Each Ctrl In Container.Controls
            If TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage Then
                SetCtrlVal(Ctrl, TagName, Value)
            ElseIf Not (Ctrl.Tag Is Nothing) Then  'And Not (TypeOf Ctrl Is Infragistics.Win.UltraWinGrid.UltraGrid)
                With Ctrl
                    StrArr = GetCtrldbFieldInfo(Ctrl)
                    If StrArr.Length >= 2 Or (TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage) Then
                        If StrArr(TagOpts.dtFieldName) = TagName Then
                            Select Case Ctrl.GetType().ToString
                                Case "System.Windows.Forms.TextBox", "RoutesModule.MyTextBox", "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                                    .Text = Value 'DataObj.Item(StrArr(1))
                                Case "System.Windows.Forms.Label"
                                    .Text = Value & ":" 'DataObj.Item(StrArr(1))
                                Case "Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit"
                                    .Text = Value 'DataObj.Item(StrArr(1)).ToString
                                Case "System.Windows.Forms.ComboBox"
                                    Dim TempCtrl As ComboBox
                                    TempCtrl = Ctrl
                                    TempCtrl.SelectedValue = Value 'DataObj.Item(StrArr(1))

                                Case "Infragistics.Win.UltraWinGrid.UltraCombo"
                                    Dim TempCtrl As Infragistics.Win.UltraWinGrid.UltraCombo
                                    TempCtrl = Ctrl
                                    TempCtrl.Value = Value 'DataObj.Item(StrArr(1))

                                Case "Infragistics.Win.UltraWinEditors.UltraCheckEditor"
                                    Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraCheckEditor
                                    tempctrl = Ctrl
                                    tempctrl.Checked = Value 'DataObj.Item(StrArr(1))
                                Case "System.Windows.Forms.CheckBox"
                                    Dim TempCtrl As CheckBox
                                    tempctrl = Ctrl
                                    tempctrl.Checked = Value 'DataObj.Item(StrArr(1))
                                Case "System.Windows.Forms.RadioButton"
                                    Dim TempCtrl As RadioButton
                                    tempctrl = Ctrl
                                    If StrArr(TagOpts.DefaultVal) = Value Then
                                        tempctrl.Checked = True
                                    End If
                                Case "System.Windows.Forms.DateTimePicker"
                                    Dim TempCtrl As DateTimePicker
                                    TempCtrl = Ctrl
                                    tempctrl.Value = Value
                                Case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                                    Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
                                    TempCtrl = Ctrl
                                    tempctrl.Value = Value
                            End Select
                        End If
                    End If

                End With
            End If
        Next
        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("SetCtrlVal: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("SetCtrlVal: " & Err.Description)

    End Function

    Public Function FormSaveFieldRow(ByVal Container As Object, ByVal Cmd As SqlCommand) As Boolean
        Dim Ctrl As Control
        Dim StrArr() As String
        Static Query As String
        'Static Dim trnSql As SqlTransaction ' = sqlConn.BeginTransaction()
        Dim Query2, Cond As String

        On Error GoTo ErrTrap

        If TypeOf Container Is Form Then
            'sqlConn.Open()
            'trnSql = sqlConn.BeginTransaction
            Query = "Update " & Container.tag & " Set "

        End If

        FormSaveFieldRow = False

        Cmd = New SqlCommand   ' (SQLQuery, sqlConn, trnSql)

        For Each Ctrl In Container.Controls
            If TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage Then
                If FormSaveFieldRow(Ctrl, Cmd) = False Then Exit Function
            ElseIf Not (Ctrl.Tag Is Nothing) And Not (TypeOf Ctrl Is Infragistics.Win.UltraWinGrid.UltraGrid) Then
                With Ctrl
                    StrArr = GetCtrldbFieldInfo(Ctrl)
                    If StrArr.Length >= 2 Or (TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage) Then
                        Query2 = StrArr(TagOpts.dtFieldName) & " = "
                        Cond = " Where Name = '" & StrArr(TagOpts.dtFieldName) & "'"
                        Select Case Ctrl.GetType().ToString
                            Case "System.Windows.Forms.TextBox", "RoutesModule.MyTextBox", "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                                Query2 = Query2 & "'" & .Text.Trim & "'"  'DataObj.Item(StrArr(1))
                            Case "Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit"
                                Dim TmpCtrl As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
                                TmpCtrl = Ctrl
                                Query2 = Query2 & "'" & TmpCtrl.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) & "'"
                            Case "System.Windows.Forms.ComboBox"
                                Dim TempCtrl As ComboBox
                                TempCtrl = Ctrl
                                If (StrArr.Length - 1) >= TagOpts.SavCboTxt Then
                                    If StrArr(TagOpts.SavCboTxt) = "1" Then
                                        Query2 = Query2 & "'" & TempCtrl.Text & "'"  'DataObj.Item(StrArr(1))
                                        Exit Select
                                    End If
                                End If
                                Query2 = Query2 & "'" & TempCtrl.SelectedValue & "'"  'DataObj.Item(StrArr(1))

                            Case "Infragistics.Win.UltraWinGrid.UltraCombo"
                                Dim TempCtrl As Infragistics.Win.UltraWinGrid.UltraCombo
                                TempCtrl = Ctrl
                                If (StrArr.Length - 1) >= TagOpts.SavCboTxt Then
                                    If StrArr(TagOpts.SavCboTxt) = "1" Then
                                        Query2 = Query2 & "'" & TempCtrl.Text & "'"  'DataObj.Item(StrArr(1))
                                        Exit Select
                                    End If
                                End If
                                Query2 = Query2 & "'" & TempCtrl.Value & "'"  'DataObj.Item(StrArr(1))

                            Case "Infragistics.Win.UltraWinEditors.UltraCheckEditor"
                                Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraCheckEditor
                                tempctrl = Ctrl
                                Query2 = Query2 & tempctrl.Checked   'DataObj.Item(StrArr(1))
                            Case "System.Windows.Forms.CheckBox"
                                Dim TempCtrl As CheckBox
                                tempctrl = Ctrl
                                Query2 = Query2 & tempctrl.Checked   'DataObj.Item(StrArr(1))
                            Case "System.Windows.Forms.RadioButton"
                                Dim TempCtrl As RadioButton
                                tempctrl = Ctrl
                                If tempctrl.Checked = True Then
                                    Query2 = Query2 & "'" & StrArr(TagOpts.DefaultVal) & "'"
                                End If
                            Case "System.Windows.Forms.DateTimePicker"
                                Dim TempCtrl As DateTimePicker
                                TempCtrl = Ctrl
                                Query2 = Query2 & "'" & tempctrl.value & "'"    'DataObj.Item(StrArr(1))
                            Case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                                Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
                                TempCtrl = Ctrl
                                Query2 = Query2 & "'" & tempctrl.value & "'"    'DataObj.Item(StrArr(1))
                        End Select
                    End If
                End With
                With Cmd
                    .Connection = sqlConn
                    .CommandText = Query & Query2 & Cond
                    .CommandType = CommandType.Text
                    '.Transaction = trnSql
                    .ExecuteNonQuery()
                End With
                Query2 = "" : Cond = ""
            End If
        Next
        If TypeOf Container Is Form Then
            Cmd.Transaction.Commit()
            Cmd = Nothing
            sqlConn.Close()
        End If
        FormSaveFieldRow = True
        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("FormSaveFieldRow: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("FormSaveFieldRow: " & Err.Description)
        Cmd.Transaction.Rollback()
        Cmd.Connection.Close()
        Cmd = Nothing
        'sqlConn.Close()

    End Function

    Public Sub UCBO_Search(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim i As Integer
        Dim Pos As Integer

        If sender.tabstop = False Then Exit Sub

        If Asc(e.KeyChar) <> Keys.Back Then
            With sender
                Pos = .Text.Length
                i = sender.FindString(sender.text)
                If i >= 0 Then
                    .SelectedIndex = i
                    .SelectionLength = 1000
                    .SelectionStart = Pos
                Else
                    .Text = ""
                End If
            End With
        End If

    End Sub

    Public Sub CBO_Search(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim i As Integer
        Dim Pos As Integer

        If sender.tabstop = False Then Exit Sub

        If Asc(e.KeyChar) <> Keys.Back Then
            With sender
                Pos = .Text.Length
                i = sender.FindString(sender.text)
                If i >= 0 Then
                    .SelectedIndex = i
                    .SelectionLength = 1000
                    .SelectionStart = Pos
                Else
                    .Text = ""
                End If
            End With
        End If

    End Sub

    Public Sub CBO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim i As Integer
        Dim Pos As Integer
        On Error GoTo ErrTrap

        If sender.tabstop = False Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            'sender.GetNextControl(sender, True).Focus()
            SendKeys.Send("{TAB}")
        End If
        Exit Sub
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("CBO_KeyUp : " & Err.Number & " - " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("CBO_KeyUp : " & Err.Number & " - " & Err.Description)
    End Sub

    Public Sub CBO_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.tabstop = False Then Exit Sub

        If sender.text.trim = "" And sender.items.count > 0 Then
            sender.selectedindex = 0
        End If
    End Sub

    Public Sub UCbo_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        If sender.value Is Nothing Then
            sender.text = ""
            Exit Sub
        End If
        For Each ugrow In sender.rows
            If ugrow.Cells(sender.displaymember).Value = sender.text Then Exit Sub
        Next
        'sender.text = ""
        sender.value = Nothing
        sender.text = ""
    End Sub

    Public Sub UltraMaskValidationError(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinMaskedEdit.MaskValidationErrorEventArgs)
        Dim Str As String
        Str = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)

        If Str = "" Then
            e.RetainFocus = False
        End If
    End Sub


    Public Sub Form_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If ByPassKeyUp Then
            ByPassKeyUp = False
            Exit Sub
        End If

        If e.KeyCode = Keys.Enter Then
            Dim ctl As Control
            If TypeOf sender Is Form Then
                ctl = sender.ActiveControl
            Else
                ctl = sender
            End If

            If TypeOf ctl Is Button Then 'sender.ActiveControl
                Exit Sub
            End If
            If TypeOf ctl Is TextBox Then 'sender.ActiveControl
                Dim CtrlTBX As TextBox
                CtrlTBX = sender.ActiveControl
                If CtrlTBX.AcceptsReturn Then Exit Sub
            End If
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Sub ClearForm(ByVal ActForm As Object)
        Dim Ctrl As Control
        Dim StrArr As String()

        For Each Ctrl In ActForm.Controls
            'If Not (Ctrl.Tag Is Nothing) Or TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage Then
            With Ctrl
                StrArr = GetCtrldbFieldInfo(Ctrl)
                'If StrArr.Length >= 2 Or (TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is Panel Or TypeOf Ctrl Is TabControl Or TypeOf Ctrl Is TabPage) Then
                If StrArr.Length >= 4 Then
                    If StrArr(TagOpts.KeepValOnReset) = "1" Then
                        GoTo NextCtrl
                    End If
                End If
                Select Case .GetType().ToString
                    Case "System.Windows.Forms.TextBox", "RoutesModule.MyTextBox", "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                        .Text = ""
                    Case "Infragistics.Win.UltraWinEditors.UltraNumericEditor"
                        .Text = "0.00"
                    Case "System.Windows.Forms.Label"
                        '.Text = "Label:"
                    Case "Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit"
                        .Text = ""
                    Case "System.Windows.Forms.ComboBox"
                        Dim TempCtrl As ComboBox
                        TempCtrl = Ctrl
                        If tempctrl.Items.Count > 0 Then
                            TempCtrl.SelectedIndex = 0
                        End If
                    Case "Infragistics.Win.UltraWinGrid.UltraCombo"
                        Dim TempCtrl As Infragistics.Win.UltraWinGrid.UltraCombo
                        TempCtrl = Ctrl
                        If tempctrl.rows.Count > 0 Then
                            'Tempctrl.PerformAction(Infragistics.Win.UltraWinGrid.UltraComboAction.FirstRow)
                            tempctrl.Value = Nothing
                            tempctrl.Text = ""
                        End If
                    Case "Infragistics.Win.UltraWinEditors.UltraCheckEditor"
                        Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraCheckEditor
                        tempctrl = Ctrl
                        tempctrl.Checked = False
                    Case "System.Windows.Forms.CheckBox"
                        Dim TempCtrl As CheckBox
                        tempctrl = Ctrl
                        tempctrl.Checked = False
                    Case "System.Windows.Forms.DateTimePicker"
                        Dim TempCtrl As DateTimePicker
                        TempCtrl = Ctrl
                        tempctrl.Value = Date.Today
                    Case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                        Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
                        TempCtrl = Ctrl
                        If tempctrl.Nullable = True Then
                            tempctrl.Value = Nothing
                        Else
                            tempctrl.Value = Date.Today
                        End If
                    Case "System.Windows.Forms.GroupBox", "System.Windows.Forms.Panel"
                        ClearForm(Ctrl)
                    Case "System.Windows.Forms.TabControl", "System.Windows.Forms.TabPage"
                        ClearForm(Ctrl)
                    Case "Infragistics.Win.UltraWinGrid.UltraGrid"
                End Select
                'End If
            End With
            'End If
NextCtrl:
        Next
    End Sub

    Public Function SearchDB(ByVal SQLQuery As String, ByVal Condition As String) As DataSet
        On Error GoTo ErrTrap
        Dim dtS As New DataSet
        Dim dtA As New SqlDataAdapter

        'Dim sqlConn As New SqlConnection(strConnection)
        Dim drsqlReader As SqlDataReader
        'Dim Pos, Pos2, i As Integer

        'Condition = Condition.Trim
        'i = InStr(Condition, "Where", CompareMethod.Text)
        'If i > 0 Then
        '    Condition = Condition.Substring(i + Len("Where"))
        'Else
        '    i = InStr(Condition, "AND", CompareMethod.Text)
        '    If i > 0 Then
        '        Condition = Condition.Substring(i + Len("AND"))
        '    End If
        'End If
        'Pos = InStr(SQLQuery, KeyWords(KW._1Where), CompareMethod.Text)
        'For i = KW._2Order To KW._3Group
        '    Pos2 = InStr(SQLQuery, KeyWords(i), CompareMethod.Text)
        '    If Pos2 > 0 Then Exit For
        'Next
        'If Pos <= 0 Then 'No Where Clause
        '    Condition = " Where " & Condition & " "
        '    If Pos2 <= 0 Then
        '        SQLQuery = SQLQuery & Condition
        '    Else
        '        SQLQuery = SQLQuery.Insert(Pos2, " " & Condition)
        '    End If
        'Else 'Where Clause Exists
        '    Condition = " AND " & Condition
        '    If Pos2 <= 0 Then ' No Additional Clauses
        '        SQLQuery = SQLQuery & Condition
        '    Else 'Additional Clauses Exist
        '        SQLQuery = SQLQuery.Insert(Pos2, Condition)
        '    End If
        'End If
        SQLQuery = PrepSelectQuery(SQLQuery, Condition)



        SearchDB = Nothing
        Windows.Forms.Cursor.Current = Cursors.WaitCursor()
        PopulateDataset2(dtA, dtS, SQLQuery)
        If dtS.Tables(0).Rows.Count > 0 Then
            SearchDB = dtS
        Else
            dtS = Nothing
        End If
        Windows.Forms.Cursor.Current = Cursors.Default


        Exit Function
ErrTrap:
        Windows.Forms.Cursor.Current = Cursors.Default
        If Err.Number = 5 Then
            'Message modified by Michael Pastor
            MsgBox("Either another user is currently editing the specified record, or the connection is slow.", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MsgBox("This record is probably being edited by another user or there is a slow communication.")
        Else
            'Message modified by Michael Pastor
            MsgBox("InitiateEdit : " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("InitiateEdit : " & Err.Description)
        End If

    End Function

    Public Function PrepSelectQuery(ByVal SelectQry As String, Optional ByVal Condition As String = "") As String

        PrepSelectQuery = SelectQry
        Condition = Condition.Trim
        If Condition = "" Then Exit Function

        Dim Pos, Pos2, i As Integer


        'i = InStr(Condition, "Where", CompareMethod.Text)
        If Condition.Substring(0, Len("Where")).ToUpper = "WHERE" Then
            'If i > 0 Then
            Condition = Condition.Substring(Len("Where"))
        Else
            'i = InStr(Condition, "AND", CompareMethod.Text)

            'If i > 0 Then
            i = 0
            If Condition.Substring(0, 3).ToUpper = "AND" Then
                Condition = Condition.Substring(i + Len("AND"))
            End If
        End If
        Pos = InStr(SelectQry, KeyWords(KW._1Where), CompareMethod.Text)
        For i = KW._2Order To KW._3Group
            Pos2 = InStr(SelectQry, KeyWords(i), CompareMethod.Text)
            If Pos2 > 0 Then Exit For
        Next
        If Pos <= 0 Then 'No Where Clause
            Condition = " Where " & Condition & " "
            If Pos2 <= 0 Then
                SelectQry = SelectQry & Condition
            Else
                SelectQry = SelectQry.Insert(Pos2, " " & Condition)
            End If
        Else 'Where Clause Exists
            Condition = " AND " & Condition
            If Pos2 <= 0 Then ' No Additional Clauses
                SelectQry = SelectQry & Condition
            Else 'Additional Clauses Exist
                SelectQry = SelectQry.Insert(Pos2, " " & Condition & " ")
            End If
        End If
        PrepSelectQuery = SelectQry


    End Function


    Public ReadOnly Property CellSize(ByVal frm As Object) As SizeF

        ' NOTE:  This property will work only for fixed-width fonts.

        Get

            ' Get a DC for the user control.

            Dim oGfx As Graphics = frm.CreateGraphics()


            ' Build a character string containing 100 characters.  I
            ' choose a 100-character string because empirical evidence
            ' seems to show that measuring a 1-character string doesn't
            ' provide an accurate measurement (although I don't know why).

            Dim sText As String = New String("M"c, 100)

            ' Determine the dimensions of the 100 character string.
            Dim oCellSize As SizeF = oGfx.MeasureString(sText, frm.Font)

            ' Reduce the width to that of a single character.
            oCellSize.Width /= 100

            Return oCellSize

        End Get

    End Property

    Public Function UGLoadLayout(ByVal ActForm As Form, ByVal UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal UserID As Integer) As Boolean
        Dim Buffer As New IO.MemoryStream
        Dim SQLString, strBuf As String
        Dim Cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim i() As Byte
        On Error GoTo ErrTrap

        If UltraGrid.Tag Is Nothing Then
            UltraGrid.Tag = ""
        End If
        SQLString = "Select * from ListLayouts where UserID = " & UserID & " and FormName = '" & ActForm.Tag & "' AND GRIDTAG = '" & UltraGrid.Tag & "'"

        sqlConn.Open()

        Cmd = New SqlCommand(SQLString, sqlConn)

        With Cmd

            .CommandType = CommandType.Text
            '.ExecuteNonQuery()
            dr = .ExecuteReader
        End With
        If dr.Read = False Then
            'MsgBox("No Layout Available.")
            dr.Close()
            Cmd.Connection.Close()
            Cmd = Nothing
            Exit Function
        End If
        i = dr(4)
        'dr.GetBytes(3, 0, i, 0, 8000)
        Buffer.Write(i, 0, i.Length)

        dr.Close()


        Buffer.Seek(0, IO.SeekOrigin.Begin)
        UltraGrid.DisplayLayout.Load(Buffer, Infragistics.Win.UltraWinGrid.PropertyCategories.All)
        Cmd.Connection.Close()
        Cmd = Nothing
        UltraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        If UltraGrid.Rows.Count > 0 Then
            UltraGrid.ActiveRow = UltraGrid.Rows(0)
        End If
        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("UGLoadLayout: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("UGLoadLayout: " & Err.Description)
        'Resume
        sqlConn.Close()
        Cmd = Nothing
    End Function

    Public Function UGSaveLayout(ByVal ActForm As Form, ByVal UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal UserID As Integer) As Boolean
        Dim Buffer As New IO.MemoryStream
        Dim i() As Byte
        Dim SQLString, strBuf, GridTag As String
        Dim Cmd As SqlCommand
        On Error GoTo ErrTrap
        UGSaveLayout = False
        'Dim FileName = "layout.bin"
        'Dim FileLayout As New IO.FileStream(FileName, IO.FileMode.OpenOrCreate)
        'FileLayout.Seek(0, IO.SeekOrigin.Begin)
        'UltraGrid.DisplayLayout.Save(FileLayout, Infragistics.Win.UltraWinGrid.PropertyCategories.All)
        'FileLayout.Close()

        'FileLayout = IO.File.Open(FileName, IO.FileMode.Open)

        'FileLayout.Seek(0, IO.SeekOrigin.Begin)

        'UltraGrid.DisplayLayout.Load(FileLayout)

        'FileLayout.Close()
        If ActForm.Tag Is Nothing Then
            MsgBox("No Tag Specified.", MsgBoxStyle.Exclamation, "Save Grid Layout")
            Exit Function
        End If
        If ActForm.Tag = "" Then
            MsgBox("No Tag Specified.", MsgBoxStyle.Exclamation, "Save Grid Layout")
            Exit Function
        End If
        If UltraGrid.Tag Is Nothing Then
            GridTag = ""
        Else
            GridTag = UltraGrid.Tag
        End If
        Buffer.Seek(0, IO.SeekOrigin.Begin)
        UltraGrid.DisplayLayout.Save(Buffer, Infragistics.Win.UltraWinGrid.PropertyCategories.All)

        SQLString = "Delete from " & AppTblPath & "ListLayouts where UserID = " & UserID & " and FormName = '" & ActForm.Tag & "'; " & _
        "Insert into " & AppTblPath & "ListLayouts values(" & UserID & ", '" & ActForm.Tag & "', '" & GridTag & "', @LayOut )"


        i = Buffer.GetBuffer


        sqlConn.Open()

        Dim trnSql As SqlTransaction = sqlConn.BeginTransaction()
        Cmd = New SqlCommand(SQLString, sqlConn, trnSql)

        Dim params As SqlParameterCollection = Cmd.Parameters

        params.Add("@LayOut", SqlDbType.Image, Buffer.Length)
        Cmd.Parameters("@LayOut").Value = Buffer.ToArray

        With Cmd
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With

        Cmd.Transaction.Commit()
        Cmd.Connection.Close()
        Cmd = Nothing
        Buffer.Close()

        UGSaveLayout = True

        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("UGSaveLayout: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("UGSaveLayout: " & Err.Description)
        If Not Cmd Is Nothing Then

            Cmd.Transaction.Rollback()
        End If
        sqlConn.Close()
    End Function


    Public Function UGLoadListingLayout(ByVal UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal LayOutID As Integer) As Boolean
        Dim SQLString, strBuf As String
        Dim Cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim i(), J() As Byte
        On Error GoTo ErrTrap


        SQLString = "Select * from ListingsTemplates where ID = " & LayOutID

        sqlConn.Open()

        Cmd = New SqlCommand(SQLString, sqlConn)

        With Cmd

            .CommandType = CommandType.Text
            '.ExecuteNonQuery()
            dr = .ExecuteReader
        End With
        If dr.Read = False Then
            'MsgBox("No Layout Available.")
            dr.Close()
            Cmd.Connection.Close()
            Cmd = Nothing
            Exit Function
        End If
        i = dr(3)

        Dim Buffer As New IO.MemoryStream(i.Length)

        Buffer.Seek(0, IO.SeekOrigin.Begin)
        Buffer.Write(i, 0, i.Length)
        Buffer.Seek(0, IO.SeekOrigin.Begin)

        J = Buffer.GetBuffer

        UltraGrid.DisplayLayout.Load(Buffer, Infragistics.Win.UltraWinGrid.PropertyCategories.All)

        Buffer.Close()
        dr.Close()
        Cmd.Connection.Close()
        Cmd = Nothing
        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("UGLoadListingLayout: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("UGLoadListingLayout: " & Err.Description)
        'Resume
        sqlConn.Close()
        Cmd = Nothing
    End Function

    Public Function UGSaveListingLayout(ByVal ActForm As Form, ByVal UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByRef LayoutID As Integer, ByVal TemplateName As String) As Boolean
        Dim Buffer As New IO.MemoryStream
        Dim i() As Byte
        Dim UpdateStr, strBuf As String
        Dim Cmd As SqlCommand
        On Error GoTo ErrTrap

        If TemplateName.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("The template name remains unspecified. Please enter an appropriate name for the template.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("No Name Specified for the Template")
            Exit Function
        End If

        If ActForm.Tag.trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("The listing name remains unspecified. Please enter an appropriate name for the listing.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Listing has no name.")
            Exit Function
        End If

        Buffer.Seek(0, IO.SeekOrigin.Begin)
        UltraGrid.DisplayLayout.Save(Buffer, Infragistics.Win.UltraWinGrid.PropertyCategories.All)

        If LayoutID > 0 Then
            UpdateStr = "Update ListingsTemplates Set Name = '" & TemplateName & "' , Template = @LayOut " & " where ID = " & LayoutID
        Else
            UpdateStr = "Insert into ListingsTemplates(ListName, Name, Template) values('" & ActForm.Tag & "', '" & TemplateName & "', @LayOut )"
        End If


        Buffer.Seek(0, IO.SeekOrigin.Begin)

        i = Buffer.GetBuffer


        sqlConn.Open()

        Dim trnSql As SqlTransaction = sqlConn.BeginTransaction()
        Cmd = New SqlCommand(UpdateStr, sqlConn, trnSql)

        Dim params As SqlParameterCollection = Cmd.Parameters

        params.Add("@LayOut", SqlDbType.Image, Buffer.Length)
        Cmd.Parameters("@LayOut").Value = Buffer.ToArray

        With Cmd
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With

        Cmd.Transaction.Commit()
        Cmd.CommandText = "Select ID from ListingsTemplates where Name = '" & TemplateName & "' and ListName = '" & ActForm.Tag & "'"
        Dim dr As SqlDataReader

        With Cmd
            .CommandType = CommandType.Text
            dr = .ExecuteReader
        End With
        If dr.Read = False Then
            MsgBox("Error Reading back saved layout.")
        Else
            LayoutID = dr(0)
        End If
        Cmd.Connection.Close()
        Cmd = Nothing
        Buffer.Close()

        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("UGSaveListingLayout: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("UGSaveListingLayout: " & Err.Description)
        If Not Cmd Is Nothing Then
            Cmd.Transaction.Rollback()
        End If
        sqlConn.Close()
    End Function


    Public Function ExportUltraGrid(ByVal UltraGrid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim dlg As New SaveFileDialog
        Dim FileName, CSVRow As String '  = "layout.bin"
        Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim ugcell As Infragistics.Win.UltraWinGrid.UltraGridCell
        Dim Delimiter As String = ","
        Dim FieldBlock As String = """"
        On Error GoTo ErrTrap

        Dim result As Integer

        dlg.Filter = "Text|*.txt|CSV|*.csv|All Files|*.*"
        dlg.FilterIndex = 0

        result = dlg.ShowDialog()
        If result = DialogResult.Abort Or result = DialogResult.Cancel Then Exit Function

        While dlg.CheckPathExists = False
            MsgBox("Wrong path. Please select again.")
            result = dlg.ShowDialog()
            If result = DialogResult.Abort Or result = DialogResult.Cancel Then Exit Function
        End While
        FileName = dlg.FileName
        FileOpen(1, FileName, OpenMode.Output)
        For Each ugcol In UltraGrid.DisplayLayout.Bands(0).Columns
            If ugcol.Hidden = False Then
                CSVRow = CSVRow & FieldBlock & ugcol.Header.Caption & FieldBlock & Delimiter
            End If
        Next
        CSVRow = CSVRow.Substring(0, Len(CSVRow) - Len(Delimiter))
        PrintLine(1, CSVRow)
        CSVRow = ""
        For Each ugrow In UltraGrid.Rows
            For Each ugcell In ugrow.Cells
                If ugcol.Hidden = False Then
                    CSVRow = CSVRow & FieldBlock & ugcell.Value & FieldBlock & Delimiter
                End If
            Next
            CSVRow = CSVRow.Substring(0, Len(CSVRow) - Len(Delimiter))
            PrintLine(1, CSVRow)
            CSVRow = ""
        Next

        FileClose(1)

        dlg = Nothing
        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("ExportUltraGrid: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("ExportUltraGrid: " & Err.Description)
        dlg = Nothing

        FileClose(1)
    End Function


    Public Function ReturnRowByID(ByVal ID As String, ByRef dbRow As DataRow, ByVal dbTableName As String, Optional ByVal Condition As String = "", Optional ByVal IDFldName As String = "ID", Optional ByVal AltQuery As String = "") As Boolean
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet

        dbRow = Nothing
        ReturnRowByID = False
        If AltQuery = "" Then
            Dim sQuery As String = PrepSelectQuery("Select * from " & dbTableName & " Where " & IDFldName & " = '" & ID & "'", Condition)
            PopulateDataset2(dtAdapter, dtSet, sQuery)
        Else
            PopulateDataset2(dtAdapter, dtSet, AltQuery)
        End If

        If dtSet.Tables(0).Rows.Count > 0 Then
            dbRow = dtSet.Tables(0).NewRow
            dbRow = dtSet.Tables(0).Rows(0)
            ReturnRowByID = True
            dtSet = Nothing
            dtAdapter = Nothing
        Else
            dtSet = Nothing
            dtAdapter = Nothing
        End If


    End Function

    Public Function UpdateDbFromDataSetV2(ByVal dsChanges As DataSet, _
        ByVal strSQL As String, ByVal Condition As String) As Integer
        Dim dtAdapt As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim col As DataColumn

        Dim dtRow As DataRow
        Dim UpdateQry As String
        Dim Params As New SqlParameter
        Dim i As Integer
        Dim TblList()(), FldsList()() As Object

        TblList = TablesList(strSQL)


        UpdateDbFromDataSetV2 = 0
        If dsChanges Is Nothing Then Exit Function
        If dsChanges.Tables(0).Rows.Count = 0 Then Exit Function

        UpdateQry = MakeUpdateQry(strSQL, Condition)

        '"Update DailyEntry Set Weight = @Fld0, Charge = @Fld1 where TranDate = '06/03/2002' and manifestid = @Fld2" 

        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConn

        ''For Each dtRow In dsChanges.Tables(0).Rows

        ''    For i = 0 To dsChanges.Tables(0).Columns.Count - 1
        ''        With cmd.Parameters
        ''            .Add("@Fld" & i, dtRow.Item(i))
        ''        End With
        ''    Next i
        ''    cmd.ExecuteNonQuery()
        ''    cmd.Parameters.Clear()
        ''Next

        FldsList = GetQryFields(strSQL)
        Dim ct As Constraint
        Dim unq As UniqueConstraint

        For Each ct In dsChanges.Tables(0).Constraints
            If ct.GetType.ToString = "System.Data.UniqueConstraint" Then
                unq = ct
                If unq.IsPrimaryKey Then Exit For
            End If
        Next

        For i = 0 To dsChanges.Tables(0).Columns.Count - 1
            col = dsChanges.Tables(0).Columns(i)
            Dim ucol As DataColumn

            For Each ucol In unq.Columns
                If ucol.ColumnName = col.ColumnName Then
                    col.Unique = True
                    Exit For
                End If
            Next
            If col.Unique Then
                If InStr(UpdateQry, " Where ", CompareMethod.Text) > 0 Then
                    UpdateQry += " AND " & FldsList(i)(0) & " = @FldK" & i
                Else
                    UpdateQry += " Where " & FldsList(i)(0) & " = @FldK" & i
                End If
            End If

            With cmd.Parameters
                Select Case dsChanges.Tables(0).Columns(i).DataType.ToString
                    Case "System.Int32", "System.Integer", "System.Int64"
                        .Add("@Fld" & i, SqlDbType.Int, 4, col.ToString)
                        If col.Unique Then
                            .Add("@FldK" & i, SqlDbType.Int, 4, col.ToString)
                        End If
                    Case "System.Int16"
                        .Add("@Fld" & i, SqlDbType.SmallInt, 2, col.ToString)
                        If col.Unique Then
                            .Add("@FldK" & i, SqlDbType.SmallInt, 2, col.ToString)
                        End If
                    Case "System.String"
                        .Add("@Fld" & i, SqlDbType.VarChar, col.MaxLength, col.ToString)
                        If col.Unique Then
                            .Add("@FldK" & i, SqlDbType.VarChar, col.MaxLength, col.ToString)
                        End If
                    Case "System.Decimal"
                        .Add("@Fld" & i, SqlDbType.Decimal, 5, col.ToString)
                        If col.Unique Then
                            .Add("@FldK" & i, SqlDbType.Decimal, 5, col.ToString)
                        End If
                    Case "System.DateTime"
                        .Add("@Fld" & i, SqlDbType.DateTime, 8, col.ToString)
                        If col.Unique Then
                            .Add("@FldK" & i, SqlDbType.DateTime, 8, col.ToString)
                        End If
                    Case Else
                        'Message modified by Michael Pastor
                        MsgBox("Unknown Type: " & col.DataType.ToString, MsgBoxStyle.Exclamation, "Data Invalid")
                        '- MsgBox("Unknown Type: " & col.DataType.ToString)
                        sqlConn.Close()
                        cmd.Parameters.Clear()
                        cmd = Nothing
                        dtAdapt = Nothing
                        Exit Function
                End Select
            End With
        Next i

        'With cmd.Parameters
        '    .Add("@Fld0", SqlDbType.Decimal, 5, "Weight")
        '    .Add("@Fld1", SqlDbType.Decimal, 5, "Charge")
        '    .Add("@Fld2", SqlDbType.Int, 4, dsChanges.Tables(0).Columns(1).ToString)
        'End With

        cmd.CommandText = UpdateQry
        sqlConn.Open()
        dtAdapt.UpdateCommand = cmd
        dtAdapt.TableMappings.Add("Table", TblList(0)(0))

        Try
            dtAdapt.Update(dsChanges)
        Catch ex As System.Data.SqlClient.SqlException
            'Message NOT modified by Michael Pastor, due to format being identical to modified version. 
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Weight Entry")
            sqlConn.Close()
            Exit Function
        Finally
            sqlConn.Close()
        End Try
        cmd.Parameters.Clear()
        cmd = Nothing
        dtAdapt = Nothing

    End Function

    Public Function MakeUpdateQry(ByVal SelectQry As String, ByVal Cond As String) As String
        Dim TblList()(), FldsList()() As Object
        Dim UpdQry As String
        Dim i As Integer

        TblList = TablesList(SelectQry)
        FldsList = GetQryFields(SelectQry)

        UpdQry = "Update " & TblList(0)(0) & " Set "

        For i = 0 To FldsList.GetUpperBound(0)
            UpdQry += FldsList(i)(0) & " = @Fld" & i & " , "
        Next
        UpdQry = UpdQry.Substring(0, Len(UpdQry) - 2)
        'UpdQry = AddWhereClause(UpdQry, SelectQry, Cond)

        MakeUpdateQry = UpdQry
    End Function

    Public Function AddWhereClause(ByVal UpdateQry As String, ByVal SelectQry As String, ByVal Condition As String) As String
        Dim Pos, Pos2, i As Integer
        Dim PriCond As String
        Dim WFlag, PFlag, SFlag As Boolean

        WFlag = False : PFlag = False : SFlag = False

        Condition = Condition.Trim
        If Condition <> "" Then
            WFlag = True : SFlag = True
            If Condition.Substring(0, Len("Where")).ToUpper = "WHERE" Then
                Condition = Condition.Substring(Len("Where"))
            Else
                i = 0
                If Condition.Substring(0, 3).ToUpper = "AND" Then
                    Condition = Condition.Substring(i + Len("AND"))
                End If
            End If
        End If

        Pos = InStr(SelectQry, KeyWords(KW._1Where), CompareMethod.Text)
        If Pos > 0 Then
            Pos -= 1
            WFlag = True : PFlag = True
            For i = KW._2Order To KW._3Group
                Pos2 = InStr(SelectQry, KeyWords(i), CompareMethod.Text)
                If Pos2 > 0 Then Exit For
            Next
            Pos2 = IIf(Pos2 > 0, Pos2, Len(SelectQry))
            PriCond = SelectQry.Substring(Pos + Len(KeyWords(KW._1Where)), Pos2 - (Pos + Len(KeyWords(KW._1Where))))
        End If
        If WFlag Then
            UpdateQry += " Where " & PriCond & IIf(PFlag And SFlag, " AND ", "") & Condition
        End If
        AddWhereClause = UpdateQry

    End Function

    Public Function GetQryFields(ByVal SelectQry As String) As String()()
        Dim Pos, Pos2, i As Integer
        Dim FldsList() As String
        Dim TmpStr As String

        SelectQry = SelectQry.Trim


        Pos2 = InStr(SelectQry, " FROM ", CompareMethod.Text)
        TmpStr = SelectQry.Substring(Len("Select "), Pos2 - Len("Select "))
        FldsList = TmpStr.Split(",")
        Dim FldsAliasList(FldsList.GetUpperBound(0))() As String
        For i = 0 To FldsList.GetUpperBound(0)
            FldsAliasList(i) = FldsList(i).Trim.Split(" ")
        Next i
        GetQryFields = FldsAliasList
    End Function

    Public Function SearchOnLeave(ByRef sender As Object, ByRef IDFld As Object, ByVal sqlTableName As String, Optional ByVal sqlIDFld As String = "ID", Optional ByVal sqlNameFld As String = "Name", Optional ByVal OtherFlds As String = "", Optional ByVal Title As String = "", Optional ByVal CondClause As String = "", Optional ByVal NoReset As Boolean = False, Optional ByVal HidCols As String() = Nothing) As Boolean
        'On Error GoTo ErrTrap
        Dim daCity As New SqlDataAdapter
        Dim dsCity As New DataSet
        Dim dvCities1 As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim WGTGrpSQL As String
        Dim TableAlias As Object()
        Dim TableName As String

        SearchOnLeave = False

        If TypeOf sender Is TextBox Then
        ElseIf TypeOf sender Is Infragistics.Win.UltraWinEditors.UltraTextEditor Then
        Else
            'Message modified by Michael Pastor
            MsgBox("Unknown Control passed to SearchOnLeave.", MsgBoxStyle.Exclamation, "Data Invalid")
            '- MsgBox("Unknown Control passed to SearchOnLeave.")
            Exit Function
        End If

        If sender.modified = False Then Exit Function
        sender.Modified = False

        If TypeOf IDFld Is TextBox Then
        ElseIf TypeOf sender Is Infragistics.Win.UltraWinEditors.UltraTextEditor Then
        Else
            'Message modified by Michael Pastor
            MsgBox("Unknown Control passed to SearchOnLeave.", MsgBoxStyle.Exclamation, "Data Invalid")
            '- MsgBox("Unknown Control passed to SearchOnLeave.")
            Exit Function
        End If

        If CondClause <> "" Then
            Dim pos As Integer
            pos = InStr(CondClause, "Where", CompareMethod.Text)
            If pos >= 1 Then
                CondClause = CondClause.Substring(pos + Len("Where"))
                CondClause = " AND " & CondClause
            Else
                Dim StrArr() As String
                CondClause = CondClause.Trim

                StrArr = SplitStringToArray(CondClause, " ")
                If StrArr(0).ToUpper <> "AND" Then
                    CondClause = " AND " & CondClause
                End If
            End If
        End If

        If OtherFlds = "*" Then
            WGTGrpSQL = "Select " & OtherFlds & " from " & sqlTableName
        Else
            WGTGrpSQL = "Select " & sqlIDFld & ", " & sqlNameFld & OtherFlds & " from " & sqlTableName
        End If

        ' TableAlias = sqlTableName.Split(" ", 2)
        TableAlias = sqlTableName.Split(" ")
        If TableAlias.GetLength(0) > 1 Then
            TableName = TableAlias(1)
        Else
            TableName = TableAlias(0)
        End If

        HasErr = False
        Dim strAcctId As String = sender.Text
        'If IsNumeric(strAcctId.Substring(0, 4)) Then ' GroupID
        Dim bAcctIsNumeric As Boolean
        If Len(strAcctId) < 4 Then
            bAcctIsNumeric = IsNumeric(strAcctId)
        Else
            bAcctIsNumeric = IsNumeric(strAcctId.Substring(0, 4))
        End If
        If bAcctIsNumeric Then ' GroupID
            WGTGrpSQL = WGTGrpSQL & " where " & sqlIDFld & " = '" & sender.Text & "'" & CondClause
            PopulateDataset2(daCity, dsCity, WGTGrpSQL)
            dvCities1.Table = dsCity.Tables(TableName)
            If dvCities1.Table.Rows.Count > 0 Then
                IDFld.Text = sender.Text.ToString
                sender.Text = dvCities1.Table.Rows(0).Item(sqlNameFld)
                SearchOnLeave = True
            Else
                'Message modified by Michael Pastor
                MsgBox("Data not found.", MsgBoxStyle.Exclamation, "Data Unavailable")
                '- MsgBox("Not found!")
                cleanNoRecords = True
                If NoReset = False Then
                    sender.ResetText()
                    sender.Focus()
                End If
            End If
        Else 'Blank or City Name
            If sender.Text.Trim() = "" Then Exit Function
            If sender.Text.StartsWith("?") Then
                sender.Text = sender.Text.Substring(1)
            End If
            Dim SrchStr As String
            SrchStr = sender.Text
            SrchStr = SrchStr.Replace("'", "''")
            WGTGrpSQL = WGTGrpSQL & " where " & sqlNameFld & " like '" & SrchStr & "%' " & CondClause & " Order by " & sqlIDFld ' sqlNameFld
            If PopulateDataset2(daCity, dsCity, WGTGrpSQL) Is Nothing Then
                Exit Function
            End If
            dvCities1.Table = dsCity.Tables(TableName)
            If dvCities1.Table.Rows.Count > 0 Then
                If dvCities1.Table.Rows.Count > 1 Then
                    Dim Srch As New SearchListings
                    Srch.dsList = dsCity
                    Srch.HidCols = HidCols

                    Srch.UltraGrid1.Text = Title
                    Srch.Text = "Search Results"
                    Srch.ShowDialog()
                    If Srch.DialogResult <> DialogResult.OK Then
                        sender.Focus()
                        GoTo Release
                    End If
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
                        Srch = Nothing
                        sender.Focus()
                        Exit Try
                    Finally
                        If HasErr = False Then
                            ugRow = Srch.UltraGrid1.ActiveRow
                            sender.Text = ugRow.Cells(sqlNameFld).Text
                            IDFld.Text = ugRow.Cells(sqlIDFld).Text
                            Srch = Nothing
                        End If
                    End Try
                Else ' Just one record found
                    Try
                        sender.Text = dvCities1(0).Item(sqlNameFld) 'ugRow.Cells("City").Text
                        IDFld.Text = dvCities1(0).Item(sqlIDFld) ' ugRow.Cells("Zipcode").Text
                    Catch ex As Exception
                        'Message modified by Michael Pastor
                        MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Critical Error")
                        '- MsgBox(ex.Message)
                        Exit Function
                    End Try
                End If
                SearchOnLeave = True
            Else
                MsgBox("Data not found.", MsgBoxStyle.Exclamation, "Data Unavailable")
                'MsgBox("No matching record found!") 'Karina uncommented
                cleanNoRecords = True
                If NoReset = False Then
                    sender.ResetText()
                    sender.Focus()
                End If
            End If
        End If
Release:
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing
        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("ZipCode Error: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("ZipCode Error: " & Err.Description)
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing

    End Function

    Public Function UpdateDbFromDataSetV4(ByVal dsChanges As DataSet, _
            ByVal SQLstr As String, ByVal PKArray As Object()(), Optional ByVal IdentityFld() As String = Nothing, Optional ByVal AltUpdateQry As String = Nothing, Optional ByVal ColParamArray()() As String = Nothing) As Integer

        Dim Conn As New SqlConnection(strConnection)
        Dim dtAdapter As SqlDataAdapter = New SqlDataAdapter(SQLstr, Conn)
        Dim ColParam As SqlParameter
        Dim CondParam As SqlParameter
        Dim DTType As SqlDbType

        Dim Col As DataColumn
        Dim i As Integer
        Dim TblList()() As Object
        Dim FldArray As Object()()
        Dim sqlResult As String
        Dim Values As String


        TblList = TablesList(SQLstr)

        FldArray = FieldsList(SQLstr)

        Dim MapTableName As String
        MapTableName = TblList(0)(0)
        MapTableName = MapTableName.Split(".")(MapTableName.Split(".").Length - 1)
        '======================================================================================
        'Update
        '======================================================================================
        If AltUpdateQry Is Nothing Then
            sqlResult = "Update " & TblList(0)(0) & " Set "
            For i = 0 To FldArray.GetUpperBound(0)
                If IdentityFld Is Nothing Then
                    sqlResult = sqlResult & FldArray(i)(0) & " = @Val" & i & " , "
                Else
                    If IdentityFld.BinarySearch(IdentityFld, FldArray(i)(0)) < 0 Then
                        'If FldArray(i)(0) <> IdentityFld.BinarySearch(IdentityFld, FldArray(i)(0)) Then
                        sqlResult = sqlResult & FldArray(i)(0) & " = @Val" & i & " , "
                    End If
                End If
            Next
            sqlResult = sqlResult.Substring(0, Len(sqlResult) - Len(" , "))
            sqlResult = sqlResult & " Where "
            For i = 0 To PKArray.GetUpperBound(0)
                sqlResult = sqlResult & PKArray(i)(0) & " = @Cond" & i & " AND "
            Next
            sqlResult = sqlResult.Substring(0, Len(sqlResult) - Len(" AND "))

            dtAdapter.UpdateCommand = New SqlCommand(sqlResult, Conn)
            For i = 0 To FldArray.GetUpperBound(0)
                Col = dsChanges.Tables(0).Columns(i)
                DTType = ReturnDBType(Col.DataType.ToString)
                If DTType = SqlDbType.Variant Then
                    GoTo Release
                End If
                ColParam = dtAdapter.UpdateCommand.Parameters.Add("@Val" & i, DTType) 'SqlDbType.Decimal
                ColParam.SourceColumn = FldArray(i)(0)
                ColParam.SourceVersion = DataRowVersion.Current
            Next

            For i = 0 To PKArray.GetUpperBound(0)
                CondParam = dtAdapter.UpdateCommand.Parameters.Add("@Cond" & i, PKArray(i)(1)) 'SqlDbType.DateTime
                CondParam.SourceColumn = PKArray(i)(0)
                CondParam.SourceVersion = DataRowVersion.Original
            Next
        Else
            sqlResult = AltUpdateQry
            If ColParamArray Is Nothing Then
                MsgBox("Grid Columns Parameter Array is not specified.")
                Exit Function
            End If
            dtAdapter.UpdateCommand = New SqlCommand(sqlResult, Conn)
            For i = 0 To ColParamArray.GetUpperBound(0)
                Col = dsChanges.Tables(0).Columns(ColParamArray(i)(1))
                DTType = ReturnDBType(Col.DataType.ToString)
                If DTType = SqlDbType.Variant Then
                    GoTo Release
                End If
                ColParam = dtAdapter.UpdateCommand.Parameters.Add(ColParamArray(i)(0), DTType) 'SqlDbType.Decimal
                ColParam.SourceColumn = ColParamArray(i)(1) 'FldArray(i)(0)
                ColParam.SourceVersion = DataRowVersion.Current
            Next

        End If



        '======================================================================================
        'Insert
        '======================================================================================
        'Values = " Values("
        'sqlResult = "Insert into " & TblList(0)(0) & "("
        'For i = 0 To FldArray.GetUpperBound(0)
        '    sqlResult = sqlResult & FldArray(i)(0) & " , "
        '    Values = Values & " = @Val" & i & " , "
        'Next
        'sqlResult = sqlResult.Substring(0, Len(sqlResult) - Len(" , ")) & ") "
        'Values = Values.Substring(0, Len(Values) - Len(" , ")) & ") "
        'sqlResult = sqlResult & Values

        'dtAdapter.InsertCommand = New SqlCommand(sqlResult, Conn)
        'For i = 0 To FldArray.GetUpperBound(0)
        '    Col = dsChanges.Tables(0).Columns(i)
        '    DTType = ReturnDBType(Col.DataType.ToString)
        '    If DTType = SqlDbType.Variant Then
        '        GoTo Release
        '    End If

        '    ColParam = dtAdapter.InsertCommand.Parameters.Add("@Val" & i, DTType) 'SqlDbType.Decimal
        '    ColParam.SourceColumn = FldArray(i)(0)
        '    ColParam.SourceVersion = DataRowVersion.Current
        'Next

        '======================================================================================
        'Delete
        '======================================================================================
        sqlResult = "Delete From " & TblList(0)(0) & " Where "
        For i = 0 To PKArray.GetUpperBound(0)
            sqlResult = sqlResult & PKArray(i)(0) & " = @Cond" & i & " AND "
        Next
        sqlResult = sqlResult.Substring(0, Len(sqlResult) - Len(" AND "))

        dtAdapter.DeleteCommand = New SqlCommand(sqlResult, Conn)

        For i = 0 To PKArray.GetUpperBound(0)
            CondParam = dtAdapter.DeleteCommand.Parameters.Add("@Cond" & i, PKArray(i)(1)) 'SqlDbType.DateTime
            CondParam.SourceColumn = PKArray(i)(0)
            CondParam.SourceVersion = DataRowVersion.Original
            'CondParam.Value = PKArray(i)(2)
        Next
        Dim cmd As SqlCommand
        cmd = dtAdapter.DeleteCommand



        'Update Section
        With dtAdapter
            .MissingMappingAction = MissingMappingAction.Error
            .TableMappings.Add("Table", MapTableName)   'TblList(0)(0)
            '''.TableMappings.Add(TblList(0)(0), "Table")
            For i = 0 To FldArray.GetUpperBound(0)
                If FldArray(i).Length > 1 Then
                    .TableMappings(0).ColumnMappings.Add(FldArray(i)(0), FldArray(i)(1))
                    '.TableMappings(0).ColumnMappings.Add(FldArray(i)(1), FldArray(i)(0))
                    '''.TableMappings(1).ColumnMappings.Add(FldArray(i)(0), FldArray(i)(1))
                Else
                    .TableMappings(0).ColumnMappings.Add(FldArray(i)(0), FldArray(i)(0))
                End If
            Next
        End With
        Try
            Conn.Open()
            'cmd.ExecuteNonQuery()
            UpdateDbFromDataSetV4 = dtAdapter.Update(dsChanges)
            'UpdateDbFromDataSetV4 = 1
        Catch ex As System.Data.SqlClient.SqlException
            'Message modified by Michael Pastor
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            Conn.Close()
            Exit Function
        Catch ex As System.FormatException
            'Message modified by Michael Pastor
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            Conn.Close()
            Exit Function
        Finally
            'close the connection
            Conn.Close()

        End Try
Release:
        dtAdapter.SelectCommand.Parameters.Clear()
        dtAdapter.SelectCommand.Dispose()
        dtAdapter.SelectCommand = Nothing

        dtAdapter.UpdateCommand.Parameters.Clear()
        dtAdapter.UpdateCommand.Dispose()
        dtAdapter.UpdateCommand = Nothing

        'dtAdapter.InsertCommand.Parameters.Clear()
        'dtAdapter.InsertCommand.Dispose()
        'dtAdapter.InsertCommand = Nothing

        dtAdapter.DeleteCommand.Parameters.Clear()
        dtAdapter.DeleteCommand.Dispose()
        dtAdapter.DeleteCommand = Nothing
        Conn = Nothing

        dtAdapter = Nothing
    End Function

    Public Function DeleteFromDataSetV4(ByVal dsChanges As DataSet, _
            ByVal SQLstr As String, ByVal PKArray As Object()()) As Integer

        Dim Conn As New SqlConnection(strConnection)
        Dim dtAdapter As SqlDataAdapter = New SqlDataAdapter(SQLstr, Conn)
        Dim ColParam As SqlParameter
        Dim CondParam As SqlParameter
        Dim DTType As SqlDbType

        Dim Col As DataColumn
        Dim i As Integer
        Dim TblList()() As Object
        Dim FldArray As Object()()
        Dim sqlResult As String
        Dim Values As String


        TblList = TablesList(SQLstr)

        FldArray = FieldsList(SQLstr)
        '======================================================================================
        'Delete
        '======================================================================================
        sqlResult = "Delete From " & TblList(0)(0) & " Where "
        For i = 0 To PKArray.GetUpperBound(0)
            sqlResult = sqlResult & PKArray(i)(0) & " = @Cond" & i & " AND "
        Next
        sqlResult = sqlResult.Substring(0, Len(sqlResult) - Len(" AND "))

        dtAdapter.DeleteCommand = New SqlCommand(sqlResult, Conn)

        For i = 0 To PKArray.GetUpperBound(0)
            CondParam = dtAdapter.DeleteCommand.Parameters.Add("@Cond" & i, PKArray(i)(1)) 'SqlDbType.DateTime
            CondParam.SourceColumn = PKArray(i)(0)
            CondParam.SourceVersion = DataRowVersion.Original
            CondParam.Value = PKArray(i)(2)
        Next
        Dim cmd As SqlCommand
        cmd = dtAdapter.DeleteCommand



        'Update Section

        With dtAdapter
            .MissingMappingAction = MissingMappingAction.Error
            .TableMappings.Add("Table", TblList(0)(0))
            '.TableMappings.Add("mft", "Table")
            For i = 0 To FldArray.GetUpperBound(0)
                If FldArray(i).Length > 1 Then
                    .TableMappings(0).ColumnMappings.Add(FldArray(i)(0), FldArray(i)(1))
                    '.TableMappings(0).ColumnMappings.Add(FldArray(i)(1), FldArray(i)(0))
                End If
            Next
        End With
        Try
            Conn.Open()
            cmd.ExecuteNonQuery()
            'DeleteFromDataSetV4 = dtAdapter.Update(dsChanges)
            DeleteFromDataSetV4 = 1
        Catch ex As System.Data.SqlClient.SqlException
            'Message modified by Michael Pastor
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            Conn.Close()
            Exit Function
        Finally
            'close the connection
            Conn.Close()

        End Try
Release:

        dtAdapter.DeleteCommand.Parameters.Clear()
        dtAdapter.DeleteCommand.Dispose()
        dtAdapter.DeleteCommand = Nothing
        Conn = Nothing
        dtAdapter = Nothing
    End Function


    Private Function ReturnDBType(ByVal DataType As String) As SqlDbType
        ReturnDBType = SqlDbType.Variant

        Select Case DataType
            Case "System.Integer", "System.Int32"
                ReturnDBType = SqlDbType.Int
            Case "System.Decimal"
                ReturnDBType = SqlDbType.Decimal
            Case "System.String"
                ReturnDBType = SqlDbType.VarChar
            Case "System.DateTime"
                ReturnDBType = SqlDbType.DateTime
            Case "System.Double"
                ReturnDBType = SqlDbType.Float
            Case "System.Boolean"
                ReturnDBType = SqlDbType.Bit
            Case Else
                'Message modified by Michael Pastor
                MsgBox("Error: SQLDBType Not Found!", MsgBoxStyle.Critical, "Critical Error")
                '- MsgBox("Error : SQLDBType Not Found!")
                Exit Function
        End Select

    End Function

    Public Function ExecuteQuery(ByVal Query As String, Optional ByVal cmdSQLTrans As SqlCommand = Nothing, Optional ByVal CloseConn As Boolean = True) As Boolean
        Dim Conn As SqlConnection '(strConnection)
        Dim cmd As SqlCommand '= New SqlCommand(Query, Conn)
        Dim HadErr As Boolean = False
        If Query = "" Then
            ExecuteQuery = True
            GoTo Release
        Else
            ExecuteQuery = False
        End If
        ExecuteQuery = False
        FixSingleQuote(Query, True)
        If cmdSQLTrans Is Nothing Then
            Conn = New SqlConnection(strConnection)
            cmd = New SqlCommand(Query, Conn)
        Else
            Conn = cmdSQLTrans.Connection
            cmd = cmdSQLTrans
            cmd.CommandText = Query
        End If
        Try
            If cmd.Connection.State <> ConnectionState.Open Then
                Conn.Open()
            End If
            cmd.ExecuteNonQuery()
        Catch ex As System.Data.SqlClient.SqlException
            'Message modified by Michael Pastor
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            HadErr = True
            GoTo Release
        Finally
            If HadErr = False Then
                ExecuteQuery = True
            End If
            'close the connection
        End Try
Release:
        If Not Conn Is Nothing Then
            If CloseConn = True And Conn.State = ConnectionState.Open Then
                If Not cmd.Transaction Is Nothing Then
                    If HadErr Then
                        cmd.Transaction.Rollback()
                    Else
                        cmd.Transaction.Commit()
                    End If
                End If
                Conn.Close()
                cmd = Nothing
            End If
        End If
        Conn = Nothing
    End Function

    Public Sub umskDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim DateText As String = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals)
        Dim YearSec, DaySec, MoSec, DateTextRaw As String
        Dim YearVal, MoVal, DayVal As Int32
        Dim StrArr() As String

        DateTextRaw = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)
        YearSec = DateText.Substring(DateText.LastIndexOf("/") + 1)
        StrArr = GetCtrldbFieldInfo(sender)
        If StrArr.Length >= (TagOpts.DefaultVal + 1) Then
            If DateTextRaw.Trim = "" And StrArr(TagOpts.DefaultVal).ToUpper = "NOW" Then
                sender.Text = Format(Now(), "MM/dd/yyyy")
                Exit Sub
            End If
        End If

        If YearSec.Trim = "" Then
            YearVal = Year(Now)
        ElseIf Val(YearSec) < 70 Then
            YearVal = 2000 + Val(YearSec)
            sender.text = DateText.Substring(0, DateText.LastIndexOf("/") + 1) & YearVal
        ElseIf Val(YearSec) >= 70 And Val(YearSec) < 100 Then
            YearVal = 1900 + Val(YearSec)
            sender.Text = DateText.Substring(0, DateText.LastIndexOf("/") + 1) & YearVal
        ElseIf Val(YearSec) >= 100 And Val(YearSec) < 1000 Then
            'Message modified by Michael Pastor
            MsgBox("Year inputed is invalid. Please re-enter a valid year.", MsgBoxStyle.Exclamation, "Data Invalid")
            '- MsgBox("Invalid Year!")
            e.Cancel = True
        End If

        'MoSec = DateText.Substring(DateText.LastIndexOf("/") - 2, 2)
        'If MoSec.Trim = "" Then
        '    MoVal = Month(Now)
        '    sender.Text = DateText.Substring(0, DateText.LastIndexOf("/") - 2) & MoVal & DateText.Substring(DateText.LastIndexOf("/"))
        'ElseIf Val(MoSec) > 12 Or Val(MoSec) < 1 Then
        '    MsgBox("Invalid Month!")
        '    e.Cancel = True
        'End If

        'DaySec = DateText.Substring(DateText.IndexOf("/") - 2)
        'If DaySec.Trim = "" Then
        '    DayVal = Microsoft.VisualBasic.Day(Now)
        'ElseIf Val(DaySec) > 31 Or Val(MoSec) < 1 Then
        '    MsgBox("Invalid Month!")
        '    e.Cancel = True
        'Else 'Check day is valid for month and year

        'End If
    End Sub

    Public Function MatchText(ByRef oRow As Infragistics.Win.UltraWinGrid.UltraGridRow, _
                              ByRef UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid, _
                              ByRef m_searchInfo As clsSearchInfo, _
                              ByRef m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn) As Boolean

        If oRow Is Nothing Then
            MatchText = False
            Exit Function
        End If
        If oRow.ListObject Is Nothing Then
            MatchText = False
            Exit Function
        End If

        Dim strColumnKey As String = m_searchInfo.lookIn
        Dim oCol As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim strCellValue As String = ""

        '   Determine whether we are searching the current column or all columns
        Dim bSearchAllColumns = True
        If UltraGrid1.DisplayLayout.Bands(0).Columns.Exists(strColumnKey) Then bSearchAllColumns = False

        '   If we are searching all columns then we must iterate through all the cells
        '    in this row, which we can do by using the band's Columns collection
        If bSearchAllColumns Then
            For Each oCol In UltraGrid1.DisplayLayout.Bands(0).Columns
                If Not oRow.Cells(oCol.Key).Value Is Nothing Then
                    If Match(m_searchInfo, oRow.Cells(oCol.Key).Value) Then
                        MatchText = True
                        m_oColumn = oCol
                        Exit Function
                    Else
                        MatchText = False
                    End If
                End If
            Next
        Else
            oCol = UltraGrid1.DisplayLayout.Bands(0).Columns(strColumnKey)
            If Not oRow.Cells(oCol.Key).Value Is Nothing Then
                If Match(m_searchInfo, oRow.Cells(oCol.Key).Value) Then
                    MatchText = True
                    m_oColumn = oCol
                    Exit Function
                End If
            End If
        End If

    End Function

    Public Function Match(ByRef m_searchInfo As clsSearchInfo, ByVal cellValue As String) As Boolean
        Dim userString As String = m_searchInfo.searchString

        '   If our search is case insensitive, make both strings uppercase
        If Not m_searchInfo.matchCase Then
            userString = userString.ToUpper
            cellValue = cellValue.ToUpper
        End If

        '   If we are searching any part of the cell value...
        If m_searchInfo.searchContent = SearchContentEnum.AnyPartOfField Then

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

        ElseIf m_searchInfo.searchContent = SearchContentEnum.WholeField Then
            If userString = cellValue Then Match = True Else Match = False
            Exit Function

        ElseIf m_searchInfo.searchContent = SearchContentEnum.StartOfField Then
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

    Public Function ReadOnlyControls(ByVal Container As Object, ByVal RO As Boolean)
        Dim Ctrl As Control
        Dim StrArr() As String
        Dim BkGrnd, FrGrnd As Color
        If RO Then
            FrGrnd = Color.Black
            BkGrnd = System.Drawing.SystemColors.Control
        Else
            FrGrnd = Color.Black
            BkGrnd = Color.White
        End If

        ''Dim cstat As Boolean = Container.controls(0).enabled
        ''Container.controls(0).enabled = False
        ''BkGrnd = Container.controls(0).backcolor
        ''Container.controls(0).enabled = cstat

        For Each Ctrl In Container.controls
            StrArr = GetCtrldbFieldInfo(Ctrl)
            With Ctrl
                Select Case Ctrl.GetType().ToString
                    Case "System.Windows.Forms.TextBox", "RoutesModule.MyTextBox", "Infragistics.Win.UltraWinEditors.UltraTextEditor"
                        Dim TempCtrl As TextBox
                        Tempctrl = Ctrl
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        tempctrl.readonly = RO
                        tempctrl.ForeColor = FrGrnd
                        'If InStr(BkGrnd.ToString, "Empty") <= 0 Then tempctrl.BackColor = BkGrnd
                        tempctrl.TabStop = Not RO
                    Case "Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit"
                        Dim TempCtrl As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
                        tempctrl = Ctrl
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        tempctrl.Enabled = Not RO
                        If tempctrl.Enabled Then
                            tempctrl.Appearance.BackColor = BkGrnd
                            tempctrl.Appearance.ForeColor = FrGrnd
                        Else
                            tempctrl.Appearance.BackColorDisabled = BkGrnd
                            tempctrl.Appearance.ForeColorDisabled = FrGrnd
                        End If
                    Case "Infragistics.Win.UltraWinGrid.UltraGrid"
                        Dim TempCtrl As Infragistics.Win.UltraWinGrid.UltraGrid
                        tempctrl = Ctrl
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        tempctrl.Enabled = Not RO

                    Case "System.Windows.Forms.ComboBox"
                        Dim TempCtrl As ComboBox
                        TempCtrl = Ctrl
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        TempCtrl.Enabled = Not RO
                        'tempctrl.TabStop = Not RO
                        'tempctrl.ForeColor = FrGrnd
                        'If InStr(BkGrnd.ToString, "Empty") <= 0 Then tempctrl.BackColor = BkGrnd

                    Case "Infragistics.Win.UltraWinGrid.UltraCombo"
                        Dim TempCtrl As Infragistics.Win.UltraWinGrid.UltraCombo
                        tempctrl = Ctrl
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        tempctrl.Enabled = Not RO
                        If tempctrl.Enabled Then
                            tempctrl.Appearance.BackColor = BkGrnd
                            tempctrl.Appearance.ForeColor = FrGrnd
                        Else
                            tempctrl.Appearance.BackColorDisabled = BkGrnd
                            tempctrl.Appearance.ForeColorDisabled = FrGrnd
                        End If
                    Case "Infragistics.Win.UltraWinEditors.UltraCheckEditor"
                        Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraCheckEditor
                        tempctrl = Ctrl
                        'tempctrl.Checked = False
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        tempctrl.Enabled = Not RO
                        tempctrl.TabStop = Not RO
                        If tempctrl.Enabled Then
                            tempctrl.Appearance.BackColor = Color.White
                            tempctrl.Appearance.ForeColor = FrGrnd
                        Else
                            tempctrl.Appearance.BackColorDisabled = Color.White
                            tempctrl.Appearance.ForeColorDisabled = FrGrnd
                        End If
                    Case "System.Windows.Forms.CheckBox"
                        Dim TempCtrl As CheckBox
                        tempctrl = Ctrl
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        tempctrl.Enabled = Not RO
                        tempctrl.TabStop = Not RO
                        tempctrl.ForeColor = FrGrnd
                        tempctrl.BackColor = Color.White
                    Case "System.Windows.Forms.RadioButton"
                        Dim TempCtrl As RadioButton
                        TempCtrl = Ctrl
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        TempCtrl.Enabled = Not RO
                        tempctrl.TabStop = Not RO
                        tempctrl.ForeColor = FrGrnd
                    Case "System.Windows.Forms.Button"
                        Dim TempCtrl As System.Windows.Forms.Button
                        tempctrl = Ctrl
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        tempctrl.Enabled = Not RO
                        tempctrl.TabStop = Not RO
                        tempctrl.ForeColor = FrGrnd
                        'tempctrl.BackColor = BkGrnd
                    Case "System.Windows.Forms.DateTimePicker"
                        Dim TempCtrl As DateTimePicker
                        TempCtrl = Ctrl
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        tempctrl.Enabled = Not RO
                        'tempctrl.TabStop = Not RO
                    Case "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                        Dim TempCtrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
                        TempCtrl = Ctrl
                        If StrArr.Length > TagOpts.JustView Then
                            If StrArr(TagOpts.JustView).ToUpper = "VIEW" Then GoTo NextCtrl
                        End If
                        tempctrl.Enabled = Not RO
                    Case "System.Windows.Forms.GroupBox", "System.Windows.Forms.Panel"
                        ReadOnlyControls(Ctrl, RO)
                    Case "System.Windows.Forms.TabControl", "System.Windows.Forms.TabPage"
                        ReadOnlyControls(Ctrl, RO)
                    Case Else
                        '.Text = DataObj.Item(GridColCaption) 'StrArr(1))
                End Select
            End With
NextCtrl:
        Next



    End Function

    Public Class clsWeekDaysCount
        Public Date1 As Date
        Public Date2 As Date
        Public Days(7) As Integer
        Public SvcDays(7) As Boolean
    End Class
    Public Class clsMonthDays
        Public Year As Int16
        Public MonthIndex As Int16
        Public MonthName As String
        Public Date1 As Date
        Public Date2 As Date
    End Class

    Public Class clsHolidays
        Public dates() As Date
        Public WeekDaysCnt(7) As Int16
    End Class

    Public Function CountWeekDays(ByRef WeekDays As clsWeekDaysCount) As Boolean
        Dim DaysCnt, Days1, Days2, i As Int32
        Dim WeeksCnt As Int32
        Dim TempDate As Date

        CountWeekDays = False
        If WeekDays.Date2 < WeekDays.Date1 Then
            'Message modified by Michael Pastor
            MsgBox("'TO' date is sooner than 'FROM' date.", MsgBoxStyle.Exclamation, "Data Invalid")
            '- MsgBox("'TO' Date is smaller than 'FROM' date.")
            Exit Function
        End If
        DaysCnt = DateDiff(DateInterval.Day, WeekDays.Date1, WeekDays.Date2)
        WeeksCnt = DaysCnt / 7
        Days1 = DaysCnt - (WeeksCnt * 7)
        If WeeksCnt > 0 Then
            Days2 = 7 - Days1 - 1
        Else
            Days2 = 0
        End If

        For i = 0 To Days1
            WeekDays.Days(Weekday(DateAdd(DateInterval.Day, (-1) * i, WeekDays.Date2), FirstDayOfWeek.Monday)) = WeeksCnt + 1
        Next
        TempDate = DateAdd(DateInterval.Day, (-1) * i, WeekDays.Date2)
        For i = 0 To Days2 - 1
            WeekDays.Days(Weekday(DateAdd(DateInterval.Day, (-1) * i, TempDate), FirstDayOfWeek.Monday)) = WeeksCnt
        Next
        For i = 0 To 7
            WeekDays.SvcDays(i) = False
        Next

        CountWeekDays = True


    End Function

    Public Function GetMonthDays(ByRef MonthDays As clsMonthDays) As Boolean
        Dim NextMonthBDate As Date
        ' Input = Year , Month Index
        ' Output = Month Name, Start & End Date
        MonthDays.Date1 = "#" & Format(MonthDays.MonthIndex, "0#") & "/01/" & MonthDays.Year & "#"
        NextMonthBDate = DateAdd(DateInterval.Month, 1, MonthDays.Date1)
        MonthDays.Date2 = DateAdd(DateInterval.Day, -1, NextMonthBDate)
        MonthDays.MonthName = MonthName(MonthDays.MonthIndex, False)
    End Function

    Public Function CheckSetupINI() As Boolean
        Dim Buffer As New IO.MemoryStream
        Dim i As Int16

        Dim srObj As StreamReader
        Dim strLine, SplitStr(), Servers(), IPAddr, IPName As String

        On Error GoTo ErrTrap

        CheckSetupINI = False
        'Pass the file path and the file name to the StreamReader constructor.
        srObj = New StreamReader("Setup.ini")

        'Read the first line of text.
        For i = 0 To 1
            strLine = srObj.ReadLine
            If strLine Is Nothing Then Exit Function
            Servers = strLine.Split("=")
            SplitStr = Servers(1).Split(",")
            If SplitStr.Length > 0 Then
                SplitStr(0) = SplitStr(0).Trim
                IPAddr = SplitStr(0)
            Else
                IPAddr = ""
            End If
            If SplitStr.Length > 1 Then
                SplitStr(1) = SplitStr(1).Trim
                IPName = SplitStr(1)
            Else
                IPName = IPAddr
            End If

            Select Case Servers(0).Trim.ToUpper
                Case "LOCALIP"
                    If LocalIP <> "" Then
                        MsgBox("Duplicate lines for LocalIP in Setup.ini . Aborting the program.")
                        Exit Function
                    End If
                    LocalIP = IPAddr
                    LocalName = IPName
                Case "REMOTEIP"
                    If RemoteIP <> "" Then
                        MsgBox("Duplicate lines for LocalIP in Setup.ini . Aborting the program.")
                        Exit Function
                    End If
                    RemoteIP = IPAddr
                    RemoteName = IPName
                Case Else
                    'Message modified by Michael Pastor
                    MsgBox("Setup.ini is found to be of an invalid format. Aborting program.", MsgBoxStyle.Critical, "Critical Error")
                    '- MsgBox("Invalid Setup.ini file format. Aborting the program.")
                    Exit Function
            End Select
        Next

        srObj.Close()
        srObj = Nothing
        CheckSetupINI = True

        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("CheckSetupFile: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("CheckSetupFile: " & Err.Description)
        'Resume
        Exit Function
    End Function
    Public Sub CheckSetups()
        Dim qSetups As String = "Select * from Setups "
        Dim dsTemp As New System.Data.DataSet
        Dim daTemp As New SqlDataAdapter
        Dim row As DataRow

        If Not PopulateDataset2(daTemp, dsTemp, qSetups) Is Nothing Then
            If dsTemp.Tables(0).Rows.Count > 0 Then
                row = dsTemp.Tables(0).Rows(0)
                LocalIP = row("LocalIP")
                RemoteIP = row("RemoteIP")
                If LocalIP = "" Then ' Branch
                    'GroupBox1.Enabled = False
                    'GroupBox3.Enabled = False
                End If

                If RemoteIP = "" Then ' Corp
                    'GroupBox2.Enabled = False
                End If

                If (LocalIP & RemoteIP) <> (RemoteIP & LocalIP) Then
                    'GroupBox4.Enabled = False 'Cust
                End If

            End If
        End If
        daTemp.Dispose()
        dsTemp.Dispose()
        daTemp = Nothing
        dsTemp = Nothing
        row = Nothing

    End Sub

    Public Sub Value_Dec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles utFuel.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Public Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles utDriverID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled = True
        End If
    End Sub

    Public Sub FixSingleQuote(ByRef Query As String, Optional ByVal IsSQLQry As Boolean = False)
        Dim StrArr() As Char
        Dim i As Int32

        Exit Sub

        i = 0
        If IsSQLQry Then

            Dim j, Found, TotalFnd, Pos(Query.Length - 1), PosCorr, WHEREIndex As Int32
            Query = Query.ToUpper
            WHEREIndex = Query.IndexOf(" WHERE ")
            Found = 0
            TotalFnd = 0
            StrArr = Query.ToCharArray(0, Query.Length)
            If WHEREIndex <= 0 Then
                WHEREIndex = StrArr.Length - 1
            End If
            For i = 0 To WHEREIndex

                Select Case StrArr(i)
                    Case "'"
                        Select Case Found
                            Case 0
                                Found = 1
                                TotalFnd += 1
                                Pos(TotalFnd - 1) = i
                            Case 1
                                Found = 2
                                TotalFnd += 1
                                Pos(TotalFnd - 1) = i
                            Case 2
                                TotalFnd += 1
                                Pos(TotalFnd - 1) = i

                                For j = i + 1 To StrArr.Length - 1
                                    If StrArr(j) = "'" Then

                                    End If
                                    If StrArr(j) <> " " And StrArr(j) <> "," Then
                                        Query = Query.Insert(Pos(TotalFnd - 2) + PosCorr, "'")
                                        PosCorr += 1
                                        Found = 1
                                        Exit For
                                    End If
                                Next
                                'If StrArr(i - 1) = "'" Then
                                '    Found = 3
                                '    Pos(TotalFnd - 1) = i
                                'Else
                                '    Query = Query.Insert(Pos(TotalFnd - 2) + PosCorr, "'")
                                '    PosCorr += 1
                                '    Found = 2
                                'End If
                        End Select
                    Case ","
                        Select Case Found
                            Case 0
                                'Nothing
                            Case 1
                                ' Part of Text, Carry on
                            Case 2
                                Found = 0

                        End Select
                End Select
            Next

            WHEREIndex = Query.IndexOf(" WHERE ")
            If WHEREIndex > 0 Then
                Dim WhereParts() As String
                Dim WhereClause, xQuery As String
                Dim AndArr() As Char = {" ", "A", "N", "D", " "}
                'Dim j As Int32

                WhereClause = Query.Substring(WHEREIndex)
                WhereParts = WhereClause.Split(AndArr) '(" AND ")
                xQuery = Query.Substring(0, WHEREIndex)
                For j = 0 To WhereParts.Length - 1
                    StrArr = WhereParts(j).ToCharArray
                    Found = 0
                    TotalFnd = 0
                    Pos.Clear(Pos, 0, Pos.Length)
                    PosCorr = 0
                    For i = 0 To StrArr.Length - 1

                        Select Case StrArr(i)
                            Case "'"
                                Select Case Found
                                    Case 0
                                        Found = 1
                                        TotalFnd += 1
                                        Pos(TotalFnd - 1) = i
                                    Case 1
                                        Found = 2
                                        TotalFnd += 1
                                        Pos(TotalFnd - 1) = i
                                    Case 2
                                        TotalFnd += 1
                                        Pos(TotalFnd - 1) = i
                                        If StrArr(i - 1) = "'" Then
                                            Found = 1
                                            'Pos(TotalFnd - 1) = i
                                        Else
                                            WhereParts(j) = WhereParts(j).Insert(Pos(TotalFnd - 2) + PosCorr, "'")
                                            PosCorr += 1
                                            Found = 2
                                        End If
                                End Select
                        End Select
                    Next i
                    If Found = 1 Then
                        WhereParts(j) = WhereParts(j).Insert(Pos(TotalFnd - 2) + PosCorr, "'")
                        PosCorr += 1
                        Found = 0
                    End If
                    xQuery = xQuery & WhereParts(j) & " AND "
                Next j
                xQuery = xQuery.Substring(0, xQuery.Length - 1 - Len(" AND "))
                Query = xQuery
            End If 'WHERE Clause

        Else

            While i <> -1
                i = Query.IndexOf("'S", i)
                'If i = 0 Then Exit While
                If i >= 1 Then
                    If Query.Substring(i - 1, 1) <> "'" Then
                        Query = Query.Insert(i, "'")
                        i += 2
                    Else
                    End If
                End If
            End While

            i = 0
            While i <> -1
                i = Query.IndexOf("S'", i)
                If i = -1 Then Exit While
                If i > 1 Then
                    If Query.Substring(i + 1, 1) <> "'" Then
                        Query = Query.Insert(i, "'")
                        i += 2
                    Else ' Could be '.... Jones'' (last ' for termination)
                        If IsSQLQry Then
                            If (i + 2) >= Query.Length Then
                                Query = Query.Insert(i, "'")
                                'i += 2
                                Exit While
                            End If
                        End If
                    End If
                End If
            End While
        End If


    End Sub

    Public Function GetPassword(ByVal Pass As String, Optional ByVal Title As String = "Password Needed To Continue...") As Boolean
        Dim x As New EnterTextBox
        'Dim FileName As String

        GetPassword = False

        On Error GoTo ErrTrap

        'If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "Enter Password:"
        x.Label2.Text = ""
        x.Label2.Visible = False
        x.btnBrowse1.Visible = False

        x.Text = Title
        x.TextBox1.Enabled = True
        x.TextBox1.Text = ""
        x.btnSave.Text = "&OK"
        x.AcceptButton = x.btnSave
        x.CancelButton = x.btnExit

        x.TextBox2.Visible = False
        'x.Show()
        x.ShowDialog()
        If x.DialogResult = DialogResult.OK Then
            If x.TextBox1.Text.Trim <> Pass Then
                'Message modified by Michael Pastor
                MsgBox("Password is incorrect.", MsgBoxStyle.Exclamation, "Incorrect Password")
                '- MsgBox("Incorrect password.")
            Else
                GetPassword = True
            End If
            x.Dispose()
            x = Nothing
        End If
        Exit Function
ErrTrap:
        If Err.Number > 0 Then
            'Message modified by Michael Pastor
            MsgBox("Error: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error: " & Err.Description)
        End If

    End Function

    Public Function GetImportPath() As Boolean
        'Dim Buffer As New IO.MemoryStream
        Dim i As Int16

        Dim srObj As StreamReader
        Dim strLine, SplitStr(), Servers(), IPAddr, IPName As String

        On Error GoTo ErrTrap

        GetImportPath = False
        'Pass the file path and the file name to the StreamReader constructor.
        srObj = New StreamReader("Setup.ini")

        'Read the first line of text.

        strLine = srObj.ReadLine

        While Not strLine Is Nothing
            Servers = strLine.Split("=")
            Select Case Servers(0).Trim.ToUpper
                Case "IPIPATH"
                    IPIPath = Servers(1)
                Case "EDIPATH"
                    EDIPath = Servers(1)
                Case "SCANLISTPATH"
                    ScanListPath = Servers(1)
                Case Else
            End Select
            strLine = srObj.ReadLine
        End While

        srObj.Close()
        srObj = Nothing
        GetImportPath = True

        Exit Function
ErrTrap:
        'Message modified by Michael Pastor
        MsgBox("GetImportPath: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("GetImportPath: " & Err.Description)
        'Resume
        Exit Function
    End Function

    ''
    ' Private Function IsFutureDate(ByVal p_sDate As String) As Integer
    ' Input:
    '   p_sDate - a string with a date in one of the standard formats, ie mm/dd/yyyy, mm-dd-yy, etc.
    ' Return Values:
    '   -1 if the date is in the past
    '    0 if the date in in the present
    '    1 if the date is in the future
    ''
    Public Function IsFutureDate(ByVal p_sDate As String) As Integer
        Dim dEndDate As Date = p_sDate
        dEndDate.CompareTo(CDate(p_sDate))
        If dEndDate.Date < Date.Today Then Return -1
        If dEndDate.Date = Date.Today Then Return 0
        If dEndDate.Date > Date.Today Then Return 1
    End Function

    Public Sub StandardFormPrep(ByRef rp_oMe As System.Windows.Forms.Form, ByRef rp_sMeText As String, ByVal p_sTablePath As String)

        'Standard Code for Most Unison Form's Load Event

        AddHandler rp_oMe.Activated, AddressOf Form_Activated
        AddHandler rp_oMe.KeyUp, AddressOf Form_KeyUp

        If Not rp_oMe.Tag Is Nothing Then
            If rp_oMe.Tag <> "" Then
                rp_oMe.Tag = p_sTablePath & rp_oMe.Tag
            End If
        End If

        'rp_oMe.CenterToScreen() 'Must be called from form's code because CenterToString() is protected

        rp_oMe.KeyPreview = True
        rp_sMeText = rp_oMe.Text

    End Sub

    Public Sub CheckAll(ByRef rp_CheckedListBox As System.Windows.Forms.CheckedListBox, Optional ByVal p_bStatus As Boolean = True)
        Dim i As Integer
        For i = 0 To rp_CheckedListBox.Items.Count - 1
            rp_CheckedListBox.SetItemChecked(i, p_bStatus)
        Next
    End Sub

End Module

