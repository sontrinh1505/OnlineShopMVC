﻿using OnlineShopMVC.Areas.Admin.Models;
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

namespace OnlineShopMVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {

        IUserService _userService;

        public UserController(IUserService _userService)
        {
            this._userService = _userService;
        }


        // GET: Admin/Account
        public ActionResult Index(int page = 1, int pageSize = 10 )
        {
            var userList = _userService.GetAll().ToList();
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
    }
}