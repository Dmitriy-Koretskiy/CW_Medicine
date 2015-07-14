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
    /// Логика взаимодействия для AdminMode.xaml
    /// </summary>
    public partial class AdminMode : Window
    {
        private string currentTable = "";//название текущей таблицы

        public AdminMode()
        {
            InitializeComponent();
        }

        private void B_insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WorkWithDB.InsertRow(currentTable);
            }
            catch
            {
                MessageBox.Show("Insert error");
            }
        }

        private void B_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WorkWithDB.UpdateTable(currentTable);
            }
            catch
            {
                MessageBox.Show("Update error");
            }
        }

        private void B_delete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int ind = ShowResultDataGrid.SelectedIndex;
                WorkWithDB.DeleteRow(currentTable, ind);

            }
            catch
            {
                MessageBox.Show("Delete error");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTable = ((ComboBoxItem)CBox.SelectedItem).Content.ToString();//получение текущей таблицы
            ShowResultDataGrid.ItemsSource = WorkWithDB.ds.Tables[currentTable].DefaultView;
        }
    }
}
