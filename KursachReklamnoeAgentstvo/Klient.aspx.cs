using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class Klient : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            QR = DBconnection.qrKlient;
            {
                gvFill(QR);
                lb_Postavshik_Load(sender, e);
            }
        }
        private void gvFill(string qr)
        {
            sdsKlient.ConnectionString =
            DBconnection.connection.ConnectionString.ToString();
            sdsKlient.SelectCommand = qr;
            sdsKlient.DataSourceMode = SqlDataSourceMode.DataReader;
            gvKlient.DataSource = sdsKlient;
            gvKlient.DataBind();
        }
        protected void gvKlient_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[7].Visible = false;
        }
        private string QR1 = "";
        protected void lb_Postavshik_Load(object sender, EventArgs e)
        {
            QR1 = DBconnection.qrkl;
            if (!IsPostBack)
            {
                lbRole_Fill(QR1);
            }
        }

        protected void lbRole_Fill(string qrSobese)
        {
            sdsKlient.ConnectionString = DBconnection.connection.ConnectionString.ToString();
            sdsKlient.SelectCommand = qrSobese;
            sdsKlient.DataSourceMode = SqlDataSourceMode.DataReader;
            ListBox1.DataSource = sdsKlient;
            ListBox1.DataTextField = "Логин";
            ListBox1.DataValueField = "ID_Authorization";
            ListBox1.DataBind();
        }
        DBprocedure procedures = new DBprocedure();
        protected void Button3_Click(object sender, EventArgs e)
        {
            procedures.spKlient_insert(TextBox3.Text.ToString(), TextBox4.Text.ToString(), TextBox5.Text.ToString(), 
                TextBox6.Text.ToString(), TextBox7.Text.ToString(), Convert.ToInt32(ListBox1.SelectedValue.ToString()));
            //Page_Load(sender, e);
            gvFill(QR);
           // Response.Redirect("Klient.aspx");
        }
       
        protected void gvKlient_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvKlient.SelectedRow;
            TextBox3.Text = row.Cells[2].Text.ToString();
            TextBox4.Text = row.Cells[3].Text.ToString();
            TextBox5.Text = row.Cells[4].Text.ToString();
            TextBox6.Text = row.Cells[5].Text.ToString();
            TextBox7.Text = row.Cells[6].Text.ToString();
            ListBox1.SelectedValue = row.Cells[7].Text.ToString();
            DBconnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            procedures.spKlient_updated(DBconnection.IDrecord, TextBox3.Text.ToString(), TextBox4.Text.ToString(), TextBox5.Text.ToString(),
                TextBox6.Text.ToString(), TextBox7.Text.ToString(), Convert.ToInt32(ListBox1.SelectedValue.ToString()));
            gvFill(QR);
           // Response.Redirect("Klient.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            procedures.spKlient_delete(DBconnection.IDrecord);
            Page_Load(sender, e);
            gvFill(QR);
           // Response.Redirect("Klient.aspx");
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
        protected void gvKlient_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Имя_Клиента"):
                    e.SortExpression = "[Name_Klient]";
                    break;
                case ("Фамилия_Клиента"):
                    e.SortExpression = "[Fam_Klient]";
                    break;
                case ("Отчество_Клиента"):
                    e.SortExpression = "[Otch_Klient]";
                    break;
                case ("Номер_телефона"):
                    e.SortExpression = "[Phone_Number_K]";
                    break;
                case ("Почта"):
                    e.SortExpression = "[Email_Klient]";
                    break;
                case ("Авторизация"):
                    e.SortExpression = "[Authorization_Klient_ID]";
                    break;
                case ("Логин"):
                    e.SortExpression = "[Login]";
                    break;
            }
            sortGridView(gvKlient, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Name_Klient] like '%" + TextBox2.Text + "%' or [Fam_Klient] like '%" + TextBox2.Text + "%' or [Otch_Klient] like '%" + TextBox2.Text + "%'";
            gvFill(newQr);

            // string newQr = QR + " where [Name_Klient] like '%" + TextBox2.Text + "%' or [Fam_Klient] like '%" + TextBox2.Text+ "%' or [Otch_Klient] like '%" + TextBox2.Text+ "%' or [Phone_Number_K] like '%" + TextBox2.Text + "%' or [Email_Klient] like '%" + TextBox2.Text + "%' or [Authorization_Klient_ID] like '%" + TextBox2.Text + "%'";
            //gvFill(newQr);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow Row in gvKlient.Rows)
            {
                if (Row.Cells[0].Text.Equals(TextBox2.Text)
                || Row.Cells[1].Text.Equals(TextBox2.Text)
                || Row.Cells[2].Text.Equals(TextBox2.Text)
                || Row.Cells[3].Text.Equals(TextBox2.Text)
                || Row.Cells[4].Text.Equals(TextBox2.Text)
                || Row.Cells[5].Text.Equals(TextBox2.Text)
                || Row.Cells[6].Text.Equals(TextBox2.Text)
                || Row.Cells[7].Text.Equals(TextBox2.Text)
                || Row.Cells[8].Text.Equals(TextBox2.Text))

                    Row.BackColor = System.Drawing.Color.DarkGray;
                else
                    Row.BackColor = System.Drawing.Color.White;
            }
        }
    }
    
}