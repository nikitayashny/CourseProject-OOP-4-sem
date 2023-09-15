using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Client.Views;

namespace Client
{
    public partial class App : Application
    {
        Catalog catalog = new Catalog();
        private void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                Shop shop = new Shop(this, catalog);
                Home home = new Home(shop);
                shop.MainFrame.Navigate(home);
                shop.Show();
            }
            catch
            {
                MessageBox.Show("Подключение к бд не установлено");
                Shutdown();
            }
        }
    }
}
