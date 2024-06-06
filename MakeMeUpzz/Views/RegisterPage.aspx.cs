using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        DatabaseContextEntities db = new DatabaseContextEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            FailLbl.Visible = false;
        }

        protected bool ValidationCheck(string email, string password, string confirmPassword, string username, string userDOB)
        {
            if (string.IsNullOrEmpty(email) | string.IsNullOrEmpty(password) | string.IsNullOrEmpty(confirmPassword) | string.IsNullOrEmpty(username) | string.IsNullOrEmpty(userDOB))
            {
                FailLbl.Text = "All fields must be filled";
                FailLbl.Visible = true;
                return false;
            }

            if (String.Compare(GetGender(), "None") == 0)
            {
                FailLbl.Text = "Gender must not be empty";
                FailLbl.Visible = true;
                return false;
            }

            string validateEmail = (from User in db.Users where User.UserEmail.ToUpper().Equals(email.ToUpper()) select User.UserEmail).FirstOrDefault();

            if (validateEmail != null && validateEmail.ToUpper().Equals(email.ToUpper()))
            {
                FailLbl.Text = "Email already exists";
                FailLbl.Visible = true;
                return false;
            }

            if (string.Compare(email.Substring(email.Length - 4, 4), ".com") != 0)
            {
                FailLbl.Text = "Email must be valid";
                FailLbl.Visible = true;
                return false;
            }

            if (password != confirmPassword)
            {
                FailLbl.Text = "Password and Confirmation Password is different";
                FailLbl.Visible = true;
                return false;
            }

            if (username.Length < 5 || username.Length > 15)
            {
                FailLbl.Text = "Username must be in between 5 to 15 characters";
                FailLbl.Visible = true;
                return false;
            }

            string validateUsername = (from x in db.Users where x.Username.Equals(username) select x.Username).FirstOrDefault();

            if (validateUsername != null && validateUsername.Equals(username))
            {
                FailLbl.Text = "Username already exists";
                FailLbl.Visible = true;
                return false;
            }

            return true;

        }

        protected int GenerateUserId()
        {
            int newUserId;
            string lastUsername = (from x in db.Users select x.Username).ToList().LastOrDefault();
            if (lastUsername == null)
            {
                newUserId = 1;
                return newUserId;
            }
            else
            {
                int lastId = (from User in db.Users select User.UserID).LastOrDefault();
                newUserId = lastId + 1;
                return newUserId;
            }
            
        }

        protected string GetGender()
        {
            if (RadioMale.Checked)
            {
                return "Male";
            }
            else if(RadioFemale.Checked)
            {
                return "Female";
            }
            else
            {
                return "None";
            }
        }

        protected void InsertNewUser(string email, string password, string username, string userDOB, string userGender)
        {
            int userId = GenerateUserId();
            User newUser = new User();
            newUser.UserID = userId;
            newUser.Username = username;
            newUser.UserEmail = email;
            newUser.UserDOB = DateTime.Parse(userDOB);
            newUser.UserGender = userGender;
            newUser.UserRole = "User";
            newUser.UserPassword = password;

            db.Users.Add(newUser);
            db.SaveChangesAsync();
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void RegistBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text.ToString();
            string username = UsernameTxt.Text.ToString();
            string password = PasswordTxt.Text.ToString();
            string confirmPassword = ConfirmTxt.Text.ToString();
            string userDOB = DOBDate.Text.ToString();
            FailLbl.Text = "";
            FailLbl.Visible = false;

            if (ValidationCheck(email, password, confirmPassword, username, userDOB))
            {
                string userGender = GetGender();
                InsertNewUser(email, password, username, userDOB, userGender);
            }

        }
    }
}