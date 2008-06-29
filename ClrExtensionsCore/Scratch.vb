Public Module Scratch
	Sub test()

		Dim x = New Integer() {1, 2, 3, 4, 5, 6}
		Dim max = x.Max
		x.ToIEnumerable.TryCastNullable(Of Integer)()

	End Sub


	Public Event Boom As EventHandler(Of EventArgs)


End Module


Public Module LongExtension
	'TODO - Add the method for turning longs into formatted strings like 12.3MB
End Module

Public Module DoubleExtension

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

Public Module ExceptionExtension
	'TODO Add a function to dump the detailed SQL exceptions that are not normally part of SqlException.ToString

End Module

Public Module EventHandlerExtension

	''' <summary>
	''' This method is only available to C# applications. VB programs should use the RaiseEvent keyword instead.
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <param name="this"></param>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	<MethodImpl(MethodImplOptions.NoInlining)> _
	<Extension()> Public Sub [RaiseEvent](Of T As EventArgs)(ByVal this As EventHandler(Of T), ByVal sender As Object, ByVal e As T)
		Threading.Thread.MemoryBarrier()
		If this IsNot Nothing Then this(sender, e)
	End Sub

End Module

Public Module ThreadingExtension
	'The generic Volatile Read and Write are described in http://www.panopticoncentral.net/archive/2004/09/30/1721.aspx
	'C# don't need them, instead the volatile keyword

	Function VolatileRead(Of T)(ByRef Address As T) As T
		VolatileRead = Address
		Threading.Thread.MemoryBarrier()
	End Function

	Sub VolatileWrite(Of T)(ByRef Address As T, ByVal Value As T)
		Threading.Thread.MemoryBarrier()
		Address = Value
	End Sub

End Module


