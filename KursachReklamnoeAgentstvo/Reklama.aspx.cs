using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class Reklama : Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBconnection.qrReklama;
            {
                gvFill(QR);
                lb_Postavshik_Load(sender, e);
                lb_Postavshik2_Load(sender, e);
            }
        }
        private void gvFill(string qr)
        {
            sdsReklama.ConnectionString =
            DBconnection.connection.ConnectionString.ToString();
            sdsReklama.SelectCommand = qr;
            sdsReklama.DataSourceMode = SqlDataSourceMode.DataReader;
            gvReklama.DataSource = sdsReklama;
            gvReklama.DataBind();
        }
        private string QR1 = "";
        protected void lb_Postavshik_Load(object sender, EventArgs e)
        {
            QR1 = DBconnection.qrRek;
            if (!IsPostBack)
            {
                lbRole_Fill(QR1);
            }
        }

        protected void lbRole_Fill(string qrSobese)
        {
            sdsReklama.ConnectionString = DBconnection.connection.ConnectionString.ToString();
            sdsReklama.SelectCommand = qrSobese;
            sdsReklama.DataSourceMode = SqlDataSourceMode.DataReader;
            ListBox2.DataSource = sdsReklama;
            //ListBox2.DataTextField = "Имя сотрудника";
            ListBox2.DataValueField = "FIO";
            ListBox2.DataBind();
        }

        private string QR2 = "";
        protected void lb_Postavshik2_Load(object sender, EventArgs e)
        {
            QR2 = DBconnection.qrRek2;
            if (!IsPostBack)
            {
                lbRole2_Fill(QR2);
            }
        }

        protected void lbRole2_Fill(string qrSobese)
        {
            sdsReklama.ConnectionString = DBconnection.connection.ConnectionString.ToString();
            sdsReklama.SelectCommand = qrSobese;
            sdsReklama.DataSourceMode = SqlDataSourceMode.DataReader;
            ListBox1.DataSource = sdsReklama;
            ListBox1.DataTextField = "Тема заказа";
            ListBox1.DataValueField = "id_Zakaz";
            ListBox1.DataBind();
        }
        DBprocedure procedures = new DBprocedure();
        protected void Button3_Click(object sender, EventArgs e)
        {
            Int32 FIO = new DBconnection().ProverkaPoFio(ListBox2.SelectedValue.ToString());
            procedures.spReklama_insert(TextBox3.Text.ToString(),TextBox4.Text.ToString(),FIO, Convert.ToInt32(ListBox1.SelectedValue.ToString()));
            //Page_Load(sender, e);
            gvFill(QR);
        }

        protected void gvReklama_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvReklama.SelectedRow;
            TextBox3.Text = row.Cells[2].Text.ToString();
            TextBox4.Text = row.Cells[3].Text.ToString();
            //ListBox2.SelectedValue = row.Cells[6].Text.ToString();
            ListBox1.SelectedValue = row.Cells[5].Text.ToString();
            DBconnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Int32 FIO = new DBconnection().ProverkaPoFio(ListBox2.SelectedValue.ToString());
            procedures.spReklama_updated(DBconnection.IDrecord, TextBox3.Text.ToString(), TextBox4.Text.ToString(), FIO, Convert.ToInt32(ListBox1.SelectedValue.ToString()));
            //Page_Load(sender, e);
            gvFill(QR);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            procedures.spReklama_delete(DBconnection.IDrecord);
            Page_Load(sender, e);
            gvFill(QR);
        }

        protected void gvReklama_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {    
                case ("Статус"):
                    e.SortExpression = "[dbo].[Reklama].[Status]";
                    break;
                case ("Дата начала"):
                    e.SortExpression = "[Date_Of_Begin]";
                    break;
                case ("ЗаказРеклама"):
                    e.SortExpression = "[Zakaz_Reklama_ID]";
                    break;
                case ("СотрудникРеклама"):
                    e.SortExpression = "[Sotrudnik_Reklama_ID]";
                    break;
             case ("Имя сотрудника"):
                    e.SortExpression = "[Name_Sotrudnik]";
                    break;
                case ("Фамилия сотрудника"):
                    e.SortExpression = "[Fam_Sotrudnik]";
                    break;
                case ("Отчество сотрудника"):
                    e.SortExpression = "[Otch_Sotrudnik]";
                    break;
            }
            sortGridView(gvReklama, e, out sortDirection, out strField);
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

            

        string newQr = QR + " where [dbo].[Reklama].[Status] like '%" + TextBox2.Text + "%' or [Date_Of_Begin] like '%" + TextBox2.Text + "%' or [Zakaz_Reklama_ID] like '%" + TextBox2.Text + "%' or [Sotrudnik_Reklama_ID] like '%" + TextBox2.Text + "%' or [Name_Sotrudnik] like '%" + TextBox2.Text +
                TextBox2.Text + "%' or [Fam_Sotrudnik] like '%" + TextBox2.Text + "%' or [Otch_Sotrudnik] like '%"  + "%'";
            gvFill(newQr);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow Row in gvReklama.Rows)
            {
                if (Row.Cells[0].Text.Equals(TextBox2.Text)
                || Row.Cells[1].Text.Equals(TextBox2.Text)
                || Row.Cells[2].Text.Equals(TextBox2.Text)
                || Row.Cells[3].Text.Equals(TextBox2.Text)
                || Row.Cells[4].Text.Equals(TextBox2.Text)
                || Row.Cells[5].Text.Equals(TextBox2.Text)
                || Row.Cells[6].Text.Equals(TextBox2.Text)
                || Row.Cells[7].Text.Equals(TextBox2.Text)
                || Row.Cells[8].Text.Equals(TextBox2.Text)
                || Row.Cells[9].Text.Equals(TextBox2.Text))

                    Row.BackColor = System.Drawing.Color.DarkGray;
                else
                    Row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void gvReklama_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
        }
    }
}