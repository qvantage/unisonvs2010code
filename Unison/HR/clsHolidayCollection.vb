Public Class clsHolidayCollection
    Inherits System.Collections.CollectionBase

    Private _shortDateHashtable As New Hashtable

    Public ReadOnly Property ShortDateHashtable() As Hashtable
        Get
            Return _shortDateHashtable
        End Get
    End Property

    Public Sub Add(ByVal newHoliday As Date)
        Me.List.Add(newHoliday)
        ShortDateHashtable.Add(newHoliday.ToShortDateString, newHoliday)
    End Sub

    Default Public ReadOnly Property Item(ByVal strDate As String) As Date
        Get
            Return CDate(ShortDateHashtable.Item(strDate))
        End Get
    End Property

    Public Sub Remove(ByVal removeHoliday As Date)
        Me.List.Remove(removeHoliday)
    End Sub
End Class
