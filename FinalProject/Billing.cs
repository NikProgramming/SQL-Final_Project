using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Billing
    {
        int buyerID;
        int orderID;
        int customerID;
        int itemID;//idk if this is needed
        bool payment;


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
