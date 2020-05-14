using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.DynamicData;
using System.Windows.Threading;
using System.Threading;

namespace KursachReklamnoeAgentstvo
{
    public class DBconnection
    {
        public static SqlConnection connection = new SqlConnection("Data Source =DESKTOP-T3ECMD0\\GEFFEST;" +
                     " Initial Catalog = Reklamnoe_Agentstvo; Persist Security Info = true;" +
                     " User ID = sa; Password = \"c2f5i4f53\"");
        public static string Log, Pass, Sotr;

        public DataTable dtAuthorization = new DataTable("Authorization");
        public static string qrAuthorization = "SELECT [ID_Authorization], [Login] as \"Логин\"," +
            "[Password] as \"Пароль\"," +
            "[Role_ID] as \"Роль\" ,  [Dostup_Role] as \"Доступ\" , [Dostup] as \"ДоступID\" FROM [dbo].[Authorization] inner join [dbo].[Role] on [dbo].[Authorization].[Role_id] = [dbo].[Role].[id_Role]",
        
            
            qrabc = "SELECT [ID_Role], [Dostup_Role] as \"Доступ\", [Dostup] as \"ДоступID\" FROM [dbo].[Role]";

            
            public DataTable dtRole_for_cb = new DataTable("Role_for_cb");
        public void RoleFillcb()
        {
            dtFill(dtRole_for_cb, qrabc);
        }




        public DataTable dtChek = new DataTable("Chek");
        public static string qrChek = "SELECT [ID_Chek], [Date_Of_Pechat] as \"Дата печати\"," +
            "[Type_Of_Oplata] as \"Тип оплаты\"," +
            "[Zakaz_Price_ID] as \"ЗаказПрайс\"," +
            "[Sotrudnik_Chek_ID] as \"Сотрудник\"," +
            "[Klient_Chek_ID] as \"Клиент\", [Tema_Zakaz] as \"Тема заказа\",[Cena_Price_List] as \"Цена\"," +
            "[Name_Sotrudnik] as \"Имя сотрудника\"," +
            "[Fam_Sotrudnik] as \"Фамилия сотрудника\"," +
            "[Otch_Sotrudnik] as \"Отчество сотрудника\"," +
            "[Name_Klient] as \"Имя Клиента\"," +
            "[Fam_Klient] as \"Фамилия Клиента\", " +
            "[Otch_Klient] as \"Отчество Клиента\" FROM [dbo].[Chek] inner join[dbo].[Zakaz_Price] on[dbo].[Chek].[Zakaz_Price_ID] = [dbo].[Zakaz_Price].[id_Zakaz_Price]" +
            "inner join [dbo].[Zakaz] on [Zakaz_ID] = [ID_Zakaz]" +
            "inner join [dbo].[Price_List] on [Price_List_ID] = [ID_Price_List]" +
            "inner join[dbo].[Sotrudnik] on[dbo].[Chek].[Sotrudnik_Chek_ID] = [dbo].[Sotrudnik].[id_Sotrudnik]" +
            "inner join[dbo].[Klient] on[dbo].[Chek].[Klient_Chek_ID] = [dbo].[Klient].[id_Klient]",

             qrChe1 = "SELECT [id_Sotrudnik],[Name_Sotrudnik] + ' ' +[Fam_Sotrudnik]+ ' ' +[Otch_Sotrudnik] as FIO FROM [dbo].[Sotrudnik]",
            qrChe3 = "SELECT [id_Zakaz_Price], [Tema_Zakaz] as \"Тема заказа\" FROM [dbo].[Zakaz_Price]",
        qrChe2 = "SELECT [id_Klient],[Name_Klient] + ' ' +[Fam_Klient]+ ' ' +[Otch_Klient] as FIOK FROM [dbo].[Klient]";


        public DataTable dtDoljnost = new DataTable("Doljnost");
        public static string qrDoljnost = "SELECT [ID_Doljnost], [Name_Doljnost] as \"Название должности\"," +
            "[Zarplata] as \"Зарплата\"   FROM [dbo].[Doljnost]";





