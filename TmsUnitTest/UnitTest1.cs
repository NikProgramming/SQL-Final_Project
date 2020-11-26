using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FinalProject;


namespace TmsUnitTest
{
    //https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
    //link to understand unit tests
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void billingTest()
        {

            //Arrange
            Billing bill = new Billing();
            //Act

            //Assert

        }

        [TestMethod]
        public void contractTest()
        {

            //Arrange
            Billing bill = new Billing();
            //Act

            //Assert
        }

        [TestMethod]
        public void carrierTest()
        {

            //Arrange
            
            //Act

            //Assert
        }

        [TestMethod]
        public void orderTest()
        {

            //Arrange
            
            //Act

            //Assert
        }


        [TestMethod]
        public void buyerTest()
        {
            //Arrange
           
            //Act

            //Assert
        }
    }
}
