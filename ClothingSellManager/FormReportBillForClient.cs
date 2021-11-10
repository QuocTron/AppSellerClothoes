using ClothingSellManager.ClassObjectForReport;
using ClothingSellManager.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ClothingSellManager
{
   
    public partial class FormReportBillForClient : Form
    {
        string maBillOfClient = "";
        ClothingContext context = new ClothingContext();
        CultureInfo culture = new CultureInfo("vi-VN");
        public FormReportBillForClient(string maBillFromBillMgn)
        {
            InitializeComponent();
            maBillOfClient = maBillFromBillMgn;
        }

        private void FormReportBillForClient_Load(object sender, EventArgs e)
        {
            BILL dbBillForReport = context.BILLs.FirstOrDefault(p=>p.MABILL==maBillOfClient);
            List<BILLINFO> listBillInfo = context.BILLINFOes.Where(p => p.MABILL == maBillOfClient).ToList();
            ReportParameter[] param = new ReportParameter[7];
            if (dbBillForReport != null)
            {
                DateTime dateBuy = (DateTime)dbBillForReport.GIORA;
                param[0] = new ReportParameter("Client", dbBillForReport.CLIENT.HOTENKH.ToString());
                param[1] = new ReportParameter("MaBill", dbBillForReport.MABILL.ToString());
                param[2] = new ReportParameter("Date", string.Format(dateBuy.ToString("dd/MM/yyyy") +"  -  "+ dateBuy.ToString("hh:mm")));
                param[3] = new ReportParameter("Staff", dbBillForReport.STAFF.FULLNAME.ToString());
                param[4] = new ReportParameter("SoLuong", dbBillForReport.BILLINFOes.Sum(p => p.SOLUONG).ToString());
                param[5] = new ReportParameter("TotalPrice", dbBillForReport.TOTALPRICE.ToString("c", culture));
                param[6] = new ReportParameter("Discount", dbBillForReport.DISCOUNT.ToString());
            }
            List<ClassRpBillOfClient> listBillForClientTest = new List<ClassRpBillOfClient>();
            foreach (var billInfo in listBillInfo)
            {
                ClassRpBillOfClient bill = new ClassRpBillOfClient();
                bill.MatHang = billInfo.CLOTHING.TENQUANAO;
                bill.SoLuong = billInfo.SOLUONG;
                bill.Size = billInfo.CLOTHINGINFO.SIZE;
                bill.DonGia = billInfo.CLOTHINGINFO.PRICE;
                bill.ThanhTien = (billInfo.SOLUONG * billInfo.CLOTHINGINFO.PRICE);
                listBillForClientTest.Add(bill);
            }
            this.rpvBillForClient.LocalReport.ReportPath = "ReportBillOfClient.rdlc";
            if (param != null)
                this.rpvBillForClient.LocalReport.SetParameters(param);
            var source = new ReportDataSource("DataSetBillOfClient", listBillForClientTest);
            rpvBillForClient.LocalReport.DataSources.Clear();
            rpvBillForClient.LocalReport.DataSources.Add(source);
            this.rpvBillForClient.RefreshReport();
        }
    }
}
