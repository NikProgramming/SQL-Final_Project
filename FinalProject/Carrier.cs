/* -------------------------------------------------------------------------------------------
        * File           : Carrier.cs
        * Project        : PROG2020 - SQ Final
        * Programmers    : Troy Hill, Justin Langevin, Nikola Ristic, Josiah Rehkopf
        * First Version  : 12/1/2020
        * Description    : This file holds the code that is used to model the carrier of the TMS system.
        *                  It creates trips and calculates the distance and time they will take.

        * ------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FinalProject
{
    /// 
    /// \class Carrier
    ///
    /// \brief The purpose of this class is to realistically models the Carrier service for the TMS system.
    ///	
    ///		NAME: Service
    ///		PURPOSE : The Service class has been created to model the Carriers set trips for the orders.
    ///
    /// Within the class definition 
    /// - struct Destination - : Contains the current city that you're in(will change name)
    /// - int carrierID - models the carrier ID.
    /// - string address - models the address/destination.
    /// - int driveHours - models the amount of hours the driver need to drive.
    /// - string company - models the carrier company name.
    /// - static double - models the total time traveled.
    /// - static string - models the load .
    /// - static double - models the remainingTime of the trip.
    /// 
    /// \author  <i>Troy Hill</i>
    ///
    public class Carrier
    {
        //set up struct for each city
        struct Destinations
        {
            public string destination;
            public int distance;
            public double time;
            public string west;
            public string east;
        } 

        //time it takes to load and unload at cities
        const int loadUnloadTime = 2;
        static double totalTravelTime = 0;
        static int totalDistance = 0;

        ///
        ///		\brief Called to set up the trip and go through the trip.
        ///		\details <b>Details</b>
        ///
        ///		This Method returns the total time for the trip.
        ///		
        ///     Fault exceptions: None   
        /// 
        ///		\return Returns a time in hours.
        ///

        /* -------------------------------------------------------------------------------------------
       * Method        :   SetTrip()
       * Description   :   calcuates the distance of a trip
       * Parameters    :   string origin - the trip starting point
       *                   string destination - where the trip ends
       *                   string load - the type of load being sent
       * Returns       :   double - the distance
       * ------------------------------------------------------------------------------------------*/
        public static double SetTrip(string origin, string destination, string load)
        {
            //current city
            Destinations currentLocation = new Destinations();

            //windsor
            Destinations windsor = new Destinations();
            windsor.destination = "Windsor";
            windsor.distance = 191;
            windsor.time = 2.5;
            windsor.west = "END";
            windsor.east = "London";

            //london
            Destinations london = new Destinations();
            london.destination = "London";
            london.distance = 128;
            london.time = 1.75;
            london.west = "Windsor";
            london.east = "Hamilton";

            //hamilton
            Destinations hamilton = new Destinations();
            hamilton.destination = "Hamilton";
            hamilton.distance = 68;
            hamilton.time = 1.25;
            hamilton.west = "London";
            hamilton.east = "Toronto";

            //toronto
            Destinations toronto = new Destinations();
            toronto.destination = "Toronto";
            toronto.distance = 60;
            toronto.time = 1.3;
            toronto.west = "Hamilton";
            toronto.east = "Oshawa";

            //oshawa
            Destinations oshawa = new Destinations();
            oshawa.destination = "Oshawa";
            oshawa.distance = 134;
            oshawa.time = 1.65;
            oshawa.west = "Toronto";
            oshawa.east = "Belleville";
            
            //belleville
            Destinations belleville = new Destinations();
            belleville.destination = "Belleville";
            belleville.distance = 82;
            belleville.time = 1.2;
            belleville.west = "Oshawa";
            belleville.east = "Kingston";

            //kingston
            Destinations kingston = new Destinations();
            kingston.destination = "Kingston";
            kingston.distance = 196;
            kingston.time = 2.5;
            kingston.west = "Belleville";
            kingston.east = "Ottawa";

            //ottawa
            Destinations ottawa = new Destinations();
            ottawa.destination = "Ottawa";
            ottawa.distance = 0;
            ottawa.time = 0;
            ottawa.west = "Kingston";
            ottawa.east = "END";

            //check to see where to start
            if(origin == "Windsor")
            {
                currentLocation = windsor;
            }
            else if(origin == "London")
            {
                currentLocation = london;
            }
            else if (origin == "Hamilton")
            {
                currentLocation = hamilton;
            }
            else if (origin == "Toronto")
            {
                currentLocation = toronto;
            }
            else if (origin == "Oshawa")
            {
                currentLocation = oshawa;
            }
            else if (origin == "Belleville")
            {
                currentLocation = belleville;
            }
            else if (origin == "Kingston")
            {
                currentLocation = kingston;
            }
            else if (origin == "Ottawa")
            {
                currentLocation = ottawa;
            }

            //connect to local database
            string cs = "server=localhost;userid=root;password=123sql;database=TMSDatabase";
            string direction = "";
            MySqlConnection directionCon = new MySqlConnection(cs);
            directionCon.Open();
            //get direction from most recent contract
            MySqlCommand getDirection = new MySqlCommand("SELECT direction FROM OD ORDER BY travelID DESC LIMIT 1", directionCon);
            MySqlDataReader readDirection = getDirection.ExecuteReader();
            while(readDirection.Read())
            {
                direction = readDirection.GetString(0);
            }
            //close connection and reader
            readDirection.Close();
            directionCon.Close();

            //initialize total travel time
            totalTravelTime = 0;

            //if going east
            if(direction == "E")
            {
                //if the load is "Less than Load"
                if (load == "LTL")
                {
                    //add load time
                    totalTravelTime += loadUnloadTime;
                    while (currentLocation.destination != destination)
                    {
                        //add to travel time
                        totalTravelTime += currentLocation.time;
                        //go to next city
                        if (currentLocation.east == "London")
                        {
                            currentLocation = london;
                        }
                        else if (currentLocation.east == "Hamilton")
                        {
                            currentLocation = hamilton;
                        }
                        else if (currentLocation.east == "Toronto")
                        {
                            currentLocation = toronto;
                        }
                        else if (currentLocation.east == "Oshawa")
                        {
                            currentLocation = oshawa;
                        }
                        else if (currentLocation.east == "Belleville")
                        {
                            currentLocation = belleville;
                        }
                        else if (currentLocation.east == "Kingston")
                        {
                            currentLocation = kingston;
                        }
                        else if (currentLocation.east == "Ottawa")
                        {
                            currentLocation = ottawa;
                        }
                        //add distance
                        totalDistance = currentLocation.distance;
                        //if not in destination city
                        if (currentLocation.destination != destination)
                        {
                            //make a stop
                            totalTravelTime += loadUnloadTime;
                        }
                    }
                    //add distance
                    totalDistance = currentLocation.distance;
                    //add travel time for destination city
                    totalTravelTime += currentLocation.time;
                    //unload
                    totalTravelTime += loadUnloadTime;
                }
                else if (load == "FTL") //otherwise if load is "Full truck load"
                {
                    //add load time
                    totalTravelTime += loadUnloadTime;
                    while (currentLocation.destination != destination)
                    {
                        //add travel time
                        totalTravelTime += currentLocation.time;
                        //go to next city
                        if (currentLocation.east == "London")
                        {
                            currentLocation = london;
                        }
                        else if (currentLocation.east == "Hamilton")
                        {
                            currentLocation = hamilton;
                        }
                        else if (currentLocation.east == "Toronto")
                        {
                            currentLocation = toronto;
                        }
                        else if (currentLocation.east == "Oshawa")
                        {
                            currentLocation = oshawa;
                        }
                        else if (currentLocation.east == "Belleville")
                        {
                            currentLocation = belleville;
                        }
                        else if (currentLocation.east == "Kingston")
                        {
                            currentLocation = kingston;
                        }
                        else if (currentLocation.east == "Ottawa")
                        {
                            currentLocation = ottawa;
                        }
                        //add distance
                        totalDistance = currentLocation.distance;
                    }
                    //add distance
                    totalDistance = currentLocation.distance;
                    //add travel time for destination city
                    totalTravelTime += currentLocation.time;
                    //set unload time
                    totalTravelTime += loadUnloadTime; ;
                }
            }
            else if(direction == "W") //if going west
            {
                //if the load is "Less than Load"
                if (load == "LTL")
                {
                    //add load time
                    totalTravelTime += loadUnloadTime;
                    while (currentLocation.destination != destination)
                    {
                        //add to travel time
                        totalTravelTime += currentLocation.time;
                        //go to next city
                        if (currentLocation.west == "London")
                        {
                            currentLocation = london;
                        }
                        else if (currentLocation.west == "Hamilton")
                        {
                            currentLocation = hamilton;
                        }
                        else if (currentLocation.west == "Toronto")
                        {
                            currentLocation = toronto;
                        }
                        else if (currentLocation.west == "Oshawa")
                        {
                            currentLocation = oshawa;
                        }
                        else if (currentLocation.west == "Belleville")
                        {
                            currentLocation = belleville;
                        }
                        else if (currentLocation.west == "Kingston")
                        {
                            currentLocation = kingston;
                        }
                        else if(currentLocation.west == "Windsor")
                        {
                            currentLocation = windsor;
                        }
                        //add distance
                        totalDistance = currentLocation.distance;
                        //if not in destination city
                        if (currentLocation.destination != destination)
                        {
                            //make a stop
                            totalTravelTime += loadUnloadTime;
                        }
                    }
                    //add distance
                    totalDistance = currentLocation.distance;
                    //add travel time for destination city
                    totalTravelTime += currentLocation.time;
                    //unload
                    totalTravelTime += loadUnloadTime;
                }
                else if (load == "FTL") //otherwise if load is "Full truck load"
                {
                    //add load time
                    totalTravelTime += loadUnloadTime;
                    while (currentLocation.destination != destination)
                    {
                        //add travel time
                        totalTravelTime += currentLocation.time;
                        //go to next city
                        if (currentLocation.west == "London")
                        {
                            currentLocation = london;
                        }
                        else if (currentLocation.west == "Hamilton")
                        {
                            currentLocation = hamilton;
                        }
                        else if (currentLocation.west == "Toronto")
                        {
                            currentLocation = toronto;
                        }
                        else if (currentLocation.west == "Oshawa")
                        {
                            currentLocation = oshawa;
                        }
                        else if (currentLocation.west == "Belleville")
                        {
                            currentLocation = belleville;
                        }
                        else if (currentLocation.west == "Kingston")
                        {
                            currentLocation = kingston;
                        }
                        else if (currentLocation.west == "Windsor")
                        {
                            currentLocation = windsor;
                        }
                        //add distance
                        totalDistance = currentLocation.distance;
                    }
                    //add distance
                    totalDistance = currentLocation.distance;
                    //add travel time for destination city
                    totalTravelTime += currentLocation.time;
                    //set unload time
                    totalTravelTime += loadUnloadTime; 
                }
            }

            return totalTravelTime;
        }

        /* -------------------------------------------------------------------------------------------
        * Method        :   distance()
        * Description   :   returns the total distance of the trip
        * Parameters    :   none
        * Returns       :   int - the distance
        * ------------------------------------------------------------------------------------------*/
        public static int distance()
        {
            return totalDistance;
        }

        ///
        ///		\brief Called to show the remaining time for the trip.
        ///		\details <b>Details</b>
        ///
        ///		This Method returns the remaining time for the trip.
        /// 
        ///     Fault exceptions:
        /// 
        ///		\return Returns a remaining time in hours.
        ///
        
        /* -------------------------------------------------------------------------------------------
        * Method       :   timeLeft()
        * Description  :   returns the remaining time of the trip
        * Parameters   :   none
        * Returns      :   double - the time left
        * ------------------------------------------------------------------------------------------*/
        public static double timeLeft()
        {
            totalTravelTime = totalTravelTime - 0.01;
            //set time left in travel
            double timeLeft = totalTravelTime;
            return timeLeft;
        }
    }
}
