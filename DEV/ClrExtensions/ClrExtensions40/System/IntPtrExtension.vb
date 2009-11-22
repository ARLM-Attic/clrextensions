'Copyright (c) 2008, Jonathan Allen

Imports System.Runtime.InteropServices
#If IncludeUntested Then

Public Module IntPtrExtension

    ''' <summary>
    ''' Retrives the structure at the indicated location
    ''' </summary>
    ''' <typeparam name="T">The type of structure expected</typeparam>
    ''' <param name="pointer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId:="pointer")>
    <Untested()>
    <Extension()> Public Function ToStruct(Of T As Structure)(ByVal pointer As IntPtr) As T
        Return DirectCast(Marshal.PtrToStructure(pointer, GetType(T)), T)
    End Function

End Module
#End If