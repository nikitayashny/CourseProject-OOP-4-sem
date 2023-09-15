using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MySql.Data.MySqlClient;

namespace Admin
{
    public partial class CatalogWindow : Window
    {
        private MySqlDataAdapter adapter;

        private DataTable table;

        private Command search;
        private Command priceSearch;
        private Command rbs_Checked;
        private Command rbm_Checked;
        private Command rbl_Checked;
        private Command change;
        private Command delete;
        private Command undo;
        private Command redo;

        public Stack<DataTable> histDone = new Stack<DataTable>();
        public Stack<DataTable> histUndone = new Stack<DataTable>();

        private bool sure;

        public ICommand Change
        {
            get
            {
                return change ?? (change = new Command(obj =>
                {
                    try
                    {
                        RBS.IsChecked = false;
                        RBM.IsChecked = false;
                        RBL.IsChecked = false;
                        TextBox_PriceSearch.Text = "";
                        TextBox_Search.Text = "";

                        bool flag = false;
                        if (TextBox_ChangePrice.Text == "")
                        {
                            TextBox_ChangePrice.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            TextBox_ChangePrice.Background = default;

                        if (flag)
                            return;

                        if (listviewProducts.SelectedItem != null)
                        {
                            Accept accept = new Accept();
                            accept.ShowDialog();
                            sure = accept.sure;

                            if (sure == false)
                                return;

                            object o = listviewProducts.SelectedItem;
                            ListViewItem lvi = (ListViewItem)listviewProducts.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = FindByName("TextBlock_id", lvi) as TextBlock;

                            if (tb != null)
                                tb.Dispatcher.BeginInvoke(new Func<bool>(tb.Focus));

                            DB db = new DB();

                            adapter = new MySqlDataAdapter();
                            table = new DataTable();

                            MySqlCommand change = new MySqlCommand("UPDATE `products` SET `price` = @price WHERE `products`.`id_product` = @id;", db.GetConnection());
                            change.Parameters.Add("@price", MySqlDbType.Int32).Value = TextBox_ChangePrice.Text;
                            change.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(tb.Text);

                            adapter.SelectCommand = change;
                            adapter.Fill(table);

                            Refresh();
                            TextBox_ChangePrice.Text = "";

                            db.openConnection();

                            adapter = new MySqlDataAdapter("SELECT * FROM `products`", db.GetConnection());
                            table = new DataTable();

                            adapter.Fill(table);
                            histDone.Push(table);

                            db.closeConnection();
                        }
                        else
                            MessageBox.Show("Не выбран элемент для изменения");
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
                        if (listviewProducts.SelectedItem != null)
                        {
                            Accept accept = new Accept();
                            accept.ShowDialog();
                            sure = accept.sure;

                            if (sure == false)
                                return;

                            object o = listviewProducts.SelectedItem;
                            ListViewItem lvi = (ListViewItem)listviewProducts.ItemContainerGenerator.ContainerFromItem(o);
                            TextBlock tb = FindByName("TextBlock_id", lvi) as TextBlock;

                            if (tb != null)
                                tb.Dispatcher.BeginInvoke(new Func<bool>(tb.Focus));

                            DB db = new DB();

                            MySqlCommand delete = new MySqlCommand("DELETE FROM products WHERE `products`.`id_product` = @id", db.GetConnection());
                            delete.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(tb.Text);

                            db.openConnection();

                            if (delete.ExecuteNonQuery() == 1)
                                MessageBox.Show("Товар удалён");
                            else
                                MessageBox.Show("Такого id не существует");

                            db.closeConnection();

                            listviewProducts.SelectedItem = null;
                            Refresh();

                            db.openConnection();

                            adapter = new MySqlDataAdapter("SELECT * FROM `products`", db.GetConnection());
                            table = new DataTable();

                            adapter.Fill(table);
                            histDone.Push(table);

                            db.closeConnection();
                        }
                        else
                            MessageBox.Show("Не выбран элемент для удаления");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

        public ICommand Search
        {
            get
            {
                return search ?? (search = new Command(obj =>
                {
                    try
                    {
                        RBS.IsChecked = false;
                        RBM.IsChecked = false;
                        RBL.IsChecked = false;
                        TextBox_PriceSearch.Text = "";
                        TextBox_ChangePrice.Text = "";

                        DB db = new DB();

                        adapter = new MySqlDataAdapter();
                        table = new DataTable();

                        MySqlCommand search = new MySqlCommand("SELECT * FROM `products` WHERE `name` LIKE @name", db.GetConnection());
                        search.Parameters.AddWithValue("@name", "%" + TextBox_Search.Text + "%");

                        adapter.SelectCommand = search;
                        adapter.Fill(table);

                        listviewProducts.ItemsSource = table.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand PriceSearch
        {
            get
            {
                return priceSearch ?? (priceSearch = new Command(obj =>
                {
                    try
                    {
                        RBS.IsChecked = false;
                        RBM.IsChecked = false;
                        RBL.IsChecked = false;
                        TextBox_ChangePrice.Text = "";
                        TextBox_Search.Text = "";

                        DB db = new DB();

                        adapter = new MySqlDataAdapter();
                        table = new DataTable();

                        MySqlCommand search = new MySqlCommand("SELECT * FROM `products` WHERE price <= @price", db.GetConnection());
                        search.Parameters.Add("@price", MySqlDbType.Int32).Value = TextBox_PriceSearch.Text;

                        adapter.SelectCommand = search;
                        adapter.Fill(table);

                        listviewProducts.ItemsSource = table.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

        public ICommand RBS_Checked
        {
            get
            {
                return rbs_Checked ?? (rbs_Checked = new Command(obj =>
                {
                    try
                    {
                        TextBox_PriceSearch.Text = "";
                        TextBox_ChangePrice.Text = "";
                        TextBox_Search.Text = "";

                        DB db = new DB();

                        adapter = new MySqlDataAdapter();
                        table = new DataTable();

                        MySqlCommand search = new MySqlCommand("SELECT * FROM `products` WHERE size = @size", db.GetConnection());
                        search.Parameters.Add("@size", MySqlDbType.VarChar).Value = RBS.Content;

                        adapter.SelectCommand = search;
                        adapter.Fill(table);

                        listviewProducts.ItemsSource = table.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

        public ICommand RBM_Checked
        {
            get
            {
                return rbm_Checked ?? (rbm_Checked = new Command(obj =>
                {
                    try
                    {
                        TextBox_PriceSearch.Text = "";
                        TextBox_ChangePrice.Text = "";
                        TextBox_Search.Text = "";

                        DB db = new DB();

                        adapter = new MySqlDataAdapter();
                        table = new DataTable();

                        MySqlCommand search = new MySqlCommand("SELECT * FROM `products` WHERE size = @size", db.GetConnection());
                        search.Parameters.Add("@size", MySqlDbType.VarChar).Value = RBM.Content;

                        adapter.SelectCommand = search;
                        adapter.Fill(table);

                        listviewProducts.ItemsSource = table.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand RBL_Checked
        {
            get
            {
                return rbl_Checked ?? (rbl_Checked = new Command(obj =>
                {
                    try
                    {
                        TextBox_PriceSearch.Text = "";
                        TextBox_ChangePrice.Text = "";
                        TextBox_Search.Text = "";

                        DB db = new DB();

                        adapter = new MySqlDataAdapter();
                        table = new DataTable();

                        MySqlCommand search = new MySqlCommand("SELECT * FROM `products` WHERE size = @size", db.GetConnection());
                        search.Parameters.Add("@size", MySqlDbType.VarChar).Value = RBL.Content;

                        adapter.SelectCommand = search;
                        adapter.Fill(table);

                        listviewProducts.ItemsSource = table.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

        public ICommand Undo
        {
            get
            {
                return undo ?? (undo = new Command(obj =>
                {
                    try
                    {

                        table = new DataTable();
                        table = histDone.Pop();
                        histUndone.Push(table);

                        listviewProducts.ItemsSource = table.DefaultView;

                        DB db = new DB();

                        db.openConnection();

                        MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM products", db.GetConnection());

                        deleteCommand.ExecuteNonQuery();

                        MySqlCommand addCommand = new MySqlCommand(
                                "INSERT INTO `products` (`id_product`, `name`, `size`, `color`, `price`, `amount`, `picture`, `date`) " +
                                "VALUES (@id_product, @name, @size, @color, @price, @amount, @picture, @date)", db.GetConnection());

                        addCommand.Parameters.AddWithValue("@id_product", "");
                        addCommand.Parameters.AddWithValue("@name", "");
                        addCommand.Parameters.AddWithValue("@size", "");
                        addCommand.Parameters.AddWithValue("@color", "");
                        addCommand.Parameters.AddWithValue("@price", "");
                        addCommand.Parameters.AddWithValue("@amount", "");
                        addCommand.Parameters.AddWithValue("@picture", "");
                        addCommand.Parameters.AddWithValue("@date", "");

                        foreach (DataRow row in table.Rows)
                        {
                            addCommand.Parameters["@id_product"].Value = row["id_product"].ToString();
                            addCommand.Parameters["@name"].Value = row["name"].ToString();
                            addCommand.Parameters["@size"].Value = row["size"].ToString();
                            addCommand.Parameters["@color"].Value = row["color"].ToString();
                            addCommand.Parameters["@price"].Value = row["price"].ToString();
                            addCommand.Parameters["@amount"].Value = row["amount"].ToString();
                            addCommand.Parameters["@picture"].Value = row["picture"].ToString();
                            addCommand.Parameters["@date"].Value = row["date"].ToString();

                            addCommand.ExecuteNonQuery();
                        }

                        db.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

        public ICommand Redo
        {
            get
            {
                return redo ?? (redo = new Command(obj =>
                {
                    try
                    {
                        table = new DataTable();
                        table = histUndone.Pop();
                        histDone.Push(table);
                        listviewProducts.ItemsSource = table.DefaultView;

                        DB db = new DB();
                        db.openConnection();

                        MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM products", db.GetConnection());
                        deleteCommand.ExecuteNonQuery();

                        MySqlCommand addCommand = new MySqlCommand(
                                "INSERT INTO `products` (`id_product`, `name`, `size`, `color`, `price`, `amount`, `picture`, `date`) " +
                                "VALUES (@id_product, @name, @size, @color, @price, @amount, @picture, @date)", db.GetConnection());

                        addCommand.Parameters.AddWithValue("@id_product", "");
                        addCommand.Parameters.AddWithValue("@name", "");
                        addCommand.Parameters.AddWithValue("@size", "");
                        addCommand.Parameters.AddWithValue("@color", "");
                        addCommand.Parameters.AddWithValue("@price", "");
                        addCommand.Parameters.AddWithValue("@amount", "");
                        addCommand.Parameters.AddWithValue("@picture", "");
                        addCommand.Parameters.AddWithValue("@date", "");

                        foreach (DataRow row in table.Rows)
                        {
                            addCommand.Parameters["@id_product"].Value = row["id_product"].ToString();
                            addCommand.Parameters["@name"].Value = row["name"].ToString();
                            addCommand.Parameters["@size"].Value = row["size"].ToString();
                            addCommand.Parameters["@color"].Value = row["color"].ToString();
                            addCommand.Parameters["@price"].Value = row["price"].ToString();
                            addCommand.Parameters["@amount"].Value = row["amount"].ToString();
                            addCommand.Parameters["@picture"].Value = row["picture"].ToString();
                            addCommand.Parameters["@date"].Value = row["date"].ToString();

                            addCommand.ExecuteNonQuery();
                        }

                        db.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

        public CatalogWindow()
        {
            InitializeComponent();
            Refresh();

            DB db = new DB();
            MySqlConnection connection = db.GetConnection();
            connection.Open();

            MySqlTransaction transaction = connection.BeginTransaction();   // транзакция (laba 8)
            MySqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = "call procselect";    // вызов процедуры  (laba 8)
                command.ExecuteNonQuery();
                transaction.Commit();

                adapter = new MySqlDataAdapter(command);
                table = new DataTable();

                adapter.Fill(table);
                histDone.Push(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }

        private void Refresh()
        {
            try
            {
                DB db = new DB();

                db.openConnection();

                adapter = new MySqlDataAdapter("call procselect", db.GetConnection());
                table = new DataTable();

                adapter.Fill(table);
                listviewProducts.ItemsSource = table.DefaultView;

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
    }
}
