using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace KursachReklamnoeAgentstvo
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            DBprocedure procedures = new DBprocedure();

            procedures.fDostup(DBconnection.Log, DBconnection.Pass);

            foreach (char dost in DBconnection.strDostup)
             {
                if (dost == '1')
                {
                    Button1.Visible = false;
                    Button2.Visible = false;
                    Button3.Visible = false;
                    Button4.Visible = false;
                    Button5.Visible = false;
                    Button7.Visible = false;
                    Button8.Visible = false;
                    Button9.Visible = false;
                    //Button10.Visible = false;
                    Button11.Visible = false;
                }




              }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Chek.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Doljnost.aspx");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Price_List.aspx");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reklama.aspx");
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sobesedovanie.aspx");
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sotrudnik.aspx");
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("Status.aspx");
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("Zakaz.aspx");
        }
        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("Klient.aspx");
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personal_area.aspx");
        }
        protected void Button14_Click(object sender, EventArgs e)
        {
            Response.Redirect("FORMSUBMISSION.aspx");
        }
        protected void Button15_Click(object sender, EventArgs e)
        {
            Response.Redirect("ONAS.aspx");
        }
        protected void Button16_Click(object sender, EventArgs e)
        {
            Response.Redirect("History.aspx");
        }
    }
}