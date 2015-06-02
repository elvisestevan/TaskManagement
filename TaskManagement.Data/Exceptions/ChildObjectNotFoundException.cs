using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.Exceptions
{
    public class ChildObjectNotFoundException : Exception 
    {
        public ChildObjectNotFoundException(string message)
            : base(message)
        {

        }
    }
}
