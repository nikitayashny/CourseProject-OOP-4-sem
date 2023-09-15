using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.Views;

namespace Client
{
    public class FavoritesVM
    {
        private Command addFromFavorites;
        private Command deleteFromFavorites;
        public ICommand DeleteFromFavorites
        {
            get
            {
                return deleteFromFavorites ?? (deleteFromFavorites = new Command(obj =>
                {
                    try
                    {
                        Favorites favorites = obj as Favorites;
                        if (favorites.listviewFavorites.SelectedItem != null)
                        {
                            object o = favorites.listviewFavorites.SelectedItem;
                            ListViewItem lvi = (ListViewItem)favorites.listviewFavorites.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = DataWorker.FindByName("TextBlock_name", lvi) as TextBlock;

                            var result = favorites.db.favorites
                                   .Where(f => f.product_name == tb.Text && f.login == favorites.shop.CurrentLogin)
                                   .ToList();

                            favorites.db.favorites.RemoveRange(result);
                            favorites.db.SaveChanges();

                            favorites.RefreshFavorites();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand AddFromFavorites
        {
            get
            {
                return addFromFavorites ?? (addFromFavorites = new Command(obj =>
                {
                    try
                    {
                        Favorites favorites = obj as Favorites;
                        if (favorites.listviewFavorites.SelectedItem != null)
                        {
                            object o = favorites.listviewFavorites.SelectedItem;
                            ListViewItem lvi = (ListViewItem)favorites.listviewFavorites.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = DataWorker.FindByName("TextBlock_name", lvi) as TextBlock;

                            string login = favorites.shop.CurrentLogin;
                            string product_name = tb.Text;
                            Basket baskets = new Basket(login, product_name);

                            DataWorker.AddToBasket(login, product_name);

                            MessageBox.Show("Товар добавлен в корзину");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }));
            }
        }
    }
}
