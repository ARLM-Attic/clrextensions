Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for CollectionExtensionTest and is intended
'''to contain all CollectionExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class CollectionExtensionTest


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

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for AddRange
    '''</summary>
    Public Sub AddRangeTestHelper(Of T)()



        Dim target As ICollection(Of T) = Nothing ' TODO: Initialize to an appropriate value
        Dim list As IEnumerable(Of T) = Nothing ' TODO: Initialize to an appropriate value
        CollectionExtension.AddRange(Of T)(target, list)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")

    End Sub

    <TestMethod()> _
    Public Sub AddRangeTest()

        Dim listA As New List(Of Integer)
        Dim listB As New List(Of Integer)

        listA.AddRange(New Integer() {1, 2, 3, 4, 5})
        listB.AddRange(New Integer() {6, 7, 8, 9, 10})

        Dim wrapper As ICollection(Of Integer) = listA
        wrapper.AddRange(listB)

        For i = 1 To 10
            Assert.AreEqual(i, wrapper(i - 1))
        Next

    End Sub
End Class
