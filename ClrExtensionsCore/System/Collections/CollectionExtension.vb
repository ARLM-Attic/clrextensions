Imports System.Runtime.InteropServices
Imports ClrExtensions.System.Collections


Public Module CollectionExtension

#If IncludeUntested Then

    <Untested()> <Extension()> Sub AddRange(Of T)(ByVal target As ICollection(Of T), ByVal list As IEnumerable(Of T))
        For Each item In list
            target.Add(item)
        Next
    End Sub
#End If

End Module
