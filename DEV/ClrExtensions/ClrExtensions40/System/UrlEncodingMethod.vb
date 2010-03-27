'Copyright (c) 2008, Jonathan Allen
#If IncludeUntested Then

''' <summary>
''' This is used to indicate which URL Encoding algorythm should be used.
''' </summary>
''' <remarks></remarks>
Public Enum UrlEncodingMethod

    ''' <summary>
    ''' Use this to signify the value was already encoded. The operation thus becomes a no-op.
    ''' </summary>
    ''' <remarks></remarks>
    DoNoEncode = -1

    ''' <summary>
    ''' The method used by the .NET framework's HttpUtility class
    ''' </summary>
    ''' <remarks></remarks>
    Clr = 0
    ''' <summary>
    ''' The method used by the OAuth specification
    ''' </summary>
    ''' <remarks></remarks>
    OAuth
End Enum

#End If