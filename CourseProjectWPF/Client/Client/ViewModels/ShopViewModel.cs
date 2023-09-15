using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Client.ViewModels
{
    internal class ShopViewModel
    {
        public ObservableCollection<ProductViewModel> ProductsList { get; set; }

        public ShopViewModel(List<Product> products)
        {
            ProductsList = new ObservableCollection<ProductViewModel>(products.Select(p => new ProductViewModel(p)));
        }
    }
}
