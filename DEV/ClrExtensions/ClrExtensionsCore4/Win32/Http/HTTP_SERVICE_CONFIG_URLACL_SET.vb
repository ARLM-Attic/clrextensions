'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
#If IncludeUntested Then

Namespace Win32.Http
    <StructLayout(LayoutKind.Sequential)>
    Public Structure HTTP_SERVICE_CONFIG_URLACL_SET
        Public KeyDesc As HTTP_SERVICE_CONFIG_URLACL_KEY
        Public ParamDesc As HTTP_SERVICE_CONFIG_URLACL_PARAM
    End Structure
End Namespace
#End If