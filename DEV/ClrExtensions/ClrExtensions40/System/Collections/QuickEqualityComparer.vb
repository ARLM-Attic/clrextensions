'Copyright (c) 2008, Jonathan Allen

Namespace Collections
#If IncludeUntested Then

	''' <summary>
	''' This creates a new IEqualityComparer object from a pair of functions
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <remarks></remarks>
    Public Class QuickEqualityComparer(Of T)
        Implements IEqualityComparer(Of T)

        Private ReadOnly m_EqualityFunction As Func(Of T, T, Boolean)
        Private ReadOnly m_HashingFunction As Func(Of T, Integer)

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="equalityFunction"></param>
        ''' <remarks>The lack of a true hashing function will make this version slow, don't use it when working with dictionaries</remarks>
        <Untested()>
        Sub New(ByVal equalityFunction As Func(Of T, T, Boolean))
            MyClass.New(equalityFunction, Nothing)
        End Sub

        <Untested()>
        Sub New(ByVal equalityFunction As Func(Of T, T, Boolean), ByVal hashingFunction As Func(Of T, Integer))
            If equalityFunction Is Nothing Then Throw New ArgumentNullException("equalityFunction")
            If hashingFunction Is Nothing Then Throw New ArgumentNullException("hashingFunction")

            m_EqualityFunction = equalityFunction
            m_HashingFunction = If(hashingFunction, Function(x As T) 0)
        End Sub

        <Untested()>
        Private Function IEqualityComparer_Equals(ByVal x As T, ByVal y As T) As Boolean Implements Global.System.Collections.Generic.IEqualityComparer(Of T).Equals
            Return m_EqualityFunction(x, y)
        End Function

        <Untested()>
        Private Function IEqualityComparer_GetHashCode(ByVal obj As T) As Integer Implements Global.System.Collections.Generic.IEqualityComparer(Of T).GetHashCode
            Return m_HashingFunction(obj)
        End Function
    End Class
#End If
End Namespace