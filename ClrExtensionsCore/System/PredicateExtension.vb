'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
Imports ClrExtensions.System.Collections


Module PredicateExtension
#If IncludeUntested Then

    ''' <summary>
    ''' Converts a Predicate into a Func(Of T, Boolean)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="predicate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Public Function ToFunction(Of T)(ByVal predicate As Predicate(Of T)) As Func(Of T, Boolean)
        Dim result As Func(Of T, Boolean) = Function(item) predicate.Invoke(item)
        Return result
    End Function
#End If
End Module
