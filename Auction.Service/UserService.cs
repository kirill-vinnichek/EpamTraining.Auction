using Auction.Data.Infrastructure;
using Auction.Data.Repository;
using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Service
{
    public interface IUserService
    {
        User GetUser(int id);
        User GetUserByEmail(string email);
        void Update(User user);
        bool CreateUser(User user);
        bool CanMakeBet(User user, decimal amount);
        IEnumerable<User> Search(string search);
    }


    public class UserService : IUserService
    {
        private IUnitOfWork uof;
        private IUserRepository userRepository;
        
        public UserService(IUnitOfWork uof, IUserRepository userRepository)
        {
            this.uof = uof;
            this.userRepository = userRepository;
        }

        public User GetUser(int id)
        {
            return userRepository.GetById(id);
        }

        public bool CreateUser(User user)
        {
            if (user.UserId != 0) return false;
            userRepository.Add(user);
            uof.Commit();
            return true;
        }



        public User GetUserByEmail(string email)
        {
            return userRepository.Get(u => u.Email.Contains(email));
        }

        public void Save()
        {
            uof.Commit();
        }

        public void Update(User user)
        {
           userRepository.Update(user);
            uof.Commit();
        }

        public IEnumerable<User> Search(string search)
        {
            var s = search.ToLower();
            return userRepository.GetMany(u => u.FirstName.ToLower().Contains(s) ||  u.LastName.ToLower().Contains(s) || u.Email.ToLower().Contains(s));
        }

        public bool CanMakeBet(User user,decimal amount)
        {
            if (user.Cash < amount)
                return false;
            return true;
        }
    }

}
