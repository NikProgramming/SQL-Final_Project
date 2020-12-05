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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FinalProject
{
    /// 
    /// \class MainWindow
    ///
    /// \brief The purpose of this class is to realistically model the Main window for the TMS system.
    ///	
    ///		NAME: MainWindow
    ///		PURPOSE : The MainWindow class has been created to display the main window of the program
    ///     RELATIONSHIPS: Login, register, Delivery Date, Marketplace
    /// Within the class definition 
    /// - N/A
    ///
    /// \author  <i>Nikola Ristic</i>
    ///
    public partial class MainWindow : Window
    {
        //is a user logged in?
        bool? userOn;
        bool? purchaseAccepted;
        ///
        ///		\brief Started when MainWindow is clicked
        ///		\details <b>Details</b>
        ///     
        ///		This Method initializes the MainWindow area and displays all the buttons and designs
        /// 
        ///		\return N/A.
        ///
        public MainWindow()
        {
            userOn = false;
            InitializeComponent();
        }

        ///
        ///		\brief Called to create the button for the MarketPlace.
        ///		\details <b>Details</b>
        ///		\param sender - <b>object</b> - Represents the object that is calling the method.
        ///     \param e - <b>RoutedEventArgs</b> - Represents the item thats being sent in.
        ///
        ///		This Method goes to the market place window.
        /// 
        ///		\return N/A.
        ///
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MarketPlace market = new MarketPlace();
            purchaseAccepted= market.ShowDialog();
            if(purchaseAccepted==true)
            {
                Successful successful = new Successful();
                successful.ShowDialog();
            }
            else
            {

            }
        }

        ///
        ///		\brief Called to create the button for the Delivery Date.
        ///		\details <b>Details</b>
        ///		\param sender - <b>object</b> - Represents the object that is calling the method.
        ///     \param e - <b>RoutedEventArgs</b> - Represents the item thats being sent in.
        ///
        ///		This Method goes to the Delivery Date window.
        /// 
        ///		\return N/A.
        ///
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeliveryTimes delivery = new DeliveryTimes();
            delivery.ShowDialog();

        }

        ///
        ///		\brief Called to create the button for logging in
        ///		\details <b>Details</b>
        ///		\param sender - <b>object</b> - Represents the object that is calling the method.
        ///     \param e - <b>RoutedEventArgs</b> - Represents the item thats being sent in.
        ///
        ///		This Method goes to the logging in window.
        /// 
        ///		\return N/A.
        ///
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            login loginUser = new login();
            userOn = loginUser.ShowDialog();
            deliveryTimes.IsEnabled = userOn.Value;
            enterMarketplace.IsEnabled = userOn.Value;
        }

        ///
        ///		\brief Called to create the button for registering
        ///		\details <b>Details</b>
        ///		\param sender - <b>object</b> - Represents the object that is calling the method.
        ///     \param e - <b>RoutedEventArgs</b> - Represents the item thats being sent in.
        ///
        ///		This Method goes to the registering window.
        /// 
        ///		\return N/A.
        ///
        private void Login_Click1(object sender, RoutedEventArgs e)
        {
           register regUser = new register();
           regUser.ShowDialog();
        }
    }
}
