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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CW_Medicine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        
             WorkWithDB.CreateDataSet();
        }

        private void B_start_Click(object sender, RoutedEventArgs e)
        {
            if (TB_name.Text != "")
            {
                Info.userName = TB_name.Text;
                Info.password = TB_password.Text;
                if (RB_User.IsChecked == true)
                {
                    Info.idUserName =  WorkWithDB.GetUserId(Info.userName);
                    if (WorkWithRow.IsCorrectPassword(Info.userName, Info.password))
                    {
                        if (RB_1.IsChecked == true)
                        {
                            var w = new Mode_1();
                            w.Show();
                            Close();
                        }
                        if (RB_2.IsChecked == true)
                        {
                            var w = new Mode_2();
                            w.Show();
                            Close();
                        }
                        if (RB_3.IsChecked == true)
                        {
                            var w = new Mode_3();
                            w.Show();
                            Close();
                        }
                    }
                    else {
                        MessageBox.Show("Incorrect password");
                    }           
                }
                else
                {
                      if (WorkWithRow.IsCorrectPassword(Info.userName, TB_password.Text))
                      {
                    var w = new AdminMode();
                    w.Show();
                    Close();
                      }
                }
            }
            else {
                MessageBox.Show("Input your name");
            }
        }

        private void B_statistics_Click(object sender, RoutedEventArgs e)
        {
            var w = new Statistics();
            w.Show();
            Close();
        }
    }
}
