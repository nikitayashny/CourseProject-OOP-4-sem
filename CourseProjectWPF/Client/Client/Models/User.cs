using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public User() { }
        public User(string login, string password, string email)
        {        
            this.login = login;
            this.password = password;
            this.email = email;
        }
    }
}
