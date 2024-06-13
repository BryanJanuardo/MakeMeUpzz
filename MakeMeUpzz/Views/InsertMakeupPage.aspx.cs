using MakeMeUpzz.Controllers;
using MakeMeUpzz.Handlers;
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
    public partial class InsertMakeupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                ErrorValidationLabel.Text = "";
                List<string> MakeupTypes = MakeupTypeController.getAllMakeupTypeName().value;
                List<string> MakeupBrands = MakeupBrandController.getMakeupBrandName().value;

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
            int makeupPrice;
            int makeupWeight;

            try
            {
                makeupPrice = Convert.ToInt32(makeupPriceText);
                makeupWeight = Convert.ToInt32(makeupWeightText);
            }
            catch (Exception ex)
            {
                ErrorValidationLabel.Text = "Input Price and Weight must be number";
                return;
            }

            Response<Makeup> response = MakeupController.validationNewMakeup(makeupName, makeupPrice, makeupWeight, makeupType, makeupBrand);
            if (response.success == false)
            {
                ErrorValidationLabel.Text = response.message;
                return;
            }

            MakeupController.insertNewMakeup(makeupName, makeupPrice, makeupWeight, makeupType, makeupBrand);
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }
    }
}