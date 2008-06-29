
Public Module IDictionaryExtension

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
