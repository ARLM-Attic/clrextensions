Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Security.Principal

Namespace Win32.Http

	''' <summary>
	''' This context can be used for performing configuration operations against http.dll.
	''' </summary>
	''' <remarks>This has to be hand-tested because it messes with the OS</remarks>
	Public Class HttpApiConfigContext
		Implements IDisposable

		Public Sub New()
			HttpInitialize(HTTPAPI_VERSION.HTTPAPI_VERSION_1, HttpInitializeFlags.HTTP_INITIALIZE_CONFIG, IntPtr.Zero).ThrowOnError()
		End Sub

		Private m_Disposed As Boolean

		Protected Overridable Sub Dispose(ByVal disposing As Boolean)
			If Not m_Disposed Then
				'We are going to let this throw because it means we have serious problems
				HttpTerminate(HttpInitializeFlags.HTTP_INITIALIZE_CONFIG, IntPtr.Zero).ThrowOnError()
			End If
			m_Disposed = True
		End Sub

		Public Sub Dispose() Implements IDisposable.Dispose
			Dispose(True)
			GC.SuppressFinalize(Me)
		End Sub

		Protected Overrides Sub Finalize()
			Dispose(False)
		End Sub

		Public Sub SetUrlAcl(ByVal url As String, ByVal acl As UrlAcl)
			CheckDisposed()

			Dim config As HTTP_SERVICE_CONFIG_URLACL_SET
			config.KeyDesc.pUrlPrefix = url
			config.ParamDesc.pStringSecurityDescriptor = acl.ToSddl

			HttpSetServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigUrlAclInfo, config, Marshal.SizeOf(config), IntPtr.Zero).ThrowOnError()

		End Sub

		Private Sub CheckDisposed()
            If m_Disposed Then Throw New InvalidOperationException("Context has been disposed")
		End Sub

		Public Sub DeleteUrlAcl(ByVal url As String)
			CheckDisposed()

			Dim config As HTTP_SERVICE_CONFIG_URLACL_SET
			config.KeyDesc.pUrlPrefix = url
			config.ParamDesc.pStringSecurityDescriptor = ""
			HttpDeleteServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigUrlAclInfo, config, Marshal.SizeOf(config), IntPtr.Zero).ThrowOnError()
		End Sub

		Public Function QueryUrlAcl() As Dictionary(Of String, UrlAcl)
			CheckDisposed()

			Dim result As New Dictionary(Of String, UrlAcl)

			Dim input As New HTTP_SERVICE_CONFIG_URLACL_QUERY
			Dim returnLength As Integer

			input.dwToken = 0
			input.QueryDesc = HTTP_SERVICE_CONFIG_QUERY_TYPE.HttpServiceConfigQueryNext

			Dim errCode As SystemErrorCode
			Do
				'This call is used to determine how large of a buffer to create
				errCode = HttpQueryServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigUrlAclInfo, input, Marshal.SizeOf(input), IntPtr.Zero, 0, returnLength, IntPtr.Zero)

				errCode.ThrowOnError(SystemErrorCode.ERROR_NO_MORE_ITEMS, SystemErrorCode.ERROR_INSUFFICIENT_BUFFER)

				If errCode = SystemErrorCode.ERROR_NO_MORE_ITEMS Then Exit Do 'we already have all of the items

				If errCode = SystemErrorCode.ERROR_INSUFFICIENT_BUFFER Then

					Using buffer As New StructPointer(Of HTTP_SERVICE_CONFIG_URLACL_SET)(returnLength)
						'This call actually gets the value
						Dim output As New HTTP_SERVICE_CONFIG_URLACL_SET
						HttpQueryServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigUrlAclInfo, input, Marshal.SizeOf(input), buffer.Pointer, returnLength, returnLength, IntPtr.Zero).ThrowOnError()

						output = buffer.Structure
						result.Add(output.KeyDesc.pUrlPrefix, New UrlAcl(output.ParamDesc.pStringSecurityDescriptor))
					End Using
				End If
				input.dwToken += 1
			Loop

			Return result
		End Function

#If IncludeUntested Then
		<Untested()> Public Function QueryUrlAcl(ByVal url As String) As Dictionary(Of String, UrlAcl)
			Throw New NotImplementedException

			'use HttpServiceConfigQueryExact
		End Function
#End If

	End Class
End Namespace
