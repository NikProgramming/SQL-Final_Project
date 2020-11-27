using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /*
        int carrierID;
        string address;
        int workHours;
        int driveHours;
        string company;
        */
        static double totalTravelTime = 0;
        static string load;
        static double remainingTime;

        ///
        ///		\brief Called to set up the trip and go through the trip.
        ///		\details <b>Details</b>
        ///
        ///		This Method returns the total time for the trip.
        ///		
        ///     Fault exceptions: -----------------------------   
        /// 
        ///		\return Returns a time in hours.
        ///
        public static double SetTrip()
        {
            //origin city
            string origin = "Windsor"; //= Contract.origin;
            //destination city
            string destination = "Hamilton";// = Contract.destination;
            //current city
            Destinations currentLocation = new Destinations();
            //what type of load
            load = "LTL";

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
            oshawa.east = "BelleVille";
            
            //belleville
            Destinations belleville = new Destinations();
            belleville.destination = "BelleVille";
            belleville.distance = 82;
            belleville.time = 1.2;
            belleville.west = "Oshawa";
            belleville.east = "Kingston";

            //kingston
            Destinations kingston = new Destinations();
            kingston.destination = "Kingston";
            kingston.distance = 196;
            kingston.time = 2.5;
            kingston.west = "BelleVille";
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
            else if (origin == "BelleVille")
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
                    if(currentLocation.east == "London")
                    {
                        currentLocation = london;
                    }
                    else if(currentLocation.east == "Hamilton")
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
                    else if (currentLocation.east == "BelleVille")
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

                    //if not in destination city
                    if(currentLocation.destination != destination)
                    {
                        //make a stop
                        totalTravelTime += loadUnloadTime;
                    }
                    //set remaining time
                    remainingTime = timeLeft();
                }
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
                    else if (currentLocation.east == "BelleVille")
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
                    //set remaining time
                    remainingTime = timeLeft();
                }
                //add travel time for destination city
                totalTravelTime += currentLocation.time;
                //set unload time
                totalTravelTime += loadUnloadTime;;
            }

            return totalTravelTime;
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
        public static double timeLeft()
        {
            //set date time
            DateTime eta = new DateTime();
            //set time for right now
            eta = DateTime.Now;
            //set time left in travel
            double timeLeft = (eta.Hour + totalTravelTime) - eta.Hour;
            return timeLeft;
        }
    }
}
