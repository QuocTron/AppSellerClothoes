using ClothingSellManager.FormReport;
using ClothingSellManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingSellManager
{
    public partial class fAdmin : Form
    {
        ClothingContext context = new ClothingContext();
        CultureInfo culture = new CultureInfo("vi-VN");

        public fAdmin()
        {
            InitializeComponent();
            ptbImgUser.Image = new Bitmap(Application.StartupPath + "\\Resources\\user (3).png");
            pbImgClothing.Image = new Bitmap(Application.StartupPath + "\\Resources\\NoImage.jpg");
        }

        #region method
        private void LoadCategory()
        {
            List<CLOTHINGCATEGORY> listCategory = context.CLOTHINGCATEGORies.ToList();
            List<CLOTHING> listClothing = context.CLOTHINGs.ToList();
            List<CLOTHINGINFO> listClothinginfo = context.CLOTHINGINFOes.ToList();
            List<STAFF> listStaff = context.STAFFs.ToList();
            BindGirdCategory(listCategory);
            BindGirdClothing(listClothing);
            BindGirdSize(listClothinginfo);
            BindGirdAccount(listStaff);
        }
        private void LoadComboClothing()
        {
            LoadComBoBoxTenSPSize();
            LoadComBoBoxCategory();
            LoadComBoBoxPosition();
        }
        private void LoadComBoBoxCategory()
        {
            cbbCategory.DataSource = context.CLOTHINGCATEGORies.ToList();
            cbbCategory.DisplayMember = "TENLOAI";
            cbbCategory.ValueMember = "MALOAI";
        }
        private void LoadComBoBoxTenSPSize()
        {
            cbTenSPSize.DataSource = context.CLOTHINGs.ToList();
            cbTenSPSize.DisplayMember = "TENQUANAO";
            cbTenSPSize.ValueMember = "MAQUANAO";
        }
        private void LoadComBoBoxPosition()
        {
            cbbChucVu.DataSource = context.POSITIONs.ToList();
            cbbChucVu.DisplayMember = "TENBOPHAN";
            cbbChucVu.ValueMember = "MABOPHAN";
        }
        private void BindGirdCategory (List<CLOTHINGCATEGORY> listClothingCategory)
        {
            dtgvCategory.Rows.Clear();
            foreach (CLOTHINGCATEGORY item in listClothingCategory)
            {
                int index = dtgvCategory.Rows.Add();
                dtgvCategory.Rows[index].Cells["IDLOAI"].Value = item.MALOAI;
                dtgvCategory.Rows[index].Cells["TENLOAI"].Value = item.TENLOAI;
            }
        }

        private void BindGirdClothing(List<CLOTHING> listClothing)
        {
            dtgvProduct.Rows.Clear();
            foreach (CLOTHING item in listClothing)
            {
                int index = dtgvProduct.Rows.Add();
                dtgvProduct.Rows[index].Cells["MAQUANAO"].Value = item.MAQUANAO;
                dtgvProduct.Rows[index].Cells["TENQUANAO"].Value = item.TENQUANAO;
                dtgvProduct.Rows[index].Cells["LOAI"].Value = item.CLOTHINGCATEGORY.TENLOAI;
            }
            
        }
        private void BindGirdSales(List<BILL> listSales)
        {
            dtgvSales.Rows.Clear();
            foreach (BILL item in listSales)
            {
                int index = dtgvSales.Rows.Add();
                dtgvSales.Rows[index].Cells["MaBill"].Value = item.MABILL;
                dtgvSales.Rows[index].Cells["GioRa"].Value = item.GIORA;
                dtgvSales.Rows[index].Cells["TrangThai"].Value = item.TRANGTHAI == 1 ? "Đã thanh toán" : "Chưa thanh toán";
                dtgvSales.Rows[index].Cells["Discount"].Value = item.DISCOUNT.ToString() + "%";
                dtgvSales.Rows[index].Cells["TotalPrice"].Value = item.TOTALPRICE.ToString("c", culture);
                dtgvSales.Rows[index].Cells["STT"].Value = item.STT != null ? item.CLIENT.HOTENKH : "Khách không để lại";
                dtgvSales.Rows[index].Cells["MaNhanVien"].Value = item.MANHAVIEN == null ? "Đã nghỉ việc" : item.STAFF.FULLNAME;
            }
        }
        private void BindGirdSize(List<CLOTHINGINFO> listClothinginfo)
        {
            dtgvSize.Rows.Clear();
            foreach (CLOTHINGINFO item in listClothinginfo)
            {
                int index = dtgvSize.Rows.Add();
                dtgvSize.Rows[index].Cells["IDSIZE"].Value = item.ID;
                dtgvSize.Rows[index].Cells["SIZE"].Value = item.SIZE;
                dtgvSize.Rows[index].Cells["PRICE"].Value = item.PRICE;
                dtgvSize.Rows[index].Cells["TENQUANAOSIZE"].Value = item.CLOTHING.TENQUANAO;
                dtgvSize.Rows[index].Cells["SOLUONG"].Value = item.SOLUONG;

            }
        }
        private void BindGirdAccount(List<STAFF> listStaff)
        {
            dtgvAccount.Rows.Clear();
            foreach (STAFF staff in listStaff)
            {
                int index = dtgvAccount.Rows.Add();
                dtgvAccount.Rows[index].Cells["IDNHANVIEN"].Value = staff.IDNHANVIEN;
                dtgvAccount.Rows[index].Cells["FULLNAME"].Value = staff.FULLNAME;
                dtgvAccount.Rows[index].Cells["MABOPHANSTAFF"].Value = staff.POSITION.TENBOPHAN;
            }
        }
        private void LoadDataCategoryChange()
        {
            BindGirdCategory(context.CLOTHINGCATEGORies.ToList());
            BindGirdClothing(context.CLOTHINGs.ToList());
            BindGirdSize(context.CLOTHINGINFOes.ToList());
            LoadComBoBoxCategory();
            LoadComBoBoxTenSPSize();
        }
        private void LoadDataClothingChange()
        {
            BindGirdClothing(context.CLOTHINGs.ToList());
            BindGirdSize(context.CLOTHINGINFOes.ToList());
            LoadComBoBoxTenSPSize();
        }
        private bool CheckValueCategory()
        {
            if (txtIDCat.Text == "")
            {
                MessageBox.Show("Nhập ID danh mục");
                return false;
            }
            if (txtNameCat.Text == "")
            {
                MessageBox.Show("Nhập tên danh mục");
                return false;
            }
            return true;
        }
        private bool CheckValueClothing()
        {
            if (txtIDClothing.Text == "" && txtNameClothing.Text == "")
            {
                MessageBox.Show("Bạn vui lòng nhập thông tin !");
                return false;
            }
            else if (txtIDClothing.Text == "")
            {
                MessageBox.Show("Bạn vui lòng nhập Mã quần áo !");
                txtIDClothing.Focus();
                return false;
            }
            else if (txtNameClothing.Text == "")
            {
                MessageBox.Show("Bạn vui lòng nhập tên quần áo !");
                txtNameClothing.Focus();
                return false;
            }
            return true;
        }
        private bool CheckValueSize()
        {
            if (txtSize.Text == "")
            {
                MessageBox.Show("Chưa nhập Size");
                return false;
            }
            if (mnProductGia.Value < 10000)
            {
                MessageBox.Show("Giá phải nhập trên 10000");
                return false;
            }
            if (numricSoLuong.Value < 10)
            {
                MessageBox.Show("Nhập số lượng trên 10");
                return false;
            }
            return true;
        }
        private bool CheckValueAccount()
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Nhập Mã nhân viên");
                return false;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Nhập tên nhân viên");
                return false;
            }
            return true;
        }
        private int GetSelectItemsCategory(string idCategory, string tenCat)
        {
            for (int i = 0; i < dtgvCategory.Rows.Count; i++)
            {
                if (dtgvCategory.Rows[i].Cells[0].Value.ToString() == idCategory && dtgvCategory.Rows[i].Cells[1].Value.ToString().ToLower() == tenCat.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }
        private int GetSelectedClothingInfo(string size, string maQuanAo)
        {
            for (int i = 0; i < dtgvSize.Rows.Count; i++)
            {
                if (dtgvSize.Rows[i].Cells[1].Value.ToString().ToLower() == size.ToLower() && dtgvSize.Rows[i].Cells[3].Value.ToString().ToLower() == maQuanAo.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }
        private int GetSelectedClothing(string tenQuanAo , string maLoai)
        {
            for (int i = 0; i < dtgvProduct.Rows.Count; i++)
            {
                if (dtgvProduct.Rows[i].Cells[1].Value.ToString().ToLower() == tenQuanAo.ToLower() && dtgvProduct.Rows[i].Cells[2].Value.ToString().ToLower() == maLoai.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }
        private int GetSelectedAccount(string maNV)
        {
            for (int i = 0; i < dtgvAccount.Rows.Count; i++)
            {
                if (dtgvAccount.Rows[i].Cells[0].Value.ToString().ToLower() == maNV)
                {
                    return i;
                }
            }
            return -1;
        }
        private void ReloadDTGV()
        {
            BindGirdCategory(context.CLOTHINGCATEGORies.ToList());
            txtIDCat.Text = "";
            txtNameCat.Text = "";
        }
        private void ResetTxtClothing()
        {
            txtIDClothing.Text = "";
            txtNameClothing.Text = "";
            cbbCategory.SelectedIndex = 0;
            pbImgClothing.Image = new Bitmap(Application.StartupPath + "\\Resources\\NoImage.jpg");
        }
        private void ResetTxtSize()
        {
            txtSize.Text = "";
            txtID.Text = "";
            cbTenSPSize.SelectedIndex = 0;
            mnProductGia.Value = 0;
            numricSoLuong.Value = 0;
        }
        private void ResetTxtAcc()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            ptbImgUser.Image = new Bitmap(Application.StartupPath + "\\Resources\\user (3).png");
        }
       
        string path = "";
        private void LoadFileImage(PictureBox ptb)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                ptb.Image = Image.FromFile(open.FileName);
                path = open.FileName;
            }
        }
        // chuyển hình sang byte[]
        private byte[] ImageToByteArray (Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png); 
            return m.ToArray();
        }
        // chuyển byte[] sang hình
        private Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b); // mã hóa byte
            return Image.FromStream(m);// tạo ra 1 hình ảnh từ m
        }
        private void LoadSales()
        {
            List<BILL> listSales = context.BILLs.ToList();
            BindGirdSales(listSales);
        }
        #endregion

        #region event
        private void fAdmin_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            dateTimePicker1.Value = new DateTime(today.Year, today.Month, today.Day, today.Hour, today.Minute, today.Second);
            LoadCategory();
            LoadComboClothing();
            InsertCategory += FAdmin_InsertCategory;
            DeleteChildOfCategory += FAdmin_DeleteChildOfCategory;
            DeleteClothing += FAdmin_DeleteClothing;

        }

       

        // thêm xóa sửa quần áo
        private void btnAddPro_Click(object sender, EventArgs e)
        {
            if (CheckValueClothing())
            {
                string check = txtIDClothing.Text;
                var checks = context.CLOTHINGs.FirstOrDefault(p => p.MAQUANAO == check);
                if (checks == null)
                {
                    if (GetSelectedClothing(txtNameClothing.Text, cbbCategory.Text.ToString()) == -1)
                    {
                        CLOTHING insert = new CLOTHING();
                        insert.MAQUANAO = txtIDClothing.Text.Trim();
                        insert.TENQUANAO = txtNameClothing.Text.Trim();
                        insert.MALOAICLOTHING = cbbCategory.SelectedValue.ToString();
                        insert.Hinh = ImageToByteArray(pbImgClothing.Image);
                        context.CLOTHINGs.Add(insert);
                        context.SaveChanges();
                        LoadDataClothingChange();
                        if (insertClothing != null)
                            insertClothing(this, new EventArgs());
                        MessageBox.Show("Thêm dữ liệu thành công !");
                        ResetTxtClothing();
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm này đã tồn tại");
                    }
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm này đã tồn tại !");
                }
            }
        }
        private void btnDelPro_Click(object sender, EventArgs e)
        {
            if (CheckValueClothing())
            {
                string check = txtIDClothing.Text;
                CLOTHING delete = context.CLOTHINGs.FirstOrDefault(p => p.MAQUANAO == check);
                if (delete != null)
                {
                    DialogResult dia = MessageBox.Show("Bạn có muốn xóa !", "Thông báo", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == dia)
                    {
                        if (deleteClothing != null)
                            deleteClothing(this, new EventArgs());
                        context.CLOTHINGs.Remove(delete);
                        context.SaveChanges();
                        LoadDataClothingChange();
                        MessageBox.Show("Xóa dữ liệu thành công !");
                        ResetTxtClothing();
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại sản phẩm này");
                }
            }
            else
            {
                MessageBox.Show("Xóa dữ liệu thất bại");
            }

        }
        private void btnEditPro_Click(object sender, EventArgs e)
        {
            if (CheckValueClothing())
            {
                string check = txtIDClothing.Text;
                var update = context.CLOTHINGs.FirstOrDefault(p => p.MAQUANAO == check);
                if (update != null)
                {
                    update.MAQUANAO = txtIDClothing.Text;
                    update.TENQUANAO = txtNameClothing.Text;
                    update.MALOAICLOTHING = cbbCategory.SelectedValue.ToString();
                    update.Hinh = ImageToByteArray(pbImgClothing.Image);

                    context.SaveChanges();
                    LoadDataClothingChange();
                    if (updateClothing != null)
                        updateClothing(this, new EventArgs());
                    MessageBox.Show("Cập nhật dữ liệu thành công !");
                }
                else
                {
                    MessageBox.Show("Không tồn tại sản phẩm này");
                }
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại !");
            }
        }
        private void dtgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgvProduct.CurrentRow.Selected = true;
                txtIDClothing.Text = dtgvProduct.Rows[e.RowIndex].Cells["MAQUANAO"].Value.ToString();
                txtNameClothing.Text = dtgvProduct.Rows[e.RowIndex].Cells["TENQUANAO"].Value.ToString();
                cbbCategory.DataSource = context.CLOTHINGCATEGORies.ToList();
                cbbCategory.DisplayMember = "TENLOAI";
                cbbCategory.ValueMember = "MALOAI";
                cbbCategory.Text = dtgvProduct.Rows[e.RowIndex].Cells["LOAI"].Value.ToString();
                CLOTHING dbHinh = context.CLOTHINGs.FirstOrDefault(p => p.MAQUANAO == txtIDClothing.Text);
                pbImgClothing.Image = ByteArrayToImage(dbHinh.Hinh);
            }
            else
            {
                MessageBox.Show("Chọn đúng dòng");
            }
        }
        private void txtTenTim_TextChanged(object sender, EventArgs e)
        {
            List<CLOTHING> listClothing = context.CLOTHINGs.ToList();
            List<CLOTHING> listClothingSearch = context.CLOTHINGs.Where(p => p.TENQUANAO.ToLower().Contains(txtTenTim.Text.ToLower()) || p.MAQUANAO.ToLower().Contains(txtTenTim.Text.ToLower()) || p.CLOTHINGCATEGORY.TENLOAI.ToLower().Contains(txtTenTim.Text.ToLower())).ToList();
            if (txtTenTim.Text != "")
            {
                BindGirdClothing(listClothingSearch);
            }
            else
            {
                BindGirdClothing(listClothing);
            }
        }
        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            LoadFileImage(pbImgClothing);
        }
        private void pbImgClothing_Click(object sender, EventArgs e)
        {
            LoadFileImage(pbImgClothing);
        }
        private void btnShowPro_Click(object sender, EventArgs e)
        {
            BindGirdClothing(context.CLOTHINGs.ToList());
            ResetTxtClothing();
        }
        private void btnSearchClothing_Click(object sender, EventArgs e)
        {
            if (dtgvProduct.Rows.Count != 0)
            {
                txtIDClothing.Text = dtgvProduct.Rows[0].Cells["MAQUANAO"].Value.ToString();
                txtNameClothing.Text = dtgvProduct.Rows[0].Cells["TENQUANAO"].Value.ToString();
                cbbCategory.DataSource = context.CLOTHINGCATEGORies.ToList();
                cbbCategory.DisplayMember = "TENLOAI";
                cbbCategory.ValueMember = "MALOAI";
                cbbCategory.Text = dtgvProduct.Rows[0].Cells["LOAI"].Value.ToString();
                CLOTHING dbHinh = context.CLOTHINGs.FirstOrDefault(p => p.MAQUANAO == txtIDClothing.Text);
                pbImgClothing.Image = ByteArrayToImage(dbHinh.Hinh);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để lấy");
            }
        }
        private void btcNoImg_Click(object sender, EventArgs e)
        {
            pbImgClothing.Image = new Bitmap(Application.StartupPath + "\\Resources\\NoImage.jpg");
        }
        // thêm xóa sửa Size
        private void btnAddSize_Click(object sender, EventArgs e)
        {
            if (CheckValueSize())
            {
                if (GetSelectedClothingInfo(txtSize.Text, cbTenSPSize.Text.ToString()) == -1)
                {
                    CLOTHINGINFO clothingInFo = new CLOTHINGINFO()
                    {
                        SIZE = txtSize.Text,
                        PRICE = (double)mnProductGia.Value,
                        MAQUANAOCLOTHINGINFO = cbTenSPSize.SelectedValue.ToString(),
                        SOLUONG = (int)numricSoLuong.Value
                    };

                    context.CLOTHINGINFOes.AddOrUpdate(clothingInFo);
                    context.SaveChanges();
                    BindGirdSize(context.CLOTHINGINFOes.ToList());
                    if (insertClothingInfo != null)
                        insertClothingInfo(this, new EventArgs());
                    MessageBox.Show("Thêm dữ liệu thành công");
                    ResetTxtSize();
                }
                else
                {
                    MessageBox.Show("Sản phẩm này đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        private void btnDelSize_Click(object sender, EventArgs e)
        {
            if (CheckValueSize())
            {
                CLOTHINGINFO delete = context.CLOTHINGINFOes.FirstOrDefault(p => p.ID.ToString() == txtID.Text || (p.SIZE == txtSize.Text && cbTenSPSize.SelectedValue.ToString() == p.MAQUANAOCLOTHINGINFO));
                if (delete != null)
                {
                    DialogResult dia = MessageBox.Show("Bạn có muốn xóa !", "Thông báo", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == dia)
                    {
                        if (deleteSize != null)
                            deleteSize(this, new IDClothingEvent(delete.MAQUANAOCLOTHINGINFO, delete.ID));
                        List<BILLINFO> listDeleteBillInfo = context.BILLINFOes.Where(p => p.IDSIZE == delete.ID).ToList();
                        foreach (BILLINFO item in listDeleteBillInfo)
                        {
                            item.IDSIZE = null;
                            context.SaveChanges();
                        }
                        context.CLOTHINGINFOes.Remove(delete);
                        context.SaveChanges();
                        BindGirdSize(context.CLOTHINGINFOes.ToList());
                        MessageBox.Show("Xóa dữ liệu thành công !");
                        ResetTxtSize();
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại sản phẩm này");
                }
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        private void btnEditSize_Click(object sender, EventArgs e)
        {
            if (CheckValueSize())
            {
                CLOTHINGINFO dbUpdate = context.CLOTHINGINFOes.FirstOrDefault(p => p.ID.ToString() == txtID.Text || (p.SIZE == txtSize.Text && cbTenSPSize.SelectedValue.ToString() == p.MAQUANAOCLOTHINGINFO));
                if (dbUpdate != null)
                {
                    dbUpdate.SIZE = txtSize.Text;
                    dbUpdate.PRICE = (double)mnProductGia.Value;
                    dbUpdate.MAQUANAOCLOTHINGINFO = cbTenSPSize.SelectedValue.ToString();
                    dbUpdate.SOLUONG = (int)numricSoLuong.Value;
                    context.SaveChanges();
                    BindGirdSize(context.CLOTHINGINFOes.ToList());
                    MessageBox.Show("Cập nhật danh mục thành công");
                    if (updateClothingInfo != null)
                        updateClothingInfo(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Không tồn tại sản phẩm này");
                }
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }
        private void dtgvSize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtID.Text = dtgvSize.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSize.Text = dtgvSize.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbTenSPSize.DataSource = context.CLOTHINGs.ToList();
                cbTenSPSize.DisplayMember = "TENQUANAO";
                cbTenSPSize.ValueMember = "MAQUANAO";
                cbTenSPSize.Text = dtgvSize.Rows[e.RowIndex].Cells[1].Value.ToString();
                mnProductGia.Value = Convert.ToDecimal(dtgvSize.Rows[e.RowIndex].Cells[3].Value.ToString());
                numricSoLuong.Value = Convert.ToDecimal(dtgvSize.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            else
            {
                MessageBox.Show("Chọn đúng dòng");
            }
        }
        private void btnShowSize_Click(object sender, EventArgs e)
        {
            List<CLOTHINGINFO> listClothingCount = context.CLOTHINGINFOes.OrderBy(p => p.SOLUONG).ToList();
            dtgvSize.Rows.Clear();
            foreach (CLOTHINGINFO item in listClothingCount)
            {
                int index = dtgvSize.Rows.Add();
                dtgvSize.Rows[index].Cells["IDSIZE"].Value = item.ID;
                dtgvSize.Rows[index].Cells["SIZE"].Value = item.SIZE;
                dtgvSize.Rows[index].Cells["PRICE"].Value = item.PRICE;
                dtgvSize.Rows[index].Cells["TENQUANAOSIZE"].Value = item.CLOTHING.TENQUANAO;
                dtgvSize.Rows[index].Cells["SOLUONG"].Value = item.SOLUONG;
                if (Convert.ToInt32(dtgvSize.Rows[index].Cells["SOLUONG"].Value.ToString()) < 10)
                {
                    dtgvSize.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void btnLamMoiSize_Click(object sender, EventArgs e)
        {
            BindGirdSize(context.CLOTHINGINFOes.ToList());
            ResetTxtSize();
        }
        private void txtSearchSize_TextChanged(object sender, EventArgs e)
        {
            List<CLOTHINGINFO> listClothingIF = context.CLOTHINGINFOes.ToList();
            List<CLOTHINGINFO> listClothingIFSearch = context.CLOTHINGINFOes.Where(p => p.CLOTHING.TENQUANAO.ToLower().Contains(txtSearchSize.Text.ToLower()) || p.SIZE.ToLower().Contains(txtSearchSize.Text.ToLower()) || p.ID.ToString() == txtSearchSize.Text).ToList();
            if (txtSearchSize.Text != "")
            {
                BindGirdSize(listClothingIFSearch);
            }
            else
            {
                BindGirdSize(listClothingIF);
            }
        }
        private void btnSearchSize_Click(object sender, EventArgs e)
        {
            if (dtgvSize.Rows.Count != 0)
            {
                txtID.Text = dtgvSize.Rows[0].Cells[0].Value.ToString();
                txtSize.Text = dtgvSize.Rows[0].Cells[1].Value.ToString();
                cbTenSPSize.DataSource = context.CLOTHINGs.ToList();
                cbTenSPSize.DisplayMember = "TENQUANAO";
                cbTenSPSize.ValueMember = "MAQUANAO";
                cbTenSPSize.Text = dtgvSize.Rows[0].Cells[3].Value.ToString();
                mnProductGia.Value = Convert.ToDecimal(dtgvSize.Rows[0].Cells[2].Value.ToString());
                numricSoLuong.Value = Convert.ToDecimal(dtgvSize.Rows[0].Cells[4].Value.ToString());
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để lấy");
            }
        }
        // thêm xóa sửa danh mục
        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            if (CheckValueCategory())
            {
                if (GetSelectItemsCategory(txtIDCat.Text, txtNameCat.Text) == -1)
                {
                    CLOTHINGCATEGORY category = new CLOTHINGCATEGORY()
                    {
                        MALOAI = txtIDCat.Text,
                        TENLOAI = txtNameCat.Text,
                    };
                    context.CLOTHINGCATEGORies.AddOrUpdate(category);
                    context.SaveChanges();
                    LoadDataCategoryChange();
                    if (insertCategory != null)
                        insertCategory(this, new EventArgs());
                    if (insertCategoryManager != null)
                        insertCategoryManager(this, new EventArgs());
                    MessageBox.Show("Thêm danh mục thành công");
                    ReloadDTGV();
                }
                else
                {
                    MessageBox.Show(" Sản phẩm này đã tồn tại  ");
                }
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            if (CheckValueCategory())
            {
                CLOTHINGCATEGORY dbUpdate = context.CLOTHINGCATEGORies.FirstOrDefault(p => p.MALOAI == txtIDCat.Text);
                if (dbUpdate != null)
                {
                    dbUpdate.MALOAI = txtIDCat.Text;
                    dbUpdate.TENLOAI = txtNameCat.Text;
                    context.SaveChanges();
                    LoadDataCategoryChange();
                    if (insertCategory != null)
                        insertCategory(this, new EventArgs());
                    if (insertCategoryManager != null)
                        insertCategoryManager(this, new EventArgs());
                    MessageBox.Show("Cập nhật danh mục thành công");
                    ReloadDTGV();
                }
                else
                {
                    MessageBox.Show("Sản phẩm này không tồn tại ");
                }
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            if (CheckValueCategory())
            {
                string check = txtIDCat.Text;
                var delete = context.CLOTHINGCATEGORies.FirstOrDefault(p => p.MALOAI == check);
                if (delete != null)
                {
                    DialogResult dia = MessageBox.Show("Bạn có muốn xóa !", "Thông báo", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == dia)
                    {
                        if (deleteChildOfCategory != null)
                            deleteChildOfCategory(this, new EventArgs());
                        context.CLOTHINGCATEGORies.Remove(delete);
                        context.SaveChanges();
                        LoadDataCategoryChange();
                        MessageBox.Show("Xóa dữ liệu thành công !");
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại sản phẩm này");
                }
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        private void btnXemDM_Click(object sender, EventArgs e)
        {
            ReloadDTGV();
        }
        private void dtgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >-1)
            {
                txtIDCat.Text = dtgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNameCat.Text = dtgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("Chọn đúng dòng ");
            }
            
        }

        // thêm xóa sửa Account
        private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtMaNV.Text = dtgvAccount.Rows[e.RowIndex].Cells["IDNHANVIEN"].Value.ToString();
                txtTenNV.Text = dtgvAccount.Rows[e.RowIndex].Cells["FULLNAME"].Value.ToString();
                cbbChucVu.Text = dtgvAccount.Rows[e.RowIndex].Cells["MABOPHANSTAFF"].Value.ToString();
                STAFF dbHinh = context.STAFFs.FirstOrDefault(p => p.IDNHANVIEN == txtMaNV.Text);
                if (dbHinh != null)
                {
                    if (dbHinh.AVATA != null)
                    {
                        ptbImgUser.Image = ByteArrayToImage(dbHinh.AVATA);
                    }
                    else
                    {
                        ptbImgUser.Image = new Bitmap(Application.StartupPath + "\\Resources\\user (3).png");
                    }
                }
            }
        }
        private void btnLoadHinh_Click(object sender, EventArgs e)
        {
            LoadFileImage(ptbImgUser);
        }

        private void ptbImgUser_Click(object sender, EventArgs e)
        {
            LoadFileImage(ptbImgUser);
        }
        private void btnXoaAcc_Click(object sender, EventArgs e)
        {
            if (CheckValueAccount())
            {
                STAFF dbDelete = context.STAFFs.FirstOrDefault(p => p.IDNHANVIEN == txtMaNV.Text);
                if (dbDelete != null)
                {
                    if (EventDeleteAcc != null)
                    {
                        if (EventDeleteAcc(this, dbDelete.IDNHANVIEN) == 0)
                        {
                            context.STAFFs.Remove(dbDelete);
                            context.SaveChanges();
                            BindGirdAccount(context.STAFFs.ToList());
                            ResetTxtAcc();
                            MessageBox.Show("Xóa thành công");
                        }
                        else// bằng -1
                        {
                            MessageBox.Show("Không được xóa");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại người này");
                }
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        private void btnSuaAcc_Click(object sender, EventArgs e)
        {
            if (CheckValueAccount())
            {
                if (GetSelectedAccount(txtMaNV.Text) != -1)
                {
                    STAFF dbUpdateStaff = context.STAFFs.FirstOrDefault(p => p.IDNHANVIEN == txtMaNV.Text);
                    if (dbUpdateStaff != null)
                    {
                        dbUpdateStaff.FULLNAME = txtTenNV.Text;
                        dbUpdateStaff.MABOPHANSTAFF = cbbChucVu.SelectedValue.ToString();
                        if (ptbImgUser.Image != null)
                            dbUpdateStaff.AVATA = ImageToByteArray(ptbImgUser.Image);
                        context.SaveChanges();
                        if (accountManagerUpdate != null)
                            accountManagerUpdate(this, new AccountEvent(dbUpdateStaff.IDNHANVIEN));
                        BindGirdAccount(context.STAFFs.ToList());
                        MessageBox.Show("Cập nhật thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại mã nhân viên");
                }
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }
        private void btnXemAcc_Click(object sender, EventArgs e)
        {
            BindGirdAccount(context.STAFFs.ToList());
            ResetTxtAcc();
        }
        // Chuyển trang sales
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (dtgvSales.Rows.Count > 0)
            {
                txtNumberPage.Text = "1";
            }
        }
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (dtgvSales.Rows.Count > 0)
            {
                int page = Convert.ToInt32(txtNumberPage.Text);
                if (page > 1)
                    page--;
                txtNumberPage.Text = page.ToString();
            }
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (dtgvSales.Rows.Count > 0)
            {
                int sumRecod = context.BILLs.Count();
                int lastPage = sumRecod / 10;
                int page = Convert.ToInt32(txtNumberPage.Text);
                if (sumRecod % 10 != 0)
                    lastPage++;
                if (page < lastPage)
                    page++;
                txtNumberPage.Text = page.ToString();
            }
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (dtgvSales.Rows.Count > 0)
            {
                int sumRecod = context.BILLs.Count();
                int lastPage = sumRecod / 10;
                if (sumRecod % 10 != 0)
                    lastPage++;
                txtNumberPage.Text = lastPage.ToString();
            }
        }
        private void txtNumberPage_TextChanged(object sender, EventArgs e)
        {
            if (dtgvSales.Rows.Count > 0)
            {
                int page = Convert.ToInt32(txtNumberPage.Text);
                List<BILL> lisyBill = context.BILLs.OrderBy(p => p.TOTALPRICE).Take(10 * page).Skip((10 * page) - 10).ToList();
                BindGirdSales(lisyBill);
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadSales();
        }
        private void btnOutReport_Click(object sender, EventArgs e)
        {
            FReportThongKeDoanhThu f = new FReportThongKeDoanhThu();
            f.ShowDialog();
        }
        // Event
        private void FAdmin_DeleteClothing(object sender, EventArgs e)
        {
            if (deleteCategoryManager != null)
                deleteCategoryManager(this, new IDClothingEvent(txtIDClothing.Text));
            List<CLOTHINGINFO> listDeleteCLTSize = context.CLOTHINGINFOes.Where(p => p.MAQUANAOCLOTHINGINFO == txtIDClothing.Text).ToList();
            if (listDeleteCLTSize.Count > 0)
            {
                foreach (CLOTHINGINFO size in listDeleteCLTSize)
                {
                    List<BILLINFO> listDeleteBillInfo = context.BILLINFOes.Where(p => p.IDSIZE == size.ID).ToList();
                    foreach (BILLINFO item in listDeleteBillInfo)
                    {
                        item.IDSIZE = null;
                        item.MAQUANAO = null;
                        context.SaveChanges();
                    }
                    context.CLOTHINGINFOes.Remove(size);
                    context.SaveChanges();
                }
            }
            else
            {
                List<BILLINFO> listDeleteBillInfo = context.BILLINFOes.Where(p => p.MAQUANAO == txtIDClothing.Text).ToList();
                foreach (BILLINFO item in listDeleteBillInfo)
                {
                    item.MAQUANAO = null;
                    context.SaveChanges();
                }
            }
        }
        private void FAdmin_DeleteChildOfCategory(object sender, EventArgs e)
        {
            List<CLOTHING> listDeleteClothing = context.CLOTHINGs.Where(p => p.MALOAICLOTHING == txtIDCat.Text).ToList();
            if (listDeleteClothing.Count > 0)
            {
                foreach (CLOTHING clothing in listDeleteClothing)
                {
                    if (deleteCategoryManager != null)
                        deleteCategoryManager(this, new IDClothingEvent(clothing.MAQUANAO));
                    List<CLOTHINGINFO> listDeleteCLTSize = context.CLOTHINGINFOes.Where(p => p.MAQUANAOCLOTHINGINFO == clothing.MAQUANAO).ToList();
                    if (listDeleteCLTSize.Count > 0)
                    {
                        foreach (CLOTHINGINFO size in listDeleteCLTSize)
                        {
                            List<BILLINFO> listDeleteBillInfo = context.BILLINFOes.Where(p => p.IDSIZE == size.ID).ToList();
                            foreach (BILLINFO item in listDeleteBillInfo)
                            {
                                item.IDSIZE = null;
                                item.MAQUANAO = null;
                                context.SaveChanges();
                            }
                            context.CLOTHINGINFOes.Remove(size);
                            context.SaveChanges();
                        }
                        context.CLOTHINGs.Remove(clothing);
                        context.SaveChanges();
                    }
                    else
                    {
                        context.CLOTHINGs.Remove(clothing);
                        context.SaveChanges();
                    }
                }
            }
        }
        private void FAdmin_InsertCategory(object sender, EventArgs e)
        {
            cbbCategory.DataSource = context.CLOTHINGCATEGORies.ToList();
            cbbCategory.DisplayMember = "TENLOAI";
            cbbCategory.ValueMember = "MALOAI";
        }

        

        #endregion

        #region eventHandler

        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }
        private event EventHandler insertCategoryManager;
        public event EventHandler InsertCategoryManager
        {
            add { insertCategoryManager += value; }
            remove { insertCategoryManager += value; }
        }
        private event EventHandler deleteChildOfCategory;
        public event EventHandler DeleteChildOfCategory
        {
            add { deleteChildOfCategory += value; }
            remove { deleteChildOfCategory += value; }
        }
        private event EventHandler<IDClothingEvent> deleteCategoryManager;
        public event EventHandler<IDClothingEvent> DeleteCategoryManager
        {
            add { deleteCategoryManager += value; }
            remove { deleteCategoryManager -= value; }
        }
        private event EventHandler<IDClothingEvent> deleteSize;
        public event EventHandler<IDClothingEvent> DeleteSize
        {
            add { deleteSize += value; }
            remove { deleteSize -= value; }
        }
        private event EventHandler<AccountEvent> accountManagerUpdate;
        public event EventHandler<AccountEvent> AccountManagerUpdate
        {
            add { accountManagerUpdate += value; }
            remove { accountManagerUpdate -= value; }
        }

        public delegate int HandlerDelete(object ojb, String maNV);
        public event HandlerDelete EventDeleteAcc;

        private event EventHandler insertClothing;
        public event EventHandler InsertClothing
        {
            add { insertClothing += value; }
            remove { insertClothing += value; }
        }

        private event EventHandler updateClothing;
        public event EventHandler UpdateClothing
        {
            add { updateClothing += value; }
            remove { updateClothing -= value; }
        }

        private event EventHandler deleteClothing;
        public event EventHandler DeleteClothing
        {
            add { deleteClothing += value; }
            remove { deleteClothing -= value; }
        }

        private event EventHandler insertClothingInfo;
        public event EventHandler InsertClothingInfo
        {
            add { insertClothingInfo += value; }
            remove { insertClothingInfo -= value; }
        }
        private event EventHandler updateClothingInfo;
        public event EventHandler UpdateClothingInfo
        {
            add { updateClothingInfo += value; }
            remove { updateClothingInfo -= value; }
        }


        #endregion

        

        public class IDClothingEvent : EventArgs
        {
            public string IDClothing { get; set; }
            public int IdSize { get; set; }
            public IDClothingEvent(string iDClothing)
            {
                this.IDClothing = iDClothing;
            }
            public IDClothingEvent(string iDClothing, int id)
            {
                this.IDClothing = iDClothing;
                this.IdSize = id;
            }
        }
        public class AccountEvent : EventArgs
        {
            public string MaNV { get; set; }
            public AccountEvent(string maNV)
            {
                this.MaNV = maNV;
            }
        }

       
    }

}
