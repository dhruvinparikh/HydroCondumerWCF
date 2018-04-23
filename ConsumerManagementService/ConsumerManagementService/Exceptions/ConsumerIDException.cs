using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerManagementService.Exceptions
{
    class ConsumerIDException : Exception
    {
        public ConsumerIDException()
            : this("Wrong consumer ID format")
        {
        }

        public ConsumerIDException(String message) : base(message)
        {

        }
    }
}
