using System;
using System.Windows;
using System.Windows.Input;

namespace Admin
{
    public partial class Accept : Window
    {
        private Command back;
        private Command accept;
        public bool sure;

        public ICommand Back
        {
            get
            {
                return back ?? (back = new Command(obj =>
                {
                    try
                    {
                        sure = false;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

        public ICommand AcceptCommand
        {
            get
            {
                return accept ?? (accept = new Command(obj =>
                {
                    try
                    {
                        sure = true;

                        if (cbSampleYes.IsChecked == true && cbSampleSure.IsChecked == true)
                            Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

        public Accept()
        {
            InitializeComponent();
        }
    }
}