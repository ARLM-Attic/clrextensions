'Copyright (c) 2008, Jonathan Allen
#If IncludeUntested Then

Public Module ArrayExtension

#If ClrVersion >= 35 Then
    ''' <summary>
    ''' Sorts a rectanglar array by the indicated column
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="array"></param>
    ''' <param name="sortColumn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Function SortByColumn(Of T)(ByVal array As T(,), ByVal sortColumn As Integer) As T(,)
        Dim fragments = array.ToJagged

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
    <Untested()> <Extension()> Function ToJagged(Of T)(ByVal array As T(,)) As T()()
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
    <Untested()> <Extension()> Function ToRectangle(Of T)(ByVal array As T()()) As T(,)
        Dim xMax As Integer = array.GetUpperBound(0)
        Dim yMax As Integer = array(0).GetUpperBound(0)

        For i = 1 To xMax
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