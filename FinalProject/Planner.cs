/* -------------------------------------------------------------------------------------------
        * File           : Planner.cs
        * Project        : PROG2020 - SQ Final
        * Programmers    : Troy Hill, Justin Langevin, Nikola Ristic, Josiah Rehkopf
        * First Version  : 12/1/2020
        * Description    : This file holds the code that is used to model the planner of the TMS system.
        *                  It recieves a city and returns the appropriate carrier.

        * ------------------------------------------------------------------------------------------*/
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
    ///
    /// \author  <i>Josiah Rehkopf</i>
    ///
    public class Planner
    {
        ///
        ///		\brief Called to select a carrier.
        ///		\details <b>Details</b>
        ///     \param location - <b>string</b> - Represents the location of the order.
        ///     \param carrier  -<b>string</b> - Represents the carriers to select from. 
        /// 
        ///		This Methods returns the carrier that has been selected.
        ///		
        ///     The Fault exceptions: the fault exceptions we have in place is to verify 
        ///     that every city has an associated carrier so that way one carrier doesn't have all the orders. 
        ///     
        /// 
        ///		\return void.
        ///
        static public string SelectCarrier(string location)
        {
            string city = location;
            string carrier = "N/A";
            if (city == "Windsor") //checks if city is Windsor
            {
                carrier = "Tillman Transport"; //sets carrier to Tillman Transport
            }
            if (city == "Hamilton") //checks if city is Hamilton
            {
                carrier = "Tillman Transport"; //sets carrier to Tillman Transport
            }
            if (city == "Oshawa") //checks if city is Oshawa
            {
                carrier = "Planet Express"; //sets carrier to Planet Express
            }
            if (city == "Belleville") //checks if city is Belleville
            {
                carrier = "Planet Express"; //sets carrier to Planet Express
            }
            if (city == "Ottawa") //checks if city is Ottawa
            {
                carrier = "We Haul"; //sets carrier to We Haul
            }
            if (city == "London") //checks if city is London
            {
                carrier = "Schooner's"; //sets carrier to Schooner's
            }
            if (city == "Toronto") //checks if city is Toronto
            {
                carrier = "We Haul"; //sets carrier to We Haul
            }
            if (city == "Kingston") //checks if city is Kingston
            {
                carrier = "Schooner's"; //sets carrier to Schooner's
            }

            return carrier; //returns the selected carrier
        }
    }
}
