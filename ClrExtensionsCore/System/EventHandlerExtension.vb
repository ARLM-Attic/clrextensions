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
