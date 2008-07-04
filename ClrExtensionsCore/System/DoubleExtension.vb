<Obsolete("Untested")> Public Module DoubleExtension

	''' <summary>
	''' 
	''' </summary>
	''' <param name="this"></param>
	''' <param name="exponent"></param>
	''' <returns></returns>
	''' <remarks>Not needed in VB, but C# doesn't have an exponent operator</remarks>
	<Extension()> Public Function Pow(ByVal this As Double, ByVal exponent As Double) As Double
		Return this ^ exponent
	End Function
End Module
