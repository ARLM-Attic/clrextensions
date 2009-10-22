Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions
Imports System.Diagnostics



'''<summary>
'''This is a test class for ThreadExtensionTest and is intended
'''to contain all ThreadExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ThreadExtensionTest


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
	'''A test for Sleep
	'''</summary>
	<TestMethod()> _
	Public Sub SleepTest()
		Dim s As New stopwatch
		For i = 0 To 4
			s.Reset()
			s.Start()
			ThreadExtension.Sleep(0, 15)
			s.Stop()
			Assert.IsTrue(14.9 <= s.Elapsed.TotalSeconds And s.Elapsed.TotalSeconds <= 15.1)

			s.Reset()
			s.Start()
			ThreadExtension.Sleep(1, 15)
			s.Stop()
			Assert.IsTrue(74.9 <= s.Elapsed.TotalSeconds And s.Elapsed.TotalSeconds <= 75.1)
		Next

	End Sub


End Class
