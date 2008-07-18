Imports System.Runtime.InteropServices
Imports ClrExtensions.System.Collections


Module FuncExtension
#If IncludeUntested Then

    <Untested()> <Extension()> Public Function ToPredicate(Of T)(ByVal func As Func(Of T, Boolean)) As Predicate(Of T)
        Dim result As Predicate(Of T) = Function(item) func.Invoke(item)
        Return result
    End Function

    <Untested()> <Extension()> Function CreateList(Of T)(ByVal func As Func(Of T, T), ByVal count As Integer, ByVal firstElement As T) As List(Of T)
        Dim result As New List(Of T)(count)
        Dim current = firstElement
        Do
            result.Add(current)
            current = func(current)
        Loop Until result.Count = count
        Return result
    End Function

    ''' <summary>
    ''' This creates a function that memorizes every argument/result pair in order to speed up repeated, lengthy calculations. 
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <typeparam name="TResult"></typeparam>
    ''' <param name="func"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Public Function Memorize(Of T, TResult)(ByVal func As Func(Of T, TResult)) As Func(Of T, TResult)
        Dim dataStore As New Dictionary(Of T, TResult)

        Dim result As Func(Of T, TResult) = Function(a) If(dataStore.ContainsKey(a), dataStore(a), StoreAndReturn(dataStore, a, func(a)))
        Return result
    End Function

    Private Function StoreAndReturn(Of TKey, TValue)(ByVal dictionary As Dictionary(Of TKey, TValue), ByVal key As TKey, ByVal value As TValue) As TValue
        dictionary(key) = value
        Return value
    End Function

    <Untested()> <Extension()> Public Function Memorize(Of T1, T2, TResult)(ByVal func As Func(Of T1, T2, TResult)) As Func(Of T1, T2, TResult)
        Dim dataStore As New Dictionary(Of T1, T2, TResult)

        Dim result As Func(Of T1, T2, TResult) = Function(a, b) If(dataStore.ContainsKey(a, b), dataStore(a, b), dataStore.StoreAndReturn(a, b, func(a, b)))
        Return result
    End Function

    <Untested()> <Extension()> Public Function Memorize(Of T1, T2, T3, TResult)(ByVal func As Func(Of T1, T2, T3, TResult)) As Func(Of T1, T2, T3, TResult)
        Dim dataStore As New Dictionary(Of T1, T2, T3, TResult)

        Dim result As Func(Of T1, T2, T3, TResult) = Function(a, b, c) If(dataStore.ContainsKey(a, b, c), dataStore(a, b, c), dataStore.StoreAndReturn(a, b, c, func(a, b, c)))
        Return result
    End Function
#End If
End Module
