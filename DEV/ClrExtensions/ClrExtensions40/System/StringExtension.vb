﻿Imports System.Security.Cryptography

'Copyright (c) 2008, Jonathan Allen

#If ClrVersion > 0 Then
Imports System.Net.Mail
#End If
Imports System.Text
Imports System.Text.RegularExpressions

#If 1 = 1 Then

Public Module StringExtension

#If ClrVersion >= 35 Then
    ''' <summary>
    ''' Joins all the strings in the supplied enumeration.
    ''' Empty and null enumerations will return an empty string
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="separator"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function Join(ByVal source As IEnumerable(Of String), ByVal separator As String) As String
        If source Is Nothing Then Return ""
        Return String.Join(separator, source.ToArray)
    End Function
#End If

    ''' <summary>
    ''' Repeats the given string N times.
    ''' To facilitate some coding patterns, N may be 0; this will result in an empty string.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="count"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function Repeat(ByVal value As String, ByVal count As Integer) As String
        If value Is Nothing Then Throw New ArgumentNullException("value")
        If value = "" Then Throw New ArgumentException("value cannot be empty", "value")
        If count < 0 Then Throw New ArgumentOutOfRangeException("count")
        If count = 0 Then Return ""
        Dim result As New StringBuilder(value.Length * count)
        For i = 1 To count
            result.Append(value)
        Next
        Return result.ToString
    End Function

#If ClrVersion >= 35 Then
    ''' <summary>
    ''' Joins all the strings in the supplied enumeration.
    ''' Empty and null enumerations will return an empty string
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="separator"></param>
    ''' <param name="options">Optionally skip null and empty entries in the enumeration</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function Join(ByVal source As IEnumerable(Of String), ByVal separator As String, ByVal options As StringSplitOptions) As String
        If source Is Nothing Then Return ""
        Select Case options
            Case StringSplitOptions.None
                Return String.Join(separator, source.ToArray)
            Case StringSplitOptions.RemoveEmptyEntries
                Return String.Join(separator, source.Where(Function(s) s <> "").ToArray)
            Case Else
                Throw New ArgumentOutOfRangeException("options")
        End Select
    End Function
