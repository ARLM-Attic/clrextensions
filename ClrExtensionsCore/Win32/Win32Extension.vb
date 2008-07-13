
Namespace Win32
	Module Win32Extension
		''' <summary>
		''' Turns an error code into an exception unless the error code is NO_ERROR
		''' </summary>
		''' <param name="errorCode"></param>
		''' <remarks></remarks>
		<Extension()> Public Sub ThrowOnError(ByVal errorCode As SystemErrorCode)
			If errorCode <> SystemErrorCode.NO_ERROR Then Throw New Win32Exception(errorCode)
		End Sub

		''' <summary>
		''' Turns an error code into an exception unless the error code is NO_ERROR or in the valuesResults list.
		''' </summary>
		''' <param name="errorCode"></param>
		''' <param name="validResults"></param>
		''' <remarks></remarks>
		<Extension()> Public Sub ThrowOnError(ByVal errorCode As SystemErrorCode, ByVal ParamArray validResults() As SystemErrorCode)
			If errorCode = SystemErrorCode.NO_ERROR Then Return
			If Not errorCode.IsIn(validResults) Then Throw New Win32Exception(errorCode)
		End Sub
	End Module
End Namespace
