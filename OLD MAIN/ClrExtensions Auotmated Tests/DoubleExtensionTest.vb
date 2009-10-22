Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for DoubleExtensionTest and is intended
'''to contain all DoubleExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DoubleExtensionTest


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
	'''A test for Pow
	'''</summary>
	<TestMethod()> _
	Public Sub PowTest()
		For i As Double = -10 To 10
			For j As Double = -10 To 10
				Assert.AreEqual(i ^ j, i.Pow(j))
			Next
		Next
	End Sub

	'''<summary>
	'''A test for Pow
	'''</summary>
	<TestMethod()> _
	Public Sub PowTest1()
		For i As Double = -10 To 10
			For j = -10 To 10
				Assert.AreEqual(i ^ j, i.Pow(j))
			Next
		Next
	End Sub
End Class
