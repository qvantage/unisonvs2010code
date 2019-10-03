Public Class clsTpcDate
    ''
    ''METHOD:    Public Function IsHoliday(ByVal dt As Date) As Boolean
    ''PURPOSE:   Feed this function any date and it will return TRUE if that date is a Top Priority 
    ''           holiday or FALSE if it is not.
    ''NOTES:     None
    ''
    'Public Function IsHoliday(ByVal dt As Date) As Boolean

    '    Dim cTpcHolidays As New clsTpcHolidays

    '    IsHoliday = cTpcHolidays.IsHoliday(CDate(dt.ToShortDateString))

    'End Function
    '
    'FUNCTION:  Public Function WeekEnding(ByVal dt As Date) As Date 
    'PURPOSE:   Feed this function any date and it will return the appropriate Top Priority 
    '           Week-Ending value.
    'NOTES:     This function assumes the computers locale is set to United States.  No provision
    '           Is made for any other country.
    '
    Public Function WeekEnding(ByVal dt As Date) As Date
        Dim dtWeekEnding As New Date
        dtWeekEnding = dt
        If dtWeekEnding.DayOfWeek = DayOfWeek.Sunday Then
            WeekEnding = dtWeekEnding
        Else
            WeekEnding = dtWeekEnding.AddDays(7 - dtWeekEnding.DayOfWeek)
        End If
    End Function

End Class

