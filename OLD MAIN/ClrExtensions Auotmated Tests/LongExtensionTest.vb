Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for LongExtensionTest and is intended
'''to contain all LongExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class LongExtensionTest


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
    '''A test for ParseByteSize
    '''</summary>
    <TestMethod()> _
    Public Sub ParseByteSizeTest()

        Dim source = New String() {"0 B", "10 B", "100 B", "1000 B", "9.77 KB", "97.66 KB", "976.56 KB", "1 KB", "1 MB", "1 GB", "9.54 MB", "95.37 MB", "953.67 MB", "9.31 GB"}
        Dim expected = New Long() {0, 10, 100, 1000, 10004, 100004, 999997, 1024, 1024 * 1024, 1024 * 1024 * 1024, 10003415, 100002693, 999995474, 9996536381}

        For i = 0 To source.Length - 1
            Assert.AreEqual(expected(i), source(i).ParseByteSize)
        Next

    End Sub

    '''<summary>
    '''A test for ToByteSize
    '''</summary>
    <TestMethod()> _
    Public Sub ToByteSizeTest()
        Dim source = New Long() {0, 10, 100, 1000, 10000, 100000, 1000000, 1024, 1024 * 1024, 1024 * 1024 * 1024, 10000000, 100000000, 1000000000, 10000000000}
        Dim expected = New String() {"0 B", "10 B", "100 B", "1000 B", "9.77 KB", "97.66 KB", "976.56 KB", "1 KB", "1 MB", "1 GB", "9.54 MB", "95.37 MB", "953.67 MB", "9.31 GB"}

        For i = 0 To source.Length - 1
            Assert.AreEqual(expected(i), source(i).ToByteSize)
        Next

    End Sub

End Class
