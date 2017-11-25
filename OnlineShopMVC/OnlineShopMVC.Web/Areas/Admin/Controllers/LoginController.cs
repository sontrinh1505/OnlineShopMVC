
using OnlineShopMVC.Areas.Admin.Models;
using OnlineShopMVC.Common;
using OnlineShopMVC.Service;
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

        IUserService _userService;

        public LoginController(IUserService _userService)
        {
            this._userService = _userService;
        }


        // GET: Admin/Login

        [HttpGet]
        public ActionResult Index()
        {           
            return View();
        }




        //login su dung store procedure, session, authcookie
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(LoginModel login)
        //{
        //    //var result = new AccountModel().Login(login.UserName, login.PassWord);

        //    if(Membership.ValidateUser(login.UserName, login.PassWord) && ModelState.IsValid)
        //    {
        //        //SessionHelper.SetSession(new UserSession() { UserName = login.UserName });
        //        FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Incorrect username or password");
        //    }

        //    return View(login);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Login(login.UserName, Encryptor.MD5Hash(login.PassWord));
                if (result == 1)
                {
                    var user = _userService.GetUserByUserName(login.UserName);
                    var userSession = new UserLogin()
                    {
                        UserID = user.ID,
                        UserName = user.UserName
                    };
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Admin");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "The username don't exist");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "The User is blocking");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Incorect password");
                }

            }
            return View();
        }

        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();

        //    return RedirectToAction("Index","Login");
        //}


        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            
            return RedirectToAction("index", "login");
        }
        
    }
}