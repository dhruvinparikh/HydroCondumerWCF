using ConsumerManagementService.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerManagementService.DBUtil
{
    class ConsumerDB
    {
        public static int add(Consumer consumer)
        {
            SqlCommand sqlCommand = new SqlCommand("insert into consumer values (@id,@fn,@ln,@cn,@ba,@d,@p)", DBUtil.getSqlConnection());
            sqlCommand.Parameters.AddWithValue("@id", consumer.ConsumerID);
            sqlCommand.Parameters.AddWithValue("@fn", consumer.FirstName);
            sqlCommand.Parameters.AddWithValue("@ln", consumer.LastName);
            sqlCommand.Parameters.AddWithValue("@cn", consumer.City);
            sqlCommand.Parameters.AddWithValue("@ba", consumer.BillAmount);
            sqlCommand.Parameters.AddWithValue("@d", consumer.DueDate);
            sqlCommand.Parameters.AddWithValue("@p", 0);
            return sqlCommand.ExecuteNonQuery();
        }

        public static List<Consumer> getConsumerID(String id)
        {
            String sql = "select* from consumer where consumerid like '" + id + "%'";
            return getStudent(new SqlCommand(sql, DBUtil.getSqlConnection()));
        }

        public static List<Consumer> getConsumerFirstNameLike(String strName)
        {
            String sql = "select * from consumer where firstname like '" + strName + "%'";
            return getStudent(new SqlCommand(sql, DBUtil.getSqlConnection()));
        }

        public static List<Consumer> getConsumerFirstName(String strName)
        {
            String sql = "select * from consumer where firstname = '" + strName + "'";
            return getStudent(new SqlCommand(sql, DBUtil.getSqlConnection()));
        }

        public static List<Consumer> getConsumerLastNameLike(String strName)
        {
            String sql = "select * from consumer where lastname like '" + strName + "%'";
            return getStudent(new SqlCommand(sql, DBUtil.getSqlConnection()));
        }

        public static List<Consumer> getConsumerLastName(String strName)
        {
            String sql = "select * from consumer where lastname = '" + strName + "'";
            return getStudent(new SqlCommand(sql, DBUtil.getSqlConnection()));
        }

        public static List<Consumer> getConsumerCityLike(String strName)
        {
            String sql = "select * from consumer where city like '" + strName + "%'";
            return getStudent(new SqlCommand(sql, DBUtil.getSqlConnection()));
        }

        public static List<Consumer> getConsumerCity(String strName)
        {
            String sql = "select * from consumer where city = '" + strName + "'";
            return getStudent(new SqlCommand(sql, DBUtil.getSqlConnection()));
        }

        public static List<Consumer> getDefaulter(DateTime date)
        {
            String sql = "select * from consumer where duedate < @d and paid = 0";
            SqlCommand cmd = new SqlCommand(sql, DBUtil.getSqlConnection());
            cmd.Parameters.AddWithValue("@d", date);
            return getStudent(cmd);
        }

        public static List<Consumer> getRegular(DateTime date)
        {
            String sql = "select * from consumer where duedate >= @d and (paid = 1 or paid = 0)";
            SqlCommand cmd = new SqlCommand(sql, DBUtil.getSqlConnection());
            cmd.Parameters.AddWithValue("@d", date);
            return getStudent(cmd);
        }

        public static List<Consumer> getConsumerByBA(Double billAmount,String condition)
        {
            String sql = "select * from consumer where billamount " + condition +" "+ billAmount;
            return getStudent(new SqlCommand(sql, DBUtil.getSqlConnection()));
        }

        public static List<Consumer> getAll()
        {
            String sql = "select * from consumer";
            return getStudent(new SqlCommand(sql, DBUtil.getSqlConnection()));
        }

        public static int deleteID(String id)
        {
            String sql = "delete from consumer where consumerID = '" + id + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, DBUtil.getSqlConnection());
            return sqlCommand.ExecuteNonQuery();
        }

        public static List<Consumer> getStudent(SqlCommand sqlCommand)
        {
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Consumer> consumers = new List<Consumer>();

            while (sqlDataReader.Read())
            {
                Consumer consumer = new Consumer();
                consumer.ConsumerID = Convert.ToInt64(sqlDataReader["CONSUMERID"]);
                consumer.FirstName = sqlDataReader["FIRSTNAME"].ToString();
                consumer.LastName = sqlDataReader["LASTNAME"].ToString();
                consumer.City = sqlDataReader["CITY"].ToString();
                consumer.BillAmount = Convert.ToDouble(sqlDataReader["BILLAMOUNT"]);
                consumer.DueDate = Convert.ToDateTime(sqlDataReader["DUEDATE"]);
                consumers.Add(consumer);
            }
            return consumers;
        }

        public static int updateConsumer(Consumer consumer)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE HydroConsumer.dbo.consumer SET firstname = @fname, lastname = @lname, city = @c, billamount = @bamount where consumerid = @cid", DBUtil.getSqlConnection());
            sqlCommand.Parameters.AddWithValue("@cid", consumer.ConsumerID);
            sqlCommand.Parameters.AddWithValue("@fname", consumer.FirstName);
            sqlCommand.Parameters.AddWithValue("@lname", consumer.LastName);
            sqlCommand.Parameters.AddWithValue("@c", consumer.City);
            sqlCommand.Parameters.AddWithValue("@bamount", consumer.BillAmount);
            //sqlCommand.Parameters.AddWithValue("@ddate", consumer.DueDate);
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
