using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSellManager.DTO
{
    public class MenuBillDTO
    {
       

        public string TenQuanAo { get; set; }
        public string Size { get; set; }
        public int SoLuong { get; set; }
        public double Price { get; set; }
        public double ThanhTien { get; set; }

        public MenuBillDTO(string tenQuanAo, string size, int soLuong, double price, double thanhTien)
        {
            TenQuanAo = tenQuanAo;
            Size = size;
            SoLuong = soLuong;
            Price = price;
            ThanhTien = thanhTien;
        }


        public MenuBillDTO(DataRow row)
        {
            TenQuanAo = row["TENQUANAO"].ToString();
            Size = row["SIZE"].ToString();
            SoLuong = (int)row["SOLUONG"];
            Price = (double)row["PRICE"];
            ThanhTien = (double)Convert.ToDouble(row["totalPrice"].ToString());
        }
    }
}
