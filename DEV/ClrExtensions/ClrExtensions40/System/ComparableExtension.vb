#If IncludeUntested Then
Module ComparableExtension

	''' <summary>
	''' The compile-time type of <paramref name="sampleObject"/> is used to create the ICompable object.
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <param name="sampleObject">This may be null</param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Untested()> <Extension()> Public Function ToComparer(Of T As IComparable(Of T))(ByVal sampleObject As T) As IComparer(Of T)
		Return New ComparerComparable(Of T)
	End Function

	''' <summary>
	''' 
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <remarks>This isn't public because we don't check to see if T is actually IComparable(Of T). ANyone using this does so at their own risk.</remarks>
	Friend Class ComparerComparable(Of T)
		Implements IComparer(Of T)

        <Untested()>
            Public Function Compare(ByVal x As T, ByVal y As T) As Integer Implements Global.System.Collections.Generic.IComparer(Of T).Compare
            Return CType(x, IComparable(Of T)).CompareTo(y)
        End Function
	End Class

End Module
#End If