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
    public partial class Catalog : Page
    {              
        private AppContext db = new AppContext();

        private List<Product> allProducts = DataWorker.GetCatalog();

        public Shop shop;
        public string CurLogin;

        public Catalog(Shop shop)
        {
            InitializeComponent();
            this.DataContext = new CatalogVM();
            this.shop = shop;
            listviewProducts.ItemsSource = allProducts;
        }
        public Catalog()
        {
            InitializeComponent();
            this.DataContext = new CatalogVM();
            listviewProducts.ItemsSource = allProducts;
        }
        public Catalog(string CurLogin, List<Product> products, Shop shop)
        {
            InitializeComponent();
            this.DataContext = new CatalogVM();
            this.CurLogin = CurLogin;
        }
     
        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listviewProducts.SelectedItem != null)
            {
                object o = listviewProducts.SelectedItem;
                ListViewItem lvi = (ListViewItem)listviewProducts.ItemContainerGenerator.ContainerFromItem(o);
                TextBlock tb = DataWorker.FindByName("TextBlock_name", lvi) as TextBlock;

                FullDescription.Visibility = Visibility.Visible;
                listviewProducts.Visibility = Visibility.Collapsed;

                var query = from p in db.products
                            where p.name == tb.Text
                            select p;

                listviewFull.ItemsSource = query.ToList();
            }
        }
    }
}
