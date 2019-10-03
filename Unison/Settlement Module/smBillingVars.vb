Module smBillingVars
    Public smBILLDBName As String '= "UN_SETTLEMENT"
    Public smBILLDBUser As String = "Unison"
    Public smBILLDBPass As String = "unison"
    Public smBILLTblPath As String '= BILLDBName & ".dbo."

    'Public EDIPath As String = "" '"C :\FTPHOME\Ingram"
    'Public IPIPath As String = "" '"C :\FTPHOME\Ingram\IPI"
    'Public ScanListPath As String = "" '"C :\FTPHOME\ScanLists"

    'Public BILLING_YEAR As New BillingYear

    'Public Enum eISA
    '    AutInfQu = 1 ' "00"
    '    AutInfM ' blank
    '    SecInfQu ' "00"
    '    SecInf 'Blank
    '    SNDQU = 5 ' "02"
    '    SENDR 'SCAC
    '    RCVQU ' "ZZ"
    '    RcvrID = 8
    '    IDate
    '    ITime
    '    StdID
    '    VerID
    '    CtlNo
    '    AckNo ' "0" = Not requested
    '    TestI ' "P" = Production "T" = Test
    '    SubEl ' ">"
    '    _END
    'End Enum

    'Public Enum eGS
    '    FuGrID = 1 'Import: "SM" Inv: "IM"
    '    SndrCd ' Inv: SCAC
    '    RcvCo = 3 ' Inv: INGRAM
    '    IDate
    '    ITime
    '    CtlNo ' Min = 1
    '    Agenc
    '    Ver ' 004030
    '    _END
    'End Enum

    'Public Enum eST
    '    SetID = 1 ' 204, 210, 240
    '    StCtl
    '    _END
    'End Enum

    'Public Enum eB2
    '    Alpha = 2
    '    MftNo = 4
    '    PayTp = 6  ' CC, PP, MX
    '    _END
    'End Enum

    'Public Enum eB2A
    '    AppTp = 2 ' Purpose is MF = Manifest
    '    _END
    'End Enum

    'Public Enum eB3 '  Beg Segment For Carrier's Invoice
    '    InvNo = 2
    '    ShpMth = 4 ' CC = Collect, PP = Prepaid, MX = Mixed
    '    InvDate = 6
    '    NetAmt = 7  ' Total Invoice Amount
    '    SCAC = 11 ' Carriers code
    '    DuDate = 12 ' Invoice Due Date
    '    _END
    'End Enum

    'Public Enum eL11
    '    RefID = 1
    '    RefQu ' MA, AAO Carrier Code, 2I, ACI Ticket, PO, FR, AC
    '    Desc 'AAO
    '    _END
    'End Enum

    'Public Enum eG62
    '    DQual = 1
    '    iDate ' PUDate
    '    _END
    'End Enum

    'Public Enum eN1
    '    EntID = 1 ' SH, CN Consignee, 
    '    Name
    '    IDQul
    '    IDCod ' Shipper No., Ship To AcctNo
    '    _END
    'End Enum

    'Public Enum eN3
    '    Add1 = 1
    '    Add2
    '    _END
    'End Enum

    'Public Enum eN4
    '    City = 1
    '    State
    '    Zip
    '    Country
    '    _END
    'End Enum

    'Public Enum eLX 'Invoice: Line No in Transaction
    '    LnItm = 1
    '    _END
    'End Enum

    'Public Enum eN9 'Invoice:
    '    RefIDQu = 1 '2I = TR#, MA = MFT NO, ACI= TCKT NO, PO = PURCH ORD NO
    '    RefID ' TR#, mft#, tckt#, po#
    '    PUDate = 4 ' for 2I : yyyymmdd
    '    PyRfQu = 7 ' = ZZ
    '    PyRfID     ' CC = Collect, PP = Prepaid
    '    _END
    'End Enum

    'Public Enum eL0 'Invoice:
    '    Wgt = 4
    '    WgtQu ' = B
    '    LdgQty = 8 ' = 1
    '    PkgCod = 9 ' = PKG
    '    WgtUnit = 11 ' = L pounds
    '    _END
    'End Enum

    'Public Enum eL1 'Invoice : Rates and Charges
    '    Chg = 4 'Amount
    '    ChgCode = 8 ' 400 = Freight Charge, dsc = discount, FUE = FUEL SUR, MSC = MISC
    '    ChgDesc = 12 ' Special Chg Desc
    '    _END
    'End Enum



    'Public Enum eS5
    '    StpSq = 1 '0
    '    StpRs '00
    '    _END
    'End Enum

    'Public Enum eAT8
    '    WQual = 1 'B
    '    WUnit 'L
    '    Wgt
    '    Qty
    '    _END
    'End Enum

    'Public Enum eLAD
    '    LdVal = 14 ' Declared Val
    '    _END
    'End Enum

    'Public Enum eG61
    '    Func = 1 'IC = Info Contact
    '    Name
    '    ComQu ' TE = TelNo
    '    TelNo
    '    _END
    'End Enum

    'Public Enum eL3 ' tOTALS : mANIFEST & iNVOICE 
    '    TWgt = 1 ' Total Weight
    '    WQual ' B
    '    Chg = 5   ' Tot Charge
    '    TQty = 11 'Total Qty
    '    WUnit     ' L = LB
    '    DcVal = 14 'Tot Declared Val
    '    ValQu      'SD = Shipper DecVal
    '    _END
    'End Enum

    'Public Enum eSE
    '    SegQt = 1 ' ST through SE
    '    SCtlN 'ST02 tRANS sET cTL#
    '    _END
    'End Enum

    'Public Enum eGE
    '    SetQt = 1 'No Of Sets
    '    GCtlN 'GS06 Group Ctl#
    '    _END
    'End Enum

    'Public Enum eIEA
    '    GrpQt = 1 'No of Groups
    '    ICtlN 'Grp Ctl# ISA13 value
    '    _END
    'End Enum

    'Public Class DLInfo204
    '    Public L112I(eL11._END - 1) As String
    '    Public L11ACI(eL11._END - 1) As String
    '    Public L11PO(eL11._END - 1) As String
    '    Public L11FR(eL11._END - 1) As String
    '    Public L11AC(eL11._END - 1) As String
    '    Public AT8(eAT8._END - 1) As String
    '    Public LAD(eLAD._END - 1) As String
    '    Public N1DL(eN1._END - 1) As String
    '    Public N3DL(eN3._END - 1) As String
    '    Public N4DL(eN4._END - 1) As String
    '    Public G61(eG61._END - 1) As String 'Contact
    'End Class


    'Public Class Set204
    '    Public ST(eST._END - 1) As String
    '    Public B2(eB2._END - 1) As String
    '    Public B2A(eB2A._END - 1) As String
    '    Public L11MA(eL11._END - 1) As String
    '    Public L11AAO(eL11._END - 1) As String
    '    Public G62(eG62._END - 1) As String
    '    Public N1Sh(eN1._END - 1) As String
    '    Public N3Sh(eN3._END - 1) As String
    '    Public N4Sh(eN4._END - 1) As String
    '    Public S5(eS5._END - 1) As String

    '    Public DLInfo(1) As DLInfo204

    '    Public L3(eL3._END - 1) As String
    '    Public SE(eSE._END - 1) As String
    'End Class

    'Public Class I204
    '    Public ISA(eISA._END - 1) As String
    '    Public GS(eGS._END - 1) As String

    '    Public SetArr(1) As Set204

    '    Public GE(eGE._END - 1) As String
    '    Public IEA(eIEA._END - 1) As String
    'End Class

    'This class will represent a single month and will contain relevant billing information
    'It is actually a single row of the Unison.dbo.MonthlyWorkingDays table
    Private Class BillingMonth

        Private m_iRowId As Integer
        Private m_sLongName As String
        Private m_sShortName As String
        Private m_iNumericName As Integer
        Private m_iWorkingDays As Integer

        Sub New(ByVal p_iRowId As Integer, ByVal p_sLongName As String, ByVal p_sShortName As String, ByVal p_iNumericName As Integer, ByVal p_iWorkingDays As Integer)
            m_iRowId = p_iRowId
            m_sLongName = p_sLongName
            m_sShortName = p_sShortName
            m_iNumericName = p_iNumericName
            m_iWorkingDays = p_iWorkingDays
        End Sub

        'TO DO:  Add a Public Read-Only Property for each LongName, ShortName, NumericName & WorkingDays

    End Class

    'This class is going to contain a collection of BillingMonths (Jan - Dec), and in the future may contain BillingWeeks & BillingDays
    Public Class BillingYear

        'TO DO:  Populate the collection of BillingMonths from actual data in Unison.dbo.MonthlyWorkingDays table
        Sub New()

        End Sub

        Public Function WorkingDaysInMonth(ByVal p_iNumeric As Integer) As Integer
            'TO DO:  Replace this CASE-SELECT to actually return value from the appropriate BillingMonth object that is stored in the BillingMonthCollection
            Select Case p_iNumeric
                Case 1
                    Return 31
                Case 2
                    Return 28
                Case 3
                    Return 31
                Case 4
                    Return 30
                Case 5
                    Return 31
                Case 6
                    Return 30
                Case 7
                    Return 31
                Case 8
                    Return 31
                Case 9
                    Return 30
                Case 10
                    Return 31
                Case 11
                    Return 30
                Case 12
                    Return 31
                Case Else
                    Return 0
            End Select
        End Function

        Public Function LongMonthName(ByVal p_iNumeric As Integer) As String
            'TO DO:  Replace this CASE-SELECT to actually return value from the appropriate BillingMonth object that is stored in the BillingMonthCollection
            Select Case p_iNumeric
                Case 1
                    Return "JANUARY"
                Case 2
                    Return "FEBRUARY"
                Case 3
                    Return "MARCH"
                Case 4
                    Return "APRIL"
                Case 5
                    Return "MAY"
                Case 6
                    Return "JUNE"
                Case 7
                    Return "JULY"
                Case 8
                    Return "AUGUST"
                Case 9
                    Return "SEPTEMBER"
                Case 10
                    Return "OCTOBER"
                Case 11
                    Return "NOVEMBER"
                Case 12
                    Return "DECEMBER"
                Case Else
                    Return "ERROR"
            End Select
        End Function

        Public Function ShortMonthName(ByVal p_iNumeric As Integer) As String
            'TO DO:  Replace this CASE-SELECT to actually return value from the appropriate BillingMonth object that is stored in the BillingMonthCollection
            Select Case p_iNumeric
                Case 1
                    Return "JAN"
                Case 2
                    Return "FEB"
                Case 3
                    Return "MAR"
                Case 4
                    Return "APR"
                Case 5
                    Return "MAY"
                Case 6
                    Return "JUN"
                Case 7
                    Return "JUL"
                Case 8
                    Return "AUG"
                Case 9
                    Return "SEP"
                Case 10
                    Return "OCT"
                Case 11
                    Return "NOV"
                Case 12
                    Return "DEC"
                Case Else
                    Return "ERR"
            End Select
        End Function


    End Class


End Module
