'Copyright (c) 2008, Jonathan Allen

#If 1 = 1 Then
Imports ClrExtensions.Collections
Imports System.Data
Imports ClrExtensions.Data

Public Module IDataReaderExtension

    ''' <summary>
    ''' Wraps a IDataReader in an enumerator.
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
         <Extension()>  Function ToEnumerable(ByVal this As IDataReader) As IEnumerable(Of IDataRecord)
        Return New DataReaderEnumerable(this)
    End Function

    ''' <summary>
    ''' This takes a snapshot of a IDataReader in the form of a list of IDataRecords.
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")>
         <Extension()>  Function ToList(ByVal this As IDataReader) As List(Of IDataRecord)
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Dim schema = New DataRecordColumns(this)
        Dim result As New List(Of IDataRecord)
        For Each item In this.ToEnumerable
            result.Add(New DataRecord(schema, item))
        Next
        Return result
    End Function

    ''' <summary>
    ''' This takes a snapshot of a IDataReader in the form of a list of dictionaries. Each dictionary has one entry for each column
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")>
     <Extension()>  Function ToDictionaryList(ByVal source As IDataReader) As List(Of Dictionary(Of String, Object))
        Dim result As New List(Of Dictionary(Of String, Object))
        For Each record In source.ToEnumerable
            result.Add(record.ToDictionary)
        Next
        Return result
    End Function

    ''' <summary>
    ''' This extracts the columns from a DataRecord and places them inside a dictionary
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     <Extension()>  Function ToDictionary(ByVal this As IDataRecord) As Dictionary(Of String, Object)
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Dim result As New Dictionary(Of String, Object)
        For index = 0 To this.FieldCount - 1
            If this.IsDBNull(index) Then
                result.Add(this.GetName(index), Nothing)
            Else
                result.Add(this.GetName(index), this.GetValue(index))
            End If
        Next
        Return result
    End Function



#Region "Old methods by name"
     <Extension()>  Function GetBoolean(ByVal this As IDataRecord, ByVal name As String) As Boolean
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetBoolean(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetByte(ByVal this As IDataRecord, ByVal name As String) As Byte
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetByte(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetBytes(ByVal this As IDataRecord, ByVal name As String, ByVal fieldOffset As Long, ByVal buffer() As Byte, ByVal bufferOffset As Integer, ByVal length As Integer) As Long
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetBytes(this.GetOrdinal(name), fieldOffset, buffer, bufferoffset, length)
    End Function

     <Extension()>  Function GetChar(ByVal this As IDataRecord, ByVal name As String) As Char
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetChar(this.GetOrdinal(name))
    End Function

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId:="bufferoffset")>  <Extension()>  Function GetChars(ByVal this As IDataRecord, ByVal name As String, ByVal fieldOffset As Long, ByVal buffer() As Char, ByVal bufferoffset As Integer, ByVal length As Integer) As Long
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetChars(this.GetOrdinal(name), fieldoffset, buffer, bufferoffset, length)
    End Function

     <Extension()>  Function GetDataTypeName(ByVal this As IDataRecord, ByVal name As String) As String
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetDataTypeName(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetDateTime(ByVal this As IDataRecord, ByVal name As String) As Date
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetDateTime(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetDecimal(ByVal this As IDataRecord, ByVal name As String) As Decimal
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetDecimal(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetDouble(ByVal this As IDataRecord, ByVal name As String) As Double
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetDouble(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetFieldType(ByVal this As IDataRecord, ByVal name As String) As Type
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetFieldType(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetSingle(ByVal this As IDataRecord, ByVal name As String) As Single
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetFloat(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetGuid(ByVal this As IDataRecord, ByVal name As String) As Guid
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetGuid(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetInt16(ByVal this As IDataRecord, ByVal name As String) As Short
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetInt16(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetInt32(ByVal this As IDataRecord, ByVal name As String) As Integer
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetInt32(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetInt64(ByVal this As IDataRecord, ByVal name As String) As Long
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetInt64(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetString(ByVal this As IDataRecord, ByVal name As String) As String
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.GetString(this.GetOrdinal(name))
    End Function

     <Extension()>  Function IsDBNull(ByVal this As IDataRecord, ByVal name As String) As Boolean
        If this Is Nothing Then Throw New ArgumentNullException("this")

        Return this.IsDBNull(this.GetOrdinal(name))
    End Function

#End Region

#Region "Nullable methods, by name"

     <Extension()>  Function GetBoolean2(ByVal this As IDataRecord, ByVal name As String) As Boolean?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetBoolean(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetByte2(ByVal this As IDataRecord, ByVal name As String) As Byte?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetByte(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetChar2(ByVal this As IDataRecord, ByVal name As String) As Char?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetChar(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetDateTime2(ByVal this As IDataRecord, ByVal name As String) As Date?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetDateTime(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetDecimal2(ByVal this As IDataRecord, ByVal name As String) As Decimal?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetDecimal(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetDouble2(ByVal this As IDataRecord, ByVal name As String) As Double?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetDouble(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetFloat2(ByVal this As IDataRecord, ByVal name As String) As Single?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetFloat(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetGuid2(ByVal this As IDataRecord, ByVal name As String) As Guid?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetGuid(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetInt162(ByVal this As IDataRecord, ByVal name As String) As Short?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetInt16(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetInt322(ByVal this As IDataRecord, ByVal name As String) As Integer?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetInt32(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetInt642(ByVal this As IDataRecord, ByVal name As String) As Long?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetInt64(this.GetOrdinal(name))
    End Function

     <Extension()>  Function GetString2(ByVal this As IDataRecord, ByVal name As String) As String
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(name) Then Return Nothing
        Return this.GetString(this.GetOrdinal(name))
    End Function

#End Region

#Region "Nullable methods, by ordinal"
     <Extension()>  Function GetBoolean2(ByVal this As IDataRecord, ByVal index As Integer) As Boolean?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetBoolean(index)
    End Function

     <Extension()>  Function GetByte2(ByVal this As IDataRecord, ByVal index As Integer) As Byte?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetByte(index)
    End Function

     <Extension()>  Function GetChar2(ByVal this As IDataRecord, ByVal index As Integer) As Char?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetChar(index)
    End Function

     <Extension()>  Function GetDateTime2(ByVal this As IDataRecord, ByVal index As Integer) As Date?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetDateTime(index)
    End Function

     <Extension()>  Function GetDecimal2(ByVal this As IDataRecord, ByVal index As Integer) As Decimal?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetDecimal(index)
    End Function

     <Extension()>  Function GetDouble2(ByVal this As IDataRecord, ByVal index As Integer) As Double?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetDouble(index)
    End Function

     <Extension()>  Function GetFloat2(ByVal this As IDataRecord, ByVal index As Integer) As Single?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetFloat(index)
    End Function

     <Extension()>  Function GetGuid2(ByVal this As IDataRecord, ByVal index As Integer) As Guid?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetGuid(index)
    End Function

     <Extension()>  Function GetInt162(ByVal this As IDataRecord, ByVal index As Integer) As Short?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetInt16(index)
    End Function

     <Extension()>  Function GetInt322(ByVal this As IDataRecord, ByVal index As Integer) As Integer?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetInt32(index)
    End Function

     <Extension()>  Function GetInt642(ByVal this As IDataRecord, ByVal index As Integer) As Long?
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetInt64(index)
    End Function

     <Extension()>  Function GetString2(ByVal this As IDataRecord, ByVal index As Integer) As String
        If this Is Nothing Then Throw New ArgumentNullException("this")

        If this.IsDBNull(index) Then Return Nothing
        Return this.GetString(index)
    End Function
#End Region

End Module

#End If
