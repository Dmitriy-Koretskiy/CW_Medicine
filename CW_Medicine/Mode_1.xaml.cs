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
    /// Логика взаимодействия для Mode_1.xaml
    /// </summary>
    public partial class Mode_1 : Window
    {
        private string currentGroupId = "";
        private string currentSubgroupId = "";
        const int constNumberOfPrep = 6; //количество препаратов по умолчанию
        private List<string> idSubgroupList = new List<string>();     //массив с id подгрупп
        private List<string> nameSubgroupList = new List<string>();     //массив с именами подгрупп
        private List<string[]> compareList = new List<string[]>(constNumberOfPrep); //массив подгруппы
        private List<string> descriptionList = new List<string>(constNumberOfPrep);//массив с описание препаратов

        
        public Mode_1()
        {
            InitializeComponent();
            FillSubdroupList();
        }

        /// <summary>
        /// Заполнение List перечнем подгрупп
        /// </summary>
        public void FillSubdroupList()
        {
            Info.mode = "1";
            DataRow dr = WorkWithRow.RandomRow(); //случайная строка
            currentGroupId = dr.ItemArray[3].ToString();
            NameGroup.Content = WorkWithRow.ExtractData("Groups", currentGroupId, "Name");
            idSubgroupList.Clear();
            nameSubgroupList.Clear();
            string expression; //параметры поиска
            string id;
            expression = "Id_Group = " + currentGroupId;
            DataRow[] rows = WorkWithDB.ds.Tables["Medicine"].Select(expression);//извлечение строк соответствующих параметрам поиска
            for (int i = 0; (i < rows.Length) && (i < constNumberOfPrep); i++)
            {
                id = rows[i]["Id_Subgroup"].ToString();
                if (idSubgroupList.IndexOf(id) == -1)
                {
                    idSubgroupList.Add(id);
                    nameSubgroupList.Add(WorkWithRow.ExtractData("Subgroup", id, "Name"));//добавление в List
                }
            }
        }

        /// <summary>
        /// Очистка полей
        /// </summary>
        public void ClearFields() 
        {
            Preparation1.Text = "";
            Preparation2.Text = "";
            Preparation3.Text = "";
            Preparation4.Text = "";
            Preparation5.Text = "";
            Preparation6.Text = "";
            Description1.Text = "";
            Description2.Text = "";
            Description3.Text = "";
            Description4.Text = "";
            Description5.Text = "";
            Description6.Text = "";
            TB_CorrectAnswer.Text = "";
            Answer1.Content = "";
            Answer2.Content = "";
            Answer3.Content = "";
            Answer4.Content = "";
            Answer5.Content = "";
            Answer6.Content = "";
        }

        /// <summary>
        /// Возвращает индекс в List содержащий передаваемую строку 
        /// </summary>
        public int SearchIndex(string tbText)
        {
            int pos = -1;
            for (int i = 0; i < compareList.Count; i++)
            {
                if (compareList[i][1] != "")
                {
                    if (compareList[i][1] == tbText)
                    {
                        pos = i;
                        break;
                    }
                }
                if (compareList[i][0] == tbText)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            FillSubdroupList();
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            bool errorFlag = false;
            string correctAnsver = ""; //правильный ответ
            for (int i = 0; i < compareList.Count; i++)
            {
                if (compareList[i][0] != "")
                {
                    correctAnsver += "Name: " + compareList[i][0] + "\n";
                    correctAnsver += "SecondName: " + compareList[i][1] + "\n";
                    correctAnsver += "Description: " + descriptionList[i] + "\n";
                }
            }

            int pos = -1; //позиция препарата в подгруппе

            pos = SearchIndex(Preparation6.Text);
            if (pos >= 0) //проверка на соответствие с подгруппой
            {
                compareList.Remove(compareList[pos]); //удаление строки из List
                Answer6.Content = "OK";
                Description6.Text = descriptionList[pos];
                descriptionList.RemoveAt(pos);

            }
            else
            {
                Answer6.Content = "WRONG!";
                errorFlag = true;
            }
            pos = SearchIndex(Preparation5.Text);
            if (pos >= 0) //проверка на соответствие с подгруппой
            {
                compareList.Remove(compareList[pos]);
                Answer5.Content = "OK";
                Description5.Text = descriptionList[pos];
                descriptionList.RemoveAt(pos);

            }
            else
            {
                Answer5.Content = "WRONG!";
                errorFlag = true;
            }
            pos = SearchIndex(Preparation4.Text);
            if (pos >= 0) //проверка на соответствие с подгруппой
            {
                compareList.Remove(compareList[pos]);
                Answer4.Content = "OK";
                Description4.Text = descriptionList[pos];
                descriptionList.RemoveAt(pos);

            }
            else
            {
                Answer4.Content = "WRONG!";
                errorFlag = true;
            }
            pos = SearchIndex(Preparation3.Text);
            if (pos >= 0) //проверка на соответствие с подгруппой
            {
                compareList.Remove(compareList[pos]);
                Answer3.Content = "OK";
                Description3.Text = descriptionList[pos];
                descriptionList.RemoveAt(pos);

            }
            else
            {
                Answer3.Content = "WRONG!";
                errorFlag = true;
            }
            pos = SearchIndex(Preparation2.Text);
            if (pos >= 0) //проверка на соответствие с подгруппой
            {
                compareList.Remove(compareList[pos]);
                Answer2.Content = "OK";
                Description2.Text = descriptionList[pos];
                descriptionList.RemoveAt(pos);

            }
            else
            {
                Answer2.Content = "WRONG!";
                errorFlag = true;
            }
            pos = SearchIndex(Preparation1.Text);
            if (pos >= 0) //проверка на соответствие с подгруппой
            {
                compareList.Remove(compareList[pos]);
                Answer1.Content = "OK";
                Description1.Text = descriptionList[pos];
                descriptionList.RemoveAt(pos);

            }
            else
            {
                Answer1.Content = "WRONG!";
                errorFlag = true;
            }
            TB_CorrectAnswer.Text = "";
            if (errorFlag)
                TB_CorrectAnswer.Text = correctAnsver; //возвращает ответ на страницу
            else
                Info.posAns++;
            Info.amountAns++;
            L_Score.Content = Info.posAns.ToString() + "/" + Info.amountAns.ToString();
            compareList.Clear();
            nameSubgroupList.RemoveAt(idSubgroupList.IndexOf(currentSubgroupId));
            idSubgroupList.RemoveAt(idSubgroupList.IndexOf(currentSubgroupId));//удаляет подгруппу из массива группы
            if (idSubgroupList.Count <= 1)//пустая ли группа
            {
                FillSubdroupList();
            }
            Result.IsEnabled = false;

        }

        private void Subgroup_Click(object sender, RoutedEventArgs e)
        {
            string expression;
            compareList.Clear();
            descriptionList.Clear();
            int ind = nameSubgroupList.IndexOf(TB_Subgroup.Text);
            if (ind >= 0)
            {
                currentSubgroupId = idSubgroupList[ind];

                expression = "Id_Group = " + currentGroupId + " AND Id_Subgroup= " + currentSubgroupId;
                DataRow[] rows = WorkWithDB.ds.Tables["Medicine"].Select(expression);

                string acc = "";
                for (int i = 0; i < rows.Length; i++)
                {
                    string[] compare = new string[2]; //содержит строки для сравнения
                    acc = "";   //формирование строк правильного ответа
                    acc += "  Dosage: " + WorkWithRow.ExtractData("Dosage", rows[i]["Id_Dosage"].ToString(), "Dosage");
                    acc += "  Amount: " + WorkWithRow.ExtractData("Amount", rows[i]["Id_Amount"].ToString(), "Amount");
                    acc += "  DosageForm: " + WorkWithRow.ExtractData("DosageForm", rows[i]["Id_DosageForm"].ToString(), "DosageForm") + "\n";
                    acc += "  Applaying: " + WorkWithRow.ExtractData("Applaying", rows[i]["Id_Applaying"].ToString(), "Applaying");
                    descriptionList.Add(acc);
                    compare[0] = rows[i]["Name"].ToString().Trim();
                    compare[1] = rows[i]["SecondName"].ToString().Trim();
                    compareList.Add(compare);
                }
                Result.IsEnabled = true;

                number.Content = compareList.Count.ToString();
                string[] empty = new string[2];
                empty[0] = "";
                empty[1] = "";
                while (compareList.Count < constNumberOfPrep)
                { //заполнение пустыми строками
                    compareList.Add(empty);
                    descriptionList.Add("");
                }

                ClearFields();
            }
            else {
                MessageBox.Show("Incorrect subgroup");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
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


