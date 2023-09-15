using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.Views;

namespace Client
{
    public class CatalogVM 
    {
        private Command addToBasket;
        private Command addToFavorites;
        private Command openCatalog;
        public ICommand OpenCatalog
        {
            get
            {
                return openCatalog ?? (openCatalog = new Command(obj =>
                {
                    try
                    {
                        Catalog catalog = obj as Catalog;
                        catalog.listviewProducts.Visibility = Visibility.Visible;
                        catalog.FullDescription.Visibility = Visibility.Collapsed;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand AddToFavorites
        {
            get
            {
                return addToFavorites ?? (addToFavorites = new Command(obj =>
                {
                    try
                    {
                        Catalog catalog = obj as Catalog;
                        if (catalog.CurLogin != null)
                        {
                            object o = catalog.listviewProducts.SelectedItem;
                            ListViewItem lvi = (ListViewItem)catalog.listviewProducts.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = DataWorker.FindByName("TextBlock_name", lvi) as TextBlock;

                            string login = catalog.CurLogin;
                            string product_name = tb.Text;
                            Favorite favorites = new Favorite(login, product_name);

                            DataWorker.AddToFavorite(login, product_name);

                            MessageBox.Show("Товар добавлен в избранное");
                            return;
                        }
                        if (catalog.shop == null)
                        {
                            MessageBox.Show("Сначала войдите в аккаунт");
                            return;
                        }
                        if (catalog.shop.CurrentLogin == null)
                        {
                            Profile profile = new Profile(catalog.shop);
                            catalog.shop.MainFrame.Navigate(profile);
                        }
                        else
                        {
                            object o = catalog.listviewProducts.SelectedItem;
                            ListViewItem lvi = (ListViewItem)catalog.listviewProducts.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = DataWorker.FindByName("TextBlock_name", lvi) as TextBlock;

                            string login = catalog.shop.CurrentLogin;
                            string product_name = tb.Text;
                            Favorite favorites = new Favorite(login, product_name);

                            DataWorker.AddToFavorite(login, product_name);

                            MessageBox.Show("Товар добавлен в избранное");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand AddToBasket
        {
            get
            {
                return addToBasket ?? (addToBasket = new Command(obj =>
                {
                    try
                    {
                        Catalog catalog = obj as Catalog;
                        if (catalog.CurLogin != null)
                        {
                            object o = catalog.listviewProducts.SelectedItem;
                            ListViewItem lvi = (ListViewItem)catalog.listviewProducts.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = DataWorker.FindByName("TextBlock_name", lvi) as TextBlock;

                            string login = catalog.CurLogin;
                            string product_name = tb.Text;
                            Basket baskets = new Basket(login, product_name);

                            DataWorker.AddToBasket(login, product_name);

                            MessageBox.Show("Товар добавлен в корзину");
                            return;
                        }
                        if (catalog.shop == null)
                        {
                            MessageBox.Show("Сначала войдите в аккаунт");
                            return;
                        }
                        if (catalog.shop.CurrentLogin == null)
                        {
                            Profile profile = new Profile(catalog.shop);
                            catalog.shop.MainFrame.Navigate(profile);
                        }
                        else
                        {
                            object o = catalog.listviewProducts.SelectedItem;
                            ListViewItem lvi = (ListViewItem)catalog.listviewProducts.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = DataWorker.FindByName("TextBlock_name", lvi) as TextBlock;

                            string login = catalog.shop.CurrentLogin;
                            string product_name = tb.Text;
                            Basket baskets = new Basket(login, product_name);

                            DataWorker.AddToBasket(login, product_name);

                            MessageBox.Show("Товар добавлен в корзину");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
    }
}
