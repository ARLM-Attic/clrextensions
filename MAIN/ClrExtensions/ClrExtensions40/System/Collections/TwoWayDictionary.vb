'Copyright (c) 2008, Jonathan Allen


#If IncludeUntested Then

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

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")> <ContractInvariantMethod()> _
    Private Sub ObjectInvariant()
        Contract.Ensures(m_FromLeft.Count = m_FromRight.Count)
    End Sub


    <Untested()>
    <Pure()>
    Public Sub New()

    End Sub

    <Untested()>
    Public Sub Add(ByVal left As TLeft, ByVal right As TRight)
        Contract.Ensures(Count = Contract.OldValue(Count) + 1)

        m_FromLeft.Add(left, right)
        m_FromRight.Add(right, left)
    End Sub

    <Untested()>
    <Pure()>
    Public Function RightItem(ByVal left As TLeft) As TRight
        Return m_FromLeft(left)
    End Function

    <Untested()>
    <Pure()>
    Function LeftItem(ByVal right As TRight) As TLeft
        Return m_FromRight(right)
    End Function

    <Untested()>
    <Pure()>
    Public Function ContainsLeft(ByVal left As TLeft) As Boolean
        Return m_FromLeft.ContainsKey(left)
    End Function

    <Untested()>
    <Pure()>
    Public Function ContainsRight(ByVal right As TRight) As Boolean
        Return m_FromRight.ContainsKey(right)
    End Function

    <Untested()>
    Public Function RemoveLeft(ByVal left As TLeft) As Boolean
        Contract.Ensures(Count = Contract.OldValue(Count) Or Count = Contract.OldValue(Count) + 1)
        Return m_FromLeft.Remove(left)
    End Function

    <Untested()>
    Public Function RemoveRight(ByVal right As TRight) As Boolean
        Contract.Ensures(Count = Contract.OldValue(Count) Or Count = Contract.OldValue(Count) + 1)
        Return m_FromRight.Remove(right)
    End Function

    <Untested()>
    <Pure()>
    Public Function ToLeftDictionary() As Dictionary(Of TLeft, TRight)
        Return New Dictionary(Of TLeft, TRight)(m_FromLeft)
    End Function

    <Untested()>
    <Pure()>
    Public Function ToRightDictionary() As Dictionary(Of TRight, TLeft)
        Return New Dictionary(Of TRight, TLeft)(m_FromRight)
    End Function

    <Untested()>
    <Pure()>
    Public ReadOnly Property Count() As Integer
        Get
            Return m_FromLeft.Count
        End Get
    End Property

    <Untested()>
    Public Sub Clear()
        Contract.Ensures(Count = 0)
        m_FromLeft.Clear()
        m_FromRight.Clear()
    End Sub

    <Untested()>
    <Pure()>
    Public Function LeftKeys() As Dictionary(Of TLeft, TRight).KeyCollection
        Return m_FromLeft.Keys
    End Function

    <Untested()>
    <Pure()>
    Public Function RightKeys() As Dictionary(Of TRight, TLeft).KeyCollection
        Return m_FromRight.Keys
    End Function

End Class

#End If