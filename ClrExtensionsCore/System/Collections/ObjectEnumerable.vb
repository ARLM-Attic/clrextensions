<Obsolete("Untested")> Friend Class ObjectEnumerable
	Implements IEnumerable(Of Object)
	Private m_Source As IEnumerable

	Public Sub New(ByVal souce As IEnumerable)
		m_Source = souce
	End Sub

	Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Object) Implements System.Collections.Generic.IEnumerable(Of Object).GetEnumerator
		Return New ObjectEnumerator(m_Source.GetEnumerator)
	End Function

	Private Function IEnumerable_GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		Return m_Source.GetEnumerator
	End Function
End Class
