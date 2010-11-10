'Copyright (c) 2008, Jonathan Allen


#If 1 = 1 Then

''' <summary>
''' This dictionary has a one-to-one mapping between "keys" and "values", making it cheap to go from a value back to a key
''' </summary>
''' <typeparam name="TLeft">The left-hand key</typeparam>
''' <typeparam name="TRight">The right-hand key</typeparam>
''' <remarks></remarks>
<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")>
Public Class TwoWayDictionary(Of TLeft, TRight)
    Private ReadOnly m_FromLeft As New Dictionary(Of TLeft, TRight)
    Private ReadOnly m_FromRight As New Dictionary(Of TRight, TLeft)

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")> Private Sub ObjectInvariant()
    End Sub


    
    Sub New()
    End Sub

    
    Sub Add(ByVal left As TLeft, ByVal right As TRight)

        m_FromLeft.Add(left, right)
        m_FromRight.Add(right, left)
    End Sub

    
    Function RightItem(ByVal left As TLeft) As TRight
        Return m_FromLeft(left)
    End Function

    
    Function LeftItem(ByVal right As TRight) As TLeft
        Return m_FromRight(right)
    End Function

    
    Function ContainsLeft(ByVal left As TLeft) As Boolean
        Return m_FromLeft.ContainsKey(left)
    End Function

    
    Function ContainsRight(ByVal right As TRight) As Boolean
        Return m_FromRight.ContainsKey(right)
    End Function

    
    Function RemoveLeft(ByVal left As TLeft) As Boolean
        Return m_FromLeft.Remove(left)
    End Function

    
    Function RemoveRight(ByVal right As TRight) As Boolean
        Return m_FromRight.Remove(right)
    End Function

    
    Function ToLeftDictionary() As Dictionary(Of TLeft, TRight)
        Return New Dictionary(Of TLeft, TRight)(m_FromLeft)
    End Function

    
    Function ToRightDictionary() As Dictionary(Of TRight, TLeft)
        Return New Dictionary(Of TRight, TLeft)(m_FromRight)
    End Function

    
    ReadOnly Property Count() As Integer
        Get
            Return m_FromLeft.Count
        End Get
    End Property

    
    Sub Clear()
        m_FromLeft.Clear()
        m_FromRight.Clear()
    End Sub

    
    Function LeftKeys() As Dictionary(Of TLeft, TRight).KeyCollection
        Return m_FromLeft.Keys
    End Function

    
    Function RightKeys() As Dictionary(Of TRight, TLeft).KeyCollection
        Return m_FromRight.Keys
    End Function

End Class

#End If