//login.xaml.cs
/*
* FILE : login.xaml.cs
* PROJECT : PROG2020 - Client-Side Programming
* PROGRAMMER : Justin Langevin & Josiah Rehkopf & Troy Hill & Nikola Ristic
* FIRST VERSION : 12/1/2020
* DESCRIPTION : This file is used to run the login logic.
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
    /// \class login
    ///
    /// \brief The purpose of this class is to realistically model the login for the TMS system.
    ///	
    ///		NAME: Login
    ///		PURPOSE : This class is created for logining into the program which allows 
    ///               the user, if valid, to enter the marketplace and see the schedules
    ///     RELATIONSHIPS: Main menu(called from), MarketPlace (login required to enter UI), Delivery Date (login required to enter UI) 
    ///     Within the class definition 
    /// - N/A
    ///
    /// \author  <i>Nikola Ristic</i>
    ///
    public partial class login : Window
    {
        ///
        ///		\brief Used to initialize the login.
        ///		\details <b>Details</b>
        ///     
        ///		This Method initializes the login area and displays all the buttons and designs
        /// 
        ///		\return N/A.
        ///
        static public string userName;//for the user name
        static private string Password;//for the password
        static public bool accepted = false;//flag if the account is found
        static public bool signInResult = false;//if the sign in was successful


        /* -------------------------------------------------------------------------------------------
        * Method	    :   login()
        * Description	:   This is the construct for the login class            		
        * Parameters    :	none  
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public login()
        {
            InitializeComponent();
        }

        ///
        ///		\brief Called to create the back button for the login.
        ///		\details <b>Details</b>
        ///		\param sender - <b>object</b> - Represents the object that is calling the method.
        ///     \param e - <b>RoutedEventArgs</b> - Represents the item thats being sent in.
        ///
        ///		This Method returns the user to the main window.
        /// 
        ///		\return N/A.
        ///

        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_CLick1()
        * Description	:   This Method is used for the back button              		
        * Parameters    :	object sender, RoutedEventArgs e.         
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        ///
        ///		\brief Called to create the login button for the login.
        ///		\details <b>Details</b>
        ///		\param sender - <b>object</b> - Represents the object that is calling the method.
        ///     \param e - <b>RoutedEventArgs</b> - Represents the item thats being sent in.
        ///
        ///		This Method returns the user to the main window, if the name and password are valid, if not
        ///		tell user to input a valid name and password.
        /// 
        ///		\return N/A.
        ///


        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_CLick2()
        * Description	:   This Method is used for the login button              		
        * Parameters    :	object sender, RoutedEventArgs e.         
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            signInResult = Connect(userName,Password);
            if (signInResult == false)//if the user name and pass dont exist
            {
                errorMessage.Foreground = Brushes.Red; 
                errorMessage.Text = "Credentials are not valid.";
            }
            else//if they do exist.
            {
                DialogResult = true;
            }
        }


        ///
        ///		\brief Called to create the login button for the login.
        ///		\details <b>Details</b>
        ///		\param sender - <b>object</b> - Represents the object that is calling the method.
        ///     \param e - <b>TextChangedEventArgs</b> - Represents the item thats being sent in.
        ///
        ///		This Method is for the textbox which determines if the text has been changed in the textbox
        /// 
        ///		\return N/A.
        ///
        /* -------------------------------------------------------------------------------------------
        * Method	    :   TextBox_TextChanged()
        * Description	:   This Method is used to get the userName.           		
        * Parameters    :	object sender, RoutedEventArgs e.         
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            userName = userNameTxt.Text;
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   passWordTxt_TextChanged()
        * Description	:   This Method is used to get the password.           		
        * Parameters    :	object sender, RoutedEventArgs e.         
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void passWordTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password = passWordTxt.Text;
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   Connect()
        * Description	:   This Method is to connect to the database and check to see if the account exist in the accounts table.            		
        * Parameters    :	object sender, RoutedEventArgs e.         
        * Returns		:   return a true status if found.
        * ------------------------------------------------------------------------------------------*/
        public static bool Connect(string userName,string password)
        {
            string dbUserName;
            string dbPassWord;
            accepted = false;
            try
            {
                //the connection string.
                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                //the msql statement.
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM accounts", con);

                //where the command gets executed.
                MySqlDataReader rdr = cmd.ExecuteReader();

                //reads the entire table checking for the user name and password.
                while (rdr.Read())
                {
                    dbUserName = rdr.GetString(1);//gets the username from the db
                    dbPassWord = rdr.GetString(2);//gets the password from the db

                    if(dbUserName == userName && dbPassWord == password)//checks to see if the userName and password matched.
                    {
                        accepted = true;
                        break;
                    }
                   
                    
                }
                rdr.Close();
                //close the connection
                con.Close();
            }
            catch (MySqlException e)
            {
                throw e;
            }
            return accepted;
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   TextBox_TextChanged_1()
        * Description	:   This Method is used for the text box           		
        * Parameters    :	object sender, TextChangedEventArgs e.         
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   TextBox_TextChanged_1()
        * Description	:   This Method is used for the text box          		
        * Parameters    :	object sender, TextChangedEventArgs e.         
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void adminTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

    }
}
