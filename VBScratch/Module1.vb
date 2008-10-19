Imports ClrExtensions
Imports System.Runtime.CompilerServices

Module Module1

	Sub Main()
		Const STR_HiFrankWasHere As String = "Hi! frank was here."
		Dim a = System.Web.HttpUtility.UrlEncode(STR_HiFrankWasHere)
		Dim b = ClrExtensions.Security.OAuth.UrlEncode(STR_HiFrankWasHere)
		Dim c = ClrExtensions.UrlEncode(STR_HiFrankWasHere, UrlEncodingMethod.Clr)
		Dim d = ClrExtensions.UrlEncode(STR_HiFrankWasHere, UrlEncodingMethod.OAuth)

		Console.WriteLine(a)
		Console.WriteLine(b)
		Console.WriteLine(c)
		Console.WriteLine(d)



		'#If IncludeUntested Then

		'		Dim result = (New Object(,) {{"foo", 1}, {"bar", 2}, {"baz", 3}}).ToList
		'#End If

		'		Try
		'			For Each item In MathExtension.Primes
		'				Console.WriteLine(item)
		'			Next
		'		Catch ex As Exception
		'			Console.WriteLine(ex)
		'			Console.ReadLine()
		'		End Try





		'		Dim z As Action(Of Integer) = Function(a As Integer) Console.WriteLine(a)

		'		Dim x = New Integer() {1, 2, 5, 7, 8, 4, 2324, 23}
		'		x.ForEach(x, (Function(a As Integer) Console.WriteLine(x)))
	End Sub

#If IncludeUntested Then
	<Extension()> Public Function ToList(Of T)(ByVal source As T(,)) As List(Of T())
		Dim result As New List(Of T())

		For Each item In source.ToJagged
			result.Add(item)
		Next

		Return result

	End Function
#End If

	<extension()> Public Function ToDataTable(ByVal table As Object(,)) As DataTable
		Dim result As New DataTable

		For i = 0 To table.GetUpperBound(1)
			result.Columns.Add()
		Next
		For i = 0 To table.GetUpperBound(0)
			Dim row = result.NewRow
			For j = 0 To table.GetUpperBound(1)
				row(j) = table(i, j)
			Next
			result.Rows.Add(row)
		Next
		Return result
	End Function

End Module
