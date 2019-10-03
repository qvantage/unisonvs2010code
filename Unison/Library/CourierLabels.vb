Imports TTSI.BARCODES
Imports System.Text
Imports System.Data.SqlClient

Public Class CourierLabels
    Inherits SimpleTable
    ' This class maps to a single Row of the UN_TRACKING.dbo.EVENT table.

    ' Members that map directly to database rows

    ''RowID
    Private m_iRowID As Integer 'Primary Key, Auto-increment
    Public Property RowID() As Integer
        Get
            Return m_iRowID
        End Get
        Set(ByVal Value As Integer)
            m_iRowID = Value
        End Set
    End Property

    ''SysDate
    Private m_dtSysDate As Date
    Public Property SysDate() As Date
        Get
            Return m_dtSysDate
        End Get
        Set(ByVal Value As Date)
            m_dtSysDate = Value
        End Set
    End Property

    ''Void
    Private m_bVoid As Boolean
    Private Property Void() As String
        Get
            If m_bVoid = True Then
                Return "T"
            Else
                Return "F"
            End If
        End Get
        Set(ByVal Value As String)

            If Value = "T" Then
                m_bVoid = True
            Else
                m_bVoid = False
            End If

        End Set
    End Property

    ''TrackingNum
    Private m_vcTrackingNum As VarChar
    Public Property TrackingNum() As String
        Get
            Return m_vcTrackingNum.Value
        End Get
        Set(ByVal Value As String)
            m_vcTrackingNum.Value = Value
        End Set
    End Property

    ''ParcelType
    Private m_vcParcelType As VarChar
    Public Property ParcelType() As String
        Get
            Return m_vcParcelType.Value
        End Get
        Set(ByVal Value As String)
            m_vcParcelType.Value = Value
        End Set
    End Property

    ''EmployeeID
    Private m_vcEmployeeID As VarChar
    Public Property EmployeeID() As String
        Get
            Return m_vcEmployeeID.Value
        End Get
        Set(ByVal Value As String)
            m_vcEmployeeID.Value = Value
        End Set
    End Property

    ''FromCustID
    Private m_vcFromCustID As VarChar
    Public Property FromCustID() As String
        Get
            Return m_vcFromCustID.Value()
        End Get
        Set(ByVal Value As String)
            m_vcFromCustID.Value = Value
        End Set
    End Property

    '' FromCustName
    Private m_vcFromCustName As VarChar
    Public Property FromCustName() As String
        Get
            Return m_vcFromCustName.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromCustName.Value = Value
        End Set
    End Property

    ''FromAddID
    Private m_iFromAddID As Integer
    Public Property FromAddID() As Integer
        Get
            Return m_iFromAddID
        End Get
        Set(ByVal Value As Integer)
            m_iFromAddID = Value
        End Set
    End Property

    ''FromLocID
    Private m_vcFromLocID As VarChar
    Public Property FromLocID() As String
        Get
            Return m_vcFromLocID.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromLocID.Value = Value
        End Set
    End Property

    ''FromLocName
    Private m_vcFromLocName As VarChar
    Public Property FromLocName() As String
        Get
            Return m_vcFromLocName.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromLocName.Value = Value
        End Set
    End Property

    ''FromAdd1
    Private m_vcFromAdd1 As VarChar
    Public Property FromAdd1() As String
        Get
            Return m_vcFromAdd1.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromAdd1.Value = Value
        End Set
    End Property

    ''FromAdd2
    Private m_vcFromAdd2 As VarChar
    Public Property FromAdd2() As String
        Get
            Return m_vcFromAdd2.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromAdd2.Value = Value
        End Set
    End Property

    ''FromCity
    Private m_vcFromCity As VarChar
    Public Property FromCity() As String
        Get
            Return m_vcFromCity.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromCity.Value = Value
        End Set
    End Property

    ''FromState
    Private m_vcFromState As VarChar
    Public Property FromState() As String
        Get
            Return m_vcFromState.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromState.Value = Value
        End Set
    End Property

    ''FromZip
    Private m_vcFromZip As VarChar
    Public Property FromZip() As String
        Get
            Return m_vcFromZip.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromZip.Value = Value
        End Set
    End Property

    ''FromContact
    Private m_vcFromContact As VarChar
    Public Property FromContact() As String
        Get
            Return m_vcFromContact.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromContact.Value = Value
        End Set
    End Property

    ''FromPhone
    Private m_vcFromPhone As VarChar
    Public Property FromPhone() As String
        Get
            Return m_vcFromPhone.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromContact.Value = Value
        End Set
    End Property

    ''FromEMail
    Private m_vcFromEMail As VarChar
    Public Property FromEMail() As String
        Get
            Return m_vcFromEMail.Value
        End Get
        Set(ByVal Value As String)
            m_vcFromEMail.Value = Value
        End Set
    End Property

    ''ToCustID
    Private m_vcToCustID As VarChar
    Public Property ToCustID() As String
        Get
            Return m_vcToCustID.Value
        End Get
        Set(ByVal Value As String)
            m_vcToCustID.Value = Value
        End Set
    End Property

    ''ToCustName 
    Private m_vcToCustName As VarChar
    Public Property ToCustName() As String
        Get
            Return m_vcToCustName.Value
        End Get
        Set(ByVal Value As String)
            m_vcToCustName.Value = Value
        End Set
    End Property

    ''ToAddID
    Private m_iToAddID As Integer
    Public Property ToAddID() As Integer
        Get
            Return m_iToAddID
        End Get
        Set(ByVal Value As Integer)
            m_iToAddID = Value
        End Set
    End Property

    ''ToLocID
    Private m_vcToLocID As VarChar
    Public Property ToLocID() As String
        Get
            Return m_vcToLocID.Value
        End Get
        Set(ByVal Value As String)
            m_vcToLocID.Value = Value
        End Set
    End Property

    ''ToLocName
    Private m_vcToLocName As VarChar
    Public Property ToLocName() As String
        Get
            Return m_vcToLocName.Value
        End Get
        Set(ByVal Value As String)
            m_vcToLocName.Value = Value
        End Set
    End Property

    ''ToAdd1
    Private m_vcToAdd1 As VarChar
    Public Property ToAdd1() As String
        Get
            Return m_vcToAdd1.Value
        End Get
        Set(ByVal Value As String)
            m_vcToAdd1.Value = Value
        End Set
    End Property

    ''ToAdd2
    Private m_vcToAdd2 As VarChar
    Public Property ToAdd2() As String
        Get
            Return m_vcToAdd2.Value
        End Get
        Set(ByVal Value As String)
            m_vcToAdd2.Value = Value
        End Set
    End Property

    ''ToCity
    Private m_vcToCity As VarChar
    Public Property ToCity() As String
        Get
            Return m_vcToCity.Value
        End Get
        Set(ByVal Value As String)
            m_vcToCity.Value = Value
        End Set
    End Property

    '' ToState
    Private m_vcToState As VarChar
    Public Property ToState() As String
        Get
            Return m_vcToState.Value
        End Get
        Set(ByVal Value As String)
            m_vcToState.Value = Value
        End Set
    End Property

    ''ToZip
    Private m_vcToZip As VarChar
    Public Property ToZip() As String
        Get
            Return m_vcToZip.Value
        End Get
        Set(ByVal Value As String)
            m_vcToZip.Value = Value
        End Set
    End Property

    ''ToContact
    Private m_vcToContact As VarChar
    Public Property ToContact() As String
        Get
            Return m_vcToContact.Value
        End Get
        Set(ByVal Value As String)
            m_vcToContact.Value = Value
        End Set
    End Property

    ''ToPhone
    Private m_vcToPhone As VarChar
    Public Property ToPHone() As String
        Get
            Return m_vcToPhone.Value
        End Get
        Set(ByVal Value As String)
            m_vcToPhone.Value = Value
        End Set
    End Property

    ''ToEMail
    Private m_vcToEMail As VarChar
    Public Property ToEMail() As String
        Get
            Return m_vcToEMail.Value
        End Get
        Set(ByVal Value As String)
            m_vcToEMail.Value = Value
        End Set
    End Property

    ''Remarks
    Private m_vcRemarks As VarChar
    Public Property Remarks() As String
        Get
            Return m_vcRemarks.Value
        End Get
        Set(ByVal Value As String)
            m_vcRemarks.Value = Value
        End Set
    End Property

    ''LabelRowID
    Private m_iLabelRowID As Integer
    Public Property LabelRowID() As Integer
        Get
            Return m_iLabelRowID
        End Get
        Set(ByVal Value As Integer)
            m_iLabelRowID = Value
        End Set
    End Property

    'Required Overrides
    Public Overrides Function Clear() As Boolean

        Try

            Dim bRetVal As Boolean = False

            bRetVal = MyBase.Clear()

            If bRetVal = True Then

                SysDate = Date.Now
                Void = String.Empty
                TrackingNum = String.Empty
                ParcelType = String.Empty
                EmployeeID = String.Empty
                FromCustID = String.Empty
                FromCustName = String.Empty
                FromAddID = 0
                FromLocID = String.Empty
                FromLocName = String.Empty
                FromAdd1 = String.Empty
                FromAdd2 = String.Empty
                FromCity = String.Empty
                FromState = String.Empty
                FromZip = String.Empty
                FromContact = String.Empty
                FromPhone = String.Empty
                FromEMail = String.Empty
                ToCustID = String.Empty
                ToCustName = String.Empty
                ToAddID = 0
                ToLocID = String.Empty
                ToLocName = String.Empty
                ToAdd1 = String.Empty
                ToAdd2 = String.Empty
                ToCity = String.Empty
                ToState = String.Empty
                ToZip = String.Empty
                ToContact = String.Empty
                ToPHone = String.Empty
                ToEMail = String.Empty
                Remarks = String.Empty
                LabelRowID = 0

                bRetVal = True

            End If

            Return bRetVal

        Catch ex As Exception

            SetError(ex.Message & " in CourierLabels.Clear()")
            Return False

        End Try

    End Function

    Protected Overrides Function SqlValueList() As String

        Dim sb As StringBuilder

        sb.Append(" ('")
        sb.Append(SysDate.ToShortDateString)
        sb.Append("','")
        sb.Append(Void)
        sb.Append("','")
        sb.Append(TrackingNum)
        sb.Append("','")
        sb.Append(ParcelType)
        sb.Append("','")
        sb.Append(EmployeeID)
        sb.Append("','")
        sb.Append(FromCustID)
        sb.Append("','")
        sb.Append(FromCustName)
        sb.Append("',")
        sb.Append(FromAddID)
        sb.Append(",'")
        sb.Append(FromLocID)
        sb.Append("','")
        sb.Append(FromLocName)
        sb.Append("','")
        sb.Append(FromAdd1)
        sb.Append("','")
        sb.Append(FromAdd2)
        sb.Append("','")
        sb.Append(FromCity)
        sb.Append("','")
        sb.Append(FromState)
        sb.Append("','")
        sb.Append(FromZip)
        sb.Append("','")
        sb.Append(FromContact)
        sb.Append("','")
        sb.Append(FromPhone)
        sb.Append("','")
        sb.Append(FromEMail)
        sb.Append("','")
        sb.Append(ToCustID)
        sb.Append("','")
        sb.Append(ToCustName)
        sb.Append("',")
        sb.Append(ToAddID)
        sb.Append(",'")
        sb.Append(ToLocID)
        sb.Append("','")
        sb.Append(ToLocName)
        sb.Append("','")
        sb.Append(ToAdd1)
        sb.Append("','")
        sb.Append(ToAdd2)
        sb.Append("','")
        sb.Append(ToCity)
        sb.Append("','")
        sb.Append(ToState)
        sb.Append("','")
        sb.Append(ToZip)
        sb.Append("','")
        sb.Append(ToContact)
        sb.Append("','")
        sb.Append(ToPHone)
        sb.Append("','")
        sb.Append(ToEMail)
        sb.Append("','")
        sb.Append(Remarks)
        sb.Append("',")
        sb.Append(LabelRowID)
        sb.Append(") ")

        Return sb.ToString()

    End Function

    Protected Overrides Function SqlColumnList() As String

        Dim sb As StringBuilder

        sb.Append(" (")
        sb.Append("SysDate,")
        sb.Append("Void,")
        sb.Append("TrackingNum,")
        sb.Append("ParcelType,")
        sb.Append("EmployeeID,")
        sb.Append("FromCustID,")
        sb.Append("FromCustName,")
        sb.Append("FromAddID,")
        sb.Append("FromLocID,")
        sb.Append("FromLocName,")
        sb.Append("FromAdd1,")
        sb.Append("FromAdd2,")
        sb.Append("FromCity,")
        sb.Append("FromState,")
        sb.Append("FromZip,")
        sb.Append("FromContact,")
        sb.Append("FromPhone,")
        sb.Append("FromEMail,")
        sb.Append("ToCustID,")
        sb.Append("ToCustName,")
        sb.Append("ToAddID,")
        sb.Append("ToLocId,")
        sb.Append("ToLocName,")
        sb.Append("ToAdd1,")
        sb.Append("ToAdd2,")
        sb.Append("ToCity,")
        sb.Append("ToState,")
        sb.Append("ToZip,")
        sb.Append("ToContact,")
        sb.Append("ToPhone,")
        sb.Append("ToEmail,")
        sb.Append("Remarks,")
        sb.Append("LabelRowID,")
        sb.Append(") ")

    End Function

    Protected Overrides ReadOnly Property InsertStatement() As String

        Get

            ResetSB()

            m_sb.Append("INSERT INTO ")
            m_sb.Append(TableName)
            m_sb.Append(SqlColumnList)
            m_sb.Append("VALUES")
            m_sb.Append(SqlValueList)

            Return m_sb.ToString()

        End Get

    End Property

    Protected Overrides ReadOnly Property SelectStatement() As String

        Get

            ResetSB()

            Dim s As String

            m_sb.Append("SELECT * FROM ")
            m_sb.Append(TableName)
            m_sb.Append("WHERE RowID = ")
            m_sb.Append(RowID)

            s = m_sb.ToString()

            Return s

        End Get

    End Property

    Protected ReadOnly Property SelectByBarcodeStatement() As String

        Get

            ResetSB()

            Dim s As String

            m_sb.Append("SELECT * FROM ")
            m_sb.Append(TableName)
            m_sb.Append("WHERE TrackingNum = '")
            m_sb.Append(TrackingNum)
            m_sb.Append("'")

            s = m_sb.ToString()

            Return s

        End Get

    End Property

    Public Overrides Function Insert() As Boolean

        Try

            Dim bRetVal As Boolean

            bRetVal = ExecuteQuery(InsertStatement)

            If bRetVal = False Then
                SetError("Insert Failed.")
            End If

            Return bRetVal

        Catch ex As Exception

            SetError(ex.Message & " in CourierLabels.Insert()")
            Return False

        End Try

    End Function

    Public Overrides Function SelectByKey() As Boolean

        Try

            Dim iRowCount As Integer = 0

            Dim sTmp As Integer = RowID 'Clear() resets all members.  We want to preserve value of RowId
            Dim bRetVal As Boolean = Clear()
            RowID = sTmp

            If bRetVal = True Then

                PopulateDataset2(m_oDataAdapter, m_oDataSet, SelectStatement())

                iRowCount = m_oDataSet.Tables(0).Rows.Count

                If iRowCount = 1 Then

                    bRetVal = CopyRowData(m_oDataSet.Tables(0).Rows(0))

                ElseIf iRowCount = 0 Then

                    SetError("Row was not found")
                    bRetVal = False

                Else

                    SetError("More than 1 row was found")
                    bRetVal = False

                End If

            End If

            Return bRetVal

        Catch ex As Exception

            SetError(ex.Message & " in SelectByKey()")
            Return False

        End Try

    End Function

    Public Function SelectByBarcode(Optional ByVal p_sBarcode As String = "") As Boolean

        Try

            If p_sBarcode <> "" Then TrackingNum = p_sBarcode 'will either use current value of TrackingNum member,or assign it based on parameter

            Dim iRowCount As Integer
            Dim bRetVal As Boolean = False

            If Not PopulateDataset2(m_oDataAdapter, m_oDataSet, SelectByBarcodeStatement()) Is Nothing Then

                iRowCount = m_oDataSet.Tables(0).Rows.Count

                If iRowCount = 1 Then

                    bRetVal = CopyRowData(m_oDataSet.Tables(0).Rows(0))

                ElseIf iRowCount = 0 Then

                    SetError("Row was not found")
                    bRetVal = False

                Else

                    SetError("More than 1 row was found")
                    bRetVal = False

                End If

            Else

                bRetVal = False

            End If


            Return bRetVal

        Catch ex As Exception

            SetError(ex.Message & " in SelectByBarcode()")
            Return False

        End Try

    End Function

    Private Function CopyRowData(ByRef p_oDataRow As DataRow) As Boolean

        Try

            RowID = p_oDataRow.Item("RowID")
            SysDate = p_oDataRow.Item("SysDate")
            Void = p_oDataRow.Item("Void")
            TrackingNum = p_oDataRow.Item("TrackingNum")
            ParcelType = p_oDataRow.Item("ParcelType")
            EmployeeID = p_oDataRow.Item("EmployeeID")
            FromCustID = p_oDataRow.Item("FromCustID")
            FromCustName = p_oDataRow.Item("FromCustName")
            FromAddID = p_oDataRow.Item("FromAddID")
            FromLocID = p_oDataRow.Item("FromLocID")
            FromLocName = p_oDataRow.Item("FromLocName")
            FromAdd1 = p_oDataRow.Item("FromAdd1")
            FromAdd2 = p_oDataRow.Item("FromAdd2")
            FromCity = p_oDataRow.Item("FromCity")
            FromState = p_oDataRow.Item("FromState")
            FromZip = p_oDataRow.Item("FromZip")
            FromContact = p_oDataRow.Item("FromContact")
            FromPhone = p_oDataRow.Item("FromPhone")
            FromEMail = p_oDataRow.Item("FromEMail")
            ToCustID = p_oDataRow.Item("ToCustID")
            ToCustName = p_oDataRow.Item("ToCustName")
            ToAddID = p_oDataRow.Item("ToAddID")
            ToLocID = p_oDataRow.Item("ToLocID")
            ToLocName = p_oDataRow.Item("ToLocName")
            ToAdd1 = p_oDataRow.Item("ToAdd1")
            ToAdd2 = p_oDataRow.Item("ToAdd2")
            ToCity = p_oDataRow.Item("ToCity")
            ToState = p_oDataRow.Item("ToState")
            ToZip = p_oDataRow.Item("ToZip")
            ToContact = p_oDataRow.Item("ToContact")
            ToPHone = p_oDataRow.Item("ToPhone")
            ToEMail = p_oDataRow.Item("ToEMail")
            Remarks = p_oDataRow.Item("Remarks")
            LabelRowID = p_oDataRow.Item("LabelRowID")

            Return True

        Catch ex As Exception

            SetError(ex.Message)
            Return False

        End Try

    End Function

    Sub New()

        ' Initialzie the Table Name Members
        m_sTablePath = ""
        m_sTableName = "CourierLabels"

        ' Initialize the VarChar Members
        m_vcTrackingNum = New VarChar(17)
        m_vcParcelType = New VarChar(20)
        m_vcEmployeeID = New VarChar(10)
        m_vcFromCustID = New VarChar(10)
        m_vcFromCustName = New VarChar(70)
        m_vcFromLocID = New VarChar(10)
        m_vcFromLocName = New VarChar(70)
        m_vcFromAdd1 = New VarChar(40)
        m_vcFromAdd2 = New VarChar(30)
        m_vcFromCity = New VarChar(50)
        m_vcFromState = New VarChar(2)
        m_vcFromZip = New VarChar(10)
        m_vcFromContact = New VarChar(40)
        m_vcFromPhone = New VarChar(20)
        m_vcFromEMail = New VarChar(60)
        m_vcToCustID = New VarChar(10)
        m_vcToCustName = New VarChar(70)
        m_vcToLocID = New VarChar(10)
        m_vcToLocName = New VarChar(70)
        m_vcToAdd1 = New VarChar(40)
        m_vcToAdd2 = New VarChar(30)
        m_vcToCity = New VarChar(50)
        m_vcToState = New VarChar(2)
        m_vcToZip = New VarChar(10)
        m_vcToContact = New VarChar(40)
        m_vcToPhone = New VarChar(20)
        m_vcToEMail = New VarChar(60)
        m_vcRemarks = New VarChar(255)


    End Sub

    Sub New(ByVal p_sTablePath As String)

        ' Initialzie the Table Name Members
        m_sTablePath = p_sTablePath
        m_sTableName = "CourierLabels"

        ' Initialize the VarChar Members
        m_vcTrackingNum = New VarChar(17)
        m_vcParcelType = New VarChar(20)
        m_vcEmployeeID = New VarChar(10)
        m_vcFromCustID = New VarChar(10)
        m_vcFromCustName = New VarChar(70)
        m_vcFromLocID = New VarChar(10)
        m_vcFromLocName = New VarChar(70)
        m_vcFromAdd1 = New VarChar(40)
        m_vcFromAdd2 = New VarChar(30)
        m_vcFromCity = New VarChar(50)
        m_vcFromState = New VarChar(2)
        m_vcFromZip = New VarChar(10)
        m_vcFromContact = New VarChar(40)
        m_vcFromPhone = New VarChar(20)
        m_vcFromEMail = New VarChar(60)
        m_vcToCustID = New VarChar(10)
        m_vcToCustName = New VarChar(70)
        m_vcToLocID = New VarChar(10)
        m_vcToLocName = New VarChar(70)
        m_vcToAdd1 = New VarChar(40)
        m_vcToAdd2 = New VarChar(30)
        m_vcToCity = New VarChar(50)
        m_vcToState = New VarChar(2)
        m_vcToZip = New VarChar(10)
        m_vcToContact = New VarChar(40)
        m_vcToPhone = New VarChar(20)
        m_vcToEMail = New VarChar(60)
        m_vcRemarks = New VarChar(255)


    End Sub


End Class
