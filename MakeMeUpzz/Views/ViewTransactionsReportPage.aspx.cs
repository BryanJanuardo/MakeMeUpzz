using CrystalDecisions.Shared;
using MakeMeUpzz.Controllers;
using MakeMeUpzz.Dataset;
using MakeMeUpzz.Models;
using MakeMeUpzz.ReportFinal;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace MakeMeUpzz.Views
{
    public partial class ViewTransactionsReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseContextEntities db = new DatabaseContextEntities();
            CrystalReportFinal report = new CrystalReportFinal();
            CrystalReportViewer1.ReportSource = report;
            DataSet data = getData(db.TransactionHeaders.ToList());
            report.SetDataSource(data);

        }

        
        public DataSet getData(List<TransactionHeader> th)
        {
            DataSet data = new DataSet();
            var headertable = data.TransactionHeaders;
            var detailtable = data.TransactionDetails;

            foreach(TransactionHeader t in th)
            {
                var grandTotal = t.TransactionDetails.Sum(td => td.Quantity * td.Makeup.MakeupPrice);
                var hrow = headertable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["grandTotal"] = grandTotal;
                headertable.Rows.Add(hrow);

                foreach(TransactionDetail d in t.TransactionDetails)
                {
                    var subTotal = d.Quantity * d.Makeup.MakeupPrice;
                    var drow = detailtable.NewRow();
                    drow["TransactionDetailID"] = d.TransactionDetailID;
                    drow["TransactionID"] = d.TransactionID;
                    drow["MakeupID"] = d.MakeupID;
                    drow["Quantity"] = d.Quantity;
                    drow["subTotal"] = subTotal;
                    detailtable.Rows.Add(drow);

                    //var makeup = MakeupRepository.getMakeupById(d.MakeupID);
                }
            }
            return data;
        }

    }
}