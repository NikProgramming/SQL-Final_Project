//Billing.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{

    /// 
    /// \class Billing
    ///
    /// \brief The purpose of this class is to realistically model the billing for the TMS system.
    ///	
    ///		NAME: Circle
    ///		PURPOSE : The billing class has been created to 
    ///
    /// Within the class definition 
    /// - int buyerID	- models the ID of a buyer.
    ///
    /// \author  <i>Justin Langevin</i>
    ///
    class Billing
    {
        int buyerID;
        int orderID;
        int customerID;
        int itemID;//idk if this is needed
        bool payment;

        ///
        ///		\brief Called to check if the payment has gone Threw for the payment.
        ///		\details <b>Details</b>
        ///     \param buyerID - <b>int</b> - Represents the buyersID.
        ///     \param orderID - <b>int</b> - Represents the orderID.
        ///     \param customerID - <b>int</b> - Represents the customerID.
        ///     
        ///		This Function returns the Verifies the if thew user has payed to call billing function.
        /// 
        ///		\return void.
        ///
        public void VerifyPayment(int buyerID, int orderID, int customerID)
        {
            if (payment == true)
            {
                Receipt(buyerID, orderID, customerID);
            }
            else
            {
                Receipt(buyerID, orderID, customerID);
            }
        }



        ///
        ///		\brief Called to create the receiptLog for the billing.
        ///		\details <b>Details</b>
        ///		\param buyerID - <b>int</b> - Represents the buyersID.
        ///     \param orderID - <b>int</b> - Represents the orderID.
        ///     \param customerID - <b>int</b> - Represents the customerID.
        ///
        ///		This Method returns the Receipt for the user.
        /// 
        ///		\return Returns a receipt log.
        ///
        public string Receipt(int buyerID, int orderID, int customerID)
        {
            string receiptLog ="";
            if (payment == true)
            {
                receiptLog = "BuyerID: " + buyerID.ToString() + " OrderID: " + orderID.ToString() + " CustomerID: " + customerID.ToString();
            }
            else
            {
                receiptLog = "Payment Decline";
            }
            return receiptLog;
        }
    }
}
