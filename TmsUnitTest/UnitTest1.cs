using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FinalProject;


namespace TmsUnitTest
{
    //https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
    //link to understand unit tests

    /// 
    /// \class UnitTest1
    ///
    /// \Test Plan
    /// 
    /// \brief The purpose of this class is to test the classes and function within are tms solution.
    /// this is the test plan for are TMS solution and milestone 3 since we chose to do it in doxygen and not excel.
    ///	
    ///		NAME: UnitTest1
    ///		PURPOSE : The UnitTest1 class have been create to test the entire Tms solution.
    ///
    ///
    /// \author  <i>Justin Langevin</i>, <i>Troy Hill</i>, <i>Nikola Ristic</i>, <i>Josiah Rehkopf</i>
    ///
    [TestClass]
    public class UnitTest1
    {

        ///
        ///		\brief Called to check if the payment method has successfully been processed.
        ///     
        ///		This Method Verifies if the user has payed within the billing function. This allows
        ///		us to check if the test was successful by comparing the receipt logs sent in.
        ///     
        ///     \details <b>Details</b>
        ///     
        ///     How the test is conducted: We input a test orderID and customerID buyerID 
        ///     and the payment status to verify the payment from there we call the receipt 
        ///     log to get the out come we expect it to fail.
        /// 
        ///     Type of test: Functional
        ///     
        ///     Expected outcome: For the test to return payment declined.
        ///     
        ///     Result: it returned payment declined.
        /// 
        ///		\return void.
        ///
        [TestMethod]
        public void billingTest()
        {

            //Arrange
            int orderID = 1;
            int customerID = 1;
            int buyerID = 1;
            string expected = "Payment Decline";
            string result;
            Billing bill = new Billing();


            //Act
            bill.VerifyPayment(orderID,customerID, buyerID, true);
            result = bill.Receipt(orderID, customerID, buyerID);


            //Assert
            Assert.AreEqual(expected, result);
        }





        /// 
        /// Add comments pls
        /// 
        [TestMethod]
        public void contractTest()
        {
            //Arrange
            int expected = 1;
            int result = 0;
            //Act
            result = Contract.connectMarketplace();
            //Assert
            Assert.AreEqual(expected, result);
        }


        /// 
        /// Add comments pls
        /// 
        [TestMethod]
        public void carrierTest()
        {
            //Arrange
            double expected = 11.5;
            double result = 0.0;
            //Act
            result = Carrier.SetTrip();
            //Assert
            Assert.AreEqual(expected, result);
        }

        ///
        ///		\brief Called to check if the order method has successfully been processed.
        ///		\details <b>Details</b>
        ///     
        ///     How the test is conducted: We test the orderconfirmation by creating the expected result
        ///     and returning the result that is given in the order confirmation. We then compare and see
        ///     if the result is equal to the expected.
        /// 
        ///     Type of test: Functional
        ///         
        ///     Expected outcome: It returns if the order is confirmed
        ///     
        ///     Result: it returns true to tell that the order was confirmed.
        /// 
        ///		This Method Verifies the if the user has had their order confirmation confirmed
        /// 
        ///		\return void.
        ///
        [TestMethod]
        public void orderTest()
        {
            //Arrange
            bool expected = true;
            bool result;
            Order testOrder = new Order();
            //Act
            result= testOrder.OrderConfirmation();
            //Assert
            Assert.AreEqual(expected, result);
        }

        ///
        ///		\brief Called to check if the order method has unsuccessfully been processed.
        ///		\details <b>Details</b>
        ///     
        ///     How the test is conducted: We test the orderconfirmation by creating the expected result
        ///     and returning the result that is given in the order confirmation. We then compare and see
        ///     if the result is equal to the expected meaning that its valid.
        /// 
        ///     Type of test: Exception
        ///         
        ///     Expected outcome: It returns that the order is not confirmed
        ///     
        ///     Result: it returns true to tell that the order was confirmed.
        /// 
        ///		This Method Verifies the if the user has had their order confirmation confirmed
        /// 
        ///		\return void.
        ///
        [TestMethod]
        public void orderTestException()
        {
            //Arrange
            bool expected = false;
            bool result;
            Order testOrder = new Order();
            //Act
            result = testOrder.OrderConfirmation();
            //Assert
            Assert.AreEqual(expected, result);
        }



        ///
        ///		\brief Called to check if the SelectCarrier method works properly.
        ///     
        ///		This Method Verifies that the correct carrier is selected based on the users
        ///		location.
        ///		
        ///     How the test is conducted: The test is conducted by creating a expected carrier and a city.
        ///     The test then sends the created city to the selectCarrier and gets the return. The expected
        ///     carrier is then compared to the carrier that is returned.
        /// 
        ///     \details <b>Details</b>
        ///     
        ///     Type of test: Functional
        ///         
        ///     Expected outcome: For the test to return the carrier Planet Express.
        ///     
        ///     Result: it returned Planet Express.
        /// 
        ///		\return void.
        ///
        [TestMethod]
        public void plannerTest()
        {
            string expected = "Planet Express";
            string city = "Oshawa";
            Planner testPlanner = new Planner();
            string result = testPlanner.SelectCarrier(city);
            Assert.AreEqual(expected, result);

        }
    }
}
