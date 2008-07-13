Imports ClrExtensions.System.Collections

#If IncludeUntested Then
Namespace System.Collections

	<Untested()> Friend Class TypeEnumerable(Of T)
		Implements IEnumerable(Of T)

		Private m_Source As IEnumerable

		Public Sub New(ByVal souce As IEnumerable)
			m_Source = souce
		End Sub

		Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
			Return New TypeEnumerator(Of T)(m_Source.GetEnumerator)
		End Function

		Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
			Return m_Source.GetEnumerator
		End Function
	End Class

End Namespace
#End If