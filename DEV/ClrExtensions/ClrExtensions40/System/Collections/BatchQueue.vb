#If ClrVersion >= 35 Or SilverlightVersion >= 40 Then
Namespace Collections
    ''' <summary>
    ''' This is a queue which is thread-safe and can be dequeued in batches
    ''' </summary>
    ''' <remarks>All methods are threadsafe</remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")>
    Public Class BatchQueue(Of T)
        Private ReadOnly m_Lock As New Object
        Private ReadOnly m_List As New LinkedList(Of T)

        ''' <summary>
        ''' Adds a single item to the end of the queue
        ''' </summary>
        ''' <param name="value">Value to be enqueued</param>
        ''' <remarks>The value can be null.</remarks>
        Sub Enqueue(ByVal value As T)

            SyncLock m_Lock
                AddInternal(value)
            End SyncLock
        End Sub

        ''' <summary>
        ''' Adds a single item to the beginning of the queue
        ''' </summary>
        ''' <param name="value">Value to be enqueued</param>
        ''' <remarks>The value can be null</remarks>
        Sub EnqueueFirst(ByVal value As T)

            SyncLock m_Lock
                m_List.AddFirst(value)
            End SyncLock
        End Sub

        ''' <summary>
        ''' Adds a list of items to the end of the queue
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks>The list cannot be null, but it can contain nulls</remarks>
        Sub Enqueue(ByVal list As IEnumerable(Of T))
            If list Is Nothing Then Throw New ArgumentNullException("list")

            SyncLock m_Lock
                For Each item In list
                    AddInternal(item)
                Next
            End SyncLock
        End Sub

        ''' <summary>
        ''' Adds a list of items to the beginning of the queue
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks>The list cannot be null, but it can contain nulls</remarks>
        Sub EnqueueFirst(ByVal list As IEnumerable(Of T))
            If list Is Nothing Then Throw New ArgumentNullException("list")

            SyncLock m_Lock
                For Each item In list.Reverse
                    m_List.AddFirst(item)
                Next
            End SyncLock
        End Sub

        ''' <summary>
        ''' Clears the contents of the queue.
        ''' </summary>
        ''' <remarks></remarks>
        Sub Clear()

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
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId:="0#")>
        Function TryDequeue(ByRef value As T) As Boolean

            SyncLock m_Lock
                If m_List.Count > 0 Then
                    value = m_List.First.Value
                    m_List.RemoveFirst()
                    Return True
                End If

                value = Nothing
                Return False
            End SyncLock
        End Function


        ''' <summary>
        ''' Dequeues a list of values
        ''' </summary>
        ''' <param name="minBatchSize">Minimum number of items to remove from the queue</param>
        ''' <param name="maxBatchSize">Maximum number of items to remove from the queue</param>
        ''' <returns>A list containing minBatchSize &lt;= count &lt;= MaxBatchSize items or an empty list if there aren't at least minBatchSize items</returns>
        ''' <remarks></remarks>
        Function DequeueBatch(ByVal minBatchSize As Integer, ByVal maxBatchSize As Integer) As List(Of T)

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

                End If

                Return New List(Of T)
            End SyncLock

        End Function

        ''' <summary>
        ''' Returns the number of items currently in the queue
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Count() As Integer
            Get
                SyncLock m_Lock
                    Return m_List.Count
                End SyncLock
            End Get
        End Property

        Private Sub AddInternal(ByVal value As T)
            m_List.AddLast(value)
        End Sub

    End Class
End Namespace
#End If
