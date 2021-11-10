using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSellManager.DAO
{
    public class ClothingDAO
    {
        private static ClothingDAO instance;

        public static ClothingDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ClothingDAO();
                return instance;
            }
            set => instance = value;
        }

        private ClothingDAO() { }

        public DataTable TableClothingByCategoryID(string maLoai)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(string.Format("SELECT CL.* FROM CLOTHING CL , CLOTHINGCATEGORY CC WHERE CL.MALOAICLOTHING='{0}' AND CL.MALOAICLOTHING=CC.MALOAI", maLoai));
            return data;
        }

    }
}
