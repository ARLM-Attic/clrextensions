'Copyright (c) 2008, Jonathan Allen

Imports ClrExtensions.Collections
Namespace Collections
#If IncludeUntested Then


    Friend Class ObjectEnumerable
        Implements IEnumerable(Of Object)
        Private ReadOnly m_Source As IEnumerable

        <Untested()>
        <Pure()>
        Public Sub New(ByVal source As IEnumerable)
            If source Is Nothing Then Throw New ArgumentNullException("source")
            Contract.EndContractBlock()

            m_Source = source
        End Sub

        <Untested()>
        <Pure()>
        Public Function GetEnumerator() As IEnumerator(Of Object) Implements IEnumerable(Of Object).GetEnumerator
            Return New ObjectEnumerator(m_Source.GetEnumerator)
        End Function

        <Untested()>
        <Pure()>
        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return m_Source.GetEnumerator
        End Function
    End Class

#End If
End Namespace