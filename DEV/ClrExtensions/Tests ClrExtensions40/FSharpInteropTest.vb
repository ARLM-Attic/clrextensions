Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ClrExtensions
Imports Microsoft.FSharp.Core



'''<summary>
'''This is a test class for FSharpInteropTest and is intended
'''to contain all FSharpInteropTest Unit Tests
'''</summary>
<TestClass()> _
Public Class FSharpInteropTest


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


    '''<summary>
    '''A test for OptionGetUnderlyingValue
    '''</summary>
    <TestMethod()> _
    Sub OptionGetUnderlyingValueTest()
        Dim valueA As Object = Nothing

        Dim valueB As Object = 5

        Dim valueC_ As FSharpOption(Of Integer) = FSharpOption(Of Integer).None
        Dim valueC = valueC_
        Dim valueD_ As New FSharpOption(Of Integer)(5)
        Dim valueD = valueD_

        Dim valueE_ As FSharpOption(Of FSharpOption(Of Integer)) = FSharpOption(Of FSharpOption(Of Integer)).None
        Dim valueE = valueE_
        Dim valueF_ As New FSharpOption(Of FSharpOption(Of Integer))(FSharpOption(Of Integer).None)
        Dim valueF = valueF_
        Dim valueG_ As New FSharpOption(Of FSharpOption(Of Integer))(New FSharpOption(Of Integer)(5))
        Dim valueG = valueG_




        Assert.AreEqual(Nothing, OptionGetUnderlyingValue(valueA))
        Assert.AreEqual(5, OptionGetUnderlyingValue(valueB))
        Assert.AreEqual(Nothing, OptionGetUnderlyingValue(valueC))
        Assert.AreEqual(5, OptionGetUnderlyingValue(valueD))
        Assert.AreEqual(Nothing, OptionGetUnderlyingValue(valueE))
        Assert.AreEqual(Nothing, OptionGetUnderlyingValue(valueF))
        Assert.AreEqual(5, OptionGetUnderlyingValue(valueG))

    End Sub


End Class
