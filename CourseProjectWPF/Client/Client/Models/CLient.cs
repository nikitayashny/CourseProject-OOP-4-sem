using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class CLient
    {
        [Key]
        public int id{ get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public CLient() { }
        public CLient(string login, string name, string address, string phone)
        {
            this.login = login;
            this.name = name;
            this.address = address;
            this.phone = phone;
        }
    }
}
