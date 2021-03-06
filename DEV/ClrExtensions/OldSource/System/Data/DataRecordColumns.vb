'Copyright (c) 2008, Jonathan Allen

#If IncludeUntested Then

Imports ClrExtensions.Collections
Imports System.Data
Imports ClrExtensions.Data

Namespace Data
	Friend Class DataRecordColumns
		Private m_Names As List(Of String)
		Private m_TypeNames As List(Of String)
		Private m_Types As List(Of Type)

        <Untested()>
        Public Sub New(ByVal source As IDataRecord)
            For i = 0 To source.FieldCount - 1
                m_Names.Add(source.GetName(i))
                m_TypeNames.Add(source.GetDataTypeName(i))
                m_Types.Add(source.GetFieldType(i))
            Next
        End Sub

        <Untested()>
        Friend Function GetOrdinal(ByVal name As String) As Integer
            For i As Integer = 0 To m_Names.Count - 1
                If m_Names(i).Equals(name, StringComparison.InvariantCultureIgnoreCase) Then Return i
            Next
            Throw New ArgumentOutOfRangeException("name")
        End Function

        <Untested()>
        Friend Function GetDataTypeName(ByVal i As Integer) As String
            Return m_TypeNames(i)
        End Function

        <Untested()>
        Friend Function GetFieldType(ByVal i As Integer) As Type
            Return m_Types(i)
        End Function

        <Untested()>
        Friend Function GetName(ByVal i As Integer) As String
            Return m_Names(i)
        End Function
	End Class
End Namespace
#End If