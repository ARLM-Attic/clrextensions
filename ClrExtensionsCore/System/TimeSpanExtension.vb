Public Module TimeSpanExtension

    ''' <summary>
    ''' Adds a number of days to a TimeSpan, returning a new TimeSpan
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="days"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function AddDays(ByVal value As TimeSpan, ByVal days As Integer) As TimeSpan
        Return value.Add(New TimeSpan(days, 0, 0, 0))
    End Function

    ''' <summary>
    ''' Adds a number of hours to a TimeSpan, returning a new TimeSpan
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="hours"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function AddHours(ByVal value As TimeSpan, ByVal hours As Integer) As TimeSpan
        Return value.Add(New TimeSpan(hours, 0, 0))
    End Function

    ''' <summary>
    ''' Adds a number of minutes to a TimeSpan, returning a new TimeSpan
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="minutes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function AddMinutes(ByVal value As TimeSpan, ByVal minutes As Integer) As TimeSpan
        Return value.Add(New TimeSpan(0, minutes, 0))
    End Function

    ''' <summary>
    ''' Adds a number of seconds to a TimeSpan, returning a new TimeSpan
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="seconds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function AddSeconds(ByVal value As TimeSpan, ByVal seconds As Integer) As TimeSpan
        Return value.Add(New TimeSpan(0, 0, seconds))
    End Function

    ''' <summary>
    ''' Adds a number of milliseconds to a TimeSpan, returning a new TimeSpan
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="milliseconds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function AddMilliseconds(ByVal value As TimeSpan, ByVal milliseconds As Integer) As TimeSpan
        Return value.Add(New TimeSpan(0, 0, 0, 0, milliseconds))
    End Function

#If IncludeUntested Then

    ''' <summary>
    ''' Returns the greater of two time spans
    ''' </summary>
    ''' <param name="valueA"></param>
    ''' <param name="valueB"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> Public Function Max(ByVal valueA As TimeSpan, ByVal valueB As TimeSpan) As TimeSpan
        If valueA >= valueB Then Return valueA Else Return valueB
    End Function

    ''' <summary>
    ''' Returns the greator of a list of time spans
    ''' </summary>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> Public Function Max(ByVal ParamArray values() As TimeSpan) As TimeSpan
        Return values.Max
    End Function

    ''' <summary>
    ''' Returns the lessor of two time spans
    ''' </summary>
    ''' <param name="valueA"></param>
    ''' <param name="valueB"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> Public Function Min(ByVal valueA As TimeSpan, ByVal valueB As TimeSpan) As TimeSpan
        If valueA >= valueB Then Return valueA Else Return valueB
    End Function

    ''' <summary>
    ''' Returns the least of a list of time spans
    ''' </summary>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> Public Function Min(ByVal ParamArray values() As TimeSpan) As TimeSpan
        Return values.Max
    End Function


#End If

End Module
