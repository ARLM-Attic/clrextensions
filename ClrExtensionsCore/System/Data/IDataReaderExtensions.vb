Public Module IDataReaderExtension

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

	<Extension()> Public Function GetFieldType(ByVal this As IDataRecord, ByVal name As String) As System.Type
		Return this.GetFieldType(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetFloat(ByVal this As IDataRecord, ByVal name As String) As Single
		Return this.GetFloat(this.GetOrdinal(name))
	End Function

	<Extension()> Public Function GetGuid(ByVal this As IDataRecord, ByVal name As String) As System.Guid
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

	<Extension()> Public Function GetGuidSafe(ByVal this As IDataRecord, ByVal name As String) As System.Guid?
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

	<Extension()> Public Function GetGuidSafe(ByVal this As IDataRecord, ByVal i As Integer) As System.Guid?
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

Friend Class DataReaderEnumerable
	Implements IEnumerable(Of IDataRecord)

	Private m_Source As IDataReader

	Public Sub New(ByVal source As IDataReader)
		m_Source = source
	End Sub

	Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of System.Data.IDataRecord) Implements System.Collections.Generic.IEnumerable(Of System.Data.IDataRecord).GetEnumerator
		Return New DataReaderEnumerator(m_Source)
	End Function

	Private Function IEnumerable_GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		Return New DataReaderEnumerator(m_Source)
	End Function
End Class

Friend Class DataReaderEnumerator
	Implements IEnumerator(Of IDataRecord)

	Private m_Source As IDataReader

	Public Sub New(ByVal source As IDataReader)
		m_Source = source
	End Sub

	Public ReadOnly Property Current() As System.Data.IDataRecord Implements System.Collections.Generic.IEnumerator(Of System.Data.IDataRecord).Current
		Get
			Return m_Source
		End Get
	End Property

	Private ReadOnly Property IEnumerator_Current() As Object Implements System.Collections.IEnumerator.Current
		Get
			Return m_Source
		End Get
	End Property

	Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
		Return m_Source.Read
	End Function

	Private Sub Reset() Implements System.Collections.IEnumerator.Reset
		Throw New NotSupportedException
	End Sub

	Private disposedValue As Boolean = False		' To detect redundant calls

	' IDisposable
	Protected Overridable Sub Dispose(ByVal disposing As Boolean)
		If Not Me.disposedValue Then
			If disposing Then
				m_Source.Dispose()
			End If

			' TODO: free your own state (unmanaged objects).
			' TODO: set large fields to null.
		End If
		Me.disposedValue = True
	End Sub

#Region " IDisposable Support "
	' This code added by Visual Basic to correctly implement the disposable pattern.
	Public Sub Dispose() Implements IDisposable.Dispose
		' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
		Dispose(True)
		GC.SuppressFinalize(Me)
	End Sub
#End Region

End Class

Friend Class DataRecordColumns
	Private m_Names As List(Of String)
	Private m_TypeNames As List(Of String)
	Private m_Types As List(Of Type)

	Public Sub New(ByVal source As IDataRecord)
		For i = 0 To source.FieldCount - 1
			m_Names.Add(source.GetName(i))
			m_TypeNames.Add(source.GetDataTypeName(i))
			m_Types.Add(source.GetFieldType(i))
		Next
	End Sub

	Friend Function GetOrdinal(ByVal name As String) As Integer
		For i As Integer = 0 To m_Names.Count - 1
			If m_Names(i).Equals(name, StringComparison.InvariantCultureIgnoreCase) Then Return i
		Next
		Throw New ArgumentOutOfRangeException("name")
	End Function

	Friend Function GetDataTypeName(ByVal i As Integer) As String
		Return m_TypeNames(i)
	End Function

	Friend Function GetFieldType(ByVal i As Integer) As Type
		Return m_Types(i)
	End Function

	Friend Function GetName(ByVal i As Integer) As String
		Return m_Names(i)
	End Function
End Class

