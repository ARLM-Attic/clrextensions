'Copyright (c) 2008, Jonathan Allen

#If 1 = 1 Then


Public Module TypeExtension

    ''' <summary>
    ''' Determines if a given type has the indicated Attribute
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="attribute"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     <Extension()>  Function HasAttribute(ByVal type As Reflection.MemberInfo, ByVal attribute As Type) As Boolean
        If type Is Nothing Then Throw New ArgumentNullException("type")
        If attribute Is Nothing Then Throw New ArgumentNullException("attribute")

        Return type.GetCustomAttributes(attribute, True).Length > 0
    End Function

    ''' <summary>
    ''' Returns a type's name in VB's format. For example, TimeSpan[] becomes TimeSpan()
    ''' </summary>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     <Extension()>  Function NameVBFormat(ByVal type As Reflection.MemberInfo) As String
        If type Is Nothing Then Throw New ArgumentNullException("type")

        'TODO - handle VB-sepcific names such as Integer, String, and Date
        'TODO - what happens if the type is generic?
        Return type.Name.Replace("[", "(").Replace("]", ")")
    End Function


	'TODO - Look up the reflection code used before to see if any of it belongs here

	'TODO - Create a new instance from a Type
	'TODO - Create a delegate that gets new instance from a Type
	'TODO - Create a delegate representing a method

End Module
#End If
