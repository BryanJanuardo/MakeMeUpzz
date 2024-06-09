using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class UserHandler
    {
        public static int GenerateUserId()
        {
            int newUserId;
            string lastUsername = (from x in getAllUser() select x.Username).ToList().LastOrDefault();
            if (lastUsername == null)
            {
                newUserId = 1;
                return newUserId;
            }
            else
            {
                int lastId = (from User in getAllUser() select User.UserID).LastOrDefault();
                newUserId = lastId + 1;
                return newUserId;
            }

        }

        public static void insertNewUser(string email, string password, string username, string userDOB, string userGender)
        {
            User newUser = UserFactory.createUser(GenerateUserId(), email, password, username, userDOB, userGender);
            UserRepository.insertNewUser(newUser);
        }

        public static List<User> getAllUser()
        {
            List<User> users = UserRepository.getAllUser();
            return users;
        }
    }
}