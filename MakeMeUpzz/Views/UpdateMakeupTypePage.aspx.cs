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
    public partial class UpdateMakeupTypePage : System.Web.UI.Page
    {
        DatabaseContextEntities db = new DatabaseContextEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                List<string> MakeupTypes = MakeupTypeController.getAllMakeupTypeName();

                MakeupTypeDropDownList.DataSource = MakeupTypes;
                MakeupTypeDropDownList.DataBind();
            }

            if (Session["user"] == null && Request.Cookies["User_Cookie"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    var id = Int32.Parse(Request.Cookies["User_Cookie"].Value);
                    user = (from x in db.Users where x.UserID == id select x).FirstOrDefault();
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
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string makeupTypeName = MakeupTypeNameInput.Text;
            ErrorValidationLabel.Text = MakeupTypeController.newMakeupTypeValidation(makeupTypeName);

            if (ErrorValidationLabel.Text != "")    
                return;

            MakeupTypeController.updateMakeupType(MakeupTypeDropDownList.SelectedIndex + 1, makeupTypeName);

            Response.Redirect("UpdateMakeupTypePage.aspx");
        }

        protected void MakeupTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeupTypeNameInput.Text = MakeupTypeDropDownList.Text;
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeupPage.aspx");
        }
    }
}