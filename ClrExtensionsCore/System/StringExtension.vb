﻿
Public Module StringExtension

	''' <summary>
	''' Joins all the strings in the supplied enumeration.
	''' Empty and null enumerations will return an empty string
	''' </summary>
	''' <param name="source"></param>
	''' <param name="separator"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function Join(ByVal source As IEnumerable(Of String), ByVal separator As String) As String
		If source Is Nothing Then Return ""
		Return String.Join(separator, source.ToArray)
	End Function

#If IncludeUntested Then


	''' <summary>
	''' Joins all the strings in the supplied enumeration.
	''' Empty and null enumerations will return an empty string
	''' </summary>
	''' <param name="source"></param>
	''' <param name="separator"></param>
	''' <param name="options">Optionally skip null and empty entries in the enumeration</param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function Join(ByVal source As IEnumerable(Of String), ByVal separator As String, ByVal options As StringSplitOptions) As String
		If source Is Nothing Then Return ""
		Select Case options
			Case StringSplitOptions.None
				Return String.Join(separator, source.ToArray)
			Case StringSplitOptions.RemoveEmptyEntries
				Return String.Join(separator, source.Where(Function(s) s <> "").ToArray)
			Case Else
				Throw New ArgumentException("options")
		End Select
	End Function

	''' <summary>
	''' Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array.
	''' </summary>
	''' <param name="source"></param>
	''' <param name="separator">A string that delimits the substrings in this string</param>
	''' <returns>An array whose elements contain the substrings in this string that are delimited by the separator.</returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function Split(ByVal source As String, ByVal separator As String) As String()
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
	''' <exception cref="System.ArgumentException">options is not one of the System.StringSplitOptions values.</exception>
	<Untested()> <Extension()> Public Function Split(ByVal source As String, ByVal separator As String, ByVal options As StringSplitOptions) As String()
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
	''' <exception cref="System.ArgumentException">options is not one of the System.StringSplitOptions values.</exception>
	<Untested()> <Extension()> Public Function Split(ByVal source As String, ByVal separator As String, ByVal count As Integer) As String()
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
	''' <exception cref="System.ArgumentException">options is not one of the System.StringSplitOptions values.</exception>
	<Untested()> <Extension()> Public Function Split(ByVal source As String, ByVal separator As String, ByVal count As Integer, ByVal options As StringSplitOptions) As String()
		If source Is Nothing Then Return New String() {}

		Dim temp = Microsoft.VisualBasic.Split(source, separator, count)
		Select Case options
			Case StringSplitOptions.None
				Return temp
			Case StringSplitOptions.RemoveEmptyEntries
				Return temp.Where(Function(s) s <> "").ToArray
			Case Else
				Throw New ArgumentException("options")
		End Select
	End Function

	''' <summary>
	''' Changes the first letter to a lower case letter, leaving the rest alone. Useful for turning "TestVar" into "testVar"
	''' Nulls and empty strings are unchanged
	''' </summary>
	''' <param name="value"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function FirstToLower(ByVal value As String) As String
		If value Is Nothing Then Return Nothing
		If value = "" Then Return ""
		If value.Length = 1 Then Return value.ToLower
		Return value.Substring(0, 1).ToUpper & value.Substring(1)
	End Function

	''' <summary>
	''' Changes the first letter to a capital, leaving the rest alone. Useful for turning "testVar" into "TestVar"
	''' Nulls and empty strings are unchanged
	''' </summary>
	''' <param name="value"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function FirstToUpper(ByVal value As String) As String
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
	<Untested()> <Extension()> Public Function Capitalize(ByVal value As String) As String
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
	<Untested()> <Extension()> Public Function DefaultIfNull(ByVal value As String) As String
		Return If(value Is Nothing, "", value)
	End Function

	''' <summary>
	''' Converts nulls into a default value
	''' </summary>
	''' <param name="value"></param>
	''' <param name="default"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function DefaultIfNull(ByVal value As String, ByVal [default] As String) As String
		Return If(value Is Nothing, [default], value)
	End Function

	''' <summary>
	''' Converts nulls and empty strings into a default value
	''' </summary>
	''' <param name="value"></param>
	''' <param name="default"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function DefaultIfEmpty(ByVal value As String, ByVal [default] As String) As String
		Return If(value = "", [default], value)
	End Function

	''' <summary>
	''' Checks to see if the string is an email address as per the System.Net.Mail definition
	''' </summary>
	''' <param name="value"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function IsEmailAddress(ByVal value As String) As Boolean
		If value = "" Then Return False
		Try
			Dim temp = New Net.Mail.MailAddress(value)
			Return True
		Catch ex As FormatException
			Return False
		End Try
	End Function

	''' <summary>
	''' Uses the IsMatch function in regular expressions for matching
	''' </summary>
	''' <param name="value"></param>
	''' <param name="pattern"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function IsMatch(ByVal value As String, ByVal pattern As String) As Boolean
		Return Text.RegularExpressions.Regex.IsMatch(value, pattern)
	End Function

	''' <summary>
	''' Uses the IsMatch function in regular expressions for matching
	''' </summary>
	''' <param name="value"></param>
	''' <param name="pattern"></param>
	''' <param name="options"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function IsMatch(ByVal value As String, ByVal pattern As String, ByVal options As Text.RegularExpressions.RegexOptions) As Boolean
		Return Text.RegularExpressions.Regex.IsMatch(value, pattern, options)
	End Function

	''' <summary>
	''' Returns the first N characters, or the whole string
	''' Nulls are unchanged
	''' </summary>
	''' <param name="value"></param>
	''' <param name="length"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function Left(ByVal value As String, ByVal length As Integer) As String
		If value.Length < length Then Throw New ArgumentOutOfRangeException("length")

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
	<Extension()> Public Function Right(ByVal value As String, ByVal length As Integer) As String
		If value.Length < length Then Throw New ArgumentOutOfRangeException("length")

		If value Is Nothing Then Return Nothing
		If value = "" Then Return ""
		Return If(value.Length > length, value.Substring(value.Length - length), value)
	End Function

	''' <summary>
	''' Repeats the given string N times.
	''' To facilitate some coding patterns, N may be 0; this will result in an empty string.
	''' </summary>
	''' <param name="value"></param>
	''' <param name="count"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function Repeat(ByVal value As String, ByVal count As Integer) As String
		If value Is Nothing Then Throw New ArgumentNullException("value")
		If value = "" Then Throw New ArgumentException("value")
		If count < 0 Then Throw New ArgumentOutOfRangeException("count")
		If count = 0 Then Return ""
		Dim result As New Text.StringBuilder(value.Length * count)
		For i = 1 To count
			result.Append(value)
		Next
		Return result.ToString
	End Function

	''' <summary>
	''' This method does key-value replacements based on a simple pattern match
	''' </summary>
	''' <param name="value"></param>
	''' <param name="searchPattern">A string representing the fragment to match on. This should follow the String.Format syntax. For example, "${0}" will search for $Key1, $Key2, etc.</param>
	''' <param name="dictionary"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function PatternReplace(ByVal value As String, ByVal searchPattern As String, ByVal dictionary As Dictionary(Of String, String)) As String
		If searchPattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If searchPattern = "" Then Throw New ArgumentException("pattern")
		If Not searchPattern.Contains("{0}") Then Throw New FormatException("The search pattern doesn't contain the replacement command {0}")

		If value = "" Then Return value

		Dim result = New Text.StringBuilder(value)
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
	<Untested()> <Extension()> Public Function PatternReplace(Of T)(ByVal value As String, ByVal searchPattern As String, ByVal replacementPattern As String, ByVal dictionary As Dictionary(Of String, T)) As String
		If searchPattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If searchPattern = "" Then Throw New ArgumentException("pattern")
		If Not searchPattern.Contains("{0}") Then Throw New FormatException("The search pattern doesn't contain the replacement command {0}")

		If value = "" Then Return value

		Dim result = New Text.StringBuilder(value)
		For Each item In dictionary
			result.Replace(String.Format(searchPattern, item.Key), String.Format(replacementPattern, item.Key, item.Value))
		Next
		Return result.ToString
	End Function


	<Untested()> <Extension()> Public Function NormalizeLineBreaks(ByVal value As String) As String
		Return value.Replace(vbCrLf, vbCr).Replace(vbLf, vbCr).Replace(vbCr, vbCrLf)
	End Function

	<Untested()> <Extension()> Public Function NormalizeLineBreaks(ByVal value As String, ByVal mode As LineBreakMode) As String
		Select Case mode
			Case LineBreakMode.Windows
				Return NormalizeLineBreaks(value)
			Case LineBreakMode.Macintosh
				Return value.Replace(vbCrLf, vbCr).Replace(vbLf, vbCr)
			Case LineBreakMode.Unix
				Return value.Replace(vbCrLf, vbLf).Replace(vbCr, vbCrLf)
			Case Else
				Throw New ArgumentOutOfRangeException("mode")
		End Select
	End Function

	<Untested()> <Extension()> Public Function HtmlLineBreaks(ByVal value As String) As String
		Return value.Replace(vbCrLf, "<br/>").Replace(vbLf, "<br/>").Replace(vbCr, "<br/>")
	End Function





	<Untested()> <Extension()> Public Function ToKeyValueCollection(ByVal source As String, ByVal rowSeparator As String, ByVal columnSeparator As String) As ObjectModel.Collection(Of KeyValuePair(Of String, String))
		If rowSeparator = columnSeparator Then Return ToKeyValueCollection(source, rowSeparator)

		Dim result As New ObjectModel.Collection(Of KeyValuePair(Of String, String))
		Dim rows = source.Split(rowSeparator, StringSplitOptions.RemoveEmptyEntries)

		For Each pair In rows.Select(Function(s) s.Split(columnSeparator, 2))
			If pair.Length = 2 Then result.Add(New KeyValuePair(Of String, String)(pair(0), pair(1))) Else result.Add(New KeyValuePair(Of String, String)(pair(0), ""))
		Next

		Return result
	End Function

	<Untested()> <Extension()> Public Function ToKeyValueCollection(ByVal source As String, ByVal separator As String) As ObjectModel.Collection(Of KeyValuePair(Of String, String))
		Dim result As New ObjectModel.Collection(Of KeyValuePair(Of String, String))
		Dim rows = source.Split(separator)

		If rows.Count Mod 2 <> 0 Then Throw New FormatException("This contains an odd number of entries")
		For i = 0 To rows.Count - 1 Step 2
			result.Add(New KeyValuePair(Of String, String)(rows(i), rows(i + 1)))
		Next

		Return result
	End Function

	<Untested()> <Extension()> Public Function MD5Hash(ByVal value As String) As String
		Return Security.Cryptography.MD5CryptoServiceProvider.Create().ComputeHash(Text.Encoding.UTF8.GetBytes(value)).ToString("x2")
	End Function

	<Untested()> <Extension()> Function Reverse(ByVal value As String) As String
		If value Is Nothing Then Return Nothing

		Dim result = value.ToCharArray

		For i = 0 To result.Length \ 2 - 1
			Dim c = result(i)
			result(i) = result(result.Length - i - 1)
			result(result.Length - i - 1) = c
		Next

		Return New String(result)
	End Function


	<Untested()> <Extension()> Public Function Format(ByVal value As String, ByVal ParamArray args() As Object) As String
		Return String.Format(value, args)
	End Function

	''' <summary>
	''' 
	''' </summary>
	''' <param name="value"></param>
	''' <returns></returns>
	''' <remarks>Not really needed for VB, but C# programmers seem to like it</remarks>
	<Untested()> <Extension()> Public Function IsNullOrEmpty(ByVal value As String) As Boolean
		Return value = ""
	End Function

	'Would this actually be useful to anyone?
	'<Extension()> Public Function ToMemoryStream(ByVal this As String, ByVal encoding As Text.Encoding) As IO.MemoryStream
	'	Return New IO.MemoryStream(this.ToByteArray(encoding))
	'End Function


	<Untested()> <Extension()> Public Function ToEnum(Of T As Structure)(ByVal value As String) As T
		Return CType([Enum].Parse(GetType(T), value, True), T)
	End Function


	<Untested()> <Extension()> Public Function ToTitleCase(ByVal value As String) As String
		Return Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value)
	End Function

	<Untested()> <Extension()> Public Function Truncate(ByVal value As String, ByVal maxLength As Integer) As String
		If maxLength < 4 Then Throw New ArgumentOutOfRangeException("maxLength")

		If value = "" Then Return ""
		If value.Length < maxLength Then Return value
		Return value.Substring(0, maxLength - 3) & "..."
	End Function

	<Untested()> <Extension()> Public Function TruncateStart(ByVal value As String, ByVal maxLength As Integer) As String
		If maxLength < 4 Then Throw New ArgumentOutOfRangeException("maxLength")

		If value = "" Then Return ""
		If value.Length < maxLength Then Return value
		Return "..." & value.Right(maxLength - 3)
	End Function


	<Untested()> <Extension()> Public Function IsNumeric(ByVal value As String) As Boolean
		Return Microsoft.VisualBasic.IsNumeric(value)
	End Function


#End If



End Module




Public Enum LineBreakMode
	Windows = 0
	Macintosh = 1
	Unix = 2
End Enum

