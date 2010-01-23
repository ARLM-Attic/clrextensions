'Copyright (c) 2008, Jonathan Allen

#If IncludeUntested Then
Imports ClrExtensions.Collections
Imports System.Data
Imports ClrExtensions.Data

Namespace Data
    Friend Class DataReaderEnumerable
        Implements IEnumerable(Of IDataRecord)

        Private ReadOnly m_Source As IDataReader

        <Untested()>
                 Sub New(ByVal source As IDataReader)
            If source Is Nothing Then Throw New ArgumentNullException("source")

            m_Source = source
        End Sub

        <Untested()>
                 Function GetEnumerator() As IEnumerator(Of Global.System.Data.IDataRecord) Implements IEnumerable(Of Global.System.Data.IDataRecord).GetEnumerator

            Return New DataReaderEnumerator(m_Source)
        End Function

        <Untested()>
                Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator

            Return New DataReaderEnumerator(m_Source)
        End Function
    End Class
End Namespace
#End If
