#If IncludeUntested Then
Module ComparerExtension

	<Untested()> <Extension()> Function Reverse(Of T)(ByVal base As IComparer(Of T)) As IComparer(Of T)
		Return New Collections.ReverseComparer(Of T)(base)
	End Function

End Module

Namespace Collections
	<Untested()> Public Class ReverseComparer(Of T)
		Implements IComparer(Of T)
		Private m_Base As IComparer(Of T)

		Public Sub New(ByVal base As IComparer(Of T))
			m_Base = base
		End Sub

		Public Function Compare(ByVal x As T, ByVal y As T) As Integer Implements Global.System.Collections.Generic.IComparer(Of T).Compare
			Return m_Base.Compare(x, y) * -1
		End Function
	End Class
End Namespace
#End If