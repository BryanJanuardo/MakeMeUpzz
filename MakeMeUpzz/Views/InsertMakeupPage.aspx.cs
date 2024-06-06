using MakeMeUpzz.Controllers;
using MakeMeUpzz.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class InsertMakeupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                List<string> MakeupTypes = MakeupTypeController.getAllMakeupTypeName();
                List<string> MakeupBrands = MakeupBrandController.getMakeupBrandName();

                MakeupTypeDropDownList.DataSource = MakeupTypes;
                MakeupTypeDropDownList.DataBind();
                MakeupBrandDropDownList.DataSource = MakeupBrands;
                MakeupBrandDropDownList.DataBind();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string makeupName = MakeupNameInput.Text;
            string makeupPriceText = MakeupPriceInput.Text;
            string makeupWeightText = MakeupWeightInput.Text;
            string makeupType = MakeupTypeDropDownList.Text.ToString();
            string makeupBrand = MakeupBrandDropDownList.Text.ToString();
            ErrorValidationLabel.Text = MakeupController.validationNewMakeup(makeupName, makeupPriceText, makeupWeightText, makeupType, makeupBrand);
            
            if (ErrorValidationLabel.Text != "")
                return;

            int makeupPrice = Convert.ToInt32(makeupPriceText);
            int makeupWeight = Convert.ToInt32(makeupWeightText);

            MakeupController.insertNewMakeup(makeupName, makeupPrice, makeupWeight, makeupType, makeupBrand);
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }
    }
}