using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    internal class BasketViewModel : ViewModelBase
    {
        public Basket Basket;
        public BasketViewModel(Basket basket)
        {
            Basket = basket;
        }
    }
}
