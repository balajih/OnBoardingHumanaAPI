using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnBoardingHumanaAPI.Models;

namespace OnBoardingHumanaAPI.DAL
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int id);
        void InsertUser(User user);
        void DeleteUser(int userID);
        void UpdateUser(User user);
        void Save();
    }
}