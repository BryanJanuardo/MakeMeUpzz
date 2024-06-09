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
    public partial class UpdateMakeupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                Makeup makeup = MakeupController.getMakeupById(id);

                if(makeup != null) 
                {
                    MakeupNameInput.Text = makeup.MakeupName;
                    MakeupPriceInput.Text = makeup.MakeupPrice.ToString();
                    MakeupWeightInput.Text = makeup.MakeupWeight.ToString();
                }

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
            int id = Convert.ToInt32(Request.QueryString["ID"]);

            MakeupController.editMakeup(id, makeupName, makeupPrice, makeupWeight, makeupType, makeupBrand);

            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

    }
}