#If ClrVersion >= 35 Then
#If IncludeUntested Then
Namespace Collections
    ''' <summary>
    ''' This is a queue which is thread-safe and can be dequeued in batches
    ''' </summary>
    ''' <remarks>All methods are threadsafe</remarks>
    Public Class BatchQueue(Of T)
        Private ReadOnly m_Lock As New Object
        Private ReadOnly m_List As New LinkedList(Of T)

        <ContractInvariantMethod()>
        Private Sub ObjectInvariant()
            Contract.Invariant(m_List IsNot Nothing)
        End Sub


        ''' <summary>
        ''' Adds a single item to the queue
        ''' </summary>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        <Untested()>
        Public Sub Enqueue(ByVal value As T)
            SyncLock m_Lock
                AddInternal(value)
            End SyncLock
        End Sub

        <Untested()>
        Public Sub EnqueueFirst(ByVal value As T)
            SyncLock m_Lock
                m_List.AddFirst(value)
            End SyncLock
        End Sub

        ''' <summary>
        ''' Adds a list of items to the queue
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks></remarks>
        <Untested()>
        Public Sub Enqueue(ByVal list As IEnumerable(Of T))
            SyncLock m_Lock
                For Each item In list
                    AddInternal(item)
                Next
            End SyncLock
        End Sub

        <Untested()>
        Public Sub EnqueueFirst(ByVal list As IEnumerable(Of T))
            SyncLock m_Lock
                For Each item In list.Reverse
                    m_List.AddFirst(item)
                Next
            End SyncLock
        End Sub

        <Untested()>
        Public Sub Clear()
            SyncLock m_Lock
                m_List.Clear()
            End SyncLock
        End Sub

        ''' <summary>
        ''' Attempts to dequeue the first element in the queue
        ''' </summary>
        ''' <param name="value">This is set to the element dequeued or Nothing if the queue is empty</param>
        ''' <returns>True if the queue contained items, False otherwise</returns>
        ''' <remarks></remarks>
        <Untested()>
        Public Function TryDequeue(ByRef value As T) As Boolean
            SyncLock m_Lock
                If m_List.Count > 0 Then
                    value = m_List.First.Value
                    m_List.RemoveFirst()
                    Return True
                Else
                    value = Nothing
                    Return False
                End If
            End SyncLock
        End Function


        ''' <summary>
        ''' Dequeues a list of values
        ''' </summary>
        ''' <param name="minBatchSize">Minimum number of items to remove from the queue</param>
        ''' <param name="maxBatchSize">Maximum number of items to remove from the queue</param>
        ''' <returns>A list containing minBatchSize &lt;= count &lt;= MaxBatchSize items or an empty list if there aren't at least minBatchSize items</returns>
        ''' <remarks></remarks>
        <Untested()>
        Public Function DequeueBatch(ByVal minBatchSize As Integer, ByVal maxBatchSize As Integer) As IList(Of T)
            SyncLock m_Lock

                If m_List.Count >= minBatchSize Then

                    Dim result As New List(Of T)
                    Dim currentNode = m_List.First
                    Do
                        result.Add(currentNode.Value)
                        Dim nodeToRemove = currentNode
                        currentNode = currentNode.Next 'we have to get the next node BEFORE we remove it from the list
                        m_List.Remove(nodeToRemove)
                    Loop Until result.Count = maxBatchSize OrElse currentNode Is Nothing
                    Return result

                Else
                    Return New List(Of T)
                End If
            End SyncLock

        End Function

        ''' <summary>
        ''' Returns the number of items currently in the queue
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Untested()>
        Public ReadOnly Property Count() As Integer
            Get
                SyncLock m_Lock
                    Return m_List.Count
                End SyncLock
            End Get
        End Property

        <Untested()>
        Private Sub AddInternal(ByVal value As T)
            m_List.AddLast(value)
        End Sub
    End Class
End Namespace
#End If
#End If