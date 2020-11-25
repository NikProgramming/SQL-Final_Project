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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool? userOn;
        public MainWindow()
        {
            userOn = false;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login purchases = new login();
            purchases.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MarketPlace market = new MarketPlace();
            market.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeliveryTimes delivery = new DeliveryTimes();
            delivery.ShowDialog();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            login loginUser = new login();
            userOn = loginUser.ShowDialog();
            deliveryTimes.IsEnabled = userOn.Value;
            enterMarketplace.IsEnabled = userOn.Value;
            
        }

        private void Login_Click1(object sender, RoutedEventArgs e)
        {

        }
    }
}
