
<Untested()> Public Module DecimalExtension

	Private Function Pow10(ByVal exponent As Integer) As Decimal
		Dim result As Decimal = 1
		If exponent > 0 Then
			For i = 1 To exponent
				result *= 10
			Next
		ElseIf exponent < 0 Then
			For i = exponent To -1 Step -1
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
	''' <remarks>This may inadvertendly throw an overflow exception for large values with high precision</remarks>
	<Extension()> Public Function TruncatePrecision(ByVal value As Decimal, ByVal precision As Integer) As Decimal
		Dim precisionPower = Pow10(precision)
		Return Decimal.Truncate(value * precisionPower) / precisionPower

		'TODO: Rewrite this so it will work with any decimal
	End Function

End Module
