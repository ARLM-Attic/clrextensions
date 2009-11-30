Imports System.Text
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports ClrExtensions.Net.Rest

'Copyright (c) 2008, Jonathan Allen
#If Subset <> "Client" Then

Namespace Security
    Namespace OAuth
#If IncludeUntested Then

        ''' <summary>
        ''' Utilities for generating and signing web requests using the OAuth specification
        ''' </summary>
        ''' <remarks>See http://oauth.net/ for information on this standard.
        ''' This class is currently being hand-tested. Some testing is also done via the WrapNetflix project.</remarks>
        Public Module OAuthUtility

            ''' <summary>
            ''' Custom URL encoding for the OAuth spec
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <Untested()>
            Public Function UrlEncode(ByVal value As String) As String
                If value Is Nothing Then Throw New ArgumentNullException("value")
                Contract.EndContractBlock()

                Const unreservedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~"

                Dim result As New StringBuilder
                Dim symbol As Char
                For Each symbol In value
                    If (unreservedChars.IndexOf(symbol) <> -1) Then
                        result.Append(symbol)
                    Else
                        result.Append(("%"c & String.Format("{0:X2}", Asc(symbol))))
                    End If
                Next
                Return result.ToString
            End Function

            Private ReadOnly s_Random As New ThreadsafeRandom

            <Untested()>
            <Extension()> Public Function SignRestCall(ByVal url As RestCall, ByVal consumerKey As String, ByVal consumerSecret As String) As RestCall
                Return SignRestCall(url, consumerKey, consumerSecret, Nothing, Nothing)
            End Function

            <Untested()>
            <Extension()> Public Function SignRestCall(ByVal url As RestCall, ByVal consumerKey As String, ByVal consumerSecret As String, ByVal token As String, ByVal tokenSecret As String) As RestCall
                If url Is Nothing Then Throw New ArgumentNullException("url")
                If consumerKey Is Nothing Then Throw New ArgumentNullException("consumerKey")
                If consumerSecret Is Nothing Then Throw New ArgumentNullException("consumerSecret")
                Contract.EndContractBlock()


                Dim httpMethod As String = url.Verb.ToMethodString
                'Dim signatureType As String = "HMAC-SHA1"
                Return New RestCall(url.Verb, GenerateRequest(url.ToUri, consumerKey, consumerSecret, token, tokenSecret, httpMethod))
            End Function

            <Untested()>
            Public Function GenerateRequest(ByVal uri As Uri, ByVal consumerKey As String, ByVal consumerSecret As String, ByVal token As String, ByVal tokenSecret As String, ByVal httpMethod As String) As String

                'step 1
                Dim timeStamp = OAuth.GenerateTimestamp
                Dim nonce = OAuth.GenerateNonce

                'step 2
                'Dim normalizedUrl_1 As String = Nothing
                'Dim normalizedRequestParameters_1 As String = Nothing
                'Dim signatureBase = OAuth.GenerateSignatureBase(uri, consumerKey, token, tokenSecret, httpMethod, timeStamp, nonce, signatureType, normalizedUrl_1, normalizedRequestParameters_1)

                'step 3
                Dim normalizedUrl_2 As String = Nothing
                Dim normalizedRequestParameters_2 As String = Nothing
                Dim signature = GenerateSignature(uri, consumerKey, consumerSecret, If(token <> "", token, Nothing), If(tokenSecret <> "", tokenSecret, Nothing), httpMethod, timeStamp, nonce, normalizedUrl_2, normalizedRequestParameters_2)

                'step 4
                Dim signatureEncoded = UrlEncode(signature)

                'step 5
                Dim fullRequest = normalizedUrl_2 & "?" & normalizedRequestParameters_2 & "&oauth_signature=" & signatureEncoded

                Return fullRequest
            End Function

            <Untested()>
            Private Function ComputeHash(ByVal hashAlgorithm As HashAlgorithm, ByVal data As String) As String
                If (hashAlgorithm Is Nothing) Then
                    Throw New ArgumentNullException("hashAlgorithm")
                End If
                If String.IsNullOrEmpty(data) Then
                    Throw New ArgumentNullException("data")
                End If
                Dim dataBuffer As Byte() = Encoding.ASCII.GetBytes(data)
                Return Convert.ToBase64String(hashAlgorithm.ComputeHash(dataBuffer))
            End Function

            <Untested()>
            Public Function GenerateNonce() As String
                Return s_Random.Next(&H1E208, &H98967F).ToString
            End Function

            <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId:="8#")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId:="9#")> <Untested()>
            Public Function GenerateSignature(ByVal url As Uri, ByVal consumerKey As String, ByVal consumerSecret As String, ByVal token As String, ByVal tokenSecret As String, ByVal httpMethod As String, ByVal timestamp As String, ByVal nonce As String, <Out()> ByRef normalizedUrl As String, <Out()> ByRef normalizedRequestParameters As String) As String
                Return GenerateSignature(url, consumerKey, consumerSecret, token, tokenSecret, httpMethod, timestamp, nonce, SignatureType.HMACSHA1, normalizedUrl, normalizedRequestParameters)
            End Function

            <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId:="9#")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId:="10#")> <Untested()>
            Public Function GenerateSignature(ByVal url As Uri, ByVal consumerKey As String, ByVal consumerSecret As String, ByVal token As String, ByVal tokenSecret As String, ByVal httpMethod As String, ByVal timestamp As String, ByVal nonce As String, ByVal signatureType As SignatureType, <Out()> ByRef normalizedUrl As String, <Out()> ByRef normalizedRequestParameters As String) As String
                normalizedUrl = Nothing
                normalizedRequestParameters = Nothing
                Select Case signatureType
                    Case signatureType.HMACSHA1
                        Dim signatureBase As String = GenerateSignatureBase(url, consumerKey, token, tokenSecret, httpMethod, timestamp, nonce, "HMAC-SHA1", normalizedUrl, normalizedRequestParameters)
                        Using hmacsha1 As New HMACSHA1
                            hmacsha1.Key = Encoding.ASCII.GetBytes(
                                String.Format("{0}&{1}", UrlEncode(consumerSecret), If(String.IsNullOrEmpty(tokenSecret), "", UrlEncode(tokenSecret))))

                            Return GenerateSignatureUsingHash(signatureBase, hmacsha1)
                        End Using

                    Case signatureType.PLAINTEXT
                        Return Web.HttpUtility.UrlEncode(String.Format("{0}&{1}", consumerSecret, tokenSecret))

                    Case signatureType.RSASHA1
                        Throw New NotImplementedException
                End Select
                Throw New ArgumentException("Unknown signature type", "signatureType")
            End Function

            <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId:="0")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId:="4")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId:="9#")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId:="8#")> <Untested()>
            Public Function GenerateSignatureBase(ByVal url As Uri, ByVal consumerKey As String, ByVal token As String, ByVal tokenSecret As String, ByVal httpMethod As String, ByVal timestamp As String, ByVal nonce As String, ByVal signatureType As String, <Out()> ByRef normalizedUrl As String, <Out()> ByRef normalizedRequestParameters As String) As String
                If url Is Nothing Then Throw New ArgumentNullException("url")
                If consumerKey = "" Then Throw New ArgumentNullException("consumerKey")
                If httpMethod = "" Then Throw New ArgumentNullException("httpMethod")
                If signatureType = "" Then Throw New ArgumentNullException("signatureType")
                Contract.EndContractBlock()

                If token Is Nothing Then token = ""
                If tokenSecret Is Nothing Then tokenSecret = ""

                normalizedUrl = Nothing
                normalizedRequestParameters = Nothing
                Dim parameters As List(Of QueryParameter) = GetQueryParameters(url.Query)
                parameters.Add(New QueryParameter("oauth_version", "1.0"))
                parameters.Add(New QueryParameter("oauth_nonce", nonce))
                parameters.Add(New QueryParameter("oauth_timestamp", timeStamp))
                parameters.Add(New QueryParameter("oauth_signature_method", signatureType))
                parameters.Add(New QueryParameter("oauth_consumer_key", consumerKey))
                If Not String.IsNullOrEmpty(token) Then
                    parameters.Add(New QueryParameter("oauth_token", token))
                End If
                parameters.Sort(New QueryParameterComparer)
                normalizedUrl = String.Format("{0}://{1}", url.Scheme, url.Host)
                If (((url.Scheme <> "http") OrElse (url.Port <> 80)) AndAlso ((url.Scheme <> "https") OrElse (url.Port <> &H1BB))) Then
                    normalizedUrl = (normalizedUrl & ":" & url.Port)
                End If
                normalizedUrl = (normalizedUrl & url.AbsolutePath)
                normalizedRequestParameters = NormalizeRequestParameters(parameters)
                Dim signatureBase As New StringBuilder
                signatureBase.AppendFormat("{0}&", httpMethod.ToUpper)
                signatureBase.AppendFormat("{0}&", UrlEncode(normalizedUrl))
                signatureBase.AppendFormat("{0}", UrlEncode(normalizedRequestParameters))
                Return signatureBase.ToString
            End Function

            <Untested()>
            Public Function GenerateSignatureUsingHash(ByVal signatureBase As String, ByVal hash As HashAlgorithm) As String
                Return ComputeHash(hash, signatureBase)
            End Function

            <Untested()>
            Public Function GenerateTimestamp() As String
                Dim ts = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0, 0))
                Return Convert.ToInt64(ts.TotalSeconds).ToString
            End Function

            <Untested()>
            Private Function GetQueryParameters(ByVal parameters As String) As List(Of QueryParameter)
                If parameters Is Nothing Then Throw New ArgumentNullException("parameters")
                Contract.EndContractBlock()

                If parameters.StartsWith("?") Then
                    parameters = parameters.Remove(0, 1)
                End If
                Dim result As New List(Of QueryParameter)
                If Not String.IsNullOrEmpty(parameters) Then
                    Dim p As String() = parameters.Split(New Char() {"&"c})
                    Dim s As String
                    For Each s In p
                        If (Not String.IsNullOrEmpty(s) AndAlso Not s.StartsWith("oauth_")) Then
                            If (s.IndexOf("="c) > -1) Then
                                Dim temp As String() = s.Split(New Char() {"="c})
                                result.Add(New QueryParameter(temp(0), temp(1)))
                            Else
                                result.Add(New QueryParameter(s, String.Empty))
                            End If
                        End If
                    Next
                End If
                Return result
            End Function

            <Untested()>
            Private Function NormalizeRequestParameters(ByVal parameters As IList(Of QueryParameter)) As String
                If parameters Is Nothing Then Throw New ArgumentNullException("parameters")
                Contract.EndContractBlock()

                Dim sb As New StringBuilder
                Dim p As QueryParameter = Nothing
                Dim i As Integer
                For i = 0 To parameters.Count - 1
                    p = parameters.Item(i)
                    sb.AppendFormat("{0}={1}", p.Name, p.Value)
                    If (i < (parameters.Count - 1)) Then
                        sb.Append("&")
                    End If
                Next i
                Return sb.ToString
            End Function


            ' Fields
            <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId:="HMACSHA")> Public Const HMACSHA1SignatureType As String = "HMAC-SHA1"
            Public Const OAuthCallbackKey As String = "oauth_callback"
            Public Const OAuthConsumerKeyKey As String = "oauth_consumer_key"
            Public Const OAuthNonceKey As String = "oauth_nonce"
            Public Const OAuthParameterPrefix As String = "oauth_"
            Public Const OAuthSignatureKey As String = "oauth_signature"
            Public Const OAuthSignatureMethodKey As String = "oauth_signature_method"
            Public Const OAuthTimestampKey As String = "oauth_timestamp"
            Public Const OAuthTokenKey As String = "oauth_token"
            Public Const OAuthTokenSecretKey As String = "oauth_token_secret"
            Public Const OAuthVersion As String = "1.0"
            Public Const OAuthVersionKey As String = "oauth_version"
            Public Const PlaintextSignatureType As String = "PLAINTEXT"
            <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId:="RSASHA")> Public Const RSASHA1SignatureType As String = "RSA-SHA1"
            'Public Const unreservedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~"



            Private Class QueryParameterComparer
                Implements IComparer(Of QueryParameter)
                ' Methods
                <Untested()>
                Public Function [Compare](ByVal x As QueryParameter, ByVal y As QueryParameter) As Integer Implements IComparer(Of QueryParameter).Compare
                    If x Is Nothing Then Throw New ArgumentNullException("x")
                    If y Is Nothing Then Throw New ArgumentNullException("y")
                    Contract.EndContractBlock()

                    If (x.Name = y.Name) Then
                        Return String.Compare(x.Value, y.Value)
                    End If
                    Return String.Compare(x.Name, y.Name)
                End Function

            End Class


            Private NotInheritable Class ThreadsafeRandom
                Inherits Random

                'TODO - This should be moved once a test harness has been created

                Private ReadOnly m_SyncRoot As New Object
                <Untested()>
                Public Overrides Function [Next]() As Integer
                    SyncLock m_SyncRoot
                        Return MyBase.[Next]()
                    End SyncLock
                End Function
                <Untested()>
                Public Overrides Function [Next](ByVal minValue As Integer, ByVal maxValue As Integer) As Integer
                    SyncLock m_SyncRoot
                        Return MyBase.[Next](minValue, maxValue)
                    End SyncLock
                End Function
                <Untested()>
                Public Overrides Function [Next](ByVal maxValue As Integer) As Integer
                    SyncLock m_SyncRoot
                        Return MyBase.[Next](maxValue)
                    End SyncLock
                End Function
                <Untested()>
                Public Overrides Sub NextBytes(ByVal buffer() As Byte)
                    SyncLock m_SyncRoot
                        MyBase.NextBytes(buffer)
                    End SyncLock
                End Sub
                <Untested()>
                Public Overrides Function NextDouble() As Double
                    SyncLock m_SyncRoot
                        Return MyBase.NextDouble()
                    End SyncLock
                End Function
            End Class

        End Module


        Public Enum SignatureType
            ' Fields
            <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId:="HMACSHA")> HMACSHA1 = 0
            <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId:="PLAINTEXT")> PLAINTEXT = 1
            <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId:="RSASHA")> RSASHA1 = 2
        End Enum
#End If
    End Namespace
End Namespace

#End If