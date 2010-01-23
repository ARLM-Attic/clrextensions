'Copyright (c) 2008, Jonathan Allen
#If IncludeUntested Then

Imports System.Runtime.CompilerServices
Imports ClrExtensions.Net.Rest

Public Module RestExtension
    <Untested()>
 <Extension()>  Function ToMethodString(ByVal value As RestVerb) As String
        Select Case value
            Case RestVerb.Delete : Return "DELETE"
            Case RestVerb.Get : Return "GET"
            Case RestVerb.Post : Return "POST"
            Case RestVerb.Put : Return "PUT"
            Case Else : Throw New ArgumentOutOfRangeException("value")
        End Select
    End Function

    <Untested()>
 <Extension()>  Function ToSchemeString(ByVal value As RestScheme) As String
        Select Case value
            Case RestScheme.Http : Return "http://"
            Case RestScheme.Https : Return "https://"
            Case Else : Throw New ArgumentOutOfRangeException("value")
        End Select
    End Function

#If Subset <> "Client" Then
    <Untested()>
    Friend Function GetRestSchemeValues() As ICollection(Of RestScheme)
        Return New RestScheme() {RestScheme.Http, RestScheme.Https}
    End Function
#End If

End Module
#End If