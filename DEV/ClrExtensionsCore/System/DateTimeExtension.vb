'Copyright (c) 2008, Jonathan Allen

Public Module DateTimeExtension
    Private s_Calendar As New Globalization.GregorianCalendar

    ''' <summary>
    ''' Returns the first day in the month specified
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function FirstOfMonth(ByVal value As Date) As Date
        Return New Date(value.Year, value.Month, 1)
    End Function

    ''' <summary>
    ''' Returns the last day in the month specified
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function LastOfMonth(ByVal value As Date) As Date
        Return New Date(value.Year, value.Month, Date.DaysInMonth(value.Year, value.Month))
    End Function

    ''' <summary>
    ''' Returns the next date that falls on the indicated day of the week
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="dayofWeek"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function [Next](ByVal value As Date, ByVal dayofWeek As DayOfWeek) As Date
        Dim temp = dayofWeek - value.DayOfWeek
        If temp <= 0 Then
            Return value.Date.AddDays(7 + temp)
        Else
            Return value.Date.AddDays(temp)
        End If
    End Function

    ''' <summary>
    ''' Returns the previous date that falls on the indicated day of the week
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="dayofWeek"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function Previous(ByVal value As Date, ByVal dayofWeek As DayOfWeek) As Date
        Dim temp = value.DayOfWeek - dayofWeek
        If temp > 0 Then
            Return value.Date.AddDays(-temp)
        Else
            Return value.Date.AddDays(-7 - temp)
        End If
    End Function

    ''' <summary>
    ''' Returns the first date in the indicated month that lands on the given day.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="dayofWeek"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function FirstOfMonth(ByVal value As Date, ByVal dayofWeek As DayOfWeek) As Date
        Dim result = value.FirstOfMonth
        If result.DayOfWeek = dayofWeek Then
            Return result
        Else
            Return result.Next(dayofWeek)
        End If
    End Function

    ''' <summary>
    ''' Returns the late date in the indicated month that lands on the given day. 
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="dayofWeek"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function LastOfMonth(ByVal value As Date, ByVal dayofWeek As DayOfWeek) As Date
        Dim result = value.LastOfMonth
        If result.DayOfWeek = dayofWeek Then
            Return result
        Else
            Return result.Previous(dayofWeek)
        End If
    End Function

#If IncludeUntested Then

    ''' <summary>
    ''' Returns a DateTime with the time altered
    ''' </summary>
    ''' <param name="value">Date component</param>
    ''' <param name="hours">0 to 23</param>
    ''' <param name="minutes">0 to 59</param>
    ''' <param name="seconds">0 to 59</param>
    ''' <param name="milliseconds">0 to 999</param>
    ''' <returns></returns>
    ''' <remarks>Technically speaking there are 61 seconds in a minute every few years, but it looks like the .NET framework doesn't support it</remarks>
    <Untested()> <Extension()> Public Function SetTime(ByVal value As Date, ByVal hours As Integer, ByVal minutes As Integer, ByVal seconds As Integer, ByVal milliseconds As Integer) As Date
        If hours < 0 Or hours > 23 Then Throw New ArgumentOutOfRangeException("hours")
        If minutes < 0 Or minutes > 59 Then Throw New ArgumentOutOfRangeException("minutes")
        If seconds < 0 Or seconds > 59 Then Throw New ArgumentOutOfRangeException("seconds")
        If milliseconds < 0 Or milliseconds > 999 Then Throw New ArgumentOutOfRangeException("milliseconds")

        Return New Date(value.Year, value.Month, value.Day, hours, minutes, seconds, milliseconds)
    End Function

    ''' <summary>
    ''' Returns a DateTime with the time altered
    ''' </summary>
    ''' <param name="value">Date component</param>
    ''' <param name="hours">0 to 23</param>
    ''' <param name="minutes">0 to 59</param>
    ''' <param name="seconds">0 to 59</param>
    ''' <returns></returns>
    ''' <remarks>Technically speaking there are 61 seconds in a minute every few years, but it looks like the .NET framework doesn't support it</remarks>
    <Untested()> <Extension()> Public Function SetTime(ByVal value As Date, ByVal hours As Integer, ByVal minutes As Integer, ByVal seconds As Integer) As Date
        If hours < 0 Or hours > 23 Then Throw New ArgumentOutOfRangeException("hours")
        If minutes < 0 Or minutes > 59 Then Throw New ArgumentOutOfRangeException("minutes")
        If seconds < 0 Or seconds > 59 Then Throw New ArgumentOutOfRangeException("seconds")

        Return New Date(value.Year, value.Month, value.Day, hours, minutes, seconds)
    End Function

    ''' <summary>
    ''' Returns the Quarter for the indicated date
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Public Function Quarter(ByVal this As DateTime) As Integer
        Select Case this.Month
            Case 1 To 3 : Return 1
            Case 4 To 6 : Return 2
            Case 7 To 9 : Return 3
            Case 10 To 12 : Return 4
        End Select
    End Function

    ''' Returns a QuarterYear object for the indicated date
	<Untested()> <Extension()> Public Function ToQuarterYear(ByVal this As DateTime) As QuarterYear
		Return New QuarterYear(this)
	End Function

#End If

    ''' <summary>
    ''' Returns a DateTime with the time altered
    ''' </summary>
    ''' <param name="value">Date component</param>
    ''' <param name="hours"></param>
    ''' <param name="minutes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function SetTime(ByVal value As Date, ByVal hours As Integer, ByVal minutes As Integer) As Date
        If hours < 0 Or hours > 23 Then Throw New ArgumentOutOfRangeException("hours")
        If minutes < 0 Or minutes > 59 Then Throw New ArgumentOutOfRangeException("minutes")

        Return New Date(value.Year, value.Month, value.Day, hours, minutes, 0)
    End Function

    ''' <summary>
    ''' Returns a DateTime with the time altered
    ''' </summary>
    ''' <param name="value">Date component</param>
    ''' <param name="time">Time component, must be less than 1 day</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function SetTime(ByVal value As Date, ByVal time As TimeSpan) As Date
        If time.Days > 0 Then Throw New ArgumentOutOfRangeException("time", "Time exceeds one day. Use this.Date.Add(time) instead.")
        Return value.Date.Add(time)
    End Function

    'Todo: Look up how to create this date string. It is used for RSS feeds
    '<Extension()> Public Function ToRfc822DateString(ByVal this As Date) As String

    ''' <summary>
    ''' Returns true is the indicated date is between the start and end dates. This is an inclusive check.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="start"></param>
    ''' <param name="end"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function IsBetween(ByVal value As Date, ByVal start As Date, ByVal [end] As Date) As Boolean
        Return start <= value And value <= [end]
    End Function

    Public Function FromUnixTime(ByVal unixTime As Long) As Date
        Return UnixEpoch + TimeSpan.FromSeconds(unixTime)
    End Function

    <Extension()> Public Function ToUnixTime(ByVal value As Date) As Long
        Dim ts As TimeSpan = DirectCast((value.ToUniversalTime - UnixEpoch), TimeSpan)
        Return CLng(ts.TotalSeconds)
    End Function

    Public ReadOnly UnixEpoch As Date = New Date(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)

End Module


