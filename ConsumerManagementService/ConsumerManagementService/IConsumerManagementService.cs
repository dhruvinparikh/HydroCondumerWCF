using ConsumerManagementService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsumerManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IConsumerManagementService
    {
        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        int add(Consumer consumer);

        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        List<Consumer> getConsumerID(String id);

        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        List<Consumer> getConsumerFirstNameLike(String strName);

        [OperationContract]
        List<Consumer> getConsumerFirstName(String strName);

        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        List<Consumer> getConsumerLastLike(String strName);

        [OperationContract]
        List<Consumer> getConsumerLastName(String strName);

        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        List<Consumer> getConsumerCityLike(String strName);

        [OperationContract]
        List<Consumer> getConsumerCity(String strName);

        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        List<Consumer> getDefaulter(DateTime date);

        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        List<Consumer> getRegular(DateTime date);

        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        List<Consumer> getConsumerByBA(String billAmount,String condition);

        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        int updateConsumer(Consumer consumer);

        [OperationContract]
        List<Consumer> getAll();

        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        int deleteID(String id);

        [OperationContract]
        List<Login> getAllLogin();

        [OperationContract]
        int updatePassword(Login login);

        [OperationContract]
        int addLogin(Login login);

        [FaultContract(typeof(ConsumerFault))]
        [OperationContract]
        int authenticate(Login login);

    }
}