        public DataTable dtKlient = new DataTable("Klient");
        public static string qrKlient = "SELECT [ID_Klient], [Name_Klient] as \"Имя_Клиента\"," +
            "[Fam_Klient] as \"Фамилия_Клиента\", " +
            "[Otch_Klient] as \"Отчество_Клиента\", [Phone_Number_K] as \"Номер_телефона\"," +
            "[Email_Klient] as \"Почта\"," +
            "[Authorization_Klient_ID] as \"Авторизация\", [Login] as \"Логин\"  FROM [dbo].[Klient] inner join [dbo].[Authorization] on [dbo].[Klient].[Authorization_Klient_ID] = [dbo].[Authorization].[ID_Authorization]",

            qrkl = "SELECT [ID_Authorization], [Login] as \"Логин\" FROM [dbo].[Authorization]";

        public DataTable dtPrice_List = new DataTable("Price_List");
        public static string qrPrice_List = "SELECT [ID_Price_List]," +
            "[Name_Price_List] as \"Название\"," +
            "[Srok_Price_List] as \"Срок выполнения\"," +
            "[Cena_Price_List] as \"Цена\"  FROM [dbo].[Price_List]";

        public DataTable dtReklama = new DataTable("Reklama");
        public static string qrReklama = "SELECT [ID_Reklama], [dbo].[Reklama].[Status] as \"Статус\"," +
            "[Date_Of_Begin] as \"Дата начала\"," +
            "[Zakaz_Reklama_ID] as \"ЗаказРеклама\"," +
            "[Sotrudnik_Reklama_ID] as \"СотрудникРеклама\"," +
            "[Name_Sotrudnik] as \"Имя сотрудника\"," +
            "[Fam_Sotrudnik] as \"Фамилия сотрудника\"," +
            "[Otch_Sotrudnik] as \"Отчество сотрудника\"," +
            "[Tema_Zakaz] as \"Тема заказа\" FROM [dbo].[Reklama] inner join[dbo].[Zakaz] on[dbo].[Reklama].[Zakaz_Reklama_ID] = [dbo].[Zakaz].[id_Zakaz]" +
            "inner join[dbo].[Sotrudnik] on[dbo].[Reklama].[Sotrudnik_Reklama_ID] = [dbo].[Sotrudnik].[id_Sotrudnik]",

            qrRek = "SELECT [id_Sotrudnik],[Name_Sotrudnik] + ' ' +[Fam_Sotrudnik]+ ' ' +[Otch_Sotrudnik] as FIO FROM [dbo].[Sotrudnik]",

            qrRek2 = "SELECT [id_Zakaz], [Tema_Zakaz] as \"Тема заказа\" FROM [dbo].[Zakaz]";


        public DataTable dtRole = new DataTable("Role");
        public static string qrRole = "SELECT [ID_Role], [Name_Role] as \"Название роли\"," +
            "[Dostup] as \"ДоступАдмин\"," +
            "[Dostup_Role] as \"Доступ\"   FROM [dbo].[Role]";

        public DataTable dtSobesedovanie = new DataTable("Sobesedovanie");
        public static string qrSobesedovanie = "SELECT [ID_Sobesedovanie], [Date_Sobesedovanie] as \"Дата собеседования\"," +
            "[Result_Sobesedovanie] as \"Результат собеседования\" FROM [dbo].[Sobesedovanie]";

