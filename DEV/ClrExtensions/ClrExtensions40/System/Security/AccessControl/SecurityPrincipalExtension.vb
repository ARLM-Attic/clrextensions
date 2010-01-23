'Copyright (c) 2008, Jonathan Allen

Imports System
Imports System.Security.Principal
#If IncludeUntested Then


''' <summary>
''' 
''' </summary>
''' <remarks>These are hand-tested because they are dependent on the OS</remarks>
Public Module SecurityPrincipalExtension


    <Untested()>
 <Extension()> Function Translate(Of T As IdentityReference)(ByVal value As IdentityReference) As T
        If value Is Nothing Then Throw New ArgumentNullException("value")

        Return DirectCast(value.Translate(GetType(T)), T)
    End Function

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")> <Untested()>
 <Extension()>  Function ToSid(ByVal account As NTAccount) As SecurityIdentifier
        If account Is Nothing Then Throw New ArgumentNullException("account")

        Return account.Translate(Of SecurityIdentifier)()
    End Function

    <Untested()>
 <Extension()>  Function ToSddl(ByVal account As NTAccount) As String
        If account Is Nothing Then Throw New ArgumentNullException("account")

        Return account.ToSid.Value
    End Function

    <Untested()>
     Function AccountToSid(ByVal domainName As String, ByVal accountName As String) As SecurityIdentifier
        Return New NTAccount(domainName, accountName).ToSid
    End Function

    <Untested()>
     Function AccountToSidString(ByVal domainName As String, ByVal accountName As String) As String
        Return New NTAccount(domainName, accountName).ToSddl
    End Function

    <Untested()>
     Function AccountToSid(ByVal name As String) As SecurityIdentifier
        Return New NTAccount(name).ToSid
    End Function

    <Untested()>
     Function AccountToSddl(ByVal name As String) As String
        Return New NTAccount(name).ToSddl
    End Function

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")> <Untested()>
 <Extension()>  Function ToAccount(ByVal sid As SecurityIdentifier) As NTAccount
        If sid Is Nothing Then Throw New ArgumentNullException("sid")

        Return sid.Translate(Of NTAccount)()
    End Function

    <Untested()>
     Function SddlToAccount(ByVal sid As String) As NTAccount
        Return (New SecurityIdentifier(sid)).ToAccount
    End Function


End Module
#End If