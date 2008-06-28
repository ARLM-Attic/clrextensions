
Friend Class TypeEnumerator(Of T)
	Implements IEnumerator(Of T)

	Private m_Source As IEnumerator

	Public Sub New(ByVal souce As IEnumerator)
		m_Source = souce
	End Sub

	Public ReadOnly Property Current() As T Implements System.Collections.Generic.IEnumerator(Of T).Current
		Get
			Return CType(m_Source.Current, T)
		End Get
	End Property

	Public ReadOnly Property IEnumerator_Current() As Object Implements System.Collections.IEnumerator.Current
		Get
			Return m_Source.Current
		End Get
	End Property

	Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
		Return m_Source.MoveNext
	End Function

	Public Sub Reset() Implements System.Collections.IEnumerator.Reset
		m_Source.Reset()
	End Sub

	Private disposedValue As Boolean = False		' To detect redundant calls

	' IDisposable
	Protected Overridable Sub Dispose(ByVal disposing As Boolean)
		If Not Me.disposedValue Then
			If disposing Then
				Dim temp = TryCast(m_Source, IDisposable)
				If temp IsNot Nothing Then temp.Dispose()
			End If

			' TODO: free your own state (unmanaged objects).
			' TODO: set large fields to null.
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
