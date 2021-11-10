using ClothingSellManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSellManager.DAO
{
    public class MenuBillDAO
    {

        private static MenuBillDAO instance;

        public static MenuBillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MenuBillDAO();
                return instance;
            }
            set => instance = value;
        }

        private MenuBillDAO() { }

        public List<MenuBillDTO> GetBillMenu (string maBill)
        {
            DataTable data = new DataTable();
            List<MenuBillDTO> listMenu = new List<MenuBillDTO>();
            string query = string.Format("SELECT   C.TENQUANAO , CF.SIZE , BF.SOLUONG ,CF.PRICE, (BF.SOLUONG*CF.PRICE) AS totalPrice FROM BILL B, CLOTHING C, CLOTHINGINFO CF, BILLINFO BF where  BF.MAQUANAO = C.MAQUANAO and cf.ID = bf.IDSIZE AND B.MABILL = BF.MABILL AND B.TRANGTHAI = 0  AND BF.MABILL = '{0}'", maBill);
            data= DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                MenuBillDTO menuBill = new MenuBillDTO(row);
                listMenu.Add(menuBill);
            }
            return listMenu;
        }
    }
}
