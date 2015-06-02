using System;

namespace TaskManagement.Data.Exceptions
{
    public class RootObjectNotFoundException : Exception
    {

        public RootObjectNotFoundException(string message)
            : base(message)
        {

        }
    }
}
