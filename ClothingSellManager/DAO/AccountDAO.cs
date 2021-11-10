using ClothingSellManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSellManager.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            set => instance = value;
        }

        private AccountDAO() { }

        public bool Login(string userName , string passWord)
        {
            string query = string.Format("EXEC USP_Login {0}, {1}", userName, passWord);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        public object NamePosition (string userName)
        {
            return  DataProvider.Instance.ExcuteScalar(string.Format("select P.TENBOPHAN from STAFF S , POSITION P WHERE S.MABOPHANSTAFF=P.MABOPHAN AND S.IDNHANVIEN = '{0}'",userName));
        }

        public AccountDTO GetAccountIDNhanVien(string userName)
        {
            DataTable table = DataProvider.Instance.ExecuteQuery(string.Format("select * from STAFF S  WHERE  S.IDNHANVIEN = '{0}'", userName));
            foreach (DataRow item in table.Rows)
            {
                AccountDTO account = new AccountDTO(item);
                return account;
            }
            return null;
        }
    }
}
