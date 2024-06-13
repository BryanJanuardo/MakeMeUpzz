using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
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
        static int userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

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

            FailLbl.Text = UserController.updateProfileValidation(username, email, genderTxt, dobTxt);
            if (FailLbl.Text != "")
                return;

            User currentUser = Session["user"] as User;
            userID = currentUser.UserID;
            DateTime dob = Convert.ToDateTime(dobTxt);

            statusLbl.Text = UserController.updateUserProfile(userID, username, email, genderTxt, dob);

            
        }

        protected void updatePasswordBtn_Click(object sender, EventArgs e)
        {
            string currentPassword = PasswordTxt.Text;
            string newPassword = newPasswordTxt.Text;

            User currentUser = Session["user"] as User;
            userID = currentUser.UserID;

            FailLbl.Text = UserController.updatePasswordValidation(currentPassword, newPassword);
            if (FailLbl.Text != "")
                return;

            UserController.updateUserPassword(userID, currentPassword, newPassword);
            
        }
    }
}