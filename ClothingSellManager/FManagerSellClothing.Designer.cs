
namespace ClothingSellManager
{
    partial class FManagerSellClothing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FManagerSellClothing));
            this.btnDelProduct = new System.Windows.Forms.Button();
            this.btnAddProductSell = new System.Windows.Forms.Button();
            this.cbbProduct = new System.Windows.Forms.ComboBox();
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flpClothing = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAll = new System.Windows.Forms.Button();
            this.cbbSizeClothing = new System.Windows.Forms.ComboBox();
            this.cbbSoLuongCon = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSPClick = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFinalSum = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelProduct
            // 
            this.btnDelProduct.BackColor = System.Drawing.Color.Red;
            this.btnDelProduct.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDelProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnDelProduct.Image")));
            this.btnDelProduct.Location = new System.Drawing.Point(183, 137);
            this.btnDelProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelProduct.Name = "btnDelProduct";
            this.btnDelProduct.Size = new System.Drawing.Size(39, 36);
            this.btnDelProduct.TabIndex = 9;
            this.btnDelProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelProduct.UseVisualStyleBackColor = false;
            this.btnDelProduct.Click += new System.EventHandler(this.btnDelProduct_Click);
            // 
            // btnAddProductSell
            // 
            this.btnAddProductSell.BackColor = System.Drawing.Color.Lime;
            this.btnAddProductSell.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddProductSell.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProductSell.Image")));
            this.btnAddProductSell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProductSell.Location = new System.Drawing.Point(10, 176);
            this.btnAddProductSell.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddProductSell.Name = "btnAddProductSell";
            this.btnAddProductSell.Size = new System.Drawing.Size(212, 64);
            this.btnAddProductSell.TabIndex = 8;
            this.btnAddProductSell.Text = "Thêm SP";
            this.btnAddProductSell.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProductSell.UseVisualStyleBackColor = false;
            this.btnAddProductSell.Click += new System.EventHandler(this.btnAddProductSell_Click);
            // 
            // cbbProduct
            // 
            this.cbbProduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProduct.FormattingEnabled = true;
            this.cbbProduct.Location = new System.Drawing.Point(272, 42);
            this.cbbProduct.Margin = new System.Windows.Forms.Padding(2);
            this.cbbProduct.Name = "cbbProduct";
            this.cbbProduct.Size = new System.Drawing.Size(178, 35);
            this.cbbProduct.TabIndex = 2;
            this.cbbProduct.TextChanged += new System.EventHandler(this.cbbProduct_TextChanged);
            // 
            // cbbCategory
            // 
            this.cbbCategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.Location = new System.Drawing.Point(109, 42);
            this.cbbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(150, 35);
            this.cbbCategory.TabIndex = 0;
            this.cbbCategory.SelectedValueChanged += new System.EventHandler(this.cbbCategory_SelectedValueChanged);
            this.cbbCategory.TextChanged += new System.EventHandler(this.cbbCategory_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.txtDiaChi);
            this.groupBox2.Controls.Add(this.txtFullName);
            this.groupBox2.Controls.Add(this.txtSDT);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(465, 298);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(228, 273);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(67, 184);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(87, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(67, 100);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(67, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(5, 222);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(217, 35);
            this.txtDiaChi.TabIndex = 5;
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(5, 148);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(217, 35);
            this.txtFullName.TabIndex = 3;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(5, 67);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(217, 35);
            this.txtSDT.TabIndex = 1;
            // 
            // nudDiscount
            // 
            this.nudDiscount.Location = new System.Drawing.Point(112, 18);
            this.nudDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(100, 35);
            this.nudDiscount.TabIndex = 9;
            this.nudDiscount.ValueChanged += new System.EventHandler(this.nudDiscount_ValueChanged_1);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.841726F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThanhToan.Image = ((System.Drawing.Image)(resources.GetObject("btnThanhToan.Image")));
            this.btnThanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThanhToan.Location = new System.Drawing.Point(399, 5);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(131, 93);
            this.btnThanhToan.TabIndex = 9;
            this.btnThanhToan.Text = "Thanh toán ";
            this.btnThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // txtSum
            // 
            this.txtSum.Location = new System.Drawing.Point(216, 14);
            this.txtSum.Margin = new System.Windows.Forms.Padding(2);
            this.txtSum.Name = "txtSum";
            this.txtSum.ReadOnly = true;
            this.txtSum.Size = new System.Drawing.Size(179, 35);
            this.txtSum.TabIndex = 5;
            this.txtSum.TextChanged += new System.EventHandler(this.txtSum_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 27);
            this.label7.TabIndex = 4;
            this.label7.Text = "Giảm Gía";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox3.Controls.Add(this.lvBill);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(697, 40);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(544, 405);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hóa Đơn";
            // 
            // lvBill
            // 
            this.lvBill.BackgroundImageTiled = true;
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvBill.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBill.GridLines = true;
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(3, 24);
            this.lvBill.Margin = new System.Windows.Forms.Padding(2);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(531, 377);
            this.lvBill.TabIndex = 0;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            this.lvBill.SelectedIndexChanged += new System.EventHandler(this.lvBill_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Sản Phẩm";
            this.columnHeader1.Width = 188;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Thành tiền";
            this.columnHeader5.Width = 206;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(23, 23);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1248, 34);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(97, 30);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảngToolStripMenuItem
            // 
            this.thôngTinTàiKhoảngToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thôngTinTàiKhoảngToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.thôngTinTàiKhoảngToolStripMenuItem.Name = "thôngTinTàiKhoảngToolStripMenuItem";
            this.thôngTinTàiKhoảngToolStripMenuItem.Size = new System.Drawing.Size(229, 30);
            this.thôngTinTàiKhoảngToolStripMenuItem.Text = "Thông tin tài khoản";
            this.thôngTinTàiKhoảngToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảngToolStripMenuItem_Click);
            // 
            // nudCount
            // 
            this.nudCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCount.Location = new System.Drawing.Point(10, 137);
            this.nudCount.Margin = new System.Windows.Forms.Padding(2);
            this.nudCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(76, 35);
            this.nudCount.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkOrange;
            this.groupBox1.Controls.Add(this.flpClothing);
            this.groupBox1.Controls.Add(this.btnAll);
            this.groupBox1.Controls.Add(this.cbbCategory);
            this.groupBox1.Controls.Add(this.cbbProduct);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.91367F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(460, 533);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Mục";
            // 
            // flpClothing
            // 
            this.flpClothing.AutoScroll = true;
            this.flpClothing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.flpClothing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpClothing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpClothing.ForeColor = System.Drawing.Color.Black;
            this.flpClothing.Location = new System.Drawing.Point(5, 85);
            this.flpClothing.Margin = new System.Windows.Forms.Padding(2);
            this.flpClothing.Name = "flpClothing";
            this.flpClothing.Size = new System.Drawing.Size(445, 444);
            this.flpClothing.TabIndex = 0;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.Aqua;
            this.btnAll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAll.Image = ((System.Drawing.Image)(resources.GetObject("btnAll.Image")));
            this.btnAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAll.Location = new System.Drawing.Point(11, 31);
            this.btnAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(94, 51);
            this.btnAll.TabIndex = 17;
            this.btnAll.Text = "All";
            this.btnAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // cbbSizeClothing
            // 
            this.cbbSizeClothing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSizeClothing.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSizeClothing.FormattingEnabled = true;
            this.cbbSizeClothing.Location = new System.Drawing.Point(96, 61);
            this.cbbSizeClothing.Margin = new System.Windows.Forms.Padding(2);
            this.cbbSizeClothing.Name = "cbbSizeClothing";
            this.cbbSizeClothing.Size = new System.Drawing.Size(132, 34);
            this.cbbSizeClothing.TabIndex = 11;
            // 
            // cbbSoLuongCon
            // 
            this.cbbSoLuongCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbbSoLuongCon.Enabled = false;
            this.cbbSoLuongCon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSoLuongCon.FormattingEnabled = true;
            this.cbbSoLuongCon.Location = new System.Drawing.Point(122, 99);
            this.cbbSoLuongCon.Margin = new System.Windows.Forms.Padding(2);
            this.cbbSoLuongCon.Name = "cbbSoLuongCon";
            this.cbbSoLuongCon.Size = new System.Drawing.Size(100, 34);
            this.cbbSoLuongCon.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 27);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kích cỡ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 27);
            this.label2.TabIndex = 14;
            this.label2.Text = "SL còn";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox4.Controls.Add(this.txtSPClick);
            this.groupBox4.Controls.Add(this.cbbSizeClothing);
            this.groupBox4.Controls.Add(this.nudCount);
            this.groupBox4.Controls.Add(this.btnDelProduct);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cbbSoLuongCon);
            this.groupBox4.Controls.Add(this.btnAddProductSell);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(464, 40);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(228, 244);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Option";
            // 
            // txtSPClick
            // 
            this.txtSPClick.Location = new System.Drawing.Point(4, 24);
            this.txtSPClick.Margin = new System.Windows.Forms.Padding(2);
            this.txtSPClick.Name = "txtSPClick";
            this.txtSPClick.ReadOnly = true;
            this.txtSPClick.Size = new System.Drawing.Size(222, 35);
            this.txtSPClick.TabIndex = 15;
            this.txtSPClick.Text = "Chọn sản phẩm";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtFinalSum);
            this.groupBox5.Controls.Add(this.txtSum);
            this.groupBox5.Controls.Add(this.btnThanhToan);
            this.groupBox5.Controls.Add(this.nudDiscount);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(700, 445);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(534, 110);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thanh toán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 27);
            this.label3.TabIndex = 11;
            this.label3.Text = "Số tiền phải trả";
            // 
            // txtFinalSum
            // 
            this.txtFinalSum.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinalSum.Location = new System.Drawing.Point(216, 66);
            this.txtFinalSum.Margin = new System.Windows.Forms.Padding(2);
            this.txtFinalSum.Name = "txtFinalSum";
            this.txtFinalSum.ReadOnly = true;
            this.txtFinalSum.Size = new System.Drawing.Size(179, 40);
            this.txtFinalSum.TabIndex = 10;
            // 
            // FManagerSellClothing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1248, 600);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Yi Baiti", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FManagerSellClothing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTD STORE FASHION (Seller)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FManagerSellClothing_FormClosing);
            this.Load += new System.EventHandler(this.FManagerSellClothing_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbbCategory;
        private System.Windows.Forms.ComboBox cbbProduct;
        private System.Windows.Forms.Button btnAddProductSell;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảngToolStripMenuItem;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnDelProduct;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flpClothing;
        private System.Windows.Forms.ComboBox cbbSizeClothing;
        private System.Windows.Forms.ComboBox cbbSoLuongCon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtFinalSum;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSPClick;
    }
}