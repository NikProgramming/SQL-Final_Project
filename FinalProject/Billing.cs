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
            //declaring variables
            string contractCarrierInfo;
            string travel;
            string load = "";
            string truck_type = "";
            double time;
            string direction = "";

            //declaring rates
            double ftlRate = 0.0;
            double ltlRate = 0.0;
            double reeferRate = 0.0;

            //if the payment is accepted
            if (payment == true)
            {
                //if the load is low
                if (loadValue == 1)
                {
                    load = "LTL";
                }
                else if (loadValue == 0) //if the load is full
                {
                    load = "FTL";
                }

                //if a dry van is used
                if (vanType == 0)
                {
                    truck_type = "Dry Van";
                }
                else if (vanType == 1) //if the truck is a reefer
                {
                    truck_type = "Reefer";
                }

                //if the first carrier is not equal to the second carrier
                if (carrier1 != carrier2)
                {
                    contractCarrierInfo = carrier1 + " & " + carrier2;
                }
                else //if there is only one carrier
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

                //determine direction
                travel = origin + " to " + destination;

                //if between kingston and Toronto
                if (origin == "Kingston" && destination == "Toronto")
                {
                    direction = "W";
                }
                else if (origin == "Toronto" && destination == "Kingston") 
                {
                    direction = "E";
                }
                else if (origin == "Ottawa" && destination == "Belleville") //if between Ottawa and Belleville
                {
                    direction = "W";
                }
                else if (origin == "Belleville" && destination == "Ottawa")
                {
                    direction = "E";
                }
                else if (origin == "Belleville" && destination == "Windsor") //if between Belleville and Windsor
                {
                    direction = "W";
                }
                else if (origin == "Windsor" && destination == "Belleville") 
                {
                    direction = "E";
                }
                else if (origin == "London" && destination == "Toronto") //if between London and Toronto
                {
                    direction = "E";
                }
                else if (origin == "Toronto" && destination == "London")
                {
                    direction = "W";
                }
                else if (origin == "Windsor" && destination == "Hamilton") //if between Hamilton and Windsor
                {
                    direction = "E";
                }
                else if (origin == "Hamilton" && destination == "Windsor")
                {
                    direction = "W";
                }

                //calculate time left
                time = Carrier.timeLeft();
                //store trip info
                storeTrips(contractCarrierInfo, travel, time, direction);
                //set the trip up
                time = Carrier.SetTrip(origin, destination, load);

                //initialize cost
                cost = 1.0;
                //for each day that passes
                for (double dayTracker = time; dayTracker >= 0; dayTracker -= 12)
                {
                    //if the hours are over 12
                    if (dayTracker > 12)
                    {
                        //increase estimated time for delivery by 12
                        time += 12;
                        //increase cost by 150 dollars
                        cost += 150;
                    }
                }

                //if the carrier is Planet Express
                if (carrier1 == "Planet Express" || carrier2 == "Planet Express")
                {
                    //set their rates
                    ltlRate = 0.3621;
                    ftlRate = 5.21;
                    reeferRate = 0.08;
                }
                else if (carrier1 == "Schooner's" || carrier2 == "Schooner's") //if the carrier is Schooner's 
                {
                    //set their rates
                    ltlRate = 0.3434;
                    ftlRate = 5.05;
                    reeferRate = 0.07;
                }
                else if (carrier1 == "Tillman Transport" || carrier2 == "Tillman Transport") //if the carrier is Tillman Transport
                {
                    //set their rates
                    ltlRate = 0.3012;
                    ftlRate = 5.11;
                    reeferRate = 0.09;
                }
                else if (carrier1 == "We Haul" || carrier2 == "We Haul") //if the carrier is We Haul
                {
                    //set their rates
                    ltlRate = 0.0;
                    ftlRate = 5.2;
                    reeferRate = 0.065;
                }

                //increase rates by OSHT standards
                ltlRate += ltlRate * 0.05;
                ftlRate += ftlRate * 0.08;
                //if Low Truck Load
                if (load == "LTL")
                {
                    //for number of pallets
                    for (int quantity = Contract.quantityReturn(); quantity >= 0; quantity--)
                    { 
                        //calculate the cost
                        cost += (cost * (ltlRate * Carrier.distance()));
                        //if a reefer is used
                        if (truck_type == "Reefer")
                        {
                            //apply reefer rate
                            cost += cost * reeferRate;
                        }
                    }
                }
                else if (load == "FTL") //if Full Truck Load
                {
                    //calculate the cost
                    cost += (cost * (ftlRate*Carrier.distance()));
                    //if a reefer is used
                    if (truck_type == "Reefer")
                    {
                        //apply reefer rate
                        cost += cost * reeferRate;
                    }
                }

                //connect to local database
                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                //Update time
                MySqlCommand insertNewTime = new MySqlCommand("UPDATE OD SET tTime=" + time + " ORDER BY travelID desc limit 1", con);
                insertNewTime.ExecuteNonQuery();
                //set cost
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
