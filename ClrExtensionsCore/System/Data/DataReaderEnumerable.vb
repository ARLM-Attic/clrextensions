#If IncludeUntested Then
Imports ClrExtensions.System.Collections
Imports System.Data
Imports ClrExtensions.System.Data

Namespace System.Data
	<Untested()> Friend Class DataReaderEnumerable
		Implements IEnumerable(Of IDataRecord)

		Private m_Source As IDataReader

		Public Sub New(ByVal source As IDataReader)
			m_Source = source
		End Sub

		Public Function GetEnumerator() As IEnumerator(Of Global.System.Data.IDataRecord) Implements IEnumerable(Of Global.System.Data.IDataRecord).GetEnumerator
			Return New DataReaderEnumerator(m_Source)
		End Function

		Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
			Return New DataReaderEnumerator(m_Source)
		End Function
	End Class
End Namespace
#End If