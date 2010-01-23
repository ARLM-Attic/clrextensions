Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for EnumExtensionTest and is intended
'''to contain all EnumExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class EnumExtensionTest


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


    '''<summary>
    '''A test for EnumIsDefined
    '''</summary>
    Sub EnumIsDefinedTestHelper(Of T As Structure)()
        Dim value As T = New T() ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = EnumExtension.EnumIsDefined(Of T)(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    <ExpectedException(GetType(ArgumentException))>
    <TestMethod()> _
    Sub EnumIsDefinedTest()
        EnumIsDefined(Of Integer)(0)
    End Sub
End Class
