using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class FavoriteRepository : IRepository<Favorite>
    {
        private AppContext db;
        public FavoriteRepository(AppContext context)
        {
            this.db = context;
        }
        public IEnumerable<Favorite> GetAll()
        {
            return db.favorites;
        }
        public Favorite Get(int id)
        {
            return db.favorites.Find(id);
        }
        public void Create(Favorite favorite)
        {
            db.favorites.Add(favorite);
        }

        public void Delete(int id)
        {
            Favorite favorite = db.favorites.Find(id);
            if (favorite != null)
            {
                db.favorites.Remove(favorite);
            }
        }
    }
}
