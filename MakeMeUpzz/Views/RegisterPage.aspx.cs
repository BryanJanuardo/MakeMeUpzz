using MakeMeUpzz.Controllers;
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

        protected void RegistBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text.ToString();
            string username = UsernameTxt.Text.ToString();
            string password = PasswordTxt.Text.ToString();
            string confirmPassword = ConfirmTxt.Text.ToString();
            string userDOB = DOBDate.Text.ToString();
            FailLbl.Text = UserController.ValidationCheck(email, password, confirmPassword, username, userDOB, GetGender());

            if (FailLbl.Text != "")
                return;

            UserController.insertNewUser(email, password, username, userDOB, GetGender());
            Response.Redirect("LoginPage.aspx");
        }
    }
}