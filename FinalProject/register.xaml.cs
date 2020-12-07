//register.xaml.cs

/*
* FILE : register.xaml.cs
* PROJECT : PROG2020 - Client-Side Programming
* PROGRAMMER : Justin Langevin & Josiah Rehkopf & Troy Hill & Nikola Ristic
* FIRST VERSION : 12/1/2020
* DESCRIPTION : This file is used to run the register logic.
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
    /// \class register
    ///
    /// \brief The purpose of this class is to realistically model the register for the TMS system.
    ///	
    ///		NAME: register
    ///		PURPOSE : This class is created for registering into the program which allows 
    ///               the creation of a new user
    ///     RELATIONSHIPS: Main menu (called from)
    /// Within the class definition 
    /// - N/A
    ///
    /// \author  <i>Nikola Ristic</i>
    ///
    public partial class register : Window
    {
        static public string userN;
        static public string password;
        static public string adminID;
        static public bool adminbool = false;
        ///
        ///		\brief Used to initialize the register.
        ///		\details <b>Details</b>
        ///     
        ///		This Method initializes the register area and displays all the buttons and designs
        /// 
        ///		\return N/A.
        ///
        public register()
        {
            InitializeComponent();
        }

        ///
        ///		\brief Called to create the back button for the register.
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


        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_CLick2()
        * Description	:   This Method is used for the continue button              		
        * Parameters    :	object sender, RoutedEventArgs e.         
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if(userN != " " && password != " ")//if the password and username inputs are not empty
            {
                DialogResult = storeAccounts(userN, password);

            }
            else
            {
                DialogResult = false;
            }
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   passWord_TextChanged()
        * Description	:   This Method is used for getting the password             		
        * Parameters    :	object sender, RoutedEventArgs e.         
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void passWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = passWord.Text;
            password.Trim();//gets rid of white space.
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   userName_TextChanged()
        * Description	:   This Method is used for getting the userName            		
        * Parameters    :	object sender, RoutedEventArgs e.         
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void userName_TextChanged(object sender, TextChangedEventArgs e)
        {
            userN = userName.Text;
            userN.Trim();//gets rid of white space
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   storeAccounts()
        * Description	:   This Method is used for storing the accounts being registers         		
        * Parameters    :	string userName, string password.      
        * Returns		:   returns a true flag
        * ------------------------------------------------------------------------------------------*/
        public static bool storeAccounts(string userName, string password)
        {
            string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
            //set up connection to the database
            MySqlConnection con = new MySqlConnection(cs);
            //open the connection
            con.Open();
            //set up the command string

            string insertContractQuery = "INSERT INTO accounts VALUES(NULL,@UserName,@Password);";
            //set up the command itself and get ready to execute
            MySqlCommand cmd = new MySqlCommand(insertContractQuery, con);

            //apply values to each parameter
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@Password", password);
      

            //prepare the command
            cmd.Prepare();
            //execute the query to insert the contract
            cmd.ExecuteNonQuery();
            //close the connection
            con.Close();
            return true;
        }

    }
}
