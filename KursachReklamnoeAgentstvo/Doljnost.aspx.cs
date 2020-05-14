using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class Dpljnost : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBconnection.qrDoljnost;
            {
                gvFill(QR);
            }

            //foreach (char dost in DBconnection.strDostup)
           // {
            //    if (dost == '1')
            //    {
                   
            //    }




          //  }
        }
        private void gvFill(string qr)
        {
            sdsDoljnost.ConnectionString =
            DBconnection.connection.ConnectionString.ToString();
            sdsDoljnost.SelectCommand = qr;
            sdsDoljnost.DataSourceMode = SqlDataSourceMode.DataReader;
            gvDoljnost.DataSource = sdsDoljnost;
            gvDoljnost.DataBind();
        }
        DBprocedure procedures = new DBprocedure();
        protected void Button3_Click(object sender, EventArgs e)
        {           
            procedures.spDoljnost_insert(TextBox3.Text.ToString(), Convert.ToDecimal(TextBox4.Text.ToString()));
            Page_Load(sender, e);
            gvFill(QR);           
        }

        protected void gvDoljnost_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            procedures.spDoljnost_updated(DBconnection.IDrecord, TextBox3.Text.ToString(), Convert.ToDecimal(TextBox4.Text.ToString()));
            Page_Load(sender, e);
            gvFill(QR);
        }

        protected void gvDoljnost_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvDoljnost.SelectedRow;
            TextBox3.Text = row.Cells[2].Text.ToString();
            TextBox4.Text = row.Cells[3].Text.ToString();
            DBconnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            procedures.spDoljnost_delete(DBconnection.IDrecord);
            Page_Load(sender, e);
            gvFill(QR);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox2.Text = "";
            gvFill(QR);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow Row in gvDoljnost.Rows)
            {
                if (Row.Cells[0].Text.Equals(TextBox2.Text)
                || Row.Cells[1].Text.Equals(TextBox2.Text)
                || Row.Cells[2].Text.Equals(TextBox2.Text))
                    Row.BackColor = System.Drawing.Color.DarkGray;
                else
                    Row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void gvDoljnost_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Название должности"):
                    e.SortExpression = "[Name_Doljnost]";
                    break;
                case ("Зарплата"):
                    e.SortExpression = "[Zarplata]";
                    break;
            }
            sortGridView(gvDoljnost, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }
        private void sortGridView(GridView gridView,
           GridViewSortEventArgs e,
           out SortDirection sortDirection,
           out string strSortField)
        {
            strSortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null &&
                gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (strSortField ==
                    gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"]
                        == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }
            }
            gridView.Attributes["CurrentSortField"] = strSortField;
            gridView.Attributes["CurrentSortDirection"] =
                (sortDirection == SortDirection.Ascending ? "ASC"
                : "DESC");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Name_Doljnost] like '%" + TextBox2.Text + "%' or [Zarplata] like '%" + TextBox2.Text + "%'";
            gvFill(newQr);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //Verify that the control is rendered
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Employees.doc");
            Response.ContentType = "application/word";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            gvDoljnost.HeaderRow.Style.Add("background-color", "#FFFFFF");
            gvDoljnost.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Employees.xls");
            Response.ContentType = "application/excel";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            gvDoljnost.HeaderRow.Style.Add("background-color", "#FFFFFF");
            gvDoljnost.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
    }
}