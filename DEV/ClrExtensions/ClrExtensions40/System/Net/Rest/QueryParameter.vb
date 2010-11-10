'Copyright (c) 2008, Jonathan Allen
Imports System.Collections.Specialized
#If 1 = 1 Then
#If Subset <> "Client" Then

Namespace Net.Rest
    Public Class QueryParameter
        Private m_Name As String
        Private m_Value As String

        ''' <summary>
        ''' Creates a new QueryParameter without a value
        ''' </summary>
        ''' <param name="name"></param>
        ''' <remarks></remarks>
        
        Sub New(ByVal name As String)
            MyClass.New(name, Nothing)
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="value"></param>
        ''' <remarks>A null value means something different than an empty value</remarks>
        
        Sub New(ByVal name As String, ByVal value As String)
            m_Name = name
            m_Value = value
        End Sub


#If ClrVersion > 0 Then
        
        Sub New(ByVal name As String, ByVal value As String, ByVal encoding As UrlEncodingMethod)
            m_Name = name
            m_Value = UrlEncode(value, encoding)
        End Sub
#End If

        
        ReadOnly Property Name() As String
            Get
                Return m_Name
            End Get
        End Property

        
        ReadOnly Property Value() As String
            Get
                Return m_Value
            End Get
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns>Returns "name=value" if value isnot nothing, otherwise returns "name"</returns>
        ''' <remarks></remarks>
        
        Overrides Function ToString() As String
            If Value Is Nothing Then
                Return Name
            Else
                Return Name & "=" & Value
            End If
        End Function

    End Class
End Namespace
#End If
#End If