'Copyright (c) 2008, Jonathan Allen

Public Module LongExtension

    'TODO - Support the various meanings for KB, MB, and GB

    Private Const GB As Long = CLng(1024 ^ 3)
    Private Const MB As Long = CLng(1024 ^ 2)
    Private Const KB As Long = CLng(1024 ^ 1)
    Private Const B As Long = 1

    ''' <summary>
    ''' Converts a byte count into a string such as "1.2 KB"
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns></returns>
    ''' <remarks>1 KB=1024 Bytes, 1 MB=1024 KB, 1 GB = 1024 MB
    ''' The return format is "##0.## XX" where XX is B, KB, MB, or GB as appropriate</remarks>
    <Extension()> Public Function ToByteSize(ByVal bytes As Long) As String
        Select Case CDbl(bytes)
            Case Is >= GB
                Return (bytes / (GB)).ToString("##0.##") & " GB"
            Case Is >= MB
                Return (bytes / MB).ToString("##0.##") & " MB"
            Case Is >= KB
                Return (bytes / KB).ToString("##0.##") & " KB"
            Case Else
                Return bytes & " B"
        End Select
    End Function

    ''' <summary>
    ''' This reads a string such as "1.2 KB" and turns it into a count of bytes
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function ParseByteSize(ByVal value As String) As Long
        If value Is Nothing Then Throw New ArgumentNullException("value")


        Dim temp As String = value.Replace(" ", "").ToUpper

        Try
            If temp.EndsWith("GB") Then
                Return CLng(GB * CDec(temp.Substring(0, temp.Length - 2)))
            ElseIf temp.EndsWith("MB") Then
                Return CLng(MB * CDec(temp.Substring(0, temp.Length - 2)))
            ElseIf temp.EndsWith("KB") Then
                Return CLng(KB * CDec(temp.Substring(0, temp.Length - 2)))
            ElseIf temp.EndsWith("B") Then
                Return CLng(temp.Substring(0, temp.Length - 1))
            Else
                Return CLng(temp)
            End If
        Catch ex As OverflowException
            Throw New FormatException("Cannot parse string")
        End Try

    End Function
End Module
