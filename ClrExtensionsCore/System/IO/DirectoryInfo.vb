Imports System.Runtime.InteropServices
Imports ClrExtensions.System.Collections


Module DirectoryInfo

#If IncludeUntested Then

    ''' <summary>
    ''' Copies the contents of one folder to another
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="target"></param>
    ''' <param name="recursive">If true the copy is recursive</param>
    ''' <param name="overwrite">If true files will be silently over-written. If false, a pre-existing file will cause an exception to be thrown</param>
    ''' <remarks></remarks>
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
