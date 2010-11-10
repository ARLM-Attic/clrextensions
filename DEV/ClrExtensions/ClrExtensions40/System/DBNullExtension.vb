#If 1 = 1 Then
Public Module DBNullExtension

    
    <Extension()>  Function FromDBString(ByVal value As Object) As String
        If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, String)
    End Function

    
    <Extension()>  Function FromDBInt32(ByVal value As Object) As Integer?
        If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Integer)
    End Function

    
    <Extension()>  Function FromDBDecimal(ByVal value As Object) As Decimal?
        If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Decimal)
    End Function

    
    <Extension()>  Function FromDBDateTime(ByVal value As Object) As Date?
        If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Date)
    End Function

    
    <Extension()>  Function FromDBBoolean(ByVal value As Object) As Boolean?
        If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing Else Return DirectCast(value, Boolean)
    End Function

    
    <Extension()>  Function ToDB(Of T As Structure)(ByVal value As T?) As Object
        If value.HasValue Then Return value Else Return DBNull.Value
    End Function

End Module
#End If