'Copyright (c) 2008, Jonathan Allen

Imports System
Imports System.Security.Principal

''' <summary>
''' 
''' </summary>
''' <remarks>These are hand-tested because they are dependent on the OS</remarks>
Public Module SecurityPrincipalExtension


	<Extension()> Function Translate(Of T As IdentityReference)(ByVal value As IdentityReference) As T
		If value Is Nothing Then Throw New ArgumentNullException("value")

		Return DirectCast(value.Translate(GetType(T)), T)
	End Function

	<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")>
 <Extension()> Function ToSid(ByVal account As NTAccount) As SecurityIdentifier
		If account Is Nothing Then Throw New ArgumentNullException("account")

		Return account.Translate(Of SecurityIdentifier)()
	End Function

	<Extension()> Function ToSddl(ByVal account As NTAccount) As String
		If account Is Nothing Then Throw New ArgumentNullException("account")

		Return account.ToSid.Value
	End Function

	Function AccountToSid(ByVal domainName As String, ByVal accountName As String) As SecurityIdentifier
		Return New NTAccount(domainName, accountName).ToSid
	End Function

	Function AccountToSidString(ByVal domainName As String, ByVal accountName As String) As String
		Return New NTAccount(domainName, accountName).ToSddl
	End Function

	Function AccountToSid(ByVal name As String) As SecurityIdentifier
		Return New NTAccount(name).ToSid
	End Function

	Function AccountToSddl(ByVal name As String) As String
		Return New NTAccount(name).ToSddl
	End Function

	<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")>
	 <Extension()> Function ToAccount(ByVal sid As SecurityIdentifier) As NTAccount
		If sid Is Nothing Then Throw New ArgumentNullException("sid")

		Return sid.Translate(Of NTAccount)()
	End Function

	Function SddlToAccount(ByVal sid As String) As NTAccount
		Return (New SecurityIdentifier(sid)).ToAccount
	End Function


End Module
