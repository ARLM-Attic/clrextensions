Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.FSharp.Core
Imports ClrExtensions.VBLanguageExtension



'''<summary>
'''This is a test class for VBLanguageExtensionTest and is intended
'''to contain all VBLanguageExtensionTest Unit Tests
'''</summary>
<TestClass()> _
Public Class VBLanguageExtensionTest


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
    '''A test for CStr2
    '''</summary>
    <TestMethod()> _
    Public Sub CStr2Test2()
        Dim valueA As Object = Nothing
        Dim valueB As Object = DBNull.Value
        Dim valueC_ As Nullable(Of Integer) = Nothing
        Dim valueC As Object = valueC_
        Dim valueD_ As Nullable(Of Integer) = 5
        Dim valueD As Object = valueD_
        Dim valueE_ As FSharpOption(Of Integer) = FSharpOption(Of Integer).None
        Dim valueE = valueE_
        Dim valueF_ As New FSharpOption(Of Integer)(5)
        Dim valueF = valueF_

        Dim valueG_ As FSharpOption(Of FSharpOption(Of Integer)) = FSharpOption(Of FSharpOption(Of Integer)).None
        Dim valueG = valueG_
        Dim valueH_ As New FSharpOption(Of FSharpOption(Of Integer))(FSharpOption(Of Integer).None)
        Dim valueH = valueH_
        Dim valueI_ As New FSharpOption(Of FSharpOption(Of Integer))(New FSharpOption(Of Integer)(5))
        Dim valueI = valueI_

        Dim valueJ As Object = "5"

        Dim defaultValue = "Missing"

        Assert.AreEqual(defaultValue, CStr2(valueA, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueB, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueC, defaultValue))
        Assert.AreEqual("5", CStr2(valueD, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueE, defaultValue))
        Assert.AreEqual("5", CStr2(valueF, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueG, defaultValue))
        Assert.AreEqual(defaultValue, CStr2(valueH, defaultValue))
        Assert.AreEqual("5", CStr2(valueI, defaultValue))
        Assert.AreEqual("5", CStr2(valueJ, defaultValue))


    End Sub

    '''<summary>
    '''A test for CStr2
    '''</summary>
    <TestMethod()> _
    Public Sub CStr2Test1()
        Dim valueA As Object = Nothing
        Dim valueB As Object = DBNull.Value
        Dim valueC_ As Nullable(Of Integer) = Nothing
        Dim valueC As Object = valueC_
        Dim valueD_ As Nullable(Of Integer) = 5
        Dim valueD As Object = valueD_
        Dim valueE_ As FSharpOption(Of Integer) = FSharpOption(Of Integer).None
        Dim valueE = valueE_
        Dim valueF_ As New FSharpOption(Of Integer)(5)
        Dim valueF = valueF_

        Dim valueG_ As FSharpOption(Of FSharpOption(Of Integer)) = FSharpOption(Of FSharpOption(Of Integer)).None
        Dim valueG = valueG_
        Dim valueH_ As New FSharpOption(Of FSharpOption(Of Integer))(FSharpOption(Of Integer).None)
        Dim valueH = valueH_
        Dim valueI_ As New FSharpOption(Of FSharpOption(Of Integer))(New FSharpOption(Of Integer)(5))
        Dim valueI = valueI_

        Dim valueJ As Object = "5"



        Assert.AreEqual(Nothing, CStr2(valueA))
        Assert.AreEqual(Nothing, CStr2(valueB))
        Assert.AreEqual(Nothing, CStr2(valueC))
        Assert.AreEqual("5", CStr2(valueD))
        Assert.AreEqual(Nothing, CStr2(valueE))
        Assert.AreEqual("5", CStr2(valueF))
        Assert.AreEqual(Nothing, CStr2(valueG))
        Assert.AreEqual(Nothing, CStr2(valueH))
        Assert.AreEqual("5", CStr2(valueI))
        Assert.AreEqual("5", CStr2(valueJ))
    End Sub
End Class
