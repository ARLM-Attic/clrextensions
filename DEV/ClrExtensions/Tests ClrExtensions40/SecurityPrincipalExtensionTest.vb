Imports System.Security.Principal

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions



'''<summary>
'''This is a test class for SecurityPrincipalExtensionTest and is intended
'''to contain all SecurityPrincipalExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class SecurityPrincipalExtensionTest


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
    '''A test for AccountToSddl
    '''</summary>
    <TestMethod()> _
    Public Sub AccountToSddlTest()
        Dim name As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = SecurityPrincipalExtension.AccountToSddl(name)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for AccountToSid
    '''</summary>
    <TestMethod()> _
    Public Sub AccountToSidTest()
        Dim name As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As SecurityIdentifier = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As SecurityIdentifier
        actual = SecurityPrincipalExtension.AccountToSid(name)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for AccountToSid
    '''</summary>
    <TestMethod()> _
    Public Sub AccountToSidTest1()
        Dim domainName As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim accountName As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As SecurityIdentifier = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As SecurityIdentifier
        actual = SecurityPrincipalExtension.AccountToSid(domainName, accountName)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for AccountToSidString
    '''</summary>
    <TestMethod()> _
    Public Sub AccountToSidStringTest()
        Dim domainName As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim accountName As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = SecurityPrincipalExtension.AccountToSidString(domainName, accountName)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for SddlToAccount
    '''</summary>
    <TestMethod()> _
    Public Sub SddlToAccountTest()
        Dim sid As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As NTAccount = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As NTAccount
        actual = SecurityPrincipalExtension.SddlToAccount(sid)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ToAccount
    '''</summary>
    <TestMethod()> _
    Public Sub ToAccountTest()
        Dim sid As SecurityIdentifier = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As NTAccount = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As NTAccount
        actual = SecurityPrincipalExtension.ToAccount(sid)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ToSddl
    '''</summary>
    <TestMethod()> _
    Public Sub ToSddlTest()
        Dim account As NTAccount = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = SecurityPrincipalExtension.ToSddl(account)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ToSid
    '''</summary>
    <TestMethod()> _
    Public Sub ToSidTest()
        Dim account As NTAccount = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As SecurityIdentifier = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As SecurityIdentifier
        actual = SecurityPrincipalExtension.ToSid(account)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Translate
    '''</summary>
    Public Sub TranslateTestHelper(Of T As IdentityReference)()
        Dim value As IdentityReference = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As T = CType(Nothing, T) ' TODO: Initialize to an appropriate value
        Dim actual As T
        actual = SecurityPrincipalExtension.Translate(Of T)(value)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    <TestMethod()> _
    Public Sub TranslateTest()
        Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " & _
                "Please call TranslateTestHelper(Of T) with appropriate type parameters.")
    End Sub
End Class
