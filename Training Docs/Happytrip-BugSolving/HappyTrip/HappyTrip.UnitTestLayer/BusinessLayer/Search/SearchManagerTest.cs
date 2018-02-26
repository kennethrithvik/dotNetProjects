using HappyTrip.Model.BusinessLayer.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;
using System.Data;
using HappyTrip.DataAccessLayer.Common;
namespace HappyTrip.UnitTestLayer
{
    
    
    /// <summary>
    ///This is a test class for SearchManagerTest and is intended
    ///to contain all SearchManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SearchManagerTest
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
        ///A test for SearchForFlights
        ///</summary>
        //[TestMethod()]
        //public void SearchForFlightsTest()
        //{
        //    SearchManager target = new SearchManager(); // TODO: Initialize to an appropriate value
        //    SearchInfo searchInformation = new SearchInfo();  // TODO: Initialize to an appropriate value
        //    SearchLog expected = null; // TODO: Initialize to an appropriate value
        //    SearchLog actual;
        //    City fromcity = new City();
        //    fromcity.CityId = 32;
        //    fromcity.Name = "New Delhi";

        //    City tocity = new City();
        //    tocity.CityId = 58;
        //    tocity.Name = "Bellary";
        //    TravelClass travelclass = (TravelClass)Enum.Parse(typeof(TravelClass), "Economy");
        //    TravelDirection traveldirection = (TravelDirection)Enum.Parse(typeof(TravelDirection), "OneWay");
        //    searchInformation.ToCity = tocity;
        //    searchInformation.FromCity = fromcity;
        //    searchInformation.Class = travelclass;
        //    searchInformation.Direction = traveldirection;
        //    searchInformation.NoOfSeats = 2;
        //    searchInformation.OnwardDateOfJourney = Convert.ToDateTime("06/05/2013");
          
                      
        //    actual = target.SearchForFlights(searchInformation);
        //    Assert.AreNotEqual(expected, actual);
        //   // Assert.Inconclusive("Verify the correctness of this test method.");
        //}
    }
}
