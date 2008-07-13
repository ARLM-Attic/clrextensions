Imports System.Windows.Forms


<Untested()> Friend Class ControlEnumerator
	Implements IEnumerator(Of Control)

	Private m_Root As Control.ControlCollection
	Private m_Unvisited As New Queue(Of Control)
	Private m_Visited As New Queue(Of Control)
	Private m_Current As Control

	Public Sub New(ByVal root As Control.ControlCollection)
		m_Root = root
		Preload(m_Root)
	End Sub

	Private Sub Preload(ByVal controls As Control.ControlCollection)
		For Each item As Control In controls
			m_Unvisited.Enqueue(item)
		Next
	End Sub

	Public ReadOnly Property Current() As System.Windows.Forms.Control Implements System.Collections.Generic.IEnumerator(Of System.Windows.Forms.Control).Current
		Get
			Return m_Current
		End Get
	End Property

	Private ReadOnly Property IEnumerator_Current() As Object Implements System.Collections.IEnumerator.Current
		Get
			Return m_Current
		End Get
	End Property

	Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
		If m_Current IsNot Nothing Then m_Visited.Enqueue(m_Current)

		If m_Unvisited.Count = 0 Then 'we need to look at the next generation
			For Each control In m_Visited
				Preload(control.Controls)
			Next
			m_Visited.Clear()
		End If

		If m_Unvisited.Count > 0 Then
			m_Current = m_Unvisited.Dequeue
			Return True
		Else
			m_Current = Nothing
			Return False
		End If

	End Function

	Public Sub Reset() Implements System.Collections.IEnumerator.Reset
		m_Unvisited.Clear()
		m_Visited.Clear()
		m_Current = Nothing
		Preload(m_Root)
	End Sub

	Private disposedValue As Boolean = False		' To detect redundant calls

	' IDisposable
	Protected Overridable Sub Dispose(ByVal disposing As Boolean)
		If Not Me.disposedValue Then
			If disposing Then
				' TODO: free other state (managed objects).
			End If

			'we are freeing these variables so we don't accidentilly keep a large object graph in memory
			m_Root = Nothing
			m_Unvisited = Nothing
			m_Visited = Nothing
			m_Current = Nothing
		End If
		Me.disposedValue = True
	End Sub

#Region " IDisposable Support "
	' This code added by Visual Basic to correctly implement the disposable pattern.
	Public Sub Dispose() Implements IDisposable.Dispose
		' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
		Dispose(True)
		GC.SuppressFinalize(Me)
	End Sub
#End Region

End Class