#End If


    ''' <summary>
    ''' Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="separator">A string that delimits the substrings in this string</param>
    ''' <returns>An array whose elements contain the substrings in this string that are delimited by the separator.</returns>
    ''' <remarks></remarks>

    <Extension()> Function Split(ByVal source As String, ByVal separator As String) As String()
        If source Is Nothing Then Return New String() {}
        Return source.Split(New String() {separator}, StringSplitOptions.None)
    End Function

    ''' <summary>
    ''' Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array. A parameter specifies whether to return empty array elements.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="separator">A string that delimits the substrings in this string</param>
    ''' <param name="options">Specify System.StringSplitOptions.RemoveEmptyEntries to omit empty array elements from the array returned, or System.StringSplitOptions.None to include empty array elements in the array returned.</param>
    ''' <returns>An array whose elements contain the substrings in this string that are delimited by the separator.</returns>
    ''' <remarks></remarks>
    ''' <exception cref="ArgumentException">options is not one of the System.StringSplitOptions values.</exception>

    <Extension()> Function Split(ByVal source As String, ByVal separator As String, ByVal options As StringSplitOptions) As String()
        If source Is Nothing Then Return New String() {}
        Return source.Split(New String() {separator}, options)
    End Function


    ''' <summary>
    ''' Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="separator">A string that delimits the substrings in this string</param>
    ''' <param name="count">The maximum number of substrings to return.</param>
    ''' <returns>An array whose elements contain the substrings in this string that are delimited by the separator.</returns>
    ''' <remarks></remarks>
    ''' <exception cref="ArgumentException">options is not one of the System.StringSplitOptions values.</exception>

    <Extension()> Function Split(ByVal source As String, ByVal separator As String, ByVal count As Integer) As String()
        If separator = "" Then Throw New ArgumentException("separator cannot be empty", "separator")
        If count < 2 Then Throw New ArgumentOutOfRangeException("count")

        If source Is Nothing Then Return New String() {}
        Return Split(source, separator, count, StringSplitOptions.None)
    End Function


    ''' <summary>
    ''' Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array. A parameter specifies whether to return empty array elements.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="separator">A string that delimits the substrings in this string</param>
    ''' <param name="count">The maximum number of substrings to return.</param>
    ''' <param name="options">Specify System.StringSplitOptions.RemoveEmptyEntries to omit empty array elements from the array returned, or System.StringSplitOptions.None to include empty array elements in the array returned.</param>
    ''' <returns>An array whose elements contain the substrings in this string that are delimited by the separator.</returns>
    ''' <remarks></remarks>
    ''' <exception cref="ArgumentException">options is not one of the System.StringSplitOptions values.</exception>

    <Extension()> Function Split(ByVal source As String, ByVal separator As String, ByVal count As Integer, ByVal options As StringSplitOptions) As String()
        If separator = "" Then Throw New ArgumentException("seperator cannot be empty", "separator")
        If count < 2 Then Throw New ArgumentOutOfRangeException("count")


        If source Is Nothing Then Return New String() {}

        Dim temp = Microsoft.VisualBasic.Split(source, separator, count)
        Select Case options
            Case StringSplitOptions.None
                Return temp
            Case StringSplitOptions.RemoveEmptyEntries
                Dim result As New List(Of String)
                Dim remainder As String = source
                Do
                    Dim pivot = remainder.IndexOf(separator)
                    If pivot = -1 Then Exit Do

                    Dim fragment = remainder.Substring(0, pivot)
                    If fragment <> "" Then result.Add(fragment)
                    remainder = remainder.Substring(pivot + 1)
                Loop Until remainder = "" Or result.Count = count - 1

                If remainder <> "" Then result.Add(remainder)

                Return result.ToArray

                'The below won't work because it will return less than Count elements
                'Return temp.Where(Function(s) s <> "").ToArray
            Case Else
                Throw New ArgumentOutOfRangeException("options")
        End Select
    End Function


    ''' <summary>
    ''' Changes the first letter to a lower case letter, leaving the rest alone. Useful for turning "TestVar" into "testVar"
    ''' Nulls and empty strings are unchanged
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function FirstToLower(ByVal value As String) As String
        If value Is Nothing Then Return Nothing
        If value = "" Then Return ""
        If value.Length = 1 Then Return value.ToLower
        Return value.Substring(0, 1).ToLower & value.Substring(1)
    End Function

    ''' <summary>
    ''' Changes the first letter to a capital, leaving the rest alone. Useful for turning "testVar" into "TestVar"
    ''' Nulls and empty strings are unchanged
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function FirstToUpper(ByVal value As String) As String
        If value Is Nothing Then Return Nothing
        If value = "" Then Return ""
        If value.Length = 1 Then Return value.ToUpper
        Return value.Substring(0, 1).ToUpper & value.Substring(1)
    End Function

    ''' <summary>
    ''' Changes the first letter to a capital and the rest to lower case. Useful for turning "TEST" into "Test"
    ''' Nulls and empty strings are unchanged
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function Capitalize(ByVal value As String) As String
        If value Is Nothing Then Return Nothing
        If value = "" Then Return ""
        If value.Length = 1 Then Return value.ToUpper
        Return value.Substring(0, 1).ToUpper & value.Substring(1).ToLower
    End Function

    ''' <summary>
    ''' Converts nulls into empty strings
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function DefaultIfNull(ByVal value As String) As String
        Return If(value Is Nothing, "", value)
    End Function

    ''' <summary>
    ''' Converts nulls into a default value
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="default"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function DefaultIfNull(ByVal value As String, ByVal [default] As String) As String
        Return If(value Is Nothing, [default], value)
    End Function

    ''' <summary>
    ''' Converts nulls and empty strings into a default value
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="default"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function DefaultIfEmpty(ByVal value As String, ByVal [default] As String) As String
        Return If(value = "", [default], value)
    End Function

#If ClrVersion > 0 Then

    ''' <summary>
    ''' Checks to see if the string is an email address as per the System.Net.Mail definition. Note that a string may be the combination of a display name and an address. TO just get the address part, use ToMailAddress.Address
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId:="temp")>
    <Extension()> Function IsEmailAddress(ByVal value As String) As Boolean
        If value = "" Then Return False
        Try
            Dim temp = New MailAddress(value)
            Return True
        Catch ex As FormatException
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Returns the canonical email address from a full email address
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function ToMailAddress(ByVal value As String) As MailAddress
        If value Is Nothing Then Throw New ArgumentNullException("value")
        If value = "" Then Throw New ArgumentException("value cannot be empty", "value")

        Return New MailAddress(value)
    End Function

