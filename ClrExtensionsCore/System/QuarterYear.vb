Namespace System

#If IncludeUntested Then
    Public Structure QuarterYear
        Implements IEquatable(Of QuarterYear)
        Implements IComparable(Of QuarterYear)

        Private m_Year As Integer
        Private m_Quarter As Integer

        Public Sub New(ByVal value As Date)
            Me.New(value.Year, value.Quarter)
        End Sub

        Public Function AddQuarter(ByVal quarters As Integer) As QuarterYear
            Return New QuarterYear(FirstOfQuarter.AddMonths(quarters * 3))
        End Function

        Public Function AddYear(ByVal years As Integer) As QuarterYear
            Return New QuarterYear(FirstOfQuarter.AddYears(years))
        End Function

        Public Sub New(ByVal year As Integer, ByVal quarter As Integer)
            If quarter < 0 OrElse quarter > 4 Then Throw New ArgumentOutOfRangeException("quarter")
            m_Year = year
            m_Quarter = quarter
        End Sub

        Public ReadOnly Property Quarter() As Integer
            Get
                Return m_Quarter
            End Get
        End Property

        Public ReadOnly Property Year() As Integer
            Get
                Return m_Year
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return "Q" & m_Quarter & " " & m_Year
        End Function



        Public Function FirstOfQuarter() As Date
            Select Case Quarter
                Case 1 : Return New Date(m_Year, 1, 1)
                Case 2 : Return New Date(m_Year, 4, 1)
                Case 3 : Return New Date(m_Year, 7, 1)
                Case 4 : Return New Date(m_Year, 10, 1)
            End Select
        End Function

        Public Shared Function Now() As QuarterYear
            Return New QuarterYear(Date.Now)
        End Function

        Public Shared Function Range(ByVal start As QuarterYear, ByVal count As Integer) As List(Of QuarterYear)
            Dim result As New List(Of QuarterYear)
            result.Add(start)

            For i = 1 To count - 1
                result.Add(start.AddQuarter(i))
            Next

            Return result
        End Function

        Public Shared Function Range(ByVal start As QuarterYear, ByVal [end] As QuarterYear) As List(Of QuarterYear)
            If start < [end] Then Return New List(Of QuarterYear)

            Dim result As New List(Of QuarterYear)
            Dim temp = start
            Do
                result.Add(temp)
            Loop While temp < [end]

            Return result
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return m_Year.GetHashCode Xor m_Quarter.GetHashCode
        End Function

        Public Shared Operator >(ByVal left As QuarterYear, ByVal right As QuarterYear) As Boolean
            If left.Year > right.Year Then Return True
            If left.Year < right.Year Then Return False

            If left.Quarter > right.Quarter Then Return True
            Return False
        End Operator

        Public Shared Operator <(ByVal left As QuarterYear, ByVal right As QuarterYear) As Boolean
            If left.Year < right.Year Then Return True
            If left.Year > right.Year Then Return False

            If left.Quarter < right.Quarter Then Return True
            Return False
        End Operator


        Public Shared Operator >=(ByVal left As QuarterYear, ByVal right As QuarterYear) As Boolean
            If left.Year > right.Year Then Return True
            If left.Year < right.Year Then Return False

            If left.Quarter >= right.Quarter Then Return True
            Return False
        End Operator

        Public Shared Operator <=(ByVal left As QuarterYear, ByVal right As QuarterYear) As Boolean
            If left.Year < right.Year Then Return True
            If left.Year > right.Year Then Return False

            If left.Quarter <= right.Quarter Then Return True
            Return False
        End Operator


        Public Shared Operator =(ByVal quarter1 As QuarterYear, ByVal quarter2 As QuarterYear) As Boolean
            Return quarter1.Equals(quarter2)
        End Operator

        Public Shared Operator <>(ByVal quarter1 As QuarterYear, ByVal quarter2 As QuarterYear) As Boolean
            Return Not (quarter1 = quarter2)
        End Operator

        Public Overloads Function Equals(ByVal other As QuarterYear) As Boolean Implements Global.System.IEquatable(Of QuarterYear).Equals
            Return Quarter = other.Quarter AndAlso Year = other.Year
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is QuarterYear Then Return CType(obj, QuarterYear) = Me
        End Function

        Public Function CompareTo(ByVal other As QuarterYear) As Integer Implements Global.System.IComparable(Of QuarterYear).CompareTo
            If Me > other Then Return 1
            If Me < other Then Return -1
            Return 0
        End Function


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


End Namespace
