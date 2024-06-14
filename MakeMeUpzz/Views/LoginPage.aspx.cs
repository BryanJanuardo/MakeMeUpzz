using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
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

            Response<User> response = UserController.loginValidation(email, password);

            if (response.success == false)
            {
                FailLbl.Text = response.message;
                return;
            }

            response = UserController.getUserByCredentials(email, password);

            var user = response.value;
                
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
                FailLbl.Text = response.message;
                return;
            }
        }
    }
}