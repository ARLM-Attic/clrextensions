'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices

Namespace Win32.Http
	<StructLayout(LayoutKind.Sequential)> _
	 Public Structure HTTP_SERVICE_CONFIG_URLACL_QUERY
		Public QueryDesc As HTTP_SERVICE_CONFIG_QUERY_TYPE
		Public KeyDesc As HTTP_SERVICE_CONFIG_URLACL_KEY
		Public dwToken As Integer
	End Structure
End Namespace
