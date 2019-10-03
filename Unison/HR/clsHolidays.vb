Public Class clsTpcHolidays
    Private _holidays As clsHolidayCollection

    Public Sub New()
        _holidays = New clsHolidayCollection
        LoadHolidays()
    End Sub

    Public Function IsHoliday(ByVal dt As Date) As Boolean
        If StrComp(dt.ToShortDateString, _holidays(dt.ToShortDateString).ToShortDateString) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    'METHOD:    Private Sub LoadHolidays()
    'PURPOSE:   This sub routine will populate _holidays with all holidays that Top Priority has
    '           Observed in the past five years and will observe in the next 5 years.
    'NOTE:      This version hard-codes the holidays, but they should eventually come from a DB table
    '           or the logic can be programmed.
    Private Sub LoadHolidays()
        'Add Fourth of July
        _holidays.Add(#7/4/2001#)
        _holidays.Add(#7/4/2002#)
        _holidays.Add(#7/4/2003#)
        _holidays.Add(#7/4/2004#)
        _holidays.Add(#7/4/2005#)
        _holidays.Add(#7/4/2006#)
        _holidays.Add(#7/4/2007#)
        _holidays.Add(#7/4/2008#)
        _holidays.Add(#7/4/2009#)
        _holidays.Add(#7/4/2010#)

        'Add Thanksgiving
        _holidays.Add(#11/25/2001#)
        _holidays.Add(#11/25/2002#)
        _holidays.Add(#11/25/2003#)
        _holidays.Add(#11/25/2004#)
        _holidays.Add(#11/25/2005#)
        _holidays.Add(#11/25/2006#)
        _holidays.Add(#11/25/2007#)
        _holidays.Add(#11/25/2008#)
        _holidays.Add(#11/25/2009#)
        _holidays.Add(#11/25/2010#)

        'Add Christmas
        _holidays.Add(#12/25/2001#)
        _holidays.Add(#12/25/2002#)
        _holidays.Add(#12/25/2003#)
        _holidays.Add(#12/25/2004#)
        _holidays.Add(#12/25/2005#)
        _holidays.Add(#12/25/2006#)
        _holidays.Add(#12/25/2007#)
        _holidays.Add(#12/25/2008#)
        _holidays.Add(#12/25/2009#)
        _holidays.Add(#12/25/2010#)

        'Add New Year's Day
        _holidays.Add(#1/1/2001#)
        _holidays.Add(#1/1/2002#)
        _holidays.Add(#1/1/2003#)
        _holidays.Add(#1/1/2004#)
        _holidays.Add(#1/1/2005#)
        _holidays.Add(#1/1/2006#)
        _holidays.Add(#1/1/2007#)
        _holidays.Add(#1/1/2008#)
        _holidays.Add(#1/1/2009#)
        _holidays.Add(#1/1/2010#)
    End Sub
End Class
