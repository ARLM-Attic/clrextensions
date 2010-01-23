#If IncludeUntested Then
' Module ComparableExtension

'''' <summary>
'''' The compile-time type of <paramref name="sampleObject"/> is used to create the IComparable object.
'''' </summary>
'''' <typeparam name="T"></typeparam>
'''' <param name="sampleObject">This may be null</param>
'''' <returns></returns>
'''' <remarks></remarks>
'<Untested()> <Extension()>  Function ToComparer(Of T As IComparable(Of T))(ByVal sampleObject As T) As IComparer(Of T)
'Return New ComparerComparable(Of T)
'End Function

'End Module

''' <summary>
''' 
''' </summary>
''' <typeparam name="T"></typeparam>
''' <remarks>This doesn't check to see if T is actually IComparable(Of T). Anyone using this does so at their own risk.</remarks>
 Class ComparerComparable(Of T)
    Implements IComparer(Of T)

    <Untested()>
 Function Compare(ByVal x As T, ByVal y As T) As Integer Implements Global.System.Collections.Generic.IComparer(Of T).Compare
        Return CType(x, IComparable(Of T)).CompareTo(y)
    End Function
End Class

#End If
