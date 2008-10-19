Imports System.Net.Mail

Imports System

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for StringExtensionTest and is intended
'''to contain all StringExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class StringExtensionTest

	Dim strings As String() = New String() {"qwerty", "asdfg", "zxcvb", "poiuy", "lkjhg", "mnbvc"}
	Dim stringsWithBlanks As String() = New String() {"qwerty", "", "asdfg", "zxcvb", "", "", "poiuy", "lkjhg", "mnbvc"}
	Dim stringsWithNulls As String() = New String() {"qwerty", Nothing, "asdfg", "zxcvb", Nothing, Nothing, "poiuy", "lkjhg", "mnbvc"}
	'Dim stringList As New List(Of String)(strings)

	Dim comma As String = "qwerty,asdfg,zxcvb,poiuy,lkjhg,mnbvc"
	Dim colon As String = "qwerty:asdfg:zxcvb:poiuy:lkjhg:mnbvc"
	Dim commaSpace As String = "qwerty, asdfg, zxcvb, poiuy, lkjhg, mnbvc"

	Dim commaWithEmpties As String = "qwerty,,asdfg,zxcvb,,,poiuy,lkjhg,mnbvc"
	Dim colonWithEmpties As String = "qwerty::asdfg:zxcvb:::poiuy:lkjhg:mnbvc"
	Dim commaSpaceWithEmpties As String = "qwerty, , asdfg, zxcvb, , , poiuy, lkjhg, mnbvc"

	Function stringsLimited() As String()()
		Dim results As String()()
		ReDim results(8)
		results(0) = New String() {}
		results(1) = New String() {}
		results(2) = New String() {"qwerty", "asdfg,zxcvb,poiuy,lkjhg,mnbvc"}
		results(3) = New String() {"qwerty", "asdfg", "zxcvb,poiuy,lkjhg,mnbvc"}
		results(4) = New String() {"qwerty", "asdfg", "zxcvb", "poiuy,lkjhg,mnbvc"}
		results(5) = New String() {"qwerty", "asdfg", "zxcvb", "poiuy", "lkjhg,mnbvc"}
		results(6) = New String() {"qwerty", "asdfg", "zxcvb", "poiuy", "lkjhg", "mnbvc"}
		results(7) = New String() {"qwerty", "asdfg", "zxcvb", "poiuy", "lkjhg", "mnbvc"}
		results(8) = New String() {"qwerty", "asdfg", "zxcvb", "poiuy", "lkjhg", "mnbvc"}
		Return results
	End Function

	Function stringsLimited2() As String()()
		Dim results As String()()
		ReDim results(11)
		results(0) = New String() {}
		results(1) = New String() {}
		results(2) = New String() {"qwerty", ",asdfg,zxcvb,,,poiuy,lkjhg,mnbvc"}
		results(3) = New String() {"qwerty", "", "asdfg,zxcvb,,,poiuy,lkjhg,mnbvc"}
		results(4) = New String() {"qwerty", "", "asdfg", "zxcvb,,,poiuy,lkjhg,mnbvc"}
		results(5) = New String() {"qwerty", "", "asdfg", "zxcvb", ",,poiuy,lkjhg,mnbvc"}
		results(6) = New String() {"qwerty", "", "asdfg", "zxcvb", "", ",poiuy,lkjhg,mnbvc"}
		results(7) = New String() {"qwerty", "", "asdfg", "zxcvb", "", "", "poiuy,lkjhg,mnbvc"}
		results(8) = New String() {"qwerty", "", "asdfg", "zxcvb", "", "", "poiuy", "lkjhg,mnbvc"}
		results(9) = New String() {"qwerty", "", "asdfg", "zxcvb", "", "", "poiuy", "lkjhg", "mnbvc"}
		results(10) = New String() {"qwerty", "", "asdfg", "zxcvb", "", "", "poiuy", "lkjhg", "mnbvc"}
		results(11) = New String() {"qwerty", "", "asdfg", "zxcvb", "", "", "poiuy", "lkjhg", "mnbvc"}
		Return results
	End Function

	Function stringsLimited3() As String()()
		Dim results As String()()
		ReDim results(8)
		results(0) = New String() {}
		results(1) = New String() {}
		results(2) = New String() {"qwerty", ",asdfg,zxcvb,,,poiuy,lkjhg,mnbvc"}
		results(3) = New String() {"qwerty", "asdfg", "zxcvb,,,poiuy,lkjhg,mnbvc"}
		results(4) = New String() {"qwerty", "asdfg", "zxcvb", ",,poiuy,lkjhg,mnbvc"}
		results(5) = New String() {"qwerty", "asdfg", "zxcvb", "poiuy", "lkjhg,mnbvc"}
		results(6) = New String() {"qwerty", "asdfg", "zxcvb", "poiuy", "lkjhg", "mnbvc"}
		results(7) = New String() {"qwerty", "asdfg", "zxcvb", "poiuy", "lkjhg", "mnbvc"}
		results(8) = New String() {"qwerty", "asdfg", "zxcvb", "poiuy", "lkjhg", "mnbvc"}
		Return results
	End Function

	'''<summary>
	'''A test for Join
	'''</summary>
	<TestMethod()> _
	Public Sub JoinTest()

		Assert.AreEqual(comma, strings.Join(","))
		Assert.AreEqual(colon, strings.Join(":"))
		Assert.AreEqual(commaSpace, strings.Join(", "))

		Assert.AreEqual(commaWithEmpties, stringsWithBlanks.Join(","))
		Assert.AreEqual(colonWithEmpties, stringsWithBlanks.Join(":"))
		Assert.AreEqual(commaSpaceWithEmpties, stringsWithBlanks.Join(", "))

		Assert.AreEqual(commaWithEmpties, stringsWithNulls.Join(","))
		Assert.AreEqual(colonWithEmpties, stringsWithNulls.Join(":"))
		Assert.AreEqual(commaSpaceWithEmpties, stringsWithNulls.Join(", "))

	End Sub

	'''<summary>
	'''A test for Repeat
	'''</summary>
	<TestMethod()> _
	Public Sub RepeatTest()
		Dim expected = New String() {"", "X", "XX", "XXX", "XXXX", "XXXXX", "XXXXXX"}
		For i = 0 To expected.Length - 1
			Assert.AreEqual(expected(i), "X".Repeat(i))
		Next

	End Sub

	'''<summary>
	'''A test for Join
	'''</summary>
	<TestMethod()> _
	Public Sub JoinTest1()
		Assert.AreEqual(comma, strings.Join(",", StringSplitOptions.None))
		Assert.AreEqual(colon, strings.Join(":", StringSplitOptions.None))
		Assert.AreEqual(commaSpace, strings.Join(", ", StringSplitOptions.None))

		Assert.AreEqual(commaWithEmpties, stringsWithBlanks.Join(",", StringSplitOptions.None))
		Assert.AreEqual(colonWithEmpties, stringsWithBlanks.Join(":", StringSplitOptions.None))
		Assert.AreEqual(commaSpaceWithEmpties, stringsWithBlanks.Join(", ", StringSplitOptions.None))

		Assert.AreEqual(commaWithEmpties, stringsWithNulls.Join(",", StringSplitOptions.None))
		Assert.AreEqual(colonWithEmpties, stringsWithNulls.Join(":", StringSplitOptions.None))
		Assert.AreEqual(commaSpaceWithEmpties, stringsWithNulls.Join(", ", StringSplitOptions.None))



		Assert.AreEqual(comma, strings.Join(",", StringSplitOptions.RemoveEmptyEntries))
		Assert.AreEqual(colon, strings.Join(":", StringSplitOptions.RemoveEmptyEntries))
		Assert.AreEqual(commaSpace, strings.Join(", ", StringSplitOptions.RemoveEmptyEntries))

		Assert.AreEqual(comma, stringsWithBlanks.Join(",", StringSplitOptions.RemoveEmptyEntries))
		Assert.AreEqual(colon, stringsWithBlanks.Join(":", StringSplitOptions.RemoveEmptyEntries))
		Assert.AreEqual(commaSpace, stringsWithBlanks.Join(", ", StringSplitOptions.RemoveEmptyEntries))

		Assert.AreEqual(comma, stringsWithNulls.Join(",", StringSplitOptions.RemoveEmptyEntries))
		Assert.AreEqual(colon, stringsWithNulls.Join(":", StringSplitOptions.RemoveEmptyEntries))
		Assert.AreEqual(commaSpace, stringsWithNulls.Join(", ", StringSplitOptions.RemoveEmptyEntries))

	End Sub

	'''<summary>
	'''A test for Split
	'''</summary>
	<TestMethod()> _
	Public Sub SplitTest()

		Assert.IsTrue(ArrayEquals(strings, comma.Split(",")))
		Assert.IsTrue(ArrayEquals(strings, colon.Split(":")))
		Assert.IsTrue(ArrayEquals(strings, commaSpace.Split(", ")))

		Assert.IsTrue(ArrayEquals(stringsWithBlanks, commaWithEmpties.Split(",")))
		Assert.IsTrue(ArrayEquals(stringsWithBlanks, colonWithEmpties.Split(":")))
		Assert.IsTrue(ArrayEquals(stringsWithBlanks, commaSpaceWithEmpties.Split(", ")))

	End Sub

	Function ArrayEquals(Of T)(ByVal left As T(), ByVal right As T()) As Boolean
		If left.Length <> right.Length Then Return False
		For i = 0 To left.Length - 1
			If Not Object.Equals(left(i), right(i)) Then Return False
		Next
		Return True
	End Function


	'''<summary>
	'''A test for Split
	'''</summary>
	<TestMethod()> _
	Public Sub SplitTest1()
		Assert.IsTrue(ArrayEquals(strings, comma.Split(",", StringSplitOptions.None)))
		Assert.IsTrue(ArrayEquals(strings, colon.Split(":", StringSplitOptions.None)))
		Assert.IsTrue(ArrayEquals(strings, commaSpace.Split(", ", StringSplitOptions.None)))

		Assert.IsTrue(ArrayEquals(stringsWithBlanks, commaWithEmpties.Split(",", StringSplitOptions.None)))
		Assert.IsTrue(ArrayEquals(stringsWithBlanks, colonWithEmpties.Split(":", StringSplitOptions.None)))
		Assert.IsTrue(ArrayEquals(stringsWithBlanks, commaSpaceWithEmpties.Split(", ", StringSplitOptions.None)))

		Assert.IsTrue(ArrayEquals(strings, comma.Split(",", StringSplitOptions.RemoveEmptyEntries)))
		Assert.IsTrue(ArrayEquals(strings, colon.Split(":", StringSplitOptions.RemoveEmptyEntries)))
		Assert.IsTrue(ArrayEquals(strings, commaSpace.Split(", ", StringSplitOptions.RemoveEmptyEntries)))

		Assert.IsTrue(ArrayEquals(strings, commaWithEmpties.Split(",", StringSplitOptions.RemoveEmptyEntries)))
		Assert.IsTrue(ArrayEquals(strings, colonWithEmpties.Split(":", StringSplitOptions.RemoveEmptyEntries)))
		Assert.IsTrue(ArrayEquals(strings, commaSpaceWithEmpties.Split(", ", StringSplitOptions.RemoveEmptyEntries)))

	End Sub

	'''<summary>
	'''A test for Split
	'''</summary>
	<TestMethod()> _
	Public Sub SplitTest2()
		Dim expected = stringsLimited()
		For i = 2 To expected.Length - 1
			Assert.IsTrue(ArrayEquals(expected(i), comma.Split(",", i)))
		Next
	End Sub

	'''<summary>
	'''A test for Split
	'''</summary>
	<TestMethod()> _
	Public Sub SplitTest3()
		Dim expected = stringsLimited()
		Dim expected2 = stringsLimited2()
		Dim expected3 = stringsLimited3()

		For i = 2 To expected.Length - 1
			Assert.IsTrue(ArrayEquals(expected(i), comma.Split(",", i, StringSplitOptions.None)))
		Next
		For i = 2 To expected.Length - 1
			Assert.IsTrue(ArrayEquals(expected(i), comma.Split(",", i, StringSplitOptions.RemoveEmptyEntries)))
		Next


		For i = 2 To expected2.Length - 1
			Assert.IsTrue(ArrayEquals(expected2(i), commaWithEmpties.Split(",", i, StringSplitOptions.None)))
		Next
		For i = 2 To expected3.Length - 1
			Dim actual = commaWithEmpties.Split(",", i, StringSplitOptions.RemoveEmptyEntries)
			Assert.IsTrue(ArrayEquals(expected3(i), actual))
		Next

	End Sub


	Dim casingSource As String() = New String() {"", Nothing, "testVar", "TestVar", "t", "T", "12345", "test var", "TEST VAR"}

	'''<summary>
	'''A test for FirstToLower
	'''</summary>
	<TestMethod()> _
	Public Sub FirstToLowerTest()
		Dim expected = New String() {"", Nothing, "testVar", "testVar", "t", "t", "12345", "test var", "tEST VAR"}

		For i = 0 To casingSource.Length - 1
			Assert.AreEqual(expected(i), casingSource(i).FirstToLower)
		Next
	End Sub




	'''<summary>
	'''A test for FirstToUpper
	'''</summary>
	<TestMethod()> _
	Public Sub FirstToUpperTest()
		Dim expected = New String() {"", Nothing, "TestVar", "TestVar", "T", "T", "12345", "Test var", "TEST VAR"}

		For i = 0 To casingSource.Length - 1
			Assert.AreEqual(expected(i), casingSource(i).FirstToUpper)
		Next
	End Sub

	'''<summary>
	'''A test for Capitalize
	'''</summary>
	<TestMethod()> _
	Public Sub CapitalizeTest()
        Dim expected = New String() {"", Nothing, "Testvar", "Testvar", "T", "T", "12345", "Test var", "Test var"}

		For i = 0 To casingSource.Length - 1
			Assert.AreEqual(expected(i), casingSource(i).Capitalize)
		Next

	End Sub

	'''<summary>
	'''A test for DefaultIfNull
	'''</summary>
	<TestMethod()> _
	Public Sub DefaultIfNullTest()
        Dim expected = New String() {"", "", "testVar", "TestVar", "t", "T", "12345", "test var", "TEST VAR"}

		For i = 0 To casingSource.Length - 1
			Assert.AreEqual(expected(i), casingSource(i).DefaultIfNull())
		Next
	End Sub


	'''<summary>
	'''A test for DefaultIfNull
	'''</summary>
	<TestMethod()> _
	Public Sub DefaultIfNullTest1()
        Dim expected = New String() {"", "ZZZ", "testVar", "TestVar", "t", "T", "12345", "test var", "TEST VAR"}

		For i = 0 To casingSource.Length - 1
			Assert.AreEqual(expected(i), casingSource(i).DefaultIfNull("ZZZ"))
		Next
	End Sub

	'''<summary>
	'''A test for DefaultIfEmpty
	'''</summary>
	<TestMethod()> _
	Public Sub DefaultIfEmptyTest()
        Dim expected = New String() {"ZZZ", "ZZZ", "testVar", "TestVar", "t", "T", "12345", "test var", "TEST VAR"}

		For i = 0 To casingSource.Length - 1
            Assert.AreEqual(expected(i), casingSource(i).DefaultIfEmpty("ZZZ"))
		Next
	End Sub

	Dim validEmailAddresses As String() = New String() {"jonathan@test.com", "jonathan.allen@test.test2.com", "Jonathan Allen <jonathan@test.com>"}

	'''<summary>
	'''A test for IsEmailAddress
	'''</summary>
	<TestMethod()> _
	Public Sub IsEmailAddressTest()
		Dim notValid = New String() {Nothing, "", "qweety", "qwerty.com", "<Jonathan Allen> jonathan@test.com"}

		For Each item In validEmailAddresses
			Assert.IsTrue(item.IsEmailAddress)
		Next
		For Each item In notValid
			Assert.IsFalse(item.IsEmailAddress)
		Next

	End Sub


	'''<summary>
	'''A test for ToMailAddress
	'''</summary>
	<TestMethod()> _
	Public Sub ToMailAddressTest()
		Dim addresses = New String() {"jonathan@test.com", "jonathan.allen@test.test2.com", "jonathan@test.com"}
		Dim displayNames = New String() {"", "", "Jonathan Allen"}

		For i As Integer = 0 To validEmailAddresses.Length - 1
			Assert.AreEqual(addresses(i), validEmailAddresses(i).ToMailAddress.Address)
			Assert.AreEqual(displayNames(i), validEmailAddresses(i).ToMailAddress.DisplayName)
		Next
	End Sub

	'''<summary>
	'''A test for Left
	'''</summary>
	<TestMethod()> _
	Public Sub LeftTest()
		Dim expected1 = New String() {"", Nothing, "t", "T", "t", "T", "1", "t", "T"}
		Dim expected2 = New String() {"", Nothing, "te", "Te", "t", "T", "12", "te", "TE"}
		Dim expected3 = New String() {"", Nothing, "tes", "Tes", "t", "T", "123", "tes", "TES"}

		For i = 0 To casingSource.Length - 1
			Assert.AreEqual(expected1(i), casingSource(i).Left(1))
			Assert.AreEqual(expected2(i), casingSource(i).Left(2))
			Assert.AreEqual(expected3(i), casingSource(i).Left(3))
		Next
	End Sub

	'''<summary>
	'''A test for Right
	'''</summary>
	<TestMethod()> _
	Public Sub RightTest()
		Dim expected1 = New String() {"", Nothing, "r", "r", "t", "T", "5", "r", "R"}
		Dim expected2 = New String() {"", Nothing, "ar", "ar", "t", "T", "45", "ar", "AR"}
		Dim expected3 = New String() {"", Nothing, "Var", "Var", "t", "T", "345", "var", "VAR"}

		For i = 0 To casingSource.Length - 1
			Assert.AreEqual(expected1(i), casingSource(i).Right(1))
			Assert.AreEqual(expected2(i), casingSource(i).Right(2))
			Assert.AreEqual(expected3(i), casingSource(i).Right(3))
		Next
	End Sub


	Dim lineBreakMixed As String = "qwerty" & vbCr & "asdfg" & vbLf & "zxcvb" & vbCrLf & "poiuy" & vbCr & vbCr & "lkjhg" & vbLf & vbLf & "mnbvc" & vbCrLf & vbCrLf & "."
	Dim lineBreakWindows As String = "qwerty" & vbCrLf & "asdfg" & vbCrLf & "zxcvb" & vbCrLf & "poiuy" & vbCrLf & vbCrLf & "lkjhg" & vbCrLf & vbCrLf & "mnbvc" & vbCrLf & vbCrLf & "."
	Dim lineBreakLinux As String = "qwerty" & vbLf & "asdfg" & vbLf & "zxcvb" & vbLf & "poiuy" & vbLf & vbLf & "lkjhg" & vbLf & vbLf & "mnbvc" & vbLf & vbLf & "."
	Dim lineBreakMac As String = "qwerty" & vbCr & "asdfg" & vbCr & "zxcvb" & vbCr & "poiuy" & vbCr & vbCr & "lkjhg" & vbCr & vbCr & "mnbvc" & vbCr & vbCr & "."
	Dim lineBreakHtml As String = "qwerty" & "<br/>" & "asdfg" & "<br/>" & "zxcvb" & "<br/>" & "poiuy" & "<br/>" & "<br/>" & "lkjhg" & "<br/>" & "<br/>" & "mnbvc" & "<br/>" & "<br/>" & "."


	'''<summary>
	'''A test for NormalizeLineBreaks
	'''</summary>
	<TestMethod()> _
	Public Sub NormalizeLineBreaksTest()
		Assert.AreEqual(lineBreakWindows, lineBreakMixed.NormalizeLineBreaks)
	End Sub

	'''<summary>
	'''A test for NormalizeLineBreaks
	'''</summary>
	<TestMethod()> _
	Public Sub NormalizeLineBreaksTest1()
		Assert.AreEqual(lineBreakWindows, lineBreakMixed.NormalizeLineBreaks(LineBreakMode.Windows))
		Assert.AreEqual(lineBreakMac, lineBreakMixed.NormalizeLineBreaks(LineBreakMode.Macintosh))
		Assert.AreEqual(lineBreakLinux, lineBreakMixed.NormalizeLineBreaks(LineBreakMode.Unix))
	End Sub


	'''<summary>
	'''A test for HtmlLineBreaks
	'''</summary>
	<TestMethod()> _
	Public Sub HtmlLineBreaksTest()
		Assert.AreEqual(lineBreakHtml, lineBreakMixed.HtmlLineBreaks)
	End Sub


	'''<summary>
	'''A test for Reverse
	'''</summary>
	<TestMethod()> _
	Public Sub ReverseTest()
		Dim expected = New String() {"", Nothing, "raVtset", "raVtseT", "t", "T", "54321", "rav tset", "RAV TSET"}

		For i = 0 To casingSource.Length - 1
			Assert.AreEqual(expected(i), casingSource(i).Reverse)
		Next
	End Sub

	''''<summary>
	''''A test for ToTitleCase
	''''</summary>
	'<TestMethod()> _
	'Public Sub ToTitleCaseTest()
	'	Dim casingSource2 As String() = New String() {"", Nothing, "testVar", "TestVar", "t", "T", "12345", "test as var", "TEST as VAR"}
	'	Dim expected = New String() {"", Nothing, "Testvar", "Testvar", "T", "T", "12345", "Test As Var", "TEST As VAR"}

	'	For i = 0 To casingSource2.Length - 1
	'		Assert.AreEqual(expected(i), casingSource2(i).ToTitleCase)
	'	Next
	'End Sub



	'''<summary>
	'''A test for IsNullOrEmpty
	'''</summary>
	<TestMethod()> _
	Public Sub IsNullOrEmptyTest()
		Dim expected = New Boolean() {True, True, False, False, False, False, False, False, False}
		For i As Integer = 0 To casingSource.Length - 1
			Assert.AreEqual(expected(i), casingSource(i).IsNullOrEmpty)
		Next
	End Sub


	Public Shared UrlEncodingSource() As String = New String() {"Hi! frank was here."}
	Public Shared UrlEncodingClrResult() As String = New String() {"Hi!+frank+was+here."}
	Public Shared UrlEncodingOAuthResult() As String = New String() {"Hi%21%20frank%20was%20here."}

	'''<summary>
	'''A test for UrlEncode
	'''</summary>
	<TestMethod()> _
	Public Sub UrlEncodeTest()
		For i = 0 To UrlEncodingSource.Length - 1
			Assert.AreEqual(UrlEncodingClrResult(i), UrlEncodingSource(i).UrlEncode)
			Assert.AreEqual(UrlEncodingClrResult(i), UrlEncodingSource(i).UrlEncode(UrlEncodingMethod.Clr))
			Assert.AreEqual(UrlEncodingOAuthResult(i), UrlEncodingSource(i).UrlEncode(UrlEncodingMethod.OAuth))
		Next
	End Sub

End Class


'{"", Nothing, "testVar", "TestVar", "t", "T", "12345", "test var", "TEST VAR"}
