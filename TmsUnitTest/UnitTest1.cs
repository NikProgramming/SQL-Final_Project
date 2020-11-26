﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FinalProject;


namespace TmsUnitTest
{
    //https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
    //link to understand unit tests

    /// 
    /// \class UnitTest1
    ///
    /// \brief The purpose of this class is to test the classes and function within are tms solution.
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
        ///		\brief Called to check if the payment method has sucessfully been processed.
        ///     
        ///		This Method Verifies the if thew user has payed with billing function This allows
        ///		us to check if the test was successful by comparing the receipt logs sent in.
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
        ///		\brief Called to check if the order method has sucessfully been processed.
        ///		\details <b>Details</b>
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


        [TestMethod]
        public void buyerTest()
        {
            //Arrange
           
            //Act

            //Assert
        }

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
