//register.xaml.cs
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
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if(userN != " " && password != " ")
            {
                storeAccounts(userN, password);
            }
            else if(userN != " " && password !="" && adminID =="admin123")
            {
                Connect(userN,password, adminID);
            }

        }

        private void passWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = passWord.Text;
            password.Trim();
        }

        private void userName_TextChanged(object sender, TextChangedEventArgs e)
        {
            userN = userName.Text;
            userN.Trim();
        }


        public static void storeAccounts(string userName, string password)
        {
            string cs = @"server=localhost;userid=root;password=Shetland3321;database=TMSDatabase";
            //set up connection to the database
            MySqlConnection con = new MySqlConnection(cs);
            //open the connection
            con.Open();
            //set up the command string

            string insertContractQuery = "INSERT INTO accounts VALUES(@UserName,@Password);";
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
        }

        private void adminPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            adminID = adminUser.Text;
            adminID.Trim();
        }



        public static void Connect(string userName, string password, string adminID)
        {
            string dbUserName;
            string dbPassWord;
            string adminPass;
            try
            {
                string cs = @"server=localhost;userid=root;password=Shetland3321;database=`TMS Database`";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM admins", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    dbUserName = rdr.GetString(0);
                    dbPassWord = rdr.GetString(1);
                    adminPass = rdr.GetString(2);

                    if (dbUserName == userName && dbPassWord == password && adminPass == adminID)
                    {
                        adminbool = true;
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
        }
    }
}
