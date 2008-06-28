
Public Module IDictionaryEnumeratorExtension

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


End Module
