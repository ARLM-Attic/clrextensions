Imports System.Runtime.InteropServices

Namespace Win32.Http
	<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
	 Public Structure HTTP_SERVICE_CONFIG_URLACL_KEY
		<MarshalAs(UnmanagedType.LPWStr)> _
		Public pUrlPrefix As String

		Public Sub New(ByVal urlPrefix As String)
			pUrlPrefix = urlPrefix
		End Sub
	End Structure
End Namespace
