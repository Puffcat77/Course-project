using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project
{
    public partial class ReportForm : Form
    {
        public string ReportName { get; set; }

        public ReportForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            if (ReportName == "RepairFrequency")
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "reportsDataSet.RepairFrequency". При необходимости она может быть перемещена или удалена.
                this.repairFrequencyTableAdapter.Fill(this.reportsDataSet.RepairFrequency);
                this.RepairFrequencyReportViewer.RefreshReport();

                this.RepairCostsReportViewer.Hide();
                this.PurchaseCostsReportViewer.Hide();
            }
            else if (ReportName == "RepairCosts")
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "reportsDataSet.RepairCosts". При необходимости она может быть перемещена или удалена.
                this.repairCostsTableAdapter.Fill(this.reportsDataSet.RepairCosts);
                this.RepairCostsReportViewer.RefreshReport();

                this.RepairFrequencyReportViewer.Hide();
                this.PurchaseCostsReportViewer.Hide();
            }
            else if (ReportName == "PurchaseCosts")
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "reportsDataSet.PurchaseCosts". При необходимости она может быть перемещена или удалена.
                this.purchaseCostsTableAdapter.Fill(this.reportsDataSet.PurchaseCosts);
                this.PurchaseCostsReportViewer.RefreshReport();

                this.RepairCostsReportViewer.Hide();
                this.RepairFrequencyReportViewer.Hide();
            }
        }
    }
}
