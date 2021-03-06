'Copyright (c) 2008, Jonathan Allen

#If 1 = 1 Then

public  Module ListExtension

    ''' <summary>
    ''' Breaks a list into a collection of lists whose size is no more than the indicated limit
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="size"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")> 
    <Extension()>      Function Chunk(Of T)(ByVal source As IList(Of T), ByVal size As Integer) As List(Of List(Of T))
        If source Is Nothing Then Throw New ArgumentNullException("source")

        Dim result As New List(Of List(Of T))
        For i = 0 To CInt(Math.Ceiling(source.Count / size)) - 1
            result.Add(New List(Of T)(source.GetRange(i * size, Math.Min(size, source.Count - (i * size)))))
        Next
        Return result
    End Function

    ''' <summary>
    ''' Adds a GetRange method to any IList that doesn't already have one.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="index">The starting index to return</param>
    ''' <param name="count">The Maximum number of items to return</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    
    <Extension()> 
         Function GetRange(Of T)(ByVal this As IList(Of T), ByVal index As Integer, ByVal count As Integer) As List(Of T)
        If this Is Nothing Then Throw New ArgumentNullException("this")
        If count < 0 Then Throw New ArgumentOutOfRangeException("count")
        If index < 0 Then Throw New ArgumentOutOfRangeException("index")

        Dim result As New List(Of T)(count)
        For i = index To Math.Min(index + count, this.Count) - 1
            result.Add(this(i))
        Next
        Return result
    End Function


    ''' <summary>
    ''' This joins two lists based on their index. 
    ''' </summary>
    ''' <typeparam name="TLeft">The type of item contained in left</typeparam>
    ''' <typeparam name="TRight">The type of item contained in the right</typeparam>
    ''' <typeparam name="TResult">The return type of the combined items</typeparam>
    ''' <param name="left">A finite list of items</param>
    ''' <param name="right">A finite list of items at least as long as left, or an infinite list</param>
    ''' <param name="combiner">The function that combines a left item with a right item</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
        
    <Extension()>
     Function Join(Of TLeft, TRight, TResult)(ByVal left As IList(Of TLeft), ByVal right As IEnumerable(Of TRight), ByVal combiner As Func(Of TLeft, TRight, TResult)) As List(Of TResult)
        If left Is Nothing Then Throw New ArgumentNullException("left")
        If right Is Nothing Then Throw New ArgumentNullException("right")
        If combiner Is Nothing Then Throw New ArgumentNullException("combiner")

        Dim result As New List(Of TResult)(left.Count)
        Dim s = left.GetEnumerator
        Dim d = right.GetEnumerator

        Do While s.MoveNext
            If Not d.MoveNext Then Throw New ArgumentException("Right is smaller than left")
            result.Add(combiner(s.Current, d.Current))
        Loop
        Return result
    End Function

#If ClrVersion >= 35 Then
    ''' <summary>
    ''' This attempts to create a new list of the indicated type. This may fail due to casting.
    ''' For a safer version use OfType, which filters out items that cannot be cast.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function ToList(Of T)(ByVal this As IList) As List(Of T)
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return (From item As Object In this Select CType(item, T)).ToList
    End Function

    ''' <summary>
    ''' This calls ToString on each element in the list, then joins them on the seperator
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="separator"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function StringJoin(Of T)(ByVal this As IList(Of T), ByVal separator As String) As String
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Dim temp As New List(Of String)(this.Count)
        For Each item In this
            temp.Add(item.ToString)
        Next
        Return temp.Join(separator)
    End Function



    ''' <summary>
    ''' This converts each item in the list to a string using the supplied format function, then joins them on the separator
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="separator"></param>
    ''' <param name="formatter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function StringJoin(Of T)(ByVal this As IList(Of T), ByVal separator As String, ByVal formatter As Func(Of T, String)) As String
        If this Is Nothing Then Throw New ArgumentNullException("this")
        If formatter Is Nothing Then Throw New ArgumentNullException("formatter")

        Dim temp As New List(Of String)(this.Count)
        For Each item In this
            temp.Add(formatter(item))
        Next
        Return temp.Join(separator)
    End Function