        public DataTable dtSotrudnik = new DataTable("Sotrudnik");
        public static string qrSotrudnik = "SELECT [ID_Sotrudnik], [Name_Sotrudnik] as \"Имя сотрудника\"," +
            "[Fam_Sotrudnik] as \"Фамилия сотрудника\"," +
            "[Otch_Sotrudnik] as \"Отчество сотрудника\"," +
            "[Date_Of_Rojdeniya] as \"Дата рождения\"," +
            "[Seriya_Pass] as \"Серия паспорта\"," +
            "[Number_Pass] as \"Номер паспорта\"," +
            "[Status] as \"Статус\"," +
            "[Date_Of_Priem] as \"Дата приема\"," +
            "[Doljnost_ID] as \"Должность\"," +
            "[Authorization_ID] as \"ЛогинИД\",[Name_Doljnost] as \"Название должности\",[Login] as \"Логин\"  FROM [dbo].[Sotrudnik] inner join [dbo].[Doljnost] on [dbo].[Sotrudnik].[Doljnost_ID] = [dbo].[Doljnost].[id_Doljnost]" +
            " inner join [dbo].[Authorization] on [dbo].[Sotrudnik].[Authorization_ID] = [dbo].[Authorization].[id_Authorization]",

            qrst = "SELECT [ID_Authorization], [Login] as \"Логин\" FROM [dbo].[Authorization]" , qrst2 = "SELECT [id_Doljnost], [Name_Doljnost] as \"Название должности\" FROM [dbo].[Doljnost]";

        public DataTable dtSotrudnik_Sobesedovanie = new DataTable("Sotrudnik_Sobesedovanie");
        public static string qrSotrudnik_Sobesedovanie = "SELECT [ID_Sotrudnik_Sobesedovanie]," + 
            "[Sobesedovanie_ID] as \"Собеседование\"," +
            "[Sotrudnik_Sobesedovanie_ID] as \"Сотрудник\"," +
            "[Name_Sotrudnik] as \"Имя сотрудника\"," +
            "[Fam_Sotrudnik] as \"Фамилия сотрудника\"," +
            "[Otch_Sotrudnik] as \"Отчество сотрудника\",[Date_Sobesedovanie] as \"Дата собеседования\" FROM [dbo].[Sotrudnik_Sobesedovanie] inner join[dbo].[Sotrudnik] on[dbo].[Sotrudnik_Sobesedovanie].[Sotrudnik_Sobesedovanie_ID] = [dbo].[Sotrudnik].[id_Sotrudnik] " +
            "inner join[dbo].[Sobesedovanie] on[dbo].[Sotrudnik_Sobesedovanie].[Sobesedovanie_ID] = [dbo].[Sobesedovanie].[id_Sobesedovanie]";

        public DataTable dtStatus = new DataTable("Status");
        public static string qrStatus = "SELECT [ID_Status], [Name_Status] as \"Название статуса\"  FROM [dbo].[Status]";

        public DataTable dtZakaz = new DataTable("Zakaz");
        public static string qrZakaz = "SELECT [ID_Zakaz], [Tema_Zakaz] as \"Тема заказа\"," +
            "[Date_Of_Prinat] as \"Дата принятия\"," +
            "[Date_Of_End] as \"Дата окончания\"," +
            "[Utverjdenie] as \"Утверждение\"," +
            "[Status_ID] as \"Статус\"," +
            "[Sotrudnik_Zakaz_ID] as \"Сотрудник\"," +
            "[Klient_Zakaz_ID] as \"Клиент\"," +
            "[Name_Status] as \"Название статуса\"," +
            "[Name_Sotrudnik] as \"Имя сотрудника\"," +
            "[Fam_Sotrudnik] as \"Фамилия сотрудника\"," +
            "[Otch_Sotrudnik] as \"Отчество сотрудника\"," +
            "[Name_Klient] as \"Имя Клиента\"," +
            "[Fam_Klient] as \"Фамилия Клиента\", " +
            "[Otch_Klient] as \"Отчество Клиента\" FROM [dbo].[Zakaz] inner join[dbo].[Status] on[dbo].[Zakaz].[Status_ID] = [dbo].[Status].[id_Status]" +
            "inner join[dbo].[Sotrudnik] on[dbo].[Zakaz].[Sotrudnik_Zakaz_ID] = [dbo].[Sotrudnik].[id_Sotrudnik] inner join[dbo].[Klient] on[dbo].[Zakaz].[Klient_Zakaz_ID] = [dbo].[Klient].[id_Klient]",

