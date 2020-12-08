/*
* FILE : DeliveryTimes.xaml.cs
* PROJECT : PROG2020 - Client-Side Programming
* PROGRAMMER : Justin Langevin & Josiah Rehkopf & Troy Hill & Nikola Ristic
* FIRST VERSION : 12/1/2020
* DESCRIPTION : This file is used for the Delivery time display logic.
*/
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
        public static List<string> infoList = new List<string>();
        ///
        ///		\brief Started when Delivery date is clicked
        ///		\details <b>Details</b>
        ///     
        ///		This Method initializes the DeliveryTimes area and displays all the buttons and designs
        /// 
        ///		\return N/A.
        ///

        /* -------------------------------------------------------------------------------------------
        * Method	    :   DeliveryTimes()
        * Description	:   This is the construct for the DeliveryTimes class            		
        * Parameters    :	none  
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public DeliveryTimes()
        {
            InitializeComponent();
            getTravelTimes();//gets the travel times
            for(int i =0; i < infoList.Count; i++)//for loop to display the times
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

        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click()
        * Description	:   This is the method for the Button_Click           		
        * Parameters    :	object sender, RoutedEventArgs e  
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            infoList.Clear();
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   time_TextChanged()
        * Description	:   This is the Method for the text class            		
        * Parameters    :	object sender, RoutedEventArgs e 
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void time_TextChanged(object sender, TextChangedEventArgs e)
        {           
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   getTravelTimes()
        * Description	:   This is the method for the getTravelTimes it gets the travel time from the TMSdatabase.            		
        * Parameters    :	none  
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public static void getTravelTimes()
        {
            //set up the connection string
            int travelID;
            string travel;
            string carriers;
            string direction;
            double time;
            double cost;
            string info = "";

            string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
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
