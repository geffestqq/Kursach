using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace KursachReklamnoeAgentstvo
{
    public partial class Registr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text!=TextBox4.Text)
            {
                System.Windows.MessageBox.Show("Пароли не совпадают" +
                                       "\n Ошибка", "Рекламное агентство",
                                       MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                DBprocedure procedures = new DBprocedure();
                procedures.spAuthorization_insert(TextBox1.Text.ToString(), TextBox2.Text.ToString(), Convert.ToInt32(TextBox3.Text.ToString()));
                System.Windows.MessageBox.Show("Вы успешно зарегестрировались! " +
                                       "\n Успешно", "Рекламное агентство",
                                       MessageBoxButton.OK, MessageBoxImage.Information);
                Response.Redirect("Vhod.aspx");
            }
        }
    }
}