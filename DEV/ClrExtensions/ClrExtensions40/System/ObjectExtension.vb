'Copyright (c) 2008, Jonathan Allen

Imports System.Text
Imports System.IO


Public Module ObjectExtension

    ''' <summary>
    ''' Converts an object to a string in manner that ensures exceptions are not thrown.
    ''' </summary>
    ''' <param name="value">Value to be converted into a string</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is None, null, DBNull, or an empty string. 
    ''' If the value is Some(x), x.ToString is returned.
    ''' For all other values, ToString is called.</returns>
    ''' <remarks></remarks>
    <Extension()> Function ToStringSafe(ByVal value As Object, ByVal [default] As String) As String
        Dim temp = ObjectExtension.ToStringSafe(value)
        Return If(temp <> "", temp, [default])
    End Function

    ''' <summary>
    ''' Converts an object to a string in manner that ensures exceptions are not thrown.
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is None, Nothing or DBNull</returns>
    ''' <remarks></remarks>
    <Extension()> Function ToStringSafe(ByVal value As Object) As String
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        Dim temp As Object
#If ClrVersion >= 40 Then
        If value.GetType.Name = "FSharpOption`1" Then temp = FSharpInterop.OptionGetUnderlyingValue(value) Else temp = value
#Else
        temp = value
#End If
        If temp Is Nothing Then Return Nothing
        Return temp.ToString
    End Function


