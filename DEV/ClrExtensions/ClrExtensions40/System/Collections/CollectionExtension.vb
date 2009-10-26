'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
Imports ClrExtensions.Collections

#If IncludeUntested Then

Public Module CollectionExtension



    ''' <summary>
    ''' This creates an AddRange method on all strongly typed collections that don't already have one.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="target">The list that will be updated</param>
    ''' <param name="source">The list that will be copied into the target list</param>
    ''' <remarks></remarks>
    <Untested()>
    <Extension()>
    Sub AddRange(Of T)(ByVal target As ICollection(Of T), ByVal source As IEnumerable(Of T))
        If target Is Nothing Then Throw New ArgumentNullException("target")
        If source Is Nothing Then Throw New ArgumentNullException("source")
        For Each item In source
            target.Add(item)
        Next
    End Sub


End Module
#End If