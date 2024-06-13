using MakeMeUpzz.Controllers;
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

        }

        protected void InputButton_Click(object sender, EventArgs e)
        {
            string name = MakeUpBrandTxt.Text;
            string ratingText = MakeUpRatingTxt.Text.ToString();

            FailLbl.Text = MakeupBrandController.validationNewMakeupBrand(name, ratingText);
            if (FailLbl.Text != "")
                return;

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