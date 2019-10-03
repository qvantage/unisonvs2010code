Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Math

Module HRVars
    Public HRDBName As String 'SAM-MULTIPLE: = "UN_HR"
    Public HRDBUser As String = "Unison" '"tpctrk"
    Public HRDBPass As String = "unison" '"top"
    Public HRTblPath As String 'SAM-MULTIPLE: = HRDBName & ".dbo." 'TRCDBName & ".dbo." 'Karina changed
    Public WEIGHTDBName As String = "unison" '"top"
    Public TRUCKSDBName As String = "unison" '"top"
    Public WEIGHTTblPath As String = "unison" '"top"
    Public TRUCKSTblPath As String = "unison" '"top"


#Region "Class Library:  Work Date Related"

    Public Enum PayPeriodFrequency As Short
        WEEKLY = 0
        BIWEEKLY = 1
        'MONTHLY = 2 'MONTHLY IS ONLY FOR GOVERNMENT AGENCIES
    End Enum

    Public Enum DayOfWeek As Short
        SUNDAY = 0
        MONDAY = 1
        TUESDAY = 2
        WEDNESDAY = 3
        THUSDAY = 4
        FRIDAY = 5
        SATURDAY = 6
    End Enum

    Public Class clsWorkDate

        Private _dtInitialPayPeriodEndDate As Date
        Private _enumPayPerFreq As PayPeriodFrequency
        Private _enumWeekEndingDay As DayOfWeek

        'PURPOSE:   Feed this function any date and it will return the appropriate company Week-Ending value.
        'NOTES:     This function assumes the computers locale is set to United States.  No provision
        '           Is made for any other country.  This means that Sunday is day 0.
        '
        Public Function WeekEnding(ByVal dt As Date) As Date

            Dim dtWeekEnding As New Date
            dtWeekEnding = dt

            If dtWeekEnding.DayOfWeek = _enumWeekEndingDay Then
                WeekEnding = dtWeekEnding
            Else
                WeekEnding = dtWeekEnding.AddDays(7 - dtWeekEnding.DayOfWeek)
            End If

        End Function
        ' IsInPayPeriod Added By Ali
        Public Function IsInPayPeriod(ByVal dt As Date, ByVal dtPayrollEnding As Date) As Boolean
            IsInPayPeriod = False

            Select Case _enumPayPerFreq
                Case PayPeriodFrequency.WEEKLY
                    If dt >= dtPayrollEnding.AddDays(-6) And dt <= dtPayrollEnding Then
                        IsInPayPeriod = True
                    End If
                Case PayPeriodFrequency.BIWEEKLY
                    If dt >= dtPayrollEnding.AddDays(-13) And dt <= dtPayrollEnding Then
                        IsInPayPeriod = True
                    End If
            End Select

        End Function

        Public Function PayrollEndDate(ByVal dt As Date) As Date

            Dim dtPayrollEndDate As New Date
            dtPayrollEndDate = WeekEnding(dt)

            'Determine step and direction
            Dim iStep As Short
            Dim dtTmp As Date = _dtInitialPayPeriodEndDate
            Dim i As Integer = dtTmp.CompareTo(dt) '-1 if dtTmp < dt, 0 if dtTmp = dt, 1 if dtTmp > dt

            If i = 1 Then
                Select Case _enumPayPerFreq
                    Case PayPeriodFrequency.WEEKLY
                        Do While i = -1
                            dtTmp = dtTmp.AddDays(-7)
                            i = dtTmp.CompareTo(dt)
                        Loop
                        dtTmp = dtTmp.AddDays(7)
                    Case PayPeriodFrequency.BIWEEKLY
                        Do While i = -1
                            dtTmp = dtTmp.AddDays(-14)
                            i = dtTmp.CompareTo(dt)
                        Loop
                        dtTmp = dtTmp.AddDays(14)
                    Case Else
                        dtTmp = Nothing
                        'Case PayPeriodFrequency.MONTHLY
                        '    Do While i = -1
                        '        dtTmp = dtTmp.AddMonths(-1)
                        '        i = dtTmp.CompareTo(dt)
                        '    Loop
                        '    dtTmp = dtTmp.AddMonths(1)
                End Select
            Else
                Select Case _enumPayPerFreq
                    Case PayPeriodFrequency.WEEKLY
                        Do While i = -1
                            dtTmp = dtTmp.AddDays(7)
                            i = dtTmp.CompareTo(dt)
                        Loop
                    Case PayPeriodFrequency.BIWEEKLY
                        Do While i = -1
                            dtTmp = dtTmp.AddDays(14)
                            i = dtTmp.CompareTo(dt)
                        Loop
                    Case Else
                        dtTmp = Nothing
                        'Case PayPeriodFrequency.MONTHLY
                        '    Do While i = -1
                        '        dtTmp = dtTmp.AddMonths(1)
                        '        i = dtTmp.CompareTo(dt)
                        '    Loop
                End Select
            End If

            PayrollEndDate = dtTmp

        End Function

        'PURPOSE:   This constructor will initialze itself with the values passed to it that define a companies work date policies
        'PARAMS:    dt - this represents an intial pay period end date
        '           freq - defines the pay period frequency,  at least the first three letters of the weekday must be present
        '           day - this refers to the week-ending day.
        Public Sub New(ByVal dt As Date, ByVal freq As String, ByVal day As String)

            'Set value
            _dtInitialPayPeriodEndDate = dt

            'Determine and set appropriate frequency
            Select Case freq
                Case "WEEKLY"
                    _enumPayPerFreq = PayPeriodFrequency.WEEKLY
                Case "BIWEEKLY"
                    _enumPayPerFreq = PayPeriodFrequency.BIWEEKLY
                    'Case "MONTHLY"
                    '    _enumPayPerFreq = PayPeriodFrequency.MONTHLY
            End Select

            'Determine and set appropriate week ending day
            Dim strDOW As String = day.Substring(0, 3).ToUpper
            Select Case strDOW
                Case "SUN"
                    _enumWeekEndingDay = DayOfWeek.SUNDAY
                Case "MON"
                    _enumWeekEndingDay = DayOfWeek.MONDAY
                Case "TUE"
                    _enumWeekEndingDay = DayOfWeek.TUESDAY
                Case "WED"
                    _enumWeekEndingDay = DayOfWeek.WEDNESDAY
                Case "THU"
                    _enumWeekEndingDay = DayOfWeek.THUSDAY
                Case "FRI"
                    _enumWeekEndingDay = DayOfWeek.FRIDAY
                Case "SAT"
                    _enumWeekEndingDay = DayOfWeek.SATURDAY
            End Select

        End Sub

        'PURPOSE:   Feed this function any date and it will return TRUE if that date is a company holiday or FALSE if it is not.
        'NOTES:     Deactivate Holiday Functionality Until Future Consideration
        '
        'Public Function IsHoliday(ByVal dt As Date) As Boolean

        'Dim cTpcHolidays As New clsTpcHolidays

        'IsHoliday = cTpcHolidays.IsHoliday(CDate(dt.ToShortDateString))

        'End Function

    End Class

    Public Class clsWorkHours
        Private _sMaxHoursAllowed As Single
        Private _sCurrentHoursWorked As Single

        Public Property MaxHoursAllowed() As Single
            Get
                Return _sMaxHoursAllowed
            End Get
            Set(ByVal Value As Single)
                If (Value < 0) Then
                    _sMaxHoursAllowed = 0
                ElseIf (Value > 24) Then
                    _sMaxHoursAllowed = 24
                Else
                    _sMaxHoursAllowed = Value
                End If
            End Set
        End Property

        Public ReadOnly Property CurrentHoursWorked() As Single
            Get
                Return _sCurrentHoursWorked
            End Get
        End Property

        'METHOD:    Public Function Add(ByVal hoursWorked As Single) As Single
        'PURPOSE:   This function is called in order to record the number of hours that have been worked.
        '           The hoursWorked will be added to the class up to MaxHoursAllowed.  The function will
        '           return the number of hoursWorked that were absorbed.
        Public Function Add(ByVal hoursWorked As Single) As Single
            Dim sNewTotal As Single = hoursWorked + _sCurrentHoursWorked
            Dim sReturn As Single = 0
            If sNewTotal <= _sMaxHoursAllowed Then
                _sCurrentHoursWorked = sNewTotal
                sReturn = hoursWorked 'Because it absorbed all the hoursWorked
            Else
                Dim sMaxAllowed As Single = _sMaxHoursAllowed - _sCurrentHoursWorked
                _sCurrentHoursWorked += sMaxAllowed
                sReturn = sMaxAllowed
            End If
            Return sReturn
        End Function

        Public Function Copy() As clsWorkHours
            Dim cWorkHoursTwin As New clsWorkHours
            cWorkHoursTwin._sCurrentHoursWorked = Me._sCurrentHoursWorked
            cWorkHoursTwin._sMaxHoursAllowed = Me._sMaxHoursAllowed
            Copy = cWorkHoursTwin
        End Function

    End Class

    Public Class clsWorkDay

        Private _cDate As Date
        Private _sTimeIn As Single
        Private _sTimeOut As Single
        Private _sBreakHours As Single
        Private _cRegularHours As clsWorkHours
        Private _cOvertimeHours As clsWorkHours
        Private _cDoubletimeHours As clsWorkHours
        Private _sPeriods As Short

        Public Property Periods() As Short
            Get
                Return _sPeriods
            End Get
            Set(ByVal Value As Short)
                _sPeriods = Value
            End Set
        End Property

        Public ReadOnly Property MaxRegHours() As Single
            Get
                Return _cRegularHours.MaxHoursAllowed
            End Get
        End Property

        Public ReadOnly Property MaxOtHours() As Single
            Get
                Return _cOvertimeHours.MaxHoursAllowed
            End Get
        End Property

        Public ReadOnly Property MaxDtHours() As Single
            Get
                Return _cDoubletimeHours.MaxHoursAllowed
            End Get
        End Property

        Public ReadOnly Property RegHours() As Single
            Get
                Return CSng(Math.Round(_cRegularHours.CurrentHoursWorked, 2))
            End Get
        End Property

        Public ReadOnly Property OtHours() As Single
            Get
                Return CSng(Math.Round(_cOvertimeHours.CurrentHoursWorked, 2))
            End Get
        End Property

        Public ReadOnly Property DtHours() As Single
            Get
                Return CSng(Math.Round(_cDoubletimeHours.CurrentHoursWorked, 2))
            End Get
        End Property

        Public ReadOnly Property WorkDate() As Date
            Get
                Return _cDate
            End Get
        End Property

        'METHOD:    Public Sub New()
        'PURPOSE:   This is the class' constructor.  It will initialize the private variables and set 
        '           them to standard US company defaults.
        Public Sub New(Optional ByVal workDate As Date = #1/1/1900#)
            If StrComp(workDate.ToShortDateString, "01/01/1900") = 0 Then
                _cDate = Date.Now
            Else
                _cDate = workDate
            End If
            _sTimeIn = 0.0
            _sTimeOut = 0.0
            _sBreakHours = 0.0
            _cRegularHours = New clsWorkHours
            _cRegularHours.MaxHoursAllowed = 8
            _cOvertimeHours = New clsWorkHours
            _cOvertimeHours.MaxHoursAllowed = 4
            _cDoubletimeHours = New clsWorkHours
            _cDoubletimeHours.MaxHoursAllowed = 12
            _sPeriods = 0
        End Sub

        'METHOD:    Public Function SetMaxHours(ByVal maxReg As Single, ByVal maxOt As Single, ByVal maxDt As Single) As Short
        'PURPOSE:   This method will allow the consumer to override the default values for each of the 
        '           working hour types.  It also enforces a maximum 24 hour work day.  If the parameters
        '           exceed 24 hours, the current max values will not be changed and the function will
        '           return a number that represents the value that exceeded 24.
        Public Function SetMaxHours(ByVal maxReg As Single, ByVal maxOt As Single, ByVal maxDt As Single) As Single

            Dim fReturn As Single

            'Make sure the total allowed workday does not exceed 24 hours
            If (maxReg + maxOt + maxDt) <= 24.0 Then
                'OK to Proceed
                _cRegularHours.MaxHoursAllowed = maxReg
                _cOvertimeHours.MaxHoursAllowed = maxOt
                _cDoubletimeHours.MaxHoursAllowed = maxDt
                fReturn = 0
            Else
                'throw exception
                fReturn = (maxReg + maxOt + maxDt) - 24
            End If
        End Function

        'METHOD:    Public Function Tabulate(ByVal timeIn As Single, ByVal timeOut As Single, Optional ByVal break As Single = 0) As Single
        'PURPOSE:   This method will take the time period entered and categorize each hour as either
        '           Regular, Overtime or Doubletime based upon the Max values allowed for each category.
        'NOTES:     This method will reset the Current hours worked for each category before categorizing
        '           the hours based on the new parameters.
        'RETURN:    0 if everything went fine, a non-zero number if there was a problem
        Public Function Categorize(ByVal timeIn As Single, ByVal timeOut As Single, Optional ByVal break As Single = 0) As Single

            Dim fReturn As Single = 0

            'First, adjust the timeOut parameter if a midnight rollover occured
            Dim fTimeOut As Single = timeOut
            If timeOut < timeIn Then
                fTimeOut += 24
            End If

            'Now, make sure the work period does not exceed 24 hours
            Dim fHoursWorked As Single = fTimeOut - timeIn
            If fHoursWorked > 24 Then
                fReturn = fHoursWorked - 24
                Return fReturn
            End If

            'Subtract breaktime
            fHoursWorked -= break

            'categorize each working hour according to its type
            fHoursWorked -= _cRegularHours.Add(fHoursWorked)
            fHoursWorked -= _cOvertimeHours.Add(fHoursWorked)
            fHoursWorked -= _cDoubletimeHours.Add(fHoursWorked)

        End Function

        Public Function Copy() As clsWorkDay
            Dim cWorkDayTwin As clsWorkDay
            cWorkDayTwin = New clsWorkDay(Me.WorkDate)
            cWorkDayTwin._sTimeIn = Me._sTimeIn
            cWorkDayTwin._sTimeOut = Me._sTimeOut
            cWorkDayTwin._sBreakHours = Me._sBreakHours
            cWorkDayTwin._cRegularHours = Me._cRegularHours.Copy
            cWorkDayTwin._cOvertimeHours = Me._cOvertimeHours.Copy
            cWorkDayTwin._cDoubletimeHours = Me._cDoubletimeHours.Copy
            Copy = cWorkDayTwin
        End Function

    End Class

    Public Class clsWorkDayCollection
        Inherits System.Collections.CollectionBase

        Private _shortDateHashtable As New Hashtable

        Public ReadOnly Property ShortDateHashtable() As Hashtable
            Get
                Return _shortDateHashtable
            End Get
        End Property

        Public Sub Add(ByVal newWorkDay As clsWorkDay)
            Me.List.Add(newWorkDay)
            ShortDateHashtable.Add(newWorkDay.WorkDate.ToShortDateString, newWorkDay)
        End Sub

        Public ReadOnly Property ItemIndex(ByVal strDate As String) As Integer
            Get
                Dim i As Integer = 0
                Dim cWorkDay As clsWorkDay
                For Each cWorkDay In Me
                    If StrComp(CStr(cWorkDay.WorkDate), strDate) = 0 Then
                        Exit For
                    Else
                        i += 1
                    End If
                Next
                Return i
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal strDate As String) As clsWorkDay
            Get
                Return ShortDateHashtable.Item(strDate)
            End Get
        End Property

        Default Public Property Item(ByVal index As Integer) As clsWorkDay
            Get
                Return Me.List.Item(index)
            End Get
            Set(ByVal Value As clsWorkDay)
                Me.List.Item(index) = Value
            End Set
        End Property

        Public Sub Remove(ByVal removeWorkDay As clsWorkDay)
            Me.List.Remove(removeWorkDay)
        End Sub

    End Class

    Public Class clsWorkWeek

        Private _fMaxWeeklyRegularHours As Single
        Private _fWeeklyRegularHours As Single
        Private _fMaxWeeklyOvertimeHours As Single
        Private _fWeeklyOvertimeHours As Single
        Private _fMaxWeeklyDoubletimeHours As Single
        Private _fWeeklyDoubletimeHours As Single

        Private _cWorkDays As clsWorkDayCollection

        Public ReadOnly Property WorkDays() As clsWorkDayCollection
            Get
                Return _cWorkDays
            End Get
        End Property

        Public ReadOnly Property RegHours() As Single
            Get
                Return _fWeeklyRegularHours
            End Get
        End Property

        Public ReadOnly Property OtHours() As Single
            Get
                Return _fWeeklyOvertimeHours
            End Get
        End Property

        Public ReadOnly Property DtHours() As Single
            Get
                Return _fWeeklyDoubletimeHours
            End Get
        End Property

        Public Sub New(Optional ByVal weekEnding As Date = #1/1/1900#)

            Dim dtWeekEnding As New Date

            'Determine Weekending Date
            If StrComp("01/01/1900", weekEnding.ToShortDateString) = 0 Then
                dtWeekEnding = Date.Now
            Else
                dtWeekEnding = weekEnding
            End If

            'Initialze each of the working day collection
            _cWorkDays = New clsWorkDayCollection
            _cWorkDays.Add(New clsWorkDay(weekEnding.AddDays(-6)))
            _cWorkDays.Add(New clsWorkDay(weekEnding.AddDays(-5)))
            _cWorkDays.Add(New clsWorkDay(weekEnding.AddDays(-4)))
            _cWorkDays.Add(New clsWorkDay(weekEnding.AddDays(-3)))
            _cWorkDays.Add(New clsWorkDay(weekEnding.AddDays(-2)))
            _cWorkDays.Add(New clsWorkDay(weekEnding.AddDays(-1)))
            _cWorkDays.Add(New clsWorkDay(weekEnding))

            'Initialize other members
            _fMaxWeeklyRegularHours = 40
            _fWeeklyRegularHours = 0
            _fMaxWeeklyOvertimeHours = 128
            _fWeeklyOvertimeHours = 0
            _fMaxWeeklyDoubletimeHours = 128
            _fWeeklyDoubletimeHours = 0

            'DEBUG-BEGIN:  Test Collection Access
            'Dim i As Short
            'For i = 0 To 6
            'MessageBox.Show(_cWorkDays.Item(i).MaxRegHours())
            'MessageBox.Show(_cWorkDays.Item(i).WorkDate.ToShortDateString)
            'Next
            'DEBUG-END:

        End Sub

        ' Returns a concatenated update string
        Public Function ProcessTimeCard(ByVal drWorkDetails As SqlDataReader) As String

            Dim iIndex As Integer = 0
            Dim i As Integer
            Dim fTimeIn, fTimeOut, fBreak, fOldReg, fNewMaxReg, fOldOt, fNewMaxOt, fOldDt, fNewMaxDt, fProcessed As Single
            Dim cWorkDay, cWorkDayTwin As clsWorkDay
            Dim strWorkDate, strSQLDate As String
            Dim strSQL As String = ""


            'Dim bDebug As Boolean = True
            Do While drWorkDetails.Read
                'If bDebug Then
                'MessageBox.Show("About to ProcessTimeCard for " & drWorkDetails("EmployeeID") & "-" & drWorkDetails("WeekEnding"))
                'bDebug = False
                'End If
                cWorkDay = _cWorkDays(CStr(drWorkDetails("CheckInDate")))
                If Not (cWorkDay Is Nothing) Then
                    iIndex = _cWorkDays.ItemIndex(CStr(drWorkDetails("CheckInDate")))
                    strWorkDate = cWorkDay.WorkDate.ToShortDateString
                    strSQLDate = CStr(drWorkDetails("CheckInDate"))
                    ' Determine if the current Row applys to the current WorkDay
                    If StrComp(strWorkDate, strSQLDate) = 0 Then
                        cWorkDay.Periods += CShort(1)
                        If cWorkDay.Periods > 1 Then
                            fOldReg = cWorkDay.RegHours
                            fOldOt = cWorkDay.OtHours
                            fOldDt = cWorkDay.DtHours
                        Else
                            fOldReg = 0
                            fOldOt = 0
                            fOldDt = 0
                        End If
                        fNewMaxReg = cWorkDay.MaxRegHours
                        fNewMaxOt = cWorkDay.MaxOtHours
                        fNewMaxDt = cWorkDay.MaxDtHours
                        ' Check to see if daily max regular values need to be adjusted because of weekly totals

                        '2006-07-11 Added By Ali: Resolve Negative Hours On 2nd Shift, Day 5 when RemainderWeekRegHrs = RemainderDailyRegHours

                        If (_fMaxWeeklyRegularHours - _fWeeklyRegularHours) < (fNewMaxReg - cWorkDay.RegHours) Then
                            fNewMaxReg = (_fMaxWeeklyRegularHours - _fWeeklyRegularHours)
                            ' Ali: Shouldn't the 12 be replaced with MaxDailyReg+MaxDailyOT?
                            ' Before Change: OfNewMaxOt = 12 - fNewMaxReg ' Confirm this rule with Zak or Ali
                            fNewMaxOt = (24 - fNewMaxDt) - fNewMaxReg
                            ' By Ali: On the 6th day, Maximum of OT Should be 12 if Weekly Reg Hrs has reached 40
                            'If fNewMaxOt > 8 Then
                            '    fNewMaxOt = 8
                            'End If
                        End If
                        ' Check to see if daily max Ot hours need to be adjusted
                        If (_fMaxWeeklyOvertimeHours - _fWeeklyOvertimeHours) < fNewMaxOt Then
                            fNewMaxOt = (_fMaxWeeklyOvertimeHours - _fWeeklyOvertimeHours)
                        End If
                        ' Adjust daily max OT
                        fNewMaxDt = 24 - (fNewMaxReg + fNewMaxOt)
                        'MessageBox.Show("(" & _cWorkDays.ItemIndex(CStr(drWorkDetails("CheckInDate"))) & ")")

                        'If this is the first period of the current day, set MaxHours
                        If cWorkDay.Periods = 1 Then
                            _cWorkDays.Item(iIndex).SetMaxHours(fNewMaxReg, fNewMaxOt, fNewMaxDt)
                        End If

                        'Now, update remaining days with new default values
                        Dim iStart As Integer
                        iStart = iIndex + 1
                        If iStart < 7 Then
                            For i = (iIndex + 1) To 6
                                _cWorkDays.Item(i).SetMaxHours(fNewMaxReg, fNewMaxOt, fNewMaxDt)
                            Next
                        End If

                        fTimeIn = CSng(drWorkDetails("TimeIn"))
                        fTimeOut = CSng(drWorkDetails("TimeOut"))
                        fBreak = CSng(drWorkDetails("BreakTime"))
                        'Do it for real since remaining days have been adjusted accordingly
                        cWorkDay.Categorize(fTimeIn, fTimeOut, fBreak)
                        'Update Weekly Totals
                        _fWeeklyRegularHours += (cWorkDay.RegHours - fOldReg)
                        _fWeeklyOvertimeHours += (cWorkDay.OtHours - fOldOt)
                        _fWeeklyDoubletimeHours += (cWorkDay.DtHours - fOldDt)
                        'Construct an SQL UPDATE statement that can be used to update the db
                        fProcessed = CSng(drWorkDetails("Processed"))
                        If fProcessed = 0 Then
                            strSQL = strSQL & "UPDATE " & HRTblPath & "EmployeeActivityDetail SET WeeklyRegHrsTotal = " & _fWeeklyRegularHours & ", RegHrs = " & (cWorkDay.RegHours - fOldReg) & ", OtHrs = " & (cWorkDay.OtHours - fOldOt) & ", DtHrs = " & (cWorkDay.DtHours - fOldDt) & " WHERE RowId = " & CStr(drWorkDetails("RowId")) & ";"
                        End If
                        'BEGIN-DEBUG
                        'MessageBox.Show("Work Date: " & cWorkDay.WorkDate & "WEEKLY REG: " & _fWeeklyRegularHours & " WEEKLY OT: " & _fWeeklyOvertimeHours)
                        'END-DEBUG
                    End If
                    cWorkDay = Nothing
                End If
            Loop

            Return strSQL

        End Function

        'Returns a concatenated update string
        Public Function ProcessTimeCardV2(ByRef p_dataSet As Data.DataSet) As String

            Dim iIndex As Integer = 0
            Dim i As Integer
            Dim fTimeIn, fTimeOut, fBreak, fOldReg, fNewMaxReg, fOldOt, fNewMaxOt, fOldDt, fNewMaxDt, fProcessed As Single
            Dim cWorkDay, cWorkDayTwin As clsWorkDay
            Dim strWorkDate, strSQLDate As String
            Dim strSQL As String = ""

            Dim dataRow As DataRow

            Dim iTotalRows As Integer = p_dataSet.Tables(0).Rows.Count
            Dim iRowIndex As Integer = 0
            Dim iReturn As Integer = 0

            'Dim bDebug As Boolean = True
            If iTotalRows > 0 Then

                While iRowIndex < iTotalRows
                    'If bDebug Then
                    'MessageBox.Show("About to ProcessTimeCard for " & drWorkDetails("EmployeeID") & "-" & drWorkDetails("WeekEnding"))
                    'bDebug = False
                    'End If
                    cWorkDay = _cWorkDays(CStr(p_dataSet.Tables(0).Rows(iRowIndex).Item("CheckInDate")))
                    If Not (cWorkDay Is Nothing) Then
                        iIndex = _cWorkDays.ItemIndex(CStr(p_dataSet.Tables(0).Rows(iRowIndex).Item("CheckInDate")))
                        strWorkDate = cWorkDay.WorkDate.ToShortDateString
                        strSQLDate = CStr(p_dataSet.Tables(0).Rows(iRowIndex).Item("CheckInDate"))
                        ' Determine if the current Row applys to the current WorkDay
                        If StrComp(strWorkDate, strSQLDate) = 0 Then
                            cWorkDay.Periods += CShort(1)
                            If cWorkDay.Periods > 1 Then
                                fOldReg = cWorkDay.RegHours
                                fOldOt = cWorkDay.OtHours
                                fOldDt = cWorkDay.DtHours
                            Else
                                fOldReg = 0
                                fOldOt = 0
                                fOldDt = 0
                            End If
                            fNewMaxReg = cWorkDay.MaxRegHours
                            fNewMaxOt = cWorkDay.MaxOtHours
                            fNewMaxDt = cWorkDay.MaxDtHours
                            ' Check to see if daily max regular values need to be adjusted because of weekly totals
                            If (_fMaxWeeklyRegularHours - _fWeeklyRegularHours) < (fNewMaxReg - cWorkDay.RegHours) Then
                                fNewMaxReg = (_fMaxWeeklyRegularHours - _fWeeklyRegularHours)
                                ' Ali: Shouldn't the 12 be replaced with MaxDailyReg+MaxDailyOT?
                                ' Before Change: OfNewMaxOt = 12 - fNewMaxReg ' Confirm this rule with Zak or Ali
                                fNewMaxOt = (24 - fNewMaxDt) - fNewMaxReg ' Confirm this rule with Zak or Ali
                                ' By Ali: On the 6th day, Maximum of OT Should be 12 if Weekly Reg Hrs has reached 40
                                'If fNewMaxOt > 8 Then
                                '    fNewMaxOt = 8
                                'End If
                            End If
                            ' Check to see if daily max Ot hours need to be adjusted
                            If (_fMaxWeeklyOvertimeHours - _fWeeklyOvertimeHours) < fNewMaxOt Then
                                fNewMaxOt = (_fMaxWeeklyOvertimeHours - _fWeeklyOvertimeHours)
                            End If
                            ' Adjust daily max OT
                            fNewMaxDt = 24 - (fNewMaxReg + fNewMaxOt)
                            'MessageBox.Show("(" & _cWorkDays.ItemIndex(CStr(drWorkDetails("CheckInDate"))) & ")")

                            'If this is the first period of the current day, set MaxHours
                            If cWorkDay.Periods = 1 Then
                                _cWorkDays.Item(iIndex).SetMaxHours(fNewMaxReg, fNewMaxOt, fNewMaxDt)
                            End If

                            'Now, update remaining days with new default values
                            Dim iStart As Integer
                            iStart = iIndex + 1
                            If iStart < 7 Then
                                For i = (iIndex + 1) To 6
                                    _cWorkDays.Item(i).SetMaxHours(fNewMaxReg, fNewMaxOt, fNewMaxDt)
                                Next
                            End If

                            fTimeIn = CSng(p_dataSet.Tables(0).Rows(iRowIndex).Item("TimeIn"))
                            fTimeOut = CSng(p_dataSet.Tables(0).Rows(iRowIndex).Item("TimeOut"))
                            fBreak = CSng(p_dataSet.Tables(0).Rows(iRowIndex).Item("BreakTime"))
                            'Do it for real since remaining days have been adjusted accordingly
                            cWorkDay.Categorize(fTimeIn, fTimeOut, fBreak)
                            'Update Weekly Totals
                            _fWeeklyRegularHours += (cWorkDay.RegHours - fOldReg)
                            _fWeeklyOvertimeHours += (cWorkDay.OtHours - fOldOt)
                            _fWeeklyDoubletimeHours += (cWorkDay.DtHours - fOldDt)
                            'Construct an SQL UPDATE statement that can be used to update the db
                            fProcessed = CSng(p_dataSet.Tables(0).Rows(iRowIndex).Item("Processed"))
                            If fProcessed = 0 Then
                                strSQL = strSQL & "UPDATE " & HRTblPath & "EmployeeActivityDetail SET WeeklyRegHrsTotal = " & _fWeeklyRegularHours & ", RegHrs = " & (cWorkDay.RegHours - fOldReg) & ", OtHrs = " & (cWorkDay.OtHours - fOldOt) & ", DtHrs = " & (cWorkDay.DtHours - fOldDt) & " WHERE RowId = " & CStr(p_dataSet.Tables(0).Rows(iRowIndex).Item("RowId")) & ";"
                            End If
                            'BEGIN-DEBUG
                            'MessageBox.Show("Work Date: " & cWorkDay.WorkDate & "WEEKLY REG: " & _fWeeklyRegularHours & " WEEKLY OT: " & _fWeeklyOvertimeHours)
                            'END-DEBUG
                        End If
                        cWorkDay = Nothing
                    End If
                    iRowIndex += 1
                End While
            End If

            Return strSQL

        End Function

        'Returns the number of dataset records modified
        Public Function ProcessTimeCardV3(ByRef p_dataSet As Data.DataSet) As Integer

            Dim iIndex As Integer = 0
            Dim i As Integer
            Dim fTimeIn, fTimeOut, fBreak, fOldReg, fNewMaxReg, fOldOt, fNewMaxOt, fOldDt, fNewMaxDt, fProcessed As Single
            Dim cWorkDay, cWorkDayTwin As clsWorkDay
            Dim strWorkDate, strSQLDate As String
            Dim strSQL As String = ""

            Dim dataRow As DataRow

            Dim iTotalRows As Integer = p_dataSet.Tables(0).Rows.Count
            Dim iRowIndex As Integer = 0
            Dim iReturn As Integer = 0

            'Dim bDebug As Boolean = True
            If iTotalRows > 0 Then

                While iRowIndex < iTotalRows
                    'If bDebug Then
                    'MessageBox.Show("About to ProcessTimeCard for " & drWorkDetails("EmployeeID") & "-" & drWorkDetails("WeekEnding"))
                    'bDebug = False
                    'End If
                    cWorkDay = _cWorkDays(CStr(p_dataSet.Tables(0).Rows(iRowIndex).Item("CheckInDate")))
                    If Not (cWorkDay Is Nothing) Then
                        iIndex = _cWorkDays.ItemIndex(CStr(p_dataSet.Tables(0).Rows(iRowIndex).Item("CheckInDate")))
                        strWorkDate = cWorkDay.WorkDate.ToShortDateString
                        strSQLDate = CStr(p_dataSet.Tables(0).Rows(iRowIndex).Item("CheckInDate"))
                        ' Determine if the current Row applys to the current WorkDay
                        If StrComp(strWorkDate, strSQLDate) = 0 Then
                            cWorkDay.Periods += CShort(1)
                            If cWorkDay.Periods > 1 Then
                                fOldReg = cWorkDay.RegHours
                                fOldOt = cWorkDay.OtHours
                                fOldDt = cWorkDay.DtHours
                            Else
                                fOldReg = 0
                                fOldOt = 0
                                fOldDt = 0
                            End If
                            fNewMaxReg = cWorkDay.MaxRegHours
                            fNewMaxOt = cWorkDay.MaxOtHours
                            fNewMaxDt = cWorkDay.MaxDtHours
                            ' Check to see if daily max regular values need to be adjusted because of weekly totals
                            If (_fMaxWeeklyRegularHours - _fWeeklyRegularHours) < (fNewMaxReg - cWorkDay.RegHours) Then
                                fNewMaxReg = (_fMaxWeeklyRegularHours - _fWeeklyRegularHours)
                                ' Ali: Shouldn't the 12 be replaced with MaxDailyReg+MaxDailyOT?
                                ' Before Change: OfNewMaxOt = 12 - fNewMaxReg ' Confirm this rule with Zak or Ali
                                fNewMaxOt = (24 - fNewMaxDt) - fNewMaxReg ' Confirm this rule with Zak or Ali
                                ' By Ali: On the 6th day, Maximum of OT Should be 12 if Weekly Reg Hrs has reached 40
                                'If fNewMaxOt > 8 Then
                                '    fNewMaxOt = 8
                                'End If
                            End If
                            ' Check to see if daily max Ot hours need to be adjusted
                            If (_fMaxWeeklyOvertimeHours - _fWeeklyOvertimeHours) < fNewMaxOt Then
                                fNewMaxOt = (_fMaxWeeklyOvertimeHours - _fWeeklyOvertimeHours)
                            End If
                            ' Adjust daily max OT
                            fNewMaxDt = 24 - (fNewMaxReg + fNewMaxOt)
                            'MessageBox.Show("(" & _cWorkDays.ItemIndex(CStr(drWorkDetails("CheckInDate"))) & ")")

                            'If this is the first period of the current day, set MaxHours
                            If cWorkDay.Periods = 1 Then
                                _cWorkDays.Item(iIndex).SetMaxHours(fNewMaxReg, fNewMaxOt, fNewMaxDt)
                            End If

                            'Now, update remaining days with new default values
                            Dim iStart As Integer
                            iStart = iIndex + 1
                            If iStart < 7 Then
                                For i = (iIndex + 1) To 6
                                    _cWorkDays.Item(i).SetMaxHours(fNewMaxReg, fNewMaxOt, fNewMaxDt)
                                Next
                            End If

                            fTimeIn = CSng(p_dataSet.Tables(0).Rows(iRowIndex).Item("TimeIn"))
                            fTimeOut = CSng(p_dataSet.Tables(0).Rows(iRowIndex).Item("TimeOut"))
                            fBreak = CSng(p_dataSet.Tables(0).Rows(iRowIndex).Item("BreakTime"))
                            'Do it for real since remaining days have been adjusted accordingly
                            cWorkDay.Categorize(fTimeIn, fTimeOut, fBreak)
                            'Update Weekly Totals
                            _fWeeklyRegularHours += (cWorkDay.RegHours - fOldReg)
                            _fWeeklyOvertimeHours += (cWorkDay.OtHours - fOldOt)
                            _fWeeklyDoubletimeHours += (cWorkDay.DtHours - fOldDt)
                            'Construct an SQL UPDATE statement that can be used to update the db
                            fProcessed = CSng(p_dataSet.Tables(0).Rows(iRowIndex).Item("Processed"))
                            If fProcessed = 0 Then
                                p_dataSet.Tables(0).Rows(iRowIndex).Item("WeeklyRegHrsTotal") = _fWeeklyRegularHours
                                p_dataSet.Tables(0).Rows(iRowIndex).Item("RegHrs") = (cWorkDay.RegHours - fOldReg)
                                p_dataSet.Tables(0).Rows(iRowIndex).Item("OtHrs") = (cWorkDay.OtHours - fOldOt)
                                p_dataSet.Tables(0).Rows(iRowIndex).Item("DtHrs") = (cWorkDay.DtHours - fOldDt)
                                'strSQL = strSQL & "UPDATE " & HRTblPath & "EmployeeActivityDetail SET WeeklyRegHrsTotal = " & _fWeeklyRegularHours & ", RegHrs = " & (cWorkDay.RegHours - fOldReg) & ", OtHrs = " & (cWorkDay.OtHours - fOldOt) & ", DtHrs = " & (cWorkDay.DtHours - fOldDt) & " WHERE RowId = " & CStr(drWorkDetails("RowId")) & ";"
                            End If
                            'BEGIN-DEBUG
                            'MessageBox.Show("Work Date: " & cWorkDay.WorkDate & "WEEKLY REG: " & _fWeeklyRegularHours & " WEEKLY OT: " & _fWeeklyOvertimeHours)
                            'END-DEBUG
                        End If
                        cWorkDay = Nothing
                    End If
                    iRowIndex += 1
                End While
            End If

            Return iReturn

        End Function

    End Class

#End Region

#Region "Helper Functions"

    Private Function UpdateHoursInDb(ByVal sql As String) As String

        Dim cnSqlServer As New SqlConnection(strConnection)
        Dim strSQL As String = sql
        Dim strReturnMsg As String = Nothing
        Dim drReader As SqlDataReader
        Dim cmd As New SqlCommand(strSQL, cnSqlServer)

        Try

            'Open the connection
            cnSqlServer.Open()

            'Open the Data Reader
            drReader = cmd.ExecuteReader

            'close the Data Reader to commit the transaction
            drReader.Close()

            'Report records affected
            'MessageBox.Show("Number of Records Inserted: " & drReader.RecordsAffected)

        Catch ex As Exception
            'Error Handling Code
            strReturnMsg = ex.Message.ToString
        Finally

            'cleanup code that needs to run no matter what
            If Not (drReader Is Nothing) Then
                If drReader.IsClosed = False Then
                    drReader.Close()
                End If
            Else
                'MessageBox.Show("drReader Is Nothing")
            End If

            If Not (cnSqlServer Is Nothing) Then
                cnSqlServer.Close()
                cnSqlServer.Dispose()
            Else
                'MessageBox.Show("cnSqlServer Is Nothing")
            End If

        End Try

        Return strReturnMsg

    End Function

#End Region

#Region "Public Functions"

    Public Function CategorizeWorkHoursFinal(ByVal p_iEmpId As Integer, ByVal p_strDate As String) As Boolean

        Dim strSQL As String
        Dim dtAdapter As SqlDataAdapter
        Dim dataSet As Data.DataSet
        Dim cWorkWeek As clsWorkWeek

        strSQL = "SELECT * FROM " & HRTblPath & "EmployeeActivityDetail where employeeId = " & CStr(p_iEmpId) & " and WeekEnding = CAST('" & CStr(p_strDate) & "' AS datetime) order by CheckInDate, TimeIn asc;"
        dataSet = PopulateDataset2(dtAdapter, dataSet, strSQL)
        cWorkWeek = New clsWorkWeek(CDate(p_strDate))
        cWorkWeek.ProcessTimeCardV3(dataSet)
        UpdateDbFromDataSet(dataSet, strSQL)

    End Function

    Public Function CategorizeWorkHoursV3(ByVal p_iEmpId As Integer, ByVal p_strDate As String) As Boolean

        Dim strCondition As String
        Dim bReturn As Boolean
        Dim dataSet As Data.DataSet

        strCondition = " WHERE ead.employeeId = " & CStr(p_iEmpId) & " and ead.WeekEnding = CAST('" & p_strDate & "' AS datetime) order by ead.CheckInDate, ead.TimeIn asc;"

        bReturn = FetchEmployeeActivityDetails(dataSet, strCondition)
        If (bReturn = True) Then
            Dim cWorkWeek As clsWorkWeek
            cWorkWeek = New clsWorkWeek(CDate(p_strDate))
            cWorkWeek.ProcessTimeCardV3(dataSet)
            UpdateDbFromDataSet(dataSet, "") ' Ask Ali for Help
        End If

        Return bReturn

    End Function

    Public Function CategorizeWorkHoursV2(ByVal p_iEmpId As Integer, ByVal p_strDate As String) As Boolean

        Dim strCondition As String
        Dim bReturn As Boolean
        Dim dataSet As Data.DataSet
        Dim strSQL As String

        strCondition = " WHERE ead.employeeId = " & CStr(p_iEmpId) & " and ead.WeekEnding = CAST('" & p_strDate & "' AS datetime) order by ead.CheckInDate, ead.TimeIn asc;"

        bReturn = FetchEmployeeActivityDetails(dataSet, strCondition)
        If (bReturn = True) Then
            Dim cWorkWeek As clsWorkWeek
            cWorkWeek = New clsWorkWeek(CDate(p_strDate))
            strSQL = cWorkWeek.ProcessTimeCardV2(dataSet)
            UpdateHoursInDb(strSQL)
        End If

        Return bReturn

    End Function


    Public Function CategorizeWorkHours(ByVal p_iEmpId As Integer, ByVal p_strDate As String) As String

        'Database Access Variables
        Dim strCn As String ' ***Legacy Code.  Kept to minimize code changes***
        strCn = strConnection
        Dim cnSqlServer As New SqlConnection(strCn)
        Dim strSQL, strReturnMsg As String
        Dim drGeneric As SqlDataReader
        Dim cmdSQL As SqlCommand
        'Dim cTopDate As New clsTpcDate

        Try
            'Open the database connection
            cnSqlServer.Open()

            'Determine all distinct EmployeeID-WeekEnding combos ***Legacy code.  Kept to minimize code changes***
            'strSQL = "SELECT DISTINCT EmployeeID,WeekEnding FROM " & HRTblPath & "EMPLOYEEACTIVITYDETAIL WHERE Processed = 0 AND EmployeeID = " & p_iEmpId & " AND WeekEnding = CAST('" & p_strDate & "' AS DATETIME) ORDER BY EmployeeID, WeekEnding;"
            strSQL = "SELECT DISTINCT EmployeeID,WeekEnding FROM " & HRTblPath & "EMPLOYEEACTIVITYDETAIL WHERE EmployeeID = " & p_iEmpId & " AND WeekEnding = CAST('" & p_strDate & "' AS DATETIME) ORDER BY EmployeeID, WeekEnding;"
            cmdSQL = New SqlCommand(strSQL, cnSqlServer)
            drGeneric = cmdSQL.ExecuteReader
            strSQL = Nothing
            Dim listAllDates As New ArrayList
            Do While drGeneric.Read
                strSQL = strSQL & "SELECT * FROM " & HRTblPath & "EmployeeActivityDetail where employeeId = " & CStr(drGeneric("EmployeeId")) & " and WeekEnding = CAST('" & CStr(drGeneric("WeekEnding")) & "' AS datetime) order by CheckInDate, TimeIn asc;"
                listAllDates.Add(CDate(drGeneric("WeekEnding")).ToShortDateString)
            Loop
            drGeneric.Close()

            'Call clsWorkWeek's ProcessTimeCard for each distinct EmployeeID-WeekEnding combo
            Dim bSuccess As Boolean

            cmdSQL.CommandText = strSQL
            drGeneric = cmdSQL.ExecuteReader
            strSQL = Nothing

            'ProcessTimeCard if there is at least 1 ResultSet
            Dim cWorkWeek As clsWorkWeek
            Dim iIndex As Integer
            If Not (drGeneric Is Nothing) Then
                iIndex = 0
                cWorkWeek = New clsWorkWeek(CDate(listAllDates(iIndex)))
                strSQL = cWorkWeek.ProcessTimeCard(drGeneric)
                strReturnMsg = UpdateHoursInDb(strSQL)
                cWorkWeek = Nothing
                If Not (strReturnMsg = Nothing) Then Exit Try
            End If

            'Enter this loop if there are more than 1 ResultSets
            bSuccess = drGeneric.NextResult
            Do While bSuccess = True
                iIndex += 1
                cWorkWeek = New clsWorkWeek(CDate(listAllDates(iIndex)))
                strSQL = cWorkWeek.ProcessTimeCard(drGeneric)
                strReturnMsg = UpdateHoursInDb(strSQL)
                cWorkWeek = Nothing
                If Not (strReturnMsg = Nothing) Then Exit Try
                bSuccess = drGeneric.NextResult
            Loop

            strReturnMsg = "All records have been sucessfully processed."


        Catch ex As Exception

            strReturnMsg = ex.ToString.ToString

        Finally

            'cleanup code that needs to run no matter what
            If Not (drGeneric Is Nothing) Then
                If drGeneric.IsClosed = False Then
                    drGeneric.Close()
                End If
            End If

            If Not (cnSqlServer Is Nothing) Then
                cnSqlServer.Close()
                cnSqlServer.Dispose()
            End If

        End Try

        Return strReturnMsg

    End Function

#End Region

End Module
