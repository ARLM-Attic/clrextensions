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