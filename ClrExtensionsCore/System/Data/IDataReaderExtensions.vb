Imports ClrExtensions.System.Collections
Imports System.Data
Imports ClrExtensions.System.Data

#If IncludeUntested Then
<Untested()> Public Module IDataReaderExtension

	<Extension()> Public Function ToEnumerable(ByVal this As IDataReader) As IEnumerable(Of IDataRecord)
		Return New DataReaderEnumerable(this)
	End Function

	<Extension()> Public Function ToList(ByVal this As IDataReader) As List(Of IDataRecord)
		Dim schema = New DataRecordColumns(this)
		Dim result As New List(Of IDataRecord)
		For Each item In this.ToEnumerable
			result.Add(New DataRecord(schema, item))
		Next
		Return result
	End Function

	<Extension()> Public Function ToDictionaryList(ByVal this As IDataReader) As List(Of Dictionary(Of String, Object))
		Dim result As New List(Of Dictionary(Of String, Object))
		For Each record In this.ToEnumerable
			result.Add(record.ToDictionary)
		Next
		Return result
	End Function

	<Extension()> Public Function ToDictionary(ByVal this As IDataRecord) As Dictionary(Of String, Object)
		Dim result As New Dictionary(Of String, Object)
		For i = 0 To this.FieldCount - 1
			If this.IsDBNull(i) Then
				result.Add(this.GetName(i), Nothing)
			Else
				result.Add(this.GetName(i), this.GetValue(i))
			End If
		Next
		Return result
	End Function



#Region "Old methods by name"
	<Extension()> Public Function GetBoolean(ByVal this As IDataRecord, ByVal name As String) As Boolean
		Return this.GetBoolean(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetByte(ByVal this As IDataRecord, ByVal name As String) As Byte
		Return this.GetByte(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetBytes(ByVal this As IDataRecord, ByVal name As String, ByVal fieldOffset As Long, ByVal buffer() As Byte, ByVal bufferoffset As Integer, ByVal length As Integer) As Long
		Return this.GetBytes(this.GetOrdinal(name), fieldOffset, buffer, bufferoffset, length)
	End Function

	<Extension()> Public Function GetChar(ByVal this As IDataRecord, ByVal name As String) As Char
		Return this.GetChar(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetChars(ByVal this As IDataRecord, ByVal name As String, ByVal fieldoffset As Long, ByVal buffer() As Char, ByVal bufferoffset As Integer, ByVal length As Integer) As Long
		Return this.GetChars(this.GetOrdinal(name), fieldoffset, buffer, bufferoffset, length)
	End Function

	<Extension()> Public Function GetDataTypeName(ByVal this As IDataRecord, ByVal name As String) As String
		Return this.GetDataTypeName(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetDateTime(ByVal this As IDataRecord, ByVal name As String) As Date
		Return this.GetDateTime(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetDecimal(ByVal this As IDataRecord, ByVal name As String) As Decimal
		Return this.GetDecimal(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetDouble(ByVal this As IDataRecord, ByVal name As String) As Double
		Return this.GetDouble(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetFieldType(ByVal this As IDataRecord, ByVal name As String) As Type
		Return this.GetFieldType(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetFloat(ByVal this As IDataRecord, ByVal name As String) As Single
		Return this.GetFloat(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetGuid(ByVal this As IDataRecord, ByVal name As String) As Guid
		Return this.GetGuid(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetInt16(ByVal this As IDataRecord, ByVal name As String) As Short
		Return this.GetInt16(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetInt32(ByVal this As IDataRecord, ByVal name As String) As Integer
		Return this.GetInt32(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetInt64(ByVal this As IDataRecord, ByVal name As String) As Long
		Return this.GetInt64(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetString(ByVal this As IDataRecord, ByVal name As String) As String
		Return this.GetString(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function IsDBNull(ByVal this As IDataRecord, ByVal name As String) As Boolean
		Return this.IsDBNull(this.GetOrdinal(name))
	End Function

#End Region

#Region "Nullable methods, by name"

	<Extension()> Public Function GetBooleanSafe(ByVal this As IDataRecord, ByVal name As String) As Boolean?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetBoolean(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetByteSafe(ByVal this As IDataRecord, ByVal name As String) As Byte?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetByte(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetCharSafe(ByVal this As IDataRecord, ByVal name As String) As Char?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetChar(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetDateTimeSafe(ByVal this As IDataRecord, ByVal name As String) As Date?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetDateTime(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetDecimalSafe(ByVal this As IDataRecord, ByVal name As String) As Decimal?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetDecimal(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetDoubleSafe(ByVal this As IDataRecord, ByVal name As String) As Double?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetDouble(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetFloatSafe(ByVal this As IDataRecord, ByVal name As String) As Single?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetFloat(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetGuidSafe(ByVal this As IDataRecord, ByVal name As String) As Guid?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetGuid(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetInt16Safe(ByVal this As IDataRecord, ByVal name As String) As Short?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetInt16(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetInt32Safe(ByVal this As IDataRecord, ByVal name As String) As Integer?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetInt32(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetInt64Safe(ByVal this As IDataRecord, ByVal name As String) As Long?
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetInt64(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetStringSafe(ByVal this As IDataRecord, ByVal name As String) As String
		If this.IsDBNull(name) Then Return Nothing
		Return this.GetString(this.GetOrdinal(name))
	End Function

#End Region

#Region "Nullable methods, by ordinal"
	<Extension()> Public Function GetBooleanSafe(ByVal this As IDataRecord, ByVal i As Integer) As Boolean?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetBoolean(i)
	End Function

	<Extension()> Public Function GetByteSafe(ByVal this As IDataRecord, ByVal i As Integer) As Byte?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetByte(i)
	End Function

	<Extension()> Public Function GetCharSafe(ByVal this As IDataRecord, ByVal i As Integer) As Char?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetChar(i)
	End Function

	<Extension()> Public Function GetDateTimeSafe(ByVal this As IDataRecord, ByVal i As Integer) As Date?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetDateTime(i)
	End Function

	<Extension()> Public Function GetDecimalSafe(ByVal this As IDataRecord, ByVal i As Integer) As Decimal?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetDecimal(i)
	End Function

	<Extension()> Public Function GetDoubleSafe(ByVal this As IDataRecord, ByVal i As Integer) As Double?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetDouble(i)
	End Function

	<Extension()> Public Function GetFloatSafe(ByVal this As IDataRecord, ByVal i As Integer) As Single?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetFloat(i)
	End Function

	<Extension()> Public Function GetGuidSafe(ByVal this As IDataRecord, ByVal i As Integer) As Guid?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetGuid(i)
	End Function

	<Extension()> Public Function GetInt16Safe(ByVal this As IDataRecord, ByVal i As Integer) As Short?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetInt16(i)
	End Function

	<Extension()> Public Function GetInt32Safe(ByVal this As IDataRecord, ByVal i As Integer) As Integer?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetInt32(i)
	End Function

	<Extension()> Public Function GetInt64Safe(ByVal this As IDataRecord, ByVal i As Integer) As Long?
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetInt64(i)
	End Function

	<Extension()> Public Function GetStringSafe(ByVal this As IDataRecord, ByVal i As Integer) As String
		If this.IsDBNull(i) Then Return Nothing
		Return this.GetString(i)
	End Function
#End Region

End Module

#End If