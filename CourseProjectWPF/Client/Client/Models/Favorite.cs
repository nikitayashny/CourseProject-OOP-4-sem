using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Favorite
    {
        public string login { get; set; }
        public string product_name { get; set; }
        [Key]
        public int id { get; set; }

        public Favorite() { }
        public Favorite(string login, string product_name)
        {
            this.login = login;
            this.product_name = product_name;
        }
    }
}
