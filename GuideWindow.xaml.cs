using Microsoft.Reporting.WinForms.Internal.Soap.ReportingServices2005.Execution;
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
    /// Логика взаимодействия для GuideWindow.xaml
    /// </summary>
    public partial class GuideWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlConnection connection;

        string CurrentTableName { get; set; }

        public string UserType { get; set; }
        private DataTable currentTable;
        private Brush baseButtonBrush;
        bool isTableEditing = false;

        public GuideWindow()
        {
            InitializeComponent();
            MainDataGrid.IsReadOnly = true;
            connectionString = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            connection = null;
            CurrentTableName = "";
            ApplyBtn.IsEnabled = false;
            baseButtonBrush = ApplyBtn.Background;
        }

        private void UpdateDB()
        {
            try
            {
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(currentTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void FillGrid(string tablePrefix)
        //{
        //    foreach (var column in MainDataGrid.Columns.All())
        //    {
        //        var c = column as DataGridTextColumn;
        //        if ()
        //    }
        //}

        private void FillGrid(string tableName)
        {
            string sql = "";
            switch (tableName)
            {
                case "Inventory":
                    sql = "select InventoryID as 'Идентификатор оборувания', InventoryNumber as 'Инвентарный номер', SerialNumber as 'Серийный номер', " +
                    "EntryDate as 'Дата ввода в эксплуатацию', WithdrawalDate as 'Дата вывода из эксплуатации', " +
                    "GuaranteeDate as 'Дата гарантийного обслуживания', Condition as 'Состояние', " +
                    "SpecialSoftware as 'Специальное ПО', InventoryName as 'Название оборудования', " +
                    "ResponsibleID as 'Идентификатор ответственного', InventoryCardID as 'Идентификатор инвентарной карты', " +
                    "Notes as 'Заметки' FROM Inventory I";
                    break;
                case "InventoryCard":
                    sql = "select InventoryCardID 'Идентификатор инвентарной карты', " +
                        "InventoryCardNumber as 'Номер инвентарной карты', CreationDate as 'Дата создания инвентарной карты' " +
                          "FROM InventoryCard";
                    break;
                case "Department":
                    sql = "select Department_ID as 'Идентификатор отдела', Name as 'Название отдела' FROM Department";
                    break;
                case "Responsible":
                    sql = "select ResponsibleID 'Идентификатор ответственного', FCs as 'Инициалы', CabinetNumber as 'Номер кабинета', " +
                        "Address as 'Адрес', Department_ID as 'Идентификатор отдела'  FROM Responsible";
                    break;
                case "RepairNote":
                    sql = "SELECT RepairNoteID AS [Идентификатор записи о ремонте], InventoryID AS [Идентификатор оборудования], " +
                        "RepairCompanyID AS [Идентификатор ремонтной компании], RepairCost AS [Стоимость ремонта],"+
                        "RepairDate AS[Дата ремонта], Notes AS Заметки FROM dbo.RepairNote";
                    break;
                case "MovementNote":
                    sql = "SELECT MovementNoteID AS [Идентификатор записи о перемещении], InventoryID AS [Идентификатор оборудования]," +
                        " PreviousResponsibleID AS [Предыдущий ответственный], CurrentResponsibleID AS [Текущий ответственный], " + 
                        "MovementDate AS[Дата перемещения], Notes AS Заметки FROM dbo.MovementNote";
                    break;
                case "WriteOffMemo":
                    sql = "SELECT WriteOffMemoID 'Идентификатор записи о списании на склад', WriteOffDate AS [Дата списания], " +
                        "InventoryID AS [Идентификатор оборудования] FROM WriteOffMemo";
                    break;
                case "PurchaseMemo":
                    sql = "SELECT PurchaseMemoID AS [Идентификатор записи о закупке], PurchasableInventoryID " +
                        "AS [Идентификатор закупаемого оборудования], PurchaseCompanyID AS [Идентифитор фирмы закупки]," +
                        " DateOfPurchase AS [Дата закупки], Cost AS Стоимость FROM dbo.PurchaseMemo";
                    break;
                case "PurchaseCompany":
                    sql = "select PurchaseCompanyID 'Идентифитор фирмы закупки', CompanyName from PurchaseCompany";
                    break;
                case "RepairCompany":
                    sql = "select RepairCompanyID 'Идентификатор ремонтной компании', RepairCompanyName from RepairCompany";
                    break;
            }
            try
            {
                currentTable = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                adapter.SelectCommand = command;
                adapter.Fill(currentTable);
                MainDataGrid.ItemsSource = currentTable.DefaultView;
                (MainDataGrid.Columns[0] as DataGridTextColumn).Visibility = Visibility.Visible;
                (MainDataGrid.Columns[0] as DataGridTextColumn).IsReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void GuideComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as ComboBoxItem);
            CurrentTableName = selectedItem.Tag.ToString();
            FillGrid(CurrentTableName);
            foreach (var column in MainDataGrid.Columns)
            {
                if (column.Header.ToString().Contains("Дата"))
                    (column as DataGridTextColumn).Binding.StringFormat = String.Format("dd.MM.yyyy");
                if (column.Header.ToString().Contains("Цена") || column.Header.ToString().Contains("Стоимость"))
                    (column as DataGridTextColumn).Binding.StringFormat = String.Format("##.00");
            }
            ApplyBtn.IsEnabled = true;
        }

        private void ToMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserType != "Technician")
            {
                MessageBox.Show("У вас недостаточно прав.");
                return;
            }
            if (isTableEditing)
            {
                IsEditingLabel.Visibility = Visibility.Hidden;
                MainDataGrid.IsReadOnly = true;
                MainDataGrid.CanUserAddRows = false;
                MainDataGrid.CanUserDeleteRows = false;
                GuideComboBox.IsEnabled = true;
                ToMainMenuBtn.IsEnabled = true;
                UpdateDB();
            }
            else
            {
                IsEditingLabel.Visibility = Visibility.Visible;
                MainDataGrid.IsReadOnly = false;
                MainDataGrid.CanUserAddRows = true;
                MainDataGrid.CanUserDeleteRows = true;
                GuideComboBox.IsEnabled = false;
                ToMainMenuBtn.IsEnabled = false;
            }
            isTableEditing = !isTableEditing;
        }

        private void Btn_MouseMove(object sender, MouseEventArgs e)
        {
            var b = (sender as Button);
            b.Background = (b.Background == baseButtonBrush) ? b.Background = Brushes.LawnGreen : b.Background = baseButtonBrush;
        }
    }
}