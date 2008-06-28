
Public Module ObjectExtension

	''' <summary>
	''' Creates a text dump of the object and its properties to an unlimited depth.
	''' </summary>
	''' <param name="this"></param>
	''' <returns></returns>
	''' <remarks>This tracks the object graph to prevent circular references</remarks>
	<Extension()> Function ToDebugString(ByVal this As Object) As String
		Dim result As New Text.StringBuilder
		Dim graph As New List(Of Object)

		DebugString(Nothing, this, result, 0, graph)
		Return result.ToString

	End Function

	Private Sub DebugString(ByVal propertyName As String, ByVal current As Object, ByVal result As Text.StringBuilder, ByVal depth As Integer, ByVal graph As List(Of Object))

		'TODO: Add support for Collections and Dictionaries
		'TODO: Add support formatting for well known types
		'TODO: Add support for public variables

		Dim header As String = If(propertyName = "", "", vbTab.Repeat(depth) & propertyName & ": ")

		If current Is Nothing Then
			result.AppendLine(header & "<NULL>")

		ElseIf TypeOf current Is String Then
			result.AppendLine(header & current.ToString)

		ElseIf TypeOf current Is SByte Then
			result.AppendLine(header & current.ToString)
		ElseIf TypeOf current Is Short Then
			result.AppendLine(header & current.ToString)
		ElseIf TypeOf current Is Integer Then
			result.AppendLine(header & current.ToString)
		ElseIf TypeOf current Is Long Then
			result.AppendLine(header & current.ToString)


		ElseIf TypeOf current Is Byte Then
			result.AppendLine(header & current.ToString)
		ElseIf TypeOf current Is UInt16 Then
			result.AppendLine(header & current.ToString)
		ElseIf TypeOf current Is UInt32 Then
			result.AppendLine(header & current.ToString)
		ElseIf TypeOf current Is UInt64 Then
			result.AppendLine(header & current.ToString)

		ElseIf TypeOf current Is Single Then
			result.AppendLine(header & current.ToString)
		ElseIf TypeOf current Is Double Then
			result.AppendLine(header & current.ToString)
		ElseIf TypeOf current Is Decimal Then
			result.AppendLine(header & current.ToString)

		ElseIf TypeOf current Is Date Then
			result.AppendLine(header & current.ToString)
			'TODO If DateTime.Kind is set, include that in this output

		ElseIf TypeOf current Is DateTimeOffset Then
			result.AppendLine(header & current.ToString)

		ElseIf TypeOf current Is Boolean Then
			result.AppendLine(header & current.ToString)

		ElseIf TypeOf current Is ValueType Then
			'Value types don't get added to the graph, they cannot be circular and would just be boxed anyways
			result.AppendLine(header & current.GetType.Name)

			DebugStringProperties(propertyName, current, result, depth, graph)


		Else
			Dim refIndex = graph.IndexOf(current)
			If refIndex > -1 Then 'previously visited
				result.AppendLine(header & current.GetType.Name & " (ref " & refIndex & ")")
			Else
				result.AppendLine(header & current.GetType.Name & " (id " & graph.Count & ")")
				graph.Add(current)

				DebugStringProperties(propertyName, current, result, depth, graph)
			End If
		End If




	End Sub

	Private Sub DebugStringProperties(ByVal propertyName As String, ByVal current As Object, ByVal result As Text.StringBuilder, ByVal depth As Integer, ByVal graph As List(Of Object))
		For Each prop In current.GetType.GetProperties.OrderBy(Function(p) p.Name)
			If prop.CanRead AndAlso prop.GetGetMethod.GetParameters.Count = 0 Then
				Try
					DebugString(prop.Name, prop.GetValue(current, Nothing), result, depth + 1, graph)
				Catch ex As Exception
					result.AppendLine(vbTab.Repeat(depth + 1) & propertyName & ": ???")
				End Try
			Else
				result.AppendLine(vbTab.Repeat(depth + 1) & propertyName & ": ???")
			End If
		Next
	End Sub

	<Extension()> Public Function DeepCopy(Of T)(ByVal this As T) As T
		If Not this.GetType.IsSerializable Then Throw New ArgumentException("Only serializable types can be copied")

		Dim memoryStream = New IO.MemoryStream()
		Dim binaryFormatter = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

		binaryFormatter.Serialize(memoryStream, this)
		memoryStream.Seek(0, IO.SeekOrigin.Begin)

		Return DirectCast(binaryFormatter.Deserialize(memoryStream), T)
	End Function

	'TODO - Convert the object to XML using an XML Serializer
	'<Extension()> Public Function ToXDocument(ByVal this As Object) As XDocument


End Module