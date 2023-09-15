using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Admin
{
    public partial class Orders : Window
    {
        private Command accept;
        private Command done;
        private Command sortbydate;
        private Command showwaitings;
        private Command showaccepted;
        private Command showdone;
        public Orders()
        {
            InitializeComponent();
            RefreshOrders();
        }
        public ICommand ShowDone
        {
            get
            {
                return showdone ?? (showdone = new Command(obj =>
                {
                    DB db = new DB();
                    db.openConnection();

                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM orders where status = 'Done'", db.GetConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    listviewOrders.ItemsSource = table.DefaultView;

                    db.closeConnection();
                }));
            }
        }
        public ICommand ShowAccepted
        {
            get
            {
                return showaccepted ?? (showaccepted = new Command(obj =>
                {
                    DB db = new DB();
                    db.openConnection();

                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM orders where status = 'Accepted'", db.GetConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    listviewOrders.ItemsSource = table.DefaultView;

                    db.closeConnection();
                }));
            }
        }
        public ICommand ShowWaitings
        {
            get
            {
                return showwaitings ?? (showwaitings = new Command(obj =>
                {
                    DB db = new DB();
                    db.openConnection();

                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM orders where status = 'Waiting'", db.GetConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    listviewOrders.ItemsSource = table.DefaultView;

                    db.closeConnection();
                }));
            }
        }
        public ICommand SortByDate
        {
            get
            {
                return sortbydate ?? (sortbydate = new Command(obj =>
                {
                    DB db = new DB();
                    db.openConnection();

                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM orders order by date desc", db.GetConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    listviewOrders.ItemsSource = table.DefaultView;

                    db.closeConnection();                    
                }));
            }
        }
        public ICommand Accept
        {
            get
            {
                return accept ?? (accept = new Command(obj =>
                {
                    if (listviewOrders.SelectedItem != null)
                    {
                        object o = listviewOrders.SelectedItem;
                        ListViewItem lvi = (ListViewItem)listviewOrders.ItemContainerGenerator.ContainerFromItem(o);
                        TextBlock tb = FindByName("TextBlock_id", lvi) as TextBlock;

                        DB db = new DB();

                        MySqlCommand accept = new MySqlCommand("UPDATE `orders` SET `status`='Accepted' WHERE id = @id", db.GetConnection());
                        accept.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(tb.Text);

                        db.openConnection();

                        accept.ExecuteNonQuery();


                        db.closeConnection();

                        listviewOrders.SelectedItem = null;
                        RefreshOrders();                    
                    }
                    else
                        MessageBox.Show("Не выбран заказ");
                }));
            }
        }
        public ICommand Done
        {
            get
            {
                return done ?? (done = new Command(obj =>
                {
                    if (listviewOrders.SelectedItem != null)
                    {
                        object o = listviewOrders.SelectedItem;
                        ListViewItem lvi = (ListViewItem)listviewOrders.ItemContainerGenerator.ContainerFromItem(o);
                        TextBlock tb = FindByName("TextBlock_id", lvi) as TextBlock;
                        TextBlock tbl = FindByName("TextBlock_login", lvi) as TextBlock;

                        DB db = new DB();

                        MySqlCommand done = new MySqlCommand("UPDATE `orders` SET `status`='Done' WHERE id = @id", db.GetConnection());
                        done.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(tb.Text);

                        MySqlCommand findmail = new MySqlCommand("Select email from users where login = @login", db.GetConnection());
                        findmail.Parameters.Add("@login", MySqlDbType.VarChar).Value = tbl.Text;
                        string mailaddress;
                        db.openConnection();

                        done.ExecuteNonQuery();                       
                        mailaddress = findmail.ExecuteScalar().ToString();
                        db.closeConnection();

                        TextBlock tbname = FindByName("TextBlock_product_name", lvi) as TextBlock;
                        string product_name = tbname.Text;
                        listviewOrders.SelectedItem = null;
                        RefreshOrders();


                        try
                        {
                            var mail = CreateMail("LSD Clothing", "yashny.lsdclothing@gmail.com", mailaddress, "Информация о заказе", "Ваш заказ " + product_name + " готов к выдаче");
                            SendMail("smtp.gmail.com", 587, "yashny.lsdclothing@gmail.com", "hekupnuelsnecjij", mail);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                        MessageBox.Show("Не выбран заказ");
                }));
            }
        }

        private void RefreshOrders()
        {
            try
            {
                DB db = new DB();

                db.openConnection();

                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM orders", db.GetConnection());
                DataTable table = new DataTable();

                adapter.Fill(table);
                listviewOrders.ItemsSource = table.DefaultView;

                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private FrameworkElement FindByName(string name, FrameworkElement root)
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
        public static MailMessage CreateMail(string name, string emailFrom, string emailTo, string subject, string body)
        {
            var from = new MailAddress(emailFrom, name);
            var to = new MailAddress(emailTo);
            var mail = new MailMessage(from, to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            return mail;
        }
        public static void SendMail(string host, int smptPort, string emailFrom, string pass, MailMessage mail)
        {
            SmtpClient smtp = new SmtpClient(host, smptPort);
            smtp.Credentials = new NetworkCredential(emailFrom, pass);
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
    }
}
