using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class UserHandler
    {
        public static Response<int> GenerateUserId()
        {
            int newUserId;
            string lastUsername = (from x in UserRepository.getAllUser() select x.Username).ToList().LastOrDefault();
            if (lastUsername == null)
            {
                newUserId = 1;
            }
            else
            {
                int lastId = (from User in UserRepository.getAllUser() select User.UserID).LastOrDefault();
                newUserId = lastId + 1;
            }
            return Response<int>.createResponse("Generate new id success", true, newUserId);
        }

        public static Response<User> insertNewUser(string email, string password, string username, string userDOB, string userGender)
        {
            User newUser = UserFactory.createUser(GenerateUserId().value, email, password, username, userDOB, userGender);
            UserRepository.insertNewUser(newUser);

            return Response<User>.createResponse("Insert new user success", true, null);
        }

        public static Response<List<User>> getAllUser()
        {
            List<User> users = UserRepository.getAllUser();
            return Response<List<User>>.createResponse("Get all user success!", true, users);
        }

        public static Response<User> GetUserByEmail(string email)
        {
            User user = (from User in UserRepository.getAllUser() where User.UserEmail.ToUpper().Equals(email.ToUpper()) select User).FirstOrDefault();
            if(user == null)
            {
                return Response<User>.createResponse("Get user by email fail", false, null);
            }
            else
            {
                return Response<User>.createResponse("Get user by email success!", true, user);
            }
        }
        public static Response<User> getUserByCredentials(string email, string password)
        {
            User user = (from User in UserRepository.getAllUser() where User.UserEmail.ToUpper().Equals(email.ToUpper()) && User.UserPassword.Equals(password) select User).FirstOrDefault();
            return Response<User>.createResponse("Get user by credentials success!", true , user);
        }

        public static Response<User> getUserByUserId(int id)
        {
            User user = (from x in UserRepository.getAllUser() where x.UserID == id select x).FirstOrDefault();
            return Response<User>.createResponse("Get user by user id success!", true, user);
        }

        public static Response<User> updateUserProfile(int userID, string username, string email, string gender, DateTime dob)
        {
            UserRepository.updateUserProfile(userID, username, email, gender, dob);
            return Response<User>.createResponse("Update user profile success!", true, null);
        }

        public static Response<User> updateUserPassword(int userID, string oldPassword, string newPassword)
        {
            UserRepository.updateUserPassword(userID, oldPassword, newPassword);
            return Response<User>.createResponse("Update user password success!", true, null);
        }
    }
}