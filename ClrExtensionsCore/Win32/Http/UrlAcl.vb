Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Security.Principal

Namespace Win32.Http
	Public Class UrlAcl
		Inherits ObjectModel.Collection(Of UrlAce)

		Public Sub New(ByVal ParamArray aceList() As UrlAce)
			MyBase.New(aceList)
		End Sub

		Public Sub New(ByVal aceList As IList(Of UrlAce))
			MyBase.New(aceList)
		End Sub

		Public Sub New(ByVal sddl As String)
			'TODO translate this into ACE's
			Console.WriteLine("UrlAcl.New(" & sddl & ")")
		End Sub

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
