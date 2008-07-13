#If IncludeUntested Then


<Untested()> Public Module TypeExtension
	<Extension()> Public Function HasAttribute(ByVal type As Type, ByVal attribute As Type) As Boolean
		Return type.GetCustomAttributes(attribute, True).Length > 0
	End Function

	<Extension()> Public Function NameVBFormat(ByVal type As Type) As String
		Return type.Name.Replace("[", "(").Replace("]", ")")
	End Function

End Module
#End If
