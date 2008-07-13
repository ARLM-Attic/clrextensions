Imports ClrExtensions.System.Collections
Namespace System.Collections
#If IncludeUntested Then


	<Untested()> Friend Class ObjectEnumerable
		Implements IEnumerable(Of Object)
		Private m_Source As IEnumerable

		Public Sub New(ByVal souce As IEnumerable)
			m_Source = souce
		End Sub

		Public Function GetEnumerator() As IEnumerator(Of Object) Implements IEnumerable(Of Object).GetEnumerator
			Return New ObjectEnumerator(m_Source.GetEnumerator)
		End Function

		Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
			Return m_Source.GetEnumerator
		End Function
	End Class

#End If
End Namespace