using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CW_Medicine
{
    static class WorkWithDB
    {
        private static SqlConnection con = new SqlConnection(@"Server=ПК\SQLEXPRESS;Database=CW_Med;Trusted_Connection=Yes;");//создание подключения
        public static DataSet ds = new DataSet("Med");//создание объекта  DataSet

        /// <summary>
        /// Заполнение DataSet данными из  базы данных
        /// </summary>
        public static void CreateDataSet()
        {
            ds.Clear();
            string[] tablename = { "AccessRights", "Amount", "Applaying", "Dosage", "DosageForm", "Groups", "Medicine", "Sessions", "Subgroup", "Users" };
            con.Open();
            for (int i = 0; i < tablename.Length; i++)
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select * From " + tablename[i], con);
                sda.Fill(ds, tablename[i]);
            }                                                                                                                           
            con.Close();


          
        }

        /// <summary>
        /// Получение идентификатора пользователя, если его
        /// не существует,то добавляет имя пользователя в базу данных
        /// </summary>
        public static string GetUserId(string userName)
        {
            string expression = "Login = '" + userName + "'"; //параметры фильтра
            DataRow[] rows = ds.Tables["Users"].Select(expression);//поиск строк
            if (rows.Length == 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Users", con);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                DataRow row = ds.Tables["Users"].NewRow(); //создание новой строки таблицы
                row[0] = 3;
                row[1] = userName;
                row[2] = Info.password;
                row[3] = "1";
                ds.Tables["Users"].Rows.Add(row);//добавление строки в таблицу
                con.Open();// открытие соединения

                sda.Update(ds.Tables["Users"]);//обновление таблицы

                ds.Tables.Remove("Users");//перезапись таблицы
                sda.Fill(ds, "Users");
                con.Close(); //закрытие соединения
                return GetUserId(userName);
            }
            else
            {
                return rows[0][0].ToString();
            }
        }

        /// <summary>
        /// Запись результатов текущей сессии
        /// </summary>
        public static void WriteCurrentSession()
        {
            DataRow row = ds.Tables["Sessions"].NewRow();//формирование новой записи
            row[1] = Info.idUserName;
            row[2] = DateTime.Now;
            row[3] = Info.mode;
            row[4] = Info.posAns.ToString() + "/" + Info.amountAns.ToString(); ;
            con.Open();//открытие соединения
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Sessions", con);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            ds.Tables["Sessions"].Rows.Add(row);//добавлениезаписи в таблицу
            sda.Update(ds.Tables["Sessions"]);
            con.Close();//закрытие соединения
            Info.posAns = 0;//обнуление счетчика ответов
            Info.amountAns = 0;
        }

        /// <summary>
        /// Обновление таблицы
        /// </summary>
        public static void UpdateTable(string currentTable)
        {
            con.Open();
            string query = "Select * from " + currentTable;
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(ds.Tables[currentTable]);
            ds.Tables[currentTable].Clear();
            sda.Fill(ds, currentTable);
            con.Close();
        }

        /// <summary>
        /// Удаление строки
        /// </summary>
        public static void DeleteRow(string currentTable, int index)
        {
            con.Open();
            string query = "Select * from " + currentTable;
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            ds.Tables[currentTable].Rows[index].Delete();
            sda.Update(ds.Tables[currentTable]);
            ds.Tables[currentTable].Clear();
            sda.Fill(ds, currentTable);
            con.Close();
        }

        /// <summary>Вставка строкиОбновление таблицы
        /// </summary>
        public static void InsertRow(string currentTable)
        {

            DataRow row = ds.Tables[currentTable].NewRow();
            ds.Tables[currentTable].Rows.Add(row);
        }

        /// <summary>
        /// Создание улучшенной таблицы сессии
        /// </summary>
        public static void CreateStatisticsView()
        {
            con.Open();
            string query = "SELECT u.Login, s.DateTime, s.Mode, s.Score FROM Sessions s, Users u WHERE u.Id=s.Id_User";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.Fill(ds, "StatisticsView");
            con.Close();
        }
    }
}
