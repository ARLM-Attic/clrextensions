
<Untested()> Public Class QuickEqualityComparer(Of T)
	Implements IEqualityComparer(Of T)

	Private m_EqualityFunction As Func(Of T, T, Boolean)
	Private m_HashingFunction As Func(Of T, Integer)

	''' <summary>
	''' 
	''' </summary>
	''' <param name="equalityFunction"></param>
	''' <remarks>The lack of a true hashing function will make this version slow</remarks>
	Public Sub New(ByVal equalityFunction As Func(Of T, T, Boolean))
		MyClass.New(equalityFunction, Nothing)
	End Sub

	Public Sub New(ByVal equalityFunction As Func(Of T, T, Boolean), ByVal hashingFunction As Func(Of T, Integer))
		m_EqualityFunction = equalityFunction
		m_HashingFunction = If(hashingFunction, Function(x As T) 0)
	End Sub

	Public Function IEqualityComparer_Equals(ByVal x As T, ByVal y As T) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of T).Equals
		Return m_EqualityFunction(x, y)
	End Function

	Public Function IEqualityComparer_GetHashCode(ByVal obj As T) As Integer Implements System.Collections.Generic.IEqualityComparer(Of T).GetHashCode
		Return m_HashingFunction(obj)
	End Function
End Class
