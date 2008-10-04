Public Module EnumExtension

    ''' <summary>
    ''' Returns True if the value is defined by the indicated enumeration
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks>This is constrained on Structure, but really should be constrained on Enum if it were possible</remarks>
	Public Function IsDefined(Of T As Structure)(ByVal value As T) As Boolean
		If Not GetType(T).IsEnum Then Throw New ArgumentException("T is not an enumeration")
		Return [Enum].IsDefined(GetType(T), value)
    End Function

#If IncludeUntested Then

    ''' <summary>
    ''' Parse a string, returning the indicated enum
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> Public Function EnumParse(Of T As Structure)(ByVal value As String) As T
        Return CType([Enum].Parse(GetType(T), value), T)
    End Function

    ''' <summary>
    ''' Parse a string, returning the indicated enum
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> Public Function EnumTryParse(Of T As Structure)(ByVal value As String) As T?
        Try
            Return CType([Enum].Parse(GetType(T), value), T)
        Catch ex As ArgumentException
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Parse a string, returning the indicated enum
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <param name="ignoreCase"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> Public Function EnumParse(Of T As Structure)(ByVal value As String, ByVal ignoreCase As Boolean) As T
        Return CType([Enum].Parse(GetType(T), value, ignoreCase), T)
    End Function

    ''' <summary>
    ''' Parse a string, returning the indicated enum
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <param name="ignoreCase"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> Public Function EnumTryParse(Of T As Structure)(ByVal value As String, ByVal ignoreCase As Boolean) As T?
        Try
            Return CType([Enum].Parse(GetType(T), value, ignoreCase), T)
        Catch ex As ArgumentException
            Return Nothing
        End Try
    End Function
#End If

End Module

