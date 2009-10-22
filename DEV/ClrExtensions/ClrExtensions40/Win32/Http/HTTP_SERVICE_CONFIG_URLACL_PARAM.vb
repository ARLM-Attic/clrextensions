'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
#If IncludeUntested Then

Namespace Win32.Http
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure HTTP_SERVICE_CONFIG_URLACL_PARAM
        <MarshalAs(UnmanagedType.LPWStr)>
        Public pStringSecurityDescriptor As String

        Public Sub New(ByVal stringSecurityDescriptor As String)
            pStringSecurityDescriptor = stringSecurityDescriptor
        End Sub
    End Structure
End Namespace
#End If