
Public Class TwoWayDictionary(Of TLeft, TRight)
    Private m_FromLeft As New Dictionary(Of TLeft, TRight)
    Private m_FromRight As New Dictionary(Of TRight, TLeft)

    Public Sub New()

    End Sub

    Public Sub Add(ByVal left As TLeft, ByVal right As TRight)
        m_FromLeft.Add(left, right)
        m_FromRight.Add(right, left)
    End Sub

    Public Function RightItem(ByVal left As TLeft) As TRight
        Return m_FromLeft(left)
    End Function

    Public Function LeftItem(ByVal right As TRight) As TLeft
        Return m_FromRight(right)
    End Function

    Public Function ContainsLeft(ByVal left As TLeft) As Boolean
        Return m_FromLeft.ContainsKey(left)
    End Function

    Public Function ContainsRight(ByVal right As TRight) As Boolean
        Return m_FromRight.ContainsKey(right)
    End Function

    Public Function RemoveLeft(ByVal left As TLeft) As Boolean
        Return m_FromLeft.Remove(left)
    End Function

    Public Function RemoveRight(ByVal right As TRight) As Boolean
        Return m_FromRight.Remove(right)
    End Function

    Public Function ToLeftDictionary() As Dictionary(Of TLeft, TRight)
        Return New Dictionary(Of TLeft, TRight)(m_FromLeft)
    End Function

    Public Function ToRightDictionary() As Dictionary(Of TRight, TLeft)
        Return New Dictionary(Of TRight, TLeft)(m_FromRight)
    End Function

    Public ReadOnly Property Count() As Integer
        Get
            Return m_FromLeft.Count
        End Get
    End Property

    Public Sub Clear()
        m_FromLeft.Clear()
        m_FromRight.Clear()
    End Sub

    Public Function LeftKeys() As Dictionary(Of TLeft, TRight).KeyCollection
        Return m_FromLeft.Keys
    End Function

    Public Function RightKeys() As Dictionary(Of TRight, TLeft).KeyCollection
        Return m_FromRight.Keys
    End Function

End Class
