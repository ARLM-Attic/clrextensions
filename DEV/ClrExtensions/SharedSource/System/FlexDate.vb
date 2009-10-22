'Copyright (c) 2008, Jonathan Allen


#If IncludeUntested Then

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
    Private m_DateMode As FlexDateParts

    Private m_Year As Integer?
    Private m_Quarter As Integer?
    Private m_Month As Integer?
    Private m_WeekOfMonth As Integer?
    Private m_WeekOfYear As Integer?
    Private m_Day As Integer?

    <Untested()> Public Sub New(ByVal value As Date)
        m_Year = value.Year
        m_Month = value.Month
        m_Day = value.Day
    End Sub

    <Untested()> Public Sub New(ByVal year As Integer)
        m_Year = year
    End Sub

    <Untested()> Public Shared Function FromYearMonthDay(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer) As FlexDate
        Dim result As New FlexDate
        result.m_Year = year
        result.m_Month = month
        result.m_Day = day
        result.m_DateMode = FlexDateParts.YearMonthDay
        Return result
    End Function

    <Untested()> Public Shared Function FromYearMonthWeek(ByVal year As Integer, ByVal month As Integer, ByVal week As Integer) As FlexDate
        Dim result As New FlexDate
        result.m_Year = year
        result.m_Month = month
        result.m_WeekOfMonth = week
        result.m_DateMode = FlexDateParts.YearMonthWeek
        Return result
    End Function

    <Untested()> Public Shared Function FromYearMonth(ByVal year As Integer, ByVal month As Integer) As FlexDate
        Dim result As New FlexDate
        result.m_Year = year
        result.m_Month = month
        result.m_DateMode = FlexDateParts.YearMonthWeek
        Return result
    End Function

    <Untested()> Public Shared Function FromYearQuarter(ByVal year As Integer, ByVal quarter As Integer) As FlexDate
        Dim result As New FlexDate
        result.m_Year = year
        result.m_Quarter = quarter
        result.m_DateMode = FlexDateParts.YearQuarter
        Return result
    End Function

    <Untested()> Public Shared Function FromYear(ByVal year As Integer) As FlexDate
        Dim result As New FlexDate
        result.m_Year = year
        result.m_DateMode = FlexDateParts.Year
        Return result
    End Function

    <Untested()> Public ReadOnly Property DateParts() As FlexDateParts
        Get
            Return m_DateMode
        End Get
    End Property

    <Untested()> Public ReadOnly Property Day() As Integer?
        Get
            Return m_Day
        End Get
    End Property

    <Untested()> Public ReadOnly Property Month() As Integer?
        Get
            Return m_Month
        End Get
    End Property

    <Untested()> Public ReadOnly Property Quarter() As Integer?
        Get
            If m_Quarter.HasValue Then Return m_Quarter
            If m_Month.HasValue Then Return QuarterYear.MonthToQuarter(m_Month.Value)
            Return Nothing
        End Get
    End Property

    <Untested()> Public ReadOnly Property WeekOfMonth() As Integer?
        Get
            Return m_WeekOfMonth
        End Get
    End Property

    <Untested()> Public ReadOnly Property WeekOfYear() As Integer?
        Get
            Return m_WeekOfYear
        End Get
    End Property

    <Untested()> Public ReadOnly Property Year() As Integer?
        Get
            Return m_Year
        End Get
    End Property

End Structure

<Flags()> Public Enum FlexDateParts
	None = 0
	Year = 1
	WeekOfYear = 2
	Quarter = 4
	Month = 8
	WeekOfMonth = 16
	Day = 32

	YearWeek = Year Or WeekOfYear
	YearQuarter = Year Or Quarter
	YearMonth = Year Or Quarter Or Month
	YearMonthWeek = Year Or Quarter Or Month Or WeekOfMonth
	YearMonthDay = Year Or Quarter Or Month Or Day
End Enum

#End If

