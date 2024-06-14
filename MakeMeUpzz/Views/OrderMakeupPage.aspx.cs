using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class OrderMakeupPage : System.Web.UI.Page
    {
        protected void setDefaultValueMakeupQuantity()
        {
            for (int i = 0; i < MakeupController.getAllMakeup().value.Count; i++)
            {
                var row = MakeupGridView.Rows[i].Cells[7].FindControl("MakeupQuantityInput") as TextBox;
                row.Text = "0";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = Session["user"] as User;
            if (IsPostBack == false)
            {
                ErrorLabel.Text = "";
                if (Session["user"] == null && Request.Cookies["User_Cookie"] == null)
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
                else
                {
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

                    if (user.UserRole == "Admin")
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }
                }
                MakeupGridView.DataSource = MakeupController.getAllMakeupSortDescByRating().value;
                MakeupGridView.DataBind();
                setDefaultValueMakeupQuantity();
            }
        }

        protected void MakeupGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Order")
            {
                Control control = e.CommandSource as Control;
                GridViewRow row = control.NamingContainer as GridViewRow;
                int rowIndex = row.RowIndex;
                 
                int makeupId = Convert.ToInt32(MakeupGridView.Rows[rowIndex].Cells[0].Text);
                int makeupQuantity = Convert.ToInt32((MakeupGridView.Rows[rowIndex].Cells[7].FindControl("MakeupQuantityInput") as TextBox).Text);
                User user = Session["user"] as User;
                int userId = user.UserID;

                Response<Cart> response = CartController.quantityValidation(makeupQuantity);
                if (response.success == false)
                {
                    ErrorLabel.Text = response.message;
                    return;
                }

                response = CartController.addMakeupToCart(userId, makeupId, makeupQuantity);
                ErrorLabel.Text = response.message;
            }
        }

        protected void ClearCartButton_Click(object sender, EventArgs e)
        {
            User user = Session["user"] as User;
            Response<Cart> response = CartController.resetCart(user.UserID);
            if (response.success == false)
            {
                ErrorLabel.Text = response.message;
                return;
            }
            ErrorLabel.Text = response.message;
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            User user = Session["user"] as User;
            Response<Cart> response = TransactionController.checkoutCart(user.UserID);
            if (response.success == false)
            {
                ErrorLabel.Text = response.message;
                return;
            }
            ErrorLabel.Text = response.message;
        }
    }
}