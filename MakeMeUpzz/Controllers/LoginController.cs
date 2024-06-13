using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class LoginController
    {
        DatabaseContextEntities db = new DatabaseContextEntities();
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