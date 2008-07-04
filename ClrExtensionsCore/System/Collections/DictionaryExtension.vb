
Public Module DictionaryExtension

	<Extension()> Function Keys(ByVal this As IDictionaryEnumerator) As Collections.ObjectModel.Collection(Of Object)
		Dim result As New Collections.ObjectModel.Collection(Of Object)
		Do While this.MoveNext
			result.Add(this.Key)
		Loop
		Return result
	End Function

	<Extension()> Function Values(ByVal this As IDictionaryEnumerator) As Collections.ObjectModel.Collection(Of Object)
		Dim result As New Collections.ObjectModel.Collection(Of Object)
		Do While this.MoveNext
			result.Add(this.Value)
		Loop
		Return result
	End Function

	<Extension()> Function Entries(ByVal this As IDictionaryEnumerator) As Collections.ObjectModel.Collection(Of DictionaryEntry)
		Dim result As New Collections.ObjectModel.Collection(Of Collections.DictionaryEntry)
		Do While this.MoveNext
			result.Add(this.Entry)
		Loop
		Return result
	End Function


	<Extension()> Function Keys(Of T)(ByVal this As IDictionaryEnumerator) As Collections.ObjectModel.Collection(Of T)
		Dim result As New Collections.ObjectModel.Collection(Of T)
		Do While this.MoveNext
			result.Add(CType(this.Key, T))
		Loop
		Return result
	End Function

	<Extension()> Function ToDictionary(Of TKey, TValue)(ByVal this As IEnumerable(Of KeyValuePair(Of TKey, TValue))) As Dictionary(Of TKey, TValue)
		Return this.ToDictionary(Function(item) item.Key, Function(item) item.Value)
	End Function

	<Extension()> Public Function StringJoin(ByVal this As IDictionary(Of String, String), ByVal rowSeparator As String, ByVal columnSeparator As String) As String

		Dim temp As New List(Of String)(this.Count)

		For Each item In this
			temp.Add(item.Key & columnSeparator & item.Value)
		Next
		Return temp.Join(rowSeparator)
	End Function


	<Extension()> Public Function StringJoin(ByVal this As IDictionary(Of String, String), ByVal separator As String) As String

		Dim temp As New List(Of String)(this.Count * 2)

		For Each item In this
			temp.Add(item.Key)
			temp.Add(item.Value)
		Next
		Return temp.Join(separator)
	End Function

	<Extension()> Public Function GetValue(Of T)(ByVal this As IDictionary, ByVal key As Object) As T
		Dim temp As Object = this(key)
		Return If(temp IsNot Nothing, CType(temp, T), Nothing)
	End Function

	<Extension()> Public Function GetValue(Of T)(ByVal this As IDictionary, ByVal key As Object, ByVal [default] As T) As T
		Dim temp As Object = this(key)
		Return If(temp IsNot Nothing, CType(temp, T), [default])
	End Function


End Module
