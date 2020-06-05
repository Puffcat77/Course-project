using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Course_project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string UserType { get; set; }
        private Brush baseButtonBrush { get; set; }


        public MainWindow()
        {
            UserType = "";
            InitializeComponent();
            baseButtonBrush = GuideBtn.Background;
            foreach (var child in MainWindowGrid.Children)
            {
                if (child is Button) 
                {
                    var b = (child as Button);
                    b.MouseEnter += Button_MouseMoved;
                    b.MouseLeave += Button_MouseMoved;
                }
            }
            //AuthorizeUser();
        }

        private void Button_MouseMoved(object sender, RoutedEventArgs e)
        {
            var b = (sender as Button);
            if (b.Background == baseButtonBrush)
                b.Background = Brushes.LawnGreen;
            else b.Background = baseButtonBrush;
        }

        private void AuthorizeUser() 
        {
            while (UserType == "")
            {
                var authWindow = new AuthentificationWindow();
                authWindow.ShowDialog();
                UserType = authWindow.UserType;
                if (UserType == "")
                {
                    MessageBox.Show("Вы должны войти в систему.");
                }
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void authBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizeUser();
        }

        private void GuideBtn_Click(object sender, RoutedEventArgs e)
        {
            GuideWindow gdWindow = new GuideWindow();
            gdWindow.UserType = UserType;
            gdWindow.ShowDialog();
        }
    }
}
