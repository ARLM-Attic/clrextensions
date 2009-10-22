Imports System.Collections.ObjectModel

Imports System.Collections.Specialized

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions.Net.Rest



'''<summary>
'''This is a test class for QueryParameterCollectionTest and is intended
'''to contain all QueryParameterCollectionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class QueryParameterCollectionTest


	Private testContextInstance As TestContext

	'''<summary>
	'''Gets or sets the test context which provides
	'''information about and functionality for the current test run.
	'''</summary>
	Public Property TestContext() As TestContext
		Get
			Return testContextInstance
		End Get
		Set(ByVal value As TestContext)
			testContextInstance = Value
		End Set
	End Property

#Region "Additional test attributes"
	'
	'You can use the following additional attributes as you write your tests:
	'
	'Use ClassInitialize to run code before running the first test in the class
	'<ClassInitialize()>  _
	'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
	'End Sub
	'
	'Use ClassCleanup to run code after all tests in a class have run
	'<ClassCleanup()>  _
	'Public Shared Sub MyClassCleanup()
	'End Sub
	'
	'Use TestInitialize to run code before running each test
	'<TestInitialize()>  _
	'Public Sub MyTestInitialize()
	'End Sub
	'
	'Use TestCleanup to run code after each test has run
	'<TestCleanup()>  _
	'Public Sub MyTestCleanup()
	'End Sub
	'
#End Region


	'''<summary>
	'''A test for AddRange
	'''</summary>
	<TestMethod()> _
	Public Sub AddRangeTest2()
		Dim target As New QueryParameterCollection

		target.AddByParsing(QueryParameterTest.fullString)
		For i = 0 To QueryParameterTest.names.Length - 1
			Assert.AreEqual(QueryParameterTest.names(i), target(i).Name)
			Assert.AreEqual(QueryParameterTest.values(i), target(i).Value)
			Assert.AreEqual(QueryParameterTest.toStringValues(i), target(i).ToString)
		Next

	End Sub

	'''<summary>
	'''A test for AddRange
	'''</summary>
	<TestMethod()> _
	Public Sub AddRangeTest()
		Dim target As New QueryParameterCollection

		Dim temp As New NameValueCollection
		For i = 0 To QueryParameterTest.names.Length - 1
			temp.Add(QueryParameterTest.names(i), QueryParameterTest.values(i))
		Next

		target.AddRange(temp)
		For i = 0 To QueryParameterTest.names.Length - 1
			Assert.AreEqual(QueryParameterTest.names(i), target(i).Name)
			Assert.AreEqual(QueryParameterTest.values(i), target(i).Value)
			Assert.AreEqual(QueryParameterTest.toStringValues(i), target(i).ToString)
		Next

	End Sub

    '''<summary>
    '''A test for Item
    '''</summary>
    <TestMethod()> _
    Public Sub ItemTest()
        Dim target As QueryParameterCollection = New QueryParameterCollection ' TODO: Initialize to an appropriate value
        Dim key As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target(key)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ParseQueryString
    '''</summary>
    <TestMethod(), _
     DeploymentItem("ClrExtensionsCore.dll")> _
    Public Sub ParseQueryStringTest()
        Dim queryString As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Collection(Of QueryParameter) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As Collection(Of QueryParameter)
        actual = QueryParameterCollection_Accessor.ParseQueryString(queryString)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for AddRange
    '''</summary>
    <TestMethod()> _
    Public Sub AddRangeTest1()
        Dim target As QueryParameterCollection = New QueryParameterCollection ' TODO: Initialize to an appropriate value
        Dim values As NameValueCollection = Nothing ' TODO: Initialize to an appropriate value
        target.AddRange(values)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for AddByParsing
    '''</summary>
    <TestMethod()> _
    Public Sub AddByParsingTest()
        Dim target As QueryParameterCollection = New QueryParameterCollection ' TODO: Initialize to an appropriate value
        Dim queryString As String = String.Empty ' TODO: Initialize to an appropriate value
        target.AddByParsing(queryString)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for QueryParameterCollection Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub QueryParameterCollectionConstructorTest1()
        Dim target As QueryParameterCollection = New QueryParameterCollection
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for QueryParameterCollection Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub QueryParameterCollectionConstructorTest()
        Dim queryString As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As QueryParameterCollection = New QueryParameterCollection(queryString)
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub
End Class
