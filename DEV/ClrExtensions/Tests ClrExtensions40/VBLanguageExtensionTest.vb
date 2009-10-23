Imports System

Imports ClrExtensions

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.FSharp.Core
Imports ClrExtensions.VBLanguageExtension



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


    '''<summary>
    '''A test for CStr2
    '''</summary>
    <TestMethod()> _
    Public Sub CStr2Test2()
        Dim valueA As Object = Nothing
        Dim valueB As Object = DBNull.Value
        Dim valueC_ As Nullable(Of Integer) = Nothing
        Dim valueC As Object = valueC_
        Dim valueD_ As Nullable(Of Integer) = 5
        Dim valueD As Object = valueD_
        Dim valueE_ As FSharpOption(Of Integer) = FSharpOption(Of Integer).None
        Dim valueE = valueE_
        Dim valueF_ As New FSharpOption(Of Integer)(5)
        Dim valueF = valueF_

        Dim valueG_ As FSharpOption(Of FSharpOption(Of Integer)) = FSharpOption(Of FSharpOption(Of Integer)).None
        Dim valueG = valueG_
        Dim valueH_ As New FSharpOption(Of FSharpOption(Of Integer))(FSharpOption(Of Integer).None)
        Dim valueH = valueH_
        Dim valueI_ As New FSharpOption(Of FSharpOption(Of Integer))(New FSharpOption(Of Integer)(5))
        Dim valueI = valueI_

        Dim valueJ As Object = "5"
        Dim valueK As Object = ""

        Dim defaultValue = "Missing"

        Assert.AreEqual(defaultValue, CStr2(valueA, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueB, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueC, defaultValue))
        Assert.AreEqual("5", CStr2(valueD, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueE, defaultValue))
        Assert.AreEqual("5", CStr2(valueF, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueG, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueH, defaultValue))
        Assert.AreEqual("5", CStr2(valueI, defaultValue))
        Assert.AreEqual("5", CStr2(valueJ, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueK, defaultValue))


    End Sub

    '''<summary>
    '''A test for CStr2
    '''</summary>
    <TestMethod()> _
    Public Sub CStr2Test1()
        Dim valueA As Object = Nothing
        Dim valueB As Object = DBNull.Value
        Dim valueC_ As Nullable(Of Integer) = Nothing
        Dim valueC As Object = valueC_
        Dim valueD_ As Nullable(Of Integer) = 5
        Dim valueD As Object = valueD_
        Dim valueE_ As FSharpOption(Of Integer) = FSharpOption(Of Integer).None
        Dim valueE = valueE_
        Dim valueF_ As New FSharpOption(Of Integer)(5)
        Dim valueF = valueF_

        Dim valueG_ As FSharpOption(Of FSharpOption(Of Integer)) = FSharpOption(Of FSharpOption(Of Integer)).None
        Dim valueG = valueG_
        Dim valueH_ As New FSharpOption(Of FSharpOption(Of Integer))(FSharpOption(Of Integer).None)
        Dim valueH = valueH_
        Dim valueI_ As New FSharpOption(Of FSharpOption(Of Integer))(New FSharpOption(Of Integer)(5))
        Dim valueI = valueI_

        Dim valueJ As Object = "5"
        Dim valueK As Object = ""



        Assert.AreEqual(Nothing, CStr2(valueA))
        Assert.AreEqual(Nothing, CStr2(valueB))
        Assert.AreEqual(Nothing, CStr2(valueC))
        Assert.AreEqual("5", CStr2(valueD))
        Assert.AreEqual(Nothing, CStr2(valueE))
        Assert.AreEqual("5", CStr2(valueF))
        Assert.AreEqual(Nothing, CStr2(valueG))
        Assert.AreEqual(Nothing, CStr2(valueH))
        Assert.AreEqual("5", CStr2(valueI))
        Assert.AreEqual("5", CStr2(valueJ))
        Assert.AreEqual("", CStr2(valueK))
    End Sub

    '''<summary>
    '''A test for CBool2
    '''</summary>
    <TestMethod()> _
    Public Sub CBool2Test()
        Dim defaultValue = True
        Dim values As New List(Of Tuple(Of Object, Boolean?)) From {
            {Nothing, True},
            {DBNull.Value, True},
            {"", True},
            {True, True},
            {False, False}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CBool2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CBool2
    '''</summary>
    <TestMethod()> _
    Public Sub CBool2Test1()

        Dim values As New List(Of Tuple(Of Object, Boolean?)) From {
            {Nothing, Nothing},
            {DBNull.Value, Nothing},
            {"", Nothing},
            {True, True},
            {False, False}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CBool2(a.Item1)))

    End Sub

    '''<summary>
    '''A test for CByte2
    '''</summary>
    <TestMethod()> _
    Public Sub CByte2Test()
        Dim defaultValue = 5
        Dim values As New List(Of Tuple(Of Object, Byte?)) From {
            {Nothing, 5},
            {DBNull.Value, 5},
            {"", 5},
            {0, 0},
            {"100", 100}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CByte2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CByte2
    '''</summary>
    <TestMethod()> _
    Public Sub CByte2Test1()
        Dim values As New List(Of Tuple(Of Object, Byte?)) From {
            {Nothing, Nothing},
            {DBNull.Value, Nothing},
            {"", Nothing},
            {0, 0},
            {"100", 100}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CByte2(a.Item1)))
    End Sub

    '''<summary>
    '''A test for CChar2
    '''</summary>
    <TestMethod()> _
    Public Sub CChar2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Char) = New Nullable(Of Char)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Char)
        actual = VBLanguageExtension.CChar2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CChar2
    '''</summary>
    <TestMethod()> _
    Public Sub CChar2Test1()
        Dim defaultValue = "5"c
        Dim values As New List(Of Tuple(Of Object, Char?)) From {
            {Nothing, defaultValue},
            {DBNull.Value, defaultValue},
            {"", defaultValue},
            {"a"c, "a"c},
            {"A", "A"c}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CChar2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CDate2
    '''</summary>
    <TestMethod()> _
    Public Sub CDate2Test()
        Dim defaultValue = #1/1/2008#
        Dim values As New List(Of Tuple(Of Object, Date?)) From {
            {Nothing, defaultValue},
            {DBNull.Value, defaultValue},
            {"", defaultValue},
            {#1/2/3000#, #1/2/3000#},
            {"1/3/3000", #1/3/3000#}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CDate2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CDate2
    '''</summary>
    <TestMethod()> _
    Public Sub CDate2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of DateTime) = New Nullable(Of DateTime)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of DateTime)
        actual = VBLanguageExtension.CDate2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CDbl2
    '''</summary>
    <TestMethod()> _
    Public Sub CDbl2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Double) = New Nullable(Of Double)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Double)
        actual = VBLanguageExtension.CDbl2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CDbl2
    '''</summary>
    <TestMethod()> _
    Public Sub CDbl2Test1()
        Dim defaultValue As Double = 5
        Dim values As New List(Of Tuple(Of Object, Double?)) From {
            {Nothing, defaultValue},
            {DBNull.Value, defaultValue},
            {"", defaultValue},
            {1.5, 1.5},
            {"3.2", 3.2}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CDbl2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CDec2
    '''</summary>
    <TestMethod()> _
    Public Sub CDec2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of [Decimal]) = New Nullable(Of [Decimal])() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of [Decimal])
        actual = VBLanguageExtension.CDec2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CDec2
    '''</summary>
    <TestMethod()> _
    Public Sub CDec2Test1()
        Dim defaultValue As Decimal = 5
        Dim values As New List(Of Tuple(Of Object, Decimal?)) From {
            {Nothing, defaultValue},
            {DBNull.Value, defaultValue},
            {"", defaultValue},
            {1.5, 1.5},
            {"3.2", 3.2}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CDec2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CInt2
    '''</summary>
    <TestMethod()> _
    Public Sub CInt2Test()
        Dim defaultValue = 5
        Dim values As New List(Of Tuple(Of Object, Integer?)) From {
            {Nothing, defaultValue},
            {DBNull.Value, defaultValue},
            {"", defaultValue},
            {1, 1},
            {"3", 3}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CInt2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CInt2
    '''</summary>
    <TestMethod()> _
    Public Sub CInt2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Integer) = New Nullable(Of Integer)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Integer)
        actual = VBLanguageExtension.CInt2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CLng2
    '''</summary>
    <TestMethod()> _
    Public Sub CLng2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Long) = New Nullable(Of Long)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Long)
        actual = VBLanguageExtension.CLng2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CLng2
    '''</summary>
    <TestMethod()> _
    Public Sub CLng2Test1()
        Dim defaultValue As Long = 5
        Dim values As New List(Of Tuple(Of Object, Long?)) From {
            {Nothing, defaultValue},
            {DBNull.Value, defaultValue},
            {"", defaultValue},
            {1, 1},
            {"3", 3}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CLng2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CSByte2
    '''</summary>
    <TestMethod()> _
    Public Sub CSByte2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of SByte) = New Nullable(Of SByte)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of SByte)
        actual = VBLanguageExtension.CSByte2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CSByte2
    '''</summary>
    <TestMethod()> _
    Public Sub CSByte2Test1()
        Dim defaultValue As SByte = -15
        Dim values As New List(Of Tuple(Of Object, SByte?)) From {
            {Nothing, defaultValue},
            {DBNull.Value, defaultValue},
            {"", defaultValue},
            {-1, -1},
            {"3", 3}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CSByte2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CShort2
    '''</summary>
    <TestMethod()> _
    Public Sub CShort2Test()
        Dim defaultValue As Short = -15
        Dim values As New List(Of Tuple(Of Object, Short?)) From {
            {Nothing, defaultValue},
            {DBNull.Value, defaultValue},
            {"", defaultValue},
            {-1, -1},
            {"3", 3}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CShort2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CShort2
    '''</summary>
    <TestMethod()> _
    Public Sub CShort2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Short) = New Nullable(Of Short)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Short)
        actual = VBLanguageExtension.CShort2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CSng2
    '''</summary>
    <TestMethod()> _
    Public Sub CSng2Test()
        Dim defaultValue As Single = -15
        Dim values As New List(Of Tuple(Of Object, Single?)) From {
            {Nothing, defaultValue},
            {DBNull.Value, defaultValue},
            {"", defaultValue},
            {-1, -1},
            {"3", 3}}

        values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CSng2(a.Item1, defaultValue)))
    End Sub

    '''<summary>
    '''A test for CSng2
    '''</summary>
    <TestMethod()> _
    Public Sub CSng2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Single) = New Nullable(Of Single)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Single)
        actual = VBLanguageExtension.CSng2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CStr2
    '''</summary>
    <TestMethod()> _
    Public Sub CStr2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = VBLanguageExtension.CStr2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CStr2
    '''</summary>
    <TestMethod()> _
    Public Sub CStr2Test3()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = VBLanguageExtension.CStr2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    ''''<summary>
    ''''A test for CStr2
    ''''</summary>
    'Public Sub CStr2Test4Helper(Of T As Structure)()
    'Dim value As Nullable(Of T) = New Nullable(Of T)() ' TODO: Initialize to an appropriate value
    'Dim [default] As String = String.Empty ' TODO: Initialize to an appropriate value
    'Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
    'Dim actual As String
    'actual = VBLanguageExtension.CStr2(Of T)(value, [default])
    'Assert.AreEqual(expected, actual)
    'Assert.Inconclusive("Verify the correctness of this test method.")
    'End Sub

    '<TestMethod()> _
    'Public Sub CStr2Test4()
    'Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " & _
    '"Please call CStr2Test4Helper(Of T) with appropriate type parameters.")
    'End Sub

    ''''<summary>
    ''''A test for CStr2
    ''''</summary>
    'Public Sub CStr2Test5Helper(Of T As Structure)()
    'Dim value As Nullable(Of T) = New Nullable(Of T)() ' TODO: Initialize to an appropriate value
    'Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
    'Dim actual As String
    'actual = VBLanguageExtension.CStr2(Of T)(value)
    'Assert.AreEqual(expected, actual)
    'Assert.Inconclusive("Verify the correctness of this test method.")
    'End Sub

    '<TestMethod()> _
    'Public Sub CStr2Test5()
    'Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " & _
    '"Please call CStr2Test5Helper(Of T) with appropriate type parameters.")
    'End Sub

    '''<summary>
    '''A test for CUInt2
    '''</summary>
    <TestMethod()> _
    Public Sub CUInt2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of UInteger) = New Nullable(Of UInteger)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of UInteger)
        actual = VBLanguageExtension.CUInt2(value)
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
    '''A test for CULng2
    '''</summary>
    <TestMethod()> _
    Public Sub CULng2Test()
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
    Public Sub CULng2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of ULong) = New Nullable(Of ULong)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of ULong)
        actual = VBLanguageExtension.CULng2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CUShort2
    '''</summary>
    <TestMethod()> _
    Public Sub CUShort2Test()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim [default] As UShort = 0 ' TODO: Initialize to an appropriate value
        Dim expected As UShort = 0 ' TODO: Initialize to an appropriate value
        Dim actual As UShort
        actual = VBLanguageExtension.CUShort2(value, [default])
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CUShort2
    '''</summary>
    <TestMethod()> _
    Public Sub CUShort2Test1()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of UShort) = New Nullable(Of UShort)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of UShort)
        actual = VBLanguageExtension.CUShort2(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCBool
    '''</summary>
    <TestMethod()> _
    Public Sub TryCBoolTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Boolean) = New Nullable(Of Boolean)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Boolean)
        actual = VBLanguageExtension.TryCBool(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCByte
    '''</summary>
    <TestMethod()> _
    Public Sub TryCByteTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Byte) = New Nullable(Of Byte)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Byte)
        actual = VBLanguageExtension.TryCByte(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCChar
    '''</summary>
    <TestMethod()> _
    Public Sub TryCCharTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Char) = New Nullable(Of Char)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Char)
        actual = VBLanguageExtension.TryCChar(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCDate
    '''</summary>
    <TestMethod()> _
    Public Sub TryCDateTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of DateTime) = New Nullable(Of DateTime)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of DateTime)
        actual = VBLanguageExtension.TryCDate(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCDbl
    '''</summary>
    <TestMethod()> _
    Public Sub TryCDblTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Double) = New Nullable(Of Double)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Double)
        actual = VBLanguageExtension.TryCDbl(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCDec
    '''</summary>
    <TestMethod()> _
    Public Sub TryCDecTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of [Decimal]) = New Nullable(Of [Decimal])() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of [Decimal])
        actual = VBLanguageExtension.TryCDec(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCInt
    '''</summary>
    <TestMethod()> _
    Public Sub TryCIntTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Integer) = New Nullable(Of Integer)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Integer)
        actual = VBLanguageExtension.TryCInt(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCLng
    '''</summary>
    <TestMethod()> _
    Public Sub TryCLngTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Long) = New Nullable(Of Long)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Long)
        actual = VBLanguageExtension.TryCLng(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCSByte
    '''</summary>
    <TestMethod()> _
    Public Sub TryCSByteTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of SByte) = New Nullable(Of SByte)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of SByte)
        actual = VBLanguageExtension.TryCSByte(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCShort
    '''</summary>
    <TestMethod()> _
    Public Sub TryCShortTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Short) = New Nullable(Of Short)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Short)
        actual = VBLanguageExtension.TryCShort(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCSng
    '''</summary>
    <TestMethod()> _
    Public Sub TryCSngTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of Single) = New Nullable(Of Single)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of Single)
        actual = VBLanguageExtension.TryCSng(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCUInt
    '''</summary>
    <TestMethod()> _
    Public Sub TryCUIntTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of UInteger) = New Nullable(Of UInteger)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of UInteger)
        actual = VBLanguageExtension.TryCUInt(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCULng
    '''</summary>
    <TestMethod()> _
    Public Sub TryCULngTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of ULong) = New Nullable(Of ULong)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of ULong)
        actual = VBLanguageExtension.TryCULng(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for TryCUShort
    '''</summary>
    <TestMethod()> _
    Public Sub TryCUShortTest()
        Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Nullable(Of UShort) = New Nullable(Of UShort)() ' TODO: Initialize to an appropriate value
        Dim actual As Nullable(Of UShort)
        actual = VBLanguageExtension.TryCUShort(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
