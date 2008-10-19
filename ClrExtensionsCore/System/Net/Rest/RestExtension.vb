'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.CompilerServices
Imports ClrExtensions.Net.Rest

Public Module RestExtension
	<Extension()> Public Function ToMethodString(ByVal value As RestVerb) As String
		Select Case value
			Case RestVerb.Delete : Return "DELETE"
			Case RestVerb.Get : Return "GET"
			Case RestVerb.Post : Return "POST"
			Case RestVerb.Put : Return "PUT"
			Case Else : Throw New ArgumentOutOfRangeException
		End Select
	End Function

	<Extension()> Public Function ToSchemeString(ByVal value As RestScheme) As String
		Select Case value
			Case RestScheme.Http : Return "http://"
			Case RestScheme.https : Return "https://"
			Case Else : Throw New ArgumentOutOfRangeException
		End Select
	End Function

End Module
