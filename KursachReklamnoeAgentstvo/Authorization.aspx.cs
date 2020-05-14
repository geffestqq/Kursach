using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class Authorization : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBconnection.qrAuthorization;
            if (!IsPostBack)
            {
                gvFill1(QR);
                lb_Postavshik_Load(sender, e);
            }


            //QR = DBconnection.qrAuthorization;
            //{


            //    if (!IsPostBack)
            //    {
            //        gvFill(QR);
            //        lb_Postavshik_Load(sender, e);

            //    }
            //}
        }
        //private void gvFill(string qr)
        //{
        //    sdsAuthorization.ConnectionString =
        //    DBconnection.connection.ConnectionString.ToString();
        //    sdsAuthorization.SelectCommand = qr;
        //    sdsAuthorization.DataSourceMode = SqlDataSourceMode.DataReader;
        //    gvAuthorization.DataSource = sdsAuthorization;
        //    gvAuthorization.DataBind();
        //}

        private void gvFill1(string qr)
        {
            sdsAuthorization.ConnectionString = DBconnection.connection.ConnectionString.ToString();
            sdsAuthorization.SelectCommand = qr;
            sdsAuthorization.DataSourceMode = SqlDataSourceMode.DataReader;
            gvAuthorization.DataSource = sdsAuthorization;
            gvAuthorization.DataBind();
        }

        protected void gvAuthorization_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[4].Visible = false;
        }


        private string QR1 = "";
        protected void lb_Postavshik_Load(object sender, EventArgs e)
        {
            QR1 = DBconnection.qrabc;
            if (!IsPostBack)
            {
                lbRole_Fill(QR1);
            }
        }

        protected void lbRole_Fill(string qrSobese)
        {
            sdsAuthorization.ConnectionString = DBconnection.connection.ConnectionString.ToString();
            sdsAuthorization.SelectCommand = qrSobese;
            sdsAuthorization.DataSourceMode = SqlDataSourceMode.DataReader;
            ListBox1.DataSource = sdsAuthorization;
            ListBox1.DataTextField = "Доступ";
            ListBox1.DataValueField = "ID_Role";
            ListBox1.DataBind();
        }




        DBprocedure procedures = new DBprocedure();
        protected void Button3_Click(object sender, EventArgs e)
        {
            procedures.spAuthorization_insert(TextBox3.Text.ToString(), TextBox4.Text.ToString(), Convert.ToInt32(ListBox1.SelectedValue.ToString()));

            //Page_Load(sender, e);
            gvFill1(QR);
        }

        protected void gvAuthorization_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAuthorization.SelectedRow;
            TextBox3.Text = row.Cells[2].Text.ToString();
            TextBox4.Text = row.Cells[3].Text.ToString();
            ListBox1.SelectedValue = row.Cells[4].Text.ToString();
            DBconnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            procedures.spAuthorization_updated(DBconnection.IDrecord, TextBox3.Text.ToString(), TextBox4.Text.ToString(), Convert.ToInt32(ListBox1.SelectedValue.ToString()));
            gvFill1(QR);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            procedures.spAuthorization_delete(DBconnection.IDrecord);
            Page_Load(sender, e);
            gvFill1(QR);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Login] like '%" + TextBox2.Text + "%' or [Password] like '%" + TextBox2.Text + "%' or [Role_ID] like '%" + TextBox2.Text + "%'";
            gvFill1(newQr);
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
        protected void gvAuthorization_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Логин"):
                    e.SortExpression = "[Login]";
                    break;
                case ("Пароль"):
                    e.SortExpression = "[Password]";
                    break;
                case ("Роль"):
                    e.SortExpression = "[Role_ID]";
                    break;
            }
            sortGridView(gvAuthorization, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill1(QR + " order by " + e.SortExpression + " " + strDirection);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow Row in gvAuthorization.Rows)
            {
                if (Row.Cells[0].Text.Equals(TextBox2.Text)
                || Row.Cells[1].Text.Equals(TextBox2.Text)
                || Row.Cells[2].Text.Equals(TextBox2.Text)
                || Row.Cells[3].Text.Equals(TextBox2.Text)
                || Row.Cells[4].Text.Equals(TextBox2.Text)
                || Row.Cells[5].Text.Equals(TextBox2.Text)
                || Row.Cells[6].Text.Equals(TextBox2.Text))

                    Row.BackColor = System.Drawing.Color.DarkGray;
                else
                    Row.BackColor = System.Drawing.Color.White;
            }
        }
    }
}