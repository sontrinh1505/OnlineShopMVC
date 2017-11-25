﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Model;
using Data.Infrastructure;
using Data.Repositories;
using OnlineShopMVC.Common;

namespace OnlineShopMVC.Service
{
    public interface IUserService
    {

        int Login(string UserName, string Password);

        User Add(User User);

        void Update(User User);

        User Delete(int id);

        User GetUserByUserName(string UserName);

        IEnumerable<User> GetAll();

        IEnumerable<User> GetAllPaging(int page, int pageSize, string sort, out int totalRow);

        IEnumerable<User> GetAll(string keyWord);

        IEnumerable<User> Search(string keyWord, int page, int pageSize, string sort, out int totalRow);

        User GetById(int id);

        void Save();
    }
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public User Add(User User)
        {
            var user = _userRepository.Add(User);
            _unitOfWork.Commit();

            return user;
        }

        public User Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetAll(string keyWord)
        {
            string[] includes = { "MenuGroup" };
            if (!string.IsNullOrEmpty(keyWord))
                return _userRepository.GetMulti(x => x.Name.Contains(keyWord), includes);
            else
                return _userRepository.GetAll(includes);
        }

        public User GetById(int id)
        {
            return _userRepository.GetSingleById(id);
        }

       

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<User> Search(string keyWord, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _userRepository.GetMulti(x => x.Status == true && x.Name.Contains(keyWord));
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void Update(User User)
        {
            _userRepository.Update(User);
        }

        public IEnumerable<User> GetAllPaging(int page, int pageSize, string sort, out int totalRow)
        {
            var query = _userRepository.GetMulti(x => x.Status == true).ToList();
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public int Login(string UserName, string Password)
        {
            var user = GetUserByUserName(UserName);
            if(user == null)
            {
                return 0;
            }
            if (user.Status == false)
                return -1;
            else
            {
                if(user.PassWord != Password)
                {
                    return -2;
                }
            }
            
            return 1;
        }

        public User GetUserByUserName(string UserName)
        {
            return _userRepository.GetSingleByCondition(x => x.UserName == UserName);
        }
    }
}
