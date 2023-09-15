using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using MySql.Data.MySqlClient;

namespace Client.Views
{
    public partial class Delivery : Page
    {
        public Shop shop;
        public AppContext db = new AppContext();

        public Delivery(Shop shop)
        {           
            InitializeComponent();
            this.DataContext = new DeliveryVM();
            this.shop = shop;
            OpenDelivery();
        }

        private void OpenDelivery()
        {
            var count = db.clients
                            .Where(c => c.login == shop.CurrentLogin)
                            .Count();
           
            if (shop.CurrentLogin == null)
            {
                Profile profile = new Profile(shop);
                shop.MainFrame.Navigate(profile);
            }
            else if (count > 0)
            {
                shop.MainFrame.Navigate(this);
                RefreshBasket();
                DB DB = new DB();
                DB.openConnection();

                MySqlCommand CheckName = new MySqlCommand(
                              "SELECT name from clients where login = @login;", DB.GetConnection());
                CheckName.Parameters.Add("@login", MySqlDbType.VarChar).Value = shop.CurrentLogin;
                MySqlCommand CheckAddress = new MySqlCommand(
                              "SELECT address from clients where login = @login;", DB.GetConnection());
                CheckAddress.Parameters.Add("@login", MySqlDbType.VarChar).Value = shop.CurrentLogin;
                MySqlCommand CheckPhone = new MySqlCommand(
                              "SELECT phone from clients where login = @login;", DB.GetConnection());
                CheckPhone.Parameters.Add("@login", MySqlDbType.VarChar).Value = shop.CurrentLogin;

                string name = CheckName.ExecuteScalar().ToString();
                string phone = CheckPhone.ExecuteScalar().ToString();
                string address = CheckAddress.ExecuteScalar().ToString();

                DB.closeConnection();

                DeliveryViewer.Visibility = Visibility.Visible;
                Border_ShippingAddress.Visibility = Visibility.Collapsed;
                Image_ShippingAddress.Visibility = Visibility.Collapsed;
                Border_Payment.Visibility = Visibility.Visible;
                Image_Payment.Visibility = Visibility.Visible;
                TextBlock_Address.Text = address;
                TextBlock_Name.Text = name;
                TextBlock_Phone.Text = phone;
            }
            else
            {
                shop.MainFrame.Navigate(this);
                DeliveryViewer.Visibility = Visibility.Visible;
                Border_ShippingAddress.Visibility = Visibility.Visible;
                Image_ShippingAddress.Visibility = Visibility.Visible;
                Border_Payment.Visibility = Visibility.Collapsed;
                Image_Payment.Visibility = Visibility.Collapsed;
            }
        }
        public void RefreshBasket()
        {
            try
            {
               
                var products = (from p in db.products
                                join b in db.baskets on p.name equals b.product_name
                                where b.login == shop.CurrentLogin
                                select p).ToList();

                listviewDelivery.ItemsSource = products;
            }
            catch (Exception ex)
            {
                listviewDelivery.ItemsSource = null;
            }
        }
    }
}
