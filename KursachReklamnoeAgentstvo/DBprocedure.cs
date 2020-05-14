using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KursachReklamnoeAgentstvo
{
    public class DBprocedure
    {
        private SqlCommand command
             = new SqlCommand("", DBconnection.connection);

        private void commandConfig(string config)
        {
            command.CommandType =
                System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }

        public void Password_Update(Int32 ID_Authorization, string Password)
        {
            commandConfig("Password_updated");
            command.Parameters.AddWithValue("@ID_Authorization", ID_Authorization);
            command.Parameters.AddWithValue("@Password", Password);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }
        public string fDostup(string login, string password)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT [Role_ID] FROM [dbo].[Authorization] WHERE [Login] = '" + login + "' AND [Password] = '" + password + "'";
            DBconnection.connection.Open();
            string Dostup = command.ExecuteScalar().ToString();
            DBconnection.Log = login;
            DBconnection.Pass = password;
            DBconnection.connection.Close();
            return (Dostup);
        }
        //#1 ТАБЛИЦА ДОЛЖНОСТИ
        public void spDoljnost_insert(string Name_Doljnost, decimal Zarplata)
        {
            //обращение к хранимой процедуре
            commandConfig("Doljnost_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Name_Doljnost", Name_Doljnost);
            command.Parameters.AddWithValue("@Zarplata", Zarplata);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spDoljnost_updated(Int32 ID_Doljnost, string Name_Doljnost, decimal Zarplata)
        {
            commandConfig("Doljnost_updated");
            command.Parameters.AddWithValue("@ID_Doljnost", ID_Doljnost);
            command.Parameters.AddWithValue("@Name_Doljnost", Name_Doljnost);
            command.Parameters.AddWithValue("@Zarplata", Zarplata);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spDoljnost_delete(Int32 ID_Doljnost)
        {
            commandConfig("Doljnost_delete");
            command.Parameters.AddWithValue("@ID_Doljnost", ID_Doljnost);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#2 ТАБЛИЦА РОЛИ
        public void spRole_insert(string Name_Role, Int32 Dostup, string Dostup_Role)
        {
            //обращение к хранимой процедуре
            commandConfig("Role_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Name_Role", Name_Role);
            command.Parameters.AddWithValue("@Dostup", Dostup);
            command.Parameters.AddWithValue("@Dostup_Role", Dostup_Role);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spRole_updated(Int32 ID_Role, string Name_Role, Int32 Dostup, string Dostup_Role)
        {
            commandConfig("Role_updated");
            command.Parameters.AddWithValue("@ID_Role", ID_Role);
            command.Parameters.AddWithValue("@Name_Role", Name_Role);
            command.Parameters.AddWithValue("@Dostup", Dostup);
            command.Parameters.AddWithValue("@Dostup_Role", Dostup_Role);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spRole_delete(Int32 ID_Role)
        {
            commandConfig("Role_delete");
            command.Parameters.AddWithValue("@ID_Role", ID_Role);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#3 ТАБЛИЦА АВТОРИЗАЦИЯ
        public void spAuthorization_insert(string Login, string Password, Int32 Role_ID)
        {
            //обращение к хранимой процедуре
            commandConfig("Authorization_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Login", Login);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Role_ID", Role_ID);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spAuthorization_updated(Int32 ID_Authorization, string Login, string Password, Int32 Role_ID)
        {
            commandConfig("Authorization_updated");
            command.Parameters.AddWithValue("@ID_Authorization", ID_Authorization);
            command.Parameters.AddWithValue("@Login", Login);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Role_ID", Role_ID);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spAuthorization_delete(Int32 ID_Authorization)
        {
            commandConfig("Authorization_delete");
            command.Parameters.AddWithValue("@ID_Authorization", ID_Authorization);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#4 ТАБЛИЦА СОТРУДНИКИ
        public void spSotrudnik_insert(string Name_Sotrudnik, string Fam_Sotrudnik, string Otch_Sotrudnik,
            string Date_Of_Rojdeniya, string Seriya_Pass, string Number_Pass, string Status, string Date_Of_Priem,
            Int32 Doljnost_ID, Int32 Authorization_ID)
        {
            //обращение к хранимой процедуре
            commandConfig("Sotrudnik_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Name_Sotrudnik", Name_Sotrudnik);
            command.Parameters.AddWithValue("@Fam_Sotrudnik", Fam_Sotrudnik);
            command.Parameters.AddWithValue("@Otch_Sotrudnik", Otch_Sotrudnik);
            command.Parameters.AddWithValue("@Date_Of_Rojdeniya", Date_Of_Rojdeniya);
            command.Parameters.AddWithValue("@Seriya_Pass", Seriya_Pass);
            command.Parameters.AddWithValue("@Number_Pass", Number_Pass);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@Date_Of_Priem", Date_Of_Priem);
            command.Parameters.AddWithValue("@Doljnost_ID", Doljnost_ID);
            command.Parameters.AddWithValue("@Authorization_ID", Authorization_ID);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spSotrudnik_updated(Int32 ID_Sotrudnik, string Name_Sotrudnik, string Fam_Sotrudnik, string Otch_Sotrudnik,
            string Date_Of_Rojdeniya, string Seriya_Pass, string Number_Pass, string Status, string Date_Of_Priem,
            Int32 Doljnost_ID, Int32 Authorization_ID)
        {
            commandConfig("Sotrudnik_updated");
            command.Parameters.AddWithValue("@ID_Sotrudnik", ID_Sotrudnik);
            command.Parameters.AddWithValue("@Name_Sotrudnik", Name_Sotrudnik);
            command.Parameters.AddWithValue("@Fam_Sotrudnik", Fam_Sotrudnik);
            command.Parameters.AddWithValue("@Otch_Sotrudnik", Otch_Sotrudnik);
            command.Parameters.AddWithValue("@Date_Of_Rojdeniya", Date_Of_Rojdeniya);
            command.Parameters.AddWithValue("@Seriya_Pass", Seriya_Pass);
            command.Parameters.AddWithValue("@Number_Pass", Number_Pass);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@Date_Of_Priem", Date_Of_Priem);
            command.Parameters.AddWithValue("@Doljnost_ID", Doljnost_ID);
            command.Parameters.AddWithValue("@Authorization_ID", Authorization_ID);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spSotrudnik_delete(Int32 ID_Sotrudnik)
        {
            commandConfig("Sotrudnik_delete");
            command.Parameters.AddWithValue("@ID_Sotrudnik", ID_Sotrudnik);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#5 ТАБЛИЦА СОБЕСЕДОВАНИЕ
        public void spSobesedovanie_insert(string Date_Sobesedovanie, string Result_Sobesedovanie)
        {
            //обращение к хранимой процедуре
            commandConfig("Sobesedovanie_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Date_Sobesedovanie", Date_Sobesedovanie);
            command.Parameters.AddWithValue("@Result_Sobesedovanie", Result_Sobesedovanie);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spSobesedovanie_updated(Int32 ID_Sobesedovanie, string Date_Sobesedovanie, string Result_Sobesedovanie)
        {
            commandConfig("Sobesedovanie_updated");
            command.Parameters.AddWithValue("@ID_Sobesedovanie", ID_Sobesedovanie);
            command.Parameters.AddWithValue("@Date_Sobesedovanie", Date_Sobesedovanie);
            command.Parameters.AddWithValue("@Result_Sobesedovanie", Result_Sobesedovanie);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spSobesedovanie_delete(Int32 ID_Sobesedovanie)
        {
            commandConfig("Sobesedovanie_delete");
            command.Parameters.AddWithValue("@ID_Sobesedovanie", ID_Sobesedovanie);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#6 ТАБЛИЦА СОТРУДНИК-СОБЕСЕДОВАНИЕ
        public void spSotrudnik_Sobesedovanie_insert(int Sobesedovanie_ID, int Sotrudnik_Sobesedovanie_ID)
        {
            //обращение к хранимой процедуре
            commandConfig("Sotrudnik_Sobesedovanie_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Sobesedovanie_ID", Sobesedovanie_ID);
            command.Parameters.AddWithValue("@Sotrudnik_Sobesedovanie_ID", Sotrudnik_Sobesedovanie_ID);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spSotrudnik_Sobesedovanie_updated(int ID_Sotrudnik_Sobesedovanie, int Sobesedovanie_ID, int Sotrudnik_Sobesedovanie_ID)
        {
            commandConfig("Sotrudnik_Sobesedovanie_updated");
            command.Parameters.AddWithValue("@ID_Sotrudnik_Sobesedovanie", ID_Sotrudnik_Sobesedovanie);
            command.Parameters.AddWithValue("@Sobesedovanie_ID", Sobesedovanie_ID);
            command.Parameters.AddWithValue("@Sotrudnik_Sobesedovanie_ID", Sotrudnik_Sobesedovanie_ID);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spSotrudnik_Sobesedovanie_delete(int ID_Sotrudnik_Sobesedovanie)
        {
            commandConfig("Sotrudnik_Sobesedovanie_delete");
            command.Parameters.AddWithValue("@ID_Sotrudnik_Sobesedovanie", ID_Sotrudnik_Sobesedovanie);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#7 ТАБЛИЦА КЛИЕНТ
        public void spKlient_insert(string Name_Klient, string Fam_Klient,
           string Otch_Klient, string Phone_Number_K, string Email_Klient, Int32 Authorization_Klient_ID)
        {
            //обращение к хранимой процедуре
            commandConfig("Klient_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Name_Klient", Name_Klient);
            command.Parameters.AddWithValue("@Fam_Klient", Fam_Klient);
            command.Parameters.AddWithValue("@Otch_Klient", Otch_Klient);
            command.Parameters.AddWithValue("@Phone_Number_K", Phone_Number_K);
            command.Parameters.AddWithValue("@Email_Klient", Email_Klient);
            command.Parameters.AddWithValue("@Authorization_Klient_ID", Authorization_Klient_ID);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spKlient_updated(Int32 ID_Klient, string Name_Klient, string Fam_Klient,
           string Otch_Klient, string Phone_Number_K, string Email_Klient, Int32 Authorization_Klient_ID)
        {
            commandConfig("Klient_updated");
            command.Parameters.AddWithValue("@ID_Klient", ID_Klient);
            command.Parameters.AddWithValue("@Name_Klient", Name_Klient);
            command.Parameters.AddWithValue("@Fam_Klient", Fam_Klient);
            command.Parameters.AddWithValue("@Otch_Klient", Otch_Klient);
            command.Parameters.AddWithValue("@Phone_Number_K", Phone_Number_K);
            command.Parameters.AddWithValue("@Email_Klient", Email_Klient);
            command.Parameters.AddWithValue("@Authorization_Klient_ID", Authorization_Klient_ID); ;
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spKlient_delete(Int32 ID_Klient)
        {
            commandConfig("Klient_delete");
            command.Parameters.AddWithValue("@ID_Klient", ID_Klient);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#8 ТАБЛИЦА СТАТУС
        public void spStatus_insert(string Name_Status)
        {
            //обращение к хранимой процедуре
            commandConfig("Status_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Name_Status", Name_Status);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spStatus_updated(Int32 ID_Status,string Name_Status)
        {
            commandConfig("Status_updated");
            command.Parameters.AddWithValue("@ID_Status", ID_Status);
            command.Parameters.AddWithValue("@Name_Status", Name_Status);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spStatus_delete(Int32 ID_Status)
        {
            commandConfig("Status_delete");
            command.Parameters.AddWithValue("@ID_Status", ID_Status);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#9 ТАБЛИЦА ЗАКАЗ
        public void spZakaz_insert(string Tema_Zakaz, string Date_Of_Prinat, string Date_Of_End,
            string Utverjdenie, Int32 Status_ID, Int32 Sotrudnik_Zakaz_ID, Int32 Klient_Zakaz_ID)
        {
            //обращение к хранимой процедуре
            commandConfig("Zakaz_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Tema_Zakaz", Tema_Zakaz);
            command.Parameters.AddWithValue("@Date_Of_Prinat", Date_Of_Prinat);
            command.Parameters.AddWithValue("@Date_Of_End", Date_Of_End);
            command.Parameters.AddWithValue("@Utverjdenie", Utverjdenie);
            command.Parameters.AddWithValue("@Status_ID", Status_ID);
            command.Parameters.AddWithValue("@Sotrudnik_Zakaz_ID", Sotrudnik_Zakaz_ID);
            command.Parameters.AddWithValue("@Klient_Zakaz_ID", Klient_Zakaz_ID);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spZakaz_updated(Int32 ID_Zakaz, string Tema_Zakaz, string Date_Of_Prinat, string Date_Of_End,
            string Utverjdenie, Int32 Status_ID, Int32 Sotrudnik_Zakaz_ID, Int32 Klient_Zakaz_ID)
        {
            commandConfig("Zakaz_updated");
            command.Parameters.AddWithValue("@ID_Zakaz", ID_Zakaz);
            command.Parameters.AddWithValue("@Tema_Zakaz", Tema_Zakaz);
            command.Parameters.AddWithValue("@Date_Of_Prinat", Date_Of_Prinat);
            command.Parameters.AddWithValue("@Date_Of_End", Date_Of_End);
            command.Parameters.AddWithValue("@Utverjdenie", Utverjdenie);
            command.Parameters.AddWithValue("@Status_ID", Status_ID);
            command.Parameters.AddWithValue("@Sotrudnik_Zakaz_ID", Sotrudnik_Zakaz_ID);
            command.Parameters.AddWithValue("@Klient_Zakaz_ID", Klient_Zakaz_ID);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spZakaz_delete(Int32 ID_Zakaz)
        {
            commandConfig("Zakaz_delete");
            command.Parameters.AddWithValue("@ID_Zakaz", ID_Zakaz);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#10 ТАБЛИЦА РЕКЛАМА
        public void spReklama_insert(string Status, string Date_Of_Begin, Int32 Zakaz_Reklama_ID,
            Int32 Sotrudnik_Reklama_ID)
        {
            //обращение к хранимой процедуре
            commandConfig("Reklama_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@Date_Of_Begin", Date_Of_Begin);
            command.Parameters.AddWithValue("@Zakaz_Reklama_ID", Zakaz_Reklama_ID);
            command.Parameters.AddWithValue("@Sotrudnik_Reklama_ID", Sotrudnik_Reklama_ID);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spReklama_updated(Int32 ID_Reklama, string Status, string Date_Of_Begin, Int32 Zakaz_Reklama_ID,
            Int32 Sotrudnik_Reklama_ID)
        {
            commandConfig("Reklama_updated");
            command.Parameters.AddWithValue("@ID_Reklama", ID_Reklama);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@Date_Of_Begin", Date_Of_Begin);
            command.Parameters.AddWithValue("@Zakaz_Reklama_ID", Zakaz_Reklama_ID);
            command.Parameters.AddWithValue("@Sotrudnik_Reklama_ID", Sotrudnik_Reklama_ID);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spReklama_delete(Int32 ID_Reklama)
        {
            commandConfig("Reklama_delete");
            command.Parameters.AddWithValue("@ID_Reklama", ID_Reklama);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#11 ТАБЛИЦА ПРАЙС ЛИСТ
        public void spPrice_List_insert(string Name_Price_List, string Srok_Price_List, Int32 Cena_Price_List)
        {
            //обращение к хранимой процедуре
            commandConfig("Price_List_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Name_Price_List", Name_Price_List);
            command.Parameters.AddWithValue("@Srok_Price_List", Srok_Price_List);
            command.Parameters.AddWithValue("@Cena_Price_List", Cena_Price_List);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spPrice_List_updated(Int32 ID_Price_List, string Name_Price_List, string Srok_Price_List, Int32 Cena_Price_List)
        {
            commandConfig("Price_List_updated");
            command.Parameters.AddWithValue("@ID_Price_List", ID_Price_List);
            command.Parameters.AddWithValue("@Name_Price_List", Name_Price_List);
            command.Parameters.AddWithValue("@Srok_Price_List", Srok_Price_List);
            command.Parameters.AddWithValue("@Cena_Price_List", Cena_Price_List);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spPrice_List_delete(Int32 ID_Price_List)
        {
            commandConfig("Price_List_delete");
            command.Parameters.AddWithValue("@ID_Price_List", ID_Price_List);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#12 ТАБЛИЦА ЗАКАЗ-ПРАЙС
        public void spZakaz_Price_insert(int Zakaz_ID, int Price_List_ID)
        {
            //обращение к хранимой процедуре
            commandConfig("Zakaz_Price_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Zakaz_ID", Zakaz_ID);
            command.Parameters.AddWithValue("@Price_List_ID", Price_List_ID);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spZakaz_Price_updated(int ID_Zakaz_Price, int Zakaz_ID, int Price_List_ID)
        {
            commandConfig("Zakaz_Price_updated");
            command.Parameters.AddWithValue("@ID_Zakaz_Price", ID_Zakaz_Price);
            command.Parameters.AddWithValue("@Zakaz_ID", Zakaz_ID);
            command.Parameters.AddWithValue("@Price_List_ID", Price_List_ID);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spZakaz_Price_delete(int ID_Zakaz_Price)
        {
            commandConfig("Zakaz_Price_delete");
            command.Parameters.AddWithValue("@ID_Zakaz_Price", ID_Zakaz_Price);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //#13 ТАБЛИЦА ЧЕК
        public void spChek_insert(string Date_Of_Pechat, string Type_Of_Oplata, Int32 Zakaz_Price_ID,
          Int32 Sotrudnik_Chek_ID, Int32 Klient_Chek_ID)
        {
            //обращение к хранимой процедуре
            commandConfig("Chek_insert");
            //обозначение входных параметров
            command.Parameters.AddWithValue("@Date_Of_Pechat", Date_Of_Pechat);
            command.Parameters.AddWithValue("@Type_Of_Oplata", Type_Of_Oplata);
            command.Parameters.AddWithValue("@Zakaz_Price_ID", Zakaz_Price_ID);
            command.Parameters.AddWithValue("@Sotrudnik_Chek_ID", Sotrudnik_Chek_ID);
            command.Parameters.AddWithValue("@Klient_Chek_ID", Klient_Chek_ID);
            //подключение, выполнение команды и отключение
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();

        }

        //изменение
        public void spChek_updated(int ID_Chek,string Date_Of_Pechat, string Type_Of_Oplata, int Zakaz_Price_ID,
          int Sotrudnik_Chek_ID, int Klient_Chek_ID)
        {
            commandConfig("Chek_updated");
            command.Parameters.AddWithValue("@ID_Chek", ID_Chek);
            command.Parameters.AddWithValue("@Date_Of_Pechat", Date_Of_Pechat);
            command.Parameters.AddWithValue("@Type_Of_Oplata", Type_Of_Oplata);
            command.Parameters.AddWithValue("@Zakaz_Price_ID", Zakaz_Price_ID);
            command.Parameters.AddWithValue("@Sotrudnik_Chek_ID", Sotrudnik_Chek_ID);
            command.Parameters.AddWithValue("@Klient_Chek_ID", Klient_Chek_ID);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }

        //удаление
        public void spChek_delete(int ID_Chek)
        {
            commandConfig("Chek_delete");
            command.Parameters.AddWithValue("@ID_Chek", ID_Chek);
            DBconnection.connection.Open();
            command.ExecuteNonQuery();
            DBconnection.connection.Close();
        }
    }
}