#If IncludeUntested Then
Public Module DBNullExtension

    <Extension()> Public Function FromDBString(ByVal value As Object) As String
        If value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, String)
    End Function

    <Extension()> Public Function FromDBInt32(ByVal value As Object) As Integer?
        If value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Integer)
    End Function

    <Extension()> Public Function FromDBDecimal(ByVal value As Object) As Decimal?
        If value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Decimal)
    End Function

    <Extension()> Public Function FromDBDateTime(ByVal value As Object) As Date?
        If value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Date)
    End Function

    <Extension()> Public Function FromDBBoolean(ByVal value As Object) As Boolean?
        If value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Boolean)
    End Function

    <Extension()> Public Function ToDB(Of T As Structure)(ByVal value As T?) As Object
        If value.HasValue Then Return value Else Return Nothing
    End Function

End Module
#End If