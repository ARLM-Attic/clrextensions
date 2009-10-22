Imports System.Collections.Generic
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ClrExtensions

'''<summary>
'''This is a test class for ByteExtensionTest and is intended
'''to contain all ByteExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ByteExtensionTest
	Dim BitStrings As String() = New String() {"00000000", "00000001", "00000010", "00000011", "00000100", "00011010", "10010001", "11111111"}
	Dim LowerHexStrings As String() = New String() {"00", "01", "02", "03", "04", "1a", "91", "ff"}
	Dim UpperHexStrings As String() = New String() {"00", "01", "02", "03", "04", "1A", "91", "FF"}

	Dim b0 As Byte = 0
	Dim b1 As Byte = 1
	Dim b2 As Byte = 2
	Dim b3 As Byte = 3
	Dim b4 As Byte = 4
	Dim b5 As Byte = 26
	Dim b6 As Byte = 145
	Dim bMax As Byte = 255
	Dim bArray As Byte() = New Byte() {b0, b1, b2, b3, b4, b5, b6, bMax}
	Dim bList As New List(Of Byte)(bArray)

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
	'''A test for ToString
	'''</summary>
	<TestMethod()> _
	Public Sub ToStringTest5()

		For i = 0 To bArray.Count - 1
			Assert.AreEqual(BitStrings(i),ByteExtension.ToString(bArray(i), ByteFormat.Bits))
		Next
		For i = 0 To bArray.Count - 1
			Assert.AreEqual(LowerHexStrings(i), ByteExtension.ToString(bArray(i), ByteFormat.LowerCaseHex))
		Next
		For i = 0 To bArray.Count - 1
			Assert.AreEqual(UpperHexStrings(i), ByteExtension.ToString(bArray(i), ByteFormat.UpperCaseHex))
		Next

		Assert.AreEqual(BitStrings(0), ByteExtension.ToString(CByte(Nothing), ByteFormat.Bits))
		Assert.AreEqual(LowerHexStrings(0), ByteExtension.ToString(CByte(Nothing), ByteFormat.LowerCaseHex))
		Assert.AreEqual(UpperHexStrings(0),ByteExtension.ToString(CByte(Nothing), ByteFormat.UpperCaseHex))

	End Sub

	'''<summary>
	'''A test for ToString
	'''</summary>
	<TestMethod()> _
	Public Sub ToStringTest4()
		'bList versions skips the pre-allocation logic


		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), ByteFormat.Bits))
		Assert.AreEqual("", ByteExtension.ToString(New Byte() {}, ByteFormat.Bits))
		Assert.AreEqual("", ByteExtension.ToString(New List(Of Byte), ByteFormat.Bits))
		Assert.AreEqual(String.Join(" ", BitStrings), ByteExtension.ToString(bArray, ByteFormat.Bits))
		Assert.AreEqual(String.Join(" ", BitStrings), ByteExtension.ToString(bList, ByteFormat.Bits))
		Assert.AreEqual(String.Join(" ", BitStrings), ByteExtension.ToString(bList.Take(100), ByteFormat.Bits))

		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), ByteFormat.LowerCaseHex))
		Assert.AreEqual("", ByteExtension.ToString(New Byte() {}, ByteFormat.LowerCaseHex))
		Assert.AreEqual("", ByteExtension.ToString(New List(Of Byte), ByteFormat.LowerCaseHex))
		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bArray, ByteFormat.LowerCaseHex))
		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bList, ByteFormat.LowerCaseHex))
		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bList.Take(100), ByteFormat.LowerCaseHex))

		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), ByteFormat.UpperCaseHex))
		Assert.AreEqual("", ByteExtension.ToString(New Byte() {}, ByteFormat.UpperCaseHex))
		Assert.AreEqual("", ByteExtension.ToString(New List(Of Byte), ByteFormat.UpperCaseHex))
		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bArray, ByteFormat.UpperCaseHex))
		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bList, ByteFormat.UpperCaseHex))
		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bList.Take(100), ByteFormat.UpperCaseHex))


	End Sub


	<TestMethod()> _
	<ExpectedException(GetType(ArgumentOutOfRangeException))> _
	Public Sub ToStringTest3a()
		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), ByteFormat.Bits, 2))
	End Sub

	<TestMethod()> _
	  <ExpectedException(GetType(ArgumentOutOfRangeException))> _
	  Public Sub ToStringTest3b()
		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), ByteFormat.LowerCaseHex, -1))
	End Sub

	<TestMethod()> _
	  <ExpectedException(GetType(ArgumentOutOfRangeException))> _
	  Public Sub ToStringTest3c()
		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), CType(5, ByteFormat), 0))
	End Sub

	Private Shared Function ToStringTest3Extracted(ByVal source As String(), ByVal groupSize As Integer) As String
		Dim a = source.Chunk(groupSize)
		Dim aa As New List(Of String)
		For i = 0 To a.Count - 1
			aa.Add(String.Join("", a(i).ToArray))
		Next
		Return String.Join(" ", aa.ToArray)
	End Function



	'''<summary>
	'''A test for ToString
	'''</summary>
	<TestMethod()> _
	Public Sub ToStringTest3()
		Dim groupSize = 0
		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), ByteFormat.Bits, groupSize))
		Assert.AreEqual("", ByteExtension.ToString(New Byte() {}, ByteFormat.Bits, groupSize))
		Assert.AreEqual("", ByteExtension.ToString(New List(Of Byte), ByteFormat.Bits, groupSize))

		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), ByteFormat.LowerCaseHex, groupSize))
		Assert.AreEqual("", ByteExtension.ToString(New Byte() {}, ByteFormat.LowerCaseHex, groupSize))
		Assert.AreEqual("", ByteExtension.ToString(New List(Of Byte), ByteFormat.LowerCaseHex, groupSize))

		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), ByteFormat.UpperCaseHex, groupSize))
		Assert.AreEqual("", ByteExtension.ToString(New Byte() {}, ByteFormat.UpperCaseHex, groupSize))
		Assert.AreEqual("", ByteExtension.ToString(New List(Of Byte), ByteFormat.UpperCaseHex, groupSize))

		Assert.AreEqual(String.Join("", BitStrings), ByteExtension.ToString(bArray, ByteFormat.Bits, groupSize))
		Assert.AreEqual(String.Join("", BitStrings), ByteExtension.ToString(bList, ByteFormat.Bits, groupSize))
		Assert.AreEqual(String.Join("", BitStrings), ByteExtension.ToString(bList.Take(100), ByteFormat.Bits, groupSize))

		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bArray, ByteFormat.LowerCaseHex, groupSize))
		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bList, ByteFormat.LowerCaseHex, groupSize))
		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bList.Take(100), ByteFormat.LowerCaseHex, groupSize))

		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bArray, ByteFormat.UpperCaseHex, groupSize))
		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bList, ByteFormat.UpperCaseHex, groupSize))
		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bList.Take(100), ByteFormat.UpperCaseHex, groupSize))


		groupSize = 1

		Assert.AreEqual(String.Join(" ", BitStrings), ByteExtension.ToString(bArray, ByteFormat.Bits, groupSize))
		Assert.AreEqual(String.Join(" ", BitStrings), ByteExtension.ToString(bList, ByteFormat.Bits, groupSize))
		Assert.AreEqual(String.Join(" ", BitStrings), ByteExtension.ToString(bList.Take(100), ByteFormat.Bits, groupSize))

		Assert.AreEqual(String.Join(" ", LowerHexStrings), ByteExtension.ToString(bArray, ByteFormat.LowerCaseHex, groupSize))
		Assert.AreEqual(String.Join(" ", LowerHexStrings), ByteExtension.ToString(bList, ByteFormat.LowerCaseHex, groupSize))
		Assert.AreEqual(String.Join(" ", LowerHexStrings), ByteExtension.ToString(bList.Take(100), ByteFormat.LowerCaseHex, groupSize))

		Assert.AreEqual(String.Join(" ", UpperHexStrings), ByteExtension.ToString(bArray, ByteFormat.UpperCaseHex, groupSize))
		Assert.AreEqual(String.Join(" ", UpperHexStrings), ByteExtension.ToString(bList, ByteFormat.UpperCaseHex, groupSize))
		Assert.AreEqual(String.Join(" ", UpperHexStrings), ByteExtension.ToString(bList.Take(100), ByteFormat.UpperCaseHex, groupSize))

		groupSize = 2

		Dim lHex2 = ToStringTest3Extracted(LowerHexStrings, 2)
		Dim uHex2 = ToStringTest3Extracted(UpperHexStrings, 2)

		Assert.AreEqual(lHex2, ByteExtension.ToString(bArray, ByteFormat.LowerCaseHex, groupSize))
		Assert.AreEqual(lHex2, ByteExtension.ToString(bList, ByteFormat.LowerCaseHex, groupSize))
		Assert.AreEqual(lHex2, ByteExtension.ToString(bList.Take(100), ByteFormat.LowerCaseHex, groupSize))

		Assert.AreEqual(uHex2, ByteExtension.ToString(bArray, ByteFormat.UpperCaseHex, groupSize))
		Assert.AreEqual(uHex2, ByteExtension.ToString(bList, ByteFormat.UpperCaseHex, groupSize))
		Assert.AreEqual(uHex2, ByteExtension.ToString(bList.Take(100), ByteFormat.UpperCaseHex, groupSize))


		groupSize = 4

		Dim lHex4 = ToStringTest3Extracted(LowerHexStrings, 4)
		Dim uHex4 = ToStringTest3Extracted(UpperHexStrings, 4)

		Assert.AreEqual(lHex4, ByteExtension.ToString(bArray, ByteFormat.LowerCaseHex, groupSize))
		Assert.AreEqual(lHex4, ByteExtension.ToString(bList, ByteFormat.LowerCaseHex, groupSize))
		Assert.AreEqual(lHex4, ByteExtension.ToString(bList.Take(100), ByteFormat.LowerCaseHex, groupSize))

		Assert.AreEqual(uHex4, ByteExtension.ToString(bArray, ByteFormat.UpperCaseHex, groupSize))
		Assert.AreEqual(uHex4, ByteExtension.ToString(bList, ByteFormat.UpperCaseHex, groupSize))
		Assert.AreEqual(uHex4, ByteExtension.ToString(bList.Take(100), ByteFormat.UpperCaseHex, groupSize))


	End Sub


	'''<summary>
	'''A test for ToString
	'''</summary>
	<TestMethod()> _
	Public Sub ToStringTest2()
		'bList versions skips the pre-allocation logic



		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), "x2"))
		Assert.AreEqual("", ByteExtension.ToString(New Byte() {}, "x2"))
		Assert.AreEqual("", ByteExtension.ToString(New List(Of Byte), "x2"))
		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bArray, "x2"))
		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bList, "x2"))
		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bList.Take(100), "x2"))

		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), "X2"))
		Assert.AreEqual("", ByteExtension.ToString(New Byte() {}, "X2"))
		Assert.AreEqual("", ByteExtension.ToString(New List(Of Byte), "X2"))
		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bArray, "X2"))
		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bList, "X2"))
		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bList.Take(100), "X2"))

	End Sub

	'''<summary>
	'''A test for ToString
	'''</summary>
	<TestMethod()> _
	Public Sub ToStringTest()
		Dim groupSize = 0

		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), "x2", groupSize))
		Assert.AreEqual("", ByteExtension.ToString(New Byte() {}, "x2", groupSize))
		Assert.AreEqual("", ByteExtension.ToString(New List(Of Byte), "x2", groupSize))

		Assert.AreEqual("", ByteExtension.ToString(CType(Nothing, IEnumerable(Of Byte)), "X2", groupSize))
		Assert.AreEqual("", ByteExtension.ToString(New Byte() {}, "X2", groupSize))
		Assert.AreEqual("", ByteExtension.ToString(New List(Of Byte), "X2", groupSize))


		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bArray, "x2", groupSize))
		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bList, "x2", groupSize))
		Assert.AreEqual(String.Join("", LowerHexStrings), ByteExtension.ToString(bList.Take(100), "x2", groupSize))

		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bArray, "X2", groupSize))
		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bList, "X2", groupSize))
		Assert.AreEqual(String.Join("", UpperHexStrings), ByteExtension.ToString(bList.Take(100), "X2", groupSize))


		groupSize = 1


		Assert.AreEqual(String.Join(" ", LowerHexStrings), ByteExtension.ToString(bArray, "x2", groupSize))
		Assert.AreEqual(String.Join(" ", LowerHexStrings), ByteExtension.ToString(bList, "x2", groupSize))
		Assert.AreEqual(String.Join(" ", LowerHexStrings), ByteExtension.ToString(bList.Take(100), "x2", groupSize))

		Assert.AreEqual(String.Join(" ", UpperHexStrings), ByteExtension.ToString(bArray, "X2", groupSize))
		Assert.AreEqual(String.Join(" ", UpperHexStrings), ByteExtension.ToString(bList, "X2", groupSize))
		Assert.AreEqual(String.Join(" ", UpperHexStrings), ByteExtension.ToString(bList.Take(100), "X2", groupSize))

		groupSize = 2

		Dim lHex2 = ToStringTest3Extracted(LowerHexStrings, 2)
		Dim uHex2 = ToStringTest3Extracted(UpperHexStrings, 2)

		Assert.AreEqual(lHex2, ByteExtension.ToString(bArray, "x2", groupSize))
		Assert.AreEqual(lHex2, ByteExtension.ToString(bList, "x2", groupSize))
		Assert.AreEqual(lHex2, ByteExtension.ToString(bList.Take(100), "x2", groupSize))

		Assert.AreEqual(uHex2, ByteExtension.ToString(bArray, "X2", groupSize))
		Assert.AreEqual(uHex2, ByteExtension.ToString(bList, "X2", groupSize))
		Assert.AreEqual(uHex2, ByteExtension.ToString(bList.Take(100), "X2", groupSize))


		groupSize = 4

		Dim lHex4 = ToStringTest3Extracted(LowerHexStrings, 4)
		Dim uHex4 = ToStringTest3Extracted(UpperHexStrings, 4)

		Assert.AreEqual(lHex4, ByteExtension.ToString(bArray, "x2", groupSize))
		Assert.AreEqual(lHex4, ByteExtension.ToString(bList, "x2", groupSize))
		Assert.AreEqual(lHex4, ByteExtension.ToString(bList.Take(100), "x2", groupSize))

		Assert.AreEqual(uHex4, ByteExtension.ToString(bArray, "X2", groupSize))
		Assert.AreEqual(uHex4, ByteExtension.ToString(bList, "X2", groupSize))
		Assert.AreEqual(uHex4, ByteExtension.ToString(bList.Take(100), "X2", groupSize))

	End Sub

	'''<summary>
	'''A test for ToByteArray
	'''</summary>
	<TestMethod()> _
	Public Sub ToByteArrayTest()

		Dim source = "adfljkahd flkjahfl ksdjfhls dkfhsdlkfjhdslfjks"
		Dim encodings = New Text.Encoding() {Encoding.ASCII, Encoding.Unicode, Encoding.UTF32, Encoding.UTF7, Encoding.UTF8}

		For Each encoding In encodings
			Dim expected = encoding.GetBytes(source)
			Dim actual = source.ToByteArray(encoding)
			For i = 0 To expected.Length - 1
				Assert.AreEqual(expected(i), actual(i))
			Next
		Next

	End Sub

	'''<summary>
	'''A test for ToBitString
	'''</summary>
	<TestMethod()> _
	Public Sub ToBitStringTest()
		For i = 0 To bArray.Length - 1
			Assert.AreEqual(BitStrings(i), bArray(i).ToBitString)
		Next
	End Sub

	'''<summary>
	'''A test for IsBitSet
	'''</summary>
	<TestMethod()> _
	Public Sub IsBitSetTest()
		Dim b1 As Byte = 1
		Dim b2 As Byte = 2
		Dim b3 As Byte = 3
		Dim b4 As Byte = 4
		Dim b5 As Byte = 26
		Dim b6 As Byte = 145

		For i = 0 To 7
			Assert.AreEqual(False, ByteExtension.IsBitSet(b0, i))
		Next

		For i = 0 To 7
			Assert.AreEqual(i = 0, ByteExtension.IsBitSet(b1, i))
		Next

		For i = 0 To 7
			Assert.AreEqual(i = 1, ByteExtension.IsBitSet(b2, i))
		Next

		For i = 0 To 7
			Assert.AreEqual(i = 1 Or i = 0, ByteExtension.IsBitSet(b3, i))
		Next

		For i = 0 To 7
			Assert.AreEqual(i = 2, ByteExtension.IsBitSet(b4, i))
		Next

		'00011010
		Assert.AreEqual(False, ByteExtension.IsBitSet(b5, 0))
		Assert.AreEqual(True, ByteExtension.IsBitSet(b5, 1))
		Assert.AreEqual(False, ByteExtension.IsBitSet(b5, 2))
		Assert.AreEqual(True, ByteExtension.IsBitSet(b5, 3))
		Assert.AreEqual(True, ByteExtension.IsBitSet(b5, 4))
		Assert.AreEqual(False, ByteExtension.IsBitSet(b5, 5))
		Assert.AreEqual(False, ByteExtension.IsBitSet(b5, 6))
		Assert.AreEqual(False, ByteExtension.IsBitSet(b5, 7))


		'10010001
		Assert.AreEqual(True, ByteExtension.IsBitSet(b6, 0))
		Assert.AreEqual(False, ByteExtension.IsBitSet(b6, 1))
		Assert.AreEqual(False, ByteExtension.IsBitSet(b6, 2))
		Assert.AreEqual(False, ByteExtension.IsBitSet(b6, 3))
		Assert.AreEqual(True, ByteExtension.IsBitSet(b6, 4))
		Assert.AreEqual(False, ByteExtension.IsBitSet(b6, 5))
		Assert.AreEqual(False, ByteExtension.IsBitSet(b6, 6))
		Assert.AreEqual(True, ByteExtension.IsBitSet(b6, 7))


		For i = 0 To 7
			Assert.AreEqual(True, ByteExtension.IsBitSet(bMax, i))
		Next
	End Sub

	'''<summary>
	'''A test for ToString
	'''</summary>
	<TestMethod()> _
	Public Sub ToStringTest6()


		Dim raw = "adfljkahd flkjahfl ksdjfhls dkfhsdlkfjhdslfjks"
		Dim source = Encoding.ASCII.GetBytes(raw)

		Dim encodings = New Text.Encoding() {encoding.ASCII, encoding.Unicode, encoding.UTF32, encoding.UTF7, encoding.UTF8}

		For Each encoding In encodings
			Dim expected = encoding.GetString(source)
			Dim actual = source.ToString(encoding)
			For i = 0 To expected.Length - 1
				Assert.AreEqual(expected(i), actual(i))
			Next
		Next

	End Sub
End Class