#End If


    ''' <summary>
    ''' This determines if a specified sequence is contained in the source list.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="pattern"></param>
    ''' <returns>The starting index of the pattern in the list, or -1 if not found</returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function IndexOfSequence(Of T)(ByVal this As IList(Of T), ByVal pattern As IList(Of T)) As Integer
        If this Is Nothing Then Throw New ArgumentNullException("this")
        If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
        If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")


        For startIndex = 0 To this.Count - (pattern.Count)
            If Object.Equals(this(startIndex), pattern(0)) Then    'check the full pattern
                Dim PatternFailed = False
                For patternIndex = 1 To pattern.Count - 1
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

    ''' <summary>
    ''' This determines if a specified sequence is contained in the source list.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="pattern"></param>
    ''' <returns>The starting index of the pattern in the list, or -1 if not found</returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function IndexOfSequence(Of T)(ByVal this As IList(Of T), ByVal ParamArray pattern() As T) As Integer
        If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
        If pattern.Length = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")

        Return IndexOfSequence(this, CType(pattern, IList(Of T)))
    End Function

    ''' <summary>
    ''' This determines if a specified sequence is contained in the source list.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="comparer">A custom comparer used to determine if two elements are equal</param>
    ''' <param name="pattern"></param>
    ''' <returns>The starting index of the pattern in the list, or -1 if not found</returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function IndexOfSequence(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal pattern As IList(Of T)) As Integer
        If comparer Is Nothing Then Throw New ArgumentNullException("comparer")
        If this Is Nothing Then Return -1
        If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
        If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")



        For startIndex = 0 To this.Count - (pattern.Count)
            If comparer.Equals(this(startIndex), pattern(0)) Then      'check the full pattern
                Dim PatternFailed = False
                For patternIndex = 1 To pattern.Count - 1
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

    ''' <summary>
    ''' This determines if a specified sequence is contained in the source list.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="comparer">A custom comparer used to determine if two elements are equal</param>
    ''' <param name="pattern"></param>
    ''' <returns>The starting index of the pattern in the list, or -1 if not found</returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function IndexOfSequence(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal ParamArray pattern() As T) As Integer
        If comparer Is Nothing Then Throw New ArgumentNullException("comparer")
        If this Is Nothing Then Return -1
        If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
        If pattern.Length = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")

        Return IndexOfSequence(this, comparer, CType(pattern, IList(Of T)))
    End Function

    ''' <summary>
    ''' This determines if the source list starts with the specified sequence
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="comparer">A custom comparer used to determine if two elements are equal</param>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function StartsWith(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal pattern As IList(Of T)) As Boolean
        If this Is Nothing Then Throw New ArgumentNullException("this")
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

    ''' <summary>
    ''' This determines if the source list starts with the specified sequence
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function StartsWith(Of T)(ByVal this As IList(Of T), ByVal pattern As IList(Of T)) As Boolean
        If this Is Nothing Then Throw New ArgumentNullException("this")
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

    ''' <summary>
    ''' This determines if the source list ends with the specified sequence
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="comparer">A custom comparer used to determine if two elements are equal</param>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function EndsWith(Of T)(ByVal source As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal pattern As IList(Of T)) As Boolean
        If source Is Nothing Then Throw New ArgumentNullException("source")
        If comparer Is Nothing Then Throw New ArgumentNullException("comparer")
        If pattern Is Nothing Then Throw New ArgumentNullException("pattern")
        If pattern.Count = 0 Then Throw New ArgumentException("pattern cannot be empty", "pattern")

        If pattern.Count > source.Count Then Return False

        Dim startIndex = source.Count - pattern.Count
        For patternIndex = 0 To pattern.Count - 1
            If Not comparer.Equals(source(startIndex + patternIndex), pattern(patternIndex)) Then
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' This determines if the source list ends with the specified sequence
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function EndsWith(Of T)(ByVal this As IList(Of T), ByVal pattern As IList(Of T)) As Boolean
        If this Is Nothing Then Throw New ArgumentNullException("this")
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

    ''' <summary>
    ''' This determines if the source list ends with the specified sequence
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function EndsWith(Of T)(ByVal this As IList(Of T), ByVal ParamArray pattern() As T) As Boolean
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return EndsWith(this, CType(pattern, IList(Of T)))
    End Function

    ''' <summary>
    ''' This determines if the source list ends with the specified sequence
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="comparer">A custom comparer used to determine if two elements are equal</param>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function EndsWith(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal ParamArray pattern() As T) As Boolean
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return EndsWith(this, comparer, CType(pattern, IList(Of T)))
    End Function

    ''' <summary>
    ''' This determines if the source list starts with the specified sequence
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function StartsWith(Of T)(ByVal this As IList(Of T), ByVal ParamArray pattern() As T) As Boolean
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return StartsWith(this, CType(pattern, IList(Of T)))
    End Function

    ''' <summary>
    ''' This determines if the source list starts with the specified sequence
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="comparer">A custom comparer used to determine if two elements are equal</param>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function StartsWith(Of T)(ByVal this As IList(Of T), ByVal comparer As IEqualityComparer(Of T), ByVal ParamArray pattern() As T) As Boolean
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return StartsWith(this, comparer, CType(pattern, IList(Of T)))
    End Function

    ''' <summary>
    ''' This returns a list of indexes where the element passes the where clause 
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="where">Predicate to execute on each method</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function IndexesWhere(Of T)(ByVal source As IList(Of T), ByVal where As Func(Of T, Boolean)) As List(Of Integer)
        If source Is Nothing Then Throw New ArgumentNullException("source")
        If where Is Nothing Then Throw New ArgumentNullException("where")

        Dim result As New List(Of Integer)
        For i = 0 To source.Count - 1
            If where(source(i)) Then result.Add(i)
        Next
        Return result
    End Function

    ''' <summary>
    ''' This returns every Nth item in the list
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="startIndex"></param>
    ''' <param name="skip"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()>  <Extension()>  Function TakeEvery(Of T)(ByVal source As IList(Of T), ByVal startIndex As Integer, ByVal skip As Integer) As List(Of T)
        If source Is Nothing Then Throw New ArgumentNullException("source")
        If skip < 1 Then Throw New ArgumentOutOfRangeException("skip")

        Dim result As New List(Of T)
        For i = startIndex To source.Count - 1 Step skip
            result.Add(source(i))
        Next
        Return result
    End Function

    ''' <summary>
    ''' This inserts a list of values into the target list at the specified point
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="target"></param>
    ''' <param name="index"></param>
    ''' <param name="source"></param>
    ''' <remarks></remarks>
     <Extension()> Sub InsertRange(Of T)(ByVal target As IList(Of T), ByVal index As Integer, ByVal source As IEnumerable(Of T))
        If target Is Nothing Then Throw New ArgumentNullException("target")
        If source Is Nothing Then Throw New ArgumentNullException("source")
        If index < 0 Then Throw New ArgumentOutOfRangeException("index")

        Dim currentIndex = index
        For Each item In source
            target.Insert(currentIndex, item)
            currentIndex += 1
        Next

    End Sub


End Module

#End If
