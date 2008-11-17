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

		Public Sub AddByParsing(ByVal queryString As String)
			Me.AddRange(ParseQueryString(queryString))
		End Sub

		Public Shared Function ParseQueryString(ByVal queryString As String) As ObjectModel.Collection(Of QueryParameter)
			Dim result As New ObjectModel.Collection(Of QueryParameter)
			Dim rows = queryString.Split("&", StringSplitOptions.RemoveEmptyEntries)

			For Each pair In rows.Select(Function(s) s.Split("=", 2, StringSplitOptions.None))
				If pair.Length = 2 Then result.Add(New QueryParameter(pair(0), pair(1))) Else result.Add(New QueryParameter(pair(0), Nothing))
			Next
			Return result
		End Function


	End Class
End Namespace
