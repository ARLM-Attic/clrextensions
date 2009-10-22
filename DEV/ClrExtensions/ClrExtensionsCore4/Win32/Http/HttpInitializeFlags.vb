'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
#If IncludeUntested Then

Namespace Win32.Http
	<Flags()> Public Enum HttpInitializeFlags As UInt32
		HTTP_INITIALIZE_SERVER = &H1
		HTTP_INITIALIZE_CONFIG = &H2
	End Enum
End Namespace
#End If