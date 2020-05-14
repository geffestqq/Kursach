using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class Zakaz_Price : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBconnection.qrZakaz_Price;
            {
                gvFill(QR);
            }
        }
        private void gvFill(string qr)
        {
            sdsZakaz_Price.ConnectionString =
            DBconnection.connection.ConnectionString.ToString();
            sdsZakaz_Price.SelectCommand = qr;
            sdsZakaz_Price.DataSourceMode = SqlDataSourceMode.DataReader;
            gvZakaz_Price.DataSource = sdsZakaz_Price;
            gvZakaz_Price.DataBind();
        }

        protected void gvZakaz_Price_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }
    }
}