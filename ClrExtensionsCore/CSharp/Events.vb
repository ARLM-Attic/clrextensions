Public Module Events



	''' <summary>
	''' This method is only available to C# applications. VB programs should use the RaiseEvent keyword instead.
	''' </summary>
	''' <param name="event"></param>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	<MethodImpl(MethodImplOptions.NoInlining)> _
	<Extension()> Public Sub Raise(ByVal [event] As EventHandler, ByVal sender As Object, ByVal e As EventArgs)
		Threading.Thread.MemoryBarrier()
		If [event] IsNot Nothing Then [event](sender, e)
	End Sub

	''' <summary>
	''' This method is only available to C# applications. VB programs should use the RaiseEvent keyword instead.
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <param name="event"></param>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	<MethodImpl(MethodImplOptions.NoInlining)> _
	<Extension()> Public Sub Raise(Of T As EventArgs)(ByVal [event] As EventHandler(Of T), ByVal sender As Object, ByVal e As T)
		Threading.Thread.MemoryBarrier()
		If [event] IsNot Nothing Then [event](sender, e)
	End Sub

	''' <summary>
	''' This method is only available to C# applications. VB programs should use the RaiseEvent keyword instead.
	''' </summary>
	''' <param name="event"></param>
	''' <param name="sender"></param>
	''' <remarks></remarks>
	<MethodImpl(MethodImplOptions.NoInlining)> _
	<Extension()> Public Sub Raise(ByVal [event] As EventHandler(Of EventArgs), ByVal sender As Object)
		Threading.Thread.MemoryBarrier()
		If [event] IsNot Nothing Then [event](sender, EventArgs.Empty)
	End Sub

	''' <summary>
	''' This method is only available to C# applications. VB programs should use the RaiseEvent keyword instead.
	''' </summary>
	''' <param name="event"></param>
	''' <param name="sender"></param>
	''' <remarks></remarks>
	<MethodImpl(MethodImplOptions.NoInlining)> _
	<Extension()> Public Sub Raise(ByVal [event] As EventHandler, ByVal sender As Object)
		Threading.Thread.MemoryBarrier()
		If [event] IsNot Nothing Then [event](sender, EventArgs.Empty)
	End Sub
End Module
