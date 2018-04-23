using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerManagementHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost
                (typeof(ConsumerManagementService.ConsumerManagementService)))
            {
                host.Open();
                Console.WriteLine("Host started, Press any key to stop...");
                Console.ReadLine();
            }
        }
    }
}
