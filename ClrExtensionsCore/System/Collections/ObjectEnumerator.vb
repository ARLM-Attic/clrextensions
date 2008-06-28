
Friend Class ObjectEnumerator
	Implements IEnumerator(Of Object)

	Private m_Source As IEnumerator

	Public Sub New(ByVal source As IEnumerator)
		m_Source = source
	End Sub

	Public ReadOnly Property Current() As Object Implements System.Collections.Generic.IEnumerator(Of Object).Current
		Get
			Return m_Source.Current
		End Get
	End Property

	Private ReadOnly Property IEnumerator_Current() As Object Implements System.Collections.IEnumerator.Current
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

	Protected Overridable Sub Dispose(ByVal disposing As Boolean)
		If Not Me.disposedValue Then
			If disposing Then
				Dim temp = TryCast(m_Source, IDisposable)
				If temp IsNot Nothing Then temp.Dispose()
			End If
		End If
		Me.disposedValue = True
	End Sub

	' This code added by Visual Basic to correctly implement the disposable pattern.
	Public Sub Dispose() Implements IDisposable.Dispose
		' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
		Dispose(True)
		GC.SuppressFinalize(Me)
	End Sub

End Class
