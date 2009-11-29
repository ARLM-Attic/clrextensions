'Copyright (c) 2008, Jonathan Allen

Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports ClrExtensions.Collections

#If IncludeUntested Then

Namespace Collections

    ''' <summary>
    ''' This is a sorted list that won't throw an exception if two items have the same value.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")> <Serializable()>
    <DebuggerDisplay("Count = {Count}")>
    <ComVisible(False)>
    Public NotInheritable Class SortedList(Of T)
        Implements IList(Of T)
        Implements IList

        Private ReadOnly m_Values As New List(Of T)
        Private ReadOnly m_Comparer As IComparer(Of T)

        Private Class ComparerWrapper
            Implements IComparer(Of T)
            Private ReadOnly m_ComparisonFunction As Func(Of T, T, Integer)

            <Untested()>
            Public Sub New(ByVal comparisonFunction As Func(Of T, T, Integer))
                m_ComparisonFunction = comparisonFunction
            End Sub

            <Untested()>
            <Pure()> Public Function Compare(ByVal x As T, ByVal y As T) As Integer Implements IComparer(Of T).Compare
                Return m_ComparisonFunction(x, y)
            End Function
        End Class

        <Untested()>
        <Pure()>
        Public Sub New()
            'TODO - verify this type check logic
            If Not GetType(IComparable(Of T)).IsAssignableFrom(GetType(T)) Then Throw New ArgumentException("Type " & GetType(T).Name & " does not implement IComparable of T")

            m_Comparer = New ComparerWrapper(Function(x, y) DirectCast(x, IComparable(Of T)).CompareTo(y))
        End Sub

        <Pure()>
        <Untested()>
        Public Sub New(ByVal comparer As IComparer(Of T))
            If comparer Is Nothing Then Throw New ArgumentNullException("comparer")
            Contract.EndContractBlock()

            m_Comparer = comparer
        End Sub

        <Pure()>
        <Untested()>
        Public Sub New(ByVal comparisonFunction As Func(Of T, T, Integer))
            If comparisonFunction Is Nothing Then Throw New ArgumentNullException("comparisonFunction")
            Contract.EndContractBlock()

            m_Comparer = New ComparerWrapper(comparisonFunction)
        End Sub

        <Untested()>
        Public Sub Add(ByVal item As T) Implements Generic.ICollection(Of T).Add
            Contract.Ensures(Count = Contract.OldValue(Count) + 1)

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

        <Untested()>
        Public Sub Clear() Implements ICollection(Of T).Clear, IList.Clear
            Contract.Ensures(Count = 0)

            m_Values.Clear()
        End Sub

        <Untested()>
        <Pure()>
        Public Function Contains(ByVal item As T) As Boolean Implements ICollection(Of T).Contains
            For i = 0 To Count - 1
                If item.Equals(m_Values(i)) Then Return True
            Next
            Return False
            'TODO - learn how the binary search functions in this context
            'Return m_Values.BinarySearch(item, m_Comparer) >= 0
        End Function

        <Untested()>
        Public Sub CopyTo(ByVal array() As T, ByVal arrayIndex As Integer) Implements ICollection(Of T).CopyTo
            If array Is Nothing Then Throw New ArgumentNullException("array")
            If arrayIndex < 0 Then Throw New ArgumentOutOfRangeException("arrayIndex")
            Contract.EndContractBlock()

            m_Values.CopyTo(array, arrayIndex)
        End Sub

        <Untested()>
        <Pure()>
        Public ReadOnly Property Count() As Integer Implements ICollection(Of T).Count
            Get
                Return m_Values.Count
            End Get
        End Property

        <Untested()>
        <Pure()>
        Public ReadOnly Property IsReadOnly() As Boolean Implements ICollection(Of T).IsReadOnly
            Get
                Return False
            End Get
        End Property

        <Untested()>
        Public Function Remove(ByVal item As T) As Boolean Implements ICollection(Of T).Remove
            Contract.Ensures(Count = Contract.OldValue(Count) Or Count = Contract.OldValue(Count) - 1)
            Return m_Values.Remove(item)
        End Function

        <Untested()>
        <Pure()>
        Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
            Return m_Values.GetEnumerator
        End Function

        <Untested()>
        <Pure()>
        Public Function IndexOf(ByVal item As T) As Integer Implements IList(Of T).IndexOf
            Return m_Values.IndexOf(item)
        End Function

        <Untested()>
        Private Sub Insert(ByVal index As Integer, ByVal item As T) Implements IList(Of T).Insert
            Throw New NotSupportedException
        End Sub

        <Untested()>
        Default Public ReadOnly Property Item(ByVal index As Integer) As T
            <Pure()>
            Get
                If index <= 0 Then Throw New ArgumentOutOfRangeException("index")
                Contract.EndContractBlock()

                Return m_Values(index)
            End Get
        End Property

        <Untested()>
        Private Property IListOfT_Item(ByVal index As Integer) As T Implements IList(Of T).Item
            <Pure()>
            Get
                If index < 0 Then Throw New ArgumentOutOfRangeException("index")
                If index >= Count Then Throw New ArgumentOutOfRangeException("index")
                Contract.EndContractBlock()

                Return m_Values(index)
            End Get
            Set(ByVal value As T)
                Throw New NotSupportedException
            End Set
        End Property

        <Untested()>
        Public Sub RemoveAt(ByVal index As Integer) Implements Generic.IList(Of T).RemoveAt
            If index < 0 Then Throw New ArgumentOutOfRangeException("index")
            If index >= Count Then Throw New ArgumentOutOfRangeException("index")
            Contract.Ensures(Count = Contract.OldValue(Count) - 1)

            m_Values.RemoveAt(index)
        End Sub

        <Untested()>
        <Pure()>
        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return m_Values.GetEnumerator
        End Function

        <Untested()>
        Private Sub ICollection_CopyTo(ByVal array As Global.System.Array, ByVal index As Integer) Implements ICollection.CopyTo
            If array Is Nothing Then Throw New ArgumentNullException("array")
            If index < 0 Then Throw New ArgumentOutOfRangeException("index")
            Contract.EndContractBlock()

            CType(m_Values, IList).CopyTo(array, index)
        End Sub

        <Untested()>
        Private ReadOnly Property ICollection_Count() As Integer Implements ICollection.Count
            <Pure()>
            Get
                Return Me.Count
            End Get
        End Property

        <Untested()>
        Private ReadOnly Property IList_IsSynchronized() As Boolean Implements ICollection.IsSynchronized
            <Pure()>
            Get
                Return False
            End Get
        End Property

        <Untested()>
        Private ReadOnly Property IList_SyncRoot() As Object Implements ICollection.SyncRoot
            <Pure()>
            Get
                Return Me
            End Get
        End Property

        <Untested()>
        Private Function IList_Add(ByVal value As Object) As Integer Implements IList.Add
            Contract.Ensures(Count = Contract.OldValue(Count) + 1)

            Dim temp = CType(value, T)
            Me.Add(temp)
            Return Me.IndexOf(temp)
        End Function

        <Untested()>
        <Pure()>
        Private Function IList_Contains(ByVal value As Object) As Boolean Implements IList.Contains
            Return Me.Contains(CType(value, T))
        End Function

        <Untested()>
        <Pure()>
        Private Function IList_IndexOf(ByVal value As Object) As Integer Implements IList.IndexOf
            Return Me.IndexOf(CType(value, T))
        End Function

        <Untested()>
        Private Sub IList_Insert(ByVal index As Integer, ByVal value As Object) Implements IList.Insert
            Throw New NotSupportedException
        End Sub

        <Untested()>
        <Pure()>
        Private ReadOnly Property IList_IsFixedSize() As Boolean Implements IList.IsFixedSize
            Get
                Return False
            End Get
        End Property

        <Untested()>
        <Pure()>
        Private ReadOnly Property IList_IsReadOnly() As Boolean Implements IList.IsReadOnly
            Get
                Return False
            End Get
        End Property

        <Untested()>
        Private Property IList_Item(ByVal index As Integer) As Object Implements IList.Item
            <Pure()>
            Get
                If index < 0 Then Throw New ArgumentOutOfRangeException("index")
                If index >= Count Then Throw New ArgumentOutOfRangeException("index")
                Contract.EndContractBlock()

                Return Me(index)
            End Get
            Set(ByVal value As Object)
                Throw New NotSupportedException
            End Set
        End Property

        <Untested()>
        Private Sub IList_Remove(ByVal value As Object) Implements IList.Remove
            Contract.Ensures(Count = Contract.OldValue(Count) Or Count = Contract.OldValue(Count) - 1)

            Me.Remove(CType(value, T))
        End Sub

        <Untested()>
        Private Sub IList_RemoveAt(ByVal index As Integer) Implements IList.RemoveAt
            If index < 0 Then Throw New ArgumentOutOfRangeException("index")
            If index >= Count Then Throw New ArgumentOutOfRangeException("index")
            Contract.Ensures(Count = Contract.OldValue(Count) - 1)


            Me.RemoveAt(index)
        End Sub
    End Class

End Namespace
#End If