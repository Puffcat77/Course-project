using Course_project.Windows;
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
        public GuideWindow()
        {
            InitializeComponent();
            MainDataGrid.IsReadOnly = true;
            connectionString = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            connection = null;
            CurrentTableName = "";
            OptionsComboBox.IsEnabled = false;
            ApplyBtn.IsEnabled = false;
        }

        private void FillGrid(string tableName)
        {
            string sql = "";
            switch (tableName)
            {
                case "Inventory":
                    sql = "select InventoryNumber as 'Инвентарный номер', SerialNumber as 'Серийный номер', " +
                    "EntryDate as 'Дата ввода в эксплуатацию', WithdrawalDate as 'Дата вывода из эксплуатации', " +
                    "GuaranteeDate as 'Дата гарантийного обслуживания', Condition as 'Состояние', " +
                    "SpecialSoftware as 'Специальное ПО', InventoryName as 'Название оборудования', " +
                    "FCs as 'Ответственный', InventoryCardNumber as 'Номер инвентарной карты', " +
                    "Notes as 'Заметки' FROM Inventory I INNER JOIN " +
                    "Responsible R ON I.ResponsibleID = R.ResponsibleID INNER JOIN " +
                    "InventoryCard IC ON I.InventoryCardID = IC.InventoryCardID";
                    break;
                case "InventoryCard":
                    sql = "select InventoryCardNumber as 'Номер инвентарной карты', CreationDate as 'Дата создания инвентарной карты' " +
                          "FROM InventoryCard";
                    break;
                case "Department":
                    sql = "select Name as 'Название отдела' FROM Department";
                    break;
                case "Responsible":
                    sql = "select FCs as 'Инициалы', CabinetNumber as 'Номер кабинета', " +
                        "Address as 'Адрес', D.Name as 'Название отдела'  FROM Responsible R " +
                        "inner join Department D on D.Department_ID = R.Department_ID";
                    break;
                case "RepairNote":
                    sql = "select InventoryName as 'Название оборудования', RepairCompanyName as 'Название ремонтной компании', " +
                        "RepairCost as 'Стоимость ремонта в рублях', RepairDate as 'Дата ремонта', RN.Notes as 'Заметки по ремонту' FROM RepairNote RN " +
                        "inner join Inventory I on RN.InventoryID = I.InventoryID inner join RepairCompany RC on RC.RepairCompanyID = RN.RepairCompanyID";
                    break;
                case "MovementNote":
                    sql = "select R.FCs as 'Текущий ответственный', RNM.[Предыдущий ответственный] as 'Предыдущий ответственный', " +
                         "RNM.[Дата перемещения] 'Дата перемещения', RNM.[Название оборудования] 'Название оборудования' " +
                         "from(select FCs as 'Предыдущий ответственный', MovementDate 'Дата перемещения', InventoryName " +
                         "'Название оборудования', CurrentResponsibleID from MovementNote MN inner join Responsible R on " +
                         "R.ResponsibleID = MN.PreviousResponsibleID inner join Inventory I on MN.InventoryID = I.InventoryID) " +
                         "as RNM inner join Responsible R on RNM.CurrentResponsibleID = R.ResponsibleID";
                    break;
                case "WriteOffMemo":
                    sql = "SELECT WriteOffDate AS [Дата списания], InventoryName AS [Название оборудования] " +
                         "FROM WriteOffMemo W INNER JOIN " +
                         "Inventory I ON W.InventoryID = I.InventoryID";
                    break;
                case "PurchaseMemo":
                    sql = "SELECT I.InventoryName AS [Название оборудования], PC.CompanyName AS [Название компании], " +
                        "PM.DateOfPurchase AS [Дата покупки], PM.Cost AS [Цена в рублях] FROM PurchaseMemo AS PM INNER JOIN " +
                        "PurchaseCompany AS PC ON PM.PurchaseCompanyID = PC.PurchaseCompanyID INNER JOIN " +
                        "Inventory AS I ON PM.PurchasableInventoryID = I.InventoryID";
                    break;
                case "PurchaseCompany":
                    sql = "select CompanyName from PurchaseCompany";
                    break;
                case "RepairCompany":
                    sql = "select RepairCompanyName from RepairCompany";
                    break;
            }
            try
            {
                DataTable table = new DataTable();
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                MainDataGrid.ItemsSource = table.DefaultView;
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

        private void OptionsComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as ComboBoxItem);
            string sql = "";
            switch (selectedItem.Tag.ToString())
            {
                case "Add":

                    break;
                case "Edit":
                    break;
                case "Delete":
                    break;
                case "Guarantee":
                    break;
            }
            FillGrid(CurrentTableName);
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
                if (column.Header.ToString().Contains("Цена"))
                    (column as DataGridTextColumn).Binding.StringFormat = String.Format("##.00");
            }
            OptionsComboBox.IsEnabled = true;
            ApplyBtn.IsEnabled = true;
        }

        private void ToMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}