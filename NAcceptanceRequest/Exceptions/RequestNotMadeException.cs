using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAcceptanceRequest.Exceptions
{
    public class RequestNotMadeException : Exception
    {
        public RequestNotMadeException()
            : base("Request must have been made before calling this")
        {
        }
    }
}
