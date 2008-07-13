Imports ClrExtensions



<Untested()> Public Module ListControlExtension
	'TODO Maybe the AddItem methods should return the newly created item

	<Extension()> Public Sub AddItem(ByVal this As Web.UI.WebControls.ListItemCollection, ByVal text As String, ByVal value As String)
		this.Add(New Web.UI.WebControls.ListItem(text, value))
	End Sub

	<Extension()> Public Sub AddItem(ByVal this As Web.UI.WebControls.ListItemCollection, ByVal text As String, ByVal value As String, ByVal enabled As Boolean)
		this.Add(New Web.UI.WebControls.ListItem(text, value, enabled))
	End Sub

End Module
