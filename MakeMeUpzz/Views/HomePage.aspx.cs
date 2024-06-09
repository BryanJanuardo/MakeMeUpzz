using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        private DatabaseContextEntities db = new DatabaseContextEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["user"] == null && Request.Cookies["User_Cookie"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    var id = Int32.Parse(Request.Cookies["User_Cookie"].Value);
                    user = (from x in db.Users where x.UserID == id select x).FirstOrDefault();
                    Session["user"] = user;
                }
                else
                {
                    user = (User) Session["user"];
                }
            }
        }
    }
}