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
            Response.Redirect("~/Views/HandleTransactionPage.aspx");
        }

        protected void UserLogoutButton_Click(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;
            foreach(string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-999);
            }

            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void AdminLogoutButton_Click(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;
            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-999);
            }
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void AdminProfileButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void UserProfileButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void TransactionReportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ViewTransactionReportPage.aspx");
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void HistoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistoryPage.aspx");
        }

        protected void TransactionHistoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistoryPage.aspx");
        }
    }
}