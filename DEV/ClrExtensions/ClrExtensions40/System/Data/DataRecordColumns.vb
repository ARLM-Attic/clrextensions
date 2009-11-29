'Copyright (c) 2008, Jonathan Allen

#If IncludeUntested Then

Imports ClrExtensions.Collections
Imports System.Data
Imports ClrExtensions.Data

Namespace Data
	Friend Class DataRecordColumns
        Private ReadOnly m_Names As New List(Of String)
        Private ReadOnly m_TypeNames As New List(Of String)
        Private ReadOnly m_Types As New List(Of Type)

        <Untested()>
        <Pure()>
        Public Sub New(ByVal source As IDataRecord)
            If source Is Nothing Then Throw New ArgumentNullException("source")
            Contract.EndContractBlock()

            For i = 0 To source.FieldCount - 1
                m_Names.Add(source.GetName(i))
                m_TypeNames.Add(source.GetDataTypeName(i))
                m_Types.Add(source.GetFieldType(i))
            Next
        End Sub

        <Untested()>
        <Pure()>
        Friend Function GetOrdinal(ByVal name As String) As Integer
            For i As Integer = 0 To m_Names.Count - 1
                If m_Names(i).Equals(name, StringComparison.InvariantCultureIgnoreCase) Then Return i
            Next
            Throw New ArgumentOutOfRangeException("name")
        End Function

        <Untested()>
        <Pure()>
        Friend Function GetDataTypeName(ByVal i As Integer) As String
            If i <= 0 Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return m_TypeNames(i)
        End Function

        <Untested()>
        <Pure()>
        Friend Function GetFieldType(ByVal i As Integer) As Type
            If i <= 0 Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return m_Types(i)
        End Function

        <Untested()>
        <Pure()>
        Friend Function GetName(ByVal i As Integer) As String
            If i <= 0 Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return m_Names(i)
        End Function
	End Class
End Namespace
#End If