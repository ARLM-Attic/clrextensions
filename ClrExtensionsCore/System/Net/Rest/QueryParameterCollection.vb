'Copyright (c) 2008, Jonathan Allen
Imports System.Collections.Specialized

Namespace Net.Rest
	Public Class QueryParameterCollection
		Inherits ObjectModel.Collection(Of QueryParameter)
		Public Sub AddRange(ByVal values As System.Collections.Specialized.NameValueCollection)
			For Each key As String In values.Keys
				Me.Add(New QueryParameter(key, values(key)))
			Next
		End Sub
	End Class
End Namespace
