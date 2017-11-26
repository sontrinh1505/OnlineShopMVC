using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Data.Repositories;
using OnlineShopMVC.Common;
using Data.Models;
using PagedList;

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

        IEnumerable<User> GetAllPaging(int page, int pageSize);

        IEnumerable<User> GetAll(string keyWord);

        IEnumerable<User> Search(string keyWord, int page, int pageSize, string sort, out int totalRow);

        User GetById(long id);

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

        public User Add(User user)
        {
            user.CreatedBy = SessionHelper.GetSession().UserID;
            user.CreatedDate = DateTime.Now;
            user.PassWord = Encryptor.MD5Hash(user.PassWord);
            var result = _userRepository.Add(user);
            _unitOfWork.Commit();

            return result;
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

        public User GetById(long id)
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
            User.ModifiedBy = SessionHelper.GetSession().UserID;
            User.ModifiedDate = DateTime.Now;
            _userRepository.Update(User);
        }

        public IEnumerable<User> GetAllPaging(int page, int pageSize)
        {
            var query = _userRepository.GetMulti(x => x.Status == true).OrderBy(x => x.UserName).ToList();
             
            return query.ToPagedList(page, pageSize);
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
