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
    public partial class Cart : Page
    {
        public AppContext db = new AppContext();
        public Shop shop;
        private Button b;

        public Cart(Shop shop)
        {
            InitializeComponent();
            this.DataContext = new CartVM();
            this.shop = shop;
            RefreshBasket();
        }
        public void RefreshBasket()
        {
            try
            {

                var products = (from p in db.products
                             join b in db.baskets on p.name equals b.product_name
                             where b.login == shop.CurrentLogin
                             select p).ToList();

                var results = from product in db.products
                             join basket in db.baskets on product.name equals basket.product_name
                             where basket.login == shop.CurrentLogin
                              select product.price;

                var totalPrice = results.Sum();


                var resultc = from product in db.products
                              join basket in db.baskets on product.name equals basket.product_name
                              where basket.login == shop.CurrentLogin
                              select product.price;

                var result = results.Count();

                listviewBasket.ItemsSource = products;
                RunSum.Text = totalPrice.ToString();
                RunQuantity.Text = result.ToString();
            }
            catch (Exception ex)
            {
                listviewBasket.ItemsSource = null;
                RunSum.Text = "0";
                RunQuantity.Text = "0";
            }
        }
        private void OnMouseDoubleClickBasket(object sender, MouseButtonEventArgs e)
        {
            if (listviewBasket.SelectedItem != null)
            {
                if (b != null)
                {
                    b.Visibility = Visibility.Hidden;
                }

                object o = listviewBasket.SelectedItem;
                ListViewItem lvi = (ListViewItem)listviewBasket.ItemContainerGenerator.ContainerFromItem(o);
                b = DataWorker.FindByName("DeleteButton", lvi) as Button;

                if (b != null)
                    b.Dispatcher.BeginInvoke(new Func<bool>(b.Focus));
                b.Visibility = Visibility.Visible;
            }
        }
    }
}
