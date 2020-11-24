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
            string destination;
            int km;
            int time;
            string west;
            string east;
        }

        const int loadUnloadTime = 2;

        int carrierID;
        string address;
        int workHours;
        int driveHours;
        public string SetTrip(string destination)
        {

            return "s";
        }
    }
}
