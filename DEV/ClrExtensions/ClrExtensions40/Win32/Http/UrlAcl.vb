'Copyright (c) 2008, Jonathan Allen
#If IncludeUntested Then

Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Security.Principal

Namespace Win32.Http
	Public Class UrlAcl
		Inherits ObjectModel.Collection(Of UrlAce)

        <Untested()>
            Public Sub New(ByVal ParamArray aceList() As UrlAce)
            MyBase.New(aceList)
        End Sub

        <Untested()>
            Public Sub New(ByVal aceList As IList(Of UrlAce))
            MyBase.New(aceList)
        End Sub

        <Untested()>
            Public Sub New(ByVal sddl As String)
            If Not sddl.Contains("(") Then Return

            Dim step1 = sddl.Substring(2) 'remove the D:
            Dim step2 = step1.Split(New Char() {"("c, ")"c}, StringSplitOptions.RemoveEmptyEntries)
            For Each section In step2
                Dim step3 = section.Split(";"c)

                Dim permissionChar = step3(0)
                Dim rights = step3(2)
                Dim sid = step3(5)

                Dim urlPermission As UrlPermission
                If rights.Contains("GA") Then urlPermission = urlPermission Or Http.UrlPermission.All
                If rights.Contains("GX") Then urlPermission = urlPermission Or Http.UrlPermission.Registration
                If rights.Contains("GW") Then urlPermission = urlPermission Or Http.UrlPermission.Delegation

                Dim ace As New UrlAce(New SecurityIdentifier(sid), urlPermission)
                Me.Add(ace)
            Next
        End Sub

        <Untested()>
            Public Function ToSddl() As String
            Dim result As New Text.StringBuilder
            result.Append("D:")
            For Each ace In Me
                result.Append(ace.toSddl)
            Next

            Return result.ToString

        End Function
	End Class
End Namespace
#End If