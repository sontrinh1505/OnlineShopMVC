using Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OnlineShopMVCDbContext: DbContext
    {
        public OnlineShopMVCDbContext() : base ("OnlineShopMVCDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer<OnlineShopMVCDbContext>(new CreateDatabaseIfNotExists<OnlineShopMVCDbContext>());
        }


        public  DbSet<About> Abouts { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Contact> Contacts { get; set; }
        public  DbSet<Content> Contents { get; set; }
        public  DbSet<ContentTag> ContentTags { get; set; }
        public  DbSet<Feedback> Feedbacks { get; set; }
        public  DbSet<Footer> Footers { get; set; }
        public  DbSet<Menu> Menus { get; set; }
        public  DbSet<MenuType> MenuTypes { get; set; }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<ProductCategory> ProductCategories { get; set; }
        public  DbSet<Slide> Slides { get; set; }
        public  DbSet<SystemConfig> SystemConfigs { get; set; }
        public  DbSet<Tag> Tags { get; set; }
        public  DbSet<User> Users { get; set; }

        public static OnlineShopMVCDbContext Create()
        {
            return new OnlineShopMVCDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }

    }
}
