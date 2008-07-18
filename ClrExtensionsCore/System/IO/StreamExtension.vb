Imports System.Runtime.InteropServices
Imports ClrExtensions.System.Collections


Module StreamExtension
#If IncludeUntested Then

    <Untested()> <Extension()> Function ToStreamReader(ByVal source As IO.Stream) As IO.StreamReader
        Return New IO.StreamReader(source)
    End Function

    <Untested()> <Extension()> Function ToStreamReader(ByVal source As IO.Stream, ByVal encoding As Text.Encoding) As IO.StreamReader
        Return New IO.StreamReader(source, encoding)
    End Function

    <Untested()> <Extension()> Function ToStreamWriter(ByVal source As IO.Stream) As IO.StreamWriter
        Return New IO.StreamWriter(source)
    End Function

    <Untested()> <Extension()> Function ToStreamWriter(ByVal source As IO.Stream, ByVal encoding As Text.Encoding) As IO.StreamWriter
        Return New IO.StreamWriter(source, encoding)
    End Function

    <Untested()> <Extension()> Sub CopyTo(ByVal source As IO.Stream, ByVal target As IO.Stream, ByVal bufferSize As Integer)
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
    <Untested(), Extension()> _
        Public Sub CopyTo(ByVal source As IO.Stream, ByVal target As IO.Stream)
        Const bufferSize As Integer = 1024 * 4
        CopyTo(source, target, bufferSize)
    End Sub
#End If


End Module
