using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using ConsumerManagementService.DBUtil;
using ConsumerManagementService.Exceptions;
using ConsumerManagementService.Model;

namespace ConsumerManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ConsumerManagementService : IConsumerManagementService
    {
        public int add(Consumer consumer)
        {
            bool valid = true;
            ConsumerFault fault = new ConsumerFault();
            fault.Error = "";
            fault.Details = "";
            fault.consumerID = "";
            fault.firstName = "";
            fault.lastName = "";
            fault.city = "";
            fault.billAmount = "";
            fault.dueDate = "";

            Consumer c = new Consumer();

            try
            {
                c.setConsumerID(consumer.ConsumerID);
            }
            catch (Exception obj)
            {
                valid = false;
                fault.consumerID = obj.Message;
            }

            try
            {
                c.setFirstName(consumer.FirstName);
            }
            catch(Exception obj)
            {
                valid = false;
                fault.firstName = obj.Message;
            }

            try
            {
                c.setLastName(consumer.LastName);
            }
            catch (Exception obj)
            {
                valid = false;
                fault.lastName = obj.Message;
            }

            try
            {
                c.setCity(consumer.City);
            }
            catch(Exception obj)
            {
                valid = false;
                fault.city = obj.Message;
            }

            try
            {
                c.BillAmount = consumer.BillAmount;
            }
            catch(Exception obj)
            {
                valid = false;
                fault.billAmount = obj.Message;
            }

            try
            {
                c.DueDate = consumer.DueDate;
            }
            catch(Exception obj)
            {
                valid = false;
                fault.dueDate = obj.Message;
            }

            if (!valid)
            {
                fault.Error = "Invalid";
                fault.Details = "Form not submitted";
                DBUtil.DBUtil.closeSqlConnection();
                throw new FaultException<ConsumerFault>(fault);
            }

            int count = 0;
            try
            {
                new Consumer().setConsumerID(consumer.ConsumerID);
                count = ConsumerDB.add(consumer);
                if(count == 0)
                {
                    throw new Exception("Primary key exception");
                }
                DBUtil.DBUtil.closeSqlConnection();
            }
            
            catch (Exception obj)
            {
                DBUtil.DBUtil.closeSqlConnection();
                fault.Error = "Invalid";
                fault.Details = "No record inserted";
                throw new FaultException<ConsumerFault>(fault);
            }
            return count;
        }

        public int deleteID(string id)
        {
            ConsumerFault fault = new ConsumerFault();
            int c = ConsumerDB.deleteID(id);
            DBUtil.DBUtil.closeSqlConnection();
            if (!(c > 0))
            {
                fault.Error = "Delete error";
                fault.Details = "Unable to delete";
                throw new FaultException<ConsumerFault>(fault);
            }
            return c;
        }

        public List<Consumer> getAll()
        {
            List<Consumer> list = ConsumerDB.getAll();
            DBUtil.DBUtil.closeSqlConnection();
            return list;
        }

        public List<Consumer> getConsumerByBA(String billAmount,String condition)
        {
            double amount = 0.0;
            ConsumerFault fault = new ConsumerFault();
            try
            {
                amount = Convert.ToDouble(billAmount);
                if(amount < 0)
                {
                    throw new Exception("Negative value found");
                }
            }
            catch (FormatException ex)
            {
                fault.Error = ex.Message;
                fault.Details = "Not a valid bill amount";
                throw new FaultException<ConsumerFault>(fault);
            }
            catch (OverflowException ex)
            {
                fault.Error = ex.Message;
                fault.Details = "Ammount should be in legal limits";
                throw new FaultException<ConsumerFault>(fault);
            }
            catch(Exception ex)
            {
                fault.Error = ex.Message;
                fault.Details = "Non-negative values permitted";
                throw new FaultException<ConsumerFault>(fault);
            }
            List<Consumer> list = ConsumerDB.getConsumerByBA(amount,condition);
            DBUtil.DBUtil.closeSqlConnection();
            if (!(list.Count > 0))
            {
                fault.Error = "No Data";
                fault.Details = "No Record found";
                throw new FaultException<ConsumerFault>(fault);
            }
            return list;
        }

        public List<Consumer> getConsumerCity(string strName)
        {
            List<Consumer> list = ConsumerDB.getConsumerCity(strName);
            DBUtil.DBUtil.closeSqlConnection();
            return list;
        }

        public List<Consumer> getConsumerCityLike(string strName)
        {
            ConsumerFault fault = new ConsumerFault();
            List<Consumer> list = ConsumerDB.getConsumerCityLike(strName);
            DBUtil.DBUtil.closeSqlConnection();
            if (!(list.Count > 0))
            {
                fault.Error = "No Data";
                fault.Details = "No Record found";
                throw new FaultException<ConsumerFault>(fault);
            }
            return list;
        }

        public List<Consumer> getConsumerFirstName(string strName)
        {
            List<Consumer> list = ConsumerDB.getConsumerFirstName(strName);
            DBUtil.DBUtil.closeSqlConnection();
            return list;
        }

        public List<Consumer> getConsumerFirstNameLike(string strName)
        {
            ConsumerFault fault = new ConsumerFault();
            List<Consumer> list = ConsumerDB.getConsumerFirstNameLike(strName);
            DBUtil.DBUtil.closeSqlConnection();
            if (!(list.Count > 0))
            {
                fault.Error = "No Data";
                fault.Details = "No Record found";
                throw new FaultException<ConsumerFault>(fault);
            }
            return list;
        }

        public List<Consumer> getConsumerID(string id)
        {
            Consumer consumer = new Consumer();
            ConsumerFault fault = new ConsumerFault();
            try
            {
                consumer.setConsumerID(Convert.ToInt64(id));
            }
            catch (ConsumerIDException ex)
            {
                fault.Error = ex.Message;
                fault.Details = "Consumer ID must be 11 digits";
                throw new FaultException<ConsumerFault>(fault);
            }
            catch(OverflowException ex)
            {
                fault.Error = ex.Message;
                fault.Details = "Consumer ID must be 11 digits";
                throw new FaultException<ConsumerFault>(fault);
            }
            catch(FormatException ex)
            {
                fault.Error = ex.Message;
                fault.Details = "numeric values expected for Consumer ID";
                throw new FaultException<ConsumerFault>(fault);
            }
            List<Consumer> list = ConsumerDB.getConsumerID(id);
            DBUtil.DBUtil.closeSqlConnection();
            if (!(list.Count > 0))
            {
                fault.Error = "No Data";
                fault.Details = "No Record found";
                throw new FaultException<ConsumerFault>(fault);
            }
            return list;
        }

        public List<Consumer> getConsumerLastLike(string strName)
        {
            ConsumerFault fault = new ConsumerFault();
            List<Consumer> list = ConsumerDB.getConsumerLastNameLike(strName);
            DBUtil.DBUtil.closeSqlConnection();
            if (!(list.Count > 0))
            {
                fault.Error = "No Data";
                fault.Details = "No Record found";
                throw new FaultException<ConsumerFault>(fault);
            }
            return list;
        }

        public List<Consumer> getConsumerLastName(string strName)
        {
            List<Consumer> list = ConsumerDB.getConsumerLastName(strName);
            DBUtil.DBUtil.closeSqlConnection();
            return list;
        }

        public List<Consumer> getDefaulter(DateTime date)
        {
            ConsumerFault fault = new ConsumerFault();
            List<Consumer> list = ConsumerDB.getDefaulter(date);
            DBUtil.DBUtil.closeSqlConnection();
            if (!(list.Count > 0))
            {
                fault.Error = "No Data";
                fault.Details = "No Record found";
                throw new FaultException<ConsumerFault>(fault);
            }
            return list;
        }

        public List<Consumer> getRegular(DateTime date)
        {
            ConsumerFault fault = new ConsumerFault();
            List<Consumer> list = ConsumerDB.getRegular(date);
            DBUtil.DBUtil.closeSqlConnection();
            if (!(list.Count > 0))
            {
                fault.Error = "No Data";
                fault.Details = "No Record found";
                throw new FaultException<ConsumerFault>(fault);
            }
            return list;
        }

        public int addLogin(Login login)
        {
            int count = LoginDB.add(login);
            DBUtil.DBUtil.closeSqlConnection();
            return count;
        }

        public int authenticate(Login login)
        {
            int count = 0;
            ConsumerFault fault = new ConsumerFault();
            try
            {
                count = LoginDB.authenticate(login);
                DBUtil.DBUtil.closeSqlConnection();
            }
            catch(Exception e)
            {
                fault.Error = e.ToString();
                fault.Details = e.Message;
                throw new FaultException<ConsumerFault>(fault);
            }
            if (!(count > 0))
            {
                fault.Error = "Username/password";
                fault.Details = "Username and password combination does not match";
                throw new FaultException<ConsumerFault>(fault);
            }
            return count;
        }

        public int updatePassword(Login login)
        {
            int count = LoginDB.updatePassword(login);
            DBUtil.DBUtil.closeSqlConnection();
            return count;
        }

        public List<Login> getAllLogin()
        {
            List<Login> list = LoginDB.getAll();
            DBUtil.DBUtil.closeSqlConnection();
            return list;
        }

        public int updateConsumer(Consumer consumer)
        {
            bool valid = true;
            ConsumerFault fault = new ConsumerFault();
            fault.Error = "";
            fault.Details = "";
            fault.consumerID = "";
            fault.firstName = "";
            fault.lastName = "";
            fault.city = "";
            fault.billAmount = "";
            fault.dueDate = "";

            Consumer c = new Consumer();

            try
            {
                c.setFirstName(consumer.FirstName);
            }
            catch (Exception obj)
            {
                valid = false;
                fault.firstName = obj.Message;
            }

            try
            {
                c.setLastName(consumer.LastName);
            }
            catch (Exception obj)
            {
                valid = false;
                fault.lastName = obj.Message;
            }

            try
            {
                c.setCity(consumer.City);
            }
            catch (Exception obj)
            {
                valid = false;
                fault.city = obj.Message;
            }

            try
            {
                c.BillAmount = consumer.BillAmount;
            }
            catch (Exception obj)
            {
                valid = false;
                fault.billAmount = obj.Message;
            }

            try
            {
                c.DueDate = consumer.DueDate;
            }
            catch (Exception obj)
            {
                valid = false;
                fault.dueDate = obj.Message;
            }

            if (!valid)
            {
                fault.Error = "Invalid";
                fault.Details = "Form not updated";
                DBUtil.DBUtil.closeSqlConnection();
                throw new FaultException<ConsumerFault>(fault);
            }
            int count = ConsumerDB.updateConsumer(consumer);
            DBUtil.DBUtil.closeSqlConnection();
            if(!(count > 0))
            {
                fault.Error = "Update error";
                fault.Details = "Updation failed";
                throw new FaultException<ConsumerFault>(fault);
            }
            return count;
        }
    }
}
