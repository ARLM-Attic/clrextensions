'Copyright (c) 2008, Jonathan Allen

Imports System.Text
Imports System.Runtime.InteropServices
Imports ClrExtensions.Collections
Imports System.IO
#If IncludeUntested Then

Module StreamExtension

	Private Const DefaultBufferSize As Integer = 1024 * 4

    ''' <summary>
    ''' Wraps a Stream with a StreamReader
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	<Untested()> <Extension()> Function ToStreamReader(ByVal source As Stream) As StreamReader
		Return New StreamReader(source)
	End Function

	''' <summary>
	''' Wraps a Stream with a StreamReader using the indicated encoding
	''' </summary>
	''' <param name="source"></param>
	''' <param name="encoding"></param>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()> <Extension()> Function ToStreamReader(ByVal source As Stream, ByVal encoding As Encoding) As StreamReader
        Return New StreamReader(source, encoding)
    End Function

	''' <summary>
	''' Wraps a Stream with a StreamWriter
	''' </summary>
	''' <param name="source"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Function ToStreamWriter(ByVal source As Stream) As StreamWriter
		Return New StreamWriter(source)
	End Function

	''' <summary>
	''' Wraps a Stream with a StreamWriter using the indicated encoding
	''' </summary>
	''' <param name="source"></param>
	''' <returns></returns>
	''' <remarks></remarks>
    <Untested()> <Extension()> Function ToStreamWriter(ByVal source As Stream, ByVal encoding As Encoding) As StreamWriter
        Return New StreamWriter(source, encoding)
    End Function


	''' <summary>
	''' Copies from one stream to another using the specified buffer size
	''' </summary>
	''' <param name="source"></param>
	''' <param name="target"></param>
	''' <param name="bufferSize"></param>
	''' <remarks></remarks>
	<Untested()> <Extension()> Sub CopyTo(ByVal source As Stream, ByVal target As Stream, ByVal bufferSize As Integer)
		Dim buffer(bufferSize - 1) As Byte

		Dim bytesRead As Integer
		Do
			bytesRead = source.Read(buffer, 0, bufferSize)
			If bytesRead = 0 Then Return
			target.Write(buffer, 0, bytesRead)
		Loop
	End Sub

	''' <summary>
	''' Copies one stream to another using a default buffer size of 4KB
	''' </summary>
	''' <param name="source"></param>
	''' <param name="target"></param>
	''' <remarks></remarks>
    <Untested(), Extension()>
    Public Sub CopyTo(ByVal source As Stream, ByVal target As Stream)
        CopyTo(source, target, DefaultBufferSize)
    End Sub


	'<Untested()> <Extension()> Function ReadToEnd(ByVal stream As Stream) As Byte()
	'	Return ReadToEnd(stream, DefaultBufferSize)
	'End Function

	'<Untested()> <Extension()> Function ReadToEnd(ByVal stream As Stream, ByVal bufferSize As Integer) As Byte()
	'	'TODO - implement this
	'End Function

	'''' <summary>
	'''' This will return an empty array if it cannot read the requested number of bytes
	'''' </summary>
	'''' <param name="stream"></param>
	'''' <param name="length"></param>
	'''' <returns></returns>
	'''' <remarks></remarks>
	'<Untested()> <Extension()> Function TryRead(ByVal stream As Stream, ByVal length As Integer) As Byte()
	'	'TODO - implement this
	'End Function

	'<Untested()> <Extension()> Function TryRead(ByVal stream As Stream, ByVal minLegth As Integer, ByVal maxLength As Integer) As Byte()
	'	'TODO - implement this

	'End Function


End Module

#End If


