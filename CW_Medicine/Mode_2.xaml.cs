using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace CW_Medicine
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Mode_2 : Window
    {
        private string nameMed = ""; //имя препарата с которым будет происходить сравнение
        public Mode_2()
        {
            InitializeComponent();
            Realization();
        }

        /// <summary>
        /// Подготовка правильных ответов
        /// </summary>
        private void Realization()
        {
            Info.mode = "2";
            DataRow dr = WorkWithRow.RandomRow();//получение случайной строки
            string acc = ""; //строка с параметрами препарата
            acc += "Group: " + WorkWithRow.ExtractData("Groups", dr["Id_Group"].ToString(), "Name") + "\n";
            acc += "Subgroup: " + WorkWithRow.ExtractData("Subgroup", dr["Id_Subgroup"].ToString(), "Name") + "\n";
            acc += "  Dosage: " + WorkWithRow.ExtractData("Dosage", dr["Id_Dosage"].ToString(), "Dosage");
            acc += "  Amount: " + WorkWithRow.ExtractData("Amount", dr["Id_Amount"].ToString(), "Amount");
            acc += "  DosageForm: " + WorkWithRow.ExtractData("DosageForm", dr["Id_DosageForm"].ToString(), "DosageForm") + "\n";
            acc += "  Applaying: " + WorkWithRow.ExtractData("Applaying", dr["Id_Applaying"].ToString(), "Applaying");
            L_Description.Text = acc;
            TB_CorrectAnswer.Clear();
            nameMed = dr["Name"].ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TB_CorrectAnswer.Clear();
            TB_Name.Clear();
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            bool errorFlag = false; //флаг ошибки
            if (nameMed == TB_Name.Text)
            {
                Answer1.Content = "OK";
            }
            else
            {
                errorFlag = true;
                Answer1.Content = "WRONG!";
            }
            if (errorFlag)
                TB_CorrectAnswer.Text = nameMed; //возвращает ответ на страницу
            else
                Info.posAns++;
            Info.amountAns++;
            L_Score.Content = Info.posAns.ToString() + "/" + Info.amountAns.ToString();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Realization();
        }

        private void B_Finish_Click(object sender, RoutedEventArgs e)
        {

            WorkWithDB.WriteCurrentSession();
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
    }
}
