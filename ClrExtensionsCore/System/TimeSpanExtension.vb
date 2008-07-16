Public Module TimeSpanExtension


    <Extension()> Public Function AddDays(ByVal value As TimeSpan, ByVal days As Integer) As TimeSpan
        Return value.Add(New TimeSpan(days, 0, 0, 0))
    End Function

    <Extension()> Public Function AddHours(ByVal value As TimeSpan, ByVal hours As Integer) As TimeSpan
        Return value.Add(New TimeSpan(hours, 0, 0))
    End Function

    <Extension()> Public Function AddMinutes(ByVal value As TimeSpan, ByVal minutes As Integer) As TimeSpan
        Return value.Add(New TimeSpan(0, minutes, 0))
    End Function

    <Extension()> Public Function AddSeconds(ByVal value As TimeSpan, ByVal seconds As Integer) As TimeSpan
        Return value.Add(New TimeSpan(0, 0, seconds))
    End Function

    <Extension()> Public Function AddMilliseconds(ByVal value As TimeSpan, ByVal milliseconds As Integer) As TimeSpan
        Return value.Add(New TimeSpan(0, 0, 0, 0, milliseconds))
    End Function

End Module
