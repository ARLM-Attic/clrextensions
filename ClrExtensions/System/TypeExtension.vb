Public Module TypeExtension
	<Extension()> Public Function HasAttribute(ByVal this As Type, ByVal attribute As Type) As Boolean
		Return this.GetCustomAttributes(attribute, True).Length > 0
	End Function
End Module
