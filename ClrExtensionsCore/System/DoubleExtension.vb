Public Module DoubleExtension

	''' <summary>
	''' Shortcut to replace the missing POW operator in C#
	''' </summary>
	''' <param name="value"></param>
	''' <param name="exponent"></param>
	''' <returns></returns>
	''' <remarks>Not needed in VB, but C# doesn't have an exponent operator</remarks>
	<Extension()> Public Function Pow(ByVal value As Double, ByVal exponent As Double) As Double
		Return value ^ exponent
	End Function

	''' <summary>
	''' Shortcut to replace the missing POW operator in C#
	''' </summary>
	''' <param name="value"></param>
	''' <param name="exponent"></param>
	''' <returns></returns>
	''' <remarks>Not needed in VB, but C# doesn't have an exponent operator</remarks>
	<Extension()> Public Function Pow(ByVal value As Double, ByVal exponent As Integer) As Double
		Return value ^ exponent
	End Function


End Module
