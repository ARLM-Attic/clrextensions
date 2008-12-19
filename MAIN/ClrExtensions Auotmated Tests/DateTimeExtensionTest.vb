Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ClrExtensions



'''<summary>
'''This is a test class for DateTimeExtensionTest and is intended
'''to contain all DateTimeExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DateTimeExtensionTest

	Private Const testDate As Date = #1/14/2008#
	Private Const testNextMonday As Date = #1/21/2008#
	Private Const testNextWednesday As Date = #1/16/2008#
	Private Const testPreviousMonday As Date = #1/7/2008#
	Private Const testPreviousWednesday As Date = #1/9/2008#

	Private Const testMonthStart As Date = #1/1/2008#
	Private Const testMonthEnd As Date = #1/31/2008#

	Private Const testFirstTuesday As Date = #1/1/2008#
	Private Const testFirstMonday As Date = #1/7/2008#
	Private Const testSecondTuesday As Date = #1/8/2008#
	Private Const testSecondMonday As Date = #1/14/2008#

	Private Const testLastMonday As Date = #1/28/2008#
	Private Const testLastTuesday As Date = #1/29/2008#


	Private Const testDateTimeSeconds As Date = #1/14/2008 10:03:36 AM#
	Private Const testDateTime As Date = #1/14/2008 2:27:00 PM#
	Private Const testDateHour As Date = #1/14/2008 4:00:00 PM#

	Private testTimeSeconds As TimeSpan = testDateTimeSeconds.TimeOfDay
	Private testTime As TimeSpan = testDateTime.TimeOfDay
	Private testTimeHour As TimeSpan = testDateHour.TimeOfDay


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
			testContextInstance = value
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
	'''A test for SetTime
	'''</summary>
	<TestMethod()> _
	Public Sub SetTimeTest3()
		Assert.AreEqual(testDateTime, DateTimeExtension.SetTime(testDate, 14, 27))
		Assert.AreEqual(testDateTime, DateTimeExtension.SetTime(testDateTimeSeconds, 14, 27))
	End Sub

#If TODO Then
	'''<summary>
	'''A test for SetTime
	'''</summary>
	<TestMethod()> _
	Public Sub SetTimeTest2()

		Dim this As DateTime = New DateTime	' TODO: Initialize to an appropriate value
		Dim hours As Integer = 0 ' TODO: Initialize to an appropriate value
		Dim minutes As Integer = 0 ' TODO: Initialize to an appropriate value
		Dim seconds As Integer = 0 ' TODO: Initialize to an appropriate value
		Dim expected As DateTime = New DateTime	' TODO: Initialize to an appropriate value
		Dim actual As DateTime
		actual = DateTimeExtension.SetTime(this, hours, minutes, seconds)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	'''<summary>
	'''A test for SetTime
	'''</summary>
	<TestMethod()> _
	Public Sub SetTimeTest1()
		Dim this As DateTime = New DateTime	' TODO: Initialize to an appropriate value
		Dim hours As Integer = 0 ' TODO: Initialize to an appropriate value
		Dim minutes As Integer = 0 ' TODO: Initialize to an appropriate value
		Dim seconds As Integer = 0 ' TODO: Initialize to an appropriate value
		Dim milliseconds As Integer = 0	' TODO: Initialize to an appropriate value
		Dim expected As DateTime = New DateTime	' TODO: Initialize to an appropriate value
		Dim actual As DateTime
		actual = DateTimeExtension.SetTime(this, hours, minutes, seconds, milliseconds)
		Assert.AreEqual(expected, actual)
		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub
#End If

	'''<summary>
	'''A test for SetTime
	'''</summary>
	<TestMethod()> _
	Public Sub SetTimeTest()
		Assert.AreEqual(testDateTime, DateTimeExtension.SetTime(testDate, testTime))
		Assert.AreEqual(testDateTimeSeconds, DateTimeExtension.SetTime(testDate, testTimeSeconds))
		Assert.AreEqual(testDateHour, DateTimeExtension.SetTime(testDate, testTimeHour))
	End Sub

	'''<summary>
	'''A test for Previous
	'''</summary>
	<TestMethod()> _
	Public Sub PreviousTest()
		Assert.AreEqual(testPreviousMonday, DateTimeExtension.Previous(testDate, System.DayOfWeek.Monday))
		Assert.AreEqual(testPreviousWednesday, DateTimeExtension.Previous(testDate, System.DayOfWeek.Wednesday))
	End Sub

	'''<summary>
	'''A test for Next
	'''</summary>
	<TestMethod()> _
	Public Sub NextTest()
		Assert.AreEqual(testNextMonday, DateTimeExtension.Next(testDate, System.DayOfWeek.Monday))
		Assert.AreEqual(testNextWednesday, DateTimeExtension.Next(testDate, System.DayOfWeek.Wednesday))
	End Sub

	'''<summary>
	'''A test for LastOfMonth
	'''</summary>
	<TestMethod()> _
	Public Sub LastOfMonthTest1()
		Assert.AreEqual(testLastMonday, DateTimeExtension.LastOfMonth(testDate, System.DayOfWeek.Monday))
		Assert.AreEqual(testLastTuesday, DateTimeExtension.LastOfMonth(testDate, System.DayOfWeek.Tuesday))
	End Sub

	'''<summary>
	'''A test for LastOfMonth
	'''</summary>
	<TestMethod()> _
	Public Sub LastOfMonthTest()
		Assert.AreEqual(testMonthEnd, DateTimeExtension.LastOfMonth(testDate))
	End Sub

	'''<summary>
	'''A test for IsBetween
	'''</summary>
	<TestMethod()> _
	Public Sub IsBetweenTest()
		Assert.AreEqual(True, DateTimeExtension.IsBetween(testDate, testPreviousMonday, testNextMonday))
		Assert.AreEqual(True, DateTimeExtension.IsBetween(testDate, testDate, testNextMonday))
		Assert.AreEqual(True, DateTimeExtension.IsBetween(testDate, testPreviousMonday, testDate))

		Assert.AreEqual(False, DateTimeExtension.IsBetween(testFirstTuesday, testPreviousMonday, testNextMonday))
		Assert.AreEqual(False, DateTimeExtension.IsBetween(testLastMonday, testPreviousMonday, testNextMonday))
	End Sub

	'''<summary>
	'''A test for FirstOfMonth
	'''</summary>
	<TestMethod()> _
	Public Sub FirstOfMonthTest1()
		Assert.AreEqual(testMonthStart, DateTimeExtension.FirstOfMonth(testDate))
	End Sub

	'''<summary>
	'''A test for FirstOfMonth
	'''</summary>
	<TestMethod()> _
	Public Sub FirstOfMonthTest()
		Assert.AreEqual(testFirstMonday, DateTimeExtension.FirstOfMonth(testDate, System.DayOfWeek.Monday))
		Assert.AreEqual(testFirstTuesday, DateTimeExtension.FirstOfMonth(testDate, System.DayOfWeek.Tuesday))
	End Sub

    Dim unixValue As Long = 1227888916
    Dim dateValue As New DateTime(2008, 11, 28, 16, 15, 16, DateTimeKind.Utc)

    '''<summary>
    '''A test for ToUnixTime
    '''</summary>
    <TestMethod()> _
    Public Sub ToUnixTimeTest()
        Assert.AreEqual(unixValue, dateValue.ToUnixTime)
    End Sub

    '''<summary>
    '''A test for FromUnixTime
    '''</summary>
    <TestMethod()> _
    Public Sub FromUnixTimeTest()
        Dim result As Date = FromUnixTime(unixValue)
        Assert.AreEqual(dateValue, result)
        Assert.AreEqual(DateTimeKind.Utc, result.Kind)
    End Sub
End Class
