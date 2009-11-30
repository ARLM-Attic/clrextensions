'Copyright (c) 2008, Jonathan Allen
Imports System.IO
#If IncludeUntested Then

Public Module IOExtension


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="driveLetter"></param>
    ''' <param name="uncName"></param>
    ''' <remarks>This was hand tested. We cannot automate because it messes with the OS</remarks>
    Public Sub MapDrive(ByVal driveLetter As Char, ByVal uncName As String)
        Dim driveLetterFixed = Char.ToLower(driveLetter)
        If driveLetterFixed < "a"c OrElse driveLetterFixed > "z"c Then Throw New ArgumentOutOfRangeException("driveLetter")
        If uncName Is Nothing Then Throw New ArgumentNullException("uncName")
        If uncName = "" Then Throw New ArgumentException("uncName cannot be empty", "uncName")
        Contract.EndContractBlock()

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
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")> <Untested()>
    Public Function PrintFile(ByVal fileName As String) As Process
        If fileName Is Nothing Then Throw New ArgumentNullException("fileName")
        If fileName = "" Then Throw New ArgumentException("fileName cannot be empty")
        Contract.EndContractBlock()

        If Not System.IO.File.Exists(filename) Then Throw New IOException("File " & filename & " does not exist.")

        Dim printJob As Process = Nothing
        Try
            printJob = New Process()
            printJob.StartInfo.FileName = filename
            printJob.StartInfo.UseShellExecute = True
            printJob.StartInfo.Verb = "print"
            printJob.Start()
        Catch 'dispose the Process if we had any problems constructing it
            If printJob IsNot Nothing Then printJob.Dispose()
            Throw
        End Try

        Return printJob
    End Function

    <Untested()>
    Public Function ToFileName(ByVal text As String) As String
        Dim temp As New System.Text.StringBuilder(text)
        For Each c In Path.GetInvalidPathChars
            temp.Replace(c, "_")
        Next
        temp.Replace(Path.DirectorySeparatorChar, "_")
        temp.Replace(Path.AltDirectorySeparatorChar, "_")
        temp.Replace(Path.VolumeSeparatorChar, "_")
        Select Case System.Environment.OSVersion.Platform
            Case PlatformID.Win32NT, PlatformID.Win32S, PlatformID.Win32Windows, PlatformID.WinCE
                temp.Replace("*"c, "_")
                temp.Replace("?"c, "_")
        End Select

        Return temp.ToString
    End Function

End Module
#End If