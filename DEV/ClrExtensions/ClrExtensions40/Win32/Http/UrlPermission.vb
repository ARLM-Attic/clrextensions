'Copyright (c) 2008, Jonathan Allen
#If IncludeUntested Then

Namespace Win32.Http
    <Flags()> Public Enum UrlPermission
        None = 0
        Registration = 1 'GX
        Delegation = 2 'GW
        All = 4 'GA
    End Enum
End Namespace
#End If