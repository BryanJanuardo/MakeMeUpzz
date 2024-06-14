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
    public partial class UpdateMakeupBrandPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorValidationLabel.Text = "";
            if (Session["user"] == null && Request.Cookies["User_Cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    var userid = Convert.ToInt32(Request.Cookies["User_Cookie"].Value);
                    user = UserController.getUserByUserId(userid).value;
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
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Response<MakeupBrand> response = MakeupBrandController.getMakeupBrandById(id);
            MakeUpBrandTxt.Text = response.value.MakeupBrandName;
            MakeUpBrandRatingTxt.Text = response.value.MakeupBrandRating.ToString();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string brand = MakeUpBrandTxt.Text;
            string ratingTxt = MakeUpBrandRatingTxt.Text;

            Response<MakeupBrand> response = MakeupBrandController.validationNewMakeupBrand(brand, ratingTxt);
            
            if (response.success == false)
            {
                ErrorValidationLabel.Text = response.message;
                return;
            }

            int rating = Convert.ToInt32(ratingTxt);
            int id = Convert.ToInt32(Request.QueryString["id"]);

            response = MakeupBrandController.editMakeupBrand(id, brand, rating);
            ErrorValidationLabel.Text = response.message;
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeupPage.aspx");
        }
    }
}