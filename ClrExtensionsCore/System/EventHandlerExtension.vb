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

	''' <summary>
	''' This method is only available to C# applications. VB programs should use the RaiseEvent keyword instead.
	''' </summary>
	''' <param name="this"></param>
	''' <param name="sender"></param>
	''' <remarks></remarks>
	<MethodImpl(MethodImplOptions.NoInlining)> _
	<Extension()> Public Sub [RaiseEvent](ByVal this As EventHandler(Of EventArgs), ByVal sender As Object)
		Threading.Thread.MemoryBarrier()
		If this IsNot Nothing Then this(sender, EventArgs.Empty)
	End Sub
End Module
