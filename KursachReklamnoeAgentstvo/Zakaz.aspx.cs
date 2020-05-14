using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class Zakaz : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBconnection.qrZakaz;
            {
                gvFill(QR);
                lb_Postavshik_Load(sender, e);
                lb_Postavshik2_Load(sender, e);
                lb_Postavshik3_Load(sender, e);
            }
        }
        private void gvFill(string qr)
        {
            sdsZakaz.ConnectionString =
            DBconnection.connection.ConnectionString.ToString();
            sdsZakaz.SelectCommand = qr;
            sdsZakaz.DataSourceMode = SqlDataSourceMode.DataReader;
            gvZakaz.DataSource = sdsZakaz;
            gvZakaz.DataBind();
        }

        protected void gvZakaz_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
        }
        private string QR1 = "";
        protected void lb_Postavshik_Load(object sender, EventArgs e)
        {
            QR1 = DBconnection.qrChe1;
            if (!IsPostBack)
            {
                lbRole_Fill(QR1);
            }
        }

        protected void lbRole_Fill(string qrSobese)
        {
            sdsZakaz.ConnectionString = DBconnection.connection.ConnectionString.ToString();
            sdsZakaz.SelectCommand = qrSobese;
            sdsZakaz.DataSourceMode = SqlDataSourceMode.DataReader;
            ListBox1.DataSource = sdsZakaz;
            //ListBox1.DataTextField = "Логин";
            ListBox1.DataValueField = "FIO";
            ListBox1.DataBind();
        }
        private string QR2 = "";
        protected void lb_Postavshik2_Load(object sender, EventArgs e)
        {
            QR2 = DBconnection.qrChe2;
            if (!IsPostBack)
            {
                lbRole2_Fill(QR2);
            }
        }

        protected void lbRole2_Fill(string qrSobese)
        {
            sdsZakaz.ConnectionString = DBconnection.connection.ConnectionString.ToString();
            sdsZakaz.SelectCommand = qrSobese;
            sdsZakaz.DataSourceMode = SqlDataSourceMode.DataReader;
            ListBox3.DataSource = sdsZakaz;
            //ListBox1.DataTextField = "Логин";
            ListBox3.DataValueField = "FIOK";
            ListBox3.DataBind();
        }

        private string QR3 = "";
        protected void lb_Postavshik3_Load(object sender, EventArgs e)
        {
            QR3 = DBconnection.qrZak;
            if (!IsPostBack)
            {
                lbRole3_Fill(QR3);
            }
        }

        protected void lbRole3_Fill(string qrSobese)
        {
            sdsZakaz.ConnectionString = DBconnection.connection.ConnectionString.ToString();
            sdsZakaz.SelectCommand = qrSobese;
            sdsZakaz.DataSourceMode = SqlDataSourceMode.DataReader;
            ListBox4.DataSource = sdsZakaz;
            ListBox4.DataTextField = "Название статуса";
            ListBox4.DataValueField = "ID_Status";
            ListBox4.DataBind();
        }
        DBprocedure procedures = new DBprocedure();
        protected void Button3_Click(object sender, EventArgs e)
        {
            Int32 FIO = new DBconnection().ProverkaPoFio(ListBox1.SelectedValue.ToString());
            Int32 FIOK = new DBconnection().ProverkaPoFioK(ListBox3.SelectedValue.ToString());
            procedures.spZakaz_insert(TextBox3.Text.ToString(), TextBox4.Text.ToString(), TextBox6.Text.ToString(), TextBox5.Text.ToString(), Convert.ToInt32(ListBox4.SelectedValue.ToString()),FIO,FIOK);
            //Page_Load(sender, e);
            gvFill(QR);
        }

        protected void gvZakaz_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void gvZakaz_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvZakaz.SelectedRow;
            TextBox3.Text = row.Cells[2].Text.ToString();
            TextBox4.Text = row.Cells[3].Text.ToString();
            TextBox6.Text = row.Cells[4].Text.ToString();
            TextBox5.Text = row.Cells[5].Text.ToString();
            ListBox4.SelectedValue = row.Cells[6].Text.ToString();
            //ListBox2.SelectedValue = row.Cells[6].Text.ToString();
           // ListBox1.SelectedValue = row.Cells[5].Text.ToString();
            DBconnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Int32 FIO = new DBconnection().ProverkaPoFio(ListBox1.SelectedValue.ToString());
            Int32 FIOK = new DBconnection().ProverkaPoFioK(ListBox3.SelectedValue.ToString());
            procedures.spZakaz_updated(DBconnection.IDrecord,TextBox3.Text.ToString(), TextBox4.Text.ToString(), TextBox6.Text.ToString(), TextBox5.Text.ToString(), Convert.ToInt32(ListBox4.SelectedValue.ToString()), FIO, FIOK);
            //Page_Load(sender, e);
            gvFill(QR);

           
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            procedures.spZakaz_delete(DBconnection.IDrecord);
            Page_Load(sender, e);
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
        protected void gvZakaz_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Тема заказа"):
                    e.SortExpression = "[Tema_Zakaz]";
                    break;
                case ("Дата принятия"):
                    e.SortExpression = "[Date_Of_Prinat]";
                    break;
                case ("Дата окончания"):
                    e.SortExpression = "[Date_Of_End]";
                    break;
                case ("Утверждение"):
                    e.SortExpression = "[Utverjdenie]";
                    break;
                case ("Статус"):
                    e.SortExpression = "[Status_ID]";
                    break;
                case ("Сотрудник"):
                    e.SortExpression = "[Sotrudnik_Zakaz_ID]";
                    break;
                case ("Клиент"):
                    e.SortExpression = "[Klient_Zakaz_ID]";
                    break;
                case ("Название статуса"):
                    e.SortExpression = "[Name_Status]";
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
                case ("Имя Клиента"):
                    e.SortExpression = "[Name_Klient]";
                    break;
                case ("Фамилия Клиента"):
                    e.SortExpression = "[Fam_Klient]";
                    break;
                case ("Отчество Клиента"):
                    e.SortExpression = "[Otch_Klient]";
                    break;
            }
            sortGridView(gvZakaz, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Tema_Zakaz] like '%" + TextBox2.Text + "%' or [Date_Of_Prinat] like '%" + TextBox2.Text + "%' or [Date_Of_End] like '%" + TextBox2.Text + "%'";
            gvFill(newQr);
         
        }
    }
}