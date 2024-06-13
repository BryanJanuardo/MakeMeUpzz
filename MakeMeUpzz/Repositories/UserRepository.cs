using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class UserRepository
    {
        public static List<User> getAllUser()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.Users.ToList();
        }

        public static void insertNewUser(User newUser)
        {
            DatabaseContextEntities db = Singleton.getDB();
            db.Users.Add(newUser);
            db.SaveChangesAsync();
        }

        public static string updateUserProfile(int userID, string username, string email, string gender, DateTime dob)
        {
            DatabaseContextEntities db = Singleton.getDB();
            User toUpdateUser = (from user in db.Users where user.UserID == userID select user).FirstOrDefault();
            if (toUpdateUser != null)
            {

                toUpdateUser.Username = username;
                toUpdateUser.UserEmail = email;
                toUpdateUser.UserGender = gender;
                toUpdateUser.UserDOB = dob;
                db.SaveChanges();
                return "Successfully updated the new profile";
            }
            return "Fail to update the user profile";

        }

        public static void updateUserPassword(int userID, string oldPassword, string newPassword)
        {
            DatabaseContextEntities db = Singleton.getDB();
            User toUpdatePassword = (from user in db.Users where user.UserID == userID && user.UserPassword == oldPassword select user).FirstOrDefault();

            if (toUpdatePassword != null)
            {

                toUpdatePassword.UserPassword = newPassword;
                db.SaveChanges();
            }
        }
    }
}