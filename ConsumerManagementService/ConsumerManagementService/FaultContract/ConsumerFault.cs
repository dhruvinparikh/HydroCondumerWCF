using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerManagementService
{
    [DataContract]
    class ConsumerFault
    {
        [DataMember]
        public String Error { get; set; }
        [DataMember]
        public String Details { get; set; }
        [DataMember]
        public String consumerID { get; set; }
        [DataMember]
        public String firstName { get; set; }
        [DataMember]
        public String lastName { get; set; }
        [DataMember]
        public String billAmount { get; set; }
        [DataMember]
        public String city { get; set; }
        [DataMember]
        public String dueDate { get; set; }
    }
}
