

Public Module IListExtension

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



End Module






