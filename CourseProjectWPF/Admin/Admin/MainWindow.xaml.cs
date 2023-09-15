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
using System.Windows.Resources;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Admin
{
    public partial class MainWindow : Window
    {
        public Uri uri = new Uri("C:/Users/User/Desktop/CourseProjectWPF/Admin/Admin/languages/english.xaml", UriKind.RelativeOrAbsolute);
        public Uri urid = new Uri("C:/Users/User/Desktop/CourseProjectWPF/Admin/Admin/themes/Dark.xaml", UriKind.RelativeOrAbsolute);
        private Command openCatalog;
        private Command add;
        private Command delete;
        private Command changeLanguage;
        private Command darkLight;
        private Command orders;

        public ICommand Orders
        {
            get
            {
                return orders ?? (orders = new Command(obj =>
                {
                    try
                    {
                        Orders orders = new Orders();
                        orders.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand OpenCatalog
        {
            get
            {
                return openCatalog ?? (openCatalog = new Command(obj =>
                {
                    try
                    {
                        CatalogWindow catalogWindow = new CatalogWindow();
                        catalogWindow.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand Add
        {
            get
            {
                return add ?? (add = new Command(obj =>
                {
                    try
                    {
                        AddWindow addWindow = new AddWindow();
                        addWindow.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand Delete
        {
            get
            {
                return delete ?? (delete = new Command(obj =>
                {
                    try
                    {
                        DeleteWindow deleteWindow = new DeleteWindow();
                        deleteWindow.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand Changelanguge
        {
            get
            {
                return changeLanguage ?? (changeLanguage = new Command(obj =>
                {
                    try
                    {
                        if (Application.Current.Resources.MergedDictionaries[0].Source == uri)
                        {
                            Application.Current.Resources.MergedDictionaries[0].Source = new Uri("C:/Users/User/Desktop/CourseProjectWPF/Admin/Admin/languages/russian.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else
                            Application.Current.Resources.MergedDictionaries[0].Source = new Uri("C:/Users/User/Desktop/CourseProjectWPF/Admin/Admin/languages/english.xaml", UriKind.RelativeOrAbsolute);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

        public ICommand DarkLight
        {
            get
            {
                return darkLight ?? (darkLight = new Command(obj =>
                {
                    try
                    {
                        if (Application.Current.Resources.MergedDictionaries[1].Source == urid)
                        {
                            Application.Current.Resources.MergedDictionaries[1].Source = new Uri("C:/Users/User/Desktop/CourseProjectWPF/Admin/Admin/themes/Light.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else
                            Application.Current.Resources.MergedDictionaries[1].Source = new Uri("C:/Users/User/Desktop/CourseProjectWPF/Admin/Admin/themes/Dark.xaml", UriKind.RelativeOrAbsolute);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
