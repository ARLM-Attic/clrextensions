<Obsolete("Untested")> Public Module ThreadExtension
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

	Sub Sleep(ByVal minutes As Integer, ByVal seconds As Integer)
		Threading.Thread.Sleep(minutes * 60 * 1000 + seconds * 60)
	End Sub
End Module

