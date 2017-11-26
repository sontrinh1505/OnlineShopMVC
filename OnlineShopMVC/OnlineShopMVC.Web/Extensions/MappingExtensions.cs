using AutoMapper;
using Data.Models;
using OnlineShopMVC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopMVC.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        //User <-> UserViewModel
        public static User ToModel(this UserViewModel viewmodel)
        {
            return Mapper.Map<UserViewModel, User>(viewmodel);
        }

        public static UserViewModel ToViewModel(this User model)
        {
            return Mapper.Map<User, UserViewModel>(model);
        }

        public static IEnumerable<User> ToListModel(this IEnumerable<UserViewModel> viewmodel)
        {
            return Mapper.Map<IEnumerable<UserViewModel>, IEnumerable<User>>(viewmodel);
        }

        public static IEnumerable<UserViewModel> ToListViewModel(this IEnumerable<User> model)
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(model);
        }
    }
}