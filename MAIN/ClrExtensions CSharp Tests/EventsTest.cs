using ClrExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Clr_Extensions_CSharp_Tests
{


	/// <summary>
	///This is a test class for EventsTest and is intended
	///to contain all EventsTest Unit Tests
	///</summary>
	[TestClass()]
	public class EventsTest
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




		[TestMethod()]
		public void RaiseTest()
		{
				var a = new EventTester();
				a.RaiseA();
				a.RaiseB();
				a.RaiseC();
				a.RaiseD();
				a.RaiseE();
				Assert.AreEqual(0, a.eventCount);

				var b = new EventTester();
				b.Event1 += b.Target1;
				b.Event2 += b.Target2;
				b.Event3 += b.Target4;

				b.RaiseA();
				Assert.AreEqual(1, b.eventCount);
				b.eventCount = 0;

				b.RaiseB();
				Assert.AreEqual(1, b.eventCount);
				b.eventCount = 0;

				b.RaiseC();
				Assert.AreEqual(2, b.eventCount);
				b.eventCount = 0;

				b.RaiseE();
				Assert.AreEqual(4, b.eventCount);
				b.eventCount = 0;

				b.RaiseE();
				Assert.AreEqual(4, b.eventCount);
				b.eventCount = 0;
		}


		private class EventTester
		{
			public int eventCount = 0;

			public void RaiseA()
			{
				Event1.Raise(this);
			}
			public void RaiseB()
			{
				Event1.Raise(this, EventArgs.Empty);
			}
			public void RaiseC()
			{
				Event2.Raise(this, new ResolveEventArgs ("XXX"));
			}
			public void RaiseD()
			{
				Event3.Raise(this);
			}
			public void RaiseE()
			{
				Event3.Raise(this, EventArgs.Empty);
			}

			public event EventHandler Event1;
			public event EventHandler<ResolveEventArgs> Event2;
			public event EventHandler<EventArgs> Event3;

			public void Target1(object source, EventArgs e)
			{
				eventCount += 1;
			}

			public void Target2(object source, ResolveEventArgs e)
			{
				eventCount += 2;
			}

			public void Target4(object source, EventArgs e)
			{
				eventCount += 4;
			}

			public void Target8(object source, ResolveEventArgs e)
			{
				eventCount += 8;
			}
		}


	}
}
