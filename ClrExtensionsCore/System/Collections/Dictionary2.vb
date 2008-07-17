Namespace System.Collections

#If IncludeUntested Then
	<Untested()> Public Class Dictionary(Of TKey1, TKey2, TValue)
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

		Public Function StoreAndReturn(ByVal key1 As TKey1, ByVal key2 As TKey2, ByRef value As TValue) As TValue
			Me(key1, key2) = value
			Return value
		End Function
	End Class
#End If
End Namespace
