'Copyright (c) 2008, Jonathan Allen

Imports ClrExtensions.System.Collections

Namespace System.Collections

#If IncludeUntested Then

	<Untested()> Friend Class ObjectEnumerator
		Implements IEnumerator(Of Object)

		Private m_Source As IEnumerator

		Public Sub New(ByVal source As IEnumerator)
			m_Source = source
		End Sub

		Public ReadOnly Property Current() As Object Implements IEnumerator(Of Object).Current
			Get
				Return m_Source.Current
			End Get
		End Property

		Private ReadOnly Property IEnumerator_Current() As Object Implements IEnumerator.Current
			Get
				Return m_Source.Current
			End Get
		End Property

		Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
			Return m_Source.MoveNext
		End Function

		Public Sub Reset() Implements IEnumerator.Reset
			m_Source.Reset()
		End Sub

		Private m_Disposed As Boolean

		Protected Overridable Sub Dispose(ByVal disposing As Boolean)
			If Not Me.m_Disposed Then
				If disposing Then
					Dim temp = TryCast(m_Source, IDisposable)
					If temp IsNot Nothing Then temp.Dispose()
				End If
			End If
			Me.m_Disposed = True
		End Sub

		Public Sub Dispose() Implements IDisposable.Dispose
			Dispose(True)
			GC.SuppressFinalize(Me)
		End Sub

	End Class
#End If
End Namespace
