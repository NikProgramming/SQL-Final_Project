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
           // Contract.connectMarketplace();
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
            DeliveriesCon.Clear();
            purchaseCon.Clear();
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

            selected = ListOptions.SelectedItem.ToString();
            string[] result = selected.Split(' ');

            if (result[1] == "Purchased_Contracts")
            {

               
            }
            else if (result[1] == "Users")
            {
                selectedItem = (string)ContractDisplay.SelectedItem;
                string[] userID = selectedItem.Split(' ');
                toDelete = int.Parse(userID[0]);
                deleteUser();
                userCon.RemoveAt(toDelete - 1);
                ContractDisplay.ItemsSource = null; 
                ContractDisplay.ItemsSource = userCon;
                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase"; 
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand resetIndex = new MySqlCommand("ALTER TABLE accounts AUTO_INCREMENT = 1", con);
                resetIndex.ExecuteNonQuery();
                con.Close();
                updateScreen();

            }
            else if (result[1] == "Deliveries")
            {
                selectedItem = (string)ContractDisplay.SelectedItem;
                string[] deliveryNumber = selectedItem.Split(' ');
                toDelete = int.Parse(deliveryNumber[0]);
                deleteDeleviry();
                DeliveriesCon.RemoveAt(toDelete - 1);
                ContractDisplay.ItemsSource = null;
                ContractDisplay.ItemsSource = DeliveriesCon;
                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand resetIndex = new MySqlCommand("ALTER TABLE accounts AUTO_INCREMENT = 1", con);
                resetIndex.ExecuteNonQuery();
                con.Close();
                updateScreen();
            }
            else if (result[1] == "Add_Admin_Passwords")
            {
               
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
