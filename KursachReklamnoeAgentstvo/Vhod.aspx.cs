using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace KursachReklamnoeAgentstvo
{
    public partial class Vhod : System.Web.UI.Page
    {
        private SqlCommand command
                = new SqlCommand("", DBconnection.connection);
       
        protected void Page_Load(object sender, EventArgs e)
        {

            int Major = Environment.OSVersion.Version.Major;
            int Minor = Environment.OSVersion.Version.Minor;
            RegistryKey adobe = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Adobe");             
                if (adobe != null)
                {
                    RegistryKey acrobatReader = adobe.OpenSubKey("Acrobat Reader");

                    if (acrobatReader == null)
                    {
                        MessageBox.Show("Не установлен Acrobat Reader !", "Рекламное Агенство");
                    }
                }
                RegistryKey frecKey = Registry.LocalMachine;
                Type excel = Type.GetTypeFromProgID("Excel.Application");
                if (excel == null)
                {
                    MessageBox.Show("Не установлен Excel !", "Рекламное Агенство");
                }
                Type word = Type.GetTypeFromProgID("Word.Application");
                if (word == null)
                {
                    MessageBox.Show("Не установлен Word !", "Рекламное Агенство");
                }

                 frecKey = frecKey.OpenSubKey(
                 @"HARDWARE\DESCRIPTION\System\CentralProcessor\0", false);
                Int32 MHz = Convert.ToInt32(frecKey.GetValue("~MHz").ToString());
                if (MHz < 1333)
                {
                    MessageBox.Show("Не хватает тактовой частоты процессора !", "Рекламное Агенство");
              
                }
                long before = GC.GetTotalMemory(false);
                if (before <1000)
                {
                     MessageBox.Show("Не хватает оперативной памяти на компьютере!", "Рекламное Агенство");
                }
            
         

            //foreach (var drive in DriveInfo.GetDrives())
            //{
            //    try
            //    {
            //        if (drive.AvailableFreeSpace > -1000)
            //        {
            //            MessageBox.Show("Не хватает памяти на жестком диске!", "Рекламное Агенство");
                        
            //        }
            //    }
            //    catch { }
            //}                      

        



        Thread thread = new Thread(() =>
                {
                    try
                    {
                        DBconnection connection = new DBconnection();
                        connection.dbEnter(tbLogin.Text, tbPassword.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка. Соединение с Базой данных не установленно " +
                                   " Приложение будет закрыто", "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        Environment.Exit(-1);
                    }

                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
           
            }

     

        protected void btEnter_Click(object sender, EventArgs e)
            {
            DBprocedure procedures = new DBprocedure();
                DBconnection connection = new DBconnection();
                connection.dbEnter(tbLogin.Text, tbPassword.Text);
                switch (DBconnection.IDuser)
                {
                    case (0):
                        tbLogin.BackColor = System.Drawing.Color.Red;
                        tbPassword.BackColor = System.Drawing.Color.Red;
                        lblTitle.Text = "Введён не верный логнин или пароль!";
                        tbPassword.Text = "";
                        tbLogin.Text = "";
                        break;
                    default:
                        DBconnection.strDostup = procedures.fDostup(tbLogin.Text, tbPassword.Text);
                        Response.Redirect("MainPage.aspx");
                        break;
                }          
            }

        protected void btEnter0_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registr.aspx");
        }
    }
}