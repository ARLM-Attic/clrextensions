Imports ClrExtensions.System.Collections
Imports System.Data
Imports ClrExtensions.System.Data

#If IncludeUntested Then
Namespace System.Data
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

		Public ReadOnly Property FieldCount() As Integer Implements IDataRecord.FieldCount
			Get
				Return m_Data.Count
			End Get
		End Property

		Public Function GetBoolean(ByVal i As Integer) As Boolean Implements IDataRecord.GetBoolean
			Return CBool(m_Data(i))
		End Function

		Public Function GetByte(ByVal i As Integer) As Byte Implements IDataRecord.GetByte
			Return CByte(m_Data(i))
		End Function

		Public Function GetBytes(ByVal i As Integer, ByVal fieldOffset As Long, ByVal buffer() As Byte, ByVal bufferoffset As Integer, ByVal length As Integer) As Long Implements IDataRecord.GetBytes
			Array.Copy(CType(m_Data(i), Byte()), fieldOffset, buffer, bufferoffset, length)
		End Function

		Public Function GetChar(ByVal i As Integer) As Char Implements IDataRecord.GetChar
			Return CChar(m_Data(i))
		End Function

		Public Function GetChars(ByVal i As Integer, ByVal fieldoffset As Long, ByVal buffer() As Char, ByVal bufferoffset As Integer, ByVal length As Integer) As Long Implements IDataRecord.GetChars
			Array.Copy(CType(m_Data(i), Char()), fieldoffset, buffer, bufferoffset, length)
		End Function

		Public Function GetData(ByVal i As Integer) As IDataReader Implements IDataRecord.GetData
			Throw New NotSupportedException
		End Function

		Public Function GetDataTypeName(ByVal i As Integer) As String Implements IDataRecord.GetDataTypeName
			Return m_Schema.GetDataTypeName(i)
		End Function

		Public Function GetDateTime(ByVal i As Integer) As Date Implements IDataRecord.GetDateTime
			Return CDate(m_Data(i))

		End Function

		Public Function GetDecimal(ByVal i As Integer) As Decimal Implements IDataRecord.GetDecimal
			Return CDec(m_Data(i))

		End Function

		Public Function GetDouble(ByVal i As Integer) As Double Implements IDataRecord.GetDouble
			Return CDbl(m_Data(i))

		End Function

		Public Function GetFieldType(ByVal i As Integer) As Type Implements IDataRecord.GetFieldType
			Return m_Schema.GetFieldType(i)
		End Function

		Public Function GetFloat(ByVal i As Integer) As Single Implements IDataRecord.GetFloat
			Return CSng(m_Data(i))

		End Function

		Public Function GetGuid(ByVal i As Integer) As Guid Implements IDataRecord.GetGuid
			Return CType(m_Data(i), Guid)

		End Function

		Public Function GetInt16(ByVal i As Integer) As Short Implements IDataRecord.GetInt16
			Return CShort(m_Data(i))

		End Function

		Public Function GetInt32(ByVal i As Integer) As Integer Implements IDataRecord.GetInt32
			Return CInt(m_Data(i))

		End Function

		Public Function GetInt64(ByVal i As Integer) As Long Implements IDataRecord.GetInt64
			Return CLng(m_Data(i))

		End Function

		Public Function GetName(ByVal i As Integer) As String Implements IDataRecord.GetName
			Return m_Schema.GetName(i)

		End Function

		Public Function GetOrdinal(ByVal name As String) As Integer Implements IDataRecord.GetOrdinal
			Return m_Schema.GetOrdinal(name)
		End Function

		Public Function GetString(ByVal i As Integer) As String Implements IDataRecord.GetString
			Return CStr(m_Data(i))

		End Function

		Public Function GetValue(ByVal i As Integer) As Object Implements IDataRecord.GetValue
			Return m_Data(i)
		End Function

		Public Function GetValues(ByVal values() As Object) As Integer Implements IDataRecord.GetValues
			Array.Copy(m_Data.ToArray, values, m_Data.Count)
		End Function

		Public Function IsDBNull(ByVal i As Integer) As Boolean Implements IDataRecord.IsDBNull
			Return m_Data(i) Is DBNull.Value
		End Function

		Default Public Overloads ReadOnly Property Item(ByVal i As Integer) As Object Implements IDataRecord.Item
			Get
				Return m_Data(i)
			End Get
		End Property

		Default Public Overloads ReadOnly Property Item(ByVal name As String) As Object Implements IDataRecord.Item
			Get
				Return m_Data(GetOrdinal(name))
			End Get
		End Property
	End Class
End Namespace
#End If
