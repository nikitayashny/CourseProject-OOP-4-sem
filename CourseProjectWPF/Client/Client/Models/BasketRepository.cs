using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Client
{
    public class BasketRepository : IRepository<Basket>
    {
        private AppContext db;
        public BasketRepository(AppContext context)
        {
            this.db = context;
        }
        public IEnumerable<Basket> GetAll()
        {
            return db.baskets;
        }
        public Basket Get(int id)
        {
            return db.baskets.Find(id);
        }
        public void Create(Basket basket)
        {
            db.baskets.Add(basket);
        }
       
        public void Delete(int id)
        {
            Basket basket = db.baskets.Find(id);
            if (basket != null)
            {
                db.baskets.Remove(basket);
            }
        }
    }
}
