using System.Windows;
using System.Windows.Controls;

namespace Client.Views
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();

        }

        public event RoutedEventHandler OpenCatalog;
        public event RoutedEventHandler OpenHome;
        public event RoutedEventHandler OpenAboutUs;
        public event RoutedEventHandler OpenBasket;
        public event RoutedEventHandler OpenWhatsNew;
        public event RoutedEventHandler OpenFavorites;
        public event RoutedEventHandler OpenSearch;
        public event RoutedEventHandler OpenProfile;
        public event RoutedEventHandler OpenDelivery;

        private void Open_Catalog_Click(object sender, RoutedEventArgs e)
        {
            if (OpenCatalog != null) OpenCatalog.Invoke(sender, e);
        }
        private void Open_Home_Click(object sender, RoutedEventArgs e)
        {
            if (OpenHome != null) OpenHome.Invoke(sender, e);
        }
        private void Open_AboutUs_Click(object sender, RoutedEventArgs e)
        {
            if (OpenAboutUs != null) OpenAboutUs.Invoke(sender, e);
        }
        private void Open_Basket_Click(object sender, RoutedEventArgs e)
        {
            if (OpenBasket != null) OpenBasket.Invoke(sender, e);
        }
        private void Open_WhatsNew_Click(object sender, RoutedEventArgs e)
        {
            if (OpenWhatsNew != null) OpenWhatsNew.Invoke(sender, e);
        }
        private void Open_Favorites_Click(object sender, RoutedEventArgs e)
        {
            if (OpenFavorites != null) OpenFavorites.Invoke(sender, e);
        }
        private void Open_Search_Click(object sender, RoutedEventArgs e)
        {
            if (OpenSearch != null) OpenSearch.Invoke(sender, e);
        }
        private void Open_Profile_Click(object sender, RoutedEventArgs e)
        {
            if (OpenProfile != null) OpenProfile.Invoke(sender, e);
        }
        private void Open_Delivery_Click(object sender, RoutedEventArgs e)
        {
            if (OpenDelivery != null) OpenDelivery.Invoke(sender, e);
        }
    }
}
