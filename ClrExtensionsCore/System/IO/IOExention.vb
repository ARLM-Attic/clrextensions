Public Module IOExention

    Public Sub MapDrive(ByVal driveLetter As String, ByVal uncName As String)
        Dim fixedUncName As String = uncName
        'This won't work if the unc name ends with a \
        If fixedUncName.EndsWith("\") Then fixedUncName = fixedUncName.Substring(0, fixedUncName.Length - 1)

        Dim oNetWork As New IWshRuntimeLibrary.IWshNetwork_Class
        Try 'This usually isn't necessary, but we can't detect when it is needed.
            oNetWork.RemoveNetworkDrive(driveLetter, True, True)
        Catch ex As Runtime.InteropServices.COMException
            'Ignore errors, it just means it wasn't necessary
        End Try

        oNetWork.MapNetworkDrive(driveLetter, fixedUncName, True)
    End Sub

End Module
