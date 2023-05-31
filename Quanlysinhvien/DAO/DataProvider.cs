using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class DataProvider
    {
        static string provider = @"Data Source=DANGQUANG\DQ;Initial Catalog=QLSV;Integrated Security=True";
        SqlConnection connect = new SqlConnection(provider);

        public DataTable GetData(string sql)
        {
            DataTable rs = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);
            adapter.Fill(rs);
            return rs;
        }
        public void Excute(string sql)
        {
            connect.Open();
            SqlCommand command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
            connect.Close();
        }
    }
}
