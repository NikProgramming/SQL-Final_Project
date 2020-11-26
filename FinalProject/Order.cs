//Order.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{

    /// 
    /// \class Order
    ///
    /// \brief The purpose of this class is to realistically model the Order for the TMS system.
    ///	
    ///		NAME: Order
    ///		PURPOSE : The Order class has been created to model the Order for the TMS solution.
    ///
    /// Within the class definition 
    /// - int itemID	- models the ID of a item.
    /// - int orderID   - models the ID of the order.
    /// - string itemName - models the name of the item.
    /// - int customer - models the ID of the customer.
    ///
    /// \author  <i>Input name here</i>
    ///
    public class Order
    {
        ///
        ///		\brief Called to take the order of the customer.
        ///		\details <b>Details</b>
        ///     \param buyerID - <b>int</b> - Represents the buyersID.
        ///     \param orderID - <b>int</b> - Represents the orderID.
        ///     \param customerID - <b>int</b> - Represents the customerID.
        ///     \param itemName - <b>string</b> - Represents the item name
        ///		This Method takes the user order.
        /// 
        ///		\return void.
        ///
        public void takeOrder(int orderID, int customerID, int itemID, string itemName)
        {

        }


        ///
        ///		\brief Called to check the order confirmation.
        ///		\details <b>Details</b>
        ///		This Method checks for the user order confirmation.
        /// 
        ///		\return void.
        ///
        public Boolean OrderConfirmation()
        {
            return true;
        }
    }
}
