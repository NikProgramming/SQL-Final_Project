﻿//Billing.cs
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
    ///		NAME: Billing
    ///		PURPOSE : The billing class has been created to bill the user
    ///
    /// Within the class definition 
    /// - int buyerID	- models the ID of a buyer.
    /// - int orderID   - models the ID of the order.
    /// - int customerID - models the ID of the customer.
    /// - int itemID    - models the ID of the item.
    /// - bool Payment  - holds a flag to verify the payment.
    /// 
    /// 
    /// \author  <i>Justin Langevin</i>
    ///
    public class Billing
    {
        int buyerID =1;
        int orderID = 1;
        int customerID = 1;
        int itemID = 1;//idk if this is needed
        bool payment;

        ///
        ///		\brief Called to check if the payment has gone through.
        ///		
        ///		\details <b>Details</b>
        ///     \param buyerID - <b>int</b> - Represents the buyersID.
        ///     \param orderID - <b>int</b> - Represents the orderID.
        ///     \param customerID - <b>int</b> - Represents the customerID.
        ///     
        ///		This Method verifies the payment.
        ///		
        ///     Fault exceptions: We are checking to see if the payment has been 
        ///     paid for this allows us to verify twice to certify the payment.        
        /// 
        ///		\return void.
        ///
        public void VerifyPayment(int buyerID, int orderID, int customerID, bool payment)
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
        ///     Fault exceptions: The second time to verify the payment to ensure the value is correct.
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
