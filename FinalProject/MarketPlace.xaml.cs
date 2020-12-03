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
    /// \class MarketPlace
    ///
    /// \brief The purpose of this class is to realistically model the MarketPlace for the TMS system.
    ///	
    ///		NAME: MarketPlace
    ///		PURPOSE : The MarketPlace class has been created to model the market place
    ///     RELATIONSHIPS: Main menu (called from), login (required to enter UI)
    /// Within the class definition 
    /// - N/A
    ///
    /// \author  <i>Nikola Ristic</i>
    ///
    public partial class MarketPlace : Window
    {
        ///
        ///		\brief Started when MarketPlace is clicked
        ///		\details <b>Details</b>
        ///     
        ///		This Method initializes the MarketPlace area and displays all the buttons and designs
        /// 
        ///		\return N/A.
        ///
        public MarketPlace()
        {
            InitializeComponent();

            Contract.connectMarketplace();
        }

        ///
        ///		\brief Called to create the back button for the MarketPlace.
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
            DialogResult = true;
        }
    }
}
