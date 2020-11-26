using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FinalProject
{
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
        /// 
        ///		\return Returns a success value.
        ///
        static public int connectMarketplace()
        {
            string cs = @"server=159.89.117.198;userid=DevOSHT;password=Snodgr4ss!;database=cmp";
            int success = 0;
            try
            {
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();


                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Contract", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customerName = rdr.GetString(0);
                    jobType = rdr.GetInt32(1);
                    quantity = rdr.GetInt32(2);
                    origin = rdr.GetString(3);
                    destination = rdr.GetString(4);
                    vanType = rdr.GetInt32(5);
                    storeContractLocal();
                }
                rdr.Close();
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
        ///		\brief Called to create the receiptLog for the billing.
        ///		\details <b>Details</b>
        ///
        ///		This Method returns nothing
        /// 
        ///		\return Returns nothing.
        ///
        static void storeContractLocal()
        {
            string cs = @"server=localhost;userid=root;password=123sql;database=TMS Database";

            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            //string insertContractQuery = "INSERT INTO contract VALUES(" + customerName + "," + jobType.ToString() + "," + quantity.ToString() + "," + origin + "," + destination + "," + vanType + ");";
            string insertContractQuery = "INSERT INTO contract VALUES(@name, @job, @quantity, @origin, @destination, @van);";
            MySqlCommand cmd = new MySqlCommand(insertContractQuery, con);

            cmd.Parameters.AddWithValue("@name", customerName);
            cmd.Parameters.AddWithValue("@job", jobType.ToString());
            cmd.Parameters.AddWithValue("@quantity", quantity.ToString());
            cmd.Parameters.AddWithValue("@origin", origin);
            cmd.Parameters.AddWithValue("@destination", destination);
            cmd.Parameters.AddWithValue("@van", vanType.ToString());
            cmd.Prepare();

            cmd.ExecuteNonQuery();

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
