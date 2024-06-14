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
    public partial class InsertMakeupTypePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
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

                    if (user.UserRole == "User")
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string makeupTypeName = MakeupTypeNameInput.Text;

            Response<MakeupType> response = MakeupTypeController.newMakeupTypeValidation(makeupTypeName);

            if(response.success == false)
                ErrorValidationLabel.Text = response.message;

            response = MakeupTypeController.insertNewMakeupType(makeupTypeName);
            ErrorLabel.Text = response.message;
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeupPage.aspx");
        }
    }
}