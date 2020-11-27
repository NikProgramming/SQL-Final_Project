using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FinalProject
{
    /// 
    /// \class Contract
    ///
    /// \brief The purpose of this class is to realistically model the Contract service for the TMS system.
    ///	
    ///		NAME: Contract
    ///		PURPOSE : The Service class has been created model the Contract system of the TMS solution.
    ///
    /// Within the class definition 
    /// - Static public string customerName: 
    /// - static public int jobType:
    /// - static public int quantity:
    /// - static public string origin:
    /// - static public string destination:
    /// - static public int vanType:
    /// 
    /// \author  <i>Troy Hill</i>
    ///
    public class Contract
    {
        //string incomingOrderID;
        //string incomingCustomerID;
        int orderID;
        int customerID;
        
        //string customerGender;
        //string dateOfBirth;

        static public string customerName;
        static public int jobType;
        static public int quantity;
        static public string origin;
        static public string destination;
        static public int vanType;

        ///
        ///		\brief Called to connect the program to the external contract marketplace
        ///		\details <b>Details</b>
        ///
        ///		This Method returns if the connection succeeded.
        ///		This Method returns if the connection succeeded.
        /// 
        ///		\return Returns a success value.
        ///
        static public int connectMarketplace()
        {
            //set up the connection string
            string cs = @"server=159.89.117.198;userid=DevOSHT;password=Snodgr4ss!;database=cmp";
            int success = 0;
            try
            {
                //create mysqlconnection and connect to the string connection
                MySqlConnection con = new MySqlConnection(cs);
                //open the connection to the marketplace
                con.Open();

                //prepare to execute the command to grab everything form the marketplace
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Contract", con);

                //execute the command while putting everything into the reader
                MySqlDataReader rdr = cmd.ExecuteReader();

                //while still getting the contracts
                while (rdr.Read())
                {
                    //get the customer name
                    customerName = rdr.GetString(0);
                    //get the job type
                    jobType = rdr.GetInt32(1);
                    //get the quantity of the item they want shipped
                    quantity = rdr.GetInt32(2);
                    //get the origin city
                    origin = rdr.GetString(3);
                    //get the destination city
                    destination = rdr.GetString(4);
                    //set the van type to be used
                    vanType = rdr.GetInt32(5);
                    //store the contract in our database
                    storeContractLocal();
                }
                //close the reader
                rdr.Close();
                //close the connection
                con.Close();
                success = 1;
            }
            catch(MySqlException e)
            {
                throw e;
            }
            return success;
        }

        ///
        ///		\brief Called to store the contracts in the local database
        ///		\details <b>Details</b>
        ///
        ///		This method stores each contract pulled in from the marketplace from the 
        ///		connectMarketplace() function and stores them in our own database
        /// 
        ///		\return Returns nothing.
        ///
        static void storeContractLocal()
        {
            //set up connection string for the local database
            string cs = @"server=localhost;userid=root;password=123sql;database=TMS Database";
            //set up connection to the database
            MySqlConnection con = new MySqlConnection(cs);
            //open the connection
            con.Open();
            //set up the command string
            string insertContractQuery = "INSERT INTO contract VALUES(@name, @job, @quantity, @origin, @destination, @van);";
            //set up the command itself and get ready to execute
            MySqlCommand cmd = new MySqlCommand(insertContractQuery, con);

            //apply values to each parameter
            cmd.Parameters.AddWithValue("@name", customerName);
            cmd.Parameters.AddWithValue("@job", jobType.ToString());
            cmd.Parameters.AddWithValue("@quantity", quantity.ToString());
            cmd.Parameters.AddWithValue("@origin", origin);
            cmd.Parameters.AddWithValue("@destination", destination);
            cmd.Parameters.AddWithValue("@van", vanType.ToString());
            //prepare the command
            cmd.Prepare();
            //execute the query to insert the contract
            cmd.ExecuteNonQuery();
            //close the connection
            con.Close();
        }

        void infoValidation()
        {
            /*
            if (int.TryParse(incomingOrderID, out orderID) == true)
            {

            }

            if (int.TryParse(incomingCustomerID, out customerID) == true)
            {

            }
            */
        }
    }
}
