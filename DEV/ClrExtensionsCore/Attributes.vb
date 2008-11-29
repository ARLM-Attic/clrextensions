'Copyright (c) 2008, Jonathan Allen


#If CONFIG = "Release-Untested" Then

<AttributeUsage(AttributeTargets.All, AllowMultiple:=False, Inherited:=True)> _
Public Class UntestedAttribute
    Inherits Attribute
End Class

#ElseIf CONFIG = "Debug" Then

    'In debug mode we flag untested features to make them more noticable

<Obsolete()> _
<AttributeUsage(AttributeTargets.All, AllowMultiple:=False, Inherited:=True)> _
Public Class UntestedAttribute
    Inherits Attribute
End Class

#ElseIf CONFIG = "Release" Then

<Obsolete("Untested code shouldn't be in this release", True)> _
<AttributeUsage(AttributeTargets.All, AllowMultiple:=False, Inherited:=True)> _
Public Class UntestedAttribute
    Inherits Attribute
End Class


#End If
