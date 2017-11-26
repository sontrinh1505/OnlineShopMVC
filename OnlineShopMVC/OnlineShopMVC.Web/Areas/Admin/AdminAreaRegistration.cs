﻿using System.Web.Mvc;

namespace OnlineShopMVC.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, controller = "Admin" },
                new[] { "OnlineShopMVC.Areas.Admin.Controllers" }
            );

            //context.MapRoute(
            //    "Login",
            //    "Login/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional, controller = "Login" },
            //    new[] { "OnlineShopMVC.Areas.Admin.Controllers" }
            //);

            //context.MapRoute(
            //    "User",
            //    "User/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional, controller = "User" },
            //    new[] { "OnlineShopMVC.Areas.Admin.Controllers" }
            //);
        }
    }
}