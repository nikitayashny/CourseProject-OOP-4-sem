using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public string login { get; set; }
        public string product_name { get; set; }
        public string status { get; set; }
        public string card_number { get; set; }
        public string holder_name { get; set; }
        public string expiration_date { get; set; }
        public int CVV { get; set; }
        public string date { get; set; }

        public Order() { }
        public Order(string login, string product_name, string status, string card_number, string holder_name, string expiration_date, int CVV, string date)
        {
            this.login = login;
            this.product_name = product_name;
            this.status = status;
            this.card_number = card_number;
            this.holder_name = holder_name;
            this.expiration_date = expiration_date;
            this.CVV = CVV;
            this.date = date;
        }
    }
}
