using MakeMeUpzz.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String transactionID = Request.QueryString["ID"];
                TransactionDetailGV.DataSource = TransactionController.showDetail(Convert.ToInt32(transactionID)).value;
                TransactionDetailGV.DataBind();
            }
        }
    }
}