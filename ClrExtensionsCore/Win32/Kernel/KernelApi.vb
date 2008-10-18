'Copyright (c) 2008, Jonathan Allen

Imports System
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.Text
Imports System.Security.Principal

Namespace Win32
	Module KernelApi
		'	<DllImport("Kernel32.dll", EntryPoint:="RtlZeroMemory")> _
		'	Public Shared Sub ZeroMemory(ByVal dest As IntPtr, ByVal size As Integer)
		'	End Sub

		Public Declare Sub ZeroMemory Lib "Kernel32.dll" Alias "RtlZeroMemory" (ByVal dest As IntPtr, ByVal size As Integer)

	End Module
End Namespace
