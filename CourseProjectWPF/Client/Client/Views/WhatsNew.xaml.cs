using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;

namespace Client.Views
{
    public partial class WhatsNew : Page
    {        
        public AppContext db = new AppContext();

        public Shop shop;

        public WhatsNew(Shop shop)
        {
            InitializeComponent();
            this.DataContext = new WhatsNewVM();
            this.shop = shop;
            listviewWhatsNew.ItemsSource = DataWorker.RefreshWhatsNew().DefaultView;
        }
        private void OnMouseDoubleClickWhatsNew(object sender, MouseButtonEventArgs e)
        {
            if (listviewWhatsNew.SelectedItem != null)
            {
                object o = listviewWhatsNew.SelectedItem;
                ListViewItem lvi = (ListViewItem)listviewWhatsNew.ItemContainerGenerator.ContainerFromItem(o);
                TextBlock tb = DataWorker.FindByName("TextBlock_name", lvi) as TextBlock;

                FullDescriptionWhatsNew.Visibility = Visibility.Visible;
                listviewWhatsNew.Visibility = Visibility.Collapsed;

                var query = from p in db.products
                            where p.name == tb.Text
                            select p;

                listviewFullWhatsNew.ItemsSource = query.ToList();
            }
        }
    }
}
