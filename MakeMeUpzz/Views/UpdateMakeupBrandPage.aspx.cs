using MakeMeUpzz.Controllers;
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

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string brand = MakeUpBrandTxt.Text;
            string ratingTxt = MakeUpBrandRatingTxt.Text;

            ErrorValidationLabel.Text = MakeupBrandController.validationNewMakeupBrand(brand, ratingTxt);
            if (ErrorValidationLabel.Text != "")
                return;

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