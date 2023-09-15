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
    public class ProfileVM
    {
        public Uri uri = new Uri("C:/Users/User/Desktop/CourseProjectWPF/Client/Client/languages/english.xaml", UriKind.RelativeOrAbsolute);

        private Command logIn;
        private Command orCreateAccount;
        private Command registrate;
        private Command orLogin;
        private Command engRus;
        private Command exit;
        public ICommand Exit
        {
            get
            {
                return exit ?? (exit = new Command(obj =>
                {
                    try
                    {
                        Profile profile = obj as Profile;
                        profile.shop.CurrentLogin = null;
                        profile.Success.Visibility = Visibility.Collapsed;
                        profile.StackPanelLogin.Visibility = Visibility.Visible;
                        profile.RefreshOrders();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand EngRus
        {
            get
            {
                return engRus ?? (engRus = new Command(obj =>
                {
                    try
                    {
                        if (Application.Current.Resources.MergedDictionaries[0].Source == uri)
                        {
                            Application.Current.Resources.MergedDictionaries[0].Source = new Uri("C:/Users/User/Desktop/CourseProjectWPF/Client/Client/languages/russian.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else
                            Application.Current.Resources.MergedDictionaries[0].Source = new Uri("C:/Users/User/Desktop/CourseProjectWPF/Client/Client/languages/english.xaml", UriKind.RelativeOrAbsolute);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand OrLogin
        {
            get
            {
                return orLogin ?? (orLogin = new Command(obj =>
                {
                    try
                    {
                        Profile profile = obj as Profile;
                        profile.StackPanelRegistration.Visibility = Visibility.Collapsed;
                        profile.StackPanelLogin.Visibility = Visibility.Visible;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand Registrate
        {
            get
            {
                return registrate ?? (registrate = new Command(obj =>
                {
                    try
                    {
                        Profile profile = obj as Profile;
                        bool flag = false;
                        if (profile.TextBox_Login_Registration.Text == "")
                        {
                            profile.TextBox_Login_Registration.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            profile.TextBox_Login_Registration.Background = default;
                        if (profile.PasswordBox_Password_Registration.Password == "")
                        {
                            profile.PasswordBox_Password_Registration.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            profile.PasswordBox_Password_Registration.Background = default;
                        if (profile.PasswordBox_Password_Registration_Repeat.Password == "")
                        {
                            profile.PasswordBox_Password_Registration_Repeat.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            profile.PasswordBox_Password_Registration_Repeat.Background = default;
                        if (profile.TextBox_email.Text == "")
                        {
                            profile.TextBox_email.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            profile.TextBox_email.Background = default;
                        if (!Regex.IsMatch(profile.TextBox_email.Text, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
                        {
                            profile.TextBox_email.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            flag = true;
                        }
                        else
                            profile.TextBox_email.Background = default;
                        if (profile.PasswordBox_Password_Registration.Password != profile.PasswordBox_Password_Registration_Repeat.Password)
                        {
                            MessageBox.Show("Пароли не совпадают");
                            profile.PasswordBox_Password_Registration.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            profile.PasswordBox_Password_Registration_Repeat.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                            return;
                        }

                        if (flag)
                            return;
                        else
                        {
                            string login = profile.TextBox_Login_Registration.Text;
                            string password = profile.PasswordBox_Password_Registration.Password;
                            string email = profile.TextBox_email.Text;
                            DataWorker.RegisterNewUser(login, password, email);

                            profile.shop.CurrentLogin = profile.TextBox_Login_Registration.Text;
                            profile.TextBox_Login_Registration.Text = null;
                            profile.PasswordBox_Password_Registration.Password = null;
                            profile.PasswordBox_Password_Registration_Repeat.Password = null;
                            profile.TextBox_email.Text = null;
                            profile.StackPanelLogin.Visibility = Visibility.Collapsed;
                            profile.StackPanelRegistration.Visibility = Visibility.Collapsed;
                            profile.Success.Visibility = Visibility.Visible;
                            profile.RefreshOrders();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует");
                    }
                }));
            }
        }
        public ICommand OrCreateAccount
        {
            get
            {
                return orCreateAccount ?? (orCreateAccount = new Command(obj =>
                {
                    try
                    {   Profile profile = obj as Profile;
                        profile.StackPanelLogin.Visibility = Visibility.Collapsed;
                        profile.StackPanelRegistration.Visibility = Visibility.Visible;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        public ICommand LogIn
        {
            get
            {
                return logIn ?? (logIn = new Command(obj =>
                {
                    Profile profile = obj as Profile;
                    bool flag = false;
                    if (profile.PasswordBox_Password.Password.Trim() == "")
                    {
                        profile.PasswordBox_Password.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                        flag = true;
                    }
                    else
                        profile.PasswordBox_Password.Background = default;
                    if (profile.TextBox_Login.Text.Trim() == "")
                    {
                        profile.TextBox_Login.Background = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0));
                        flag = true;
                    }
                    else
                        profile.TextBox_Login.Background = default;

                    if (flag)
                        return;
                    try
                    {
                        var count = profile.db.users
                            .Where(u => u.login == profile.TextBox_Login.Text && u.password == profile.PasswordBox_Password.Password)
                            .Count();

                        if (count > 0)
                        {
                            profile.shop.CurrentLogin = profile.TextBox_Login.Text;
                            profile.TextBox_Login.Text = null;
                            profile.PasswordBox_Password.Password = null;
                            profile.StackPanelLogin.Visibility = Visibility.Collapsed;
                            profile.StackPanelRegistration.Visibility = Visibility.Collapsed;
                            profile.Success.Visibility = Visibility.Visible;
                            profile.RefreshOrders();
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден");
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
