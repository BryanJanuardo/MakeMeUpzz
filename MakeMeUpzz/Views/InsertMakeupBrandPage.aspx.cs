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
    public partial class InsertMakeupBrandPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FailLbl.Text = "";
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

        protected void InputButton_Click(object sender, EventArgs e)
        {
            string name = MakeUpBrandTxt.Text;
            string ratingText = MakeUpRatingTxt.Text.ToString();

            Response<MakeupBrand> response = MakeupBrandController.validationNewMakeupBrand(name, ratingText);
            if (response.success == false)
            {
                FailLbl.Text = response.message;
                return;
            }

            int rating = Convert.ToInt32(ratingText);
            MakeupBrandController.insertNewMakeupBrand(name, rating);
            Response.Redirect("~/Views/ManageMakeupPage.aspx");

        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeupPage.aspx");
        }
    }
}