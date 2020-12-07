/* -------------------------------------------------------------------------------------------
        * File           : Buyer.cs
        * Project        : PROG2020 - SQ Final
        * Programmers    : Troy Hill, Justin Langevin, Nikola Ristic, Josiah Rehkopf
        * First Version  : 12/1/2020
        * Description    : This file holds the code that is used to model the Buyer of the TMS system.
        *                  It allows the user to create a new order.

        * ------------------------------------------------------------------------------------------*/
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
        ///
        ///		\brief Called to create a order.
        ///		\details <b>Details</b>
        ///     
        ///		This Methods creates a customers order.
        /// 
        ///		\return void.
        ///

        /* -------------------------------------------------------------------------------------------
       * Method        :   CreateOrder()
       * Description   :   creates a new order for the user
       * Parameters    :   string compName - the company name
       *                   string destination - where the order is going
       *                   string origin - origin of the order
       * Returns       :   bool - returns if the payment was verified or not
       * ------------------------------------------------------------------------------------------*/
        static public bool CreateOrder(string compName, string destination, string origin)
        {
            string carrier1;
            string carrier2;
            //gets the carriers
            carrier1=Planner.SelectCarrier(destination);
            carrier2 = Planner.SelectCarrier(origin); 
            int load = MarketPlace.loadValue(); //gets the load type
            int truckType = MarketPlace.vanType(); //gets the truck type
            return Billing.VerifyPayment(compName, carrier1, carrier2, origin, destination, true, load, truckType); //returns if the payment was verified
        }


    }
}
