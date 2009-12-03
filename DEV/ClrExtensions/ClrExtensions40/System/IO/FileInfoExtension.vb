'Copyright (c) 2008, Jonathan Allen

#If IncludeUntested Then

Public Module FileInfoExtension

#If ClrVersion > 0 Then
    ''' <summary>
    ''' This prints a file using the defaults set by the operating system
    ''' </summary>
    ''' <param name="file"></param>
    ''' <returns>The process for the application that is doing the printing</returns>
    ''' <remarks>This was hand tested because it is so heavily dependent on OS settings</remarks>
    <Extension()> Public Function Print(ByVal file As System.IO.FileInfo) As Process
        If file Is Nothing Then Throw New ArgumentNullException("file")
        If Not file.Exists Then Throw New System.IO.IOException("The file does not exist.")
        Return IOExtension.PrintFile(file.FullName)
    End Function
#End If

End Module
#End If
