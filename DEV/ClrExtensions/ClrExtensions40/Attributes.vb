'Copyright (c) 2008, Jonathan Allen


#If CONFIG = "Release-Untested" Or CONFIG = "Debug-Untested" Then

<AttributeUsage(AttributeTargets.Method Or AttributeTargets.Property Or AttributeTargets.Constructor, AllowMultiple:=False, Inherited:=True)>
NotInheritable  Class UntestedAttribute
    Inherits Attribute
End Class

#ElseIf CONFIG = "Debug" Then

'In debug mode we flag untested features to make them more noticable

'<Obsolete("This method has not been tested")>
<AttributeUsage(AttributeTargets.Method Or AttributeTargets.Property Or AttributeTargets.Constructor, AllowMultiple:=False, Inherited:=True)>
 NotInheritable Class UntestedAttribute
    Inherits Attribute
End Class

#ElseIf CONFIG = "Release" Or CONFIG = "Debug-Tested" Then

<Obsolete("Untested code shouldn't be in this release", True)>
<AttributeUsage(AttributeTargets.Method Or AttributeTargets.Property Or AttributeTargets.Constructor, AllowMultiple:=False, Inherited:=True)>
NotInheritable Class UntestedAttribute
    Inherits Attribute
End Class


#End If
