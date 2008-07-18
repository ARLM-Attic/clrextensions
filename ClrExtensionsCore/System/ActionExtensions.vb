Imports System.Runtime.InteropServices
Imports ClrExtensions.System.Collections


Module ActionExtensions
#If IncludeUntested Then

    <Untested()> <Extension()> Public Sub Repeat(ByVal action As Action, ByVal occurances As Integer)
        For i = 0 To occurances
            action.Invoke()
        Next
    End Sub

    <Untested()> <Extension()> Public Sub Repeat(ByVal action As Action(Of Integer), ByVal occurances As Integer)
        For i = 0 To occurances
            action.Invoke(i)
        Next
    End Sub
#End If
End Module
