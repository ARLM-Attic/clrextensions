<Untested()> Public Module Int32Extension

	<Extension()> Public Function IsBetween(ByVal value As Integer, ByVal lowValue As Integer, ByVal highValue As Integer) As Boolean
		Return lowValue <= value And value <= highValue
	End Function


	''' <summary>
	''' Determines if a certain Enumeration Flag is set in a value. Both the value and the flag should be of the same enumeration type, but this isn't enforced.
	''' </summary>
	''' <param name="value">Value to check</param>
	''' <param name="flag">Flag to check for</param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function IsFlagSet(ByVal value As Integer, ByVal flag As Integer) As Boolean
		'TODO: Rewrite this if Microsoft ever decides to support Enumerations with generics
		Return CBool(value And flag)
	End Function

	'TODO: Create versions of these for all the interger types

	<Extension()> Public Function IsBitSet(ByVal value As Integer, ByVal bit As Integer) As Boolean
		Dim bitMask As Integer = 1 << bit

		Return CBool(value And bitMask)
	End Function

	<Extension()> Public Function SetBit(ByVal value As Integer, ByVal bit As Integer) As Integer
		Dim bitMask As Integer = 1 << bit

		Return value Or bitMask
	End Function

	<Extension()> Public Function ClearBit(ByVal value As Integer, ByVal bit As Integer) As Integer
		Dim bitMask As Integer = Not (1 << bit)

		Return value And bitMask
	End Function


	<Extension()> Public Function ToBitString(ByVal value As Integer) As String
		Dim result As New Text.StringBuilder(32 + 4)
		For i = 31 To 0 Step -1
			result.Append(If(value.IsBitSet(i), "1", "0"))
			If i Mod 8 = 0 And i <> 0 Then result.Append(" ")
		Next

		Return result.ToString
	End Function


	<Extension()> Public Function Pow(ByVal base As Integer, ByVal exponent As Integer) As Integer
		Return CInt(base ^ exponent)
	End Function



End Module
