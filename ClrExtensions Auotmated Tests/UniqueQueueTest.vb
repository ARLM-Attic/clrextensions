Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions.System.Collections



'''<summary>
'''This is a test class for UniqueQueueTest and is intended
'''to contain all UniqueQueueTest Unit Tests
'''</summary>
<TestClass()> _
Public Class UniqueQueueTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

    Private Class TestObject
        Implements IEquatable(Of TestObject)

        Private m_Id As Integer
        Private m_Value As Integer

        Public Property Id() As Integer
            Get
                Return m_Id
            End Get
            Set(ByVal value As Integer)
                m_Id = value
            End Set
        End Property

        Public Property Value() As Integer
            Get
                Return m_Value
            End Get
            Set(ByVal value As Integer)
                m_Value = value
            End Set
        End Property

        Public Overloads Function Equals(ByVal other As TestObject) As Boolean Implements System.IEquatable(Of TestObject).Equals
            If other Is Nothing Then Return False
            Return other.Id = Me.Id
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            Return Equals(TryCast(obj, TestObject))
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return Id.GetHashCode
        End Function

        Public Sub New(ByVal id As Integer, ByVal value As Integer)
            m_Id = id
            m_Value = value
        End Sub
    End Class


    <TestMethod()> _
    Public Sub DuplicatesIqnoredTest()
        Dim queue As New UniqueQueue(Of TestObject)(UniqueQueueMode.DuplicatesIqnored)

        'Pass 1
        For i = 0 To 100
            queue.Enqueue(New TestObject(i, 0))
        Next
        For i = 0 To 100
            If i Mod 2 = 0 Then queue.Enqueue(New TestObject(i, 1))
        Next

        Dim x As TestObject = Nothing
        For i = 0 To 101
            Assert.AreEqual(101 - i, queue.Count)
            If queue.TryDequeue(x) Then
                Assert.AreEqual(i, x.Id)
                Assert.AreEqual(0, x.Value)
            Else
                If i < 101 Then Assert.Fail("There should have been a result for index " & i)
                If x IsNot Nothing Then Assert.Fail("TryDequeue should return a null")
            End If
        Next


        'Pass 2
        Dim temp As New List(Of TestObject)
        For i = 0 To 100
            temp.Add(New TestObject(i, 0))
        Next
        queue.Enqueue(temp)

        Dim temp2 As New List(Of TestObject)

        For i = 0 To 100
            If i Mod 2 = 0 Then temp2.Add(New TestObject(i, 1))
        Next
        queue.Enqueue(temp2)

        x = Nothing
        For i = 0 To 101
            Assert.AreEqual(101 - i, queue.Count)
            If queue.TryDequeue(x) Then
                Assert.AreEqual(i, x.Id)
                Assert.AreEqual(0, x.Value)
            Else
                If i < 101 Then Assert.Fail("There should have been a result for index " & i)
                If x IsNot Nothing Then Assert.Fail("TryDequeue should return a null")
            End If
        Next

        'Pass 3
        For i = 0 To 100
            queue.Enqueue(New TestObject(i, 0))
        Next
        For i = 0 To 100
            If i Mod 2 = 0 Then queue.Enqueue(New TestObject(i, 1))
        Next

        Dim batch As IList(Of TestObject)
        Do
            batch = queue.DequeueBatch(5, 25)
            Assert.IsTrue(batch.Count = 0 Or (batch.Count >= 5 And batch.Count <= 25))
            If batch.Count = 0 Then
                Assert.IsTrue(queue.Count < 5)
            End If
        Loop Until batch.Count = 0

    End Sub


    <TestMethod()> _
    Public Sub ReplaceTest()
        Dim queue As New UniqueQueue(Of TestObject)(UniqueQueueMode.Replace)

        'Pass 1
        For i = 0 To 100
            queue.Enqueue(New TestObject(i, 0))
        Next
        For i = 0 To 100
            If i Mod 2 = 0 Then queue.Enqueue(New TestObject(i, 1))
        Next

        Dim x As TestObject = Nothing
        For i = 0 To 101
            Assert.AreEqual(101 - i, queue.Count)
            If queue.TryDequeue(x) Then
                Assert.AreEqual(i, x.Id)
                If x.Id Mod 2 = 0 Then
                    Assert.AreEqual(1, x.Value)
                Else
                    Assert.AreEqual(0, x.Value)
                End If
            Else
                If i < 101 Then Assert.Fail("There should have been a result for index " & i)
                If x IsNot Nothing Then Assert.Fail("TryDequeue should return a null")
            End If
        Next


        'Pass 2
        Dim temp As New List(Of TestObject)
        For i = 0 To 100
            temp.Add(New TestObject(i, 0))
        Next
        queue.Enqueue(temp)

        Dim temp2 As New List(Of TestObject)

        For i = 0 To 100
            If i Mod 2 = 0 Then temp2.Add(New TestObject(i, 1))
        Next
        queue.Enqueue(temp2)

        x = Nothing
        For i = 0 To 101
            Assert.AreEqual(101 - i, queue.Count)
            If queue.TryDequeue(x) Then
                Assert.AreEqual(i, x.Id)
                If x.Id Mod 2 = 0 Then
                    Assert.AreEqual(1, x.Value)
                Else
                    Assert.AreEqual(0, x.Value)
                End If
            Else
                If i < 101 Then Assert.Fail("There should have been a result for index " & i)
                If x IsNot Nothing Then Assert.Fail("TryDequeue should return a null")
            End If
        Next

        'Pass 3
        For i = 0 To 100
            queue.Enqueue(New TestObject(i, 0))
        Next
        For i = 0 To 100
            If i Mod 2 = 0 Then queue.Enqueue(New TestObject(i, 1))
        Next

        Dim batch As IList(Of TestObject)
        Do
            batch = queue.DequeueBatch(5, 25)
            Assert.IsTrue(batch.Count = 0 Or (batch.Count >= 5 And batch.Count <= 25))
            If batch.Count = 0 Then
                Assert.IsTrue(queue.Count < 5)
            End If
        Loop Until batch.Count = 0

    End Sub

    <TestMethod()> _
    Public Sub MoveToEndTest()
        Dim queue As New UniqueQueue(Of TestObject)(UniqueQueueMode.MoveToEnd)

        'Pass 1
        For i = 0 To 100
            queue.Enqueue(New TestObject(i, 0))
        Next
        For i = 0 To 100
            If i Mod 2 = 0 Then queue.Enqueue(New TestObject(i, 1))
        Next

        Dim x As TestObject = Nothing
        For i = 1 To 99 Step 2
            If queue.TryDequeue(x) Then
                Assert.AreEqual(i, x.Id)
                Assert.AreEqual(0, x.Value)
            Else
                If i < 101 Then Assert.Fail("There should have been a result for index " & i)
                If x IsNot Nothing Then Assert.Fail("TryDequeue should return a null")
            End If
        Next
        For i = 0 To 100 Step 2
            If queue.TryDequeue(x) Then
                Assert.AreEqual(i, x.Id)
                Assert.AreEqual(1, x.Value)
            Else
                If i < 101 Then Assert.Fail("There should have been a result for index " & i)
                If x IsNot Nothing Then Assert.Fail("TryDequeue should return a null")
            End If
        Next

     


        'Pass 2
        Dim temp As New List(Of TestObject)
        For i = 0 To 100
            temp.Add(New TestObject(i, 0))
        Next
        queue.Enqueue(temp)

        Dim temp2 As New List(Of TestObject)

        For i = 0 To 100
            If i Mod 2 = 0 Then temp2.Add(New TestObject(i, 1))
        Next
        queue.Enqueue(temp2)

        x = Nothing
        For i = 1 To 99 Step 2
            If queue.TryDequeue(x) Then
                Assert.AreEqual(i, x.Id)
                Assert.AreEqual(0, x.Value)
            Else
                If i < 101 Then Assert.Fail("There should have been a result for index " & i)
                If x IsNot Nothing Then Assert.Fail("TryDequeue should return a null")
            End If
        Next
        For i = 0 To 100 Step 2
            If queue.TryDequeue(x) Then
                Assert.AreEqual(i, x.Id)
                Assert.AreEqual(1, x.Value)
            Else
                If i < 101 Then Assert.Fail("There should have been a result for index " & i)
                If x IsNot Nothing Then Assert.Fail("TryDequeue should return a null")
            End If
        Next

        'Pass 3
        For i = 0 To 100
            queue.Enqueue(New TestObject(i, 0))
        Next
        For i = 0 To 100
            If i Mod 2 = 0 Then queue.Enqueue(New TestObject(i, 1))
        Next

        Dim batch As IList(Of TestObject)
        Do
            batch = queue.DequeueBatch(5, 25)
            Assert.IsTrue(batch.Count = 0 Or (batch.Count >= 5 And batch.Count <= 25))
            If batch.Count = 0 Then
                Assert.IsTrue(queue.Count < 5)
            End If
        Loop Until batch.Count = 0

    End Sub

End Class
