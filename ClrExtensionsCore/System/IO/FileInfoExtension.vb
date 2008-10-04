
Module FileInfoExtension

    ''' <summary>
    ''' This prints a file using the defaults set by the operating system
    ''' </summary>
    ''' <param name="file"></param>
    ''' <returns>The process for the application that is doing the printing</returns>
    ''' <remarks>This was hand tested because it is so heavily dependent on OS settings</remarks>
    <Extension()> Public Function Print(ByVal file As IO.FileInfo) As Process
        Return IOExtension.PrintFile(file.FullName)
    End Function

End Module