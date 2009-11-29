Imports System.Threading

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for ReaderWriterLockSlimExtension_LockTokenTest and is intended
'''to contain all ReaderWriterLockSlimExtension_LockTokenTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ReaderWriterLockSlimExtension_LockTokenTest


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
    '''A test for LockToken Constructor
    '''</summary>
    <ExpectedException(GetType(ArgumentNullException))>
    <TestMethod(), _
     DeploymentItem("ClrExtensions40.dll")> _
    Public Sub ReaderWriterLockSlimExtension_LockTokenConstructorTest()
        Dim lock As ReaderWriterLockSlim = Nothing
        Dim mode As ReaderWriterLockSlimExtension_Accessor.LockMode = Nothing
        Dim target As ReaderWriterLockSlimExtension_Accessor.LockToken = New ReaderWriterLockSlimExtension_Accessor.LockToken(lock, mode)
    End Sub

    '''<summary>
    '''A test for LockToken Constructor
    '''</summary>
    <ExpectedException(GetType(ArgumentOutOfRangeException))>
    <TestMethod(), _
     DeploymentItem("ClrExtensions40.dll")> _
    Public Sub ReaderWriterLockSlimExtension_LockTokenConstructorTest2()
        Dim lock As New ReaderWriterLockSlim
        Dim mode As New ReaderWriterLockSlimExtension_Accessor.LockMode(New PrivateObject(-1))
        Dim target As ReaderWriterLockSlimExtension_Accessor.LockToken = New ReaderWriterLockSlimExtension_Accessor.LockToken(lock, mode)
    End Sub

End Class
