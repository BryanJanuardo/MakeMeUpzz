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

        public static User GetUserByEmail(string email)
        {
            return (from User in UserRepository.getAllUser() where User.UserEmail.ToUpper().Equals(email.ToUpper()) select User).FirstOrDefault();
        }

        public static User getUserByCredentials(string email, string password)
        {
            return (from User in UserRepository.getAllUser() where User.UserEmail.ToUpper().Equals(email.ToUpper()) && User.UserPassword.Equals(password) select User).FirstOrDefault();

        }

        public static string loginValidation(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "Email must be filled";
        }

            if (string.IsNullOrEmpty(password))
            {
                return "Password must be filled";
            }

            User validateUser = UserController.GetUserByEmail(email);

            if (validateUser == null)
            {
                return "Incorrect email or password";
            }
            else if (!validateUser.UserEmail.ToUpper().Equals(email.ToUpper()))
            {
                return "Incorrect email or password";
            }

            if (!validateUser.UserPassword.Equals(password))
            {
                return "Incorrect email or password";
            }

            return "";
        }
    }
}