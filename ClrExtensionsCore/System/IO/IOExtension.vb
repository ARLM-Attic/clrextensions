﻿Public Module IOExtension

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="driveLetter"></param>
    ''' <param name="uncName"></param>
    ''' <remarks>This was hand tested. We cannot automate because it messes with the OS</remarks>
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


    ''' <summary>
    ''' This prints a file using the defaults set by the operating system
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks>This was hand tested because it is so heavily dependent on OS settings</remarks>
    Public Function PrintFile(ByVal fileName As String) As Process
        Dim printJob As New Process()
        printJob.StartInfo.FileName = fileName
        printJob.StartInfo.UseShellExecute = True
        printJob.StartInfo.Verb = "print"
        printJob.Start()
        Return printJob
    End Function

End Module
