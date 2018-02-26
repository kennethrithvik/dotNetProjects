using HappyTrip.DataAccessLayer.Transaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HappyTrip.Model.Entities.Transaction;
using System.Data;

namespace HappyTrip.UnitTestLayer
{
    
    
    /// <summary>
    ///This is a test class for BookingDAOTest and is intended
    ///to contain all BookingDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BookingDAOTest
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
        ///A test for BookingDAO Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HappyTrip.DataAccessLayer.dll")]
        public void BookingDAOConstructorTest()
        {
            BookingDAO_Accessor target = new BookingDAO_Accessor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        ///// <summary>
        /////A test for GetInstance
        /////</summary>
        //[TestMethod()]
        //public void GetInstanceTest()
        //{
        //    BookingTypes type = new BookingTypes(); // TODO: Initialize to an appropriate value
        //    BookingDAO expected = null; // TODO: Initialize to an appropriate value
        //    BookingDAO actual;
        //    actual = BookingDAO.GetInstance(type);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for MakeBooking
        /////</summary>
        //[TestMethod()]
        //public void MakeBookingTest()
        //{
        //    BookingDAO_Accessor target = new BookingDAO_Accessor(); // TODO: Initialize to an appropriate value
           
        //    Booking newBooking = new FlightBooking(); // TODO: Initialize to an appropriate value
        //    newBooking.BookingId = 123;
        //    newBooking.BookingDate = Convert.ToDateTime("04/30/2013");
        //   BookingTypes btypes = (BookingTypes)Enum.Parse(typeof(BookingTypes), "Flight");
        //   newBooking.BookingType = btypes;
        //   BookingContact bookingcontact = new BookingContact();
        //   bookingcontact.ContactName = "Parameswari";
        //   bookingcontact.Address = "Villivakkam";
        //   bookingcontact.City = "Chennai";
        //   bookingcontact.Email = "Parameswaribala@gmail.com";
        //   bookingcontact.MobileNo = "9952032862";
        //   bookingcontact.PhoneNo = "26502438";
        //   bookingcontact.PinCode = "600049";
        //   bookingcontact.State = "TamilNadu";

        //   newBooking.Contact = bookingcontact;
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = target.MakeBooking(newBooking);
        //    Assert.IsNotNull(actual);
        //    //Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for StoreBookingForUser
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("HappyTrip.DataAccessLayer.dll")]
        //public void StoreBookingForUserTest()
        //{
        //    BookingDAO_Accessor target = new BookingDAO_Accessor(); // TODO: Initialize to an appropriate value
        //    string bookingRefernceNo = string.Empty; // TODO: Initialize to an appropriate value
        //    string userName = string.Empty; // TODO: Initialize to an appropriate value
        //    IDbConnection dbConnection = null; // TODO: Initialize to an appropriate value
        //    target.StoreBookingForUser(bookingRefernceNo, userName, dbConnection);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}
    }
}
