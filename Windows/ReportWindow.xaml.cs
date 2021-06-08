using Microsoft.Reporting.WinForms;
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
using System.Windows.Shapes;

namespace Course_project
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private Brush baseColorBrush { get; set; }
        public ReportWindow()
        {
            InitializeComponent();
            baseColorBrush = ToMainMenuBtn.Background;
        }

        private void GenerateReportBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ReportForm reportForm = new ReportForm();
            reportForm.ReportName = (sender as Button).Tag.ToString();
            reportForm.ShowDialog();
            this.Show();
        }

        private void ToMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_MouseMove(object sender, MouseEventArgs e)
        {
            var b = sender as Button;
            b.Background = (b.Background == baseColorBrush) ? Brushes.LawnGreen : baseColorBrush;
        }
    }
}
