'Copyright (c) 2008, Jonathan Allen

#If 1 = 1 Then
Imports ClrExtensions.Collections
Imports System.Data
Imports ClrExtensions.Data

Namespace Data
    Friend Class DataReaderEnumerable
        Implements IEnumerable(Of IDataRecord)

        Private ReadOnly m_Source As IDataReader

        
                 Sub New(ByVal source As IDataReader)
            If source Is Nothing Then Throw New ArgumentNullException("source")

            m_Source = source
        End Sub

        
                 Function GetEnumerator() As IEnumerator(Of Global.System.Data.IDataRecord) Implements IEnumerable(Of Global.System.Data.IDataRecord).GetEnumerator

            Return New DataReaderEnumerator(m_Source)
        End Function

        
                Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator

            Return New DataReaderEnumerator(m_Source)
        End Function
    End Class
End Namespace
#End If
