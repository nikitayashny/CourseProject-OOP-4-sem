using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class DeleteWindow : Window
    {
        private Command delete;
        private Command back;
        public ICommand Back
        {
            get
            {
                return back ?? (back = new Command(obj =>
                {
                    try
                    {
                        Close();
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
                        if (TextBox_Delete.Text == "")
                        {
                            TextBox_Delete.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            return;
                        }
                        else
                            TextBox_Delete.Background = default;

                        DB db = new DB();
                        MySqlCommand delete = new MySqlCommand("DELETE FROM products WHERE `products`.`id_product` = @id", db.GetConnection());
                        delete.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(TextBox_Delete.Text);

                        db.openConnection();

                        if (delete.ExecuteNonQuery() == 1)
                            MessageBox.Show("Товар удалён");
                        else
                            MessageBox.Show("Такого id не существует");

                        db.closeConnection();
                        TextBox_Delete.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public DeleteWindow()
        {
            InitializeComponent();
        }
    }
}
