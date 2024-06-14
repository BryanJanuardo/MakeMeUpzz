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
    public partial class HandleTransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
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

                if (user.UserRole == "Admin")
                {
                    ShowTransactionList();
                }
                else if(user.UserRole == "User")
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        private void ShowTransactionList()
        {
            HandleTransactionGV.DataSource = TransactionController.getAllUnhandledTransaction().value;
            HandleTransactionGV.DataBind();
        }

        protected void HandleTransactionGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = HandleTransactionGV.Rows[e.NewEditIndex];
            int transactionID = Convert.ToInt32(row.Cells[0].Text);
            Response<TransactionHeader> response = TransactionController.HandleTransaction(transactionID);
            ErrorLabel.Text = response.message;
            ShowTransactionList();
        }

        protected void HandleTransactionGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                String status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                Button handleButton = e.Row.Cells[4].Controls[0] as Button;

                if (status.Equals("handled"))
                {
                    handleButton.Visible = false;
                }
            }
        }
    }
}