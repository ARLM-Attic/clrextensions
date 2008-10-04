Imports System.Runtime.InteropServices
Imports ClrExtensions.System.Collections


Public Module CollectionExtension



    ''' <summary>
    ''' This creates an AddRange method on all strongly typed collections that don't already have one.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="target">The list that will be updated</param>
    ''' <param name="source">The list that will be copied into the target list</param>
    ''' <remarks></remarks>
    <Extension()> Sub AddRange(Of T)(ByVal target As ICollection(Of T), ByVal source As IEnumerable(Of T))
        For Each item In source
            target.Add(item)
        Next
    End Sub


End Module
