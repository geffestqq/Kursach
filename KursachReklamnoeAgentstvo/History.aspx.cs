using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class History : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            QR = DBconnection.qrHistory;
            {
                gvFill(QR);
            }
        }

        private void gvFill(string qr)
        {
            sdsHistory.ConnectionString =
            DBconnection.connection.ConnectionString.ToString();
            sdsHistory.SelectCommand = qr;
            sdsHistory.DataSourceMode = SqlDataSourceMode.DataReader;
            gvHistory.DataSource = sdsHistory;
            gvHistory.DataBind();
        }

        protected void gvHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void gvHistory_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvHistory_RowDataBound2(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void gvHistory_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
        }
    }
}
    
    
    
