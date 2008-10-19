'Copyright (c) 2008, Jonathan Allen

Namespace Collections

	''' <summary>
	''' This represents a triplet of values
	''' </summary>
	''' <typeparam name="TA"></typeparam>
	''' <typeparam name="TB"></typeparam>
	''' <typeparam name="TC"></typeparam>
	''' <remarks></remarks>
	Public Class Tuple(Of TA, TB, TC)
		Implements IEquatable(Of Tuple(Of TA, TB, TC))

		Private m_A As TA
		Private m_B As TB
		Private m_C As TC

		Public ReadOnly Property C() As TC
			Get
				Return m_C
			End Get
		End Property

		Public ReadOnly Property B() As TB
			Get
				Return m_B
			End Get
		End Property

		Public ReadOnly Property A() As TA
			Get
				Return m_A
			End Get
		End Property

		Public Sub New(ByVal a As TA, ByVal b As TB, ByVal c As TC)
			m_A = a
			m_B = b
			m_C = c
		End Sub

		Public Overrides Function Equals(ByVal obj As Object) As Boolean
			If Not TypeOf obj Is Tuple(Of TA, TB, TC) Then Return False
			Return Me.Equals(DirectCast(obj, Tuple(Of TA, TB, TC)))
		End Function


		Public Overrides Function GetHashCode() As Integer
			Dim result = 0

			If m_A IsNot Nothing Then result = result Xor m_A.GetHashCode
			If m_B IsNot Nothing Then result = result Xor m_B.GetHashCode
			If m_C IsNot Nothing Then result = result Xor m_C.GetHashCode

			Return result
		End Function

		Public Overloads Function Equals(ByVal other As Tuple(Of TA, TB, TC)) As Boolean Implements IEquatable(Of Tuple(Of TA, TB, TC)).Equals
			Return Object.Equals(A, other.A) AndAlso Object.Equals(B, other.B) AndAlso Object.Equals(C, other.C)
		End Function
	End Class
End Namespace
