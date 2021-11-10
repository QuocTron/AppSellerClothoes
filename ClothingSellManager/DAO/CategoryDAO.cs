using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSellManager.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDAO();
                return instance;
            }
            set => instance = value;
        }

        private CategoryDAO() { }

        public DataTable TableCategory()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM CLOTHINGCATEGORY");
            return data;
        }

    }
}
