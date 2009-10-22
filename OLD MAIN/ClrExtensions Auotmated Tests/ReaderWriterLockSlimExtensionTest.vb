Imports System
Imports System.Threading
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ClrExtensions



'''<summary>
'''This is a test class for ReaderWriterLockSlimExtensionTest and is intended
'''to contain all ReaderWriterLockSlimExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ReaderWriterLockSlimExtensionTest


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
    '''A test for WriteSection
    '''</summary>
    <TestMethod()> _
    Public Sub WriteSectionTest()
        Dim lock As New ReaderWriterLockSlim

        Assert.IsFalse(lock.IsReadLockHeld)
        Assert.IsFalse(lock.IsUpgradeableReadLockHeld)
        Assert.IsFalse(lock.IsWriteLockHeld)

        Using lock.WriteSection
            Assert.IsFalse(lock.IsReadLockHeld)
            Assert.IsFalse(lock.IsUpgradeableReadLockHeld)
            Assert.IsTrue(lock.IsWriteLockHeld)
        End Using

        Assert.IsFalse(lock.IsReadLockHeld)
        Assert.IsFalse(lock.IsUpgradeableReadLockHeld)
        Assert.IsFalse(lock.IsWriteLockHeld)
    End Sub

    '''<summary>
    '''A test for UpgradeableReadSection
    '''</summary>
    <TestMethod()> _
    Public Sub UpgradeableReadSectionTest()
        Dim lock As New ReaderWriterLockSlim

        Assert.IsFalse(lock.IsReadLockHeld)
        Assert.IsFalse(lock.IsUpgradeableReadLockHeld)
        Assert.IsFalse(lock.IsWriteLockHeld)

        Using lock.UpgradeableReadSection
            Assert.IsFalse(lock.IsReadLockHeld)
            Assert.IsTrue(lock.IsUpgradeableReadLockHeld)
            Assert.IsFalse(lock.IsWriteLockHeld)

            Using lock.WriteSection
                Assert.IsFalse(lock.IsReadLockHeld)
                Assert.IsTrue(lock.IsUpgradeableReadLockHeld)
                Assert.IsTrue(lock.IsWriteLockHeld)
            End Using

            Assert.IsFalse(lock.IsReadLockHeld)
            Assert.IsTrue(lock.IsUpgradeableReadLockHeld)
            Assert.IsFalse(lock.IsWriteLockHeld)

        End Using

        Assert.IsFalse(lock.IsReadLockHeld)
        Assert.IsFalse(lock.IsUpgradeableReadLockHeld)
        Assert.IsFalse(lock.IsWriteLockHeld)
    End Sub

    '''<summary>
    '''A test for ReadSection
    '''</summary>
    <TestMethod()> _
    Public Sub ReadSectionTest()
        Dim lock As New ReaderWriterLockSlim

        Assert.IsFalse(lock.IsReadLockHeld)
        Assert.IsFalse(lock.IsUpgradeableReadLockHeld)
        Assert.IsFalse(lock.IsWriteLockHeld)

        Using lock.ReadSection
            Assert.IsTrue(lock.IsReadLockHeld)
            Assert.IsFalse(lock.IsUpgradeableReadLockHeld)
            Assert.IsFalse(lock.IsWriteLockHeld)
        End Using

        Assert.IsFalse(lock.IsReadLockHeld)
        Assert.IsFalse(lock.IsUpgradeableReadLockHeld)
        Assert.IsFalse(lock.IsWriteLockHeld)
    End Sub
End Class
