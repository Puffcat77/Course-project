using Course_project.Models;
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
    /// Логика взаимодействия для AnalysisWindow.xaml
    /// </summary>
    public partial class AnalysisWindow : Window
    {
        private Brush baseButtonBrush;
        private List<(string, string)> AnalysisOptions { get; set; }
        private InventoryDBContext InventoryContext;
        public AnalysisWindow()
        {
            InitializeComponent();
            baseButtonBrush = ToMainMenuBtn.Background;
            InventoryContext = new InventoryDBContext();
            AnalysisOptions = new List<(string, string)>()
            {
                ("InventoryByResponsible", "Оборудование по ответственным"),
                ("PurchasedInventoryByYears", "Закупленное оборудование по годам"),
                ("ExpiredGuaranteeByResp", "Оборудование с истекшей гарантией по ответственным"),
                ("InventoryByResponsiblesByAddress", "Ответственные с оборудованием по адресам ответственных"),
                ("InventoryWithoutRepairs", "Оборудование, для которого не проводился ремонт"),
                ("SummaryForRepairs", "Суммарные затраты на ремонт оборудования"),
                ("ResponsibleWithRepairs", "Ответственные, у которых произошла минимум одна отправка на ремонт."),
                ("CheckGuarantee", "Проверка статуса гарантийного обслуживания"),
                ("FindExpired", "Оборудование без гарантийного обслуживания"),
                ("ShowWrittenOffInventory", "Списанное оборудование"),
            };
            FillAnalysisComboBox();
        }

        private void FillAnalysisComboBox()
        {
            foreach (var option in AnalysisOptions)
            {
                var item = new ComboBoxItem() { Name = option.Item1, Tag = option.Item1, Content = option.Item2 };
                item.Selected += AnalysisOption_selected;
                AnalysisComboBox.Items.Add(item);
            }
        }

        private void AnalysisOption_selected(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as ComboBoxItem).Tag.ToString())
                {
                    case "InventoryByResponsible":
                        AnalysisDataGrid.ItemsSource = InventoryContext.group_inventory_by_resp.ToList();
                        break;
                    case "PurchasedInventoryByYears":
                        AnalysisDataGrid.ItemsSource = InventoryContext.purchased_inventory_by_years.ToList();
                        break;
                    case "ExpiredGuaranteeByResp":
                        AnalysisDataGrid.ItemsSource = InventoryContext.inventory_without_guarantee_by_resp.ToList();
                        break;
                    case "InventoryByResponsiblesByAddress":
                        AnalysisDataGrid.ItemsSource = InventoryContext.inventory_by_resp_by_address.ToList();
                        break;
                    case "InventoryWithoutRepairs":
                        AnalysisDataGrid.ItemsSource = InventoryContext.inventory_without_repairs.ToList();
                        break;
                    case "ResponsibleWithRepairs":
                        AnalysisDataGrid.ItemsSource = InventoryContext.responsibles_who_needed_repair.ToList();
                        break;
                    case "SummaryForRepairs":
                        AnalysisDataGrid.ItemsSource = InventoryContext.summary_for_inventory_repairs.ToList();
                        break;
                    case "CheckGuarantee":
                        AnalysisDataGrid.ItemsSource = InventoryContext.CheckGuarantee();
                        break;
                    case "FindExpired":
                        AnalysisDataGrid.ItemsSource = InventoryContext.FindExpired();
                        break;
                    case "ShowWrittenOffInventory":
                        AnalysisDataGrid.ItemsSource = InventoryContext.ShowWrittenOffInventory();
                        break;
                }
                foreach (var column in AnalysisDataGrid.Columns)
                {
                    (column as DataGridTextColumn).Header = (column as DataGridTextColumn).Header.ToString().Replace("_", " ");
                    if (column.Header.ToString().Contains("Дата"))
                        (column as DataGridTextColumn).Binding.StringFormat = String.Format("dd.MM.yyyy");
                    if (column.Header.ToString().Contains("Цена") || column.Header.ToString().Contains("Стоимость"))
                        (column as DataGridTextColumn).Binding.StringFormat = String.Format("##.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_MouseMove(object sender, MouseEventArgs e)
        {
            var b = sender as Button;
            b.Background = (b.Background == baseButtonBrush) ? Brushes.LawnGreen : baseButtonBrush;
        }
    }
}
