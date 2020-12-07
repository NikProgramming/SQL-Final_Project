using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace FinalProject
{

    /// 
    /// \class DeliveryTimes
    ///
    /// \brief The purpose of this class is to realistically model the Delievery times for the TMS system.
    ///	
    ///		NAME: DeliveryTimes
    ///		PURPOSE : The DeliveryTimes class has been created to 
    ///     RELATIONSHIPS: Main menu (called from), login (required to enter UI)
    /// Within the class definition 
    /// - N/A
    ///
    /// \author  <i>Justin Langevin</i>
    ///
    public partial class DeliveryTimes : Window
    {
        List<string> infoList = new List<string>();
        ///
        ///		\brief Started when Delivery date is clicked
        ///		\details <b>Details</b>
        ///     
        ///		This Method initializes the DeliveryTimes area and displays all the buttons and designs
        /// 
        ///		\return N/A.
        ///
        public DeliveryTimes()
        {
            InitializeComponent();
            getTravelTimes();
            for(int i =0; i < infoList.Count; i++)
            {
                time.Text += infoList[i];
            }
        }


        ///
        ///		\brief Called to create the back button for the DeliveryTimes.
        ///		\details <b>Details</b>
        ///		\param sender - <b>object</b> - Represents the object that is calling the method.
        ///     \param e - <b>RoutedEventArgs</b> - Represents the item thats being sent in.
        ///
        ///		This Method returns the user to the main window.
        /// 
        ///		\return N/A.
        ///
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void time_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }


        public void getTravelTimes()
        {
            //set up the connection string
            int travelID;
            string travel;
            string carriers;
            string direction;
            double time;
            double cost;
            string info = "";

            string cs = @"server=localhost;userid=root;password=Shetland3321;database=TMSDatabase";
            try
            {
                //create mysqlconnection and connect to the string connection
                MySqlConnection con = new MySqlConnection(cs);
                //open the connection to the marketplace
                con.Open();

                //prepare to execute the command to grab everything form the marketplace
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM OD", con);

                //execute the command while putting everything into the reader
                MySqlDataReader rdr = cmd.ExecuteReader();

                //while still getting the contracts
                while (rdr.Read())
                {
                    //get the customer name
                     travelID = rdr.GetInt32(0);
                    //get the job type
                    travel = rdr.GetString(1);
                    //get the quantity of the item they want shipped
                    carriers = rdr.GetString(2);
                    //get the origin city
                    direction = rdr.GetString(3);
                    //get the destination city
                    time = rdr.GetDouble(4);
                    cost = rdr.GetDouble(5);
                    //set the van type to be use
                    //store the contract in our database
                    //plan.SelectCarrier(destination);
                    info = travelID + " " + travel + " " + carriers + " " + direction + " " + time + " " + cost +"\n";
                    infoList.Add(info);
                }
                //close the reader
                rdr.Close();
                //close the connection
                con.Close();
            }
            catch (MySqlException e)
            {
                throw e;
            }

        }
    }
}
