'Copyright (c) 2008, Jonathan Allen

#If IncludeUntested Then
Imports ClrExtensions.Collections
Imports System.Data
Imports ClrExtensions.Data

Namespace Data
	Friend Class DataReaderEnumerator
		Implements IEnumerator(Of IDataRecord)

		Private m_Source As IDataReader

        <Untested()>
        Public Sub New(ByVal source As IDataReader)
            m_Source = source
        End Sub

        <Untested()>
        Public ReadOnly Property Current() As Global.System.Data.IDataRecord Implements IEnumerator(Of IDataRecord).Current
            Get
                Return m_Source
            End Get
        End Property

        <Untested()>
        Private ReadOnly Property IEnumerator_Current() As Object Implements IEnumerator.Current
            Get
                Return m_Source
            End Get
        End Property

        <Untested()>
        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            Return m_Source.Read
        End Function

        <Untested()>
        Private Sub Reset() Implements IEnumerator.Reset
            Throw New NotSupportedException
        End Sub

		Private m_Disposed As Boolean

        <Untested()>
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.m_Disposed Then
                If disposing Then
                    m_Source.Dispose()
                End If
            End If
            Me.m_Disposed = True
        End Sub

        <Untested()>
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

	End Class
End Namespace
#End If