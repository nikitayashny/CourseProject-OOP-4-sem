using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace Admin
{
    public partial class AddWindow : Window
    {
        private Command add;
        private Command back;
        //         <TextBox x:Name="TextBox_picture" materialDesign:HintAssist.Hint="{DynamicResource m_ImageURL}" Height="50" Margin="10" BorderBrush="Black" BorderThickness="2" FontFamily="Nunito" FontSize="18" FontWeight="Light" Padding="10"/>
        string filepath = "";
        DateTime date = DateTime.Now;


        public ICommand Add
        {
            get
            {
                return add ?? (add = new Command(obj =>
                {
                    try
                    {
                        bool flag = false;
                        if (TextBox_name.Text == "")
                        {
                            TextBox_name.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            TextBox_name.Background = default;
                        if (TextBox_size.Text == "")
                        {
                            TextBox_size.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            TextBox_size.Background = default;
                        if (TextBox_color.Text == "")
                        {
                            TextBox_color.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            TextBox_color.Background = default;
                        if (TextBox_price.Text == "")
                        {
                            TextBox_price.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            TextBox_price.Background = default;
                        if (TextBox_amount.Text == "")
                        {
                            TextBox_amount.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            TextBox_amount.Background = default;
                        if (filepath == "")
                        {
                            MessageBox.Show("Выберите картинку");
                            flag = true; 
                        }
                       

                        if (flag)
                            return;
                        else
                        {
              
                            

                            DB db = new DB();
                            MySqlCommand addCommand = new MySqlCommand(
                                "INSERT INTO `products` (`name`, `size`, `color`, `price`, `amount`, `picture`, date) " +
                                "VALUES (@name, @size, @color, @price, @amount, @picture, @date)", db.GetConnection());

                            addCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = TextBox_name.Text;
                            addCommand.Parameters.Add("@size", MySqlDbType.VarChar).Value = TextBox_size.Text;
                            addCommand.Parameters.Add("@color", MySqlDbType.VarChar).Value = TextBox_color.Text;
                            addCommand.Parameters.Add("@price", MySqlDbType.Int32).Value = Convert.ToInt32(TextBox_price.Text);
                            addCommand.Parameters.Add("@amount", MySqlDbType.Int32).Value = Convert.ToInt32(TextBox_amount.Text);
                            addCommand.Parameters.Add("@picture", MySqlDbType.VarChar).Value = filepath;
                            addCommand.Parameters.Add("@date", MySqlDbType.VarChar).Value = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();

                            db.openConnection();

                            if (addCommand.ExecuteNonQuery() == 1)
                                MessageBox.Show("Товар добавлен");
                            else
                                MessageBox.Show("Товар не добавлен");

                            db.closeConnection();

                            RefreshFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

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

        public AddWindow()
        {
            InitializeComponent();
        }

        private void RefreshFields()
        {
            TextBox_name.Text = "";
            TextBox_size.Text = "";
            TextBox_amount.Text = "";
            TextBox_color.Text = "";
            filepath = "";
            TextBox_price.Text = "";
        }

        private void enterImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog path = new OpenFileDialog();
            if (path.ShowDialog() == true)
            {
                filepath = path.FileName;
            }
             
        }
    }
}