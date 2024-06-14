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
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                    }
                    else
                    {
                        user = (User)Session["user"];
                    }

                    if (user.UserRole == "Admin")
                    {
                        List<TransactionHeader> data = TransactionController.getAllTransactionHeaders().value;
                        if (data.Count != 0)
                        {
                            TransactionHistoryGV.DataSource = data;
                            TransactionHistoryGV.DataBind();
                        }
                        else
                        {
                            StatusLbl.Visible = true;
                        }
                    }
                    else
                    {
                        if (user != null)
                        {
                            List<TransactionHeader> data = TransactionController.getAllTransactionByUserID(user.UserID).value;
                            if (data.Count != 0)
                            {
                                TransactionHistoryGV.DataSource = data;
                                TransactionHistoryGV.DataBind();
                            }
                            else
                            {
                                StatusLbl.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        protected void TransactionHistoryGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            String transactionID = TransactionHistoryGV.DataKeys[e.NewSelectedIndex]["TransactionID"].ToString();
            Response.Redirect("TransactionDetailPage.aspx?id=" + transactionID);
        }
    }
}