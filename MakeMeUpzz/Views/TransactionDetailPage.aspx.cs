﻿using MakeMeUpzz.Controllers;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String transactionID = Request.QueryString["ID"];
                TransactionDetailGV.DataSource = TransactionController.showDetail(int.Parse(transactionID));
                TransactionDetailGV.DataBind();
            }
        }
    }
}