
Public Module MathExtension

	Public Function Primes() As IEnumerable(Of Integer)
		Return New PrimeGenerator
	End Function

	Private Class PrimeGenerator
		Implements IEnumerable(Of Integer)

		Public Function GetEnumerator() As Global.System.Collections.Generic.IEnumerator(Of Integer) Implements Global.System.Collections.Generic.IEnumerable(Of Integer).GetEnumerator
			Return New PrimeEnumerator
		End Function

		Public Function GetEnumerator1() As Global.System.Collections.IEnumerator Implements Global.System.Collections.IEnumerable.GetEnumerator
			Return New PrimeEnumerator
		End Function
	End Class

	Private Class PrimeEnumerator
		Implements IEnumerator(Of Integer)

		Private m_List As New List(Of Integer)
		Private m_CurrentIndex As Integer = -1

		Friend Sub New()
			m_List.Add(2)
			m_List.Add(3)
		End Sub

		Public ReadOnly Property Current() As Integer Implements Global.System.Collections.Generic.IEnumerator(Of Integer).Current
			Get
				Return m_List(m_CurrentIndex)
			End Get
		End Property

		Private ReadOnly Property Current1() As Object Implements Global.System.Collections.IEnumerator.Current
			Get
				Return Current
			End Get
		End Property

		Public Function MoveNext() As Boolean Implements Global.System.Collections.IEnumerator.MoveNext
			m_CurrentIndex += 1

			If m_CurrentIndex = m_List.Count Then 'find next prime
				Dim canidate As Integer = m_List(m_List.Count - 1) + 2 'we know we only wnat odds

				Do
					For Each factor In m_List
						If canidate Mod factor = 0 Then GoTo NextCanidate
					Next
					m_List.Add(canidate)
					Return True
NextCanidate:
					canidate += 2
				Loop

			End If
			Return True

		End Function

		Public Sub Reset() Implements Global.System.Collections.IEnumerator.Reset
			m_CurrentIndex = 0
		End Sub

		Private Sub Dispose() Implements IDisposable.Dispose
		End Sub

	End Class

End Module
