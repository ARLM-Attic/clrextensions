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

End Module

