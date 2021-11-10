using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSellManager.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        private string connectionSTR = @"Data Source=QUOCTRON;Initial Catalog=ClothingSellManager;Integrated Security=True";
        SqlConnection connection = new SqlConnection();
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            set => instance = value; 
        }
        private DataProvider() { }

        // lấy ra các dòng select
        // lấy ra bảng 
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            connection = new SqlConnection(connectionSTR);
            connection.Open();
            SqlCommand command = new SqlCommand(query,connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        // lấy số dòng được thực thi
        public int ExcuteNonQuery(string query)
        {
            int data = 0;
            connection = new SqlConnection(connectionSTR);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            data = command.ExecuteNonQuery();
            connection.Close();
            return data;
        }

        // trả ra số dòng
        public object ExcuteScalar(string query)
        {
            object data = "";
            connection = new SqlConnection(connectionSTR);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            data = command.ExecuteScalar();
            connection.Close();
            return data;
        }
    }
}
