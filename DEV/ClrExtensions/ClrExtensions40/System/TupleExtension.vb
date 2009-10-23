Public Module TupleExtension
    <Extension()> Public Sub Add(Of TArg1, TArg2)(ByVal list As List(Of Tuple(Of TArg1, TArg2)), ByVal arg1 As TArg1, ByVal arg2 As TArg2)
        list.Add(New Tuple(Of TArg1, TArg2)(arg1, arg2))
    End Sub
End Module
