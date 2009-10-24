'Copyright (c) 2008, Jonathan Allen


#If IncludeUntested Then

''' <summary>
''' This represents quarter-year pair such as "Q2 2008"
''' </summary>
''' <remarks></remarks>
Public Structure QuarterYear
	Implements IEquatable(Of QuarterYear)
	Implements IComparable(Of QuarterYear)

	Private m_Year As Integer
	Private m_Quarter As Integer

	''' <summary>
	''' The date to base the QuarterYear on
	''' </summary>
	''' <param name="value"></param>
	''' <remarks></remarks>
    <Untested()>
    Public Sub New(ByVal value As Date)
        Me.New(value.Year, value.Quarter)
    End Sub

	''' <summary>
	''' Returns a new QuarterYear by adding N quarters the indicated QuarterYear
	''' </summary>
	''' <param name="quarters"></param>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public Function AddQuarter(ByVal quarters As Integer) As QuarterYear
        Return New QuarterYear(FirstOfQuarter.AddMonths(quarters * 3))
    End Function

	''' <summary>
	''' Returns a new QuarterYear by adding N years the indicated QuarterYear
	''' </summary>
	''' <param name="years"></param>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public Function AddYear(ByVal years As Integer) As QuarterYear
        Return New QuarterYear(FirstOfQuarter.AddYears(years))
    End Function

	''' <summary>
	''' Returns a new QuarterYear based on the quarter and year
	''' </summary>
	''' <param name="year"></param>
	''' <param name="quarter"></param>
	''' <remarks></remarks>
    <Untested()>
    Public Sub New(ByVal year As Integer, ByVal quarter As Integer)
        If quarter < 0 OrElse quarter > 4 Then Throw New ArgumentOutOfRangeException("quarter")
        m_Year = year
        m_Quarter = quarter
    End Sub

	''' <summary>
	''' Returns the quarter
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public ReadOnly Property Quarter() As Integer
        Get
            Return m_Quarter
        End Get
    End Property

	''' <summary>
	''' Returns the year
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public ReadOnly Property Year() As Integer
        Get
            Return m_Year
        End Get
    End Property

	''' <summary>
	''' Returns the value in Q# #### format. e.g. "Q2 2008"
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public Overrides Function ToString() As String
        Return "Q" & m_Quarter & " " & m_Year
    End Function

	''' <summary>
	''' Returns the first date in a give QuarterYear
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public Function FirstOfQuarter() As Date
        Return FirstOfQuarter(Quarter, Year)
    End Function

	''' <summary>
	''' Returns the first date in a give quarter/year
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public Shared Function FirstOfQuarter(ByVal quarter As Integer, ByVal year As Integer) As Date
        Select Case quarter
            Case 1 : Return New Date(year, 1, 1)
            Case 2 : Return New Date(year, 4, 1)
            Case 3 : Return New Date(year, 7, 1)
            Case 4 : Return New Date(year, 10, 1)
        End Select
    End Function

	''' <summary>
	''' Returns the current QuarterYear
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public Shared Function Now() As QuarterYear
        Return New QuarterYear(Date.Now)
    End Function

	''' <summary>
	''' Creates a list of QuarterYears starting at a given QuarterYear
	''' </summary>
	''' <param name="start"></param>
	''' <param name="count">Number of QuarterYears to return</param>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public Shared Function Range(ByVal start As QuarterYear, ByVal count As Integer) As List(Of QuarterYear)
        Dim result As New List(Of QuarterYear)
        result.Add(start)

        For i = 1 To count - 1
            result.Add(start.AddQuarter(i))
        Next

        Return result
    End Function

	''' <summary>
	''' Creates a list of QuarterYears starting at a given QuarterYear
	''' </summary>
	''' <param name="start"></param>
	'''<param name="end">Last quarter to return</param>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public Shared Function Range(ByVal start As QuarterYear, ByVal [end] As QuarterYear) As List(Of QuarterYear)
        If start < [end] Then Return New List(Of QuarterYear)

        Dim result As New List(Of QuarterYear)
        Dim temp = start
        Do
            result.Add(temp)
        Loop While temp < [end]

        Return result
    End Function

    <Untested()>
    Public Overrides Function GetHashCode() As Integer
        Return m_Year.GetHashCode Xor m_Quarter.GetHashCode
    End Function

    <Untested()>
    Public Shared Operator >(ByVal left As QuarterYear, ByVal right As QuarterYear) As Boolean
        If left.Year > right.Year Then Return True
        If left.Year < right.Year Then Return False

        If left.Quarter > right.Quarter Then Return True
        Return False
    End Operator

    <Untested()>
    Public Shared Operator <(ByVal left As QuarterYear, ByVal right As QuarterYear) As Boolean
        If left.Year < right.Year Then Return True
        If left.Year > right.Year Then Return False

        If left.Quarter < right.Quarter Then Return True
        Return False
    End Operator


    <Untested()>
    Public Shared Operator >=(ByVal left As QuarterYear, ByVal right As QuarterYear) As Boolean
        If left.Year > right.Year Then Return True
        If left.Year < right.Year Then Return False

        If left.Quarter >= right.Quarter Then Return True
        Return False
    End Operator

    <Untested()>
    Public Shared Operator <=(ByVal left As QuarterYear, ByVal right As QuarterYear) As Boolean
        If left.Year < right.Year Then Return True
        If left.Year > right.Year Then Return False

        If left.Quarter <= right.Quarter Then Return True
        Return False
    End Operator


    <Untested()>
    Public Shared Operator =(ByVal quarter1 As QuarterYear, ByVal quarter2 As QuarterYear) As Boolean
        Return quarter1.Equals(quarter2)
    End Operator

    <Untested()>
    Public Shared Operator <>(ByVal quarter1 As QuarterYear, ByVal quarter2 As QuarterYear) As Boolean
        Return Not (quarter1 = quarter2)
    End Operator

    <Untested()>
    Public Overloads Function Equals(ByVal other As QuarterYear) As Boolean Implements Global.System.IEquatable(Of QuarterYear).Equals
        Return Quarter = other.Quarter AndAlso Year = other.Year
    End Function

    <Untested()>
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is QuarterYear Then Return CType(obj, QuarterYear) = Me
    End Function

    <Untested()>
    Public Function CompareTo(ByVal other As QuarterYear) As Integer Implements Global.System.IComparable(Of QuarterYear).CompareTo
        If Me > other Then Return 1
        If Me < other Then Return -1
        Return 0
    End Function

	''' <summary>
	''' Returns the Quarter for a given Month
	''' </summary>
	''' <param name="month"></param>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()>
    Public Shared Function MonthToQuarter(ByVal month As Integer) As Integer
        Select Case month
            Case 1 To 3 : Return 1
            Case 4 To 6 : Return 2
            Case 7 To 9 : Return 3
            Case 10 To 12 : Return 4
        End Select
    End Function

End Structure

#End If


