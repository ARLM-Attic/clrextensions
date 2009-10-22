'Copyright (c) 2008, Jonathan Allen

#If IncludeUntested Then
Namespace Collections

	''' <summary>
	''' This is a queue in which any given item can only appear once.
	''' </summary>
	''' <remarks>All methods are threadsafe</remarks>
	Public Class UniqueQueue(Of T)
		Private ReadOnly m_Lock As New Threading.ReaderWriterLockSlim
		Private ReadOnly m_List As New LinkedList(Of T)
		Private ReadOnly m_comparer As IEqualityComparer(Of T)
		Private ReadOnly m_Mode As UniqueQueueMode

		''' <summary>
		''' Creates a new unique queue using the objects default comparer
		''' </summary>
		''' <remarks></remarks>
        <Untested()>
        Public Sub New(ByVal mode As UniqueQueueMode)
            If Not mode.EnumIsDefined Then Throw New ArgumentOutOfRangeException("mode", mode, "Mode isn't defined")
            m_Mode = mode
        End Sub

		''' <summary>
		''' Creates a new unique queue using a custom comparer
		''' </summary>
		''' <param name="comparer"></param>
		''' <remarks></remarks>
        <Untested()>
        Public Sub New(ByVal mode As UniqueQueueMode, ByVal comparer As IEqualityComparer(Of T))
            If Not mode.EnumIsDefined Then Throw New ArgumentOutOfRangeException("mode", mode, "Mode isn't defined")

            m_Mode = mode
            m_comparer = comparer
        End Sub

		''' <summary>
		''' Adds a single item to the queue
		''' </summary>
		''' <param name="value"></param>
		''' <remarks></remarks>
        <Untested()>
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
        <Untested()>
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
        <Untested()>
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
        <Untested()>
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
        <Untested()>
        Public ReadOnly Property Count() As Integer
            Get
                Using m_Lock.ReadSection
                    Return m_List.Count
                End Using
            End Get
        End Property

        <Untested()>
        Private Sub AddInternal(ByVal value As T)
            Dim node As LinkedListNode(Of T) = Nothing

            'Find the pre-existing node, if it exists
            If m_comparer Is Nothing Then
                Dim testNode = m_List.First
                Do Until testNode Is Nothing
                    If testNode.Value.Equals(value) Then
                        node = testNode
                        Exit Do
                    End If
                    testNode = testNode.Next
                Loop
            Else
                Dim testNode = m_List.First
                Do Until testNode Is Nothing
                    If m_comparer.Equals(testNode.Value, value) Then
                        node = testNode
                        Exit Do
                    End If
                    testNode = testNode.Next
                Loop
            End If

            If node IsNot Nothing Then 'the mode determines what to do
                Select Case m_Mode
                    Case UniqueQueueMode.DuplicatesIqnored
                        'NOP
                    Case UniqueQueueMode.MoveToEnd
                        m_List.Remove(node)
                        m_List.AddLast(value)
                    Case UniqueQueueMode.Replace
                        node.Value = value
                End Select
            Else 'add the item
                m_List.AddLast(value)
            End If
        End Sub


	End Class

	''' <summary>
	''' Operation modes for a Unique Queue
	''' </summary>
	''' <remarks></remarks>
	Public Enum UniqueQueueMode
		''' <summary>
		''' Adding a duplicate item replaces the original item
		''' </summary>
		''' <remarks></remarks>
		Replace = 0
		''' <summary>
		''' Adding a duplicate item deletes the original and adds the new version to the end of the list
		''' </summary>
		''' <remarks></remarks>
		MoveToEnd = 1
		''' <summary>
		''' Duplicates are not added to the queue, the original version remains
		''' </summary>
		''' <remarks></remarks>
		DuplicatesIqnored = 2
	End Enum

End Namespace

#End If