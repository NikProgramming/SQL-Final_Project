using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{ 
    public class Carrier
    {
        struct Destinations
        {
            public string destination;
            public int distance;
            public double time;
            public string west;
            public string east;
        } 

        const int loadUnloadTime = 2;

        int carrierID;
        string address;
        int workHours;
        int driveHours;
        string company;
        static double totalTravelTime = 0;
        static string load;
        static double remainingTime;

        ///
        ///		\brief Called to set up the trip and go through the trip.
        ///		\details <b>Details</b>
        ///
        ///		This Method returns the total time for the trip.
        /// 
        ///		\return Returns a time in hours.
        ///
        public static double SetTrip()
        {
            //Contract contract = new Contract();
            string origin = "Windsor"; //= Contract.origin;
            string destination = "Hamilton";// = Contract.destination;
            Destinations currentLocation = new Destinations();
            load = "LTL";

            Destinations windsor = new Destinations();
            windsor.destination = "Windsor";
            windsor.distance = 191;
            windsor.time = 2.5;
            windsor.west = "END";
            windsor.east = "London";

            Destinations london = new Destinations();
            london.destination = "London";
            london.distance = 128;
            london.time = 1.75;
            london.west = "Windsor";
            london.east = "Hamilton";

            Destinations hamilton = new Destinations();
            hamilton.destination = "Hamilton";
            hamilton.distance = 68;
            hamilton.time = 1.25;
            hamilton.west = "London";
            hamilton.east = "Toronto";

            Destinations toronto = new Destinations();
            toronto.destination = "Toronto";
            toronto.distance = 60;
            toronto.time = 1.3;
            toronto.west = "Hamilton";
            toronto.east = "Oshawa";

            Destinations oshawa = new Destinations();
            oshawa.destination = "Oshawa";
            oshawa.distance = 134;
            oshawa.time = 1.65;
            oshawa.west = "Toronto";
            oshawa.east = "BelleVille";
 
            Destinations belleville = new Destinations();
            belleville.destination = "BelleVille";
            belleville.distance = 82;
            belleville.time = 1.2;
            belleville.west = "Oshawa";
            belleville.east = "Kingston";


            Destinations kingston = new Destinations();
            kingston.destination = "Kingston";
            kingston.distance = 196;
            kingston.time = 2.5;
            kingston.west = "BelleVille";
            kingston.east = "Ottawa";

            Destinations ottawa = new Destinations();
            ottawa.destination = "Ottawa";
            ottawa.distance = 0;
            ottawa.time = 0;
            ottawa.west = "Kingston";
            ottawa.east = "END";

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


            if (load == "LTL")
            {
                totalTravelTime += loadUnloadTime;
                while (currentLocation.destination != destination)
                {
                    totalTravelTime += currentLocation.time;
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

                    if(currentLocation.destination != destination)
                    {
                        totalTravelTime += loadUnloadTime;
                    }
                    remainingTime = timeLeft();
                }
                totalTravelTime += currentLocation.time;
                totalTravelTime += loadUnloadTime;
            }
            else if (load == "FTL")
            {
                totalTravelTime += loadUnloadTime;
                while (currentLocation.destination != destination)
                {
                    totalTravelTime += currentLocation.time;
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
                    remainingTime = timeLeft();
                }
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
        ///		\return Returns a remaining time in hours.
        ///
        public static double timeLeft()
        {
            DateTime eta = new DateTime();
            eta = DateTime.Now;
            double timeLeft = (eta.Hour + totalTravelTime) - eta.Hour;
            return timeLeft;
        }
    }
}
