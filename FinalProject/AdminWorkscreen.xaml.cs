﻿using System;
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
        public static List<string> purchaseCon = new List<string>();
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
            
            run = true;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = "";
            
            selected = ListOptions.SelectedItem.ToString();
            string[] result = selected.Split(' ');
            
            if (result[1] == "Purchased_Contracts")
            {

                ContractDisplay.ItemsSource = purchaseCon;
            }
            else if (result[1] == "Users")
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
        
    

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ContractDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        public static void adminPass()
        {
            string adPassword;
            string cs = @"server=localhost;userid=root;password=Shetland3321;database=TMSDatabase";
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

        public void getTravelTimes()
        {
            //set up the connection string
            int travelID;
            string travel;
            string carriers;
            string direction;
            double time;
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
                    //set the van type to be use
                    //store the contract in our database
                    //plan.SelectCarrier(destination);
                    info = travelID + " " + travel + " " + carriers + " " + direction + " " + time + "\n";
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

        public void getUsers()
        {
            string dbUserName;
            string dbPassWord;
            string user;

            try
            {
                string cs = @"server=localhost;userid=root;password=Shetland3321;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM accounts", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    dbUserName = rdr.GetString(0);
                    dbPassWord = rdr.GetString(1);
                    user = dbUserName + " " + dbPassWord;
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

        public void deleteDeleviry()
        {
            //set up the connection string
            int travelID;
            string travel;
            string carriers;
            string direction;
            double time;
            string info = "";

            string cs = @"server=localhost;userid=root;password=Shetland3321;database=TMSDatabase";
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


        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            selectedItem = (string)ContractDisplay.SelectedItem;
            string[] result = selectedItem.Split(' ');
            toDelete = int.Parse(result[0]);
            deleteDeleviry();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {

        }
    }
}
