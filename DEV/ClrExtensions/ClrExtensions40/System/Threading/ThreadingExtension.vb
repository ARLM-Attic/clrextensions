'Copyright (c) 2008, Jonathan Allen

#If IncludeUntested Then

Public Module ThreadExtension
    'The generic Volatile Read and Write are described in http://www.panopticoncentral.net/archive/2004/09/30/1721.aspx
    'C# don't need them, instead use the volatile keyword

    ''' <summary>
    ''' Perform a Volatile Read on a variable
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="address"></param>
    ''' <returns></returns>
    ''' <remarks>C# doesn't need this, instead use the volatile keyword</remarks>
 <untested>   Function VolatileRead(Of T)(ByRef address As T) As T
        VolatileRead = address
        Threading.Thread.MemoryBarrier()
    End Function

    ''' <summary>
    ''' Perform a Volatile Write on a variable
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="address"></param>
    ''' <param name="value"></param>
    ''' <remarks>C# doesn't need this, instead use the volatile keyword</remarks>
 <untested>   Sub VolatileWrite(Of T)(ByRef address As T, ByVal value As T)
        Threading.Thread.MemoryBarrier()
        address = value
    End Sub

    ''' <summary>
    ''' Sleeps for a period of minutes and seconds
    ''' </summary>
    ''' <param name="minutes"></param>
    ''' <param name="seconds"></param>
    ''' <remarks></remarks>
<untested>    Sub Sleep(ByVal minutes As Integer, ByVal seconds As Integer)
        Threading.Thread.Sleep((minutes * 60 + seconds) * 1000)
    End Sub

End Module

#End If