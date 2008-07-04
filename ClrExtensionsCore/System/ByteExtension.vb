Public Module ByteExtension

#Region "IEnumerable(of Byte)"

	''' <summary>
	''' Calls Byte.ToString(format) on each byte and concatenates the results
	''' </summary>
	''' <param name="this"></param>
	''' <param name="format">Null, "", or a valid string for Byte.ToString</param>
	''' <returns>An empty string if this is empty/null</returns>
	''' <remarks></remarks>
	''' <exception cref="System.FormatException">Thrown if the format string is malformed.</exception>
	<Extension()> Public Function ToString(ByVal this As IEnumerable(Of Byte), ByVal format As String) As String
		Return ToString(this, format, 0)
	End Function

	''' <summary>
	''' Calls Byte.ToString(format) on each byte and concatenates the results
	''' </summary>
	''' <param name="this"></param>
	''' <param name="format">Null, "", or a valid string for Byte.ToString</param>
	''' <param name="groupingSize">Amount of bytes to group together. Each group is separated by a space.</param>
	''' <returns>An empty string if this is empty/null</returns>
	''' <remarks></remarks>
	''' <exception cref="System.FormatException">Thrown if the format string is malformed.</exception>
	''' <exception cref="System.ArgumentOutOfRangeException ">Thrown is groupingSize &lt; 0.</exception>
	<Extension()> Function ToString(ByVal this As IEnumerable(Of Byte), ByVal format As String, ByVal groupingSize As Integer) As String
		If groupingSize < 0 Then Throw New ArgumentOutOfRangeException("groupingSize")

		If this Is Nothing Then Return ""

		'pre-allocate the string buffer if possible
		Dim temp = TryCast(this, ICollection(Of Byte))
		Dim result = If(temp Is Nothing, New Text.StringBuilder(), New Text.StringBuilder(temp.Count * format.Length))
		Dim count As Integer
		For Each b In this
			result.Append(b.ToString(format))
			count += 1
			If groupingSize > 0 AndAlso count Mod groupingSize = 0 Then result.Append(" ")
		Next
		Return result.ToString.Trim
	End Function

	''' <summary>
	''' Calls Byte.ToString(format) on each byte and concatenates the results
	''' </summary>
	''' <param name="this"></param>
	''' <param name="format">Must be a defined value</param>
	''' <returns>An empty string if this is empty/null</returns>
	''' <remarks>The grouping size is 0, except for Bits which is 1</remarks>
	''' <exception cref="System.ArgumentOutOfRangeException">Thrown is format isn't a named value</exception>
	Public Function ToString(ByVal this As IEnumerable(Of Byte), ByVal format As ByteFormat) As String
		Dim groupingSize = 0
		If format = ByteFormat.Bits Then groupingSize = 1

		Return ToString(this, format, groupingSize)
	End Function

	''' <summary>
	''' Calls Byte.ToString(format) on each byte and concatenates the results
	''' </summary>
	''' <param name="this"></param>
	''' <param name="format">Must be a defined value. If set to Bits, the group-size is limited to 0 or 1.</param>
	''' <param name="groupingSize">Amount of bytes to group together. Each group is separated by a space.</param>
	''' <returns>An empty string if this is empty/null</returns>
	''' <remarks></remarks>
	''' <exception cref="System.ArgumentOutOfRangeException">Thrown is format isn't a named value</exception>
	''' <exception cref="System.ArgumentOutOfRangeException ">Thrown is groupingSize &lt; 0.</exception>
	''' <exception cref="System.ArgumentOutOfRangeException ">Thrown is format is Bit and groupingSize &gt; 1.</exception>
	<Extension()> Function ToString(ByVal this As IEnumerable(Of Byte), ByVal format As ByteFormat, ByVal groupingSize As Integer) As String
		If groupingSize < 0 Then Throw New ArgumentOutOfRangeException("groupingSize")
		If groupingSize > 1 And format = ByteFormat.Bits Then Throw New ArgumentOutOfRangeException("groupingSize", "The group size cannot be greater than 1 for the format mode Bit")
		If Not IsDefined(format) Then Throw New ArgumentOutOfRangeException("format")

		If this Is Nothing Then Return ""

		Select Case format
			Case ByteFormat.Bits
				'pre-allocate the string buffer if possible

				Dim temp = TryCast(this, ICollection(Of Byte))
				Dim result = If(temp Is Nothing, New List(Of String), New List(Of String)(temp.Count))
				For Each b In this
					result.Add(b.ToBitString)
				Next
				If groupingSize = 0 Then Return result.Join("") Else Return result.Join(" ")

			Case ByteFormat.LowerCaseHex
				Return this.ToString("x2", groupingSize)

			Case ByteFormat.UpperCaseHex
				Return this.ToString("X2", groupingSize)

			Case Else
				Debug.Assert(False, "This should have been caught above. Did someone add a new ByteFormat?")
				Throw New ArgumentOutOfRangeException("format")

		End Select
	End Function

#End Region

#Region "Byte"
	''' <summary>
	''' Returns the value as a series of bits from most to least significant bit
	''' </summary>
	''' <param name="this"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Function ToBitString(ByVal this As Byte) As String
		Dim result As New Text.StringBuilder(7)
		For i = 7 To 0 Step -1
			result.Append(If(this.IsBitSet(i), "1", "0"))
		Next

		Return result.ToString
	End Function

	''' <summary>
	''' Returns the value as a string
	''' </summary>
	''' <param name="this"></param>
	''' <param name="format"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	''' <exception cref="System.ArgumentOutOfRangeException">Thrown is format isn't a defined value</exception>
	<Extension()> Function ToString(ByVal this As Byte, ByVal format As ByteFormat) As String
		Select Case format
			Case ByteFormat.Bits
				Return this.ToBitString

			Case ByteFormat.LowerCaseHex
				Return this.ToString("x2")

			Case ByteFormat.UpperCaseHex
				Return this.ToString("X2")

			Case Else
				Throw New ArgumentOutOfRangeException("format")
		End Select
	End Function

	''' <summary>
	''' Determines if a given bit is set.
	''' </summary>
	''' <param name="this"></param>
	''' <param name="bit">0 to 7, 0 being the least significant digit</param>
	''' <returns></returns>
	''' <remarks></remarks>
	''' <exception cref="System.ArgumentOutOfRangeException">Thrown if bit is outside 0 to 7</exception>
	<Extension()> Public Function IsBitSet(ByVal this As Byte, ByVal bit As Integer) As Boolean
		If Not bit.IsBetween(0, 7) Then Throw New ArgumentOutOfRangeException("bit")
		Dim bitMask As Integer = 1 << bit
		Return CBool(this And bitMask)
	End Function

#End Region


	''' <summary>
	''' The format used to convert bytes to strings
	''' </summary>
	''' <remarks></remarks>
	Public Enum ByteFormat
		''' <summary>
		''' Bits
		''' </summary>
		''' <remarks></remarks>
		Bits = 0
		''' <summary>
		''' Two-digit hexadecimal using lowercase letters
		''' </summary>
		''' <remarks></remarks>
		UpperCaseHex = 1
		''' <summary>
		''' Two-digit hexadecimal using uppercase letters
		''' </summary>
		''' <remarks></remarks>
		LowerCaseHex = 2
	End Enum

#Region "Byte()"

	''' <summary>
	''' This converts a byte array to a string using the supplied encoding
	''' </summary>
	''' <param name="this"></param>
	''' <param name="encoding">Cannot be null.</param>
	''' <returns></returns>
	''' <remarks>We don't use the "default" encoding because it is almost invariably wrong.</remarks>
	''' <exception cref="System.ArgumentNullException">Thrown is encoding is null</exception>
	<Extension()> Function ToString(ByVal this As Byte(), ByVal encoding As Text.Encoding) As String
		If encoding Is Nothing Then Throw New ArgumentNullException("encoding")
		If this Is Nothing Then Return ""
		If this.Length = 0 Then Return ""

		Return encoding.GetString(this)
	End Function

	''' <summary>
	''' This converts a string into a byte array using the specified encoding
	''' </summary>
	''' <param name="this"></param>
	''' <param name="encoding">Cannot be null.</param>
	''' <returns></returns>
	''' <remarks></remarks>
	''' <exception cref="System.ArgumentNullException">Thrown is encoding is null</exception>
	<Extension()> Public Function ToByteArray(ByVal this As String, ByVal encoding As Text.Encoding) As Byte()
		If this = "" Then Return New Byte() {}
		Return encoding.GetBytes(this)
	End Function

#End Region


End Module


