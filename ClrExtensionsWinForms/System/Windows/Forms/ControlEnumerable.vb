Imports System.Windows.Forms


<Obsolete("Untested")> Friend Class ControlEnumerable
	Implements IEnumerable(Of Control)

	Private m_Root As Control.ControlCollection

	Public Sub New(ByVal root As Control.ControlCollection)
		m_Root = root
	End Sub

	Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of System.Windows.Forms.Control) Implements System.Collections.Generic.IEnumerable(Of System.Windows.Forms.Control).GetEnumerator
		Return New ControlEnumerator(m_Root)
	End Function

	Private Function IEnumerable_GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		Return New ControlEnumerator(m_Root)
	End Function
End Class
