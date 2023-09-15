using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Basket
    {      
        public string login { get; set; }
        public string product_name { get; set; }
        [Key]
        public int id { get; set; }
        

        public Basket() { }
        public Basket(string login, string product_name)
        {
            this.login = login;
            this.product_name = product_name;
        }
    }
}