#End If


    ''' <summary>
    ''' Returns the first N characters, or the whole string
    ''' Nulls are unchanged
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function Left(ByVal value As String, ByVal length As Integer) As String
        If length <= 0 Then Throw New ArgumentOutOfRangeException("length")

        If value Is Nothing Then Return Nothing
        If value = "" Then Return ""
        Return If(value.Length > length, value.Substring(0, length), value)
    End Function

    ''' <summary>
    ''' Returns the last N characters, or the whole string
    ''' Nulls are unchanged
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <Extension()> Function Right(ByVal value As String, ByVal length As Integer) As String
        If length <= 0 Then Throw New ArgumentOutOfRangeException("length")

        If value Is Nothing Then Return Nothing
        If value = "" Then Return ""
        Return If(value.Length > length, value.Substring(value.Length - length), value)
    End Function

    ''' <summary>
    ''' Normalizes line breaks to the Windows standard
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of  methods", MessageId:="0")>
    <Extension()> Function NormalizeLineBreaks(ByVal value As String) As String
        If value = "" Then Return value
        Return value.Replace(vbCrLf, vbCr).Replace(vbLf, vbCr).Replace(vbCr, vbCrLf)
    End Function


    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of  methods", MessageId:="0")>
    <Extension()> Function NormalizeLineBreaks(ByVal value As String, ByVal mode As LineBreakMode) As String
        If value = "" Then Return value

        Select Case mode
            Case LineBreakMode.Windows
                Return NormalizeLineBreaks(value)
            Case LineBreakMode.Macintosh
                Return value.Replace(vbCrLf, vbCr).Replace(vbLf, vbCr)
            Case LineBreakMode.Unix
                Return value.Replace(vbCrLf, vbLf).Replace(vbCr, vbLf)
            Case Else
                Throw New ArgumentOutOfRangeException("mode")
        End Select
    End Function


    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of  methods", MessageId:="0")>
    <Extension()> Function HtmlLineBreaks(ByVal value As String) As String
        If value = "" Then Return value
        Return value.Replace(vbCrLf, "<br/>").Replace(vbLf, "<br/>").Replace(vbCr, "<br/>")
    End Function


    <Extension()> Function Reverse(ByVal value As String) As String
        If value Is Nothing Then Return Nothing

        Dim result = value.ToCharArray

        For i = 0 To result.Length \ 2 - 1
            Dim c = result(i)
            result(i) = result(result.Length - i - 1)
            result(result.Length - i - 1) = c
        Next

        Return New String(result)
    End Function

    '''' <summary>
    '''' 
    '''' </summary>
    '''' <param name="value"></param>
    '''' <returns></returns>
    '''' <remarks>I'm not sure the semantics of this is right. We may end up rolling our own version, hopefully one more useful.</remarks>
    '<Extension()>  Function ToTitleCase(ByVal value As String) As String
    '	If value Is Nothing Then Return Nothing
    '	If value = "" Then Return ""
    '	Return Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value)
    'End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks>Not really needed for VB, but C# programmers seem to like it</remarks>

    <Extension()> Function IsNullOrEmpty(ByVal value As String) As Boolean
        Return value = ""
        'Side note, String.IsNullOrEmpty has bug in .NET 2.0. It should be fixed in 2.0 SP 1.
    End Function



