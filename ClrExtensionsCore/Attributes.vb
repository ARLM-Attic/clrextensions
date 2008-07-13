
#If CONFIG = "Release-Untested" Then

Public Class UntestedAttribute
	Inherits Attribute
End Class

#ElseIf CONFIG = "Debug" Then

'In debug mode we flag untested features to make them more noticable

<Obsolete()> Public Class UntestedAttribute
	Inherits Attribute
End Class

#ElseIf CONFIG = "Release" Then

<Obsolete( "Untested code shouldn't be in this release", True )> Public Class UntestedAttribute
	Inherits Attribute
End Class


#End If
