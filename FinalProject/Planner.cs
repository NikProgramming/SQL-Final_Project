//Planner.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// 
    /// \class Planner
    ///
    /// \brief The purpose of this class is to realistically model the Planner for the TMS system.
    ///	
    ///		NAME: Planner
    ///		PURPOSE : The Planner class has been created to model the Planner.
    ///
    /// Within the class definition 
    /// - int plannerID	- models the ID of a plannerID.
    /// - int orderID   - models the ID of the order.
    /// - string address - models the ID of the address.
    ///
    /// \author  <i>Input name here</i>
    ///
    public class Planner
    {
        int plannerID;
        int orderID;
        string address; //(trip)

        ///
        ///		\brief Called to select a carrier.
        ///		\details <b>Details</b>
        ///     
        ///		This Methods returns the carrier that has been selected.
        /// 
        ///		\return void.
        ///
        public string SelectCarrier()
        {
            return "s";
        }
    }
}
