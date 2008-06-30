Public Module StringExtension

	''' <summary>
	''' Joins all the strings in the supplied enumeration.
	''' Empty and null enumerations will return an empty string
	''' </summary>
	''' <param name="this"></param>
	''' <param name="separator"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function Join(ByVal this As IEnumerable(Of String), ByVal separator As String) As String
		If this Is Nothing Then Return ""
		Return String.Join(separator, this.ToArray)
	End Function

	''' <summary>
	''' Joins all the strings in the supplied enumeration.
	''' Empty and null enumerations will return an empty string
	''' </summary>
	''' <param name="this"></param>
	''' <param name="separator"></param>
	''' <param name="options">Optionally skip null and empty entries in the enumeration</param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function Join(ByVal this As IEnumerable(Of String), ByVal separator As String, ByVal options As StringSplitOptions) As String
		If this Is Nothing Then Return ""
		Select Case options
			Case StringSplitOptions.None
				Return String.Join(separator, this.ToArray)
			Case StringSplitOptions.RemoveEmptyEntries
				Return String.Join(separator, this.Where(Function(s) s <> "").ToArray)
			Case Else
				Throw New ArgumentException("options")
		End Select
	End Function

	''' <summary>
	''' Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array.
	''' </summary>
	''' <param name="this"></param>
	''' <param name="separator">A string that delimits the substrings in this string</param>
	''' <returns>An array whose elements contain the substrings in this string that are delimited by the separator.</returns>
	''' <remarks></remarks>
	<Extension()> Public Function Split(ByVal this As String, ByVal separator As String) As String()
		If this Is Nothing Then Return New String() {}
		Return this.Split(New String() {separator}, StringSplitOptions.None)
	End Function

	''' <summary>
	''' Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array. A parameter specifies whether to return empty array elements.
	''' </summary>
	''' <param name="this"></param>
	''' <param name="separator">A string that delimits the substrings in this string</param>
	''' <param name="options">Specify System.StringSplitOptions.RemoveEmptyEntries to omit empty array elements from the array returned, or System.StringSplitOptions.None to include empty array elements in the array returned.</param>
	''' <returns>An array whose elements contain the substrings in this string that are delimited by the separator.</returns>
	''' <remarks></remarks>
	''' <exception cref="System.ArgumentException">options is not one of the System.StringSplitOptions values.</exception>
	<Extension()> Public Function Split(ByVal this As String, ByVal separator As String, ByVal options As StringSplitOptions) As String()
		If this Is Nothing Then Return New String() {}
		Return this.Split(New String() {separator}, options)
	End Function


	''' <summary>
	''' Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array.
	''' </summary>
	''' <param name="this"></param>
	''' <param name="separator">A string that delimits the substrings in this string</param>
	''' <param name="count">The maximum number of substrings to return.</param>
	''' <returns>An array whose elements contain the substrings in this string that are delimited by the separator.</returns>
	''' <remarks></remarks>
	''' <exception cref="System.ArgumentException">options is not one of the System.StringSplitOptions values.</exception>
	<Extension()> Public Function Split(ByVal this As String, ByVal separator As String, ByVal count As Integer) As String()
		If this Is Nothing Then Return New String() {}
		Return Split(this, separator, count, StringSplitOptions.None)
	End Function

	''' <summary>
	''' Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array. A parameter specifies whether to return empty array elements.
	''' </summary>
	''' <param name="this"></param>
	''' <param name="separator">A string that delimits the substrings in this string</param>
	''' <param name="count">The maximum number of substrings to return.</param>
	''' <param name="options">Specify System.StringSplitOptions.RemoveEmptyEntries to omit empty array elements from the array returned, or System.StringSplitOptions.None to include empty array elements in the array returned.</param>
	''' <returns>An array whose elements contain the substrings in this string that are delimited by the separator.</returns>
	''' <remarks></remarks>
	''' <exception cref="System.ArgumentException">options is not one of the System.StringSplitOptions values.</exception>
	<Extension()> Public Function Split(ByVal this As String, ByVal separator As String, ByVal count As Integer, ByVal options As StringSplitOptions) As String()
		If this Is Nothing Then Return New String() {}

		Dim temp = Microsoft.VisualBasic.Split(this, separator, count)
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
	''' <param name="this"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function FirstToLower(ByVal this As String) As String
		If this Is Nothing Then Return Nothing
		If this = "" Then Return ""
		If this.Length = 1 Then Return this.ToLower
		Return this.Substring(0, 1).ToUpper & this.Substring(1)
	End Function

	''' <summary>
	''' Changes the first letter to a capital, leaving the rest alone. Useful for turning "testVar" into "TestVar"
	''' Nulls and empty strings are unchanged
	''' </summary>
	''' <param name="this"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function FirstToUpper(ByVal this As String) As String
		If this Is Nothing Then Return Nothing
		If this = "" Then Return ""
		If this.Length = 1 Then Return this.ToUpper
		Return this.Substring(0, 1).ToUpper & this.Substring(1)
	End Function

	''' <summary>
	''' Changes the first letter to a capital and the rest to lower case. Useful for turning "TEST" into "Test"
	''' Nulls and empty strings are unchanged
	''' </summary>
	''' <param name="this"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function Capitalize(ByVal this As String) As String
		If this Is Nothing Then Return Nothing
		If this = "" Then Return ""
		If this.Length = 1 Then Return this.ToUpper
		Return this.Substring(0, 1).ToUpper & this.Substring(1).ToLower
	End Function

	''' <summary>
	''' Converts nulls into empty strings
	''' </summary>
	''' <param name="this"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function DefaultIfNull(ByVal this As String) As String
		Return If(this Is Nothing, "", this)
	End Function

	''' <summary>
	''' Converts nulls into a default value
	''' </summary>
	''' <param name="this"></param>
	''' <param name="default"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function DefaultIfNull(ByVal this As String, ByVal [default] As String) As String
		Return If(this Is Nothing, [default], this)
	End Function

	''' <summary>
	''' Converts nulls and empty strings into a default value
	''' </summary>
	''' <param name="this"></param>
	''' <param name="default"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function DefaultIfEmpty(ByVal this As String, ByVal [default] As String) As String
		Return If(this = "", [default], this)
	End Function

	''' <summary>
	''' Checks to see if the string is an email address as per the System.Net.Mail definition
	''' </summary>
	''' <param name="this"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function IsEmailAddress(ByVal this As String) As Boolean
		If this = "" Then Return False
		Try
			Dim temp = New Net.Mail.MailAddress(this)
			Return True
		Catch ex As FormatException
			Return False
		End Try
	End Function

	''' <summary>
	''' Uses the IsMatch function in regular expressions for matching
	''' </summary>
	''' <param name="this"></param>
	''' <param name="pattern"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function IsMatch(ByVal this As String, ByVal pattern As String) As Boolean
		Return Text.RegularExpressions.Regex.IsMatch(this, pattern)
	End Function

	''' <summary>
	''' Uses the IsMatch function in regular expressions for matching
	''' </summary>
	''' <param name="this"></param>
	''' <param name="pattern"></param>
	''' <param name="options"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function IsMatch(ByVal this As String, ByVal pattern As String, ByVal options As Text.RegularExpressions.RegexOptions) As Boolean
		Return Text.RegularExpressions.Regex.IsMatch(this, pattern, options)
	End Function

	''' <summary>
	''' Returns the first N characters, or the whole string
	''' Nulls are unchanged
	''' </summary>
	''' <param name="this"></param>
	''' <param name="length"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function Left(ByVal this As String, ByVal length As Integer) As String
		If this.Length < length Then Throw New ArgumentOutOfRangeException("length")

		If this Is Nothing Then Return Nothing
		If this = "" Then Return ""
		Return If(this.Length > length, this.Substring(0, length), this)
	End Function

	''' <summary>
	''' Returns the last N characters, or the whole string
	''' Nulls are unchanged
	''' </summary>
	''' <param name="this"></param>
	''' <param name="length"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function Right(ByVal this As String, ByVal length As Integer) As String
		If this.Length < length Then Throw New ArgumentOutOfRangeException("length")

		If this Is Nothing Then Return Nothing
		If this = "" Then Return ""
		Return If(this.Length > length, this.Substring(this.Length - length), this)
	End Function

	''' <summary>
	''' Repeats the given string N times.
	''' To facilitate some coding patterns, N may be 0; this will result in an empty string.
	''' </summary>
	''' <param name="this"></param>
	''' <param name="count"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function Repeat(ByVal this As String, ByVal count As Integer) As String
		If this Is Nothing Then Throw New ArgumentNullException("this")
		If this = "" Then Throw New ArgumentException("this")
		If count < 0 Then Throw New ArgumentOutOfRangeException("count")
		If count = 0 Then Return ""
		Dim result As New Text.StringBuilder(this.Length * count)
		For i = 1 To count
			result.Append(this)
		Next
		Return result.ToString
	End Function

	''' <summary>
	''' This method does key-value replacements based on a simple pattern match
	''' </summary>
	''' <param name="this"></param>
	''' <param name="searchPattern">A string representing the fragment to match on. This should follow the String.Format syntax. For example, "${0}" will search for $Key1, $Key2, etc.</param>
	''' <param name="dictionary"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function PatternReplace(ByVal this As String, ByVal searchPattern As String, ByVal dictionary As Dictionary(Of String, String)) As String
		If searchPattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If searchPattern = "" Then Throw New ArgumentException("pattern")
		If Not searchPattern.Contains("{0}") Then Throw New FormatException("The search pattern doesn't contain the replacement command {0}")

		If this = "" Then Return this

		Dim result = New Text.StringBuilder(this)
		For Each item In dictionary
			result.Replace(String.Format(searchPattern, item.Key), item.Value)
		Next
		Return result.ToString
	End Function

	''' <summary>
	''' This method does key-value replacements based on a simple pattern match
	''' </summary>
	''' <param name="this"></param>
	''' <param name="searchPattern">A string representing the fragment to match on. This should follow the String.Format syntax. For example, "${0}" will search for $Key1, $Key2, etc.</param>
	''' <param name="replacementPattern">A string representing the fragment to replace the match with. Use {0} to represent the original key and {1} to represent the new value. Standard String.Format options are allowed.</param>
	''' <param name="dictionary"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function PatternReplace(Of T)(ByVal this As String, ByVal searchPattern As String, ByVal replacementPattern As String, ByVal dictionary As Dictionary(Of String, T)) As String
		If searchPattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If searchPattern = "" Then Throw New ArgumentException("pattern")
		If Not searchPattern.Contains("{0}") Then Throw New FormatException("The search pattern doesn't contain the replacement command {0}")

		If this = "" Then Return this

		Dim result = New Text.StringBuilder(this)
		For Each item In dictionary
			result.Replace(String.Format(searchPattern, item.Key), String.Format(replacementPattern, item.Key, item.Value))
		Next
		Return result.ToString
	End Function


	<Extension()> Public Function NormalizeLineBreaks(ByVal this As String) As String
		Return this.Replace(vbCrLf, vbCr).Replace(vbLf, vbCr).Replace(vbCr, vbCrLf)
	End Function

	<Extension()> Public Function NormalizeLineBreaks(ByVal this As String, ByVal mode As LineBreakMode) As String
		Select Case mode
			Case LineBreakMode.Windows
				Return NormalizeLineBreaks(this)
			Case LineBreakMode.Macintosh
				Return this.Replace(vbCrLf, vbCr).Replace(vbLf, vbCr)
			Case LineBreakMode.Unix
				Return this.Replace(vbCrLf, vbLf).Replace(vbCr, vbCrLf)
			Case Else
				Throw New ArgumentOutOfRangeException("mode")
		End Select
	End Function

	<Extension()> Public Function HtmlLineBreaks(ByVal this As String) As String
		Return this.Replace(vbCrLf, "<br/>").Replace(vbLf, "<br/>").Replace(vbCr, "<br/>")
	End Function

	Public Enum LineBreakMode
		Windows = 0
		Macintosh = 1
		Unix = 2
	End Enum


	<Extension()> Public Function ToDictionary(ByVal this As String, ByVal rowSeparator As String, ByVal columnSeparator As String) As Dictionary(Of String, String)
		If rowSeparator = columnSeparator Then Return ToDictionary(this, rowSeparator)

		Dim result As New Dictionary(Of String, String)
		Dim rows = this.Split(rowSeparator, StringSplitOptions.RemoveEmptyEntries)

		For Each pair In rows.Select(Function(s) s.Split(columnSeparator, 2))
			If pair.Length = 2 Then result.Add(pair(0), pair(1)) Else result.Add(pair(0), "")
		Next

		Return result
	End Function

	<Extension()> Public Function ToDictionary(ByVal this As String, ByVal separator As String) As Dictionary(Of String, String)
		Dim result As New Dictionary(Of String, String)
		Dim rows = this.Split(separator)

		If rows.Count Mod 2 <> 0 Then Throw New FormatException("This contains an odd number of entries")
		For i = 0 To rows.Count - 1 Step 2
			result.Add(rows(i), rows(i + 1))
		Next

		Return result
	End Function

	<Extension()> Public Function ToKeyValueCollection(ByVal this As String, ByVal rowSeparator As String, ByVal columnSeparator As String) As ObjectModel.Collection(Of KeyValuePair(Of String, String))
		If rowSeparator = columnSeparator Then Return ToKeyValueCollection(this, rowSeparator)

		Dim result As New ObjectModel.Collection(Of KeyValuePair(Of String, String))
		Dim rows = this.Split(rowSeparator, StringSplitOptions.RemoveEmptyEntries)

		For Each pair In rows.Select(Function(s) s.Split(columnSeparator, 2))
			If pair.Length = 2 Then result.Add(New KeyValuePair(Of String, String)(pair(0), pair(1))) Else result.Add(New KeyValuePair(Of String, String)(pair(0), ""))
		Next

		Return result
	End Function

	<Extension()> Public Function ToKeyValueCollection(ByVal this As String, ByVal separator As String) As ObjectModel.Collection(Of KeyValuePair(Of String, String))
		Dim result As New ObjectModel.Collection(Of KeyValuePair(Of String, String))
		Dim rows = this.Split(separator)

		If rows.Count Mod 2 <> 0 Then Throw New FormatException("This contains an odd number of entries")
		For i = 0 To rows.Count - 1 Step 2
			result.Add(New KeyValuePair(Of String, String)(rows(i), rows(i + 1)))
		Next

		Return result
	End Function

	<Extension()> Public Function MD5Hash(ByVal this As String) As String
		Return Security.Cryptography.MD5CryptoServiceProvider.Create().ComputeHash(Text.Encoding.UTF8.GetBytes(this)).ToString("x2")
	End Function

	<Extension()> Function Reverse(ByVal this As String) As String
		If this Is Nothing Then Return Nothing

		Dim result = this.ToCharArray

		For i = 0 To result.Length \ 2 - 1
			Dim c = result(i)
			result(i) = result(result.Length - i - 1)
			result(result.Length - i - 1) = c
		Next

		Return New String(result)
	End Function


	<Extension()> Public Function Format(ByVal this As String, ByVal ParamArray args() As Object) As String
		Return String.Format(this, args)
	End Function

	''' <summary>
	''' 
	''' </summary>
	''' <param name="this"></param>
	''' <returns></returns>
	''' <remarks>Not really needed for VB, but C# programmers seem to like it</remarks>
	<Extension()> Public Function IsNullOrEmpty(ByVal this As String) As Boolean
		Return this = ""
	End Function

	<Extension()> Public Function ToMemoryStream(ByVal this As String, ByVal encoding As Text.Encoding) As IO.MemoryStream
		Return New IO.MemoryStream(this.ToByteArray(encoding))
	End Function


	<Extension()> Public Function ToEnum(Of T As Structure)(ByVal this As String) As T
		Return CType([Enum].Parse(GetType(T), this, True), T)
	End Function


	<Extension()> Public Function ToTitleCase(ByVal this As String) As String
		Return Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this)
	End Function

	<Extension()> Public Function Truncate(ByVal this As String, ByVal maxLength As Integer) As String
		If maxLength < 4 Then Throw New ArgumentOutOfRangeException("maxLength")

		If this = "" Then Return ""
		If this.Length < maxLength Then Return this
		Return this.Substring(0, maxLength - 3) & "..."
	End Function

	<Extension()> Public Function TruncateStart(ByVal this As String, ByVal maxLength As Integer) As String
		If maxLength < 4 Then Throw New ArgumentOutOfRangeException("maxLength")

		If this = "" Then Return ""
		If this.Length < maxLength Then Return this
		Return "..." & this.Right(maxLength - 3)
	End Function


	<Extension()> Public Function IsNumeric(ByVal this As String) As Boolean
		Return Microsoft.VisualBasic.IsNumeric(this)
	End Function


	'TODO - Add the method for turning formatted strings like 12.3MB into longs



End Module






