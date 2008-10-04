using ClrExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Clr_Extensions_CSharp_Tests
{
    
    
    /// <summary>
    ///This is a test class for ActionExtensionsTest and is intended
    ///to contain all ActionExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ActionExtensionsTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Repeat
        ///</summary>
        [TestMethod()]
        public void RepeatTest1()
        {

            var count = 0;
            Action<int> action = (i)=> count+=i;
            int occurances = 10; 
            action.Repeat(occurances);
            Assert.AreEqual(55, count);
            
        }

        /// <summary>
        ///A test for Repeat
        ///</summary>
        [TestMethod()]
        public void RepeatTest()
        {
            var count = 0;
            Action action = () => count ++;
            int occurances = 10;
            action.Repeat(occurances);
            Assert.AreEqual(10, count);
        }
    }
}
