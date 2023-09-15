using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Product
    {
        [Key]
        public int id_product { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public int price { get; set; }
        public int amount{ get; set; }
        public string picture{ get; set; }
        public string date{ get; set; }

        public Product() { }
        public Product(int id_product, string name, string size, string color, int price, int amount, string picture, string date)
        {
            this.id_product = id_product;
            this.name = name;
            this.size = size;
            this.color = color;
            this.price = price;
            this.amount = amount;
            this.picture = picture;
            this.date = date;
        }
    }
}
