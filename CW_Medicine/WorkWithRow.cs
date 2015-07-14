using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CW_Medicine
{
    static class WorkWithRow
    {

        public static DataRow RandomRow()
        {
            //  WorkWithDB wwdb = new WorkWithDB();

            DataTable table = WorkWithDB.ds.Tables["Medicine"];

            var rgen = new Random();

            int rindex = rgen.Next(table.Rows.Count);
            DataRow dr = table.Rows[rindex];
            return dr;
        }

        public static string ExtractData(string tableName, string id_data, string columnName)
        {
            DataTable table = WorkWithDB.ds.Tables[tableName];
            string expression;
            string res;
            expression = "Id = " + id_data;
            DataRow[] row = table.Select(expression);
            res = row[0][columnName].ToString();
            return res;
        }

        public static bool IsCorrectPassword(string name, string password)
        {
            bool isCorrect = false;
            string expression = "Login = '" + name + "'";
            DataRow[] rows = WorkWithDB.ds.Tables["Users"].Select(expression);
            if ((rows[0][2].ToString() == password))
                isCorrect = true;
            return isCorrect;
        }


    }

    static class Info
    {
        public static string userName = "";
        public static string idUserName = "";
        public static string password = "";
        public static int posAns = 0;
        public static int amountAns = 0;
        public static string mode = "";
    }

}
