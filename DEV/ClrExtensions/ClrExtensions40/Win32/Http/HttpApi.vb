'Copyright (c) 2008, Jonathan Allen

Namespace Win32.Http
	<CLSCompliant(False)>
	Public Module HttpApi

		Declare Function HttpSetServiceConfiguration Lib "httpapi.dll" Alias "HttpSetServiceConfiguration" (ByVal ServiceIntPtr As IntPtr, ByVal ConfigId As HTTP_SERVICE_CONFIG_ID, ByRef configInformation As HTTP_SERVICE_CONFIG_URLACL_SET, ByVal ConfigInformationLength As Integer, ByVal pOverlapped As IntPtr) As SystemErrorCode

		'TODO - Set versions of SSLCert and IPListen

		'Declare Function HttpSetServiceConfiguration Lib "httpapi.dll" Alias "HttpSetServiceConfiguration" (ByVal ServiceIntPtr As IntPtr, ByVal ConfigId As HTTP_SERVICE_CONFIG_ID, ByRef configInformation As HTTP_SERVICE_CONFIG_SSL_SET, ByVal ConfigInformationLength As Integer, ByVal pOverlapped As IntPtr) As SystemErrorCode

		'Declare Function HttpSetServiceConfiguration Lib "httpapi.dll" Alias "HttpSetServiceConfiguration" (ByVal ServiceIntPtr As IntPtr, ByVal ConfigId As HTTP_SERVICE_CONFIG_ID, ByRef configInformation As HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM, ByVal ConfigInformationLength As Integer, ByVal pOverlapped As IntPtr) As SystemErrorCode

		Public Declare Function HttpDeleteServiceConfiguration Lib "httpapi.dll" Alias "HttpDeleteServiceConfiguration" (ByVal ServiceIntPtr As IntPtr, ByVal ConfigId As HTTP_SERVICE_CONFIG_ID, ByRef configInformation As HTTP_SERVICE_CONFIG_URLACL_SET, ByVal ConfigInformationLength As Integer, ByVal pOverlapped As IntPtr) As SystemErrorCode

		'TODO - Delete versions of SSLCert and IPListen

		'Public Declare Function HttpDeleteServiceConfiguration Lib "httpapi.dll" Alias "HttpDeleteServiceConfiguration" (ByVal ServiceIntPtr As IntPtr, ByVal ConfigId As HTTP_SERVICE_CONFIG_ID, ByRef configInformation As HTTP_SERVICE_CONFIG_SSL_SET, ByVal ConfigInformationLength As Integer, ByVal pOverlapped As IntPtr) As SystemErrorCode

		'Public Declare Function HttpDeleteServiceConfiguration Lib "httpapi.dll" Alias "HttpDeleteServiceConfiguration" (ByVal ServiceIntPtr As IntPtr, ByVal ConfigId As HTTP_SERVICE_CONFIG_ID, ByRef configInformation As HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM, ByVal ConfigInformationLength As Integer, ByVal pOverlapped As IntPtr) As SystemErrorCode


		Public Declare Function HttpInitialize Lib "httpapi.dll" Alias "HttpInitialize" (ByVal version As HTTPAPI_VERSION, ByVal flags As HttpInitializeFlags, ByVal pReservedn As IntPtr) As SystemErrorCode

		Public Declare Function HttpQueryServiceConfiguration Lib "httpapi.dll" Alias "HttpQueryServiceConfiguration" (ByVal ServiceHandle As IntPtr, ByVal ConfigId As HTTP_SERVICE_CONFIG_ID, ByRef inputConfigInfo As HTTP_SERVICE_CONFIG_URLACL_QUERY, ByVal InputConfigInfoLength As Integer, ByVal pOutputConfigInfo As IntPtr, ByVal OutputConfigInfoLength As Integer, ByRef pReturnLength As Integer, ByVal pOverlapped As IntPtr) As SystemErrorCode

		'TODO - Query versions of SSLCert and IPListen

		Public Declare Function HttpTerminate Lib "httpapi.dll" Alias "HttpTerminate" (ByVal flags As HttpInitializeFlags, ByVal pReservedn As IntPtr) As SystemErrorCode

	End Module
End Namespace
