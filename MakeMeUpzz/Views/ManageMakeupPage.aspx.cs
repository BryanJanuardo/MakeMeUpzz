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
    public partial class ManageMakeupPage : System.Web.UI.Page
    {
        private void updateTable()
        {
            MakeupGridView.DataSource = MakeupController.getAllMakeupSortDescByRating().value;
            MakeupGridView.DataBind();

            MakeupTypeGridView.DataSource = MakeupTypeController.getAllMakeupType().value;
            MakeupTypeGridView.DataBind();

            MakeupBrandGridView.DataSource = MakeupBrandController.getAllMakeupBrand().value;
            MakeupBrandGridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
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

                    if (user.UserRole == "User")
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }
                }

                updateTable();
            }
        }

        protected void InsertMakeupButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupPage.aspx");
        }

        protected void InsertMakeupTypeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupTypePage.aspx");
        }

        protected void InsertMakeupBrandButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupBrandPage.aspx");
        }

        protected void MakeupGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupGridView.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupPage.aspx?ID=" + id);
        }

        protected void MakeupGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response<Makeup> response = MakeupController.deleteMakeup(id);
            updateTable();
            ErrorLabel.Text = response.message;
        }
        protected void MakeupTypeGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupTypeGridView.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupTypePage.aspx?ID=" + id);
            updateTable();
        }

        protected void MakeupTypeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupTypeGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response<MakeupType> response = MakeupTypeController.deleteMakeupType(id);
            updateTable();
            ErrorLabelType.Text = response.message;
        }
        protected void MakeupBrandGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupBrandGridView.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupBrandPage.aspx?ID=" + id);
            updateTable();
        }

        protected void MakeupBrandGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupBrandGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response<MakeupBrand> response = MakeupBrandController.deleteMakeupBrand(id);
            updateTable();
            ErrorLabelBrand.Text = response.message;
        }
    }
}