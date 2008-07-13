Public Module EnumExtension

	Public Function IsDefined(Of T As Structure)(ByVal value As T) As Boolean
		If Not GetType(T).IsEnum Then Throw New ArgumentException("T is not an enumeration")
		Return [Enum].IsDefined(GetType(T), value)
	End Function

End Module

