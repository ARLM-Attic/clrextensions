

Module ByteExtension

	''' <summary>
	''' Converts a byte array to a string by caling Byte.ToString(format)
	''' </summary>
	''' <param name="this"></param>
	''' <param name="format"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Function ToString(ByVal this As IEnumerable(Of Byte), ByVal format As String) As String
		Dim temp = TryCast(this, ICollection(Of Byte))

		Dim result = If(temp Is Nothing, New Text.StringBuilder(), New Text.StringBuilder(temp.Count))

		For Each b In this
			result.Append(b.ToString(format))
		Next
		Return result.ToString
	End Function

End Module
