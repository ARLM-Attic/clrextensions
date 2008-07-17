Namespace System.Collections
#If IncludeUntested Then
	<Untested()> Public Class Dictionary(Of TKey1, TKey2, TKey3, TValue)
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

		Public Function StoreAndReturn(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3, ByRef value As TValue) As TValue
			Me(key1, key2, key3) = value
			Return value
		End Function
	End Class
#End If
End Namespace
