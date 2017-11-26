using AutoMapper;
using Data.Models;
using OnlineShopMVC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopMVC.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>().ReverseMap().MaxDepth(4);
                

            });
        }
    }
}