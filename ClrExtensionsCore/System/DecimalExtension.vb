
Public Module DecimalExtension

	Public Function Pow10(ByVal exponent As Integer) As Decimal
		Dim result As Decimal = 1
		If exponent > 0 Then
			For i = 1 To exponent
				result *= 10
			Next
		ElseIf exponent < 0 Then
			For i = exponent To -1
				result /= 10
			Next
		End If
		Return result
	End Function

	''' <summary>
	''' Truncates the decimal to the specified precision
	''' </summary>
	''' <param name="value"></param>
	''' <param name="precision">Number of decimal places to retain. If negative, number of zeros to the left of the decimal place.</param>
	''' <returns></returns>
	''' <remarks>This may inadvertendly throw an overflow exception for large values</remarks>
	<Extension()> Public Function TruncatePrecision(ByVal value As Decimal, ByVal precision As Integer) As Decimal
		Try
			Dim precisionPower = Pow10(precision)
			Return Decimal.Truncate(value * precisionPower) / precisionPower
		Catch ex As OverflowException
			'Revert to slow method
			Dim literal = value.ToString

			Select Case precision
				Case Is > 0
					Dim dotIndex = literal.IndexOf(".")
					If dotIndex + precision + 1 > literal.Length Then Return CDec(literal.Substring(0, dotIndex + precision + 1))
					Return value
				Case 0
					Return CDec(literal.Substring(0, literal.IndexOf(".")))
				Case Is < 0
					Return CDec(literal.Substring(0, literal.IndexOf(".") + precision) & "0".Repeat(-1 * precision))
			End Select
		End Try
	End Function

End Module

