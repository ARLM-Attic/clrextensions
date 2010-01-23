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
    '''A test for ReadSection
    '''</summary>
    <TestMethod()> _
    Sub ReadSectionTest()

        Dim lock As New ReaderWriterLockSlim
        Using lock.ReadSection
            Assert.AreEqual(True, lock.IsReadLockHeld)
            Assert.AreEqual(False, lock.IsUpgradeableReadLockHeld)
            Assert.AreEqual(False, lock.IsWriteLockHeld)
            Assert.AreEqual(1, lock.CurrentReadCount)
        End Using
        Assert.AreEqual(False, lock.IsReadLockHeld)
        Assert.AreEqual(False, lock.IsUpgradeableReadLockHeld)
        Assert.AreEqual(False, lock.IsWriteLockHeld)
        Assert.AreEqual(0, lock.CurrentReadCount)

    End Sub

    '''<summary>
    '''A test for UpgradeableReadSection
    '''</summary>
    <TestMethod()> _
    Sub UpgradeableReadSectionTest()

        Dim lock As New ReaderWriterLockSlim
        Using lock.UpgradeableReadSection
            Assert.AreEqual(False, lock.IsReadLockHeld)
            Assert.AreEqual(True, lock.IsUpgradeableReadLockHeld)
            Assert.AreEqual(False, lock.IsWriteLockHeld)
            Assert.AreEqual(0, lock.CurrentReadCount)

            Using lock.WriteSection
                Assert.AreEqual(False, lock.IsReadLockHeld)
                Assert.AreEqual(True, lock.IsUpgradeableReadLockHeld)
                Assert.AreEqual(True, lock.IsWriteLockHeld)
                Assert.AreEqual(0, lock.CurrentReadCount)
            End Using

            Assert.AreEqual(False, lock.IsReadLockHeld)
            Assert.AreEqual(True, lock.IsUpgradeableReadLockHeld)
            Assert.AreEqual(False, lock.IsWriteLockHeld)
            Assert.AreEqual(0, lock.CurrentReadCount)
        End Using
        Assert.AreEqual(False, lock.IsReadLockHeld)
        Assert.AreEqual(False, lock.IsUpgradeableReadLockHeld)
        Assert.AreEqual(False, lock.IsWriteLockHeld)
        Assert.AreEqual(0, lock.CurrentReadCount)

    End Sub

    '''<summary>
    '''A test for WriteSection
    '''</summary>
    <TestMethod()> _
    Sub WriteSectionTest()
        Dim lock As New ReaderWriterLockSlim

        Using lock.WriteSection
            Assert.AreEqual(False, lock.IsReadLockHeld)
            Assert.AreEqual(False, lock.IsUpgradeableReadLockHeld)
            Assert.AreEqual(True, lock.IsWriteLockHeld)
            Assert.AreEqual(0, lock.CurrentReadCount)
        End Using
        Assert.AreEqual(False, lock.IsReadLockHeld)
        Assert.AreEqual(False, lock.IsUpgradeableReadLockHeld)
        Assert.AreEqual(False, lock.IsWriteLockHeld)
        Assert.AreEqual(0, lock.CurrentReadCount)

    End Sub

    '''<summary>
    '''A test for ReadSection
    '''</summary>
    <ExpectedException(GetType(ArgumentNullException))>
    <TestMethod()> _
    Sub ReadSectionTest1()
        Dim lock As ReaderWriterLockSlim = Nothing
        ReaderWriterLockSlimExtension.ReadSection(lock)
    End Sub

    '''<summary>
    '''A test for WriteSection
    '''</summary>
    <ExpectedException(GetType(ArgumentNullException))>
    <TestMethod()> _
    Sub WriteSectionTest1()
        Dim lock As ReaderWriterLockSlim = Nothing
        ReaderWriterLockSlimExtension.WriteSection(lock)
    End Sub

    '''<summary>
    '''A test for UpgradeableReadSection
    '''</summary>
    <ExpectedException(GetType(ArgumentNullException))>
    <TestMethod()> _
    Sub UpgradeableReadSectionTest1()
        Dim lock As ReaderWriterLockSlim = Nothing
        ReaderWriterLockSlimExtension.UpgradeableReadSection(lock)
    End Sub
End Class
