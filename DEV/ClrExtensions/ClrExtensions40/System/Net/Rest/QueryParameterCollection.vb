'Copyright (c) 2008, Jonathan Allen
Imports System.Collections.Specialized
#If Subset <> "Client" Then
#If IncludeUntested Then

Namespace Net.Rest

    Public Class QueryParameterCollection
        Inherits ObjectModel.Collection(Of QueryParameter)

        <Untested()>
        Public Sub New()

        End Sub
        <Untested()>
        Public Sub New(ByVal queryString As String)
            AddByParsing(queryString)
        End Sub

#If ClrVersion > 0 Then
        <Untested()>
        Public Sub AddRange(ByVal values As System.Collections.Specialized.NameValueCollection)
            If values Is Nothing Then Throw New ArgumentNullException("values")
            Contract.EndContractBlock()

            For Each key As String In values.Keys
                Me.Add(New QueryParameter(key, values(key)))
            Next
        End Sub
#End If

        <Untested()>
        Public Sub AddByParsing(ByVal queryString As String)
            Me.AddRange(ParseQueryString(queryString))
        End Sub

        <Untested()>
        Default Public Overloads ReadOnly Property Item(ByVal key As String) As String
            Get
                For Each param In Me
                    If String.Equals(param.Name, key, StringComparison.OrdinalIgnoreCase) Then Return param.Value
                Next
                Return Nothing
            End Get
        End Property

        <Untested()>
        Private Shared Function ParseQueryString(ByVal queryString As String) As ObjectModel.Collection(Of QueryParameter)
            If queryString Is Nothing Then Throw New ArgumentNullException("queryString")
            Contract.EndContractBlock()

            Dim result As New ObjectModel.Collection(Of QueryParameter)
            Dim rows = queryString.Split("&"c) 'removed , StringSplitOptions.RemoveEmptyEntries because CF does not seem to understand
            Dim values() As String

            For Each item As String In rows
                values = item.Split("="c) 'little c insure conversion to char, option explicit does not allow string to implicit cast to char
                result.Add(New QueryParameter(values(0).Trim, values(1).Trim))
            Next

            Return result
        End Function


    End Class
End Namespace
#End If
#End If