Imports System.Runtime.InteropServices
Imports ClrExtensions.Collections

#If IncludeUntested Then
Module StreamReaderExtension
	<Untested()> <Extension()> Function Enumerate(ByVal stream As Global.System.IO.StreamReader) As IEnumerator(Of String)
		Return New StreamReaderEnumerator(stream)
	End Function

	<Untested()> Friend Class StreamReaderEnumerator
		Implements IEnumerator(Of String)
		Private ReadOnly m_Stream As Global.System.IO.StreamReader
		Private m_CurrentLine As String

		Public Sub New(ByVal stream As Global.System.IO.StreamReader)
			m_Stream = stream
		End Sub


		Private ReadOnly Property Current() As String Implements Global.System.Collections.Generic.IEnumerator(Of String).Current
			Get
				Return m_CurrentLine
			End Get
		End Property

		Private ReadOnly Property Current1() As Object Implements Global.System.Collections.IEnumerator.Current
			Get
				Return m_CurrentLine
			End Get
		End Property

		Private Function MoveNext() As Boolean Implements Global.System.Collections.IEnumerator.MoveNext
			m_CurrentLine = m_Stream.ReadLine
			Return m_CurrentLine IsNot Nothing
		End Function

		Private Sub Reset() Implements Global.System.Collections.IEnumerator.Reset
			m_CurrentLine = Nothing
			m_Stream.BaseStream.Position = 0
		End Sub

		Private m_Disposed As Boolean = False		' To detect redundant calls

		Protected Overridable Sub Dispose(ByVal disposing As Boolean)
			If Not Me.m_Disposed Then
				If disposing Then
					m_Stream.Dispose()
				End If
			End If
			Me.m_Disposed = True
		End Sub

		Private Sub Dispose() Implements IDisposable.Dispose
			Dispose(True)
		End Sub

	End Class

End Module


Namespace IO

	''' <summary>
	''' This class prevents the underlying stream from being closed by a higher level wrapper like StreamReader
	''' </summary>
	''' <remarks></remarks>
	<Untested()> Class StreamProtector
		Inherits Global.System.IO.Stream
		Private m_BaseStream As Global.System.IO.Stream

		Public Overrides ReadOnly Property CanRead() As Boolean
			Get
				Return m_BaseStream.CanRead
			End Get
		End Property

		Public Overrides ReadOnly Property CanSeek() As Boolean
			Get
				Return m_BaseStream.CanRead
			End Get
		End Property

		Public Overrides ReadOnly Property CanWrite() As Boolean
			Get
				Return m_BaseStream.CanWrite
			End Get
		End Property

		Public Overrides Sub Flush()
			m_BaseStream.Flush()
		End Sub

		Public Overrides ReadOnly Property Length() As Long
			Get
				Return m_BaseStream.Length
			End Get
		End Property

		Public Overrides Property Position() As Long
			Get
				Return m_BaseStream.Position
			End Get
			Set(ByVal value As Long)
				m_BaseStream.Position = value
			End Set
		End Property

		Public Overrides Function Read(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer) As Integer
			Return m_BaseStream.Read(buffer, offset, count)
		End Function

		Public Overrides Function Seek(ByVal offset As Long, ByVal origin As Global.System.IO.SeekOrigin) As Long
			Return m_BaseStream.Seek(offset, origin)
		End Function

		Public Overrides Sub SetLength(ByVal value As Long)
			m_BaseStream.SetLength(value)
		End Sub

		Public Overrides Sub Write(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer)
			m_BaseStream.Write(buffer, offset, count)
		End Sub

		Public Overrides Function BeginRead(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer, ByVal callback As Global.System.AsyncCallback, ByVal state As Object) As Global.System.IAsyncResult
			Return m_BaseStream.BeginRead(buffer, offset, count, callback, state)
		End Function

		Public Overrides Function BeginWrite(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer, ByVal callback As Global.System.AsyncCallback, ByVal state As Object) As Global.System.IAsyncResult
			Return m_BaseStream.BeginWrite(buffer, offset, count, callback, state)
		End Function

		Public Overrides ReadOnly Property CanTimeout() As Boolean
			Get
				Return m_BaseStream.CanTimeout
			End Get
		End Property

		Public Overrides Sub Close()
			'NOP
        End Sub

#If Client35 Then
        		Public Overrides Function CreateObjRef(ByVal requestedType As Global.System.Type) As Global.System.Runtime.Remoting.ObjRef
			'TODO find out what this function actually does in this context
			Throw New NotSupportedException
		End Function
#End If

		Public Overrides Function EndRead(ByVal asyncResult As Global.System.IAsyncResult) As Integer
			Return m_BaseStream.EndRead(asyncResult)
		End Function

		Public Overrides Sub EndWrite(ByVal asyncResult As Global.System.IAsyncResult)
			m_BaseStream.EndWrite(asyncResult)
		End Sub

		Public Overrides Function ReadByte() As Integer
			Return m_BaseStream.ReadByte()
		End Function

		Public Overrides Property ReadTimeout() As Integer
			Get
				Return m_BaseStream.ReadTimeout
			End Get
			Set(ByVal value As Integer)
				m_BaseStream.ReadTimeout = value
			End Set
		End Property


		Public Overrides Sub WriteByte(ByVal value As Byte)
			m_BaseStream.WriteByte(value)
		End Sub

		Public Overrides Property WriteTimeout() As Integer
			Get
				Return m_BaseStream.WriteTimeout
			End Get
			Set(ByVal value As Integer)
				m_BaseStream.WriteTimeout = value
			End Set
		End Property

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			'NOP
			GC.SuppressFinalize(Me)
		End Sub
	End Class


End Namespace
#End If