#If 1 = 1 Then


    ''' <summary>
    ''' This method does key-value replacements based on a simple pattern match
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="searchPattern">A string representing the fragment to match on. This should follow the String.Format syntax. For example, "${0}" will search for $Key1, $Key2, etc.</param>
    ''' <param name="dictionary"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Function PatternReplace(ByVal value As String, ByVal searchPattern As String, ByVal dictionary As Dictionary(Of String, String)) As String
        If searchPattern Is Nothing Then Throw New ArgumentNullException("searchPattern")
        If searchPattern = "" Then Throw New ArgumentException("searchPattern cannot be empty", "searchPattern")
        If Not searchPattern.Contains("{0}") Then Throw New FormatException("The search pattern doesn't contain the replacement command {0}")
        If dictionary Is Nothing Then Throw New ArgumentNullException("dictionary")

        If value = "" Then Return value

        Dim result = New StringBuilder(value)
        For Each item In dictionary
            result.Replace(String.Format(searchPattern, item.Key), item.Value)
        Next
        Return result.ToString
    End Function

    ''' <summary>
    ''' This method does key-value replacements based on a simple pattern match
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="searchPattern">A string representing the fragment to match on. This should follow the String.Format syntax. For example, "${0}" will search for $Key1, $Key2, etc.</param>
    ''' <param name="replacementPattern">A string representing the fragment to replace the match with. Use {0} to represent the original key and {1} to represent the new value. Standard String.Format options are allowed.</param>
    ''' <param name="dictionary"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Function PatternReplace(Of T)(ByVal value As String, ByVal searchPattern As String, ByVal replacementPattern As String, ByVal dictionary As Dictionary(Of String, T)) As String
        If searchPattern Is Nothing Then Throw New ArgumentNullException("searchPattern")
        If searchPattern = "" Then Throw New ArgumentException("searchPattern cannot be empty", "searchPattern")
        If Not searchPattern.Contains("{0}") Then Throw New FormatException("The search pattern doesn't contain the replacement command {0}")
        If dictionary Is Nothing Then Throw New ArgumentNullException("dictionary")
        If replacementPattern Is Nothing Then Throw New ArgumentNullException("replacementPattern")
        If replacementPattern = "" Then Throw New ArgumentException("replacementPattern cannot be empty", "replacementPattern")

        If value = "" Then Return value

        Dim result = New StringBuilder(value)
        For Each item In dictionary
            result.Replace(String.Format(searchPattern, item.Key), String.Format(replacementPattern, item.Key, item.Value))
        Next
        Return result.ToString
    End Function

#If ClrVersion >= 35 Then
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")> <Extension()>
    Function ToKeyValueCollection(ByVal source As String, ByVal rowSeparator As String, ByVal columnSeparator As String) As ObjectModel.Collection(Of KeyValuePair(Of String, String))
        If source Is Nothing Then Throw New ArgumentNullException("source")


        If rowSeparator = columnSeparator Then Return ToKeyValueCollection(source, rowSeparator)

        Dim result As New ObjectModel.Collection(Of KeyValuePair(Of String, String))
        Dim rows = source.Split(rowSeparator, StringSplitOptions.RemoveEmptyEntries)

        For Each pair In rows.Select(Function(s) s.Split(columnSeparator, 2))
            If pair.Length = 2 Then result.Add(New KeyValuePair(Of String, String)(pair(0), pair(1))) Else result.Add(New KeyValuePair(Of String, String)(pair(0), ""))
        Next

        Return result
    End Function
#End If

#If ClrVersion > 0 Then

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")>
     <Extension()>
    Function ToKeyValueCollection(ByVal source As String, ByVal separator As String) As ObjectModel.Collection(Of KeyValuePair(Of String, String))
        Dim result As New ObjectModel.Collection(Of KeyValuePair(Of String, String))
        Dim rows = source.Split(separator)

        If rows.Length Mod 2 <> 0 Then Throw New FormatException("This contains an odd number of entries")
        For i = 0 To rows.Length - 1 Step 2
            result.Add(New KeyValuePair(Of String, String)(rows(i), rows(i + 1)))
        Next

        Return result
    End Function
#End If
#End If

#If ClrVersion > 0 Then

    <Extension()> Function MD5Hash(ByVal value As String) As String
        If value Is Nothing Then Throw New ArgumentNullException("value")

        Using hasher = System.Security.Cryptography.MD5CryptoServiceProvider.Create()
            Return hasher.ComputeHash(Encoding.UTF8.GetBytes(value)).ToString("x2")
        End Using
    End Function
#End If


    <Extension()> Function Format(ByVal value As String, ByVal ParamArray args() As Object) As String
        If value Is Nothing Then Throw New ArgumentNullException("value")
        If args Is Nothing Then Throw New ArgumentNullException("args")

        Return String.Format(value, args)
    End Function

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of  methods", MessageId:="0")> <Extension()> Function Truncate(ByVal value As String, ByVal maxLength As Integer) As String
        If maxLength < 4 Then Throw New ArgumentOutOfRangeException("maxLength")

        If value = "" Then Return ""
        If value.Length < maxLength Then Return value
        Return value.Substring(0, maxLength - 3) & "..."
    End Function

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of  methods", MessageId:="0")> <Extension()> Function TruncateStart(ByVal value As String, ByVal maxLength As Integer) As String
        If maxLength < 4 Then Throw New ArgumentOutOfRangeException("maxLength")

        If value = "" Then Return ""
        If value.Length < maxLength Then Return value
        Return "..." & value.Right(maxLength - 3)
    End Function

#If ClrVersion > 0 Then
    <Extension()> Function IsNumeric(ByVal value As String) As Boolean
        Return Microsoft.VisualBasic.IsNumeric(value)
    End Function
#End If


    ''' <summary>
    ''' Uses the IsMatch function in regular expressions for matching
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Function IsMatch(ByVal value As String, ByVal pattern As String) As Boolean
        Return RegularExpressions.Regex.IsMatch(value, pattern)
    End Function

    ''' <summary>
    ''' Uses the IsMatch function in regular expressions for matching
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="pattern"></param>
    ''' <param name="options"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Function IsMatch(ByVal value As String, ByVal pattern As String, ByVal options As RegexOptions) As Boolean
        Return Regex.IsMatch(value, pattern, options)
    End Function

    'Would this actually be useful to anyone?
    '<Extension()>  Function ToMemoryStream(ByVal this As String, ByVal encoding As Text.Encoding) As IO.MemoryStream
    '	Return New IO.MemoryStream(this.ToByteArray(encoding))
    'End Function


    <Extension()> Function ToEnum(Of T As Structure)(ByVal value As String) As T
        If value Is Nothing Then Throw New ArgumentNullException("value")

        Return CType([Enum].Parse(GetType(T), value, True), T)
    End Function

