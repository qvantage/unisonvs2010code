Imports TTSI.BARCODES
Imports System.Data.SqlClient
Imports System.Text

Module WeightVars

    Public WEIGHTDBName As String ' = "UN_WEIGHT" '"RoutesModule"
    Public WEIGHTDBUser As String = "Unison" '"Routes"
    Public WEIGHTDBPass As String = "unison" '"routes"
    Public WEIGHTTblPath As String ' = WEIGHTDBName & ".dbo."


    Public Class TrackingLink
        '   This class maps to a single Row of the UN_WEIGHT.dbo.TrakingLink table, for basic SELECT & INSERT operations.
        '   This class also provides methods that return data based on information in other tables that link to this class.

        ' Members used to query the Unison Database
        Private m_oDataAdapter As SqlDataAdapter
        Private m_oDataSet As DataSet
        Private m_strInsertStmt As String
        Private ReadOnly Property InsertStatement() As String

            Get

                ResetSB()
                m_sb.Append("INSERT INTO ")
                m_sb.Append(WEIGHTTblPath)
                m_sb.Append("TrackingLink(WeightPlanID, CourierLabelID) VALUES ")
                m_sb.Append(Me.SqlValueList)

                m_strInsertStmt = m_sb.ToString()

                Return m_strInsertStmt

            End Get

        End Property

        Private m_strSelectStmt As String
        Private ReadOnly Property SelectStatement() As String
            Get
                ' The assumption is that a WeightPlan can only have 1 Barcode attached to it at a time.
                ResetSB()
                m_sb.Append("SELECT * FROM ")
                m_sb.Append(WEIGHTTblPath)
                m_sb.Append("TrackingLink WHERE WeightPlanID = ")
                m_sb.Append(Me.WeightPlanID)
                m_sb.Append(" AND Active = 1")

                m_strSelectStmt = m_sb.ToString()

                Return m_strSelectStmt
            End Get
        End Property

        Private m_strInactiveSelectStmt As String
        Private ReadOnly Property InactiveSelectStatement() As String
            Get
                ResetSB()
                m_sb.Append("SELECT * FROM ")
                m_sb.Append(WEIGHTTblPath)
                m_sb.Append("TrackingLink WHERE WeightPlanID = ")
                m_sb.Append(Me.WeightPlanID)
                m_sb.Append(" AND CourierLabelID = ")
                m_sb.Append(Me.CourierLabelID)
                m_sb.Append(" AND Active = 0")

                m_strSelectStmt = m_sb.ToString()

                Return m_strSelectStmt
            End Get
        End Property

        Private m_strDeleteStmt As String
        Private ReadOnly Property DeleteStatement() As String
            Get
                ' The assumption is that the RowID of this object has already been populated
                ' The Delete does not actually delete the record, it just inactivates it.
                ResetSB()
                m_sb.Append("UPDATE ")
                m_sb.Append(WEIGHTTblPath)
                m_sb.Append("TrackingLink SET Active = 0 WHERE RowID = ")
                m_sb.Append(Me.RowId)

                m_strDeleteStmt = m_sb.ToString()

                Return m_strDeleteStmt
            End Get
        End Property

        Private m_strUndeleteStmt As String
        Private ReadOnly Property UndeleteStatement() As String
            Get
                ResetSB()
                m_sb.Append("UPDATE ")
                m_sb.Append(WEIGHTTblPath)
                m_sb.Append("TrackingLink SET Active = 1 WHERE RowID = ")
                m_sb.Append(Me.RowId)
                Return m_sb.ToString()
            End Get
        End Property

        Public Sub Clear()
            Try
                If Not IsNothing(m_oDataAdapter) Then m_oDataAdapter.Dispose()
                If Not IsNothing(m_oDataSet) Then m_oDataSet.Dispose()
                m_strSelectStmt = m_strSelectStmt.Empty
                m_strInsertStmt = m_strInsertStmt.Empty
                m_iRowId = 0
                m_iWeightPlanID = 0
                m_iCourierLabelID = 0
                ClearErrorState()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try
        End Sub

        ' Utillty Members
        Private m_sb As New StringBuilder
        Private Sub ResetSB()
            m_sb.Remove(0, m_sb.Length)
        End Sub

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

        Public Sub ClearErrorState()
            m_bHasError = False
            m_sErrorMessage = String.Empty
        End Sub

        ' Object Status Members
        Private m_bIsEmpty As Boolean
        Public ReadOnly Property IsEmpty() As Boolean
            Get
                Return m_bIsEmpty
            End Get
        End Property

        ' Members that map to each row
        Private m_iWeightPlanID As Integer
        Public Property WeightPlanID() As Integer
            Get
                Return m_iWeightPlanID
            End Get
            Set(ByVal Value As Integer)
                m_iWeightPlanID = Value
            End Set
        End Property

        Private m_iCourierLabelID As Integer
        Public Property CourierLabelID() As Integer
            Get
                Return m_iCourierLabelID
            End Get
            Set(ByVal Value As Integer)
                m_iCourierLabelID = Value
            End Set
        End Property

        Private m_iRowId As Integer ' Auto-Increment
        Public ReadOnly Property RowId() As Integer
            Get
                Return m_iRowId
            End Get
        End Property

        Public ReadOnly Property SqlValueList() As String

            Get
                Dim sb As New StringBuilder

                sb.Append("(")
                sb.Append(Me.WeightPlanID)
                sb.Append(",")
                sb.Append(Me.CourierLabelID)
                sb.Append(")")

                Return sb.ToString()
            End Get

        End Property

        Public Function Insert() As Boolean

            ' First Check to see if it has been assigned in the past
            If SelectInactive() = True Then

                Return Undelete(Me.RowId)

            ElseIf m_bHasError = False Then

                ' If it has never existed, insert it
                Return ExecuteQuery(Me.InsertStatement)

            Else

                Return False

            End If

        End Function

        Public Function Delete(Optional ByVal p_iRowID As Integer = 0) As Boolean
            ' If passed a rowID, it will us it to determine which row to "delete".
            ' otherwise it will use the current value in the RowID property
            Try
                If p_iRowID = 0 Then
                    Return ExecuteQuery(Me.DeleteStatement)
                Else
                    m_iRowId = p_iRowID
                    Return ExecuteQuery(Me.DeleteStatement)
                End If
            Catch ex As Exception
                SetError(ex.Message)
                Return False
            End Try
        End Function

        Public Function Undelete(ByVal p_rowId As Integer) As Boolean

            Try

                m_iRowId = p_rowId
                Return ExecuteQuery(Me.UndeleteStatement)

            Catch ex As Exception

                SetError(ex.Message)
                Return False

            End Try


        End Function

        Public Function SelectByWeightPlanID(ByVal p_iWeightPlanID As Integer) As Boolean
            ' The assumption is that a WeightPlan can only have 1 Barcode attached to it at a time.
            ' This function will return true if 1 row is found, false in every other situation.
            ' If more than 1 row is returned, an error condition will also be set

            Clear()

            Try


                Dim iRowCount As Integer
                Dim oDataRow As DataRow
                Dim bRetVal As Boolean

                m_iWeightPlanID = p_iWeightPlanID

                PopulateDataset2(m_oDataAdapter, m_oDataSet, Me.SelectStatement)

                iRowCount = m_oDataSet.Tables(0).Rows.Count

                Select Case iRowCount

                    Case 0

                        ' No need to do anything
                        bRetVal = False

                    Case 1

                        ' Assogm Row data to Member Variables
                        oDataRow = m_oDataSet.Tables(0).Rows(0)
                        m_iRowId = oDataRow.Item("RowId")
                        m_iWeightPlanID = oDataRow.Item("WeightPlanID")
                        m_iCourierLabelID = oDataRow.Item("CourierLabelID")
                        bRetVal = True

                    Case Else

                        ' Record error event
                        SetError("More than record matches search criteria.  This is a violation of data integrety")
                        bRetVal = False

                End Select

                Return bRetVal

            Catch ex As Exception

                ' Record Exception Event
                SetError(ex.Message)
                Return False

            End Try

        End Function

        Public Function SelectInactive() As Boolean
            ' The assumption is that a WeightPlan can only have 1 Barcode attached to it at a time.
            ' This function will return true if 1 row is found, false in every other situation.
            ' If more than 1 row is returned, an error condition will also be set

            ClearErrorState()

            Try


                Dim iRowCount As Integer
                Dim oDataRow As DataRow
                Dim bRetVal As Boolean

                PopulateDataset2(m_oDataAdapter, m_oDataSet, Me.InactiveSelectStatement)

                iRowCount = m_oDataSet.Tables(0).Rows.Count

                Select Case iRowCount

                    Case 0

                        ' No need to do anything
                        bRetVal = False

                    Case 1

                        ' Assogm Row data to Member Variables
                        oDataRow = m_oDataSet.Tables(0).Rows(0)
                        m_iRowId = oDataRow.Item("RowId")
                        m_iWeightPlanID = oDataRow.Item("WeightPlanID")
                        m_iCourierLabelID = oDataRow.Item("CourierLabelID")
                        bRetVal = True

                    Case Else

                        ' Record error event
                        SetError("More than record matches search criteria.  This is a violation of data integrety")
                        bRetVal = False

                End Select

                Return bRetVal

            Catch ex As Exception

                ' Record Exception Event
                SetError(ex.Message)
                Return False

            End Try

        End Function

        Public Function GetBarcodeForWeightPlan(ByVal p_iWeightPlanID As Integer) As String

            If SelectByWeightPlanID(p_iWeightPlanID) Then

                Dim oDataAdapter As SqlDataAdapter
                Dim oDataSet As DataSet
                Dim sSqlCmd As String
                Dim iRowCount As Integer

                ResetSB()

                m_sb.Append("SELECT TrackingNum FROM ")
                m_sb.Append(WEIGHTTblPath)
                m_sb.Append("CourierLabels WHERE RowID = ")
                m_sb.Append(Me.CourierLabelID)
                m_sb.Append(" and Void = 'F'")

                sSqlCmd = m_sb.ToString()

                PopulateDataset2(oDataAdapter, oDataSet, sSqlCmd)

                iRowCount = oDataSet.Tables(0).Rows.Count

                If iRowCount = 1 Then
                    Return oDataSet.Tables(0).Rows(0).Item("TrackingNum")
                Else
                    Return String.Empty
                End If

            Else

                Return String.Empty

            End If

        End Function

        Public Function GetBarcodeByRowID(ByVal p_iRowID As Integer) As String

            Dim oDataAdapter As SqlDataAdapter
            Dim oDataSet As DataSet
            Dim sSqlCmd As String
            Dim iRowCount As Integer

            ResetSB()

            m_sb.Append("SELECT TrackingNum FROM ")
            m_sb.Append(WEIGHTTblPath)
            m_sb.Append("CourierLabels WHERE RowID = ")
            m_sb.Append(p_iRowID)
            m_sb.Append(" and Void = 'F'")

            sSqlCmd = m_sb.ToString()

            PopulateDataset2(oDataAdapter, oDataSet, sSqlCmd)

            iRowCount = oDataSet.Tables(0).Rows.Count

            If iRowCount = 1 Then
                Return oDataSet.Tables(0).Rows(0).Item("TrackingNum")
            Else
                Return String.Empty
            End If

        End Function

        Private Sub SetError(ByVal p_sErrorMsg As String)

            m_bHasError = False
            m_sErrorMessage = p_sErrorMsg

        End Sub

        Sub New()

            Clear()

        End Sub


    End Class


End Module
