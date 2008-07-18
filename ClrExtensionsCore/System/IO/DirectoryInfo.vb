Imports System.Runtime.InteropServices
Imports ClrExtensions.System.Collections


Module DirectoryInfo

#If IncludeUntested Then

    <Untested()> <Extension()> Public Sub CopyTo(ByVal source As IO.DirectoryInfo, ByVal target As IO.DirectoryInfo, ByVal recursive As Boolean, ByVal overwrite As Boolean)
        If source Is Nothing Then Throw New ArgumentNullException("source")
        If target Is Nothing Then Throw New ArgumentNullException("target")
        target.Create()

        For Each file In source.GetFiles
            file.CopyTo(IO.Path.Combine(target.FullName, file.Name), overwrite)
        Next
        If recursive Then
            For Each directory In source.GetDirectories
                Dim childTarget As New IO.DirectoryInfo(IO.Path.Combine(target.FullName, directory.Name))
                childTarget.Create()
                childTarget.CopyTo(childTarget, recursive, overwrite)
            Next
        End If
    End Sub


#End If

End Module
