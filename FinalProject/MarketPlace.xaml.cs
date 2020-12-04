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
        List <string> contractStrings = new List<string>();
        string purchasedItem;
        string CompanyName;
        string origin;
        string destination;

        public MarketPlace()
        {
            InitializeComponent();
            Contract.connectMarketplace();
            for(int i=0;i<Contract.contractList.Count;i++)
            {
                contractStrings.Add(fileConnecter9000(i));
            }
            ContractDisplay.ItemsSource = contractStrings;
        }

        public string fileConnecter9000(int index)
        {
            string stringContract="";
            stringContract = Contract.contractList[index].customerName +" "+ Contract.contractList[index].origin + " " + Contract.contractList[index].destination ;


            return stringContract;
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
            for (int i = 0; i < contractStrings.Count; i++)
            {
                contractStrings.RemoveAt(i);
            }
            ContractDisplay = null;
            DialogResult = true;
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
            Buyer.CreateOrder();

        }

        private void Purchase_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
