'Copyright (c) 2008, Jonathan Allen

#If 1 = 1 Then
Imports ClrExtensions.Collections
Imports System.Data
Imports ClrExtensions.Data

Namespace Data
	Friend Class DataReaderEnumerator
		Implements IEnumerator(Of IDataRecord)

        Private ReadOnly m_Source As IDataReader

        
                 Sub New(ByVal source As IDataReader)
            If source Is Nothing Then Throw New ArgumentNullException("source")

            m_Source = source
        End Sub

        
                 ReadOnly Property Current() As Global.System.Data.IDataRecord Implements IEnumerator(Of IDataRecord).Current
            Get
                Return m_Source
            End Get
        End Property

        
        Private ReadOnly Property IEnumerator_Current() As Object Implements IEnumerator.Current
                        Get
                Return m_Source
            End Get
        End Property

        
         Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            Return m_Source.Read
        End Function

        
        Private Sub Reset() Implements IEnumerator.Reset
            Throw New NotSupportedException
        End Sub

		Private m_Disposed As Boolean

        
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.m_Disposed Then
                If disposing Then
                    m_Source.Dispose()
                End If
            End If
            Me.m_Disposed = True
        End Sub

        
         Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

	End Class
End Namespace
#End If