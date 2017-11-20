using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryModel
    {
        private OnlineShopMVCDbContext context = null;

        public CategoryModel()
        {
            context = new OnlineShopMVCDbContext();
        }

        public List<Category> ListAll()
        {
            var categories = context.Database.SqlQuery<Category>("sp_category_listAll").ToList();

            return categories;



        }
    }
}
