Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions.Win32
Imports System.Runtime.InteropServices



'''<summary>
'''This is a test class for StructPointerTest and is intended
'''to contain all StructPointerTest Unit Tests
'''</summary>
<TestClass()> _
Public Class StructPointerTest


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
#End Region

    <TestMethod()> _
    Public Sub StructPointerTest1()
        Dim s = New Foo
        s.A = 5
        s.B = 20
        s.C = 40

        Using sp As New StructPointer(Of Foo)(s)
            Assert.AreEqual(5, Marshal.ReadInt32(sp.Pointer))
            Assert.AreEqual(20, Marshal.ReadInt32(sp.Pointer, 4))
            Assert.AreEqual(CLng(40), Marshal.ReadInt64(sp.Pointer, 8))

            Marshal.WriteInt32(sp.Pointer, 50)
            Marshal.WriteInt32(sp.Pointer, 4, 2)
            Marshal.WriteInt32(sp.Pointer, 8, 4)

            Assert.AreEqual(50, Marshal.ReadInt32(sp.Pointer))
            Assert.AreEqual(2, Marshal.ReadInt32(sp.Pointer, 4))
            Assert.AreEqual(CLng(4), Marshal.ReadInt64(sp.Pointer, 8))

            s = sp.ToStructure
        End Using

        Assert.AreEqual(50, s.A)
        Assert.AreEqual(2, s.B)
        Assert.AreEqual(CLng(4), s.C)

    End Sub

    <TestMethod()>
    <ExpectedException(GetType(InvalidOperationException))>
    Public Sub StructPointerTest2()
        Dim s = New Foo
        Dim sp As New StructPointer(Of Foo)(s)
        sp.Dispose()
        Dim ptr = sp.Pointer
    End Sub

    <TestMethod()> _
    Public Sub StructPointerTest3()
        Dim s = New Foo
        s.A = 5
        s.B = 20
        s.C = 40

        Using sp As New StructPointer(Of Foo)
            Assert.AreEqual(0, Marshal.ReadInt32(sp.Pointer))
            Assert.AreEqual(0, Marshal.ReadInt32(sp.Pointer, 4))
            Assert.AreEqual(CLng(0), Marshal.ReadInt64(sp.Pointer, 8))

            Marshal.WriteInt32(sp.Pointer, 50)
            Marshal.WriteInt32(sp.Pointer, 4, 2)
            Marshal.WriteInt32(sp.Pointer, 8, 4)

            Assert.AreEqual(50, Marshal.ReadInt32(sp.Pointer))
            Assert.AreEqual(2, Marshal.ReadInt32(sp.Pointer, 4))
            Assert.AreEqual(CLng(4), Marshal.ReadInt64(sp.Pointer, 8))

            s = sp.ToStructure
        End Using

        Assert.AreEqual(50, s.A)
        Assert.AreEqual(2, s.B)
        Assert.AreEqual(CLng(4), s.C)

    End Sub

    <TestMethod()> _
    Public Sub StructPointerTest4()
        Dim s = New Foo
        s.A = 5
        s.B = 20
        s.C = 40

        Using sp As New StructPointer(Of Foo)(4 + 4 + 16)
            Assert.AreEqual(0, Marshal.ReadInt32(sp.Pointer))
            Assert.AreEqual(0, Marshal.ReadInt32(sp.Pointer, 4))
            Assert.AreEqual(CLng(0), Marshal.ReadInt64(sp.Pointer, 8))

            Marshal.WriteInt32(sp.Pointer, 50)
            Marshal.WriteInt32(sp.Pointer, 4, 2)
            Marshal.WriteInt32(sp.Pointer, 8, 4)

            Assert.AreEqual(50, Marshal.ReadInt32(sp.Pointer))
            Assert.AreEqual(2, Marshal.ReadInt32(sp.Pointer, 4))
            Assert.AreEqual(CLng(4), Marshal.ReadInt64(sp.Pointer, 8))

            s = sp.ToStructure
        End Using

        Assert.AreEqual(50, s.A)
        Assert.AreEqual(2, s.B)
        Assert.AreEqual(CLng(4), s.C)

    End Sub

    <TestMethod()>
    Public Sub StructPointerTest5()
        'This tests the finalizer

        Dim s = New Foo
        Dim sp As New StructPointer(Of Foo)(s)
        sp = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()

    End Sub


    Structure Foo
        Public A As Int32
        Public B As Int32
        Public C As Int64
    End Structure
End Class
