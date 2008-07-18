#If IncludeUntested Then

Public Module DictionaryExtension

    <Untested()> <Extension()> Sub ForEachs(Of TKey, TValue)(ByVal source As IDictionary(Of TKey, TValue), ByVal action As Action(Of TKey, TValue))
        For Each item In source
            action.Invoke(item.Key, item.Value)
        Next
    End Sub

    <Untested()> <Extension()> Function Keys(ByVal this As IDictionaryEnumerator) As Collections.ObjectModel.Collection(Of Object)
        Dim result As New Collections.ObjectModel.Collection(Of Object)
        Do While this.MoveNext
            result.Add(this.Key)
        Loop
        Return result
    End Function

    <Untested()> <Extension()> Function Values(ByVal this As IDictionaryEnumerator) As Collections.ObjectModel.Collection(Of Object)
        Dim result As New Collections.ObjectModel.Collection(Of Object)
        Do While this.MoveNext
            result.Add(this.Value)
        Loop
        Return result
    End Function

    <Untested()> <Extension()> Function Entries(ByVal this As IDictionaryEnumerator) As Collections.ObjectModel.Collection(Of DictionaryEntry)
        Dim result As New Collections.ObjectModel.Collection(Of Collections.DictionaryEntry)
        Do While this.MoveNext
            result.Add(this.Entry)
        Loop
        Return result
    End Function


    <Untested()> <Extension()> Function Keys(Of T)(ByVal this As IDictionaryEnumerator) As Collections.ObjectModel.Collection(Of T)
        Dim result As New Collections.ObjectModel.Collection(Of T)
        Do While this.MoveNext
            result.Add(CType(this.Key, T))
        Loop
        Return result
    End Function

    <Untested()> <Extension()> Function ToDictionary(Of TKey, TValue)(ByVal this As IEnumerable(Of KeyValuePair(Of TKey, TValue))) As Dictionary(Of TKey, TValue)
        Return this.ToDictionary(Function(item) item.Key, Function(item) item.Value)
    End Function

    <Untested()> <Extension()> Public Function StringJoin(ByVal this As IDictionary(Of String, String), ByVal rowSeparator As String, ByVal columnSeparator As String) As String

        Dim temp As New List(Of String)(this.Count)

        For Each item In this
            temp.Add(item.Key & columnSeparator & item.Value)
        Next
        Return temp.Join(rowSeparator)
    End Function


    <Untested()> <Extension()> Public Function StringJoin(ByVal this As IDictionary(Of String, String), ByVal separator As String) As String

        Dim temp As New List(Of String)(this.Count * 2)

        For Each item In this
            temp.Add(item.Key)
            temp.Add(item.Value)
        Next
        Return temp.Join(separator)
    End Function

    <Untested()> <Extension()> Public Function GetValue(Of T)(ByVal this As IDictionary, ByVal key As Object) As T
        Dim temp As Object = this(key)
        Return If(temp IsNot Nothing, CType(temp, T), Nothing)
    End Function

    <Untested()> <Extension()> Public Function GetValue(Of T)(ByVal this As IDictionary, ByVal key As Object, ByVal [default] As T) As T
        Dim temp As Object = this(key)
        Return If(temp IsNot Nothing, CType(temp, T), [default])
    End Function


    <Untested()> <Extension()> Public Function ToDictionary(ByVal source As String, ByVal rowSeparator As String, ByVal columnSeparator As String) As Dictionary(Of String, String)
        If rowSeparator = columnSeparator Then Return ToDictionary(source, rowSeparator)

        Dim result As New Dictionary(Of String, String)
        Dim rows = source.Split(rowSeparator, StringSplitOptions.RemoveEmptyEntries)

        For Each pair In rows.Select(Function(s) s.Split(columnSeparator, 2))
            If pair.Length = 2 Then result.Add(pair(0), pair(1)) Else result.Add(pair(0), "")
        Next

        Return result
    End Function

    <Untested()> <Extension()> Public Function ToDictionary(ByVal source As String, ByVal separator As String) As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)
        Dim rows = source.Split(separator)

        If rows.Count Mod 2 <> 0 Then Throw New FormatException("This contains an odd number of entries")
        For i = 0 To rows.Count - 1 Step 2
            result.Add(rows(i), rows(i + 1))
        Next

        Return result
    End Function

End Module
#End If