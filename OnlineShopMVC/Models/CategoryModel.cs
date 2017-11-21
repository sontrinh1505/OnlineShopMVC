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

        public int Create(Category category)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", category.Name),
                new SqlParameter("@Alias", category.Alias),
                new SqlParameter("@ParentId", category.ParentId),
                new SqlParameter("@Order", category.Order),
                new SqlParameter("@Status", category.Status),
            };

            var res = context.Database.ExecuteSqlCommand("sp_Category_Insert @Name, @Alias, @ParentId, @Order, @Status", parameters);

            return res;
        }


        
    }
}
