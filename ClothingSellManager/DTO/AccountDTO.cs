using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSellManager.DTO
{
    public class AccountDTO
    {
        private string idNhanVien;
        private string fullName;
        private string maBoPhan;
        private string passWord;

        public string IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string MaBoPhan { get => maBoPhan; set => maBoPhan = value; }
        public string PassWord { get => passWord; set => passWord = value; }

        public AccountDTO(string idNhanVien , string fullName , string maBoPhan , string passWord)
        {
            this.IdNhanVien = idNhanVien;
            this.FullName = fullName;
            this.MaBoPhan = maBoPhan;
            this.PassWord = passWord;
        }

        public AccountDTO(DataRow row)
        {
            this.IdNhanVien = row["idNhanVien"].ToString(); 
            this.FullName = row["fullName"].ToString(); 
            this.MaBoPhan = row["maBoPhanStaff"].ToString();
            this.PassWord = row["passWord"].ToString(); 
        }
    }
}
