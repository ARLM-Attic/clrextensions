#If IncludeUntested Then
Module ComparerExtension

    <Untested()>
    <Pure()>
    <Extension()> Function Reverse(Of T)(ByVal base As IComparer(Of T)) As IComparer(Of T)
        Contract.Ensures(Contract.Result(Of IComparer(Of T))() IsNot Nothing)

        Return New Collections.ReverseComparer(Of T)(base)
    End Function

End Module

Namespace Collections
    Public Class ReverseComparer(Of T)
        Implements IComparer(Of T)
        Private ReadOnly m_Base As IComparer(Of T)

        <Untested()>
        <Pure()>
        Public Sub New(ByVal base As IComparer(Of T))
            If base Is Nothing Then Throw New ArgumentNullException("base")
            Contract.EndContractBlock()

            m_Base = base
        End Sub

        <Untested()>
        <Pure()>
        Public Function Compare(ByVal x As T, ByVal y As T) As Integer Implements Global.System.Collections.Generic.IComparer(Of T).Compare
            Return m_Base.Compare(x, y) * -1
        End Function
    End Class
End Namespace
#End If
