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

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


        public static bool adminConnect(string password)
        {
            string dbPassWord;
            adminAccept = false;
            try
            {
                string cs = @"server=localhost;userid=root;password=123sql;database=TMSDatabase";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM adminPass", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    dbPassWord = rdr.GetString(0);

                    if (adminPass == dbPassWord)
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

        private void adminTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            adminPass = adminP.Text;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            adminSignIn = adminConnect(adminPass);
            if (adminSignIn == false)
            {
                adminError.Foreground = Brushes.Red;
                adminError.Text = "Admin Pass not valid.";
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
