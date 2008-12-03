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
    '''A test for Cint2
    '''</summary>
    <TestMethod()> <ExpectedException(GetType(InvalidCastException))> _
    Public Sub Cint2Testb()
        CInt2("g")
    End Sub


    '''<summary>
    '''A test for TryCUShort
    '''</summary>
    <TestMethod()> _
    Public Sub TryCUShortTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Integer) = New Nullable(Of Integer) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Integer)
        actual = VBLanguageExtension.TryCUShort(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCULng
    '''</summary>
    <TestMethod()> _
    Public Sub TryCULngTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of ULong) = New Nullable(Of ULong) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of ULong)
        actual = VBLanguageExtension.TryCULng(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCUInt
    '''</summary>
    <TestMethod()> _
    Public Sub TryCUIntTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of UInteger) = New Nullable(Of UInteger) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of UInteger)
        actual = VBLanguageExtension.TryCUInt(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCSng
    '''</summary>
    <TestMethod()> _
    Public Sub TryCSngTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Single) = New Nullable(Of Single) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Single)
        actual = VBLanguageExtension.TryCSng(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCShort
    '''</summary>
    <TestMethod()> _
    Public Sub TryCShortTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Short) = New Nullable(Of Short) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Short)
        actual = VBLanguageExtension.TryCShort(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCSByte
    '''</summary>
    <TestMethod()> _
    Public Sub TryCSByteTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of SByte) = New Nullable(Of SByte) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of SByte)
        actual = VBLanguageExtension.TryCSByte(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCLng
    '''</summary>
    <TestMethod()> _
    Public Sub TryCLngTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Long) = New Nullable(Of Long) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Long)
        actual = VBLanguageExtension.TryCLng(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCInt
    '''</summary>
    <TestMethod()> _
    Public Sub TryCIntTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Integer) = New Nullable(Of Integer) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Integer)
        actual = VBLanguageExtension.TryCInt(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCDec
    '''</summary>
    <TestMethod()> _
    Public Sub TryCDecTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of [Decimal]) = New Nullable(Of [Decimal]) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of [Decimal])
        actual = VBLanguageExtension.TryCDec(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCDbl
    '''</summary>
    <TestMethod()> _
    Public Sub TryCDblTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Double) = New Nullable(Of Double) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Double)
        actual = VBLanguageExtension.TryCDbl(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
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
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Byte) = New Nullable(Of Byte) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Byte)
        actual = VBLanguageExtension.TryCByte(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
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
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        actual = VBLanguageExtension.CUShort2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
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
    '''A test for CULng2
    '''</summary>
    <TestMethod()> _
    Public Sub CULng2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As ULong = 0 ' TODO: Initialize to an appropriate value
        Dim expected As ULong = 0 ' TODO: Initialize to an appropriate value
        Dim actual As ULong
        actual = VBLanguageExtension.CULng2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CULng2
    '''</summary>
    <TestMethod()> _
    Public Sub CULng2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of ULong) = New Nullable(Of ULong) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of ULong)
        actual = VBLanguageExtension.CULng2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CUInt2
    '''</summary>
    <TestMethod()> _
    Public Sub CUInt2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As UInteger = 0 ' TODO: Initialize to an appropriate value
        Dim expected As UInteger = 0 ' TODO: Initialize to an appropriate value
        Dim actual As UInteger
        actual = VBLanguageExtension.CUInt2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
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
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As SByte = 0 ' TODO: Initialize to an appropriate value
        Dim expected As SByte = 0 ' TODO: Initialize to an appropriate value
        Dim actual As SByte
        actual = VBLanguageExtension.CSByte2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
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
    '''A test for CLng2
    '''</summary>
    <TestMethod()> _
    Public Sub CLng2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As Long = 0 ' TODO: Initialize to an appropriate value
        Dim expected As Long = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Long
        actual = VBLanguageExtension.CLng2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CLng2
    '''</summary>
    <TestMethod()> _
    Public Sub CLng2Test()
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
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Integer) = New Nullable(Of Integer) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Integer)
        actual = VBLanguageExtension.CInt2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CInt2
    '''</summary>
    <TestMethod()> _
    Public Sub CInt2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        actual = VBLanguageExtension.CInt2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CDec2
    '''</summary>
    <TestMethod()> _
    Public Sub CDec2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As [Decimal] = New [Decimal] ' TODO: Initialize to an appropriate value
        Dim expected As [Decimal] = New [Decimal] ' TODO: Initialize to an appropriate value
        Dim actual As [Decimal]
        actual = VBLanguageExtension.CDec2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CDec2
    '''</summary>
    <TestMethod()> _
    Public Sub CDec2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of [Decimal]) = New Nullable(Of [Decimal]) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of [Decimal])
        actual = VBLanguageExtension.CDec2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
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
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of DateTime) = New Nullable(Of DateTime) ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of DateTime)
        actual = VBLanguageExtension.CDate2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CDate2
    '''</summary>
    <TestMethod()> _
    Public Sub CDate2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As DateTime = New DateTime ' TODO: Initialize to an appropriate value
        Dim expected As DateTime = New DateTime ' TODO: Initialize to an appropriate value
        Dim actual As DateTime
        actual = VBLanguageExtension.CDate2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
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
