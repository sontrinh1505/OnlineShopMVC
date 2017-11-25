namespace Data.Migrations
{
    using Models.Model;
    using OnlineShopMVC.Common;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.OnlineShopMVCDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.OnlineShopMVCDbContext context)
        {
            CreateUser(context);
        }


        private void CreateUser(Data.OnlineShopMVCDbContext context)
        {
            if (context.Users.Count() == 0)
            {
              
                var user = new User()
                {
                    UserName = "admin",
                    PassWord = Encryptor.MD5Hash("123456"),
                    Email = "Administrator@gmail.com",
                    Address = "Binh Phuoc, Viet Nam",
                    CreatedDate = DateTime.Now,
                    Status = true

                };

                context.Users.Add(user);
                context.SaveChanges();
            }

        }

    }
}
