using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class UserFactory
    {
        public static User createUser(int userId, string email, string password, string username, string userDOB, string userGender)
        {
            User newUser = new User()
            {
                UserID = userId,
                Username = username,
                UserEmail = email,
                UserDOB = DateTime.Parse(userDOB),
                UserGender = userGender,
                UserRole = "User",
                UserPassword = password
            };
            return newUser;
        }
    }
}