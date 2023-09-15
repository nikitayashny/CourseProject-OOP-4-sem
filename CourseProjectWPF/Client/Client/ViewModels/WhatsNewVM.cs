using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Client.Views;

namespace Client
{
    public class WhatsNewVM
    {
        private Command openWhatsNew;
        private Command addToFavoritesWhatsNew;
        private Command addToBasketWhatsNew;
        public ICommand AddToBasketWhatsNew
        {
            get
            {
                return addToBasketWhatsNew ?? (addToBasketWhatsNew = new Command(obj =>
                {
                    try
                    {
                        WhatsNew whatsnew = obj as WhatsNew;
                        if (whatsnew.shop.CurrentLogin == null)
                        {
                            Profile profile = new Profile(whatsnew.shop);
                            whatsnew.shop.MainFrame.Navigate(profile);
                        }
                        else
                        {
                            object o = whatsnew.listviewWhatsNew.SelectedItem;
                            ListViewItem lvi = (ListViewItem)whatsnew.listviewWhatsNew.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = DataWorker.FindByName("TextBlock_name", lvi) as TextBlock;

                            string login = whatsnew.shop.CurrentLogin;
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
        public ICommand AddToFavoritesWhatsNew
        {
            get
            {
                return addToFavoritesWhatsNew ?? (addToFavoritesWhatsNew = new Command(obj =>
                {
                    try
                    {
                        WhatsNew whatsnew = obj as WhatsNew;
                        if (whatsnew.shop.CurrentLogin == null)
                        {
                            Profile profile = new Profile(whatsnew.shop);
                            whatsnew.shop.MainFrame.Navigate(profile);
                        }
                        else
                        {
                            object o = whatsnew.listviewWhatsNew.SelectedItem;
                            ListViewItem lvi = (ListViewItem)whatsnew.listviewWhatsNew.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = DataWorker.FindByName("TextBlock_name", lvi) as TextBlock;

                            string login = whatsnew.shop.CurrentLogin;
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
        public ICommand OpenWhatsNew
        {
            get
            {
                return openWhatsNew ?? (openWhatsNew = new Command(obj =>
                {
                    try
                    {
                        WhatsNew whatsnew = obj as WhatsNew;
                        whatsnew.FullDescriptionWhatsNew.Visibility = Visibility.Collapsed;
                        whatsnew.listviewWhatsNew.Visibility = Visibility.Visible;
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
