'Copyright (c) 2008, Jonathan Allen

Imports ClrExtensions.Collections

#If IncludeUntested Then
Namespace Collections

    Friend Class TypeEnumerable(Of T)
        Implements IEnumerable(Of T)

        Private m_Source As IEnumerable

        <Untested()>
        Public Sub New(ByVal souce As IEnumerable)
            m_Source = souce
        End Sub

        <Untested()>
        Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
            Return New TypeEnumerator(Of T)(m_Source.GetEnumerator)
        End Function

        <Untested()>
        Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
            Return m_Source.GetEnumerator
        End Function
    End Class

End Namespace
#End If