using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Review
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string review { get; set; }
        public Review() { }
        public Review(string name, string review)
        {
            this.name = name;
            this.review = review;
        }
    }
}
