using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.Views;

namespace Client.ViewModels
{
    class ProductViewModel : ViewModelBase
    {
        public Product Product;

        public ProductViewModel(Product product)
        {
            Product = product;
        }
    }
}
