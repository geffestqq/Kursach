using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class Sotrudnik : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBconnection.qrSotrudnik;
            {
                gvFill(QR);
                lb_Postavshik_Load(sender, e);
                lb_Postavshik_Load1(sender, e);
            }
        }

        private void gvFill(string qr)
        {
            sdsSotrudnik.ConnectionString =
            DBconnection.connection.ConnectionString.ToString();
            sdsSotrudnik.SelectCommand = qr;
            sdsSotrudnik.DataSourceMode = SqlDataSourceMode.DataReader;
            gvSotrudnik.DataSource = sdsSotrudnik;
            gvSotrudnik.DataBind();
        }
        private string QR1 = "";
        protected void lb_Postavshik_Load(object sender, EventArgs e)
        {
            QR1 = DBconnection.qrst;
            if (!IsPostBack)
            {
                lbRole_Fill(QR1);
            }
        }

        protected void lbRole_Fill(string qrSobese)
        {
            sdsSotrudnik.ConnectionString = DBconnection.connection.ConnectionString.ToString();
            sdsSotrudnik.SelectCommand = qrSobese;
            sdsSotrudnik.DataSourceMode = SqlDataSourceMode.DataReader;
            ListBox2.DataSource = sdsSotrudnik;
            ListBox2.DataTextField = "Логин";
            ListBox2.DataValueField = "ID_Authorization";
            ListBox2.DataBind();
        }
        

        private string QR2 = "";
        protected void lb_Postavshik_Load1(object sender, EventArgs e)
        {
            QR2 = DBconnection.qrst2;
            if (!IsPostBack)
            {
                lbRole1_Fill(QR2);
            }
        }

        protected void lbRole1_Fill(string qrSobese)
        {
            sdsSotrudnik.ConnectionString = DBconnection.connection.ConnectionString.ToString();
            sdsSotrudnik.SelectCommand = qrSobese;
            sdsSotrudnik.DataSourceMode = SqlDataSourceMode.DataReader;
            ListBox3.DataSource = sdsSotrudnik;
            ListBox3.DataTextField = "Название должности";
            ListBox3.DataValueField = "id_Doljnost";
            ListBox3.DataBind();
        }


        protected void gvSotrudnik_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
        }
        DBprocedure procedures = new DBprocedure();
        protected void Button3_Click(object sender, EventArgs e)
        {
            procedures.spSotrudnik_insert(TextBox5.Text.ToString(), TextBox4.Text.ToString(), TextBox6.Text.ToString(),
                TextBox7.Text.ToString(), TextBox8.Text.ToString(), TextBox9.Text.ToString(), TextBox10.Text.ToString(), TextBox11.Text.ToString(),
                Convert.ToInt32(ListBox3.SelectedValue.ToString()), Convert.ToInt32(ListBox2.SelectedValue.ToString()));
            gvFill(QR);
        }

        protected void gvSotrudnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvSotrudnik.SelectedRow;
            TextBox5.Text = row.Cells[2].Text.ToString();
            TextBox4.Text = row.Cells[3].Text.ToString();
            TextBox6.Text = row.Cells[4].Text.ToString();
            TextBox7.Text = row.Cells[5].Text.ToString();
            TextBox8.Text = row.Cells[6].Text.ToString();
            TextBox9.Text = row.Cells[7].Text.ToString();
            TextBox10.Text = row.Cells[8].Text.ToString();
            TextBox11.Text = row.Cells[9].Text.ToString();
            ListBox3.SelectedValue = row.Cells[10].Text.ToString();
            ListBox2.SelectedValue = row.Cells[11].Text.ToString();
            DBconnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            procedures.spSotrudnik_updated(DBconnection.IDrecord, TextBox5.Text.ToString(), TextBox4.Text.ToString(), TextBox6.Text.ToString(),
                TextBox7.Text.ToString(), TextBox8.Text.ToString(), TextBox9.Text.ToString(), TextBox10.Text.ToString(), TextBox11.Text.ToString(),
                Convert.ToInt32(ListBox3.SelectedValue.ToString()), Convert.ToInt32(ListBox2.SelectedValue.ToString()));
            gvFill(QR);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            procedures.spSotrudnik_delete(DBconnection.IDrecord);

            gvFill(QR);
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
            protected void gvSotrudnik_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {

                case ("Имя сотрудника"):
                    e.SortExpression = "[Name_Sotrudnik]";
                    break;
                case ("Фамилия сотрудника"):
                    e.SortExpression = "[Fam_Sotrudnik]";
                    break;
                case ("Отчество сотрудника"):
                    e.SortExpression = "[Otch_Sotrudnik]";
                    break;
                case ("Дата рождения"):
                    e.SortExpression = "[Date_Of_Rojdeniya]";
                    break;
                case ("Серия паспорта"):
                    e.SortExpression = "[Seriya_Pass]";
                    break;
                case ("Номер паспорта"):
                    e.SortExpression = "[Number_Pass]";
                    break;
                case ("Статус"):
                    e.SortExpression = "[Status]";
                    break;
                case ("Дата приема"):
                    e.SortExpression = "[Date_Of_Priem]";
                    break;
                case ("Название должности"):
                    e.SortExpression = "[Name_Doljnost]";
                    break;
                case ("Логин"):
                    e.SortExpression = "[Login]";
                    break;
            }
            sortGridView(gvSotrudnik, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Name_Sotrudnik] like '%" + TextBox2.Text + "%' or [Fam_Sotrudnik] like '%" + TextBox2.Text + "%' or [Otch_Sotrudnik] like '%" + TextBox2.Text + "%' or [Date_Of_Rojdeniya] like '%" + TextBox2.Text + "%' or [Seriya_Pass] like '%" + TextBox2.Text + "%' or [Number_Pass] like '%" +
                TextBox2.Text + "%' or [Status] like '%" + TextBox2.Text + "%' or [Date_Of_Priem] like '%" + TextBox2.Text + "%' or [Name_Doljnost] like '%" + TextBox2.Text + "%' or [Login] like '%" + TextBox2.Text + "%'";           

            gvFill(newQr);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow Row in gvSotrudnik.Rows)
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
                || Row.Cells[9].Text.Equals(TextBox2.Text)
                || Row.Cells[12].Text.Equals(TextBox2.Text)
                || Row.Cells[13].Text.Equals(TextBox2.Text))

                    Row.BackColor = System.Drawing.Color.DarkGray;
                else
                    Row.BackColor = System.Drawing.Color.White;
            }
        }
    }
}