'Copyright (c) 2008, Jonathan Allen

Public Module IOExtension

#If Client35 Then
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
#End If

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

	Public Function ToFileName(ByVal text As String) As String
		Dim temp As New System.Text.StringBuilder(text)
		For Each c In IO.Path.GetInvalidPathChars
			temp.Replace(c, "_")
		Next
		temp.Replace(IO.Path.DirectorySeparatorChar, "_")
		temp.Replace(IO.Path.AltDirectorySeparatorChar, "_")
		temp.Replace(IO.Path.VolumeSeparatorChar, "_")
		Select Case System.Environment.OSVersion.Platform
			Case PlatformID.Win32NT, PlatformID.Win32S, PlatformID.Win32Windows, PlatformID.WinCE
				temp.Replace("*"c, "_")
				temp.Replace("?"c, "_")
		End Select

		Return temp.ToString
	End Function

End Module
