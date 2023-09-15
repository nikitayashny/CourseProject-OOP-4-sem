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

namespace Client.Views
{ 
    public partial class Home : Page
    {
        private List<Review> reviews = DataWorker.GetReviews();
        Shop shop;
        public Home(Shop shop)
        {
            InitializeComponent();
            listviewReviews.ItemsSource = reviews;
            this.shop = shop;
        }
        private void Header_OpenCatalog(object sender, RoutedEventArgs e)
        {         
            Catalog catalog = new Catalog(shop);
            shop.MainFrame.Navigate(catalog);
        }
        private void Header_OpenAboutUs(object sender, RoutedEventArgs e)
        {
            AboutUs aboutus = new AboutUs();
            shop.MainFrame.Navigate(aboutus);
        }

    }
}
