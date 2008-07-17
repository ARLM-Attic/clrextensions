#If IncludeUntested Then

Imports ClrExtensions.System.Collections

Module Scratch
	Sub test()
	End Sub




End Module

Module ActionExtensions

	<Untested()> <Extension()> Public Sub Repeat(ByVal action As Action, ByVal occurances As Integer)
		For i = 0 To occurances
			action.Invoke()
		Next
	End Sub

	<Untested()> <Extension()> Public Sub Repeat(ByVal action As Action(Of Integer), ByVal occurances As Integer)
		For i = 0 To occurances
			action.Invoke(i)
		Next
	End Sub

End Module

Module DirectoryInfo
	<Untested()> <Extension()> Public Sub CopyTo(ByVal source As IO.DirectoryInfo, ByVal target As IO.DirectoryInfo, ByVal recursive As Boolean, ByVal overwrite As Boolean)
		If source Is Nothing Then Throw New ArgumentNullException("source")
		If target Is Nothing Then Throw New ArgumentNullException("target")
		target.Create()

		For Each file In source.GetFiles
			file.CopyTo(IO.Path.Combine(target.FullName, file.Name), overwrite)
		Next
		If recursive Then
			For Each directory In source.GetDirectories
				Dim childTarget As New IO.DirectoryInfo(IO.Path.Combine(target.FullName, directory.Name))
				childTarget.Create()
				childTarget.CopyTo(childTarget, recursive, overwrite)
			Next
		End If
	End Sub




End Module

Module FuncExtension

	<Untested()> <Extension()> Public Function ToPredicate(Of T)(ByVal func As Func(Of T, Boolean)) As Predicate(Of T)
		Dim result As Predicate(Of T) = Function(item) func.Invoke(item)
		Return result
	End Function

	''' <summary>
	''' This creates a function that memorizes every argument/result pair in order to speed up repeated, lengthy calculations. 
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <typeparam name="TResult"></typeparam>
	''' <param name="func"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function Memorize(Of T, TResult)(ByVal func As Func(Of T, TResult)) As Func(Of T, TResult)
		Dim dataStore As New Dictionary(Of T, TResult)

		Dim result As Func(Of T, TResult) = Function(a) If(dataStore.ContainsKey(a), dataStore(a), StoreAndReturn(dataStore, a, func(a)))
		Return result
	End Function

	Private Function StoreAndReturn(Of TKey, TValue)(ByVal dictionary As Dictionary(Of TKey, TValue), ByVal key As TKey, ByVal value As TValue) As TValue
		dictionary(key) = value
		Return value
	End Function

	<Untested()> <Extension()> Public Function Memorize(Of T1, T2, TResult)(ByVal func As Func(Of T1, T2, TResult)) As Func(Of T1, T2, TResult)
		Dim dataStore As New Dictionary(Of T1, T2, TResult)

		Dim result As Func(Of T1, T2, TResult) = Function(a, b) If(dataStore.ContainsKey(a, b), dataStore(a, b), dataStore.StoreAndReturn(a, b, func(a, b)))
		Return result
	End Function

	<Untested()> <Extension()> Public Function Memorize(Of T1, T2, T3, TResult)(ByVal func As Func(Of T1, T2, T3, TResult)) As Func(Of T1, T2, T3, TResult)
		Dim dataStore As New Dictionary(Of T1, T2, T3, TResult)

		Dim result As Func(Of T1, T2, T3, TResult) = Function(a, b, c) If(dataStore.ContainsKey(a, b, c), dataStore(a, b, c), dataStore.StoreAndReturn(a, b, c, func(a, b, c)))
		Return result
	End Function

End Module


Module PredicateExtension
	<Untested()> <Extension()> Public Function ToFunction(Of T)(ByVal predicate As Predicate(Of T)) As Func(Of T, Boolean)
		Dim result As Func(Of T, Boolean) = Function(item) predicate.Invoke(item)
		Return result
	End Function
End Module





Module StreamExtension
	<Untested()> <Extension()> Function ToStreamReader(ByVal source As IO.Stream) As IO.StreamReader
		Return New IO.StreamReader(source)
	End Function

	<Untested()> <Extension()> Function ToStreamReader(ByVal source As IO.Stream, ByVal encoding As Text.Encoding) As IO.StreamReader
		Return New IO.StreamReader(source, encoding)
	End Function

	<Untested()> <Extension()> Function ToStreamWriter(ByVal source As IO.Stream) As IO.StreamWriter
		Return New IO.StreamWriter(source)
	End Function

	<Untested()> <Extension()> Function ToStreamWriter(ByVal source As IO.Stream, ByVal encoding As Text.Encoding) As IO.StreamWriter
		Return New IO.StreamWriter(source, encoding)
	End Function

End Module

#End If
