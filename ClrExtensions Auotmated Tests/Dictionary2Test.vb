Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ClrExtensions.System.Collections

'''<summary>
'''This is a test class for DictionaryTest and is intended
'''to contain all DictionaryTest Unit Tests
'''</summary>
<TestClass()> _
Public Class Dictionary2Test

	Private Function MathDictionary() As Dictionary(Of Integer, Integer, Double)
		Dim result As New Dictionary(Of Integer, Integer, Double)
		For i = 0 To 20
			For j = 1 To 20 Step 2
				result(i, j) = i / j
			Next
		Next
		Return result
	End Function

	'''<summary>
	'''A test for Item
	'''</summary>
	Public Sub ItemTestHelper(Of TKey1, TKey2, TValue)()
		Dim target As Dictionary(Of TKey1, TKey2, TValue) = New Dictionary(Of TKey1, TKey2, TValue)	' TODO: Initialize to an appropriate value
		Dim key1 As TKey1 = CType(Nothing, TKey1) ' TODO: Initialize to an appropriate value
		Dim key2 As TKey2 = CType(Nothing, TKey2) ' TODO: Initialize to an appropriate value
		Dim expected As TValue = CType(Nothing, TValue)	' TODO: Initialize to an appropriate value
		Dim actual As TValue
		target(key1, key2) = expected
		actual = target(key1, key2)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	<TestMethod()> _
	Public Sub ItemTest()
		Dim result = MathDictionary()
		For i = 0 To 20
			For j = 1 To 20 Step 2
				Assert.AreEqual(i / j, result(i, j))
			Next
		Next
	End Sub

	<TestMethod()> _
	Public Sub TryGetValueTest()
		Dim result = MathDictionary()
		For i = 0 To 20
			For j = 1 To 20 Step 2
				Dim value As Double
				Dim found = result.TryGetValue(i, j, value)

				If j Mod 2 = 1 Then
					Assert.IsTrue(found)
					Assert.AreEqual(i / j, result(i, j))
				Else
					Assert.IsFalse(found)
					Assert.AreEqual(0, value)
				End If
			Next
		Next
	End Sub

	<TestMethod()> _
	Public Sub StoreAndReturnTest()
		Dim x As New Dictionary(Of Integer, Integer, Double)
		For i = 1 To 10
			For j = 1 To 20
				Dim expected = i / j
				Dim actual = x.StoreAndReturn(i, j, expected)
				Assert.AreEqual(expected, actual)
			Next
		Next
	End Sub

	<TestMethod()> _
	 Public Sub RemoveTest()
		Dim result = MathDictionary()
		Dim expectedCount = result.Count \ 2
		For i = 0 To 20
			For j = 1 To 20 Step 4
				result.Remove(i, j)
			Next
		Next


		For i = 0 To 20
			For j = 1 To 20 Step 4
				Assert.IsFalse(result.ContainsKey(i, j))
			Next
		Next
		For i = 0 To 20
			For j = 1 + 2 To 20 Step 4
				Assert.IsTrue(result.ContainsKey(i, j))
			Next
		Next

		Assert.AreEqual(expectedCount, result.Count)
	End Sub

	<TestMethod()> _
	Public Sub ContainsKeyTest()
		'Covered by RemoveTest()
	End Sub

	<TestMethod()> _
	Public Sub AddTest()
		Dim result As New Dictionary(Of Integer, Integer, Double)
		For i = 0 To 20
			For j = 1 To 20 Step 2
				result.Add(i, j, i / j)
			Next
		Next

		Try
			result.Add(0, 1, -1)
			Assert.Fail()
		Catch ex As ArgumentException
			Assert.AreEqual(0.0, result(0, 1))
		End Try

	End Sub

	<TestMethod()> _
	Public Sub DictionaryConstructorTest()
		Dim x = New Dictionary(Of Integer, Integer, Double)
		Dim x2 = New Dictionary(Of Integer, Integer, Double)(100)
	End Sub

End Class
