using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class Sotrudnik_Sobesedovanie : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBconnection.qrSotrudnik_Sobesedovanie;
            {
                gvFill(QR);
            }
        }
        private void gvFill(string qr)
        {
            sdsSotrudnik_Sobesedovanie.ConnectionString =
            DBconnection.connection.ConnectionString.ToString();
            sdsSotrudnik_Sobesedovanie.SelectCommand = qr;
            sdsSotrudnik_Sobesedovanie.DataSourceMode = SqlDataSourceMode.DataReader;
            gvSotrudnik_Sobesedovanie.DataSource = sdsSotrudnik_Sobesedovanie;
            gvSotrudnik_Sobesedovanie.DataBind();
        }

        protected void gvSotrudnik_Sobesedovanie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvSotrudnik_Sobesedovanie_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }
    }
}