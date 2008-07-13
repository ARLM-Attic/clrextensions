Imports System.Runtime.InteropServices

Namespace Win32

	''' <summary>
	''' This class turns a struct into an unmanaged pointer and back again. It should always be contained in a using block to ensure the memory it allocates is freed.
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <remarks></remarks>
	Public Class StructPointer(Of T As Structure)
		Implements IDisposable

		Private m_Pointer As IntPtr

		Public ReadOnly Property Pointer() As IntPtr
			Get
				Return m_Pointer
			End Get
		End Property

		''' <summary>
		''' This creates a zero-filled buffer of the specified size
		''' </summary>
		''' <param name="size"></param>
		''' <remarks></remarks>
		Public Sub New(ByVal size As Integer)
			m_Pointer = Marshal.AllocHGlobal(size)
			KernelApi.ZeroMemory(m_Pointer, size)
		End Sub

		''' <summary>
		''' This creates a buffer that contains the passed value
		''' </summary>
		''' <param name="value"></param>
		''' <remarks></remarks>
		Public Sub New(ByVal value As T)
			m_Pointer = Marshal.AllocHGlobal(Marshal.SizeOf(value))
			Marshal.StructureToPtr(value, m_Pointer, False)
		End Sub

		''' <summary>
		''' This turns the buffer back into a structure
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public ReadOnly Property [Structure]() As T
			Get
				Return DirectCast(Marshal.PtrToStructure(m_Pointer, GetType(T)), T)
			End Get
		End Property

		Private disposedValue As Boolean = False		' To detect redundant calls

		' IDisposable
		Protected Overridable Sub Dispose(ByVal disposing As Boolean)
			If Not Me.disposedValue Then
				If disposing Then
					' TODO: free other state (managed objects).
				End If

				Marshal.FreeHGlobal(m_Pointer)
			End If
			Me.disposedValue = True
		End Sub

#Region " IDisposable Support "
		' This code added by Visual Basic to correctly implement the disposable pattern.
		Public Sub Dispose() Implements IDisposable.Dispose
			' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
			Dispose(True)
			GC.SuppressFinalize(Me)
		End Sub
#End Region

	End Class
End Namespace
