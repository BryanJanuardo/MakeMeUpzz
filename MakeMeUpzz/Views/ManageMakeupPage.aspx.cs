using MakeMeUpzz.Controllers;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                MakeupGridView.DataSource = MakeupController.getAllMakeupSortDescByRating().value;
                MakeupGridView.DataBind();
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
            MakeupController.deleteMakeup(id);
            MakeupGridView.DataSource = MakeupController.getAllMakeupSortDescByRating().value;
            MakeupGridView.DataBind();
        }
    }
}