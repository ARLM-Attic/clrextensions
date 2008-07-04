Module Scratch
	Sub test()
	End Sub


End Module

<Obsolete("Untested")> Public Structure Tuple(Of TA, TB)
	Implements IEquatable(Of Tuple(Of TA, TB))

	Private m_A As TA
	Private m_B As TB

	Public ReadOnly Property B() As TB
		Get
			Return m_B
		End Get
	End Property

	Public ReadOnly Property A() As TA
		Get
			Return m_A
		End Get
	End Property

	Public Sub New(ByVal a As TA, ByVal b As TB)
		m_A = a
		m_B = b
	End Sub

	Public Overrides Function Equals(ByVal obj As Object) As Boolean
		If Not TypeOf obj Is Tuple(Of TA, TB) Then Return False
		Return Me.Equals(DirectCast(obj, Tuple(Of TA, TB)))
	End Function

	Public Overrides Function GetHashCode() As Integer
		Dim result = 0

		If m_A IsNot Nothing Then result = result Xor m_A.GetHashCode
		If m_B IsNot Nothing Then result = result Xor m_B.GetHashCode

		Return result
	End Function

	Public Overloads Function Equals(ByVal other As Tuple(Of TA, TB)) As Boolean Implements System.IEquatable(Of Tuple(Of TA, TB)).Equals
		Return Object.Equals(A, other.A) AndAlso Object.Equals(B, other.B)
	End Function
End Structure


<Obsolete("Untested")> Public Structure Tuple(Of TA, TB, TC)
	Implements IEquatable(Of Tuple(Of TA, TB, TC))

	Private m_A As TA
	Private m_B As TB
	Private m_C As TC

	Public ReadOnly Property C() As TC
		Get
			Return m_C
		End Get
	End Property

	Public ReadOnly Property B() As TB
		Get
			Return m_B
		End Get
	End Property

	Public ReadOnly Property A() As TA
		Get
			Return m_A
		End Get
	End Property

	Public Sub New(ByVal a As TA, ByVal b As TB, ByVal c As TC)
		m_A = a
		m_B = b
		m_C = c
	End Sub

	Public Overrides Function Equals(ByVal obj As Object) As Boolean
		If Not TypeOf obj Is Tuple(Of TA, TB, TC) Then Return False
		Return Me.Equals(DirectCast(obj, Tuple(Of TA, TB, TC)))
	End Function


	Public Overrides Function GetHashCode() As Integer
		Dim result = 0

		If m_A IsNot Nothing Then result = result Xor m_A.GetHashCode
		If m_B IsNot Nothing Then result = result Xor m_B.GetHashCode
		If m_C IsNot Nothing Then result = result Xor m_C.GetHashCode

		Return result
	End Function

	Public Overloads Function Equals(ByVal other As Tuple(Of TA, TB, TC)) As Boolean Implements System.IEquatable(Of Tuple(Of TA, TB, TC)).Equals
		Return Object.Equals(A, other.A) AndAlso Object.Equals(B, other.B) AndAlso Object.Equals(C, other.c)
	End Function
End Structure

<Obsolete("Untested")> Public Class Dictionary(Of TKey1, TKey2, TValue)
	Inherits Dictionary(Of Tuple(Of TKey1, TKey2), TValue)

	Private Shared Function MakeKey(ByVal key1 As TKey1, ByVal key2 As TKey2) As Tuple(Of TKey1, TKey2)
		Return New Tuple(Of TKey1, TKey2)(key1, key2)
	End Function

	Public Overloads Sub Add(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal value As TValue)
		MyBase.Add(MakeKey(key1, key2), value)
	End Sub

	Default Public Overloads Property Item(ByVal key1 As TKey1, ByVal key2 As TKey2) As TValue
		Get
			Return MyBase.Item(MakeKey(key1, key2))
		End Get
		Set(ByVal value As TValue)
			MyBase.Item(MakeKey(key1, key2)) = value
		End Set
	End Property

	Public Overloads Function ContainsKey(ByVal key1 As TKey1, ByVal key2 As TKey2) As Boolean
		Return MyBase.ContainsKey(MakeKey(key1, key2))
	End Function

	Public Overloads Function Remove(ByVal key1 As TKey1, ByVal key2 As TKey2) As Boolean
		Return MyBase.Remove(MakeKey(key1, key2))
	End Function

	Public Overloads Function TryGetValue(ByVal key1 As TKey1, ByVal key2 As TKey2, ByRef value As TValue) As Boolean
		Return MyBase.TryGetValue(MakeKey(key1, key2), value)
	End Function
End Class

<Obsolete("Untested")> Public Class Dictionary(Of TKey1, TKey2, TKey3, TValue)
	Inherits Dictionary(Of Tuple(Of TKey1, TKey2, TKey3), TValue)

	Public Sub New()

	End Sub
	Public Sub New(ByVal capacity As Integer)
		MyBase.New(capacity)
	End Sub

	Private Shared Function MakeKey(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3) As Tuple(Of TKey1, TKey2, TKey3)
		Return New Tuple(Of TKey1, TKey2, TKey3)(key1, key2, key3)
	End Function

	Public Overloads Sub Add(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3, ByVal value As TValue)
		MyBase.Add(MakeKey(key1, key2, key3), value)
	End Sub

	Default Public Overloads Property Item(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3) As TValue
		Get
			Return MyBase.Item(MakeKey(key1, key2, key3))
		End Get
		Set(ByVal value As TValue)
			MyBase.Item(MakeKey(key1, key2, key3)) = value
		End Set
	End Property

	Public Overloads Function ContainsKey(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3) As Boolean
		Return MyBase.ContainsKey(MakeKey(key1, key2, key3))
	End Function

	Public Overloads Function Remove(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3) As Boolean
		Return MyBase.Remove(MakeKey(key1, key2, key3))
	End Function

	Public Overloads Function TryGetValue(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3, ByRef value As TValue) As Boolean
		Return MyBase.TryGetValue(MakeKey(key1, key2, key3), value)
	End Function

End Class


