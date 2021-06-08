using Course_project.Models;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Course_project
{
    /// <summary>
    /// Логика взаимодействия для AuthentificationWindow.xaml
    /// </summary>
    public partial class AuthentificationWindow : Window
    {
        public string UserType { get; set; }
        private Brush baseColorBrush;
        private InventoryDBContext InventoryDBContext { get; set; }

        public AuthentificationWindow()
        {
            InitializeComponent();
            authBtn.Background = Brushes.LightGreen;
            UserType = "";
            baseColorBrush = authBtn.Background;
            InventoryDBContext = new InventoryDBContext();
        }

        private void authBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = loginTextBox.Text;
                string password = passBox.Password;

                Users user = InventoryDBContext.Users.FirstOrDefault((Users u) => u.Login == login && u.Password == password) as Users;

                if (user != null)
                {
                    if (login == "watcher")
                    {
                        MessageBox.Show("Вы вошли как обычный сотрудник.");
                    }
                    else if (login == "technician")
                    {
                        MessageBox.Show("Вы вошли как сотрудник техотдела.");
                    }
                    UserType = user.Type;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные.");
                    loginTextBox.Text = "";
                    passBox.Password = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Btn_MouseMove(object sender, MouseEventArgs e)
        {
            var b = sender as Button;
            b.Background = (b.Background == baseColorBrush) ? Brushes.LawnGreen : baseColorBrush;
        }
    }
}
