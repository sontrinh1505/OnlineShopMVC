using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountModel
    {
        private OnlineShopMVCDbContext context = null;

        public AccountModel()
        {
            context = new OnlineShopMVCDbContext();
        }

        public bool Login(string UserName, string PassWord)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@PassWord", PassWord)
            };
            var res = context.Database.SqlQuery<bool>("Account_Login @UserName, @PassWord", sqlParams).SingleOrDefault();

            return res;

        }
    }
}
