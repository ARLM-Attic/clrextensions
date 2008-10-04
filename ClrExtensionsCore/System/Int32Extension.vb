
Public Module Int32Extension

    ''' <summary>
    ''' Returns true if the value is between the low and high value, inclusive
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="lowValue"></param>
    ''' <param name="highValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Extension()> Public Function IsBetween(ByVal value As Integer, ByVal lowValue As Integer, ByVal highValue As Integer) As Boolean
		Return lowValue <= value And value <= highValue
	End Function

#If IncludeUntested = 1 Then

	''' <summary>
	''' Determines if a certain Enumeration Flag is set in a value. Both the value and the flag should be of the same enumeration type, but this isn't enforced.
	''' </summary>
	''' <param name="value">Value to check</param>
	''' <param name="flag">Flag to check for</param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function IsFlagSet(ByVal value As Integer, ByVal flag As Integer) As Boolean
		'TODO: Rewrite this if Microsoft ever decides to support Enumerations with generics
		Return CBool(value And flag)
	End Function


	''' <summary>
	''' Adds the English suffix to a number for displaying in ranks
	''' </summary>
	''' <param name="value"></param>
	''' <returns>1st, 2nd, 3rd, 4th, etc.</returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function EnglishSuffix(ByVal value As Integer) As String
		If value <= 0 Then Throw New ArgumentOutOfRangeException("value")

		If (value Mod 100).IsBetween(10, 19) Then
			Return value & "th"
		Else
			Select Case value Mod 10
				Case 1
					Return value & "st"
				Case 2
					Return value & "nd"
				Case 3
					Return value & "rd"
				Case Else
					Return value & "th"
			End Select
		End If
	End Function

    ''' <summary>
    ''' Returns true is the value is even
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Untested()> <Extension()> Public Function IsEven(ByVal value As Integer) As Boolean
		Return value Mod 2 = 0
	End Function

    ''' <summary>
    ''' Returns true is the value is odd
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Untested()> <Extension()> Public Function IsOdd(ByVal value As Integer) As Boolean
		Return value Mod 2 = 1
	End Function

    ''' <summary>
    ''' Returns true is the value is a multiple of the factor
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="factor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Untested()> <Extension()> Public Function IsMultipleOf(ByVal value As Integer, ByVal factor As Integer) As Boolean
		Return value Mod factor = 0
	End Function

    ''' <summary>
    ''' Returns true is the value is factor of the multiple
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="multiple"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Untested()> <Extension()> Public Function IsFactorOf(ByVal value As Integer, ByVal multiple As Integer) As Boolean
		Return multiple Mod value = 0
	End Function

#End If

	'TODO: Create versions of these for all the interger types

    ''' <summary>
    ''' Determines is a given bit is set
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="bit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Extension()> Public Function IsBitSet(ByVal value As Integer, ByVal bit As Integer) As Boolean
		Dim bitMask As Integer = 1 << bit

		Return CBool(value And bitMask)
	End Function

    ''' <summary>
    ''' Returns a new integer with the given bit set
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="bit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Extension()> Public Function SetBit(ByVal value As Integer, ByVal bit As Integer) As Integer
		Dim bitMask As Integer = 1 << bit

		Return value Or bitMask
	End Function

    ''' <summary>
    ''' Returns a new integer with the given bit cleared
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="bit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Extension()> Public Function ClearBit(ByVal value As Integer, ByVal bit As Integer) As Integer
		Dim bitMask As Integer = Not (1 << bit)

		Return value And bitMask
	End Function

    ''' <summary>
    ''' Turns the given integer into a string of 1's and 0's, with a space after every groupSize digits
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="groupSize">This must be 0, 2, 4, 8, 16, or 32</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Extension()> Public Function ToBitString(ByVal value As Integer, ByVal groupSize As Integer) As String

		Select Case groupSize
			Case 0, 32
				Dim result As New Text.StringBuilder(32 + 4)
				For i = 31 To 0 Step -1
					result.Append(If(value.IsBitSet(i), "1", "0"))
				Next
				Return result.ToString
			Case 2, 4, 8, 16
				Dim result As New Text.StringBuilder(32 + 32 Mod groupSize)
				For i = 31 To 0 Step -1
					result.Append(If(value.IsBitSet(i), "1", "0"))
					If i Mod groupSize = 0 And i <> 0 Then result.Append(" ")
				Next
				Return result.ToString
			Case Else
				Throw New ArgumentOutOfRangeException("groupSize")
		End Select

	End Function

    ''' <summary>
    ''' Turns the given integer into a string of 1's and 0's, with a space after every 8th digit
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Extension()> Public Function ToBitString(ByVal value As Integer) As String
		Return ToBitString(value, 8)
	End Function

    ''' <summary>
    ''' Performs a power operation, casting the result back to an integer
    ''' </summary>
    ''' <param name="base"></param>
    ''' <param name="exponent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Extension()> Public Function Pow(ByVal base As Integer, ByVal exponent As Integer) As Integer
		If base = 0 And exponent < 0 Then Throw New ArgumentException("Not a number")
		Return CInt(base ^ exponent)
	End Function

End Module
