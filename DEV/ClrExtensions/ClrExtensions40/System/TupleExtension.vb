#If ClrVersion >= 40 Then
Public Module TupleExtension
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")> <Extension()> Public Sub Add(Of TArg1, TArg2)(ByVal list As List(Of Tuple(Of TArg1, TArg2)), ByVal arg1 As TArg1, ByVal arg2 As TArg2)
        If list Is Nothing Then Throw New ArgumentNullException("list")
        Contract.EndContractBlock()

        list.Add(New Tuple(Of TArg1, TArg2)(arg1, arg2))
    End Sub
End Module
#End If

