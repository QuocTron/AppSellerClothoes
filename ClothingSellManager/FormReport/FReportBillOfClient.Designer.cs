
namespace ClothingSellManager.FormReport
{
    partial class FReportBillOfClient
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
            this.rpvBillForClient = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvBillForClient
            // 
            this.rpvBillForClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvBillForClient.Location = new System.Drawing.Point(0, 0);
            this.rpvBillForClient.Name = "rpvBillForClient";
            this.rpvBillForClient.ServerReport.BearerToken = null;
            this.rpvBillForClient.Size = new System.Drawing.Size(1054, 604);
            this.rpvBillForClient.TabIndex = 1;
            // 
            // FReportBillOfClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 604);
            this.Controls.Add(this.rpvBillForClient);
            this.Name = "FReportBillOfClient";
            this.Text = "FReportBillOfClient";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBillForClient;
    }
}