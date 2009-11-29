'Copyright (c) 2008, Jonathan Allen

#If IncludeUntested Then

Public Module DictionaryExtension

    <Untested()>
    <Extension()> Public Function GetOrCreate(Of TKey, TValue)(ByVal dictionary As Dictionary(Of TKey, TValue), ByVal key As TKey, ByVal valueFunction As Func(Of TKey, TValue)) As TValue
        If dictionary Is Nothing Then Throw New ArgumentNullException("dictionary")
        If valueFunction Is Nothing Then Throw New ArgumentNullException("valueFunction")
        Contract.Ensures(dictionary.Count = Contract.OldValue(dictionary.Count) OrElse dictionary.Count = Contract.OldValue(dictionary.Count) + 1)

        If dictionary.ContainsKey(key) Then
            Return dictionary(key)
        Else
            Return dictionary.StoreAndReturn(key, valueFunction(key))
        End If
    End Function

    <Untested()>
   <Extension()> Public Function GetOrCreate(Of TKey, TValue)(ByVal dictionary As Dictionary(Of TKey, TValue), ByVal key As TKey, ByVal defaultValue As TValue) As TValue
        If dictionary Is Nothing Then Throw New ArgumentNullException("dictionary")
        Contract.Ensures(dictionary.Count = Contract.OldValue(dictionary.Count) OrElse dictionary.Count = Contract.OldValue(dictionary.Count) + 1)

        If dictionary.ContainsKey(key) Then
            Return dictionary(key)
        Else
            Return dictionary.StoreAndReturn(key, defaultValue)
        End If
    End Function

    ''' <summary>
    ''' Stores the value, then returns the same value
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks>This was created to support anonymous functions in VB that need to do more than one thing with a value in a single line. See the Memorize function for an example of its use</remarks>
    <Untested()> <Extension()> Public Function StoreAndReturn(Of TKey, TValue)(ByVal dictionary As Dictionary(Of TKey, TValue), ByVal key As TKey, ByVal value As TValue) As TValue
        If dictionary Is Nothing Then Throw New ArgumentNullException("dictionary")
        Contract.Ensures(dictionary.Count = Contract.OldValue(dictionary.Count) OrElse dictionary.Count = Contract.OldValue(dictionary.Count) + 1)

        dictionary(key) = value
        Return value
    End Function

    <Untested()>
   <Extension()> Sub ForEach(Of TKey, TValue)(ByVal source As IDictionary(Of TKey, TValue), ByVal action As Action(Of TKey, TValue))
        If source Is Nothing Then Throw New ArgumentNullException("source")
        If action Is Nothing Then Throw New ArgumentNullException("action")
        Contract.EndContractBlock()

        For Each item In source
            action.Invoke(item.Key, item.Value)
        Next
    End Sub

    <Untested()>
    <Pure()>
    <Extension()> Function Keys(ByVal this As IDictionaryEnumerator) As ObjectModel.Collection(Of Object)
        If this Is Nothing Then Throw New ArgumentNullException("this")
        Contract.Ensures(Contract.Result(Of ObjectModel.Collection(Of Object))() IsNot Nothing)
        Contract.EndContractBlock()

        Dim result As New ObjectModel.Collection(Of Object)
        Do While this.MoveNext
            result.Add(this.Key)
        Loop
        Return result
    End Function

    <Untested()>
    <Pure()>
    <Extension()> Function Values(ByVal this As IDictionaryEnumerator) As ObjectModel.Collection(Of Object)
        If this Is Nothing Then Throw New ArgumentNullException("this")
        Contract.Ensures(Contract.Result(Of ObjectModel.Collection(Of Object))() IsNot Nothing)
        Contract.EndContractBlock()

        Dim result As New ObjectModel.Collection(Of Object)
        Do While this.MoveNext
            result.Add(this.Value)
        Loop
        Return result
    End Function

    <Pure()>
    <Untested()> <Extension()> Function Entries(ByVal this As IDictionaryEnumerator) As ObjectModel.Collection(Of DictionaryEntry)
        If this Is Nothing Then Throw New ArgumentNullException("this")
        Contract.Ensures(Contract.Result(Of ObjectModel.Collection(Of DictionaryEntry))() IsNot Nothing)
        Contract.EndContractBlock()

        Dim result As New ObjectModel.Collection(Of DictionaryEntry)
        Do While this.MoveNext
            result.Add(this.Entry)
        Loop
        Return result
    End Function


    <Pure()>
    <Untested()> <Extension()> Function Keys(Of T)(ByVal this As IDictionaryEnumerator) As ObjectModel.Collection(Of T)
        If this Is Nothing Then Throw New ArgumentNullException("this")
        Contract.Ensures(Contract.Result(Of ObjectModel.Collection(Of T))() IsNot Nothing)
        Contract.EndContractBlock()

        Dim result As New ObjectModel.Collection(Of T)
        Do While this.MoveNext
            result.Add(CType(this.Key, T))
        Loop
        Return result
    End Function

