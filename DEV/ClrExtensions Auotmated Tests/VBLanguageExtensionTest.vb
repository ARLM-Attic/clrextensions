Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for VBLanguageExtensionTest and is intended
'''to contain all VBLanguageExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class VBLanguageExtensionTest


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
    '''A test for TryCUShort
    '''</summary>
    <TestMethod()> _
    Public Sub TryCUShortTest()

        Dim expected As UShort?() = New UShort?() {Nothing, Nothing, Nothing, UShort.MinValue, Nothing, 0, 1, UShort.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", UShort.MinValue.ToString, "-1", "0", "1", UShort.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As UShort

        For i = 0 To expected.Count - 1
            actual(i) = TryCUShort(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)

    End Sub

    '''<summary>
    '''A test for TryCULng
    '''</summary>
    <TestMethod()> _
    Public Sub TryCULngTest()
        Dim expected As ULong?() = New ULong?() {Nothing, Nothing, Nothing, ULong.MinValue, Nothing, 0, 1, ULong.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", ULong.MinValue.ToString, "-1", "0", "1", ULong.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As ULong

        For i = 0 To expected.Count - 1
            actual(i) = TryCULng(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for TryCUInt
    '''</summary>
    <TestMethod()> _
    Public Sub TryCUIntTest()
        Dim expected As UInteger?() = New UInteger?() {Nothing, Nothing, Nothing, ULong.MinValue, Nothing, 0, 1, UInt32.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", UInteger.MinValue.ToString, "-1", "0", "1", UInteger.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As UInteger

        For i = 0 To expected.Count - 1
            actual(i) = TryCUInt(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for TryCSng
    '''</summary>
    <TestMethod()> _
    Public Sub TryCSngTest()
        Dim expected As Single?() = New Single?() {Nothing, Nothing, Nothing, -1, 0, 1, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", "-1", "0", "1", 0}

        Dim actual?(expected.Length - 1) As Single

        For i = 0 To expected.Count - 1
            actual(i) = TryCSng(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for TryCShort
    '''</summary>
    <TestMethod()> _
    Public Sub TryCShortTest()
        Dim expected As Short?() = New Short?() {Nothing, Nothing, Nothing, Short.MinValue, -1, 0, 1, Short.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Short.MinValue.ToString, "-1", "0", "1", Short.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As Short

        For i = 0 To expected.Count - 1
            actual(i) = TryCShort(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for TryCSByte
    '''</summary>
    <TestMethod()> _
    Public Sub TryCSByteTest()
        Dim expected As SByte?() = New SByte?() {Nothing, Nothing, Nothing, SByte.MinValue, -1, 0, 1, SByte.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", SByte.MinValue.ToString, "-1", "0", "1", SByte.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As SByte

        For i = 0 To expected.Count - 1
            actual(i) = TryCSByte(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for TryCLng
    '''</summary>
    <TestMethod()> _
    Public Sub TryCLngTest()
        Dim expected As Long?() = New Long?() {Nothing, Nothing, Nothing, Long.MinValue, -1, 0, 1, Long.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Long.MinValue.ToString, "-1", "0", "1", Long.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As Long

        For i = 0 To expected.Count - 1
            actual(i) = TryCLng(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for TryCInt
    '''</summary>
    <TestMethod()> _
    Public Sub TryCIntTest()
        Dim expected As Integer?() = New Integer?() {Nothing, Nothing, Nothing, Integer.MinValue, -1, 0, 1, Integer.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Integer.MinValue.ToString, "-1", "0", "1", Integer.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As Integer

        For i = 0 To expected.Count - 1
            actual(i) = TryCInt(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for TryCDec
    '''</summary>
    <TestMethod()> _
    Public Sub TryCDecTest()
        Dim expected As Decimal?() = New Decimal?() {Nothing, Nothing, Nothing, Decimal.MinValue, -1, 0, 1, Decimal.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Decimal.MinValue.ToString, "-1", "0", "1", Decimal.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As Decimal

        For i = 0 To expected.Count - 1
            actual(i) = TryCDec(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for TryCDbl
    '''</summary>
    <TestMethod()> _
    Public Sub TryCDblTest()
        Dim expected As Double?() = New Double?() {Nothing, Nothing, Nothing, Nothing, -1, 0, 1, Nothing, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Double.MinValue.ToString, "-1", "0", "1", Double.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As Double

        For i = 0 To expected.Count - 1
            actual(i) = TryCDbl(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for TryCDate
    '''</summary>
    <TestMethod()> _
    Public Sub TryCDateTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of DateTime) = New Nullable(Of DateTime) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of DateTime)
        actual = VBLanguageExtension.TryCDate(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCChar
    '''</summary>
    <TestMethod()> _
    Public Sub TryCCharTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Char) = New Nullable(Of Char) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Char)
        actual = VBLanguageExtension.TryCChar(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCByte
    '''</summary>
    <TestMethod()> _
    Public Sub TryCByteTest()
        Dim expected As Byte?() = New Byte?() {Nothing, Nothing, Nothing, Byte.MinValue, Nothing, 0, 1, Byte.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Byte.MinValue.ToString, "-1", "0", "1", Byte.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As Byte

        For i = 0 To expected.Count - 1
            actual(i) = TryCByte(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for TryCBool
    '''</summary>
    <TestMethod()> _
    Public Sub TryCBoolTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Boolean) = New Nullable(Of Boolean) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Boolean)
        actual = VBLanguageExtension.TryCBool(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CUShort2
    '''</summary>
    <TestMethod()> _
    Public Sub CUShort2Test1()
        Dim expected As UShort?() = New UShort?() {Nothing, Nothing, Nothing, UShort.MinValue, 0, 1, UShort.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", UShort.MinValue.ToString, "0", "1", UShort.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As UShort

        For i = 0 To expected.Count - 1
            actual(i) = CUShort2(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for CUShort2
    '''</summary>
    <TestMethod()> _
    Public Sub CUShort2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Integer) = New Nullable(Of Integer) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Integer)
        actual = VBLanguageExtension.CUShort2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CLng2
    '''</summary>
    <TestMethod()> _
    Public Sub CLng2Test1()
        Dim expected As Long() = New Long() {5, 5, 5, Integer.MinValue, -1, 0, 1, Long.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Long.MinValue.ToString, "-1", "0", "1", Long.MaxValue.ToString, 0}

        Dim actual(expected.Length - 1) As Long

        For i = 0 To expected.Count - 1
            actual(i) = CLng2(source(i), 5)
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for CLng2
    '''</summary>
    <TestMethod()> _
    Public Sub CLng2Test()
        Dim expected As Long?() = New Long?() {Nothing, Nothing, Nothing, Long.MinValue, -1, 0, 1, Long.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Long.MinValue.ToString, "-1", "0", "1", Long.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As Long

        For i = 0 To expected.Count - 1
            actual(i) = CLng2(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for CUInt2
    '''</summary>
    <TestMethod()> _
    Public Sub CUInt2Test1()
        Dim expected As UInteger() = New UInteger() {5, 5, 5, UInteger.MinValue, 0, 1, UInteger.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", UInteger.MinValue.ToString, "0", "1", UInteger.MaxValue.ToString, 0}

        Dim actual(expected.Length - 1) As UInteger

        For i = 0 To expected.Count - 1
            actual(i) = CUInt2(source(i), 5)
        Next

        CollectionAssert.AreEqual(expected, actual)

    End Sub

    '''<summary>
    '''A test for CUInt2
    '''</summary>
    <TestMethod()> _
    Public Sub CUInt2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of UInteger) = New Nullable(Of UInteger) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of UInteger)
        actual = VBLanguageExtension.CUInt2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CStr2
    '''</summary>
    <TestMethod()> _
    Public Sub CStr2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = VBLanguageExtension.CStr2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CSng2
    '''</summary>
    <TestMethod()> _
    Public Sub CSng2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As Single = 0.0! ' TODO: Initialize to an appropriate value
        Dim expected As Single = 0.0! ' TODO: Initialize to an appropriate value
        Dim actual As Single
        actual = VBLanguageExtension.CSng2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CSng2
    '''</summary>
    <TestMethod()> _
    Public Sub CSng2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Single) = New Nullable(Of Single) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Single)
        actual = VBLanguageExtension.CSng2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CShort2
    '''</summary>
    <TestMethod()> _
    Public Sub CShort2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Short) = New Nullable(Of Short) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Short)
        actual = VBLanguageExtension.CShort2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CShort2
    '''</summary>
    <TestMethod()> _
    Public Sub CShort2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As Short = 0 ' TODO: Initialize to an appropriate value
        Dim expected As Short = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Short
        actual = VBLanguageExtension.CShort2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CSByte2
    '''</summary>
    <TestMethod()> _
    Public Sub CSByte2Test1()

        Dim expected As Byte() = New Byte() {5, 5, 5, Byte.MinValue, 0, 1, Byte.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Byte.MinValue.ToString, "0", "1", Byte.MaxValue.ToString, 0}

        Dim actual(expected.Length - 1) As Byte

        For i = 0 To expected.Count - 1
            actual(i) = CByte2(source(i), 5)
        Next

        CollectionAssert.AreEqual(expected, actual)

    End Sub

    '''<summary>
    '''A test for CSByte2
    '''</summary>
    <TestMethod()> _
    Public Sub CSByte2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of SByte) = New Nullable(Of SByte) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of SByte)
        actual = VBLanguageExtension.CSByte2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CULng2
    '''</summary>
    <TestMethod()> _
    Public Sub CULng2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As Long = 0 ' TODO: Initialize to an appropriate value
        Dim expected As Long = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Long
        actual = VBLanguageExtension.CLng2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CULng2
    '''</summary>
    <TestMethod()> _
    Public Sub CULng2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Long) = New Nullable(Of Long) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Long)
        actual = VBLanguageExtension.CLng2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CInt2
    '''</summary>
    <TestMethod()> _
    Public Sub CInt2Test1()
        Dim expected As Integer?() = New Integer?() {Nothing, Nothing, Nothing, Integer.MinValue, -1, 0, 1, Integer.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Integer.MinValue.ToString, "-1", "0", "1", Integer.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As Integer

        For i = 0 To expected.Count - 1
            actual(i) = CInt2(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for CInt2
    '''</summary>
    <TestMethod()> _
    Public Sub CInt2Test()
        Dim expected As Integer() = New Integer() {5, 5, 5, Integer.MinValue, -1, 0, 1, Integer.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Integer.MinValue.ToString, "-1", "0", "1", Integer.MaxValue.ToString, 0}

        Dim actual(expected.Length - 1) As Integer

        For i = 0 To expected.Count - 1
            actual(i) = CInt2(source(i), 5)
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for CDec2
    '''</summary>
    <TestMethod()> _
    Public Sub CDec2Test1()
        Dim expected As Decimal?() = New Decimal?() {Nothing, Nothing, Nothing, Decimal.MinValue, -1, 0, 1, Decimal.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Decimal.MinValue.ToString, "-1", "0", "1", Decimal.MaxValue.ToString, 0}

        Dim actual?(expected.Length - 1) As Decimal

        For i = 0 To expected.Count - 1
            actual(i) = CDec2(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for CDec2
    '''</summary>
    <TestMethod()> _
    Public Sub CDec2Test()
        Dim expected As Decimal() = New Decimal() {5, 5, 5, Decimal.MinValue, -1, 0, 1, Decimal.MaxValue, 0}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Decimal.MinValue.ToString, "-1", "0", "1", Decimal.MaxValue.ToString, 0}

        Dim actual(expected.Length - 1) As Decimal

        For i = 0 To expected.Count - 1
            actual(i) = CDec2(source(i), 5)
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for CDbl2
    '''</summary>
    <TestMethod()> _
    Public Sub CDbl2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As Double = 0.0! ' TODO: Initialize to an appropriate value
        Dim expected As Double = 0.0! ' TODO: Initialize to an appropriate value
        Dim actual As Double
        actual = VBLanguageExtension.CDbl2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CDbl2
    '''</summary>
    <TestMethod()> _
    Public Sub CDbl2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Double) = New Nullable(Of Double) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Double)
        actual = VBLanguageExtension.CDbl2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CDate2
    '''</summary>
    <TestMethod()> _
    Public Sub CDate2Test1()
        Dim expected As Date?() = New Date?() {Nothing, Nothing, Nothing, Date.MinValue, #1/10/2000#}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Date.MinValue.ToString, "#1/10/2000#"}

        Dim actual?(expected.Length - 1) As Date

        For i = 0 To expected.Count - 1
            actual(i) = CDate2(source(i))
        Next

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for CDate2
    '''</summary>
    <TestMethod()> _
    Public Sub CDate2Test()

        Dim expected As Date() = New Date() {#1/1/2000#, #1/1/2000#, #1/1/2000#, Date.MinValue, #1/10/2000#}
        Dim source As Object() = New Object() {DBNull.Value, Nothing, "", Date.MinValue.ToString, "#1/10/2000#"}

        Dim actual(expected.Length - 1) As Date

        For i = 0 To expected.Count - 1
            actual(i) = CDate2(source(i), #1/1/2000#)
        Next

        CollectionAssert.AreEqual(expected, actual)

    End Sub

    '''<summary>
    '''A test for CChar2
    '''</summary>
    <TestMethod()> _
    Public Sub CChar2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As Char = Global.Microsoft.VisualBasic.ChrW(0) ' TODO: Initialize to an appropriate value
        Dim expected As Char = Global.Microsoft.VisualBasic.ChrW(0) ' TODO: Initialize to an appropriate value
        Dim actual As Char
        actual = VBLanguageExtension.CChar2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CChar2
    '''</summary>
    <TestMethod()> _
    Public Sub CChar2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Char) = New Nullable(Of Char) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Char)
        actual = VBLanguageExtension.CChar2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CByte2
    '''</summary>
    <TestMethod()> _
    Public Sub CByte2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Byte) = New Nullable(Of Byte) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Byte)
        actual = VBLanguageExtension.CByte2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CByte2
    '''</summary>
    <TestMethod()> _
    Public Sub CByte2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As Byte = 0 ' TODO: Initialize to an appropriate value
        Dim expected As Byte = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Byte
        actual = VBLanguageExtension.CByte2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CBool2
    '''</summary>
    <TestMethod()> _
    Public Sub CBool2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Boolean) = New Nullable(Of Boolean) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Boolean)
        actual = VBLanguageExtension.CBool2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CBool2
    '''</summary>
    <TestMethod()> _
    Public Sub CBool2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As Boolean = False ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = VBLanguageExtension.CBool2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
