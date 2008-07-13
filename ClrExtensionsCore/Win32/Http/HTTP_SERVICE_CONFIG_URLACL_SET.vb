Imports System.Runtime.InteropServices

Namespace Win32.Http
	<StructLayout(LayoutKind.Sequential)> _
	 Public Structure HTTP_SERVICE_CONFIG_URLACL_SET
		Public KeyDesc As HTTP_SERVICE_CONFIG_URLACL_KEY
		Public ParamDesc As HTTP_SERVICE_CONFIG_URLACL_PARAM
	End Structure
End Namespace
