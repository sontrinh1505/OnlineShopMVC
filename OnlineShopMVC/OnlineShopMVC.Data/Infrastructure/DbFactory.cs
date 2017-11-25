namespace Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private OnlineShopMVCDbContext dbContext;

        public OnlineShopMVCDbContext Init()
        {
             return dbContext ?? (dbContext = new OnlineShopMVCDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}