using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAcceptanceRequest.Exceptions
{
    public class RequestFailedException : Exception
    {
        public RequestFailedException(Exception ex)
            : base("Request Failed", ex)
        {
        }
    }
}
