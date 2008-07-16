Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for Int32ExtensionTest and is intended
'''to contain all Int32ExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class Int32ExtensionTest

	Dim BitStrings As String() = New String() { _
	  "10000000000000000000000000000000" _
	, "11111111111111111111111101101111" _
	, "11111111111111111111111111100110" _
	, "11111111111111111111111111111100" _
	, "11111111111111111111111111111101" _
	, "11111111111111111111111111111110" _
	, "11111111111111111111111111111111" _
	, "00000000000000000000000000000000" _
	, "00000000000000000000000000000001" _
	, "00000000000000000000000000000010" _
	, "00000000000000000000000000000011" _
	, "00000000000000000000000000000100" _
	, "00000000000000000000000000011010" _
	, "00000000000000000000000010010001" _
	, "01111111111111111111111111111111" _
	}


	'Dim LowerHexStrings As String() = New String() {"00", "01", "02", "03", "04", "1a", "91", "ff"}
	'Dim UpperHexStrings As String() = New String() {"00", "01", "02", "03", "04", "1A", "91", "FF"}


	Dim min As Integer = Integer.MinValue
	Dim m6 As Integer = -145
	Dim m5 As Integer = -26
	Dim m4 As Integer = -4
	Dim m3 As Integer = -3
	Dim m2 As Integer = -2
	Dim m1 As Integer = -1
	Dim p0 As Integer = 0
	Dim p1 As Integer = 1
	Dim p2 As Integer = 2
	Dim p3 As Integer = 3
	Dim p4 As Integer = 4
	Dim p5 As Integer = 26
	Dim p6 As Integer = 145
	Dim max As Integer = Integer.MaxValue

	Dim bArray As Integer() = New Integer() {min, m6, m5, m4, m3, m2, m1, p0, p1, p2, p3, p4, p5, p6, max}
	Dim bList As New List(Of Integer)(bArray)



	'''<summary>
	'''A test for IsBetween
	'''</summary>
	<TestMethod()> _
	Public Sub IsBetweenTest()

		Dim source As New Random(0)

		For i = 0 To 100
			Dim left = source.Next(Integer.MinValue, Integer.MaxValue)
			Dim middle = source.Next(Integer.MinValue, Integer.MaxValue)
			Dim right = source.Next(Integer.MinValue, Integer.MaxValue)
			Assert.AreEqual(left < middle AndAlso middle < right, middle.IsBetween(left, right))
		Next

	End Sub

	'''<summary>
	'''A test for Pow
	'''</summary>
	<TestMethod()> _
	Public Sub PowTest()

		For base = -10 To 10
			For exponent = -10 To 9
				Diagnostics.Debug.WriteLine(base & vbTab & exponent)

				If Double.IsNaN(base ^ exponent) Or Double.IsInfinity(base ^ exponent) Then
					Try
						base.Pow(exponent)
						Assert.Fail("Base " & base & " Exponent " & exponent)
					Catch ex As ArgumentException
						'PASS
					End Try
				Else
					Assert.AreEqual(CInt(base ^ exponent), base.Pow(exponent))
				End If


			Next
		Next

	End Sub

	'''<summary>
	'''A test for ToBitString
	'''</summary>
	<TestMethod()> _
	Public Sub ToBitStringTest()

		For i = 0 To bArray.Length - 1
			Dim actual = Int32Extension.ToBitString(bArray(i))
			Assert.AreEqual(BitStrings(i), actual)
		Next

		For i = 0 To bArray.Length - 1
			Dim expected = BitStrings(i).Substring(0, 8) & " " & BitStrings(i).Substring(8, 8) _
			& " " & BitStrings(i).Substring(8 + 8, 8) & " " & BitStrings(i).Substring(8 + 8 + 8, 8)

			Dim actual = Int32Extension.ToBitString(bArray(i))

			Assert.AreEqual(expected, actual)
		Next
	End Sub

	'''<summary>
	'''A test for SetBit
	'''</summary>
	<TestMethod()> _
	Public Sub SetBitTest()
		For i = 0 To bArray.Length - 1

			For bit = 0 To 31

				Dim expected = New Text.StringBuilder(BitStrings(i))
				expected.Chars(31 - bit) = "1"c

				Dim actual = bArray(i).SetBit(bit)
				Assert.AreEqual(expected.ToString, actual.ToBitString(0))

			Next

		Next
	End Sub

	'''<summary>
	'''A test for IsBitSet
	'''</summary>
	<TestMethod()> _
	Public Sub IsBitSetTest()
		For i = 0 To bArray.Length - 1

			For bit = 0 To 31

				Dim expected = BitStrings(i).Chars(31 - bit) = "1"
				Dim actual = bArray(i).IsBitSet(bit)
				Assert.AreEqual(expected, actual)

			Next

		Next
	End Sub

	'''<summary>
	'''A test for ClearBit
	'''</summary>
	<TestMethod()> _
	Public Sub ClearBitTest()
		For i = 0 To bArray.Length - 1

			For bit = 0 To 31

				Dim expected = New Text.StringBuilder(BitStrings(i))
				expected.Chars(31 - bit) = "0"c

				Dim actual = bArray(i).ClearBit(bit)
				Assert.AreEqual(expected.ToString, actual.ToBitString(0))

			Next

		Next
	End Sub

End Class
