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

            MakeupBrandController.editMakeupBrand(id, brand, rating);
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeupPage.aspx");
        }
    }
}