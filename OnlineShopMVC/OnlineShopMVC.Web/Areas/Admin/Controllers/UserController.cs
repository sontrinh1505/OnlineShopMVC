using OnlineShopMVC.Areas.Admin.Models;
using OnlineShopMVC.Extensions;
using OnlineShopMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Data.Models;
using OnlineShopMVC.DTO;
using OnlineShopMVC.Common;

namespace OnlineShopMVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {

        IUserService _userService;

        public UserController(IUserService _userService)
        {
            this._userService = _userService;
        }

        public ActionResult Index(int page = 1, int pageSize = 10 )
        {
            var userList = _userService.GetAll().ToList();
            var userListVM = userList.OrderBy(x => x.UserName).ToListViewModel();
            var result = userListVM.ToPagedList(page, pageSize);
            return View(result);
                      
        }

        public ActionResult BlockList(int page = 1, int pageSize = 10)
        {
            var userList = _userService.GetBlockUsers().ToList();
            var userListVM = userList.OrderBy(x => x.UserName).ToListViewModel();
            var result = userListVM.ToPagedList(page, pageSize);
            return View(result);

        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            if(ModelState.IsValid)
            {

                var result = _userService.Add(user.ToModel());

                if (result != null)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Can not create user.");
                }
            }

            return View(user);
        }



        public ActionResult Edit(long id)
        {
            var user = _userService.GetById(id).ToViewModel();
            return View(user);
        }


        public ActionResult UnlockUser(long id)
        {
            var result = _userService.UnlockUser(id);
            if(result)
            {
                ModelState.AddModelError("", "Can not unlock this user.");
                
            }

            return RedirectToAction("BlockList");
        }

        public ActionResult LockUser(long id)
        {
            var result = _userService.UnlockUser(id);
            if (!result)
            {
                ModelState.AddModelError("", "Can not lock this user.");

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {

                _userService.Update(user.ToModel());
                _userService.Save();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Can not update user.");

            return View(user);
        }

        //[HttpDelete]
        //public ActionResult Delete(long id)
        //{
        //    var result = _userService.Delete(id);

        //    if(!result)
        //    {
        //        ModelState.AddModelError("","Can not delete this user.");
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public JsonResult Delete(long id)
        {
            var result = _userService.Delete(id);

            if (!result)
            {
                ModelState.AddModelError("", "Can not delete this user.");
            }
            return Json(new { status = "Success"});
        }
    }
}