﻿using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
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
            if (Session["user"] == null && Request.Cookies["User_Cookie"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    var id = Convert.ToInt32(Request.Cookies["User_Cookie"].Value);
                    user = UserController.getUserByUserId(id).value;
                    Session["user"] = user;

                    if (user.UserRole.Equals("User"))
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                }
                else
                {
                    user = (User)Session["user"];

                    if (user.UserRole.Equals("User"))
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                }
            }
        }
    }
}