﻿Option Strict Off
Imports System
Imports ClrExtensions
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.FSharp.Core
Imports ClrExtensions.VBLanguageExtension




<TestClass()>
Public Class VBLanguageExtensionTest


	Private testContextInstance As TestContext

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
	'<ClassInitialize()> 
	' Shared Sub MyClassInitialize(ByVal testContext As TestContext)
	'End Sub
	'
	'Use ClassCleanup to run code after all tests in a class have run
	'<ClassCleanup()> 
	' Shared Sub MyClassCleanup()
	'End Sub
	'
	'Use TestInitialize to run code before running each test
	'<TestInitialize()> 
	' Sub MyTestInitialize()
	'End Sub
	'
	'Use TestCleanup to run code after each test has run
	'<TestCleanup()> 
	' Sub MyTestCleanup()
	'End Sub
	'
#End Region


	<TestMethod()>
	Sub CStr2Test3()
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

	<TestMethod()>
	Sub CStr2Test1()
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

	<TestMethod()>
	Sub CBool2Test()
		Dim defaultValue = True
		Dim values As New List(Of Tuple(Of Object, Boolean?)) From {
		 {Nothing, True},
		 {DBNull.Value, True},
		 {"", True},
		 {True, True},
		 {False, False}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CBool2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CBool2Test1()

		Dim values As New List(Of Tuple(Of Object, Boolean?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {True, True},
		 {False, False}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CBool2(a.Item1)))

	End Sub

	<TestMethod()>
	Sub CByte2Test()
		Dim defaultValue = 5
		Dim values As New List(Of Tuple(Of Object, Byte?)) From {
		 {Nothing, 5},
		 {DBNull.Value, 5},
		 {"", 5},
		 {0, 0},
		 {"100", 100}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CByte2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CByte2Test1()
		Dim values As New List(Of Tuple(Of Object, Byte?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {0, 0},
		 {"100", 100}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CByte2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CChar2Test()
		Dim values As New List(Of Tuple(Of Object, Char?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {"a"c, "a"c},
		 {"A", "A"c}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CChar2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CChar2Test1()
		Dim defaultValue = "5"c
		Dim values As New List(Of Tuple(Of Object, Char?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {"a"c, "a"c},
		 {"A", "A"c}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CChar2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CDate2Test()
		Dim defaultValue = #1/1/2008#
		Dim values As New List(Of Tuple(Of Object, Date?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {#1/2/3000#, #1/2/3000#},
		 {"1/3/3000", #1/3/3000#}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CDate2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CDate2Test1()
		Dim values As New List(Of Tuple(Of Object, Date?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {#1/2/3000#, #1/2/3000#},
		 {"1/3/3000", #1/3/3000#}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CDate2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CDbl2Test()

		Dim values As New List(Of Tuple(Of Object, Double?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {1.5, 1.5},
		 {"3.2", 3.2}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CDbl2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CDbl2Test1()
		Dim defaultValue As Double = 5
		Dim values As New List(Of Tuple(Of Object, Double?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {1.5, 1.5},
		 {"3.2", 3.2}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CDbl2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CDec2Test()

		Dim values As New List(Of Tuple(Of Object, Decimal?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {1.5, 1.5},
		 {"3.2", 3.2}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CDec2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CDec2Test1()
		Dim defaultValue As Decimal = 5
		Dim values As New List(Of Tuple(Of Object, Decimal?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {1.5, 1.5},
		 {"3.2", 3.2}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CDec2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CInt2Test()
		Dim defaultValue = 5
		Dim values As New List(Of Tuple(Of Object, Integer?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {1, 1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CInt2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CInt2Test1()

		Dim values As New List(Of Tuple(Of Object, Integer?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {1, 1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CInt2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CLng2Test()
		Dim values As New List(Of Tuple(Of Object, Long?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {1, 1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CLng2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CLng2Test1()
		Dim defaultValue As Long = 5
		Dim values As New List(Of Tuple(Of Object, Long?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {1, 1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CLng2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CSByte2Test()
		Dim values As New List(Of Tuple(Of Object, SByte?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {-1, -1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CSByte2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CSByte2Test1()
		Dim defaultValue As SByte = -15
		Dim values As New List(Of Tuple(Of Object, SByte?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {-1, -1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CSByte2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CShort2Test()
		Dim defaultValue As Short = -15
		Dim values As New List(Of Tuple(Of Object, Short?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {-1, -1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CShort2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CShort2Test1()

		Dim values As New List(Of Tuple(Of Object, Short?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {-1, -1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CShort2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CSng2Test()
		Dim defaultValue As Single = -15
		Dim values As New List(Of Tuple(Of Object, Single?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {-1, -1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CSng2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CSng2Test1()
		Dim values As New List(Of Tuple(Of Object, Single?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {-1, -1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CSng2(a.Item1)))
	End Sub


	<TestMethod()>
	Sub CUInt2Test()

		Dim values As New List(Of Tuple(Of Object, UInt32?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {1, 1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CUInt2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CUInt2Test1()
		Dim defaultValue = 5
		Dim values As New List(Of Tuple(Of Object, UInt32?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {1, 1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CUInt2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CULng2Test()
		Dim defaultValue = 5
		Dim values As New List(Of Tuple(Of Object, UInt64?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {1.5, 1.5},
		 {"3.5", 3.5}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CULng2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CULng2Test1()
		Dim defaultValue = 5
		Dim values As New List(Of Tuple(Of Object, UInt64?)) From {
		 {Nothing, defaultValue},
		 {DBNull.Value, defaultValue},
		 {"", defaultValue},
		 {1.5, 1.5},
		 {"3.5", 3.5}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CULng2(a.Item1, defaultValue)))
	End Sub

	<TestMethod()>
	Sub CUShort2Test()
		Dim values As New List(Of Tuple(Of Object, UShort?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {1, 1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CUShort2(a.Item1)))
	End Sub

	<TestMethod()>
	Sub CUShort2Test1()
		Dim values As New List(Of Tuple(Of Object, UShort?)) From {
		 {Nothing, Nothing},
		 {DBNull.Value, Nothing},
		 {"", Nothing},
		 {1, 1},
		 {"3", 3}}

		values.ForEach(Sub(a) Assert.AreEqual(a.Item2, CUShort2(a.Item1)))
	End Sub

	<TestMethod()>
	Public Sub CStr2Test()

		Dim a As New Integer?
		Dim b As Integer? = 1

		Assert.AreEqual(Nothing, CStr2(a))
		Assert.AreEqual("1", CStr2(b))
	End Sub

	<TestMethod()>
	Public Sub CStr2Test2()

		Dim a As New Integer?
		Dim b As Integer? = 1

		Assert.AreEqual("2", CStr2(a, "2"))
		Assert.AreEqual("1", CStr2(b))
	End Sub



	<TestMethod()>
	Public Sub TryCULngTest()
		Dim a = "asd"
		Dim b = "-5"
		Dim c = "5"
		Dim d = ""

		Dim outA As ULong?
		Dim outB As ULong?
		Dim outC As ULong?
		Dim outD As ULong?


		outA = TryCULng(a)
		outB = TryCULng(b)
		outC = TryCULng(c)
		outD = TryCULng(d)

		Assert.AreEqual(Nothing, outA)
		Assert.AreEqual(Nothing, outB)
		Assert.AreEqual(CULng(5), outC)
		Assert.AreEqual(Nothing, outD)



	End Sub

	<TestMethod()>
	Public Sub TryCUShortTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of UShort) = New Nullable(Of UShort)()	' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of UShort)
		actual = VBLanguageExtension.TryCUShort(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCUIntTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of UInteger) = New Nullable(Of UInteger)()	' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of UInteger)
		actual = VBLanguageExtension.TryCUInt(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCSngTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of Single) = New Nullable(Of Single)()	' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of Single)
		actual = VBLanguageExtension.TryCSng(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCShortTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of Short) = New Nullable(Of Short)() ' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of Short)
		actual = VBLanguageExtension.TryCShort(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCSByteTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of SByte) = New Nullable(Of SByte)() ' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of SByte)
		actual = VBLanguageExtension.TryCSByte(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCLngTest()
		Dim value = 123.456D
		Dim expected As Long? = 123.456
		Dim actual As Long?
		actual = VBLanguageExtension.TryCLng(value)
		Assert.AreEqual(expected, actual)
	End Sub

	<TestMethod()>
	Public Sub TryCIntTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of Integer) = New Nullable(Of Integer)() ' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of Integer)
		actual = VBLanguageExtension.TryCInt(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCDecTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of [Decimal]) = New Nullable(Of [Decimal])() ' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of [Decimal])
		actual = VBLanguageExtension.TryCDec(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCDblTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of Double) = New Nullable(Of Double)()	' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of Double)
		actual = VBLanguageExtension.TryCDbl(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCDateTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of DateTime) = New Nullable(Of DateTime)()	' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of DateTime)
		actual = VBLanguageExtension.TryCDate(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCCharTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of Char) = New Nullable(Of Char)()	' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of Char)
		actual = VBLanguageExtension.TryCChar(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCByteTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of Byte) = New Nullable(Of Byte)()	' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of Byte)
		actual = VBLanguageExtension.TryCByte(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub TryCBoolTest()
		Dim value As Object = Nothing ' TODO: Initialize to an appropriate value
		Dim expected As Nullable(Of Boolean) = New Nullable(Of Boolean)() ' TODO: Initialize to an appropriate value
		Dim actual As Nullable(Of Boolean)
		actual = VBLanguageExtension.TryCBool(value)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()>
	Public Sub CTimeSpanTest()
		Dim value As Object = Nothing
		Dim expected As TimeSpan = Nothing
		Dim actual As TimeSpan
		actual = VBLanguageExtension.CTimeSpan(value)
		Assert.AreEqual(expected, actual)

	End Sub


	<TestMethod()>
	<ExpectedException(GetType(FormatException))>
	Public Sub CTimeSpanTest2()
		Dim value = ""
		Dim expected As TimeSpan = Nothing
		Dim actual As TimeSpan
		actual = VBLanguageExtension.CTimeSpan(value)
	End Sub


	<TestMethod()>
	Public Sub CTimeSpanTest3()
		Dim value = "0:10:00"
		Dim expected As TimeSpan = TimeSpan.FromMinutes(10)
		Dim actual As TimeSpan
		actual = VBLanguageExtension.CTimeSpan(value)
	End Sub

	<TestMethod()>
	<ExpectedException(GetType(FormatException))>
	Public Sub CTimeSpanTest4()
		Dim value = "XXX"
		Dim expected As TimeSpan = Nothing
		Dim actual As TimeSpan
		actual = VBLanguageExtension.CTimeSpan(value)
	End Sub

	<TestMethod()>
	<ExpectedException(GetType(InvalidCastException))>
	Public Sub CTimeSpanTest5()
		Dim value = 999
		Dim expected As TimeSpan = Nothing
		Dim actual As TimeSpan
		actual = VBLanguageExtension.CTimeSpan(value)
	End Sub


	<TestMethod()>
	Public Sub CTimeSpan2Test1()
		Dim value = Nothing	' TODO: Initialize to an appropriate value
		Dim expected As TimeSpan? = Nothing
		Dim actual As TimeSpan?
		actual = VBLanguageExtension.CTimeSpan2(value)
		Assert.AreEqual(expected, actual)
	End Sub

	<TestMethod()>
	Public Sub CTimeSpan2Test2()
		Dim value = DBNull.Value	' TODO: Initialize to an appropriate value
		Dim expected As TimeSpan? = Nothing
		Dim actual As TimeSpan?
		actual = VBLanguageExtension.CTimeSpan2(value)
		Assert.AreEqual(expected, actual)
	End Sub

	<TestMethod()>
	Public Sub CTimeSpan2Test3()
		Dim value = TimeSpan.FromMinutes(10)
		Dim expected As TimeSpan? = TimeSpan.FromMinutes(10)
		Dim actual As TimeSpan?
		actual = VBLanguageExtension.CTimeSpan2(value)
		Assert.AreEqual(expected, actual)
	End Sub


	<TestMethod()>
	Public Sub CTimeSpan2Test4()
		Dim value = "0:10:00"
		Dim expected As TimeSpan? = TimeSpan.FromMinutes(10)
		Dim actual As TimeSpan?
		actual = VBLanguageExtension.CTimeSpan2(value)
		Assert.AreEqual(expected, actual)
	End Sub


	<TestMethod()>
	Public Sub CTimeSpan2Test5()
		Dim value = ""
		Dim expected As TimeSpan? = Nothing
		Dim actual As TimeSpan?
		actual = VBLanguageExtension.CTimeSpan2(value)
		Assert.AreEqual(expected, actual)
	End Sub

	<TestMethod()>
	<ExpectedException(GetType(FormatException))>
	Public Sub CTimeSpan2Test6()
		Dim value = "XXX"
		Dim expected As TimeSpan? = Nothing
		Dim actual As TimeSpan?
		actual = VBLanguageExtension.CTimeSpan2(value)
		Assert.AreEqual(expected, actual)
	End Sub

	<TestMethod()>
	<ExpectedException(GetType(InvalidCastException))>
	Public Sub CTimeSpan2Test7()
		Dim value = 999
		Dim expected As TimeSpan? = Nothing
		Dim actual As TimeSpan?
		actual = VBLanguageExtension.CTimeSpan2(value)
		Assert.AreEqual(expected, actual)
	End Sub


End Class
