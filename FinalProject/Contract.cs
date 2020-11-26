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
        string incomingOrderID;
        string incomingCustomerID;
        int orderID;
        int customerID;
        
        string customerGender;
        string dateOfBirth;

        public string customerName;
        public int jobType;
        public int quantity;
        public string origin;
        public string destination;
        public int vanType;

        public void connectMarketplace()
        {
            string cs = @"server=159.89.117.198;userid=DevOSHT;password=Snodgr4ss!;database=cmp";

            MySqlConnection con = new MySqlConnection(cs);
            con.Open();


            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Contract", con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
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
        }

        void storeContractLocal()
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
            if (int.TryParse(incomingOrderID, out orderID) == true)
            {

            }

            if (int.TryParse(incomingCustomerID, out customerID) == true)
            {

            }
        }
    }
}
