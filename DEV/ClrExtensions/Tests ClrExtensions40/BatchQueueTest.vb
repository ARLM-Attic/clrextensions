Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions.Collections



'''<summary>
'''This is a test class for BatchQueueTest and is intended
'''to contain all BatchQueueTest Unit Tests
'''</summary>
<TestClass()>
Public Class BatchQueueTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()> 
    ' Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()> 
    ' Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()> 
    ' Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()> 
    ' Sub MyTestCleanup()
    'End Sub
    '
#End Region

    <TestMethod()>
    Sub ClearTest()
        Dim x = New BatchQueue(Of Integer)
        x.Enqueue({1, 2, 3, 4, 5, 6, 7, 8, 9, 10})
        Assert.AreEqual(10, x.Count)
        x.Clear()
        Assert.AreEqual(0, x.Count)
    End Sub


    '''<summary>
    '''A test for DequeueBatch
    '''</summary>
    Sub DequeueBatchTestHelper(Of T)()
        Dim target As BatchQueue(Of T) = New BatchQueue(Of T)() ' TODO: Initialize to an appropriate value
        Dim minBatchSize As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim maxBatchSize As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As List(Of T) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As List(Of T)
        actual = target.DequeueBatch(minBatchSize, maxBatchSize)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    <TestMethod()>
    Sub DequeueBatchTest()
        Dim x = New BatchQueue(Of Integer)

        Dim batch1 = x.DequeueBatch(4, 8)
        Assert.AreEqual(0, batch1.Count)
        Assert.AreEqual(0, x.Count)

        x.Enqueue({1, 2, 3, 4, 5, 6, 7, 8, 9, 10})
        Assert.AreEqual(10, x.Count)

        Dim batch2 = x.DequeueBatch(4, 8)
        Assert.AreEqual(8, batch2.Count)
        Assert.AreEqual(2, x.Count)

        Dim batch3 = x.DequeueBatch(4, 8)
        Assert.AreEqual(0, batch3.Count)
        Assert.AreEqual(2, x.Count)

        Dim v1 As Integer
        Dim a1 As Boolean
        a1 = x.TryDequeue(v1)
        Assert.AreEqual(v1, 9)
        Assert.IsTrue(a1)

        Dim v2 As Integer
        Dim a2 As Boolean
        a2 = x.TryDequeue(v2)
        Assert.AreEqual(v2, 10)
        Assert.IsTrue(a2)

        Dim v3 As Integer
        Dim a3 As Boolean
        a3 = x.TryDequeue(v3)
        Assert.AreEqual(v3, 0)
        Assert.IsFalse(a3)





    End Sub

    '''<summary>
    '''A test for EnqueueFirst
    '''</summary>
    Sub EnqueueFirstTestHelper(Of T)()
        Dim target As BatchQueue(Of T) = New BatchQueue(Of T)() ' TODO: Initialize to an appropriate value
        Dim list As IEnumerable(Of T) = Nothing ' TODO: Initialize to an appropriate value
        target.EnqueueFirst(list)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    <TestMethod()>
    Sub EnqueueFirstTest()
        Dim x As New BatchQueue(Of Integer)
        x.Enqueue(1)
        x.Enqueue(2)
        x.Enqueue(3)
        x.Enqueue(4)
        x.Enqueue(5)
        x.EnqueueFirst({7, 8, 9, 10})
        x.EnqueueFirst(6)
        Dim y = x.DequeueBatch(10, 10)

        For i = 0 To 4
            Assert.AreEqual(i + 6, y(i))
        Next
        For i = 5 To 9
            Assert.AreEqual(i - 4, y(i))
        Next


    End Sub

    <ExpectedException(GetType(ArgumentNullException))>
    <TestMethod()>
    Sub EnqueueTest1()
        Dim x As New BatchQueue(Of Integer)
        Dim y As List(Of Integer) = Nothing
        x.Enqueue(y)
    End Sub

    <ExpectedException(GetType(ArgumentNullException))>
    <TestMethod()>
    Sub EnqueueFirstTest1()
        Dim x As New BatchQueue(Of Integer)
        Dim y As List(Of Integer) = Nothing
        x.EnqueueFirst(y)
    End Sub

End Class
