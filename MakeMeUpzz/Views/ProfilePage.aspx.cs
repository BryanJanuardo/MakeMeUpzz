using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null && Request.Cookies["User_Cookie"] == null)
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
                else
                {
                    User user;
                    if (Session["user"] == null)
                    {
                        var id = Convert.ToInt32(Request.Cookies["User_Cookie"].Value);
                        user = UserController.getUserByUserId(id).value;
                        Session["user"] = user;
                    }
                    else
                    {
                        user = (User)Session["user"];
                    }
                }
                User currentUser = Session["user"] as User;
                if (currentUser != null)
                {
                    usernameTxt.Text = currentUser.Username;
                    emailTxt.Text = currentUser.UserEmail;
                    rblGender.SelectedValue = currentUser.UserGender;
                    DOBDate.Text = currentUser.UserDOB.ToString("dd MMMM yyyy");
                    PasswordTxt.Text = currentUser.UserPassword;
                }
            }

        }

        protected void updateProfileBtn_Click(object sender, EventArgs e)
        {

            string username = usernameTxt.Text;
            string email = emailTxt.Text;
            string genderTxt = rblGender.SelectedValue;
            string dobTxt = DOBDate.Text;

            Response<User> response = UserController.updateProfileValidation(username, email, genderTxt, dobTxt);
            if (response.success == false)
            {
                FailLbl.Text = response.message;
                return;
            }

            User currentUser = Session["user"] as User;
            int userID = currentUser.UserID;
            DateTime dob = Convert.ToDateTime(dobTxt);

            response = UserController.updateUserProfile(userID, username, email, genderTxt, dob);
            statusLbl.Text = response.message;
        }

        protected void updatePasswordBtn_Click(object sender, EventArgs e)
        {
            string currentPassword = PasswordTxt.Text;
            string newPassword = newPasswordTxt.Text;

            User currentUser = Session["user"] as User;
            int userID = currentUser.UserID;

            Response<User> response = UserController.updatePasswordValidation(currentPassword, newPassword);
            if (response.success == true)
            {
                FailLbl.Text = response.message;
                return;
            }

            response = UserController.updateUserPassword(userID, currentPassword, newPassword);
            ErrorLabel.Text = response.message;
        }
    }
}