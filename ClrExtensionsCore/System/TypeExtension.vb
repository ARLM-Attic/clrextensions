#If IncludeUntested Then


Public Module TypeExtension
    <Untested()> <Extension()> Public Function HasAttribute(ByVal type As Type, ByVal attribute As Type) As Boolean
        Return type.GetCustomAttributes(attribute, True).Length > 0
    End Function

    <Untested()> <Extension()> Public Function NameVBFormat(ByVal type As Type) As String
        'TODO - handle VB-sepcific names such as Integer, String, and Date
        Return type.Name.Replace("[", "(").Replace("]", ")")
    End Function

End Module
#End If
