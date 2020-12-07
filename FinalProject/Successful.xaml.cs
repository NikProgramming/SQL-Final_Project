/*
* FILE : Successful.xaml.cs
* PROJECT : PROG2020 - Client-Side Programming
* PROGRAMMER : Justin Langevin & Josiah Rehkopf & Troy Hill & Nikola Ristic
* FIRST VERSION : 12/1/2020
* DESCRIPTION : This file is used to run the Success logic after a purchase.
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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Successful.xaml
    /// this class is used to display a success screen.
    /// </summary>
    public partial class Successful : Window
    {
        /* -------------------------------------------------------------------------------------------
        * Method	    :   Successful()
        * Description	:   This is the construct for the Successful class            		
        * Parameters    :	none  
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public Successful()
        {
            InitializeComponent();
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click()
        * Description	:   This is the button for the class            		
        * Parameters    :	none  
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   TextBox_TextChanged()
        * Description	:   This is the Textbox for the class            		
        * Parameters    :	none  
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
