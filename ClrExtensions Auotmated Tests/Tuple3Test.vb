Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions.System.Collections



'''<summary>
'''This is a test class for Tuple3Test and is intended
'''to contain all Tuple3Test Unit Tests
'''</summary>
<TestClass()> _
Public Class Tuple3Test


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




    Private ReadOnly ValueA As New Tuple(Of Integer, String, Boolean)(5, "AAA", True)
    Private ReadOnly ValueB As New Tuple(Of Integer, String, Boolean)(7, "BBB", False)
    Private ReadOnly ValueC1 As New Tuple(Of Integer, String, Boolean)(9, "CCC", True)
    Private ReadOnly ValueC2 As New Tuple(Of Integer, String, Boolean)(9, "CCC", True)
    Private ReadOnly ValueZ As New Tuple(Of Integer, String, Boolean)(0, Nothing, False)

    Dim aList() As Integer = New Integer() {5, 7, 9, 9, 0}
    Dim bList() As String = New String() {"AAA", "BBB", "CCC", "CCC", Nothing}
    Dim cList() As Boolean = New Boolean() {True, False, True, True, False}
    Dim list() As Tuple(Of Integer, String, Boolean) = New Tuple(Of Integer, String, Boolean)() {ValueA, ValueB, ValueC1, ValueC2, ValueZ}





    <TestMethod()> _
    Public Sub CTest()
        For i = 0 To list.Length - 1
            Assert.AreEqual(cList(i), list(i).C)
        Next
    End Sub

    <TestMethod()> _
    Public Sub BTest()
        For i = 0 To list.Length - 1
            Assert.AreEqual(bList(i), list(i).B)
        Next
    End Sub



    <TestMethod()> _
    Public Sub ATest()
        For i = 0 To list.Length - 1
            Assert.AreEqual(aList(i), list(i).A)
        Next
    End Sub


    <TestMethod()> _
    Public Sub GetHashCodeTest()
        For i = 0 To list.Length - 1
            For j = 0 To list.Length - 1

                If i = 2 And j = 3 Or i = 3 And j = 2 Then
                    Assert.IsTrue(list(i).GetHashCode = list(j).GetHashCode)
                ElseIf i = j Then
                    Assert.IsTrue(list(i).GetHashCode = list(j).GetHashCode)
                Else
                    'Undefined
                End If
            Next
        Next
    End Sub

    <TestMethod()> _
    Public Sub EqualsTest1()
        For i = 0 To list.Length - 1
            For j = 0 To list.Length - 1

                If i = 2 And j = 3 Or i = 3 And j = 2 Then
                    Assert.IsTrue(Object.Equals(list(i), list(j)))
                ElseIf i = j Then
                    Assert.IsTrue(Object.Equals(list(i), list(j)))
                Else
                    Assert.IsFalse(Object.Equals(list(i), list(j)))
                End If
            Next
        Next
    End Sub



    <TestMethod()> _
    Public Sub EqualsTest()

        For i = 0 To list.Length - 1
            For j = 0 To list.Length - 1

                If i = 2 And j = 3 Or i = 3 And j = 2 Then
                    Assert.IsTrue(list(i).Equals(list(j)))
                ElseIf i = j Then
                    Assert.IsTrue(list(i).Equals(list(j)))
                Else
                    Assert.IsFalse(list(i).Equals(list(j)))
                End If
            Next
        Next

    End Sub

    <TestMethod()> _
    Public Sub TupleConstructorTest()
        'handled by BTest and ATest
    End Sub

    
End Class
