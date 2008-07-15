Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Security.Principal

Namespace Win32.Http
	Public Class UrlAce
		Private m_Account As NTAccount
		Private m_Sid As SecurityIdentifier
		Private m_Permission As UrlPermission

		Public Sub New(ByVal account As NTAccount, ByVal permission As UrlPermission)
			m_Account = account
			m_Sid = m_Account.ToSid
			m_Permission = permission
		End Sub

		Public Sub New(ByVal name As String, ByVal permission As UrlPermission)
			m_Account = New NTAccount(name)
			m_Sid = m_Account.ToSid
			m_Permission = permission
		End Sub

		Public Sub New(ByVal domainName As String, ByVal accountName As String, ByVal permission As UrlPermission)
			m_Account = New NTAccount(domainName, accountName)
			m_Sid = m_Account.ToSid
			m_Permission = permission
		End Sub

		Public Sub New(ByVal sid As SecurityIdentifier, ByVal permission As UrlPermission)
			m_Sid = sid
			m_Account = m_Sid.ToAccount
			m_Permission = permission
		End Sub

		Public Function ToSddl() As String
			Dim result As New Text.StringBuilder

			result.Append("(A;;")
			If CBool(m_Permission And UrlPermission.All) Then result.Append("GA")
			If CBool(m_Permission And UrlPermission.Registration) Then result.Append("GX")
			If CBool(m_Permission And UrlPermission.Delegation) Then result.Append("GW")
			result.Append(";;;")
			result.Append(m_Sid.Value)
			result.Append(")")

			Return result.ToString
        End Function
        Public ReadOnly Property Account() As NTAccount
            Get
                Return m_Account
            End Get
        End Property
        Public ReadOnly Property Permission() As UrlPermission
            Get
                Return m_Permission
            End Get
        End Property
    End Class
End Namespace
