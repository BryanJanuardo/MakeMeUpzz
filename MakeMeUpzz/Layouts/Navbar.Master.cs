using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Layouts
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ManageMakeupButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

        protected void OrderMakeupButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderMakeupPage.aspx");
        }

        protected void OrderQueueButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionDetailPage.aspx");
        }

        protected void UserLogoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void AdminLogoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void UserProfileButton_Click(object sender, EventArgs e)
        {

        }

        protected void AdminProfileButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void UserProfileButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }
    }
}