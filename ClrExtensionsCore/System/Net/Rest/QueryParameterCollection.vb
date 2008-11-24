'Copyright (c) 2008, Jonathan Allen
Imports System.Collections.Specialized

Namespace Net.Rest
	Public Class QueryParameterCollection
		Inherits ObjectModel.Collection(Of QueryParameter)

		Public Sub New()

		End Sub
		Public Sub New(ByVal queryString As String)
			AddByParsing(queryString)
		End Sub

		Public Sub AddRange(ByVal values As System.Collections.Specialized.NameValueCollection)
			For Each key As String In values.Keys
				Me.Add(New QueryParameter(key, values(key)))
			Next
		End Sub

		Public Sub AddByParsing(ByVal queryString As String)
			Me.AddRange(ParseQueryString(queryString))
		End Sub

		Default Public Overloads ReadOnly Property Item(ByVal key As String) As String
			Get
				For Each param In Me
					If String.Equals(param.Name, key, StringComparison.OrdinalIgnoreCase) Then Return param.Value
				Next
				Return Nothing
			End Get
		End Property

		Private Shared Function ParseQueryString(ByVal queryString As String) As ObjectModel.Collection(Of QueryParameter)
			Dim result As New ObjectModel.Collection(Of QueryParameter)
      Dim rows = queryString.Split("&"c) 'removed , StringSplitOptions.RemoveEmptyEntries because CF does not seem to understand
      Dim values() As String

      For Each item As String In rows
        values = item.Split("="c) 'little c insure conversion to char, option explicit does not allow string to implicit cast to char
        result.Add(New QueryParameter(values(0).Trim, values(1).Trim))
      Next
      
      Return result
    End Function


	End Class
End Namespace
