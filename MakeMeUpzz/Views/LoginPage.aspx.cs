using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
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
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text;
            string password = PasswordTxt.Text;
            bool remember = RememberMeBox.Checked;

            FailLbl.Text = UserController.loginValidation(email, password);

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