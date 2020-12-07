/*
* FILE : adminLogin.xaml.cs
* PROJECT : PROG2020 - Client-Side Programming
* PROGRAMMER : Justin Langevin & Josia h Rehkopf & Troy Hill & Nikola Ristic
* FIRST VERSION : 12/1/2020
* DESCRIPTION : This file is used to run the admin login logic.
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
    /// Interaction logic for adminLogin.xaml
    /// </summary>
    public partial class adminLogin : Window
    {
        static public bool adminSignIn = false;
        static public string adminPass;
        static public bool adminAccept = false;
        public adminLogin()
        {
            InitializeComponent();
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click1()
        * Description	:   This is the Button click for back           		
        * Parameters    :	object sender, RoutedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   adminConnect()
        * Description	:   This is the function that allows for the admin to be connect          		
        * Parameters    :	object sender, RoutedEventArgs e
        * Returns		:   true or false
        * ------------------------------------------------------------------------------------------*/
        public static bool adminConnect(string password)
        {
            string dbPassWord;
            adminAccept = false;
            try
            {
                //connection string
                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                //mysql statement
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM adminPass", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                //reads the entire table
                while (rdr.Read())
                {
                    dbPassWord = rdr.GetString(0);

                    if (adminPass == dbPassWord) //checks if the adminPass is in the database.
                    {
                        adminAccept = true;
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
            return adminAccept;
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   adminTxt_TextChanged()
        * Description	:   This is the method grabs the admin password.         		
        * Parameters    :	object sender, RoutedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void adminTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            adminPass = adminP.Text;
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click2()
        * Description	:   This is the method checks if the admin pass is in the db.       		
        * Parameters    :	object sender, RoutedEventArgs e
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            adminSignIn = adminConnect(adminPass);
            if (adminSignIn == false)//if the pass is not found
            {
                adminError.Foreground = Brushes.Red;
                adminError.Text = "Admin Pass not valid.";
            }
            else//if the pass is found
            {
                DialogResult = true;
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
