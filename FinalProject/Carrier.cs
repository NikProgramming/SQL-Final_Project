using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{ 
    class Carrier
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
        public string SetTrip()
        {
            Contract contract = new Contract();
            string origin = contract.origin;
            string destination = contract.destination;
            if (company == "Planet Express")
            {
                
            }
            else if (company == "Schooner's")
            {

            }
            else if(company == "Tillman Transport")
            {

            }
            else if(company == "We Haul")
            {

            }

            Destinations location = new Destinations();
            if (destination == "Windsor")
            {
                //Destinations windsor = new Destinations();
                location.destination = destination;
                location.distance = 191;
                location.time = 2.5;
                location.west = "END";
                location.east = "London";
            }
            else if (destination == "London")
            {
                //Destinations london = new Destinations();
                location.destination = destination;
                location.distance = 128;
                location.time = 1.75;
                location.west = "Windsor";
                location.east = "Hamilton";
            }
            else if (destination == "Hamilton")
            {
                //Destinations hamilton = new Destinations();
                location.destination = destination;
                location.distance = 68;
                location.time = 1.25;
                location.west = "London";
                location.east = "Toronto";
            }
            else if (destination == "Toronto")
            {
                location.destination = destination;
                location.distance = 60;
                location.time = 1.3;
                location.west = "Hamilton";
                location.east = "Oshawa";
            }
            else if (destination == "Oshawa")
            {
                location.destination = destination;
                location.distance = 134;
                location.time = 1.65;
                location.west = "Toronto";
                location.east = "BelleVille";
            }
            else if (destination == "BelleVille")
            {
                location.destination = destination;
                location.distance = 82;
                location.time = 1.2;
                location.west = "Oshawa";
                location.east = "Kingston";
            }
            else if(destination == "Kingston")
            {
                location.destination = destination;
                location.distance = 196;
                location.time = 2.5;
                location.west = "BelleVille";
                location.east = "Ottawa";
            }
            else if(destination == "Ottawa")
            {
                location.destination = destination;
                location.distance = 0;
                location.time = 0;
                location.west = "Kingston";
                location.east = "END";
            }

            return "s";
        }

        public int timeLeft()
        {
            DateTime eta = new DateTime();
            eta = DateTime.Now;
            int timeLeft = (eta.Minute + workHours) - eta.Minute;
            return 0;
        }
    }
}
