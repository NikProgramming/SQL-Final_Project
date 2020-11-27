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

namespace FinalProject
{

    /// 
    /// \class DeliveryTimes
    ///
    /// \brief The purpose of this class is to realistically model the Delievery times for the TMS system.
    ///	
    ///		NAME: DeliveryTimes
    ///		PURPOSE : The DeliveryTimes class has been created to 
    ///     RELATIONSHIPS: Main menu (called from), login (required to enter UI)
    /// Within the class definition 
    /// - N/A
    ///
    /// \author  <i>Justin Langevin</i>
    ///
    public partial class DeliveryTimes : Window
    {
        ///
        ///		\brief Started when Delivery date is clicked
        ///		\details <b>Details</b>
        ///     
        ///		This Method initializes the DeliveryTimes area and displays all the buttons and designs
        /// 
        ///		\return N/A.
        ///
        public DeliveryTimes()
        {
            InitializeComponent();
        }


        ///
        ///		\brief Called to create the back button for the DeliveryTimes.
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
    }
}
