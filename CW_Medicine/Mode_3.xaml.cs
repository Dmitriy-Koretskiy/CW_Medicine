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
    /// Логика взаимодействия для Mode_3.xaml
    /// </summary>
    public partial class Mode_3 : Window
    {
        private string amountStr = "";
        private string dosageStr = "";
        private string dosageFormStr = "";
        private string applayingStr = "";
        public Mode_3()
        {
            InitializeComponent();
            Prepearing();    
        }

        /// <summary>
        /// Логика взаимодействия для Mode_3.xaml
        /// </summary>
        private void Prepearing()
        {
            Info.mode = "3";
            DataRow dr = WorkWithRow.RandomRow();// получение случайной строки
            string acc = ""; //строкасодержащая вопрос вопроса
            acc += "Group: " + WorkWithRow.ExtractData("Groups", dr["Id_Group"].ToString(), "Name") + "\n";
            acc += "Subgroup: " + WorkWithRow.ExtractData("Subgroup", dr["Id_Subgroup"].ToString(), "Name") + "\n";
            acc += dr["Name"].ToString();
            dosageStr = WorkWithRow.ExtractData("Dosage", dr["Id_Dosage"].ToString(), "Dosage");
            amountStr = WorkWithRow.ExtractData("Amount", dr["Id_Amount"].ToString(), "Amount");
            dosageFormStr = WorkWithRow.ExtractData("DosageForm", dr["Id_DosageForm"].ToString(), "DosageForm");
            applayingStr = WorkWithRow.ExtractData("Applaying", dr["Id_Applaying"].ToString(), "Applaying");
            L_Info.Text = acc;
            TB_CorrectAnswer.Clear();
        }
        /// <summary>
        /// Очистка полей
        /// </summary>
        private void ClearFilds()
        {
            Answer1.Content = "";
            Answer2.Content = "";
            Answer3.Content = "";
            Answer4.Content = "";
            TB_dosage.Text = "";
            TB_amount.Text = "";
            TB_dosageform.Text = "";
            TB_applaying.Text = "";
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            string str = "";
            bool errorFlag = false;
            str += "Dosage: " + dosageStr;
            str += "Amount: " + amountStr;
            str += "DosageForm: " + dosageFormStr +"\n";
            str += "Applaying: " + applayingStr;
            if (dosageStr == TB_dosage.Text)
            {
                Answer1.Content = "OK";
            }
            else
            {
                Answer1.Content = "WRONG!";
                errorFlag = true;
            }
            if (amountStr == TB_amount.Text)
            {
                Answer2.Content = "OK";
            }
            else
            {
                Answer2.Content = "WRONG!";
                errorFlag = true;
            }
            if (dosageFormStr == TB_dosageform.Text)
            {
                Answer3.Content = "OK";
            }
            else
            {
                Answer3.Content = "WRONG!";
                errorFlag = true;
            }
            if (applayingStr == TB_applaying.Text)
            {
                Answer4.Content = "OK";
            }
            else
            {
                Answer4.Content = "WRONG!";
                errorFlag = true;
            }
            if (errorFlag)
                TB_CorrectAnswer.Text = str; //возвращает ответ на страницу
            else
                Info.posAns++;
            Info.amountAns++;
            L_Score.Content = Info.posAns.ToString() + "/" + Info.amountAns.ToString();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            ClearFilds();
            Prepearing();
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFilds();
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
