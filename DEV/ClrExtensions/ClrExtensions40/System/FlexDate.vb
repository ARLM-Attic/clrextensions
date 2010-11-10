'Copyright (c) 2008, Jonathan Allen


#If 1 = 1 Then

'TODO: Look up the new Java RFC on partial dates, it could be very useful here

''' <summary>
''' This class is used to represent a date that can be a Year, Quarter-Year, Month-Year, Week-Month-Year, or Day-Month-Year
''' Use this when "The First Week of June, 1997" means something explicitly different from "A day in First Week of June, 1997"
''' 
''' Sorting will compare fields in this order: Year, Quarter, Month, Week, Day
''' Fields that are blank sort before fields with a value
''' 
''' Having a year, month, and day isn't enough to calculate the Week as there are about a dozen different methods of calculation
''' Maybe we can derive this from the culture
''' 
''' </summary>
''' <remarks></remarks>
Public Structure FlexDate
    Implements IEquatable(Of FlexDate)
    Implements IComparable(Of FlexDate)

    Private m_DateMode As FlexDateParts

    Private m_Year As Integer?
    Private m_Quarter As Integer?
    Private m_Month As Integer?
    Private m_WeekOfMonth As Integer?
    Private m_WeekOfYear As Integer?
    Private m_Day As Integer?


    Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is FlexDate Then
            Return Equals(DirectCast(obj, FlexDate))
        Else
            Return False
        End If
    End Function


    Overrides Function GetHashCode() As Integer
        Return m_DateMode Xor
            m_Year.GetHashCode Xor
            m_WeekOfYear.GetHashCode Xor
            m_WeekOfMonth.GetHashCode Xor
            m_Month.GetHashCode Xor
            m_Quarter.GetHashCode Xor
            m_Day.GetHashCode
    End Function


    Shared Operator =(ByVal date1 As FlexDate, ByVal date2 As FlexDate) As Boolean
        Return date1.Equals(date2)
    End Operator


    Shared Operator <>(ByVal date1 As FlexDate, ByVal date2 As FlexDate) As Boolean
        Return Not (date1 = date2)
    End Operator

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId:="FlexDate")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")>
    Overloads Function Equals(ByVal other As FlexDate) As Boolean Implements System.IEquatable(Of FlexDate).Equals
        With other
            Select Case m_DateMode
                Case FlexDateParts.Day
                    Return Day = .Day

                Case FlexDateParts.Month
                    Return Month = .Month

                Case FlexDateParts.Quarter
                    Return Quarter = .Quarter

                Case FlexDateParts.WeekOfMonth
                    Return WeekOfMonth = .WeekOfMonth

                Case FlexDateParts.WeekOfYear
                    Return WeekOfYear = .WeekOfYear

                Case FlexDateParts.Year
                    Return Year = .Year

                Case FlexDateParts.YearMonth
                    Return Year = .Year And Month = .Month

                Case FlexDateParts.YearMonthDay
                    Return Year = .Year And Month = .Month And Day = .Day

                Case FlexDateParts.YearMonthWeek
                    Return Year = .Year And Month = .Month And WeekOfMonth = .WeekOfYear

                Case FlexDateParts.YearQuarter
                    Return Year = .Year And Quarter = .Quarter

                Case FlexDateParts.YearWeekOfYear
                    Return Year = .Year And WeekOfYear = .WeekOfYear

                Case Else
                    Throw New InvalidOperationException("This FlexDate is malformed.")
            End Select
        End With
    End Function

    Sub New(ByVal value As Date)
        m_Year = value.Year
        m_Month = value.Month
        m_Day = value.Day
    End Sub

    Sub New(ByVal year As Integer)
        m_Year = year
    End Sub

    Shared Function FromYearMonthDay(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer) As FlexDate
        Dim result As New FlexDate
        result.m_Year = year
        result.m_Month = month
        result.m_Day = day
        result.m_DateMode = FlexDateParts.YearMonthDay
        Return result
    End Function

    Shared Function FromYearMonthWeek(ByVal year As Integer, ByVal month As Integer, ByVal week As Integer) As FlexDate
        Dim result As New FlexDate
        result.m_Year = year
        result.m_Month = month
        result.m_WeekOfMonth = week
        result.m_DateMode = FlexDateParts.YearMonthWeek
        Return result
    End Function

    Shared Function FromYearMonth(ByVal year As Integer, ByVal month As Integer) As FlexDate
        Dim result As New FlexDate
        result.m_Year = year
        result.m_Month = month
        result.m_DateMode = FlexDateParts.YearMonthWeek
        Return result
    End Function

    Shared Function FromYearQuarter(ByVal year As Integer, ByVal quarter As Integer) As FlexDate
        Dim result As New FlexDate
        result.m_Year = year
        result.m_Quarter = quarter
        result.m_DateMode = FlexDateParts.YearQuarter
        Return result
    End Function

    Shared Function FromYear(ByVal year As Integer) As FlexDate
        Dim result As New FlexDate
        result.m_Year = year
        result.m_DateMode = FlexDateParts.Year
        Return result
    End Function

    ReadOnly Property DateParts() As FlexDateParts
        Get
            Return m_DateMode
        End Get
    End Property

    ReadOnly Property Day() As Integer
        Get
            If Not m_Day.HasValue Then Throw New InvalidOperationException("This value doesn't not have a day component")
            Return m_Day.Value
        End Get
    End Property

    ReadOnly Property Month() As Integer
        Get
            If Not m_Month.HasValue Then Throw New InvalidOperationException("This value doesn't not have a month component")
            Return m_Month.Value
        End Get
    End Property

    ReadOnly Property Quarter() As Integer
        Get
            If Not m_Quarter.HasValue And Not m_Month.HasValue Then Throw New InvalidOperationException("This value doesn't not have a quarter component")
            If m_Quarter.HasValue Then Return m_Quarter.Value
            Return QuarterYear.MonthToQuarter(m_Month.Value)
        End Get
    End Property

    ReadOnly Property WeekOfMonth() As Integer
        Get
            If Not m_WeekOfMonth.HasValue Then Throw New InvalidOperationException("This value doesn't not have a week of month component")
            Return m_WeekOfMonth.Value
        End Get
    End Property

    ReadOnly Property WeekOfYear() As Integer
        Get
            If Not m_WeekOfYear.HasValue Then Throw New InvalidOperationException("This value doesn't not have a week of year component")
            Return m_WeekOfYear.Value
        End Get
    End Property

    ReadOnly Property Year() As Integer
        Get
            If Not m_Year.HasValue Then Throw New InvalidOperationException("This value doesn't not have a year component")
            Return m_Year.Value
        End Get
    End Property

    Shared Operator >(ByVal date1 As FlexDate, ByVal date2 As FlexDate) As Boolean
        Return date1.CompareTo(date2) > 0
    End Operator

    Shared Operator <(ByVal date1 As FlexDate, ByVal date2 As FlexDate) As Boolean
        Return date1.CompareTo(date2) < 0
    End Operator

    Shared Operator >=(ByVal date1 As FlexDate, ByVal date2 As FlexDate) As Boolean
        Return date1.CompareTo(date2) >= 0
    End Operator

    Shared Operator <=(ByVal date1 As FlexDate, ByVal date2 As FlexDate) As Boolean
        Return date1.CompareTo(date2) <= 0
    End Operator

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> Function CompareTo(ByVal other As FlexDate) As Integer Implements System.IComparable(Of FlexDate).CompareTo
        With other
            Select Case m_DateMode
                Case FlexDateParts.Day
                    Return Day - .Day

                Case FlexDateParts.Month
                    Return Month - .Month

                Case FlexDateParts.Quarter
                    Return Quarter - .Quarter

                Case FlexDateParts.WeekOfMonth
                    Return WeekOfMonth - .WeekOfMonth

                Case FlexDateParts.WeekOfYear
                    Return WeekOfYear - .WeekOfYear

                Case FlexDateParts.Year
                    Return Year - .Year

                Case FlexDateParts.YearMonth
                    If Year = .Year Then Return Month - .Month
                    Return Year - .Year

                Case FlexDateParts.YearMonthDay
                    If Year = .Year Then
                        If Month = .Month Then Return Day - .Day
                        Return Month - .Month
                    End If
                    Return Year - .Year

                Case FlexDateParts.YearMonthWeek
                    If Year = .Year Then
                        If Month = .Month Then Return WeekOfMonth - .WeekOfMonth
                        Return Month - .Month
                    End If
                    Return Year - .Year

                Case FlexDateParts.YearQuarter
                    If Year = .Year Then Return Quarter - .Quarter
                    Return Year - .Year

                Case FlexDateParts.YearWeekOfYear
                    If Year = .Year Then Return WeekOfYear - .WeekOfYear
                    Return Year - .Year

                Case Else
                    Throw New InvalidOperationException
            End Select
        End With

    End Function

    Shared Function Comparable(ByVal date1 As FlexDate, ByVal date2 As FlexDate) As Boolean
        Return Comparable(date1.DateParts, date2.DateParts)
    End Function

    Shared Function Comparable(ByVal datePart1 As FlexDateParts, ByVal datePart2 As FlexDateParts) As Boolean
        Return datePart1 = datePart2
    End Function

End Structure

<Flags()> Public Enum FlexDateParts
    None = 0
    Year = 1
    WeekOfYear = 2
    Quarter = 4
    Month = 8
    WeekOfMonth = 16
    Day = 32

    YearWeekOfYear = Year Or WeekOfYear
    YearQuarter = Year Or Quarter
    YearMonth = Year Or Quarter Or Month
    YearMonthWeek = Year Or Quarter Or Month Or WeekOfMonth
    YearMonthDay = Year Or Quarter Or Month Or Day
End Enum

#End If

