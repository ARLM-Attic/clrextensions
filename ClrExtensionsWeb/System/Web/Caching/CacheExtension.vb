Imports ClrExtensions

Public Module CacheExtensions
	<Extension()> Public Sub Clear(ByVal this As Web.Caching.Cache)
		For Each key In this.GetEnumerator.Keys(Of String)()
			this.Remove(key)
		Next
	End Sub

	

End Module


Public Module ListControlExtensions
	'TODO Maybe the AddItem methods should return the newly created item

	<Extension()> Public Sub AddItem(ByVal this As Web.UI.WebControls.ListItemCollection, ByVal text As String, ByVal value As String)
		this.Add(New Web.UI.WebControls.ListItem(text, value))
	End Sub

	<Extension()> Public Sub AddItem(ByVal this As Web.UI.WebControls.ListItemCollection, ByVal text As String, ByVal value As String, ByVal enabled As Boolean)
		this.Add(New Web.UI.WebControls.ListItem(text, value, enabled))
	End Sub

End Module
