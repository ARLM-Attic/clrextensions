Namespace Win32
	Class Win32Exception
		Inherits Exception

		Public Sub New(ByVal errorCode As SystemErrorCode)
			MyBase.New("Win32 System Error " & errorCode.ToString)
			m_ErrorCode = errorCode
		End Sub

		Private m_ErrorCode As SystemErrorCode

		Public ReadOnly Property ErrorCode() As SystemErrorCode
			Get
				Return m_ErrorCode
			End Get
		End Property

	End Class
End Namespace