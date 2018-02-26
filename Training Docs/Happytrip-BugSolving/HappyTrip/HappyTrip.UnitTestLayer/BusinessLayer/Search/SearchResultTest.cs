using HappyTrip.Model.Entities.AirTravel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HappyTrip.UnitTestLayer
{
    
    
    /// <summary>
    ///This is a test class for SearchResultTest and is intended
    ///to contain all SearchResultTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SearchResultTest
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
        ///A test for GetTravelSchedules
        ///</summary>
        [TestMethod()]
        public void GetTravelSchedulesTest()
        {
            SearchResult target = new SearchResult(); // TODO: Initialize to an appropriate value
            List<TravelSchedule> expected = null; // TODO: Initialize to an appropriate value
            List<TravelSchedule> actual;
            actual = target.GetTravelSchedules();
           
            Assert.AreNotEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
