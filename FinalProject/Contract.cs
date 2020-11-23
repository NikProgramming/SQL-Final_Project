using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Contract
    {
        string incomingOrderID;
        string incomingCustomerID;
        int orderID;
        int customerID;
        string customerName;
        string customerGender;
        string dateOfBirth;

        void infoValidation()
        {
            if (int.TryParse(incomingOrderID, out orderID) == true)
            {

            }

            if (int.TryParse(incomingCustomerID, out customerID) == true)
            {

            }
        }
    }
}
