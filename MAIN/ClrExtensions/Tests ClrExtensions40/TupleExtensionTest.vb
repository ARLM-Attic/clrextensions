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
    '''A test for Add
    '''</summary>
    Public Sub AddTestHelper(Of TArg1, TArg2)()
        Dim list As List(Of Tuple(Of TArg1, TArg2)) = Nothing ' TODO: Initialize to an appropriate value
        Dim arg1 As TArg1 = CType(Nothing, TArg1) ' TODO: Initialize to an appropriate value
        Dim arg2 As TArg2 = CType(Nothing, TArg2) ' TODO: Initialize to an appropriate value
        TupleExtension.Add(Of TArg1, TArg2)(list, arg1, arg2)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    <TestMethod()> _
        Public Sub AddTest()

        Dim list As New List(Of Tuple(Of String, Integer))
        Dim a = "test"
        Dim b = 5
        TupleExtension.Add(list, a, b)
        Assert.AreEqual(1, list.Count)
        Assert.AreEqual(a, list(0).Item1)
        Assert.AreEqual(b, list(0).Item2)

    End Sub
End Class
