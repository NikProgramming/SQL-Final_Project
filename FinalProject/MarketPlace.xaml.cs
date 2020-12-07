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
        public MarketPlace()
        {
            InitializeComponent();

            if (run == false)
            {
                returnlist();
                ContractDisplay.ItemsSource = contractStrings;
            }
        }

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

        public static int loadValue()
        {
            int load = 0;
            Contract.contractDetails contract = new Contract.contractDetails();
            load = contract.jobType;
            return load;
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
            contractStrings.Clear();
            ContractDisplay = null;            
            DialogResult = false;
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
           purchasedItem=(string)ContractDisplay.SelectedItem;
           string[] words = purchasedItem.Split(' ');
           CompanyName=words[0];
           origin = words[1];
           destination = words[2];
           exitProgram= Buyer.CreateOrder(CompanyName,destination, origin);
           DialogResult = exitProgram;

        }

        private void Purchase_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        public void returnlist()
        {
            if(runTwo == false)
            {
                Contract.connectMarketplace();
            }

            for (int i = 0; i < Contract.contractList.Count; i++)
            {
                contractStrings.Add(fileConnecter9000(i));
            }
            runTwo = true;
        }
    }
}
