Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for EnumExtensionTest and is intended
'''to contain all EnumExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class EnumExtensionTest


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
	'''A test for IsDefined
	'''</summary>
	Public Sub IsDefinedTestHelper(Of T As Structure)()

		Dim values() = New Object() {-1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		For i = 0 To values.Length - 1
			Assert.AreEqual([Enum].IsDefined(GetType(T), values(i)), IsDefined(Of T)(CType(values(i), T)))
		Next

	End Sub

	<TestMethod()> _
	Public Sub IsDefinedTest()
		IsDefinedTestHelper(Of IO.DriveType)()
		IsDefinedTestHelper(Of IO.FileAccess)()
	End Sub

	<TestMethod()> _
	<ExpectedException(GetType(ArgumentException))> _
	Public Sub IsDefinedTest2()
		IsDefinedTestHelper(Of Drawing.Rectangle)()
	End Sub


End Class