#If ClrVersion >= 35 Then

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")>
    <Pure()>
    <Untested()> <Extension()> Function ToDictionary(Of TKey, TValue)(ByVal this As IEnumerable(Of KeyValuePair(Of TKey, TValue))) As Dictionary(Of TKey, TValue)
        If this Is Nothing Then Throw New ArgumentNullException("this")
        Contract.Ensures(Contract.Result(Of Dictionary(Of TKey, TValue))() IsNot Nothing)
        Contract.EndContractBlock()

        Return this.ToDictionary(Function(item) item.Key, Function(item) item.Value)
    End Function

    <Pure()> <Untested()> <Extension()> Public Function StringJoin(ByVal this As IDictionary(Of String, String), ByVal rowSeparator As String, ByVal columnSeparator As String) As String
        If this Is Nothing Then Throw New ArgumentNullException("this")
        Contract.Ensures(Contract.Result(Of String)() IsNot Nothing)
        Contract.EndContractBlock()

        Dim temp As New List(Of String)(this.Count)

        For Each item In this
            temp.Add(item.Key & columnSeparator & item.Value)
        Next
        Return temp.Join(rowSeparator)
    End Function


    <Pure()> <Untested()> <Extension()> Public Function StringJoin(ByVal this As IDictionary(Of String, String), ByVal separator As String) As String
        If this Is Nothing Then Throw New ArgumentNullException("this")
        Contract.Ensures(Contract.Result(Of String)() IsNot Nothing)
        Contract.EndContractBlock()

        Dim temp As New List(Of String)(this.Count * 2)

        For Each item In this
            temp.Add(item.Key)
            temp.Add(item.Value)
        Next
        Return temp.Join(separator)
    End Function

#End If


    <Pure()> <Untested()> <Extension()> Public Function GetValue(Of T)(ByVal this As IDictionary, ByVal key As Object) As T
        If this Is Nothing Then Throw New ArgumentNullException("this")
        If key Is Nothing Then Throw New ArgumentNullException("key")
        Contract.EndContractBlock()

        Dim temp As Object = this(key)
        Return If(temp IsNot Nothing, CType(temp, T), Nothing)
    End Function

    <Pure()> <Untested()> <Extension()> Public Function GetValue(Of T)(ByVal this As IDictionary, ByVal key As Object, ByVal [default] As T) As T
        If this Is Nothing Then Throw New ArgumentNullException("this")
        If key Is Nothing Then Throw New ArgumentNullException("key")
        Contract.EndContractBlock()

        Dim temp As Object = this(key)
        Return If(temp IsNot Nothing, CType(temp, T), [default])
    End Function

#If ClrVersion >= 35 Then

    <Pure()> <Untested()> <Extension()> Public Function ToDictionary(ByVal source As String, ByVal rowSeparator As String, ByVal columnSeparator As String) As Dictionary(Of String, String)
        If source Is Nothing Then Throw New ArgumentNullException("source")
        Contract.Ensures(Contract.Result(Of Dictionary(Of String, String))() IsNot Nothing)
        Contract.EndContractBlock()

        If rowSeparator = columnSeparator Then Return ToDictionary(source, rowSeparator)

        Dim result As New Dictionary(Of String, String)
        Dim rows = source.Split(rowSeparator, StringSplitOptions.RemoveEmptyEntries)

        For Each pair In rows.Select(Function(s) s.Split(columnSeparator, 2))
            If pair.Length = 2 Then result.Add(pair(0), pair(1)) Else result.Add(pair(0), "")
        Next

        Return result
    End Function


    <Pure()> <Untested()> <Extension()> Public Function ToDictionary(ByVal source As String, ByVal separator As String) As Dictionary(Of String, String)
        If source Is Nothing Then Throw New ArgumentNullException("source")
        Contract.Ensures(Contract.Result(Of Dictionary(Of String, String))() IsNot Nothing)
        Contract.EndContractBlock()

        Dim result As New Dictionary(Of String, String)
        Dim rows = Microsoft.VisualBasic.Split(source, separator)

        If rows.Count Mod 2 <> 0 Then Throw New FormatException("This contains an odd number of entries")
        For i = 0 To rows.Count - 1 Step 2
            result.Add(rows(i), rows(i + 1))
        Next

        Return result
    End Function
#End If

End Module
#End If