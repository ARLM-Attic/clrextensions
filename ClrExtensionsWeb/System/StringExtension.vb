Imports System.Web



Public Module StringExtension
	<Extension()> Public Function HtmlEncode(ByVal this As String) As String
		Return HttpUtility.HtmlEncode(this)
	End Function

	<Extension()> Public Function HtmlDecode(ByVal this As String) As String
		Return HttpUtility.HtmlDecode(this)
	End Function


	<Extension()> Public Function UrlEncode(ByVal this As String) As String
		Return HttpUtility.UrlEncode(this)
	End Function

	<Extension()> Public Function UrlDecode(ByVal this As String) As String
		Return HttpUtility.UrlDecode(this)
	End Function

	<Extension()> Public Function UrlPathEncode(ByVal this As String) As String
		Return HttpUtility.UrlPathEncode(this)
	End Function

	<Extension()> Public Function ParseQueryString(ByVal this As String) As Specialized.NameValueCollection
		Return HttpUtility.ParseQueryString(this)
	End Function

End Module