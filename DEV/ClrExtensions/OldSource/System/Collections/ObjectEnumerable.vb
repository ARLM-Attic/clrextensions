'Copyright (c) 2008, Jonathan Allen

Imports ClrExtensions.Collections
Namespace Collections
#If IncludeUntested Then


    Friend Class ObjectEnumerable
        Implements IEnumerable(Of Object)
        Private m_Source As IEnumerable

        <Untested()>
        Public Sub New(ByVal souce As IEnumerable)
            m_Source = souce
        End Sub

        <Untested()>
        Public Function GetEnumerator() As IEnumerator(Of Object) Implements IEnumerable(Of Object).GetEnumerator
            Return New ObjectEnumerator(m_Source.GetEnumerator)
        End Function

        <Untested()>
        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return m_Source.GetEnumerator
        End Function
    End Class

#End If
End Namespace