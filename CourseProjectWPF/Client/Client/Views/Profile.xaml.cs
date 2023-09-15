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

namespace Client.Views
{
    public partial class Profile : Page
    {
        public AppContext db = new AppContext();

        public Shop shop; 

        public Profile(Shop shop)
        {
            InitializeComponent();
            this.DataContext = new ProfileVM();
            this.shop = shop;
            RefreshOrders();
        }

        public void RefreshOrders()
        {
            if (shop.CurrentLogin != null)
            {
                var Orders = db.orders.Where(d => d.login == shop.CurrentLogin).ToList();
                listviewOrders.ItemsSource = Orders;
                StackPanelLogin.Visibility = Visibility.Collapsed;
                StackPanelRegistration.Visibility = Visibility.Collapsed;
                Success.Visibility = Visibility.Visible;
            }
            else
                listviewOrders.ItemsSource = null;
        }
    }
}
