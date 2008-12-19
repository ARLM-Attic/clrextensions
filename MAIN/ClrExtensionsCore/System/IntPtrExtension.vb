'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices

Public Module IntPtrExtension

    ''' <summary>
    ''' Retrives the structure at the indicated location
    ''' </summary>
    ''' <typeparam name="T">The type of structure expected</typeparam>
    ''' <param name="pointer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()> Public Function ToStruct(Of T As Structure)(ByVal pointer As IntPtr) As T
        Return DirectCast(Marshal.PtrToStructure(pointer, GetType(T)), T)
    End Function

End Module
