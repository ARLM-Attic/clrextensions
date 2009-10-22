Option Strict Off
Imports Microsoft.FSharp.Core

Public Module FSharpInterop
    Public Function OptionGetUnderlyingValue(ByVal value As Object) As Object
        If value Is Nothing Then Return Nothing
        Dim temp = value
        Do While temp.GetType.Name = "FSharpOption`1"
            temp = OptionModule.GetValue(temp)
            If temp Is Nothing Then Return Nothing
        Loop
        Return temp
    End Function
End Module
