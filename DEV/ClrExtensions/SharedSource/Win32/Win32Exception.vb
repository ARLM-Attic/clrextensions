'Copyright (c) 2008, Jonathan Allen
#If IncludeUntested Then

Namespace Win32

    Class Win32Exception
        Inherits Exception

        <Untested()>
            Public Sub New(ByVal errorCode As SystemErrorCode)
            MyBase.New("Win32 System Error " & errorCode.ToString)
            m_ErrorCode = errorCode
        End Sub

        Private m_ErrorCode As SystemErrorCode

        <Untested()>
        Public ReadOnly Property ErrorCode() As SystemErrorCode
            Get
                Return m_ErrorCode
            End Get
        End Property

    End Class
End Namespace
#End If