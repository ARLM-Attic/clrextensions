Imports System.Runtime.InteropServices

Public Module IntPtrExtension

    <Extension()> Public Function ToStruct(Of T As Structure)(ByVal pointer As IntPtr) As T
        Return DirectCast(Marshal.PtrToStructure(pointer, GetType(T)), T)
    End Function

End Module
