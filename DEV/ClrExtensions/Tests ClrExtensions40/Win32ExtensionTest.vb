Imports ClrExtensions.Win32

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for Win32ExtensionTest and is intended
'''to contain all Win32ExtensionTest Unit Tests
'''</summary>
<TestClass()>  _
Public Class Win32ExtensionTest
    

Private testContextInstance As TestContext

'''<summary>
'''Gets or sets the test context which provides
'''information about and functionality for the current test run.
'''</summary>
Public Property TestContext() As TestContext
    Get
        Return testContextInstance
    End Get
    Set
        testContextInstance = value
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
#End region


    '''<summary>
    '''A test for ThrowOnError
    '''</summary>
    <TestMethod()> _
    Public Sub ThrowOnErrorTest()
        Dim errorCode As SystemErrorCode = New SystemErrorCode() ' TODO: Initialize to an appropriate value
        Dim validResults() As SystemErrorCode = Nothing ' TODO: Initialize to an appropriate value
        Win32Extension.ThrowOnError(errorCode, validResults)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for ThrowOnError
    '''</summary>
    <TestMethod()> _
    Public Sub ThrowOnErrorTest1()
        Dim errorCode As SystemErrorCode = New SystemErrorCode() ' TODO: Initialize to an appropriate value
        Win32Extension.ThrowOnError(errorCode)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub
End Class
