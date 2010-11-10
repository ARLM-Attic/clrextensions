'Copyright (c) 2008, Jonathan Allen

Imports ClrExtensions.Win32
Imports System.ComponentModel

Public Module Win32Extension
    ''' <summary>
    ''' Turns an error code into an exception unless the error code is NO_ERROR
    ''' </summary>
    ''' <param name="errorCode"></param>
    ''' <remarks></remarks>
    <Extension()>
    <CLSCompliant(False)>
    Public Sub ThrowOnError(ByVal errorCode As SystemErrorCode)
        If errorCode <> SystemErrorCode.NO_ERROR Then Throw New Win32Exception(CInt(errorCode))
    End Sub

    ''' <summary>
    ''' Turns an error code into an exception unless the error code is NO_ERROR or in the valuesResults list.
    ''' </summary>
    ''' <param name="errorCode"></param>
    ''' <param name="validResults"></param>
    ''' <remarks></remarks>
    <Extension()>
    <CLSCompliant(False)>
    Public Sub ThrowOnError(ByVal errorCode As SystemErrorCode, ByVal ParamArray validResults() As SystemErrorCode)
        If errorCode = SystemErrorCode.NO_ERROR Then Return
        If Not errorCode.IsIn(validResults) Then Throw New Win32Exception(CInt(errorCode))
    End Sub
End Module