#If Subset <> "Client" And ClrVersion > 0 Then
    <Extension()> Function HtmlEncode(ByVal this As String) As String
        Return Global.System.Web.HttpUtility.HtmlEncode(this)
    End Function

    <Extension()> Function HtmlDecode(ByVal this As String) As String
        Return Global.System.Web.HttpUtility.HtmlDecode(this)
    End Function

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")>
  <Extension()> Function UrlDecode(ByVal this As String) As String
        Return Global.System.Web.HttpUtility.UrlDecode(this)
    End Function

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")>
 <Extension()> Function UrlPathEncode(ByVal this As String) As String
        Return Global.System.Web.HttpUtility.UrlPathEncode(this)
    End Function

    <Extension()> Function ParseQueryString(ByVal this As String) As Specialized.NameValueCollection
        If this Is Nothing Then Throw New ArgumentNullException("this")
        Return Global.System.Web.HttpUtility.ParseQueryString(this)
    End Function
#End If

    <Extension()> Function RemoveNonnumeric(ByVal value As String) As String
        If value Is Nothing Then Return Nothing

        Dim sb As New StringBuilder(value.Length)

        For Each c In value.ToCharArray
            If Char.IsNumber(c) Then sb.Append(c)
        Next

        Return sb.ToString()

    End Function



#If Subset <> "Client" And ClrVersion > 0 Then

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")> <Extension()> Function UrlEncode(ByVal this As String) As String
        Return UrlEncode(this, UrlEncodingMethod.Clr)
    End Function


    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")>
    <Extension()> Function UrlEncode(ByVal value As String, ByVal method As UrlEncodingMethod) As String
        If value Is Nothing Then Throw New ArgumentNullException("value")

        Select Case method
            Case UrlEncodingMethod.DoNoEncode
                Return value
            Case UrlEncodingMethod.Clr
                Return Global.System.Web.HttpUtility.UrlEncode(value)

            Case UrlEncodingMethod.OAuth
                Return Security.OAuth.UrlEncode(value)

            Case Else
                Throw New ArgumentOutOfRangeException("method", "Encoding method not specified")
        End Select
    End Function

#End If


    <Extension()> Public Function Encrypt(ByVal stringToEncrypt As String, ByVal key As String) As String
        If String.IsNullOrEmpty(stringToEncrypt) Then Throw New ArgumentException("stringToEncrypt is nothing or empty.", "stringToEncrypt")
        If String.IsNullOrEmpty(key) Then Throw New ArgumentException("key is nothing or empty.", "key")

        Dim cspp = New CspParameters()
        cspp.KeyContainerName = key

        Dim rsa = New RSACryptoServiceProvider(cspp)
        rsa.PersistKeyInCsp = True

        Dim bytes = rsa.Encrypt(UTF8Encoding.UTF8.GetBytes(stringToEncrypt), True)

        Return BitConverter.ToString(bytes)
    End Function

    <Extension()> Public Function Decrypt(ByVal stringToDecrypt As String, ByVal key As String) As String
        If String.IsNullOrEmpty(stringToDecrypt) Then Throw New ArgumentException("stringToDecrypt is nothing or empty.", "stringToDecrypt")
        If String.IsNullOrEmpty(key) Then Throw New ArgumentException("key is nothing or empty.", "key")

        Dim cspp = New CspParameters()
        cspp.KeyContainerName = key

        Dim rsa = New RSACryptoServiceProvider(cspp)
        rsa.PersistKeyInCsp = True

        Dim decryptArray = stringToDecrypt.Split(New String() {"-"}, StringSplitOptions.None)
        Dim decryptByteArray = Array.ConvertAll(Of String, Byte)(decryptArray, (Function(s) Convert.ToByte(Byte.Parse(s, System.Globalization.NumberStyles.HexNumber))))

        Dim bytes = rsa.Decrypt(decryptByteArray, True)

        Return UTF8Encoding.UTF8.GetString(bytes)
    End Function


End Module

#End If