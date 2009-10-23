
Public Module StringBuilderExtension
#If ClrVersion < 40 Then
    ''' <summary>
    ''' Clears a StringBuilder.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    <Extension()> Public Sub Clear(ByVal value As Text.StringBuilder)
        If value Is Nothing Then Throw New ArgumentNullException("value")
        value.Length = 0
    End Sub
#End If
End Module



