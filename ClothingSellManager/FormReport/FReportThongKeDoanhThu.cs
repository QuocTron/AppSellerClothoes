using ClothingSellManager.ClassObjectForReport;
using ClothingSellManager.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingSellManager.FormReport
{
    public partial class FReportThongKeDoanhThu : Form
    {
        ClothingContext context = new ClothingContext();
        DateTime today = DateTime.Now;
        public FReportThongKeDoanhThu()
        {
            InitializeComponent();
            LoadDateNow();
        }
        private void LoadDateNow()
        {
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        private void FReportThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            this.rpvThongKe.Visible = false;
        }
        private void btnXuatTheoNgay_Click(object sender, EventArgs e)
        {
            this.rpvThongKe.Visible = true;
            List<BILL> listHoaDon = context.BILLs.Where(p => p.TRANGTHAI == 1 && DbFunctions.TruncateTime(p.GIORA) >= DbFunctions.TruncateTime(dtpkFromDate.Value) && DbFunctions.TruncateTime(p.GIORA) <= DbFunctions.TruncateTime(dtpkToDate.Value)).OrderBy(p => p.TOTALPRICE).ToList();
            ReportParameter[] param = new ReportParameter[2];
            DateTime dateOutReport = new DateTime(today.Year, today.Month, today.Day);
            param[0] = new ReportParameter("Nam", dateOutReport.ToString("MM"));
            param[1] = new ReportParameter("Date", dateOutReport.ToString("dd/MM/yyyy"));
            List<ClassReportDoanhThu> listReportDoanhThu = new List<ClassReportDoanhThu>();
            foreach (var bill in listHoaDon)
            {
                ClassReportDoanhThu doanhThu = new ClassReportDoanhThu();
                DateTime dateTime = (DateTime)bill.GIORA;
                doanhThu.MaBill = bill.MABILL;
                doanhThu.GioRa = dateTime.ToString("dd/MM/yyyy");
                doanhThu.TrangThai = "Đã Thanh toán";
                doanhThu.Discount = bill.DISCOUNT;
                doanhThu.ThanhTien = bill.TOTALPRICE;
                doanhThu.KhachHang = bill.STT == null ? "Khách không cho" : bill.CLIENT.HOTENKH;
                doanhThu.NhanVien = bill.MANHAVIEN == null ? "Đã nghỉ" : bill.STAFF.FULLNAME;
                listReportDoanhThu.Add(doanhThu);
            }
            this.rpvThongKe.LocalReport.ReportPath = "ReportDoanhThu.rdlc";
            var source = new ReportDataSource("DataSetDoanhThu", listReportDoanhThu);
            if (param != null)
                this.rpvThongKe.LocalReport.SetParameters(param);
            this.rpvThongKe.LocalReport.DataSources.Clear();
            this.rpvThongKe.LocalReport.DataSources.Add(source);
            this.rpvThongKe.RefreshReport();
        }
        private void btnClientBuyBest_Click(object sender, EventArgs e)
        {
            this.rpvThongKe.Visible = true;
            this.rpvThongKe.Visible = true;
            List<BILL> listHoaDon = context.BILLs.Where(p => p.TRANGTHAI == 1 && p.STT != null).OrderBy(p => p.TOTALPRICE).ToList();
            List<ClassClientBuyBest> listClient = new List<ClassClientBuyBest>();
            foreach (BILL client in listHoaDon)
            {
                ClassClientBuyBest classClient = new ClassClientBuyBest();
                classClient.STT = (int)client.STT;
                classClient.HoTen = client.CLIENT.HOTENKH;
                classClient.SDT = client.CLIENT.SDT;
                listClient.Add(classClient);
            }
            ReportParameter[] param = new ReportParameter[2];
            DateTime dateOutReport = new DateTime(today.Year, today.Month, today.Day);
            param[0] = new ReportParameter("Day", dateOutReport.ToString("MM"));
            param[1] = new ReportParameter("Date", dateOutReport.ToString("dd/MM/yyyy"));
            this.rpvThongKe.LocalReport.ReportPath = "ReportBuyBest.rdlc";
            var source = new ReportDataSource("DataSetBuyBest", listClient);
            if (param != null)
                this.rpvThongKe.LocalReport.SetParameters(param);
            this.rpvThongKe.LocalReport.DataSources.Clear();
            this.rpvThongKe.LocalReport.DataSources.Add(source);
            this.rpvThongKe.RefreshReport();
        }
        private void btnBestProduct_Click(object sender, EventArgs e)
        {
            this.rpvThongKe.Visible = true;
            ProductBestSell();
        }
        private void ProductBestSell()
        {
            List<BILLINFO> listProduct = context.BILLINFOes.Where(p => p.MAQUANAO != null && p.IDSIZE!=null).ToList();
            List<ClassBestProduct> listBestProduct = new List<ClassBestProduct>();
            foreach (BILLINFO product in listProduct)
            {
                ClassBestProduct best = new ClassBestProduct();
                best.MaQuanAo = product.MAQUANAO;
                best.ProductName = product.CLOTHING.TENQUANAO;
                best.CategoryName = product.CLOTHINGINFO.SIZE;
                listBestProduct.Add(best);
                ReportParameter[] param = new ReportParameter[2];
                DateTime dateOutReport = new DateTime(today.Year, today.Month, today.Day);
                param[0] = new ReportParameter("Day", dateOutReport.ToString("MM"));
                param[1] = new ReportParameter("Date", dateOutReport.ToString("dd/MM/yyyy"));
                this.rpvThongKe.LocalReport.ReportPath = "ReportBestProduct.rdlc";
                var source = new ReportDataSource("DataSetBestProduct", listBestProduct);
                if (param != null)
                    this.rpvThongKe.LocalReport.SetParameters(param);
                this.rpvThongKe.LocalReport.DataSources.Clear();
                this.rpvThongKe.LocalReport.DataSources.Add(source);
                this.rpvThongKe.RefreshReport();
            }
        }
    }
}
