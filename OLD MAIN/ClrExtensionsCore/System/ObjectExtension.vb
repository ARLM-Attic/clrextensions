'Copyright (c) 2008, Jonathan Allen

Imports System.IO

Public Module ObjectExtension

    ''' <summary>
    ''' Returns true if the object is contained in the indicated list
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <param name="list"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function IsIn(Of T)(ByVal value As T, ByVal ParamArray list() As T) As Boolean
        Return list.Contains(value)
    End Function

    ''' <summary>
    ''' Returns true if the object is contained in the indicated list
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <param name="list"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function IsIn(Of T)(ByVal value As T, ByVal list As IList(Of T)) As Boolean
        Return list.Contains(value)
    End Function


#If IncludeUntested Then

    ''' <summary>
    ''' Creates a text dump of the object and its properties to an unlimited depth.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks>This tracks the object graph to prevent circular references</remarks>
    <Untested()> <Extension()> Function ToDebugString(ByVal value As Object) As String
        Dim result As New Text.StringBuilder
        Dim graph As New List(Of Object)

        DebugString(Nothing, value, result, 0, graph)
        Return result.ToString

    End Function

    Private Sub DebugString(ByVal propertyName As String, ByVal current As Object, ByVal result As Text.StringBuilder, ByVal depth As Integer, ByVal graph As List(Of Object))

        'TODO: Add support for Collections and Dictionaries
        'TODO: Add support formatting for well known types
        'TODO: Add support for public variables

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

    Private Sub DebugStringProperties(ByVal propertyName As String, ByVal current As Object, ByVal result As Text.StringBuilder, ByVal depth As Integer, ByVal graph As List(Of Object))
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

#If Client35 Then

    <Untested()> <Extension()> Public Function DeepCopy(Of T)(ByVal this As T) As T
        If Not this.GetType.IsSerializable Then Throw New ArgumentException("Only serializable types can be copied")

		Dim memoryStream = New MemoryStream()
        Dim binaryFormatter = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        binaryFormatter.Serialize(memoryStream, this)
        memoryStream.Position = 0

        Return DirectCast(binaryFormatter.Deserialize(memoryStream), T)
    End Function
#End If

    'TODO - Convert the object to XML using an XML Serializer
    '<Extension()> Public Function ToXDocument(ByVal this As Object) As XDocument

    ''' <summary>
    ''' Allows for dot-notation casting e.g. "X.Cast(Of T)" or "x.Cast&lt;T&gt;"
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Public Function Cast(Of T)(ByVal value As Object) As T
        Return CType(value, T)
    End Function

    ''' <summary>
    ''' Allows for dot-notation casting e.g. "X.TryCast(Of T)" or "x.TryCast&lt;T&gt;"
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Public Function [TryCast](Of T As Class)(ByVal value As Object) As T
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
    <Untested()> <Extension()> Public Function [TryCast](Of T As Class)(ByVal value As Object, ByVal [default] As T) As T
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
    <Untested()> <Extension()> Public Function [TryCastNullable](Of T As Structure)(ByVal value As Object) As Nullable(Of T)
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
    <Untested()> <Extension()> Public Function [TryCastNullable](Of T As Structure)(ByVal value As Object, ByVal [default] As T) As Nullable(Of T)
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
    <Untested()> Public Function ToNullableString(Of T As Structure)(ByVal value As Nullable(Of T)) As String
        Return If(value.HasValue, value.ToString, "")
    End Function
#End If

End Module
