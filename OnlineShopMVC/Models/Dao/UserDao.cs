using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;

        public UserDao()
        {
            db = new OnlineShopDbContext();
        }

        public User GetByUserName(string name)
        {
            var result = db.Users.FirstOrDefault(x => x.UserName == name);
          
            return result;
        }

        public long Inser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return user.ID;             
        }


        public int Login(string userName, string passWord)
        {
            var result = db.Users.FirstOrDefault(x => x.UserName == userName);

            if(result == null)
            {
                return 0;
            }
            else
            {
                if(!result.Status.Value)
                {
                    return -1;
                }
                else
                {
                    if(result.PassWord != passWord)
                    {
                        return -2;
                    }
                }
                
            }

            return 1;
        }
    }
}
