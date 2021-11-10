
namespace ClothingSellManager.FormReport
{
    partial class FReportThongKeDoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReportThongKeDoanhThu));
            this.btnXuatTheoNgay = new System.Windows.Forms.Button();
            this.rpvThongKe = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnClientBuyBest = new System.Windows.Forms.Button();
            this.btnBestProduct = new System.Windows.Forms.Button();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnXuatTheoNgay
            // 
            this.btnXuatTheoNgay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnXuatTheoNgay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnXuatTheoNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatTheoNgay.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatTheoNgay.Image")));
            this.btnXuatTheoNgay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatTheoNgay.Location = new System.Drawing.Point(540, 7);
            this.btnXuatTheoNgay.Name = "btnXuatTheoNgay";
            this.btnXuatTheoNgay.Size = new System.Drawing.Size(223, 69);
            this.btnXuatTheoNgay.TabIndex = 4;
            this.btnXuatTheoNgay.Text = "Xuất theo ngày";
            this.btnXuatTheoNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatTheoNgay.UseVisualStyleBackColor = false;
            this.btnXuatTheoNgay.Click += new System.EventHandler(this.btnXuatTheoNgay_Click);
            // 
            // rpvThongKe
            // 
            this.rpvThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.rpvThongKe.BackColor = System.Drawing.Color.Aqua;
            this.rpvThongKe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpvThongKe.Location = new System.Drawing.Point(12, 82);
            this.rpvThongKe.Name = "rpvThongKe";
            this.rpvThongKe.ServerReport.BearerToken = null;
            this.rpvThongKe.Size = new System.Drawing.Size(1499, 567);
            this.rpvThongKe.TabIndex = 5;
            // 
            // dtpkFromDate
            // 
            this.dtpkFromDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkFromDate.Location = new System.Drawing.Point(24, 12);
            this.dtpkFromDate.Name = "dtpkFromDate";
            this.dtpkFromDate.Size = new System.Drawing.Size(171, 35);
            this.dtpkFromDate.TabIndex = 6;
            this.dtpkFromDate.Value = new System.DateTime(2021, 10, 14, 0, 0, 0, 0);
            // 
            // btnClientBuyBest
            // 
            this.btnClientBuyBest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClientBuyBest.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientBuyBest.Image = ((System.Drawing.Image)(resources.GetObject("btnClientBuyBest.Image")));
            this.btnClientBuyBest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientBuyBest.Location = new System.Drawing.Point(848, 7);
            this.btnClientBuyBest.Name = "btnClientBuyBest";
            this.btnClientBuyBest.Size = new System.Drawing.Size(304, 69);
            this.btnClientBuyBest.TabIndex = 7;
            this.btnClientBuyBest.Text = "Khách mua nhiều nhất";
            this.btnClientBuyBest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientBuyBest.UseVisualStyleBackColor = false;
            this.btnClientBuyBest.Click += new System.EventHandler(this.btnClientBuyBest_Click);
            // 
            // btnBestProduct
            // 
            this.btnBestProduct.BackColor = System.Drawing.Color.Red;
            this.btnBestProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBestProduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBestProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnBestProduct.Image")));
            this.btnBestProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBestProduct.Location = new System.Drawing.Point(1185, 7);
            this.btnBestProduct.Name = "btnBestProduct";
            this.btnBestProduct.Size = new System.Drawing.Size(326, 69);
            this.btnBestProduct.TabIndex = 8;
            this.btnBestProduct.Text = "Sản phẩm bán nhiều nhất";
            this.btnBestProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBestProduct.UseVisualStyleBackColor = false;
            this.btnBestProduct.Click += new System.EventHandler(this.btnBestProduct_Click);
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkToDate.Location = new System.Drawing.Point(249, 12);
            this.dtpkToDate.Name = "dtpkToDate";
            this.dtpkToDate.Size = new System.Drawing.Size(168, 35);
            this.dtpkToDate.TabIndex = 9;
            this.dtpkToDate.Value = new System.DateTime(2021, 10, 14, 0, 0, 0, 0);
            // 
            // FReportThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1534, 661);
            this.Controls.Add(this.dtpkToDate);
            this.Controls.Add(this.btnBestProduct);
            this.Controls.Add(this.btnClientBuyBest);
            this.Controls.Add(this.dtpkFromDate);
            this.Controls.Add(this.rpvThongKe);
            this.Controls.Add(this.btnXuatTheoNgay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FReportThongKeDoanhThu";
            this.Text = "Thống kê ";
            this.Load += new System.EventHandler(this.FReportThongKeDoanhThu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXuatTheoNgay;
        private Microsoft.Reporting.WinForms.ReportViewer rpvThongKe;
        private System.Windows.Forms.DateTimePicker dtpkFromDate;
        private System.Windows.Forms.Button btnClientBuyBest;
        private System.Windows.Forms.Button btnBestProduct;
        private System.Windows.Forms.DateTimePicker dtpkToDate;
    }
}