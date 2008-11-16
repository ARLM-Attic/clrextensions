'Copyright (c) 2008, Jonathan Allen
Imports System.Collections.Specialized

Namespace Net.Rest
	Public Class QueryParameter
		Private m_Name As String
		Private m_Value As String

		''' <summary>
		''' Creates a new QueryParameter without a value
		''' </summary>
		''' <param name="name"></param>
		''' <remarks></remarks>
		Public Sub New(ByVal name As String)
			MyClass.New(name, Nothing)
		End Sub

		''' <summary>
		''' 
		''' </summary>
		''' <param name="name"></param>
		''' <param name="value"></param>
		''' <remarks>A null value means something different than an empty value</remarks>
		Public Sub New(ByVal name As String, ByVal value As String)
			m_Name = name
			m_Value = value
		End Sub


		Public Sub New(ByVal name As String, ByVal value As String, ByVal encoding As UrlEncodingMethod)
			m_Name = name
			m_Value = UrlEncode(value, encoding)
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

		''' <summary>
		''' 
		''' </summary>
		''' <returns>Returns "name=value" if value isnot nothing, otherwise returns "name"</returns>
		''' <remarks></remarks>
		Public Overrides Function ToString() As String
			If Value Is Nothing Then
				Return Name
			Else
				Return Name & "=" & Value
			End If
		End Function

	End Class
End Namespace
