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
        static double cost = 1.0;

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
        static public bool VerifyPayment(string CompanyID, string carrier1, string carrier2, string origin, string destination, bool payment, int loadValue, int vanType)
        {
            string contractCarrierInfo;
            string travel;
            string load = "";
            string truck_type = "";
            double time;
            string direction = "";

            double ftlRate = 0.0;
            double ltlRate = 0.0;
            double reeferRate = 0.0;


            if (payment == true)
            {
                if (loadValue == 1)
                {
                    load = "LTL";
                }
                else if (loadValue == 0)
                {
                    load = "FTL";
                }

                if (vanType == 0)
                {
                    truck_type = "Dry Van";
                }
                else if (vanType == 1)
                {
                    truck_type = "Reefer";
                }

                if (carrier1 != carrier2)
                {
                    contractCarrierInfo = carrier1 + " & " + carrier2;
                }
                else
                {
                    if (carrier1 == "N/A")
                    {
                        contractCarrierInfo = carrier2;
                    }
                    else
                    {
                        contractCarrierInfo = carrier1;
                    }
                }
                travel = origin + " to " + destination;
                if (origin == "Kingston" && destination == "Toronto")
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
                else if (origin == "Belleville" && destination == "Windsor")
                {
                    direction = "W";
                }
                else if (origin == "Windsor" && destination == "Belleville")
                {
                    direction = "E";
                }
                else if (origin == "London" && destination == "Toronto")
                {
                    direction = "E";
                }
                else if (origin == "Toronto" && destination == "London")
                {
                    direction = "W";
                }
                else if (origin == "Windsor" && destination == "Hamilton")
                {
                    direction = "E";
                }
                else if (origin == "Hamilton" && destination == "Windsor")
                {
                    direction = "W";
                }

                time = Carrier.timeLeft();
                storeTrips(contractCarrierInfo, travel, time, direction);
                time = Carrier.SetTrip(origin, destination, load);

                cost = 1.0;
                for (double dayTracker = time; dayTracker >= 0; dayTracker -= 12)
                {
                    if (dayTracker > 12)
                    {
                        time += 12;
                        cost += 150;
                    }
                }

                if (carrier1 == "Planet Express" || carrier2 == "Planet Express")
                {
                    ltlRate = 0.3621;
                    ftlRate = 5.21;
                    reeferRate = 0.08;
                }
                else if (carrier1 == "Schooner's" || carrier2 == "Schooner's")
                {
                    ltlRate = 0.3434;
                    ftlRate = 5.05;
                    reeferRate = 0.07;
                }
                else if (carrier1 == "Tillman Transport" || carrier2 == "Tillman Transport")
                {
                    ltlRate = 0.3012;
                    ftlRate = 5.11;
                    reeferRate = 0.09;
                }
                else if (carrier1 == "We Haul" || carrier2 == "We Haul")
                {
                    ltlRate = 0.0;
                    ftlRate = 5.2;
                    reeferRate = 0.065;
                }

                ltlRate += ltlRate * 0.05;
                ftlRate += ftlRate * 0.08;
                if (load == "LTL")
                {
                    for (int quantity = Contract.quantityReturn(); quantity >= 0; quantity--)
                    {
                        for (int km = Carrier.distance(); km >= 0; km--)
                        {
                            cost += (cost * (ltlRate * Carrier.distance()));
                            if (truck_type == "Reefer")
                            {
                                cost += cost * reeferRate;
                            }
                        }
                    }
                }
                else if (load == "FTL")
                {
                    cost += (cost * (ftlRate*Carrier.distance()));
                    if (truck_type == "Reefer")
                    {
                        cost += cost * reeferRate;
                    }
                }

                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand insertNewTime = new MySqlCommand("UPDATE OD SET tTime=" + time + " ORDER BY travelID desc limit 1", con);
                insertNewTime.ExecuteNonQuery();
                MySqlCommand insertCost = new MySqlCommand("UPDATE OD SET cost=" + cost + " ORDER BY travelID desc limit 1", con);
                insertCost.ExecuteNonQuery();
                con.Close();

                //return true
                return true;
            }
            return false;
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   storeTrips()
        * Description	:   This is the method to store all the trips in the tms database.          		
        * Parameters    :	string contractCarrierInfo  
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public static void storeTrips(string contractCarrierInfo, string travel, double time, string direction)
        {
            try
            {
                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
                //set up connection to the database
                MySqlConnection con = new MySqlConnection(cs);
                //open the connection
                con.Open();
                //set up the command string

                string insertContractQuery = "INSERT INTO OD VALUES(NULL, @travel, @carriers, @direction, @tTime, NULL);";
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
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
