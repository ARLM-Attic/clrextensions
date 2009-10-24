'Copyright (c) 2008, Jonathan Allen


#If IncludeUntested Then

''' <summary>
''' This dictionary has a one-to-one mapping between "keys" and "values", making it cheap to go from a value back to a key
''' </summary>
''' <typeparam name="TLeft">The left-hand key</typeparam>
''' <typeparam name="TRight">The right-hand key</typeparam>
''' <remarks></remarks>
Public Class TwoWayDictionary(Of TLeft, TRight)
    Private m_FromLeft As New Dictionary(Of TLeft, TRight)
    Private m_FromRight As New Dictionary(Of TRight, TLeft)

    <Untested()>
    Public Sub New()

    End Sub

    <Untested()>
    Public Sub Add(ByVal left As TLeft, ByVal right As TRight)
        m_FromLeft.Add(left, right)
        m_FromRight.Add(right, left)
    End Sub

    <Untested()>
    Public Function RightItem(ByVal left As TLeft) As TRight
        Return m_FromLeft(left)
    End Function

    <Untested()>
    Function LeftItem(ByVal right As TRight) As TLeft
        Return m_FromRight(right)
    End Function

    <Untested()>
Public Function ContainsLeft(ByVal left As TLeft) As Boolean
        Return m_FromLeft.ContainsKey(left)
    End Function

    <Untested()>
Public Function ContainsRight(ByVal right As TRight) As Boolean
        Return m_FromRight.ContainsKey(right)
    End Function

    <Untested()>
Public Function RemoveLeft(ByVal left As TLeft) As Boolean
        Return m_FromLeft.Remove(left)
    End Function

    <Untested()>
Public Function RemoveRight(ByVal right As TRight) As Boolean
        Return m_FromRight.Remove(right)
    End Function

    <Untested()>
Public Function ToLeftDictionary() As Dictionary(Of TLeft, TRight)
        Return New Dictionary(Of TLeft, TRight)(m_FromLeft)
    End Function

    <Untested()>
Public Function ToRightDictionary() As Dictionary(Of TRight, TLeft)
        Return New Dictionary(Of TRight, TLeft)(m_FromRight)
    End Function

    <Untested()>
    Public ReadOnly Property Count() As Integer
        Get
            Return m_FromLeft.Count
        End Get
    End Property

    <Untested()>
Public Sub Clear()
        m_FromLeft.Clear()
        m_FromRight.Clear()
    End Sub

    <Untested()>
Public Function LeftKeys() As Dictionary(Of TLeft, TRight).KeyCollection
        Return m_FromLeft.Keys
    End Function

    <Untested()>
Public Function RightKeys() As Dictionary(Of TRight, TLeft).KeyCollection
        Return m_FromRight.Keys
    End Function

End Class

#End If