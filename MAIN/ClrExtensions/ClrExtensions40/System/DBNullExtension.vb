#If IncludeUntested Then
Public Module DBNullExtension

    <Untested()>
    <Extension()> Public Function FromDBString(ByVal value As Object) As String
        If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, String)
    End Function

    <Untested()>
    <Extension()> Public Function FromDBInt32(ByVal value As Object) As Integer?
        If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Integer)
    End Function

    <Untested()>
    <Extension()> Public Function FromDBDecimal(ByVal value As Object) As Decimal?
        If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Decimal)
    End Function

    <Untested()>
    <Extension()> Public Function FromDBDateTime(ByVal value As Object) As Date?
        If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Date)
    End Function

    <Untested()>
    <Extension()> Public Function FromDBBoolean(ByVal value As Object) As Boolean?
        If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Boolean)
    End Function

    <Untested()>
    <Extension()> Public Function ToDB(Of T As Structure)(ByVal value As T?) As Object
        If value.HasValue Then Return value Else Return DBNull.Value
    End Function

End Module
#End If