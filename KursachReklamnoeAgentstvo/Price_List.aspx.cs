using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class Price_List : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBconnection.qrPrice_List;
            {
                gvFill(QR);
            }
        }
        private void gvFill(string qr)
        {
            sdsPrice_List.ConnectionString =
            DBconnection.connection.ConnectionString.ToString();
            sdsPrice_List.SelectCommand = qr;
            sdsPrice_List.DataSourceMode = SqlDataSourceMode.DataReader;
            gvPrice_List.DataSource = sdsPrice_List;
            gvPrice_List.DataBind();
        }
        DBprocedure procedures = new DBprocedure();
        protected void Button3_Click(object sender, EventArgs e)
        {
            procedures.spPrice_List_insert(TextBox3.Text.ToString(), TextBox4.Text.ToString(),Convert.ToInt32(TextBox5.Text.ToString()));
            Page_Load(sender, e);
            gvFill(QR);
        }

        protected void gvPrice_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPrice_List.SelectedRow;
            TextBox3.Text = row.Cells[2].Text.ToString();
            TextBox4.Text = row.Cells[3].Text.ToString();
            TextBox5.Text = row.Cells[4].Text.ToString();
            DBconnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            procedures.spPrice_List_updated(DBconnection.IDrecord, 
                TextBox3.Text.ToString(),
                TextBox4.Text.ToString(), 
                Convert.ToInt32(TextBox5.Text.ToString()));
            gvFill(QR);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            procedures.spPrice_List_delete(DBconnection.IDrecord);
            Page_Load(sender, e);
            gvFill(QR);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox2.Text = "";
            gvFill(QR);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Name_Price_List] like '%" + TextBox2.Text + "%' or [Srok_Price_List] like '%" + TextBox2.Text + "%' or [Cena_Price_List] like '%" + TextBox2.Text + "%'";
            gvFill(newQr);
        }
        protected void gvPrice_List_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Название"):
                    e.SortExpression = "[Name_Price_List]";
                    break;
                case ("Срок выполнения"):
                    e.SortExpression = "[Srok_Price_List]";
                    break;
                case ("Цена"):
                    e.SortExpression = "[Cena_Price_List]";
                    break;
            }
            sortGridView(gvPrice_List, e, out sortDirection, out strField);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow Row in gvPrice_List.Rows)
            {
                if (Row.Cells[0].Text.Equals(TextBox2.Text)
                || Row.Cells[1].Text.Equals(TextBox2.Text)
                || Row.Cells[2].Text.Equals(TextBox2.Text)
                || Row.Cells[3].Text.Equals(TextBox2.Text))
                    Row.BackColor = System.Drawing.Color.DarkGray;
                else
                    Row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void gvPrice_List_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }
    }
    
}