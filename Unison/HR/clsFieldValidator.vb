Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient


Public Class clsFieldValidator

#Region "Range Validations"

    Public Function Range(ByVal ctl As Control, ByVal min As Double, ByVal max As Double, Optional ByVal inclusive As Boolean = True) As Boolean

        Dim bReturn As Boolean
        Dim strTmp As String = ctl.Text

        If strTmp = "" Then strTmp = "0" 'To make sure function doesn't try to cast a null string

        If inclusive Then
            Range = IIf(((CDbl(strTmp) >= min) And (CDbl(strTmp) <= max)), True, False)
        Else
            Range = IIf(((CDbl(strTmp) > min) And (CDbl(strTmp) < max)), True, False)
        End If

    End Function

    Public Function Range(ByVal ctl As Control, ByVal min As Long, ByVal max As Long, Optional ByVal inclusive As Boolean = True) As Boolean

        Dim strTmp As String = ctl.Text

        If strTmp = "" Then strTmp = "0" 'To make sure function doesn't try to cast a null string

        If inclusive Then
            Range = IIf((CDbl(strTmp) >= min) And (CDbl(strTmp) <= max), True, False)
        Else
            Range = IIf((CDbl(strTmp) > min) And (CDbl(strTmp) < max), True, False)
        End If

    End Function

    Public Function Range(ByVal tstDate As Date, ByVal past As Date, ByVal future As Date, Optional ByVal inclusive As Boolean = True) As Boolean

        If inclusive Then
            Range = IIf((tstDate >= past) And (tstDate <= future), True, False)
        Else
            Range = IIf((tstDate >= past) And (tstDate <= future), True, False)
        End If

    End Function

    Public Function Range(ByVal ctl As Control, ByVal min As Int16, ByVal max As Int16, Optional ByVal inclusive As Boolean = True) As Boolean
        Dim strTmp As String = ctl.Text

        If strTmp = "" Then strTmp = "0" 'To make sure function doesn't try to cast a null string

        If inclusive Then
            Range = IIf((CInt(strTmp) >= min) And (CInt(strTmp) <= max), True, False)
        Else
            Range = IIf((CInt(strTmp) > min) And (CInt(strTmp) < max), True, False)
        End If
    End Function


#End Region

#Region "Set Validations"

        ''
        'Method :   Public Function TextInSet(ByVal ctl As Control, ByVal dataSet As Data.DataSet, Optional ByVal bInSet As Boolean = True) As Boolean
        'PURPOSE:   This function will determine if the control's text property is in the current DataView.  The key represents the column name to compare
        'RETURNS:   True if match found, False otherwise
        ''
    Public Function TextInSet(ByVal ctl As Control, ByVal key As String, ByVal dataView As DataView, Optional ByVal bInSet As Boolean = True) As Boolean

        'Use the DataSet's Select method to find a match
        Dim dataRow As DataRow
        Dim dataRows As DataRowCollection
        Dim bReturn As Boolean = False

        dataRows = DataView.Table.Rows

        For Each dataRow In dataRows
            If IsNumeric(ctl.Text.ToString) Then 'This must be replaced with code that makes sure ToString can cast to (key)
                If dataRow(key) = ctl.Text.ToString Then
                    bReturn = True
                    Exit For
                End If
            End If
        Next

        Return bReturn

    End Function

#End Region

End Class