             qrZak = "SELECT [ID_Status], [Name_Status] as \"Название статуса\" FROM [dbo].[Status]";

        public DataTable dtZakaz_Price = new DataTable("Zakaz_Price");
        public static string qrZakaz_Price = "SELECT [ID_Zakaz_Price]," +
            "[Zakaz_ID] as \"Заказ\"," +
            "[Price_List_ID] as \"Прайс\",[Tema_Zakaz] as \"Тема заказа\",[Cena_Price_List] as \"Цена\" FROM [dbo].[Zakaz_Price] inner join [dbo].[Zakaz] on[dbo].[Zakaz_Price].[Zakaz_ID] = [dbo].[Zakaz].[id_Zakaz] " +
            "inner join [dbo].[Price_List] on [dbo].[Zakaz_Price].[Price_List_ID] = [dbo].[Price_List].[id_Price_List]";


        public DataTable dtHistory = new DataTable("History");
        public static string qrHistory = "SELECT [ID_History], [ProductId] as \"Номер в бд\"," +
            "[Operation] as \"Операция\" FROM [dbo].[History]";

        public Int32 ProverkaPoFio(string FIO)
        {
            command.CommandText = $"SELECT [id_Sotrudnik] FROM [dbo].[Sotrudnik] where [Name_Sotrudnik] + ' ' +[Fam_Sotrudnik]+ ' ' +[Otch_Sotrudnik] = '{FIO}'";
            connection.Open();
            Int32 ID_FIO = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            return ID_FIO;
        }

        public Int32 ProverkaPoFioK(string FIOK)
        {
            command.CommandText = $"SELECT [id_Klient]  FROM [dbo].[Klient] where [Name_Klient] + ' ' +[Fam_Klient]+ ' ' +[Otch_Klient]  = '{FIOK}'";
            connection.Open();
            Int32 ID_FIO = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            return ID_FIO;
        }


        public void AuthorizationFill()
        {
            ThreadStart threadStart = new ThreadStart(AuthorizationFill);
            Thread child = new Thread(threadStart);
            child.Start();
            Thread.Sleep(2000);
            child.Abort();

            dtFill(dtAuthorization, qrAuthorization);
        }

        public void ChekFill()
        {
            dtFill(dtChek, qrChek);
        }
        public void HistoryFill()
        {
            dtFill(dtHistory, qrHistory);
        }

        public void DoljnostFill()
        {
            dtFill(dtDoljnost, qrDoljnost);
        }

        public void KlientFill()
        {
            dtFill(dtKlient, qrKlient);
        }

        public void Price_ListFill()
        {
            dtFill(dtPrice_List, qrPrice_List);
        }

        public void ReklamaFill()
        {
            dtFill(dtReklama, qrReklama);
        }

        public void RoleFill()
        {
            dtFill(dtRole, qrRole);
        }

        public void SobesedovanieFill()
        {
            dtFill(dtSobesedovanie, qrSobesedovanie);
        }

        public void SotrudnikFill()
        {
            dtFill(dtSotrudnik, qrSotrudnik);
        }

        public void Sotrudnik_SobesedovanieFill()
        {
            dtFill(dtSotrudnik_Sobesedovanie, qrSotrudnik_Sobesedovanie);
        }

        public void StatusFill()
        {
            dtFill(dtStatus, qrStatus);
        }

        public void ZakazFill()
        {
            dtFill(dtZakaz, qrZakaz);
        }

        public void Zakaz_PriceFill()
        {
            dtFill(dtZakaz_Price, qrZakaz_Price);
        }


        private SqlCommand command = new SqlCommand("", connection);
        public static Int32 IDrecord, IDuser;

        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public static string strDostup;
        public void dbEnter(string login, string password)
        {
            command.CommandText = "SELECT count (*) FROM [dbo].[Authorization]" +
                "where [Login] = '" + login + "' and [Password] = '" +
                password + "'";
            connection.Open();
            IDuser = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }
    }
}