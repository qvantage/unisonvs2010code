'**************************************************************************
'SF - 6/04/2010 - Collection Class that will add SID to the collection. 
'                 This will be used for Billing. Currently used to store the Status, Scope, Restart and Duration of the
'                 Service. This class will be used to determined if the service is Active or Not Active.
'**************************************************************************

Module RoutesVars

    Public ROUTESDBName As String '= "UN_ROUTES" '"UN_ROUTES"
    Public ROUTESDBUser As String = "Unison"
    Public ROUTESDBPass As String = "unison"
    Public ROUTESTblPath As String '= ROUTESDBName & ".dbo."

    'Declare the BillingCycle enumeration and define the values of its members
    Public Enum BillingCycles
        Weekly = 1
        Monthly = 2
        Daily = 3
        BiWeekly = 4
        ADVANCE = 5
    End Enum

    'Declare the SIDCondition enumeration and define the values of its members
    Public Enum SIDCondition
        Existing = 0 'Service started and has been regularly billed without interruption
        Restart = 1 'Service ended at some point and was restarted at a later point
        NewStart = 3 'Service has never been billed
        Closed = 4 'Service has ended and has been billed through its EndDate 'Ended
        FutureStart = 5 'Service is scheduled to start and or restart at some point in the future
        Fault = 6 'SID with nonsensical data 
    End Enum

    Public dtStartOfBillingPeriod As Date ' This variable will be set at the time an invoice is being generated and will come from user-input
    Public dtEndOfBillingPeriod As Date ' This variable will be set at the time an invoice is being generated and will come from user-input

    'BaseCharge Class 
    Class BaseCharge
        Private p_ChargeUnits As Long
        Private m_iChargeUnits As Integer
        Private m_strDescription As String
        Private m_decAmount As Decimal
        Private m_strModule As String
        Private m_eBillingCycle As BillingCycles

        'Public Property RowId() As Long
        '    Get
        '        Return p_ChargeUnits
        '    End Get
        '    Set(ByVal Value As Long)
        '        p_ChargeUnits = Value
        '    End Set
        'End Property

        'Public Sub New(ByVal p_iRowID As Long)
        '    RowId = p_iRowID
        'End Sub
        Public Property ChargeUnits() As Integer
            Get
                Return m_iChargeUnits
            End Get
            Set(ByVal Value As Integer)
                m_iChargeUnits = Value
            End Set
        End Property

        Public Sub New()
            m_strModule = "ROUTES"
            m_eBillingCycle = BillingCycles.Monthly
        End Sub

        Public Property Description() As String
            Get
                Return m_strDescription
            End Get
            Set(ByVal Value As String)
                m_strDescription = Value
            End Set
        End Property

        Public Property Amount() As Decimal
            Get
                Return m_decAmount
            End Get
            Set(ByVal Value As Decimal)
                m_decAmount = Value
            End Set
        End Property

        Public Property UnisonModule() As String
            Get
                Return m_strModule
            End Get
            Set(ByVal Value As String)
                m_strModule = Value
            End Set
        End Property

        Public Property BillingCycle() As BillingCycles
            Get
                Return m_eBillingCycle
            End Get
            Set(ByVal Value As BillingCycles)
                m_eBillingCycle = Value
            End Set
        End Property

    End Class 'END OF BaseCharge Class 

    'BaseChargeCollection Class
    Public Class BaseChargeCollection
        Inherits System.Collections.CollectionBase
        Private _RowIdHashtable As New Hashtable

        Public ReadOnly Property rowIdHashtable() As Hashtable
            Get
                Return _RowIdHashtable
            End Get
        End Property

        Public Sub Add(ByVal p_oBaseCharge As BaseCharge)
            Me.List.Add(p_oBaseCharge)
            _RowIdHashtable.Add(p_oBaseCharge.ChargeUnits, p_oBaseCharge)
        End Sub

        Public ReadOnly Property ItemIndex(ByVal p_ChargeUnits As Long) As Integer
            Get
                Dim i As Integer = 0
                Dim oBaseCharge As BaseCharge
                For Each oBaseCharge In Me
                    If oBaseCharge.ChargeUnits = p_ChargeUnits Then
                        Exit For
                    Else
                        i += 1
                    End If
                Next
                Return i
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal p_ChargeUnits As Long) As BaseCharge
            Get
                Return _RowIdHashtable.Item(p_ChargeUnits)
            End Get
        End Property

        Default Public Property Item(ByVal index As Integer) As BaseCharge
            Get
                Return Me.List.Item(index)
            End Get
            Set(ByVal value As BaseCharge)
                Me.List.Item(index) = value
            End Set
        End Property

        Public Sub Remove(ByVal p_oBaseCharge As BaseCharge)
            Me.List.Remove(p_oBaseCharge)
        End Sub
    End Class 'END OFBaseChargeCollection Class


    'SID Class
    Class SID
        Private _lRowId As Long
        Private boolStatus As Boolean   'True means SID is billable
        'Private boolScope As Boolean
        'Private boolRestart As Boolean
        Private eSIDCondition As SIDCondition
        Private m_Charges As BaseChargeCollection
        Private lDuration As Long
        Private dtStartofBilling As Date
        Private dtEndofBilling As Date
        Private lngAcctID As Long
        Private lngSID As Long
        Private dtStartDate As Date
        Private dtEndDate As Date
        Private dtLastBilledDate As Date

        Public Property RowId() As Long
            Get
                Return _lRowId
            End Get
            Set(ByVal Value As Long)
                _lRowId = Value
            End Set
        End Property

        Public Sub New(ByVal p_iRowID As Long)
            RowId = p_iRowID
            m_Charges = New BaseChargeCollection
        End Sub


        Public Property AcctId() As Long
            Get
                Return lngAcctID
            End Get
            Set(ByVal Value As Long)
                lngAcctID = Value
            End Set
        End Property

        Public Property SID() As Long
            Get
                Return lngSID
            End Get
            Set(ByVal Value As Long)
                lngSID = Value
            End Set
        End Property

        Public Property Status() As Boolean
            Get
                Return boolStatus
            End Get
            Set(ByVal Value As Boolean)
                boolStatus = Value
            End Set
        End Property

        'Public Property Scope() As Boolean
        '    Get
        '        Return boolScope
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        boolScope = Value
        '    End Set
        'End Property

        'Public Property Restart() As Boolean
        '    Get
        '        Return boolRestart
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        boolRestart = Value
        '    End Set
        'End Property

        Public Property condition() As SIDCondition
            Get
                Return eSIDCondition
            End Get
            Set(ByVal Value As SIDCondition)
                eSIDCondition = Value
            End Set
        End Property

        Public ReadOnly Property Charges() As BaseChargeCollection
            Get
                Return m_Charges
            End Get
        End Property

        Public Property Duration() As Long
            Get
                Return lDuration
            End Get
            Set(ByVal Value As Long)
                lDuration = Value
            End Set
        End Property
        'TESTING For Billing Correctness - Temporary!? - Delete when not needed
        Public Property StartDate() As Date
            Get
                Return dtStartDate
            End Get
            Set(ByVal Value As Date)
                dtStartDate = Value
            End Set
        End Property

        Public Property EndDate() As Date
            Get
                Return dtEndDate
            End Get
            Set(ByVal Value As Date)
                dtEndDate = Value
            End Set
        End Property

        Public Property LastBilledDate() As Date
            Get
                Return dtLastBilledDate
            End Get
            Set(ByVal Value As Date)
                dtLastBilledDate = Value
            End Set
        End Property

    End Class 'END of SID Class

    'SIDCollection Class
    Public Class SIDCollection
        Inherits System.Collections.CollectionBase
        Private _RowIdHashtable As New Hashtable

        Public ReadOnly Property rowIdHashtable() As Hashtable
            Get
                Return _RowIdHashtable
            End Get
        End Property

        Public Sub Add(ByVal p_oSID As SID)
            Me.List.Add(p_oSID)
            _RowIdHashtable.Add(p_oSID.RowId, p_oSID)
        End Sub

        Public ReadOnly Property ItemIndex(ByVal p_lRowId As Long) As Integer
            Get
                Dim i As Integer = 0
                Dim oSID As SID
                For Each oSID In Me
                    If oSID.RowId = p_lRowId Then
                        Exit For
                    Else
                        i += 1
                    End If
                Next
                Return i
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal p_lRowId As Long) As SID
            Get
                Return _RowIdHashtable.Item(p_lRowId)
            End Get
        End Property

        Default Public Property Item(ByVal index As Integer) As SID
            Get
                Return Me.List.Item(index)
            End Get
            Set(ByVal value As SID)
                Me.List.Item(index) = value
            End Set
        End Property

        Public Sub Remove(ByVal p_oSID As SID)
            Me.List.Remove(p_oSID)
        End Sub

    End Class 'END OFSIDCollection Class

    Public Function TestSID()
        Dim i As Integer
        Dim lRowID As Long = 93
        Dim oSIDIn As SID
        Dim oSIDCollection As New SIDCollection

        ' Add SIDs
        For i = 0 To 10
            oSIDIn = New SID(lRowID)
            oSIDCollection.Add(oSIDIn)
            lRowID += 10
        Next

        ' Iterate Through Our SID Collection
        For Each oSIDOut As SID In oSIDCollection
            MessageBox.Show("RowId for SID = " & oSIDOut.RowId.ToString)
        Next

        ' Identify a SID at a specific Index
        Dim x As Integer = 5

        MessageBox.Show("The SID at Index 5 has a RowID of " & oSIDCollection.Item(x).RowId)

        ' Count the SIDs in the Collection
        MessageBox.Show("There are a total of " & oSIDCollection.Count & " in the collection")

        ' Test Removal of a SID
        oSIDCollection.Remove(oSIDCollection.Item(93L))
        MessageBox.Show("There are now a total of " & oSIDCollection.Count & " in the collection")

        ' Confirm that the correct SID was removed by iterating through the collection again
        For Each oSIDOut As SID In oSIDCollection
            MessageBox.Show("RowId for SID = " & oSIDOut.RowId.ToString)
        Next


    End Function

    ''Public Function GetServiceIdBillingStatus(ByVal dtRow As DataRow, ByRef p_clsSID As SID, _
    ''                                            ByVal dtBillingDate As Date, ByVal dtASBDate As Date, _
    ''                                            ByVal dtAEBDDate As Date) As Boolean
    'Public Function GetServiceIdBillingStatus(ByVal dtRow As DataRow, ByRef p_clsSID As SID, ByVal dtBCD As Date, _
    '                                                ByVal dtSIDLBD As Date, ByVal dtASBDate As Date) As Boolean

    '    '**************************************************************************
    '    'SF - 5/24/2010 - This function will return true (Active) if the SID has never been billed, Stardate is greater 
    '    '                 than Billing date, Billing date (plus 1 to the date) is less than Account Billing Period date, 
    '    '                 or Billing Date is empty.  Otherwise the function will return false. Also, if the duration is
    '    '                 greather than zero, then function will reutrn false.
    '    '                 This function stores/sets the SID Status, Scope, Retstart and Duruation to the class.
    '    'SF - 6/1/2010  - Fixed a bug when StartDate is null
    '    '**************************************************************************

    '    'Dim dtBillingDate As Date
    '    'Dim dtAEBDDate As Date
    '    'Dim dtASBDate As Date

    '    Try

    '        'dtBillingDate = "09/02/2010" '"09/02/1967"
    '        'dtAEBDDate = "01/01/2010"
    '        'dtASBDate = "12/31/2011" '"12/31/2010"

    '        'Variables
    '        ''BCD - Billing Closing Date - Billing Closing Date that comes from the user's input 
    '        ''if account is closed we should use the Account Closing Date but for right now we don't have
    '        ''this column in UNISON.dbo.CUSTOMER we have just Status (boolean)
    '        ''' BCD = dtBCD

    '        ''SIDSD - Service ID Start Date - from UN_ROUTES.dbo.AccountServices --> StartDate
    '        ''' SIDSD => dtRow("StartDate")

    '        ''SIDED - Service ID End Date - from UN_ROUTES.dbo.AccountServices --> EndDate
    '        ''' SIDED => dtRow("EndDate")

    '        ''SIDLBD - Service ID Last Billed Date - from UN_ROUTES.dbo.AccountServices --> Last Bill Date
    '        ''' SIDED => dtRow("Last Bill Date")
    '        ''''' Temporary we selecting date manually this value on BillingTest.vb form because almost all accounts have "NULL" value in "Last Bill Date" column
    '        ''''' SIDED => dtSIDLBD

    '        ''ASBD - Account Start of Billing Period - from UNISON.dbo.CUSTOMER --> CREATEDATE
    '        ''''' Temporary we selecting date manually this value on BillingTest.vb form because a lot of accounts have "NULL" value in "CREATEDATE" column
    '        ''''' ASBD => dtASBDate

    '        ''AEBD - Account End of Billing Period - from UNISON.dbo.CUSTOMER --> LASTBillDate
    '        ''''' Temporary we selecting date manually this value on BillingTest.vb form because almost all accounts have "NULL" value in "LASTBillDate" column
    '        ''''' AEBD => dtAEBDDate

    '        ''Duration - Period of Time Account need to be billed for Service ID
    '        ''' Duration => p_clsSID.Duration

    '        p_clsSID.AcctId = dtRow("AccountID")
    '        p_clsSID.SID = dtRow("ID")

    '        'TESTING For Billing Correctness - Temporary!? - Delete when not needed
    '        If dtRow("StartDate") Is DBNull.Value Then
    '        Else
    '            p_clsSID.StartDate = dtRow("StartDate")
    '        End If
    '        If dtRow("EndDate") Is DBNull.Value Then
    '        Else
    '            p_clsSID.EndDate = dtRow("EndDate")
    '        End If
    '        If dtRow("Last Bill Date") Is DBNull.Value Then
    '        Else
    '            p_clsSID.LastBilledDate = dtRow("Last Bill Date")
    '        End If

    '        If dtRow("EndDate") Is DBNull.Value Then
    '            '1.Yes~CONDITION STEP - Is SIDED (Service ID End Date) Empty? --> YES
    '            '6~PROCESS STEP
    '            ''~Status: Active
    '            ''~Scope: Open
    '            p_clsSID.Status = True
    '            p_clsSID.Scope = True

    '            If dtSIDLBD.ToShortDateString = NullDate Then
    '                '2.Yes~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> YES
    '                '7~PROCESS STEP
    '                ''~Status: Active
    '                ''~Scope: Open
    '                ''~Restart: No
    '                p_clsSID.Status = True
    '                p_clsSID.Scope = True
    '                p_clsSID.Restart = False

    '                dtStartOfBillingPeriod = dtRow("StartDate")

    '                ''7~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                'p_clsSID.Duration = DateDiff(DateInterval.Day, dtAEBDDate, dtRow("StartDate"))
    '                '7~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                'p_clsSID.Duration = DateDiff(DateInterval.Day, dtBCD, dtRow("StartDate"))
    '                p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '            Else
    '                '2.No~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> NO
    '                Dim dtSIDLBDplusOne As Date
    '                dtSIDLBDplusOne = dtSIDLBD.AddDays(1)
    '                'If dtSIDLBD < dtASBDate Then
    '                If dtSIDLBDplusOne < dtASBDate Then
    '                    '3.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> YES
    '                    If dtRow("StartDate") > dtSIDLBD Then
    '                        '4.Yes~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> YES
    '                        '9~PROCESS STEP
    '                        ''~Status: Active
    '                        ''~Scope: Open
    '                        ''~Restart: Yes (Int)
    '                        p_clsSID.Status = True
    '                        p_clsSID.Scope = True
    '                        'p_clsSID.Restart = False
    '                        p_clsSID.Restart = True

    '                        dtStartOfBillingPeriod = dtRow("StartDate")

    '                        ''9~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                        'p_clsSID.Duration = DateDiff(DateInterval.Day, dtAEBDDate, dtRow("StartDate"))
    '                        '9~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                        'p_clsSID.Duration = DateDiff(DateInterval.Day, dtBCD, dtRow("StartDate"))
    '                        p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                        dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                    Else
    '                        '4.No~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> NO
    '                        '10~PROCESS STEP
    '                        ''~Status: Active
    '                        ''~Scope: Open
    '                        ''~Restart: Yes (Err)
    '                        p_clsSID.Status = True
    '                        p_clsSID.Scope = True
    '                        'p_clsSID.Restart = False
    '                        p_clsSID.Restart = True

    '                        dtStartOfBillingPeriod = dtSIDLBD.AddDays(1)

    '                        ''10~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                        'p_clsSID.Duration = DateDiff(DateInterval.Day, dtAEBDDate, dtSIDLBD)
    '                        '10~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                        'p_clsSID.Duration = DateDiff(DateInterval.Day, dtBCD, dtSIDLBD)
    '                        'p_clsSID.Duration = DateDiff(DateInterval.Day, dtBCD, dtSIDLBD)
    '                        p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                        dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                    End If
    '                    '4~CONDITION STEP - END
    '                Else
    '                    '3.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> NO
    '                    If dtSIDLBDplusOne = dtASBDate Then
    '                        '30.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> YES
    '                        '29~PROCESS STEP
    '                        ''~Status: Active
    '                        ''~Scope: Closed
    '                        ''~Restart: No
    '                        p_clsSID.Status = True
    '                        p_clsSID.Scope = True
    '                        p_clsSID.Restart = False

    '                        dtStartOfBillingPeriod = dtASBDate

    '                        '29~PROCESS STEP - "AEBD (Account End of Billing Period) - ASBD (Account Start Billing Date)"
    '                        p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                        dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                    Else
    '                        '30.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> NO
    '                        '8~PROCESS STEP
    '                        ''~Status: Active
    '                        ''~Scope: Closed
    '                        ''~Restart: No
    '                        p_clsSID.Status = True
    '                        p_clsSID.Scope = True
    '                        p_clsSID.Restart = False

    '                        dtStartOfBillingPeriod = dtSIDLBD.AddDays(1)

    '                        '8~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                        p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                        dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                    End If
    '                    '30~CONDITION STEP - END
    '                End If
    '                '3~CONDITION STEP - END
    '            End If
    '            '2~CONDITION STEP - END
    '        Else
    '            '1.No~CONDITION STEP - Is SIDED (Service ID End Date) Empty? --> NO
    '            '26~PROCESS STEP
    '            ''~Status: Active
    '            ''~Scope: Closed
    '            p_clsSID.Status = True
    '            p_clsSID.Scope = False

    '            'p_clsSID.Status = True
    '            'p_clsSID.Scope = False
    '            'If dtSIDLBD.ToShortDateString = NullDate Then
    '            '    If dtRow("StartDate") > dtAEBDDate Then
    '            '        p_clsSID.Status = False
    '            '    Else
    '            '        p_clsSID.Status = True
    '            '        p_clsSID.Scope = False
    '            '        p_clsSID.Restart = False
    '            '        dtStartOfBillingPeriod = dtRow("StartDate")
    '            '        p_clsSID.Duration = DateDiff(DateInterval.Day, dtAEBDDate, dtRow("StartDate"))
    '            '    End If
    '            'Else
    '            '    If dtSIDLBD >= dtASBDate Then
    '            '        'If dtSIDLBD < dtasbdate Then
    '            '        If dtRow("EndDate") < dtAEBDDate Then
    '            '            dtAEBDDate = dtRow("EndDate")
    '            '        End If
    '            '        p_clsSID.Status = True
    '            '        p_clsSID.Scope = False
    '            '        p_clsSID.Restart = False
    '            '        dtStartOfBillingPeriod = dtASBDate
    '            '        p_clsSID.Duration = DateDiff(DateInterval.Day, dtASBDate, dtAEBDDate)
    '            '    Else
    '            '        p_clsSID.Status = True
    '            '        p_clsSID.Scope = False
    '            '        p_clsSID.Restart = False
    '            '        dtStartOfBillingPeriod = dtSIDLBD
    '            '        p_clsSID.Duration = DateDiff(DateInterval.Day, dtSIDLBD, dtRow("Enddate"))
    '            '    End If
    '            'End If

    '            If dtRow("StartDate") > dtBCD Then
    '                '12-Yes~CONDITION STEP - Is "SIDSD (Service ID Start Date) > AEBD (Account End of Billing Period)"? --> YES
    '                '24~PROCESS STEP
    '                ''~Status: Inactive
    '                p_clsSID.Status = False
    '            Else
    '                '12-No~CONDITION STEP - Is "SIDSD (Service ID Start Date) > AEBD (Account End of Billing Period)"? --> NO
    '                If dtRow("EndDate") <= dtSIDLBD Then
    '                    'dtSIDLBD.ToShortDateString = NullDate
    '                    '13-Yes~CONDITION STEP - Is "SIDED (Service ID End Date) <= SIDLBD (Service ID Last Billed Date)"? --> YES
    '                    '24~PROCESS STEP
    '                    ''~Status: Inactive
    '                    p_clsSID.Status = False
    '                Else
    '                    '13-No~CONDITION STEP - Is "SIDED (Service ID End Date) <= SIDLBD (Service ID Last Billed Date)"? --> NO
    '                    '14~PROCESS STEP
    '                    ''~Status: Active
    '                    ''~Scope: Closed
    '                    p_clsSID.Status = True
    '                    p_clsSID.Scope = False

    '                    If dtRow("EndDate") < dtBCD Then
    '                        '15-Yes~CONDITION STEP - Is "SIDED (Service ID End Date) < AEBD (Account End of Billing Period)"? --> YES
    '                        '16~PROCESS STEP - AEBD (Account End of Billing Period) = SIDED (Service ID End Date)
    '                        'dtAEBDDate = dtRow("EndDate")
    '                        dtBCD = dtRow("EndDate")
    '                        If dtSIDLBD.ToShortDateString = NullDate Then
    '                            '17.Yes~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> YES
    '                            '19~PROCESS STEP
    '                            ''~Status: Active
    '                            ''~Scope: Closed
    '                            ''~Restart: No
    '                            p_clsSID.Status = True
    '                            p_clsSID.Scope = False
    '                            p_clsSID.Restart = False

    '                            dtStartOfBillingPeriod = dtRow("StartDate")

    '                            ''19~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                            'p_clsSID.Duration = DateDiff(DateInterval.Day, dtAEBDDate, dtRow("StartDate"))
    '                            '19~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                            'p_clsSID.Duration = DateDiff(DateInterval.Day, dtBCD, dtRow("StartDate"))
    '                            p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                            dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                        Else
    '                            '17.No~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> NO
    '                            Dim dtSIDLBDplusOne As Date = dtSIDLBD.AddDays(1)
    '                            If dtSIDLBDplusOne < dtASBDate Then
    '                                '18.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> YES
    '                                If dtRow("StartDate") > dtSIDLBD Then
    '                                    '21.Yes~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> YES
    '                                    '22~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: Yes (Int)
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = False
    '                                    'p_clsSID.Restart = False
    '                                    p_clsSID.Restart = True

    '                                    dtStartOfBillingPeriod = dtRow("StartDate")


    '                                    ''22~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                                    'p_clsSID.Duration = DateDiff(DateInterval.Day, dtAEBDDate, dtRow("StartDate"))
    '                                    '22~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                                    'p_clsSID.Duration = DateDiff(DateInterval.Day, dtBCD, dtRow("StartDate"))
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                Else
    '                                    '21.No~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> NO
    '                                    '23~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: Yes (Err)
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    'p_clsSID.Restart = False
    '                                    p_clsSID.Restart = True

    '                                    dtStartOfBillingPeriod = dtSIDLBD

    '                                    ''23~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                                    'p_clsSID.Duration = DateDiff(DateInterval.Day, dtAEBDDate, dtSIDLBD)
    '                                    '23~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                                    'p_clsSID.Duration = DateDiff(DateInterval.Day, dtBCD, dtSIDLBD)
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                End If
    '                                '21~CONDITION STEP - END
    '                            Else
    '                                '18.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> NO
    '                                If dtSIDLBDplusOne = dtASBDate Then
    '                                    '28.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> YES
    '                                    '27~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: No
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    p_clsSID.Restart = False

    '                                    dtStartOfBillingPeriod = dtASBDate

    '                                    '27~PROCESS STEP - "AEBD (Account End of Billing Period) - ASBD (Account Start Billing Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                Else
    '                                    '28.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> NO
    '                                    '20~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: No
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    p_clsSID.Restart = False

    '                                    dtStartOfBillingPeriod = dtSIDLBD.AddDays(1)

    '                                    '20~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                End If
    '                                '28~CONDITION STEP - END
    '                            End If
    '                            '18~CONDITION STEP - END
    '                        End If
    '                        '17~CONDITION STEP - END
    '                    Else
    '                        '15-No~CONDITION STEP - Is "SIDED (Service ID End Date) < AEBD (Account End of Billing Period)"? --> NO
    '                        If dtSIDLBD.ToShortDateString = NullDate Then
    '                            '17.Yes~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> YES
    '                            '19~PROCESS STEP
    '                            ''~Status: Active
    '                            ''~Scope: Closed
    '                            ''~Restart: No
    '                            p_clsSID.Status = True
    '                            p_clsSID.Scope = False
    '                            p_clsSID.Restart = False

    '                            dtStartOfBillingPeriod = dtRow("StartDate")

    '                            ''19~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                            'p_clsSID.Duration = DateDiff(DateInterval.Day, dtAEBDDate, dtRow("StartDate"))
    '                            '19~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                            'p_clsSID.Duration = DateDiff(DateInterval.Day, dtBCD, dtRow("StartDate"))
    '                            p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                            dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                        Else
    '                            '17.No~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> NO
    '                            Dim dtSIDLBDplusOne As Date = dtSIDLBD.AddDays(1)
    '                            If dtSIDLBDplusOne < dtASBDate Then
    '                                '18.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> YES
    '                                If dtRow("StartDate") > dtSIDLBD Then
    '                                    '21.Yes~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> YES
    '                                    '22~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: Yes (Int)
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    'p_clsSID.Restart = False
    '                                    p_clsSID.Restart = True

    '                                    dtStartOfBillingPeriod = dtRow("StartDate")

    '                                    ''22~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                                    'p_clsSID.Duration = DateDiff(DateInterval.Day, dtAEBDDate, dtRow("StartDate"))
    '                                    '22~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                                    'p_clsSID.Duration = DateDiff(DateInterval.Day, dtBCD, dtRow("StartDate"))
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                Else
    '                                    '21.No~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> NO
    '                                    '23~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: Yes (Err)
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    'p_clsSID.Restart = False
    '                                    p_clsSID.Restart = True

    '                                    dtStartOfBillingPeriod = dtSIDLBD.AddDays(1)

    '                                    ''23~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                                    'p_clsSID.Duration = DateDiff(DateInterval.Day, dtAEBDDate, dtSIDLBD)
    '                                    '23~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                                    'p_clsSID.Duration = DateDiff(DateInterval.Day, dtBCD, dtSIDLBD)
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                End If
    '                                '21~CONDITION STEP - END
    '                            Else
    '                                '18.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> NO
    '                                If dtSIDLBDplusOne = dtASBDate Then
    '                                    '28.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> YES
    '                                    '27~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: No
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    p_clsSID.Restart = False

    '                                    dtStartOfBillingPeriod = dtASBDate

    '                                    '27~PROCESS STEP - "AEBD (Account End of Billing Period) - ASBD (Account Start Billing Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                Else
    '                                    '28.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> NO
    '                                    '20~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: No
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    p_clsSID.Restart = False

    '                                    dtStartOfBillingPeriod = dtSIDLBD

    '                                    '20~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, dtBCD)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                End If
    '                                '28~CONDITION STEP - END
    '                            End If
    '                            '18~CONDITION STEP - END
    '                        End If
    '                        '17~CONDITION STEP - END
    '                    End If
    '                    '15~CONDITION STEP - END
    '                End If
    '                '13~CONDITION STEP - END
    '            End If
    '            '12~CONDITION STEP - END
    '        End If
    '        '1~CONDITION STEP - END

    '        If p_clsSID.Duration <= 0 Then
    '            '15.Yes~CONDITION STEP - Is Duration < 0? --> YES
    '            '20~PROCESS STEP
    '            ''~Status: Inactive
    '            ''~Scope: N/A
    '            ''~Restart: N/A
    '            ''~Duration: N/A
    '            p_clsSID.Status = False
    '            p_clsSID.Scope = vbNull
    '            p_clsSID.Restart = vbNull
    '            p_clsSID.Duration = vbNull
    '        End If

    '        Return p_clsSID.Status

    '    Catch ex As Exception
    '        'MessageBox.Show("doh")
    '        If "" = "" Then

    '        End If
    '    Finally
    '        If "" = "" Then

    '        End If
    '    End Try



    'End Function

    'Public Function GetServiceIdBillingStatusZ(ByRef p_clsSID As SID, ByVal SIDSD As Date, ByVal SIDED As Date, ByVal SIDLBD As Date, ByVal SBP As Date, ByVal EBP As Date) As Boolean

    '    Try
    '        If SIDED.ToShortDateString = NullDate Then
    '            '1.Yes~CONDITION STEP - Is SIDED (Service ID End Date) Empty? --> YES
    '            '6~PROCESS STEP
    '            ''~Status: Active
    '            ''~Scope: Open
    '            p_clsSID.Status = True
    '            p_clsSID.Scope = True

    '            If SIDLBD.ToShortDateString = NullDate Then
    '                '2.Yes~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> YES
    '                '7~PROCESS STEP
    '                ''~Status: Active
    '                ''~Scope: Open
    '                ''~Restart: No
    '                p_clsSID.Status = True
    '                p_clsSID.Scope = True
    '                p_clsSID.Restart = False

    '                dtStartOfBillingPeriod = SIDSD

    '                '7~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '            Else
    '                '2.No~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> NO
    '                Dim dtSIDLBDplusOne As Date
    '                dtSIDLBDplusOne = SIDLBD.AddDays(1)
    '                If dtSIDLBDplusOne < SBP Then
    '                    '3.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> YES
    '                    If SIDSD > SIDLBD Then
    '                        '4.Yes~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> YES
    '                        '9~PROCESS STEP
    '                        ''~Status: Active
    '                        ''~Scope: Open
    '                        ''~Restart: Yes (Int)
    '                        p_clsSID.Status = True
    '                        p_clsSID.Scope = True
    '                        'p_clsSID.Restart = False
    '                        p_clsSID.Restart = True

    '                        dtStartOfBillingPeriod = SIDSD

    '                        '9~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                        p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                        dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                    Else
    '                        '4.No~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> NO
    '                        '10~PROCESS STEP
    '                        ''~Status: Active
    '                        ''~Scope: Open
    '                        ''~Restart: Yes (Err)
    '                        p_clsSID.Status = True
    '                        p_clsSID.Scope = True
    '                        'p_clsSID.Restart = False
    '                        p_clsSID.Restart = True

    '                        dtStartOfBillingPeriod = SIDLBD.AddDays(1)

    '                        '10~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                        p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                        dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                    End If
    '                    '4~CONDITION STEP - END
    '                Else
    '                    '3.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> NO
    '                    If dtSIDLBDplusOne = SBP Then
    '                        '30.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> YES
    '                        '29~PROCESS STEP
    '                        ''~Status: Active
    '                        ''~Scope: Closed
    '                        ''~Restart: No
    '                        p_clsSID.Status = True
    '                        p_clsSID.Scope = True
    '                        p_clsSID.Restart = False

    '                        dtStartOfBillingPeriod = SBP

    '                        '29~PROCESS STEP - "AEBD (Account End of Billing Period) - ASBD (Account Start Billing Date)"
    '                        p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                        dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                    Else
    '                        '30.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> NO
    '                        '8~PROCESS STEP
    '                        ''~Status: Active
    '                        ''~Scope: Closed
    '                        ''~Restart: No
    '                        p_clsSID.Status = True
    '                        p_clsSID.Scope = True
    '                        p_clsSID.Restart = False

    '                        dtStartOfBillingPeriod = SIDLBD.AddDays(1)

    '                        '8~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                        p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                        dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                    End If
    '                    '30~CONDITION STEP - END
    '                End If
    '                '3~CONDITION STEP - END
    '            End If
    '            '2~CONDITION STEP - END
    '        Else
    '            '1.No~CONDITION STEP - Is SIDED (Service ID End Date) Empty? --> NO
    '            '26~PROCESS STEP
    '            ''~Status: Active
    '            ''~Scope: Closed
    '            p_clsSID.Status = True
    '            p_clsSID.Scope = False

    '            If SIDSD > EBP Then
    '                '12-Yes~CONDITION STEP - Is "SIDSD (Service ID Start Date) > AEBD (Account End of Billing Period)"? --> YES
    '                '24~PROCESS STEP
    '                ''~Status: Inactive
    '                p_clsSID.Status = False
    '            Else
    '                '12-No~CONDITION STEP - Is "SIDSD (Service ID Start Date) > AEBD (Account End of Billing Period)"? --> NO
    '                If SIDED <= SIDLBD Then
    '                    '13-Yes~CONDITION STEP - Is "SIDED (Service ID End Date) <= SIDLBD (Service ID Last Billed Date)"? --> YES
    '                    '24~PROCESS STEP
    '                    ''~Status: Inactive
    '                    p_clsSID.Status = False
    '                Else
    '                    '13-No~CONDITION STEP - Is "SIDED (Service ID End Date) <= SIDLBD (Service ID Last Billed Date)"? --> NO
    '                    '14~PROCESS STEP
    '                    ''~Status: Active
    '                    ''~Scope: Closed
    '                    p_clsSID.Status = True
    '                    p_clsSID.Scope = False

    '                    If SIDED < EBP Then
    '                        '15-Yes~CONDITION STEP - Is "SIDED (Service ID End Date) < AEBD (Account End of Billing Period)"? --> YES
    '                        '16~PROCESS STEP - AEBD (Account End of Billing Period) = SIDED (Service ID End Date)
    '                        EBP = SIDED
    '                        If SIDLBD.ToShortDateString = NullDate Then
    '                            '17.Yes~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> YES
    '                            '19~PROCESS STEP
    '                            ''~Status: Active
    '                            ''~Scope: Closed
    '                            ''~Restart: No
    '                            p_clsSID.Status = True
    '                            p_clsSID.Scope = False
    '                            p_clsSID.Restart = False

    '                            dtStartOfBillingPeriod = SIDSD

    '                            '19~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                            p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                            dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                        Else
    '                            '17.No~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> NO
    '                            Dim dtSIDLBDplusOne As Date = SIDLBD.AddDays(1)
    '                            If dtSIDLBDplusOne < SBP Then
    '                                '18.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> YES
    '                                If SIDSD > SIDLBD Then
    '                                    '21.Yes~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> YES
    '                                    '22~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: Yes (Int)
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = False
    '                                    'p_clsSID.Restart = False
    '                                    p_clsSID.Restart = True

    '                                    dtStartOfBillingPeriod = SIDSD


    '                                    '22~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                Else
    '                                    '21.No~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> NO
    '                                    '23~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: Yes (Err)
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    'p_clsSID.Restart = False
    '                                    p_clsSID.Restart = True

    '                                    dtStartOfBillingPeriod = SIDLBD

    '                                    '23~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                End If
    '                                '21~CONDITION STEP - END
    '                            Else
    '                                '18.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> NO
    '                                If dtSIDLBDplusOne = SBP Then
    '                                    '28.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> YES
    '                                    '27~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: No
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    p_clsSID.Restart = False

    '                                    dtStartOfBillingPeriod = SBP

    '                                    '27~PROCESS STEP - "AEBD (Account End of Billing Period) - ASBD (Account Start Billing Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                Else
    '                                    '28.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> NO
    '                                    '20~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: No
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    p_clsSID.Restart = False

    '                                    dtStartOfBillingPeriod = SIDLBD.AddDays(1)

    '                                    '20~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                End If
    '                                '28~CONDITION STEP - END
    '                            End If
    '                            '18~CONDITION STEP - END
    '                        End If
    '                        '17~CONDITION STEP - END
    '                    Else
    '                        '15-No~CONDITION STEP - Is "SIDED (Service ID End Date) < AEBD (Account End of Billing Period)"? --> NO
    '                        If SIDLBD.ToShortDateString = NullDate Then
    '                            '17.Yes~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> YES
    '                            '19~PROCESS STEP
    '                            ''~Status: Active
    '                            ''~Scope: Closed
    '                            ''~Restart: No
    '                            p_clsSID.Status = True
    '                            p_clsSID.Scope = False
    '                            p_clsSID.Restart = False

    '                            dtStartOfBillingPeriod = SIDSD

    '                            '19~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                            p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                            dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                        Else
    '                            '17.No~CONDITION STEP - Is SIDLBD (Service ID Last Billed Date) --> NO
    '                            Dim dtSIDLBDplusOne As Date = SIDLBD.AddDays(1)
    '                            If dtSIDLBDplusOne < SBP Then
    '                                '18.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> YES
    '                                If SIDSD > SIDLBD Then
    '                                    '21.Yes~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> YES
    '                                    '22~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: Yes (Int)
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    'p_clsSID.Restart = False
    '                                    p_clsSID.Restart = True

    '                                    dtStartOfBillingPeriod = SIDSD

    '                                    '22~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDSD (Service ID Start Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                Else
    '                                    '21.No~CONDITION STEP - Is (SIDSD (Service ID Start Date) < SIDLBD (Service ID Last Billing Date))? --> NO
    '                                    '23~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: Yes (Err)
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    'p_clsSID.Restart = False
    '                                    p_clsSID.Restart = True

    '                                    dtStartOfBillingPeriod = SIDLBD.AddDays(1)

    '                                    '23~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                End If
    '                                '21~CONDITION STEP - END
    '                            Else
    '                                '18.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) < ASBD (Account Start Billing Date))? --> NO
    '                                If dtSIDLBDplusOne = SBP Then
    '                                    '28.Yes~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> YES
    '                                    '27~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: No
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    p_clsSID.Restart = False

    '                                    dtStartOfBillingPeriod = SBP

    '                                    '27~PROCESS STEP - "AEBD (Account End of Billing Period) - ASBD (Account Start Billing Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                Else
    '                                    '28.No~CONDITION STEP - Is (SIDLBD (Service ID Last Billing Date) + 1) = ASBD (Account Start Billing Date))? --> NO
    '                                    '20~PROCESS STEP
    '                                    ''~Status: Active
    '                                    ''~Scope: Closed
    '                                    ''~Restart: No
    '                                    p_clsSID.Status = True
    '                                    p_clsSID.Scope = True
    '                                    p_clsSID.Restart = False

    '                                    dtStartOfBillingPeriod = SIDLBD

    '                                    '20~PROCESS STEP - "AEBD (Account End of Billing Period) - SIDLBD (Service ID Last Billing Date)"
    '                                    p_clsSID.Duration = DateDiff(DateInterval.Day, dtStartOfBillingPeriod, EBP)
    '                                    dtEndOfBillingPeriod = dtStartOfBillingPeriod.AddDays(p_clsSID.Duration)
    '                                End If
    '                                '28~CONDITION STEP - END
    '                            End If
    '                            '18~CONDITION STEP - END
    '                        End If
    '                        '17~CONDITION STEP - END
    '                    End If
    '                    '15~CONDITION STEP - END
    '                End If
    '                '13~CONDITION STEP - END
    '            End If
    '            '12~CONDITION STEP - END
    '        End If
    '        '1~CONDITION STEP - END

    '        If p_clsSID.Duration <= 0 Then
    '            '15.Yes~CONDITION STEP - Is Duration < 0? --> YES
    '            '20~PROCESS STEP
    '            ''~Status: Inactive
    '            ''~Scope: N/A
    '            ''~Restart: N/A
    '            ''~Duration: N/A
    '            p_clsSID.Status = False
    '            p_clsSID.Scope = vbNull
    '            p_clsSID.Restart = vbNull
    '            p_clsSID.Duration = vbNull
    '        End If

    '        Return p_clsSID.Status

    '    Catch ex As Exception
    '        'MessageBox.Show("doh")
    '        If "" = "" Then

    '        End If
    '    Finally
    '        If "" = "" Then

    '        End If
    '    End Try
    'End Function

    '''<summary>
    ''' This function will quickly determine whether or not an SID is billable based on the SID's "Start Date" and/or 
    ''' "End Date" and/or "Last Bill Date" and the start and end dates of the billing period for which the SID is being examined.
    '''</summary>
    '''<returns>
    ''' The function will return TRUE if the SID is billable or FALSE if it is not.
    ''' </returns>
    '''<remarks>
    ''' The logic employed in this function assumes that the tests are conducted in a specific order.  This is critical since certain
    ''' things may be assumed based on exclusion.  Although certain other information about the SID can be deduced about the SID, such as
    ''' whether or not it is a Restart, we refrain from doing so within this function because that additional information cannot always be
    ''' known and we do not want to detract from the functions stated purpose which is simply to classify an SID as billable or not.
    '''</remarks>
    Public Function SIDIsBillable(ByRef p_clsSID As SID, ByVal p_dtStartOfBillingPeriod As Date, ByVal p_dtEndOfBillingPeriod As Date) As Boolean
        Dim bReturnValue As Boolean
        Try
            If p_clsSID.StartDate = NullDate Or (p_clsSID.StartDate > p_clsSID.EndDate And p_clsSID.EndDate <> NullDate) Or (p_clsSID.LastBilledDate > p_clsSID.EndDate And p_clsSID.EndDate <> NullDate) Then
                'Check if SID has nonsensical data: StartDate=blank, StartDate>EndDate, LastBilledDate>EndDate
                p_clsSID.Status = False 'SID is not Billable
                p_clsSID.condition = SIDCondition.Fault 'SID has nonsensical data 
            Else
                'Does this SID start some time after the end of the billing period which is being considered? i.e. Future Service.
                If p_dtEndOfBillingPeriod >= p_clsSID.StartDate Then
                    'Has this SID ended and been billed through its end date? i.e. Closed and Properly Billed.
                    'IMPORTANT NOTE:    When generating a bill for an SID that ends on or before the End of Billing,
                    '                   we must set the SID's Last Billed Date to the SID's End Date.
                    If p_clsSID.EndDate = p_clsSID.LastBilledDate And p_clsSID.EndDate.ToShortDateString <> NullDate And p_clsSID.LastBilledDate.ToShortDateString <> NullDate Then
                        p_clsSID.Status = False
                        p_clsSID.condition = SIDCondition.Closed
                    Else
                        'Is the service represented by this SID expected to continue forever?
                        If p_clsSID.EndDate.ToShortDateString = NullDate Then ' in VB NullDate is equivalent to NULL
                            'p_clsSID.condition = SIDCondition.Existing
                            p_clsSID.Status = True
                        Else
                            'Does this SID ends some time before or in a same day when billing period ends?
                            If p_clsSID.EndDate >= dtEndOfBillingPeriod Then
                                'p_clsSID.condition = SIDCondition.Existing
                                p_clsSID.Status = True
                            Else
                                'Is the service represented by this SID was never billed before?
                                If p_clsSID.LastBilledDate.ToShortDateString = NullDate Then
                                    'p_clsSID.condition = SIDCondition.NewStart
                                    p_clsSID.Status = True
                                Else
                                    'Is the SID starts some time after it was billed last time?
                                    If p_clsSID.StartDate > p_clsSID.LastBilledDate Then
                                        'p_clsSID.condition = SIDCondition.NewStart
                                        p_clsSID.Status = True
                                    Else
                                        'Is the SID ends some time before or in a same day when billing period starts?
                                        'If p_clsSID.EndDate >= dtStartOfBillingPeriod Then
                                        'Is the SID ended some time before the date when SID was billed last time?
                                        If p_clsSID.EndDate > p_clsSID.LastBilledDate Then
                                            'p_clsSID.condition = SIDCondition.Existing
                                            p_clsSID.Status = True
                                        Else
                                            p_clsSID.Status = False 'If gets to here, it is not billable
                                            p_clsSID.condition = SIDCondition.Fault
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else
                    p_clsSID.Status = False
                    p_clsSID.condition = SIDCondition.FutureStart
                End If
            End If
            bReturnValue = p_clsSID.Status
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            bReturnValue = False
        Finally
            ' No cleanup would be needed if an Exception occurs
        End Try
        Return bReturnValue
    End Function

    Public Sub SetSIDCondition(ByRef p_clsSID As SID, ByVal p_dtStartOfBillingPeriod As Date, ByVal p_dtEndOfBillingPeriod As Date)
        If p_clsSID.Status = True Then
            If p_clsSID.LastBilledDate = NullDate Then
                p_clsSID.condition = SIDCondition.NewStart
            Else
                If (p_clsSID.StartDate > p_clsSID.LastBilledDate) Then 'And (p_clsSID.LastBilledDate < p_dtStartOfBillingPeriod.AddDays(-1)) Then
                    p_clsSID.condition = SIDCondition.Restart
                ElseIf (p_clsSID.StartDate <= p_clsSID.LastBilledDate) Or ((p_dtStartOfBillingPeriod < p_clsSID.LastBilledDate) And (p_clsSID.LastBilledDate < p_dtEndOfBillingPeriod)) Then
                    p_clsSID.condition = SIDCondition.Existing
                End If
            End If
        End If
    End Sub

    Public Sub SetSIDBillingWindow(ByRef p_clsSID As SID, ByVal p_dtEndOfBillingPeriod As Date)
        If p_clsSID.condition = SIDCondition.NewStart Or p_clsSID.condition = SIDCondition.Restart Then
            If p_clsSID.StartDate <> p_clsSID.EndDate Then
                If p_clsSID.EndDate = NullDate Or p_clsSID.EndDate >= p_dtEndOfBillingPeriod Then
                    p_clsSID.EndDate = p_dtEndOfBillingPeriod
                ElseIf p_clsSID.EndDate <> NullDate And p_clsSID.EndDate < p_dtEndOfBillingPeriod Then
                    p_clsSID.EndDate = p_clsSID.EndDate
                End If
            Else
                p_clsSID.Status = False
            End If
        End If

            If p_clsSID.condition = SIDCondition.Existing Then
                If (p_clsSID.StartDate = p_clsSID.EndDate) And (p_clsSID.EndDate <> NullDate) Then
                    p_clsSID.Status = False
                Else
                    p_clsSID.StartDate = p_clsSID.LastBilledDate.AddDays(1)
                    If (p_clsSID.EndDate = NullDate) Then
                        p_clsSID.EndDate = p_dtEndOfBillingPeriod
                    Else
                        If (p_dtEndOfBillingPeriod < p_clsSID.EndDate) Then
                            p_clsSID.EndDate = p_dtEndOfBillingPeriod
                        End If
                End If
                If p_clsSID.EndDate = p_clsSID.StartDate Then
                Else
                    p_clsSID.Duration = DateDiff(DateInterval.Day, p_clsSID.StartDate, p_clsSID.EndDate)
                    If (p_clsSID.Duration <= 0) Then
                        p_clsSID.Status = False
                    End If
                End If
            End If
        End If
            'If p_clsSID.Status = True Then
            '    p_clsSID.Duration = DateDiff(DateInterval.Day, p_clsSID.StartDate, p_clsSID.EndDate)
            '    If (p_clsSID.Duration <= 0) And (p_clsSID.StartDate <> p_dtEndOfBillingPeriod) Then
            '        p_clsSID.Status = False
            '    End If
            'End If
    End Sub

    Public Sub CalculateSIDCharges(ByRef p_clsSID As SID, ByVal p_dtEndOfBillingPeriod As Date)
        Dim priorDays As Integer
        Dim afterDays As Integer
        Dim numberMonths As Integer
        Dim i As Integer
        Dim temp_StartDate As Date
        Dim numberServiceDays As Integer
        Dim numberWorkingDays As Integer
        Dim amount As Decimal
        Dim charge As BaseCharge
        Dim currentMonth, currentYear As Integer
        Dim chargeCounter As Integer = 1

        'charge = New BaseCharge
        'If (p_clsSID.StartDate < p_clsSID.LastBilledDate.AddDays(1)) Then
        'priorDays = p_clsSID.StartDate.DaysInMonth(p_clsSID.StartDate.Year, p_clsSID.StartDate.Month) - p_clsSID.StartDate.Day + 1
        priorDays = BILLING_YEAR.WorkingDaysInMonth(p_clsSID.StartDate.Month) - p_clsSID.StartDate.Day + 1

        afterDays = p_clsSID.EndDate.Day
        numberMonths = (p_clsSID.EndDate.Month - 1) - (p_clsSID.StartDate.Month + 1) + 1 + 12 * (p_clsSID.EndDate.Year - p_clsSID.StartDate.Year)
        i = numberMonths
        temp_StartDate = p_clsSID.StartDate
        currentMonth = p_clsSID.StartDate.Month
        currentYear = p_clsSID.StartDate.Year
        charge = New BaseCharge

        If (i = -1) Then
        Else
            While i >= 0
                If (i = numberMonths) Then
                    numberServiceDays = priorDays
                    'numberWorkingDays = temp_StartDate.DaysInMonth(temp_StartDate.Year, temp_StartDate.Month)
                    numberWorkingDays = BILLING_YEAR.WorkingDaysInMonth(temp_StartDate.Month)
                Else
                    numberServiceDays = 1
                    numberWorkingDays = 1
                End If
                charge.Amount = 100 * (numberServiceDays / numberWorkingDays)
                charge.Description = BILLING_YEAR.LongMonthName(currentMonth) + ", " + Convert.ToString(currentYear)
                charge.ChargeUnits = chargeCounter
                p_clsSID.Charges.Add(charge)

                If currentMonth = 12 Then
                    currentMonth = 0
                    currentYear = currentYear + 1
                End If
                currentMonth = currentMonth + 1
                i = i - 1
                chargeCounter = chargeCounter + 1
                charge = New BaseCharge
            End While

            Dim temp_StartDateUpdated As New Date(p_clsSID.EndDate.Year, p_clsSID.EndDate.Month, 1)
            temp_StartDate = temp_StartDateUpdated
        End If

        numberServiceDays = p_clsSID.EndDate.Day - temp_StartDate.Day + 1
        numberWorkingDays = BILLING_YEAR.WorkingDaysInMonth(temp_StartDate.Month)

        charge.Amount = 100 * (numberServiceDays / numberWorkingDays)
        charge.Description = BILLING_YEAR.LongMonthName(currentMonth) + ", " + Convert.ToString(currentYear)
        charge.ChargeUnits = chargeCounter
        'Else
        'charge.Amount = 0
        'charge.Description = "SID Billed Up To Date"
        'charge.ChargeUnits = 0
        'End If


        p_clsSID.Charges.Add(charge)

    End Sub
End Module
