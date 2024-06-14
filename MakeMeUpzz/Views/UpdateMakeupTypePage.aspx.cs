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
    public partial class UpdateMakeupTypePage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["user"] == null && Request.Cookies["User_Cookie"] == null)
                {
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    User user;
                    if (Session["user"] == null)
                    {
                        var userid = Convert.ToInt32(Request.Cookies["User_Cookie"].Value);
                        user = UserController.getUserByUserId(userid).value;
                        Session["user"] = user;


                        if (user.UserRole.Equals("User"))
                        {
                            Response.Redirect("HomePage.aspx");
                        }
                    }
                    else
                    {
                        user = (User)Session["user"];

                        if (user.UserRole.Equals("User"))
                        {
                            Response.Redirect("HomePage.aspx");
                        }
                    }
                }
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Response<MakeupType> response = MakeupTypeController.getMakeupTypeById(id);
                MakeupTypeNameInput.Text = response.value.MakeupTypeName;
            }
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string makeupTypeName = MakeupTypeNameInput.Text;

            Response<MakeupType> response = MakeupTypeController.newMakeupTypeValidation(makeupTypeName);
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (response.success == false)
            {
                ErrorValidationLabel.Text = response.message;
                return;
            }
            
            response = MakeupTypeController.updateMakeupType(id, makeupTypeName);
            ErrorValidationLabel.Text += response.message;
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeupPage.aspx");
        }
    }
}