#If IncludeUntested Then
Public Class Range(Of T)
    Private ReadOnly m_Start As T
    Private ReadOnly m_End As T
    Private ReadOnly m_Options As RangeOptions
    Private ReadOnly m_Comparer As IComparer(Of T)

    <Untested()>
    Public ReadOnly Property Options() As RangeOptions
        Get
            Return m_Options
        End Get
    End Property

    <Untested()>
Public ReadOnly Property [End]() As T
        Get
            Return m_End
        End Get
    End Property

    <Untested()>
    Public ReadOnly Property Start() As T
        Get
            Return m_Start
        End Get
    End Property

    <Untested()>
    Public Sub New(ByVal start As T, ByVal [end] As T, ByVal comparer As IComparer(Of T), ByVal options As RangeOptions)
        m_Start = start
        m_End = [end]
        m_Options = options
        m_Comparer = comparer
    End Sub

    <Untested()>
    Public Sub New(ByVal start As T, ByVal [end] As T, ByVal options As RangeOptions)
        If Not GetType(IComparable(Of T)).IsAssignableFrom(GetType(T)) Then
            Throw New ArgumentException("T doesn't implement IComparable and a IComparer wasn't supplied")
        End If
        m_Start = start
        m_End = [end]
        m_Options = options
        m_Comparer = New ComparableExtension.ComparerComparable(Of T)
    End Sub

    <Untested()>
    Public Function Contains(ByVal testValue As T) As Boolean
        Select Case m_Options
            Case RangeOptions.IncludeBoth
                Return m_Comparer.Compare(m_Start, testValue) >= 0 AndAlso m_Comparer.Compare(testValue, m_End) <= 0
            Case RangeOptions.ExcludeStart
                Return m_Comparer.Compare(m_Start, testValue) > 0 AndAlso m_Comparer.Compare(testValue, m_End) <= 0
            Case RangeOptions.ExcludeEnd
                Return m_Comparer.Compare(m_Start, testValue) >= 0 AndAlso m_Comparer.Compare(testValue, m_End) < 0
            Case RangeOptions.ExcludeBoth
                Return m_Comparer.Compare(m_Start, testValue) > 0 AndAlso m_Comparer.Compare(testValue, m_End) < 0
            Case Else
                Throw New InvalidOperationException
        End Select
    End Function

    <Untested()>
    Public ReadOnly Property IncludesStart() As Boolean
        Get
            Return CBool(Not (m_Options And RangeOptions.ExcludeStart))
        End Get
    End Property

    <Untested()>
    Public ReadOnly Property IncludesEnd() As Boolean
        Get
            Return CBool(Not (m_Options And RangeOptions.ExcludeEnd))
        End Get
    End Property

    <Untested()>
    Public Function FromStart(ByVal stepFunction As Func(Of T, T)) As IEnumerator(Of T)
        Return New RangeEnumerator(m_Start, m_End, m_Comparer, stepFunction)
    End Function

    <Untested()>
    Public Function FromEnd(ByVal stepFunction As Func(Of T, T)) As IEnumerator(Of T)
        Return New RangeEnumerator(m_End, m_Start, m_Comparer.Reverse, stepFunction)
    End Function

    'TODO - Impement Operator.Add
    'Public Function FromStart(ByVal [step] As T) As IEnumerator(Of T)
    '	Return New RangeEnumerator(m_Start, m_End, m_Comparer, Function(base) Operator.Add(base, [step]))
    'End Function
    'Public Function FromStart(ByVal [step] As T) As IEnumerator(Of T)
    '	Return New RangeEnumerator(m_Start, m_End, m_Comparer, Function(base) Operator.Add(base, [step]))
    'End Function


    Private Class RangeEnumerator
        Implements IEnumerator(Of T)

        'TODO - this should honor the options set in the Range object
        'TODO - we don't need to keep a local copy of start, end, and comparer
        'TODO - Check both ends of the range instead of using reversing the comparer

        Private m_Current As T
        Private ReadOnly m_Start As T
        Private ReadOnly m_End As T
        Private ReadOnly m_StepFunction As Func(Of T, T)
        Private ReadOnly m_Comparer As IComparer(Of T)
        Private m_Reset As Boolean = True

        <Untested()>
            Public Sub New(ByVal start As T, ByVal [end] As T, ByVal comparer As IComparer(Of T), ByVal stepFunction As Func(Of T, T))
            m_Start = start
            m_End = [end]
            m_Comparer = comparer
            m_StepFunction = stepFunction
        End Sub


        <Untested()>
        Private ReadOnly Property Current() As T Implements Global.System.Collections.Generic.IEnumerator(Of T).Current
            Get
                If m_Reset Then Return Nothing Else Return m_Current
            End Get
        End Property

        <Untested()>
        Private ReadOnly Property Current1() As Object Implements Global.System.Collections.IEnumerator.Current
            Get
                Return Current
            End Get
        End Property

        <Untested()>
            Private Function MoveNext() As Boolean Implements Global.System.Collections.IEnumerator.MoveNext
            If m_Reset Then m_Current = m_Start Else m_Current = m_StepFunction(m_Current)
            Return m_Comparer.Compare(m_Current, m_End) <= 0
        End Function

        <Untested()>
            Public Sub Reset() Implements Global.System.Collections.IEnumerator.Reset
            m_Reset = True
        End Sub

        <Untested()>
            Private Sub Dispose() Implements IDisposable.Dispose
        End Sub

    End Class

End Class




<Flags()> Public Enum RangeOptions
	IncludeBoth = 0
	ExcludeStart = 1
	ExcludeEnd = 2
	ExcludeBoth = ExcludeStart Or ExcludeEnd
End Enum

#End If