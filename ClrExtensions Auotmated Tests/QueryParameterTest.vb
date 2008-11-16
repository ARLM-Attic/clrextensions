Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ClrExtensions.Net.Rest

'''<summary>
'''This is a test class for QueryParameterTest and is intended
'''to contain all QueryParameterTest Unit Tests
'''</summary>
<TestClass()> _
Public Class QueryParameterTest


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

	Public Shared names As String() = New String() {"a", "b", "c", "d", "e"}
	Public Shared values As String() = New String() {"1", "2", "3", Nothing, ""}
	Public Shared toStringValues As String() = New String() {"a=1", "b=2", "c=3", "d", "e="}
	Public Shared fullString As String = "a=1&b=2&c=3&d&e="

	'''<summary>
	'''A test for ToString
	'''</summary>
	<TestMethod()> _
	Public Sub ToStringTest()
		For i = 0 To names.Length - 1
			Dim query = New QueryParameter(names(i), values(i))
			Assert.AreEqual(names(i), query.Name)
			Assert.AreEqual(values(i), query.Value)
			Assert.AreEqual(toStringValues(i), query.ToString)

			If values(i) Is Nothing Then
				Dim query2 = New QueryParameter(names(i))
				Assert.AreEqual(names(i), query.Name)
				Assert.AreEqual(toStringValues(i), query.ToString)
			End If
		Next
	End Sub

End Class
