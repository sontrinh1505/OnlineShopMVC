using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMVC.Areas.Admin.Controllers
{
    //[Authorize]
    public class AdminController : BaseController
    {
        public AdminController()
        {
            
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}