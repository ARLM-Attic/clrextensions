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
End Class
