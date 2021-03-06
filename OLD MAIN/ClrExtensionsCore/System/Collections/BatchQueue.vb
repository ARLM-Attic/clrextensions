Namespace Collections
    ''' <summary>
    ''' This is a queue which is thread-safe and can be dequeued in batches
    ''' </summary>
    ''' <remarks>All methods are threadsafe</remarks>
    Public Class BatchQueue(Of T)
        Private ReadOnly m_Lock As New Threading.ReaderWriterLockSlim
        Private ReadOnly m_List As New LinkedList(Of T)

        ''' <summary>
        ''' Adds a single item to the queue
        ''' </summary>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Public Sub Enqueue(ByVal value As T)
            Using m_Lock.WriteSection
                AddInternal(value)
            End Using
        End Sub

        ''' <summary>
        ''' Adds a list of items to the queue
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks></remarks>
        Public Sub Enqueue(ByVal list As IEnumerable(Of T))
            Using m_Lock.WriteSection
                For Each item In list
                    AddInternal(item)
                Next
            End Using
        End Sub

        ''' <summary>
        ''' Attempts to dequeue the first element in the queue
        ''' </summary>
        ''' <param name="value">This is set to the element dequeued or Nothing if the queue is empty</param>
        ''' <returns>True if the queue contained items, False otherwise</returns>
        ''' <remarks></remarks>
        Public Function TryDequeue(ByRef value As T) As Boolean
            Using m_Lock.WriteSection
                If m_List.Count > 0 Then
                    value = m_List.First.Value
                    m_List.RemoveFirst()
                    Return True
                Else
                    value = Nothing
                    Return False
                End If
            End Using
        End Function


        ''' <summary>
        ''' Dequeues a list of values
        ''' </summary>
        ''' <param name="minBatchSize">Minimum number of items to remove from the queue</param>
        ''' <param name="maxBatchSize">Maximum number of items to remove from the queue</param>
        ''' <returns>A list containing minBatchSize &lt;= count &lt;= MaxBatchSize items or an empty list if there aren't at least minBatchSize items</returns>
        ''' <remarks></remarks>
        Public Function DequeueBatch(ByVal minBatchSize As Integer, ByVal maxBatchSize As Integer) As IList(Of T)
            Using m_Lock.UpgradeableReadSection

                If m_List.Count >= minBatchSize Then

                    Using m_Lock.WriteSection
                        Dim result As New List(Of T)
                        Dim currentNode = m_List.First
                        Do
                            result.Add(currentNode.Value)
                            Dim nodeToRemove = currentNode
                            currentNode = currentNode.Next 'we have to get the next node BEFORE we remove it from the list
                            m_List.Remove(nodeToRemove)
                        Loop Until result.Count = maxBatchSize OrElse currentNode Is Nothing
                        Return result
                    End Using

                Else
                    Return New List(Of T)
                End If
            End Using

        End Function

        ''' <summary>
        ''' Returns the number of items currently in the queue
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Count() As Integer
            Get
                Using m_Lock.ReadSection
                    Return m_List.Count
                End Using
            End Get
        End Property

        Private Sub AddInternal(ByVal value As T)
            m_List.AddLast(value)
        End Sub
    End Class
End Namespace
