using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    internal class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=MONKEY\SQLEXPRESS;Initial Catalog=finance;Integrated Security=True");

        public void OpenConnection()// Метод для открытия соединения с базой данных
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void CloseConnection() // Метод для закрытия соединения с базой данных
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection GetConnection()// Метод для получения текущего соединения
        {
            return sqlConnection;
        }
    }
}
