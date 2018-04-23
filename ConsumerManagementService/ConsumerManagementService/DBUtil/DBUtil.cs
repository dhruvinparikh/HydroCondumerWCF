using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerManagementService.DBUtil
{
    class DBUtil
    {
        static SqlConnection sqlConnection;

        public static SqlConnection getSqlConnection()
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLOCALDB;Initial Catalog=HydroConsumer;Integrated Security=True");
            }
            sqlConnection.Open();
            return sqlConnection;
        }

        public static void closeSqlConnection()
        {
            if (sqlConnection != null)
            {
                sqlConnection.Close();
            }
        }
    }
}
