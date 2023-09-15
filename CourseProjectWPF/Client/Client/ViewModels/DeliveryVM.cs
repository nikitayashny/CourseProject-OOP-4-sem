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
    public class DeliveryVM
    {
        private Command goToPayment;
        private Command payNow;
        private Command send;
        public ICommand PayNow
        {
            get
            {
                return payNow ?? (payNow = new Command(obj =>
                {
                    try
                    {
                        Delivery delivery = obj as Delivery;
                        bool flag = false;
                        if (delivery.TextBox_CardNumber.Text == "")
                        {
                            delivery.TextBox_CardNumber.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_CardNumber.Background = default;
                        if (!Regex.IsMatch(delivery.TextBox_CardNumber.Text, @"^\d{4}\s\d{4}\s\d{4}\s\d{4}$"))
                        {
                            delivery.TextBox_CardNumber.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_CardNumber.Background = default;
                        if (delivery.TextBox_HolderName.Text == "")
                        {
                            delivery.TextBox_HolderName.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_HolderName.Background = default;
                        if (delivery.TextBox_ExpirationDate.Text == "")
                        {
                            delivery.TextBox_ExpirationDate.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_ExpirationDate.Background = default;
                        if (!Regex.IsMatch(delivery.TextBox_ExpirationDate.Text, @"^(0[1-9]|1[0-2])/(2[3-9]|[3-9][0-9])$"))
                        {
                            delivery.TextBox_ExpirationDate.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_ExpirationDate.Background = default;
                        if (delivery.TextBox_CVV.Text == "")
                        {
                            delivery.TextBox_CVV.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_CVV.Background = default;
                        if (!Regex.IsMatch(delivery.TextBox_CVV.Text, @"^\d{3}$"))
                        {
                            delivery.TextBox_CVV.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_CVV.Background = default;

                        if (flag)
                            return;
                        else
                        {                          
                            var products = (from p in delivery.db.products
                                            join b in delivery.db.baskets on p.name equals b.product_name
                                            where b.login == delivery.shop.CurrentLogin
                                            select p).ToList();

                            foreach (var product in products)
                            {
                                string login = delivery.shop.CurrentLogin;
                                string product_name = product.name;
                                string card_number = delivery.TextBox_CardNumber.Text;
                                string holder_name = delivery.TextBox_HolderName.Text;
                                string expiration_date = delivery.TextBox_ExpirationDate.Text;
                                int CVV = Convert.ToInt32(delivery.TextBox_CVV.Text);

                                DataWorker.RegisterNewOrder(login, product_name, card_number, holder_name, expiration_date, CVV);
                            }

                            delivery.listviewDelivery.ItemsSource = null;

                            var result = delivery.db.baskets
                                   .Where(b => b.login == delivery.shop.CurrentLogin)
                                   .ToList();

                            delivery.db.baskets.RemoveRange(result);
                            delivery.db.SaveChanges();



                            delivery.TextBox_CardNumber.Text = null;
                            delivery.TextBox_HolderName.Text = null;
                            delivery.TextBox_ExpirationDate.Text = null;
                            delivery.TextBox_CVV.Text = null;

                            MessageBox.Show("Заказ оформлен успешно");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand GoToPayment
        {
            get
            {
                return goToPayment ?? (goToPayment = new Command(obj =>
                {
                    try
                    {
                        Delivery delivery = obj as Delivery;
                        
                        bool flag = false;
                        if (delivery.TextBox_Name.Text == "")
                        {
                            delivery.TextBox_Name.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_Name.Background = default;
                        if (delivery.TextBox_Address.Text == "")
                        {
                            delivery.TextBox_Address.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_Address.Background = default;
                        if (delivery.TextBox_Phone.Text == "")
                        {
                            delivery.TextBox_Phone.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_Phone.Background = default;
                        if (!Regex.IsMatch(delivery.TextBox_Phone.Text, @"^\+375\d{9}$"))
                        {
                            delivery.TextBox_Phone.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_Phone.Background = default;

                        if (flag)
                            return;
                        else
                        {
                            string login = delivery.shop.CurrentLogin;
                            string name = delivery.TextBox_Name.Text;
                            string address = delivery.TextBox_Address.Text;
                            string phone = delivery.TextBox_Phone.Text;

                            DataWorker.RegisterNewClient(login, name, address, phone);

                            delivery.TextBox_Name.Text = null;
                            delivery.TextBox_Address.Text = null;
                            delivery.TextBox_Phone.Text = null;

                            delivery.Border_ShippingAddress.Visibility = Visibility.Collapsed;
                            delivery.Image_ShippingAddress.Visibility = Visibility.Collapsed;
                            delivery.Border_Payment.Visibility = Visibility.Visible;
                            delivery.Image_Payment.Visibility = Visibility.Visible;
                            delivery.TextBlock_Address.Text = address;
                            delivery.TextBlock_Name.Text = name;
                            delivery.TextBlock_Phone.Text = phone;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand Send
        {
            get
            {
                return send ?? (send = new Command(obj =>
                {
                    try
                    {
                        Delivery delivery = obj as Delivery;

                        bool flag = false;
                        if (delivery.TextBox_Review.Text == "")
                        {
                            delivery.TextBox_Review.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            delivery.TextBox_Review.Background = default;                     

                        if (flag)
                            return;
                        else
                        {
                            string review = delivery.TextBox_Review.Text;
                            string name = delivery.db.clients
                                            .Where(c => c.login == delivery.shop.CurrentLogin)
                                            .Select(c => c.name)
                                            .SingleOrDefault().ToString();

                            DataWorker.AddNewReview(name, review);

                            delivery.TextBox_Review.Text = null;
                            MessageBox.Show("Спасибо за отзыв");
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
