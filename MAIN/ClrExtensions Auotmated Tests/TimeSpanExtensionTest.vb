Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for TimeSpanExtensionTest and is intended
'''to contain all TimeSpanExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class TimeSpanExtensionTest


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

    Dim value As New TimeSpan(0, 12, 35, 10, 500)


    '''<summary>
    '''A test for AddHours
    '''</summary>
    <TestMethod()> _
    Public Sub AddHoursTest()
        Dim expected = New TimeSpan(0, 15, 35, 10, 500)
        Assert.AreEqual(expected, value.AddHours(3))
    End Sub

    '''<summary>
    '''A test for AddMilliseconds
    '''</summary>
    <TestMethod()> _
    Public Sub AddMillisecondsTest()
        Dim expected = New TimeSpan(0, 12, 35, 10, 750)
        Assert.AreEqual(expected, value.AddMilliseconds(250))
    End Sub

    '''<summary>
    '''A test for AddMinutes
    '''</summary>
    <TestMethod()> _
    Public Sub AddMinutesTest()
        Dim expected = New TimeSpan(0, 12, 49, 10, 500)
        Assert.AreEqual(expected, value.AddMinutes(14))
    End Sub

    '''<summary>
    '''A test for AddSeconds
    '''</summary>
    <TestMethod()> _
    Public Sub AddSecondsTest()
        Dim expected = New TimeSpan(0, 12, 35, 50, 500)
        Assert.AreEqual(expected, value.AddSeconds(40))
    End Sub

    '''<summary>
    '''A test for AddDays
    '''</summary>
    <TestMethod()> _
    Public Sub AddDaysTest()
        Dim expected = New TimeSpan(6, 12, 35, 10, 500)
        Assert.AreEqual(expected, value.AddDays(6))

    End Sub
End Class
