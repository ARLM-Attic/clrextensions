Imports System.Runtime.InteropServices
Imports ClrExtensions.System.Collections


Module PredicateExtension
#If IncludeUntested Then

    <Untested()> <Extension()> Public Function ToFunction(Of T)(ByVal predicate As Predicate(Of T)) As Func(Of T, Boolean)
        Dim result As Func(Of T, Boolean) = Function(item) predicate.Invoke(item)
        Return result
    End Function
#End If
End Module