#If ClrVersion >= 40 Then
	''' <summary>
	''' Returns true if the object is contained in the indicated list
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <param name="value"></param>
	''' <param name="source"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()> Function IsIn(Of T)(ByVal value As T, ByVal ParamArray source() As T) As Boolean
		Return source.Contains(value)
	End Function
#End If



#If 1 = 1 Then

    ''' <summary>
    ''' Creates a text dump of the object and its properties to an unlimited depth.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks>This tracks the object graph to prevent circular references</remarks>
     <Extension()> Function ToDebugString(ByVal value As Object) As String
        Dim result As New StringBuilder
        Dim graph As New List(Of Object)

        DebugString(Nothing, value, result, 0, graph)
        Return result.ToString

    End Function

    
    Private Sub DebugString(ByVal propertyName As String, ByVal current As Object, ByVal result As StringBuilder, ByVal depth As Integer, ByVal graph As List(Of Object))

        'TODO: Add support for Collections and Dictionaries
        'TODO: Add support formatting for well known types
        'TODO: Add support for  variables

        Dim header As String = If(propertyName = "", "", vbTab.Repeat(depth) & propertyName & ": ")

        If current Is Nothing Then
            result.AppendLine(header & "<NULL>")

        ElseIf TypeOf current Is String Then
            result.AppendLine(header & current.ToString)

        ElseIf TypeOf current Is SByte Then
            result.AppendLine(header & current.ToString)
        ElseIf TypeOf current Is Short Then
            result.AppendLine(header & current.ToString)
        ElseIf TypeOf current Is Integer Then
            result.AppendLine(header & current.ToString)
        ElseIf TypeOf current Is Long Then
            result.AppendLine(header & current.ToString)


        ElseIf TypeOf current Is Byte Then
            result.AppendLine(header & current.ToString)
        ElseIf TypeOf current Is UInt16 Then
            result.AppendLine(header & current.ToString)
        ElseIf TypeOf current Is UInt32 Then
            result.AppendLine(header & current.ToString)
        ElseIf TypeOf current Is UInt64 Then
            result.AppendLine(header & current.ToString)

        ElseIf TypeOf current Is Single Then
            result.AppendLine(header & current.ToString)
        ElseIf TypeOf current Is Double Then
            result.AppendLine(header & current.ToString)
        ElseIf TypeOf current Is Decimal Then
            result.AppendLine(header & current.ToString)

        ElseIf TypeOf current Is Date Then
            result.AppendLine(header & current.ToString)
            'TODO If DateTime.Kind is set, include that in this output

#If Client35 Then
        ElseIf TypeOf current Is DateTimeOffset Then
            result.AppendLine(header & current.ToString)
#End If

        ElseIf TypeOf current Is Boolean Then
            result.AppendLine(header & current.ToString)

        ElseIf TypeOf current Is ValueType Then
            'Value types don't get added to the graph, they cannot be circular and would just be boxed anyways
            result.AppendLine(header & current.GetType.Name)

            DebugStringProperties(propertyName, current, result, depth, graph)


        Else
            Dim refIndex = graph.IndexOf(current)
            If refIndex > -1 Then 'previously visited
                result.AppendLine(header & current.GetType.Name & " (ref " & refIndex & ")")
            Else
                result.AppendLine(header & current.GetType.Name & " (id " & graph.Count & ")")
                graph.Add(current)

                DebugStringProperties(propertyName, current, result, depth, graph)
            End If
        End If




    End Sub

    Private Sub DebugStringProperties(ByVal propertyName As String, ByVal current As Object, ByVal result As StringBuilder, ByVal depth As Integer, ByVal graph As List(Of Object))
        For Each prop In current.GetType.GetProperties.OrderBy(Function(p) p.Name)
            If prop.CanRead AndAlso prop.GetGetMethod.GetParameters.Count = 0 Then
                Try
                    DebugString(prop.Name, prop.GetValue(current, Nothing), result, depth + 1, graph)
                Catch ex As Exception
                    result.AppendLine(vbTab.Repeat(depth + 1) & propertyName & ": ???")
                End Try
            Else
                result.AppendLine(vbTab.Repeat(depth + 1) & propertyName & ": ???")
            End If
        Next
    End Sub


     <Extension()>  Function DeepCopy(Of T)(ByVal this As T) As T
        If Not this.GetType.IsSerializable Then Throw New ArgumentException("Only serializable types can be copied")

        Dim memoryStream = New MemoryStream()
        Dim binaryFormatter = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        binaryFormatter.Serialize(memoryStream, this)
        memoryStream.Position = 0

        Return DirectCast(binaryFormatter.Deserialize(memoryStream), T)
    End Function


    'TODO - Convert the object to XML using an XML Serializer
    '<Extension()>  Function ToXDocument(ByVal this As Object) As XDocument

    ''' <summary>
    ''' Allows for dot-notation casting e.g. "X.Cast(Of T)" or "x.Cast&lt;T&gt;"
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     <Extension()>  Function Cast(Of T)(ByVal value As Object) As T
        Return CType(value, T)
    End Function

    ''' <summary>
    ''' Allows for dot-notation casting e.g. "X.TryCast(Of T)" or "x.TryCast&lt;T&gt;"
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     <Extension()>  Function [TryCast](Of T As Class)(ByVal value As Object) As T
        Return TryCast(value, T)
    End Function

    ''' <summary>
    ''' Allows for dot-notation casting with a default value when the cast fails
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <param name="default"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     <Extension()>  Function [TryCast](Of T As Class)(ByVal value As Object, ByVal [default] As T) As T
        Dim result = TryCast(value, T)
        Return If(result, [default])
    End Function

    ''' <summary>
    ''' Performs a TryCast on a value type
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     <Extension()>  Function [TryCastNullable](Of T As Structure)(ByVal value As Object) As Nullable(Of T)
        If value Is Nothing Then Return Nothing

        'todo, find a way to do this that won't throw an exception or require a double cast
        If TypeOf value Is Nullable(Of T) Then
            Return CType(value, Nullable(Of T))
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Performs a TryCast on a value type, returning a default value if the conversion fails
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <param name="default"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     <Extension()>  Function [TryCastNullable](Of T As Structure)(ByVal value As Object, ByVal [default] As T) As Nullable(Of T)
        If value Is Nothing Then Return [default]

        'todo, find a way to do this that won't throw an exception or require a double cast
        If TypeOf value Is Nullable(Of T) Then
            Return CType(value, Nullable(Of T))
        Else
            Return [default]
        End If
    End Function

    ''' <summary>
    ''' Returns the ToString on a Nullable(Of T) or an empty string as appropriate
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks>This is a work around to the fact that ToString can throw an exception if the nullable object has no value</remarks>
      Function ToNullableString(Of T As Structure)(ByVal value As Nullable(Of T)) As String
        Return If(value.HasValue, value.ToString, "")
    End Function
#End If


End Module
