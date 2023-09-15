using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using Client.Views;

namespace Client
{
    internal class DataWorker
    {
        public static List<Product> GetCatalog()
        {
            using(AppContext db = new AppContext())
            {
                try
                {
                    var Catalog = db.products.ToList();
                    return Catalog;
                }
                catch
                {
                    return null;
                }

            }
        }
        public static List<Review> GetReviews()
        {
            using (AppContext db = new AppContext())
            {
                var Reviews = db.reviews.ToList();
                return Reviews;
            }
        }
        public static void AddNewReview(string name, string review)
        {
            using (AppContext db = new AppContext())
            {
                Review review1 = new Review()
                {
                    name = name,
                    review = review
                };
                db.reviews.Add(review1);
                db.SaveChanges();
            }
        }
        public static void RegisterNewUser(string login, string password, string email)
        {
            using(AppContext db = new AppContext())
            {
                User user = new User()
                {
                    login = login,
                    password = password,
                    email = email
                };
                db.users.Add(user);
                db.SaveChanges();
            }
        }

        public static void AddToBasket(string login, string product_name)
        {
            UnitOfWork unit = new UnitOfWork();

            Basket basket = new Basket();
            basket.login = login;
            basket.product_name = product_name;

            unit.Baskets.Create(basket);
            unit.Save();
        }

        public static void AddToFavorite(string login, string product_name)
        {
            UnitOfWork unit = new UnitOfWork();

            Favorite favorite = new Favorite();
            favorite.login = login;
            favorite.product_name = product_name;

            unit.Favorites.Create(favorite);
            unit.Save();
        }

        public static void RegisterNewClient(string login, string name, string address, string phone)
        {
            using (AppContext db = new AppContext())
            {
                CLient client = new CLient()
                {
                    login = login,
                    name = name,
                    address = address,
                    phone = phone
                };
                db.clients.Add(client);
                db.SaveChanges();
            }
        }
        public static void RegisterNewOrder(string login, string product_name, string card_number, string holder_name, string expiration_date, int CVV)
        {
            DateTime date = DateTime.Now;
            using (AppContext db = new AppContext())
            {
                Order order = new Order()
                {
                    login = login,
                    product_name = product_name,
                    status = "Waiting",
                    card_number = card_number,
                    holder_name = holder_name,
                    expiration_date = expiration_date,
                    CVV = CVV,
                    date = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString()
            };
                db.orders.Add(order);
                db.SaveChanges();
            }
        }

        public static DataTable RefreshWhatsNew()
        {
            DateTime date = DateTime.Now;

            DB db = new DB();
            db.openConnection();

            MySqlCommand WhatsNewCommand = new MySqlCommand(
                          "SELECT * from products where DATEDIFF(@date, date) < 14;", db.GetConnection());
            WhatsNewCommand.Parameters.Add("@date", MySqlDbType.VarChar).Value = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();

            MySqlDataAdapter adapterWhatsNew = new MySqlDataAdapter();
            adapterWhatsNew.SelectCommand = WhatsNewCommand;
            DataTable tableWhatsNew = new DataTable();
            adapterWhatsNew.Fill(tableWhatsNew);

            db.closeConnection();
            return tableWhatsNew;

        }

        public static FrameworkElement FindByName(string name, FrameworkElement root)
        {
            Stack<FrameworkElement> tree = new Stack<FrameworkElement>();
            tree.Push(root);

            while (tree.Count > 0)
            {
                FrameworkElement current = tree.Pop();
                if (current.Name == name)
                    return current;

                int count = VisualTreeHelper.GetChildrenCount(current);
                for (int i = 0; i < count; ++i)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(current, i);
                    if (child is FrameworkElement)
                        tree.Push((FrameworkElement)child);
                }
            }
            return null;
        }
    }
}
