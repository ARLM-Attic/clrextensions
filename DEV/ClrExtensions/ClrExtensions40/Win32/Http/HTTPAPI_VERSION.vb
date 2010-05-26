'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices

Namespace Win32.Http
	<StructLayout(LayoutKind.Sequential, Pack:=2)>
	<CLSCompliant(False)>
	Public Structure HTTPAPI_VERSION
		Public HttpApiMajorVersion As UInt16
		Public HttpApiMinorVersion As UInt16

		Public Sub New(ByVal majorVersion As UInt16, ByVal minorVersion As UInt16)
			HttpApiMajorVersion = majorVersion
			HttpApiMinorVersion = minorVersion
		End Sub

		Public Shared ReadOnly HTTPAPI_VERSION_1 As New HTTPAPI_VERSION(1, 0)
		Public Shared ReadOnly HTTPAPI_VERSION_2 As New HTTPAPI_VERSION(2, 0)

	End Structure
End Namespace
