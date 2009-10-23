'Copyright (c) 2008, Jonathan Allen
#If IncludeUntested Then

Public Module Events
	''' <summary>
	''' This method is only available to C# applications. VB programs should use the RaiseEvent keyword instead.
	''' </summary>
	''' <param name="event"></param>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks>This method prevents race conditions from causing an unexpected null reference exception when raising an event.</remarks>
    <Untested()>
    <MethodImpl(MethodImplOptions.NoInlining)>
    <Extension()>
    Public Sub Raise(ByVal [event] As EventHandler, ByVal sender As Object, ByVal e As EventArgs)
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
	''' <remarks>This method prevents race conditions from causing an unexpected null reference exception when raising an event.</remarks>
    <MethodImpl(MethodImplOptions.NoInlining)>
    <Extension()>
    Public Sub Raise(Of T As EventArgs)(ByVal [event] As EventHandler(Of T), ByVal sender As Object, ByVal e As T)
        Threading.Thread.MemoryBarrier()
        If [event] IsNot Nothing Then [event](sender, e)
    End Sub

	''' <summary>
	''' This method is only available to C# applications. VB programs should use the RaiseEvent keyword instead.
	''' </summary>
	''' <param name="event"></param>
	''' <param name="sender"></param>
	''' <remarks>This method prevents race conditions from causing an unexpected null reference exception when raising an event.</remarks>
    <MethodImpl(MethodImplOptions.NoInlining)>
    <Extension()>
    Public Sub [RaiseEvent](ByVal [event] As EventHandler(Of EventArgs), ByVal sender As Object)
        Threading.Thread.MemoryBarrier()
        If [event] IsNot Nothing Then [event](sender, EventArgs.Empty)
    End Sub

	''' <summary>
	''' This method is only available to C# applications. VB programs should use the RaiseEvent keyword instead.
	''' </summary>
	''' <param name="event"></param>
	''' <param name="sender"></param>
	''' <remarks>This method prevents race conditions from causing an unexpected null reference exception when raising an event.</remarks>
    <MethodImpl(MethodImplOptions.NoInlining)>
    <Extension()>
    Public Sub Raise(ByVal [event] As EventHandler, ByVal sender As Object)
        Threading.Thread.MemoryBarrier()
        If [event] IsNot Nothing Then [event](sender, EventArgs.Empty)
    End Sub

End Module
#End If