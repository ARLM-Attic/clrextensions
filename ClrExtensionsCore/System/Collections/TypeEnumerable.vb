

Friend Class TypeEnumerable(Of T)
	Implements IEnumerable(Of T)

	Private m_Source As IEnumerable

	Public Sub New(ByVal souce As IEnumerable)
		m_Source = souce
	End Sub

	Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of T) Implements System.Collections.Generic.IEnumerable(Of T).GetEnumerator
		Return New TypeEnumerator(Of T)(m_Source.GetEnumerator)
	End Function

	Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		Return m_Source.GetEnumerator
	End Function
End Class
