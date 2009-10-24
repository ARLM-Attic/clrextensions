'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
Imports ClrExtensions.Collections


#If ClrVersion < 35 Then
Public Delegate Sub Action()
Public Delegate Sub Action(Of T1)(ByVal arg1 As T1)
Public Delegate Sub Action(Of T1, T2)(ByVal arg1 As T1, ByVal arg2 As T2)
Public Delegate Sub Action(Of T1, T2, T3)(ByVal arg1 As T1, ByVal arg2 As T2, ByVal arg3 As T3)
Public Delegate Sub Action(Of T1, T2, T3, T4)(ByVal arg1 As T1, ByVal arg2 As T2, ByVal arg3 As T3, ByVal arg4 As T4)
Public Delegate Sub Action(Of T1, T2, T3, T4, T5)(ByVal arg1 As T1, ByVal arg2 As T2, ByVal arg3 As T3, ByVal arg4 As T4, ByVal arg5 As T5)
Public Delegate Sub Action(Of T1, T2, T3, T4, T5, T6)(ByVal arg1 As T1, ByVal arg2 As T2, ByVal arg3 As T3, ByVal arg4 As T4, ByVal arg5 As T5, ByVal arg6 As T6)
Public Delegate Sub Action(Of T1, T2, T3, T4, T5, T6, T7)(ByVal arg1 As T1, ByVal arg2 As T2, ByVal arg3 As T3, ByVal arg4 As T4, ByVal arg5 As T5, ByVal arg6 As T6, ByVal arg7 As T7)
Public Delegate Sub Action(Of T1, T2, T3, T4, T5, T6, T7, T8)(ByVal arg1 As T1, ByVal arg2 As T2, ByVal arg3 As T3, ByVal arg4 As T4, ByVal arg5 As T5, ByVal arg6 As T6, ByVal arg7 As T7, ByVal arg8 As T8)
#End If

#If IncludeUntested Then

Public Module ActionExtensions

    ''' <summary>
    ''' Calls the action N times
    ''' </summary>
    ''' <param name="action">An action delegate to call</param>
    ''' <param name="occurances">The number of times the action is called</param>
    ''' <remarks></remarks>
    <Untested()>
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
    <Untested()>
    <Extension()> Public Sub Repeat(ByVal action As Action(Of Integer), ByVal occurances As Integer)
        For i = 1 To occurances
            action.Invoke(i)
        Next
    End Sub

End Module
#End If