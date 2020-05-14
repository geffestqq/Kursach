using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace KursachReklamnoeAgentstvo
{
    public partial class Personal_area : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //this.Label1.Text = b;
            this.lbl_Login_user.Text = DBconnection.Log;
            this.lbl_Password_User.Text = DBconnection.Pass;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            DBprocedure procedures = new DBprocedure();

            if (New_Passwrd.Text != tb_Confir_Password.Text)
            {
                MessageBox.Show("Пароли не совпадают!! " +
                        "\n Повторите попытку ввода!", "Ювилирный",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                New_Passwrd.Text = "";
                tb_Confir_Password.Text = "";
            }
            else
            {
                procedures.Password_Update(DBconnection.IDrecord, tb_Confir_Password.Text.ToString());

                DBconnection.Pass = tb_Confir_Password.Text.ToString();
                MessageBox.Show("Пароль успешно изменен " +
                        "\n ОК", "Ювилирный",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                New_Passwrd.Text = "";
                tb_Confir_Password.Text = "";
                Response.Redirect("Personal_area.aspx.aspx");
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}