﻿using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
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
            for (int i = 0; i < MakeupController.getAllMakeup().Count; i++)
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
                MakeupGridView.DataSource = MakeupController.getAllMakeupSortDescByRating();
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

                if (CartController.quantityValidation(makeupQuantity)){
                    CartController.addMakeupToCart(userId, makeupId, makeupQuantity);
                    return;
                }
                ErrorLabel.Text = "Quantity must be more than 0 to order!";
            }
        }

        protected void ClearCartButton_Click(object sender, EventArgs e)
        {
            User user = Session["user"] as User;
            ErrorLabel.Text = CartController.resetCart(user.UserID);
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            User user = Session["user"] as User;
            ErrorLabel.Text = TransactionController.checkoutCart(user.UserID);

        }
    }
}