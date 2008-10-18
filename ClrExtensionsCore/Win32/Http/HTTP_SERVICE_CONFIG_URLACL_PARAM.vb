'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices

Namespace Win32.Http
	<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
	 Public Structure HTTP_SERVICE_CONFIG_URLACL_PARAM
		<MarshalAs(UnmanagedType.LPWStr)> _
		Public pStringSecurityDescriptor As String

		Public Sub New(ByVal stringSecurityDescriptor As String)
			pStringSecurityDescriptor = stringSecurityDescriptor
		End Sub
	End Structure
End Namespace
