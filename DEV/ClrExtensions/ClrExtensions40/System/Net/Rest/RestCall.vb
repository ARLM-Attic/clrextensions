'Copyright (c) 2008, Jonathan Allen
Imports System.Collections.Specialized
Imports System.Text

#If Subset <> "Client" Then

Namespace Net.Rest


#If IncludeUntested Then
    ''' <summary>
    ''' This is a strongly typed representation of a Verb/URL used in REST-style calls.
    ''' </summary>
    ''' <remarks>This was partially created in resonse to the total lameness of the System.Uri class</remarks>
    Public Class RestCall
        Private ReadOnly m_Verb As RestVerb
        Private ReadOnly m_Scheme As RestScheme
        Private ReadOnly m_Root As String
        Private ReadOnly m_Path As String
        Private ReadOnly m_Query As New QueryParameterCollection

        <Untested()>
        Public ReadOnly Property Path() As String
            Get
                Return m_Path
            End Get
        End Property

        <Untested()>
        Public ReadOnly Property Root() As String
            Get
                Return m_Root
            End Get
        End Property

        <Untested()>
        Public ReadOnly Property Scheme() As RestScheme
            Get
                Return m_Scheme
            End Get
        End Property

        <Untested()>
        Public ReadOnly Property HttpMethod() As String
            Get
                Return Verb.ToMethodString
            End Get
        End Property

        <Untested()>
        Public ReadOnly Property Verb() As RestVerb
            Get
                Return m_Verb
            End Get
        End Property

        <Untested()>
        Public Sub New(ByVal verb As RestVerb, ByVal scheme As RestScheme, ByVal root As String, ByVal path As String, ByVal query As IList(Of QueryParameter))
            m_Verb = verb
            m_Scheme = scheme
            m_Root = root
            m_Path = path
            m_Query.AddRange(query)
        End Sub

        <Untested()>
        Public Sub New(ByVal verb As RestVerb, ByVal url As String)
            If url Is Nothing Then Throw New ArgumentNullException("url")
            Contract.EndContractBlock()

            Dim remainder As String = url

            m_Verb = verb

            'determine the scheme. We call the enumeration directly to make adding new scheme easier
            For Each item As RestScheme In GetRestSchemeValues()
                Dim temp As String = item.ToSchemeString
                If remainder.StartsWith(temp) Then
                    remainder = remainder.Substring(temp.Length)
                    m_Scheme = item
                    Exit For
                End If
            Next

            'remove the root
            Dim pathIndex = remainder.IndexOf("/")
            If pathIndex = -1 Then
                m_Root = remainder
                Return
            End If

            m_Root = remainder.Substring(0, pathIndex)
            remainder = remainder.Substring(pathIndex)

            'remove the query strings
            Dim queryIndex = remainder.IndexOf("?")
            If queryIndex = -1 Then
                m_Path = remainder
                Return
            End If

            m_Path = remainder.Substring(0, queryIndex)
            If queryIndex <> remainder.Length - 1 Then
                'm_Query.AddRange(Web.HttpUtility.ParseQueryString(remainder.Substring(queryIndex)))
                'We cannot use Web.HttpUtility.ParseQueryString, it screws up value of some parameters
                remainder = remainder.Substring(queryIndex + 1)

                m_Query.AddByParsing(remainder)

            End If

        End Sub

        <Untested()>
        Public Function ToUrlString() As String
            Dim result As New StringBuilder
            result.Append(Scheme.ToSchemeString)
            result.Append(Root)
            result.Append(Path)
            If m_Query.Count > 0 Then
                For i = 0 To m_Query.Count - 1
                    result.Append(If(i = 0, "?", "&"))
                    result.Append(m_Query(i).ToString)
                Next
            End If
            Return result.ToString
        End Function


        <Untested()>
        Public Function AddParameter(ByVal parameter As QueryParameter) As RestCall
            If parameter Is Nothing Then Return Me

            Dim result As New RestCall(Verb, Scheme, Root, Path, m_Query)
            result.m_Query.Add(parameter)
            Return result
        End Function
#If ClrVersion > 0 Then

        <Untested()>
        Public Function AddParameter(ByVal name As String, ByVal value As String, ByVal encoding As UrlEncodingMethod) As RestCall
            Dim result As New RestCall(Verb, Scheme, Root, Path, m_Query)
            result.m_Query.Add(New QueryParameter(name, value.UrlEncode(encoding)))
            Return result
        End Function
#End If

        'TODO: RemoveParameter(name)
        'TODO: ChangePath(path)
        'TODO: RemoveParameters
        'TODO: ChangeScheme(scheme)
        'TODO: ChangeVerb(verb)

        <Untested()>
        Public Function ToUri() As Uri
            Return New Uri(ToUrlString)
        End Function

        <Untested()>
        Public Overrides Function ToString() As String
            Return HttpMethod & " " & ToUrlString()
        End Function

        <Untested()>
        Public Function CreateHttpWebRequest() As System.Net.HttpWebRequest
            Dim result = DirectCast(System.Net.WebRequest.Create(ToUri), System.Net.HttpWebRequest)
            result.Method = HttpMethod
            Return result
        End Function

    End Class
#End If
End Namespace
#End If
