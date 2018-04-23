using ConsumerManagementService.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerManagementService.DBUtil
{
    class LoginDB
    {
        public static List<Login> getAll()
        {
            List<Login> logins = new List<Login>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "select * from login";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = DBUtil.getSqlConnection();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Login login = new Login();
                login.Username = reader[0].ToString();
                login.Password = reader[1].ToString();
                logins.Add(login);
            }
            return logins;
        }

        public static int updatePassword(Login login)
        {
            SqlCommand sqlCommand = new SqlCommand("update login set password = @id where username = @fn", DBUtil.getSqlConnection());
            sqlCommand.Parameters.AddWithValue("@id", login.Password);
            sqlCommand.Parameters.AddWithValue("@fn", login.Username);
            return sqlCommand.ExecuteNonQuery();
        }

        public static int add(Login login)
        {
            SqlCommand sqlCommand = new SqlCommand("insert into login values (@id,@fn)", DBUtil.getSqlConnection());
            sqlCommand.Parameters.AddWithValue("@id", login.Username);
            sqlCommand.Parameters.AddWithValue("@fn", login.Password);
            return sqlCommand.ExecuteNonQuery();
        }

        public static int authenticate(Login login)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from login where username = @u and password = @p", DBUtil.getSqlConnection());
            sqlCommand.Parameters.AddWithValue("@u", login.Username);
            sqlCommand.Parameters.AddWithValue("@p", login.Password);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            return count;
        }
    }
}
