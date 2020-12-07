/*
* FILE : MarketPlace.xaml.cs
* PROJECT : PROG2020 - Client-Side Programming
* PROGRAMMER : Justin Langevin & Josiah Rehkopf & Troy Hill & Nikola Ristic
* FIRST VERSION : 12/1/2020
* DESCRIPTION : This file is used to run the marketplace logic.
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
using System.IO;


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
        public static List <string> contractStrings = new List<string>();
        string purchasedItem;
        string CompanyName;
        string origin;
        string destination;
        bool exitProgram;
        public static bool run = false;
        public static bool runTwo = false;

        /* -------------------------------------------------------------------------------------------
        * Method	    :   fileConnecter9000()
        * Description	:   This constructor is used to set the ContractDisplay.
        * Parameters    :	none  
        * Returns		:   the contract string
        * ------------------------------------------------------------------------------------------*/
        public MarketPlace()
        {
            InitializeComponent();
            if (run == false)
            {
                returnlist();
                ContractDisplay.ItemsSource = contractStrings;
            }
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   fileConnecter9000()
        * Description	:   This Method is used to populate the list.  		
        * Parameters    :	none  
        * Returns		:   the contract string
        * ------------------------------------------------------------------------------------------*/
        public static string fileConnecter9000(int index)
        {
            string stringContract = "";
            string[] words = Contract.contractList[index].customerName.Split(' ');
            string companyName = "";
            for (int i = 0; i < words.Length; i++)
            {
                companyName = companyName + words[i];
            }
            stringContract = companyName + " " + Contract.contractList[index].origin + " " + Contract.contractList[index].destination;
            return stringContract;
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   loadValue()
        * Description	:   This Method is used for the loadValue    		
        * Parameters    :	none  
        * Returns		:   load
        * ------------------------------------------------------------------------------------------*/
        public static int loadValue()
        {
            int load = 0;
            Contract.contractDetails contract = new Contract.contractDetails();
            load = contract.jobType;
            return load;
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   vanType()
        * Description	:   This Method is used for the van type     		
        * Parameters    :	none  
        * Returns		:   type
        * ------------------------------------------------------------------------------------------*/
        public static int vanType()
        {
            int type = 0;
            Contract.contractDetails contract = new Contract.contractDetails();
            type = contract.vanType;
            return type;
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
        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click1()
        * Description	:   This Method is used for going back      		
        * Parameters    :	object sender, RoutedEventArgs e      
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            contractStrings.Clear();
            ContractDisplay = null;            
            DialogResult = false;
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   ListView_SelectionChanged_1()
        * Description	:   This Method is used for the list view        		
        * Parameters    :	object sender, SelectionChangedEventArgs e      
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   Button_Click2()
        * Description	:   This Method is used for the purchase order         		
        * Parameters    :	object sender, TextChangedEventArgs e      
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
           purchasedItem=(string)ContractDisplay.SelectedItem;
           string[] words = purchasedItem.Split(' ');
           CompanyName=words[0];
           origin = words[1];
           destination = words[2];
           exitProgram= Buyer.CreateOrder(CompanyName,destination, origin);
           contractStrings.Clear();
           DialogResult = exitProgram;
        }

        /* -------------------------------------------------------------------------------------------
        * Method	    :   Purchase_TextChanged()
        * Description	:   This Method is used for a text box          		
        * Parameters    :	object sender, TextChangedEventArgs e      
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        private void Purchase_TextChanged(object sender, TextChangedEventArgs e)
        {           
        }


        /* -------------------------------------------------------------------------------------------
        * Method	    :   returnlist()
        * Description	:   This Method is used to return the list of contracts          		
        * Parameters    :	none      
        * Returns		:   none
        * ------------------------------------------------------------------------------------------*/
        public void returnlist()
        {
            if(runTwo == false)//if checks if it has already been called
            {
                Contract.connectMarketplace();
            }

            //populates a list
            for (int i = 0; i < Contract.contractList.Count; i++)
            {
                contractStrings.Add(fileConnecter9000(i));
            }
            runTwo = true;
        }
    }
}
