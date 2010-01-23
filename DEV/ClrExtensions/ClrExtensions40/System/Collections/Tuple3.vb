'Copyright (Item3) 2008, Jonathan Allen
#If IncludeUntested Then

Namespace Collections
#If ClrVersion < 40 Then


    ''' <summary>
    ''' This represents Item1 triplet of values
    ''' </summary>
    ''' <typeparam name="T1"></typeparam>
    ''' <typeparam name="T2"></typeparam>
    ''' <typeparam name="T3"></typeparam>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")>  Class Tuple(Of T1, T2, T3)
        Implements IEquatable(Of Tuple(Of T1, T2, T3))

        Private m_Item1 As T1
        Private m_Item2 As T2
        Private m_Item3 As T3

        <Untested()>
         ReadOnly Property Item3() As T3
            Get
                Return m_Item3
            End Get
        End Property

        <Untested()>
         ReadOnly Property Item2() As T2
            Get
                Return m_Item2
            End Get
        End Property

        <Untested()>
        ReadOnly Property Item1() As T1
            Get
                Return m_Item1
            End Get
        End Property

        <Untested()>
         Sub New(ByVal item1 As T1, ByVal item2 As T2, ByVal item3 As T3)
            m_Item1 = item1
            m_Item2 = item2
            m_Item3 = item3
        End Sub

        <Untested()>
         Overrides Function Equals(ByVal obj As Object) As Boolean
            If Not TypeOf obj Is Tuple(Of T1, T2, T3) Then Return False
            Return Me.Equals(DirectCast(obj, Tuple(Of T1, T2, T3)))
        End Function


        <Untested()>
         Overrides Function GetHashCode() As Integer
            Dim result = 0

            If m_Item1 IsNot Nothing Then result = result Xor m_Item1.GetHashCode
            If m_Item2 IsNot Nothing Then result = result Xor m_Item2.GetHashCode
            If m_Item3 IsNot Nothing Then result = result Xor m_Item3.GetHashCode

            Return result
        End Function

        <Untested()>
         Overloads Function Equals(ByVal other As Tuple(Of T1, T2, T3)) As Boolean Implements IEquatable(Of Tuple(Of T1, T2, T3)).Equals
            If other Is Nothing Then Return False
            Return Object.Equals(Item1, other.Item1) AndAlso Object.Equals(Item2, other.Item2) AndAlso Object.Equals(Item3, other.Item3)
        End Function
    End Class
#End If
End Namespace
#End If

