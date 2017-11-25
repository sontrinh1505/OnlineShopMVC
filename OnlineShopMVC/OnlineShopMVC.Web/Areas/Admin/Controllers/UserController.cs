using OnlineShopMVC.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string a)
        {
            if(ModelState.IsValid)
            {
                //var userDao = new UserDao();

                //user.PassWord = Encryptor.MD5Hash(user.PassWord);
                //user.CreatedDate = DateTime.Now;
                //user.CreatedBy = SessionHelper.GetSession().UserID.ToString();
                //var result = userDao.Insert(user);

                //if(result > 0)
                //{
                //    return RedirectToAction("Index", "Account");
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Can not create user.");
                //}
            }

            return View();
        }
    }
}