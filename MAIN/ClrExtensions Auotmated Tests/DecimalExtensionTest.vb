Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ClrExtensions



'''<summary>
'''This is a test class for DecimalExtensionTest and is intended
'''to contain all DecimalExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DecimalExtensionTest


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


	Dim m_List As Decimal() = New Decimal() {12345.67889D, 123.456D, 12.34D, 1.2D, 0, Decimal.MinusOne, Decimal.One, Decimal.MaxValue, Decimal.MinValue}

	'''<summary>
	'''A test for TruncatePrecision
	'''</summary>
	<TestMethod()> _
	Public Sub TruncatePrecisionTest()

		Dim expected As New System.Collections.Generic.Dictionary(Of Integer, Decimal())

		expected.Add(5, New Decimal() {12345.67889D, 123.456D, 12.34D, 1.2D, 0, -1, 1, 79228162514264337593543950335D, -79228162514264337593543950335D})
		expected.Add(4, New Decimal() {12345.6788D, 123.456D, 12.34D, 1.2D, 0, -1, 1, 79228162514264337593543950335D, -79228162514264337593543950335D})
		expected.Add(3, New Decimal() {12345.678D, 123.456D, 12.34D, 1.2D, 0, -1, 1, 79228162514264337593543950335D, -79228162514264337593543950335D})
		expected.Add(2, New Decimal() {12345.67D, 123.45D, 12.34D, 1.2D, 0, -1, 1, 79228162514264337593543950335D, -79228162514264337593543950335D})
		expected.Add(1, New Decimal() {12345.6D, 123.4D, 12.3D, 1.2D, 0, -1, 1, 79228162514264337593543950335D, -79228162514264337593543950335D})
		expected.Add(0, New Decimal() {12345D, 123D, 12D, 1D, 0, -1, 1, 79228162514264337593543950335D, -79228162514264337593543950335D})
		expected.Add(-1, New Decimal() {12340D, 120D, 10D, 0, 0, 0, 0, 79228162514264337593543950330D, -79228162514264337593543950330D})
		expected.Add(-2, New Decimal() {12300D, 100D, 0D, 0, 0, 0, 0, 79228162514264337593543950300D, -79228162514264337593543950300D})
		expected.Add(-3, New Decimal() {12000D, 0D, 0D, 0, 0, 0, 0, 79228162514264337593543950000D, -79228162514264337593543950000D})
		expected.Add(-4, New Decimal() {10000D, 0D, 0D, 0D, 0, 0, 0, 79228162514264337593543950000D, -79228162514264337593543950000D})
		expected.Add(-5, New Decimal() {0D, 0D, 0D, 0D, 0, 0, 0, 79228162514264337593543900000D, -79228162514264337593543900000D})

		For Each key In expected.Keys
			For i = 0 To m_List.Length - 1
				Assert.AreEqual(expected(key)(i), m_List(i).TruncatePrecision(key))
			Next
		Next

	End Sub

	'''<summary>
	'''A test for Pow10
	'''</summary>
	<TestMethod()> _
 Public Sub Pow10Test()
		Dim expected = New Decimal() {0.00001D, 0.0001D, 0.001D, 0.01D, 0.1D, 1, 10, 100, 1000, 10000, 100000}

		For i = -5 To 5
			Assert.AreEqual(expected(i + 5), DecimalExtension.Pow10(i))
		Next

	End Sub
End Class



