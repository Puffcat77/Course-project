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

        public AuthentificationWindow()
        {
            InitializeComponent();
            authBtn.Background = Brushes.LightGreen;
            UserType = "";
        }

        private void authBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passBox.Password;
            DB db = new DB();

            DataTable userTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("select Login, Password, " +
                "Type from Users where Login = @ul and Password = @up", db.GetConnection());
            command.Parameters.Add("@ul", SqlDbType.VarChar).Value = login;
            command.Parameters.Add("@up", SqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(userTable);

            if (userTable.Rows.Count == 1)
            {
                if (login == "watcher")
                {
                    MessageBox.Show("Вы вошли как обычный сотрудник.");
                }
                else if (login == "technician")
                {
                    MessageBox.Show("Вы вошли как сотрудник техотдела.");
                }
                UserType = userTable.Rows[0]["Type"].ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные.");
                loginTextBox.Text = "";
                passBox.Password = "";
            }
        }
    }
}
