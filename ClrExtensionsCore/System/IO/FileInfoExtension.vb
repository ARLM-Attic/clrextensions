
Module FileInfoExtension

    <Extension()> Public Function Print(ByVal file As IO.FileInfo) As Process
        Return IOExtension.PrintFile(file.FullName)
    End Function

End Module