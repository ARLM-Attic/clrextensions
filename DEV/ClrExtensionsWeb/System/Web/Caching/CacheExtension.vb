Imports ClrExtensions

#If IncludeUntested Then

Public Module CacheExtension
    <Untested()> <Extension()> Public Sub Clear(ByVal this As Web.Caching.Cache)
        For Each key In this.GetEnumerator.Keys(Of String)()
            this.Remove(key)
        Next
    End Sub

End Module

#End If