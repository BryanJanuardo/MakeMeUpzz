using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class UserController
    {

        public static string ValidationCheck(string email, string password, string confirmPassword, string username, string userDOB, string gender)
        {
            if (string.IsNullOrEmpty(email) | string.IsNullOrEmpty(password) | string.IsNullOrEmpty(confirmPassword) | string.IsNullOrEmpty(username) | string.IsNullOrEmpty(userDOB))
            {
                return "All fields must be filled";
            }

            if (String.Compare(gender, "None") == 0)
            {
                return "Gender must not be empty";
            }

            string validateEmail = (from User in getAllUser() where User.UserEmail.ToUpper().Equals(email.ToUpper()) select User.UserEmail).FirstOrDefault();

            if (validateEmail != null && validateEmail.ToUpper().Equals(email.ToUpper()))
            {
                return "Email already exists";
            }

            if (string.Compare(email.Substring(email.Length - 4, 4), ".com") != 0)
            {
                return "Email must be valid";
            }

            if (password != confirmPassword)
            {
                return "Password and Confirmation Password is different";
            }

            if (username.Length < 5 || username.Length > 15)
            {
                return "Username must be in between 5 to 15 characters";
            }

            string validateUsername = (from x in getAllUser() where x.Username.Equals(username) select x.Username).FirstOrDefault();

            if (validateUsername != null && validateUsername.Equals(username))
            {
                return "Username already exists";
            }

            return "";

        }

        public static void insertNewUser(string email, string password, string username, string userDOB, string userGender)
        {
           UserHandler.insertNewUser(email, password, username, userDOB, userGender);
        }

        public static List<User> getAllUser()
        {
            List<User> users = UserRepository.getAllUser();
            return users;
        }
    }
}