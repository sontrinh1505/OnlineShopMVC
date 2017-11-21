using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopMVC.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please, enter username")]
        public string UserName { set; get; }

        [Required(ErrorMessage ="Please, enter password")]
        public string PassWord { set; get; }

        public bool RememberMe { set; get; }
    }
}