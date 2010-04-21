'Copyright (c) 2008, Jonathan Allen
#If IncludeUntested Then

public  Module ArrayExtension

#If ClrVersion >= 35 Then
    ''' <summary>
    ''' Sorts a rectanglar array by the indicated column
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="array"></param>
    ''' <param name="sortColumn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId:="Return")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId:="0#")>
    <Untested()>
    <Extension()> Function SortByColumn(Of T)(ByVal array As T(,), ByVal sortColumn As Integer) As T(,)
        If array Is Nothing Then Throw New ArgumentNullException("array")

        Dim fragments = ToJagged(array)

        Dim sorted = (From fragment In fragments Order By fragment(sortColumn)).ToArray

        Return ToRectangle(sorted)

    End Function
#End If

    ''' <summary>
    ''' Turns a rectanglar array into a jagged array
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="array"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of  methods", MessageId:="0")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId:="0#")>
    <Untested()> <Extension()> Function ToJagged(Of T)(ByVal array As T(,)) As T()()
        If array Is Nothing Then Throw New ArgumentNullException("array")

        Dim xMax As Integer = array.GetUpperBound(0)
        Dim yMax As Integer = array.GetUpperBound(1)


        Dim fragments(xMax)() As T
        For i = 0 To xMax
            Dim temp(yMax) As T
            For j = 0 To yMax
                temp(j) = array(i, j)
            Next
            fragments(i) = temp
        Next
        Return fragments

    End Function

    ''' <summary>
    ''' Turns a jagged array into a rectanglar array
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="array"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId:="Return")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId:="Body")>
    <Untested()>
    <Extension()> Function ToRectangle(Of T)(ByVal array As T()()) As T(,)
        If array Is Nothing Then Throw New ArgumentNullException("array")
        If array.Length = 0 Then Throw New ArgumentException("array length must be non-zero")
        'If array.GetUpperBound(0) < 0 Then Throw New ArgumentException("array length must be greater than 0")
        'If array(0) Is Nothing Then Throw New ArgumentException("array cannot contain nulls")

        Dim xMax As Integer = array.GetUpperBound(0)
                Dim yMax As Integer = array(0).GetUpperBound(0)

        For i = 1 To xMax
            If array(i) Is Nothing Then Throw New ArgumentException("array cannot contain null sub-arrays")
            If array(i).GetUpperBound(0) <> yMax Then Throw New ArgumentException("array is not rectanglar")
        Next

        Dim result(xMax, yMax) As T
        For i = 0 To xMax
            For j = 0 To yMax
                result(i, j) = array(i)(j)
            Next
        Next

        Return result
    End Function



End Module
#End If