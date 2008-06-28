

Public Module IntegerExtension
	''' <summary>
	''' Determines if a certain Enumeration Flag is set in a value. Both the value and the flag should be of the same enumeration type, but this isn't enforced.
	''' </summary>
	''' <param name="this">Value to check</param>
	''' <param name="flag">Flag to check for</param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function IsFlagSet(ByVal this As Integer, ByVal flag As Integer) As Boolean
		'TODO: Rewrite this if Microsoft ever decides to support Enumerations with generics
		Return CBool(this And flag)
	End Function

	'TODO: Create versions of these for all the interger types

	<Extension()> Public Function IsBitSet(ByVal this As Integer, ByVal bit As Integer) As Boolean
		Dim bitMask As Integer = 1 << bit

		Return CBool(this And bitMask)
	End Function

	<Extension()> Public Function SetBit(ByVal this As Integer, ByVal bit As Integer) As Integer
		Dim bitMask As Integer = 1 << bit

		Return this Or bitMask
	End Function

	<Extension()> Public Function ClearBit(ByVal this As Integer, ByVal bit As Integer) As Integer
		Dim bitMask As Integer = Not (1 << bit)

		Return this And bitMask
	End Function


	<Extension()> Public Function ToBitString(ByVal this As Integer) As String
		Dim result As New Text.StringBuilder(32 + 4)
		For i = 31 To 0 Step -1
			result.Append(If(this.IsBitSet(i), "1", "0"))
			If i Mod 8 = 0 And i <> 0 Then result.Append(" ")
		Next

		Return result.ToString
	End Function

End Module
