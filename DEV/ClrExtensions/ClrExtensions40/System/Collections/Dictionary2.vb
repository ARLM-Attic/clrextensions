'Copyright (c) 2008, Jonathan Allen


Namespace Collections

	''' <summary>
	''' This dictionary uses a compound key. An entry is only considered a match if both keys match.
	''' </summary>
	''' <typeparam name="TKey1">The first part of the compound key</typeparam>
	''' <typeparam name="TKey2">The second part of the compound key</typeparam>
	''' <typeparam name="TValue">The data being stored</typeparam>
	''' <remarks></remarks>
	<Serializable()>
	<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")>
	Public Class Dictionary(Of TKey1, TKey2, TValue)
		Inherits Dictionary(Of Tuple(Of TKey1, TKey2), TValue)

		''' <summary>
		''' Creates a new instance with the default size
		''' </summary>
		''' <remarks></remarks>
		Sub New()

		End Sub

#If ClrVersion > 0 Then
		Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
			MyBase.New(info, context)
		End Sub
#End If

		''' <summary>
		''' Creates a new instance with a suggested starting capacity
		''' </summary>
		''' <param name="capacity"></param>
		''' <remarks></remarks>
		Sub New(ByVal capacity As Integer)
			MyBase.New(capacity)
		End Sub

		Private Shared Function MakeKey(ByVal key1 As TKey1, ByVal key2 As TKey2) As Tuple(Of TKey1, TKey2)

			Return New Tuple(Of TKey1, TKey2)(key1, key2)
		End Function

		''' <summary>
		''' Adds the specified keys and value to the dictionary.
		''' </summary>
		''' <param name="key1">The first part of the compound key</param>
		''' <param name="key2">The second part of the compound key</param>
		''' <param name="value">The value of the element to add. The value can be null for reference types.</param>
		''' <remarks></remarks>
		''' <exception cref="ArgumentException">An element with the same key already exists </exception>
		Overloads Sub Add(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal value As TValue)

			MyBase.Add(MakeKey(key1, key2), value)
		End Sub

		''' <summary>
		''' Gets or sets the value associated with the specified key.
		''' </summary>
		''' <param name="key1">The first part of the compound key</param>
		''' <param name="key2">The second part of the compound key</param>
		''' <value></value>
		''' <returns>The value associated with the specified key. If the specified key is not found, a get operation throws a System.Collections.Generic.KeyNotFoundException, and a set operation creates a new element with the specified key.</returns>
		''' <remarks></remarks>
		<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1023:IndexersShouldNotBeMultidimensional")>
		Default Overloads Property Item(ByVal key1 As TKey1, ByVal key2 As TKey2) As TValue
			<Pure()> Get
				Return MyBase.Item(MakeKey(key1, key2))
			End Get
			Set(ByVal value As TValue)

				MyBase.Item(MakeKey(key1, key2)) = value
			End Set
		End Property

		''' <summary>
		''' Determines whether the System.Collections.Generic.Dictionary(Of TKey, TValue) contains the specified key.
		''' </summary>
		''' <param name="key1">The first part of the compound key</param>
		''' <param name="key2">The second part of the compound key</param>
		''' <returns>true if the Dictionary contains an element with the specified key; otherwise, false.</returns>
		''' <remarks></remarks>
		Overloads Function ContainsKey(ByVal key1 As TKey1, ByVal key2 As TKey2) As Boolean
			Return MyBase.ContainsKey(MakeKey(key1, key2))
		End Function

		''' <summary>
		''' Removes the value with the specified key from the System.Collections.Generic.Dictionary(Of TKey, TValue).
		''' </summary>
		''' <param name="key1">The first part of the compound key</param>
		''' <param name="key2">The second part of the compound key</param>
		''' <returns>true if the element is successfully found and removed; otherwise, false. This method returns false if key is not found </returns>
		''' <remarks></remarks>
		Overloads Function Remove(ByVal key1 As TKey1, ByVal key2 As TKey2) As Boolean

			Return MyBase.Remove(MakeKey(key1, key2))
		End Function

		''' <summary>
		''' Gets the value associated with the specified key.
		''' </summary>
		''' <param name="key1">The first part of the compound key</param>
		''' <param name="key2">The second part of the compound key</param>
		''' <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
		''' <returns>true if the Dictionary contains an element with the specified key; otherwise, false.</returns>
		''' <remarks></remarks>
		<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId:="2#")>
		Overloads Function TryGetValue(ByVal key1 As TKey1, ByVal key2 As TKey2, ByRef value As TValue) As Boolean
			Return MyBase.TryGetValue(MakeKey(key1, key2), value)
		End Function

		''' <summary>
		''' Stores the value, then returns the same value
		''' </summary>
		''' <param name="key1">The first part of the compound key</param>
		''' <param name="key2">The second part of the compound key</param>
		''' <param name="value"></param>
		''' <returns></returns>
		''' <remarks>This was created to support anonymous functions in VB that need to do more than one thing with a value in a single line. See the Memorize function for an example of its use</remarks>
		Function StoreAndReturn(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal value As TValue) As TValue

			Me(key1, key2) = value
			Return value
		End Function

#If IncludeUntested Then

        <Untested()>  Function GetOrCreate(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal valueFunction As Func(Of TKey1, TKey2, TValue)) As TValue
            If valueFunction Is Nothing Then Throw New ArgumentNullException("valueFunction")

            If ContainsKey(key1, key2) Then
                Return Item(key1, key2)
            Else
                Return StoreAndReturn(key1, key2, valueFunction(key1, key2))
            End If
        End Function

        <Untested()>  Function GetOrCreate(ByVal key1 As TKey1, ByVal key2 As TKey2, ByVal defaultValue As TValue) As TValue

            If ContainsKey(key1, key2) Then
                Return Item(key1, key2)
            Else
                Return StoreAndReturn(key1, key2, defaultValue)
            End If
        End Function

#End If

		'TODO - Use the info in the following link to transform the dictionary into a tree
		'http://blogs.msdn.com/mitsu/archive/2007/12/22/playing-with-linq-grouping-groupbymany.aspx

	End Class
End Namespace
