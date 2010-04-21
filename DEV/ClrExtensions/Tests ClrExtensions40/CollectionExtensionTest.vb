Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions
Imports System.Net.Mail



'''<summary>
'''This is a test class for CollectionExtensionTest and is intended
'''to contain all CollectionExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class CollectionExtensionTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Property TestContext() As TestContext
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
    ' Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    ' Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    ' Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    ' Sub MyTestCleanup()
    'End Sub
    '
#End Region



    <TestMethod()> _
    Sub AddRangeTest()
        Dim source As New MailAddressCollection From {{"a@test.com"}, {"b@test.com"}, {"c@test.com"}}
        Dim target As New MailAddressCollection From {{"x@test.com"}, {"y@test.com"}}
        CollectionExtension.AddRange(target, source)

        Assert.AreEqual(5, target.Count)
        For Each item In source
            Assert.IsTrue(target.Contains(item))
        Next
    End Sub

    <TestMethod()> _
    Sub AddRangeTest2()
        Dim source As New MailAddressCollection From {{"a@test.com"}, {"b@test.com"}, {"c@test.com"}}
        Dim target As New MailAddressCollection From {{"x@test.com"}, {"y@test.com"}}
        CollectionExtension.AddRange(CType(target, ICollection(Of MailAddress)), CType(source, IEnumerable(Of MailAddress)))

        Assert.AreEqual(5, target.Count)
        For Each item In source
            Assert.IsTrue(target.Contains(item))
        Next
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(ArgumentNullException))>
    Sub AddRangeTest5()
        Dim source As New MailAddressCollection From {{"a@test.com"}, {"b@test.com"}, {"c@test.com"}}
        Dim target As New MailAddressCollection From {{"x@test.com"}, {"y@test.com"}}
        CollectionExtension.AddRange(CType(Nothing, ICollection(Of MailAddress)), CType(source, IEnumerable(Of MailAddress)))
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(ArgumentNullException))>
    Sub AddRangeTest3()
        Dim source As New MailAddressCollection From {{"a@test.com"}, {"b@test.com"}, {"c@test.com"}}
        Dim target As New MailAddressCollection From {{"x@test.com"}, {"y@test.com"}}
        CollectionExtension.AddRange(CType(target, ICollection(Of MailAddress)), CType(Nothing, IEnumerable(Of MailAddress)))
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(ArgumentException))>
    Sub AddRangeTest4()
        Dim source As New MailAddressCollection From {{"a@test.com"}, {"b@test.com"}, {"c@test.com"}}
        Dim target As New ObjectModel.ReadOnlyCollection(Of MailAddress)(New MailAddressCollection From {{"x@test.com"}, {"y@test.com"}})
        CollectionExtension.AddRange(CType(target, ICollection(Of MailAddress)), CType(source, IEnumerable(Of MailAddress)))
    End Sub



End Class
