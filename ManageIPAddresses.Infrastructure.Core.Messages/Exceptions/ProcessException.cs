using System;

namespace ManageIPAddresses.Infrastructure.Core.Messages.Exceptions
{
    public class ProcessException : Exception
    {
        public ProcessException(string message) :base(message)
        {
            
        }
    }
}