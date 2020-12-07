//login.xaml.cs
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
    /// Within the class definition 
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
        static public string userName;
        static private string Password;
        static public bool accepted = false;
        static public bool signInResult = false;

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
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            signInResult = Connect(userName,Password);
            if (signInResult == false)
            {
                errorMessage.Foreground = Brushes.Red; 
                errorMessage.Text = "Credentials are not valid.";
            }
            else
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
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            userName = userNameTxt.Text;
        }

        private void passWordTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password = passWordTxt.Text;
        }



        public static bool Connect(string userName,string password)
        {
            string dbUserName;
            string dbPassWord;
            accepted = false;
            try
            {
                string cs = @"server=localhost;userid=root;password=Shetland3321;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM accounts", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    dbUserName = rdr.GetString(1);
                    dbPassWord = rdr.GetString(2);

                    if(dbUserName == userName && dbPassWord == password)
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

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void adminTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

    }
}
