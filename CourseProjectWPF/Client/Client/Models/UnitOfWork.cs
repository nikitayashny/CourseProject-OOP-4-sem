using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class UnitOfWork : IDisposable
    {
        private AppContext db = new AppContext();
        private BasketRepository basketRepository;
        private FavoriteRepository favoriteRepository;

        public BasketRepository Baskets
        {
            get
            {
                if (basketRepository == null)
                    basketRepository = new BasketRepository(db);
                return basketRepository;
            }
        }
        public FavoriteRepository Favorites
        {
            get
            {
                if (favoriteRepository == null)
                    favoriteRepository = new FavoriteRepository(db);
                return favoriteRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
