'Copyright (c) 2008, Jonathan Allen

#If IncludeUntested Then
Namespace System.Collections

    <Untested()> Friend Class TypeEnumerator(Of T)
        Implements IEnumerator(Of T)

        Private m_Source As IEnumerator

        Public Sub New(ByVal souce As IEnumerator)
            m_Source = souce
        End Sub

        Public ReadOnly Property Current() As T Implements IEnumerator(Of T).Current
            Get
                Return CType(m_Source.Current, T)
            End Get
        End Property

        Public ReadOnly Property IEnumerator_Current() As Object Implements IEnumerator.Current
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

        ' IDisposable
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
End Namespace

#End If
