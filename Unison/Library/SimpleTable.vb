Imports System.Text
Imports System.Data.SqlClient


Public Class SimpleTable
    ' This is the base class of all the simple table objects used in unison.  The purpose of the simple table objects is to introduce the 
    ' concept of Data Layer abstraction into Unison.  Since Unison was not created under the multi-tiered concept, this is an effort to move
    ' Unison in that direction.  In essence, these SimpleTable derived objects become BLL components.  The separation of layers will become
    ' more and more pervasive as we move along.

    ' Members used to query the Unison Database
    Protected m_oDataAdapter As SqlDataAdapter
    Protected m_oDataSet As DataSet

    ' The table name
    Protected m_sTableName As String
    Protected m_sTablePath As String
    Public ReadOnly Property TableName() As String
        Get
            Return " " & m_sTablePath & m_sTableName & " "
        End Get
    End Property


    ' Utillty Members
    Protected m_sb As New StringBuilder
    Protected Sub ResetSB()
        m_sb.Remove(0, m_sb.Length)
    End Sub

    Public Overridable Function Clear() As Boolean

        Try

            Dim bRetVal As Boolean = False

            bRetVal = ClearErrorState()

            If bRetVal = True Then

                If Not IsNothing(m_oDataAdapter) Then m_oDataAdapter.Dispose()
                If Not IsNothing(m_oDataSet) Then m_oDataSet.Dispose()

                m_strSelectStmt = String.Empty
                m_strInsertStmt = String.Empty

                bRetVal = True

            End If


            Return bRetVal

        Catch ex As Exception

            SetError(ex.Message & " in SimpleTable.Clear()")
            Return False

        End Try


    End Function

    ' Error Status Members
    Private m_bHasError As Boolean
    Public ReadOnly Property HasError() As Boolean
        Get
            Return m_bHasError
        End Get
    End Property

    Private m_sErrorMessage As String
    Public ReadOnly Property ErrorMessage() As String
        Get
            Return m_sErrorMessage
        End Get
    End Property

    Public Function ClearErrorState() As Boolean

        Try

            m_bHasError = False
            m_sErrorMessage = String.Empty

            Return True

        Catch ex As Exception

            SetError(ex.Message & " in SimpleTable.ClearErrorState()")
            Return False

        End Try

    End Function

    Protected Sub SetError(ByVal p_sErrorMsg As String)

        m_bHasError = True
        m_sErrorMessage = p_sErrorMsg

    End Sub


    Protected Overridable Function SqlValueList() As String
        ' This will be used to construct and return the table's full ValueList, enclosed in paranthesis
        Return String.Empty
    End Function

    Protected Overridable Function SqlColumnList() As String
        ' This will be used to construct and return the table's full column list minus any AutoIncrement fields, enclosed in paranthesis.
        ' It is meant to complment the SqlValueList
        Return String.Empty
    End Function

    Private m_strInsertStmt As String
    Protected Overridable ReadOnly Property InsertStatement() As String
        ' This will be used to construct and return the object's default Insert Statement,
        Get
            Return String.Empty
        End Get
    End Property

    Private m_strSelectStmt As String
    Protected Overridable ReadOnly Property SelectStatement() As String
        ' This will be used to construct and return the object's default Select Statement.
        Get
            Return String.Empty
        End Get
    End Property

    Public Overridable Function Insert() As Boolean
        ' This function forces children to override the default insert statement.  It will return true if successful, false otherwise
        Return False
    End Function

    Public Overridable Function SelectByKey() As Boolean
        ' This function forces children to override the default select statement.  It will return true if successful, false otherwise
        Return False
    End Function

End Class
