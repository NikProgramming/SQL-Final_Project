﻿/*
* FILE : AdminWorkscreen.xaml.cs
* PROJECT : PROG2020 - Client-Side Programming
* PROGRAMMER : Justin Langevin & Josiah Rehkopf & Troy Hill & Nikola Ristic
* FIRST VERSION : 12/1/2020
* DESCRIPTION : This file is used to run the admin logic.
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
    /// <summary>
    /// Interaction logic for AdminWorkscreen.xaml
    /// </summary>
    public partial class AdminWorkscreen : Window
    {
        //declare variables
        public static List<string> userCon = new List<string>();
        public static List<string> DeliveriesCon = new List<string>();
        public static List<string> addAdminCon = new List<string>();
        public static bool run = false;
        public static int toDelete;
        public static string selectedItem;
        public AdminWorkscreen()
        {
            InitializeComponent();
            
            if(run == false)
            {
                Contract.connectMarketplace();
                adminPass();
                getTravelTimes();
                getUsers();
            }
            else
            {
                updateScreen();
            }
            
            run = true;
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   updateScreen()
        * Description	:   This is the method for updating lists           		
        * Parameters    :	object sender
        *               :   RoutedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public static void updateScreen()
        {
            //Contract.connectMarketplace();
            adminPass();
            getTravelTimes();
            getUsers();
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click()
        * Description	:   This is the back button for the class            		
        * Parameters    :	object sender
        *               :   RoutedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            userCon.Clear();
            Contract.contractList.Clear();
            DeliveriesCon.Clear();
            addAdminCon.Clear();
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   ComboBox_SelectionChanged()
        * Description	:   This is called when an item is selected from a list           		
        * Parameters    :	object sender
        *               :   SelectionChangedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = "";
            
            selected = ListOptions.SelectedItem.ToString();
            string[] result = selected.Split(' ');
            
            if (result[1] == "Users")
            {                
                ContractDisplay.ItemsSource = userCon;
            }
            else if (result[1] == "Deliveries")
            {
                ContractDisplay.ItemsSource = DeliveriesCon;
            }
            else if (result[1] == "Add_Admin_Passwords")
            {
                ContractDisplay.ItemsSource = addAdminCon;
            }
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   ContractDisplay_SelectionChanged()
        * Description	:   This is the button for when the contractDisplay is changed           		
        * Parameters    :	object sender
        *               :   SelectionChangedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void ContractDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click()
        * Description	:   This is the button for the class            		
        * Parameters    :	object sender
        *               :   RoutedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   adminPass()
        * Description	:   This is the method to get admin passwords           		
        * Parameters    :	none
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public static void adminPass()
        {
            string adPassword;
            string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
            try
            {
                //create mysqlconnection and connect to the string connection
                MySqlConnection con = new MySqlConnection(cs);
                //open the connection to the marketplace
                con.Open();

                //prepare to execute the command to grab everything form the marketplace
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM adminPass", con);

                //execute the command while putting everything into the reader
                MySqlDataReader rdr = cmd.ExecuteReader();

                //while still getting the contracts
                while (rdr.Read())
                {
                    //get the customer name
                    adPassword = rdr.GetString(0);
                    //get the job type
                    addAdminCon.Add(adPassword);
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

        /* -------------------------------------------------------------------------------------------
        * Method	    :   getTravelTimes()
        * Description	:   This is the method to get travel information         		
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
            double price;
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
                    price = rdr.GetDouble(5);
                    //set the van type to be use
                    //store the contract in our database
                    //plan.SelectCarrier(destination);
                    info = travelID + "," + travel + "," + carriers + "," + direction + "," + time + "," + price + "\n";
                    DeliveriesCon.Add(info);
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

        /* -------------------------------------------------------------------------------------------
        * Method	    :   getUsers()
        * Description	:   This is the method to get user information         		
        * Parameters    :	none
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public static void getUsers()
        {
            int userID;
            string dbUserName;
            string dbPassWord;
            string user;

            try
            {
                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM accounts", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    userID = rdr.GetInt32(0);
                    dbUserName = rdr.GetString(1);
                    dbPassWord = rdr.GetString(2);
                    user = userID + " " +dbUserName + " " + dbPassWord;
                    userCon.Add(user);
                }
                rdr.Close();
                //close the connection
                con.Close();
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   deleteDeleviry()
        * Description	:   This is the method to delete delivery information        		
        * Parameters    :	none
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public static void deleteDeleviry()
        {

            string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
            try
            {
                //create mysqlconnection and connect to the string connection
                MySqlConnection con = new MySqlConnection(cs);
                //open the connection to the marketplace
                con.Open();
                string DeleteQuery = "DELETE FROM OD WHERE travelID = " +toDelete;
                //prepare to execute the command to grab everything form the marketplace
                MySqlCommand cmd = new MySqlCommand(DeleteQuery, con);

                //prepare the command
                cmd.Prepare();
                //execute the query to insert the contract
                cmd.ExecuteNonQuery();
                //close the connection
                con.Close();
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   deleteUser()
        * Description	:   This is the method to delete user information        		
        * Parameters    :	none
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public static void deleteUser()
        {
            //set up the connection string

            string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
            try
            {
                //create mysqlconnection and connect to the string connection
                MySqlConnection con = new MySqlConnection(cs);
                //open the connection to the marketplace
                con.Open();
                string DeleteQuery = "DELETE FROM accounts WHERE acountID = " + toDelete;
                //prepare to execute the command to grab everything form the marketplace
                MySqlCommand cmd = new MySqlCommand(DeleteQuery, con);

                //prepare the command
                cmd.Prepare();
                //execute the query to insert the contract
                cmd.ExecuteNonQuery();
                //close the connection
                con.Close();
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   deleteAdmin()
        * Description	:   This is the method to delete admin passwords       		
        * Parameters    :	none
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public static void deleteAdmin(string pass)
        {
            //set up the connection string

            string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
            try
            {
                //create mysqlconnection and connect to the string connection
                MySqlConnection con = new MySqlConnection(cs);
                //open the connection to the marketplace
                con.Open();
                string DeleteQuery = "DELETE FROM adminPass WHERE password=";
                //prepare to execute the command to grab everything form the marketplace
                MySqlCommand cmd = new MySqlCommand(DeleteQuery, con);

                //prepare the command
                cmd.Prepare();
                //execute the query to insert the contract
                cmd.ExecuteNonQuery();
                //close the connection
                con.Close();
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click2()
        * Description	:   This is the button for the class which is used to determine what needs
        *               :   to be deleted
        * Parameters    :	object sender
        *               :   RoutedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click2(object sender, RoutedEventArgs e)
        {

            string selected = "";

            //grab the selected option
            selected = ListOptions.SelectedItem.ToString();
            string[] result = selected.Split(' ');
            
            //if the user is removing a user
            if (result[1] == "Users")
            {
                //grab the selected user
                selectedItem = (string)ContractDisplay.SelectedItem;
                string[] userID = selectedItem.Split(' ');
                //set user to delete
                toDelete = int.Parse(userID[0]);
                //delete the user from the local database
                deleteUser();
                //remove user from list
                userCon.RemoveAt(toDelete - 1);
                ContractDisplay.ItemsSource = null; 
                ContractDisplay.ItemsSource = userCon;
                //truncate table
                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase"; 
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand resetIndex = new MySqlCommand("TRUNCATE TABLE accounts", con);
                resetIndex.ExecuteNonQuery();

                MySqlCommand reEnterData;
                foreach (string appUser in userCon)
                {
                    //split user
                    string[] username = appUser.Split(' ');
                    //insert existing user into table
                    reEnterData = new MySqlCommand("INSERT INTO accounts VALUES(NULL, @name, @pass);", con);
                    reEnterData.Parameters.AddWithValue("@name", username[1]);
                    reEnterData.Parameters.AddWithValue("@pass", username[2]);
                    reEnterData.Prepare();
                    reEnterData.ExecuteNonQuery();
                }   
                //close connection
                con.Close();
                //update screen
                updateScreen();

            }
            else if (result[1] == "Deliveries") //if user is removing a delivery
            {
                //grab selected delivery
                selectedItem = (string)ContractDisplay.SelectedItem;
                string[] deliveryNumber = selectedItem.Split(',');
                //select delivery to delete
                toDelete = int.Parse(deliveryNumber[0]);
                //delete delivery from local database
                deleteDeleviry();
                //remove delivery from list
                DeliveriesCon.RemoveAt(toDelete - 1);
                ContractDisplay.ItemsSource = null;
                ContractDisplay.ItemsSource = DeliveriesCon;
                //truncate table
                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand resetIndex = new MySqlCommand("TRUNCATE TABLE OD", con);
                resetIndex.ExecuteNonQuery();

                MySqlCommand reEnterData;
                foreach(string appDelivery in DeliveriesCon)
                {
                    //split delivery
                    string[] delivery = appDelivery.Split(',');
                    //insert existing delivery into table
                    reEnterData = new MySqlCommand("INSERT INTO OD VALUES(NULL, @travel, @carrier, @direction, @tTime, @price)", con);
                    reEnterData.Parameters.AddWithValue("@travel", delivery[1]);
                    reEnterData.Parameters.AddWithValue("@carrier", delivery[2]);
                    reEnterData.Parameters.AddWithValue("@direction", delivery[3]);
                    reEnterData.Parameters.AddWithValue("@tTime", double.Parse(delivery[4]));
                    reEnterData.Parameters.AddWithValue("@price", double.Parse(delivery[5]));
                    reEnterData.Prepare();
                    reEnterData.ExecuteNonQuery();
                }
                //close connection
                con.Close();
                //update screen
                updateScreen();
            }
            else if (result[1] == "Add_Admin_Passwords") //if the user is removing an admin password
            {
                //grab admin password
                selectedItem = (string)ContractDisplay.SelectedItem;
                string[] deliveryNumber = selectedItem.Split(' ');
                //select password to delete 
                toDelete = int.Parse(deliveryNumber[0]);
                //remove admin password from local database
                deleteAdmin(selectedItem);
                //remove admin password from list
                DeliveriesCon.RemoveAt(toDelete - 1);
                ContractDisplay.ItemsSource = null;
                ContractDisplay.ItemsSource = DeliveriesCon;
                updateScreen();
            }

           
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click3()
        * Description	:   This is the button for the class to edit            		
        * Parameters    :	object sender
        *               :   RoutedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click3(object sender, RoutedEventArgs e)
        {

        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click4()
        * Description	:   This is the button for the class to delete       		
        * Parameters    :	object sender
        *               :   RoutedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click4(object sender, RoutedEventArgs e)
        {

        }
    }
}