Friend Class DataRecord
	Implements IDataRecord

	Private m_Schema As DataRecordColumns
	Private m_Data As List(Of Object)

	Public Sub New(ByVal schema As DataRecordColumns, ByVal source As IDataRecord)
		m_Schema = schema
		For i = 0 To source.FieldCount - 1
			m_Data.Add(source.GetValue(i))
		Next
	End Sub

	Public ReadOnly Property FieldCount() As Integer Implements System.Data.IDataRecord.FieldCount
		Get
			Return m_Data.Count
		End Get
	End Property

	Public Function GetBoolean(ByVal i As Integer) As Boolean Implements System.Data.IDataRecord.GetBoolean
		Return CBool(m_Data(i))
	End Function

	Public Function GetByte(ByVal i As Integer) As Byte Implements System.Data.IDataRecord.GetByte
		Return CByte(m_Data(i))
	End Function

	Public Function GetBytes(ByVal i As Integer, ByVal fieldOffset As Long, ByVal buffer() As Byte, ByVal bufferoffset As Integer, ByVal length As Integer) As Long Implements System.Data.IDataRecord.GetBytes
		Array.Copy(CType(m_Data(i), Byte()), fieldOffset, buffer, bufferoffset, length)
	End Function

	Public Function GetChar(ByVal i As Integer) As Char Implements System.Data.IDataRecord.GetChar
		Return CChar(m_Data(i))
	End Function

	Public Function GetChars(ByVal i As Integer, ByVal fieldoffset As Long, ByVal buffer() As Char, ByVal bufferoffset As Integer, ByVal length As Integer) As Long Implements System.Data.IDataRecord.GetChars
		Array.Copy(CType(m_Data(i), Char()), fieldoffset, buffer, bufferoffset, length)
	End Function

	Public Function GetData(ByVal i As Integer) As System.Data.IDataReader Implements System.Data.IDataRecord.GetData
		Throw New NotSupportedException
	End Function

	Public Function GetDataTypeName(ByVal i As Integer) As String Implements System.Data.IDataRecord.GetDataTypeName
		Return m_Schema.GetDataTypeName(i)
	End Function

	Public Function GetDateTime(ByVal i As Integer) As Date Implements System.Data.IDataRecord.GetDateTime
		Return CDate(m_Data(i))

	End Function

	Public Function GetDecimal(ByVal i As Integer) As Decimal Implements System.Data.IDataRecord.GetDecimal
		Return CDec(m_Data(i))

	End Function

	Public Function GetDouble(ByVal i As Integer) As Double Implements System.Data.IDataRecord.GetDouble
		Return CDbl(m_Data(i))

	End Function

	Public Function GetFieldType(ByVal i As Integer) As System.Type Implements System.Data.IDataRecord.GetFieldType
		Return m_Schema.GetFieldType(i)
	End Function

	Public Function GetFloat(ByVal i As Integer) As Single Implements System.Data.IDataRecord.GetFloat
		Return CSng(m_Data(i))

	End Function

	Public Function GetGuid(ByVal i As Integer) As System.Guid Implements System.Data.IDataRecord.GetGuid
		Return CType(m_Data(i), Guid)

	End Function

	Public Function GetInt16(ByVal i As Integer) As Short Implements System.Data.IDataRecord.GetInt16
		Return CShort(m_Data(i))

	End Function

	Public Function GetInt32(ByVal i As Integer) As Integer Implements System.Data.IDataRecord.GetInt32
		Return CInt(m_Data(i))

	End Function

	Public Function GetInt64(ByVal i As Integer) As Long Implements System.Data.IDataRecord.GetInt64
		Return CLng(m_Data(i))

	End Function

	Public Function GetName(ByVal i As Integer) As String Implements System.Data.IDataRecord.GetName
		Return m_Schema.GetName(i)

	End Function

	Public Function GetOrdinal(ByVal name As String) As Integer Implements System.Data.IDataRecord.GetOrdinal
		Return m_Schema.GetOrdinal(name)
	End Function

	Public Function GetString(ByVal i As Integer) As String Implements System.Data.IDataRecord.GetString
		Return CStr(m_Data(i))

	End Function

	Public Function GetValue(ByVal i As Integer) As Object Implements System.Data.IDataRecord.GetValue
		Return m_Data(i)
	End Function

	Public Function GetValues(ByVal values() As Object) As Integer Implements System.Data.IDataRecord.GetValues
		Array.Copy(m_Data.ToArray, values, m_Data.Count)
	End Function

	Public Function IsDBNull(ByVal i As Integer) As Boolean Implements System.Data.IDataRecord.IsDBNull
		Return m_Data(i) Is DBNull.Value
	End Function

	Default Public Overloads ReadOnly Property Item(ByVal i As Integer) As Object Implements System.Data.IDataRecord.Item
		Get
			Return m_Data(i)
		End Get
	End Property

	Default Public Overloads ReadOnly Property Item(ByVal name As String) As Object Implements System.Data.IDataRecord.Item
		Get
			Return m_Data(GetOrdinal(name))
		End Get
	End Property
End Class
