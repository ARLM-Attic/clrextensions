#If ClrVersion >= 40 Then

Option Strict Off

Public Module FSharpInterop
    <Pure()> Public Function OptionGetUnderlyingValue(ByVal value As Object) As Object
        If value Is Nothing Then Return Nothing
        Dim temp = value
        Do While temp.GetType.Name = "FSharpOption`1"
            temp = temp.Value
            If temp Is Nothing Then Return Nothing
        Loop
        Return temp
    End Function
End Module

#End If