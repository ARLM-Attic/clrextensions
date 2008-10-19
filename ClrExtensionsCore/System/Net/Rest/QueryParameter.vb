'Copyright (c) 2008, Jonathan Allen
Imports System.Collections.Specialized

Namespace Net.Rest
	Public Class QueryParameter
		Private m_Name As String
		Private m_Value As String

		Public Sub New(ByVal name As String, ByVal value As String)
			m_Name = name
			m_Value = value
		End Sub

		Public ReadOnly Property Name() As String
			Get
				Return m_Name
			End Get
		End Property

		Public ReadOnly Property Value() As String
			Get
				Return m_Value
			End Get
		End Property

		Public Overrides Function ToString() As String
			Return Name & "=" & Value
		End Function

	End Class
End Namespace
