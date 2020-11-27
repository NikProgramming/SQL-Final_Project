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
    }
}
