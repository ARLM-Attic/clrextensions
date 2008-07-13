Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.InteropServices

<Serializable()> _
<DebuggerDisplay("Count = {Count}")> _
<ComVisible(False)> _
<Untested()> Public Class SortedList(Of T)
	Implements IList(Of T)
	Implements IList

	Private ReadOnly m_Values As New List(Of T)
	Private ReadOnly m_Comparer As IComparer(Of T)

	Private Class ComparerWrapper
		Implements IComparer(Of T)
		Private ReadOnly m_ComparisonFunction As Func(Of T, T, Integer)

		Public Sub New(ByVal comparisonFunction As Func(Of T, T, Integer))
			m_ComparisonFunction = comparisonFunction
		End Sub

		Public Function Compare(ByVal x As T, ByVal y As T) As Integer Implements System.Collections.Generic.IComparer(Of T).Compare
			Return m_ComparisonFunction(x, y)
		End Function
	End Class

	Public Sub New()
		'TODO - verify this type check logic
		If Not GetType(IComparable(Of T)).IsAssignableFrom(GetType(T)) Then
			Throw New ArgumentException("Type " & GetType(T).Name & " does not implement IComparable of T")
		End If

		m_Comparer = New ComparerWrapper(Function(x, y) DirectCast(x, IComparable(Of T)).CompareTo(y))
	End Sub

	Public Sub New(ByVal comparer As IComparer(Of T))
		If comparer Is Nothing Then Throw New ArgumentNullException("comparer")
		m_Comparer = comparer
	End Sub

	Public Sub New(ByVal comparisonFunction As Func(Of T, T, Integer))
		If comparisonFunction Is Nothing Then Throw New ArgumentNullException("comparisonFunction")
		m_Comparer = New ComparerWrapper(comparisonFunction)
	End Sub

	Public Sub Add(ByVal item As T) Implements System.Collections.Generic.ICollection(Of T).Add
		If m_Comparer IsNot Nothing Then
			For i = 0 To m_Values.Count - 1
				If m_Comparer.Compare(item, m_Values(i)) < 0 Then
					m_Values.Insert(i, item)
					Return
				End If
			Next
		Else
			Dim temp = DirectCast(item, IComparable(Of T))
			For i = 0 To m_Values.Count - 1
				If temp.CompareTo(m_Values(i)) < 0 Then
					m_Values.Insert(i, item)
					Return
				End If
			Next
		End If

		m_Values.Add(item)
	End Sub

	Public Sub Clear() Implements System.Collections.Generic.ICollection(Of T).Clear
		m_Values.Clear()
	End Sub

	Public Function Contains(ByVal item As T) As Boolean Implements System.Collections.Generic.ICollection(Of T).Contains
		For i = 0 To Count - 1
			If item.Equals(m_Values(i)) Then Return True
		Next
		Return False
		'TODO - learn how the binary search functions in this context
		'Return m_Values.BinarySearch(item, m_Comparer) >= 0
	End Function

	Public Sub CopyTo(ByVal array() As T, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of T).CopyTo
		m_Values.CopyTo(array, arrayIndex)
	End Sub

	Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of T).Count
		Get
			Return m_Values.Count
		End Get
	End Property

	Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of T).IsReadOnly
		Get
			Return False
		End Get
	End Property

	Public Function Remove(ByVal item As T) As Boolean Implements System.Collections.Generic.ICollection(Of T).Remove
		Return m_Values.Remove(item)
	End Function

	Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of T) Implements System.Collections.Generic.IEnumerable(Of T).GetEnumerator
		Return m_Values.GetEnumerator
	End Function

	Public Function IndexOf(ByVal item As T) As Integer Implements System.Collections.Generic.IList(Of T).IndexOf
		Return m_Values.IndexOf(item)
	End Function

	Private Sub Insert(ByVal index As Integer, ByVal item As T) Implements System.Collections.Generic.IList(Of T).Insert
		Throw New NotSupportedException
	End Sub

	Default Public ReadOnly Property Item(ByVal index As Integer) As T
		Get
			Return m_Values(index)
		End Get
	End Property

	Private Property IListOfT_Item(ByVal index As Integer) As T Implements System.Collections.Generic.IList(Of T).Item
		Get
			Return m_Values(index)
		End Get
		Set(ByVal value As T)
			Throw New NotSupportedException
		End Set
	End Property

	Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.Generic.IList(Of T).RemoveAt
		m_Values.RemoveAt(index)
	End Sub

	Private Function IEnumerable_GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		Return m_Values.GetEnumerator
	End Function

	Private Sub ICollection_CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
		CType(m_Values, IList).CopyTo(array, index)
	End Sub

	Private ReadOnly Property ICollection_Count() As Integer Implements System.Collections.ICollection.Count
		Get
			Return Me.Count
		End Get
	End Property

	Private ReadOnly Property IList_IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
		Get
			Return False
		End Get
	End Property

	Private ReadOnly Property IList_SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
		Get
			Return Me
		End Get
	End Property

	Private Function IList_Add(ByVal value As Object) As Integer Implements System.Collections.IList.Add
		Dim temp = CType(value, T)
		Me.Add(temp)
		Return Me.IndexOf(temp)
	End Function

	Private Sub IList_Clear() Implements System.Collections.IList.Clear
		m_Values.Clear()
	End Sub

	Private Function IList_Contains(ByVal value As Object) As Boolean Implements System.Collections.IList.Contains
		Return Me.Contains(CType(value, T))
	End Function

	Private Function IList_IndexOf(ByVal value As Object) As Integer Implements System.Collections.IList.IndexOf
		Return Me.IndexOf(CType(value, T))
	End Function

	Private Sub IList_Insert(ByVal index As Integer, ByVal value As Object) Implements System.Collections.IList.Insert
		Throw New NotSupportedException
	End Sub

	Private ReadOnly Property IList_IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
		Get
			Return False
		End Get
	End Property

	Private ReadOnly Property IList_IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
		Get
			Return False
		End Get
	End Property

	Private Property IList_Item(ByVal index As Integer) As Object Implements System.Collections.IList.Item
		Get
			Return Me(index)
		End Get
		Set(ByVal value As Object)
			Throw New NotSupportedException
		End Set
	End Property

	Private Sub IList_Remove(ByVal value As Object) Implements System.Collections.IList.Remove
		Me.Remove(CType(value, T))
	End Sub

	Private Sub IList_RemoveAt(ByVal index As Integer) Implements System.Collections.IList.RemoveAt
		Me.RemoveAt(index)
	End Sub
End Class

