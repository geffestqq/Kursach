using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursachReklamnoeAgentstvo
{
    public partial class Backup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        SqlConnection con = new SqlConnection("Data Source =DESKTOP-T3ECMD0\\GEFFEST;" +
                     " Initial Catalog = Reklamnoe_Agentstvo;Integrated Security=True");
        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
        private void DbRestore_Complete(object sender, ServerMessageEventArgs e)
        {
           
        }
        private void DbRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            
        }
         
        protected void Button1_Click1(object sender, EventArgs e)
        {

            Thread thread = new Thread(() =>
            {
                FolderBrowserDialog fdt = new FolderBrowserDialog();
                if (fdt.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fdt.SelectedPath;
                }
         
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string qry = "BACKUP DATABASE [" + con.Database + "] TO  DISK = N'" + txtPath.Text + "\\" + con.Database + ".bak'";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Резервная копия Базы Данных была создана!");
                txtPath.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Backup File(*.bak)|*.bak";
                ofd.Title = "Select backup file";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtRestore.Text = ofd.FileName;
                }

            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();          
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string qry = "USE [master] RESTORE DATABASE[" + con.Database + "] FROM DISK = N'" + txtRestore.Text + " ' WITH FILE = 1; ";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("База данных была загружена!");
                txtRestore.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}