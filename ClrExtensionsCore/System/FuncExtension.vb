'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
Imports ClrExtensions.Collections


Module FuncExtension
#If IncludeUntested Then

    ''' <summary>
    ''' This converts a Func(Of T, Boolean) into a Predicate(Of T)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="func"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Public Function ToPredicate(Of T)(ByVal func As Func(Of T, Boolean)) As Predicate(Of T)
        Dim result As Predicate(Of T) = Function(item) func.Invoke(item)
        Return result
    End Function

    ''' <summary>
    ''' This creates a list by recursively applying a function
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="func"></param>
    ''' <param name="count"></param>
    ''' <param name="firstElement"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
    ''' <param name="func">The function to be called when the result isn't already known</param>
    ''' <returns>A function with the memorization wrapper around it</returns>
    ''' <remarks>The dictionary lookups are not cheap, so this may be slower than the mathematical operations you are memorizing</remarks>
    <Untested()> <Extension()> Public Function Memorize(Of T, TResult)(ByVal func As Func(Of T, TResult)) As Func(Of T, TResult)
        Dim dataStore As New Dictionary(Of T, TResult)

        Dim result As Func(Of T, TResult) = Function(a) If(dataStore.ContainsKey(a), dataStore(a), dataStore.StoreAndReturn(a, func(a)))
        Return result
    End Function

    ''' <summary>
    ''' This creates a function that memorizes every argument/result pair in order to speed up repeated, lengthy calculations. 
    ''' </summary>
    ''' <typeparam name="T1"></typeparam>
    ''' <typeparam name="T2"></typeparam>
    ''' <typeparam name="TResult"></typeparam>
    ''' <param name="func">The function to be called when the result isn't already known</param>
    ''' <returns>A function with the memorization wrapper around it</returns>
    ''' <remarks>The dictionary lookups are not cheap, so this may be slower than the mathematical operations you are memorizing</remarks>
    <Untested()> <Extension()> Public Function Memorize(Of T1, T2, TResult)(ByVal func As Func(Of T1, T2, TResult)) As Func(Of T1, T2, TResult)
        Dim dataStore As New Dictionary(Of T1, T2, TResult)

        Dim result As Func(Of T1, T2, TResult) = Function(a, b) If(dataStore.ContainsKey(a, b), dataStore(a, b), dataStore.StoreAndReturn(a, b, func(a, b)))
        Return result
    End Function

    ''' <summary>
    ''' This creates a function that memorizes every argument/result pair in order to speed up repeated, lengthy calculations. 
    ''' </summary>
    ''' <typeparam name="T1"></typeparam>
    ''' <typeparam name="T2"></typeparam>
    ''' <typeparam name="T3"></typeparam>
    ''' <typeparam name="TResult"></typeparam>
    ''' <param name="func">The function to be called when the result isn't already known</param>
    ''' <returns>A function with the memorization wrapper around it</returns>
    ''' <remarks>The dictionary lookups are not cheap, so this may be slower than the mathematical operations you are memorizing</remarks>
    <Untested()> <Extension()> Public Function Memorize(Of T1, T2, T3, TResult)(ByVal func As Func(Of T1, T2, T3, TResult)) As Func(Of T1, T2, T3, TResult)
        Dim dataStore As New Dictionary(Of T1, T2, T3, TResult)

        Dim result As Func(Of T1, T2, T3, TResult) = Function(a, b, c) If(dataStore.ContainsKey(a, b, c), dataStore(a, b, c), dataStore.StoreAndReturn(a, b, c, func(a, b, c)))
        Return result
    End Function
#End If

End Module
