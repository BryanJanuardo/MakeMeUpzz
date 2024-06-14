using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Controllers
{
    public class UserController
    {

        public static Response<User> ValidationCheck(string email, string password, string confirmPassword, string username, string userDOB, string gender)
        {
            if (string.IsNullOrEmpty(email) | string.IsNullOrEmpty(password) | string.IsNullOrEmpty(confirmPassword) | string.IsNullOrEmpty(username) | string.IsNullOrEmpty(userDOB))
            {
                return Response<User>.createResponse("All fields must be filled", false, null);
            }

            if (String.Compare(gender, "None") == 0)
            {
                return Response<User>.createResponse("Gender must not be empty", false, null);
            }

            string validateEmail;
            Response<User> response = GetUserByEmail(email);
            if(response.success == false)
            {
                validateEmail = null;
            }
            else
            {
                validateEmail = response.value.UserEmail;
            }
            

            if (validateEmail != null && validateEmail.ToUpper().Equals(email.ToUpper()))
            {
                return Response<User>.createResponse("Email already exists", false, null);
            }

            if (string.Compare(email.Substring(email.Length - 4, 4), ".com") != 0)
            {
                return Response<User>.createResponse("Email must be valid", false, null);
            }

            if (password != confirmPassword)
            {
                return Response<User>.createResponse("Password and Confirmation Password is different", false, null);
            }

            if (username.Length < 5 || username.Length > 15)
            {
                return Response<User>.createResponse("Username must be in between 5 to 15 characters", false, null);
            }

            string validateUsername = (from x in getAllUser().value where x.Username.Equals(username) select x.Username).FirstOrDefault();

            if (validateUsername != null && validateUsername.Equals(username))
            {
                return Response<User>.createResponse("Username already exists", false, null);
            }

            return Response<User>.createResponse("Validation user success!", true, null);

        }

        public static Response<User> insertNewUser(string email, string password, string username, string userDOB, string userGender)
        {
            Response<User> response = UserHandler.insertNewUser(email, password, username, userDOB, userGender);
            return response;
        }

        public static Response<List<User>> getAllUser()
        {
            Response<List<User>> response = UserHandler.getAllUser();
            return response;
        }

        public static Response<User> GetUserByEmail(string email)
        {
            Response<User> response = UserHandler.GetUserByEmail(email);
            return response;
        }

        public static Response<User> getUserByCredentials(string email, string password)
        {
            Response<User> response = UserHandler.getUserByCredentials(email, password);
            return response;
        }

        public static Response<User> getUserByUserId(int id)
        {
            Response<User> response = UserHandler.getUserByUserId(id);
            return response;
        }

        public static Response<User> loginValidation(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                return Response<User>.createResponse("Email must be filled!", false, null);
            }

            if (string.IsNullOrEmpty(password))
            {
                return Response<User>.createResponse("Password must be filled!", false, null);
            }

            User validateUser = UserController.GetUserByEmail(email).value;

            if (validateUser == null)
            {
                return Response<User>.createResponse("User not found!", false, null);
            }
            else if (!validateUser.UserEmail.ToUpper().Equals(email.ToUpper()))
            {
                return Response<User>.createResponse("Email not found!", false, null);
            }
            if (!validateUser.UserPassword.Equals(password))
            {
                return Response<User>.createResponse("Incorrect password", false, null);
            }

            return Response<User>.createResponse("Login Success", true, null);
        }

        public static void LoadCustomerData(GridView customerData)
        {
            var customerDataList = getAllUser().value;
            customerData.DataSource = customerDataList;
            customerData.DataBind();
        }

        public static Response<User> updateProfileValidation(string username, string email, string gender, string dob)
        {
            if (username.Length < 5 || username.Length > 15)
            {
                return Response<User>.createResponse("Username must be in between 5 to 15 characters", false, null);
            }

            if (string.Compare(email.Substring(email.Length - 4, 4), ".com") != 0)
            {
                return Response<User>.createResponse("Email must be valid and end with '.com'", false, null);
            }

            if (String.Compare(gender, "None") == 0)
            {
                return Response<User>.createResponse("Gender must not be empty", false, null);
            }

            if (string.IsNullOrEmpty(dob))
            {
                return Response<User>.createResponse("Date of Birth cannot be empty", false, null);
            }

            return Response<User>.createResponse("Validation update profile success!", true, null);
        }

        public static Response<User> updatePasswordValidation(string currentPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(currentPassword))
            {
                return Response<User>.createResponse("Password cannot be empty", false, null);
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                return Response<User>.createResponse("New password cannot be empty", false, null);
            }
            return Response<User>.createResponse("Validation update password success!", true, null);
        }

        public static Response<User> updateUserProfile(int userID, string username, string email, string gender, DateTime dob)
        {
            Response<User> response = UserHandler.updateUserProfile(userID, username, email, gender, dob);
            return response;
        }

        public static Response<User> updateUserPassword(int userID, string oldPassword, string newPassword)
        {
            Response<User> response = UserHandler.updateUserPassword(userID, oldPassword, newPassword);
            return response;
        }
    }
}