'Copyright (c) 2008, Jonathan Allen

Namespace Collections
#If IncludeUntested Then

	''' <summary>
	''' This dictionary uses a compound key. An entry is only considered a match if all three keys match.
	''' </summary>
	''' <typeparam name="TKey1">The first part of the compound key</typeparam>
	''' <typeparam name="TKey2">The second part of the compound key</typeparam>
	''' <typeparam name="TKey3">The third part of the compound key</typeparam>
	''' <typeparam name="TValue">The data being stored</typeparam>
    ''' <remarks></remarks>
    <Serializable()>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")> Public Class Dictionary(Of TKey1, TKey2, TKey3, TValue)
        Inherits Dictionary(Of Tuple(Of TKey1, TKey2, TKey3), TValue)

        ''' <summary>
        ''' Creates a new instance with the default size
        ''' </summary>
        ''' <remarks></remarks>
        <Untested()>
        <Pure()>
        Public Sub New()

        End Sub

#If ClrVersion > 0 Then
        <Pure()>
        Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
        End Sub
#End If

        ''' <summary>
        ''' Creates a new instance with a suggested starting capacity
        ''' </summary>
        ''' <param name="capacity"></param>
        ''' <remarks></remarks>
        <Untested()>
        <Pure()>
        Public Sub New(ByVal capacity As Integer)
            MyBase.New(capacity)
        End Sub

        <Untested()>
        <Pure()>
        Private Shared Function MakeKey(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3) As Tuple(Of TKey1, TKey2, TKey3)
            Return New Tuple(Of TKey1, TKey2, TKey3)(key1, key2, key3)
        End Function

        ''' <summary>
        ''' Adds the specified keys and value to the dictionary.
        ''' </summary>
        ''' <param name="key1">The first part of the compound key</param>
        ''' <param name="key2">The second part of the compound key</param>
        ''' <param name="key3 ">The third part of the compound key</param>
        ''' <param name="value">The value of the element to add. The value can be null for reference types.</param>
        ''' <remarks></remarks>
        ''' <exception cref="ArgumentException">An element with the same key already exists </exception>
        <Untested()>
        Public Overloads Sub Add(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3, ByVal value As TValue)
            Contract.Ensures(Count = Contract.OldValue(Count) + 1)

            MyBase.Add(MakeKey(key1, key2, key3), value)
        End Sub

        ''' <summary>
        ''' Gets or sets the value associated with the specified key.
        ''' </summary>
        ''' <param name="key1">The first part of the compound key</param>
        ''' <param name="key2">The second part of the compound key</param>
        ''' <param name="key3 ">The third part of the compound key</param>
        ''' <value></value>
        ''' <returns>The value associated with the specified key. If the specified key is not found, a get operation throws a System.Collections.Generic.KeyNotFoundException, and a set operation creates a new element with the specified key.</returns>
        ''' <remarks></remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1023:IndexersShouldNotBeMultidimensional")> <Untested()>
        Default Public Overloads Property Item(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3) As TValue
            <Pure()>
            Get
                Return MyBase.Item(MakeKey(key1, key2, key3))
            End Get
            Set(ByVal value As TValue)
                Contract.Ensures(Count = Contract.OldValue(Count) OrElse Count = Contract.OldValue(Count) + 1)
                MyBase.Item(MakeKey(key1, key2, key3)) = value
            End Set
        End Property

        ''' <summary>
        ''' Determines whether the System.Collections.Generic.Dictionary(Of TKey, TValue) contains the specified key.
        ''' </summary>
        ''' <param name="key1">The first part of the compound key</param>
        ''' <param name="key2">The second part of the compound key</param>
        ''' <param name="key3 ">The third part of the compound key</param>
        ''' <returns>true if the Dictionary contains an element with the specified key; otherwise, false.</returns>
        ''' <remarks></remarks>
        <Untested()>
        <Pure()>
        Public Overloads Function ContainsKey(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3) As Boolean
            Return MyBase.ContainsKey(MakeKey(key1, key2, key3))
        End Function

        ''' <summary>
        ''' Removes the value with the specified key from the System.Collections.Generic.Dictionary(Of TKey, TValue).
        ''' </summary>
        ''' <param name="key1">The first part of the compound key</param>
        ''' <param name="key2">The second part of the compound key</param>
        ''' <param name="key3 ">The third part of the compound key</param>
        ''' <returns>true if the element is successfully found and removed; otherwise, false. This method returns false if key is not found </returns>
        ''' <remarks></remarks>
        <Untested()>
        Overloads Function Remove(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3) As Boolean
            Contract.Ensures(Count = Contract.OldValue(Count) Or Count = Contract.OldValue(Count) - 1)

            Return MyBase.Remove(MakeKey(key1, key2, key3))
        End Function

        ''' <summary>
        ''' Gets the value associated with the specified key.
        ''' </summary>
        ''' <param name="key1">The first part of the compound key</param>
        ''' <param name="key2">The second part of the compound key</param>
        ''' <param name="key3 ">The third part of the compound key</param>
        ''' <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        ''' <returns>true if the Dictionary contains an element with the specified key; otherwise, false.</returns>
        ''' <remarks></remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId:="3#")> <Untested()>
        <Pure()>
        Public Overloads Function TryGetValue(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3, ByRef value As TValue) As Boolean
            Contract.Ensures(Contract.Result(Of Boolean)() = False And Contract.ValueAtReturn(value) Is Nothing Or
                             Contract.Result(Of Boolean)() = True)

            Return MyBase.TryGetValue(MakeKey(key1, key2, key3), value)
        End Function

        ''' <summary>
        ''' Stores the value, then returns the same value
        ''' </summary>
        ''' <param name="key1">The first part of the compound key</param>
        ''' <param name="key2">The second part of the compound key</param>
        ''' <param name="key3 ">The third part of the compound key</param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks>This was created to support anonymous functions in VB that need to do more than one thing with a value in a single line. See the Memorize function for an example of its use</remarks>
        <Untested()>
        Public Function StoreAndReturn(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3, ByVal value As TValue) As TValue
            Contract.Ensures(Count = Contract.OldValue(Count) OrElse Count = Contract.OldValue(Count) + 1)

            Me(key1, key2, key3) = value
            Return value
        End Function

        <Untested()> Public Function GetOrCreate(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3, ByVal valueFunction As Func(Of TKey1, TKey2, TKey3, TValue)) As TValue
            If valueFunction Is Nothing Then Throw New ArgumentNullException("valueFunction")
            Contract.Ensures(Count = Contract.OldValue(Count) OrElse Count = Contract.OldValue(Count) + 1)
            Contract.EndContractBlock()

            If ContainsKey(key1, key2, key3) Then
                Return Item(key1, key2, key3)
            Else
                Return StoreAndReturn(key1, key2, key3, valueFunction(key1, key2, key3))
            End If
        End Function


        <Untested()> Public Function GetOrCreate(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal key3 As TKey3, ByVal defaultValue As TValue) As TValue
            Contract.Ensures(Count = Contract.OldValue(Count) OrElse Count = Contract.OldValue(Count) + 1)

            If ContainsKey(key1, key2, key3) Then
                Return Item(key1, key2, key3)
            Else
                Return StoreAndReturn(key1, key2, key3, defaultValue)
            End If
        End Function

    End Class



#End If
End Namespace

