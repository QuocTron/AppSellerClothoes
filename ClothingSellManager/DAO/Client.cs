using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSellManager.DAO
{
    public class Client
    {

        private static Client instance;

        public static Client Instance 
        {
            get
            {
                if (instance == null)
                    instance = new Client();
                return instance;
            }
            set => instance = value; 
        }

        public Client() { }

        public string NameClient(string sdt)
        {
            return (string)DataProvider.Instance.ExcuteScalar(string.Format("SELECT HOTENKH FROM CLIENT WHERE SDT = '{0}'",sdt));
        }
    }
}
