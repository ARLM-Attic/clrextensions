Public Module ThreadExtension
	'The generic Volatile Read and Write are described in http://www.panopticoncentral.net/archive/2004/09/30/1721.aspx
	'C# don't need them, instead use the volatile keyword

	Function VolatileRead(Of T)(ByRef address As T) As T
		VolatileRead = address
		Threading.Thread.MemoryBarrier()
	End Function

	Sub VolatileWrite(Of T)(ByRef address As T, ByVal value As T)
		Threading.Thread.MemoryBarrier()
		address = value
	End Sub

	Sub Sleep(ByVal minutes As Integer, ByVal seconds As Integer)
		Threading.Thread.Sleep((minutes * 60 + seconds) * 1000)
	End Sub

End Module

