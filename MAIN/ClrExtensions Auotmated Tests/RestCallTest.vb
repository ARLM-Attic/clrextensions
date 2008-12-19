Imports System

Imports System.Net

Imports ClrExtensions

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ClrExtensions.Net.Rest



'''<summary>
'''This is a test class for RestCallTest and is intended
'''to contain all RestCallTest Unit Tests
'''</summary>
<TestClass()> _
Public Class RestCallTest


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
    '''A test for Verb
    '''</summary>
    <TestMethod()> _
    Public Sub VerbTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim actual As RestVerb
        actual = target.Verb
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Scheme
    '''</summary>
    <TestMethod()> _
    Public Sub SchemeTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim actual As RestScheme
        actual = target.Scheme
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Root
    '''</summary>
    <TestMethod()> _
    Public Sub RootTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.Root
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Path
    '''</summary>
    <TestMethod()> _
    Public Sub PathTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.Path
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for HttpMethod
    '''</summary>
    <TestMethod()> _
    Public Sub HttpMethodTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.HttpMethod
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ToUrlString
    '''</summary>
    <TestMethod()> _
    Public Sub ToUrlStringTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.ToUrlString
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ToUri
    '''</summary>
    <TestMethod()> _
    Public Sub ToUriTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim expected As Uri = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As Uri
        actual = target.ToUri
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ToString
    '''</summary>
    <TestMethod()> _
    Public Sub ToStringTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        actual = target.ToString
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for CreateHttpWebRequest
    '''</summary>
    <TestMethod()> _
    Public Sub CreateHttpWebRequestTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim expected As HttpWebRequest = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As HttpWebRequest
        actual = target.CreateHttpWebRequest
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for AddParameter
    '''</summary>
    <TestMethod()> _
    Public Sub AddParameterTest1()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim parameter As QueryParameter = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As RestCall = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As RestCall
        actual = target.AddParameter(parameter)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for AddParameter
    '''</summary>
    <TestMethod()> _
    Public Sub AddParameterTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url) ' TODO: Initialize to an appropriate value
        Dim name As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim value As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim encoding As UrlEncodingMethod = New UrlEncodingMethod ' TODO: Initialize to an appropriate value
        Dim expected As RestCall = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As RestCall
        actual = target.AddParameter(name, value, encoding)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for RestCall Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub RestCallConstructorTest1()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim scheme As RestScheme = New RestScheme ' TODO: Initialize to an appropriate value
        Dim root As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim path As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim query As IList(Of QueryParameter) = Nothing ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, scheme, root, path, query)
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for RestCall Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub RestCallConstructorTest()
        Dim verb As RestVerb = New RestVerb ' TODO: Initialize to an appropriate value
        Dim url As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim target As RestCall = New RestCall(verb, url)
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub
End Class
