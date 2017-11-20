using Models;
using OnlineShopMVC.Areas.Admin.Code;
using OnlineShopMVC.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShopMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            //var result = new AccountModel().Login(login.UserName, login.PassWord);

            if(Membership.ValidateUser(login.UserName, login.PassWord) && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { UserName = login.UserName });
                FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect username or password");
            }

            return View(login);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            
            return RedirectToAction("Index","Login");
        }
    }
}