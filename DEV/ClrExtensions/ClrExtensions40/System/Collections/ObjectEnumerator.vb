'Copyright (c) 2008, Jonathan Allen

Imports ClrExtensions.Collections

Namespace Collections

#If 1 = 1 Then

    Friend Class ObjectEnumerator
        Implements IEnumerator(Of Object)

        Private ReadOnly m_Source As IEnumerator

        
                 Sub New(ByVal source As IEnumerator)
            If source Is Nothing Then Throw New ArgumentNullException("source")

            m_Source = source
        End Sub

        
                 ReadOnly Property Current() As Object Implements IEnumerator(Of Object).Current
            Get
                Return m_Source.Current
            End Get
        End Property

        
                Private ReadOnly Property IEnumerator_Current() As Object Implements IEnumerator.Current
            Get
                Return m_Source.Current
            End Get
        End Property

        
         Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            Return m_Source.MoveNext
        End Function

        
         Sub Reset() Implements IEnumerator.Reset
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

        
         Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

    End Class
#End If
End Namespace
