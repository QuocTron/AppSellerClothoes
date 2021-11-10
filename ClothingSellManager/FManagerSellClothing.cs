using ClothingSellManager.DAO;
using ClothingSellManager.DTO;
using ClothingSellManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ClothingSellManager
{
    public partial class FManagerSellClothing : Form
    {

        ClothingContext context = new ClothingContext();
        CultureInfo culture = new CultureInfo("vi-VN");
        private AccountDTO loginAccountDTO;
        string idBillOld = "";
        string idBillNew = "";
        int idClientNew = 0;
        double tienPhaiTra = 0;
        string maQuanAoClick = "";


        #region method
        public AccountDTO LoginAccountDTO 
        { 
            get => loginAccountDTO;
            set
            {
                loginAccountDTO = value;
                StatusAccount(loginAccountDTO.MaBoPhan);
            }
        }
        private void StatusAccount(string maBoPhan)
        {
            thôngTinTàiKhoảngToolStripMenuItem.Text = "";
            thôngTinTàiKhoảngToolStripMenuItem.Text += "Thông tin tài khoảng (" + LoginAccountDTO.FullName + ")";
            if (maBoPhan == "bp2910")
            {
                adminToolStripMenuItem.Enabled = false;
            }
            else
            {
                adminToolStripMenuItem.Enabled = true;
            }
        }
        public FManagerSellClothing(AccountDTO account)
        {
            InitializeComponent();
            this.LoginAccountDTO = account;
           
        }
        void LoadCategory()
        {
            cbbCategory.Text = "Chọn danh mục ";
            cbbCategory.DataSource = CategoryDAO.Instance.TableCategory();
            cbbCategory.ValueMember = "MALOAI";
            cbbCategory.DisplayMember = "TenLOAI";

        }
        private void LoadLayoutClothing(List<CLOTHING> listLoad)
        {
            flpClothing.Controls.Clear();
            foreach (var item in listLoad)
            {
                GroupBox groupBox = new GroupBox() { Width = 200, Height = 220 };
                PictureBox pictureBox = new PictureBox() { Width = 170, Height = 180 };
                groupBox.Text = item.TENQUANAO;
                groupBox.Font = new Font("Time new roman", 12, FontStyle.Bold);
                pictureBox.Image = ByteArrayToImage(item.Hinh);
                pictureBox.Location = new Point(15, 30);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                groupBox.BackColor = Color.Cyan;
                pictureBox.Click += PictureBox_Click;
                pictureBox.Tag = item;
                groupBox.Controls.Add(pictureBox);
                flpClothing.Controls.Add(groupBox);
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            maQuanAoClick = ((sender as PictureBox).Tag as CLOTHING).MAQUANAO;
            txtSPClick.Text= ((sender as PictureBox).Tag as CLOTHING).TENQUANAO;
            List<CLOTHINGINFO> listSize = context.CLOTHINGINFOes.Where(p => p.MAQUANAOCLOTHINGINFO == maQuanAoClick).ToList();
            if (listSize.Count > 0)
            {
                cbbSizeClothing.DataSource = listSize;
                cbbSoLuongCon.DataSource = listSize;
                
                cbbSoLuongCon.DisplayMember = "SOLUONG";
                cbbSizeClothing.ValueMember = "ID";
                cbbSizeClothing.DisplayMember = "SIZE";
            }
            else
            {
                cbbSizeClothing.Text = "Chưa có dữ liệu";
                cbbSoLuongCon.Text = "Chưa có dữ liệu";
                cbbSizeClothing.DataSource = null;
            }
        }
        private void CheckBillExist()
        {
            int i = 1;
            string idBill;
            while (true)
            {
                idBill = "bill00";
                idBillNew = idBill += i.ToString();
                BILL dbCheckBill = context.BILLs.FirstOrDefault(p => p.MABILL == idBillNew );
                if (dbCheckBill != null)
                {
                    i++;
                }
                else
                {
                    
                    int newSTT = context.CLIENTs.Max(p => p.STT);
                    CLIENT c = new CLIENT()
                    {
                        STT = context.CLIENTs.Max(p => p.STT) + 1,
                        SDT = "KHONG",
                        HOTENKH = "KHONG",
                        DIACHI = "KHONG"
                    };
                    context.CLIENTs.AddOrUpdate(c);
                    context.SaveChanges();
                    idClientNew = c.STT;
                    BILL h = new BILL()
                    {
                        MABILL = idBillNew,
                        GIORA = null,
                        TRANGTHAI = 0,
                        DISCOUNT = 0,
                        TOTALPRICE = 0,
                        STT = context.CLIENTs.Max(p => p.STT),
                        MANHAVIEN = loginAccountDTO.IdNhanVien
                    };
                    context.BILLs.AddOrUpdate(h);
                    context.SaveChanges();
                    idBillOld = h.MABILL;
                    return;
                }
            }
        }
        private int CheckCountClothing(string maQuanAo, int soLuong, int IDSize)
        {
            CLOTHINGINFO dbUpdfateCount = context.CLOTHINGINFOes.FirstOrDefault(p => p.MAQUANAOCLOTHINGINFO == maQuanAo && p.ID == IDSize);
            if (dbUpdfateCount.SOLUONG < soLuong)
            {
                return -1;
            }
            return soLuong;
        }
        private void CheckCountPro()
        {
            List<BILLINFO> listUpdateBill = context.BILLINFOes.Where(p => p.MABILL == idBillOld).ToList();
            foreach (BILLINFO billInfo in listUpdateBill)
            {
                if (CheckCountClothing(billInfo.MAQUANAO, billInfo.SOLUONG, (int)billInfo.IDSIZE) == -1)
                {
                    MessageBox.Show(string.Format("Sản phẩm( {0} Size {1} ) không đủ ", billInfo.CLOTHINGINFO.CLOTHING.TENQUANAO, billInfo.CLOTHINGINFO.SIZE), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BILLINFO dbDelete = context.BILLINFOes.FirstOrDefault(p => p.MABILL == billInfo.MABILL && p.MAQUANAO == billInfo.MAQUANAO && p.IDSIZE == billInfo.IDSIZE);
                    context.BILLINFOes.Remove(dbDelete);
                    context.SaveChanges();
                    ShowBill(idBillOld);
                    return;
                }
            }
        }
        private bool CheckValueRegexInputClient()
        {
            Regex rSDT = new Regex(@"^(0)(3|7|8|9)\d{8}$");
            Regex rName = new Regex(@"(^\D(\D+)$)");
            if (txtSDT.Text != "" && !rSDT.IsMatch(txtSDT.Text))
            {
                MessageBox.Show("Nhập đúng định dạng số điện thoại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtFullName.Text != "" && !rName.IsMatch(txtFullName.Text))
            {
                MessageBox.Show("Không được có số trong tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void InsertBillInfo(string idBill)
        {
            if (maQuanAoClick!="" && cbbSizeClothing.DataSource!=null)
            {
                int count = (int)nudCount.Value;
                int maSize = (int)cbbSizeClothing.SelectedValue;
                BILLINFO dbChecked = context.BILLINFOes.FirstOrDefault(p => p.MAQUANAO == maQuanAoClick && p.IDSIZE == maSize && p.MABILL == idBill);
                if (dbChecked == null)
                {
                    if (count > 0)
                    {
                        BILLINFO bf = new BILLINFO()
                        {
                            SOLUONG = count,
                            MABILL = idBill,
                            MAQUANAO = maQuanAoClick,
                            IDSIZE = (int)cbbSizeClothing.SelectedValue
                        };
                        context.BILLINFOes.AddOrUpdate(bf);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng không được âm", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    dbChecked.SOLUONG += count;
                    if (dbChecked.SOLUONG <= 0)
                    {
                        context.BILLINFOes.Remove(dbChecked);
                    }
                }
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
           
        }
        private void ShowBill(string maBill)
        {
            lvBill.Items.Clear();
            double totalPrice = 0;
            List<MenuBillDTO> listMenu = MenuBillDAO.Instance.GetBillMenu(maBill);

            foreach (MenuBillDTO item in listMenu)
            {
                ListViewItem listViewItem = new ListViewItem(item.TenQuanAo.ToString());// tạo dòng mới cho listview
                listViewItem.SubItems.Add(item.Size.ToString());
                listViewItem.SubItems.Add(item.SoLuong.ToString());// số lượng
                listViewItem.SubItems.Add(item.Price.ToString("c", culture));// giá tiền
                listViewItem.SubItems.Add(item.ThanhTien.ToString("c", culture));
                totalPrice += item.ThanhTien;
                lvBill.Items.Add(listViewItem);
            }
            tienPhaiTra = totalPrice;
            txtSum.Text = totalPrice.ToString("c", culture);
        }
        private void UpdateCountClothing(string maQuanAo, int soLuong, int IDSize)
        {
            CLOTHINGINFO dbUpdfateCount = context.CLOTHINGINFOes.FirstOrDefault(p => p.MAQUANAOCLOTHINGINFO == maQuanAo && p.ID == IDSize);
            if (dbUpdfateCount != null)
            {
                dbUpdfateCount.SOLUONG -= soLuong;
            }
            context.SaveChanges();
        }
        private void BillPaid(string maBill)
        {
            int discount = (int)nudDiscount.Value;
            BILL dbUpdateBill = context.BILLs.FirstOrDefault(p => p.MABILL == maBill && p.TRANGTHAI == 0);
            if (dbUpdateBill != null)
            {
                dbUpdateBill.GIORA = DateTime.Now;
                dbUpdateBill.TRANGTHAI = 1;// đã thanh toán 
                dbUpdateBill.DISCOUNT = (int)nudDiscount.Value;
                double totalPrice = context.BILLINFOes.Where(p => p.MABILL == dbUpdateBill.MABILL).Sum(p => p.SOLUONG * p.CLOTHINGINFO.PRICE);
                double finalPrice = totalPrice - (totalPrice / 100) * discount;
                dbUpdateBill.TOTALPRICE = finalPrice;
            }
            context.SaveChanges();
        }
        private void ClientPiad(int idClient)
        {
            CLIENT dbUpdateClient = context.CLIENTs.FirstOrDefault(p => p.STT == idClient);
            if (dbUpdateClient != null)
            {
                if (txtFullName.Text == "")
                {
                    dbUpdateClient.HOTENKH = "KHONG";
                }
                else
                {
                    dbUpdateClient.HOTENKH = txtFullName.Text;
                }


                if (txtSDT.Text == "")
                {
                    dbUpdateClient.SDT = "KHONG";
                }
                else
                {
                    dbUpdateClient.SDT = txtSDT.Text;
                }

                if (txtDiaChi.Text == "")
                {
                    dbUpdateClient.DIACHI = "KHONG";
                }
                else
                {
                    dbUpdateClient.DIACHI = txtDiaChi.Text;
                }

            }
            context.SaveChanges();
        }
        // chuyển byte sang image
        private Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);//mã hóa mảng byte
            return Image.FromStream(m);// chuyển đổi m sang hình
        }
        // xóa khách đã có trong SQL
        private void DeleteClientExist(string maBill)
        {
            int sDT;
            BILL billOfClient = context.BILLs.FirstOrDefault(p => p.MABILL == maBill);//bill mới
            CLIENT dbDelete = context.CLIENTs.FirstOrDefault(p => p.SDT == billOfClient.CLIENT.SDT);// khách đã có thông tin
            if (!Int32.TryParse(billOfClient.CLIENT.SDT, out sDT))
            {// không chuyển được
                CLIENT dbClientNoData = context.CLIENTs.FirstOrDefault(p => p.STT == idClientNew);
                context.CLIENTs.Remove(dbClientNoData);
                context.SaveChanges();
                idClientNew = 0;
            }
            else // chuyển được 
            if (dbDelete != null)
            {
                List<BILL> listBill = context.BILLs.Where(p => p.STT == dbDelete.STT).ToList();
                List<CLIENT> listClient = context.CLIENTs.Where(p => p.SDT == billOfClient.CLIENT.SDT).ToList();
                if (listClient.Count > 1)
                {
                    foreach (BILL itemBill in listBill)
                    {
                        itemBill.STT = billOfClient.STT;
                        context.SaveChanges();
                    }
                    context.CLIENTs.Remove(dbDelete);
                    context.SaveChanges();
                }
            }
        }
        // reset Data 
        private void ResetData()
        {
            cbbCategory.SelectedIndex = 0;
            nudCount.Value = 1;
            nudDiscount.Value = 0;
            txtSDT.Text = txtFullName.Text = txtDiaChi.Text = txtSum.Text = txtFinalSum.Text = "";
        }
        #endregion

        #region event
        private void FManagerSellClothing_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadLayoutClothing(context.CLOTHINGs.ToList());
            btnDelProduct.Enabled = false;
        }
        private void cbbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbCategory.DataSource != null)
            {
                string maloai = cbbCategory.SelectedValue.ToString();
                List<CLOTHING> listLoad = context.CLOTHINGs.Where(p => p.MALOAICLOTHING == maloai).ToList();
                cbbProduct.DataSource = listLoad;
                cbbProduct.DisplayMember = "TENQUANAO";
                cbbProduct.ValueMember = "MAQUANAO";
                LoadLayoutClothing(listLoad);
            }
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadLayoutClothing(context.CLOTHINGs.ToList());
            txtSPClick.Text = "Chọn sản phẩm";
            cbbSizeClothing.Text= "Chọn sản phẩm";
            cbbSoLuongCon.Text = "Chọn sản phẩm";
        }
        private void btnAddProductSell_Click(object sender, EventArgs e)
        {
            BILL dbCheckBill = context.BILLs.FirstOrDefault(p => p.MABILL == idBillOld);
            
            if (dbCheckBill == null)
            {
                CheckBillExist();
                InsertBillInfo(idBillOld);
                ShowBill(idBillOld);
                CheckCountPro();
            }
            else
            {
                InsertBillInfo(idBillOld);
                ShowBill(idBillOld);
                CheckCountPro();
            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (CheckValueRegexInputClient())
            {
                if (lvBill.Items.Count > 0)
                {
                    if (MessageBox.Show("Bạn có chắc là muốn thanh toán", "Thắc mắc", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<BILLINFO> listUpdateBill = context.BILLINFOes.Where(p => p.MABILL == idBillOld).ToList();
                        foreach (BILLINFO bILLINFOUpdate in listUpdateBill)
                        {
                            UpdateCountClothing(bILLINFOUpdate.MAQUANAO, bILLINFOUpdate.SOLUONG, (int)bILLINFOUpdate.IDSIZE);
                        }
                        ClientPiad(idClientNew);
                        BillPaid(idBillOld);
                        FormReportBillForClient f = new FormReportBillForClient(idBillOld);
                        f.ShowDialog();
                        DeleteClientExist(idBillOld);
                        MessageBox.Show("Đã thanh toán");
                        lvBill.Items.Clear();
                        idBillNew = idBillOld = "";
                        idClientNew = 0;
                        tienPhaiTra = 0;
                        ResetData();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm");
                }
            }
        }
        private void txtSum_TextChanged(object sender, EventArgs e)
        {
            nudDiscount.ValueChanged += NudDiscount_ValueChanged;
            NudDiscount_ValueChanged(this, new EventArgs());
        }
        private void NudDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (idBillOld != "")
            {
                double tien = tienPhaiTra - tienPhaiTra / 100 * (int)nudDiscount.Value;
                txtFinalSum.Text = tien.ToString("c", culture);
            }
            else
            {
                txtFinalSum.Text = "";
            }

        }
        private void nudDiscount_ValueChanged_1(object sender, EventArgs e)
        {
            if (idBillOld != "")
            {
                double tien = tienPhaiTra - tienPhaiTra / 100 * (int)nudDiscount.Value;
                txtFinalSum.Text = tien.ToString("c", culture);
            }
            else
            {
                txtFinalSum.Text = "";
            }
        }
        private void cbbCategory_TextChanged(object sender, EventArgs e)
        {
            List<CLOTHING> listClothing = context.CLOTHINGs.ToList();
            List<CLOTHING> listClothingSearch = context.CLOTHINGs.Where(p => p.CLOTHINGCATEGORY.TENLOAI.ToLower().Contains(cbbCategory.Text.ToLower())).ToList();
            if (cbbCategory.Text != "")
            {
                LoadLayoutClothing(listClothingSearch);
            }
            else
            {
                LoadLayoutClothing(listClothing);
            }
        }

        private void cbbProduct_TextChanged(object sender, EventArgs e)
        {
            List<CLOTHING> listClothing = context.CLOTHINGs.ToList();
            List<CLOTHING> listClothingSearch = context.CLOTHINGs.Where(p => p.TENQUANAO.ToLower().Contains(cbbProduct.Text.ToLower())).ToList();
            if (cbbProduct.Text != "")
            {
                LoadLayoutClothing(listClothingSearch);
            }
            else
            {
                LoadLayoutClothing(listClothing);
            }
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.InsertCategoryManager += F_InsertCategoryManager;
            f.DeleteCategoryManager += F_DeleteCategoryManager;
            f.InsertClothing += F_InsertClothing;
            f.UpdateClothing += F_UpdateClothing;
            f.InsertClothingInfo += F_InsertClothingInfo;
            f.UpdateClothingInfo += F_UpdateClothingInfo;
            f.DeleteSize += F_DeleteSize;
            f.AccountManagerUpdate += F_AccountManagerUpdate;
            f.EventDeleteAcc += F_EventDeleteAcc;
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void thôngTinTàiKhoảngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void FManagerSellClothing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (idBillOld != "")
            {
                if (MessageBox.Show("Bill chưa thanh toán !\nBạn có muốn thoát không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    List<BILLINFO> listDeleteBIFExit = context.BILLINFOes.Where(p => p.MABILL == idBillOld).ToList();
                    foreach (BILLINFO item in listDeleteBIFExit)
                    {
                        context.BILLINFOes.Remove(item);
                        context.SaveChanges();
                    }
                    context.BILLs.Remove(context.BILLs.FirstOrDefault(p => p.MABILL == idBillOld));
                    context.SaveChanges();
                    context.CLIENTs.Remove(context.CLIENTs.FirstOrDefault(p => p.STT == idClientNew));
                    context.SaveChanges();
                    idClientNew = 0;
                    idBillOld = "";
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn thoát không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }
        private void lvBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvBill.SelectedItems)
            {
                cbbProduct.Text = item.SubItems[0].Text;
                CLOTHING dbMaLoai = context.CLOTHINGs.FirstOrDefault(p => p.TENQUANAO == cbbProduct.Text.ToString());
                CLOTHINGCATEGORY dbCategory = context.CLOTHINGCATEGORies.FirstOrDefault(p => p.MALOAI == dbMaLoai.MALOAICLOTHING);
                cbbCategory.Text = dbCategory.TENLOAI;
                cbbSizeClothing.Text = item.SubItems[1].Text;
                nudCount.Value = Convert.ToDecimal(item.SubItems[2].Text);
            }
            btnDelProduct.Enabled = true;
        }
        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            if (lvBill.Items.Count > 0)
            {
                BILLINFO dbDelete = context.BILLINFOes.FirstOrDefault(p => p.IDSIZE.ToString() == cbbSizeClothing.SelectedValue.ToString() && p.MAQUANAO == cbbProduct.SelectedValue.ToString() && p.MABILL == idBillOld);
                if (dbDelete != null)
                {
                    context.BILLINFOes.Remove(dbDelete);
                    context.SaveChanges();
                    lvBill.Items.Clear();
                    ShowBill(idBillOld);
                    MessageBox.Show("Xóa thành công ");
                    btnDelProduct.Enabled = false;
                    if (context.BILLINFOes.Where(p => p.MABILL == idBillOld).ToList().Count == 0)
                    {
                        context.BILLs.Remove(context.BILLs.FirstOrDefault(p => p.MABILL == idBillOld));
                        context.SaveChanges();
                        ShowBill(idBillOld);
                        context.CLIENTs.Remove(context.CLIENTs.FirstOrDefault(p => p.STT == idClientNew));
                        context.SaveChanges();
                        idClientNew = 0;
                        idBillOld = "";
                    }
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào để xóa");
            }
        }
        #endregion

        #region MyEvent
        private void F_DeleteSize(object sender, fAdmin.IDClothingEvent e)
        {
            LoadCategory();
            LoadLayoutClothing(context.CLOTHINGs.ToList());
            List<BILLINFO> listDeleteBIF = context.BILLINFOes.Where(p => p.MAQUANAO == e.IDClothing && p.MABILL == idBillOld && p.IDSIZE == e.IdSize).ToList();
            if (listDeleteBIF.Count > 0)
            {
                foreach (BILLINFO infoBill in listDeleteBIF)
                {
                    context.BILLINFOes.Remove(infoBill);
                    context.SaveChanges();
                    ShowBill(idBillOld);
                }
                if (context.BILLINFOes.Where(p => p.MABILL == idBillOld).ToList().Count == 0)
                {
                    context.BILLs.Remove(context.BILLs.FirstOrDefault(p => p.MABILL == idBillOld));
                    context.SaveChanges();
                    ShowBill(idBillOld);
                    idBillOld = "";
                }
            }
        }
        private void F_UpdateClothingInfo(object sender, EventArgs e)
        {
            LoadLayoutClothing(context.CLOTHINGs.ToList());
            if (idBillOld != "")
                ShowBill(idBillOld);
        }
        private void F_UpdateClothing(object sender, EventArgs e)
        {
            LoadLayoutClothing(context.CLOTHINGs.ToList());
            if (idBillOld != "")
                ShowBill(idBillOld);
        }
        private void F_InsertClothingInfo(object sender, EventArgs e)
        {
            LoadLayoutClothing(context.CLOTHINGs.ToList());
        }
        private void F_InsertClothing(object sender, EventArgs e)
        {
            LoadLayoutClothing(context.CLOTHINGs.ToList());
        }
        private void F_DeleteCategoryManager(object sender, fAdmin.IDClothingEvent e)
        {
            LoadCategory();
            LoadLayoutClothing(context.CLOTHINGs.ToList());
            List<BILLINFO> listDeleteBIF = context.BILLINFOes.Where(p => p.MAQUANAO == e.IDClothing && p.MABILL == idBillOld).ToList();
            if (listDeleteBIF.Count > 0)
            {
                foreach (BILLINFO infoBill in listDeleteBIF)
                {
                    context.BILLINFOes.Remove(infoBill);
                    context.SaveChanges();
                    ShowBill(idBillOld);
                }
                if (context.BILLINFOes.Where(p => p.MABILL == idBillOld).ToList().Count == 0)
                {
                    context.BILLs.Remove(context.BILLs.FirstOrDefault(p => p.MABILL == idBillOld));
                    context.SaveChanges();
                    ShowBill(idBillOld);
                    idBillOld = "";
                }
            }
        }
        private int F_EventDeleteAcc(object ojb, string maNV)
        {
            if (LoginAccountDTO.IdNhanVien == maNV)
            {
                MessageBox.Show("Tài khoản này đang hoạt động \nKhông được xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            return 0;
        }
        private void F_InsertCategoryManager(object sender, EventArgs e)
        {
            LoadCategory();
        }
        private void F_AccountManagerUpdate(object sender, fAdmin.AccountEvent e)
        {
            if (LoginAccountDTO.IdNhanVien == e.MaNV)
            {
                STAFF staff = context.STAFFs.FirstOrDefault(p => p.IDNHANVIEN == e.MaNV);
                thôngTinTàiKhoảngToolStripMenuItem.Text = "";
                thôngTinTàiKhoảngToolStripMenuItem.Text += "Thông tin tài khoảng (" + staff.FULLNAME + ")";
            }
        }




        #endregion
    }
}
