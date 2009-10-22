'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
#If IncludeUntested Then

Namespace Win32.Http
	Public Enum HTTP_SERVICE_CONFIG_ID
		' Fields
		HttpServiceConfigIPListenList = 0
		HttpServiceConfigSSLCertInfo = 1
		HttpServiceConfigUrlAclInfo = 2
	End Enum

End Namespace
#End If