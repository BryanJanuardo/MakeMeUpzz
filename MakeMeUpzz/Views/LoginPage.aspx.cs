﻿using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MakeMeUpzz.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            FailLbl.Visible = false;
        }

        protected bool InputValidate(string email, string password, User user)
        {
            if (string.IsNullOrEmpty(email))
            {
                FailLbl.Text = "Email must be filled";
                FailLbl.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                FailLbl.Text = "Password must be filled";
                FailLbl.Visible = true;
                return false;
            }

            User validateUser = (from User in db.Users where User.UserEmail.ToUpper().Equals(email.ToUpper()) select User).FirstOrDefault();

            if (validateUser == null)
            {
                FailLbl.Text = "Incorrect email or password";
                FailLbl.Visible = true;
                return false;
            }
            else if (!validateUser.UserEmail.ToUpper().Equals(email.ToUpper()))
            {
                FailLbl.Text = "Incorrect email or password";
                FailLbl.Visible = true;
                return false;
            }

            if (!validateUser.UserPassword.Equals(password))
            {
                FailLbl.Text = "Incorrect email or password";
                FailLbl.Visible = true;
                return false;
            }

            FailLbl.Text = "";
            FailLbl.Visible = false;

            return true;
=======
>>>>>>> Stashed changes
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text;
            string password = PasswordTxt.Text;
            bool remember = RememberMeBox.Checked;

            FailLbl.Text = LoginController.loginValidation(email, password);

            if (FailLbl.Text != "")
                return;

            var user = UserController.getUserByCredentials(email, password);
                
            if (user != null)
            {
                Session["user"] = user;

                if (remember)
                {
                    HttpCookie cookie = new HttpCookie("User_Cookie");
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddMinutes(2);
                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("HomePage.aspx");
            }
            else
            {
                FailLbl.Text = "User not found";
                return;
            }
        }
    }
}