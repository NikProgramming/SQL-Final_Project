//Buyer.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// 
    /// \class Buyer
    ///
    /// \brief The purpose of this class is to realistically model the Buyer for the TMS system.
    ///	
    ///		NAME: Buyer
    ///		PURPOSE : The Buyer class has been created to model the buyer.
    ///
    /// Within the class definition 
    /// - int buyerID	- models the ID of a buyer.
    /// - int orderID   - models the ID of the order.
    /// - int customerID - models the ID of the customer.
    ///
    /// \author  <i>Josiah Rehkopf</i>
    ///
    public class Buyer
    {
        int buyerID;
        int orderID;
        int customerID;

        ///
        ///		\brief Called to request a customer contract.
        ///		\details <b>Details</b>
        ///     
        ///		This Methods returns the customer contract.
        /// 
        ///		\return customerContract.
        ///
        public void RequstCustomerContract()
        {

        }

        ///
        ///		\brief Called to create a order.
        ///		\details <b>Details</b>
        ///     
        ///		This Methods creates a customers order.
        /// 
        ///		\return void.
        ///
        static public bool CreateOrder(string compName, string destination, string origin)
        {
            string carrier1;
            string carrier2;
            carrier1=Planner.SelectCarrier(destination);
            carrier2 = Planner.SelectCarrier(origin);
            return true; //Billing.VerifyPayment(true);

        }
    }
}
