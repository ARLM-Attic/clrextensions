Imports System.Collections.Generic
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ClrExtensions



'''<summary>
'''This is a test class for TupleExtensionTest and is intended
'''to contain all TupleExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class TupleExtensionTest


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
    '<ClassInitialize()>  _
    ' Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    ' Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    ' Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    ' Sub MyTestCleanup()
    'End Sub
    '
#End Region


    <TestMethod()> _
    Sub AddTest()

        Dim list As New List(Of Tuple(Of String, Integer))
        Dim a = "test"
        Dim b = 5
        TupleExtension.Add(list, a, b)
        Assert.AreEqual(1, list.Count)
        Assert.AreEqual(a, list(0).Item1)
        Assert.AreEqual(b, list(0).Item2)

    End Sub

    <ExpectedException(GetType(ArgumentNullException))>
    <TestMethod()> _
    Sub AddTest1()
        Dim list As List(Of Tuple(Of String, Integer)) = Nothing
        Dim a = "test"
        Dim b = 5
        TupleExtension.Add(list, a, b)


    End Sub
End Class
