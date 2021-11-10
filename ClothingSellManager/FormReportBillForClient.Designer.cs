
namespace ClothingSellManager
{
    partial class FormReportBillForClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportBillForClient));
            this.rpvBillForClient = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BillForClientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BillForClientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvBillForClient
            // 
            this.rpvBillForClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvBillForClient.LocalReport.ReportEmbeddedResource = "ClothingSellManager.Report1.rdlc";
            this.rpvBillForClient.Location = new System.Drawing.Point(0, 0);
            this.rpvBillForClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rpvBillForClient.Name = "rpvBillForClient";
            this.rpvBillForClient.ServerReport.BearerToken = null;
            this.rpvBillForClient.Size = new System.Drawing.Size(1252, 814);
            this.rpvBillForClient.TabIndex = 0;
            // 
            // FormReportBillForClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 814);
            this.Controls.Add(this.rpvBillForClient);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormReportBillForClient";
            this.Text = "Xem trước hóa đơn";
            this.Load += new System.EventHandler(this.FormReportBillForClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BillForClientBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBillForClient;
        private System.Windows.Forms.BindingSource BillForClientBindingSource;
    }
}