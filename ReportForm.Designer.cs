namespace Course_project
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportsDataSet = new Course_project.Reports.ReportsDataSet();
            this.PurchaseCostsReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RepairCostsReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RepairFrequencyReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.repairCostsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repairCostsTableAdapter = new Course_project.Reports.ReportsDataSetTableAdapters.RepairCostsTableAdapter();
            this.purchaseCostsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchaseCostsTableAdapter = new Course_project.Reports.ReportsDataSetTableAdapters.PurchaseCostsTableAdapter();
            this.RepairFrequencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repairFrequencyBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.repairFrequencyTableAdapter = new Course_project.Reports.ReportsDataSetTableAdapters.RepairFrequencyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairCostsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseCostsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepairFrequencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairFrequencyBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportsDataSet
            // 
            this.reportsDataSet.DataSetName = "ReportsDataSet";
            this.reportsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PurchaseCostsReportViewer
            // 
            this.PurchaseCostsReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PurchaseCostsReportViewer.DocumentMapWidth = 55;
            reportDataSource1.Name = "PurchaseDataSete";
            reportDataSource1.Value = this.purchaseCostsBindingSource;
            this.PurchaseCostsReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.PurchaseCostsReportViewer.LocalReport.ReportEmbeddedResource = "Course_project.Reports.PurchCosts.rdlc";
            this.PurchaseCostsReportViewer.Location = new System.Drawing.Point(0, 0);
            this.PurchaseCostsReportViewer.Name = "PurchaseCostsReportViewer";
            this.PurchaseCostsReportViewer.ServerReport.BearerToken = null;
            this.PurchaseCostsReportViewer.Size = new System.Drawing.Size(800, 450);
            this.PurchaseCostsReportViewer.TabIndex = 0;
            // 
            // RepairCostsReportViewer
            // 
            this.RepairCostsReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RepairCostsReportViewer.DocumentMapWidth = 34;
            reportDataSource2.Name = "RepCostsDataSet";
            reportDataSource2.Value = this.repairCostsBindingSource;
            this.RepairCostsReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.RepairCostsReportViewer.LocalReport.ReportEmbeddedResource = "Course_project.Reports.RepCosts.rdlc";
            this.RepairCostsReportViewer.Location = new System.Drawing.Point(0, 0);
            this.RepairCostsReportViewer.Name = "RepairCostsReportViewer";
            this.RepairCostsReportViewer.ServerReport.BearerToken = null;
            this.RepairCostsReportViewer.Size = new System.Drawing.Size(800, 450);
            this.RepairCostsReportViewer.TabIndex = 1;
            // 
            // RepairFrequencyReportViewer
            // 
            this.RepairFrequencyReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RepairFrequencyReportViewer.DocumentMapWidth = 37;
            reportDataSource3.Name = "RepFreqDataSet";
            reportDataSource3.Value = this.repairFrequencyBindingSource1;
            this.RepairFrequencyReportViewer.LocalReport.DataSources.Add(reportDataSource3);
            this.RepairFrequencyReportViewer.LocalReport.ReportEmbeddedResource = "Course_project.Reports.RepFrequency.rdlc";
            this.RepairFrequencyReportViewer.Location = new System.Drawing.Point(0, 0);
            this.RepairFrequencyReportViewer.Name = "RepairFrequencyReportViewer";
            this.RepairFrequencyReportViewer.ServerReport.BearerToken = null;
            this.RepairFrequencyReportViewer.Size = new System.Drawing.Size(800, 450);
            this.RepairFrequencyReportViewer.TabIndex = 2;
            // 
            // repairCostsBindingSource
            // 
            this.repairCostsBindingSource.DataMember = "RepairCosts";
            this.repairCostsBindingSource.DataSource = this.reportsDataSet;
            // 
            // repairCostsTableAdapter
            // 
            this.repairCostsTableAdapter.ClearBeforeFill = true;
            // 
            // purchaseCostsBindingSource
            // 
            this.purchaseCostsBindingSource.DataMember = "PurchaseCosts";
            this.purchaseCostsBindingSource.DataSource = this.reportsDataSet;
            // 
            // purchaseCostsTableAdapter
            // 
            this.purchaseCostsTableAdapter.ClearBeforeFill = true;
            // 
            // RepairFrequencyBindingSource
            // 
            this.RepairFrequencyBindingSource.DataMember = "RepairFrequency";
            this.RepairFrequencyBindingSource.DataSource = this.reportsDataSet;
            // 
            // repairFrequencyBindingSource1
            // 
            this.repairFrequencyBindingSource1.DataMember = "RepairFrequency";
            this.repairFrequencyBindingSource1.DataSource = this.reportsDataSet;
            // 
            // repairFrequencyTableAdapter
            // 
            this.repairFrequencyTableAdapter.ClearBeforeFill = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RepairFrequencyReportViewer);
            this.Controls.Add(this.RepairCostsReportViewer);
            this.Controls.Add(this.PurchaseCostsReportViewer);
            this.Name = "ReportForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairCostsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseCostsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepairFrequencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairFrequencyBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer PurchaseCostsReportViewer;
        private Reports.ReportsDataSet reportsDataSet;
        private Microsoft.Reporting.WinForms.ReportViewer RepairCostsReportViewer;
        private Microsoft.Reporting.WinForms.ReportViewer RepairFrequencyReportViewer;
        private System.Windows.Forms.BindingSource repairCostsBindingSource;
        private Reports.ReportsDataSetTableAdapters.RepairCostsTableAdapter repairCostsTableAdapter;
        private System.Windows.Forms.BindingSource purchaseCostsBindingSource;
        private Reports.ReportsDataSetTableAdapters.PurchaseCostsTableAdapter purchaseCostsTableAdapter;
        private System.Windows.Forms.BindingSource RepairFrequencyBindingSource;
        private System.Windows.Forms.BindingSource repairFrequencyBindingSource1;
        private Reports.ReportsDataSetTableAdapters.RepairFrequencyTableAdapter repairFrequencyTableAdapter;
    }
}