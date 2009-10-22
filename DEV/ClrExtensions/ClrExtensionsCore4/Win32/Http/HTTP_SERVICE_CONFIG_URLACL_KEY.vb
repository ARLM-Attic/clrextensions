'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
#If IncludeUntested Then

Namespace Win32.Http
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure HTTP_SERVICE_CONFIG_URLACL_KEY
        <MarshalAs(UnmanagedType.LPWStr)>
        Public pUrlPrefix As String

        Public Sub New(ByVal urlPrefix As String)
            pUrlPrefix = urlPrefix
        End Sub
    End Structure
End Namespace
#End If