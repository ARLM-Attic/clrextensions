Public Module IEnumerableExtension

	<Extension()> Public Function ToIEnumerable(ByVal this As IEnumerable) As IEnumerable(Of Object)
		Return New ObjectEnumerable(this)
	End Function

	<Extension()> Public Function ToIEnumerable(Of T)(ByVal this As IEnumerable) As IEnumerable(Of T)
		Return New TypeEnumerable(Of T)(this)
	End Function

	<Extension()> Public Function ToDataTable(Of T)(ByVal this As IEnumerable(Of T)) As DataTable
		Dim result As New DataTable

		Dim props = (From p In GetType(T).GetProperties Where p.CanRead And p.GetGetMethod.GetParameters.Count = 0).ToList


		For Each prop In props
			result.Columns.Add(New DataColumn(prop.Name, prop.GetGetMethod.ReturnType))
		Next

		For Each item In this
			Dim row = result.NewRow
			For Each prop In props
				Try
					row(prop.Name) = prop.GetValue(item, Nothing)
				Catch ex As Exception
					'Errors are suppressed
				End Try
			Next
		Next

		Return result
	End Function

	<Extension()> Public Function ToDataTable(Of T)(ByVal this As IEnumerable(Of T), ByVal ParamArray properties() As String) As DataTable
		Dim result As New DataTable

		'Create the list of properties from the names
		Dim allProps = (From p In GetType(T).GetProperties Where p.CanRead And p.GetGetMethod.GetParameters.Count = 0).ToList

		Dim props As New List(Of Reflection.PropertyInfo)
		For Each name In properties
			Dim n = name
			Dim prop = allProps.First(Function(p) p.Name = n)
			If prop IsNot Nothing Then props.Add(prop) Else Throw New ArgumentException("The property " & name & " couldn't be found or isn't compatible with this function.")
		Next

		For Each prop In props
			result.Columns.Add(New DataColumn(prop.Name, prop.GetGetMethod.ReturnType))
		Next

		For Each item In this
			Dim row = result.NewRow
			For Each prop In props
				Try
					row(prop.Name) = prop.GetValue(item, Nothing)
				Catch ex As Exception
					'Errors are suppressed
				End Try
			Next
		Next

		Return result
	End Function

	<Extension()> Public Sub ForEach(Of T)(ByVal this As IEnumerable(Of T), ByVal action As Action(Of T))
		For Each item In this
			action(item)
		Next
	End Sub

	<Extension()> Public Sub ForEach(ByVal this As IEnumerable, ByVal action As Action(Of Object))
		For Each item In this
			action(item)
		Next
	End Sub

End Module





