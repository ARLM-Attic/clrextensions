<Obsolete("Untested")> Public Module ListExtension

	''' <summary>
	''' This attempts to create a new list of the indicated type. This may fail due to casting.
	''' For a safer version use OfType, which filters out items that cannot be cast.
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <param name="this"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Public Function ToList(Of T)(ByVal this As IList) As List(Of T)
		Return (From item In this Select CType(item, T)).ToList
	End Function

	<Extension()> Public Function StringJoin(Of T)(ByVal this As IList(Of T), ByVal separator As String) As String
		Dim temp As New List(Of String)(this.Count)
		For Each item In this
			temp.Add(item.ToString)
		Next
		Return temp.Join(separator)
	End Function

	<Extension()> Public Function StringJoin(Of T)(ByVal this As IList(Of T), ByVal separator As String, ByVal formater As Func(Of T, String)) As String
		Dim temp As New List(Of String)(this.Count)
		For Each item In this
			temp.Add(formater(item))
		Next
		Return temp.Join(separator)
	End Function


	<Extension()> Public Function Chunk(Of T)(ByVal this As IList(Of T), ByVal size As Integer) As List(Of List(Of T))
		Dim result As New List(Of List(Of T))
		For i = 0 To CInt(Math.Ceiling(this.Count / size)) - 1
			result.Add(New List(Of T)(this.GetRange(i * size, Math.Min(size, this.Count - (i * size)))))
		Next
		Return result
	End Function

	<Extension()> Public Function GetRange(Of T)(ByVal this As IList(Of T), ByVal index As Integer, ByVal count As Integer) As List(Of T)
		Dim result As New List(Of T)(count)
		For i = index To Math.Min(index + count, this.Count) - 1
			result.Add(this(i))
		Next
		Return result
	End Function

	<Extension()> Public Function IndexOfSequence(Of T)(ByVal this As IList(Of T), ByVal pattern As IList(Of T)) As Integer
		If this Is Nothing Then Return -1
		If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")

		For startIndex = 0 To this.Count - (pattern.Count)
			If Object.Equals(this(startIndex), pattern(0)) Then	   'check the full pattern
				Dim PatternFailed = False
				For patternIndex = 1 To pattern.Count
					If Not Object.Equals(this(startIndex + patternIndex), pattern(patternIndex)) Then
						PatternFailed = True
						Exit For
					End If
					If Not PatternFailed Then Return startIndex
				Next
			End If
		Next
		Return -1
	End Function

	<Extension()> Public Function IndexOfSequence(Of T)(ByVal this As IList(Of T), ByVal ParamArray pattern() As T) As Integer
		If this Is Nothing Then Return -1
		If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")

		Return IndexOfSequence(this, CType(pattern, IList(Of T)))
	End Function


	<Extension()> Public Function IndexOfSequence(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal pattern As IList(Of T)) As Integer
		If comparer Is Nothing Then Throw New ArgumentNullException("comparer")
		If this Is Nothing Then Return -1
		If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")



		For startIndex = 0 To this.Count - (pattern.Count)
			If comparer.Equals(this(startIndex), pattern(0)) Then	   'check the full pattern
				Dim PatternFailed = False
				For patternIndex = 1 To pattern.Count
					If Not comparer.Equals(this(startIndex + patternIndex), pattern(patternIndex)) Then
						PatternFailed = True
						Exit For
					End If
					If Not PatternFailed Then Return startIndex
				Next
			End If
		Next
		Return -1
	End Function

	<Extension()> Public Function IndexOfSequence(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal ParamArray pattern() As T) As Integer
		If comparer Is Nothing Then Throw New ArgumentNullException("comparer")
		If this Is Nothing Then Return -1
		If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")

		Return IndexOfSequence(this, comparer, CType(pattern, IList(Of T)))
	End Function

	<Extension()> Public Function StartsWith(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal pattern As IList(Of T)) As Boolean
		If comparer Is Nothing Then Throw New ArgumentNullException("comparer")
		If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")
		If pattern.Count > this.Count Then Return False

		For patternIndex = 0 To pattern.Count - 1
			If Not comparer.Equals(this(patternIndex), pattern(patternIndex)) Then
				Return False
			End If
		Next
		Return True
	End Function

	<Extension()> Public Function StartsWith(Of T)(ByVal this As IList(Of T), ByVal pattern As IList(Of T)) As Boolean
		If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")
		If pattern.Count > this.Count Then Return False

		For patternIndex = 0 To pattern.Count - 1
			If Not Object.Equals(this(patternIndex), pattern(patternIndex)) Then
				Return False
			End If
		Next
		Return True
	End Function


	<Extension()> Public Function EndsWith(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal pattern As IList(Of T)) As Boolean
		If comparer Is Nothing Then Throw New ArgumentNullException("comparer")
		If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")
		If pattern.Count > this.Count Then Return False

		Dim startIndex = this.Count - pattern.Count
		For patternIndex = 0 To pattern.Count - 1
			If Not comparer.Equals(this(startIndex + patternIndex), pattern(patternIndex)) Then
				Return False
			End If
		Next
		Return True
	End Function

	<Extension()> Public Function EndsWith(Of T)(ByVal this As IList(Of T), ByVal pattern As IList(Of T)) As Boolean
		If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
		If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")
		If pattern.Count > this.Count Then Return False

		Dim startIndex = this.Count - pattern.Count
		For patternIndex = 0 To pattern.Count - 1
			If Not Object.Equals(this(startIndex + patternIndex), pattern(patternIndex)) Then
				Return False
			End If
		Next
		Return True
	End Function

	<Extension()> Public Function EndsWith(Of T)(ByVal this As IList(Of T), ByVal ParamArray pattern() As T) As Boolean
		Return EndsWith(this, CType(pattern, IList(Of T)))
	End Function

	<Extension()> Public Function EndsWith(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal ParamArray pattern() As T) As Boolean
		Return EndsWith(this, comparer, CType(pattern, IList(Of T)))
	End Function

	<Extension()> Public Function StartsWith(Of T)(ByVal this As IList(Of T), ByVal ParamArray pattern() As T) As Boolean
		Return StartsWith(this, CType(pattern, IList(Of T)))
	End Function

	<Extension()> Public Function StartsWith(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal ParamArray pattern() As T) As Boolean
		Return StartsWith(this, comparer, CType(pattern, IList(Of T)))
	End Function


	<Extension()> Public Function IndexesWhere(Of T)(ByVal source As IList(Of T), ByVal where As Func(Of T, Boolean)) As List(Of Integer)
		Dim result As New List(Of Integer)
		For i = 0 To source.Count - 1
			If where(source(i)) Then result.Add(i)
		Next
		Return result
	End Function

	<Extension()> Public Function TakeEvery(Of T)(ByVal source As IList(Of T), ByVal startIndex As Integer, ByVal skip As Integer) As List(Of T)
		Dim result As New List(Of T)
		For i = startIndex To source.Count - 1 Step skip
			result.Add(source(i))
		Next
		Return result
	End Function


End Module
