//Billing.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FinalProject
{

    /// 
    /// \class Billing
    ///
    /// \brief The purpose of this class is to realistically model the billing for the TMS system.
    ///	
    ///		NAME: Billing
    ///		PURPOSE : The billing class has been created to bill the user
    ///
    /// Within the class definition 
    /// - int buyerID	- models the ID of a buyer.
    /// - int orderID   - models the ID of the order.
    /// - int customerID - models the ID of the customer.
    /// - int itemID    - models the ID of the item.
    /// - bool Payment  - holds a flag to verify the payment.
    /// 
    /// 
    /// \author  <i>Justin Langevin</i>
    ///
    public class Billing
    {
        int buyerID =1;
        int orderID = 1;
        int customerID = 1;
        bool payment;


        ///
        ///		\brief Called to check if the payment has gone through.
        ///		
        ///		\details <b>Details</b>
        ///     \param buyerID - <b>int</b> - Represents the buyersID.
        ///     \param orderID - <b>int</b> - Represents the orderID.
        ///     \param customerID - <b>int</b> - Represents the customerID.
        ///     
        ///		This Method verifies the payment.
        ///		
        ///     Fault exceptions: We are checking to see if the payment has been 
        ///     paid for this allows us to verify twice to certify the payment.        
        /// 
        ///		\return void.
        ///
        static public bool VerifyPayment(string CompanyID, string carrier1, string carrier2,string origin, string destination, bool payment)
        {
            string contractCarrierInfo;
            string travel;
            double time;
            string direction = "";
            if (payment == true)
            {
                if(carrier1 != carrier2)
                {
                    contractCarrierInfo = carrier1 + " & " + carrier2;
                }
                else
                {
                    if(carrier1 == "N/A")
                    {
                        contractCarrierInfo = carrier2;
                    }
                    else
                    {
                        contractCarrierInfo = carrier1;
                    }
                }
                travel = origin + " to " + destination;
                if(origin == "Kingston" && destination == "Toronto")
                {
                    direction = "W";
                }
                else if (origin == "Toronto" && destination == "Kingston")
                {
                    direction = "E";
                }
                else if (origin == "Ottawa" && destination == "Belleville")
                {
                    direction = "W";
                }
                else if (origin == "Belleville" && destination == "Ottawa")
                {
                    direction = "E";
                }
                else if(origin == "Belleville" && destination == "Windsor")
                {
                    direction = "W";
                }
                else if(origin =="Windsor" && destination == "Belleville")
                {
                    direction = "E";
                }
                else if(origin == "London" && destination == "Toronto")
                {
                    direction = "E";
                }
                else if(origin == "Toronto" && destination == "London")
                {
                    direction = "W";
                }
                else if(origin == "Windsor" && destination == "Hamilton")
                {
                    direction = "E";
                }
                else if(origin == "Hamilton" && destination =="Windsor")
                {
                    direction = "W";
                }


                time = Carrier.timeLeft();
                storeTrips(contractCarrierInfo, travel, time, direction);
                time = Carrier.SetTrip(origin, destination);
                string cs = @"server=localhost;userid=root;password=Shetland3321;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand insertNewTime = new MySqlCommand("UPDATE OD SET tTime=" + time + " ORDER BY travelID desc limit 1", con);
                insertNewTime.ExecuteNonQuery();
                con.Close();
                //return true
                return true;
            }
            return false;
        }

        public static void storeTrips(string contractCarrierInfo, string travel, double time, string direction)
        {
            try
            {
                string cs = @"server=localhost;userid=root;password=Shetland3321;database=TMSDatabase";
                //set up connection to the database
                MySqlConnection con = new MySqlConnection(cs);
                //open the connection
                con.Open();
                //set up the command string

                string insertContractQuery = "INSERT INTO OD VALUES(NULL, @travel, @carriers, @direction, @tTime);";
                //set up the command itself and get ready to execute
                MySqlCommand cmd = new MySqlCommand(insertContractQuery, con);

                //apply values to each parameter
                cmd.Parameters.AddWithValue("@travel", travel);
                cmd.Parameters.AddWithValue("@carriers", contractCarrierInfo);
                cmd.Parameters.AddWithValue("@direction", direction);
                cmd.Parameters.AddWithValue("@tTime", time);


                //prepare the command
                cmd.Prepare();
                //execute the query to insert the contract
                cmd.ExecuteNonQuery();
                //close the connection
                con.Close();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
