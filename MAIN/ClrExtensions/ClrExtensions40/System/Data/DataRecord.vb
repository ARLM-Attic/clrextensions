'Copyright (c) 2008, Jonathan Allen

#If IncludeUntested Then
Imports ClrExtensions.Collections
Imports System.Data
Imports ClrExtensions.Data

Namespace Data
    Friend Class DataRecord
        Implements IDataRecord

        Private ReadOnly m_Schema As DataRecordColumns
        Private ReadOnly m_Data As New List(Of Object)

        <Untested()>
        <Pure()>
        Public Sub New(ByVal schema As DataRecordColumns, ByVal source As IDataRecord)
            If schema Is Nothing Then Throw New ArgumentNullException("schema")
            If source Is Nothing Then Throw New ArgumentNullException("source")
            Contract.EndContractBlock()

            m_Schema = schema
            For i = 0 To source.FieldCount - 1
                m_Data.Add(source.GetValue(i))
            Next
        End Sub

        <Untested()>
        <Pure()>
        Public ReadOnly Property FieldCount() As Integer Implements IDataRecord.FieldCount
            Get
                Return m_Data.Count
            End Get
        End Property

        <Untested()>
        <Pure()>
        Public Function GetBoolean(ByVal i As Integer) As Boolean Implements IDataRecord.GetBoolean
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CBool(m_Data(i))
        End Function

        <Untested()>
        <Pure()>
        Public Function GetByte(ByVal i As Integer) As Byte Implements IDataRecord.GetByte
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CByte(m_Data(i))
        End Function


        <Untested()>
        Public Function GetBytes(ByVal i As Integer, ByVal fieldOffset As Long, ByVal buffer() As Byte, ByVal bufferoffset As Integer, ByVal length As Integer) As Long Implements IDataRecord.GetBytes
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            If buffer Is Nothing Then Throw New ArgumentNullException("buffer")
            Contract.EndContractBlock()

            Array.Copy(CType(m_Data(i), Byte()), fieldOffset, buffer, bufferoffset, length)
            Return Math.Min(CType(m_Data(i), Byte()).Length, length)
        End Function


        <Untested()>
        <Pure()>
        Public Function GetChar(ByVal i As Integer) As Char Implements IDataRecord.GetChar
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CChar(m_Data(i))
        End Function


        <Untested()>
        Public Function GetChars(ByVal i As Integer, ByVal fieldoffset As Long, ByVal buffer() As Char, ByVal bufferoffset As Integer, ByVal length As Integer) As Long Implements IDataRecord.GetChars
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            If buffer Is Nothing Then Throw New ArgumentNullException("buffer")
            Contract.EndContractBlock()

            Array.Copy(CType(m_Data(i), Char()), fieldoffset, buffer, bufferoffset, length)
            Return Math.Min(CType(m_Data(i), Char()).Length, length)
        End Function


        <Untested()>
        <Pure()>
        Public Function GetData(ByVal i As Integer) As IDataReader Implements IDataRecord.GetData
            Throw New NotSupportedException
        End Function

        <Untested()>
        <Pure()>
        Public Function GetDataTypeName(ByVal i As Integer) As String Implements IDataRecord.GetDataTypeName
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return m_Schema.GetDataTypeName(i)
        End Function

        <Untested()>
        <Pure()>
        Public Function GetDateTime(ByVal i As Integer) As Date Implements IDataRecord.GetDateTime
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CDate(m_Data(i))

        End Function

        <Untested()>
        <Pure()>
        Public Function GetDecimal(ByVal i As Integer) As Decimal Implements IDataRecord.GetDecimal
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CDec(m_Data(i))

        End Function

        <Untested()>
        <Pure()>
        Public Function GetDouble(ByVal i As Integer) As Double Implements IDataRecord.GetDouble
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CDbl(m_Data(i))

        End Function

        <Untested()>
        <Pure()>
        Public Function GetFieldType(ByVal i As Integer) As Type Implements IDataRecord.GetFieldType
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return m_Schema.GetFieldType(i)
        End Function

        <Untested()>
        <Pure()>
        Public Function GetFloat(ByVal i As Integer) As Single Implements IDataRecord.GetFloat
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CSng(m_Data(i))

        End Function

        <Untested()>
        <Pure()>
        Public Function GetGuid(ByVal i As Integer) As Guid Implements IDataRecord.GetGuid
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CType(m_Data(i), Guid)

        End Function

        <Untested()>
        <Pure()>
        Public Function GetInt16(ByVal i As Integer) As Short Implements IDataRecord.GetInt16
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CShort(m_Data(i))

        End Function

        <Untested()>
        <Pure()>
        Public Function GetInt32(ByVal i As Integer) As Integer Implements IDataRecord.GetInt32
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CInt(m_Data(i))

        End Function

        <Untested()>
        <Pure()>
        Public Function GetInt64(ByVal i As Integer) As Long Implements IDataRecord.GetInt64
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CLng(m_Data(i))

        End Function

        <Untested()>
        <Pure()>
        Public Function GetName(ByVal i As Integer) As String Implements IDataRecord.GetName
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return m_Schema.GetName(i)

        End Function

        <Untested()>
        <Pure()>
        Public Function GetOrdinal(ByVal name As String) As Integer Implements IDataRecord.GetOrdinal
            Return m_Schema.GetOrdinal(name)
        End Function

        <Untested()>
        <Pure()>
        Public Function GetString(ByVal i As Integer) As String Implements IDataRecord.GetString
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return CStr(m_Data(i))

        End Function

        <Untested()>
        <Pure()>
        Public Function GetValue(ByVal i As Integer) As Object Implements IDataRecord.GetValue
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return m_Data(i)
        End Function

        <Untested()>
        Public Function GetValues(ByVal values() As Object) As Integer Implements IDataRecord.GetValues
            If values Is Nothing Then Throw New ArgumentNullException("values")
            Array.Copy(m_Data.ToArray, values, m_Data.Count)
            Return values.Length
        End Function

        <Untested()>
        <Pure()>
        Public Function IsDBNull(ByVal i As Integer) As Boolean Implements IDataRecord.IsDBNull
            If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
            Contract.EndContractBlock()

            Return m_Data(i) Is DBNull.Value
        End Function

        <Untested()>
        Default Public Overloads ReadOnly Property Item(ByVal i As Integer) As Object Implements IDataRecord.Item
            <Pure()>
            Get
                If i >= FieldCount Then Throw New ArgumentOutOfRangeException("i")
                Contract.EndContractBlock()

                Return m_Data(i)
            End Get
        End Property

        <Untested()>
        Default Public Overloads ReadOnly Property Item(ByVal name As String) As Object Implements IDataRecord.Item
            <Pure()> Get
                Return m_Data(GetOrdinal(name))
            End Get
        End Property
    End Class
End Namespace
#End If
