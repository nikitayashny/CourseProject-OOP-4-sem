using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MySql.Data.MySqlClient;

namespace Client.Views
{
    public partial class Shop : Window
    {   
        private AppContext db = new AppContext();

        private Catalog catalog;

        public string textSearch;
        public string CurrentLogin;

        public Shop(App app, Catalog catalog)
        {
            InitializeComponent();
            this.catalog = catalog;
        }

    
        private void Header_OpenHome(object sender, RoutedEventArgs e)
        {
            Home home = new Home(this);         
            MainFrame.Navigate(home);
        }
        private void Header_OpenWhatsNew(object sender, RoutedEventArgs e)
        {
            WhatsNew whatsnew = new WhatsNew(this);
            MainFrame.Navigate(whatsnew);
        }
        public void Header_OpenCatalog(object sender, RoutedEventArgs e)
        {
            Catalog catalog = new Catalog(this);
            MainFrame.Navigate(catalog);
        }   
        private void Header_OpenAboutUs(object sender, RoutedEventArgs e)
        {
            AboutUs aboutus = new AboutUs();
            MainFrame.Navigate(aboutus);
        }
        private void Header_OpenBasket(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart(this);
            MainFrame.Navigate(cart);
        }
        private void Header_OpenFavorites(object sender, RoutedEventArgs e)
        {
            Favorites favorites = new Favorites(this);
            MainFrame.Navigate(favorites);
        }
        private void Header_OpenSearch(object sender, RoutedEventArgs e)
        {
            RefreshSearch();
            if(CurrentLogin != null)
            {        
                textSearch = Head.TextBox_Search.Text;
                Head.TextBox_Search.Text = null;

                var products = db.products.Where(p => p.name.Contains(textSearch)).ToList();
                List<Product> Products = products;
                Catalog cat = new Catalog(CurrentLogin, products, this);
                cat.listviewProducts.ItemsSource = Products;

                MainFrame.Navigate(cat);
            }
            else
            {
                MainFrame.Navigate(catalog);
                Head.TextBox_Search.Text = null;
            }       
        }
        private void Head_OpenProfile(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(this);
            MainFrame.Navigate(profile);
        }
        private void Head_OpenDelivery(object sender, RoutedEventArgs e)
        {
            Delivery delivery = new Delivery(this);
        } 
        private void RefreshSearch()
        {
            textSearch = Head.TextBox_Search.Text;

            var products = db.products.Where(p => p.name.Contains(textSearch)).ToList();

            catalog.listviewProducts.ItemsSource = products;
        }
    }
}
