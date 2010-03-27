'Copyright (c) 2008, Jonathan Allen
Imports System.Runtime.InteropServices
Imports ClrExtensions.Collections
#If IncludeUntested Then

Public Module DirectoryInfo

#If ClrVersion >= 40 Then

    ''' <summary>
    ''' Copies the contents of one folder to another
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="target"></param>
    ''' <param name="recursive">If true the copy is recursive</param>
    ''' <param name="overwrite">If true files will be silently over-written. If false, a pre-existing file will cause an exception to be thrown</param>
    ''' <remarks></remarks>
    <Untested()> <Extension()>  Sub CopyTo(ByVal source As System.IO.DirectoryInfo, ByVal target As System.IO.DirectoryInfo, ByVal recursive As Boolean, ByVal overwrite As Boolean)
        If source Is Nothing Then Throw New ArgumentNullException("source")
        If target Is Nothing Then Throw New ArgumentNullException("target")
        target.Create()

        For Each file In source.EnumerateFiles
            file.CopyTo(System.IO.Path.Combine(target.FullName, file.Name), overwrite)
        Next
        If recursive Then
            For Each directory In source.EnumerateDirectories
                Dim childTarget As New System.IO.DirectoryInfo(System.IO.Path.Combine(target.FullName, directory.Name))
                childTarget.Create()
                childTarget.CopyTo(childTarget, recursive, overwrite)
            Next
        End If
    End Sub
#End If

End Module

#End If
