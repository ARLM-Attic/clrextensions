'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
Imports ClrExtensions.System.Collections


Public Module ActionExtensions

    ''' <summary>
    ''' Calls the action N times
    ''' </summary>
    ''' <param name="action">An action delegate to call</param>
    ''' <param name="occurances">The number of times the action is called</param>
    ''' <remarks></remarks>
    <Extension()> Public Sub Repeat(ByVal action As Action, ByVal occurances As Integer)
        For i = 1 To occurances
            action.Invoke()
        Next
    End Sub

    ''' <summary>
    ''' Calls the action N times, passing the number 1 to N to the action
    ''' </summary>
    ''' <param name="action">An action delegate to call</param>
    ''' <param name="occurances">The number of times the action is called</param>
    ''' <remarks>Note that this is 1 based, not 0 based</remarks>
    <Extension()> Public Sub Repeat(ByVal action As Action(Of Integer), ByVal occurances As Integer)
        For i = 1 To occurances
            action.Invoke(i)
        Next
    End Sub

End Module
