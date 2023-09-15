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
    public class CartVM
    {
        public AppContext db = new AppContext();

        private Command checkOut;
        private Command deleteFromBasket;
        public ICommand CheckOut
        {
            get
            {
                return checkOut ?? (checkOut = new Command(obj =>
                {
                    try
                    {
                        Cart cart = obj as Cart;
                        Delivery delivery = new Delivery(cart.shop);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand DeleteFromBasket
        {
            get
            {
                return deleteFromBasket ?? (deleteFromBasket = new Command(obj =>
                {
                    try
                    {
                        Cart cart = obj as Cart;
                        if (cart.listviewBasket.SelectedItem != null)
                        {
                            object o = cart.listviewBasket.SelectedItem;
                            ListViewItem lvi = (ListViewItem)cart.listviewBasket.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = DataWorker.FindByName("Basket_name", lvi) as TextBlock;

                            cart.db.baskets.Remove(
                                    cart.db.baskets.Where(b => b.product_name == tb.Text && b.login == cart.shop.CurrentLogin).First());
                            cart.db.SaveChanges();


                            cart.RefreshBasket();
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
