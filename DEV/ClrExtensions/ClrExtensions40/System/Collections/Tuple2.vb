'Copyright (c) 2008, Jonathan Allen


Namespace Collections

#If ClrVersion < 40 Then

	''' <summary>
	''' This repesents a pair of values
	''' </summary>
	''' <typeparam name="T1"></typeparam>
	''' <typeparam name="T2"></typeparam>
	''' <remarks></remarks>
	Public Class Tuple(Of T1, T2)
		Implements IEquatable(Of Tuple(Of T1, T2))

		Private m_Item1 As T1
		Private m_Item2 As T2


		ReadOnly Property Item2() As T2
			Get
				Return m_Item2
			End Get
		End Property


		ReadOnly Property Item1() As T1
			Get
				Return m_Item1
			End Get
		End Property


		Sub New(ByVal item1 As T1, ByVal item2 As T2)
			m_Item1 = item1
			m_Item2 = item2
		End Sub


		Overrides Function Equals(ByVal obj As Object) As Boolean
			If Not TypeOf obj Is Tuple(Of T1, T2) Then Return False
			Return Me.Equals(DirectCast(obj, Tuple(Of T1, T2)))
		End Function


		Overrides Function GetHashCode() As Integer
			Dim result = 0

			If m_Item1 IsNot Nothing Then result = result Xor m_Item1.GetHashCode
			If m_Item2 IsNot Nothing Then result = result Xor m_Item2.GetHashCode

			Return result
		End Function


		Overloads Function Equals(ByVal other As Tuple(Of T1, T2)) As Boolean Implements IEquatable(Of Tuple(Of T1, T2)).Equals
			If other Is Nothing Then Return False
			Return Object.Equals(Item1, other.Item1) AndAlso Object.Equals(Item2, other.Item2)
		End Function
	End Class
#End If

End Namespace
