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
    public partial class Favorites : Page
    {
        public Shop shop;

        public AppContext db = new AppContext();

        public Button bDelete;
        public Button btoBasket;        

        public Favorites(Shop shop)
        {
            InitializeComponent();
            this.DataContext = new FavoritesVM();
            this.shop = shop;
            RefreshFavorites();
        }

        public void RefreshFavorites()
        {
            try
            {
                var query = from p in db.products
                            where (from f in db.favorites
                                   where f.login == shop.CurrentLogin
                                   select f.product_name)
                                   .Contains(p.name)
                            select p;

                listviewFavorites.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void OnMouseDoubleClickFavorites(object sender, MouseButtonEventArgs e)
        {
            if (listviewFavorites.SelectedItem != null)
            {
                if (bDelete != null || btoBasket != null)
                {
                    bDelete.Visibility = Visibility.Hidden;
                    btoBasket.Visibility = Visibility.Hidden;
                }

                object o = listviewFavorites.SelectedItem;
                ListViewItem lvi = (ListViewItem)listviewFavorites.ItemContainerGenerator.ContainerFromItem(o);
                bDelete = DataWorker.FindByName("ButtonDeleteFromFavorites", lvi) as Button;
                btoBasket = DataWorker.FindByName("ButtonAddFromFavorites", lvi) as Button;

                bDelete.Visibility = Visibility.Visible;
                btoBasket.Visibility = Visibility.Visible;
            }
        }
    }
}
