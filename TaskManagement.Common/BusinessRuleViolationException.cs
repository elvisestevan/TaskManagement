using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Common
{
    public class BusinessRuleViolationException : Exception
    {
        public BusinessRuleViolationException(string incorrectTaskStatus) :
            base(incorrectTaskStatus) { }
    }
}
